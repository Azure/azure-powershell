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
//
using Microsoft.Identity.Client;

namespace Microsoft.Azure.PowerShell.Authenticators.Identity
{
    internal class AuthenticationAccount : IAccount
    {
        private AuthenticationRecord _profile;

        internal AuthenticationAccount(AuthenticationRecord profile)
        {
            _profile = profile;
        }

        string IAccount.Username => _profile.Username;

        string IAccount.Environment => _profile.Authority;

        AccountId IAccount.HomeAccountId => _profile.AccountId;

        public static explicit operator AuthenticationAccount(AuthenticationRecord profile) => new AuthenticationAccount(profile);
        public static explicit operator AuthenticationRecord(AuthenticationAccount account) => account._profile;
    }
}
