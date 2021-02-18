using System;
using System.Collections.Generic;
using System.Text;

namespace Microsoft.Azure.Commands.Billing.Models
{
    public enum PSInvoiceStatus
    {
        /// <summary>
        /// Payment due.
        /// </summary>
        Due = 0,

        /// <summary>
        /// Payment due past the due date.
        /// </summary>
        OverDue = 1,

        /// <summary>
        /// Payment(s) completed. No remaining amount due.
        /// </summary>
        Paid = 2,

        /// <summary>
        /// Invoice voided. No remaining amount due.
        /// </summary>
        Void = 3,

        /// <summary>
        /// Unknown status.
        /// </summary>
        Unknown = 4
    }
}
