namespace Microsoft.Azure.Commands.ManagementGroups.Common
{
    public abstract class AzureManagementGroupAutoRegisterCmdletBase : AzurePrecheckRegistrationAndAutoRegisterCmdletBase
    {
        protected override string ProviderNamespace => "Microsoft.Management";
    }
}