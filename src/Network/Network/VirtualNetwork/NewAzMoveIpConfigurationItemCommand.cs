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

using Microsoft.Azure.Commands.Network.Models;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.Network
{
    [Cmdlet("New", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "MoveIpConfigurationItem"),
        OutputType(typeof(PSMoveIpConfigurationItem))]
    public class NewAzMoveIpConfigurationItemCommand : NetworkBaseCmdlet
    {
        [Parameter(
            Mandatory = true,
            HelpMessage = "The resource ID of the source IP configuration to move. This must be a secondary IP configuration on a network interface.")]
        [ValidateNotNullOrEmpty]
        public string SourceIpConfigurationId { get; set; }

        [Parameter(
            Mandatory = true,
            HelpMessage = "The resource ID of the target IP configuration on the destination network interface.")]
        [ValidateNotNullOrEmpty]
        public string TargetIpConfigurationId { get; set; }

        public override void Execute()
        {
            base.Execute();

            var item = new PSMoveIpConfigurationItem
            {
                SourceIpConfigurationId = this.SourceIpConfigurationId,
                TargetIpConfigurationId = this.TargetIpConfigurationId
            };

            WriteObject(item);
        }
    }
}
