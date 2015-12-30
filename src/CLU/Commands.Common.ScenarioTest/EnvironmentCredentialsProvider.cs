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
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Azure.Commands.Common.ScenarioTest;

namespace Microsoft.Azure.Commands.Common.ScenarioTest
{
    public class EnvironmentCredentialsProvider : ICredentialsProvider
    {
        public const string userScript = "loginUser";
        public const string serviceScript = "loginService";

        public IScriptEnvironmentHelper EnvironmentProvider { get; protected set; }

        public string LoginScriptName { get; protected set; }

        public virtual void Initialize(string key)
        {
            IDictionary<string, string> settings = GetSettings(key);
            if (!TryInitializeServiceCredentials(settings) && !TryInitializeUserCredentials(settings))
            {
                throw new InvalidOperationException($"Unable to create credentials using key {key}. " +
                    "Please ensure your environment is correctly set up.");
            }
        }

        protected virtual IDictionary<string, string> GetSettings(string key)
        {
            var environmentValue = Environment.GetEnvironmentVariable(key);
            if (string.IsNullOrWhiteSpace(environmentValue))
            {
                throw new InvalidOperationException($"Unable to create credentials. Please set environment variable `{key}`");
            }
            IDictionary<string, string> settings = new Dictionary<string, string>();
            foreach (
                var setting in
                    environmentValue.Split(new string[] {$"{Path.PathSeparator}"}, 
                    StringSplitOptions.RemoveEmptyEntries)
                )
            {
                string[] pair = setting.Split(new char[] { '='}, 2, StringSplitOptions.RemoveEmptyEntries);
                var pairKey = pair[0].Trim();
                var pairValue = pair[1].Trim();
                settings[pairKey] = pairValue;
            }

            return settings;
        }

        protected virtual bool TryInitializeServiceCredentials(IDictionary<string, string> settings )
        {
            if (settings.ContainsKey(EnvironmentConstants.ServicePrincipalKey) &&
                settings.ContainsKey(EnvironmentConstants.PasswordKey) &&
                settings.ContainsKey(EnvironmentConstants.TenantKey))
            {
                LoginScriptName = serviceScript;
                EnvironmentProvider = new ServiceAuthenticationHelper(
                    settings[EnvironmentConstants.ServicePrincipalKey], 
                    settings[EnvironmentConstants.PasswordKey],
                    settings[EnvironmentConstants.TenantKey],
                    settings.ContainsKey(EnvironmentConstants.SubscriptionKey) ? settings[EnvironmentConstants.SubscriptionKey] : null);
                return true;
            }
            return false;
        }

        protected virtual bool TryInitializeUserCredentials(IDictionary<string, string> settings )
        {
            if (settings.ContainsKey(EnvironmentConstants.UsernameKey) &&
                settings.ContainsKey(EnvironmentConstants.PasswordKey))
            {
                LoginScriptName = userScript;
                EnvironmentProvider = new UserAuthenticationHelper(
                    settings[EnvironmentConstants.UsernameKey],
                    settings[EnvironmentConstants.PasswordKey],
                    settings.ContainsKey(EnvironmentConstants.SubscriptionKey) ? settings[EnvironmentConstants.SubscriptionKey] : null);
                return true;
            }
            return false;
        }
    }
}
