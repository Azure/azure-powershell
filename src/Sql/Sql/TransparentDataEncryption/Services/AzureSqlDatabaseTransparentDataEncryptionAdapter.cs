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
using Microsoft.Azure.Commands.Sql.ServerKeyVaultKey.Model;
using Microsoft.Azure.Commands.Sql.Services;
using Microsoft.Azure.Commands.Sql.TransparentDataEncryption.Model;
using Microsoft.Azure.Commands.Sql.TransparentDataEncryption.Services;
using Microsoft.Azure.Management.Sql.LegacySdk.Models;
using Microsoft.Azure.Management.Sql.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Microsoft.Azure.Commands.Sql.TransparentDataEncryption.Adapter
{
    /// <summary>
    /// Adapter for firewall operations
    /// </summary>
    public class AzureSqlDatabaseTransparentDataEncryptionAdapter
    {
        /// <summary>
        /// Gets or sets the AzureEndpointsCommunicator which has all the needed management clients
        /// </summary>
        private AzureSqlDatabaseTransparentDataEncryptionCommunicator Communicator { get; set; }

        /// <summary>
        /// Gets or sets the Azure profile
        /// </summary>
        public IAzureContext Context { get; set; }

        /// <summary>
        /// Constructs a Transparent Data Encryption adapter
        /// </summary>
        /// <param name="context">The current azure context</param>
        public AzureSqlDatabaseTransparentDataEncryptionAdapter(IAzureContext context)
        {
            Context = context;
            Communicator = new AzureSqlDatabaseTransparentDataEncryptionCommunicator(Context);
        }

        /// <summary>
        /// Gets a Transparent Data Encryption in a server
        /// </summary>
        /// <param name="resourceGroupName">The name of the resource group</param>
        /// <param name="serverName">The name of the server</param>
        /// <param name="databaseName">The name of the database</param>
        /// <returns>The Transparent Data Encryption</returns>
        public AzureSqlDatabaseTransparentDataEncryptionModel GetTransparentDataEncryption(string resourceGroupName, string serverName, string databaseName)
        {
            var resp = Communicator.Get(resourceGroupName, serverName, databaseName);
            return CreateTransparentDataEncryptionModelFromResponse(resourceGroupName, serverName, databaseName, resp);
        }

        /// <summary>
        /// Upserts a Transparent Data Encryption
        /// </summary>
        /// <param name="model">The Transparent Data Encryption to create</param>
        /// <returns>The updated server model</returns>
        public AzureSqlDatabaseTransparentDataEncryptionModel UpsertTransparentDataEncryption(AzureSqlDatabaseTransparentDataEncryptionModel model)
        {
            TransparentDataEncryptionState state = TransparentDataEncryptionState.Enabled;

            if (model.State.ToString().Equals(TransparentDataEncryptionState.Disabled.ToString()))
            {
                state = TransparentDataEncryptionState.Disabled;
            }

            var resp = Communicator.CreateOrUpdate(model.ResourceGroupName, model.ServerName, model.DatabaseName, new Management.Sql.Models.LogicalDatabaseTransparentDataEncryption()
            {
                State = state

            });

            return CreateTransparentDataEncryptionModelFromResponse(model.ResourceGroupName, model.ServerName, model.DatabaseName, resp);
        }

        /// <summary>
        /// Gets the encryption protector for the server
        /// </summary>
        /// <param name="resourceGroupName">The name of the resource group</param>
        /// <param name="serverName">The name of the server</param>
        /// <returns>The encryption protector model</returns>
        public AzureSqlServerTransparentDataEncryptionProtectorModel GetEncryptionProtector(string resourceGroupName, string serverName)
        {
            var resp = Communicator.GetEncryptionProtector(resourceGroupName, serverName);
            return CreateEncryptionProtectorModelFromResponse(resourceGroupName, serverName, resp);
        }

        /// <summary>
        /// Creates or Updates an encryption protector
        /// </summary>
        /// <param name="model">The encryption protector model to create or update</param>
        /// <returns>The created or updated encryption protector model</returns>
        public AzureSqlServerTransparentDataEncryptionProtectorModel CreateOrUpdateEncryptionProtector(AzureSqlServerTransparentDataEncryptionProtectorModel model)
        {
            var resp = Communicator.CreateOrUpdateEncryptionProtector(model.ResourceGroupName, model.ServerName, new Management.Sql.Models.EncryptionProtector()
            {
                ServerKeyType = model.Type.ToString(),
                ServerKeyName = model.ServerKeyVaultKeyName,
                AutoRotationEnabled = model.AutoRotationEnabled                
            });
            return CreateEncryptionProtectorModelFromResponse(model.ResourceGroupName, model.ServerName, resp);
        }

        /// <summary>
        /// Convert a Management.Sql.LegacySdk.Models.TransparentDataEncryption to AzureSqlDatabaseTransparentDataEncryptionModel
        /// </summary>
        /// <param name="resourceGroup">The resource group the server is in</param>
        /// <param name="serverName">The name of the server</param>
        /// <param name="databaseName">The name of the database</param>
        /// <param name="resp">The management client server response to convert</param>
        /// <returns>The converted server model</returns>
        private static AzureSqlDatabaseTransparentDataEncryptionModel CreateTransparentDataEncryptionModelFromResponse(string resourceGroup, string serverName, string databaseName, Management.Sql.Models.LogicalDatabaseTransparentDataEncryption resp)
        {
            AzureSqlDatabaseTransparentDataEncryptionModel TransparentDataEncryption = new AzureSqlDatabaseTransparentDataEncryptionModel();

            TransparentDataEncryption.ResourceGroupName = resourceGroup;
            TransparentDataEncryption.ServerName = serverName;
            TransparentDataEncryption.DatabaseName = databaseName;

            TransparentDataEncryptionStateType State = TransparentDataEncryptionStateType.Disabled;
            if (resp != null)
            {
                Enum.TryParse<TransparentDataEncryptionStateType>(resp.State.ToString(), true, out State);
                TransparentDataEncryption.State = State;
            }

            return TransparentDataEncryption;
        }

        /// <summary>
        /// Convert a Management.Sql.LegacySdk.Models.TransparentDataEncryption.EncryptionProtector to AzureSqlServerTransparentDataEncryptionProtectorModel
        /// </summary>
        /// <param name="resourceGroup">The resource group the server is in</param>
        /// <param name="serverName">The name of the server</param>
        /// <param name="resp">The management client server response to convert</param>
        /// <returns>The converted server model</returns>
        private static AzureSqlServerTransparentDataEncryptionProtectorModel CreateEncryptionProtectorModelFromResponse(string resourceGroup, string serverName, Management.Sql.Models.EncryptionProtector resp)
        {
            AzureSqlServerTransparentDataEncryptionProtectorModel EncryptionProtector = new AzureSqlServerTransparentDataEncryptionProtectorModel();
            EncryptionProtector.ResourceGroupName = resourceGroup;
            EncryptionProtector.ServerName = serverName;
            EncryptionProtector.ServerKeyVaultKeyName = resp.ServerKeyName;
            Model.EncryptionProtectorType type = Model.EncryptionProtectorType.ServiceManaged;
            Enum.TryParse<Model.EncryptionProtectorType>(resp.ServerKeyType, true, out type);
            EncryptionProtector.Type = type;
            EncryptionProtector.AutoRotationEnabled = resp.AutoRotationEnabled;

            if (type == Model.EncryptionProtectorType.AzureKeyVault)
            {
                EncryptionProtector.KeyId = resp.Uri;
            }

            return EncryptionProtector;
        }
    }
}
