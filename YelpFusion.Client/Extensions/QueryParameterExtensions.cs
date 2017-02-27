using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using YelpFusion.Client.Attributes;
using YelpFusion.Client.Models;

namespace YelpFusion.Client.Extensions
{
    public static class QueryParameterExtensions
    {
        public static string GetQueryParamters(this object obj)
        {
            Dictionary<string, string> dict = new Dictionary<string, string>();

            PropertyInfo[] props = obj.GetType().GetProperties(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
            foreach (PropertyInfo prop in props)
            {
                object[] attrs = prop.GetCustomAttributes(true);
                foreach (object attr in attrs)
                {
                    QueryParameterAttribute parameterAttribute = attr as QueryParameterAttribute;
                    if (parameterAttribute != null)
                    {
                        dict.Add(parameterAttribute.Name, prop.GetValue(obj, null)?.ToString() ?? string.Empty);
                        break;
                    }
                }
            }

            return GetQueryParameters(dict);
        }

        public static string GetQueryParameters(this Dictionary<string, string> dict)
        {
            StringBuilder sb = new StringBuilder();
            int index = 0;
            foreach (KeyValuePair<string, string> pair in dict)
            {
                if(string.IsNullOrEmpty(pair.Value))
                    continue;;

                if (index > 0)
                    sb.Append("&");

                sb.Append($"{pair.Key}={Uri.EscapeUriString(pair.Value)}");
                index++;
            }
            return sb.ToString();
        }
    }
}