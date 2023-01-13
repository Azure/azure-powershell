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
using System;
using System.Security;

namespace Microsoft.Azure.Commands.TestFx.Mocks
{
    public class MockAccessTokenProvider : ITokenProvider
    {
        private readonly IAccessToken _accessToken;

        public MockAccessTokenProvider(string token) : this(token, "MockUser")
        {

        }

        public MockAccessTokenProvider(string token, string userId)
        {
            _accessToken = new MockAccessToken
            {
                AccessToken = token,
                LoginType = LoginType.OrgId,
                UserId = userId
            };
        }

        public IAccessToken GetAccessToken(
            AdalConfiguration config,
            string promptBehavior,
            Action<string> promptAction,
            string userId,
            SecureString password,
            string credentialType)
        {
            return _accessToken;
        }

#if !NETSTANDARD
        IAccessToken ITokenProvider.GetAccessTokenWithCertificate(
            AdalConfiguration config,
            string principalId,
            string certificateThumbprint,
            string credentialType)
        {
            return GetAccessTokenWithCertificate(config, principalId, certificateThumbprint, credentialType);
        }
#endif

        public IAccessToken GetAccessTokenWithCertificate(
            AdalConfiguration config,
            string principalId,
            string certificateThumbprint,
            string credentialType)
        {
            return _accessToken;
        }

    }
}