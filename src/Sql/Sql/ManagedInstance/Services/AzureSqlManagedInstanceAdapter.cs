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

using Microsoft.Azure.Commands.Sql.ManagedInstance.Model;
using Microsoft.Azure.Commands.Sql.ManagedInstance.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security;
using System.Security.Permissions;
using Microsoft.Azure.Commands.ResourceManager.Common.Tags;
using Microsoft.Azure.Commands.Common.Authentication.Abstractions;
using Microsoft.Azure.Commands.Sql.Common;
using Microsoft.WindowsAzure.Commands.Common;

namespace Microsoft.Azure.Commands.Sql.ManagedInstance.Adapter
{
    /// <summary>
    /// Adapter for Managed instance operations
    /// </summary>
    public class AzureSqlManagedInstanceAdapter
    {
        /// <summary>
        /// Gets or sets the AzureEndpointsCommunicator which has all the needed management clients
        /// </summary>
        private AzureSqlManagedInstanceCommunicator Communicator { get; set; }

        /// <summary>
        /// Gets or sets the Azure profile
        /// </summary>
        public IAzureContext Context { get; set; }

        /// <summary>
        /// Constructs a Managed instance adapter
        /// </summary>
        /// <param name="context">The current azure profile</param>
        public AzureSqlManagedInstanceAdapter(IAzureContext context)
        {
            Context = context;
            Communicator = new AzureSqlManagedInstanceCommunicator(Context);
        }

        /// <summary>
        /// Gets a managed instance in a resource group
        /// </summary>
        /// <param name="resourceGroupName">The name of the resource group</param>
        /// <param name="managedInstanceName">The name of the managed instance</param>
        /// <returns>The managed instance</returns>
        public AzureSqlManagedInstanceModel GetManagedInstance(string resourceGroupName, string managedInstanceName)
        {
            var resp = Communicator.Get(resourceGroupName, managedInstanceName);
            return CreateManagedInstanceModelFromResponse(resp);
        }

        /// <summary>
        /// Gets a list of all the managed instances in a subscription
        /// </summary>
        /// <returns>A list of all the managed instances</returns>
        public List<AzureSqlManagedInstanceModel> ListManagedInstances()
        {
            var resp = Communicator.List();

            return resp.Select((s) => CreateManagedInstanceModelFromResponse(s)).ToList();
        }

        /// <summary>
        /// Gets a list of all the managed instances in a resource group
        /// </summary>
        /// <param name="resourceGroupName">The name of the resource group</param>
        /// <returns>A list of all the managed instances</returns>
        public List<AzureSqlManagedInstanceModel> ListManagedInstancesByResourceGroup(string resourceGroupName)
        {
            var resp = Communicator.ListByResourceGroup(resourceGroupName);
            return resp.Select((s) =>
            {
                return CreateManagedInstanceModelFromResponse(s);
            }).ToList();
        }

        /// <summary>
        /// Upserts a managed instance
        /// </summary>
        /// <param name="model">The managed instance to upsert</param>
        /// <returns>The updated managed instance model</returns>
        public AzureSqlManagedInstanceModel UpsertManagedInstance(AzureSqlManagedInstanceModel model)
        {
            var resp = Communicator.CreateOrUpdate(model.ResourceGroupName, model.FullyQualifiedDomainName, new Management.Sql.Models.ManagedInstance()
            {
                Location = model.Location,
                Tags = model.Tags,
                AdministratorLogin = model.AdministratorLogin,
                AdministratorLoginPassword = model.AdministratorPassword != null ? ConversionUtilities.SecureStringToString(model.AdministratorPassword) : null,
                Sku = model.Sku != null ? new Management.Sql.Models.Sku(model.Sku.Name, model.Sku.Tier) : null,
                LicenseType = model.LicenseType,
                StorageSizeInGB = model.StorageSizeInGB,
                SubnetId = model.SubnetId,
                VCores = model.VCores,
                Identity = model.Identity,
                Collation = model.Collation,
                PublicDataEndpointEnabled = model.PublicDataEndpointEnabled,
                ProxyOverride = model.ProxyOverride
            });

            return CreateManagedInstanceModelFromResponse(resp);
        }

        /// <summary>
        /// Upserts a managed instance
        /// </summary>
        /// <param name="model">The managed instance to upsert</param>
        /// <returns>The updated managed instance model</returns>
        public AzureSqlManagedInstanceModel UpdateManagedInstance(AzureSqlManagedInstanceModel model)
        {
            var resp = Communicator.Update(model.ResourceGroupName, model.FullyQualifiedDomainName, new Management.Sql.Models.ManagedInstanceUpdate()
            {
                Tags = model.Tags,
                AdministratorLogin = model.AdministratorLogin,
                AdministratorLoginPassword = model.AdministratorPassword != null ? ConversionUtilities.SecureStringToString(model.AdministratorPassword) : null,
                Sku = model.Sku != null ? new Management.Sql.Models.Sku(model.Sku.Name, model.Sku.Tier) : null,
                LicenseType = model.LicenseType,
                StorageSizeInGB = model.StorageSizeInGB,
                SubnetId = model.SubnetId,
                VCores = model.VCores,
                PublicDataEndpointEnabled = model.PublicDataEndpointEnabled,
                ProxyOverride = model.ProxyOverride
            });

            return CreateManagedInstanceModelFromResponse(resp);
        }

        /// <summary>
        /// Deletes a managed instance
        /// </summary>
        /// <param name="resourceGroupName">The resource group the managed instance is in</param>
        /// <param name="managedInstanceName">The name of the managed instance to delete</param>
        public void RemoveManagedInstance(string resourceGroupName, string managedInstanceName)
        {
            Communicator.Remove(resourceGroupName, managedInstanceName);
        }

        /// <summary>
        /// Convert a Management.Sql.LegacySdk.Models.ManagedInstance to AzureSqlDatabaseManagedInstanceModel
        /// </summary>
        /// <param name="resourceGroupName">The resource group the managed instance is in</param>
        /// <param name="resp">The management client managed instance response to convert</param>
        /// <returns>The converted managed instance model</returns>
        private static AzureSqlManagedInstanceModel CreateManagedInstanceModelFromResponse(Management.Sql.Models.ManagedInstance resp)
        {
            AzureSqlManagedInstanceModel managedInstance = new AzureSqlManagedInstanceModel();

            // Extract the resource group name from the ID.
            // ID is in the form:
            // /subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/rgName/providers/Microsoft.Sql/managedInstances/managedInstanceName
            string[] segments = resp.Id.Split('/');
            managedInstance.ResourceGroupName = segments[4];

            managedInstance.ManagedInstanceName = resp.Name;
            managedInstance.Id = resp.Id;
            managedInstance.FullyQualifiedDomainName = resp.FullyQualifiedDomainName;
            managedInstance.AdministratorLogin = resp.AdministratorLogin;
            managedInstance.Location = resp.Location;
            managedInstance.Tags = TagsConversionHelper.CreateTagDictionary(TagsConversionHelper.CreateTagHashtable(resp.Tags), false);
            managedInstance.Identity = resp.Identity;
            managedInstance.FullyQualifiedDomainName = resp.FullyQualifiedDomainName;
            managedInstance.SubnetId = resp.SubnetId;
            managedInstance.LicenseType = resp.LicenseType;
            managedInstance.VCores = resp.VCores;
            managedInstance.StorageSizeInGB = resp.StorageSizeInGB;
            managedInstance.Collation = resp.Collation;
            managedInstance.PublicDataEndpointEnabled = resp.PublicDataEndpointEnabled;
            managedInstance.ProxyOverride = resp.ProxyOverride;

            Management.Internal.Resources.Models.Sku sku = new Management.Internal.Resources.Models.Sku();
            sku.Name = resp.Sku.Name;
            sku.Tier = resp.Sku.Tier;

            managedInstance.Sku = sku;

            return managedInstance;
        }

        /// <summary>
        /// Get instance sku name based on edition
        ///    Edition              | SkuName
        ///    GeneralPurpose       | GP
        ///    BusinessCritical     | BC
        /// </summary>
        /// <param name="tier">Azure Sql database edition</param>
        /// <returns>The sku name</returns>
        public static string GetInstanceSkuPrefix(string tier)
        {
            if (string.IsNullOrWhiteSpace(tier))
            {
                return null;
            }

            return SqlSkuUtils.GetVcoreSkuPrefix(tier) ?? "Unknown";
        }
    }
}
