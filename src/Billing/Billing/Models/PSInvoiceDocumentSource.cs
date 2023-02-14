using System;
using System.Collections.Generic;
using System.Text;

namespace Microsoft.Azure.Commands.Billing.Models
{
    public enum PSInvoiceDocumentSource
    {
        /// <summary>
        /// Document source is DRS.
        /// </summary>
        DRS,

        /// <summary>
        /// Document source is ENF for Brazil
        /// </summary>
        ENF
    }
}
