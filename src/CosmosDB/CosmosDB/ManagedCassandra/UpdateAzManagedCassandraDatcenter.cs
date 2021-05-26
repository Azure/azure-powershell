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

using System.Management.Automation;
using Microsoft.Azure.Commands.CosmosDB.Models;
using System.Collections.Generic;
using Microsoft.Azure.Management.CosmosDB.Models;
using Microsoft.Rest.Azure;
using Microsoft.Azure.Commands.CosmosDB.Exceptions;
using Microsoft.Azure.PowerShell.Cmdlets.CosmosDB.Exceptions;
using System;

namespace Microsoft.Azure.Commands.CosmosDB
{
    [Cmdlet("Update", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "ManagedCassandraDatacenter", DefaultParameterSetName = NameParameterSet, SupportsShouldProcess = true), OutputType(typeof(PSManagedCassandraDatacenterGetResults))]
    public class UpdateAzManagedCassandraDatacenter : NewOrUpdateAzManagedCassandraDatacenter
    {
        public override void ExecuteCmdlet()
        {
            DataCenterResource dataCenterResource = null;
            try
            {
                dataCenterResource = CosmosDBManagementClient.CassandraDataCenters.GetWithHttpMessagesAsync(ResourceGroupName, ClusterName, DatacenterName).GetAwaiter().GetResult().Body;
            }
            catch (CloudException e)
            {
                if (e.Response.StatusCode != System.Net.HttpStatusCode.NotFound)
                {
                    throw;
                }
                else
                {
                    throw new ResourceNotFoundException(message: string.Format(ExceptionMessage.NotFound, ClusterName), innerException: e);
                }
            }

            if (NodeCount < 3)
            {
                throw new ArgumentException("The minimum value for number of virtual machines should be 3.");
            }

            DataCenterResource datacenterUpdateParameters = new DataCenterResource
            {
                Properties = new DataCenterResourceProperties
                {
                    DataCenterLocation = dataCenterResource.Properties.DataCenterLocation,
                    DelegatedSubnetId = dataCenterResource.Properties.DelegatedSubnetId,
                    NodeCount = NodeCount,
                    Base64EncodedCassandraYamlFragment = Base64EncodedCassandraYamlFragment
                }
            };

            if (ShouldProcess(ClusterName, "Updating Managed Cassandra Datacenter."))
            {
                DataCenterResource dataCenterResourceResult = CosmosDBManagementClient.CassandraDataCenters.CreateUpdateWithHttpMessagesAsync(ResourceGroupName, ClusterName, DatacenterName, datacenterUpdateParameters).GetAwaiter().GetResult().Body;
                WriteObject(new PSManagedCassandraDatacenterGetResults(dataCenterResourceResult));
            }

            return;
        }
    }
}
