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
using Azure.Identity;

using Microsoft.Azure.Commands.Common.Authentication.Abstractions;

using System;
using System.Threading;
using System.Threading.Tasks;

namespace Microsoft.Azure.Commands.Common.Authentication
{
    /// <summary>
    /// Class implementing a chain of responsibility pattern for authenticators
    /// </summary>
    public abstract class DelegatingAuthenticator : IAuthenticator
    {
        protected const string AdfsTenant = "adfs";
        protected const string OrganizationsTenant = "organizations";

        protected CancellationToken AuthenticationCancellationToken
        {
            get
            {
                // todo: move "LoginCancellationToken" to common repo as a const
                if (AzureSession.Instance.TryGetComponent("LoginCancellationToken", out CancellationTokenSource cancellationTokenSource))
                {
                    return cancellationTokenSource.Token;
                }
                return new CancellationTokenSource().Token;
            }
        }

        public IAuthenticator Next { get; set; }
        public abstract bool CanAuthenticate(AuthenticationParameters parameters);
        public abstract Task<IAccessToken> Authenticate(AuthenticationParameters parameters, CancellationToken cancellationToken);

        public Task<IAccessToken> Authenticate(AuthenticationParameters parameters)
        {
            return Authenticate(parameters, AuthenticationCancellationToken);
        }

        public bool TryAuthenticate(AuthenticationParameters parameters, out Task<IAccessToken> token)
        {
            return TryAuthenticate(parameters, AuthenticationCancellationToken, out token);
        }

        public bool TryAuthenticate(AuthenticationParameters parameters, CancellationToken cancellationToken, out Task<IAccessToken> token)
        {
            token = null;
            if (CanAuthenticate(parameters))
            {
                token = Authenticate(parameters, cancellationToken);
                return true;
            }

            if (Next != null)
            {
                var retToken = Next.TryAuthenticate(parameters, cancellationToken, out token);
                telemetry = Next.GetDataForTelemetry();
                return retToken;
            }

            return false;
        }

        protected AuthTelemetryRecord telemetry = new AuthTelemetryRecord();

        public AuthTelemetryRecord GetDataForTelemetry()
        {
            return telemetry;
        }

        protected virtual void CollectTelemetry(TokenCredential credential, TokenCredentialOptions options = null)
        {
            telemetry.TokenCredentialName = credential?.GetType()?.Name;
            if (options != null)
            {
                telemetry.SetProperty(AuthTelemetryRecord.TokenCacheEnabled, CheckTokenCachePersistanceEnabled().ToString());
            }
        }

        protected Func<bool> CheckTokenCachePersistanceEnabled = () => { return false; };
    }
}
