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
using Microsoft.Azure.Commands.Common.Authentication.Models;
using Microsoft.Azure.Commands.Sql.Common;
using Microsoft.Azure.Commands.Sql.ServerKeyVaultKey.Model;
using Microsoft.Azure.Commands.Sql.Services;
using Microsoft.Azure.Management.Sql.LegacySdk.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Microsoft.Azure.Commands.Sql.ServerKeyVaultKey.Services
{
    /// <summary>
    /// Adapter for Sql Server Key Vault Key operations
    /// </summary>
    public class AzureSqlServerKeyVaultKeyAdapter
    {
        /// <summary>
        /// Gets or sets the AzureSqlServerKeyVaultKeyCommunicator which has all the needed management clients
        /// </summary>
        private AzureSqlServerKeyVaultKeyCommunicator Communicator { get; set; }

        /// <summary>
        /// Gets or sets the Azure context
        /// </summary>
        public IAzureContext Context { get; set; }

        /// <summary>
        /// Constructs a Server Key adapter
        /// </summary>
        /// <param name="context">The current AzureContext</param>
        public AzureSqlServerKeyVaultKeyAdapter(IAzureContext context)
        {
            Context = context;
            Communicator = new AzureSqlServerKeyVaultKeyCommunicator(Context);
        }

        /// <summary>
        /// Gets a Server Key Vault Key for a server
        /// </summary>
        /// <param name="resourceGroupName">Name of resource group</param>
        /// <param name="serverName">Name of SQL server</param>
        /// <param name="keyId">KeyId of the Server Key Vault Key</param>
        /// <returns>The Server Key Vault Key</returns>
        public AzureSqlServerKeyVaultKeyModel Get(string resourceGroupName, string serverName, string keyId)
        {
            string keyName = TdeKeyHelper.CreateServerKeyNameFromKeyId(keyId);
            var resp = Communicator.Get(resourceGroupName, serverName, keyName);
            return CreateServerKeyModelFromResponse(resourceGroupName, serverName, keyName, resp);
        }

        /// <summary>
        /// Lists all Server Key Vault Keys for a server
        /// </summary>
        /// <param name="resourceGroupName">Name of resource group</param>
        /// <param name="serverName">Name of SQL server</param>
        /// <returns>The list of Server Key Vault Keys on the server</returns>
        public IList<AzureSqlServerKeyVaultKeyModel> List(string resourceGroupName, string serverName)
        {
            var resp = Communicator.List(resourceGroupName, serverName);
            return resp.Select((serverKey) =>
            {
                return CreateServerKeyModelFromResponse(resourceGroupName, serverName, serverKey.Name, serverKey);
            }).ToList();
        }

        /// <summary>
        /// Creates or Updates a Server Key Vault Key
        /// </summary>
        /// <param name="model">The Server Key Vault Key model to create</param>
        /// <returns>The updated server key Vault Key model</returns>
        public AzureSqlServerKeyVaultKeyModel CreateOrUpdate(AzureSqlServerKeyVaultKeyModel model)
        {
            var resp = Communicator.CreateOrUpdate(model.ResourceGroupName, model.ServerName, model.ServerKeyName, new ServerKeyCreateOrUpdateParameters()
            {
                Properties = new ServerKeyCreateOrUpdateProperties()
                {
                    ServerKeyType = ServerKeyType.AzureKeyVault,
                    Uri = model.Uri
                }
            });

            return CreateServerKeyModelFromResponse(model.ResourceGroupName, model.ServerName, model.ServerKeyName, resp);
        }

        /// <summary>
        /// Deletes a Server Key Vault Key
        /// </summary>
        /// <param name="resourceGroupName">Name of resource group</param>
        /// <param name="serverName">Name of SQL server</param>
        /// <param name="keyId">KeyId of the Server Key Vault Key</param>
        public void Delete(string resourceGroupName, string serverName, string keyId)
        {
            string keyName = TdeKeyHelper.CreateServerKeyNameFromKeyId(keyId);
            Communicator.Delete(resourceGroupName, serverName, keyName);
        }

        /// <summary>
        /// Convert a Management.Sql.LegacySdk.Models.ServerKey to AzureSqlServerKeyVaultKeyModel
        /// </summary>
        /// <param name="resourceGroup">The resource group the server is in</param>
        /// <param name="serverName">The name of the server</param>
        /// <param name="keyName">Server Key Vault Key name</param>
        /// <param name="resp">The management client server key response to convert</param>
        /// <returns>The converted server key vault key model</returns>
        private static AzureSqlServerKeyVaultKeyModel CreateServerKeyModelFromResponse(string resourceGroup, string serverName, string keyName, Microsoft.Azure.Management.Sql.LegacySdk.Models.ServerKey resp)
        {
            AzureSqlServerKeyVaultKeyModel ServerKey = new AzureSqlServerKeyVaultKeyModel();
            ServerKey.ResourceGroupName = resourceGroup;
            ServerKey.ServerName = serverName;
            ServerKey.ServerKeyName = resp.Name;
            AzureSqlServerKeyVaultKeyModel.ServerKeyType type = AzureSqlServerKeyVaultKeyModel.ServerKeyType.AzureKeyVault;
            Enum.TryParse<AzureSqlServerKeyVaultKeyModel.ServerKeyType>(resp.Properties.ServerKeyType, out type);
            ServerKey.Type = type;
            ServerKey.Uri = resp.Properties.Uri;
            ServerKey.Thumbprint = resp.Properties.Thumbprint;

            if (type == AzureSqlServerKeyVaultKeyModel.ServerKeyType.AzureKeyVault)
            {
                ServerKey.CreationDate = resp.Properties.CreationDate;
            }
            else
            {
                ServerKey.CreationDate = null;
            }

            return ServerKey;
        }
    }
}
