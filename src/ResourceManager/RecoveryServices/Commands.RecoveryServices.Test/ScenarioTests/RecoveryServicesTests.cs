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
using Microsoft.WindowsAzure.Commands.Test.Utilities.Common;
using Xunit;
using Xunit.Abstractions;

namespace Microsoft.Azure.Commands.RecoveryServices.Test.ScenarioTests
{
    public class RecoveryServicesTests : RMTestBase
    {
        public XunitTracingInterceptor _logger;

        public RecoveryServicesTests(Xunit.Abstractions.ITestOutputHelper output)
        {
            _logger = new XunitTracingInterceptor(output);
            XunitTracingInterceptor.AddToContext(_logger);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestRecoveryServicesVaultCRUD()
        {
            TestController.NewInstance.RunPsTest(_logger, "Test-RecoveryServicesVaultCRUD");
        }

#if NETSTANDARD
        [Fact(Skip = "Different parameter set used for NetStandard. Cannot process command because of one or more missing mandatory parameters: Certificate.")]
#else
        [Fact]
#endif
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestGetRSVaultSettingsFile()
        {
            TestController.NewInstance.RunPsTest(_logger, "Test-GetRSVaultSettingsFile");
        }
    }
}
