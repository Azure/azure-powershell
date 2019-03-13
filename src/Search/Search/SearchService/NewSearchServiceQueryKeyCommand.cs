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

using Microsoft.Azure.Commands.Management.Search.Models;
using Microsoft.Azure.Commands.Management.Search.Properties;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Management.Internal.Resources.Utilities.Models;
using System;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.Management.Search.SearchService
{
    [Cmdlet("New", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "SearchQueryKey", DefaultParameterSetName = ResourceNameParameterSetName, SupportsShouldProcess = true), OutputType(typeof(PSSearchQueryKey))]
    public class NewSearchServiceQueryKeyCommand : SearchServiceBaseCmdlet
    {
        [Parameter(
            Position = 0,
            Mandatory = true,
            ValueFromPipeline = true,
            ParameterSetName = ParentObjectParameterSetName,
            HelpMessage = InputObjectHelpMessage)]
        [ValidateNotNullOrEmpty]
        public PSSearchService ParentObject { get; set; }

        [Parameter(
            Position = 0,
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            ParameterSetName = ParentResourceIdParameterSetName,
            HelpMessage = ResourceIdHelpMessage)]
        [ValidateNotNullOrEmpty]
        public string ParentResourceId { get; set; }

        [Parameter(
            Position = 0,
            Mandatory = true,
            ParameterSetName = ResourceNameParameterSetName,
            HelpMessage = ResourceGroupHelpMessage)]
        [ResourceGroupCompleter()]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Parameter(
            Position = 1,
            Mandatory = true,
            ParameterSetName = ResourceNameParameterSetName,
            HelpMessage = ResourceNameHelpMessage)]
        [ValidateNotNullOrEmpty]
        public string ServiceName { get; set; }

        [Parameter(
           Mandatory = true,
           HelpMessage = QueryKeyNameHelpMessage)]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        public override void ExecuteCmdlet()
        {
            if (ParameterSetName.Equals(ParentObjectParameterSetName, StringComparison.InvariantCulture))
            {
                ResourceGroupName = ParentObject.ResourceGroupName;
                ServiceName = ParentObject.Name;
            }
            else if (ParameterSetName.Equals(ParentResourceIdParameterSetName, StringComparison.InvariantCulture))
            {
                var id = new ResourceIdentifier(ParentResourceId);
                ResourceGroupName = id.ResourceGroupName;
                ServiceName = id.ResourceName;
            }

            if (ShouldProcess(Name, Resources.CreateQueryKey))
            {
                CatchThrowInnerException(() =>
                {
                    var res = SearchClient.QueryKeys.CreateWithHttpMessagesAsync(ResourceGroupName, ServiceName, Name).Result;
                    WriteQueryKey(res.Body);
                });
            }
        }
    }
}
