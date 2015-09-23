using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Azure.Common.Authentication.Models;
using Microsoft.Azure.Subscriptions.Models;

namespace Microsoft.Azure.Commands.ResourceManager.Common
{
    public static class ModelExtensions
    {

        public static AzureSubscription ToAzureSubscription(this Subscription other, AzureContext context)
        {
            var subscription = new AzureSubscription();
            subscription.Account = context.Account != null ? context.Account.Id : null;
            subscription.Environment = context.Environment != null ? context.Environment.Name : EnvironmentName.AzureCloud;
            subscription.Id = new Guid(other.SubscriptionId);
            subscription.Name = other.DisplayName;
            subscription.SetProperty(AzureSubscription.Property.Tenants,
                context.Tenant.Id.ToString());
            return subscription;
        }
    }
}
