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
using Microsoft.Azure.ServiceManagement.Common.Models;
using Microsoft.Azure.Commands.Common.MSGraph.Version1_0.Users;
using Microsoft.Azure.Commands.Common.MSGraph.Version1_0.Applications;
using Microsoft.Azure.Commands.Common.MSGraph.Version1_0.Applications.Models;

namespace Microsoft.Azure.Commands.KeyVault.Test.ScenarioTests
{
    public class KeyVaultManagementTests : KeyVaultTestRunner
    {
        public KeyVaultManagementTests(Xunit.Abstractions.ITestOutputHelper output) : base(output)
        {
        }

        #region New-AzureKeyVault

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestCreateNewVault()
        {
            TestRunner.RunTestScript("Test-CreateNewVault");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestPublicNetworkAccessWhenCreateNewVault()
        {
            TestRunner.RunTestScript("Test-PublicNetworkAccessWhenCreateNewVault");
        }

        #endregion

        #region Get-AzureRmKeyVault

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestGetVault()
        {
            TestRunner.RunTestScript("Test-GetVault");
        }

        #endregion

        #region Update-AzKeyVault
        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestUpdateVault()
        {
            TestRunner.RunTestScript("Test-UpdateKeyVault");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestUpdateKeyVaultWithPublicNetworkAccess()
        {
            TestRunner.RunTestScript("Test-UpdateKeyVaultWithPublicNetworkAccess");
        }
        #endregion

        #region Get-AzureRmKeyVault (list)

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestListVaults()
        {
            TestRunner.RunTestScript("Test-ListVaults");
        }

        #endregion

        #region Remove-AzureRmKeyVault

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestDeleteVault()
        {
            TestRunner.RunTestScript("Test-DeleteVaultByName");
        }

        #endregion

        #region Set-AzureRmKeyVaultAccessPolicy & Remove-AzureRmKeyVaultAccessPolicy

        [Fact(Skip = "Graph authentication blocks test passes, will be updated with TestRunner")]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestSetRemoveAccessPolicyByObjectId()
        {
            //string upn = "";

            //KeyVaultManagementController controller = KeyVaultManagementController.NewInstance;
            //controller.RunPsTestWorkflow(
            //    _logger,
            //    () =>
            //    {
            //        var objId = GetUserObjectId(controller, upn);
            //        return new[] { string.Format("{0} {1} {2} {3}", "Test-SetRemoveAccessPolicyByObjectId", _data.PreCreatedVault, _data.ResourceGroupName, objId) };
            //    },
            //    null,
            //    MethodBase.GetCurrentMethod().ReflectedType?.ToString(),
            //    MethodBase.GetCurrentMethod().Name
            //    );
        }

        [Fact(Skip = "Graph authentication blocks test passes, will be updated with TestRunner")]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestSetRemoveAccessPolicyByUPN()
        {
            //string upn = "";
            //KeyVaultManagementController.NewInstance.RunPsTestWorkflow(
            //    _logger,
            //    () =>
            //    {
            //        return new[] { string.Format("{0} {1} {2} {3}", "Test-SetRemoveAccessPolicyByUPN", _data.PreCreatedVault, _data.ResourceGroupName, upn) };
            //    },
            //    null,
            //    MethodBase.GetCurrentMethod().ReflectedType?.ToString(),
            //    MethodBase.GetCurrentMethod().Name
            //    );
        }

        [Fact(Skip = "Graph authentication blocks test passes, will be updated with TestRunner")]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestSetRemoveAccessPolicyByCompoundId()
        {
            //string upn = "";
            //Guid? appId = null;

            //KeyVaultManagementController controller = KeyVaultManagementController.NewInstance;
            //controller.RunPsTestWorkflow(
            //    _logger,
            //    () =>
            //    {
            //        var objId = GetUserObjectId(controller, upn);
            //        return new[] { string.Format("{0} {1} {2} {3} {4}", "Test-SetRemoveAccessPolicyByCompoundId", _data.PreCreatedVault, _data.ResourceGroupName, appId, objId) };
            //    },
            //    null,
            //    MethodBase.GetCurrentMethod().ReflectedType?.ToString(),
            //    MethodBase.GetCurrentMethod().Name
            //    );
        }

        [Fact(Skip = "Graph authentication blocks test passes, will be updated with TestRunner")]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestRemoveAccessPolicyWithCompoundIdPolicies()
        {
            //string upn = "";

            //Guid? appId1 = null;
            //Guid? appId2 = null;

            //KeyVaultManagementController controller = KeyVaultManagementController.NewInstance;
            //controller.RunPsTestWorkflow(
            //    _logger,
            //    () =>
            //    {
            //        var objId = GetUserObjectId(controller, upn);
            //        return new[] { string.Format("{0} {1} {2} {3} {4} {5}", "Test-RemoveAccessPolicyWithCompoundIdPolicies", _data.PreCreatedVault, _data.ResourceGroupName, appId1, appId2, objId) };
            //    },
            //    null,
            //    MethodBase.GetCurrentMethod().ReflectedType?.ToString(),
            //    MethodBase.GetCurrentMethod().Name
            //    );
        }

        [Fact(Skip = "Graph authentication blocks test passes, will be updated with TestRunner")]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestSetCompoundIdAccessPolicy()
        {
            //string upn = "";
            //Guid? appId = null;

            //KeyVaultManagementController controller = KeyVaultManagementController.NewInstance;
            //controller.RunPsTestWorkflow(
            //    _logger,
            //    () =>
            //    {
            //        var objId = GetUserObjectId(controller, upn);
            //        return new[] { string.Format("{0} {1} {2} {3} {4}", "Test-SetCompoundIdAccessPolicy", _data.PreCreatedVault, _data.ResourceGroupName, appId, objId) };
            //    },
            //    null,
            //    MethodBase.GetCurrentMethod().ReflectedType?.ToString(),
            //    MethodBase.GetCurrentMethod().Name
            //    );
        }

        [Fact(Skip = "Graph authentication blocks test passes, will be updated with TestRunner")]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestSetRemoveAccessPolicyBySPN()
        {
            //MicrosoftGraphApplication app = null;
            //MicrosoftGraphServicePrincipal principal = null;

            //KeyVaultManagementController controller = KeyVaultManagementController.NewInstance;
            //controller.RunPsTestWorkflow(
            //    _logger,
            ////script builder
            //() =>
            //{
            //    app = CreateNewAdApp(controller);
            //    principal = CreateNewAdServicePrincipal(controller, app.AppId);
            //    return new[] { string.Format("{0} {1} {2} {3}", "Test-SetRemoveAccessPolicyBySPN",
            //         _data.PreCreatedVault,
            //         _data.ResourceGroupName,
            //         principal.ServicePrincipalNames.Where(s => s.StartsWith("http")).FirstOrDefault()) };
            //},
            //// cleanup
            //() =>
            //{
            //    DeleteAdServicePrincipal(controller, principal);
            //    DeleteAdApp(controller, app);
            //},
            //MethodBase.GetCurrentMethod().ReflectedType?.ToString(),
            //MethodBase.GetCurrentMethod().Name
            //);
        }

        [Fact(Skip = "Graph authentication blocks test passes, will be updated with TestRunner")]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestModifyAccessPolicy()
        {
            //string upn = "";

            //KeyVaultManagementController controller = KeyVaultManagementController.NewInstance;

            //controller.RunPsTestWorkflow(
            //    _logger,
            //    () =>
            //    {

            //        var objId = GetUserObjectId(controller, upn);
            //        return new[] { string.Format("{0} {1} {2} {3}", "Test-ModifyAccessPolicy", _data.PreCreatedVault, _data.ResourceGroupName, objId) };
            //    },
            //    null,
            //    MethodBase.GetCurrentMethod().ReflectedType?.ToString(),
            //    MethodBase.GetCurrentMethod().Name
            //    );
        }

        [Fact(Skip = "Graph authentication blocks test passes, will be updated with TestRunner")]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestModifyAccessPolicyEnabledForDeployment()
        {
            //string upn = "";

            //KeyVaultManagementController.NewInstance.RunPsTestWorkflow(
            //    _logger,
            //    () =>
            //    {
            //        return new[] { string.Format("{0} {1} {2} {3}", "Test-ModifyAccessPolicyEnabledForDeployment", _data.PreCreatedVault, _data.ResourceGroupName, upn) };
            //    },
            //    null,
            //    MethodBase.GetCurrentMethod().ReflectedType?.ToString(),
            //    MethodBase.GetCurrentMethod().Name
            //    );
        }


        [Fact(Skip = "Graph authentication blocks test passes, will be updated with TestRunner")]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestModifyAccessPolicyEnabledForTemplateDeployment()
        {
            //string upn = "";

            //KeyVaultManagementController.NewInstance.RunPsTestWorkflow(
            //    _logger,
            //    () =>
            //    {
            //        return new[] { string.Format("{0} {1} {2} {3}", "Test-ModifyAccessPolicyEnabledForTemplateDeployment", _data.PreCreatedVault, _data.ResourceGroupName, upn) };
            //    },
            //    null,
            //    MethodBase.GetCurrentMethod().ReflectedType?.ToString(),
            //    MethodBase.GetCurrentMethod().Name
            //    );
        }

        [Fact(Skip = "Graph authentication blocks test passes, will be updated with TestRunner")]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestModifyAccessPolicyEnabledForDiskEncryption()
        {
            //string upn = "";

            //KeyVaultManagementController.NewInstance.RunPsTestWorkflow(
            //    _logger,
            //    () =>
            //    {
            //        return new[] { string.Format("{0} {1} {2} {3}", "Test-ModifyAccessPolicyEnabledForDiskEncryption", _data.PreCreatedVault, _data.ResourceGroupName, upn) };
            //    },
            //    null,
            //    MethodBase.GetCurrentMethod().ReflectedType?.ToString(),
            //    MethodBase.GetCurrentMethod().Name
            //    );
        }


        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestModifyAccessPolicyNegativeCases()
        {
            TestRunner.RunTestScript("Test-ModifyAccessPolicyNegativeCases");
        }

        [Fact(Skip = "Graph authentication blocks test passes, will be updated with TestRunner")]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestRemoveNonExistentAccessPolicyDoesNotThrow()
        {
            //string upn = "";

            //KeyVaultManagementController controller = KeyVaultManagementController.NewInstance;
            //controller.RunPsTestWorkflow(
            //    _logger,
            //    () =>
            //    {
            //        var objId = GetUserObjectId(controller, upn);
            //        return new[] { string.Format("{0} {1} {2} {3}", "Test-RemoveNonExistentAccessPolicyDoesNotThrow", _data.PreCreatedVault, _data.ResourceGroupName, objId) };
            //    },
            //    null,
            //    MethodBase.GetCurrentMethod().ReflectedType?.ToString(),
            //    MethodBase.GetCurrentMethod().Name
            //    );
        }

        #endregion

        #region Piping
        [Fact(Skip = "Graph authentication blocks test passes")]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestCreateDeleteVaultWithPiping()
        {
            TestRunner.RunTestScript(string.Format("{0} {1} {2}", "Test-CreateDeleteVaultWithPiping", base.ResourceGroupName, base.Location));
        }

        #endregion

        #region Helper Methods
        //private string GetUserObjectId(KeyVaultManagementController controllerAdmin, string upn)
        //{
        //    if (HttpMockServer.GetCurrentMode() == HttpRecorderMode.Record)
        //    {
        //        var user = controllerAdmin.GraphClient.Users.GetUser(upn);
        //        HttpMockServer.Variables["ObjectId"] = user.Id;
        //        return user.Id;
        //    }
        //    else
        //    {
        //        return HttpMockServer.Variables["ObjectId"];
        //    }
        //}

        //private MicrosoftGraphApplication CreateNewAdApp(KeyVaultManagementController controllerAdmin)
        //{
        //    var appName = TestUtilities.GenerateName("adApplication");
        //    var url = string.Format("http://{0}/home", appName);
        //    var app = new MicrosoftGraphApplication()
        //    {
        //        DisplayName = appName,
        //        IdentifierUris = new[] { url }
        //    };

        //    return controllerAdmin.GraphClient.Applications.CreateApplication(app);
        //}

        //private MicrosoftGraphServicePrincipal CreateNewAdServicePrincipal(KeyVaultManagementController controllerAdmin, string appId)
        //{
        //    var sp = new MicrosoftGraphServicePrincipal
        //    {
        //        AppId = appId,
        //        AccountEnabled = true
        //    };

        //    return controllerAdmin.GraphClient.ServicePrincipals.CreateServicePrincipal(sp);
        //}

        //private void DeleteAdApp(KeyVaultManagementController controllerAdmin, MicrosoftGraphApplication app)
        //{
        //    if (app != null)
        //    {
        //        controllerAdmin.GraphClient.Applications.DeleteApplication(app.Id);
        //    }
        //}

        //private void DeleteAdServicePrincipal(KeyVaultManagementController controllerAdmin, MicrosoftGraphServicePrincipal newServicePrincipal)
        //{
        //    if (newServicePrincipal != null)
        //    {
        //        controllerAdmin.GraphClient.ServicePrincipals.DeleteServicePrincipal(newServicePrincipal.Id);
        //    }
        //}
        #endregion
    }
}
