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
    public class AuthenticationEnvironmentHelper : IScriptEnvironmentHelper
    {
        public const string UsernameVariable = "Username";
        public const string PasswordVariable = "Password";
        public bool TrySetupScriptEnvironment(ITestContext testContext, IClientFactory clientFactory, IDictionary<string, string> settings)
        {
            if (testContext == null)
            {
                throw new ArgumentNullException("testContext");
            }

            if (testContext.Context?.Account?.Type == AzureAccount.AccountType.User)
            {
                if (string.IsNullOrWhiteSpace(testContext.Username) || string.IsNullOrWhiteSpace(testContext.Password))
                {
                    throw new ArgumentOutOfRangeException("textContext",
                        "Username and Password must be provided for user accounts");
                }

                if (settings == null)
                {
                    throw new ArgumentNullException("settings");
                }

                settings[UsernameVariable] = testContext.Username;
                Logger.Instance.WriteMessage($"Setting process environment {UsernameVariable} = {testContext.Username}");
                settings[PasswordVariable] = testContext.Password;
                Logger.Instance.WriteMessage($"Setting process environment {PasswordVariable} = {testContext.Password}");
                return true;
            }

            return false;
        }
    }
}
