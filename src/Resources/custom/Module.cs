using System;
using System.Net.Http;

namespace Microsoft.Azure.PowerShell.Cmdlets.Resources
{
    public partial class Module
    {
        public string FixNextLink( HttpResponseMessage responseMessage, string nextLink )
        {
            var requestUri = responseMessage?.RequestMessage?.RequestUri;
            if (requestUri != null && !string.IsNullOrEmpty(nextLink))
            {
                string authority = requestUri.Authority;
                string tenantId = requestUri.PathAndQuery.Split(new char[] { '/' }, StringSplitOptions.RemoveEmptyEntries)[0];
                string query = requestUri.PathAndQuery.Split(new char[] { '&' })[1];
                if (!string.IsNullOrEmpty(authority) &&
                    !string.IsNullOrEmpty(tenantId) &&
                    !string.IsNullOrEmpty(query))
                {
                    nextLink = $"https://{authority}/{tenantId}/{nextLink}&{query}";
                }
            }

            return nextLink;
        }
    }
}