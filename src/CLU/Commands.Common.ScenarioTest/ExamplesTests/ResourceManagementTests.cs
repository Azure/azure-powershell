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

using Xunit;

namespace Microsoft.Azure.Commands.Common.ScenarioTest
{
    [Collection("SampleCollection")]
    public class ResourceManagementTests
    {
        ScenarioTestFixture _collectionState;
        public ResourceManagementTests(ScenarioTestFixture fixture)
        {
            _collectionState = fixture;
        }

        [Fact]
        public void ResourceGroupsTest()
        {
            var helper = _collectionState
                .GetRunner("resource-management")
                .RunScript("01-ResourceGroups");
        }

        [Fact]
        public void ResourcesTest()
        {
            var helper = _collectionState
                .GetRunner("resource-management");
            helper.EnvironmentVariables.Add("resourceName", helper.GenerateName("csmr"));
            helper.RunScript("02-Resource");
        }

        [Fact]
        public void DeploymentsTest()
        {
            var helper = _collectionState
                .GetRunner("resource-management");
            helper.EnvironmentVariables.Add("resourceName", helper.GenerateName("csmr"));
            helper.RunScript("03-Deployments");
        }

        [Fact]
        public void RoleAssignmentsTest()
        {
            // Must login as a user due to restricted use of old graph api
            var helper = _collectionState
                .LoginAsUser()
                .GetRunner("resource-management")
                .RunScript("04-RoleAssignments");
        }

        [Fact]
        public void RoleDefinitionsTest()
        {
            var helper = _collectionState
                .GetRunner("resource-management")
                .RunScript("05-RoleDefinitions");
        }
    }
}
