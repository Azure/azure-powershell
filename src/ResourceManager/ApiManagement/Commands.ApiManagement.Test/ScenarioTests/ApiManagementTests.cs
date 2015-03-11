//  
// Copyright (c) Microsoft.  All rights reserved.
// 
//  Licensed under the Apache License, Version 2.0 (the "License");
//  you may not use this file except in compliance with the License.
//  You may obtain a copy of the License at
//    http://www.apache.org/licenses/LICENSE-2.0
// 
//  Unless required by applicable law or agreed to in writing, software
//  distributed under the License is distributed on an "AS IS" BASIS,
//  WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//  See the License for the specific language governing permissions and
//  limitations under the License.

namespace Microsoft.Azure.Commands.ApiManagement.Test.ScenarioTests
{
    using System;
    using Microsoft.Azure.Common.Authentication;
    using Microsoft.Azure.Test;
    using Microsoft.WindowsAzure.Commands.ScenarioTest;
    using Xunit;

    public class ApiManagementTests
    {
        private readonly EnvironmentSetupHelper helper;

        public ApiManagementTests()
        {
            helper = new EnvironmentSetupHelper();
        }


        protected void SetupManagementClients()
        {
            var apiManagementManagementClient = GetApiManagementManagementClient();
            helper.SetupManagementClients(apiManagementManagementClient);
        }

        private Management.ApiManagement.ApiManagementClient GetApiManagementManagementClient()
        {
            return TestBase.GetServiceClient<Management.ApiManagement.ApiManagementClient>(new CSMTestEnvironmentFactory());
        }


        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestApiManagement()
        {
            RunPowerShellTest("Test-NewApiManagement");
        }

        private void RunPowerShellTest(params string[] scripts)
        {
#if DEBUG
            Environment.SetEnvironmentVariable("AZURE_TEST_MODE", "Record");

            Environment.SetEnvironmentVariable(
                "TEST_CSM_ORGID_AUTHENTICATION",
                "SubscriptionId=bb3f6f90-0996-4c18-8d61-028ab0f0f29b;Environment=Dogfood;AADTenant=83abe5cd-bcc3-441a-bd86-e6a75360cecc");

            Environment.SetEnvironmentVariable(
                "TEST_ORGID_AUTHENTICATION",
                "SubscriptionId=bb3f6f90-0996-4c18-8d61-028ab0f0f29b;Environment=Dogfood");
#endif

            using (var context = UndoContext.Current)
            {
                context.Start(TestUtilities.GetCallingClass(), TestUtilities.GetCurrentMethodName(2));

                SetupManagementClients();

                helper.SetupEnvironment(AzureModule.AzureResourceManager);
                helper.SetupModules(AzureModule.AzureResourceManager, "ScenarioTests\\" + GetType().Name + ".ps1");

                helper.RunPowerShellTest(scripts);
            }
        }
    }
}