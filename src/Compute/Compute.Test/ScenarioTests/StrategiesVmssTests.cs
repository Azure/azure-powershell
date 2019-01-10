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

using Microsoft.Azure.Commands.Common.Strategies;
using Microsoft.Azure.ServiceManagement.Common.Models;
using Microsoft.Azure.Test.HttpRecorder;
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using System;
using System.Diagnostics;
using System.Reflection;
using Xunit;

namespace Microsoft.Azure.Commands.Compute.Test.ScenarioTests
{
    public class StrategiesVmssTests : ComputeTestRunner
    {
        XunitTracingInterceptor _logger;

        public StrategiesVmssTests(Xunit.Abstractions.ITestOutputHelper output)
            : base(output)
        {
            _logger = new XunitTracingInterceptor(output);
            XunitTracingInterceptor.AddToContext(_logger);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestSimpleNewVmss()
        {
//            ComputeTestController.NewInstance.RunPsTest(_logger, "Test-SimpleNewVmss");
            TestRunner.RunTestScript("Test-SimpleNewVmss");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestSimpleNewVmssFromSIGImage()
        {
//            ComputeTestController.NewInstance.RunPsTest(_logger, "Test-SimpleNewVmssFromSIGImage");
            TestRunner.RunTestScript("Test-SimpleNewVmssFromSIGImage");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestSimpleNewVmssWithUltraSSD()
        {
//            ComputeTestController.NewInstance.RunPsTest(_logger, "Test-SimpleNewVmssWithUltraSSD");
            TestRunner.RunTestScript("Test-SimpleNewVmssWithUltraSSD");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestSimpleNewVmssLbErrorScenario()
        {
//            ComputeTestController.NewInstance.RunPsTest(_logger, "Test-SimpleNewVmssLbErrorScenario");
            TestRunner.RunTestScript("Test-SimpleNewVmssLbErrorScenario");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestSimpleNewVmssWithSystemAssignedIdentity()
        {
//            ComputeTestController.NewInstance.RunPsTest(_logger, "Test-SimpleNewVmssWithSystemAssignedIdentity");
            TestRunner.RunTestScript("Test-SimpleNewVmssWithSystemAssignedIdentity");
        }


        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestSimpleNewVmssImageName()
        {
//            ComputeTestController.NewInstance.RunPsTest(_logger, "Test-SimpleNewVmssImageName");
            TestRunner.RunTestScript("Test-SimpleNewVmssImageName");
        }

#if NETSTANDARD
        [Fact(Skip = "Unknown issue/update, needs re-recorded")]
        [Trait(Category.RunType, Category.DesktopOnly)]
#else
        [Fact]
#endif
        [Trait(Category.RunType, Category.LiveOnly)]
        public void TestSimpleNewVmssWithSystemAssignedUserAssignedIdentity()
        {
            /**
             * To record this test run these commands first :
             * New-AzureRmResourceGroup -Name UAITG123456 -Location 'Central US'
             * New-AzureRmUserAssignedIdentity -ResourceGroupName  UAITG123456 -NameUAITG123456Identity
             * 
             * Now get the identity :
             * 
             * Get-AzureRmUserAssignedIdentity -ResourceGroupName UAITG123456 -Name UAITG123456Identity
             * Nore down the Id and use it in the PS code
             * */
//            ComputeTestController.NewInstance.RunPsTest(_logger, "Test-SimpleNewVmssWithsystemAssignedUserAssignedIdentity");
            TestRunner.RunTestScript("Test-SimpleNewVmssWithsystemAssignedUserAssignedIdentity");
       }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestSimpleNewVmssWithoutDomainName()
        {
            var create = typeof(UniqueId).GetField("_Create", BindingFlags.Static | BindingFlags.NonPublic);
            var oldCreate = create.GetValue(null);

            string GetUnigueId() => HttpMockServer.GetAssetGuid("domainName").ToString();
            create.SetValue(null, (Func<string>) GetUnigueId);
            TestRunner.RunTestScript("Test-SimpleNewVmssWithoutDomainName");
            create.SetValue(null, oldCreate);
        }
    }
}
