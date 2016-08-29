using System;
using System.Linq;

namespace Microsoft.Azure.Commands.DevTestLabs
{
    internal class WellKnownPolicyNames
    {
        public const string MarketplaceImages = "GalleryImage";
        public const string MaxVmsAllowedPerUser = "MaxVmsAllowedPerUser";
        public const string MaxVmsAllowedPerLab = "MaxVmsAllowedPerLab";
        public const string LabVmsShutdown = "LabVmsShutdown";
        public const string LabVmsAutoStart = "LabVmAutoStart";
        public const string AllowedVmSizesInLab = "AllowedVmSizesInLab";
        public const string LabBillingTask = "LabBillingTask";
    }
}
