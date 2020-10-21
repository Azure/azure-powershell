using System;
using System.Collections.Generic;
using System.Text;

namespace Microsoft.Azure.Commands.Billing.Models
{
    public class PSAmount
    {
        public string Currency { get; set; }

        public double? Value { get; set; }
    }
}
