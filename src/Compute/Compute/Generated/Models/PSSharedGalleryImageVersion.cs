using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using Microsoft.Azure.Management.Compute.Models;

namespace Microsoft.Azure.Commands.Compute.Automation.Models
{
    public class PSSharedGalleryImageVersion
    {
        public string Name { get; set; }
        public string Location { get; set; }
        public string UniqueId { get; set; }
        public DateTime? PublishedDate { get; set; }
        public DateTime? EndOfLifeDate { get; set; }
    }
}
