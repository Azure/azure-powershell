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

using System.Collections.Generic;
using System.Security;

namespace Microsoft.Azure.Commands.Sql.ManagedInstance.Model
{
    /// <summary>
    /// Represents the core properties of an Managed instance
    /// </summary>
    public class AzureSqlManagedInstanceModel
    {
        /// <summary>
        /// Gets or sets the location the managed instance is in
        /// </summary>
        public string Location { get; set; }

        /// <summary>
        /// Gets or sets the resource ID.
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Gets or sets the resource group name.
        /// </summary>
        public string ResourceGroupName { get; set; }

        /// <summary>
        /// Gets or sets the name of the managed instance
        /// </summary>
        public string ManagedInstanceName { get; set; }

        /// <summary>
        /// Gets or sets the tags associated with the managed instance.
        /// </summary>
        public Dictionary<string, string> Tags { get; set; }

        /// <summary>
        /// Gets or sets the identity of the managed instance.
        /// </summary>
        public Management.Sql.Models.ResourceIdentity Identity { get; set; }

        /// <summary>
        /// Gets or sets the Sku of the managed instance
        /// </summary>
        public Management.Internal.Resources.Models.Sku Sku { get; set; }

        /// <summary>
        /// Gets or sets the fully qualified domain name of the managed instance
        /// </summary>
        public string FullyQualifiedDomainName { get; set; }

        /// <summary>
        /// Gets or sets the sql login credentials for the admin
        /// </summary>
        public string AdministratorLogin { get; set; }

        /// <summary>
        /// Gets or sets the password for the sql admin
        /// </summary>
        public SecureString AdministratorPassword { get; set; }

        /// <summary>
        /// Gets or sets subnet resource ID for the managed instance.
        /// </summary>
        public string SubnetId { get; set; }

        /// <summary>
        /// Gets or sets the license type. Possible values are
        /// 'LicenseIncluded' and 'BasePrice'.
        /// </summary>
        public string LicenseType { get; set; }

        /// <summary>
        /// Gets or sets the number of VCores.
        /// </summary>
        public int? VCores { get; set; }

        /// <summary>
        /// Gets or sets the maximum storage size in GB.
        /// </summary>
        public int? StorageSizeInGB { get; set; }

        /// <summary>
        /// Gets or sets the Managed Instance collation
        /// </summary>
        public string Collation { get; set; }

        /// <summary>
        /// Gets or sets whether or not the public data endpoint is enabled.
        /// </summary>
        public bool? PublicDataEndpointEnabled { get; set; }

        /// <summary>
        /// Gets or sets connection type used for connecting to the instance.
        /// Possible values include: 'Proxy', 'Redirect', 'Default'
        /// </summary>
        public string ProxyOverride { get; set; }

        /// <summary>
        /// Gets or sets the Managed Instance time zone
        /// </summary>
        public string TimezoneId { get; set; }

    }
}
