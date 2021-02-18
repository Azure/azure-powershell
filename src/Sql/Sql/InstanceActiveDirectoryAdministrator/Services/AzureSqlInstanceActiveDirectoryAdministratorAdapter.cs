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
using Microsoft.Azure.Commands.Common.Authentication.Abstractions;
using Microsoft.Azure.Commands.Sql.InstanceActiveDirectoryAdministrator.Model;
using Microsoft.Azure.Graph.RBAC.Version1_6.ActiveDirectory;
using Microsoft.Azure.Graph.RBAC.Version1_6.Models;
using Microsoft.Rest.Azure.OData;
using Microsoft.Azure.Management.Sql.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Microsoft.Azure.Commands.Sql.InstanceActiveDirectoryAdministrator.Services
{
    /// <summary>
    /// Adapter for Azure SQL Instance Active Directory administrator operations
    /// </summary>
    public class AzureSqlInstanceActiveDirectoryAdministratorAdapter
    {
        /// <summary>
        /// Gets or sets the AzureSqlInstanceActiveDirectoryAdministratorCommunicator which has all the needed management clients
        /// </summary>
        private AzureSqlInstanceActiveDirectoryAdministratorCommunicator Communicator { get; set; }

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
                }
                return this._activeDirectoryClient;
            }

            set { this._activeDirectoryClient = value; }
        }

        /// <summary>
        /// Constructs a Azure SQL Instance Active Directory administrator adapter
        /// </summary>
        /// <param name="profile">The current azure profile</param>
        /// <param name="subscription">The current azure subscription</param>
        public AzureSqlInstanceActiveDirectoryAdministratorAdapter(IAzureContext context)
        {
            Context = context;
            Communicator = new AzureSqlInstanceActiveDirectoryAdministratorCommunicator(Context);
        }

        /// <summary>
        /// Gets an Azure SQL Instance Active Directory administrator by name.
        /// </summary>
        /// <param name="resourceGroupName">The name of the resource group</param>
        /// <param name="managedInstanceName">The name of the Azure SQL Managed Instance that contains the Azure Active Directory administrator</param>
        /// <returns>The Azure Sql InstanceActiveDirectoryAdministrator object</returns>
        internal AzureSqlInstanceActiveDirectoryAdministratorModel GetInstanceActiveDirectoryAdministrator(string resourceGroupName, string managedInstanceName)
        {
            var resp = Communicator.Get(resourceGroupName, managedInstanceName);
            return CreateInstanceActiveDirectoryAdministratorModelFromResponse(resourceGroupName, managedInstanceName, resp);
        }

        /// <summary>
        /// Gets a list of Azure SQL Instance Active Directory administrators.
        /// </summary>
        /// <param name="resourceGroupName">The name of the resource group</param>
        /// <param name="managedInstanceName">The name of the Azure SQL Managed Instance that contains the Azure Active Directory administrator</param>
        /// <returns>A list of Azure SQL Instance Active Directory administrators objects</returns>
        internal ICollection<AzureSqlInstanceActiveDirectoryAdministratorModel> ListInstanceActiveDirectoryAdministrators(string resourceGroupName, string managedInstanceName)
        {
            var response = Communicator.List(resourceGroupName, managedInstanceName);

            return response.Select((administrator) =>
            {
                return new AzureSqlInstanceActiveDirectoryAdministratorModel()
                {
                    ResourceGroupName = resourceGroupName,
                    InstanceName = managedInstanceName,
                    DisplayName = administrator.Login,
                    ObjectId = administrator.Sid
                };
            }).ToList();
        }

        /// <summary>
        /// Creates or updates an Azure SQL Instance Active Directory administrator.
        /// </summary>
        /// <param name="resourceGroup">The name of the resource group</param>
        /// <param name="managedInstanceName">The name of the Azure Sql Managed Instance</param>
        /// <param name="model">The input parameters for the create/update operation</param>
        /// <returns>The upserted Azure SQL Instance Active Directory administrator</returns>
        internal AzureSqlInstanceActiveDirectoryAdministratorModel UpsertInstanceActiveDirectoryAdministrator(string resourceGroup, string managedInstanceName, AzureSqlInstanceActiveDirectoryAdministratorModel model)
        {
            var resp = Communicator.CreateOrUpdate(resourceGroup, managedInstanceName, GetActiveDirectoryInformation(model.DisplayName, model.ObjectId));
            return CreateInstanceActiveDirectoryAdministratorModelFromResponse(resourceGroup, managedInstanceName, resp);
        }

        /// <summary>
        /// Deletes a Azure SQL Instance Active Directory administrator
        /// </summary>
        /// <param name="resourceGroupName">The resource group the managed instance is in</param>
        /// <param name="managedInstanceName">The name of the Azure Sql Managed Instance</param>
        public void RemoveInstanceActiveDirectoryAdministrator(string resourceGroupName, string managedInstanceName)
        {
            Communicator.Remove(resourceGroupName, managedInstanceName);
        }

        /// <summary>
        /// Converts the response from the service to a powershell database object
        /// </summary>
        /// <param name="resourceGroupName">The resource group the managed instance is in</param>
        /// <param name="managedInstanceName">The name of the Azure Sql InstanceActiveDirectoryAdministrator Managed Instance</param>
        /// <param name="admin">The service response</param>
        /// <returns>The converted model</returns>
        public static AzureSqlInstanceActiveDirectoryAdministratorModel CreateInstanceActiveDirectoryAdministratorModelFromResponse(string resourceGroup, string managedInstanceName, ManagedInstanceAdministrator admin)
        {
            AzureSqlInstanceActiveDirectoryAdministratorModel model = new AzureSqlInstanceActiveDirectoryAdministratorModel();

            model.ResourceGroupName = resourceGroup;
            model.InstanceName = managedInstanceName;
            model.DisplayName = admin.Login;
            model.ObjectId = admin.Sid;

            return model;
        }

        /// <summary>
        /// Verifies that the Azure Active Directory user or group exists, and will get the object id if it is not set.
        /// </summary>
        /// <param name="displayName">Azure Active Directory user or group display name</param>
        /// <param name="objectId">Azure Active Directory user or group object id</param>
        /// <returns></returns>
        protected ManagedInstanceAdministrator GetActiveDirectoryInformation(string displayName, Guid objectId)
        {
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

                return new ManagedInstanceAdministrator()
                {
                    Login = displayName,
                    Sid = app.ApplicationId,
                    TenantId = tenantId
                };
            }

            if (group != null)
            {
                return new ManagedInstanceAdministrator()
                {
                    Login = group.DisplayName,
                    Sid = group.Id,
                    TenantId = tenantId
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

                return new ManagedInstanceAdministrator()
                {
                    Login = displayName,
                    Sid = obj.Id,
                    TenantId = tenantId
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
                throw new InvalidOperationException(Properties.Resources.InvalidTenantId);
            }

            return tenantIdGuid;
        }
    }
}
