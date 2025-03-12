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
using System;
using System.Threading.Tasks;
using System.Threading;

namespace Microsoft.Azure.Commands.CodeSigning.Models
{
    internal class UserSuppliedCredential : TokenCredential
    {
        private readonly CodeSigningServiceCredential codeSigningServiceCredential;

        public UserSuppliedCredential(CodeSigningServiceCredential codeSigningServiceCredential)
        {
            this.codeSigningServiceCredential = codeSigningServiceCredential;
        }

        public override AccessToken GetToken(TokenRequestContext requestContext, CancellationToken cancellationToken)
        {
            return new AccessToken(codeSigningServiceCredential.GetToken(), DateTimeOffset.UtcNow);
        }

        public override ValueTask<AccessToken> GetTokenAsync(TokenRequestContext requestContext, CancellationToken cancellationToken)
        {
            return new ValueTask<AccessToken>(this.GetToken(requestContext, cancellationToken));
        }
    }
}
