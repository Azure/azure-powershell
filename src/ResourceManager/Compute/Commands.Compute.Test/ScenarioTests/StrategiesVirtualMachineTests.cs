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
using Microsoft.Azure.Commands.Common.Strategies.Network;
using Microsoft.Azure.Test;
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using Moq;
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
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestSimpleNewVm()
        {
            ComputeTestController.NewInstance.RunPsTest("Test-SimpleNewVm");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestSimpleNewVmWithAvailabilitySet()
        {
            ComputeTestController.NewInstance.RunPsTest("Test-SimpleNewVmWithAvailabilitySet");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestSimpleNewVmWithAvailabilitySet2()
        {
            ComputeTestController.NewInstance.RunPsTest("Test-SimpleNewVmWithAvailabilitySet2");
        }

        private void TestDomainNameX(string psTest, Func<string> getUniqueId)
        {
            var create = typeof(UniqueId).GetField("_Create", BindingFlags.Static | BindingFlags.NonPublic);
            var oldCreate = create.GetValue(null);
            try
            {
                // mock UniqueId.Create()
                create.SetValue(null, getUniqueId);

                var callingClassType = TestUtilities.GetCallingClass(2);
                var mockName = TestUtilities.GetCurrentMethodName(2);

                ComputeTestController.NewInstance.RunPsTestWorkflow(
                    () => new[] { psTest },
                    // no custom initializer
                    null,
                    // no custom cleanup 
                    null,
                    callingClassType,
                    mockName);
            }
            finally
            {
                create.SetValue(null, oldCreate);
            }
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestSimpleNewVmWithDefaultDomainName()
        {
            TestDomainNameX("Test-SimpleNewVmWithDefaultDomainName", () => "a469f1");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestSimpleNewVmWithDefaultDomainName2()
        {
            var i = 0;
            TestDomainNameX("Test-SimpleNewVmWithDefaultDomainName2", () =>
            {
                var result = new[] { "012346", "012346", "012346", "543210" }[i];
                ++i;
                return result;
            });
        }
    }
}
