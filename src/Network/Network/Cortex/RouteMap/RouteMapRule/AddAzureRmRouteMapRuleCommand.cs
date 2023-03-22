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
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Management.Automation;
    using Microsoft.Azure.Commands.Network.Models;

    [Cmdlet(
        VerbsCommon.Add,
        ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "RouteMapRule",
        SupportsShouldProcess = true),
        OutputType(typeof(PSRouteMap))]
    public class AddAzureRmRouteMapRuleCommand : NetworkBaseCmdlet
    {
        [Parameter(
            Mandatory = true,
            HelpMessage = "The reference of the route map resource.",
            ValueFromPipeline = true,
            ValueFromPipelineByPropertyName = true)]
        public PSRouteMap RouteMap { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "List of Route Map Rules Criteria.")]
        public PSRouteMapRuleCriterion[] MatchCriteria { get; set; }

        [Parameter(
            Mandatory = true,
            HelpMessage = "List of Route Map Rules Actions.")]
        [ValidateNotNullOrEmpty]
        public PSRouteMapRuleAction[] Actions { get; set; }

        [Parameter(
            Mandatory = true,
            HelpMessage = "Next Step If Matched.")]
        [ValidateNotNullOrEmpty]
        public string NextStepIfMatched { get; set; }

        [Parameter(
            Mandatory = true,
            HelpMessage = "The unique name for this route map rule.")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        public override void Execute()
        {
            if (this.RouteMap == null)
            {
                throw new ArgumentException("The given route map does not exist.");
            }

            if (this.RouteMap.Rules == null)
            {
                this.RouteMap.Rules = new List<PSRouteMapRule>();
            }

            var routeMapRule = new PSRouteMapRule
            {
                Name = this.Name,
                MatchCriteria = this.MatchCriteria?.ToList(),
                Actions = this.Actions?.ToList(),
                NextStepIfMatched = this.NextStepIfMatched
            };
            this.RouteMap.Rules.Add(routeMapRule);
            WriteObject(this.RouteMap);
        }
    }
}
