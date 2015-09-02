﻿// ----------------------------------------------------------------------------------
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

extern alias MicrosoftAzureCommandsResources;

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using Microsoft.Azure.Commands.Sql.Common;
using Microsoft.Azure.Commands.Sql.ServerActiveDirectoryAdministrator.Model;
using Microsoft.Azure.Commands.Sql.Properties;
using Microsoft.Azure.Commands.Sql.Server.Adapter;
using Microsoft.Azure.Commands.Sql.Services;
using Microsoft.Azure.Common.Authentication.Models;
using Microsoft.Azure.Management.Sql;
using Microsoft.Azure.Management.Sql.Models;
using MicrosoftAzureCommandsResourcesModelsActiveDirectory = MicrosoftAzureCommandsResources::Microsoft.Azure.Commands.Resources.Models.ActiveDirectory;
using Microsoft.Azure.Common.Authentication;

namespace Microsoft.Azure.Commands.Sql.ServerActiveDirectoryAdministrator.Services
{
    /// <summary>
    /// Adapter for Azure SQL Server Active Directory administrator operations
    /// </summary>
    public class AzureSqlServerActiveDirectoryAdministratorAdapter
    {
        /// <summary>
        /// Gets or sets the AzureSqlServerActiveDirectoryAdministratorCommunicator which has all the needed management clients
        /// </summary>
        private AzureSqlServerActiveDirectoryAdministratorCommunicator Communicator { get; set; }

        /// <summary>
        /// Gets or sets the Azure profile
        /// </summary>
        public AzureProfile Profile { get; set; }

        /// <summary>
        /// Gets or sets the Azure Subscription
        /// </summary>
        private AzureSubscription _subscription { get; set; }

        /// <summary>
        /// A private instance of ActiveDirectoryClient
        /// </summary>
        private MicrosoftAzureCommandsResourcesModelsActiveDirectory.ActiveDirectoryClient _activeDirectoryClient;

        /// <summary>
        /// Gets or sets the Azure ActiveDirectoryClient instance
        /// </summary>
        public MicrosoftAzureCommandsResourcesModelsActiveDirectory.ActiveDirectoryClient ActiveDirectoryClient
        {
            get
            {
                if (_activeDirectoryClient == null)
                {
                    if (!Profile.Context.Environment.IsEndpointSet(AzureEnvironment.Endpoint.Graph))
                    {
                        throw new ArgumentException(string.Format(Resources.InvalidGraphEndpoint));
                    }
                    _activeDirectoryClient = new MicrosoftAzureCommandsResourcesModelsActiveDirectory.ActiveDirectoryClient(Profile.Context);
                }
                return this._activeDirectoryClient;
            }
            
            set { this._activeDirectoryClient = value; }
        }

        /// <summary>
        /// Constructs a Azure SQL Server Active Directory administrator adapter
        /// </summary>
        /// <param name="profile">The current azure profile</param>
        /// <param name="subscription">The current azure subscription</param>
        public AzureSqlServerActiveDirectoryAdministratorAdapter(AzureProfile Profile, AzureSubscription subscription)
        {
            this.Profile = Profile;
            this._subscription = subscription;
            Communicator = new AzureSqlServerActiveDirectoryAdministratorCommunicator(Profile, subscription);
        }

        /// <summary>
        /// Gets an Azure SQL Server Active Directory administrator by name.
        /// </summary>
        /// <param name="resourceGroupName">The name of the resource group</param>
        /// <param name="serverName">The name of the Azure SQL Server that contains the Azure Active Directory administrator</param>
        /// <returns>The Azure Sql ServerActiveDirectoryAdministrator object</returns>
        internal AzureSqlServerActiveDirectoryAdministratorModel GetServerActiveDirectoryAdministrator(string resourceGroupName, string serverName)
        {
            var resp = Communicator.Get(resourceGroupName, serverName, Util.GenerateTracingId());
            return CreateServerActiveDirectoryAdministratorModelFromResponse(resourceGroupName, serverName, resp);
        }

        /// <summary>
        /// Gets a list of Azure SQL Server Active Directory administrators.
        /// </summary>
        /// <param name="resourceGroupName">The name of the resource group</param>
        /// <param name="serverName">The name of the Azure SQL Server that contains the Azure Active Directory administrator</param>
        /// <returns>A list of Azure SQL Server Active Directory administrators objects</returns>
        internal ICollection<AzureSqlServerActiveDirectoryAdministratorModel> ListServerActiveDirectoryAdministrators(string resourceGroupName, string serverName)
        {
            var resp = Communicator.List(resourceGroupName, serverName, Util.GenerateTracingId());

            return resp.Select((activeDirectoryAdmin) =>
            {
                return CreateServerActiveDirectoryAdministratorModelFromResponse(resourceGroupName, serverName, activeDirectoryAdmin);
            }).ToList();
        }

        /// <summary>
        /// Creates or updates an Azure SQL Server Active Directory administrator.
        /// </summary>
        /// <param name="resourceGroup">The name of the resource group</param>
        /// <param name="serverName">The name of the Azure Sql ServerActiveDirectoryAdministrator Server</param>
        /// <param name="model">The input parameters for the create/update operation</param>
        /// <returns>The upserted Azure SQL Server Active Directory administrator</returns>
        internal AzureSqlServerActiveDirectoryAdministratorModel UpsertServerActiveDirectoryAdministrator(string resourceGroup, string serverName, AzureSqlServerActiveDirectoryAdministratorModel model)
        {
            var resp = Communicator.CreateOrUpdate(resourceGroup, serverName, Util.GenerateTracingId(), new ServerAdministratorCreateOrUpdateParameters()
            {
                Properties = GetActiveDirectoryInformation(model.DisplayName, model.ObjectId)
            });

            return CreateServerActiveDirectoryAdministratorModelFromResponse(resourceGroup, serverName, resp);
        }

        /// <summary>
        /// Deletes a Azure SQL Server Active Directory administrator
        /// </summary>
        /// <param name="resourceGroupName">The resource group the server is in</param>
        /// <param name="serverName">The name of the Azure Sql ServerActiveDirectoryAdministrator Server</param>
        public void RemoveServerActiveDirectoryAdministrator(string resourceGroupName, string serverName)
        {
            Communicator.Remove(resourceGroupName, serverName, Util.GenerateTracingId());
        }

        /// <summary>
        /// Converts the response from the service to a powershell database object
        /// </summary>
        /// <param name="resourceGroupName">The resource group the server is in</param>
        /// <param name="serverName">The name of the Azure Sql ServerActiveDirectoryAdministrator Server</param>
        /// <param name="admin">The service response</param>
        /// <returns>The converted model</returns>
        public static AzureSqlServerActiveDirectoryAdministratorModel CreateServerActiveDirectoryAdministratorModelFromResponse(string resourceGroup, string serverName, Management.Sql.Models.ServerAdministrator admin)
        {
            AzureSqlServerActiveDirectoryAdministratorModel model = new AzureSqlServerActiveDirectoryAdministratorModel();

            model.ResourceGroupName = resourceGroup;
            model.ServerName = serverName;
            model.DisplayName = admin.Properties.Login;
            model.ObjectId = admin.Properties.Sid;

            return model;
        }

        /// <summary>
        /// Verifies that the Azure Active Directory user or group exists, and will get the object id if it is not set.
        /// </summary>
        /// <param name="displayName">Azure Active Directory user or group display name</param>
        /// <param name="objectId">Azure Active Directory user or group object id</param>
        /// <returns></returns>
        protected ServerAdministratorCreateOrUpdateProperties GetActiveDirectoryInformation(string displayName, Guid objectId)
        {
            // Gets the default Tenant id for the subscriptions
            Guid tenantId = GetTenantId();

            // Check for a Azure Active Directory group. Recommended to always use group.
            IEnumerable<MicrosoftAzureCommandsResourcesModelsActiveDirectory.PSADGroup> groupList = null;

            var filter = new MicrosoftAzureCommandsResourcesModelsActiveDirectory.ADObjectFilterOptions()
            {
                Id = (objectId != null && objectId != Guid.Empty) ? objectId.ToString() : null,
                SearchString = displayName,
                Paging = true,
            };

            // Get a list of groups from Azure Active Directory
            groupList = ActiveDirectoryClient.FilterGroups(filter).Where(gr => string.Equals(gr.DisplayName, displayName, StringComparison.OrdinalIgnoreCase));

            if (groupList.Count() > 1)
            {
                // More than one group was found with that display name.
                throw new ArgumentException(string.Format(Resources.ADGroupMoreThanOneFound, displayName));
            }
            else if (groupList.Count() == 1)
            {
                // Only one group was found. Get the group display name and object id
                var group = groupList.First();
                
                // Only support Security Groups
                if (group.SecurityEnabled.HasValue && !group.SecurityEnabled.Value)
                {
                    throw new ArgumentException(string.Format(Resources.InvalidADGroupNotSecurity, displayName));
                }

                return new ServerAdministratorCreateOrUpdateProperties()
                {
                    Login = group.DisplayName,
                    Sid = group.Id,
                    TenantId = tenantId,
                };
            }

            // No group was found. Check for a user
            filter = new MicrosoftAzureCommandsResourcesModelsActiveDirectory.ADObjectFilterOptions()
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
                filter = new MicrosoftAzureCommandsResourcesModelsActiveDirectory.ADObjectFilterOptions()
                {
                    Id = (objectId != null && objectId != Guid.Empty) ? objectId.ToString() : null,
                    UPN = displayName,
                    Paging = true,
                };

                userList = ActiveDirectoryClient.FilterUsers(filter).Where(gr => string.Equals(gr.UserPrincipalName, displayName, StringComparison.OrdinalIgnoreCase));
            }

            // No user was found
            if (userList == null || userList.Count() == 0)
            {
                throw new ArgumentException(string.Format(Resources.ADObjectNotFound, displayName));
            }
            else if (userList.Count() > 1)
            {
                // More than one user was found.
                throw new ArgumentException(string.Format(Resources.ADUserMoreThanOneFound, displayName));
            }
            else
            {
                // Only one user was found. Get the user display name and object id
                var obj = userList.First();

                return new ServerAdministratorCreateOrUpdateProperties()
                {
                    Login = displayName,
                    Sid = obj.Id,
                    TenantId = tenantId,
                };
            }
        }

        /// <summary>
        /// Get the default tenantId for the current subscription
        /// </summary>
        /// <returns></returns>
        protected Guid GetTenantId()
        {
            var tenantIdStr =
                Profile.Context.Subscription.GetPropertyAsArray(AzureSubscription.Property.Tenants).FirstOrDefault();
            var tenantIdGuid = Guid.Empty;
            
            if (string.IsNullOrWhiteSpace(tenantIdStr) || !Guid.TryParse(tenantIdStr, out tenantIdGuid))
            {
                throw new InvalidOperationException(Resources.InvalidTenantId);
            }

            return tenantIdGuid;
        }
    }
}
