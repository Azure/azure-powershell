using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.Azure.Commands.KeyVault.Models
{
    public class KeyVaultObjectFilterOptions
    {
        public string VaultName { get; set; }

        public string Name { get; set; }
               
        /// <summary>
        /// Used internally to track the paging for the listing, do not change manually.
        /// </summary>
        public string NextLink { get; set; }

    }
}
