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
    using System.Collections;
    using System.Collections.Generic;
    using System.Management.Automation;

    using AutoMapper;

    using Microsoft.Azure.Commands.Network.Models;

    using MNM = Microsoft.Azure.Management.Network.Models;
    using Microsoft.Azure.Commands.ResourceManager.Common.Tags;
    using Microsoft.Azure.Management.Network;
    using ResourceManager.Common.ArgumentCompleters;

    [Cmdlet(VerbsCommon.New, "AzureRmRouteFilter", SupportsShouldProcess = true),OutputType(typeof(PSRouteFilter))]
    public class NewAzureRouteFilterCommand : RouteFilterBaseCmdlet
    {
        [Alias("ResourceName")]
        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The resource name.")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The resource group name.")]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Parameter(
         Mandatory = true,
         ValueFromPipelineByPropertyName = true,
         HelpMessage = "location.")]
        [LocationCompleter("Microsoft.Network/routeFilters")]
        [ValidateNotNullOrEmpty]
        public string Location { get; set; }

        [Parameter(
             Mandatory = false,
             ValueFromPipelineByPropertyName = true,
             HelpMessage = "The list of Routes")]
        public List<PSRouteFilterRule> Rule { get; set; }

        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "A hashtable which represents resource tags.")]
        public Hashtable Tag { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "Do not ask for confirmation if you want to overrite a resource")]
        public SwitchParameter Force { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Run cmdlet in the background")]
        public SwitchParameter AsJob { get; set; }

        public override void Execute()
        {
            base.Execute();
            WriteWarning("The output object type of this cmdlet will be modified in a future release.");
            var present = this.IsRouteFilterPresent(this.ResourceGroupName, this.Name);
            ConfirmAction(
                Force.IsPresent,
                string.Format(Properties.Resources.OverwritingResource, Name),
                Properties.Resources.CreatingResourceMessage,
                Name,
                () =>
                {
                    var routeTable = this.CreateRouteFilter();
                    WriteObject(routeTable);
                },
                () => present);
        }

        private PSRouteFilter CreateRouteFilter()
        {
            var psRouteFilter = new PSRouteFilter();
            psRouteFilter.Name = this.Name;
            psRouteFilter.ResourceGroupName = this.ResourceGroupName;
            psRouteFilter.Location = this.Location;
            psRouteFilter.Rules = this.Rule;

            // Map to the sdk object
            var routeFilterModel = NetworkResourceManagerProfile.Mapper.Map<MNM.RouteFilter>(psRouteFilter);
            routeFilterModel.Tags = TagsConversionHelper.CreateTagDictionary(this.Tag, validate: true);

            // Execute the Create RouteTable call
            this.RouteFilterClient.CreateOrUpdate(this.ResourceGroupName, this.Name, routeFilterModel);

            var getRouteFilter = this.GetRouteFilter(this.ResourceGroupName, this.Name);

            return getRouteFilter;
        }
    }
}
