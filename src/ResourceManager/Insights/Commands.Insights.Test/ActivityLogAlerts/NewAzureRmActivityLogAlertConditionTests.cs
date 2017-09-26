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
using Microsoft.Azure.Commands.Insights.ActivityLogAlert;

namespace Microsoft.Azure.Commands.Insights.Test.ActivityLogAlerts
{
    public class NewAzureRmActivityLogAlertConditionTests
    {
        private Mock<ICommandRuntime> commandRuntimeMock;

        public NewAzureRmActivityLogAlertConditionCommand Cmdlet { get; set; }

        public NewAzureRmActivityLogAlertConditionTests(Xunit.Abstractions.ITestOutputHelper output)
        {
            ServiceManagemenet.Common.Models.XunitTracingInterceptor.AddToContext(new ServiceManagemenet.Common.Models.XunitTracingInterceptor(output));
            commandRuntimeMock = new Mock<ICommandRuntime>();
            Cmdlet = new NewAzureRmActivityLogAlertConditionCommand()
            {
                CommandRuntime = commandRuntimeMock.Object
            };
        }

        [Fact(Skip = "This is not testing anything")]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void NewAzureRmActivityLogAlertConditionCommandParametersProcessing()
        {
            Cmdlet.Field = "field1";
            Cmdlet.Equal = "equals1";
            Cmdlet.ExecuteCmdlet();
        }
    }
}
