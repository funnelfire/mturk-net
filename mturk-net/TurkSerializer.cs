using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace MTurk
{
    public static class TurkSerializer
    {
        public static string Serialize(object obj)
        {
            var col = Collect(obj);
            var qs = ToQueryString(col);
            return qs;
        }

        public static string ToQueryString(this NameValueCollection collection)
        {
            return String.Join("&", collection.AllKeys.Select(a => a + "=" + HttpUtility.UrlEncode(collection[a])));
        }
        public static NameValueCollection Collect(object obj)
        {
            var col = new NameValueCollection();
            Collect(obj, col);
            return col;
        }

        public static void Collect(object obj, NameValueCollection collection)
        {
            Internals.ParsePath(collection, null, obj);
        }

        public static class Internals
        {
            private static readonly IDictionary<Type, MethodInfo> Convertibles = typeof(Convert).GetMethods(BindingFlags.Public | BindingFlags.Static)
                    .Where(x => x.Name == "ToString" && x.GetParameters().Length == 1 && x.GetParameters()[0].ParameterType != typeof(object))
                    .ToDictionary(x => x.GetParameters()[0].ParameterType, x => x);

            public static void ParsePath(NameValueCollection collection, string path, object obj)
            {
                if (obj == null)
                    return;

                var type = obj.GetType();

                if (path == null) path = string.Empty;

                if (obj is DateTime)
                {
                    var dt = (DateTime)obj;
                    collection[path] = dt.ToString("O");
                    return;
                }

                var converter = Convertibles.Where(x => x.Key.IsInstanceOfType(obj)).Select(x => x.Value).FirstOrDefault();
                if (converter != null)
                {
                    collection[path] = (string)converter.Invoke(null, new[] { obj });
                    return;
                }

                if (path != string.Empty)
                    path += ".";

                var objects = obj as IEnumerable<object>;
                if (objects != null)
                {
                    var enumerable = objects;
                    foreach (var xi in enumerable.Select((x, i) => new { x, i = i + 1 }))
                        ParsePath(collection, path + xi.i, xi.x);

                    return;
                }

                var props = type.GetProperties(BindingFlags.Public | BindingFlags.Instance).Where(x => x.CanRead);
                if (props.Any(x => x.CanWrite)) props = props.Where(x => x.CanWrite);
                var keyvalues = props.Select(x => new { Property = x, Value = x.GetValue(obj) });
                foreach (var kv in keyvalues)
                {
                    ParsePath(collection, path + kv.Property.Name, kv.Value);
                }
            }
        }
    }
}
