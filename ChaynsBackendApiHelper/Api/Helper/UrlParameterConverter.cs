using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
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
            var baseType = data.GetType();
            var parameters = new List<string>();
            foreach (var propName in changedProperties)
            {
                var valStr = "";
                var converter = new StringConverter();

                var prop = baseType.GetProperty(propName);

                var val = prop.GetValue(data);
                
                if (val is IEnumerable && !(val is string))
                {
                    var arrEntries = prop.GetValue(data) as IEnumerable;
                    if (arrEntries != null)
                    {
                        foreach (var arrEntry in arrEntries)
                        {
                            string valToAdd;
                            if (converter.CanConvertFrom(prop.GetType()))
                            {
                                valToAdd = converter.ConvertFrom(arrEntry)?.ToString() ?? "";
                            }
                            else
                            {
                                valToAdd = arrEntry?.ToString() ?? "";
                            }

                            if (valToAdd != "") valStr += $"{valToAdd},";
                        }
                        valStr = $"[{valStr.Remove(valStr.LastIndexOf(','), 1)}]";
                    }
                }
                else
                {
                    if (converter.CanConvertFrom(prop.GetType()))
                    {
                        valStr = converter.ConvertFrom(val)?.ToString() ?? "";
                    }
                    else
                    {
                        valStr = val?.ToString() ?? "";
                    }
                }

                if (valStr != "") parameters.Add($"{propName}={valStr}");
            }
            if (parameters.Count == 0) return "";
            return "?" + string.Join("&", parameters);
        }
    }
}
