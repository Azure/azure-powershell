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

using System.Collections.Generic;
using System.Management.Automation.Runspaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.WindowsAzure.Commands.ScenarioTest.Common;
using Microsoft.WindowsAzure.Commands.ScenarioTest.Common.CustomPowerShell;
using Microsoft.WindowsAzure.Commands.Utilities.Store;

namespace Microsoft.WindowsAzure.Commands.ScenarioTest.StoreTests
{
    [TestClass]
    [Ignore] // https://github.com/WindowsAzure/azure-sdk-tools/issues/1184
    public class StoreTests : AzurePowerShellCertificateTest
    {
        public static string StoreCredentialFile = "store.publishsettings";

        public static string StoreSubscriptionName = "Store";

        public static string PromotionCodeVariable = "promotionCode";

        private CustomHost customHost;

        private List<int> expectedDefaultChoices;
        private List<int> promptChoices;
        private List<string> expectedPromptMessages;
        private List<string> expectedPromptCaptions;
        private PromptAnswer defaultAnswer;

        public StoreTests()
            : base(
            "Store\\Common.ps1",
            "Store\\StoreTests.ps1")
        {
            customHost = new CustomHost();
        }

        [TestInitialize]
        public override void TestSetup()
        {
            base.TestSetup();
            customHost = new CustomHost();
            expectedDefaultChoices = new List<int>();
            promptChoices = new List<int>();
            expectedPromptMessages = new List<string>();
            expectedPromptCaptions = new List<string>();
            defaultAnswer = PromptAnswer.Yes;
            powershell.ImportCredentials(StoreCredentialFile);
            powershell.AddScript(string.Format("Select-AzureSubscription -Default {0}", StoreSubscriptionName));
        }

        private void PromptSetup()
        {
            customHost.CustomUI.PromptChoices = promptChoices;
            customHost.CustomUI.ExpectedDefaultChoices = expectedDefaultChoices;
            customHost.CustomUI.ExpectedPromptMessages = expectedPromptMessages;
            customHost.CustomUI.ExpectedPromptCaptions = expectedPromptCaptions;
            customHost.CustomUI.DefaultAnswer = defaultAnswer;
            powershell.Runspace = RunspaceFactory.CreateRunspace(customHost);
            powershell.Runspace.Open();
            if (credentials.PowerShellVariables.ContainsKey(PromotionCodeVariable))
            {
                powershell.SetVariable(PromotionCodeVariable, credentials.PowerShellVariables[PromotionCodeVariable]);
            }
            powershell.SetVariable("freeAddOnIds", new string[] { "sendgrid_azure" });
        }

        #region Get-AzureStoreAddOn Scenario Tests

        [TestMethod]
        [TestCategory(Category.All)]
        [TestCategory(Category.Store)]
        public void TestGetAzureStoreAddOnListAvailableWithInvalidCredentials()
        {
            RunPowerShellTest("Test-WithInvalidCredentials { Get-AzureStoreAddOn -ListAvailable }");
        }

        [TestMethod]
        [TestCategory(Category.All)]
        [TestCategory(Category.Store)]
        public void TestGetAzureStoreAddOnListAvailableWithDefaultCountry()
        {
            RunPowerShellTest("Test-GetAzureStoreAddOnListAvailableWithDefaultCountry");
        }

        [TestMethod]
        [TestCategory(Category.All)]
        [TestCategory(Category.Store)]
        public void TestGetAzureStoreAddOnListAvailableWithNoAddOns()
        {
            RunPowerShellTest("Test-GetAzureStoreAddOnListAvailableWithNoAddOns");
        }

        [TestMethod]
        [TestCategory(Category.All)]
        [TestCategory(Category.Store)]
        public void TestGetAzureStoreAddOnListAvailableWithCountry()
        {
            RunPowerShellTest("Test-GetAzureStoreAddOnListAvailableWithCountry");
        }

        [TestMethod]
        [TestCategory(Category.All)]
        [TestCategory(Category.Store)]
        public void TestGetAzureStoreAddOnListAvailableWithInvalidCountryName()
        {
            RunPowerShellTest("Test-GetAzureStoreAddOnListAvailableWithInvalidCountryName");
        }

        [TestMethod]
        [TestCategory(Category.All)]
        [TestCategory(Category.Store)]
        public void TestGetAzureStoreAddOnWithInvalidCredentials()
        {
            RunPowerShellTest("Test-WithInvalidCredentials { Get-AzureStoreAddOn Name }");
        }

        [TestMethod]
        [TestCategory(Category.All)]
        [TestCategory(Category.Store)]
        public void TestGetAzureStoreAddOnWithNoAddOns()
        {
            RunPowerShellTest("Test-GetAzureStoreAddOnWithNoAddOns");
        }

        [TestMethod]
        [TestCategory(Category.All)]
        [TestCategory(Category.Store)]
        public void TestGetAzureStoreAddOnWithOneAddOn()
        {
            PromptSetup();
            RunPowerShellTest(
                "Test-GetAzureStoreAddOnWithOneAddOn",
                "AddOn-TestCleanup");
        }

        [TestMethod]
        [TestCategory(Category.All)]
        [TestCategory(Category.Store)]
        public void TestGetAzureStoreAddOnWithMultipleAddOns()
        {
            PromptSetup();
            RunPowerShellTest(
                "AddOn-TestCleanup",
                "Test-GetAzureStoreAddOnWithMultipleAddOns",
                "AddOn-TestCleanup");
        }

        [TestMethod]
        [TestCategory(Category.All)]
        [TestCategory(Category.Store)]
        public void TestGetAzureStoreAddOnWithExistingAddOn()
        {
            PromptSetup();
            RunPowerShellTest(
                "Test-GetAzureStoreAddOnWithExistingAddOn",
                "AddOn-TestCleanup");
        }

        [TestMethod]
        [TestCategory(Category.All)]
        [TestCategory(Category.Store)]
        public void TestGetAzureStoreAddOnCaseInsinsitive()
        {
            PromptSetup();
            RunPowerShellTest(
                "Test-GetAzureStoreAddOnCaseInsinsitive",
                "AddOn-TestCleanup");
        }

        [TestMethod]
        [TestCategory(Category.All)]
        [TestCategory(Category.Store)]
        [Ignore] // https://github.com/WindowsAzure/azure-sdk-tools/issues/1094
        public void TestGetAzureStoreAddOnWithInvalidName()
        {
            RunPowerShellTest("Test-GetAzureStoreAddOnWithInvalidName");
        }

        [TestMethod]
        [TestCategory(Category.All)]
        [TestCategory(Category.Store)]
        public void TestGetAzureStoreAddOnValidNonExisting()
        {
            RunPowerShellTest("Test-GetAzureStoreAddOnValidNonExisting");
        }

        [TestMethod]
        [TestCategory(Category.All)]
        [TestCategory(Category.Store)]
        public void TestGetAzureStoreAddOnWithAppService()
        {
            PromptSetup();
            RunPowerShellTest("Test-GetAzureStoreAddOnWithAppService");
        }

        [TestMethod]
        [TestCategory(Category.All)]
        [TestCategory(Category.Store)]
        public void TestGetAzureStoreAddOnPipedToRemoveAzureAddOn()
        {
            PromptSetup();
            RunPowerShellTest(
                "Test-GetAzureStoreAddOnPipedToRemoveAzureAddOn",
                "AddOn-TestCleanup");
        }

        #endregion

        #region New-AzureStoreAddOn Scenario Tests

        [TestMethod]
        [TestCategory(Category.All)]
        [TestCategory(Category.Store)]
        public void TestNewAzureStoreAddOnWithInvalidCredentials()
        {
            RunPowerShellTest("Test-WithInvalidCredentials { New-AzureStoreAddOn Name AddOn Plan \"West US\" }");
        }

        [TestMethod]
        [TestCategory(Category.All)]
        [TestCategory(Category.Store)]
        public void TestNewAzureStoreAddOnMissingRequiredParameter()
        {
            RunPowerShellTest("Test-NewAzureStoreAddOnMissingRequiredParameter");
        }

        [TestMethod]
        [TestCategory(Category.All)]
        [TestCategory(Category.Store)]
        [Ignore] // https://github.com/WindowsAzure/azure-sdk-tools/issues/1094
        public void TestNewAzureStoreAddOnWithInvalidName()
        {
            PromptSetup();
            RunPowerShellTest("Test-NewAzureStoreAddOnWithInvalidName");
        }

        [TestMethod]
        [TestCategory(Category.All)]
        [TestCategory(Category.Store)]
        [Ignore] // https://github.com/WindowsAzure/azure-sdk-tools/issues/1094
        public void TestNewAzureStoreAddOnWithInvalidWindowsAzureLocation()
        {
            PromptSetup();
            RunPowerShellTest("Test-NewAzureStoreAddOnWithInvalidWindowsAzureLocation");
        }

        [TestMethod]
        [TestCategory(Category.All)]
        [TestCategory(Category.Store)]
        public void TestNewAzureStoreAddOnSuccessfull()
        {
            PromptSetup();
            RunPowerShellTest(
                "Test-NewAzureStoreAddOnSuccessfull",
                "AddOn-TestCleanup");
        }

        [TestMethod]
        [TestCategory(Category.All)]
        [TestCategory(Category.Store)]
        public void TestNewAzureStoreAddOnWithExistingName()
        {
            PromptSetup();
            RunPowerShellTest("Test-NewAzureStoreAddOnWithExistingName");
        }

        [TestMethod]
        [TestCategory(Category.All)]
        [TestCategory(Category.Store)]
        [Ignore] // https://github.com/WindowsAzure/azure-sdk-tools/issues/1094
        public void TestNewAzureStoreAddOnWithInvalidAddOn()
        {
            PromptSetup();
            RunPowerShellTest("Test-NewAzureStoreAddOnWithInvalidAddOn");
        }

        [TestMethod]
        [TestCategory(Category.All)]
        [TestCategory(Category.Store)]
        [Ignore] // https://github.com/WindowsAzure/azure-sdk-tools/issues/1094
        public void TestNewAzureStoreAddOnWithInvalidPlan()
        {
            PromptSetup();
            RunPowerShellTest("Test-NewAzureStoreAddOnWithInvalidPlan");
        }

        [TestMethod]
        [TestCategory(Category.All)]
        [TestCategory(Category.Store)]
        [Ignore] // https://github.com/WindowsAzure/azure-sdk-tools/issues/1094
        public void TestNewAzureStoreAddOnWithInvalidLocation()
        {
            PromptSetup();
            RunPowerShellTest("Test-NewAzureStoreAddOnWithInvalidLocation");
        }

        [TestMethod]
        [TestCategory(Category.All)]
        [TestCategory(Category.Store)]
        public void TestNewAzureStoreAddOnWithInvalidPromoCode()
        {
            PromptSetup();
            RunPowerShellTest("Test-NewAzureStoreAddOnWithInvalidPromoCode");
        }

        [TestMethod]
        [TestCategory(Category.All)]
        [TestCategory(Category.Store)]
        [Ignore] // https://github.com/WindowsAzure/azure-sdk-tools/issues/1097
        public void TestNewAzureStoreAddOnWithValidPromoCode()
        {
            PromptSetup();
            RunPowerShellTest(
                "Test-NewAzureStoreAddOnWithValidPromoCode",
                "AddOn-TestCleanup");
        }

        [TestMethod]
        [TestCategory(Category.All)]
        [TestCategory(Category.Store)]
        public void TestNewAzureStoreAddOnWithNo()
        {
            defaultAnswer = PromptAnswer.No;
            PromptSetup();
            RunPowerShellTest("Test-NewAzureStoreAddOnWithNo");
        }

        [TestMethod]
        [TestCategory(Category.All)]
        [TestCategory(Category.Store)]
        public void TestNewAzureStoreAddOnConfirmationMessage()
        {
            expectedDefaultChoices.Add(PowerShellCustomConfirmation.No);
            expectedPromptCaptions.Add(Utilities.Properties.Resources.NewAddOnConformation);
            expectedPromptMessages.Add(string.Format(
                Utilities.Properties.Resources.NewNonMicrosoftAddOnMessage,
                string.Format(Utilities.Properties.Resources.AddOnUrl, "f131eadb-7aa3-401a-a2fb-1c7e71f45c3c"),
                "free",
                "Sendgrid"));
            PromptSetup();
            RunPowerShellTest(
                "Test-NewAzureStoreAddOnConfirmationMessage");
        }

        #endregion

        #region Remove-AzureStoreAddOn Scenario Tests

        [TestMethod]
        [TestCategory(Category.All)]
        [TestCategory(Category.Store)]
        public void TestRemoveAzureStoreAddOnWithInvalidCredentials()
        {
            RunPowerShellTest("Test-WithInvalidCredentials { Remove-AzureStoreAddOn Name }");
        }

        [TestMethod]
        [TestCategory(Category.All)]
        [TestCategory(Category.Store)]
        public void TestRemoveAzureStoreAddOnSuccessfull()
        {
            PromptSetup();
            RunPowerShellTest("Test-RemoveAzureStoreAddOnSuccessfull");
        }

        [TestMethod]
        [TestCategory(Category.All)]
        [TestCategory(Category.Store)]
        public void TestRemoveAzureStoreAddOnWithCasing()
        {
            PromptSetup();
            RunPowerShellTest("Test-RemoveAzureStoreAddOnWithCasing");
        }

        [TestMethod]
        [TestCategory(Category.All)]
        [TestCategory(Category.Store)]
        public void TestRemoveAzureStoreAddOnNotExisting()
        {
            RunPowerShellTest("Test-RemoveAzureStoreAddOnNotExisting");
        }

        [TestMethod]
        [TestCategory(Category.All)]
        [TestCategory(Category.Store)]
        public void TestRemoveAzureStoreAddOnPipedFromGetAzureAddOn()
        {
            PromptSetup();
            RunPowerShellTest("Test-RemoveAzureStoreAddOnPipedFromGetAzureAddOn");
        }

        [TestMethod]
        [TestCategory(Category.All)]
        [TestCategory(Category.Store)]
        public void TestRemoveAzureStoreAddOnMultiplePipedFromGetAzureAddOn()
        {
            PromptSetup();
            RunPowerShellTest("Test-RemoveAzureStoreAddOnMultiplePipedFromGetAzureAddOn");
        }

        [TestMethod]
        [TestCategory(Category.All)]
        [TestCategory(Category.Store)]
        public void TestRemoveAzureStoreAddOnWithNo()
        {
            promptChoices.AddRange(new int[] { PowerShellCustomConfirmation.Yes, PowerShellCustomConfirmation.No });
            PromptSetup();
            RunPowerShellTest("Test-RemoveAzureStoreAddOnWithNo");
        }

        #endregion
    }
}
