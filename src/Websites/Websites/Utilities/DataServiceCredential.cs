using Microsoft.Azure.Commands.Common.Authentication.Abstractions;
using System;
using System.Linq;

namespace Microsoft.Azure.Commands.WebApps.Utilities
{
    public class DataServiceCredential
    {
        private readonly IAuthenticationFactory _authenticationFactory;
        private readonly IAzureContext _context;
        private readonly string _endpointName;

        public DataServiceCredential(IAuthenticationFactory authFactory, IAzureContext context, string resourceIdEndpoint)
        {
            if (authFactory == null)
                throw new ArgumentNullException("authFactory");
            if (context == null)
                throw new ArgumentNullException("context");
            _authenticationFactory = authFactory;
            _context = context;
            _endpointName = resourceIdEndpoint;
            this.TenantId = GetTenantId(context);
        }

        public string TenantId { get; private set; }

        private static string GetTenantId(IAzureContext context)
        {
            //if (context.Account == null)
            //{
            //    throw new ArgumentException(KeyVaultProperties..ArmAccountNotFound);
            //}

            var tenantId = string.Empty;
            if (context.Tenant != null && context.Tenant.GetId() != Guid.Empty)
            {
                tenantId = context.Tenant.Id.ToString();
            }
            else if (string.IsNullOrWhiteSpace(tenantId) && context.Subscription != null && context.Account != null)
            {
                tenantId = context.Subscription.GetPropertyAsArray(AzureSubscription.Property.Tenants)
                       .Intersect(context.Account.GetPropertyAsArray(AzureAccount.Property.Tenants))
                       .FirstOrDefault();
            }

            return tenantId;
        }

    }
}

