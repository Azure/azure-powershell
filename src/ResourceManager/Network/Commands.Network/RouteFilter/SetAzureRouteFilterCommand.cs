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
    using System.Management.Automation;

    using AutoMapper;

    using Microsoft.Azure.Commands.Network.Models;
    using MNM = Microsoft.Azure.Management.Network.Models;
    using Microsoft.Azure.Commands.ResourceManager.Common.Tags;
    using Microsoft.Azure.Management.Network;

    [Cmdlet(VerbsCommon.Set, "AzureRmRouteFilter", SupportsShouldProcess = true), OutputType(typeof(PSRouteFilter))]
    public class SetAzureRouteFilterCommand : RouteFilterBaseCmdlet
    {
        [Parameter(
            Mandatory = true,
            ValueFromPipeline = true,
            HelpMessage = "The RouteFilter")]
        public PSRouteFilter RouteFilter { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "Do not ask for confirmation if you want to overrite a resource")]
        public SwitchParameter Force { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Run cmdlet in the background")]
        public SwitchParameter AsJob { get; set; }

        public override void Execute()
        {

            base.Execute();

            ConfirmAction(
                Force.IsPresent,
                string.Format(Properties.Resources.OverwritingResource, this.RouteFilter.Name),
                Properties.Resources.CreatingResourceMessage,
                this.RouteFilter.Name,
                () =>
                {
                    // Map to the sdk object
                    var routeFilterModel = NetworkResourceManagerProfile.Mapper.Map<MNM.RouteFilter>(this.RouteFilter);
                    routeFilterModel.Tags = TagsConversionHelper.CreateTagDictionary(this.RouteFilter.Tag, validate: true);

                    // Execute the PUT RouteTable call
                    this.RouteFilterClient.CreateOrUpdate(this.RouteFilter.ResourceGroupName, this.RouteFilter.Name, routeFilterModel);

                    var getRouteTable = this.GetRouteFilter(this.RouteFilter.ResourceGroupName, this.RouteFilter.Name);
                    WriteObject(getRouteTable);
                });
        }
    }
}
