namespace Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Json
{
    public sealed class UInt64Converter : JsonConverter<ulong>
    {
        internal override JsonNode ToJson(ulong value) => new JsonNumber(value.ToString());

        internal override ulong FromJson(JsonNode node) => (ulong)node;
    }
}