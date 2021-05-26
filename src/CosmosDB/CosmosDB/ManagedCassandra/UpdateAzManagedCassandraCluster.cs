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

namespace Microsoft.Azure.Commands.CosmosDB
{
    [Cmdlet("Update", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "ManagedCassandraCluster", DefaultParameterSetName = NameParameterSet, SupportsShouldProcess = true), OutputType(typeof(PSManagedCassandraClusterGetResults))]
    public class UpdateAzManagedCassandraCluster : NewOrUpdateAzManagedCassandraCluster
    {
        public override void ExecuteCmdlet()
        {
            ClusterResource clusterResource = null;
            try
            {
                clusterResource = CosmosDBManagementClient.CassandraClusters.GetWithHttpMessagesAsync(ResourceGroupName, ClusterName).GetAwaiter().GetResult().Body;
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

            IList<SeedNode> ExternalSeedNodesList;
            if (ExternalSeedNodes != null)
            {
                ExternalSeedNodesList = base.PopulateSeedNodes(ExternalSeedNodes);
            }
            else
            {                
                ExternalSeedNodesList = clusterResource.Properties.ExternalSeedNodes;
            }

            IList<Certificate> ClientCertificateList;
            if (ClientCertificates != null)
            {
                ClientCertificateList = base.PopulateCertificates(ClientCertificates);
            }
            else
            {
                ClientCertificateList = clusterResource.Properties.ClientCertificates;
            }

            IList<Certificate> ExternalGossipCertificateList;
            if (ExternalGossipCertificates != null)
            {
                ExternalGossipCertificateList = base.PopulateCertificates(ExternalGossipCertificates);
            }
            else
            {
                ExternalGossipCertificateList = clusterResource.Properties.ExternalGossipCertificates;
            }

            IDictionary<string, string> tagsDict;
            if (Tags != null)
            {
                tagsDict = base.PopulateTags(Tags);
            }
            else
            {
                tagsDict = clusterResource.Tags;
            }

            ClusterResource ClusterUpdateParameters = new ClusterResource
            {
                Properties = new ClusterResourceProperties
                {
                    ExternalSeedNodes = ExternalSeedNodesList,
                    ClientCertificates = ClientCertificateList,
                    ExternalGossipCertificates = ExternalGossipCertificateList,
                    ProvisioningState = clusterResource.Properties.ProvisioningState,
                    RestoreFromBackupId = clusterResource.Properties.RestoreFromBackupId,
                    ClusterNameOverride = clusterResource.Properties.ClusterNameOverride,
                    RepairEnabled = RepairEnabled ?? clusterResource.Properties.RepairEnabled,
                    CassandraVersion = CassandraVersion ?? clusterResource.Properties.CassandraVersion,
                    DelegatedManagementSubnetId = clusterResource.Properties.DelegatedManagementSubnetId,
                    InitialCassandraAdminPassword = clusterResource.Properties.InitialCassandraAdminPassword,
                    HoursBetweenBackups = HoursBetweenBackups ?? clusterResource.Properties.HoursBetweenBackups,
                    AuthenticationMethod = AuthenticationMethod ?? clusterResource.Properties.AuthenticationMethod,
                },
                Location = clusterResource.Location,
                Identity = Identity,
                Tags = tagsDict
            };

            if (ShouldProcess(ClusterName, "Updating Managed Cassandra Cluster."))
            {
                ClusterResource clusterResourceResult = CosmosDBManagementClient.CassandraClusters.CreateUpdateWithHttpMessagesAsync(ResourceGroupName, ClusterName, ClusterUpdateParameters).GetAwaiter().GetResult().Body;
                WriteObject(new PSManagedCassandraClusterGetResults(clusterResourceResult));
            }

            return;
        }
    }
}
