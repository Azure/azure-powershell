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
    public class WebsitesTests
    {
        ScenarioTestFixture _collectionState;
        public WebsitesTests(ScenarioTestFixture fixture)
        {
            _collectionState = fixture;
        }

        [Fact (Skip = "TODO: Work in progress")]
        public void AppServicePlanTest()
        {
            var helper = _collectionState.GetRunner("webapp-management");
            helper.RunScript("01-AppServicePlan");
        }

        [Fact]
        public void WebAppSlotTest()
        {
            var helper = _collectionState.GetRunner("webapp-management");
            helper.EnvironmentVariables.Add("appName1", helper.GenerateName("testweb"));
            helper.EnvironmentVariables.Add("appName2", helper.GenerateName("testweb"));
            helper.EnvironmentVariables.Add("appName3", helper.GenerateName("testweb"));
            helper.EnvironmentVariables.Add("appName4", helper.GenerateName("testweb"));
            helper.EnvironmentVariables.Add("planName1", helper.GenerateName("testplan"));
            helper.EnvironmentVariables.Add("planName2", helper.GenerateName("testplan"));
            helper.EnvironmentVariables.Add("planName3", helper.GenerateName("testplan"));
            helper.RunScript("02-WebAppSlot");
        }

        [Fact]
        public void WebAppTest()
        {
            var helper = _collectionState.GetRunner("webapp-management");
            helper.EnvironmentVariables.Add("appName1", helper.GenerateName("testweb"));
            helper.EnvironmentVariables.Add("appName2", helper.GenerateName("testweb"));
            helper.EnvironmentVariables.Add("appName3", helper.GenerateName("testweb"));
            helper.EnvironmentVariables.Add("appName4", helper.GenerateName("testweb"));
            helper.EnvironmentVariables.Add("planName1", helper.GenerateName("testplan"));
            helper.EnvironmentVariables.Add("planName2", helper.GenerateName("testplan"));
            helper.EnvironmentVariables.Add("planName3", helper.GenerateName("testplan"));
            helper.EnvironmentVariables.Add("planName4", helper.GenerateName("testplan"));
            helper.RunScript("03-WebApp");
        }
    }
}
