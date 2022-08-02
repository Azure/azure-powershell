using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using Microsoft.Azure.Management.Compute.Models;

namespace Microsoft.Azure.Commands.Compute.Automation.Models
{
    public class PSCommunityGallery
    {
        public string Name { get; set; }
        public string Location { get; set; }
        public string Type { get; set; }
        public string UniqueId { get; set; }
    }
}