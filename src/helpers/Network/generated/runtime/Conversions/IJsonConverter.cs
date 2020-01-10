namespace Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Json
{
    internal interface IJsonConverter
    {
        JsonNode ToJson(object value);

        object FromJson(JsonNode node);
    }
}