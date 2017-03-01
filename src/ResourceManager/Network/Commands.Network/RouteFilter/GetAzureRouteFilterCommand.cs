﻿// ----------------------------------------------------------------------------------
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
    using System.Collections.Generic;
    using System.Management.Automation;

    using Microsoft.Azure.Commands.Network.Models;
    using Microsoft.Azure.Management.Network;

    [Cmdlet(VerbsCommon.Get, "AzureRmRouteFilter"), OutputType(typeof(PSRouteFilter))]
    public class GetAzureRouteFilterCommand: RouteFilterBaseCmdlet
    {
        [Alias("ResourceName")]
        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The resource name.",
            ParameterSetName = "NoExpand")]
        [Parameter(
           Mandatory = true,
           ValueFromPipelineByPropertyName = true,
           HelpMessage = "The resource name.",
           ParameterSetName = "Expand")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The resource group name.",
            ParameterSetName = "NoExpand")]
        [Parameter(
           Mandatory = true,
           ValueFromPipelineByPropertyName = true,
           HelpMessage = "The resource group name.",
           ParameterSetName = "Expand")]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The resource reference to be expanded.",
            ParameterSetName = "Expand")]
        [ValidateNotNullOrEmpty]
        public string ExpandResource { get; set; }

        public override void Execute()
        {
            base.Execute();
            if (!string.IsNullOrEmpty(this.Name))
            {
                var routeFilter = this.GetRouteFilter(this.ResourceGroupName, this.Name, this.ExpandResource);

                WriteObject(routeFilter);
            }
            else if (!string.IsNullOrEmpty(this.ResourceGroupName))
            {
                var routeFilterList = this.RouteFilterClient.ListByResourceGroup(this.ResourceGroupName);

                var psRouteFilters = new List<PSRouteFilter>();

                foreach (var routeFilter in routeFilterList)
                {
                    var psRouteFilter = this.ToPsRouteFilter(routeFilter);
                    psRouteFilter.ResourceGroupName = this.ResourceGroupName;
                    psRouteFilters.Add(psRouteFilter);
                }

                WriteObject(psRouteFilters, true);
            }
            else
            {
                var routeFilterList = this.RouteFilterClient.List();

                var psRouteFilters = new List<PSRouteFilter>();

                foreach (var routeFilter in routeFilterList)
                {
                    var psRouteFilter = this.ToPsRouteFilter(routeFilter);
                    psRouteFilter.ResourceGroupName = NetworkBaseCmdlet.GetResourceGroup(routeFilter.Id);
                    psRouteFilters.Add(psRouteFilter);
                }

                WriteObject(psRouteFilters, true);
            }
        }
    }
}
