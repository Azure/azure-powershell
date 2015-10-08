using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Azure.Common.Authentication.Models;

namespace Microsoft.Azure.Commands.Profile.Models
{
    /// <summary>
    /// The context for connecting cmdlets in the current session to Azure.
    /// </summary>
    public class PSAzureContext
    {
        /// <summary>
        /// Convert between implementations of the current connection context for Azure.
        /// </summary>
        /// <param name="context">The connection context to covnert.</param>
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
        /// <param name="context">The connection context to covnert.</param>
        /// <returns>The converted context.</returns>
        public static implicit operator AzureContext(PSAzureContext context)
        {
            if (context == null)
            {
                return null;
            }

            var result = new AzureContext(context.Subscription, context.Account, 
                context.Environment, context.Tenant);
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
        private byte[] TokenCache { get; set; }
    }
}
