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

namespace Microsoft.Azure.Commands.Common.Compute.Tests
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using Microsoft.IdentityModel.Clients.ActiveDirectory;
    using Microsoft.Rest;

    class CredentialManager
    {
        protected CredentialManager() { }

        private const string ServicePrincipalEnvVariableName = "AZURE_SERVICE_PRINCIPAL";

        private static readonly string UserId = "UserId".ToLower();
        private static readonly string Password = "Password".ToLower();
        private static readonly string AadTenant = "AADTenant".ToLower();
        private static readonly string Subscription = "SubscriptionId".ToLower();
        private const string AuthUrl = "https://login.microsoftonline.com/";
        private const string BaseUrl = "https://management.azure.com/";

        public string ApplicationId { get; private set; }
        public string ApplicationSecret { get; private set; }
        public string TenantId { get; private set; }
        public string SubscriptionId { get; private set; }

        public TokenCredentials TokenCredentials
        {
            get
            {
                var clientCredential = new ClientCredential(ApplicationId, ApplicationSecret);
                var context = new AuthenticationContext(Path.Combine(AuthUrl, TenantId));
                var result = context.AcquireTokenAsync(BaseUrl, clientCredential);

                if (result == null) throw new InvalidOperationException("Failed to obtain the token");

                return new TokenCredentials(result.Result.AccessToken);
            }
        }

        public static CredentialManager FromServicePrincipalEnvVariable(string envVariableName = ServicePrincipalEnvVariableName)
        {
            //AZURE_SERVICE_PRINCIPAL = UserId =< UserGuid >; Password =< Password >; AADTenant =< TenantGuid >; SubscriptionId =< SubscriptionId >
            var spString = Environment.GetEnvironmentVariable(envVariableName);

            if (spString == null) throw new ArgumentNullException($"Failed to get environment variable {envVariableName}");

            var sp = new Dictionary<string, string>();
            var pairs = spString.Trim().Split(';');
            foreach (var pair in pairs)
            {
                var keyVal = pair.Trim().Split(new[] { '=' }, 2);
                if (keyVal.Length < 2) throw new ArgumentException($"Failed to parse {envVariableName}");
                sp.Add(keyVal[0].Trim().ToLower(), keyVal[1].Trim());
            }

            if (!sp.ContainsKey(UserId.ToLower())) throw new ArgumentException($"Failed to find {UserId} in {envVariableName}");
            if (!sp.ContainsKey(Password.ToLower())) throw new ArgumentException($"Failed to find {Password} in {envVariableName}");
            if (!sp.ContainsKey(AadTenant.ToLower())) throw new ArgumentException($"Failed to find {AadTenant} in {envVariableName}");
            if (!sp.ContainsKey(Subscription.ToLower())) throw new ArgumentException($"Failed to find {Subscription} in {envVariableName}");

            var credentialManager = new CredentialManager
            {
                ApplicationId = sp[UserId],
                ApplicationSecret = sp[Password],
                TenantId = sp[AadTenant],
                SubscriptionId = sp[Subscription]
            };

            return credentialManager;
        }
    }
}
