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
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Management.Automation;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Azure.Commands.AnalysisServices.Dataplane;
using Microsoft.Azure.Commands.AnalysisServices.Test.ScenarioTests;
using Microsoft.Azure.ServiceManagemenet.Common.Models;
using Microsoft.WindowsAzure.Commands.Common;
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using Moq;
using Xunit;
using Xunit.Abstractions;

namespace Microsoft.Azure.Commands.AnalysisServices.Test.InMemoryTests
{
    class AddAzureASAccountTests : AsTestsBase
    {
        private const string testAsAzureEnvironment = "westcentralus.asazure.windows.net";

        private const string testUser = "testuser";

        private const string testPassword = "testpassword";

        private AddAzureASAccountCommand cmdlet;

        private Mock<ICommandRuntime> commandRuntimeMock;

        public AddAzureASAccountTests(ITestOutputHelper output)
        {
            XunitTracingInterceptor.AddToContext(new XunitTracingInterceptor(output));
            commandRuntimeMock = new Mock<ICommandRuntime>();
            cmdlet = new AddAzureASAccountCommand()
            {
                CommandRuntime = commandRuntimeMock.Object
            };
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void CreatesNewPSResourceGroup()
        {
            // Setup
            cmdlet.RolloutEnvironment = testAsAzureEnvironment;
            var password = new SecureString();
            var testpwd = testPassword;
            testpwd.All(c => {
                password.AppendChar(c);
                return true;
                });
            cmdlet.Credential = new PSCredential(testUser, password);

            cmdlet.InvokeBeginProcessing();
            cmdlet.ExecuteCmdlet();
            cmdlet.InvokeEndProcessing();

            // Act
            Assert.NotEmpty(AsAzureClientSession.Instance.Profile.Environments);
            Assert.NotNull(AsAzureClientSession.Instance.Profile.Environments[testAsAzureEnvironment]);
            var environment = (AsAzureEnvironment)AsAzureClientSession.Instance.Profile.Environments[testAsAzureEnvironment];
            Assert.Equal(environment.Endpoints[AsAzureEnvironment.AsRolloutEndpoints.AdAuthorityBaseUrl], "");
            Assert.NotNull(environment.Endpoints[AsAzureEnvironment.AsRolloutEndpoints.RestartEndpointFormat]);
        }
    }
}
