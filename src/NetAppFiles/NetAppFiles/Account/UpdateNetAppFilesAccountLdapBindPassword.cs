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

using System.Management.Automation;
using Microsoft.Azure.Commands.NetAppFiles.Common;
using Microsoft.Azure.Commands.NetAppFiles.Models;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Management.Internal.Resources.Utilities.Models;
using Microsoft.Azure.Management.NetApp;
using Microsoft.Azure.Management.NetApp.Models;
using Microsoft.Rest.Azure;

namespace Microsoft.Azure.Commands.NetAppFiles.Account
{
    [Cmdlet(
        "Update",
        ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "NetAppFilesAccountLdapBindPassword",
        SupportsShouldProcess = true,
        DefaultParameterSetName = FieldsParameterSet), OutputType(typeof(bool))]
    [Alias("Update-AnfAccountLdapBindPassword")]
    public class UpdateAzureRmNetAppFilesAccountLdapBindPassword : AzureNetAppFilesCmdletBase
    {
        [Parameter(Mandatory = true, ParameterSetName = FieldsParameterSet, HelpMessage = "The resource group of the ANF account.")]
        [ValidateNotNullOrEmpty]
        [ResourceGroupCompleter()]
        public string ResourceGroupName { get; set; }

        [Parameter(Mandatory = true, ParameterSetName = FieldsParameterSet, HelpMessage = "The name of the ANF account.")]
        [ValidateNotNullOrEmpty]
        [Alias("AccountName")]
        [ResourceNameCompleter("Microsoft.NetApp/netAppAccounts", nameof(ResourceGroupName))]
        public string Name { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, ParameterSetName = ResourceIdParameterSet, HelpMessage = "The resource ID of the ANF account.")]
        [ValidateNotNullOrEmpty]
        public string ResourceId { get; set; }

        [Parameter(Mandatory = true, ValueFromPipeline = true, ParameterSetName = ObjectParameterSet, HelpMessage = "The account whose LDAP bind password is refreshed from Azure Key Vault.")]
        [ValidateNotNullOrEmpty]
        public PSNetAppFilesAccount InputObject { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Return true after the LDAP bind password is successfully refreshed.")]
        public SwitchParameter PassThru { get; set; }

        public override void ExecuteCmdlet()
        {
            if (ParameterSetName == ResourceIdParameterSet)
            {
                var resourceIdentifier = new ResourceIdentifier(ResourceId);
                ResourceGroupName = resourceIdentifier.ResourceGroupName;
                Name = resourceIdentifier.ResourceName;
            }
            else if (ParameterSetName == ObjectParameterSet)
            {
                var resourceIdentifier = new ResourceIdentifier(InputObject.Id);
                ResourceGroupName = resourceIdentifier.ResourceGroupName;
                Name = resourceIdentifier.ResourceName;
            }

            if (ShouldProcess(Name, string.Format(PowerShell.Cmdlets.NetAppFiles.Properties.Resources.UpdateResourceMessage, ResourceGroupName)))
            {
                try
                {
                    AzureNetAppFilesManagementClient.NetAppAccounts.RefreshLdapBindPassword(ResourceGroupName, Name);
                    if (PassThru.IsPresent)
                    {
                        WriteObject(true);
                    }
                }
                catch (ErrorResponseException ex)
                {
                    throw new CloudException(ex.Body.Error.Message, ex);
                }
            }
        }
    }
}
