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
using System.Collections;
using System.Management.Automation;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Commands.CosmosDB.Helpers;
using Microsoft.Azure.Commands.CosmosDB.Models;
using Microsoft.Azure.Management.CosmosDB.Models;
using Microsoft.Azure.Management.Internal.Resources.Utilities.Models;

namespace Microsoft.Azure.Commands.CosmosDB
{
    [Cmdlet(VerbsData.Update, ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "CosmosDBFleet", DefaultParameterSetName = NameParameterSet, SupportsShouldProcess = true), OutputType(typeof(PSFleetGetResults))]
    public class UpdateAzCosmosDBFleet : AzureCosmosDBCmdletBase
    {
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        [Parameter(Mandatory = true, ParameterSetName = NameParameterSet, HelpMessage = Constants.ResourceGroupNameHelpMessage)]
        public string ResourceGroupName { get; set; }

        [ValidateNotNullOrEmpty]
        [Parameter(Mandatory = true, ParameterSetName = NameParameterSet, HelpMessage = Constants.FleetNameHelpMessage)]
        public string Name { get; set; }

        [Parameter(Mandatory = false, HelpMessage = Constants.TagsHelpMessage)]
        public Hashtable Tag { get; set; }

        [ValidateNotNull]
        [Parameter(Mandatory = true, ValueFromPipeline = true, ParameterSetName = ObjectParameterSet, HelpMessage = Constants.FleetObjectHelpMessage)]
        public PSFleetGetResults InputObject { get; set; }

        public override void ExecuteCmdlet()
        {
            if (ParameterSetName.Equals(ObjectParameterSet, StringComparison.Ordinal))
            {
                ResourceIdentifier resourceIdentifier = new ResourceIdentifier(InputObject.Id);
                ResourceGroupName = resourceIdentifier.ResourceGroupName;
                Name = InputObject.Name;
            }

            FleetResourceUpdate fleetResourceUpdate = new FleetResourceUpdate();

            FleetResource fleetResults = CosmosDBManagementClient.Fleet.UpdateWithHttpMessagesAsync(
                ResourceGroupName,
                Name,
                fleetResourceUpdate).GetAwaiter().GetResult().Body;
            WriteObject(new PSFleetGetResults(fleetResults));

            return;
        }
    }
}
