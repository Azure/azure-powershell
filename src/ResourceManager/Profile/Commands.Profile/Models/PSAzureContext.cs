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
            return new PSAzureContext
            {
                Account = context != null ? context.Account : null,
                Environment = context != null ? context.Environment : null,
                Subscription = context != null ? context.Subscription : null,
                Tenant = context != null ? context.Tenant : null,
                TokenCache = context != null ? context.TokenCache : null
            };
        }

        /// <summary>
        /// Convert between implementations of the current connection context for Azure.
        /// </summary>
        /// <param name="context">The connection context to covnert.</param>
        /// <returns>The converted context.</returns>
        public static implicit operator AzureContext(PSAzureContext context)
        {
            var result= new AzureContext(context != null ? context.Subscription : null, context != null ? context.Account : null, 
                context != null ? context.Environment : null, context != null ? context.Tenant : null);
            result.TokenCache = context!= null? context.TokenCache : null;
            return result;
        }

        /// <summary>
        /// The account used to connect to Azure.
        /// </summary>
        public PSAzureAccount Account { get; set; }

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
