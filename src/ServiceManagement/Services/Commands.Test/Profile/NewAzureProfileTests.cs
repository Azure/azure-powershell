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

using System;
using System.Collections.Generic;
using System.Management.Automation.Language;
using Microsoft.Azure.Commands.Test.Profile;
using Microsoft.Azure.Common.Authentication;
using Microsoft.Azure.Common.Authentication.Models;
using Microsoft.Azure.Subscriptions.Csm.Models;
using Microsoft.WindowsAzure.Commands.Common.Test.Mocks;
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using Xunit;
using CSMSubscription = Microsoft.Azure.Subscriptions.Csm.Models.Subscription;
using RDFESubscription = Microsoft.Azure.Subscriptions.Rdfe.Models.Subscription;

namespace Microsoft.Azure.Commands.Test.Profile
{
    public class NewAzureProfileTests
    {
        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestCreatesNewAzureProfileWithCertificate()
        {
            ProfileTestController.NewInstance.RunPsTest("Test-CreatesNewAzureProfileWithCertificate");
        }

        [Fact(Skip = "Need support from mocking framework")]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestCreatesNewAzureProfileWithUserCredentials()
        {
            ProfileTestController.NewInstance.RunPsTest("Test-CreatesNewAzureProfileWithUserCredentials");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestCreatesNewAzureProfileWithAccessToken()
        {
            ProfileTestController.NewInstance.RunPsTest("Test-CreatesNewAzureProfileWithAccessToken");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestMakeRdfeCallWithCreatedProfile()
        {
            ProfileTestController.NewRdfeInstance.RunPSTestWithToken((context, token) => string.Format("Test-NewAzureProfileInRDFEMode {0} {1} {2}", token, context.Account.Id, context.Subscription.Id));
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestMakeArmCallWithCreatedProfile()
        {
            ProfileTestController.NewARMInstance.RunPSTestWithToken((context, token) => string.Format("Test-NewAzureProfileInARMMode {0} {1} {2}", token, context.Account.Id, context.Subscription.Id));
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestCreateEmptyProfile()
        {
            ProfileTestController.NewARMInstance.RunPsTest("Test-NewEmptyProfile");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestCreateEmptyProfileWIthCustomEnvironment()
        {
            ProfileTestController.NewARMInstance.RunPsTest("Test-NewEmptyProfileWithEnvironment");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestUsePipelineWithEnvironmentCmdlets()
        {
            ProfileTestController.NewARMInstance.RunPsTest("Test-EnvironmentPipeline");
        }
        
}
}
