using Microsoft.Azure.Commands.Common.Authentication.Abstractions;
using Microsoft.Azure.Commands.Profile.Models;
using Microsoft.Azure.Internal.Subscriptions.Models;
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using Newtonsoft.Json;
using System;
using Xunit;

namespace Microsoft.Azure.Commands.Profile.Test.UnitTest
{
    public class PSAzureSubscriptionTest
    {

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void NewPSAzureSubscription()
        {
            string locationPlacementId = "Internal_2014-09-01";
            string quotaId= "Internal_2014-09-01";
            SpendingLimit spendingLimit = SpendingLimit.Off;
            var subscriptionPolicies = new SubscriptionPolicies(locationPlacementId, quotaId, spendingLimit);

            // test PSAzureSubscriptionPolicies' constructors
            var psAzureSubscriptionPolicies = new PSAzureSubscriptionPolicy(subscriptionPolicies);
            Assert.Equal(psAzureSubscriptionPolicies.LocationPlacementId, locationPlacementId);
            Assert.Equal(psAzureSubscriptionPolicies.QuotaId, quotaId);
            Assert.Equal(psAzureSubscriptionPolicies.SpendingLimit, spendingLimit.ToString());

            var psAzureSubscriptionPolicies2 = new PSAzureSubscriptionPolicy(JsonConvert.SerializeObject(subscriptionPolicies));
            Assert.Equal(psAzureSubscriptionPolicies2.LocationPlacementId, locationPlacementId);
            Assert.Equal(psAzureSubscriptionPolicies2.QuotaId, quotaId);
            Assert.Equal(psAzureSubscriptionPolicies2.SpendingLimit, spendingLimit.ToString());

            var sub = new AzureSubscription
            {
                Id = new Guid().ToString(),
                Name = "Contoso Test Subscription",
                State = "Enabled",
            };
            sub.SetAccount("me@contoso.com");
            sub.SetEnvironment("testCloud");
            sub.SetTenant(new Guid("3c0ff8a7-e8bb-40e8-ae66-271343379af6").ToString());
            sub.SetSubscriptionPolicies(JsonConvert.SerializeObject(subscriptionPolicies));

            // test PSAzureSubscription's constructor
            var psAzureSubscription = new PSAzureSubscription(sub);
            Assert.NotNull(psAzureSubscription.SubscriptionPolicies);
            Assert.Equal(psAzureSubscription.SubscriptionPolicies.LocationPlacementId, locationPlacementId);
            Assert.Equal(psAzureSubscription.SubscriptionPolicies.QuotaId, quotaId);
            Assert.Equal(psAzureSubscription.SubscriptionPolicies.SpendingLimit, spendingLimit.ToString());
        }
    }
}
