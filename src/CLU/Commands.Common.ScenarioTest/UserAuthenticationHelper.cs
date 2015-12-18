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
using Microsoft.Azure.Commands.Common.Authentication;
using Microsoft.Azure.Commands.Common.ScenarioTest;

namespace Microsoft.Azure.Commands.Common.ScenarioTest
{
    public class UserAuthenticationHelper : IScriptEnvironmentHelper
    {
        public const string UsernameVariable = "azureUser";
        public const string PasswordVariable = "password";
        public const string SubscriptionVariable = "subscription";
        string _username;
        string _password;
        string _subscription;

        public UserAuthenticationHelper(string username, string password)
            : this(username, password, null)
        {
        }

        public UserAuthenticationHelper(string username, string password, string subscription)
        {
            _username = username;
            _password = password;
            _subscription = subscription;
        }

        public bool TrySetupScriptEnvironment(TestContext testContext, IClientFactory clientFactory, IDictionary<string, string> settings)
        {
            if (string.IsNullOrWhiteSpace(_username) || string.IsNullOrWhiteSpace(_password))
            {
                throw new ArgumentOutOfRangeException("textContext",
                    "Username and Password must be provided for user accounts");
            }

            if (settings == null)
            {
                throw new ArgumentNullException("settings");
            }

            settings[UsernameVariable] = _username;
            Logger.Instance.WriteMessage($"Setting process environment {UsernameVariable} = {_username}");
            settings[PasswordVariable] = _password;
            Logger.Instance.WriteMessage($"Setting process environment {PasswordVariable} = ***********");
            if (!string.IsNullOrWhiteSpace(_subscription))
            {
                Logger.Instance.WriteMessage($"Logging in using Subscription: {_subscription}");
                settings[SubscriptionVariable] = _subscription;
            }
            return true;

        }
    }
}
