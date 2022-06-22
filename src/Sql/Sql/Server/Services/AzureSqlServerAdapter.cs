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
using Microsoft.Azure.Commands.Sql.Server.Model;
using Microsoft.Azure.Commands.Sql.Server.Services;
using Microsoft.Azure.Commands.Sql.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security;
using System.Security.Permissions;
using Microsoft.Azure.Commands.ResourceManager.Common.Tags;
using Microsoft.Azure.Commands.Common.Authentication.Abstractions;
using Microsoft.Azure.Management.Sql.Models;
using Microsoft.Azure.Graph.RBAC.Version1_6.ActiveDirectory;
using Microsoft.Azure.Graph.RBAC.Version1_6.Models;
using Microsoft.Rest.Azure.OData;
using ServicePrincipal = Microsoft.Azure.Graph.RBAC.Version1_6.Models.ServicePrincipal;

namespace Microsoft.Azure.Commands.Sql.Server.Adapter
{
    /// <summary>
    /// Adapter for server operations
    /// </summary>
    public class AzureSqlServerAdapter
    {
        /// <summary>
        /// Gets or sets the AzureEndpointsCommunicator which has all the needed management clients
        /// </summary>
        private AzureSqlServerCommunicator Communicator { get; set; }

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
        /// Constructs a server adapter
        /// </summary>
        /// <param name="context">The current azure profile</param>
        public AzureSqlServerAdapter(IAzureContext context)
        {
            Context = context;
            Communicator = new AzureSqlServerCommunicator(Context);
        }

        /// <summary>
        /// Gets a server in a resource group
        /// </summary>
        /// <param name="resourceGroupName">The name of the resource group</param>
        /// <param name="serverName">The name of the server</param>
        /// <param name="expand">The child resources to include in the response.</param>
        /// <returns>The server</returns>
        public AzureSqlServerModel GetServer(string resourceGroupName, string serverName, string expand = null)
        {
            var resp = Communicator.Get(resourceGroupName, serverName, expand);
            return CreateServerModelFromResponse(resp);
        }

        /// <summary>
        /// Gets a list of all the servers in a subscription
        /// </summary>
        /// <param name="expand">The child resources to include in the response.</param>
        /// <returns>A list of all the servers</returns>
        public List<AzureSqlServerModel> ListServers(string expand = null)
        {
            var resp = Communicator.List(expand);
            return resp.Select((s) =>
            {
                return CreateServerModelFromResponse(s);
            }).ToList();
        }

        /// <summary>
        /// Gets a list of all the servers in a resource group
        /// </summary>
        /// <param name="resourceGroupName">The name of the resource group</param>
        /// <param name="expand">The child resources to include in the response.</param>
        /// <returns>A list of all the servers</returns>
        public List<AzureSqlServerModel> ListServersByResourceGroup(string resourceGroupName, string expand = null)
        {
            var resp = Communicator.ListByResourceGroup(resourceGroupName, expand);
            return resp.Select((s) =>
            {
                return CreateServerModelFromResponse(s);
            }).ToList();
        }

        /// <summary>
        /// Upserts a server
        /// </summary>
        /// <param name="model">The server to upsert</param>
        /// <returns>The updated server model</returns>
        public AzureSqlServerModel UpsertServer(AzureSqlServerModel model)
        {
            var resp = Communicator.CreateOrUpdate(model.ResourceGroupName, model.ServerName, new Management.Sql.Models.Server()
            {
                Location = model.Location,
                Tags = model.Tags,
                AdministratorLogin = model.SqlAdministratorLogin,
                AdministratorLoginPassword = model.SqlAdministratorPassword != null ? Decrypt(model.SqlAdministratorPassword) : null,
                Version = model.ServerVersion,
                Identity = model.Identity,
                MinimalTlsVersion = model.MinimalTlsVersion,
                PublicNetworkAccess = model.PublicNetworkAccess,
                RestrictOutboundNetworkAccess = model.RestrictOutboundNetworkAccess,
                Administrators = GetActiveDirectoryInformation(model.Administrators),
                PrimaryUserAssignedIdentityId = model.PrimaryUserAssignedIdentityId,
                KeyId = model.KeyId,
                FederatedClientId = model.FederatedClientId
            });

            return CreateServerModelFromResponse(resp);
        }

        /// <summary>
        /// Deletes a server
        /// </summary>
        /// <param name="resourceGroupName">The resource group the server is in</param>
        /// <param name="serverName">The name of the server to delete</param>
        public void RemoveServer(string resourceGroupName, string serverName)
        {
            Communicator.Remove(resourceGroupName, serverName);
        }

        /// <summary>
        /// Convert a Management.Sql.LegacySdk.Models.Server to AzureSqlDatabaseServerModel
        /// </summary>
        /// <param name="resp">The management client server response to convert</param>
        /// <returns>The converted server model</returns>
        private static AzureSqlServerModel CreateServerModelFromResponse(Management.Sql.Models.Server resp)
        {
            AzureSqlServerModel server = new AzureSqlServerModel();

            // Extract the resource group name from the ID.
            // ID is in the form:
            // /subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/rgName/providers/Microsoft.Sql/servers/serverName
            string[] segments = resp.Id.Split('/');
            server.ResourceGroupName = segments[4];

            server.ServerName = resp.Name;
            server.ServerVersion = resp.Version;
            server.SqlAdministratorLogin = resp.AdministratorLogin;
            server.Location = resp.Location;
            server.Tags = TagsConversionHelper.CreateTagDictionary(TagsConversionHelper.CreateTagHashtable(resp.Tags), false);
            server.Identity = resp.Identity;
            server.FullyQualifiedDomainName = resp.FullyQualifiedDomainName;
            server.ResourceId = resp.Id;
            server.MinimalTlsVersion = resp.MinimalTlsVersion;
            server.PublicNetworkAccess = resp.PublicNetworkAccess;
            server.RestrictOutboundNetworkAccess = resp.RestrictOutboundNetworkAccess;
            server.Administrators = resp.Administrators;

            if (server.Administrators != null && server.Administrators.AdministratorType == null)
            {
                server.Administrators.AdministratorType = "ActiveDirectory";
            }
            server.PrimaryUserAssignedIdentityId = resp.PrimaryUserAssignedIdentityId;
            server.KeyId = resp.KeyId;
            server.FederatedClientId = resp.FederatedClientId;

            return server;
        }

        /// <summary>
        /// Convert a <see cref="System.Security.SecureString"/> to a plain-text string representation.
        /// This should only be used in a proetected context, and must be done in the same logon and process context
        /// in which the <see cref="System.Security.SecureString"/> was constructed.
        /// </summary>
        /// <param name="secureString">The encrypted <see cref="System.Security.SecureString"/>.</param>
        /// <returns>The plain-text string representation.</returns>
        [PermissionSet(SecurityAction.Demand, Name = "FullTrust")]
        internal static string Decrypt(SecureString secureString)
        {
            IntPtr unmanagedString = IntPtr.Zero;
            try
            {
                unmanagedString = Marshal.SecureStringToGlobalAllocUnicode(secureString);
                return Marshal.PtrToStringUni(unmanagedString);
            }
            finally
            {
                Marshal.ZeroFreeGlobalAllocUnicode(unmanagedString);
            }
        }

        /// <summary>
        /// Verifies that the Azure Active Directory user or group exists, and will get the object id if it is not set.
        /// </summary>
        /// <param name="input">Azure Active Directory user or group object</param>
        /// <returns></returns>
        protected ServerExternalAdministrator GetActiveDirectoryInformation(ServerExternalAdministrator input)
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

                return new ServerExternalAdministrator()
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
                return new ServerExternalAdministrator()
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

                return new ServerExternalAdministrator()
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
