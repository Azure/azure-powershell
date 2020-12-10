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


using Microsoft.Azure.ServiceManagement.Common.Models;
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using Microsoft.WindowsAzure.Commands.Test.Utilities.Common;
using Xunit;
using Xunit.Abstractions;

namespace Microsoft.Azure.Commands.Websites.Test.ScenarioTests
{
    public class AccessRestrictionTests : RMTestBase
    {
        public XunitTracingInterceptor _logger;

        public AccessRestrictionTests(ITestOutputHelper output)
        {
            _logger = new XunitTracingInterceptor(output);
            XunitTracingInterceptor.AddToContext(_logger);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestGetWebAppAccessRestriction()
        {
            WebsitesController.NewInstance.RunPsTest(_logger, "Test-GetWebAppAccessRestriction");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestUpdateWebAppAccessRestrictionSimple()
        {
            WebsitesController.NewInstance.RunPsTest(_logger, "Test-UpdateWebAppAccessRestrictionSimple");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestUpdateWebAppAccessRestrictionComplex()
        {
            WebsitesController.NewInstance.RunPsTest(_logger, "Test-UpdateWebAppAccessRestrictionComplex");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestAddWebAppAccessRestriction()
        {
            WebsitesController.NewInstance.RunPsTest(_logger, "Test-AddWebAppAccessRestriction");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestAddWebAppAccessRestrictionServiceTag()
        {
            WebsitesController.NewInstance.RunPsTest(_logger, "Test-AddWebAppAccessRestrictionServiceTag");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestAddWebAppAccessRestrictionHttpHeaders()
        {
            WebsitesController.NewInstance.RunPsTest(_logger, "Test-AddWebAppAccessRestrictionHttpHeaders");
        }

        // Currently no mock for Network exists in the Test Framework
        //[Fact]
        //[Trait(Category.AcceptanceType, Category.CheckIn)]
        //public void TestAddWebAppAccessRestrictionServiceEndpoint()
        //{
        //    WebsitesController.NewInstance.RunPsTest(_logger, "Test-AddWebAppAccessRestrictionServiceEndpoint");
        //}

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestRemoveWebAppAccessRestriction()
        {
            WebsitesController.NewInstance.RunPsTest(_logger, "Test-RemoveWebAppAccessRestriction");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestRemoveWebAppAccessRestrictionServiceTag()
        {
            WebsitesController.NewInstance.RunPsTest(_logger, "Test-RemoveWebAppAccessRestrictionServiceTag");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestAddWebAppAccessRestrictionScm()
        {
            WebsitesController.NewInstance.RunPsTest(_logger, "Test-AddWebAppAccessRestrictionScm");
        }
                
        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestRemoveWebAppAccessRestrictionScm()
        {
            WebsitesController.NewInstance.RunPsTest(_logger, "Test-RemoveWebAppAccessRestrictionScm");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestAddWebAppAccessRestrictionSlot()
        {
            WebsitesController.NewInstance.RunPsTest(_logger, "Test-AddWebAppAccessRestrictionSlot");
        }
    }
}
