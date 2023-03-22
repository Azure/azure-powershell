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
    using System.Linq;
    using System.Management.Automation;
    using Microsoft.Azure.Commands.Network.Models;

    [Cmdlet(
        VerbsCommon.Remove,
        ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "RouteMapRule",
        SupportsShouldProcess = true),
        OutputType(typeof(PSRouteMap))]
    public class RemoveAzureRmRouteMapRuleCommand : NetworkBaseCmdlet
    {
        [Parameter(
            Mandatory = true,
            HelpMessage = "The reference of the route map resource.",
            ValueFromPipeline = true,
            ValueFromPipelineByPropertyName = true)]
        public PSRouteMap RouteMap { get; set; }

        [Parameter(
            Mandatory = true,
            HelpMessage = "The unique name for this route map rule.")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        public override void Execute()
        {
            if (this.RouteMap == null)
            {
                throw new ArgumentException("The given routing intent does not exist.");
            }

            if (this.RouteMap.Rules == null || !this.RouteMap.Rules.Any())
            {
                WriteObject(this.RouteMap);
                return;
            }

            var routeMapRuleToRemove = this.RouteMap.Rules.Where(
                    rule => string.Equals(rule.Name, this.Name, StringComparison.CurrentCultureIgnoreCase));

            if (routeMapRuleToRemove != null && routeMapRuleToRemove.Any())
            {
                var rule = routeMapRuleToRemove.Single();
                this.RouteMap.Rules.Remove(rule);
            }

            WriteObject(this.RouteMap);
        }
    }
}
