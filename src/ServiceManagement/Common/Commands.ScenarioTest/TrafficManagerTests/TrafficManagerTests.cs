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
using System.IO;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.WindowsAzure.Commands.ScenarioTest.Common;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using Microsoft.Azure.Test;
using Xunit;
using Microsoft.Azure.Commands.Common.Authentication;
using System;
using Xunit.Abstractions;
using Microsoft.WindowsAzure.ServiceManagemenet.Common.Models;

namespace Microsoft.WindowsAzure.Commands.ScenarioTest
{
    public class TrafficManagerTests
    {
        private EnvironmentSetupHelper helper = new EnvironmentSetupHelper();

        public TrafficManagerTests(ITestOutputHelper output)
        {
            XunitTracingInterceptor.AddToContext(new XunitTracingInterceptor(output));
        }

        #region Remove-Profile Scenario Tests

        [Fact (Skip="Re-record mocks with new framework.")]
        [Trait(Category.Service, Category.TrafficManager)]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(Category.AcceptanceType, Category.BVT)]
        public void TestRemoveProfileWithInvalidCredentials()
        {
            this.RunPowerShellTest("Test-WithInvalidCredentials { Test-CreateAndRemoveProfile }");
        }

        [Fact]
        [Trait(Category.Service, Category.TrafficManager)]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(Category.AcceptanceType, Category.BVT)]
        public void TestCreateAndRemoveProfile()
        {
            this.RunPowerShellTest("Test-CreateAndRemoveProfile");
        }

        [Fact]
        [Trait(Category.Service, Category.TrafficManager)]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(Category.AcceptanceType, Category.BVT)]
        public void TestRemoveProfileWithNonExistingName()
        {
            this.RunPowerShellTest("Test-RemoveProfileWithNonExistingName");
        }

        #endregion

        #region Get-Profile Scenario Tests

        [Fact(Skip = "Re-record mocks with new framework.")]
        [Trait(Category.Service, Category.TrafficManager)]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(Category.AcceptanceType, Category.BVT)]
        public void TestGetProfileWithInvalidCredentials()
        {
            this.RunPowerShellTest("Test-WithInvalidCredentials { Test-GetProfile }");
        }

        [Fact]
        [Trait(Category.Service, Category.TrafficManager)]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(Category.AcceptanceType, Category.BVT)]
        public void TestGetProfile()
        {
            this.RunPowerShellTest("Test-GetProfile");
        }

        [Fact(Skip = "Re-record mocks with new framework.")]
        [Trait(Category.Service, Category.TrafficManager)]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(Category.AcceptanceType, Category.BVT)]
        public void TestGetMultipleProfiles()
        {
            this.RunPowerShellTest("Test-GetMultipleProfiles");
        }

        #endregion

        #region Enable-Disable-Profile Scenario Tests

        [Fact(Skip = "Re-record mocks with new framework.")]
        [Trait(Category.Service, Category.TrafficManager)]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(Category.AcceptanceType, Category.BVT)]
        public void TestEnableProfileWithInvalidCredentials()
        {
            this.RunPowerShellTest("Test-WithInvalidCredentials { Test-EnableProfile }");
        }

        [Fact(Skip = "Re-record mocks with new framework.")]
        [Trait(Category.Service, Category.TrafficManager)]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(Category.AcceptanceType, Category.BVT)]
        public void TestDisableProfileWithInvalidCredentials()
        {
            this.RunPowerShellTest("Test-WithInvalidCredentials { Test-DisableProfile }");
        }

        [Fact]
        [Trait(Category.Service, Category.TrafficManager)]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(Category.AcceptanceType, Category.BVT)]
        public void TestEnableProfile()
        {
            this.RunPowerShellTest("Test-EnableProfile");
        }

        [Fact]
        [Trait(Category.Service, Category.TrafficManager)]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(Category.AcceptanceType, Category.BVT)]
        public void TestDisableProfile()
        {
            this.RunPowerShellTest("Test-DisableProfile");
        }

        #endregion

        #region New-Profile Scenario Tests

        [Fact]
        [Trait(Category.Service, Category.TrafficManager)]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(Category.AcceptanceType, Category.BVT)]
        public void TestNewProfile()
        {
            this.RunPowerShellTest("Test-NewProfile");
        }

        [Fact]
        [Trait(Category.Service, Category.TrafficManager)]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(Category.AcceptanceType, Category.BVT)]
        public void TestNewProfileInvalidParameters()
        {
            this.RunPowerShellTest("Test-NewProfileWithInvalidParameter");
        }

        #endregion

        #region Set-Profile Scenario Tests

        [Fact]
        [Trait(Category.Service, Category.TrafficManager)]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(Category.AcceptanceType, Category.BVT)]
        public void TestSetProfileProperty()
        {
            this.RunPowerShellTest("Test-SetProfileProperty");
        }

        [Fact]
        [Trait(Category.Service, Category.TrafficManager)]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(Category.AcceptanceType, Category.BVT)]
        public void TestAddAzureTrafficManagerEndpoint()
        {
            this.RunPowerShellTest("Test-AddAzureTrafficManagerEndpoint");
        }

        [Fact]
        [Trait(Category.Service, Category.TrafficManager)]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(Category.AcceptanceType, Category.BVT)]
        public void TestAddAzureTrafficManagerEndpointNoWeightLocation()
        {
            this.RunPowerShellTest("Test-AddAzureTrafficManagerEndpointNoWeightLocation");
        }

        [Fact]
        [Trait(Category.Service, Category.TrafficManager)]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(Category.AcceptanceType, Category.BVT)]
        public void TestRemoveAzureTrafficManagerEndpoint()
        {
            this.RunPowerShellTest("Test-RemoveAzureTrafficManagerEndpoint");
        }

        [Fact(Skip = "TODO: Fix failing test.")]
        [Trait(Category.Service, Category.TrafficManager)]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(Category.AcceptanceType, Category.BVT)]
        public void TestAddAzureTrafficManagerEndpointNoMinChildEndpoints()
        {
            this.RunPowerShellTest("Test-AddAzureTrafficManagerEndpointNoMinChildEndpoints");
        }

        [Fact(Skip = "TODO: Fix the test.")]
        [Trait(Category.Service, Category.TrafficManager)]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(Category.AcceptanceType, Category.BVT)]
        public void TestAddAzureTrafficManagerEndpointTypeTrafficManager()
        {
            this.RunPowerShellTest("Test-AddAzureTrafficManagerEndpointTypeTrafficManager");
        }

        [Fact]
        [Trait(Category.Service, Category.TrafficManager)]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(Category.AcceptanceType, Category.BVT)]
        public void TestSetAzureTrafficManagerEndpoint()
        {
            this.RunPowerShellTest("Test-SetAzureTrafficManagerEndpoint");
        }

        [Fact]
        [Trait(Category.Service, Category.TrafficManager)]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(Category.AcceptanceType, Category.BVT)]
        public void TestSetAzureTrafficManagerEndpointUpdateWeightLocation()
        {
            this.RunPowerShellTest("Test-SetAzureTrafficManagerEndpointUpdateWeightLocation");
        }

        [Fact]
        [Trait(Category.Service, Category.TrafficManager)]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(Category.AcceptanceType, Category.BVT)]
        public void TestSetAzureTrafficManagerEndpointAdds()
        {
            this.RunPowerShellTest("Test-SetAzureTrafficManagerEndpointAdds");
        }

        [Fact]
        [Trait(Category.Service, Category.TrafficManager)]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(Category.AcceptanceType, Category.BVT)]
        public void TestAddMultipleAzureTrafficManagerEndpoint()
        {
            this.RunPowerShellTest("Test-AddMultipleAzureTrafficManagerEndpoint");
        }

        #endregion

        #region Test-DomainName Scenario Tests

        [Fact]
        [Trait(Category.Service, Category.TrafficManager)]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(Category.AcceptanceType, Category.BVT)]
        public void TestTestAzureTrafficManagerDomainName()
        {
            this.RunPowerShellTest("Test-TestAzureTrafficManagerDomainName");
        }

        #endregion

        protected void SetupManagementClients()
        {
            helper.SetupSomeOfManagementClients();
        }

        protected void RunPowerShellTest(params string[] scripts)
        {
            using (UndoContext context = UndoContext.Current)
            {
                context.Start(TestUtilities.GetCallingClass(1), TestUtilities.GetCurrentMethodName(2));

                SetupManagementClients();

                List<string> modules = Directory.GetFiles("Resources\\TrafficManager".AsAbsoluteLocation(), "*.ps1").ToList();

                helper.SetupEnvironment(AzureModule.AzureServiceManagement);
                helper.SetupModules(AzureModule.AzureServiceManagement, modules.ToArray());

                helper.RunPowerShellTest(scripts);
            }
        }
    }
}
