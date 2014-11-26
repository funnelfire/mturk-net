using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace mturk
{
    public static class TurkSerializer
    {
        public static string Serialize(object obj)
        {
            var col = new NameValueCollection();
            ParsePath(col, null, obj);
            var qs = string.Join("&", col.AllKeys.Select(a => a + "=" + HttpUtility.UrlEncode(col[a])));
            return qs;
        }

        private static void ParsePath(NameValueCollection collection, string path, object obj)
        {
            if (obj == null) return;

            var convertibles = typeof(Convert).GetMethods(BindingFlags.Public | BindingFlags.Static)
                .Where(x => x.Name == "ToString" && x.GetParameters().Length == 1 && x.GetParameters()[0].ParameterType != typeof(object))
                .ToDictionary(x => x.GetParameters()[0].ParameterType, x => x);

            if (path == null)
                path = string.Empty;
            else
                path += ".";

            var props = obj.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance).Where(x => x.CanRead);
            var keyvalues = props.Select(x => new { Property = x, Value = x.GetValue(obj) });
            foreach (var kv in keyvalues)
            {
                if (kv.Value is IEnumerable<object>)
                {
                    var enumerable = (IEnumerable<object>)kv.Value;
                    foreach (var xi in enumerable.Select((x, i) => new { x, i }))
                        ParsePath(collection, path + xi.i, xi.x);
                }
                else if (convertibles.ContainsKey(kv.Property.PropertyType))
                    collection[kv.Property.Name] = (string)convertibles[kv.Property.PropertyType].Invoke(null, new[] { kv.Value });
                else
                    ParsePath(collection, path + kv.Property.Name, kv.Value);
            }
        }
    }
}
