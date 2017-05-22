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

using Microsoft.Azure.Commands.Common.Authentication;
using Microsoft.Azure.Commands.Common.Authentication.Abstractions;
using Microsoft.Azure.Commands.Common.Authentication.Models;
using Microsoft.Azure.Commands.Profile.Models;
using Microsoft.Azure.Commands.ScenarioTest;
using Microsoft.Azure.ServiceManagemenet.Common.Models;
using Microsoft.WindowsAzure.Commands.Common;
using Microsoft.WindowsAzure.Commands.Common.Test.Mocks;
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using System;
using Xunit;
using Xunit.Abstractions;

namespace Microsoft.Azure.Commands.Profile.Test
{
    public class SendFeedbackTests
    {
        private MemoryDataStore dataStore;
        private MockCommandRuntime commandRuntimeMock;

        public SendFeedbackTests(ITestOutputHelper output)
        {
            TestExecutionHelpers.SetUpSessionAndProfile();
            XunitTracingInterceptor.AddToContext(new XunitTracingInterceptor(output));
            dataStore = new MemoryDataStore();
            AzureSession.Instance.DataStore = dataStore;
            commandRuntimeMock = new MockCommandRuntime();
            AzureRmProfileProvider.Instance.Profile = new AzureRmProfile();
        }

        [Fact]
        [Trait(Category.RunType, Category.LiveOnly)]
        public void SendFeedbackFailsInNonInteractive()
        {
            var cmdlet = new SendFeedbackCommand();

            // Setup
            cmdlet.CommandRuntime = commandRuntimeMock;

            // Act
            Assert.ThrowsAny<Exception>(() =>
            {
                cmdlet.InvokeBeginProcessing();
            });
        }
#if !NETSTANDARD
        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void CanSerializeSimpleFeedbackPayloadIntoProperForm()
        {
            var payload = new PSAzureFeedback
            {
                ModuleName = "Module",
                ModuleVersion = "1.0.0",
                SubscriptionId = Guid.NewGuid().ToString(),
                TenantId = Guid.NewGuid().ToString(),
                Environment = "AzureCloud",
                Recommendation = 10,
                PositiveComments = "Positive",
                NegativeComments = "Negative",
                Email = "m@e.com"
            };

            var serializedPayload = MetricHelper.SerializeCustomEventPayload(payload);

            Assert.Equal(payload.ModuleName, serializedPayload["moduleName"]);
            Assert.Equal(payload.ModuleVersion, serializedPayload["moduleVersion"]);
            Assert.Equal(payload.SubscriptionId.ToString(), serializedPayload["subscriptionId"]);
            Assert.Equal(payload.TenantId.ToString(), serializedPayload["tenantId"]);
            Assert.Equal(payload.Environment, serializedPayload["environment"]);
            Assert.Equal(payload.Recommendation.ToString(), serializedPayload["recommendation"]);
            Assert.Equal(payload.PositiveComments, serializedPayload["positiveComments"]);
            Assert.Equal(payload.NegativeComments, serializedPayload["negativeComments"]);
            Assert.Equal(payload.Email, serializedPayload["email"]);
        }
#endif
    }
}
