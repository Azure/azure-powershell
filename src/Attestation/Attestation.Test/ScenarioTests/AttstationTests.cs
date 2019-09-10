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

using Microsoft.Azure.Commands.ScenarioTest;
using Microsoft.Azure.ServiceManagement.Common.Models;
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using Microsoft.WindowsAzure.Commands.Test.Utilities.Common;
using Xunit;

namespace Microsoft.Azure.Commands.Attestation.Test.ScenarioTests
{
    public class AttstationTests : RMTestBase
    {
        public XunitTracingInterceptor _logger;

        public AttstationTests(Xunit.Abstractions.ITestOutputHelper output)
        {
            _logger = new XunitTracingInterceptor(output);
            XunitTracingInterceptor.AddToContext(_logger);
            TestExecutionHelpers.SetUpSessionAndProfile();
        }

        #region New-AzureRmAttestation        
        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestCreateAttestation()
        {
            AttestationController.NewInstance.RunPowerShellTest(_logger, "Test-CreateAttestation");
        }
        #endregion

        #region Get-AzureRmAttestation
        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestGetAttestation()
        {
            AttestationController.NewInstance.RunPowerShellTest(_logger, "Test-GetAttestation");
        }
        #endregion

        #region Remove-AzureRmAttestation
        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestDeleteAttestationByName()
        {
            AttestationController.NewInstance.RunPowerShellTest(_logger, "Test-DeleteAttestationByName");
        }
        #endregion
    }
}
