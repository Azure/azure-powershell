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

        private readonly Func<string> _refresh;

        public ExternalAccessToken(string token, Func<string> refresh = null)
        {
            this.AccessToken = token;
            this._refresh = refresh;
        }

        public void AuthorizeRequest(Action<string, string> authTokenSetter)
        {
            AccessToken = (_refresh == null) ? AccessToken : _refresh();
            authTokenSetter("Bearer", AccessToken);
        }
    }
}
