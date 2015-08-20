﻿// ----------------------------------------------------------------------------------
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
using Microsoft.Azure.Commands.Sql.Database.Cmdlet;
using Microsoft.Azure.Commands.Sql.Server.Cmdlet;
using Microsoft.Azure.Commands.Sql.ServerUpgrade.Cmdlet;
using Microsoft.Azure.Commands.Sql.ServiceTierAdvisor.Cmdlet;
using Microsoft.Azure.Commands.Sql.Test.Utilities;
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using Xunit;

namespace Microsoft.Azure.Commands.Sql.Test.UnitTests
{
    public class AzureSqlServiceTierAdvisorAttributeTests
    {
        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void GetAzureSqlDatabaseUpgradeHintAttributes()
        {
            Type type = typeof(GetAzureSqlDatabaseUpgradeHint);
            UnitTestHelper.CheckCmdletModifiesData(type, supportsShouldProcess: false);
            UnitTestHelper.CheckConfirmImpact(type, System.Management.Automation.ConfirmImpact.None);

            UnitTestHelper.CheckCmdletParameterAttributes(type, "ServerName", isMandatory: true, valueFromPipelineByName: true);
            UnitTestHelper.CheckCmdletParameterAttributes(type, "DatabaseName", isMandatory: false, valueFromPipelineByName: true);
            UnitTestHelper.CheckCmdletParameterAttributes(type, "ExcludeElasticPoolCandidates", isMandatory: false, valueFromPipelineByName: true);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void GetAzureSqlServerUpgradeHintAttributes()
        {
            Type type = typeof(GetAzureSqlServerUpgradeHint);
            UnitTestHelper.CheckCmdletModifiesData(type, supportsShouldProcess: false);
            UnitTestHelper.CheckConfirmImpact(type, System.Management.Automation.ConfirmImpact.None);

            UnitTestHelper.CheckCmdletParameterAttributes(type, "ServerName", isMandatory: true, valueFromPipelineByName: true);
            UnitTestHelper.CheckCmdletParameterAttributes(type, "ExcludeElasticPools", isMandatory: false, valueFromPipelineByName: true);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void GetAzureSqlDatabaseExpandedAttributes()
        {
            Type type = typeof(GetAzureSqlDatabaseExpanded);
            UnitTestHelper.CheckCmdletModifiesData(type, supportsShouldProcess: false);
            UnitTestHelper.CheckConfirmImpact(type, System.Management.Automation.ConfirmImpact.None);

            UnitTestHelper.CheckCmdletParameterAttributes(type, "ServerName", isMandatory: true, valueFromPipelineByName: true);
            UnitTestHelper.CheckCmdletParameterAttributes(type, "DatabaseName", isMandatory: false, valueFromPipelineByName: true);
        }
    }
}
