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
    using MNM = Microsoft.Azure.Management.Network.Models;
    using Microsoft.Azure.Commands.Network.Models;
    using Microsoft.Azure.Management.Network.Models;

    [Cmdlet("Update", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "RouteFilterRuleConfig", SupportsShouldProcess = true), OutputType(typeof(PSRouteFilter))]
    public class UpdateAzureRouteFilterRuleConfigCommand : AzureRouteFilterRuleConfigBase
    {
        [Parameter(
            Mandatory = true,
            ValueFromPipeline = true,
            HelpMessage = "The RouteFilter")]
        public PSRouteFilter RouteFilter { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "The access type of the rule. Possible values are: 'Allow', 'Deny'")]
        [ValidateNotNullOrEmpty]
        [ValidateSet(
           MNM.Access.Allow,
           MNM.Access.Deny,
           IgnoreCase = true)]
        public override string Access { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "The route filter rule type of the rule. Possible values are: 'Community'")]
        [ValidateNotNullOrEmpty]
        [ValidateSet(
            "Community",
            IgnoreCase = true)]
        public override string RouteFilterRuleType { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "The list of community value that route filter will filter on")]
        [ValidateNotNull]
        public override string[] CommunityList { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "Do not ask for confirmation if you want to overwrite a resource")]
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
                   var rule = this.RouteFilter.Rules.SingleOrDefault(resource => string.Equals(resource.Name, this.Name, System.StringComparison.CurrentCultureIgnoreCase));

                   if (rule == null)
                   {
                       throw new ArgumentException("rule with the specified name does not exist");
                   }
                   System.Diagnostics.Debugger.Launch();
                   rule.Name = this.Name;
                   if (this.Access != null)
                   {
                       rule.Access = this.Access;
                   }

                   if (this.RouteFilterRuleType != null)
                   {
                       rule.RouteFilterRuleType = this.RouteFilterRuleType;
                   }

                   if (this.CommunityList != null)
                   {
                       rule.Communities = this.CommunityList?.ToList();
                   }

                   WriteObject(this.RouteFilter);
               });

        }
    }
}
