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
using Microsoft.Azure.Management.FrontDoor.Models;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using System.Data;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.FrontDoor.Cmdlets
{
    /// <summary>
    /// Defines the New-FrontDoorWafLogScrubbingRuleObject cmdlet.
    /// </summary>
    [Cmdlet("New", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "FrontDoorWafLogScrubbingRuleObject"), OutputType(typeof(PSFrontDoorWafLogScrubbingRule))]
    public class NewFrontDoorWafLogScrubbingRuleObject : AzureFrontDoorCmdletBase
    {

        /// <summary>
        /// Gets or sets the variable to be scrubbed from the logs.
        /// </summary>
        [Parameter(Mandatory = true, HelpMessage = "The variable to be scrubbed from the logs.")]
        [PSArgumentCompleter("RequestHeaderNames", "RequestCookieNames", "QueryStringArgNames", "RequestBodyPostArgNames", "RequestBodyJsonArgNames")]
        public string MatchVariable { get; set; }

        /// <summary>
        /// Gets or sets when matchVariable is a collection, operate on the selector to
        /// specify which elements in the collection this rule applies to.
        /// </summary>
        [Parameter(Mandatory = true, HelpMessage = "The parameter to specify which elements in the collection this rule applies to.")]
        [PSArgumentCompleter("Equals", "Contains", "StartsWith", "EndsWith", "EqualsAny")]
        public string SelectorMatchOperator { get; set; }

        /// <summary>
        /// Gets or sets defines the state of a log scrubbing rule.Default value is
        /// enabled.
        /// </summary>
        [Parameter(Mandatory = true, HelpMessage = "Defines the state of a log scrubbing rule. Default value is enabled.")]
        [PSArgumentCompleter("Enabled", "Disabled")]
        public string State { get; set; }

        /// <summary>
        /// Gets or sets when matchVariable is a collection, operator used to specify
        /// which elements in the collection this rule applies to.
        /// </summary>
        [Parameter(Mandatory = false, HelpMessage = "The operator used to specify which elements in the collection this rule applies to.")]
        public string Selector { get; set; }

        public override void ExecuteCmdlet()
        {
            var PSFrontDoorWafLogScrubbingRule = new PSFrontDoorWafLogScrubbingRule
            {
                MatchVariable = MatchVariable,
                SelectorMatchOperator = SelectorMatchOperator,
                State = State,
                Selector = Selector
            };
            WriteObject(PSFrontDoorWafLogScrubbingRule);
        }

    }
}
