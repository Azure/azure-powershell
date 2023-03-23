namespace Microsoft.Azure.PowerShell.Cmdlets.Functions.Models
{
    public partial class ManagedServiceIdentityUserAssignedIdentities
    {
        partial void AfterFromJson(Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonObject json)
        {
            // Perform serialization using the appropriate item instantiator
            Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.JsonSerializable.FromJson(
                json, 
                ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.IAssociativeArray<Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.IComponents1Jq1T4ISchemasManagedserviceidentityPropertiesUserassignedidentitiesAdditionalproperties>)this).AdditionalProperties,
                (js) => Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Components1Jq1T4ISchemasManagedserviceidentityPropertiesUserassignedidentitiesAdditionalproperties.FromJson(js),
                null );
        }
    }
}