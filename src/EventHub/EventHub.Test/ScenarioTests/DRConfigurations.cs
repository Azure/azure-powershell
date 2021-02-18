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

<<<<<<< HEAD
namespace Microsoft.Azure.Commands.EventHub.Test.ScenarioTests
{
    using Microsoft.WindowsAzure.Commands.ScenarioTest;
    using Microsoft.WindowsAzure.Commands.Test.Utilities.Common;
    using ServiceManagement.Common.Models;
    using Xunit;
    using Xunit.Abstractions;
    public class DRConfigurationTests : RMTestBase
    {
        public XunitTracingInterceptor _logger;

        public DRConfigurationTests(ITestOutputHelper output)
        {
            _logger = new XunitTracingInterceptor(output);
            XunitTracingInterceptor.AddToContext(_logger);
=======
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using Xunit;

namespace Microsoft.Azure.Commands.EventHub.Test.ScenarioTests
{
   
    public class DRConfigurationTests : EventHubTestRunner
    {

        public DRConfigurationTests(Xunit.Abstractions.ITestOutputHelper output)
            : base(output)
        {
>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void DRConfigurationsCURD()
        {
<<<<<<< HEAD
            EventHubsController.NewInstance.RunPsTest(_logger, "DRConfigurationTests");
=======
            TestRunner.RunTestScript("DRConfigurationTests");
>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void DRConfigurationsCURDAlternateName()
        {
<<<<<<< HEAD
            EventHubsController.NewInstance.RunPsTest(_logger, "DRConfigurationTestsAlternateName");
=======
            TestRunner.RunTestScript("DRConfigurationTestsAlternateName");
>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a
        }
    }
}
