using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Chayns.Backend.Api.Helper;
using Chayns.Backend.Api.Models.Data;
using Chayns.Backend.Api.Models.Data.Base;
using Chayns.Backend.Api.Models.Result;
using Chayns.Backend.Api.Models.Result.Base;
using Newtonsoft.Json;

namespace Chayns.Backend.Api.Controller.Base
{
    internal sealed class WebApiCaller<TResult> where TResult : IApiResult
    {
        internal async Task<Result<TResult>> CallApiAsync<TData>(TData request, IApiController caller, HttpMethod method, int? id = null, [CallerMemberName] string callingFunction = null) where TData : ChangeableData, IApiData
        {
            string url = Config.WEB_API_URL + (string.IsNullOrWhiteSpace(request?.GetLocationIdentifier())? "" : request.GetLocationIdentifier() + "/") + caller.Controller(callingFunction) + (id.HasValue ? ("/" + id) : "");
            Task<string> dataTask = null;
            if (request != null)
            {
                if (method == HttpMethod.Get)
                {
                    dataTask = Task.Factory.StartNew(() => UrlParameterConverter.SerializeObject(request));
                }
                else
                {
                    dataTask = Task.Factory.StartNew(() => JsonConvert.SerializeObject(request));
                }
            }

            string jsonresult = "";
            WebException webException = null;

            using (WebClient wc = new WebClient())
            {
                var credentials = caller.GetCredentials(callingFunction);
                if (credentials != null)
                {
                    wc.Headers.Add(HttpRequestHeader.Authorization,
                        credentials.Scheme() + " " + credentials.Parameter());
                }
                wc.Encoding = Encoding.UTF8;
                wc.Headers.Add(HttpRequestHeader.ContentType, "application/json");

                try
                {
                    if (method == HttpMethod.Get)
                    {
                        jsonresult = await wc.DownloadStringTaskAsync(url + (dataTask == null ? "" : await dataTask));
                    }
                    else
                    {
                        jsonresult = await wc.UploadStringTaskAsync(url, method.Method, (dataTask == null ? "" : await dataTask));
                    }
                }
                catch (WebException wex)
                {
                    webException = wex;
                }
            }

            return ParseResponse(jsonresult, webException);
        }

        internal Result<TResult> CallApi<TData>(TData request, IApiController caller, HttpMethod method, int? id = null, [CallerMemberName] string callingFunction = null) where TData : ChangeableData, IApiData
        {
            string url = Config.WEB_API_URL + (string.IsNullOrWhiteSpace(request?.GetLocationIdentifier()) ? "" : request.GetLocationIdentifier() + "/") + caller.Controller(callingFunction) + (id.HasValue ? ("/" + id) : "");
            string data = "";
            if (request != null)
            {
                if (method == HttpMethod.Get)
                {
                    data = UrlParameterConverter.SerializeObject(request);
                }
                else
                {
                    data = JsonConvert.SerializeObject(request);
                }
            }

            string jsonresult = "";
            WebException webException = null;

            using (WebClient wc = new WebClient())
            {
                var credentials = caller.GetCredentials(callingFunction);
                if (credentials != null)
                {
                    wc.Headers.Add(HttpRequestHeader.Authorization,
                        credentials.Scheme() + " " + credentials.Parameter());
                }
                wc.Encoding = Encoding.UTF8;
                wc.Headers.Add(HttpRequestHeader.ContentType, "application/json");

                try
                {
                    if (method == HttpMethod.Get)
                    {
                        jsonresult = wc.DownloadString(url + data);
                    }
                    else
                    {
                        jsonresult = wc.UploadString(url, method.Method, data);
                    }
                }
                catch (WebException wex)
                {
                    webException = wex;
                }
            }

            return ParseResponse(jsonresult, webException);
        }

        private Result<TResult> ParseResponse(string jsonresult, WebException wex)
        {
            Result<TResult> result;
            if (wex == null)
            {
                result = JsonConvert.DeserializeObject<Result<TResult>>(jsonresult);
                if (result == null)
                {
                    result = new Result<TResult>();
                }
            }
            else
            {
                result = new Result<TResult>();
            }

            result.Status = GetStatus(wex);

            return result;
        }

        private Status GetStatus(WebException wex)
        {
            Status status;
            if (wex != null)
            {
                HttpWebResponse resp = (HttpWebResponse)wex.Response;
                try
                {
                    string errorResponse;
                    // ReSharper disable once AssignNullToNotNullAttribute
                    using (var reader = new StreamReader(resp.GetResponseStream(), Encoding.UTF8))
                    {
                        errorResponse = reader.ReadToEnd();
                    }
                    ErrorResponse err = JsonConvert.DeserializeObject<ErrorResponse>(errorResponse);
                    status = new Status((int)resp.StatusCode, err.ErrorGuid, err.Message);
                }
                catch
                {
                    status = new Status((int)resp.StatusCode, Guid.Empty, resp.StatusDescription);
                }
               
            }
            else
            {
                status = new Status(200);
            }

            return status;
        }
    }
}
