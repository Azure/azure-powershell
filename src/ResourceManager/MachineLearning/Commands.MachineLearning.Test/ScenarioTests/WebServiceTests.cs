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

using Microsoft.Azure.ServiceManagemenet.Common.Models;
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using Microsoft.WindowsAzure.Commands.Test.Utilities.Common;
using Xunit;
using Xunit.Abstractions;

namespace Microsoft.Azure.Commands.MachineLearning.Test.ScenarioTests
{
    public class WebServiceTests : RMTestBase
    {
        private readonly XunitTracingInterceptor interceptor;

        public WebServiceTests(ITestOutputHelper output)
        {
            this.interceptor = new XunitTracingInterceptor(output);
            XunitTracingInterceptor.AddToContext(this.interceptor);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestCreateGetRemoveWebService()
        {
            WebServicesTestController.NewInstance.RunPsTest(this.interceptor, "Test-CreateGetRemoveMLService");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestCreateWebServiceFromFile()
        {
            WebServicesTestController.NewInstance.RunPsTest(this.interceptor, "Test-CreateWebServiceFromFile");
        }
        
        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestUpdateWebService()
        {
            WebServicesTestController.NewInstance.RunPsTest(this.interceptor, "Test-UpdateWebService");
        }
        
        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestListWebServices()
        {
            WebServicesTestController.NewInstance.RunPsTest(this.interceptor, "Test-ListWebServices");
        }
    }
}
