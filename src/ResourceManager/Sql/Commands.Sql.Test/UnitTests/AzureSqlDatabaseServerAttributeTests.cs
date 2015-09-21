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

using System;
using Microsoft.Azure.Commands.Sql.Server.Cmdlet;
using Microsoft.Azure.Commands.Sql.Test.Utilities;
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using Xunit;

namespace Microsoft.Azure.Commands.Sql.Test.UnitTests
{
    public class AzureSqlServerAttributeTests
    {
        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void NewAzureSqlServerAttributes()
        {
            Type type = typeof(NewAzureSqlServer);
            UnitTestHelper.CheckCmdletModifiesData(type, supportsShouldProcess: false);
            UnitTestHelper.CheckConfirmImpact(type, System.Management.Automation.ConfirmImpact.Low);

            UnitTestHelper.CheckCmdletParameterAttributes(type, "ServerName", isMandatory: true, valueFromPipelineByName: false);
            UnitTestHelper.CheckCmdletParameterAttributes(type, "SqlAdministratorCredentials", isMandatory: true, valueFromPipelineByName: false);
            UnitTestHelper.CheckCmdletParameterAttributes(type, "Tags", isMandatory: false, valueFromPipelineByName: false);
            UnitTestHelper.CheckCmdletParameterAttributes(type, "ServerVersion", isMandatory: false, valueFromPipelineByName: false);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void SetAzureSqlServerAttributes()
        {
            Type type = typeof(SetAzureSqlServer);
            UnitTestHelper.CheckCmdletModifiesData(type, supportsShouldProcess: true);
            UnitTestHelper.CheckConfirmImpact(type, System.Management.Automation.ConfirmImpact.Medium);

            UnitTestHelper.CheckCmdletParameterAttributes(type, "ServerName", isMandatory: true, valueFromPipelineByName: true);
            UnitTestHelper.CheckCmdletParameterAttributes(type, "SqlAdministratorPassword", isMandatory: false, valueFromPipelineByName: false);
            UnitTestHelper.CheckCmdletParameterAttributes(type, "Tags", isMandatory: false, valueFromPipelineByName: false);
            UnitTestHelper.CheckCmdletParameterAttributes(type, "ServerVersion", isMandatory: false, valueFromPipelineByName: false);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void RemoveAzureSqlServerAttributes()
        {
            Type type = typeof(RemoveAzureSqlServer);
            UnitTestHelper.CheckCmdletModifiesData(type, supportsShouldProcess: true);
            UnitTestHelper.CheckConfirmImpact(type, System.Management.Automation.ConfirmImpact.High);

            UnitTestHelper.CheckCmdletParameterAttributes(type, "ServerName", isMandatory: true, valueFromPipelineByName: true);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void GetAzureSqlServerAttributes()
        {
            Type type = typeof(GetAzureSqlServer);
            UnitTestHelper.CheckCmdletModifiesData(type, supportsShouldProcess: false);
            UnitTestHelper.CheckConfirmImpact(type, System.Management.Automation.ConfirmImpact.None);

            UnitTestHelper.CheckCmdletParameterAttributes(type, "ServerName", isMandatory: false, valueFromPipelineByName: true);
        }
    }
}
