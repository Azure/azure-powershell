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

using  Microsoft.Azure.Commands.TestFw;
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using Xunit;
using Xunit.Abstractions;

namespace Microsoft.Azure.Commands.Profile.Test
{
    public class SubscriptionCmdletTests
    {
        private readonly ITestRunnable _testManager;

        public SubscriptionCmdletTests(ITestOutputHelper output)
        {
            _testManager = TestManager.CreateInstance()
                .WithXunitTracingInterceptor(output)
                .Build();
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void AllParameterSetsSucceed()
        {
            _testManager.RunTestScript("Test-GetSubscriptionsEndToEnd");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void SetAzureRmContextWorks()
        {
            _testManager.RunTestScript("Test-SetAzureRmContextEndToEnd");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void PipingWithRmContextWorks()
        {
            _testManager.RunTestScript("Test-PipingWithContext");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void SetAzureRmContextWithoutSubscription()
        {
            _testManager.RunTestScript("Test-SetAzureRmContextWithoutSubscription");
        }
    }
}
