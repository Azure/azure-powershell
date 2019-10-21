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
using Microsoft.Azure.Commands.SqlVirtualMachine.SqlVirtualMachine.Cmdlet.Config;
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using System;
using System.Collections.Generic;
using Xunit;
using Xunit.Abstractions;
using static Microsoft.Azure.Commands.SqlVirtualMachine.Common.ParameterSet;

namespace Microsoft.Azure.Commands.SqlVirtualMachine.Test.ScenarioTests.UnitTest
{
    public class AzureSqlVMTests : AzureSqlVMBaseTests
    {
        
        public AzureSqlVMTests(ITestOutputHelper output) : base(output)
        {
            OptionalUpsertParam = new List<string>()
            {
                "Offer",
                "Sku",
                "SqlManagementType",
                "Tag"
            };
            UpsertParam = new List<string>()
            {
                "LicenseType"
            };
        }

        internal override void CheckResourceParameters(Type type, bool required = true)
        {
            UnitTestHelper.CheckCmdletParameterAttributes(type, "ResourceGroupName", required, false);
            UnitTestHelper.CheckCmdletParameterAttributes(type, "Name", required, false);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void NewAzureSqlVM()
        {
            Type type = typeof(NewAzureSqlVM);
            UnitTestHelper.CheckCmdletParameterAttributes(type, "Location", true, false);
            UpsertParamSet = new HashSet<String>()
            {
                Name + ParameterList,
            };
            base.CheckNewParameters(type);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void GetAzureSqlVM()
        {
            Type type = typeof(GetAzureSqlVM);
            base.CheckGetParameters(type);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void UpdateAzureSqlVM()
        {
            Type type = typeof(UpdateAzureSqlVM);
            UpsertParamSet = new HashSet<String>()
            {
                Name + ParameterList,
                ResourceId + ParameterList
            };
            base.CheckUpdateParameters(type);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void RemoveAzureSqlVM()
        {
            Type type = typeof(RemoveAzureSqlVM);
            base.CheckRemoveParameters(type);
        }

        // Config tests
        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void NewAzureSqlVMConfig()
        {
            Type type = typeof(NewAzureSqlVMConfig);
            UnitTestHelper.CheckCmdletModifiesData(type, supportsShouldProcess: true);
            CheckUpsertParameters(type, true);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void SetAzureSqlVMConfigGroup()
        {
            Type type = typeof(SetAzureSqlVMConfigGroup);
            UnitTestHelper.CheckCmdletModifiesData(type, supportsShouldProcess: true);
            
            UnitTestHelper.CheckCmdletParameterAttributes(type, "SqlVMGroup", true, false);
            UnitTestHelper.CheckCmdletParameterAttributes(type, "ClusterOperatorAccountPassword", true, false);
            UnitTestHelper.CheckCmdletParameterAttributes(type, "SqlServiceAccountPassword", true, false);
            UnitTestHelper.CheckCmdletParameterAttributes(type, "ClusterBootstrapAccountPassword", false, false);
        }
    }
}
