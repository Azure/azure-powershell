using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using Microsoft.Azure.Management.Compute.Models;

namespace Microsoft.Azure.Commands.Compute.Automation.Models
{
    public class PSPurchasePlan
    {
        public string Publisher { get; set; }
        public string Name { get; set; }
        public string Product { get; set; }
        public string PromotionCode { get; set; }
    }
}
