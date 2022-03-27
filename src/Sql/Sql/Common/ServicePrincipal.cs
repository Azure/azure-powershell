using System;
using System.Collections.Generic;
using System.Text;

namespace Microsoft.Azure.Commands.Sql.Common
{
    //
    // Summary:
    //     The managed instance's service principal configuration for a resource.
    public class ServicePrincipal
    {
        public ServicePrincipal() { }

        public ServicePrincipal(string principalId = null, string clientId = null, string tenantId = null, string type = null)
        {
            PrincipalId = principalId;
            ClientId = clientId;
            TenantId = tenantId;
            Type = type;
        }

        //
        // Summary:
        //     Gets the Azure Active Directory application object id.
        public string PrincipalId { get; }

        //
        // Summary:
        //     Gets the Azure Active Directory application client id.
        public string ClientId { get; }

        //
        // Summary:
        //     Gets the Azure Active Directory tenant id.
        public string TenantId { get; }

        //
        // Summary:
        //     Gets or sets service principal type. Possible values include: 'None', 'SystemAssigned'
        public string Type { get; set; }
    }
}
