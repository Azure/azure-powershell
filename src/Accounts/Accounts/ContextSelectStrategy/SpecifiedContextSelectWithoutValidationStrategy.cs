using Microsoft.Azure.Commands.Common.Authentication.Abstractions;
using Microsoft.Identity.Client;
using Microsoft.Identity.Client.NativeInterop;

using System;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.Profile.ContextSelectStrategy
{
    public class SpecifiedContextSelectWithoutValidationStrategy : ContextSelectStrategy
    {
        private string _subscriptionId;
        private string _tenantId;
        private string _accountId;

        public SpecifiedContextSelectWithoutValidationStrategy(string subscriptionId, string tenantIdOrName, string accountId)
        {
            this._subscriptionId = subscriptionId;
            this._tenantId = tenantIdOrName;
            this._accountId = accountId;
        }


        public override (IAzureTenant, IAzureSubscription) GetDefaultTenantAndSubscription(ContextSelectParameter selectParameter)
        {
            var defaultSubscription = new AzureSubscription
            {
                Id = _subscriptionId
            };

            defaultSubscription.SetOrAppendProperty(AzureSubscription.Property.Tenants, _tenantId);
            defaultSubscription.SetOrAppendProperty(AzureSubscription.Property.Account, _accountId);

            var defaultTenant = new AzureTenant
            {
                Id = _tenantId
            };
            return (defaultTenant, defaultSubscription);
        }
    }
}
