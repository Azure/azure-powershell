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
using Microsoft.Azure.Management.Internal.Resources.Utilities.Models;
using Microsoft.Azure.Management.Sql.Models;
using Microsoft.Azure.Graph.RBAC.Version1_6.ActiveDirectory;
using Microsoft.Azure.Graph.RBAC.Version1_6.Models;
using Microsoft.Rest.Azure.OData;
using ServicePrincipal = Microsoft.Azure.Graph.RBAC.Version1_6.Models.ServicePrincipal;

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
        /// A private instance of ActiveDirectoryClient
        /// </summary>
        private ActiveDirectoryClient _activeDirectoryClient;

        /// <summary>
        /// Gets or sets the Azure ActiveDirectoryClient instance
        /// </summary>
        public ActiveDirectoryClient ActiveDirectoryClient
        {
            get
            {
                if (_activeDirectoryClient == null)
                {
                    _activeDirectoryClient = new ActiveDirectoryClient(Context);
                    if (!Context.Environment.IsEndpointSet(AzureEnvironment.Endpoint.Graph))
                    {
                        throw new ArgumentException(string.Format(Microsoft.Azure.Commands.Sql.Properties.Resources.InvalidGraphEndpoint));
                    }
                    _activeDirectoryClient = new ActiveDirectoryClient(Context);
                }
                return this._activeDirectoryClient;
            }

            set { this._activeDirectoryClient = value; }
        }

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
        /// <param name="expand">The child resources to include in the response.</param>
        /// <returns>The managed instance</returns>
        public AzureSqlManagedInstanceModel GetManagedInstance(string resourceGroupName, string managedInstanceName, string expand = null)
        {
            var resp = Communicator.Get(resourceGroupName, managedInstanceName, expand);
            return CreateManagedInstanceModelFromResponse(resp);
        }

        /// <summary>
        /// Gets a list of all the managed instances in a subscription
        /// </summary>
        /// <returns>A list of all the managed instances</returns>
        public List<AzureSqlManagedInstanceModel> ListManagedInstances(string expand = null)
        {
            var resp = Communicator.List(expand);

            return resp.Select((s) => CreateManagedInstanceModelFromResponse(s)).ToList();
        }

        /// <summary>
        /// Gets a list of all managed instances in an instance pool
        /// </summary>
        /// <returns>A list of all managed instances in an instance pool</returns>
        public List<AzureSqlManagedInstanceModel> ListManagedInstancesByInstancePool(string resourceGroupName, string instancePoolName, string expand = null)
        {
            var resp = Communicator.ListByInstancePool(resourceGroupName, instancePoolName, expand);
            return resp.Select((s) => CreateManagedInstanceModelFromResponse(s)).ToList();
        }

        /// <summary>
        /// Gets a list of all the managed instances in a resource group
        /// </summary>
        /// <param name="resourceGroupName">The name of the resource group</param>
        /// <param name="expand">The child resources to include in the response.</param>
        /// <returns>A list of all the managed instances</returns>
        public List<AzureSqlManagedInstanceModel> ListManagedInstancesByResourceGroup(string resourceGroupName, string expand = null)
        {
            var resp = Communicator.ListByResourceGroup(resourceGroupName, expand);
            return resp.Select((s) =>
            {
                return CreateManagedInstanceModelFromResponse(s);
            }).ToList();
        }

        /// <summary>
        /// Failovers a managed instance.
        /// </summary>
        /// <param name="resourceGroupName">The resource group the instance is in.</param>
        /// <param name="name">The name of Azure Managed Instance to failover.</param>
        /// <param name="replicaType">The type of replica to failover.</param>
        public void FailoverManagedInstance(string resourceGroupName, string name, string replicaType)
        {
            Communicator.Failover(resourceGroupName, name, replicaType);
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
                ProxyOverride = model.ProxyOverride,
                TimezoneId = model.TimezoneId,
                DnsZonePartner = model.DnsZonePartner,
                InstancePoolId = model.InstancePoolName != null ?
                    string.Format("/subscriptions/{0}/resourceGroups/{1}/providers/Microsoft.Sql/instancePools/{2}",
                        Context.Subscription.Id, model.ResourceGroupName, model.InstancePoolName) : null,
                MinimalTlsVersion = model.MinimalTlsVersion,
                RequestedBackupStorageRedundancy = model.RequestedBackupStorageRedundancy,
                MaintenanceConfigurationId = MaintenanceConfigurationHelper.ConvertMaintenanceConfigurationIdArgument(model.MaintenanceConfigurationId, Context.Subscription.Id),
                Administrators = GetActiveDirectoryInformation(model.Administrators),
                PrimaryUserAssignedIdentityId = model.PrimaryUserAssignedIdentityId,
                KeyId = model.KeyId,
                ZoneRedundant = model.ZoneRedundant,
                ServicePrincipal = ResourceServicePrincipalHelper.UnwrapServicePrincipalObject(model.ServicePrincipal)
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
                ProxyOverride = model.ProxyOverride,
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
            managedInstance.TimezoneId = resp.TimezoneId;
            managedInstance.DnsZone = resp.DnsZone;
            managedInstance.InstancePoolName = resp.InstancePoolId != null ?
                new ResourceIdentifier(resp.InstancePoolId).ResourceName : null;
            managedInstance.MinimalTlsVersion = resp.MinimalTlsVersion;
            managedInstance.BackupStorageRedundancy = resp.CurrentBackupStorageRedundancy;
            managedInstance.RequestedBackupStorageRedundancy = resp.RequestedBackupStorageRedundancy;
            managedInstance.CurrentBackupStorageRedundancy = resp.CurrentBackupStorageRedundancy;
            managedInstance.MaintenanceConfigurationId = resp.MaintenanceConfigurationId;
            managedInstance.ServicePrincipal = ResourceServicePrincipalHelper.WrapServicePrincipalObject(resp.ServicePrincipal);

            Management.Internal.Resources.Models.Sku sku = new Management.Internal.Resources.Models.Sku();
            sku.Name = resp.Sku.Name;
            sku.Tier = resp.Sku.Tier;
            sku.Family = resp.Sku.Family;

            managedInstance.Sku = sku;
            managedInstance.Administrators = resp.Administrators;

            if (managedInstance.Administrators != null && managedInstance.Administrators.AdministratorType == null)
            {
                managedInstance.Administrators.AdministratorType = "ActiveDirectory";
            }
            managedInstance.PrimaryUserAssignedIdentityId = resp.PrimaryUserAssignedIdentityId;
            managedInstance.KeyId = resp.KeyId;
            managedInstance.ZoneRedundant = resp.ZoneRedundant;

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

        /// <summary>
        /// Verifies that the Azure Active Directory user or group exists, and will get the object id if it is not set.
        /// </summary>
        /// <param name="input">Azure Active Directory user or group object</param>
        /// <returns></returns>
        protected ManagedInstanceExternalAdministrator GetActiveDirectoryInformation(ManagedInstanceExternalAdministrator input)
        {
            if (input == null || string.IsNullOrEmpty(input.Login))
            {
                return null;
            }

            Guid? objectId = input.Sid;
            string displayName = input.Login;
            bool? adOnlyAuth = input.AzureADOnlyAuthentication;

            // Gets the default Tenant id for the subscriptions
            Guid tenantId = GetTenantId();

            // Check for a Azure Active Directory group. Recommended to always use group.
            IEnumerable<PSADGroup> groupList = null;
            PSADGroup group = null;

            var filter = new ADObjectFilterOptions()
            {
                Id = (objectId != null && objectId != Guid.Empty) ? objectId.ToString() : null,
                SearchString = displayName,
                Paging = true,
            };

            // Get a list of groups from Azure Active Directory
            groupList = ActiveDirectoryClient.FilterGroups(filter).Where(gr => string.Equals(gr.DisplayName, displayName, StringComparison.OrdinalIgnoreCase));

            if (groupList != null && groupList.Count() > 1)
            {
                // More than one group was found with that display name.
                throw new ArgumentException(string.Format(Microsoft.Azure.Commands.Sql.Properties.Resources.ADGroupMoreThanOneFound, displayName));
            }
            else if (groupList != null && groupList.Count() == 1)
            {
                // Only one group was found. Get the group display name and object id
                group = groupList.First();

                // Only support Security Groups
                if (group.SecurityEnabled.HasValue && !group.SecurityEnabled.Value)
                {
                    throw new ArgumentException(string.Format(Microsoft.Azure.Commands.Sql.Properties.Resources.InvalidADGroupNotSecurity, displayName));
                }
            }

            // Lookup for serviceprincipals
            ODataQuery<ServicePrincipal> odataQueryFilter;

            if ((objectId != null && objectId != Guid.Empty))
            {
                var applicationIdString = objectId.ToString();
                odataQueryFilter = new Rest.Azure.OData.ODataQuery<ServicePrincipal>(a => a.AppId == applicationIdString);
            }
            else
            {
                odataQueryFilter = new Rest.Azure.OData.ODataQuery<ServicePrincipal>(a => a.DisplayName == displayName);
            }

            var servicePrincipalList = ActiveDirectoryClient.FilterServicePrincipals(odataQueryFilter);

            if (servicePrincipalList != null && servicePrincipalList.Count() > 1)
            {
                // More than one service principal was found.
                throw new ArgumentException(string.Format(Microsoft.Azure.Commands.Sql.Properties.Resources.ADApplicationMoreThanOneFound, displayName));
            }
            else if (servicePrincipalList != null && servicePrincipalList.Count() == 1)
            {
                // Only one user was found. Get the user display name and object id
                PSADServicePrincipal app = servicePrincipalList.First();

                if (displayName != null && string.CompareOrdinal(displayName, app.DisplayName) != 0)
                {
                    throw new ArgumentException(string.Format(Microsoft.Azure.Commands.Sql.Properties.Resources.ADApplicationDisplayNameMismatch, displayName, app.DisplayName));
                }

                if (group != null)
                {
                    throw new ArgumentException(string.Format(Microsoft.Azure.Commands.Sql.Properties.Resources.ADDuplicateGroupAndApplicationFound, displayName));
                }

                return new ManagedInstanceExternalAdministrator()
                {
                    Login = displayName,
                    Sid = app.ApplicationId,
                    TenantId = tenantId,
                    PrincipalType = "Application",
                    AzureADOnlyAuthentication = adOnlyAuth
                };
            }

            if (group != null)
            {
                return new ManagedInstanceExternalAdministrator()
                {
                    Login = group.DisplayName,
                    Sid = group.Id,
                    TenantId = tenantId,
                    PrincipalType = "Group",
                    AzureADOnlyAuthentication = adOnlyAuth
                };
            }

            // No group or service principal was found. Check for a user
            filter = new ADObjectFilterOptions()
            {
                Id = (objectId != null && objectId != Guid.Empty) ? objectId.ToString() : null,
                SearchString = displayName,
                Paging = true,
            };

            // Get a list of user from Azure Active Directory
            var userList = ActiveDirectoryClient.FilterUsers(filter).Where(gr => string.Equals(gr.DisplayName, displayName, StringComparison.OrdinalIgnoreCase));

            // No user was found. Check if the display name is a UPN
            if (userList == null || userList.Count() == 0)
            {
                // Check if the display name is the UPN
                filter = new ADObjectFilterOptions()
                {
                    Id = (objectId != null && objectId != Guid.Empty) ? objectId.ToString() : null,
                    UPN = displayName,
                    Paging = true,
                };

                userList = ActiveDirectoryClient.FilterUsers(filter).Where(gr => string.Equals(gr.UserPrincipalName, displayName, StringComparison.OrdinalIgnoreCase));
            }

            // No user was found. Check if the display name is a guest user. 
            if (userList == null || userList.Count() == 0)
            {
                // Check if the display name is the UPN
                filter = new ADObjectFilterOptions()
                {
                    Id = (objectId != null && objectId != Guid.Empty) ? objectId.ToString() : null,
                    Mail = displayName,
                    Paging = true,
                };

                userList = ActiveDirectoryClient.FilterUsers(filter);
            }

            // No user was found
            if (userList == null || userList.Count() == 0)
            {
                throw new ArgumentException(string.Format(Microsoft.Azure.Commands.Sql.Properties.Resources.ADObjectNotFound, displayName));
            }
            else if (userList.Count() > 1)
            {
                // More than one user was found.
                throw new ArgumentException(string.Format(Microsoft.Azure.Commands.Sql.Properties.Resources.ADUserMoreThanOneFound, displayName));
            }
            else
            {
                // Only one user was found. Get the user display name and object id
                var obj = userList.First();

                return new ManagedInstanceExternalAdministrator()
                {
                    Login = displayName,
                    Sid = obj.Id,
                    TenantId = tenantId,
                    PrincipalType = "User",
                    AzureADOnlyAuthentication = adOnlyAuth
                };
            }
        }

        /// <summary>
        /// Get the default tenantId for the current subscription
        /// </summary>
        /// <returns></returns>
        protected Guid GetTenantId()
        {
            var tenantIdStr = Context.Tenant.Id.ToString();
            string adTenant = Context.Environment.GetEndpoint(AzureEnvironment.Endpoint.AdTenant);
            string graph = Context.Environment.GetEndpoint(AzureEnvironment.Endpoint.Graph);
            var tenantIdGuid = Guid.Empty;

            if (string.IsNullOrWhiteSpace(tenantIdStr) || !Guid.TryParse(tenantIdStr, out tenantIdGuid))
            {
                throw new InvalidOperationException(Microsoft.Azure.Commands.Sql.Properties.Resources.InvalidTenantId);
            }

            return tenantIdGuid;
        }
    }
}