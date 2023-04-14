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

namespace Microsoft.Azure.Commands.Network
{
    using System.Linq;
    using System.Management.Automation;
    using Microsoft.Azure.Commands.Network.Models;

    [Cmdlet(
        VerbsCommon.New,
        ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "RouteMapRuleAction",
        SupportsShouldProcess = true),
        OutputType(typeof(PSRouteMapRuleAction))]
    public class NewAzureRmRouteMapRuleActionCommand : NetworkBaseCmdlet
    {
        [Parameter(
            Mandatory = true,
            HelpMessage = "Action type, E.g. Drop, Replace, Add, Remove.")]
        [ValidateNotNullOrEmpty]
        public string Type { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "Action type, E.g. Drop, Replace, Add, Remove.")]
        public PSRouteMapRuleActionParameter[] Parameter { get; set; }

        public override void Execute()
        {
            base.Execute();

            var routeMapRuleAction = new PSRouteMapRuleAction
            {
                Type = this.Type,
                Parameters = this.Parameter?.ToList(),
            };
            WriteObject(routeMapRuleAction);
        }
    }
}
