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

using System.Collections.Generic;
using System.Globalization;
using System.Threading;
using FluentAssertions;
using Microsoft.Azure.Commands.Common.Authentication;
using Microsoft.Azure.Commands.Common.Exceptions;
using Microsoft.Azure.Commands.ResourceManager.Cmdlets.Utilities;
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using Moq;
using Xunit;

namespace Microsoft.Azure.Commands.Resources.Test.UnitTests.Utilities
{
    public class BicepUtilityTests
    {
        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestIsBicepFile()
        {
            Assert.True(BicepUtility.IsBicepFile("test.bicep"));
            Assert.False(BicepUtility.IsBicepFile("test.json"));
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestIsBicepparamFile()
        {
            Assert.True(BicepUtility.IsBicepparamFile("test.bicepparam"));
            Assert.False(BicepUtility.IsBicepparamFile("test.json"));
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void BuildParams_returns_valid_parameter_output()
        {
            var invokerMock = new Mock<IProcessInvoker>();
            invokerMock.Setup(x => x.Invoke(It.Is<ProcessInput>(p => p.Arguments == "-v")))
                .Returns(new ProcessOutput { ExitCode = 0, Stderr = "", Stdout = "Bicep CLI version 0.22.6 (d62b94db31)" });
            invokerMock.Setup(x => x.Invoke(It.Is<ProcessInput>(p => p.Arguments == "build-params \"foo.bicepparam\" --stdout")))
                .Returns(new ProcessOutput { ExitCode = 0, Stderr = "", Stdout = "{\"parametersJson\":\"{\\n  \\\"$schema\\\": \\\"https://schema.management.azure.com/schemas/2019-04-01/deploymentParameters.json#\\\",\\n  \\\"contentVersion\\\": \\\"1.0.0.0\\\",\\n  \\\"parameters\\\": {\\n    \\\"tag1\\\": {\\n      \\\"value\\\": \\\"日本語テスト_param\\\"\\n    }\\n  }\\n}\",\"templateJson\":\"{\\n  \\\"$schema\\\": \\\"https://schema.management.azure.com/schemas/2018-05-01/subscriptionDeploymentTemplate.json#\\\",\\n  \\\"contentVersion\\\": \\\"1.0.0.0\\\",\\n  \\\"metadata\\\": {\\n    \\\"_generator\\\": {\\n      \\\"name\\\": \\\"bicep\\\",\\n      \\\"version\\\": \\\"0.22.6.54827\\\",\\n      \\\"templateHash\\\": \\\"6645562165406558166\\\"\\n    }\\n  },\\n  \\\"parameters\\\": {\\n    \\\"tag1\\\": {\\n      \\\"type\\\": \\\"string\\\"\\n    }\\n  },\\n  \\\"variables\\\": {\\n    \\\"tag2\\\": \\\"日本語テスト_var\\\"\\n  },\\n  \\\"resources\\\": [\\n    {\\n      \\\"type\\\": \\\"Microsoft.Resources/resourceGroups\\\",\\n      \\\"apiVersion\\\": \\\"2022-09-01\\\",\\n      \\\"name\\\": \\\"rg-bicepparam-test\\\",\\n      \\\"location\\\": \\\"japaneast\\\",\\n      \\\"tags\\\": {\\n        \\\"tagName1\\\": \\\"[parameters('tag1')]\\\",\\n        \\\"tagName2\\\": \\\"[variables('tag2')]\\\",\\n        \\\"tagName3\\\": \\\"日本語テスト_literal\\\"\\n      },\\n      \\\"properties\\\": {}\\n    }\\n  ]\\n}\",\"templateSpecId\":null}" });
            invokerMock.Setup(x => x.CheckExecutableExists("bicep"))
                .Returns(true);

            var dataStoreMock = new Mock<IDataStore>();
            dataStoreMock.Setup(x => x.FileExists("foo.bicepparam"))
                .Returns(true);

            var bicepUtility = new BicepUtility(invokerMock.Object, dataStoreMock.Object);

            var output = bicepUtility.BuildParams("foo.bicepparam", new Dictionary<string, object>());
            var parameters = TemplateUtility.ParseTemplateParameterJson(output.parametersJson);

            parameters["tag1"].Value.Should().Be("日本語テスト_param");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void BuildParams_fails_for_non_zero_exit_code()
        {
            var invokerMock = new Mock<IProcessInvoker>();
            invokerMock.Setup(x => x.Invoke(It.Is<ProcessInput>(p => p.Arguments == "-v")))
                .Returns(new ProcessOutput { ExitCode = 0, Stderr = "", Stdout = "Bicep CLI version 0.22.6 (d62b94db31)" });
            invokerMock.Setup(x => x.Invoke(It.Is<ProcessInput>(p => p.Arguments == "build-params \"foo.bicepparam\" --stdout")))
                .Returns(new ProcessOutput { ExitCode = 1, Stderr = "Oops something went wrong!", Stdout = "" });
            invokerMock.Setup(x => x.CheckExecutableExists("bicep"))
                .Returns(true);

            var dataStoreMock = new Mock<IDataStore>();
            dataStoreMock.Setup(x => x.FileExists("foo.bicepparam"))
                .Returns(true);

            var bicepUtility = new BicepUtility(invokerMock.Object, dataStoreMock.Object);

            FluentActions.Invoking(() => bicepUtility.BuildParams("foo.bicepparam", new Dictionary<string, object>()))
                .Should().Throw<AzPSApplicationException>().WithMessage("Oops something went wrong!");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void BuildParams_fails_for_old_bicep_version()
        {
            var invokerMock = new Mock<IProcessInvoker>();
            invokerMock.Setup(x => x.Invoke(It.Is<ProcessInput>(p => p.Arguments == "-v")))
                .Returns(new ProcessOutput { ExitCode = 0, Stderr = "", Stdout = "Bicep CLI version 0.15.1 (d62b94db31)" });
            invokerMock.Setup(x => x.CheckExecutableExists("bicep"))
                .Returns(true);

            var dataStoreMock = new Mock<IDataStore>();
            dataStoreMock.Setup(x => x.FileExists("foo.bicepparam"))
                .Returns(true);

            var bicepUtility = new BicepUtility(invokerMock.Object, dataStoreMock.Object);

            FluentActions.Invoking(() => bicepUtility.BuildParams("foo.bicepparam", new Dictionary<string, object>()))
                .Should().Throw<AzPSApplicationException>().WithMessage("Please use bicep '0.16.1' or higher verison.");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void BuildParams_fails_for_missing_bicep()
        {
            var invokerMock = new Mock<IProcessInvoker>();
            invokerMock.Setup(x => x.CheckExecutableExists("bicep"))
                .Returns(false);

            var dataStoreMock = new Mock<IDataStore>();
            dataStoreMock.Setup(x => x.FileExists("foo.bicepparam"))
                .Returns(true);

            var bicepUtility = new BicepUtility(invokerMock.Object, dataStoreMock.Object);

            FluentActions.Invoking(() => bicepUtility.BuildParams("foo.bicepparam", new Dictionary<string, object>()))
                .Should().Throw<AzPSApplicationException>().WithMessage("Cannot find Bicep. Please add Bicep to your PATH or visit *");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void BuildParams_fails_for_missing_param_file()
        {
            var invokerMock = new Mock<IProcessInvoker>();
            var dataStoreMock = new Mock<IDataStore>();
            dataStoreMock.Setup(x => x.FileExists("foo.bicepparam"))
                .Returns(false);

            var bicepUtility = new BicepUtility(invokerMock.Object, dataStoreMock.Object);

            FluentActions.Invoking(() => bicepUtility.BuildParams("foo.bicepparam", new Dictionary<string, object>()))
                .Should().Throw<AzPSArgumentException>().WithMessage("Invalid Bicepparam file path.");
        }
    }
}
