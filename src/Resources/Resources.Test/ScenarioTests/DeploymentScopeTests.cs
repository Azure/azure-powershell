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

using Microsoft.Azure.ServiceManagement.Common.Models;
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using Xunit;
using Xunit.Abstractions;

namespace Microsoft.Azure.Commands.Resources.Test.ScenarioTests
{
    public class DeploymentScopeTests
    {
        public XunitTracingInterceptor _logger;

        public DeploymentScopeTests(ITestOutputHelper output)
        {
            _logger = new XunitTracingInterceptor(output);
            XunitTracingInterceptor.AddToContext(_logger);
        }

        [Fact()]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void SubscriptionLevelDeploymentEndToEnd()
        {
            ResourcesController.NewInstance.RunPsTest(_logger, "Test-DeploymentEndToEnd-SubscriptionScope");
        }

        [Fact()]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void ResourceGroupDeploymentEndToEnd()
        {
            ResourcesController.NewInstance.RunPsTest(_logger, "Test-DeploymentEndToEnd-ResourceGroup");
        }

        [Fact(Skip = "Need to update test Resources")]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void ManagementGroupLevelDeploymentEndToEnd()
        {
            ResourcesController.NewInstance.RunPsTest(_logger, "Test-DeploymentEndToEnd-ManagementGroup");
        }

        [Fact(Skip = "Need to update test Resources")]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TenantLevelDeploymentEndToEnd()
        {
            ResourcesController.NewInstance.RunPsTest(_logger, "Test-DeploymentEndToEnd-TenantScope");
        }
    }
}
