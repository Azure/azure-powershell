
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
using System.Linq;
using Microsoft.Azure.Management.Internal.Resources.Utilities.Models;
using System.Collections.Generic;
using Microsoft.Rest.Azure;

namespace Microsoft.Azure.Commands.NetAppFiles.BackupVault
{
    [Cmdlet(
        "Get",
        ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "NetAppFilesBackupVault",
        DefaultParameterSetName = FieldsParameterSet), OutputType(typeof(PSNetAppFilesBackup))]
    [Alias("Get-AnfBackupVault")]
    public class GetAzureRmNetAppFilesBackupVault: AzureNetAppFilesCmdletBase
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
            Mandatory = false,
            ParameterSetName = FieldsParameterSet,
            HelpMessage = "The name of the ANF BackupVault")]
        [Parameter(
            Mandatory = false,
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
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            ParameterSetName = ResourceIdParameterSet,
            HelpMessage = "The resource id of the ANF BackupVault")]
        [ValidateNotNullOrEmpty]
        public string ResourceId { get; set; }

        [Parameter(
            ParameterSetName = ParentObjectParameterSet,
            Mandatory = true,
            ValueFromPipeline = true,
            HelpMessage = "The account object containing the BackupVault to return")]
        [ValidateNotNullOrEmpty]
        public PSNetAppFilesVolume AccountObject { get; set; }

        public override void ExecuteCmdlet()
        {
            if (ParameterSetName == ResourceIdParameterSet)
            {
                var resourceIdentifier = new ResourceIdentifier(this.ResourceId);
                ResourceGroupName = resourceIdentifier.ResourceGroupName;
                var parentResources = resourceIdentifier.ParentResource.Split('/');
                AccountName = parentResources[1];
                Name = resourceIdentifier.ResourceName;
            }
            if (ParameterSetName == ParentObjectParameterSet)
            {
                ResourceGroupName = AccountObject.ResourceGroupName;
                var NameParts = AccountObject.Name.Split('/');
                AccountName = NameParts[0];
            }

            if (Name != null)
            {
                Management.NetApp.Models.BackupVault anfBackupVault = null;
                anfBackupVault = AzureNetAppFilesManagementClient.BackupVaults.Get(ResourceGroupName, AccountName, backupVaultName: Name);
                WriteObject(anfBackupVault.ConvertToPs());
            }
            else
            {
                try
                {
                    List<PSNetAppFilesBackupVault> anfBackupVaults = null;
                    var backupVaults = AzureNetAppFilesManagementClient.BackupVaults.ListByNetAppAccount(ResourceGroupName, accountName: AccountName).ToList();
                    anfBackupVaults = backupVaults.ConvertToPS();
                    WriteObject(anfBackupVaults, true);
                }
                catch (ErrorResponseException ex)
                {
                    throw new CloudException(ex.Body.Error.Message, ex);
                }
            }            
        }
    }
}
