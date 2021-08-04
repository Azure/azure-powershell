using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using Microsoft.Azure.Management.Compute.Models;

namespace Microsoft.Azure.Commands.Compute.Automation.Models
{
    public class PSCapacityReservation
    {
        public string Name { get; set; }
        public string Type { get; set; }
        public IDictionary<string, string> Tags { get; set; }
        public string Location { get; set; }
        public string Id { get; set; }
        public IList<SubResourceReadOnly> VirtualMachinesAssociated { get; set; }
        public CapacityReservationInstanceView InstanceView { get; set; }
        public IList<string> Zones { get; set; }
        public string ReservationId { get; set; }
        public string ProvisioningState { get; set; }
        public DateTime? ProvisioningTime { get; set; }
        public Sku Sku { get; set; }
    }
}