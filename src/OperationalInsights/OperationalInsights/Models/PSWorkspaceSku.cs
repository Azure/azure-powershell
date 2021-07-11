using System;
using System.Collections.Generic;
using System.Management.Automation;
using System.Text;
using Microsoft.Azure.Management.OperationalInsights.Models;

namespace Microsoft.Azure.Commands.OperationalInsights.Models
{
    public enum AllowedWorkspaceServiceTiers
    {
        free,
        standard,
        premium,
        pernode,
        standalone,
        pergb2018,
        CapacityReservation,
        lacluster
    }

    public class PSWorkspaceSku
    {

        public PSWorkspaceSku(string name, int? capacity = null)
        {
            this.Capacity = capacity;
            this.Name = name;
            ValidateSKU();
        }

        public PSWorkspaceSku(WorkspaceSku sku)
        {
            this.Capacity = sku.CapacityReservationLevel;
            this.Name = sku.Name;
            this.LastSkuUpdate = sku.LastSkuUpdate;
        }

        public int? Capacity { get; set; }

        public string Name { get; set; }

        public string LastSkuUpdate { get; set; }

        public WorkspaceSku getWorkspaceSku()
        {
            return new WorkspaceSku(Name, capacityReservationLevel: Capacity);
        }

        private void ValidateSKU()
        {
            AllowedWorkspaceServiceTiers serviceTrier;
            if (!Enum.TryParse(this.Name, out serviceTrier))
            {
                throw new PSArgumentException($"Sku name only supports:{AllowedWorkspaceServiceTiers.standard}, {AllowedWorkspaceServiceTiers.premium}, " +
                    $"{AllowedWorkspaceServiceTiers.pernode}, {AllowedWorkspaceServiceTiers.standalone}, {AllowedWorkspaceServiceTiers.pergb2018}, " +
                    $"{AllowedWorkspaceServiceTiers.CapacityReservation}, {AllowedWorkspaceServiceTiers.lacluster}");
            }

            if (this.Capacity != null && !serviceTrier.Equals(AllowedWorkspaceServiceTiers.CapacityReservation))
            {
                throw new PSArgumentException($"Failed to set Capacity for SKU: {serviceTrier}, Capacity is only supportted for {AllowedWorkspaceServiceTiers.CapacityReservation} SKU");
            }

            if (this.Capacity < 1000)
            {
                throw new PSArgumentException("SkuCapacity need to be above 1000 GB ");
            }

            if (this.Capacity % 100 != 0)
            {
                throw new PSArgumentException("SkuCapacity need to be multiple of 100 ");
            }
        }

    }
}
