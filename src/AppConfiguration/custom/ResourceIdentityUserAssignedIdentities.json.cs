namespace Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Models.Api20200601
{
    public partial class ResourceIdentityUserAssignedIdentities
    {
        partial void BeforeFromJson(Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Runtime.Json.JsonObject json, ref bool returnNow)
        {
            // Perform deserialization using the appropriate object factory for user identity
            // Should be removed (and regenerate the module) when https://github.com/Azure/autorest.powershell/issues/625 is closed
            Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Runtime.JsonSerializable.FromJson(
                json,
                ((Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Runtime.IAssociativeArray<Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Models.Api20200601.IUserIdentity>)this).AdditionalProperties,
                (identity) => UserIdentity.FromJson(identity),
                null);
            returnNow = true;
        }
    }
}