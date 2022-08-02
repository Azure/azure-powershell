using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using Microsoft.Azure.Management.Compute.Models;

namespace Microsoft.Azure.Commands.Compute.Automation.Models
{

    public class PSCommunityGalleryImage 
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
        public string Architecture { get; set; }
        public string PrivacyStatementUri { get; set; }
        public string Eula { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public string Type { get; set; }
        public string UniqueId { get; set; }
    }

    public class PSCommunityGalleryImageList : PSCommunityGalleryImage
    {
        public PSCommunityGalleryImage ToPSCommunityGalleryImage()
        {
            return ComputeAutomationAutoMapperProfile.Mapper.Map<PSCommunityGalleryImage>(this);
        }
    }
}