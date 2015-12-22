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

using System.Collections.Generic;
using Microsoft.Azure.Commands.Common.Authentication;
using Microsoft.Azure.Commands.Common.ScenarioTest;

namespace Microsoft.Azure.Commands.Common.ScenarioTest
{
    /// <summary>
    /// Add the given SPN credentials to the environment for the login script
    /// </summary>
    public class ServiceAuthenticationHelper : IScriptEnvironmentHelper
    {    
        string _spn;
        string _secret;
        string _tenant;
        string _subscription;
        const string SecretKey = "secret";
        const string SPNKey = "spn";
        const string TenantKey = "tenant";
        const string SubscriptionKey = "subscription";
        public ServiceAuthenticationHelper(string spn, string secret, string tenant)
            : this(spn, secret, tenant, null)
        {
        }

        public ServiceAuthenticationHelper(string spn, string secret, string tenant, string subscription)
        {
            _spn = spn;
            _secret = secret;
            _tenant = tenant;
            _subscription = subscription;
        }

        public bool TrySetupScriptEnvironment(TestContext testContext, IClientFactory clientFactory, IDictionary<string, string> settings)
        {
            Logger.Instance.WriteMessage($"Logging in using ServicePrincipal: {_spn}");
            settings[SPNKey] = _spn;
            settings[SecretKey] = _secret;
            Logger.Instance.WriteMessage($"Logging in using Tenant: {_tenant}");
            settings[TenantKey] = _tenant;
            if (!string.IsNullOrWhiteSpace(_subscription))
            {
                Logger.Instance.WriteMessage($"Logging in using Subscription: {_subscription}");
                settings[SubscriptionKey] = _subscription;
            }

            return true;
        }
    }
}
