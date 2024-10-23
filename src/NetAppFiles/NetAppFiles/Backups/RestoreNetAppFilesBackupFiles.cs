
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
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Commands.NetAppFiles.Common;
using Microsoft.Azure.Commands.NetAppFiles.Models;
using Microsoft.Azure.Management.NetApp;
using Microsoft.Azure.Management.NetApp.Models;
using Microsoft.Azure.Management.Internal.Resources.Utilities.Models;
using Microsoft.Rest.Azure;
using System;
using Microsoft.WindowsAzure.Commands.Common.CustomAttributes;

namespace Microsoft.Azure.Commands.NetAppFiles.Backup
{
    [Cmdlet(
        "Restore",
        ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "NetAppFilesBackupFile",
        SupportsShouldProcess = true,
        DefaultParameterSetName = FieldsParameterSet), OutputType(typeof(PSNetAppFilesBackup))]
    [Alias("Restore-AnfBackupFile")]
    public class RestoreNetAppFilesBackupFiles : AzureNetAppFilesCmdletBase
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
            HelpMessage = "The name of the ANF backup",
            ParameterSetName = FieldsParameterSet)]
        [Parameter(
            Mandatory = true,
            HelpMessage = "The name of the ANF backup",
            ParameterSetName = ParentObjectParameterSet)]
        [ValidateNotNullOrEmpty]
        [Alias("BackupName")]
        [ResourceNameCompleter(
            "Microsoft.NetApp/netAppAccounts/capacityPools/volumes/backups",
            nameof(ResourceGroupName),
            nameof(AccountName))]
        public string Name { get; set; }

        public const String ChangeDesc = "Parameter is being deprecated without being replaced";
        [CmdletParameterBreakingChangeWithVersion("PoolName", "12", "0.16", ChangeDescription = ChangeDesc)]
        [Parameter(
            Mandatory = false,
            ParameterSetName = FieldsParameterSet,
            HelpMessage = "The name of the ANF pool")]
        [ValidateNotNullOrEmpty]
        [ResourceNameCompleter(
            "Microsoft.NetApp/netAppAccounts/capacityPools",
            nameof(ResourceGroupName),
            nameof(AccountName))]
        public string PoolName { get; set; }

        [CmdletParameterBreakingChangeWithVersion("VolumeName", "12", "0.16", ChangeDescription = ChangeDesc)]
        [Parameter(
            Mandatory = false,
            ParameterSetName = FieldsParameterSet,
            HelpMessage = "The name of the ANF volume")]
        [ValidateNotNullOrEmpty]        
        [ResourceNameCompleter(
            "Microsoft.NetApp/netAppAccounts/capacityPools/volumes",
            nameof(ResourceGroupName),
            nameof(AccountName),
            nameof(PoolName))]
        public string VolumeName { get; set; }

        [Parameter(
            Mandatory = true,
            ParameterSetName = FieldsParameterSet,
            HelpMessage = "The name of the ANF BackupVault")]
        [ValidateNotNullOrEmpty]
        [ResourceNameCompleter(
            "Microsoft.NetApp/netAppAccounts/backupVaults",
            nameof(ResourceGroupName),
            nameof(AccountName))]
        public string BackupVaultName { get; set; }

        [Parameter(
            Mandatory = true,
            HelpMessage = "List of files to be restored")]
        [ValidateNotNullOrEmpty]
        public string[] FileList { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "Destination folder where the files will be restored. The path name should start with a forward slash. If it is omitted from request then restore is done at the root folder of the destination volume by default")]
        [ValidateNotNullOrEmpty]
        public string RestoreFilePath { get; set; }

        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,            
            HelpMessage = "Resource Id of the destination volume on which the files need to be restored")]
        [ValidateNotNullOrEmpty]
        public string DestinationVolumeId { get; set; }

        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            ParameterSetName = ResourceIdParameterSet,
            HelpMessage = "The resource id of the ANF Backup")]
        [ValidateNotNullOrEmpty]
        public string ResourceId { get; set; }

        [CmdletParameterBreakingChangeWithVersion("VolumeObject", "12", "0.16", ChangeDescription = ChangeDesc)]
        [Parameter(
            ParameterSetName = ParentObjectParameterSet,
            Mandatory = false,
            ValueFromPipeline = true,
            HelpMessage = "The volume object containing the backup to restore files from")]
        [ValidateNotNullOrEmpty]
        public PSNetAppFilesVolume VolumeObject { get; set; }

        [Parameter(
            ParameterSetName = ParentObjectParameterSet,
            Mandatory = true,
            ValueFromPipeline = true,
            HelpMessage = "The BackupVault object containing the backup to return")]
        [ValidateNotNullOrEmpty]
        public PSNetAppFilesBackupVault BackupVaultObject { get; set; }

        [Parameter(
            ParameterSetName = ObjectParameterSet,
            Mandatory = true,
            ValueFromPipeline = true,
            HelpMessage = "The backup object to restore files from")]
        [ValidateNotNullOrEmpty]
        public PSNetAppFilesBackup InputObject { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "Return whether the specified files where successfully restored")]
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
                BackupVaultName = parentResources[3];
                Name = resourceIdentifier.ResourceName;
            }
            else if (ParameterSetName == ObjectParameterSet)
            {
                ResourceGroupName = InputObject.ResourceGroupName;
                var NameParts = InputObject.Name.Split('/');
                AccountName = NameParts[0];
                BackupVaultName = NameParts[1];                
                Name = NameParts[2];
            }
            else if (ParameterSetName == ParentObjectParameterSet)
            {
                ResourceGroupName = BackupVaultObject.ResourceGroupName;
                var NameParts = BackupVaultObject.Name.Split('/');
                AccountName = NameParts[0];                
                BackupVaultName = NameParts[1];
            }

            var backupRestoreFiles = new Management.NetApp.Models.BackupRestoreFiles()
            {
                DestinationVolumeId = DestinationVolumeId,
                FileList = FileList,
                RestoreFilePath = RestoreFilePath
            };

            if (ShouldProcess(Name, string.Format(PowerShell.Cmdlets.NetAppFiles.Properties.Resources.CreateResourceMessage, ResourceGroupName)))
            {
                try
                {
                    var restoreFileResponse = AzureNetAppFilesManagementClient.BackupsUnderBackupVault.RestoreFiles(resourceGroupName: ResourceGroupName, accountName: AccountName, backupVaultName:BackupVaultName, backupName: Name, body: backupRestoreFiles);
                    success = true;
                }
                catch (ErrorResponseException ex)
                {
                    throw new CloudException(ex.Body.Error.Message, ex);
                }
            }
            if (PassThru.IsPresent)
            {
                WriteObject(success);
            }
        }
    }
}
