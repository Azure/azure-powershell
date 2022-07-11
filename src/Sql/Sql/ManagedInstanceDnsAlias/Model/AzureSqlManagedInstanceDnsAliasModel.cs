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

namespace Microsoft.Azure.Commands.Sql.ManagedInstanceDnsAlias.Model
{
    public class AzureSqlManagedInstanceDnsAliasModel
    {
        /// <summary>
        /// Gets or sets the name of resource group
        /// </summary>
        public string ResourceGroupName { get; set; }

        /// <summary>
        /// Gets or sets the name of the managed instance
        /// </summary>
        public string ManagedInstanceName { get; set; }

        /// <summary>
        /// Gets or sets the name of managed instance dns alias
        /// </summary>
        public string DnsAliasName { get; set; }

        /// <summary>
        /// Gets or sets the id of the resource
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Gets or sets the Azure DNS record.
        /// </summary>
        public string AzureDnsRecord { get; set; }

        /// <summary>
        /// Gets or sets the public Azure DNS record.
        /// </summary>
        public string PublicAzureDnsRecord { get; set; }
    }
}
