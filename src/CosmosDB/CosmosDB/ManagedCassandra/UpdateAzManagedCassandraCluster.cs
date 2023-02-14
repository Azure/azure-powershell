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
using Microsoft.Azure.Management.Internal.Resources.Utilities.Models;
using System;
using Microsoft.Azure.Commands.CosmosDB.Helpers;

namespace Microsoft.Azure.Commands.CosmosDB
{
    [Cmdlet("Update", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "ManagedCassandraCluster", DefaultParameterSetName = NameParameterSet, SupportsShouldProcess = true), OutputType(typeof(PSClusterResource))]
    public class UpdateAzManagedCassandraCluster : NewOrUpdateAzManagedCassandraCluster
    {
        [Parameter(Mandatory = true, ParameterSetName = ResourceIdParameterSet, HelpMessage = Constants.ResourceIdHelpMessage)]
        [ValidateNotNullOrEmpty]
        public string ResourceId { get; set; }

        [Parameter(Mandatory = true, ValueFromPipeline = true, ParameterSetName = ObjectParameterSet, HelpMessage = Constants.ManagedCassandraClusterObjectHelpMessage)]
        [ValidateNotNull]
        public PSClusterResource InputObject { get; set; }

        public override void ExecuteCmdlet()
        {
            if (!ParameterSetName.Equals(NameParameterSet, StringComparison.Ordinal))
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
                ClusterName = resourceIdentifier.ResourceName;
            }

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
            if (ExternalSeedNode != null)
            {
                ExternalSeedNodesList = base.PopulateExternalSeedNodes(ExternalSeedNode);
            }
            else
            {                
                ExternalSeedNodesList = clusterResource.Properties.ExternalSeedNodes;
            }

            IList<Certificate> ClientCertificateList;
            if (ClientCertificate != null)
            {
                ClientCertificateList = base.PopulateCertificates(ClientCertificate);
            }
            else
            {
                ClientCertificateList = clusterResource.Properties.ClientCertificates;
            }

            IList<Certificate> ExternalGossipCertificateList;
            if (ExternalGossipCertificate != null)
            {
                ExternalGossipCertificateList = base.PopulateCertificates(ExternalGossipCertificate);
            }
            else
            {
                ExternalGossipCertificateList = clusterResource.Properties.ExternalGossipCertificates;
            }

            IDictionary<string, string> tagsDict;
            if (Tag != null)
            {
                tagsDict = base.PopulateTags(Tag);
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
                    HoursBetweenBackups = TimeBetweenBackupInHours ?? clusterResource.Properties.HoursBetweenBackups,
                    AuthenticationMethod = AuthenticationMethod ?? clusterResource.Properties.AuthenticationMethod,
                },
                Location = clusterResource.Location,
                Tags = tagsDict
            };

            if (ShouldProcess(ClusterName, "Updating Managed Cassandra Cluster."))
            {
                ClusterResource clusterResourceResult = CosmosDBManagementClient.CassandraClusters.CreateUpdateWithHttpMessagesAsync(ResourceGroupName, ClusterName, ClusterUpdateParameters).GetAwaiter().GetResult().Body;
                WriteObject(new PSClusterResource(clusterResourceResult));
            }

            return;
        }
    }
}
