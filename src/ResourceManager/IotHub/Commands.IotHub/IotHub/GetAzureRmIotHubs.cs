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

using System.Collections.Generic;
using System.Management.Automation;
using Microsoft.Azure.Commands.Management.IotHub.Models;
using Microsoft.Azure.Management.IotHub;
using Microsoft.Azure.Management.IotHub.Models;

namespace Microsoft.Azure.Commands.Management.PowerBIEmbedded.WorkspaceCollection
{
    [Cmdlet(VerbsCommon.Get, "IotHubs"), OutputType(typeof(List<PSIotHub>))]
    public class GetAzureRmIotHubs : IotHubBaseCmdlet
    {
        [Parameter(
            Position = 0,
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Resource Group Name.")]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        public override void ExecuteCmdlet()
        {
            if (string.IsNullOrEmpty(ResourceGroupName))
            {
                IEnumerable<IotHubDescription> iotHubs = this.IotHubClient.IotHubResource.ListBySubscription();
                this.WriteObject(iotHubs, true);
            }
            else
            {
                IEnumerable<IotHubDescription> iotHubs = this.IotHubClient.IotHubResource.ListByResourceGroup(this.ResourceGroupName);
                this.WriteObject(iotHubs, true);
            }
        }
    }
}
