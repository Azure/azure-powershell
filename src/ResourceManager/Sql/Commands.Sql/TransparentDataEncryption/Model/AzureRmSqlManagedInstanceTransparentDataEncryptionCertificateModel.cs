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

using System.Security;

namespace Microsoft.Azure.Commands.Sql.TransparentDataEncryption.Model
{
    /// <summary>
    /// Represents the core properties of an Azure Sql Database Transparent Data Encryption Certificate
    /// </summary>
    public class AzureRmSqlManagedInstanceTransparentDataEncryptionCertificateModel
    {
        /// <summary>
        /// Gets or sets the name of the resource group
        /// </summary>
        public string ResourceGroupName { get; set; }

        /// <summary>
        /// Gets or sets the name of the managed instance
        /// </summary>
        public string ManagedInstanceName { get; set; }

        /// <summary>
        /// Gets or sets the private blob for the Transparent Data Encryption certificate
        /// </summary>
        public SecureString PrivateBlob { get; set; }

        /// <summary>
        /// Gets or sets the password for the Transparent Data Encryption certificate
        /// </summary>
        public SecureString Password { get; set; }

        /// <summary>
        /// Gets or sets the name for the Transparent Data Encryption certificate
        /// </summary>
        public string Name { get; set; }
    }
}
