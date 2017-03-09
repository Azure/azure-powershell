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

using Microsoft.Azure.Commands.Sql.ServerDisasterRecoveryConfiguration.Cmdlet;
using Microsoft.Azure.Commands.Sql.Test.Utilities;
using Microsoft.Azure.ServiceManagemenet.Common.Models;
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using System;
using Xunit;
using Xunit.Abstractions;

namespace Microsoft.Azure.Commands.Sql.Test.UnitTests
{
    public class AzureSqlServerDisasterRecoveryConfigurationTests
    {
        public AzureSqlServerDisasterRecoveryConfigurationTests(ITestOutputHelper output)
        {
            XunitTracingInterceptor.AddToContext(new XunitTracingInterceptor(output));
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void NewAzureSqlServerDisasterRecoveryConfigurationAttributes()
        {
            Type type = typeof(NewAzureSqlServerDisasterRecoveryConfiguration);
            UnitTestHelper.CheckCmdletModifiesData(type, supportsShouldProcess: false);
            UnitTestHelper.CheckConfirmImpact(type, System.Management.Automation.ConfirmImpact.Low);

            UnitTestHelper.CheckCmdletParameterAttributes(type, "ResourceGroupName", isMandatory: true, valueFromPipelineByName: true);
            UnitTestHelper.CheckCmdletParameterAttributes(type, "ServerName", isMandatory: true, valueFromPipelineByName: true);
            UnitTestHelper.CheckCmdletParameterAttributes(type, "VirtualEndpointName", isMandatory: true, valueFromPipelineByName: false);
            UnitTestHelper.CheckCmdletParameterAttributes(type, "PartnerResourceGroupName", isMandatory: true, valueFromPipelineByName: false);
            UnitTestHelper.CheckCmdletParameterAttributes(type, "PartnerServerName", isMandatory: true, valueFromPipelineByName: false);
            UnitTestHelper.CheckCmdletParameterAttributes(type, "FailoverPolicy", isMandatory: false, valueFromPipelineByName: false);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void GetAzureSqlServerDisasterRecoveryConfigurationAttributes()
        {
            Type type = typeof(GetAzureSqlServerDisasterRecoveryConfiguration);
            UnitTestHelper.CheckCmdletModifiesData(type, supportsShouldProcess: false);
            UnitTestHelper.CheckConfirmImpact(type, System.Management.Automation.ConfirmImpact.None);

            UnitTestHelper.CheckCmdletParameterAttributes(type, "ResourceGroupName", isMandatory: true, valueFromPipelineByName: true);
            UnitTestHelper.CheckCmdletParameterAttributes(type, "ServerName", isMandatory: true, valueFromPipelineByName: true);
            UnitTestHelper.CheckCmdletParameterAttributes(type, "VirtualEndpointName", isMandatory: false, valueFromPipelineByName: false);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void SetAzureSqlServerDisasterRecoveryConfigurationAttributes()
        {
            Type type = typeof(SetAzureSqlServerDisasterRecoveryConfiguration);
            UnitTestHelper.CheckCmdletModifiesData(type, supportsShouldProcess: false);

            UnitTestHelper.CheckCmdletParameterAttributes(type, "ResourceGroupName", isMandatory: true, valueFromPipelineByName: true);
            UnitTestHelper.CheckCmdletParameterAttributes(type, "ServerName", isMandatory: true, valueFromPipelineByName: true);
            UnitTestHelper.CheckCmdletParameterAttributes(type, "VirtualEndpointName", isMandatory: true, valueFromPipelineByName: false);
            UnitTestHelper.CheckCmdletParameterAttributes(type, "Failover", isMandatory: true, valueFromPipelineByName: false);
            UnitTestHelper.CheckCmdletParameterAttributes(type, "AllowDataLoss", isMandatory: false, valueFromPipelineByName: false);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void RemoveAzureSqlServerDisasterRecoveryConfigurationAttributes()
        {
            Type type = typeof(RemoveAzureSqlServerDisasterRecoveryConfiguration);
            UnitTestHelper.CheckCmdletModifiesData(type, supportsShouldProcess: true);

            UnitTestHelper.CheckCmdletParameterAttributes(type, "ResourceGroupName", isMandatory: true, valueFromPipelineByName: true);
            UnitTestHelper.CheckCmdletParameterAttributes(type, "ServerName", isMandatory: true, valueFromPipelineByName: true);
            UnitTestHelper.CheckCmdletParameterAttributes(type, "VirtualEndpointName", isMandatory: true, valueFromPipelineByName: true);
        }
    }
}
