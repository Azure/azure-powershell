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