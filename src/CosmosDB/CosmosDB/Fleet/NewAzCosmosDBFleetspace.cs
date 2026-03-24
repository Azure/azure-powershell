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
    [Cmdlet(VerbsCommon.New, ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "CosmosDBFleetspace", DefaultParameterSetName = NameParameterSet, SupportsShouldProcess = true), OutputType(typeof(PSFleetspaceGetResults))]
    public class NewAzCosmosDBFleetspace : AzureCosmosDBCmdletBase
    {
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        [Parameter(Mandatory = true, ParameterSetName = NameParameterSet, HelpMessage = Constants.ResourceGroupNameHelpMessage)]
        public string ResourceGroupName { get; set; }

        [ValidateNotNullOrEmpty]
        [Parameter(Mandatory = true, ParameterSetName = NameParameterSet, HelpMessage = Constants.FleetNameHelpMessage)]
        public string FleetName { get; set; }

        [ValidateNotNullOrEmpty]
        [Parameter(Mandatory = true, HelpMessage = Constants.FleetspaceNameHelpMessage)]
        public string Name { get; set; }

        [ValidateNotNullOrEmpty]
        [Parameter(Mandatory = true, HelpMessage = Constants.FleetspaceApiKindHelpMessage)]
        [PSArgumentCompleter("NoSQL")]
        public string FleetspaceApiKind { get; set; }

        [ValidateNotNullOrEmpty]
        [Parameter(Mandatory = true, HelpMessage = Constants.ServiceTierHelpMessage)]
        [PSArgumentCompleter("GeneralPurpose", "BusinessCritical")]
        public string ServiceTier { get; set; }

        [ValidateNotNullOrEmpty]
        [Parameter(Mandatory = true, HelpMessage = Constants.DataRegionHelpMessage)]
        public string[] DataRegion { get; set; }

        [Parameter(Mandatory = false, HelpMessage = Constants.ThroughputPoolMinThroughputHelpMessage)]
        public int? ThroughputPoolMinThroughput { get; set; }

        [Parameter(Mandatory = false, HelpMessage = Constants.ThroughputPoolMaxThroughputHelpMessage)]
        public int? ThroughputPoolMaxThroughput { get; set; }

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

            FleetspaceResource fleetspaceResource = new FleetspaceResource
            {
                FleetspaceApiKind = FleetspaceApiKind,
                ServiceTier = ServiceTier,
                DataRegions = DataRegion
            };

            if (ThroughputPoolMinThroughput.HasValue || ThroughputPoolMaxThroughput.HasValue)
            {
                fleetspaceResource.ThroughputPoolConfiguration = new FleetspacePropertiesThroughputPoolConfiguration
                {
                    MinThroughput = ThroughputPoolMinThroughput,
                    MaxThroughput = ThroughputPoolMaxThroughput
                };
            }

            FleetspaceResource fleetspaceResults = CosmosDBManagementClient.Fleetspace.CreateWithHttpMessagesAsync(
                ResourceGroupName,
                FleetName,
                Name,
                fleetspaceResource).GetAwaiter().GetResult().Body;
            WriteObject(new PSFleetspaceGetResults(fleetspaceResults));

            return;
        }
    }
}
