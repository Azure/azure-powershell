using System;

namespace Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Json
{
    public sealed class EnumConverter : IJsonConverter
    {
        private readonly Type type;

        internal EnumConverter(Type type)
        {
            this.type = type ?? throw new ArgumentNullException(nameof(type));
        }

        public JsonNode ToJson(object value) => new JsonString(value.ToString());

        public object FromJson(JsonNode node)
        {
            if (node.Type == JsonType.Number)
            {
                return Enum.ToObject(type, (int)node);
            }

            return Enum.Parse(type, node.ToString(), ignoreCase: true);
        }
    }
}