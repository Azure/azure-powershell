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

namespace Microsoft.Azure.Commands.NetAppFiles.Volume
{
    [Cmdlet(
        "New",
        ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "NetAppFilesVolume",
        SupportsShouldProcess = true,
        DefaultParameterSetName = FieldsParameterSet), OutputType(typeof(PSNetAppFilesVolume))]
    [Alias("New-AnfVolume")]
    public class NewAzureRmNetAppFilesVolume : AzureNetAppFilesCmdletBase
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
        [LocationCompleter("Microsoft.NetApp/netAppAccounts/capacityPools/volumes")]
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
            Mandatory = true,
            HelpMessage = "The maximum storage quota allowed for a file system in bytes")]
        [ValidateNotNullOrEmpty]
        public long? UsageThreshold { get; set; }

        [Parameter(
            Mandatory = true,
            HelpMessage = "The Azure Resource URI for a delegated subnet")]
        [ValidateNotNullOrEmpty]
        public string SubnetId { get; set; }

        [Parameter(
            Mandatory = true,
            HelpMessage = "A unique file path for the volume")]
        [ValidateNotNullOrEmpty]
        public string CreationToken { get; set; }

        [Parameter(
            Mandatory = true,
            HelpMessage = "The service level of the ANF volume")]
        [ValidateNotNullOrEmpty]
        [PSArgumentCompleter("Standard", "Premium", "Extreme")]
        public string ServiceLevel { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "A hashtable which represents resource tags")]
        [ValidateNotNullOrEmpty]
        [Alias("Tags")]
        public Hashtable Tag { get; set; }

        [Parameter(
            ParameterSetName = ParentObjectParameterSet,
            Mandatory = true,
            ValueFromPipeline = true,
            HelpMessage = "The pool for the new volume object")]
        [ValidateNotNullOrEmpty]
        public PSNetAppFilesPool PoolObject { get; set; }

        public override void ExecuteCmdlet()
        {
            if (ParameterSetName == ParentObjectParameterSet)
            {
                ResourceGroupName = PoolObject.ResourceGroupName;
                Location = PoolObject.Location;
                var NameParts = PoolObject.Name.Split('/');
                AccountName = NameParts[0];
                PoolName = NameParts[1];
            }

            var volumeBody = new Management.NetApp.Models.Volume()
            {
                ServiceLevel = ServiceLevel,
                UsageThreshold = UsageThreshold,
                CreationToken = CreationToken,
                SubnetId = SubnetId,
                Location = Location,
                Tags = Tag
            };

            if (ShouldProcess(Name, "Create the new volume"))
            {
                var anfVolume = AzureNetAppFilesManagementClient.Volumes.CreateOrUpdate(volumeBody, ResourceGroupName, AccountName, PoolName, Name);
                WriteObject(anfVolume);
            }
        }
    }
}
