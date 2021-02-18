namespace Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Models.Api20200601
{
    using Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Runtime.Json;

    public partial class KeyVaultProperties
    {
        partial void AfterToJson(ref Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Runtime.Json.JsonObject container)
        {
            // API is defined in a way that, to disable CMK, you need to pass null as keyIdentifier and/or identityClientId
            // However this is impossible in PowerShell, because when you pass a $null to a [System.String]$var, it's converted to string.Empty
            // To work-around that, I made this customization
            if (this._keyIdentifier == string.Empty)
            {
                container["keyIdentifier"] = JsonNode.FromObject(null);
            }
            if (this._identityClientId == string.Empty)
            {
                container["identityClientId"] = JsonNode.FromObject(null);
            }
        }
    }
}