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

namespace Microsoft.WindowsAzure.Commands.ServiceManagement.IaaS.Extensions
{
    /// <summary>
    /// SQL Server extension's private settings - Guest agent infrastructure owns securing these private settings
    /// </summary>
    public class SqlServerPrivateSettings
    {
        /// <summary>
        /// Azure blob store URL
        /// </summary>
        public string StorageUrl;

        /// <summary>
        /// Storage account access key
        /// </summary>
        public string StorageAccessKey;

        /// <summary>
        ///  Password required for certification when encryption is enabled
        /// </summary>
        public string Password;

        /// <summary>
        /// Azure Key Vault Credential settings
        /// </summary>
        public PrivateKeyVaultCredentialSettings PrivateKeyVaultCredentialSettings;

    }
}
