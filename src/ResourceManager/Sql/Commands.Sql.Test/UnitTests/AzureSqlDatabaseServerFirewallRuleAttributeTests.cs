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
using Microsoft.Azure.Commands.Sql.FirewallRule.Cmdlet;
using Microsoft.Azure.Commands.Sql.Test.Utilities;
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using Xunit;

namespace Microsoft.Azure.Commands.Sql.Test.UnitTests
{
    public class AzureSqlDatabaseServerFirewallRuleAttributeTests
    {
        [Fact]
        [Trait(Category.Sql, Category.CheckIn)]
        public void NewAzureSqlDatabaseServerFirewallRuleAttributes()
        {
            Type type = typeof(NewAzureSqlDatabaseServerFirewallRule);
            UnitTestHelper.CheckCmdletModifiesData(type, supportsShouldProcess: false);
            UnitTestHelper.CheckConfirmImpact(type, System.Management.Automation.ConfirmImpact.Medium);

            UnitTestHelper.CheckCmdletParameterAttributes(type, "ServerName", isMandatory: true, valueFromPipelineByName: true);
            UnitTestHelper.CheckCmdletParameterAttributes(type, "FirewallRuleName", isMandatory: true, valueFromPipelineByName: true);
            UnitTestHelper.CheckCmdletParameterAttributes(type, "StartIpAddress", isMandatory: true, valueFromPipelineByName: true);
            UnitTestHelper.CheckCmdletParameterAttributes(type, "EndIpAddress", isMandatory: true, valueFromPipelineByName: true);
        }

        [Fact]
        [Trait(Category.Sql, Category.CheckIn)]
        public void SetAzureSqlDatabaseServerFirewallRuleAttributes()
        {
            Type type = typeof(SetAzureSqlDatabaseServerFirewallRule);
            UnitTestHelper.CheckCmdletModifiesData(type, supportsShouldProcess: false);
            UnitTestHelper.CheckConfirmImpact(type, System.Management.Automation.ConfirmImpact.Medium);

            UnitTestHelper.CheckCmdletParameterAttributes(type, "ServerName", isMandatory: true, valueFromPipelineByName: true);
            UnitTestHelper.CheckCmdletParameterAttributes(type, "FirewallRuleName", isMandatory: true, valueFromPipelineByName: true);
            UnitTestHelper.CheckCmdletParameterAttributes(type, "StartIpAddress", isMandatory: true, valueFromPipelineByName: true);
            UnitTestHelper.CheckCmdletParameterAttributes(type, "EndIpAddress", isMandatory: true, valueFromPipelineByName: true);
        }

        [Fact]
        [Trait(Category.Sql, Category.CheckIn)]
        public void RemoveAzureSqlDatabaseServerFirewallRuleAttributes()
        {
            Type type = typeof(RemoveAzureSqlDatabaseServerFirewallRule);
            UnitTestHelper.CheckCmdletModifiesData(type, supportsShouldProcess: true);
            UnitTestHelper.CheckConfirmImpact(type, System.Management.Automation.ConfirmImpact.High);

            UnitTestHelper.CheckCmdletParameterAttributes(type, "ServerName", isMandatory: true, valueFromPipelineByName: true);
            UnitTestHelper.CheckCmdletParameterAttributes(type, "FirewallRuleName", isMandatory: true, valueFromPipelineByName: true);
        }

        [Fact]
        [Trait(Category.Sql, Category.CheckIn)]
        public void GetAzureSqlDatabaseServerFirewallRuleAttributes()
        {
            Type type = typeof(GetAzureSqlDatabaseServerFirewallRule);
            UnitTestHelper.CheckCmdletModifiesData(type, supportsShouldProcess: false);
            UnitTestHelper.CheckConfirmImpact(type, System.Management.Automation.ConfirmImpact.None);

            UnitTestHelper.CheckCmdletParameterAttributes(type, "ServerName", isMandatory: true, valueFromPipelineByName: true);
            UnitTestHelper.CheckCmdletParameterAttributes(type, "FirewallRuleName", isMandatory: false, valueFromPipelineByName: true);
        }
    }
}
