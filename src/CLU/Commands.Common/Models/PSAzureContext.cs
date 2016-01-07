using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Azure.Commands.Common.Authentication.Models;

namespace Microsoft.Azure.Commands.Models
{
    /// <summary>
    /// The context for connecting cmdlets in the current session to Azure.
    /// </summary>
    public class PSAzureContext
    {
        /// <summary>
        /// Convert between implementations of the current connection context for Azure.
        /// </summary>
        /// <param name="context">The connection context to convert.</param>
        /// <returns>The converted context.</returns>
        public static implicit operator PSAzureContext(AzureContext context)
        {
            if (context == null)
            {
                return null;
            }
            return new PSAzureContext
            {
                Account = context.Account,
                Environment = context.Environment,
                Subscription = context.Subscription,
                Tenant = context.Tenant,
                TokenCache = context.TokenCache
            };
        }

        /// <summary>
        /// Convert between implementations of the current connection context for Azure.
        /// </summary>
        /// <param name="context">The connection context to convert.</param>
        /// <returns>The converted context.</returns>
        public static implicit operator AzureContext(PSAzureContext context)
        {
            if (context == null)
            {
                return null;
            }

            AzureContext result = null;
            if (context.Subscription == null)
            {
                result = new AzureContext(
                      context.Account,
                      context.Environment,
                      context.Tenant);
            }
            else
            {
              result = new AzureContext(
                    context.Subscription,
                    context.Account,
                    context.Environment,
                    context.Tenant);
            }
            result.TokenCache = context.TokenCache;
            return result;
        }

        /// <summary>
        /// The account used to connect to Azure.
        /// </summary>
        public PSAzureRmAccount Account { get; set; }

        /// <summary>
        /// The endpoint and connection metadata for the targeted instance of the Azure cloud.
        /// </summary>
        public PSAzureEnvironment Environment { get; set; }

        /// <summary>
        /// The subscription targeted in Azure.
        /// </summary>
        public PSAzureSubscription Subscription { get; set; }

        /// <summary>
        /// The targeted tenant in Azure.
        /// </summary>
        public PSAzureTenant Tenant { get; set; }

        public byte[] TokenCache { get; set; }

        public override string ToString()
        {
            var account = Account != null ? Account.Id : string.Empty;
            var subscription = Subscription != null ? Subscription.SubscriptionId : string.Empty;
            var tenant = Tenant != null ? Tenant.TenantId : string.Empty;
            var environment = Environment != null ? Environment.Name : EnvironmentName.AzureCloud;
            return $"{{Account: {account}, Subscription: {subscription}, Tenant: {tenant}, Environment: {environment}}}";
        }
    }
}
