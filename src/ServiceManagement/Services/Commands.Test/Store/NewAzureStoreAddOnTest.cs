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
using System.Management.Automation;
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using Xunit;
using Microsoft.WindowsAzure.Commands.Store;
using Microsoft.WindowsAzure.Commands.Test.Utilities.Common;
using Microsoft.WindowsAzure.Commands.Utilities.Properties;
using Microsoft.WindowsAzure.Commands.Utilities.Store;
using Moq;

namespace Microsoft.WindowsAzure.Commands.Test.Store
{
    
    public class NewAzureStoreAddOnTests : SMTestBase
    {
        Mock<ICommandRuntime> mockCommandRuntime;

        Mock<StoreClient> mockStoreClient;

        Mock<PowerShellCustomConfirmation> mockConfirmation;

        NewAzureStoreAddOnCommand cmdlet;

        public NewAzureStoreAddOnTests()
        {
            new FileSystemHelper(this).CreateAzureSdkDirectoryAndImportPublishSettings();
            mockCommandRuntime = new Mock<ICommandRuntime>();
            mockStoreClient = new Mock<StoreClient>();
            mockConfirmation = new Mock<PowerShellCustomConfirmation>();
            cmdlet = new NewAzureStoreAddOnCommand()
            {
                StoreClient = mockStoreClient.Object,
                CommandRuntime = mockCommandRuntime.Object,
                CustomConfirmation = mockConfirmation.Object
            };
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void NewAzureStoreAddOnWithSuccessful()
        {
            // Setup
            bool expected = true;
            WindowsAzureAddOn addon;
            string name = "TestAddOn";
            string location = "West US";
            string addonId = "Search";
            string plan = "free";
            string message = "Expected message for new";
            cmdlet.Name = name;
            cmdlet.AddOn = addonId;
            cmdlet.Plan = plan;
            cmdlet.Location = location;
            mockConfirmation.Setup(f => f.ShouldProcess(Resources.NewAddOnConformation, message)).Returns(true);
            mockStoreClient.Setup(f => f.TryGetAddOn(name, out addon)).Returns(false);
            mockStoreClient.Setup(f => f.NewAddOn(name, addonId, plan, location, null));
            mockStoreClient.Setup(f => f.GetConfirmationMessage(OperationType.New, addonId, plan)).Returns(message);

            // Test
            cmdlet.ExecuteCmdlet();

            // Assert
            mockStoreClient.Verify(f => f.NewAddOn(name, addonId, plan, location, null), Times.Once());
            mockConfirmation.Verify(f => f.ShouldProcess(Resources.NewAddOnConformation, message), Times.Once());
            mockCommandRuntime.Verify(f => f.WriteObject(expected), Times.Once());
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void NewAzureStoreAddOnWithNoConfirmation()
        {
            // Setup
            bool expected = true;
            WindowsAzureAddOn addon;
            string name = "TestAddOn";
            string location = "West US";
            string addonId = "Search";
            string plan = "free";
            string message = "Expected message for new";
            cmdlet.Name = name;
            cmdlet.AddOn = addonId;
            cmdlet.Plan = plan;
            cmdlet.Location = location;
            mockConfirmation.Setup(f => f.ShouldProcess(Resources.NewAddOnConformation, message)).Returns(false);
            mockStoreClient.Setup(f => f.TryGetAddOn(name, out addon)).Returns(false);
            mockStoreClient.Setup(f => f.NewAddOn(name, addonId, plan, location, null));
            mockStoreClient.Setup(f => f.GetConfirmationMessage(OperationType.New, addonId, plan)).Returns(message);

            // Test
            cmdlet.ExecuteCmdlet();

            // Assert
            mockStoreClient.Verify(f => f.NewAddOn(name, addonId, plan, location, null), Times.Never());
            mockConfirmation.Verify(f => f.ShouldProcess(Resources.NewAddOnConformation, message), Times.Once());
            mockCommandRuntime.Verify(f => f.WriteObject(expected), Times.Never());
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void NewAzureStoreAddOnWithNameAlreadyUsed()
        {
            // Setup
            WindowsAzureAddOn addon;
            string name = "TestAddOn";
            string location = "West US";
            string addonId = "Search";
            string plan = "free";
            string message = "Expected message for new";
            cmdlet.Name = name;
            cmdlet.AddOn = addonId;
            cmdlet.Plan = plan;
            cmdlet.Location = location;
            mockConfirmation.Setup(f => f.ShouldProcess(Resources.NewAddOnConformation, message)).Returns(true);
            mockStoreClient.Setup(f => f.TryGetAddOn(name, out addon)).Returns(true);
            mockStoreClient.Setup(f => f.NewAddOn(name, addonId, plan, location, null));
            mockStoreClient.Setup(f => f.GetConfirmationMessage(OperationType.New, addonId, plan)).Returns(message);

            // Test
            Testing.AssertThrows<Exception>(
                () => cmdlet.ExecuteCmdlet(),
                string.Format(Resources.AddOnNameAlreadyUsed, name));
        }
    }
}