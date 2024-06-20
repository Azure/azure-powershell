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

using Microsoft.Azure.Commands.FrontDoor.Common;
using Microsoft.Azure.Commands.FrontDoor.Models;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.FrontDoor.Cmdlets
{
    /// <summary>
    /// Defines the New-FrontDoorWafCustomRuleGroupByVariableObject cmdlet.
    /// </summary>
    [Cmdlet("New", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "FrontDoorWafCustomRuleGroupByVariableObject"), OutputType(typeof(PSFrontDoorWafCustomRuleGroupByVariable))]
    public class NewFrontDoorWafCustomRuleGroupByVariableObject : AzureFrontDoorCmdletBase
    {

        /// <summary>
        /// Describes the supported variable for group by
        /// </summary>
        [Parameter(Mandatory = true, HelpMessage = "Describes the supported variable for group by")]
        [PSArgumentCompleter("SocketAddr", "GeoLocation")]
        public string VariableName { get; set; }

        public override void ExecuteCmdlet()
        {
            var FrontDoorWafCustomRuleGroupByVariable = new PSFrontDoorWafCustomRuleGroupByVariable
            {
                VariableName = VariableName,
            };
            WriteObject(FrontDoorWafCustomRuleGroupByVariable);
        }

    }
}
