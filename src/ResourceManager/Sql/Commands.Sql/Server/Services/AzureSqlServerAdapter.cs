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
        /// <returns>The server</returns>
        public AzureSqlServerModel GetServer(string resourceGroupName, string serverName)
        {
            var resp = Communicator.Get(resourceGroupName, serverName);
            return CreateServerModelFromResponse(resp);
        }

        /// <summary>
        /// Gets a list of all the servers in a subscription
        /// </summary>
        /// <param name="resourceGroupName">The name of the resource group</param>
        /// <returns>A list of all the servers</returns>
        public List<AzureSqlServerModel> ListServers()
        {
            var resp = Communicator.List();
            return resp.Select((s) =>
            {
                return CreateServerModelFromResponse(s);
            }).ToList();
        }

        /// <summary>
        /// Gets a list of all the servers in a resource group
        /// </summary>
        /// <param name="resourceGroupName">The name of the resource group</param>
        /// <returns>A list of all the servers</returns>
        public List<AzureSqlServerModel> ListServersByResourceGroup(string resourceGroupName)
        {
            var resp = Communicator.ListByResourceGroup(resourceGroupName);
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
                Identity = model.Identity
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
        /// <param name="resourceGroupName">The resource group the server is in</param>
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
    }
}
