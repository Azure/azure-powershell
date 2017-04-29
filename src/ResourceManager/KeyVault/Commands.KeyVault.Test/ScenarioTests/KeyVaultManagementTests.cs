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


using Microsoft.Azure.Graph.RBAC;
using Microsoft.Azure.Graph.RBAC.Models;
using Microsoft.Azure.ServiceManagemenet.Common.Models;
using Microsoft.Azure.Test;
using Microsoft.Azure.Test.HttpRecorder;
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using System;
using System.IO;
using System.Linq;
using Xunit;
using Xunit.Abstractions;

namespace Microsoft.Azure.Commands.KeyVault.Test.ScenarioTests
{
    public class KeyVaultManagementTests : IClassFixture<KeyVaultTestFixture>
    {
        private KeyVaultTestFixture _data;

        public KeyVaultManagementTests(KeyVaultTestFixture fixture)
        {
            HttpMockServer.RecordsDirectory = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "SessionRecords");
            this._data = fixture;
            this._data.Initialize(TestUtilities.GetCallingClass());
        }

        private void Initialize()
        {
            if (HttpMockServer.GetCurrentMode() == HttpRecorderMode.Record)
            {
                HttpMockServer.Variables["ResourceGroupName"] = _data.resourceGroupName;
                HttpMockServer.Variables["Location"] = _data.location;
                HttpMockServer.Variables["PreCreatedVault"] = _data.preCreatedVault;
            }
            else
            {
                _data.resourceGroupName = HttpMockServer.Variables["ResourceGroupName"];
                _data.location = HttpMockServer.Variables["Location"];
                _data.preCreatedVault = HttpMockServer.Variables["PreCreatedVault"];
            }
        }


        #region New-AzureRmKeyVault        

        [Fact(Skip = "Graph authentication blocks test passes")]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestCreateNewVault()
        {
            KeyVaultManagementController.NewInstance.RunPsTestWorkflow(
                () => { return new[] { string.Format("{0} {1} {2} {3} {4}", "Test-CreateNewVault", _data.resourceGroupName, _data.location, _data.tagName, _data.tagValue) }; },
                (env) => Initialize(),
                null,
                TestUtilities.GetCallingClass(),
                TestUtilities.GetCurrentMethodName()
                );
        }

        [Fact(Skip = "Graph authentication blocks test passes")]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestCreateNewPremiumVaultEnabledForDeployment()
        {
            KeyVaultManagementController.NewInstance.RunPsTestWorkflow(
                () => { return new[] { string.Format("{0} {1} {2}", "Test-CreateNewPremiumVaultEnabledForDeployment", _data.resourceGroupName, _data.location) }; },
                (env) => Initialize(),
                null,
                TestUtilities.GetCallingClass(),
                TestUtilities.GetCurrentMethodName()
                );
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestRecreateVaultFails()
        {

            KeyVaultManagementController.NewInstance.RunPsTestWorkflow(
                () => { return new[] { string.Format("{0} {1} {2} {3}", "Test-RecreateVaultFails", _data.preCreatedVault, _data.resourceGroupName, _data.location) }; },
                (env) => Initialize(),
                null,
                TestUtilities.GetCallingClass(),
                TestUtilities.GetCurrentMethodName()
                );
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestCreateVaultInUnknownResGrpFails()
        {
            KeyVaultManagementController.NewInstance.RunPsTestWorkflow(
                () => { return new[] { string.Format("{0} {1}", "Test-CreateVaultInUnknownResGrpFails", _data.location) }; },
                (env) => Initialize(),
                null,
                TestUtilities.GetCallingClass(),
                TestUtilities.GetCurrentMethodName()
                );
        }

        [Fact(Skip = "Graph authentication blocks test passes")]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestCreateVaultPositionalParams()
        {

            KeyVaultManagementController.NewInstance.RunPsTestWorkflow(
                () => { return new[] { string.Format("{0} {1} {2}", "Test-CreateVaultPositionalParams", _data.resourceGroupName, _data.location) }; },
                (env) => Initialize(),
                null,
                TestUtilities.GetCallingClass(),
                TestUtilities.GetCurrentMethodName()
                );
        }

        #endregion

        #region Get-AzureRmKeyVault

        [Fact(Skip = "Graph authentication blocks test passes")]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestGetVaultByNameAndResourceGroup()
        {
            KeyVaultManagementController.NewInstance.RunPsTestWorkflow(
                () => { return new[] { string.Format("{0} {1} {2}", "Test-GetVaultByNameAndResourceGroup", _data.preCreatedVault, _data.resourceGroupName) }; },
                (env) => Initialize(),
                null,
                TestUtilities.GetCallingClass(),
                TestUtilities.GetCurrentMethodName()
                );

        }

        [Fact(Skip = "Graph authentication blocks test passes")]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestGetVaultByNameAndResourceGroupPositionalParams()
        {
            KeyVaultManagementController.NewInstance.RunPsTestWorkflow(
                () => { return new[] { string.Format("{0} {1} {2}", "Test-GetVaultByNameAndResourceGroupPositionalParams", _data.preCreatedVault, _data.resourceGroupName) }; },
                (env) => Initialize(),
                null,
                TestUtilities.GetCallingClass(),
                TestUtilities.GetCurrentMethodName()
                );

        }

        [Fact(Skip = "Graph authentication blocks test passes")]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestGetVaultByName()
        {
            KeyVaultManagementController.NewInstance.RunPsTestWorkflow(
                () => { return new[] { string.Format("{0} {1}", "Test-GetVaultByName", _data.preCreatedVault) }; },
                (env) => Initialize(),
                null,
                TestUtilities.GetCallingClass(),
                TestUtilities.GetCurrentMethodName()
                );
        }

        [Fact(Skip = "Graph authentication blocks test passes")]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestGetVaultByNameCapitalized()
        {
            KeyVaultManagementController.NewInstance.RunPsTestWorkflow(
                () => new[] { string.Format("{0} {1}", "Test-GetVaultByName", _data.preCreatedVault.ToUpper()) },
                env => Initialize(),
                null,
                TestUtilities.GetCallingClass(),
                TestUtilities.GetCurrentMethodName()
                );
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestGetUnknownVaultFails()
        {
            KeyVaultManagementController.NewInstance.RunPsTestWorkflow(
                () => { return new[] { string.Format("{0} {1}", "Test-GetUnknownVaultFails", _data.resourceGroupName) }; },
                (env) => Initialize(),
                null,
                TestUtilities.GetCallingClass(),
                TestUtilities.GetCurrentMethodName()
                );

        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestGetVaultFromUnknownResourceGroupFails()
        {
            KeyVaultManagementController.NewInstance.RunPsTestWorkflow(
                () => { return new[] { string.Format("{0} {1}", "Test-GetVaultFromUnknownResourceGroupFails", _data.preCreatedVault) }; },
                (env) => Initialize(),
                null,
                TestUtilities.GetCallingClass(),
                TestUtilities.GetCurrentMethodName()
                );
        }

        #endregion

        #region Get-AzureRmKeyVault (list)

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestListVaultsByResourceGroup()
        {
            KeyVaultManagementController.NewInstance.RunPsTestWorkflow(
                () => { return new[] { string.Format("{0} {1}", "Test-ListVaultsByResourceGroup", _data.resourceGroupName) }; },
                (env) => Initialize(),
                null,
                TestUtilities.GetCallingClass(),
                TestUtilities.GetCurrentMethodName()
                );
        }


        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestListAllVaultsInSubscription()
        {
            KeyVaultManagementController.NewInstance.RunPsTestWorkflow(
                () => { return new[] { "Test-ListAllVaultsInSubscription" }; },
                (env) => Initialize(),
                null,
                TestUtilities.GetCallingClass(),
                TestUtilities.GetCurrentMethodName()
                );
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestListVaultsByTag()
        {
            KeyVaultManagementController.NewInstance.RunPsTestWorkflow(
                () => { return new[] { string.Format("{0} {1} {2}", "Test-ListVaultsByTag", _data.tagName, _data.tagValue) }; },
                (env) => Initialize(),
                null,
                TestUtilities.GetCallingClass(),
                TestUtilities.GetCurrentMethodName()
                );
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestListVaultsByUnknownResourceGroupFails()
        {
            KeyVaultManagementController.NewInstance.RunPsTestWorkflow(
                () => { return new[] { "Test-ListVaultsByUnknownResourceGroupFails" }; },
                (env) => Initialize(),
                null,
                TestUtilities.GetCallingClass(),
                TestUtilities.GetCurrentMethodName()
                );
        }
        #endregion

        #region Remove-AzureRmKeyVault 

        [Fact(Skip = "Graph authentication blocks test passes")]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestDeleteVaultByName()
        {
            KeyVaultManagementController.NewInstance.RunPsTestWorkflow(
                () => { return new[] { string.Format("{0} {1} {2}", "Test-DeleteVaultByName", _data.resourceGroupName, _data.location) }; },
                (env) => Initialize(),
                null,
                TestUtilities.GetCallingClass(),
                TestUtilities.GetCurrentMethodName()
                );
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestDeleteUnknownVaultFails()
        {
            KeyVaultManagementController.NewInstance.RunPsTestWorkflow(
                () => { return new[] { string.Format("{0} ", "Test-DeleteUnknownVaultFails") }; },
                (env) => Initialize(),
                null,
                TestUtilities.GetCallingClass(),
                TestUtilities.GetCurrentMethodName()
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
                    return new[] { string.Format("{0} {1} {2} {3}", "Test-SetRemoveAccessPolicyByObjectId", _data.preCreatedVault, _data.resourceGroupName, objId) };
                },
                (env) =>
                {
                    Initialize();
                    upn = GetUser(env.GetTestEnvironment());
                },
                null,
                TestUtilities.GetCallingClass(),
                TestUtilities.GetCurrentMethodName()
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
                    return new[] { string.Format("{0} {1} {2} {3}", "Test-SetRemoveAccessPolicyByUPN", _data.preCreatedVault, _data.resourceGroupName, upn) };
                },
                (env) =>
                {
                    Initialize();
                    upn = GetUser(env.GetTestEnvironment());
                },
                null,
                TestUtilities.GetCallingClass(),
                TestUtilities.GetCurrentMethodName()
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
                    return new[] { string.Format("{0} {1} {2} {3} {4}", "Test-SetRemoveAccessPolicyByCompoundId", _data.preCreatedVault, _data.resourceGroupName, appId, objId) };
                },
                (env) =>
                {
                    Initialize();
                    upn = GetUser(env.GetTestEnvironment());
                    appId = GetApplicationId(env.GetTestEnvironment(), 1);
                },
                null,
                TestUtilities.GetCallingClass(),
                TestUtilities.GetCurrentMethodName()
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
                    return new[] { string.Format("{0} {1} {2} {3} {4} {5}", "Test-RemoveAccessPolicyWithCompoundIdPolicies", _data.preCreatedVault, _data.resourceGroupName, appId1, appId2, objId) };
                },
                (env) =>
                {
                    Initialize();
                    upn = GetUser(env.GetTestEnvironment());
                    appId1 = GetApplicationId(env.GetTestEnvironment(), 1);
                    appId2 = GetApplicationId(env.GetTestEnvironment(), 2);
                },
                null,
                TestUtilities.GetCallingClass(),
                TestUtilities.GetCurrentMethodName()
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
                    return new[] { string.Format("{0} {1} {2} {3} {4}", "Test-SetCompoundIdAccessPolicy", _data.preCreatedVault, _data.resourceGroupName, appId, objId) };
                },
                (env) =>
                {
                    Initialize();
                    upn = GetUser(env.GetTestEnvironment());
                    appId = GetApplicationId(env.GetTestEnvironment(), 1);
                },
                null,
                TestUtilities.GetCallingClass(),
                TestUtilities.GetCurrentMethodName()
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
                    _data.preCreatedVault,
                    _data.resourceGroupName,
                    principal.ServicePrincipalNames.Where(s => s.StartsWith("http")).FirstOrDefault()) };
            },
            //Initialize
            (env) =>
            {
                Initialize();
            },
            // cleanup
            () =>
            {
                DeleteAdServicePrincipal(controller, principal);
                DeleteAdApp(controller, app);
            },
            TestUtilities.GetCallingClass(),
            TestUtilities.GetCurrentMethodName()
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
                    return new[] { string.Format("{0} {1} {2} {3}", "Test-ModifyAccessPolicy", _data.preCreatedVault, _data.resourceGroupName, objId) };
                },
                (env) =>
                {
                    Initialize();
                    upn = GetUser(env.GetTestEnvironment());
                },
                null,
                TestUtilities.GetCallingClass(),
                TestUtilities.GetCurrentMethodName()
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
                    return new[] { string.Format("{0} {1} {2} {3}", "Test-ModifyAccessPolicyEnabledForDeployment", _data.preCreatedVault, _data.resourceGroupName, upn) };
                },
                (env) =>
                {
                    Initialize();
                    upn = GetUser(env.GetTestEnvironment());
                },
                null,
                TestUtilities.GetCallingClass(),
                TestUtilities.GetCurrentMethodName()
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
                    return new[] { string.Format("{0} {1} {2} {3}", "Test-ModifyAccessPolicyEnabledForTemplateDeployment", _data.preCreatedVault, _data.resourceGroupName, upn) };
                },
                (env) =>
                {
                    Initialize();
                    upn = GetUser(env.GetTestEnvironment());
                },
                null,
                TestUtilities.GetCallingClass(),
                TestUtilities.GetCurrentMethodName()
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
                    return new[] { string.Format("{0} {1} {2} {3}", "Test-ModifyAccessPolicyEnabledForDiskEncryption", _data.preCreatedVault, _data.resourceGroupName, upn) };
                },
                (env) =>
                {
                    Initialize();
                    upn = GetUser(env.GetTestEnvironment());
                },
                null,
                TestUtilities.GetCallingClass(),
                TestUtilities.GetCurrentMethodName()
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
                    return new[] { string.Format("{0} {1} {2} {3}", "Test-ModifyAccessPolicyNegativeCases", _data.preCreatedVault, _data.resourceGroupName, upn) };
                },
                (env) =>
                {
                    Initialize();
                    upn = GetUser(env.GetTestEnvironment());
                },
                null,
                TestUtilities.GetCallingClass(),
                TestUtilities.GetCurrentMethodName()
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
                    return new[] { string.Format("{0} {1} {2} {3}", "Test-RemoveNonExistentAccessPolicyDoesNotThrow", _data.preCreatedVault, _data.resourceGroupName, objId) };
                },
                (env) =>
                {
                    Initialize();
                    upn = GetUser(env.GetTestEnvironment());
                },
                null,
                TestUtilities.GetCallingClass(),
                TestUtilities.GetCurrentMethodName()
                );
        }

        #endregion

        #region Piping
        [Fact(Skip = "Graph authentication blocks test passes")]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestCreateDeleteVaultWithPiping()
        {
            KeyVaultManagementController.NewInstance.RunPsTestWorkflow(
                () => { return new[] { string.Format("{0} {1} {2}", "Test-CreateDeleteVaultWithPiping", _data.resourceGroupName, _data.location) }; },
                (env) => Initialize(),
                null,
                TestUtilities.GetCallingClass(),
                TestUtilities.GetCurrentMethodName()
                );
        }

        #endregion

        #region Helper Methods
        private string GetUser(TestEnvironment environment)
        {
            if (HttpMockServer.GetCurrentMode() == HttpRecorderMode.Record)
            {
                HttpMockServer.Variables["User"] = environment.AuthorizationContext.UserId;
                return environment.AuthorizationContext.UserId;
            }
            else
            {
                return HttpMockServer.Variables["User"];
            }
        }

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

        private Guid GetApplicationId(TestEnvironment environment, int appNum)
        {
            if (appNum < 0)
                throw new ArgumentException("Invalid appNum");
            string variableName = "AppId" + appNum;
            if (HttpMockServer.GetCurrentMode() == HttpRecorderMode.Record)
            {
                Guid appId = Guid.NewGuid();
                HttpMockServer.Variables[variableName] = appId.ToString();
                return appId;
            }
            else
            {
                return new Guid(HttpMockServer.Variables[variableName]);
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

        private User CreateNewAdUser(KeyVaultManagementController controllerAdmin)
        {
            var name = TestUtilities.GenerateName("aduser");
            var parameter = new UserCreateParameters
            {
                DisplayName = name,
                UserPrincipalName = name + "@" + controllerAdmin.UserDomain,
                AccountEnabled = true,
                MailNickname = name + "test",
                PasswordProfile = new PasswordProfile
                {
                    ForceChangePasswordNextLogin = false,
                    Password = TestUtilities.GenerateName("adpass") + "0#$"
                }
            };

            return controllerAdmin.GraphClient.Users.Create(parameter);
        }

        private void DeleteAdUser(KeyVaultManagementController controllerAdmin, User user)
        {
            if (user != null)
            {
                controllerAdmin.GraphClient.Users.Delete(user.ObjectId);
            }
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
