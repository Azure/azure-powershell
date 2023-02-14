// ----------------------------------------------------------------------------------
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
using System.Linq;
using Microsoft.Azure.Commands.Network.Models;

namespace Microsoft.Azure.Commands.Network.VirtualNetwork.Subnet
{
    [Cmdlet(VerbsCommon.Remove, ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "Delegation", SupportsShouldProcess = false), OutputType(typeof(PSSubnet))]
    public class RemoveAzureSubnetDelegation : NetworkBaseCmdlet
    {
        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The name of the delegation")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(
            Mandatory = true,
            ValueFromPipeline = true,
            HelpMessage = "The subnet from which to remove the delegation")]
        public PSSubnet Subnet { get; set; }

        public override void Execute()
        {
            base.Execute();

            // Verify if the delegation exists in the Subnet
            var delegation = this.Subnet.Delegations.SingleOrDefault(resource => string.Equals(resource.Name, this.Name, System.StringComparison.CurrentCultureIgnoreCase));

            if (delegation != null)
            {
                this.Subnet.Delegations.Remove(delegation);
            }

            WriteObject(this.Subnet);
        }
    }
}
