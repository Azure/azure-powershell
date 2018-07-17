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

using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Management.Internal.Resources.Utilities.Models;
using System;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.Management.Search.SearchService
{
    [Cmdlet(VerbsCommon.Get, SearchServiceNounStr, DefaultParameterSetName = ResourceNameParameterSetName), OutputType(typeof(Models.PSSearchService))]
    public class GetSearchServiceCommand : SearchServiceBaseCmdlet
    {
        [Parameter(
            Position = 0,
            Mandatory = true,
            ParameterSetName = ResourceGroupParameterSetName,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = ResourceGroupHelpMessage)]
        [ValidateNotNullOrEmpty]
        [ResourceGroupCompleter()]
        public string ResourceGroupName { get; set; }

        [Parameter(
            Position = 1,
            Mandatory = false,
            ParameterSetName = ResourceGroupParameterSetName,
            HelpMessage = ResourceNameHelpMessage)]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(
            Position = 0,
            Mandatory = true,
            ParameterSetName = ResourceIdParameterSetName,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = ResourceIdHelpMessage)]
        [ValidateNotNullOrEmpty]
        public string ResourceId { get; set; }

        public override void ExecuteCmdlet()
        {
            if (ParameterSetName.Equals(ResourceGroupParameterSetName, StringComparison.InvariantCulture))
            {
                if (Name == null)
                {
                    var svcs = SearchClient.Services.ListByResourceGroupWithHttpMessagesAsync(ResourceGroupName).Result;
                    WriteSearchServiceList(svcs.Body);
                    return;
                }
            }
            else if (ParameterSetName.Equals(ResourceIdParameterSetName, StringComparison.InvariantCulture))
            {
                var id = new ResourceIdentifier(ResourceId);
                ResourceGroupName = id.ResourceGroupName;
                Name = id.ResourceName;
            }

            try
            {
                var svc = SearchClient.Services.GetWithHttpMessagesAsync(ResourceGroupName, Name).Result;
                WriteSearchService(svc.Body);
            }
            catch (Exception e)
            {
                // the method throws an exception when there the service does not exist.
            }
        }
    }
}
