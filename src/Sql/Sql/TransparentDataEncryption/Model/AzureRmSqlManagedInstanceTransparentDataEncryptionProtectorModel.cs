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
using System.Runtime.CompilerServices;
using Microsoft.Azure.Management.Sql.Models;

namespace Microsoft.Azure.Commands.Sql.TransparentDataEncryption.Model
{
    /// <summary>
    /// Represents the core properties of an Azure Sql Database Transparent Data Encryption Protector
    /// </summary>
    public class AzureRmSqlManagedInstanceTransparentDataEncryptionProtectorModel
    {

        public AzureRmSqlManagedInstanceTransparentDataEncryptionProtectorModel(string resourceGroupName, string managedInstanceName)
        {
            ResourceGroupName = resourceGroupName;
            ManagedInstanceName = managedInstanceName;
        }

        public AzureRmSqlManagedInstanceTransparentDataEncryptionProtectorModel(string resourceGroupName, string managedInstanceName, EncryptionProtectorType type, string keyId, bool? autoRotatonEnabled) 
            : this(resourceGroupName, managedInstanceName)
        {
            Type = type;
            KeyId = keyId;
            AutoRotationEnabled = autoRotatonEnabled;
        }

        /// <summary>
        /// Gets or sets the name of the resource group
        /// </summary>
        public string ResourceGroupName { get; private set; }

        /// <summary>
        /// Gets or sets the name of the managed instance
        /// </summary>
        public string ManagedInstanceName { get; private set; }

        /// <summary>
        /// Gets or sets the type of the Encryption Protector
        /// </summary>
        public EncryptionProtectorType Type { get; private set; }

        /// <summary>
        /// Gets or sets the name of the Instance Key Vault Key
        /// </summary>
        public string ManagedInstanceKeyVaultKeyName { get; private set; }

        /// <summary>
        /// Gets or sets the KeyId
        /// </summary>
        public string KeyId { get; private set; }

        /// <summary>
        /// Gets or sets the key auto rotation status.
        /// </summary>
        public bool? AutoRotationEnabled { get; set; }

        /// <summary>
        /// Create a AzureRmSqlManagedInstanceTransparentDataEncryptionProtectorModel from a given ManagedInstanceEncryptionProtector
        /// </summary>
        /// <param name="resourceGroupName"></param>
        /// <param name="managedInstanceName"></param>
        /// <param name="managedInstanceEncryptionProtector"></param>
        /// <returns></returns>
        public static AzureRmSqlManagedInstanceTransparentDataEncryptionProtectorModel FromManagedInstanceEncryptionProtector(
            string resourceGroupName, string managedInstanceName, ManagedInstanceEncryptionProtector managedInstanceEncryptionProtector)
        {
            EncryptionProtectorType type = EncryptionProtectorType.ServiceManaged;
            Enum.TryParse<Model.EncryptionProtectorType>(managedInstanceEncryptionProtector.ServerKeyType, true, out type);

            return new AzureRmSqlManagedInstanceTransparentDataEncryptionProtectorModel(
                resourceGroupName: resourceGroupName, managedInstanceName: managedInstanceName)
            {
                ManagedInstanceKeyVaultKeyName = managedInstanceEncryptionProtector.ServerKeyName,
                Type = type,
                KeyId = managedInstanceEncryptionProtector.Uri,
                AutoRotationEnabled = managedInstanceEncryptionProtector.AutoRotationEnabled
            };
        }
    }
}
