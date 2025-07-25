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

using Azure.Core;

using Microsoft.Azure.Commands.Common.Authentication;
using Microsoft.Azure.Commands.Common.Authentication.Abstractions;
using Microsoft.Azure.Commands.ResourceManager.Common.Properties;

using System;
using System.Threading;
using System.Threading.Tasks;

namespace Microsoft.Azure.Commands.Synapse.Common
{
    public delegate void DebugLogWriter(string log);
    public class AzureSessionCredential : TokenCredential
    {
        public AzureSessionCredential(IAzureContext DefaultContext, DebugLogWriter logWriter = null)
        {
            if (DefaultContext == null || DefaultContext.Account == null)
            {
                throw new InvalidOperationException(Resources.ContextCannotBeNull);
            }
            if (logWriter != null)
            {
                this.debugLogWriter = logWriter;
            }

            IAccessToken accessToken1 = AzureSession.Instance.AuthenticationFactory.Authenticate(
               DefaultContext.Account,
               DefaultContext.Environment,
               DefaultContext.Tenant.Id,
               null,
               ShowDialog.Never,
               null,
               AzureEnvironment.ExtendedEndpoint.AzureSynapseAnalyticsEndpointResourceId);
            accessToken =  accessToken1;
        }

        public override AccessToken GetToken(TokenRequestContext requestContext, CancellationToken cancellationToken)
        {
            DateTimeOffset expiresOn;
            string token = string.Empty;
            accessToken.AuthorizeRequest((tokenType, tokenValue) =>
            {
                token = tokenValue;
                expiresOn = DateTimeOffset.UtcNow;
            });

            if (this.debugLogWriter != null)
            {
                this.debugLogWriter("[" + DateTime.Now.ToString() + "] GetToken: " + token);
            }
            return new AccessToken(token, expiresOn);
        }

        public override ValueTask<AccessToken> GetTokenAsync(TokenRequestContext requestContext, CancellationToken cancellationToken)
        {
            DateTimeOffset expiresOn;
            string token = string.Empty;
            accessToken.AuthorizeRequest((tokenType, tokenValue) =>
            {
                token = tokenValue;
                expiresOn = DateTimeOffset.UtcNow;
            });

            if (this.debugLogWriter != null)
            {
                this.debugLogWriter("[" + DateTime.Now.ToString() + "] GetTokenAsync: " + token);
            }
            return new ValueTask<AccessToken>(new AccessToken(token, expiresOn));
        }

        private IAccessToken accessToken;
        private DebugLogWriter debugLogWriter = null;
    }

}
