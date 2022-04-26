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
using Microsoft.Azure.Commands.NetAppFiles.Helpers;
using Microsoft.Azure.Commands.NetAppFiles.Models;
using Microsoft.Azure.Management.NetApp;
using Microsoft.Azure.Management.NetApp.Models;
using Microsoft.Azure.Management.Internal.Resources.Utilities.Models;
using System.Collections.Generic;

namespace Microsoft.Azure.Commands.NetAppFiles.Volume
{
    [Cmdlet(
        "Update",
        ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "NetAppFilesVolume",
        SupportsShouldProcess = true,
        DefaultParameterSetName = FieldsParameterSet), OutputType(typeof(PSNetAppFilesVolume))]
    [Alias("Update-AnfVolume")]
    public class UpdateAzureRmNetAppFilesVolume : AzureNetAppFilesCmdletBase
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
            HelpMessage = "The location of the resource")]
        [ValidateNotNullOrEmpty]
        [LocationCompleter("Microsoft.NetApp/netAppAccounts/capacityPools")]
        public string Location { get; set; }

        [Parameter(
            Mandatory = true,
            ParameterSetName = FieldsParameterSet,
            HelpMessage = "The name of the ANF account")]
        [ValidateNotNullOrEmpty]
        [ResourceNameCompleter(
            "Microsoft.NetApp/netAppAccounts",
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
            Mandatory = true,
            ParameterSetName = FieldsParameterSet,
            HelpMessage = "The name of the ANF volume")]
        [Parameter(
            Mandatory = true,
            ParameterSetName = ParentObjectParameterSet,
            HelpMessage = "The name of the ANF volume")]
        [ValidateNotNullOrEmpty]
        [Alias("VolumeName")]
        [ResourceNameCompleter(
            "Microsoft.NetApp/netAppAccounts/capacityPools/volumes",
            nameof(ResourceGroupName),
            nameof(AccountName),
            nameof(PoolName))]
        public string Name { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "The maximum storage quota allowed for a file system in bytes")]
        [ValidateNotNullOrEmpty]
        public long? UsageThreshold { get; set; }
        
        [Parameter(
            Mandatory = false,
            HelpMessage = "The service level of the ANF volume")]
        [PSArgumentCompleter("Standard", "Premium", "Ultra", "StandardZRS")]
        [ValidateNotNullOrEmpty]
        public string ServiceLevel { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "A hashtable array which represents the export policy")]
        [ValidateNotNullOrEmpty]
        public PSNetAppFilesVolumeExportPolicy ExportPolicy { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "A hashtable array which represents the backup object")]
        [ValidateNotNullOrEmpty]
        public PSNetAppFilesVolumeBackupProperties Backup { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "Maximum throughput in Mibps that can be achieved by this volume, this will be accepted as input only for manual qosType volume")]
        public double? ThroughputMibps { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "Snapshot Policy ResourceId used to apply a snapshot policy to the volume")]
        [ValidateNotNullOrEmpty]
        public string SnapshotPolicyId { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "Specifies if default quota is enabled for the volume")]
        public SwitchParameter IsDefaultQuotaEnabled { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "Default user quota for volume in KiBs. If isDefaultQuotaEnabled is set, the minimum value of 4 KiBs applies.")]
        public long? DefaultUserQuotaInKiB { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "Default group quota for volume in KiBs. If isDefaultQuotaEnabled is set, the minimum value of 4 KiBs applies.")]
        public long? DefaultGroupQuotaInKiB { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "A hashtable which represents resource tags")]
        [ValidateNotNullOrEmpty]
        [Alias("Tags")]
        public Hashtable Tag { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "UNIX permissions for NFS volume accepted in octal 4 digit format. First digit selects the set user ID(4), set group ID (2) and sticky (1) attributes. Second digit selects permission for the owner of the file: read (4), write (2) and execute (1). Third selects permissions for other users in the same group. the fourth for other users not in the group. 0755 - gives read/write/execute permissions to owner and read/execute to group and other users.")]
        public string UnixPermission { get; set; }

        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            ParameterSetName = ResourceIdParameterSet,
            HelpMessage = "The resource id of the ANF volume")]
        [ValidateNotNullOrEmpty]
        public string ResourceId { get; set; }

        [Parameter(
            ParameterSetName = ParentObjectParameterSet,
            Mandatory = true,
            ValueFromPipeline = true,
            HelpMessage = "The pool object containing the volume to update")]
        [ValidateNotNullOrEmpty]
        public PSNetAppFilesPool PoolObject { get; set; }

        [Parameter(
            ParameterSetName = ObjectParameterSet,
            Mandatory = true,
            ValueFromPipeline = true,
            HelpMessage = "The volume object to update")]
        [ValidateNotNullOrEmpty]
        public PSNetAppFilesVolume InputObject { get; set; }

        public override void ExecuteCmdlet()
        {
            IDictionary<string, string> tagPairs = null;

            if (Tag != null)
            {
                tagPairs = new Dictionary<string, string>();

                foreach (string key in Tag.Keys)
                {
                    tagPairs.Add(key, Tag[key].ToString());
                }
            }

            if (ParameterSetName == ResourceIdParameterSet)
            {
                var resourceIdentifier = new ResourceIdentifier(this.ResourceId);
                ResourceGroupName = resourceIdentifier.ResourceGroupName;
                var parentResources = resourceIdentifier.ParentResource.Split('/');
                AccountName = parentResources[1];
                PoolName = parentResources[3];
                Name = resourceIdentifier.ResourceName;
            }
            else if (ParameterSetName == ObjectParameterSet)
            {
                ResourceGroupName = InputObject.ResourceGroupName;
                Location = InputObject.Location;
                var NameParts = InputObject.Name.Split('/');
                AccountName = NameParts[0];
                PoolName = NameParts[1];
                Name = NameParts[2];
            }
            else if (ParameterSetName == ParentObjectParameterSet)
            {
                ResourceGroupName = PoolObject.ResourceGroupName;
                Location = PoolObject.Location;
                var NameParts = InputObject.Name.Split('/');
                AccountName = NameParts[0];
                PoolName = NameParts[1];
            }

            PSNetAppFilesVolumeDataProtection dataProtection = null;
            if (!string.IsNullOrWhiteSpace(SnapshotPolicyId) || Backup != null)
            {
                dataProtection = new PSNetAppFilesVolumeDataProtection
                {
                    Snapshot = new PSNetAppFilesVolumeSnapshot() { SnapshotPolicyId = SnapshotPolicyId },
                    Backup = Backup
                };
            }

            var volumePatchBody = new VolumePatch()
            {
                ServiceLevel = ServiceLevel,
                UsageThreshold = UsageThreshold,
                ExportPolicy = (ExportPolicy != null) ? ModelExtensions.ConvertExportPolicyPatchFromPs(ExportPolicy) : null,
                Tags = tagPairs,
                ThroughputMibps = ThroughputMibps,
                DataProtection = (dataProtection != null) ? dataProtection.ConvertToPatchFromPs() : null,
                IsDefaultQuotaEnabled = IsDefaultQuotaEnabled,
                DefaultUserQuotaInKiBs = DefaultUserQuotaInKiB,
                DefaultGroupQuotaInKiBs = DefaultGroupQuotaInKiB,
                UnixPermissions = UnixPermission
            };

            if (ShouldProcess(Name, string.Format(PowerShell.Cmdlets.NetAppFiles.Properties.Resources.UpdateResourceMessage, ResourceGroupName)))
            {
                var anfVolume = AzureNetAppFilesManagementClient.Volumes.Update(volumePatchBody, ResourceGroupName, AccountName, PoolName, Name);
                WriteObject(anfVolume.ToPsNetAppFilesVolume());
            }
        }
    }
}
