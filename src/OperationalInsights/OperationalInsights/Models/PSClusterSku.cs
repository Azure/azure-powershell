// ----------------------------------------------------------------------------------
//
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

using System.Collections.Generic;
using System.Management.Automation;
using Microsoft.Azure.Management.OperationalInsights.Models;

namespace Microsoft.Azure.Commands.OperationalInsights.Models
{
    public class PSClusterSku
    {
        public PSClusterSku(string name, long? capacity = 1000)
        {
            Capacity = capacity;
            Name = string.IsNullOrEmpty(name) ? "CapacityReservation" : name;
        }

        public PSClusterSku(ClusterSku sku)
        {
            this.Capacity = sku.Capacity;
            this.Name = sku.Name;
        }

        public long? Capacity { get; set; }

        public string Name { get; set; }

        public ClusterSku geteClusterSku()
        {
            return new ClusterSku(this.Capacity, this.Name);
        }

        private void validateCapacity()
        {
            if (this.Capacity < 1000 || this.Capacity > 2000)
            {
                throw new PSArgumentException("SkuCapacity need to be in range '1000 - 2000' ");
            }

            if (this.Capacity%100 != 0)
            {
                throw new PSArgumentException("SkuCapacity need to be multiple of 100 ");
            }
        }
    }
}
