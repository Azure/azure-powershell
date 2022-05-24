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

using Microsoft.Azure.Commands.ServiceFabric.Commands;
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using Xunit;
using Xunit.Abstractions;

namespace Microsoft.Azure.Commands.ServiceFabric.Test.ScenarioTests
{
    public class ServiceFabricManagedClustersTests : ServiceFabricTestRunner
    {
        public ServiceFabricManagedClustersTests(ITestOutputHelper output) : base(output)
        {
            ServiceFabricCommonCmdletBase.WriteVerboseIntervalInSec = 0;
            ServiceFabricCmdletBase.RunningTest = true;
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestCreateBasicCluster()
        {
            TestRunner.RunTestScript("Test-CreateBasicCluster");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestNodeTypeOperations()
        {
            TestRunner.RunTestScript("Test-NodeTypeOperations");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestCertAndExtension()
        {
            TestRunner.RunTestScript("Test-CertAndExtension");
        }
    }
}
