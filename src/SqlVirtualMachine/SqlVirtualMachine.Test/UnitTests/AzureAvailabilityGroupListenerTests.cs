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

using Microsoft.Azure.Commands.SqlVirtualMachine.SqlVirtualMachine.Cmdlet;
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using System;
using System.Collections.Generic;
using Xunit;
using Xunit.Abstractions;

namespace Microsoft.Azure.Commands.SqlVirtualMachine.Test.ScenarioTests.UnitTest
{
    public class AzureAvailabilityGroupListenerTests : AzureSqlVMBaseTests
    {
        public AzureAvailabilityGroupListenerTests(ITestOutputHelper output) : base(output)
        {
            UpsertParam = new List<string>(){};
            OptionalUpsertParam = new List<string>() { };
        }

        internal override void CheckResourceParameters(Type type, bool required = true)
        {
            UnitTestHelper.CheckCmdletParameterAttributes(type, "ResourceGroupName", required, false);
            UnitTestHelper.CheckCmdletParameterAttributes(type, "Name", required, false);
            UnitTestHelper.CheckCmdletParameterAttributes(type, "SqlVMGroupName", required, false);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void NewAzureAvailabilityGroupListener()
        {
            Type type = typeof(NewAzureAvailabilityGroupListener);
            // mandatory for new
            UnitTestHelper.CheckCmdletParameterAttributes(type, "AvailabilityGroupName", true, false);
            UnitTestHelper.CheckCmdletParameterAttributes(type, "LoadBalancerResourceId", true, false);
            UnitTestHelper.CheckCmdletParameterAttributes(type, "ProbePort", true, false);
            UnitTestHelper.CheckCmdletParameterAttributes(type, "SqlVirtualMachineId", true, false);

            // optional for new
            UnitTestHelper.CheckCmdletParameterAttributes(type, "Port", false, false);
            UnitTestHelper.CheckCmdletParameterAttributes(type, "IpAddress", false, false);
            UnitTestHelper.CheckCmdletParameterAttributes(type, "PublicIpAddressResourceId", false, false);
            UnitTestHelper.CheckCmdletParameterAttributes(type, "SubnetId", false, false);
            base.CheckNewParameters(type);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void GetAzureAvailabilityGroupListener()
        {
            Type type = typeof(GetAzureAvailabilityGroupListener);
            UnitTestHelper.CheckCmdletParameterAttributes(type, "ResourceGroupName", true, false);
            UnitTestHelper.CheckCmdletParameterAttributes(type, "SqlVMGroupName", true, false);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void UpdateAzureAvailabilityGroupListener()
        {
            Type type = typeof(UpdateAzureAvailabilityGroupListener);
            base.CheckUpdateParameters(type);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void RemoveAzureAvailabilityGroupListener()
        {
            Type type = typeof(RemoveAzureAvailabilityGroupListener);
            base.CheckRemoveParameters(type);
        }

    }
}
