using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using Microsoft.Azure.Management.Compute.Models;

namespace Microsoft.Azure.Commands.Compute.Automation.Models
{
    public class PSCapacityReservationGroup
    {
        public string Name { get; set; }
        public string Type { get; set; }
        public IDictionary<string, string> Tags { get; set; }
        public string Location { get; set; }
        public string Id { get; set; }
        public IList<SubResourceReadOnly> CapacityReservations { get; set; }
        public IList<SubResourceReadOnly> VirtualMachinesAssociated { get; set; }
        public CapacityReservationGroupInstanceView InstanceView { get; set; }
        public IList<string> Zones { get; set; }
        public ResourceSharingProfile SharingProfile { get; set; }
    }
}