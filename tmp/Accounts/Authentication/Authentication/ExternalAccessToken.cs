using System;
using System.Collections.Generic;
using System.Text;

namespace Microsoft.Azure.Commands.Common.Authentication.Authentication
{
    public class ExternalAccessToken : IAccessToken
    {
        public string AccessToken
        {
            get; set;
        }

        public string LoginType
        {
            get; set;
        }

        public string TenantId
        {
            get; set;
        }

        public string UserId
        {
            get; set;
        }

        public string HomeAccountId { get; set; }

        public IDictionary<string, string> ExtendedProperties { get; set; }

        private readonly Func<string> _refresh;

        public ExternalAccessToken(string accessToken, Func<string> renew = null)
        {
            this.AccessToken = accessToken;
            this._refresh = renew;
        }

        public void AuthorizeRequest(Action<string, string> authTokenSetter)
        {
            AccessToken = (_refresh == null) ? AccessToken : _refresh();
            authTokenSetter("Bearer", AccessToken);
        }
    }
}
