using System.Data;

namespace Microsoft.Azure.Commands.ApiManagement.Models
{
    public class ApiManagementAttributes
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public string Location { get; set; }

        public string SubscriptionId { get; set; }

        public string ResourceGroup { get; set; }

        public string Sku { get; set; }

        public int Capacity { get; set; }

        public string PublisherEmail { get; set; }

        public string PublisherName { get; set; }

        //[JsonProperty(PropertyName = "sku")]
        //public ApiServiceSkuProperties SkuProperties { get; set; }

        public string ProvisioningState { get; set; }

        //public string TargetProvisioningState { get; set; }

        public string RuntimeUrl { get; set; }

        public string PortalUrl { get; set; }

        public string AddresserEmail { get; set; }
    }
}