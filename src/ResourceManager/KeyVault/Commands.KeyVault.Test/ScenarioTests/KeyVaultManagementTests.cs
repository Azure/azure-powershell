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

using Microsoft.Azure.Graph.RBAC.Version1_6;
using Microsoft.Azure.Graph.RBAC.Version1_6.Models;
using Microsoft.Azure.Test.HttpRecorder;
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using System;
using System.IO;
using System.Linq;
using System.Reflection;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using Xunit;

namespace Microsoft.Azure.Commands.KeyVault.Test.ScenarioTests
{
    public class KeyVaultManagementTests : IClassFixture<KeyVaultTestFixture>
    {
        private readonly KeyVaultTestFixture _data;

        public KeyVaultManagementTests(KeyVaultTestFixture fixture)
        {
            HttpMockServer.RecordsDirectory = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "SessionRecords");
            _data = fixture;
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

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestCreateNewVault()
        {
            KeyVaultManagementController.NewInstance.RunPsTestWorkflow(
                () => { return new[] { "Test-CreateNewVault" }; },
                null,
                MethodBase.GetCurrentMethod().ReflectedType?.ToString(),
                MethodBase.GetCurrentMethod().Name
                );
        }

        #endregion

        #region Get-AzureRmKeyVault

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestGetVault()
        {
            KeyVaultManagementController.NewInstance.RunPsTestWorkflow(
                () => { return new[] { "Test-GetVault" }; },
                null,
                MethodBase.GetCurrentMethod().ReflectedType?.ToString(),
                MethodBase.GetCurrentMethod().Name,
                Initialize);

        }

        #endregion

        #region Get-AzureRmKeyVault (list)

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestListVaults()
        {
            KeyVaultManagementController.NewInstance.RunPsTestWorkflow(
                () => { return new[] { "Test-ListVaults" }; },
                null,
                MethodBase.GetCurrentMethod().ReflectedType?.ToString(),
                MethodBase.GetCurrentMethod().Name
                );
        }

        #endregion

        #region Remove-AzureRmKeyVault 

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestDeleteVault()
        {
            KeyVaultManagementController.NewInstance.RunPsTestWorkflow(
                () => { return new[] { "Test-DeleteVaultByName" }; },
                null,
                MethodBase.GetCurrentMethod().ReflectedType?.ToString(),
                MethodBase.GetCurrentMethod().Name
                );
        }

        #endregion

        #region Set-AzureRmKeyVaultAccessPolicy & Remove-AzureRmKeyVaultAccessPolicy

        [Fact(Skip = "Graph authentication blocks test passes")]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestSetRemoveAccessPolicyByObjectId()
        {
            string upn = "";
            _data.ResetPreCreatedVault();

            KeyVaultManagementController controller = KeyVaultManagementController.NewInstance;
            controller.RunPsTestWorkflow(
                () =>
                {
                    var objId = GetUserObjectId(controller, upn);
                    return new[] { string.Format("{0} {1} {2} {3}", "Test-SetRemoveAccessPolicyByObjectId", _data.PreCreatedVault, _data.ResourceGroupName, objId) };
                },
                null,
                MethodBase.GetCurrentMethod().ReflectedType?.ToString(),
                MethodBase.GetCurrentMethod().Name
                );
        }

        [Fact(Skip = "Graph authentication blocks test passes")]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestSetRemoveAccessPolicyByUPN()
        {
            string upn = "";
            _data.ResetPreCreatedVault();
            KeyVaultManagementController.NewInstance.RunPsTestWorkflow(
                () =>
                {
                    return new[] { string.Format("{0} {1} {2} {3}", "Test-SetRemoveAccessPolicyByUPN", _data.PreCreatedVault, _data.ResourceGroupName, upn) };
                },
                null,
                MethodBase.GetCurrentMethod().ReflectedType?.ToString(),
                MethodBase.GetCurrentMethod().Name
                );
        }

        [Fact(Skip = "Graph authentication blocks test passes")]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestSetRemoveAccessPolicyByCompoundId()
        {
            string upn = "";
            Guid? appId = null;
            _data.ResetPreCreatedVault();

            KeyVaultManagementController controller = KeyVaultManagementController.NewInstance;
            controller.RunPsTestWorkflow(
                () =>
                {
                    var objId = GetUserObjectId(controller, upn);
                    return new[] { string.Format("{0} {1} {2} {3} {4}", "Test-SetRemoveAccessPolicyByCompoundId", _data.PreCreatedVault, _data.ResourceGroupName, appId, objId) };
                },
                null,
                MethodBase.GetCurrentMethod().ReflectedType?.ToString(),
                MethodBase.GetCurrentMethod().Name
                );
        }

        [Fact(Skip = "Graph authentication blocks test passes")]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestRemoveAccessPolicyWithCompoundIdPolicies()
        {
            string upn = "";

            Guid? appId1 = null;
            Guid? appId2 = null;
            _data.ResetPreCreatedVault();

            KeyVaultManagementController controller = KeyVaultManagementController.NewInstance;
            controller.RunPsTestWorkflow(
                () =>
                {
                    var objId = GetUserObjectId(controller, upn);
                    return new[] { string.Format("{0} {1} {2} {3} {4} {5}", "Test-RemoveAccessPolicyWithCompoundIdPolicies", _data.PreCreatedVault, _data.ResourceGroupName, appId1, appId2, objId) };
                },
                null,
                MethodBase.GetCurrentMethod().ReflectedType?.ToString(),
                MethodBase.GetCurrentMethod().Name
                );
        }

        [Fact(Skip = "Graph authentication blocks test passes")]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestSetCompoundIdAccessPolicy()
        {
            string upn = "";
            Guid? appId = null;
            _data.ResetPreCreatedVault();

            KeyVaultManagementController controller = KeyVaultManagementController.NewInstance;
            controller.RunPsTestWorkflow(
                () =>
                {
                    var objId = GetUserObjectId(controller, upn);
                    return new[] { string.Format("{0} {1} {2} {3} {4}", "Test-SetCompoundIdAccessPolicy", _data.PreCreatedVault, _data.ResourceGroupName, appId, objId) };
                },
                null,
                MethodBase.GetCurrentMethod().ReflectedType?.ToString(),
                MethodBase.GetCurrentMethod().Name
                );
        }

        [Fact(Skip = "Graph authentication blocks test passes")]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestSetRemoveAccessPolicyBySPN()
        {
            Application app = null;
            ServicePrincipal principal = null;

            KeyVaultManagementController controller = KeyVaultManagementController.NewInstance;
            _data.ResetPreCreatedVault();
            controller.RunPsTestWorkflow(
            //script builder
            () =>
            {
                app = CreateNewAdApp(controller);
                principal = CreateNewAdServicePrincipal(controller, app.AppId);
                return new[] { string.Format("{0} {1} {2} {3}", "Test-SetRemoveAccessPolicyBySPN",
                    _data.PreCreatedVault,
                    _data.ResourceGroupName,
                    principal.ServicePrincipalNames.Where(s => s.StartsWith("http")).FirstOrDefault()) };
            },
            // cleanup
            () =>
            {
                DeleteAdServicePrincipal(controller, principal);
                DeleteAdApp(controller, app);
            },
            MethodBase.GetCurrentMethod().ReflectedType?.ToString(),
            MethodBase.GetCurrentMethod().Name
            );
        }

        [Fact(Skip = "Graph authentication blocks test passes")]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestModifyAccessPolicy()
        {
            string upn = "";

            KeyVaultManagementController controller = KeyVaultManagementController.NewInstance;
            _data.ResetPreCreatedVault();

            controller.RunPsTestWorkflow(
                () =>
                {

                    var objId = GetUserObjectId(controller, upn);
                    return new[] { string.Format("{0} {1} {2} {3}", "Test-ModifyAccessPolicy", _data.PreCreatedVault, _data.ResourceGroupName, objId) };
                },
                null,
                MethodBase.GetCurrentMethod().ReflectedType?.ToString(),
                MethodBase.GetCurrentMethod().Name
                );
        }

        [Fact(Skip = "Graph authentication blocks test passes")]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestModifyAccessPolicyEnabledForDeployment()
        {
            string upn = "";

            _data.ResetPreCreatedVault();
            KeyVaultManagementController.NewInstance.RunPsTestWorkflow(
                () =>
                {
                    return new[] { string.Format("{0} {1} {2} {3}", "Test-ModifyAccessPolicyEnabledForDeployment", _data.PreCreatedVault, _data.ResourceGroupName, upn) };
                },
                null,
                MethodBase.GetCurrentMethod().ReflectedType?.ToString(),
                MethodBase.GetCurrentMethod().Name
                );
        }


        [Fact(Skip = "Graph authentication blocks test passes")]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestModifyAccessPolicyEnabledForTemplateDeployment()
        {
            string upn = "";

            _data.ResetPreCreatedVault();
            KeyVaultManagementController.NewInstance.RunPsTestWorkflow(
                () =>
                {
                    return new[] { string.Format("{0} {1} {2} {3}", "Test-ModifyAccessPolicyEnabledForTemplateDeployment", _data.PreCreatedVault, _data.ResourceGroupName, upn) };
                },
                null,
                MethodBase.GetCurrentMethod().ReflectedType?.ToString(),
                MethodBase.GetCurrentMethod().Name
                );
        }

        [Fact(Skip = "Graph authentication blocks test passes")]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestModifyAccessPolicyEnabledForDiskEncryption()
        {
            string upn = "";

            _data.ResetPreCreatedVault();
            KeyVaultManagementController.NewInstance.RunPsTestWorkflow(
                () =>
                {
                    return new[] { string.Format("{0} {1} {2} {3}", "Test-ModifyAccessPolicyEnabledForDiskEncryption", _data.PreCreatedVault, _data.ResourceGroupName, upn) };
                },
                null,
                MethodBase.GetCurrentMethod().ReflectedType?.ToString(),
                MethodBase.GetCurrentMethod().Name
                );
        }


        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestModifyAccessPolicyNegativeCases()
        {
            string upn = "";

            _data.ResetPreCreatedVault();
            KeyVaultManagementController.NewInstance.RunPsTestWorkflow(
                () =>
                {
                    return new[] { string.Format("{0} {1} {2} {3}", "Test-ModifyAccessPolicyNegativeCases", _data.PreCreatedVault, _data.ResourceGroupName, upn) };
                },
                null,
                MethodBase.GetCurrentMethod().ReflectedType?.ToString(),
                MethodBase.GetCurrentMethod().Name
                );
        }

        [Fact(Skip = "Graph authentication blocks test passes")]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestRemoveNonExistentAccessPolicyDoesNotThrow()
        {
            string upn = "";
            _data.ResetPreCreatedVault();

            KeyVaultManagementController controller = KeyVaultManagementController.NewInstance;
            controller.RunPsTestWorkflow(
                () =>
                {
                    var objId = GetUserObjectId(controller, upn);
                    return new[] { string.Format("{0} {1} {2} {3}", "Test-RemoveNonExistentAccessPolicyDoesNotThrow", _data.PreCreatedVault, _data.ResourceGroupName, objId) };
                },
                null,
                MethodBase.GetCurrentMethod().ReflectedType?.ToString(),
                MethodBase.GetCurrentMethod().Name
                );
        }

        #endregion

        #region Helper Methods
        private string GetUserObjectId(KeyVaultManagementController controllerAdmin, string upn)
        {
            if (HttpMockServer.GetCurrentMode() == HttpRecorderMode.Record)
            {
                var user = controllerAdmin.GraphClient.Users.Get(upn);
                HttpMockServer.Variables["ObjectId"] = user.ObjectId;
                return user.ObjectId;
            }
            else
            {
                return HttpMockServer.Variables["ObjectId"];
            }
        }

        private Application CreateNewAdApp(KeyVaultManagementController controllerAdmin)
        {
            var appName = TestUtilities.GenerateName("adApplication");
            var url = string.Format("http://{0}/home", appName);
            var appParam = new ApplicationCreateParameters
            {
                AvailableToOtherTenants = false,
                DisplayName = appName,
                Homepage = url,
                IdentifierUris = new[] { url },
                ReplyUrls = new[] { url }
            };

            return controllerAdmin.GraphClient.Applications.Create(appParam);
        }

        private ServicePrincipal CreateNewAdServicePrincipal(KeyVaultManagementController controllerAdmin, string appId)
        {
            var spParam = new ServicePrincipalCreateParameters
            {
                AppId = appId,
                AccountEnabled = true
            };

            return controllerAdmin.GraphClient.ServicePrincipals.Create(spParam);
        }

        private void DeleteAdApp(KeyVaultManagementController controllerAdmin, Application app)
        {
            if (app != null)
            {
                controllerAdmin.GraphClient.Applications.Delete(app.ObjectId);
            }
        }

        private void DeleteAdServicePrincipal(KeyVaultManagementController controllerAdmin, ServicePrincipal newServicePrincipal)
        {
            if (newServicePrincipal != null)
            {
                controllerAdmin.GraphClient.ServicePrincipals.Delete(newServicePrincipal.ObjectId);
            }
        }
        #endregion
    }


}
