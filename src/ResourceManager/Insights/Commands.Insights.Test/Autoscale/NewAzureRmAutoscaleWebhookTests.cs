﻿// ----------------------------------------------------------------------------------
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

using Microsoft.Azure.Commands.Insights.Autoscale;
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using Moq;
using System;
using System.Collections;
using System.Management.Automation;
using Xunit;

namespace Microsoft.Azure.Commands.Insights.Test.Autoscale
{
    public class NewAzureRmAutoscaleWebhookTests
    {
        private Mock<ICommandRuntime> commandRuntimeMock;

        public NewAzureRmAutoscaleWebhookCommand Cmdlet { get; set; }

        public NewAzureRmAutoscaleWebhookTests(Xunit.Abstractions.ITestOutputHelper output)
        {
            ServiceManagement.Common.Models.XunitTracingInterceptor.AddToContext(new ServiceManagement.Common.Models.XunitTracingInterceptor(output));
            commandRuntimeMock = new Mock<ICommandRuntime>();
            Cmdlet = new NewAzureRmAutoscaleWebhookCommand()
            {
                CommandRuntime = commandRuntimeMock.Object
            };
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void NewAzureRmAutoscaleWebhookCommandParametersProcessing()
        {
            Assert.Throws<ArgumentException>(() => Cmdlet.ExecuteCmdlet());

            Cmdlet.ServiceUri = "http://hook.com/webhook";
            Cmdlet.ExecuteCmdlet();

            Cmdlet.Property = new Hashtable();
            Cmdlet.ExecuteCmdlet();

            Cmdlet.Property.Add("prop1", "value1");
            Cmdlet.ExecuteCmdlet();
        }
    }
}
