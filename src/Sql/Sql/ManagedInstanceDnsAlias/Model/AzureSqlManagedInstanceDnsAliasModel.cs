using System;
using System.Collections.Generic;
using System.Text;

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
