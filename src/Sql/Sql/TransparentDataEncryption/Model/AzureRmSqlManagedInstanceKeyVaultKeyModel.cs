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

using System;
using System.Linq;
using System.Text.RegularExpressions;
using Microsoft.Azure.Commands.Sql.Common;
using Microsoft.Azure.Management.Sql.Models;

namespace Microsoft.Azure.Commands.Sql.TransparentDataEncryption.Model
{
    /// <summary>
    /// Represents the core properties of an Azure Sql Database Transparent Data Encryption Certificate
    /// </summary>
    public class AzureRmSqlManagedInstanceKeyVaultKeyModel
    {
        public AzureRmSqlManagedInstanceKeyVaultKeyModel(string resourceGroupName, string managedInstanceName, string keyId)
        {
            ResourceGroupName = resourceGroupName;
            ManagedInstanceName = managedInstanceName;
            KeyId = keyId;
            ManagedInstanceKeyName = TdeKeyHelper.CreateServerKeyNameFromKeyId(keyId);
        }

        private AzureRmSqlManagedInstanceKeyVaultKeyModel() { }

        /// <summary>
        /// Gets or sets the name of the resource group
        /// </summary>
        public string ResourceGroupName { get; private set; }

        /// <summary>
        /// Gets or sets the name of the managed instance
        /// </summary>
        public string ManagedInstanceName { get; private set; }

        /// <summary>
        /// Gets or sets the AzureKeyVault key id
        /// </summary>
        public string KeyId { get; private set; }

        /// <summary>
        /// Gets or sets the server key name
        /// </summary>
        public string ManagedInstanceKeyName { get; private set; }

        /// <summary>
        /// Gets or sets the creation date of the managed instance key
        /// </summary>
        public DateTime? CreationDate { get; private set; }

        /// <summary>
        /// Gets or sets the thumbprint of the managed instance key
        /// </summary>
        public string Thumbprint { get; private set; }

        /// <summary>
        /// Gets or sets the type of the managed instance key
        /// </summary>
        public ServerKeyType Type { get; private set; }

        /// <summary>
        /// Factory method to create AzureRmSqlManagedInstanceKeyVaultKeyModel from ManagedInstanceKey
        /// </summary>
        /// <param name="managedInstanceKey"></param>
        /// <param name="resourceGroupName"></param>
        /// <param name="managedInstanceName"></param>
        /// <returns></returns>
        public static AzureRmSqlManagedInstanceKeyVaultKeyModel FromManagedInstanceKey(ManagedInstanceKey managedInstanceKey, string resourceGroupName, string managedInstanceName)
        {
            ServerKeyType skType = ServerKeyType.AzureKeyVault;
            Enum.TryParse<ServerKeyType>(managedInstanceKey.ServerKeyType, out skType);

            AzureRmSqlManagedInstanceKeyVaultKeyModel key = new AzureRmSqlManagedInstanceKeyVaultKeyModel()
            {
                ResourceGroupName = resourceGroupName,
                ManagedInstanceName = managedInstanceName,
                KeyId = managedInstanceKey.Uri,
                ManagedInstanceKeyName = managedInstanceKey.Name,
                Type = skType,
                Thumbprint = managedInstanceKey.Thumbprint,
                CreationDate = skType == ServerKeyType.AzureKeyVault ? managedInstanceKey.CreationDate : null
            };

            return key;
        }
    }
}
