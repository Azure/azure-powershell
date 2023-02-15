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
using Microsoft.Azure.Commands.Sql.ServerActiveDirectoryAdministrator.Model;
using Microsoft.Azure.Management.Sql.Models;
using Microsoft.Rest.Azure.OData;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Azure.Commands.Common.MSGraph.Version1_0;
using Microsoft.Azure.Commands.Common.MSGraph.Version1_0.Groups.Models;
using Microsoft.Azure.Commands.Common.Authentication;
using Microsoft.Azure.Commands.Common.MSGraph.Version1_0.Applications.Models;
using ServicePrincipal = Microsoft.Azure.Graph.RBAC.Version1_6.Models.ServicePrincipal;

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
        public IAzureContext Context { get; set; }

        /// <summary>
        /// A private instance of MicrosoftGraphClient
        /// </summary>
        private MicrosoftGraphClient _microsoftGraphClient;

        /// <summary>
        /// Gets or sets the Azure MicrosoftGraphClient instance
        /// </summary>
        public MicrosoftGraphClient MicrosoftGraphClient
        {
            get
            {
                if (_microsoftGraphClient == null)
                {
                    _microsoftGraphClient = AzureSession.Instance.ClientFactory.CreateArmClient<MicrosoftGraphClient>(Context, AzureEnvironment.ExtendedEndpoint.MicrosoftGraphUrl);
                    _microsoftGraphClient.TenantID = Context.Tenant.Id;
                }
                return _microsoftGraphClient;
            }
            set { _microsoftGraphClient = value; }
        }

        /// <summary>
        /// Constructs a Azure SQL Server Active Directory administrator adapter
        /// </summary>
        /// <param name="context">The current azure context</param>
        public AzureSqlServerActiveDirectoryAdministratorAdapter(IAzureContext context)
        {
            Context = context;
            Communicator = new AzureSqlServerActiveDirectoryAdministratorCommunicator(Context);
        }

        /// <summary>
        /// Gets an Azure SQL Server Active Directory administrator by name.
        /// </summary>
        /// <param name="resourceGroupName">The name of the resource group</param>
        /// <param name="serverName">The name of the Azure SQL Server that contains the Azure Active Directory administrator</param>
        /// <returns>The Azure Sql ServerActiveDirectoryAdministrator object</returns>
        internal AzureSqlServerActiveDirectoryAdministratorModel GetServerActiveDirectoryAdministrator(string resourceGroupName, string serverName)
        {
            var resp = Communicator.Get(resourceGroupName, serverName);
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
            var resp = Communicator.List(resourceGroupName, serverName);

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
            var resp = Communicator.CreateOrUpdate(resourceGroup, serverName, GetActiveDirectoryInformation(model.DisplayName, model.ObjectId));

            return CreateServerActiveDirectoryAdministratorModelFromResponse(resourceGroup, serverName, resp);
        }

        /// <summary>
        /// Deletes a Azure SQL Server Active Directory administrator
        /// </summary>
        /// <param name="resourceGroupName">The resource group the server is in</param>
        /// <param name="serverName">The name of the Azure Sql ServerActiveDirectoryAdministrator Server</param>
        public void RemoveServerActiveDirectoryAdministrator(string resourceGroupName, string serverName)
        {
            Communicator.Remove(resourceGroupName, serverName);
        }

        /// <summary>
        /// Converts the response from the service to a powershell database object
        /// </summary>
        /// <param name="resourceGroup">The resource group the server is in</param>
        /// <param name="serverName">The name of the Azure Sql ServerActiveDirectoryAdministrator Server</param>
        /// <param name="admin">The service response</param>
        /// <returns>The converted model</returns>
        public static AzureSqlServerActiveDirectoryAdministratorModel CreateServerActiveDirectoryAdministratorModelFromResponse(string resourceGroup, string serverName, Management.Sql.Models.ServerAzureADAdministrator admin)
        {
            if (admin != null)
            {
                AzureSqlServerActiveDirectoryAdministratorModel model = new AzureSqlServerActiveDirectoryAdministratorModel();

                model.ResourceGroupName = resourceGroup;
                model.ServerName = serverName;
                model.DisplayName = admin.Login;
                model.ObjectId = admin.Sid;
                model.IsAzureADOnlyAuthentication = admin.AzureADOnlyAuthentication;
                return model;
            }

            return null;
        }

        /// <summary>
        /// Verifies that the Azure Active Directory user or group exists, and will get the object id if it is not set.
        /// </summary>
        /// <param name="displayName">Azure Active Directory user or group display name</param>
        /// <param name="objectId">Azure Active Directory user or group object id</param>
        /// <returns></returns>
        protected ServerAzureADAdministrator GetActiveDirectoryInformation(string displayName, Guid objectId)
        {
            // Gets the default Tenant id for the subscriptions
            Guid tenantId = GetTenantId();

            // Check for a Azure Active Directory group. Recommended to always use group.
            IEnumerable<MicrosoftGraphGroup> groupList = null;
            MicrosoftGraphGroup group = null;

            var filter = new MicrosoftObjectFilterOptions()
            {
                Id = (objectId != null && objectId != Guid.Empty) ? objectId.ToString() : null,
                SearchString = displayName,
                Paging = true,
            };

            // Get a list of groups from Azure Active Directory
            groupList = MicrosoftGraphClient.FilterGroups(filter).Where(gr => string.Equals(gr.DisplayName, displayName, StringComparison.OrdinalIgnoreCase));

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
            ODataQuery<MicrosoftGraphServicePrincipal> odataQueryFilter;

            if ((objectId != null && objectId != Guid.Empty))
            {
                var applicationIdString = objectId.ToString();
                odataQueryFilter = new Rest.Azure.OData.ODataQuery<MicrosoftGraphServicePrincipal>(a => a.AppId == applicationIdString);
            }
            else
            {
                odataQueryFilter = new Rest.Azure.OData.ODataQuery<MicrosoftGraphServicePrincipal>(a => a.DisplayName == displayName);
            }

            var servicePrincipalList = MicrosoftGraphClient.FilterServicePrincipals(odataQueryFilter);

            if (servicePrincipalList != null && servicePrincipalList.Count() > 1)
            {
                // More than one service principal was found.
                throw new ArgumentException(string.Format(Microsoft.Azure.Commands.Sql.Properties.Resources.ADApplicationMoreThanOneFound, displayName));
            }
            else if (servicePrincipalList != null && servicePrincipalList.Count() == 1)
            {
                // Only one user was found. Get the user display name and object id
                MicrosoftGraphServicePrincipal app = servicePrincipalList.First();

                if (displayName != null && string.CompareOrdinal(displayName, app.DisplayName) != 0)
                {
                    throw new ArgumentException(string.Format(Microsoft.Azure.Commands.Sql.Properties.Resources.ADApplicationDisplayNameMismatch, displayName, app.DisplayName));
                }

                if (group != null)
                {
                    throw new ArgumentException(string.Format(Microsoft.Azure.Commands.Sql.Properties.Resources.ADDuplicateGroupAndApplicationFound, displayName));
                }

                return new ServerAzureADAdministrator()
                {
                    Login = displayName,
                    Sid = new Guid(app.AppId),
                    TenantId = tenantId
                };
            }

            if (group != null)
            {
                return new ServerAzureADAdministrator()
                {
                    Login = group.DisplayName,
                    Sid = new Guid(group.Id),
                    TenantId = tenantId
                };
            }

            // No group or service principal was found. Check for a user
            filter = new MicrosoftObjectFilterOptions()
            {
                Id = (objectId != null && objectId != Guid.Empty) ? objectId.ToString() : null,
                SearchString = displayName,
                Paging = true,
            };

            // Get a list of user from Azure Active Directory
            var userList = MicrosoftGraphClient.FilterUsers(filter).Where(gr => string.Equals(gr.DisplayName, displayName, StringComparison.OrdinalIgnoreCase));

            // No user was found. Check if the display name is a UPN
            if (userList == null || userList.Count() == 0)
            {
                // Check if the display name is the UPN
                filter = new MicrosoftObjectFilterOptions()
                {
                    Id = (objectId != null && objectId != Guid.Empty) ? objectId.ToString() : null,
                    UPN = displayName,
                    Paging = true,
                };

                userList = MicrosoftGraphClient.FilterUsers(filter).Where(gr => string.Equals(gr.UserPrincipalName, displayName, StringComparison.OrdinalIgnoreCase));
            }

            // No user was found. Check if the display name is a guest user. 
            if (userList == null || userList.Count() == 0)
            {
                // Check if the display name is the UPN
                filter = new MicrosoftObjectFilterOptions()
                {
                    Id = (objectId != null && objectId != Guid.Empty) ? objectId.ToString() : null,
                    Mail = displayName,
                    Paging = true,
                };

                userList = MicrosoftGraphClient.FilterUsers(filter);
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

                return new ServerAzureADAdministrator()
                {
                    Login = displayName,
                    Sid = new Guid(obj.Id),
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
            string graph = Context.Environment.GetEndpoint(AzureEnvironment.ExtendedEndpoint.MicrosoftGraphUrl);
            var tenantIdGuid = Guid.Empty;

            if (string.IsNullOrWhiteSpace(tenantIdStr) || !Guid.TryParse(tenantIdStr, out tenantIdGuid))
            {
                throw new InvalidOperationException(Microsoft.Azure.Commands.Sql.Properties.Resources.InvalidTenantId);
            }

            return tenantIdGuid;
        }
    }
}