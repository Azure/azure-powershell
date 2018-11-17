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
    using System.Management.Automation;

    using Microsoft.Azure.Commands.Network.Models;

    [Cmdlet(VerbsCommon.New, "AzureRmRouteFilterRuleConfig", SupportsShouldProcess = true), OutputType(typeof(PSRouteFilterRule))]
    public class NewAzureRouteFilterRuleConfigCommand : AzureRouteFilterRuleConfigBase
    {
        [Parameter(
            Mandatory = false,
            HelpMessage = "Do not ask for confirmation if you want to overrite a resource")]
        public SwitchParameter Force { get; set; }

        public override void Execute()
        {
            base.Execute();

            ConfirmAction(
               Force.IsPresent,
               string.Format(Properties.Resources.OverwritingResource, Name),
               Properties.Resources.CreatingResourceMessage,
               Name,
               () =>
               {
                   var rule = new PSRouteFilterRule();

                   rule.Name = this.Name;
                   rule.Access = this.Access;
                   rule.RouteFilterRuleType = this.RouteFilterRuleType;
                   rule.Communities = this.CommunityList;

                   WriteObject(rule);
               });
        }
    }
}
