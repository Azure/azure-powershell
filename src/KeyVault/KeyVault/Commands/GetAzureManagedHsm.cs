using System.Collections;
using System.Collections.Generic;
using System.Management.Automation;
using Microsoft.Azure.Commands.KeyVault.Models;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;

namespace Microsoft.Azure.Commands.KeyVault.Commands
{
    [Cmdlet("Get", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "ManagedHsm")]
    [OutputType(typeof(PSManagedHsm), typeof(PSKeyVaultIdentityItem))]
    public class GetAzureManagedHsm : KeyVaultManagementCmdletBase
    {
        #region Input Parameter Definitions

        /// <summary>
        /// Hsm name
        /// </summary>
        [Parameter(Mandatory = false,
            Position = 0,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Hsm name. Cmdlet constructs the FQDN of a hsm based on the name and currently selected environment.")]
        [ResourceNameCompleter("Microsoft.KeyVault/managedHSMs", "ResourceGroupName")]
        [Alias(Constants.Name)]
        [ValidateNotNullOrEmpty]
        [SupportsWildcards]
        public string HsmName { get; set; }

        /// <summary>
        /// Resource group name
        /// </summary>
        [Parameter(Mandatory = false,
            Position = 1,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Specifies the name of the resource group associated with the managed hsm being queried.")]
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
            HelpMessage = "Specifies the key and optional value of the specified tag to filter the list of managed hsms by.")]
        public Hashtable Tag { get; set; }

        #endregion

        public override void ExecuteCmdlet()
        {
            ResourceGroupName = string.IsNullOrWhiteSpace(ResourceGroupName) ? GetResourceGroupName(HsmName, true) : ResourceGroupName;

            if (ShouldGetByName(ResourceGroupName, HsmName))
            {
                PSManagedHsm mhsm = KeyVaultManagementClient.GetManagedHsm(
                                                HsmName,
                                                ResourceGroupName,
                                                ActiveDirectoryClient);
                WriteObject(FilterByTag(mhsm, Tag));
            }
            else
            {              
                WriteObject(
                    TopLevelWildcardFilter(
                        ResourceGroupName, HsmName,
                        FilterByTag(
                            KeyVaultManagementClient.ListManagedHsms(ResourceGroupName, ActiveDirectoryClient), Tag)),
                    true);
            }
        }
    }
}
