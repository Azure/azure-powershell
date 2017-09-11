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

using Microsoft.WindowsAzure.Commands.ScenarioTest;
using Moq;
using System.Management.Automation;
using Xunit;
using Microsoft.Azure.Commands.Insights.ActionGroups;

namespace Microsoft.Azure.Commands.Insights.Test.ActionGroups
{
    using Microsoft.Azure.Management.Monitor.Management.Models;

    public class NewAzureRmActionGroupReceiverTests
    {
        private Mock<ICommandRuntime> commandRuntimeMock;

        public NewAzureRmActionGroupReceiverCommand Cmdlet { get; set; }

        public NewAzureRmActionGroupReceiverTests(Xunit.Abstractions.ITestOutputHelper output)
        {
            commandRuntimeMock = new Mock<ICommandRuntime>();
            Cmdlet = new NewAzureRmActionGroupReceiverCommand()
            {
                CommandRuntime = commandRuntimeMock.Object
            };
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void NewAzureRmReceiverCommandEmailParametersProcessing()
        {
            Cmdlet.Type = "email";
            Cmdlet.Name = "email1";
            Cmdlet.EmailAddress = "foo@email.com";
            Cmdlet.ExecuteCmdlet();
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void NewAzureRmReceiverCommandSmsParametersProcessing()
        {
            Cmdlet.Type = "sms";
            Cmdlet.Name = "sms1";
            Cmdlet.CountryCode = "1";
            Cmdlet.PhoneNumber = "4254251234";
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void NewAzureRmReceiverCommandWebhookParametersProcessing()
        {
            Cmdlet.Type = "webhook";
            Cmdlet.Name = "webhook1";
            Cmdlet.ServiceUri = "http://test.com";
            Cmdlet.ExecuteCmdlet();
        }
    }
}