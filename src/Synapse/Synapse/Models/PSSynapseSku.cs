using Microsoft.Azure.Management.Synapse.Models;

namespace Microsoft.Azure.Commands.Synapse.Models
{
    public class PSSynapseSku
    {
        public PSSynapseSku(Sku sku)
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

        public override string ToString()
        {
            return !string.IsNullOrEmpty(this.Name) ? this.Name : base.ToString();
        }
    }
}