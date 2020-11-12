using Microsoft.Azure.Commands.KeyVault.Models;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using System.Collections;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.KeyVault.Commands
{
    [Cmdlet("Get", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "ManagedHsm")]
    [OutputType(typeof(PSManagedHsm), typeof(PSKeyVaultIdentityItem))]
    public class GetAzureManagedHsm : KeyVaultManagementCmdletBase
    {
        #region Input Parameter Definitions

        /// <summary>
        /// HSM name
        /// </summary>
        [Parameter(Mandatory = false,
            Position = 0,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "HSM name. Cmdlet constructs the FQDN of a HSM based on the name and currently selected environment.")]
        [ResourceNameCompleter("Microsoft.KeyVault/managedHSMs", "ResourceGroupName")]
        [Alias("HsmName")]
        [ValidateNotNullOrEmpty]
        [SupportsWildcards]
        public string Name { get; set; }

        /// <summary>
        /// Resource group name
        /// </summary>
        [Parameter(Mandatory = false,
            Position = 1,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Specifies the name of the resource group associated with the managed HSM being queried.")]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        [SupportsWildcards]
        public string ResourceGroupName { get; set; }

        /// <summary>
        /// Tag value
        /// </summary>
        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Specifies the key and optional value of the specified tag to filter the list of managed HSMs by.")]
        public Hashtable Tag { get; set; }

        #endregion

        public override void ExecuteCmdlet()
        {
            ResourceGroupName = string.IsNullOrWhiteSpace(ResourceGroupName) ? GetResourceGroupName(Name, true) : ResourceGroupName;

            if (ShouldGetByName(ResourceGroupName, Name))
            {
                PSManagedHsm mhsm = KeyVaultManagementClient.GetManagedHsm(
                                                Name,
                                                ResourceGroupName,
                                                ActiveDirectoryClient);
                WriteObject(FilterByTag(mhsm, Tag));
            }
            else
            {              
                WriteObject(
                    TopLevelWildcardFilter(
                        ResourceGroupName, Name,
                        FilterByTag(
                            KeyVaultManagementClient.ListManagedHsms(ResourceGroupName, ActiveDirectoryClient), Tag)),
                    true);
            }
        }
    }
}
