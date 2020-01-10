namespace Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Json
{
    public sealed class UInt16Converter : JsonConverter<ushort>
    {
        internal override JsonNode ToJson(ushort value) => new JsonNumber(value);

        internal override ushort FromJson(JsonNode node) => (ushort)node;
    }
}