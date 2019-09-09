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
    public class AzureSqlVMGroupTests : AzureSqlVMBaseTests
    {
        public AzureSqlVMGroupTests(ITestOutputHelper output) : base(output)
        {
            OptionalUpsertParam = new List<string>()
            {
                "FileShareWitnessPath",
                "ClusterBootstrapAccount",
                "OuPath",
                "Tag"
            };
            UpsertParam = new List<string>()
            {
                "ClusterOperatorAccount",
                "SqlServiceAccount",
                "StorageAccountUrl",
                "StorageAccountPrimaryKey",
                "DomainFqdn"
            };
        }

        internal override void CheckResourceParameters(Type type, bool required = true)
        {
            UnitTestHelper.CheckCmdletParameterAttributes(type, "ResourceGroupName", required, false);
            UnitTestHelper.CheckCmdletParameterAttributes(type, "Name", required, false);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void NewAzureSqlVMGroup()
        {
            Type type = typeof(NewAzureSqlVMGroup);
            UnitTestHelper.CheckCmdletParameterAttributes(type, "Location", true, false);
            UnitTestHelper.CheckCmdletParameterAttributes(type, "Offer", true, false);
            UnitTestHelper.CheckCmdletParameterAttributes(type, "Sku", true, false);
            base.CheckNewParameters(type);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void GetAzureSqlVMGroup()
        {
            Type type = typeof(GetAzureSqlVMGroup);
            base.CheckGetParameters(type);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void UpdateAzureSqlVMGroup()
        {
            Type type = typeof(UpdateAzureSqlVMGroup);
            base.CheckUpdateParameters(type);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void RemoveAzureSqlVMGroup()
        {
            Type type = typeof(RemoveAzureSqlVMGroup);
            base.CheckRemoveParameters(type);
        }

    }
}
