// ----------------------------------------------------------------------------------
//
// Copyright Microsoft Corporation
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// http://www.apache.org/licenses/LICENSE-2.0
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// ----------------------------------------------------------------------------------
using Microsoft.Azure.Commands.Common.Authentication;
using Microsoft.Azure.Commands.Common.Authentication.Abstractions;
using Microsoft.Azure.Commands.Profile.Properties;

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

using System;
using System.Threading.Tasks;

namespace Microsoft.Azure.Commands.Profile.Utilities
{
    internal class OpenIDConfiguration : IOpenIDConfiguration
    {
        private const string DefaultPath = "{0}/v2.0/.well-known/openid-configuration";

        internal Uri Authority;

        internal string Path;

        internal string Tenant;

        private IHttpOperationsFactory _httpClientFactory = null;

        public OpenIDConfiguration(string tenantDomain, string baseUri, string path = DefaultPath, IHttpOperationsFactory httpClientFactory = null)
        {
            this.Authority = new Uri(baseUri);
            this.Path = string.Format(path, tenantDomain);
            this.Tenant = tenantDomain;
            this._httpClientFactory = httpClientFactory;
            AbsoluteUri = new Uri(Authority, Path).AbsoluteUri;
        }

        public async Task<string> GetIssuerAsync(IHttpOperationsFactory httpClientFactory)
        {
            var url = new Uri(AbsoluteUri);
            if (!Uri.IsWellFormedUriString(url.AbsoluteUri, UriKind.Absolute))
            {
                throw new UriFormatException(string.Format(Resources.InvalidOpenIDConfigUri, url));
            }

            OpenIDConfigDoc = await httpClientFactory.ReadAsStringAsync(url);
            var jObject = JsonConvert.DeserializeObject<JObject>(OpenIDConfigDoc);
            foreach (JProperty property in jObject.Properties())
            {
                if (string.Equals(property.Name, "issuer"))
                {
                    return (string)property.Value;
                }
            }
            throw new InvalidOperationException(string.Format(Resources.OpenIDConfigResponseError, OpenIDConfigDoc));
        }

        private string tenantId = null;

        public string TenantId
        {
            get
            {
                if (tenantId == null)
                {
                    if (_httpClientFactory != null)
                    {
                        var issuer = GetIssuerAsync(_httpClientFactory).ConfigureAwait(false).GetAwaiter().GetResult();
                        var parts = issuer.SplitRemoveEmpty('/');
                        if (parts.Length < 3 || !Guid.TryParse(parts[2], out Guid _))
                        {
                            throw new InvalidOperationException(string.Format(Resources.TenantIdNotFoundinIssuer, issuer));
                        }
                        tenantId = parts[2];
                    }
                }
                return tenantId;
            }
        }

        public string AbsoluteUri
        {
            get;
            private set;
        }

        public string OpenIDConfigDoc
        {
            get;
            private set;
        }
    }
}
