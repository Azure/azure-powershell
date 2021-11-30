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
using System.Management.Automation;
using Microsoft.Azure.Commands.CosmosDB.Models;
using Microsoft.Azure.Management.CosmosDB.Models;
using Microsoft.Azure.Commands.CosmosDB.Helpers;
using Microsoft.Azure.Commands.CosmosDB.Exceptions;
using Microsoft.Azure.Management.CosmosDB;
using Microsoft.Rest.Azure;
using Microsoft.Azure.PowerShell.Cmdlets.CosmosDB.Exceptions;
using Microsoft.Azure.Management.Internal.Resources.Utilities.Models;

namespace Microsoft.Azure.Commands.CosmosDB
{
    [Cmdlet(VerbsCommon.New, ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "ManagedCassandraDatacenter", DefaultParameterSetName = NameParameterSet, SupportsShouldProcess = true), OutputType(typeof(PSDataCenterResource), typeof(ConflictingResourceException))]
    public class NewAzManagedCassandraDatacenter : NewOrUpdateAzManagedCassandraDatacenter
    {
        [Parameter(Mandatory = true, HelpMessage = Constants.ManagedCassandraDatacenterLocationHelpMessage)]
        [ValidateNotNullOrEmpty]
        public string Location { get; set; }

        [Parameter(Mandatory = true, HelpMessage = Constants.ManagedCassandraDataCenterDelegatedSubnetIdHelpMessage)]
        [ValidateNotNullOrEmpty]
        public string DelegatedSubnetId { get; set; }

        [Parameter(Mandatory = true, ValueFromPipeline = true, ParameterSetName = ParentObjectParameterSet, HelpMessage = Constants.ManagedCassandraClusterObjectHelpMessage)]
        [ValidateNotNull]
        public PSClusterResource ParentObject { get; set; }

        [Parameter(Mandatory = false, HelpMessage = Constants.ManagedCassandraSku)]
        [ValidateNotNullOrEmpty]
        public string Sku { get; set; }

        [Parameter(Mandatory = false, HelpMessage = Constants.ManagedCassandraDiskCapacity)]
        [ValidateNotNullOrEmpty]
        public int? DiskCapacity { get; set; }

        [Parameter(Mandatory = false, HelpMessage = Constants.ManagedCassandraManagedDiskCustomerKeyUri)]
        [ValidateNotNullOrEmpty]
        public string ManagedDiskCustomerKeyUri { get; set; }

        [Parameter(Mandatory = false, HelpMessage = Constants.ManagedCassandraUseAvailabilityZone)]
        public SwitchParameter UseAvailabilityZone { get; set; }

        public override void ExecuteCmdlet()
        {
            if (ParameterSetName.Equals(ParentObjectParameterSet, StringComparison.Ordinal))
            {
                ResourceIdentifier resourceIdentifier = new ResourceIdentifier(ParentObject.Id);
                ResourceGroupName = resourceIdentifier.ResourceGroupName;
                ClusterName = resourceIdentifier.ResourceName;
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
            }

            if (dataCenterResource != null)
            {
                throw new ConflictingResourceException(message: string.Format(ExceptionMessage.Conflict, DatacenterName));
            }

            if (NodeCount < 3)
            {
                throw new ArgumentException("The minimum value for number of virtual machines should be 3.");
            }

            DataCenterResource dataCenterResourceParameters = new DataCenterResource
            {
                Properties = new DataCenterResourceProperties
                {
                    DataCenterLocation = Location,
                    DelegatedSubnetId = DelegatedSubnetId,
                    NodeCount = NodeCount,
                    Base64EncodedCassandraYamlFragment = Base64EncodedCassandraYamlFragment
                }
            };

            if (ShouldProcess(DatacenterName, "Creating a new Managed Cassandra DataCenter"))
            {
                DataCenterResource dataCenterResourceResult = CosmosDBManagementClient.CassandraDataCenters.CreateUpdateWithHttpMessagesAsync(ResourceGroupName, ClusterName, DatacenterName, dataCenterResourceParameters).GetAwaiter().GetResult().Body;
                WriteObject(new PSDataCenterResource(dataCenterResourceResult));
            }

            return;
        }
    }
}
