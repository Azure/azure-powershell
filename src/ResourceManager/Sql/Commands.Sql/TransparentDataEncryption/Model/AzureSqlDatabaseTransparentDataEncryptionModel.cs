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

namespace Microsoft.Azure.Commands.Sql.TransparentDataEncryption.Model
{
    /// <summary>
    /// The possible states in which an Transparent Data Encryption may be in
    /// </summary>
    public enum TransparentDataEncryptionStateType { Enabled, Disabled };

    /// <summary>
    /// Represents the core properties of an Azure Sql Database Transparent Data Encryption
    /// </summary>
    public class AzureSqlDatabaseTransparentDataEncryptionModel
    {
        /// <summary>
        /// Gets or sets the name of the resource group
        /// </summary>
        public string ResourceGroupName { get; set; }

        /// <summary>
        /// Gets or sets the name of the server
        /// </summary>
        public string ServerName { get; set; }

        /// <summary>
        /// Gets or sets the name of the database
        /// </summary>
        public string DatabaseName { get; set; }

        /// <summary>
        /// Gets or sets the state of the Transparent Data Encryption
        /// </summary>
        public TransparentDataEncryptionStateType State { get; set; }
    }
}
