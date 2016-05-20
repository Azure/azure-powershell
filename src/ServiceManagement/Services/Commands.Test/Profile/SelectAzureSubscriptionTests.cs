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

using System.Management.Automation;
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using Xunit;
using Microsoft.WindowsAzure.Commands.Profile;
using Moq;
using Microsoft.Azure.Commands.Test.Profile;

namespace Microsoft.Azure.Commands.Test.Profile
{
    
    public class SelectAzureSubscriptionTests
    {
        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void CleansDefaultSubscriptionTwice()
        {
            // Setup
            Mock<ICommandRuntime> commandRuntimeMock = new Mock<ICommandRuntime>();
            SelectAzureSubscriptionCommand cmdlet = new SelectAzureSubscriptionCommand()
            {
                CommandRuntime = commandRuntimeMock.Object,
                PassThru = true,
                NoDefault = true
            };

            // Test
            cmdlet.ExecuteCmdlet();
            cmdlet.ExecuteCmdlet();

            // Assert that no exception is thrown
            Assert.True(true);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void StorageAccountIsNotCleaned()
        {
            ProfileTestController.NewRdfeInstance.RunPsTest("Test-StorageAccountIsNotCleaned");
        }
        
        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void GetSubscriptionPipeToSetSubscription()
        {
            ProfileTestController.NewRdfeInstance.RunPsTest("Test-GetSubscriptionPipeToSetSubscription");
        }
    }
}