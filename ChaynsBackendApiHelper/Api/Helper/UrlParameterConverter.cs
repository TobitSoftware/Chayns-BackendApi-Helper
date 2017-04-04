using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;
using System.Web;
using Chayns.Backend.Api.Models.Data;

namespace Chayns.Backend.Api.Helper
{
    public static class UrlParameterConverter
    {
        /// <summary>
        /// Serializes an object to url-parameters
        /// </summary>
        /// <typeparam name="TData">Datatype of the serializeable object</typeparam>
        /// <param name="data">Object to serialize</param>
        /// <returns>Url-parameters</returns>
        public static string SerializeObject<TData>(TData data) where TData : ChangeableData
        {
            HashSet<string> changedProperties;
            if ((changedProperties = data?.GetAllChangedProperties()) == null || changedProperties.Count == 0)
            {
                return "";
            }

            List<string> parameter = new List<string>();
            foreach (var propName in changedProperties)
            {
                PropertyInfo prop = typeof (TData).GetProperty(propName);
                object val = prop.GetValue(data);

                StringConverter converter = new StringConverter();
                if (converter.CanConvertFrom(prop.GetType()))
                {
                    string valStr = converter.ConvertFrom(val)?.ToString() ?? "";
                    valStr = HttpUtility.UrlEncode(valStr);
                    parameter.Add($"{propName}={valStr}");
                }
                else
                {
                    string valStr = val?.ToString() ?? "";
                    valStr = HttpUtility.UrlEncode(valStr);
                    parameter.Add($"{propName}={valStr}");
                }

            }
            return "?" + string.Join("&", parameter);
        }
    }
}
