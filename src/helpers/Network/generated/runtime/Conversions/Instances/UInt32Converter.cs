namespace Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Json
{
    public sealed class UInt32Converter : JsonConverter<uint>
    {
        internal override JsonNode ToJson(uint value) => new JsonNumber(value);

        internal override uint FromJson(JsonNode node) => (uint)node;
    }
}