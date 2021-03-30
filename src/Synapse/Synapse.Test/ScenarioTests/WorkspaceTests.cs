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

namespace Microsoft.Azure.Commands.Synapse.Test.ScenarioTests
{
    using Microsoft.WindowsAzure.Commands.ScenarioTest;
    using ServiceManagement.Common.Models;
    using Xunit;

    public class WorkspaceTests : SynapseTestBase
    {
        public XunitTracingInterceptor _logger;

        public WorkspaceTests(Xunit.Abstractions.ITestOutputHelper output)
        {
            _logger = new XunitTracingInterceptor(output);
            XunitTracingInterceptor.AddToContext(_logger);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestSynapseWorkspace()
        {
            SynapseTestBase.NewInstance.RunPsTest(_logger, "Test-SynapseWorkspace");
        }

        [Fact(Skip = "Can't call Graph API through Service Principal.")]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestSynapseWorkspaceActiveDirectoryAdministrator()
        {
            SynapseTestBase.NewInstance.RunPsTest(
                _logger,
                "Test-SynapseWorkspaceActiveDirectoryAdministrator");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestSynapseWorkspaceSecurity()
        {
            SynapseTestBase.NewInstance.RunPsTest(
                _logger,
                "Test-SynapseWorkspaceSecurity");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestSynapseManagedIdentitySqlControlSetting()
        {
            SynapseTestBase.NewInstance.RunPsTest(
                _logger,
                "Test-SynapseManagedIdentitySqlControlSetting");
        }

        [Fact(Skip = "This test requires to create KeyVault beforehand and calls Graph API.")]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestSynapseWorkspaceKey()
        {
            SynapseTestBase.NewInstance.RunPsTest(
                _logger,
                "Test-SynapseWorkspaceKey");
        }
    }
}
