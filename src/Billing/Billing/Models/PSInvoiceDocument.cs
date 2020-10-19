using System;
using System.Collections.Generic;
using System.Text;

namespace Microsoft.Azure.Commands.Billing.Models
{
    public class PSInvoiceDocument
    {
        public string Id { get; set; }

        public IEnumerable<string> DocumentNumbers { get; set; }

        public string Kind { get; set; }

        public string Url { get; set; }

        public string Source { get; set; }
    }
}
