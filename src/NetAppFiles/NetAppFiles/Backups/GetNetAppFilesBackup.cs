
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
using Microsoft.WindowsAzure.Commands.Common.CustomAttributes;
using System;

namespace Microsoft.Azure.Commands.NetAppFiles.Backup
{
    [Cmdlet(
        "Get",
        ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "NetAppFilesBackup",
        DefaultParameterSetName = FieldsParameterSet), OutputType(typeof(PSNetAppFilesBackup))]
    [Alias("Get-AnfBackup")]
    public class GetAzureRmNetAppFilesBackup: AzureNetAppFilesCmdletBase
    {
        protected const string AccountBackupFieldsParameterSet = "ByAccountBackupFieldsParameterSet";
        [Parameter(
            Mandatory = true,
            ParameterSetName = FieldsParameterSet,
            HelpMessage = "The resource group of the ANF account")]
        [Parameter(
            Mandatory = true,
            HelpMessage = "The name of the ANF backup",
            ParameterSetName = AccountBackupFieldsParameterSet)]
        [ValidateNotNullOrEmpty]
        [ResourceGroupCompleter()]
        public string ResourceGroupName { get; set; }

        [Parameter(
            Mandatory = true,
            ParameterSetName = FieldsParameterSet,
            HelpMessage = "The name of the ANF account")]
        [Parameter(
            Mandatory = true,
            HelpMessage = "The name of the ANF backup",
            ParameterSetName = AccountBackupFieldsParameterSet)]
        [ValidateNotNullOrEmpty]
        [ResourceNameCompleter(
            "Microsoft.NetApp/netAppAccount",
            nameof(ResourceGroupName))]
        public string AccountName { get; set; }

        [Parameter(
            Mandatory = false,
            ParameterSetName = FieldsParameterSet,
            HelpMessage = "The name of the ANF BackupVault")]
        [ValidateNotNullOrEmpty]
        [ResourceNameCompleter(
            "Microsoft.NetApp/netAppAccounts/backupVaults",
            nameof(ResourceGroupName),
            nameof(AccountName))]
        public string BackupVaultName { get; set; }

        [Parameter(
            Mandatory = false,
            ParameterSetName = FieldsParameterSet,
            HelpMessage = "The name of the ANF backup")]
        [Parameter(
            Mandatory = false,
            HelpMessage = "The name of the ANF BackupVault",
            ParameterSetName = ParentObjectParameterSet)]
        [ValidateNotNullOrEmpty]
        [Alias("BackupName")]
        [ResourceNameCompleter(
            "Microsoft.NetApp/netAppAccounts/backups",
            nameof(ResourceGroupName),
            nameof(AccountName))]
        public string Name { get; set; }

        [Parameter(
            Mandatory = false,
            ParameterSetName = FieldsParameterSet,
            HelpMessage = "Filter list of backups, this filter accepts volumeResourceId")]        
        public string Filter { get; set; }

        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            ParameterSetName = ResourceIdParameterSet,
            HelpMessage = "The resource id of the ANF Backup")]
        [ValidateNotNullOrEmpty]
        public string ResourceId { get; set; }

        [Parameter(
            ParameterSetName = ParentObjectParameterSet,
            Mandatory = true,
            ValueFromPipeline = true,
            HelpMessage = "The BackupVault object containing the backup to return")]
        [ValidateNotNullOrEmpty]
        public PSNetAppFilesBackupVault BackupVaultObject { get; set; }

        public override void ExecuteCmdlet()
        {
            if (ParameterSetName == ResourceIdParameterSet)
            {
                var resourceIdentifier = new ResourceIdentifier(this.ResourceId);
                ResourceGroupName = resourceIdentifier.ResourceGroupName;
                var parentResources = resourceIdentifier.ParentResource.Split('/');
                AccountName = parentResources[1];
                BackupVaultName = parentResources[3];                
                Name = resourceIdentifier.ResourceName;
            }
            if (ParameterSetName == ParentObjectParameterSet)
            {
                ResourceGroupName = BackupVaultObject.ResourceGroupName;                
                var NameParts = BackupVaultObject.Name.Split('/');
                AccountName = NameParts[0];
                BackupVaultName = NameParts[1];
            }

            if (Name != null)
            {
                Management.NetApp.Models.Backup anfBackup = null;
                anfBackup = AzureNetAppFilesManagementClient.Backups.Get(ResourceGroupName, AccountName, backupVaultName:BackupVaultName, backupName: Name);
                WriteObject(anfBackup.ConvertToPs());
            }
            else
            {
                try
                {
                    List<PSNetAppFilesBackup> anfBackups = null;
                    var backups = AzureNetAppFilesManagementClient.Backups.ListByVault(ResourceGroupName, accountName: AccountName, backupVaultName: BackupVaultName,filter: Filter);
                    // Get all backups by polling on next page link
                    var backupsResponseList = ListNextLink<Management.NetApp.Models.Backup>.GetAllResourcesByPollingNextLink(backups, AzureNetAppFilesManagementClient.Backups.ListByVaultNext);

                    anfBackups = backupsResponseList.ConvertToPS();

                    WriteObject(anfBackups, true);
                }
                catch (ErrorResponseException ex)
                {
                    throw new CloudException(ex.Body.Error.Message, ex);
                }
            }
        }
    }
}
