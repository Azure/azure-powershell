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

    [Cmdlet(VerbsCommon.Remove, "AzureRmRouteFilterRuleConfig", SupportsShouldProcess = true), OutputType(typeof(PSRouteFilterRule))]
    public class RemoveAzureRouteFilterRuleConfigCommand : NetworkBaseCmdlet
    {
        [Parameter(
           Mandatory = true,
           HelpMessage = "The name of the route filter rule")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(
            Mandatory = true,
            ValueFromPipeline = true,
            HelpMessage = "The RouteFilter")]
        public PSRouteFilter RouteFilter { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "Do not ask for confirmation if you want to overrite a resource")]
        public SwitchParameter Force { get; set; }

        public override void Execute()
        {
            base.Execute();
            
            // Verify if the route exists in the RouteTable
            ConfirmAction(
                Force.IsPresent,
                string.Format(Properties.Resources.OverwritingResource, this.RouteFilter.Name),
                Properties.Resources.CreatingResourceMessage,
                this.RouteFilter.Name,
                () =>
                {
                    var rule = this.RouteFilter.Rules.SingleOrDefault(resource => string.Equals(resource.Name, this.Name, System.StringComparison.CurrentCultureIgnoreCase));
                    if (rule != null)
                    {
                        this.RouteFilter.Rules.Remove(rule);
                    }

                    WriteObject(this.RouteFilter);
                });
            
        }
    }
}
