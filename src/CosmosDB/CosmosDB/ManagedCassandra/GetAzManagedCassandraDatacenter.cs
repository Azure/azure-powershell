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
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Management.CosmosDB.Models;
using Microsoft.Azure.Commands.CosmosDB.Models;
using Microsoft.Azure.Commands.CosmosDB.Helpers;

namespace Microsoft.Azure.Commands.CosmosDB
{
    [Cmdlet(VerbsCommon.Get, ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "ManagedCassandraDatacenter", DefaultParameterSetName = NameParameterSet), OutputType(typeof(PSManagedCassandraDatacenterGetResults))]
    public class GetAzManagedCassandraDatacenter: AzureCosmosDBCmdletBase
    {
        [Parameter(Mandatory = true, ParameterSetName = NameParameterSet, HelpMessage = Constants.ResourceGroupNameHelpMessage)]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Parameter(Mandatory = true, ParameterSetName = NameParameterSet, HelpMessage = Constants.ManagedCassandraClusterNameHelpMessage)]
        [ValidateNotNullOrEmpty]
        public string ClusterName { get; set; }

        [Parameter(Mandatory = false, ParameterSetName = NameParameterSet, HelpMessage = Constants.ManagedCassandraDatacenterNameHelpMessage)]
        [ValidateNotNullOrEmpty]
        public string DataCenterName { get; set; }

        public override void ExecuteCmdlet()
        {
            if (!string.IsNullOrEmpty(DataCenterName))
            {
                DataCenterResource dataCenterResource = CosmosDBManagementClient.CassandraDataCenters.GetWithHttpMessagesAsync(ResourceGroupName, ClusterName, DataCenterName).GetAwaiter().GetResult().Body;
                WriteObject(new PSManagedCassandraDatacenterGetResults(dataCenterResource));
            }
            else 
            {
                IEnumerable<DataCenterResource> dataCenterResources = CosmosDBManagementClient.CassandraDataCenters.ListWithHttpMessagesAsync(ResourceGroupName, ClusterName).GetAwaiter().GetResult().Body;

                foreach (DataCenterResource dataCenterResource in dataCenterResources)
                    WriteObject(new PSManagedCassandraDatacenterGetResults(dataCenterResource));
            }

            return;
        }
    }
}
