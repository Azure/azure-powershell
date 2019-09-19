using System;
using System.Linq;
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
                string query = string.Empty;
                string[] queryArray = requestUri.PathAndQuery.Split(new char[] { '&' });
                if (queryArray.Length == 1)
                {
                    query = requestUri.PathAndQuery.Split(new char[] { '?' }).Last();
                }
                else
                {
                    query = queryArray.Last();
                }

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
