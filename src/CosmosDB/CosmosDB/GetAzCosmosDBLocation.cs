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

using System.Collections.Generic;
using System.Management.Automation;
using Microsoft.Azure.Commands.CosmosDB.Helpers;
using Microsoft.Azure.Commands.CosmosDB.Models;
using Microsoft.Azure.Management.CosmosDB.Models;

namespace Microsoft.Azure.Commands.CosmosDB
{
    [Cmdlet(VerbsCommon.Get, ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "CosmosDBLocation"), OutputType(typeof(PSLocationGetResult))]
    public class GetAzCosmosDBLocation : AzureCosmosDBCmdletBase
    {
        [Parameter(Mandatory = false, HelpMessage = Constants.LocationNameHelpMessage)]
        [ValidateNotNullOrEmpty]
        public string Location { get; set; }

        public override void ExecuteCmdlet()
        {
            if (string.IsNullOrEmpty(Location))
            {
                IEnumerable<LocationGetResult> locationListResult = CosmosDBManagementClient.Locations.ListWithHttpMessagesAsync().GetAwaiter().GetResult().Body;
                foreach (LocationGetResult locationGetResult in locationListResult)
                {
                    WriteObject(new PSLocationGetResult(locationGetResult));
                }
            }
            else
            {
                LocationGetResult locationGetResult = CosmosDBManagementClient.Locations.GetWithHttpMessagesAsync(Location).GetAwaiter().GetResult().Body;
                WriteObject(new PSLocationGetResult(locationGetResult));
            }

            return;
        }
    }
}
