namespace Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Json
{
    public sealed class Int64Converter : JsonConverter<long>
    {
        internal override JsonNode ToJson(long value) => new JsonNumber(value);

        internal override long FromJson(JsonNode node) => (long)node;
    }
}