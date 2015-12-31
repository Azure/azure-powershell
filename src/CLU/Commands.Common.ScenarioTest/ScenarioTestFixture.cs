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
    public class ScenarioTestFixture
    {
        protected EnvironmentContextFactory _contextFactory;
        public ScenarioTestFixture()
        {
            Generator = new Random();
            SessionId = $"{Generator.Next(10000, 99999)}";
            var credentials = new EnvironmentCredentialsProvider();
            credentials.Initialize("TestCredentials");
            _contextFactory = new EnvironmentContextFactory(credentials);
            var helper = GetRunner("lib");
            var profileText = helper.RunScript(credentials.LoginScriptName);
            var profile = JsonConvert.DeserializeObject<PSAzureProfile>(profileText);
            if (profile == null)
            {
                throw new ArgumentOutOfRangeException(nameof(profile), $"Deserialized profile is null: `{profileText}`");
            }
            AzureContext = (AzureContext) (profile.Context);
        }

        public string SessionId { get; protected set; }
        public Random Generator { get; protected set; }

        public ExampleScriptRunner GetRunner(string directoryName)
        {
            var context = _contextFactory.GetTestContext(directoryName);
            context.Context = AzureContext;
            return new ExampleScriptRunner(Generator, SessionId)
            {
                TestContext = context
            };
        }

        public AzureContext AzureContext { get; protected set;}
    }
}
