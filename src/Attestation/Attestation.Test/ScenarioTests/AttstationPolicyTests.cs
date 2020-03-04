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
    public class AttstationPolicyTests : RMTestBase
    {
        public XunitTracingInterceptor _logger;

        public AttstationPolicyTests(Xunit.Abstractions.ITestOutputHelper output)
        {
            _logger = new XunitTracingInterceptor(output);
            XunitTracingInterceptor.AddToContext(_logger);
            TestExecutionHelpers.SetUpSessionAndProfile();
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestGetAttestationPolicy()
        {
            AttestationController.NewInstance.RunDataPowerShellTest(_logger, "Test-GetAttestationPolicy");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestResetAttestationPolicy()
        {
            AttestationController.NewInstance.RunDataPowerShellTest(_logger, "Test-ResetAttestationPolicy");
        }

        /// <summary>
        /// This test is categorized as LiveOnly since the Set-AzAttestationPolicy cmdlet retrieves and validates
        /// a signed JWT token from the service.  A playback of a recording will result in failure, since the
        /// recorded JWT will have expired since the recording was generated.
        ///
        /// On a related note, if one does try to create a recording of this test case, currently there's a
        /// conflict for the following two libraries used by the authentication code in this DLL
        /// (Microsoft.Azure.PowerShell.Cmdlets.Attestation.Test.dll) and the DLL used to implement the
        /// PowerShell cmdlets (Microsoft.Azure.PowerShell.Cmdlets.Attestation.dll).  This DLL requires
        /// version 5.1.2 (indirectly through Microsoft.Rest.ClientRuntime.Azure.TestFramework) and the cmdlet
        /// DLL requires version 5.6.0 (indirectly through Microsoft.IdentityModel.JsonWebTokens.
        ///     * Microsoft.IdentityModel.Tokens.dll
        ///     * Microsoft.IdentityModel.Logging.dll
        ///
        /// A work-around to record tests is to copy the 5.6.0 versions of the DLL's into the bin directory
        /// holding the Microsoft.Azure.PowerShell.Cmdlets.Attestation.Test.dll.
        /// </summary>
        [Fact]
        [Trait(Category.AcceptanceType, Category.LiveOnly)]
        public void TestSetAttestationPolicy()
        {
            AttestationController.NewInstance.RunDataPowerShellTest(_logger, "Test-SetAttestationPolicy");
        }
    }
}
