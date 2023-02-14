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
using Microsoft.Azure.Management.Internal.Resources.Utilities.Models;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Commands.NetAppFiles.Common;
using Microsoft.Azure.Commands.NetAppFiles.Helpers;
using Microsoft.Azure.Commands.NetAppFiles.Models;
using Microsoft.Azure.Management.NetApp;
using System.Linq;
using Microsoft.Azure.Management.NetApp.Models;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using System;

namespace Microsoft.Azure.Commands.NetAppFiles.Snapshot
{
    [Cmdlet(
        "Restore",        
        ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "NetAppFilesSnapshotFile",
        SupportsShouldProcess = true,
        DefaultParameterSetName = FieldsParameterSet), OutputType(typeof(PSNetAppFilesSnapshot))]
    [Alias("Restore-AnfSnapshotFiles")]
    public class RestoreAzureRmNetAppFilesSnapshotFiles : AzureNetAppFilesCmdletBase
    {
        [Parameter
            (Mandatory = true,
            ParameterSetName = FieldsParameterSet,            
            HelpMessage = "The resource group of the ANF volume")]
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

        [Parameter(Mandatory = true, HelpMessage = "The name of the ANF pool", ParameterSetName = FieldsParameterSet)]
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
        [ValidateNotNullOrEmpty]
        [ResourceNameCompleter(
            "Microsoft.NetApp/netAppAccounts/capacityPools/volumes",
            nameof(ResourceGroupName),
            nameof(AccountName),
            nameof(PoolName))]
        public string VolumeName { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "The name of the ANF snapshot")]
        [ValidateNotNullOrEmpty]
        [Alias("SnapshotName")]
        [ResourceNameCompleter(
            "Microsoft.NetApp/netAppAccounts/capacityPools/volumes/snapshots",
            nameof(ResourceGroupName),
            nameof(AccountName),
            nameof(PoolName))]
        public string Name { get; set; }

        [Parameter(
            Mandatory = true,
            HelpMessage = "List of files to be restored")]
        [ValidateNotNullOrEmpty]
        public string[] FilePath { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "Destination folder where the files will be restored")]
        [ValidateNotNullOrEmpty]
        public string DestinationPath { get; set; }

        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            ParameterSetName = ResourceIdParameterSet,
            HelpMessage = "The resource id of the ANF snapshot")]
        [ValidateNotNullOrEmpty]
        public string ResourceId { get; set; }
        
        [Parameter(
            ParameterSetName = ParentObjectParameterSet,
            Mandatory = true,
            ValueFromPipeline = true,
            HelpMessage = "The volume object containing the snapshot")]
        [ValidateNotNullOrEmpty]
        public PSNetAppFilesVolume VolumeObject { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "Return whether the specified files where successfully restored")]
        public SwitchParameter PassThru { get; set; }

        public override void ExecuteCmdlet()
        {
            bool success = false;
            if (ParameterSetName == ResourceIdParameterSet)
            {
                var resourceIdentifier = new ResourceIdentifier(ResourceId);
                ResourceGroupName = resourceIdentifier.ResourceGroupName;
                var parentResources = resourceIdentifier.ParentResource.Split('/');
                AccountName = parentResources[1];
                PoolName = parentResources[3];
                VolumeName = parentResources[5];
                Name = resourceIdentifier.ResourceName;
            }
            else if (ParameterSetName == ParentObjectParameterSet && this.IsParameterBound(c => c.VolumeObject))
            {
                ResourceGroupName = VolumeObject.ResourceGroupName;
                var NameParts = VolumeObject.Name.Split('/');
                if (NameParts.Length > 2)
                {
                    AccountName = NameParts[0];
                    PoolName = NameParts[1];
                    VolumeName = NameParts[2];
                }
                else
                {
                    throw new ArgumentException("Invalid Parent id in volume object input .", "VolumeObject");
                }
            }

            if (ShouldProcess(Name, string.Format(PowerShell.Cmdlets.NetAppFiles.Properties.Resources.RestoringFilesMessage, string.Join(",",FilePath))))
            {
                SnapshotRestoreFiles snapshotRestoreFilesBody = new SnapshotRestoreFiles()
                {
                    FilePaths = FilePath,
                    DestinationPath = DestinationPath
                };

                AzureNetAppFilesManagementClient.Snapshots.RestoreFiles(snapshotRestoreFilesBody, ResourceGroupName, AccountName, PoolName, VolumeName, Name);
                success = true;
            }
            if (PassThru.IsPresent)
            {
                WriteObject(success);
            }
        }
    }
}
