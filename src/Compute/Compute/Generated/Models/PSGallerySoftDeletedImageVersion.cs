using System;
using System.Collections.Generic;

namespace Microsoft.Azure.Commands.Compute.Automation.Models
{
    public class PSGallerySoftDeletedImageVersion
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public string Location { get; set; }
        public IDictionary<string, string> Tags { get; set; }
        public string SoftDeletedTime { get; set; }
        public DateTime? ConsumptionEndTime { get; set; }
        public DateTime? HardDeletionTargetTime { get; set; }
    }
}
