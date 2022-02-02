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

using Microsoft.Azure.Management.Synapse.Models;

namespace Microsoft.Azure.Commands.Synapse.Models
{
    public class PSSynapseSku
    {
        public PSSynapseSku(Sku sku)
        {
            this.Tier = sku?.Tier;
            this.Name = sku?.Name;
            this.Capacity = sku?.Capacity ?? 0;
        }

        public PSSynapseSku(SkuV3 sku)
        {
            this.Tier = sku?.Tier;
            this.Name = sku?.Name;
        }

        /// <summary>
        /// Gets the service tier
        /// </summary>
        public string Tier { get; set; }

        /// <summary>
        /// Gets the SKU name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets if the SKU supports scale out/in then the capacity
        /// integer should be included. If scale out/in is not possible for the
        /// resource this may be omitted.
        /// </summary>
        public int Capacity { get; set; }

        public override string ToString()
        {
            return !string.IsNullOrEmpty(this.Name) ? this.Name : base.ToString();
        }
    }
}