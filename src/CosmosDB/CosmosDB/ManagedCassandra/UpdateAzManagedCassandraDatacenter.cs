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
using Microsoft.Azure.Commands.CosmosDB.Helpers;
using Microsoft.Azure.Management.Internal.Resources.Utilities.Models;

namespace Microsoft.Azure.Commands.CosmosDB
{
    [Cmdlet("Update", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "ManagedCassandraDatacenter", DefaultParameterSetName = NameParameterSet, SupportsShouldProcess = true), OutputType(typeof(PSDataCenterResource))]
    public class UpdateAzManagedCassandraDatacenter : NewOrUpdateAzManagedCassandraDatacenter
    {
        [Parameter(Mandatory = true, ParameterSetName = ResourceIdParameterSet, HelpMessage = Constants.ResourceIdHelpMessage)]
        [ValidateNotNullOrEmpty]
        public string ResourceId { get; set; }

        [Parameter(Mandatory = true, ValueFromPipeline = true, ParameterSetName = ObjectParameterSet, HelpMessage = Constants.ManagedCassandraDatacenterObjectHelpMessage)]
        [ValidateNotNull]
        public PSDataCenterResource InputObject { get; set; }

        [Parameter(Mandatory = true, ValueFromPipeline = true, ParameterSetName = ParentObjectParameterSet, HelpMessage = Constants.ManagedCassandraClusterObjectHelpMessage)]
        [ValidateNotNull]
        public PSClusterResource ParentObject { get; set; }

        public override void ExecuteCmdlet()
        {
            if (ParameterSetName.Equals(ParentObjectParameterSet, StringComparison.Ordinal))
            {
                ResourceIdentifier resourceIdentifier = new ResourceIdentifier(ParentObject.Id);
                ResourceGroupName = resourceIdentifier.ResourceGroupName;
                ClusterName = resourceIdentifier.ResourceName;
            }
            else if (!ParameterSetName.Equals(NameParameterSet, StringComparison.Ordinal))
            {
                ResourceIdentifier resourceIdentifier = null;
                if (ParameterSetName.Equals(ResourceIdParameterSet))
                {
                    resourceIdentifier = new ResourceIdentifier(ResourceId);
                }
                else if (ParameterSetName.Equals(ObjectParameterSet))
                {
                    resourceIdentifier = new ResourceIdentifier(InputObject.Id);
                }
                ResourceGroupName = resourceIdentifier.ResourceGroupName;
                String[] parentSegments = resourceIdentifier.ParentResource.Split(separator: '/');
                if (parentSegments.Length != 2)
                {
                    throw new ArgumentException("ResourceId is invalid.");
                }
                ClusterName = resourceIdentifier.ParentResource.Split(separator: '/')[1];
                DatacenterName = resourceIdentifier.ResourceName;
            }

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
                    Base64EncodedCassandraYamlFragment = Base64EncodedCassandraYamlFragment ?? dataCenterResource.Properties.Base64EncodedCassandraYamlFragment,
                    NodeCount = NodeCount.HasValue ? NodeCount.Value : dataCenterResource.Properties.NodeCount,
                    BackupStorageCustomerKeyUri = BackupStorageCustomerKeyUri ?? dataCenterResource.Properties.BackupStorageCustomerKeyUri
                }
            };
         
            if (ShouldProcess(ClusterName, "Updating Managed Cassandra Datacenter."))
            {
                DataCenterResource dataCenterResourceResult = CosmosDBManagementClient.CassandraDataCenters.CreateUpdateWithHttpMessagesAsync(ResourceGroupName, ClusterName, DatacenterName, datacenterUpdateParameters).GetAwaiter().GetResult().Body;
                WriteObject(new PSDataCenterResource(dataCenterResourceResult));
            }

            return;
        }
    }
}
