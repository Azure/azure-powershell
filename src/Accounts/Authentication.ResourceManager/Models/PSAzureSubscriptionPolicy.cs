using Newtonsoft.Json;
using Microsoft.Azure.Internal.Subscriptions.Models;

namespace Microsoft.Azure.Commands.Profile.Models
{
    public class PSAzureSubscriptionPolicy
    {
        /// <summary>
        /// Default constructor
        /// </summary>
        public PSAzureSubscriptionPolicy()
        {

        }

        /// <summary>
        /// object constructor
        /// </summary>
        /// <param name="subscriptionPolicies">Json string to convert</param>
        public PSAzureSubscriptionPolicy(SubscriptionPolicies subscriptionPolicies)
        {
            if (subscriptionPolicies != null)
            {
                this.LocationPlacementId = subscriptionPolicies.LocationPlacementId;
                this.QuotaId = subscriptionPolicies.QuotaId;
                this.SpendingLimit = subscriptionPolicies.SpendingLimit.ToString();
            }
        }

        /// <summary>
        /// string constructor
        /// </summary>
        /// <param name="azureSubscriptionPolicies">Json string to convert</param>
        public PSAzureSubscriptionPolicy(string azureSubscriptionPolicies) : this(string.IsNullOrEmpty(azureSubscriptionPolicies)?null:JsonConvert.DeserializeObject<SubscriptionPolicies>(azureSubscriptionPolicies)) { }

        public string LocationPlacementId { get; private set; }

        public string QuotaId { get; private set; }

        public string SpendingLimit { get; private set; }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this, Formatting.Indented, 
                new JsonSerializerSettings() { NullValueHandling = NullValueHandling.Ignore });
        }

    }
}