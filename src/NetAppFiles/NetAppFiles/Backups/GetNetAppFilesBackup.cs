
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
using System.Linq;
using Microsoft.Azure.Management.Internal.Resources.Utilities.Models;
using System.Collections.Generic;

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
            Mandatory = false,
            HelpMessage = "The name of the ANF backup")]
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
            Mandatory = false,
            HelpMessage = "The name of the ANF backup",
            ParameterSetName = AccountBackupFieldsParameterSet)]
        [Parameter(
            Mandatory = false,
            HelpMessage = "The name of the ANF backup",
            ParameterSetName = ParentObjectParameterSet)]
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

        public override void ExecuteCmdlet()
        {
            bool accountBackup = false;
            if (ParameterSetName == ResourceIdParameterSet)
            {
                var resourceIdentifier = new ResourceIdentifier(this.ResourceId);
                ResourceGroupName = resourceIdentifier.ResourceGroupName;
                var parentResources = resourceIdentifier.ParentResource.Split('/');
                AccountName = parentResources[1];
                PoolName = parentResources[3];
                VolumeName = parentResources[5];
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
            if (ParameterSetName == ParentObjectParameterSet)
            {
                ResourceGroupName = VolumeObject.ResourceGroupName;                
                var NameParts = VolumeObject.Name.Split('/');
                AccountName = NameParts[0];
                PoolName = NameParts[1];
                VolumeName = NameParts[2];
            }
            else if (ParameterSetName == AccountBackupFieldsParameterSet)
            {
                accountBackup = true;
                Name = AccountBackupName;
            }

            if (Name != null)
            {
                Management.NetApp.Models.Backup anfBackup = null;
                if (accountBackup)
                {
                    anfBackup = AzureNetAppFilesManagementClient.AccountBackups.Get(ResourceGroupName, AccountName,  backupName: Name);
                }
                else
                {
                    anfBackup = AzureNetAppFilesManagementClient.Backups.Get(ResourceGroupName, AccountName, backupName: Name, poolName: PoolName, volumeName: VolumeName);
                }
                WriteObject(anfBackup.ConvertToPs());
            }
            else
            {
                List<PSNetAppFilesBackup> anfBackups = null;
                if (accountBackup)
                {
                    var backups = AzureNetAppFilesManagementClient.AccountBackups.List(ResourceGroupName, accountName: AccountName).ToList(); 
                    anfBackups = backups.ConvertToPS();
                }
                else
                {
                    //anfBackups = AzureNetAppFilesManagementClient.Backups.List(ResourceGroupName, accountName: AccountName, poolName: PoolName, volumeName: VolumeName)..Select(e => e.ConvertToPs());
                    var backups = AzureNetAppFilesManagementClient.Backups.List(ResourceGroupName, accountName: AccountName, poolName: PoolName, volumeName: VolumeName).ToList();
                    anfBackups = backups.ConvertToPS();
                }
                WriteObject(anfBackups, true);
            }
        }
    }
}
