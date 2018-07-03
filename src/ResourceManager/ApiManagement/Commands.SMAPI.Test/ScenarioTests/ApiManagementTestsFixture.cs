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

using Microsoft.Rest.ClientRuntime.Azure.TestFramework;

namespace Microsoft.Azure.Commands.ApiManagement.ServiceManagement.Test.ScenarioTests
{
    public class ApiManagementTestsFixture : TestsFixture
    {
        public string Location { get; set; }
        public string ResourceGroupName { get; set; }
        public string ApiManagementServiceName { get; set; }

        public ApiManagementTestsFixture()
        {
            using (MockContext context = MockContext.Start("ApiManagementTests", "CreateApiManagementService"))
            {
                var resourceManagementClient = ApiManagementHelper.GetResourceManagementClient();
                ResourceGroupName = "powershelltest";
                Location = "West US";

                if (string.IsNullOrWhiteSpace(ResourceGroupName))
                {
                    ResourceGroupName = Azure.Test.TestUtilities.GenerateName("Api-Default");
                    resourceManagementClient.TryRegisterResourceGroup(Location, ResourceGroupName);
                }

                ApiManagementServiceName = "powershellsdkservice";
                ApiManagementHelper.GetApiManagementClient(context).TryCreateApiService(ResourceGroupName, ApiManagementServiceName, Location);
            }
        }
    }
}