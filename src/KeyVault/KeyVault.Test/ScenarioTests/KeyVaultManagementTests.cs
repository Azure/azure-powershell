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


using Microsoft.Azure.Test;
using Microsoft.Azure.Test.HttpRecorder;
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using System;
using System.IO;
using System.Linq;
using System.Reflection;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using Xunit;
using Microsoft.Azure.ServiceManagement.Common.Models;

namespace Microsoft.Azure.Commands.KeyVault.Test.ScenarioTests
{
    public class KeyVaultManagementTests : IClassFixture<KeyVaultTestFixture>
    {
        private readonly KeyVaultTestFixture _data;
        public XunitTracingInterceptor _logger;

        public KeyVaultManagementTests(Xunit.Abstractions.ITestOutputHelper output)
        {
            _logger = new XunitTracingInterceptor(output);
            XunitTracingInterceptor.AddToContext(_logger);
            HttpMockServer.RecordsDirectory = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "SessionRecords");
            _data = new KeyVaultTestFixture();
            _data.Initialize(MethodBase.GetCurrentMethod().ReflectedType?.ToString());
        }

        private void Initialize()
        {
            if (HttpMockServer.GetCurrentMode() == HttpRecorderMode.Record)
            {
                HttpMockServer.Variables["ResourceGroupName"] = _data.ResourceGroupName;
                HttpMockServer.Variables["Location"] = _data.Location;
                HttpMockServer.Variables["PreCreatedVault"] = _data.PreCreatedVault;
            }
            else
            {
                _data.ResourceGroupName = HttpMockServer.Variables["ResourceGroupName"];
                _data.Location = HttpMockServer.Variables["Location"];
                _data.PreCreatedVault = HttpMockServer.Variables["PreCreatedVault"];
            }
        }


        #region New-AzureRmKeyVault        

        [Fact(Skip = "Graph authentication blocks test passes")]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestCreateNewVault()
        {
            KeyVaultManagementController.NewInstance.RunPsTestWorkflow(
                _logger,
                () => { return new[] { string.Format("{0} {1} {2} {3} {4}", "Test-CreateNewVault", _data.ResourceGroupName, _data.Location, _data.TagName, _data.TagValue) }; },
                null,
                MethodBase.GetCurrentMethod().ReflectedType?.ToString(),
                MethodBase.GetCurrentMethod().Name,
                Initialize
                );
        }

        [Fact(Skip = "Graph authentication blocks test passes")]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestCreateNewPremiumVaultEnabledForDeployment()
        {
            KeyVaultManagementController.NewInstance.RunPsTestWorkflow(
                _logger,
                () => { return new[] { string.Format("{0} {1} {2}", "Test-CreateNewPremiumVaultEnabledForDeployment", _data.ResourceGroupName, _data.Location) }; },
                null,
                MethodBase.GetCurrentMethod().ReflectedType?.ToString(),
                MethodBase.GetCurrentMethod().Name,
                Initialize
                );
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestRecreateVaultFails()
        {

            KeyVaultManagementController.NewInstance.RunPsTestWorkflow(
                _logger,
                () => { return new[] { string.Format("{0} {1} {2} {3}", "Test-RecreateVaultFails", _data.PreCreatedVault, _data.ResourceGroupName, _data.Location) }; },
                null,
                MethodBase.GetCurrentMethod().ReflectedType?.ToString(),
                MethodBase.GetCurrentMethod().Name,
                Initialize
                );
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestCreateVaultInUnknownResGrpFails()
        {
            KeyVaultManagementController.NewInstance.RunPsTestWorkflow(
                _logger,
                () => { return new[] { string.Format("{0} {1}", "Test-CreateVaultInUnknownResGrpFails", _data.Location) }; },
                null,
                MethodBase.GetCurrentMethod().ReflectedType?.ToString(),
                MethodBase.GetCurrentMethod().Name,
                Initialize
                );
        }

        [Fact(Skip = "Graph authentication blocks test passes")]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestCreateVaultPositionalParams()
        {
            KeyVaultManagementController.NewInstance.RunPsTestWorkflow(
                _logger,
                () => { return new[] { string.Format("{0} {1} {2}", "Test-CreateVaultPositionalParams", _data.ResourceGroupName, _data.Location) }; },
                null,
                MethodBase.GetCurrentMethod().ReflectedType?.ToString(),
                MethodBase.GetCurrentMethod().Name,
                Initialize
                );
        }

        #endregion

        #region Get-AzureRmKeyVault

        [Fact(Skip = "Graph authentication blocks test passes")]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestGetVaultByNameAndResourceGroup()
        {
            KeyVaultManagementController.NewInstance.RunPsTestWorkflow(
                _logger,
                () => { return new[] { string.Format("{0} {1} {2}", "Test-GetVaultByNameAndResourceGroup", _data.PreCreatedVault, _data.ResourceGroupName) }; },
                null,
                MethodBase.GetCurrentMethod().ReflectedType?.ToString(),
                MethodBase.GetCurrentMethod().Name,
                Initialize
                );

        }

        [Fact(Skip = "Graph authentication blocks test passes")]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestGetVaultByNameAndResourceGroupPositionalParams()
        {
            KeyVaultManagementController.NewInstance.RunPsTestWorkflow(
                _logger,
                () => { return new[] { string.Format("{0} {1} {2}", "Test-GetVaultByNameAndResourceGroupPositionalParams", _data.PreCreatedVault, _data.ResourceGroupName) }; },
                null,
                MethodBase.GetCurrentMethod().ReflectedType?.ToString(),
                MethodBase.GetCurrentMethod().Name,
                Initialize
                );

        }

        [Fact(Skip = "Graph authentication blocks test passes")]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestGetVaultByName()
        {
            KeyVaultManagementController.NewInstance.RunPsTestWorkflow(
                _logger,
                () => { return new[] { string.Format("{0} {1}", "Test-GetVaultByName", _data.PreCreatedVault) }; },
                null,
                MethodBase.GetCurrentMethod().ReflectedType?.ToString(),
                MethodBase.GetCurrentMethod().Name,
                Initialize
                );
        }

        [Fact(Skip = "Graph authentication blocks test passes")]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestGetVaultByNameCapitalized()
        {
            KeyVaultManagementController.NewInstance.RunPsTestWorkflow(
                _logger,
                () => new[] { string.Format("{0} {1}", "Test-GetVaultByName", _data.PreCreatedVault.ToUpper()) },
                null,
                MethodBase.GetCurrentMethod().ReflectedType?.ToString(),
                MethodBase.GetCurrentMethod().Name,
                Initialize
                );
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestGetUnknownVaultFails()
        {
            KeyVaultManagementController.NewInstance.RunPsTestWorkflow(
                _logger,
                () => { return new[] { string.Format("{0} {1}", "Test-GetUnknownVaultFails", _data.ResourceGroupName) }; },
                null,
                MethodBase.GetCurrentMethod().ReflectedType?.ToString(),
                MethodBase.GetCurrentMethod().Name,
                Initialize
                );

        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestGetVaultFromUnknownResourceGroupFails()
        {
            _data.ResetPreCreatedVault();
            KeyVaultManagementController.NewInstance.RunPsTestWorkflow(
                _logger,
                () => { return new[] { string.Format("{0} {1}", "Test-GetVaultFromUnknownResourceGroupFails", _data.PreCreatedVault) }; },
                null,
                MethodBase.GetCurrentMethod().ReflectedType?.ToString(),
                MethodBase.GetCurrentMethod().Name,
                Initialize
                );
        }

        #endregion

        #region Get-AzureRmKeyVault (list)

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestListVaultsByResourceGroup()
        {
            _data.ResetPreCreatedVault();
            KeyVaultManagementController.NewInstance.RunPsTestWorkflow(
                _logger,
                () => { return new[] { string.Format("{0} {1}", "Test-ListVaultsByResourceGroup", _data.ResourceGroupName) }; },
                null,
                MethodBase.GetCurrentMethod().ReflectedType?.ToString(),
                MethodBase.GetCurrentMethod().Name,
                Initialize
                );
        }


        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestListAllVaultsInSubscription()
        {
            KeyVaultManagementController.NewInstance.RunPsTestWorkflow(
                _logger,
                () => { return new[] { "Test-ListAllVaultsInSubscription" }; },
                null,
                MethodBase.GetCurrentMethod().ReflectedType?.ToString(),
                MethodBase.GetCurrentMethod().Name,
                Initialize
                );
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestListVaultsByTag()
        {
            KeyVaultManagementController.NewInstance.RunPsTestWorkflow(
                _logger,
                () => { return new[] { string.Format("{0} {1} {2}", "Test-ListVaultsByTag", _data.TagName, _data.TagValue) }; },
                null,
                MethodBase.GetCurrentMethod().ReflectedType?.ToString(),
                MethodBase.GetCurrentMethod().Name,
                Initialize
                );
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestListVaultsByUnknownResourceGroupFails()
        {
            KeyVaultManagementController.NewInstance.RunPsTestWorkflow(
                _logger,
                () => { return new[] { "Test-ListVaultsByUnknownResourceGroupFails" }; },
                null,
                MethodBase.GetCurrentMethod().ReflectedType?.ToString(),
                MethodBase.GetCurrentMethod().Name,
                Initialize
                );
        }
        #endregion

        #region Remove-AzureRmKeyVault 

        [Fact(Skip = "Graph authentication blocks test passes")]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestDeleteVaultByName()
        {
            KeyVaultManagementController.NewInstance.RunPsTestWorkflow(
                _logger,
                () => { return new[] { string.Format("{0} {1} {2}", "Test-DeleteVaultByName", _data.ResourceGroupName, _data.Location) }; },
                null,
                MethodBase.GetCurrentMethod().ReflectedType?.ToString(),
                MethodBase.GetCurrentMethod().Name,
                Initialize
                );
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestDeleteUnknownVaultFails()
        {
            KeyVaultManagementController.NewInstance.RunPsTestWorkflow(
                _logger,
                () => { return new[] { string.Format("{0} ", "Test-DeleteUnknownVaultFails") }; },
                null,
                MethodBase.GetCurrentMethod().ReflectedType?.ToString(),
                MethodBase.GetCurrentMethod().Name,
                Initialize
                );
        }

        #endregion

        #region Set-AzureRmKeyVaultAccessPolicy & Remove-AzureRmKeyVaultAccessPolicy

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestModifyAccessPolicyNegativeCases()
        {
            string upn = "";

            _data.ResetPreCreatedVault();
            KeyVaultManagementController.NewInstance.RunPsTestWorkflow(
                _logger,
                () =>
                {
                    return new[] { string.Format("{0} {1} {2} {3}", "Test-ModifyAccessPolicyNegativeCases", _data.PreCreatedVault, _data.ResourceGroupName, upn) };
                },
                null,
                MethodBase.GetCurrentMethod().ReflectedType?.ToString(),
                MethodBase.GetCurrentMethod().Name,
                Initialize
                );
        }

        #endregion

        #region Piping
        [Fact(Skip = "Graph authentication blocks test passes")]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestCreateDeleteVaultWithPiping()
        {
            KeyVaultManagementController.NewInstance.RunPsTestWorkflow(
                _logger,
                () => { return new[] { string.Format("{0} {1} {2}", "Test-CreateDeleteVaultWithPiping", _data.ResourceGroupName, _data.Location) }; },
                null,
                MethodBase.GetCurrentMethod().ReflectedType?.ToString(),
                MethodBase.GetCurrentMethod().Name,
                Initialize
                );
        }

        #endregion
    }


}
