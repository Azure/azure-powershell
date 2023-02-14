
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
using System.Collections.Generic;

namespace Microsoft.Azure.Commands.NetAppFiles.Backup
{
    [Cmdlet(
        "Update",
        ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "NetAppFilesSubvolume",
        SupportsShouldProcess = true,
        DefaultParameterSetName = FieldsParameterSet), OutputType(typeof(PSNetAppFilesBackupPolicy))]
    [Alias("Update-AnfSubvolume")]
    public class UpdateAzureRmNetAppFilesSubvolume : AzureNetAppFilesCmdletBase
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
            HelpMessage = "The name of the ANF Subvolume")]
        [ValidateNotNullOrEmpty]
        [Alias("SubvolumeName")]
        [ResourceNameCompleter(
            "Microsoft.NetApp/netAppAccounts/capacityPools/volumes/subvolumes",
            nameof(ResourceGroupName),
            nameof(AccountName),
            nameof(PoolName),
            nameof(VolumeName))]
        public string Name { get; set; }

        [Parameter(
            Mandatory = true,
            HelpMessage = "Path for subvolume")]
        [ValidateNotNullOrEmpty]
        public string Path { get; set; }

        [Parameter(
            Mandatory = true,
            HelpMessage = "Truncate subvolume to the provided size in bytes")]
        [ValidateNotNullOrEmpty]
        public long? Size { get; set; }

        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            ParameterSetName = ResourceIdParameterSet,
            HelpMessage = "The resource id of the ANF Subvolume")]
        [ValidateNotNullOrEmpty]
        public string ResourceId { get; set; }

        [Parameter(
            ParameterSetName = ParentObjectParameterSet,
            Mandatory = true,
            ValueFromPipeline = true,
            HelpMessage = "The volume object containing the subvolume to return")]
        [ValidateNotNullOrEmpty]
        public PSNetAppFilesVolume VolumeObject { get; set; }

        [Parameter(
            ParameterSetName = ObjectParameterSet,
            Mandatory = true,
            ValueFromPipeline = true,
            HelpMessage = "The subvolume object to update")]
        [ValidateNotNullOrEmpty]
        public PSNetAppFilesBackup InputObject { get; set; }

        public override void ExecuteCmdlet()
        {
            if (ParameterSetName == ResourceIdParameterSet)
            {
                var resourceIdentifier = new ResourceIdentifier(this.ResourceId);
                ResourceGroupName = resourceIdentifier.ResourceGroupName;
                var parentResources = resourceIdentifier.ParentResource.Split('/');
                AccountName = parentResources[1];
                PoolName = parentResources[3];
                VolumeName = parentResources[5];
                Name = resourceIdentifier.ResourceName;
            }
            else if (ParameterSetName == ObjectParameterSet)
            {
                ResourceGroupName = InputObject.ResourceGroupName;
                var NameParts = InputObject.Name.Split('/');
                AccountName = NameParts[0];
                PoolName = NameParts[1];
                VolumeName = NameParts[2];
                Name = NameParts[3];
            }
            else if (ParameterSetName == ParentObjectParameterSet)
            {
                ResourceGroupName = VolumeObject.ResourceGroupName;
                var NameParts = VolumeObject.Name.Split('/');
                AccountName = NameParts[0];
                PoolName = NameParts[1];
                VolumeName = NameParts[2];
            }

            var subvolumePatch = new Management.NetApp.Models.SubvolumePatchRequest()
            {
                Path = Path,
                Size = Size
            };

            if (ShouldProcess(Name, string.Format(PowerShell.Cmdlets.NetAppFiles.Properties.Resources.UpdateResourceMessage, Name)))
            {
                var anfSubvolume = AzureNetAppFilesManagementClient.Subvolumes.Update(subvolumePatch, ResourceGroupName, accountName: AccountName, poolName: PoolName, volumeName: VolumeName, subvolumeName: Name);
                WriteObject(anfSubvolume.ConvertToPs());
            }
        }
    }
}
