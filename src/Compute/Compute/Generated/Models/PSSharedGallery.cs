using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using Microsoft.Azure.Management.Compute.Models;

namespace Microsoft.Azure.Commands.Compute.Automation.Models
{
    public class PSSharedGallery
    {
        public string Name { get; set; }
        public string Location { get; set; }
        public string UniqueId { get; set; }
    }
}