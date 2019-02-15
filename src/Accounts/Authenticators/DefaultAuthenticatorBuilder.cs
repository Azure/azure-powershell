// ----------------------------------------------------------------------------------
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

using System;
using Microsoft.Azure.Commands.Common.Authentication;
using Microsoft.Azure.Commands.Common.Authentication.Abstractions;

namespace Microsoft.Azure.PowerShell.Authenticators
{
    public class DefaultAuthenticatorBuilder : IAuthenticatorBuilder
    {
        public DefaultAuthenticatorBuilder()
        {
                AppendAuthenticator(() => { return new UsernamePasswordAuthenticator(); });
                AppendAuthenticator(() => { return new DeviceCodeAuthenticator(); });
                AppendAuthenticator(() => { return new ServicePrincipalAuthenticator(); });
                AppendAuthenticator(() => { return new SilentAuthenticator(); });
        }

        public IAuthenticator Authenticator { get; set; }

        public bool AppendAuthenticator(Func<IAuthenticator> constructor)
        {
            if (null == Authenticator)
            {
                Authenticator = constructor();
                return true;
            }

            IAuthenticator current;
            for (current = Authenticator; current != null && current.Next != null; current = current.Next) ;
            current.Next = constructor();
            return true;
        }
    }
}
