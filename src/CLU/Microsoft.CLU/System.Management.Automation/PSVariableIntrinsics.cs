using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;

namespace System.Management.Automation
{
    public sealed class PSVariableIntrinsics
    {
        public PSVariable Get(string name)
        {
            if (_variables.ContainsKey(name))
                return _variables[name];
            return null;
        }

        public T Get<T>(string name) where T : class
        {
            if (_variables.ContainsKey(name))
            {
                var value = _variables[name];
                return value.GetValue<T>();
            }
            return null;
        }

        public object GetValue(string name)
        {
            throw new System.NotImplementedException("Can't get arbitrary types to load. Use Get<T>() instead.");
        }

        public object GetValue(string name, object defaultValue)
        {
            if (_variables.ContainsKey(name))
                return _variables[name].Value;
            return defaultValue;
        }

        public void Remove(string name)
        {
            if (_variables.ContainsKey(name))
                _variables.Remove(name);
        }

        public void Set(PSVariable variable)
        {
            _variables[variable.Name] = variable;
        }

        public void Set(string name, object value)
        {
            _variables[name] = new PSVariable(name, value);
        }

        internal string ToJsonString()
        {
            var bldr = new Text.StringBuilder();
            bldr.Append("'variables':");
            bldr.Append('{');

            bool first = true;
            foreach (var kv in _variables)
            {
                if (!first) bldr.Append(',');
                first = false;
                bldr.Append("'").Append(kv.Key).Append("':").Append(JsonConvert.SerializeObject(kv.Value.Value));
            }
            bldr.Append('}');
            return bldr.ToString();
        }

        internal void Load(JObject json)
        {
            foreach (var field in json["variables"].Children<JProperty>())
            {
                switch (field.Value.Type)
                {
                    case JTokenType.Boolean:
                        _variables[field.Name] = new PSVariable(field.Name, (bool)(field.Value as JValue).Value);
                        break;
                    case JTokenType.Integer:
                        _variables[field.Name] = new PSVariable(field.Name, (long)(field.Value as JValue).Value);
                        break;
                    case JTokenType.Float:
                        _variables[field.Name] = new PSVariable(field.Name, (double)(field.Value as JValue).Value);
                        break;
                    case JTokenType.String:
                        _variables[field.Name] = new PSVariable(field.Name, (field.Value as JValue).Value as string);
                        break;
                    case JTokenType.Object:
                        _variables[field.Name] = new PSVariable(field.Name, field.Value);
                        break;
                }
            }
        }

        private string GetTypeFieldName(string variable)
        {
            return "_" + variable + "_type";
        }

        private string GetJSONEscapedPath(string path)
        {
            return path.Replace(unEscapedSeparator, escapedSeparator); 
        }

        private string GetJSONUnescapedPath(string path)
        {
            return path.Replace(escapedSeparator, unEscapedSeparator);
        }

        private Dictionary<string, PSVariable> _variables = new Dictionary<string, PSVariable>(_invariantComparer);
        private static IEqualityComparer<string> _invariantComparer = new StringInvariantComparer();
        private static string unEscapedSeparator = new String(new char[1] { System.IO.Path.DirectorySeparatorChar });
        private static string escapedSeparator = new String(new char[2] {System.IO.Path.DirectorySeparatorChar, System.IO.Path.DirectorySeparatorChar });
    }
}