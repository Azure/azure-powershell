namespace Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Json
{
    public sealed class BooleanConverter : JsonConverter<bool>
    {
        internal override JsonNode ToJson(bool value) => new JsonBoolean(value);

        internal override bool FromJson(JsonNode node) => (bool)node;
    }
}