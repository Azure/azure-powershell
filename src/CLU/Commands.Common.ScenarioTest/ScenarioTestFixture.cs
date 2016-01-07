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
using Microsoft.Azure.Commands.Common.Authentication.Models;
using Microsoft.Azure.Commands.Common.ScenarioTest;
using Microsoft.Azure.Commands.Models;
using Newtonsoft.Json;

namespace Microsoft.Azure.Commands.Common.ScenarioTest
{
    internal enum ContextType
    {
        None,
        Auto,
        User,
        ServicePrincipal
    }

    public class ScenarioTestFixture
    {
        public AzureContext AzureContext { get; protected set; }

        public ScenarioTestFixture()
        {
            Generator = new Random();
            SessionId = $"{Generator.Next(10000, 99999)}";
        }

        public string SessionId { get; protected set; }
        public Random Generator { get; protected set; }

        public ScenarioTestFixture LoginAsUser()
        {
            var newTestFixture = new ScenarioTestFixture();
            newTestFixture.Login(EnvironmentCredentialsProvider.LoginUserScript);
            return newTestFixture;
        }

        public ScenarioTestFixture LoginAsService()
        {
            var newTestFixture = new ScenarioTestFixture();
            newTestFixture.Login(EnvironmentCredentialsProvider.LoginServiceScript);
            return newTestFixture;
        }

        private void Login(string loginScript)
        {
            var helper = new ExampleScriptRunner(Generator, SessionId)
            {
                TestContext = EnvironmentContextFactory.GetTestContext("lib")
            };
            var profileText = helper.RunScript(loginScript);
            var profile = JsonConvert.DeserializeObject<PSAzureProfile>(profileText);
            if (profile == null)
            {
                throw new ArgumentOutOfRangeException(nameof(profile), $"Deserialized profile is null: `{profileText}`");
            }
            AzureContext = profile.Context;
        }

        public ExampleScriptRunner GetRunner(string directoryName)
        {
            if (AzureContext == null)
            {
                var credentials = new EnvironmentCredentialsProvider();
                credentials.Initialize();
                Login(credentials.LoginScriptName);
            }
            var context = EnvironmentContextFactory.GetTestContext(directoryName);
            context.Context = AzureContext;
            var scriptRunner = new ExampleScriptRunner(Generator, SessionId)
            {
                TestContext = context
            };
            if (context.Context != null && context.Context.Subscription != null)
            {
                scriptRunner.EnvironmentVariables[EnvironmentCredentialsProvider.SubscriptionVariable] = 
                    context.Context.Subscription.Id.ToString();
            }
            return scriptRunner;
        }
    }
}
