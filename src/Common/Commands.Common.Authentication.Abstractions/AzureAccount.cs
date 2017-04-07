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

using System;
using System.Collections.Generic;

namespace Microsoft.Azure.Commands.Common.Authentication.Abstractions
{
    public class AzureAccount : IAzureAccount
    {
        public string Id { get; set; }

        public string Credential { get; set; }

        public string Type { get; set; }

        public IDictionary<string, string> ExtendedProperties { get; } = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);

        public override bool Equals(object obj)
        {
            var anotherAccount = obj as AzureAccount;
            if (anotherAccount == null)
            {
                return false;
            }
            else
            {
                return string.Equals(anotherAccount.Id, Id, StringComparison.InvariantCultureIgnoreCase);
            }
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }

        public static class AccountType
        {
            public const string Certificate = "Certificate",
            User = "User",
            ServicePrincipal = "ServicePrincipal",
            AccessToken = "AccessToken";
        }

        public static class Property
        {
            public const string Subscriptions = "Subscriptions",

        /// <summary>
        /// Comma separated list of tenants on this account.
        /// </summary>
        Tenants = "Tenants",

        /// <summary>
        /// Access token.
        /// </summary>
        AccessToken = "AccessToken",

        /// <summary>
        /// Thumbprint for associated certificate
        /// </summary>
        CertificateThumbprint = "CertificateThumbprint";

        }
    }
}
