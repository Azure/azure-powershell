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

using Microsoft.Azure.Commands.Insights.Alerts;
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using Moq;
using System;
using System.Management.Automation;
using Xunit;

namespace Microsoft.Azure.Commands.Insights.Test.Alerts
{
    public class NewAzureRmAlertRuleEmailTests
    {
        private Mock<ICommandRuntime> commandRuntimeMock;

        public NewAzureRmAlertRuleEmailCommand Cmdlet { get; set; }

        public NewAzureRmAlertRuleEmailTests(Xunit.Abstractions.ITestOutputHelper output)
        {
            ServiceManagemenet.Common.Models.XunitTracingInterceptor.AddToContext(new ServiceManagemenet.Common.Models.XunitTracingInterceptor(output));
            commandRuntimeMock = new Mock<ICommandRuntime>();
            Cmdlet = new NewAzureRmAlertRuleEmailCommand()
            {
                CommandRuntime = commandRuntimeMock.Object
            };
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void NewAzureRmAlertRuleEmailCommandParametersProcessing()
        {
            Cmdlet.SendToServiceOwners = true;
            Cmdlet.ExecuteCmdlet();

            Cmdlet.CustomEmails = new string[0];
            Cmdlet.ExecuteCmdlet();

            Cmdlet.CustomEmails = new string[] { "gu@macrosoft.com" };
            Cmdlet.ExecuteCmdlet();

            Cmdlet.CustomEmails = new string[] { "gu@macrosoft.com", "hu@megasoft.com" };
            Cmdlet.ExecuteCmdlet();

            Cmdlet.SendToServiceOwners = false;
            Cmdlet.ExecuteCmdlet();

            Cmdlet.CustomEmails = new string[] { "gu@macrosoft.com" };
            Cmdlet.ExecuteCmdlet();

            Cmdlet.CustomEmails = new string[0];
            Assert.Throws<ArgumentException>(() => Cmdlet.ExecuteCmdlet());

            Cmdlet.CustomEmails = null;
            Assert.Throws<ArgumentException>(() => Cmdlet.ExecuteCmdlet());
        }
    }
}

