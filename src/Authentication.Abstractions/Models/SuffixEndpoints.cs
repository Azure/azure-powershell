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

namespace Microsoft.Azure.Commands.Common.Authentication.Abstractions.Models
{
    /// <summary>
    /// ARM suffix endpoints schema.
    /// </summary>
    internal class SuffixEndpoints
    {
        /// <summary>
        /// Gets or sets the AzureDataLakeStoreFileSystem endpoint.
        /// </summary>        
        public string AzureDataLakeStoreFileSystem { get; set; }

        /// <summary>
        /// Gets or sets the ACRLoginServer endpoint.
        /// </summary>
        public string AcrLoginServer { get; set; }

        /// <summary>
        /// Gets or sets the SQLServerHostname endpoint.
        /// </summary>
        public string SqlServerHostname { get; set; }

        /// <summary>
        /// Gets or sets the AzureDataLakeAnalyticsCatalogAndJob endpoint.
        /// </summary>
        public string AzureDataLakeAnalyticsCatalogAndJob { get; set; }

        /// <summary>
        /// Gets or sets the KeyVaultDNS endpoint.
        /// </summary>
        public string KeyVaultDns { get; set; }

        /// <summary>
        /// Gets or sets the Storage endpoint.
        /// </summary>
        public string Storage { get; set; }
    }
}