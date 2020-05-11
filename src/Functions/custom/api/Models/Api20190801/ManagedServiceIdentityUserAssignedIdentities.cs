namespace Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801
{
    public partial class ManagedServiceIdentityUserAssignedIdentities
    {
        partial void AfterFromJson(Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonObject json)
        {
            // Perform serialization using the appropriate item instantiator
            Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.JsonSerializable.FromJson(
                json, 
                ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.IAssociativeArray<Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IComponentsSchemasManagedserviceidentityPropertiesUserassignedidentitiesAdditionalproperties>)this).AdditionalProperties, 
                (js) => Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ComponentsSchemasManagedserviceidentityPropertiesUserassignedidentitiesAdditionalproperties.FromJson(js) ,
                null );
        }
    }
}