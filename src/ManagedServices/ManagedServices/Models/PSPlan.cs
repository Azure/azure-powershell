using Microsoft.Azure.Management.ManagedServices.Models;

namespace Microsoft.Azure.PowerShell.Cmdlets.ManagedServices.Models
{
    public class PSPlan
    {
        public string Name { get; set; }

        public string Publisher { get; set; }

        public string Product { get; set; }

        public string Version { get; set; }

        public PSPlan(Plan plan)
        {
            if (plan != null)
            {
                this.Name = plan.Name;
                this.Publisher = plan.Publisher;
                this.Product = plan.Product;
                this.Version = plan.Version;
            }
        }
    }
}