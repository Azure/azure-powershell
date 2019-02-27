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
using Microsoft.Azure.Commands.Anf.Common;
using Microsoft.Azure.Commands.Anf.Models;
using Microsoft.Azure.Management.NetApp;

namespace Microsoft.Azure.Commands.Anf.Volume
{
    [Cmdlet("Set", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "AnfVolume"), OutputType(typeof(PSAnfVolume))]
    public class SetAzureRmAnfVolume : AzureAnfCmdletBase
    {
        [Parameter(Mandatory = true, HelpMessage = "The resource group of the ANF account")]
        [ResourceGroupCompleter()]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Parameter(Mandatory = true, HelpMessage = "The location of the resource")]
        [ValidateNotNullOrEmpty]
        public string Location { get; set; }

        [Parameter(Mandatory = true, HelpMessage = "The name of the ANF account")]
        [ValidateNotNullOrEmpty]
        public string AccountName { get; set; }

        [Parameter(Mandatory = true, HelpMessage = "The name of the ANF pool")]
        [ValidateNotNullOrEmpty]
        public string PoolName { get; set; }

        [Parameter(Mandatory = true, HelpMessage = "The name of the ANF volume")]
        [ValidateNotNullOrEmpty]
        public string VolumeName { get; set; }

        [Parameter(Mandatory = true, HelpMessage = "The maximum storage quota allowed for a file system in bytes")]
        [ValidateNotNullOrEmpty]
        public long? UsageThreshold { get; set; }

        [Parameter(Mandatory = true, HelpMessage = "The Azure Resource URI for a delegated subnet")]
        [ValidateNotNullOrEmpty]
        public string SubnetId { get; set; }

        [Parameter(Mandatory = true, HelpMessage = "A unique file path for the volume")]
        [ValidateNotNullOrEmpty]
        public string CreationToken { get; set; }

        [Parameter(Mandatory = true, HelpMessage = "The service level of the ANF volume")]
        [ValidateNotNullOrEmpty]
        public string ServiceLevel { get; set; }

        public override void ExecuteCmdlet()
        {
            var volumeBody = new Management.NetApp.Models.Volume()
            {
                ServiceLevel = ServiceLevel,
                UsageThreshold = UsageThreshold,
                CreationToken = CreationToken,
                SubnetId = SubnetId,
                Location = Location
            };

            var anfVolume = AzureNetAppFilesManagementClient.Volumes.CreateOrUpdate(volumeBody, ResourceGroupName, AccountName, PoolName, VolumeName);
            WriteObject(anfVolume);
        }
    }
}
