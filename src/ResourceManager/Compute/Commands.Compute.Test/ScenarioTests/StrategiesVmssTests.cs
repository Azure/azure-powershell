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
using Microsoft.Azure.ServiceManagemenet.Common.Models;
using Microsoft.Azure.Test.HttpRecorder;
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using System;
using System.Diagnostics;
using System.Reflection;
using Xunit;

namespace Microsoft.Azure.Commands.Compute.Test.ScenarioTests
{
    public class StrategiesVmssTests
    {
        XunitTracingInterceptor _logger;

        public StrategiesVmssTests(Xunit.Abstractions.ITestOutputHelper output)
        {
            _logger = new XunitTracingInterceptor(output);
            XunitTracingInterceptor.AddToContext(_logger);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestSimpleNewVmss()
        {
            ComputeTestController.NewInstance.RunPsTest(_logger, "Test-SimpleNewVmss");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestSimpleNewVmssLbErrorScenario()
        {
            ComputeTestController.NewInstance.RunPsTest(_logger, "Test-SimpleNewVmssLbErrorScenario");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestSimpleNewVmssWithSystemAssignedIdentity()
        {
            ComputeTestController.NewInstance.RunPsTest(_logger, "Test-SimpleNewVmssWithSystemAssignedIdentity");
        }


        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestSimpleNewVmssImageName()
        {
            ComputeTestController.NewInstance.RunPsTest(_logger, "Test-SimpleNewVmssImageName");
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
            ComputeTestController.NewInstance.RunPsTest(_logger, "Test-SimpleNewVmssWithsystemAssignedUserAssignedIdentity");
       }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestSimpleNewVmssWithoutDomainName()
        {
            TestDomainName(
                "Test-SimpleNewVmssWithoutDomainName",
                () => HttpMockServer.GetAssetGuid("domainName").ToString());
        }

        internal void TestDomainName(string psTest, Func<string> getUniqueId)
        {
            var sf = new StackTrace().GetFrame(1);
            var callingClassType = sf.GetMethod().ReflectedType?.ToString();
            var mockName = sf.GetMethod().Name;

            var create = typeof(UniqueId).GetField("_Create", BindingFlags.Static | BindingFlags.NonPublic);
            var oldCreate = create.GetValue(null);

            ComputeTestController controller = ComputeTestController.NewInstance;
            controller.SetLogger(_logger);

            controller.RunPsTestWorkflow(
                () => new[] { psTest },
                // initializer
                _ => create.SetValue(null, getUniqueId),
                // cleanup 
                () => create.SetValue(null, oldCreate),
                callingClassType,
                mockName);
        }
    }
}
