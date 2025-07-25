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

using Microsoft.Azure.Commands.Management.CognitiveServices;
using Microsoft.Azure.Commands.Management.CognitiveServices.Test.ScenarioTests;
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using Xunit;
using Xunit.Abstractions;

namespace CognitiveServices.Test.ScenarioTests
{
    public class CognitiveServicesUtilsTests : CognitiveServicesTestRunner
    {
        public CognitiveServicesUtilsTests(ITestOutputHelper output) : base(output)
        {
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestUtils()
        {
            ResourceId resourceId;
            Assert.True(ResourceId.TryParse("/subscriptions/f9b96b36-1f5e-4021-8959-51527e26e6d3/resourceGroups/yuanyang-test-sdk/providers/Microsoft.CognitiveServices/accounts/yytest-ta", out resourceId));
            Assert.Equal("f9b96b36-1f5e-4021-8959-51527e26e6d3", resourceId.SubscriptionId);
            Assert.Equal("yuanyang-test-sdk", resourceId.ResourceGroupName);
            Assert.Equal("Microsoft.CognitiveServices", resourceId.ProvidersName);
            Assert.Equal("yytest-ta", resourceId.GetAccountName());


            Assert.True(ResourceId.TryParse("/subscriptions/f9b96b36-1f5e-4021-8959-51527e26e6d3/resourceGroups/yuanyang-test-sdk/providers/Microsoft.CognitiveServices", out resourceId));
            Assert.Equal("f9b96b36-1f5e-4021-8959-51527e26e6d3", resourceId.SubscriptionId);
            Assert.Equal("yuanyang-test-sdk", resourceId.ResourceGroupName);
            Assert.Equal("Microsoft.CognitiveServices", resourceId.ProvidersName);
            Assert.Equal("", resourceId.GetAccountName());

            Assert.True(ResourceId.TryParse("/subscriptions/f9b96b36-1f5e-4021-8959-51527e26e6d3/resourceGroups/yuanyang-test-sdk/providers/Microsoft.CognitiveServices/accounts/yytest-ta/commitmentPlans/plan", out resourceId));
            Assert.Equal("f9b96b36-1f5e-4021-8959-51527e26e6d3", resourceId.SubscriptionId);
            Assert.Equal("yuanyang-test-sdk", resourceId.ResourceGroupName);
            Assert.Equal("Microsoft.CognitiveServices", resourceId.ProvidersName);
            Assert.Equal("yytest-ta", resourceId.GetAccountName());
            Assert.Equal("plan", resourceId.GetAccountSubResourceName("commitmentPlans"));
            Assert.Equal("plan", resourceId.GetAccountSubResourceName("CommitmentPlans"));
            Assert.Equal("", resourceId.GetAccountSubResourceName("deployments"));

            Assert.False(ResourceId.TryParse("/subscriptions/f9b96b36-1f5e-4021-8959-51527e26e6d3/resourceGroups/yuanyang-test-sdk/providers/Microsoft.CognitiveServices/accounts/", out resourceId));
            Assert.False(ResourceId.TryParse("/subscriptions/f9b96b36-1f5e-4021-8959-51527e26e6d3/resourceGroups/yuanyang-test-sdk/providers/Microsoft.CognitiveServices/accounts", out resourceId));
        }
    }
}
