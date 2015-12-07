using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace System.Management.Automation
{
    public class PSVariable
    {
        public PSVariable(string name) { Name = name; }
        public PSVariable(string name, object value) { Name = name; Value = value; }

        public string Name { get; private set; }
        public virtual object Value { get; set; }

        public T GetValue<T>() where T : class
        {
            if (Value == null)
                return null;

            if (Value is T)
                return Value as T;

            if (Value is JObject)
                return JsonConvert.DeserializeObject<T>((Value as JObject).ToString(Formatting.None));

            return default(T);
        }
    }
}