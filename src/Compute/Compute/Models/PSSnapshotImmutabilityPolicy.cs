using System;

namespace Microsoft.Azure.Commands.Compute.Automation.Models
{
    public class PSSnapshotImmutabilityPolicy
    {
        public int? ImmutabilityDurationDays { get; set; }
        public string Type { get; set; }
        public DateTime? PolicyStartTime { get; set; }
        public DateTime? PolicyExpirationTime { get; set; }
        public bool? IsPolicyExpired { get; set; }
    }

    public partial class PSSnapshot
    {
        public PSSnapshotImmutabilityPolicy ImmutabilityPolicy { get; set; }
    }
}
