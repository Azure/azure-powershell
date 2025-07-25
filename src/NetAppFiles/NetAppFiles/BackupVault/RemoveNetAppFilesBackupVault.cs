
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

using System.Collections;
using System.Management.Automation;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Commands.NetAppFiles.Common;
using Microsoft.Azure.Commands.NetAppFiles.Models;
using Microsoft.Azure.Management.NetApp;
using Microsoft.Azure.Management.NetApp.Models;
using System.Globalization;
using Microsoft.Azure.Commands.NetAppFiles.Helpers;
using Microsoft.Azure.Management.Internal.Resources.Utilities.Models;
using Microsoft.WindowsAzure.Commands.Common.CustomAttributes;
using Microsoft.Rest.Azure;

namespace Microsoft.Azure.Commands.NetAppFiles.BackupVault
{
    [Cmdlet(
        "Remove",
        ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "NetAppFilesBackupVault",
        SupportsShouldProcess = true,
        DefaultParameterSetName = FieldsParameterSet), OutputType(typeof(bool))]    
    [Alias("Remove-AnfBackupVault")]
    public class RemoveAzureRmNetAppFilesBackupVault: AzureNetAppFilesCmdletBase
    {
        [Parameter(
            Mandatory = true,
            ParameterSetName = FieldsParameterSet,
            HelpMessage = "The resource group of the ANF account")]
        [ValidateNotNullOrEmpty]
        [ResourceGroupCompleter()]
        public string ResourceGroupName { get; set; }

        [Parameter(
            Mandatory = true,
            ParameterSetName = FieldsParameterSet,
            HelpMessage = "The name of the ANF account")]
        [ValidateNotNullOrEmpty]
        [ResourceNameCompleter(
            "Microsoft.NetApp/netAppAccount",
            nameof(ResourceGroupName))]
        public string AccountName { get; set; }

        [Parameter(
            Mandatory = true,
            HelpMessage = "The name of the ANF BackupVault",
            ParameterSetName = FieldsParameterSet)]
        [Parameter(
            Mandatory = true,
            HelpMessage = "The name of the ANF BackupVault",
            ParameterSetName = ParentObjectParameterSet)]
        [ValidateNotNullOrEmpty]
        [Alias("BackupVaultName")]
        [ResourceNameCompleter(
            "Microsoft.NetApp/netAppAccounts/backupVaults",
            nameof(ResourceGroupName),
            nameof(AccountName))]
        public string Name { get; set; }

        [Parameter(
            ParameterSetName = ParentObjectParameterSet,
            Mandatory = true,
            ValueFromPipeline = true,
            HelpMessage = "The Account object containing the BackupVault to remove")]
        [ValidateNotNullOrEmpty]
        public PSNetAppFilesAccount AccountObject { get; set; }

        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            ParameterSetName = ResourceIdParameterSet,
            HelpMessage = "The resource id of the ANF BackupVault")]
        [ValidateNotNullOrEmpty]
        public string ResourceId { get; set; }

        [Parameter(
            ParameterSetName = ObjectParameterSet,
            Mandatory = true,
            ValueFromPipeline = true,
            HelpMessage = "The BackupVault object to remove")]
        [ValidateNotNullOrEmpty]
        public PSNetAppFilesBackupVault InputObject { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "Return whether the specified BackupVault was successfully removed")]
        public SwitchParameter PassThru { get; set; }

        public override void ExecuteCmdlet()
        {
            bool success = false;

            if (ParameterSetName == ResourceIdParameterSet)
            {
                var resourceIdentifier = new ResourceIdentifier(this.ResourceId);
                ResourceGroupName = resourceIdentifier.ResourceGroupName;
                var parentResources = resourceIdentifier.ParentResource.Split('/');
                AccountName = parentResources[1];
                Name = resourceIdentifier.ResourceName;
            }
            else if (ParameterSetName == ObjectParameterSet)
            {
                ResourceGroupName = InputObject.ResourceGroupName;
                var NameParts = InputObject.Name.Split('/');
                AccountName = NameParts[0];
                Name = NameParts[1];
            }
            else if (ParameterSetName == ParentObjectParameterSet)
            {
                ResourceGroupName = AccountObject.ResourceGroupName;                
                var NameParts = AccountObject.Name.Split('/');
                AccountName = NameParts[0];
            }

            if (ShouldProcess(Name, string.Format(PowerShell.Cmdlets.NetAppFiles.Properties.Resources.RemoveResourceMessage, ResourceGroupName)))
            {
                try
                { 
                    AzureNetAppFilesManagementClient.BackupVaults.Delete(ResourceGroupName, AccountName, backupVaultName: Name);
                    success = true;
                }
                catch (ErrorResponseException ex)
                {
                    throw new CloudException(ex.Body.Error.Message, ex);
                }
            }
            if (PassThru)
            {
                WriteObject(success);
            }
        }
    }
}
