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
using Microsoft.Azure.Test;
using Microsoft.Azure.Test.HttpRecorder;
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using Moq;
using System;
using System.Diagnostics;
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
        [Trait(Category.AcceptanceType, Category.Flaky)]
        public void TestSimpleNewVm()
        {
            TestRunner.RunTestScript("Test-SimpleNewVm");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestSimpleNewVmWithAvailabilitySet()
        {
            TestRunner.RunTestScript("Test-SimpleNewVmWithAvailabilitySet");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.Flaky)]
        public void TestSimpleNewVmWithAvailabilitySet2()
        {
            TestRunner.RunTestScript("Test-SimpleNewVmWithAvailabilitySet2");
        }

        internal static void TestDomainName(string psTest, Func<string> getUniqueId)
        {
            //var callingClassType = TestUtilities.GetCallingClass(2);
            //var mockName = TestUtilities.GetCurrentMethodName(2);
            var sf = new StackTrace().GetFrame(1); //1 or 2??
            var callingClassType = sf.GetMethod().ReflectedType?.ToString();
            var mockName = sf.GetMethod().Name;

            var create = typeof(UniqueId).GetField("_Create", BindingFlags.Static | BindingFlags.NonPublic);
            var oldCreate = create.GetValue(null);

            ComputeTestController.NewInstance.RunPsTestWorkflow(
                () => new[] { psTest },
                // initializer
                //_ => create.SetValue(null, getUniqueId),
                // cleanup 
                () => create.SetValue(null, oldCreate),
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
            TestRunner.RunTestScript("Test-SimpleNewVmImageName");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.Flaky)]
        public void TestSimpleNewVmImageNameMicrosoftSqlUbuntu()
        {
            TestRunner.RunTestScript("Test-SimpleNewVmImageNameMicrosoftSqlUbuntu");
        }
    }
}
