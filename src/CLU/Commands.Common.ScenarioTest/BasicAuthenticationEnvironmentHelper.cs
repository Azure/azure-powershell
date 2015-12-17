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
using Microsoft.Azure.Commands.Common.Authentication.Models;
using Microsoft.Azure.Commands.Examples.Test;

namespace Microsoft.Azure.Commands.ScenarioTest
{
    public class BasicAuthenticationEnvironmentHelper : IScriptEnvironmentHelper
    {
        public const string UsernameVariable = "azureUser";
        public const string PasswordVariable = "password";
        string _username;
        string _password;

        public BasicAuthenticationEnvironmentHelper(string username, string password)
        {
            _username = username;
            _password = password;
        }

        public bool TrySetupScriptEnvironment(ITestContext testContext, IClientFactory clientFactory, IDictionary<string, string> settings)
        {
            if (testContext == null)
            {
                throw new ArgumentNullException("testContext");
            }

            if (testContext.Context?.Account?.Type == AzureAccount.AccountType.User)
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
                Logger.Instance.WriteMessage($"Setting process environment {PasswordVariable} = {_password}");
                return true;
            }

            return false;
        }
    }
}
