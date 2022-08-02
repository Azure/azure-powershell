using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using Microsoft.Azure.Management.Compute.Models;

namespace Microsoft.Azure.Commands.Compute.Automation.Models
{

    public class PSCommunityGalleryImageVersion
    {
        public DateTime? PublishedDate { get; set; }
        public DateTime? EndOfLifeDate { get; set; }
        public bool? ExcludeFromLatest { get; set; }
        public SharedGalleryImageVersionStorageProfile StorageProfile { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public string Type { get; set; }
        public string UniqueId { get; set; }
    }

    public class PSCommunityGalleryImageVersionList : PSCommunityGalleryImageVersion
    {
        public PSCommunityGalleryImageVersion ToPSCommunityGalleryImageVersion()
        {
            return ComputeAutomationAutoMapperProfile.Mapper.Map<PSCommunityGalleryImageVersion>(this);
        }
    }
}