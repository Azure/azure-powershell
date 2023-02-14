// ----------------------------------------------------------------------------------
// Copyright Microsoft Corporation
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// http://www.apache.org/licenses/LICENSE-2.0
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// ----------------------------------------------------------------------------------

using System;
using System.Management.Automation;
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

        public PSWorkspaceSku()
        {
            this.Capacity = null;
            this.Name = null;
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
            if (Name == null)
            {
                return null;
            }
            return new WorkspaceSku(Name, capacityReservationLevel: Capacity);
        }

        private void ValidateSKU()
        {
            AllowedWorkspaceServiceTiers serviceTrier;
            if (!Enum.TryParse(this.Name, ignoreCase:true, out serviceTrier))
            {
                throw new PSArgumentException($"Sku name only supports:{AllowedWorkspaceServiceTiers.standard}, {AllowedWorkspaceServiceTiers.premium}, " +
                    $"{AllowedWorkspaceServiceTiers.pernode}, {AllowedWorkspaceServiceTiers.standalone}, {AllowedWorkspaceServiceTiers.pergb2018}, " +
                    $"{AllowedWorkspaceServiceTiers.CapacityReservation}, {AllowedWorkspaceServiceTiers.lacluster}");
            }

            if ((this.Capacity != null || this.Capacity != 0) && serviceTrier.Equals(AllowedWorkspaceServiceTiers.CapacityReservation))
            {
                throw new PSArgumentException($"Failed to set Capacity for SKU: {serviceTrier}, Capacity is only supportted for {AllowedWorkspaceServiceTiers.CapacityReservation} SKU");
            }

            if (this.Capacity != null && this.Capacity < 1000)
            {
                throw new PSArgumentException("SkuCapacity need to be more than 1000 GB ");
            }

            if (this.Capacity != null && this.Capacity % 100 != 0)
            {
                throw new PSArgumentException("SkuCapacity need to be multiple of 100 ");
            }
        }

    }
}
