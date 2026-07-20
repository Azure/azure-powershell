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

using System;
using System.Collections.Generic;
using System.Management.Automation;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Commands.CosmosDB.Helpers;
using Microsoft.Azure.Commands.CosmosDB.Models;
using Microsoft.Azure.Management.CosmosDB.Models;
using Microsoft.Azure.Management.Internal.Resources.Utilities.Models;

namespace Microsoft.Azure.Commands.CosmosDB
{
    [Cmdlet(VerbsCommon.Get, ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "CosmosDBFleetspace", DefaultParameterSetName = NameParameterSet), OutputType(typeof(PSFleetspaceGetResults))]
    public class GetAzCosmosDBFleetspace : AzureCosmosDBCmdletBase
    {
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        [Parameter(Mandatory = true, ParameterSetName = NameParameterSet, HelpMessage = Constants.ResourceGroupNameHelpMessage)]
        public string ResourceGroupName { get; set; }

        [ValidateNotNullOrEmpty]
        [Parameter(Mandatory = true, ParameterSetName = NameParameterSet, HelpMessage = Constants.FleetNameHelpMessage)]
        public string FleetName { get; set; }

        [ValidateNotNullOrEmpty]
        [Parameter(Mandatory = false, HelpMessage = Constants.FleetspaceNameHelpMessage)]
        public string Name { get; set; }

        [ValidateNotNull]
        [Parameter(Mandatory = true, ValueFromPipeline = true, ParameterSetName = ParentObjectParameterSet, HelpMessage = Constants.FleetObjectHelpMessage)]
        public PSFleetGetResults ParentObject { get; set; }

        public override void ExecuteCmdlet()
        {
            if (ParameterSetName.Equals(ParentObjectParameterSet, StringComparison.Ordinal))
            {
                ResourceIdentifier resourceIdentifier = new ResourceIdentifier(ParentObject.Id);
                ResourceGroupName = resourceIdentifier.ResourceGroupName;
                FleetName = ParentObject.Name;
            }

            if (!string.IsNullOrEmpty(Name))
            {
                FleetspaceResource fleetspaceResource = CosmosDBManagementClient.Fleetspace.GetWithHttpMessagesAsync(ResourceGroupName, FleetName, Name).GetAwaiter().GetResult().Body;
                WriteObject(new PSFleetspaceGetResults(fleetspaceResource));
            }
            else
            {
                IEnumerable<FleetspaceResource> fleetspaceResources = CosmosDBManagementClient.Fleetspace.ListWithHttpMessagesAsync(ResourceGroupName, FleetName).GetAwaiter().GetResult().Body;

                foreach (FleetspaceResource fleetspaceResource in fleetspaceResources)
                {
                    WriteObject(new PSFleetspaceGetResults(fleetspaceResource));
                }
            }

            return;
        }
    }
}
