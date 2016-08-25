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

namespace Microsoft.Azure.Commands.LogicApp.Test.UnitTests
{
    using Microsoft.Azure.Commands.LogicApp.Cmdlets;
    using Microsoft.WindowsAzure.Commands.ScenarioTest;
    using ServiceManagemenet.Common.Models;
    using System.Management.Automation;
    using Xunit;
    using Xunit.Abstractions;
    /// <summary>
    /// Unit test for the Create Logic app command.
    /// </summary>
    public class CreateLogicAppTests : LogicAppUnitTestBase
    {
        public CreateLogicAppTests(ITestOutputHelper output)
        {
            XunitTracingInterceptor.AddToContext(new XunitTracingInterceptor(output));
        }

        /// <summary>
        /// This verifies the exception thrown by the commandlet when non-existing definition file is provided as input
        /// </summary>
        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void NewAzureLogicApp_ThrowsExceptionWithNonexistingDefinitionFile()
        {
            var cmdlet = new NewAzureLogicAppCommand
            {
                Name = Name,
                DefinitionFilePath = DefinitionFilePath,
                ResourceGroupName = ResourceGroupName
            };

            var exception = Assert.Throws<PSArgumentException>(() => cmdlet.ExecuteCmdlet());
            Assert.Equal("File LogicAppDefinition.json does not exist.", exception.Message);
        }

        /// <summary>
        /// This verifies the exception thrown by the commandlet when non-existing parameter file is provided as input
        /// </summary>
        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void NewAzureLogicApp_ThrowsExceptionWithNonexistingParameterFile()
        {
            var cmdlet = new NewAzureLogicAppCommand
            {
                Name = Name,
                ParameterFilePath = ParameterFilePath,
                ResourceGroupName = ResourceGroupName
            };
            var exception = Assert.Throws<PSArgumentException>(() => cmdlet.ExecuteCmdlet());
            Assert.Equal("File LogicAppParameter.json does not exist.", exception.Message);
        }
    }
}
