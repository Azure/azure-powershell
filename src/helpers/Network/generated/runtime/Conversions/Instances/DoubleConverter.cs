namespace Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Json
{
    public sealed class DoubleConverter : JsonConverter<double>
    {
        internal override JsonNode ToJson(double value) => new JsonNumber(value);

        internal override double FromJson(JsonNode node) => (double)node;
    }
}