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
using System.Collections.Generic;

namespace Microsoft.Azure.Commands.CosmosDB
{
    [Cmdlet(VerbsCommon.New, ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "ManagedCassandraCluster", DefaultParameterSetName = NameParameterSet, SupportsShouldProcess = true), OutputType(typeof(PSClusterResource), typeof(ConflictingResourceException))]
    public class NewAzManagedCassandraCluster : NewOrUpdateAzManagedCassandraCluster
    {

        [Parameter(Mandatory = true, HelpMessage = Constants.ManagedCassandraLocationHelpMessage)]
        [ValidateNotNullOrEmpty]
        public string Location { get; set; }

        [Parameter(Mandatory = true, HelpMessage = Constants.ManagedCassandraDelegatedSubnetIdHelpMessage)]
        [ValidateNotNullOrEmpty]
        public string DelegatedManagementSubnetId { get; set; }

        [Parameter(Mandatory = false, HelpMessage = Constants.ManagedCassandraInitialCassandraAdminPasswordHelpMessage)]
        [ValidateNotNullOrEmpty]
        public string InitialCassandraAdminPassword { get; set; }

        [Parameter(Mandatory = false, HelpMessage = Constants.ManagedCassandraClusterNameOverrideHelpMessage)]
        [ValidateNotNullOrEmpty]
        public string ClusterNameOverride { get; set; }

        [Parameter(Mandatory = false, HelpMessage = Constants.ManagedCassandraRestoreFromBackupIdHelpMessage)]
        [ValidateNotNullOrEmpty]
        public string RestoreFromBackupId { get; set; }


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
            }

            if (clusterResource != null)
            {
                throw new ConflictingResourceException(message: string.Format(ExceptionMessage.Conflict, ClusterName));
            }

            if(InitialCassandraAdminPassword == null && ExternalGossipCertificate == null)
            {
                throw new ArgumentException("At least one out of the InitialCassandraAdminPassword or ExternalGossipCertificates is required.");
            }

            if (InitialCassandraAdminPassword != null && ExternalGossipCertificate != null)
            {
                throw new ArgumentException("Only one out of the InitialCassandraAdminPassword or ExternalGossipCertificates has to be specified.");
            }

            IList<SeedNode> ExternalSeedNodesList = new List<SeedNode>();
            if(ExternalSeedNode != null)
            {
                ExternalSeedNodesList = base.PopulateExternalSeedNodes(ExternalSeedNode);
            }

            IList<Certificate> ClientCertificateList = new List<Certificate>();
            if (ClientCertificate != null)
            {
                ClientCertificateList = base.PopulateCertificates(ClientCertificate);
            }

            IList<Certificate> ExternalGossipCertificateList = new List<Certificate>();
            if (ExternalGossipCertificate != null)
            {
                ExternalGossipCertificateList = base.PopulateCertificates(ExternalGossipCertificate);
            }

            Dictionary<string, string> tagsDict = new Dictionary<string, string>();
            if (Tag != null)
            {
                tagsDict = base.PopulateTags(Tag);
            }

            ClusterResource ClusterCreateParameters = new ClusterResource
            {
                Properties = new ClusterResourceProperties
                {                            
                    RepairEnabled = RepairEnabled,
                    CassandraVersion = CassandraVersion,
                    ExternalSeedNodes = ExternalSeedNodesList,
                    ClientCertificates = ClientCertificateList,
                    ClusterNameOverride = ClusterNameOverride,
                    RestoreFromBackupId = RestoreFromBackupId,
                    HoursBetweenBackups = TimeBetweenBackupInHours,
                    AuthenticationMethod = AuthenticationMethod,
                    ExternalGossipCertificates = ExternalGossipCertificateList,
                    DelegatedManagementSubnetId = DelegatedManagementSubnetId,
                    InitialCassandraAdminPassword = InitialCassandraAdminPassword,
                },
                Location = Location,
                Tags = tagsDict
            };

            if (ShouldProcess(ClusterName, "Creating a new Managed Cassandra Cluster"))
            {
                ClusterResource clusterResourceResult = CosmosDBManagementClient.CassandraClusters.CreateUpdateWithHttpMessagesAsync(ResourceGroupName, ClusterName, ClusterCreateParameters).GetAwaiter().GetResult().Body;
                WriteObject(new PSClusterResource(clusterResourceResult));
            }

            return;
        }
    }
}
