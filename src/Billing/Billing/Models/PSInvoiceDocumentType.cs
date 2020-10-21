using System;
using System.Collections.Generic;
using System.Text;

namespace Microsoft.Azure.Commands.Billing.Models
{
    public enum PSInvoiceDocumentType
    {
        Unknown,
        Invoice,
        VoidNote,
        TaxReceipt,
        CreditNote
    }
}
