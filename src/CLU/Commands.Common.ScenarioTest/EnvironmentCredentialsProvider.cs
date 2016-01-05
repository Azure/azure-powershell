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

namespace Microsoft.Azure.Commands.Common.ScenarioTest
{
    public class EnvironmentCredentialsProvider : ICredentialsProvider
    {
        public const string userScript = "loginUser";
        public const string serviceScript = "loginService";

        public const string SecretVariable = "secret";
        public const string SpnVariable = "spn";
        public const string TenantVariable = "tenant";

        public const string UsernameVariable = "azureUser";
        public const string PasswordVariable = "password";
        public const string SubscriptionVariable = "subscription";

        public string LoginScriptName { get; protected set; }

        public virtual void Initialize()
        {
            if (!TryInitializeServiceCredentials() && !TryInitializeUserCredentials())
            {
                throw new InvalidOperationException($"Unable to create credentials. " +
                    "Please ensure your environment is correctly set up.");
            }
        }
        
        protected virtual bool TryInitializeServiceCredentials()
        {
            if (!string.IsNullOrWhiteSpace(Environment.GetEnvironmentVariable(SpnVariable)) &&
                !string.IsNullOrWhiteSpace(Environment.GetEnvironmentVariable(SecretVariable)) &&
                !string.IsNullOrWhiteSpace(Environment.GetEnvironmentVariable(TenantVariable)))
            {
                LoginScriptName = serviceScript;
                Logger.Instance.WriteMessage($"Logging in using ServicePrincipal: {Environment.GetEnvironmentVariable(SpnVariable)}");
                Logger.Instance.WriteMessage($"Logging in using Key: *********");
                Logger.Instance.WriteMessage($"Logging in using Tenant: {Environment.GetEnvironmentVariable(TenantVariable)}");
                if (!string.IsNullOrWhiteSpace(Environment.GetEnvironmentVariable(SubscriptionVariable)))
                {
                    Logger.Instance.WriteMessage($"Logging in using Subscription: {Environment.GetEnvironmentVariable(SubscriptionVariable)}");
                }
                return true;
            }
            return false;
        }

        protected virtual bool TryInitializeUserCredentials()
        {
            if (!string.IsNullOrWhiteSpace(Environment.GetEnvironmentVariable(UsernameVariable)) &&
                !string.IsNullOrWhiteSpace(Environment.GetEnvironmentVariable(PasswordVariable)))
            {
                LoginScriptName = userScript;
                Logger.Instance.WriteMessage($"Logging in using UserName: {Environment.GetEnvironmentVariable(UsernameVariable)}");
                Logger.Instance.WriteMessage($"Logging in using Password: *********");
                if (!string.IsNullOrWhiteSpace(Environment.GetEnvironmentVariable(SubscriptionVariable)))
                {
                    Logger.Instance.WriteMessage($"Logging in using Subscription: {Environment.GetEnvironmentVariable(SubscriptionVariable)}");
                }
                return true;
            }
            return false;
        }
    }
}
