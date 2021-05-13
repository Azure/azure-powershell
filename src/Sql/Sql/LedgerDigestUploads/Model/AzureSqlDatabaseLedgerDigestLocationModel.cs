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

        public Int64 LastDigestBlockId { get; set; }

        public bool IsCurrent { get; set; }
    }
}
