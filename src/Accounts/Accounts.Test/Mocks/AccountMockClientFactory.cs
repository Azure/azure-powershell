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
using Microsoft.Azure.Commands.TestFx.Mocks;
using Microsoft.Rest;
using Microsoft.WindowsAzure.Commands.Common.Test.Mocks;
using System.Collections.Generic;

namespace Microsoft.Azure.Commands.Profile.Test.Mocks
{
    class AccountMockClientFactory : MockClientFactory, IClientFactory
    {
        public delegate object NextClient();

        private NextClient nextClient;
        public AccountMockClientFactory(NextClient next, bool throwIfClientNotSpecified = true) : base(null, null)
        {
            nextClient = next;
        }

        public new TClient CreateCustomArmClient<TClient>(params object[] parameters) where TClient : ServiceClient<TClient>
        {
            TClient client = nextClient() as TClient;

            return client;
        }
    }
}
