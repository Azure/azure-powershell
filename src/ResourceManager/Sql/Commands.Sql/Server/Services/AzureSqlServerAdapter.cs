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
using Microsoft.Azure.Management.Sql.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security;
using System.Security.Permissions;

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
        public AzureContext Context { get; set; }

        /// <summary>
        /// Constructs a server adapter
        /// </summary>
        /// <param name="context">The current azure profile</param>
        public AzureSqlServerAdapter(AzureContext context)
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
            var resp = Communicator.Get(resourceGroupName, serverName, Util.GenerateTracingId());
            return CreateServerModelFromResponse(resourceGroupName, resp);
        }

        /// <summary>
        /// Gets a list of all the servers in a resource group
        /// </summary>
        /// <param name="resourceGroupName">The name of the resource group</param>
        /// <returns>A list of all the servers</returns>
        public List<AzureSqlServerModel> GetServers(string resourceGroupName)
        {
            var resp = Communicator.List(resourceGroupName, Util.GenerateTracingId());
            return resp.Select((s) =>
            {
                return CreateServerModelFromResponse(resourceGroupName, s);
            }).ToList();
        }

        /// <summary>
        /// Upserts a server
        /// </summary>
        /// <param name="model">The server to upsert</param>
        /// <returns>The updated server model</returns>
        public AzureSqlServerModel UpsertServer(AzureSqlServerModel model)
        {
            var resp = Communicator.CreateOrUpdate(model.ResourceGroupName, model.ServerName, Util.GenerateTracingId(), new ServerCreateOrUpdateParameters()
            {
                Location = model.Location,
                Tags = model.Tags,
                Properties = new ServerCreateOrUpdateProperties()
                {
                    AdministratorLogin = model.SqlAdministratorLogin,
                    AdministratorLoginPassword = Decrypt(model.SqlAdministratorPassword),
                    Version = model.ServerVersion,
                }
            });

            return CreateServerModelFromResponse(model.ResourceGroupName, resp);
        }

        /// <summary>
        /// Deletes a server
        /// </summary>
        /// <param name="resourceGroupName">The resource group the server is in</param>
        /// <param name="serverName">The name of the server to delete</param>
        public void RemoveServer(string resourceGroupName, string serverName)
        {
            Communicator.Remove(resourceGroupName, serverName, Util.GenerateTracingId());
        }

        /// <summary>
        /// Convert a Management.Sql.Models.Server to AzureSqlDatabaseServerModel
        /// </summary>
        /// <param name="resourceGroupName">The resource group the server is in</param>
        /// <param name="resp">The management client server response to convert</param>
        /// <returns>The converted server model</returns>
        private static AzureSqlServerModel CreateServerModelFromResponse(string resourceGroupName, Management.Sql.Models.Server resp)
        {
            AzureSqlServerModel server = new AzureSqlServerModel();

            server.ResourceGroupName = resourceGroupName;
            server.ServerName = resp.Name;
            server.ServerVersion = resp.Properties.Version;
            server.SqlAdministratorLogin = resp.Properties.AdministratorLogin;
            server.Location = resp.Location;

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
