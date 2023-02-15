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

using Microsoft.Azure.Commands.Common.Authentication.Models;
using Microsoft.Azure.Commands.Sql.InstanceFailoverGroup.Model;
using Microsoft.Azure.Commands.Sql.Services;
using Microsoft.Azure.Management.Sql.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Azure.Commands.Common.Authentication.Abstractions;

namespace Microsoft.Azure.Commands.Sql.InstanceFailoverGroup.Services
{
    /// <summary>
    /// Adapter for InstanceFailoverGroup operations
    /// </summary>
    public class AzureSqlInstanceFailoverGroupAdapter
    {
        /// <summary>
        /// Gets or sets the AzureEndpointsCommunicator which has all the needed management clients
        /// </summary>
        private AzureSqlInstanceFailoverGroupCommunicator Communicator { get; set; }

        /// <summary>
        /// Gets or sets the Azure profile
        /// </summary>
        public IAzureContext Context { get; set; }

        /// <summary>
        /// Gets or sets the Azure Subscription
        /// </summary>
        private IAzureSubscription _subscription { get; set; }

        /// <summary>
        /// Constructs a database adapter
        /// </summary>
        /// <param name="context">The current azure context</param>
        public AzureSqlInstanceFailoverGroupAdapter(IAzureContext context)
        {
            _subscription = context.Subscription;
            Context = context;
            Communicator = new AzureSqlInstanceFailoverGroupCommunicator(Context);
        }

        /// <summary>
        /// Gets an Azure Sql Database InstanceFailoverGroup by name.
        /// </summary>
        /// <param name="resourceGroupName">The name of the resource group</param>
        /// <param name="location">The name of the local region</param>
        /// <param name="failoverGroupName">The name of the Azure Sql Database InstanceFailoverGroup</param>
        /// <returns>The Azure Sql Database InstanceFailoverGroup object</returns>
        internal AzureSqlInstanceFailoverGroupModel GetInstanceFailoverGroup(string resourceGroupName, string location, string failoverGroupName)
        {
            var resp = Communicator.Get(resourceGroupName, location, failoverGroupName);

            return CreateInstanceFailoverGroupModelFromResponse(resp);
        }

        /// <summary>
        /// Gets a list of Azure Sql Databases InstanceFailoverGroup.
        /// </summary>
        /// <param name="resourceGroupName">The name of the resource group</param>
        /// <param name="location">The name of the local region</param>
        /// <returns>A list of database objects</returns>
        internal ICollection<AzureSqlInstanceFailoverGroupModel> ListInstanceFailoverGroups(string resourceGroupName, string location)
        {
            var resp = Communicator.List(resourceGroupName, location);

            return resp.Select((db) =>
            {
                return CreateInstanceFailoverGroupModelFromResponse(db);
            }).ToList();
        }

        /// <summary>
        /// Creates or updates an Azure Sql Database InstanceFailoverGroup.
        /// </summary>
        /// <param name="model">The input parameters for the create/update operation</param>
        /// <returns>The upserted Azure Sql Database InstanceFailoverGroup</returns>
        internal AzureSqlInstanceFailoverGroupModel UpsertInstanceFailoverGroup(AzureSqlInstanceFailoverGroupModel model)
        {
            List<PartnerRegionInfo>  partnerRegions = new List<PartnerRegionInfo>();
            PartnerRegionInfo partnerRegion = new PartnerRegionInfo(model.PartnerRegion, "Secondary");
            partnerRegions.Add(partnerRegion);

            List<ManagedInstancePairInfo> pairs = new List<ManagedInstancePairInfo>();
            ManagedInstancePairInfo pair = new ManagedInstancePairInfo();
            pair.PrimaryManagedInstanceId = string.Format(
                AzureSqlInstanceFailoverGroupModel.PrimaryManagedInstanceIdTemplate,
                _subscription.Id.ToString(),
                model.ResourceGroupName,
                model.PrimaryManagedInstanceName);
            pair.PartnerManagedInstanceId = string.Format(
                AzureSqlInstanceFailoverGroupModel.PartnerManagedInstanceIdTemplate,
                model.PartnerSubscriptionId == null ? _subscription.Id.ToString() : model.PartnerSubscriptionId,
                model.PartnerResourceGroupName,
                model.PartnerManagedInstanceName);
            pairs.Add(pair);

            InstanceFailoverGroupReadOnlyEndpoint readOnlyEndpoint = new InstanceFailoverGroupReadOnlyEndpoint();
            readOnlyEndpoint.FailoverPolicy = model.ReadOnlyFailoverPolicy;
            InstanceFailoverGroupReadWriteEndpoint readWriteEndpoint = new InstanceFailoverGroupReadWriteEndpoint();
            readWriteEndpoint.FailoverPolicy = model.ReadWriteFailoverPolicy;

            if (model.FailoverWithDataLossGracePeriodHours.HasValue)
            {
                readWriteEndpoint.FailoverWithDataLossGracePeriodMinutes = checked(model.FailoverWithDataLossGracePeriodHours * 60);
            }

            var resp = Communicator.CreateOrUpdate(model.ResourceGroupName, model.Location, model.Name, new Management.Sql.Models.InstanceFailoverGroup
            {
                ReadWriteEndpoint = readWriteEndpoint,
                ReadOnlyEndpoint = readOnlyEndpoint,
                PartnerRegions = partnerRegions,
                ManagedInstancePairs = pairs
            });

            return CreateInstanceFailoverGroupModelFromResponse(resp);
        }

        /// <summary>
        /// Deletes an instance failover group
        /// </summary>
        /// <param name="resourceGroupName">The resource group the server is in</param>
        /// <param name="location">The name of the local region</param>
        /// <param name="failoverGroupName">The name of the Azure SQL Database Failover Group to delete</param>
        public void RemoveInstanceFailoverGroup(string resourceGroupName, string location, string failoverGroupName)
        {
            Communicator.Remove(resourceGroupName, location, failoverGroupName);
        }

        /// <summary>
        /// Finds and removes the Secondary Link by the secondary resource group and Azure SQL Server
        /// </summary>
        /// <param name="resourceGroupName">The name of the Resource Group containing the primary database</param>
        /// <param name="location">The name of the partner location</param>
        /// <param name="failoverGroupName">The name of the Azure Sql Database FailoverGroup</param>
        /// <param name="allowDataLoss">Whether the failover operation will allow data loss</param>
        /// <returns>The Azure SQL Database ReplicationLink object</returns>
        internal AzureSqlInstanceFailoverGroupModel Failover(string resourceGroupName, string location, string failoverGroupName, bool allowDataLoss)
        {
            if (!allowDataLoss)
            {
                Communicator.Failover(resourceGroupName, location, failoverGroupName);
            }
            else
            {
                Communicator.ForceFailoverAllowDataLoss(resourceGroupName, location, failoverGroupName);
            }

            return null;
        }

        /// <summary>
        /// Converts the response from the service to a powershell database object
        /// </summary>
        /// <param name="failoverGroup">Recommended Action object</param>
        /// <returns>The converted model</returns>
        private AzureSqlInstanceFailoverGroupModel CreateInstanceFailoverGroupModelFromResponse(Management.Sql.Models.InstanceFailoverGroup failoverGroup)
        {
            AzureSqlInstanceFailoverGroupModel model = new AzureSqlInstanceFailoverGroupModel();

            model.Name = failoverGroup.Name;
            model.ReadOnlyFailoverPolicy = failoverGroup.ReadOnlyEndpoint.FailoverPolicy;
            model.ReadWriteFailoverPolicy = failoverGroup.ReadWriteEndpoint.FailoverPolicy;
            model.ReplicationRole = failoverGroup.ReplicationRole;
            model.ReplicationState = failoverGroup.ReplicationState;
            model.FailoverWithDataLossGracePeriodHours = failoverGroup.ReadWriteEndpoint.FailoverWithDataLossGracePeriodMinutes == null ?
                                                        null : failoverGroup.ReadWriteEndpoint.FailoverWithDataLossGracePeriodMinutes / 60;

            model.Id = failoverGroup.Id;

            model.ResourceGroupName = GetUriSegment(failoverGroup.Id, 4);
            model.Location = GetUriSegment(failoverGroup.Id, 8);

            model.PartnerResourceGroupName = GetUriSegment(failoverGroup.ManagedInstancePairs.First().PartnerManagedInstanceId, 4);
            model.PartnerRegion = failoverGroup.PartnerRegions.First().Location;

            model.PrimaryManagedInstanceName = GetUriSegment(failoverGroup.ManagedInstancePairs.First().PrimaryManagedInstanceId, 8);
            model.PartnerManagedInstanceName = GetUriSegment(failoverGroup.ManagedInstancePairs.First().PartnerManagedInstanceId, 8);

            return model;
        }

        private string GetUriSegment(string uri, int segmentNum)
        {
            if (uri != null)
            {
                var segments = uri.Split('/');

                if (segments.Length > segmentNum)
                {
                    return segments[segmentNum];
                }
            }

            return null;
        }
    }
}
