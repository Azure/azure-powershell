// ----------------------------------------------------------------------------------
//
// Copyright Microsoft Corporation
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// http://www.apache.org/licenses/LICENSE-2.0
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// ----------------------------------------------------------------------------------

using Microsoft.Azure.Commands.KeyVault.Models;
using Microsoft.Azure.Commands.KeyVault.Properties;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;

using System;
using System.Collections;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.KeyVault.Commands
{
    [Cmdlet("Get", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "KeyVaultManagedHsm", DefaultParameterSetName = GetManagedHsmParameterSet)]
    [OutputType(typeof(PSManagedHsm), typeof(PSDeletedManagedHsm), typeof(PSKeyVaultIdentityItem))]
    public class GetAzureManagedHsm : KeyVaultManagementCmdletBase
    {
        #region Parameter Set Names

        private const string GetManagedHsmParameterSet = "GetManagedHsm";
        private const string GetDeletedManagedHsmParameterSet = "GetDeletedManagedHsm";
        private const string ListDeletedManagedHsmsParameterSet = "ListDeletedManagedHsms";
        
        #endregion

        #region Input Parameter Definitions

        /// <summary>
        /// HSM name
        /// </summary>
        [Parameter(Mandatory = false,
            ParameterSetName = GetManagedHsmParameterSet,
            Position = 0,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "HSM name. Cmdlet constructs the FQDN of a HSM based on the name and currently selected environment.")]
        [Parameter(Mandatory = true,
            ParameterSetName = GetDeletedManagedHsmParameterSet,
            Position = 0,
            ValueFromPipelineByPropertyName = true)]
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
            ParameterSetName = GetManagedHsmParameterSet,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Specifies the name of the resource group associated with the managed HSM being queried.")]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        [SupportsWildcards]
        public string ResourceGroupName { get; set; }

        [Parameter(Mandatory = true,
            Position = 1,
            ParameterSetName = GetDeletedManagedHsmParameterSet,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The location of the deleted managed HSM pool.")]
        [LocationCompleter("Microsoft.KeyVault/vaults")]
        [ValidateNotNullOrEmpty()]
        public string Location { get; set; }

        [Parameter(Mandatory = true,
            ParameterSetName = GetDeletedManagedHsmParameterSet,
            HelpMessage = "Specifies whether to show the previously deleted managed HSM pool in the output.")]
        [Parameter(Mandatory = true,
            ParameterSetName = ListDeletedManagedHsmsParameterSet)]
        public SwitchParameter InRemovedState { get; set; }

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
            switch (ParameterSetName)
            {
                case GetManagedHsmParameterSet:
                    ResourceGroupName = string.IsNullOrWhiteSpace(ResourceGroupName) ? GetResourceGroupName(Name, true) : ResourceGroupName;

                    if (ShouldGetByName(ResourceGroupName, Name))
                    {
                        WriteObject(FilterByTag(KeyVaultManagementClient.GetManagedHsm(
                                                        Name,
                                                        ResourceGroupName,
                                                        GraphClient), Tag));
                    }
                    else
                    {
                        WriteObject(
                            TopLevelWildcardFilter(
                                ResourceGroupName, Name,
                                FilterByTag(
                                    KeyVaultManagementClient.ListManagedHsms(ResourceGroupName, GraphClient), Tag)),
                            true);
                    }
                    break;
                case GetDeletedManagedHsmParameterSet:
                    WriteObject(FilterByTag(KeyVaultManagementClient.GetDeletedManagedHsm(
                                    Name,
                                    Location), Tag));
                    break;
                case ListDeletedManagedHsmsParameterSet:
                    WriteObject(FilterByTag(
                        KeyVaultManagementClient.ListDeletedManagedHsms(),
                        Tag), true);
                    break;
                default:
                    throw new ArgumentException(Resources.BadParameterSetName);
            }
            
        }
    }
}
