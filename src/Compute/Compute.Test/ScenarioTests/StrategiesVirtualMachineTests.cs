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
using Microsoft.Azure.Test.HttpRecorder;
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using System;
using System.Reflection;
using Xunit;

namespace Microsoft.Azure.Commands.Compute.Test.ScenarioTests
{
    public class StrategiesVirtualMachineTests : ComputeTestRunner
    {
        public StrategiesVirtualMachineTests(Xunit.Abstractions.ITestOutputHelper output)
            : base(output)
        {
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestSimpleNewVm()
        {
            TestRunner.RunTestScript("Test-SimpleNewVm");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestSimpleNewVmFromSIGImage()
        {
            TestRunner.RunTestScript("Test-SimpleNewVmFromSIGImage");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestSimpleNewVmWithUltraSSD()
        {
            TestRunner.RunTestScript("Test-SimpleNewVmWithUltraSSD");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestSimpleNewVmWithAccelNet()
        {
            TestRunner.RunTestScript("Test-SimpleNewVmWithAccelNet");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestNewVmWin10()
        {
            TestRunner.RunTestScript("Test-NewVmWin10");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestSimpleNewVmWithSystemAssignedIdentity()
        {
            TestRunner.RunTestScript("Test-SimpleNewVmSystemAssignedIdentity");
        }

        [Fact(Skip = "Unknown issue/update, needs re-recorded")]
        [Trait(Category.RunType, Category.DesktopOnly)]
        [Trait(Category.RunType, Category.LiveOnly)]
        public void TestSimpleNewVmWithSystemAssignedAndUserAssignedIdentity()
        {
            /**
             * To record this test run these commands first :
             * New-AzResourceGroup -Name UAITG123456 -Location 'Central US'
             * New-AzUserAssignedIdentity -ResourceGroupName  UAITG123456 -Name UAITG123456Identity
             * 
             * Now get the identity :
             * 
             * Get-AzUserAssignedIdentity -ResourceGroupName UAITG123456 -Name UAITG123456Identity
             * Nore down the Id and use it in the PS code
             * */
            TestRunner.RunTestScript("Test-SimpleNewVmUserAssignedIdentitySystemAssignedIdentity");
        }

        [Fact] 
        [Trait(Category.AcceptanceType, Category.CheckIn)] 
        public void TestSimpleNewVmWithAvailabilitySet()
        {
            TestRunner.RunTestScript("Test-SimpleNewVmWithAvailabilitySet");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestSimpleNewVmWithAvailabilitySet2()
        {
            TestRunner.RunTestScript("Test-SimpleNewVmWithAvailabilitySet2");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestSimpleNewVmWithDefaultDomainName()
        {
            var create = typeof(UniqueId).GetField("_Create", BindingFlags.Static | BindingFlags.NonPublic);
            var oldCreate = create.GetValue(null);

            string GetUnigueId() => HttpMockServer.GetAssetGuid("domainName").ToString();
            create.SetValue(null, (Func<string>) GetUnigueId);
            TestRunner.RunTestScript("Test-SimpleNewVmWithDefaultDomainName");
            create.SetValue(null, oldCreate);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestSimpleNewVmWithDefaultDomainName2()
        {
            var create = typeof(UniqueId).GetField("_Create", BindingFlags.Static | BindingFlags.NonPublic);
            var oldCreate = create.GetValue(null);

            var i = 0;
            var result = new Guid();
            string GetUnigueId() { 
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
            };

            create.SetValue(null, (Func<string>) GetUnigueId);
            TestRunner.RunTestScript("Test-SimpleNewVmWithDefaultDomainName2");
            create.SetValue(null, oldCreate);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestSimpleNewVmImageName()
        {
            TestRunner.RunTestScript("Test-SimpleNewVmImageName");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestSimpleNewVmImageNameMicrosoftSqlUbuntu()
        {
            TestRunner.RunTestScript("Test-SimpleNewVmImageNameMicrosoftSqlUbuntu");
        }
    }
}
