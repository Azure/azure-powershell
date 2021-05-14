using System;
using System.Collections.Generic;
using System.Text;

namespace Microsoft.Azure.Commands.Sql.LedgerDigestUploads.Model
{
	class AzureSqlDatabaseLedgerDigestLocationModel
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
        /// Gets or sets the ledger digest upload endpoint
        /// </summary>
        public string Endpoint { get; set; }

        /// <summary>
        /// Gets or sets the last digest block id for this location
        /// </summary>
        public Int64 LastDigestBlockId { get; set; }

        /// <summary>
        /// Gets or sets whether this is the current location
        /// </summary>
        public bool IsCurrent { get; set; }
    }
}
