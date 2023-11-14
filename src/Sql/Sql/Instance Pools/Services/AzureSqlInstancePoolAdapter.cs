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

using System.Collections.Generic;
using System.Linq;
using Microsoft.Azure.Commands.Common.Authentication.Abstractions;
using Microsoft.Azure.Commands.ResourceManager.Common.Tags;
using Microsoft.Azure.Commands.Sql.Instance_Pools.Model;
using Microsoft.Azure.Management.Internal.Resources.Utilities.Models;
using Microsoft.Azure.Management.Sql.Models;

namespace Microsoft.Azure.Commands.Sql.Instance_Pools.Services
{
    /// <summary>
    /// Adapter for instance pool operations
    /// </summary>
    public class AzureSqlInstancePoolAdapter
    {
        /// <summary>
        /// Gets or sets the AzureEndpointsCommunicator which has all the needed management clients
        /// </summary>
        private AzureSqlInstancePoolCommunicator Communicator { get; set; }

        /// <summary>
        /// Gets or sets the Azure profile
        /// </summary>
        public IAzureContext Context { get; set; }

        /// <summary>
        /// Constructor for the instance pool adapter
        /// </summary>
        /// <param name="context">The Azure Context</param>
        public AzureSqlInstancePoolAdapter(IAzureContext context)
        {
            Context = context;
            Communicator = new AzureSqlInstancePoolCommunicator(Context);
        }

        #region Instance Pools

        /// <summary>
        /// Creates or updates an instance pool
        /// </summary>
        /// <param name="model">The instance pool entity</param>
        /// <returns>The created or updated instance pool entity</returns>
        public AzureSqlInstancePoolModel UpsertInstancePool(AzureSqlInstancePoolModel model)
        {
            var result = Communicator.UpsertInstancePool(model.ResourceGroupName, model.InstancePoolName,
                new InstancePool()
                {
                    LicenseType = model.LicenseType,
                    Sku = model.Sku,
                    Location = model.Location,
                    SubnetId = model.SubnetId,
                    Tags = model.Tags,
                    VCores = model.VCores,
                    MaintenanceConfigurationId = model.MaintenanceConfigurationId,
                });
            return CreateInstancePoolModelFromResponse(result);
        }

        /// <summary>
        /// Gets an instance pool
        /// </summary>
        /// <param name="resourceGroupName">The resource group name</param>
        /// <param name="instancePoolName">The instance pool name</param>
        /// <returns>An existing instance pool entity</returns>
        public AzureSqlInstancePoolModel GetInstancePool(string resourceGroupName, string instancePoolName)
        {
            var result = Communicator.GetInstancePool(resourceGroupName, instancePoolName);
            return CreateInstancePoolModelFromResponse(result);
        }

        /// <summary>
        /// Gets a list of existing instance pools belonging to the provided resource group
        /// </summary>
        /// <param name="resourceGroupName">The resource group name</param>
        /// <returns>A list of instance pool entities</returns>
        public List<AzureSqlInstancePoolModel> ListInstancePoolsByResourceGroup(string resourceGroupName)
        {
            var result = Communicator.ListByResourceGroup(resourceGroupName);
            return result.Select(CreateInstancePoolModelFromResponse).ToList();
        }

        public List<AzureSqlInstancePoolModel> List()
        {
            var result = Communicator.List();
            return result.Select(CreateInstancePoolModelFromResponse).ToList();
        }

        /// <summary>
        /// Removes an existing instance pool
        /// </summary>
        /// <param name="resourceGroupName">The resource group name</param>
        /// <param name="instancePoolName">The instance pool name</param>
        public void RemoveInstancePool(string resourceGroupName, string instancePoolName)
        {
            Communicator.RemoveInstancePool(resourceGroupName, instancePoolName);
        }

        public AzureSqlInstancePoolModel CreateInstancePoolModelFromResponse(
            InstancePool instancePoolResp)
        {
            return new AzureSqlInstancePoolModel()
            {
                Edition = instancePoolResp.Sku.Tier,
                ComputeGeneration = instancePoolResp.Sku.Family,
                InstancePoolName = instancePoolResp.Name,
                Location = instancePoolResp.Location,
                ResourceGroupName = new ResourceIdentifier(instancePoolResp.Id).ResourceGroupName,
                Id = instancePoolResp.Id,
                SubnetId = instancePoolResp.SubnetId,
                Tags = TagsConversionHelper.CreateTagDictionary(TagsConversionHelper.CreateTagHashtable(instancePoolResp.Tags), false),
                Type = instancePoolResp.Type,
                VCores = instancePoolResp.VCores.Value,
                LicenseType = instancePoolResp.LicenseType,
                Sku = instancePoolResp.Sku,
                MaintenanceConfigurationId = instancePoolResp.MaintenanceConfigurationId,
            };
        }

        #endregion
    }
}
