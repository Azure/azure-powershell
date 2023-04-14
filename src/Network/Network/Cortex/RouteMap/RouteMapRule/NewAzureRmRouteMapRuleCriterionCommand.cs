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
        ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "RouteMapRuleCriterion",
        SupportsShouldProcess = true),
        OutputType(typeof(PSRouteMapRuleCriterion))]
    public class NewAzureRmRouteMapRuleCriterionCommand : NetworkBaseCmdlet
    {
        [Parameter(
            Mandatory = true,
            HelpMessage = "Match Condition, contains or equals.")]
        [ValidateNotNullOrEmpty]
        public string MatchCondition { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "Route Prefix.")]
        public string[] RoutePrefix { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "Community.")]
        public string[] Community { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "AsPath.")]
        public string[] AsPath { get; set; }

        public override void Execute()
        {
            base.Execute();

            var routeMapRuleCriterion = new PSRouteMapRuleCriterion
            {
                MatchCondition = this.MatchCondition,
                RoutePrefix = this.RoutePrefix?.ToList(),
                Community = this.Community?.ToList(),
                AsPath = this.AsPath?.ToList(),
            };
            WriteObject(routeMapRuleCriterion);
        }
    }
}
