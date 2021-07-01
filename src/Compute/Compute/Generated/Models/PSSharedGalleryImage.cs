using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using Microsoft.Azure.Management.Compute.Models;

namespace Microsoft.Azure.Commands.Compute.Automation.Models
{
    public class PSSharedGalleryImage
    {
        public OperatingSystemTypes OsType { get; set; }
        public OperatingSystemStateTypes OsState { get; set; }
        public DateTime? EndOfLifeDate { get; set; }
        public GalleryImageIdentifier Identifier { get; set; }
        public RecommendedMachineConfiguration Recommended { get; set; }
        public Disallowed Disallowed { get; set; }
        public string HyperVGeneration { get; set; }
        public IList<GalleryImageFeature> Features { get; set; }
        public ImagePurchasePlan PurchasePlan { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public string UniqueId { get; set; }
    }
}
