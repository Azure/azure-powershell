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
using Microsoft.Rest.Azure;
using Microsoft.WindowsAzure.Commands.Common;
using ServerKeyType = Microsoft.Azure.Management.Sql.Models.ServerKeyType;
using Microsoft.Azure.Commands.Sql.Common;

namespace Microsoft.Azure.Commands.Sql.TransparentDataEncryption.Adapter
{
    /// <summary>
    /// Adapter for firewall operations
    /// </summary>
    public class AzureSqlDatabaseTransparentDataEncryptionArmAdapter
    {
        /// <summary>
        /// Gets or sets the AzureEndpointsCommunicator which has all the needed management clients
        /// </summary>
        private AzureSqlDatabaseTransparentDataEncryptionArmCommunicator Communicator { get; set; }

        /// <summary>
        /// Gets or sets the Azure profile
        /// </summary>
        public IAzureContext Context { get; set; }

        /// <summary>
        /// Constructs a Transparent Data Encryption adapter
        /// </summary>
        /// <param name="context">The current azure context</param>
        public AzureSqlDatabaseTransparentDataEncryptionArmAdapter(IAzureContext context)
        {
            Context = context;
            Communicator = new AzureSqlDatabaseTransparentDataEncryptionArmCommunicator(Context);
        }

        internal void AddAzureRmSqlServerTransparentDataEncryptionCertificate(AzureRmSqlServerTransparentDataEncryptionCertificateModel azureRmSqlServerTransparentDataEncryptionCertificateModel)
        {
            string resourceGroupName = azureRmSqlServerTransparentDataEncryptionCertificateModel.ResourceGroupName;
            string serverName = azureRmSqlServerTransparentDataEncryptionCertificateModel.ServerName;
            string privateBlob = azureRmSqlServerTransparentDataEncryptionCertificateModel.PrivateBlob.ConvertToString();
            string password = azureRmSqlServerTransparentDataEncryptionCertificateModel.Password.ConvertToString();

            Communicator.AddAzureRmSqlServerTransparentDataEncryptionCertificate(
                resourceGroupName,
                serverName,
                privateBlob,
                password);
        }

        internal void AddAzureRmSqlManagedInstanceTransparentDataEncryptionCertificate(AzureRmSqlManagedInstanceTransparentDataEncryptionCertificateModel azureRmSqlManagedInstanceTransparentDataEncryptionCertificateModel)
        {
            string resourceGroupName = azureRmSqlManagedInstanceTransparentDataEncryptionCertificateModel.ResourceGroupName;
            string managedInstanceName = azureRmSqlManagedInstanceTransparentDataEncryptionCertificateModel.ManagedInstanceName;
            string privateBlob = azureRmSqlManagedInstanceTransparentDataEncryptionCertificateModel.PrivateBlob.ConvertToString();
            string password = azureRmSqlManagedInstanceTransparentDataEncryptionCertificateModel.Password.ConvertToString();

            Communicator.AddAzureRmSqlManagedInstanceTransparentDataEncryptionCertificate(
                resourceGroupName,
                managedInstanceName,
                privateBlob,
                password);
        }
		
        internal AzureRmSqlManagedInstanceKeyVaultKeyModel AddAzureRmSqlManagedInstanceKeyVaultKey(AzureRmSqlManagedInstanceKeyVaultKeyModel azureRmSqlManagedInstanceKeyVaultKeyModel)
        {
            ManagedInstanceKey managedInstanceKey = new ManagedInstanceKey()
            {
                ServerKeyType = ServerKeyType.AzureKeyVault,
                Uri = azureRmSqlManagedInstanceKeyVaultKeyModel.KeyId
            };

            string resourceGroupName = azureRmSqlManagedInstanceKeyVaultKeyModel.ResourceGroupName;
            string managedInstanceName = azureRmSqlManagedInstanceKeyVaultKeyModel.ManagedInstanceName;
            
            ManagedInstanceKey response = Communicator.AddAzureRmSqlManagedInstanceKeyVaultKey(
                resourceGroupName: resourceGroupName,
                managedInstanceName: managedInstanceName,
                keyName: azureRmSqlManagedInstanceKeyVaultKeyModel.ManagedInstanceKeyName,
                managedInstanceKeyParameters: managedInstanceKey);
            
            return AzureRmSqlManagedInstanceKeyVaultKeyModel.FromManagedInstanceKey(
                managedInstanceKey: response,
                resourceGroupName: resourceGroupName,
                managedInstanceName: managedInstanceName);
        }

        internal AzureRmSqlManagedInstanceKeyVaultKeyModel GetAzureRmSqlManagedInstanceKeyVaultKey(AzureRmSqlManagedInstanceKeyVaultKeyModel azureRmSqlManagedInstanceKeyVaultKeyModel)
        {
            string resourceGroupName = azureRmSqlManagedInstanceKeyVaultKeyModel.ResourceGroupName;
            string managedInstanceName = azureRmSqlManagedInstanceKeyVaultKeyModel.ManagedInstanceName;

            ManagedInstanceKey response = Communicator.GetAzureRmSqlManagedInstanceKeyVaultKey(
                resourceGroupName: resourceGroupName,
                managedInstanceName: managedInstanceName,
                keyName: azureRmSqlManagedInstanceKeyVaultKeyModel.ManagedInstanceKeyName);
            
            return AzureRmSqlManagedInstanceKeyVaultKeyModel.FromManagedInstanceKey(
                managedInstanceKey: response,
                resourceGroupName: resourceGroupName,
                managedInstanceName: managedInstanceName);
        }
        
        internal void RemoveAzureRmSqlManagedInstanceKeyVaultKey(AzureRmSqlManagedInstanceKeyVaultKeyModel azureRmSqlManagedInstanceKeyVaultKeyModel)
        {
            Communicator.RemoveAzureRmSqlManagedInstanceKeyVaultKey(
                resourceGroupName: azureRmSqlManagedInstanceKeyVaultKeyModel.ResourceGroupName,
                managedInstanceName: azureRmSqlManagedInstanceKeyVaultKeyModel.ManagedInstanceName,
                keyName: azureRmSqlManagedInstanceKeyVaultKeyModel.ManagedInstanceKeyName);
        }

        internal IEnumerable<AzureRmSqlManagedInstanceKeyVaultKeyModel> ListAzureRmSqlManagedInstanceKeyVaultKeys(string resourceGroupName, string managedInstanceName)
        {
           return Communicator.ListAzureRmSqlManagedInstanceKeyVaultKeys(
                resourceGroupName: resourceGroupName,
                managedInstanceName: managedInstanceName)
                .Select(b => AzureRmSqlManagedInstanceKeyVaultKeyModel.FromManagedInstanceKey(b, resourceGroupName:resourceGroupName, managedInstanceName:managedInstanceName));
        }

        public AzureRmSqlManagedInstanceTransparentDataEncryptionProtectorModel GetAzureRmSqlManagedInstanceTransparentDataEncryptionProtector(AzureRmSqlManagedInstanceTransparentDataEncryptionProtectorModel model)
        {
            var managedInstanceEncryptionProtector = Communicator.GetManagedInstanceEncryptionProtector(
                resourceGroupName: model.ResourceGroupName,
                managedInstanceName: model.ManagedInstanceName);

            return AzureRmSqlManagedInstanceTransparentDataEncryptionProtectorModel.FromManagedInstanceEncryptionProtector(
                model.ResourceGroupName, model.ManagedInstanceName, managedInstanceEncryptionProtector);
        }

        public AzureRmSqlManagedInstanceTransparentDataEncryptionProtectorModel CreateOrUpdateManagedInstanceEncryptionProtector(AzureRmSqlManagedInstanceTransparentDataEncryptionProtectorModel model)
        {
            ManagedInstanceEncryptionProtector managedInstanceEncryptionProtector = Communicator.CreateOrUpdateManagedInstanceEncryptionProtector(
                resourceGroupName: model.ResourceGroupName,
                managedInstanceName: model.ManagedInstanceName,
                managedInstanceEncryptionProtector: new ManagedInstanceEncryptionProtector()
                {
                    ServerKeyType = model.Type.ToString(),
                    ServerKeyName = TdeKeyHelper.CreateServerKeyNameFromKeyId(model.KeyId),
                    AutoRotationEnabled = model.AutoRotationEnabled
                });

            return AzureRmSqlManagedInstanceTransparentDataEncryptionProtectorModel
                .FromManagedInstanceEncryptionProtector(
                    resourceGroupName: model.ResourceGroupName,
                    managedInstanceName: model.ManagedInstanceName,
                    managedInstanceEncryptionProtector: managedInstanceEncryptionProtector);
        }
    }
}
