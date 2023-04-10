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
using System.Linq;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.Network
{
    [Cmdlet("New", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "ApplicationGatewayGroupByVariable"), OutputType(typeof(PSApplicationGatewayGroupByVariable))]
    public class NewAzApplicationGatewayGroupByVariableCommand : NetworkBaseCmdlet
    {
        [Parameter(
            Mandatory = true,
            HelpMessage = "User Session clause variable.")]
        [ValidateNotNullOrEmpty]
        [ValidateSet("ClientAddr", "Geo", "None", IgnoreCase = true)]
        public string VariableName { get; set; }

        public override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();
            WriteObject(NewObject());
        }

        protected PSApplicationGatewayGroupByVariable NewObject()
        {
            return new PSApplicationGatewayGroupByVariable()
            {
                VariableName = this.VariableName
            };
        }
    }
}
