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
using Microsoft.Azure.Commands.Compute.Strategies;
using Microsoft.Azure.Test;
using Microsoft.Azure.Test.HttpRecorder;
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using System;
using System.Reflection;
using Xunit;

namespace Microsoft.Azure.Commands.Compute.Test.ScenarioTests
{
    public class StrategiesVirtualMachineTests
    {
        public StrategiesVirtualMachineTests(Xunit.Abstractions.ITestOutputHelper output)
        {
            ServiceManagemenet.Common.Models.XunitTracingInterceptor.AddToContext(
                new ServiceManagemenet.Common.Models.XunitTracingInterceptor(output));
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.Flaky)]
        public void TestSimpleNewVm()
        {
            ComputeTestController.NewInstance.RunPsTest("Test-SimpleNewVm");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.Flaky)]
        public void TestNewVmWin10()
        {
            ComputeTestController.NewInstance.RunPsTest("Test-NewVmWin10");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestSimpleNewVmWithSystemAssignedIdentity()
        {
            ComputeTestController.NewInstance.RunPsTest("Test-SimpleNewVmSystemAssignedIdentity");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.LiveOnly)]
        public void TestSimpleNewVmWithSystemAssignedAndUserAssignedIdentity()
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
            ComputeTestController.NewInstance.RunPsTest("Test-SimpleNewVmUserAssignedIdentitySystemAssignedIdentity");
        }

        [Fact] 
        [Trait(Category.AcceptanceType, Category.CheckIn)] 
        public void TestSimpleNewVmWithAvailabilitySet()
        {
            ComputeTestController.NewInstance.RunPsTest("Test-SimpleNewVmWithAvailabilitySet");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.Flaky)]
        public void TestSimpleNewVmWithAvailabilitySet2()
        {
            ComputeTestController.NewInstance.RunPsTest("Test-SimpleNewVmWithAvailabilitySet2");
        }

        public static void TestDomainName(string psTest, Func<string> getUniqueId)
        {
            var callingClassType = TestUtilities.GetCallingClass(2);
            var mockName = TestUtilities.GetCurrentMethodName(2);

            var oldCreate = UniqueId._Create;

            ComputeTestController.NewInstance.RunPsTestWorkflow(
                () => new[] { psTest },
                // initializer
                _ => UniqueId._Create = getUniqueId,
                // cleanup 
                () => UniqueId._Create = oldCreate,
                callingClassType,
                mockName);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestSimpleNewVmWithDefaultDomainName()
        {
            TestDomainName(
                "Test-SimpleNewVmWithDefaultDomainName",
                () => HttpMockServer.GetAssetGuid("domainName").ToString());
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.Flaky)]
        public void TestSimpleNewVmWithDefaultDomainName2()
        {
            var i = 0;
            var result = new Guid();
            TestDomainName("Test-SimpleNewVmWithDefaultDomainName2", () =>
            { 
                switch (i)
                {
                    case 1:
                        break;
                    default:
                        result = HttpMockServer.GetAssetGuid("domainName");
                        break;
                }
                ++i;
                return result.ToString();
            });
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.Flaky)]
        public void TestSimpleNewVmImageName()
        {
            ComputeTestController.NewInstance.RunPsTest("Test-SimpleNewVmImageName");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.Flaky)]
        public void TestSimpleNewVmImageNameMicrosoftSqlUbuntu()
        {
            ComputeTestController.NewInstance.RunPsTest("Test-SimpleNewVmImageNameMicrosoftSqlUbuntu");
        }
    }
}
