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
namespace Microsoft.Azure.Commands.Sql.ServerKeyVaultKey.Model
{
    /// <summary>
    /// Represents the core properties of an Azure Sql Server Key
    /// </summary>
    public class AzureSqlServerKeyVaultKeyModel
    {
        /// <summary>
        /// Enum representing the allowed Server Key types
        /// </summary>
        public enum ServerKeyType { AzureKeyVault, ServiceManaged };

        /// <summary>
        /// Gets or sets the name of the resource group
        /// </summary>
        public string ResourceGroupName { get; set; }

        /// <summary>
        /// Gets or sets the name of the server
        /// </summary>
        public string ServerName { get; set; }

        /// <summary>
        /// Gets or sets the name of the server key
        /// </summary>
        public string ServerKeyName { get; set; }

        /// <summary>
        /// Gets or sets the type of the server key
        /// </summary>
        public ServerKeyType Type { get; set; }

        /// <summary>
        /// Gets or sets the uri of the server key
        /// </summary>
        public string Uri { get; set; }

        /// <summary>
        /// Gets or sets the thumbprint of the server key
        /// </summary>
        public string Thumbprint { get; set; }

        /// <summary>
        /// Gets or sets the creation date of the server key
        /// </summary>
        public DateTime? CreationDate { get; set; }
    }
}
