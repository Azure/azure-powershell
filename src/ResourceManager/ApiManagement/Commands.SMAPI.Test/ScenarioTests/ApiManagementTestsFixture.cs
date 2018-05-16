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

namespace Microsoft.Azure.Commands.ApiManagement.ServiceManagement.Test.ScenarioTests
{
    using Azure.Test;

    public class ApiManagementTestsFixture : TestsFixture
    {
        public string Location { get; set; }
        public string ResourceGroupName { get; set; }
        public string ApiManagementServiceName { get; set; }

        public ApiManagementTestsFixture()
        {
            try
            {
                TestUtilities.StartTest("ApiManagementTests", "CreateApiManagementService");

                var resourceManagementClient = ApiManagementHelper.GetResourceManagementClient();
                ResourceGroupName = resourceManagementClient.TryGetResourceGroup(null);
                Location = "West US";

                if (string.IsNullOrWhiteSpace(ResourceGroupName))
                {
                    ResourceGroupName = TestUtilities.GenerateName("Api-Default");
                    resourceManagementClient.TryRegisterResourceGroup("eastus", ResourceGroupName);
                }

                ApiManagementServiceName = TestUtilities.GenerateName("hydraapimservice");
                ApiManagementHelper.GetApiManagementClient().TryCreateApiService(ResourceGroupName, ApiManagementServiceName, Location);
            }
            finally
            {
                TestUtilities.EndTest();
            }
        }
    }
}