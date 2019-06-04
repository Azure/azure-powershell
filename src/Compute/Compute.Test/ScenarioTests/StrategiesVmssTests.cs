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
    public class StrategiesVmssTests : ComputeTestRunner
    {
        public StrategiesVmssTests(Xunit.Abstractions.ITestOutputHelper output)
            : base(output)
        {
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestSimpleNewVmss()
        {
            TestRunner.RunTestScript("Test-SimpleNewVmss");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestSimpleNewVmssFromSIGImage()
        {
            TestRunner.RunTestScript("Test-SimpleNewVmssFromSIGImage");
        }

        [Fact(Skip = "Test failed while re-recording.")]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestSimpleNewVmssWithUltraSSD()
        {
            TestRunner.RunTestScript("Test-SimpleNewVmssWithUltraSSD");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestSimpleNewVmssLbErrorScenario()
        {
            TestRunner.RunTestScript("Test-SimpleNewVmssLbErrorScenario");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestSimpleNewVmssWithSystemAssignedIdentity()
        {
            TestRunner.RunTestScript("Test-SimpleNewVmssWithSystemAssignedIdentity");
        }


        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(Category.RunType, Category.CoreOnly)]
        public void TestSimpleNewVmssImageName()
        {
            TestRunner.RunTestScript("Test-SimpleNewVmssImageName");
        }

        [Fact(Skip = "Unknown issue/update, needs re-recorded")]
        [Trait(Category.RunType, Category.DesktopOnly)]
        [Trait(Category.RunType, Category.LiveOnly)]
        public void TestSimpleNewVmssWithSystemAssignedUserAssignedIdentity()
        {
            /**
             * To record this test run these commands first :
             * New-AzResourceGroup -Name UAITG123456 -Location 'Central US'
             * New-AzUserAssignedIdentity -ResourceGroupName  UAITG123456 -NameUAITG123456Identity
             * 
             * Now get the identity :
             * 
             * Get-AzUserAssignedIdentity -ResourceGroupName UAITG123456 -Name UAITG123456Identity
             * Nore down the Id and use it in the PS code
             * */
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
