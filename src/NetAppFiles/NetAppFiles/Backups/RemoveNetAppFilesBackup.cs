
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
using System.Globalization;
using Microsoft.Azure.Commands.NetAppFiles.Helpers;
using Microsoft.Azure.Management.Internal.Resources.Utilities.Models;

namespace Microsoft.Azure.Commands.NetAppFiles.Backup
{    
    [Cmdlet(
        "Remove",
        ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "NetAppFilesBackup",
        SupportsShouldProcess = true,
        DefaultParameterSetName = FieldsParameterSet), OutputType(typeof(PSNetAppFilesBackupPolicy))]
    [Alias("Remove-AnfBackup")]
    public class RemoveAzureRmNetAppFilesBackup : AzureNetAppFilesCmdletBase
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
            Mandatory = false,
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
            Mandatory = true,
            ParameterSetName = FieldsParameterSet,
            HelpMessage = "The name of the ANF pool")]
        [ValidateNotNullOrEmpty]
        [ResourceNameCompleter(
            "Microsoft.NetApp/netAppAccounts/capacityPools",
            nameof(ResourceGroupName),
            nameof(AccountName))]
        public string PoolName { get; set; }

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
            HelpMessage = "The name of the ANF backup",
            ParameterSetName = FieldsParameterSet)]
        [Parameter(
            Mandatory = true,
            HelpMessage = "The name of the ANF backup",
            ParameterSetName = ParentObjectParameterSet)]
        [ValidateNotNullOrEmpty]
        [Alias("BackupName")]
        [ResourceNameCompleter(
            "Microsoft.NetApp/netAppAccounts/backups",
            nameof(ResourceGroupName),
            nameof(AccountName),
            nameof(PoolName),
            nameof(VolumeName))]
        public string Name { get; set; }

        [Parameter(
            Mandatory = true,
            HelpMessage = "The name of the ANF backup",
            ParameterSetName = AccountBackupFieldsParameterSet)]
        [ValidateNotNullOrEmpty]
        [ResourceNameCompleter(
            "Microsoft.NetApp/netAppAccounts/backups",
            nameof(ResourceGroupName),
            nameof(AccountName))]
        public string AccountBackupName { get; set; }

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
            HelpMessage = "The volume object containing the backup to return")]
        [ValidateNotNullOrEmpty]
        public PSNetAppFilesVolume VolumeObject { get; set; }

        [Parameter(
            ParameterSetName = ObjectParameterSet,
            Mandatory = true,
            ValueFromPipeline = true,
            HelpMessage = "The snapshot object to remove")]
        [ValidateNotNullOrEmpty]
        public PSNetAppFilesBackup InputObject { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "Return whether the specified backup was successfully removed")]
        public SwitchParameter PassThru { get; set; }

        public override void ExecuteCmdlet()
        {
            bool success = false;
            bool accountBackup = false;
            if (ParameterSetName == ResourceIdParameterSet)
            {
                var resourceIdentifier = new ResourceIdentifier(this.ResourceId);
                ResourceGroupName = resourceIdentifier.ResourceGroupName;
                var parentResources = resourceIdentifier.ParentResource.Split('/');
                AccountName = parentResources[1];
                if (parentResources.Length > 1)
                {
                    PoolName = parentResources[3];
                    VolumeName = parentResources[5];
                }
                Name = resourceIdentifier.ResourceName;
                
                try
                {
                    var existingVolume = AzureNetAppFilesManagementClient.Volumes.Get(ResourceGroupName, AccountName, PoolName, VolumeName);
                    if (existingVolume == null)
                    {
                        accountBackup = true;
                    }
                }
                catch
                {
                    accountBackup = true;
                }
            }
            else if (ParameterSetName == ObjectParameterSet)
            {
                ResourceGroupName = InputObject.ResourceGroupName;
                var NameParts = InputObject.Name.Split('/');
                AccountName = NameParts[0];
                if (NameParts.Length == 2)
                {
                    Name = NameParts[1];
                    accountBackup = true;
                }
                else if (NameParts.Length > 2)
                {
                    PoolName = NameParts[1];
                    VolumeName = NameParts[2];
                    Name = NameParts[3];
                }
            }
            else if (ParameterSetName == ParentObjectParameterSet)
            {
                ResourceGroupName = VolumeObject.ResourceGroupName;
                var NameParts = VolumeObject.Name.Split('/');
                AccountName = NameParts[0];
                if (NameParts.Length > 1)
                {
                    PoolName = NameParts[1];
                    VolumeName = NameParts[2];
                }
            }
            else if (ParameterSetName == AccountBackupFieldsParameterSet)
            {
                accountBackup = true;
                Name = AccountBackupName;
            }

            if (ShouldProcess(Name, string.Format(PowerShell.Cmdlets.NetAppFiles.Properties.Resources.RemoveResourceMessage, ResourceGroupName)))
            {                
                if (accountBackup)
                {
                    AzureNetAppFilesManagementClient.AccountBackups.Delete(ResourceGroupName, AccountName, backupName: Name);
                }
                else
                {
                    AzureNetAppFilesManagementClient.Backups.Delete(ResourceGroupName, AccountName, poolName: PoolName, volumeName: VolumeName, backupName: Name);
                }
                success = true;
            }
            if (PassThru)
            {
                WriteObject(success);
            }

        }
    }
}
