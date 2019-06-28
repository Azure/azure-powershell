namespace Microsoft.Azure.PowerShell.Cmdlets.Storage.Cmdlets
{
    public partial class NewAzStorageAccount_CreateViaIdentityExpanded
    {
        // Workaround for the lack of a parameter being created for an object that has only a required constant.
        // add a parameter that creates the otherwise empty object.
        [System.Management.Automation.Parameter(Mandatory = false, HelpMessage = "Specify IdentityType as 'SystemAssigned'")]
        [Microsoft.Azure.PowerShell.Cmdlets.Storage.Category(Microsoft.Azure.PowerShell.Cmdlets.Storage.ParameterCategory.Body)]
        public System.Management.Automation.SwitchParameter AssignIdentity { set {
           // if this switch is set, just use the internal setter for the Identity property 
           // and set a new Identity object, which has the Type as a constant.
          ((Microsoft.Azure.PowerShell.Cmdlets.Storage.Models.Api20190401.IStorageAccountCreateParametersInternal)this.ParametersBody).Identity = new Microsoft.Azure.PowerShell.Cmdlets.Storage.Models.Api20171001.Identity();
        }}
    }
}
