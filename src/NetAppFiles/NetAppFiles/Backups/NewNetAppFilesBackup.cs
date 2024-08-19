
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
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using Microsoft.Azure.Commands.NetAppFiles.Common;
using Microsoft.Azure.Commands.NetAppFiles.Models;
using Microsoft.Azure.Management.NetApp;
using Microsoft.Azure.Management.NetApp.Models;
using Microsoft.Azure.Commands.NetAppFiles.Helpers;
using Microsoft.Rest.Azure;
using Microsoft.WindowsAzure.Commands.Common.CustomAttributes;
using System;
using Azure.Core;
namespace Microsoft.Azure.Commands.NetAppFiles.Backup
{
    [Cmdlet(
        VerbsCommon.New,
        ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "NetAppFilesBackup",
        SupportsShouldProcess = true,
        DefaultParameterSetName = FieldsParameterSet), OutputType(typeof(PSNetAppFilesBackup))]
    [Alias("New-AnfBackup")]
    public class NewAzureRmNetAppFilesBackup : AzureNetAppFilesCmdletBase
    {
        [Parameter(
            Mandatory = true,
            ParameterSetName = FieldsParameterSet,
            HelpMessage = "The resource group of the ANF account")]
        [ValidateNotNullOrEmpty]
        [ResourceGroupCompleter()]
        public string ResourceGroupName { get; set; }

        [CmdletParameterBreakingChangeWithVersion("Location", "12", "0.16", ChangeDescription = ChangeDesc)]
        [Parameter(
            Mandatory = false,
            ParameterSetName = FieldsParameterSet,
            HelpMessage = "The location of the resource")]
        [ValidateNotNullOrEmpty]
        [LocationCompleter("Microsoft.NetApp/netAppAccounts/backupvaults/backups")]
        public string Location { get; set; }

        [Parameter(
            Mandatory = true,
            ParameterSetName = FieldsParameterSet,
            HelpMessage = "The name of the ANF account")]
        [ValidateNotNullOrEmpty]
        [ResourceNameCompleter(
            "Microsoft.NetApp/netAppAccount",
            nameof(ResourceGroupName))]
        public string AccountName { get; set; }

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
            HelpMessage = "The name of the ANF backup")]
        [ValidateNotNullOrEmpty]
        [Alias("BackupName")]
        [ResourceNameCompleter(
            "Microsoft.NetApp/netAppAccounts/backupvaults/backups",
            nameof(ResourceGroupName),
            nameof(AccountName),
            nameof(BackupVaultName))]
        public string Name { get; set; }

        [Parameter(
            Mandatory = true,
            HelpMessage = "ResourceId used to identify the Volume")]
        public string VolumeResourceId { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "Label for backup")]
        [ValidateNotNullOrEmpty]
        public string Label { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "Manual backup an already existing snapshot. This will always be false for scheduled backups and true/false for manual backups")]
        [ValidateNotNullOrEmpty]
        public SwitchParameter UseExistingSnapshot { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "The name of the snapshot, use with UseExistingSnapshot")]
        [ValidateNotNullOrEmpty]
        public string SnapshotName { get; set; }

        [CmdletParameterBreakingChangeWithVersion("VolumeObject", "12", "0.16", ChangeDescription = ChangeDesc)]
        [Parameter(
            ParameterSetName = ParentObjectParameterSet,
            Mandatory = false,
            ValueFromPipeline = true,
            HelpMessage = "The volume for the new backup object")]
        [ValidateNotNullOrEmpty]
        public PSNetAppFilesVolume VolumeObject { get; set; }

        [Parameter(
            ParameterSetName = ParentObjectParameterSet,
            Mandatory = true,
            ValueFromPipeline = true,
            HelpMessage = "The BackupVault object containing the backup to return")]
        [ValidateNotNullOrEmpty]
        public PSNetAppFilesBackupVault BackupVaultObject { get; set; }

        public override void ExecuteCmdlet()
        {
            if (ParameterSetName == ParentObjectParameterSet)
            {
                ResourceGroupName = BackupVaultObject.ResourceGroupName;
                Location = BackupVaultObject.Location;
                var NameParts = BackupVaultObject.Name.Split('/');
                AccountName = NameParts[0];
                BackupVaultName = NameParts[1];
            }
            if (!ResourceIdentifier.TryParse(VolumeResourceId, out _))
            {
                throw new Exception($"VolumeResourceId is an invalid resource Id");
            }

            var backupBody = new Management.NetApp.Models.Backup()
            {
                Label = Label,
                VolumeResourceId = VolumeResourceId,
                UseExistingSnapshot = UseExistingSnapshot,
                SnapshotName = SnapshotName
            };

            if (ShouldProcess(Name, string.Format(PowerShell.Cmdlets.NetAppFiles.Properties.Resources.CreateResourceMessage, ResourceGroupName)))
            {
                try
                {
                    var anfBackup = AzureNetAppFilesManagementClient.Backups.Create(ResourceGroupName, AccountName, backupVaultName: BackupVaultName, backupName: Name, body: backupBody);
                    WriteObject(anfBackup.ConvertToPs());
                }
                catch (ErrorResponseException ex)
                {
                    throw new CloudException(ex.Body.Error.Message, ex);
                }
            }
        }
    }
}