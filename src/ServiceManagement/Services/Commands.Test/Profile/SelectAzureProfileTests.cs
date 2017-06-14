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

using Microsoft.WindowsAzure.Commands.ScenarioTest;
using Xunit;

namespace Microsoft.Azure.Commands.Test.Profile
{
    public class SelectAzureProfileTests
    {
        [Fact]
        public void TestSelectDefaultProfile()
        {
            ProfileTestController.NewRdfeInstance.RunPSTestWithToken((context, token) => string.Format("Test-SelectDefaultProfile {0} {1} {2}", token, context.Account.Id, context.Subscription.Id));
        }

        [Fact(Skip = "PSGet Migration: TODO Move to ARM")]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestMakeArmCallWithCreatedProfile()
        {
            ProfileTestController.NewARMInstance.RunPSTestWithToken((context, token) => string.Format("Test-NewAzureProfileInARMMode {0} {1} {2}", token, context.Account.Id, context.Subscription.Id));
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestMakeRdfeCallWithCreatedProfile()
        {
            ProfileTestController.NewRdfeInstance.RunPSTestWithToken((context, token) => string.Format("Test-NewAzureProfileInRDFEMode {0} {1} {2}", token, context.Account.Id, context.Subscription.Id));
        }
    }
}
