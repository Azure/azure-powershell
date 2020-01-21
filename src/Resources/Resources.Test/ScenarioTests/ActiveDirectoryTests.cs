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

using System.Reflection;
using Microsoft.Azure.Graph.RBAC;
using Microsoft.Azure.Graph.RBAC.Models;
using Microsoft.Azure.ServiceManagement.Common.Models;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using Xunit;
using Xunit.Abstractions;

namespace Microsoft.Azure.Commands.Resources.Test.ScenarioTests
{
    public class ActiveDirectoryTests: ResourceTestRunner
    {
        XunitTracingInterceptor interceptor { get; set; }

        public ActiveDirectoryTests(ITestOutputHelper output) : base(output)
        {
            interceptor = new XunitTracingInterceptor(output);
            XunitTracingInterceptor.AddToContext(interceptor);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestGetAllADGroups()
        {
            const string scriptMethod = "Test-GetAllADGroups";
            ADGroup newGroup = null;
            var controllerAdmin = ResourcesController.NewInstance;

            controllerAdmin.RunPsTestWorkflow(
                interceptor,
                // scriptBuilder
                () =>
                {
                    newGroup = CreateNewAdGroup(controllerAdmin);
                    return new[] { scriptMethod };
                },
                // cleanup
                () =>
                {
                    DeleteAdGroup(controllerAdmin, newGroup);
                },
                MethodBase.GetCurrentMethod().ReflectedType?.ToString(),
                MethodBase.GetCurrentMethod().Name);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestGetADGroupWithSearchString()
        {
            const string scriptMethod = "Test-GetADGroupWithSearchString '{0}'";
            ADGroup newGroup = null;
            var controllerAdmin = ResourcesController.NewInstance;

            controllerAdmin.RunPsTestWorkflow(
                interceptor,
                // scriptBuilder
                () =>
                {
                    newGroup = CreateNewAdGroup(controllerAdmin);
                    return new[] { string.Format(scriptMethod, newGroup.DisplayName) };
                },
                // cleanup
                () =>
                {
                    DeleteAdGroup(controllerAdmin, newGroup);
                },
                MethodBase.GetCurrentMethod().ReflectedType?.ToString(),
                MethodBase.GetCurrentMethod().Name);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestGetADGroupWithBadSearchString()
        {
            TestRunner.RunTestScript("Test-GetADGroupWithBadSearchString");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestGetADGroupWithObjectId()
        {
            const string scriptMethod = "Test-GetADGroupWithObjectId '{0}'";
            ADGroup newGroup = null;
            var controllerAdmin = ResourcesController.NewInstance;

            controllerAdmin.RunPsTestWorkflow(
                interceptor,
                // scriptBuilder
                () =>
                {
                    newGroup = CreateNewAdGroup(controllerAdmin);
                    return new[] { string.Format(scriptMethod, newGroup.ObjectId) };
                },
                // cleanup
                () =>
                {
                    DeleteAdGroup(controllerAdmin, newGroup);
                },
                MethodBase.GetCurrentMethod().ReflectedType?.ToString(),
                MethodBase.GetCurrentMethod().Name);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestGetADGroupSecurityEnabled()
        {
            const string scriptMethod = "Test-GetADGroupSecurityEnabled '{0}' '{1}'";
            ADGroup newGroup = null;
            var controllerAdmin = ResourcesController.NewInstance;

            controllerAdmin.RunPsTestWorkflow(
                interceptor,
                // scriptBuilder
                () =>
                {
                    newGroup = CreateNewAdGroup(controllerAdmin);
                    return new[] { string.Format(scriptMethod, newGroup.ObjectId, newGroup.SecurityEnabled) };
                },
                // cleanup
                () =>
                {
                    DeleteAdGroup(controllerAdmin, newGroup);
                },
                MethodBase.GetCurrentMethod().ReflectedType?.ToString(),
                MethodBase.GetCurrentMethod().Name);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestGetADGroupWithBadObjectId()
        {
            TestRunner.RunTestScript("Test-GetADGroupWithBadObjectId");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestGetADGroupWithUserObjectId()
        {
            const string scriptMethod = "Test-GetADGroupWithUserObjectId '{0}'";
            User newUser = null;
            var controllerAdmin = ResourcesController.NewInstance;

            controllerAdmin.RunPsTestWorkflow(
                interceptor,
                // scriptBuilder
                () =>
                {
                    newUser = CreateNewAdUser(controllerAdmin);
                    return new[] { string.Format(scriptMethod, newUser.ObjectId) };
                },
                // cleanup
                () =>
                {
                    DeleteAdUser(controllerAdmin, newUser);
                },
                MethodBase.GetCurrentMethod().ReflectedType?.ToString(),
                MethodBase.GetCurrentMethod().Name);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestGetADGroupMemberWithGroupObjectId()
        {
            const string scriptMethod = "Test-GetADGroupMemberWithGroupObjectId '{0}' '{1}' '{2}'";
            User newUser = null;
            ADGroup newGroup = null;
            var controllerAdmin = ResourcesController.NewInstance;

            controllerAdmin.RunPsTestWorkflow(
                interceptor,
                // scriptBuilder
                () =>
                {
                    newUser = CreateNewAdUser(controllerAdmin);
                    newGroup = CreateNewAdGroup(controllerAdmin);

                    string memberUrl = string.Format(
                        "{0}{1}/directoryObjects/{2}",
                        controllerAdmin.GraphClient.BaseUri.AbsoluteUri,
                        controllerAdmin.GraphClient.TenantID,
                        newUser.ObjectId);

                    controllerAdmin.GraphClient.Groups.AddMember(newGroup.ObjectId, new GroupAddMemberParameters(memberUrl));

                    return new[] { string.Format(scriptMethod, newGroup.ObjectId, newUser.ObjectId, newUser.DisplayName) };
                },
                // cleanup
                () =>
                {
                    DeleteAdUser(controllerAdmin, newUser);
                    DeleteAdGroup(controllerAdmin, newGroup);
                },
                MethodBase.GetCurrentMethod().ReflectedType?.ToString(),
                MethodBase.GetCurrentMethod().Name);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestGetADGroupMemberWithBadGroupObjectId()
        {
            TestRunner.RunTestScript("Test-GetADGroupMemberWithBadGroupObjectId");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestGetADGroupMemberWithUserObjectId()
        {
            const string scriptMethod = "Test-GetADGroupMemberWithUserObjectId '{0}'";
            User newUser = null;
            var controllerAdmin = ResourcesController.NewInstance;

            controllerAdmin.RunPsTestWorkflow(
                interceptor,
                // scriptBuilder
                () =>
                {
                    newUser = CreateNewAdUser(controllerAdmin);
                    return new[] { string.Format(scriptMethod, newUser.ObjectId) };
                },
                // cleanup
                () =>
                {
                    DeleteAdUser(controllerAdmin, newUser);
                },
                MethodBase.GetCurrentMethod().ReflectedType?.ToString(),
                MethodBase.GetCurrentMethod().Name);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestGetADGroupMemberFromEmptyGroup()
        {
            const string scriptMethod = "Test-GetADGroupMemberFromEmptyGroup '{0}'";
            ADGroup newGroup = null;
            var controllerAdmin = ResourcesController.NewInstance;

            controllerAdmin.RunPsTestWorkflow(
                interceptor,
                // scriptBuilder
                () =>
                {
                    newGroup = CreateNewAdGroup(controllerAdmin);
                    return new[] { string.Format(scriptMethod, newGroup.ObjectId) };
                },
                // cleanup
                () =>
                {
                    DeleteAdGroup(controllerAdmin, newGroup);
                },
                MethodBase.GetCurrentMethod().ReflectedType?.ToString(),
                MethodBase.GetCurrentMethod().Name);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestGetADServicePrincipalWithObjectId()
        {
            const string scriptMethod = "Test-GetADServicePrincipalWithObjectId '{0}'";
            ServicePrincipal newServicePrincipal = null;
            Application app = null;
            var controllerAdmin = ResourcesController.NewInstance;

            controllerAdmin.RunPsTestWorkflow(
                interceptor,
                // scriptBuilder
                () =>
                {
                    app = CreateNewAdApp(controllerAdmin);
                    newServicePrincipal = CreateNewAdServicePrincipal(controllerAdmin, app.AppId);
                    return new[] { string.Format(scriptMethod, newServicePrincipal.ObjectId) };
                },
                // cleanup
                () =>
                {
                    DeleteAdServicePrincipal(controllerAdmin, newServicePrincipal);
                    DeleteAdApp(controllerAdmin, app);
                },
                MethodBase.GetCurrentMethod().ReflectedType?.ToString(),
                MethodBase.GetCurrentMethod().Name);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestGetADServicePrincipalWithBadObjectId()
        {
            TestRunner.RunTestScript("Test-GetADServicePrincipalWithBadObjectId");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestGetADServicePrincipalWithUserObjectId()
        {
            const string scriptMethod = "Test-GetADServicePrincipalWithUserObjectId '{0}'";
            User newUser = null;
            var controllerAdmin = ResourcesController.NewInstance;

            controllerAdmin.RunPsTestWorkflow(
                interceptor,
                // scriptBuilder
                () =>
                {
                    newUser = CreateNewAdUser(controllerAdmin);
                    return new[] { string.Format(scriptMethod, newUser.ObjectId) };
                },
                // cleanup
                () =>
                {
                    DeleteAdUser(controllerAdmin, newUser);
                },
                MethodBase.GetCurrentMethod().ReflectedType?.ToString(),
                MethodBase.GetCurrentMethod().Name);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestGetADServicePrincipalWithSPN()
        {
            const string scriptMethod = "Test-GetADServicePrincipalWithSPN '{0}'";
            ServicePrincipal newServicePrincipal = null;
            Application app = null;
            var controllerAdmin = ResourcesController.NewInstance;

            controllerAdmin.RunPsTestWorkflow(
                interceptor,
                // scriptBuilder
                () =>
                {
                    app = CreateNewAdApp(controllerAdmin);
                    newServicePrincipal = CreateNewAdServicePrincipal(controllerAdmin, app.AppId);
                    return new[] { string.Format(scriptMethod, newServicePrincipal.ServicePrincipalNames[1]) };
                },
                // cleanup
                () =>
                {
                    DeleteAdServicePrincipal(controllerAdmin, newServicePrincipal);
                    DeleteAdApp(controllerAdmin, app);
                },
                MethodBase.GetCurrentMethod().ReflectedType?.ToString(),
                MethodBase.GetCurrentMethod().Name);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestGetADServicePrincipalWithBadSPN()
        {
            TestRunner.RunTestScript("Test-GetADServicePrincipalWithBadSPN");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestGetADServicePrincipalWithSearchString()
        {
            const string scriptMethod = "Test-GetADServicePrincipalWithSearchString '{0}'";
            ServicePrincipal newServicePrincipal = null;
            Application app = null;
            var controllerAdmin = ResourcesController.NewInstance;

            controllerAdmin.RunPsTestWorkflow(
                interceptor,
                // scriptBuilder
                () =>
                {
                    app = CreateNewAdApp(controllerAdmin);
                    newServicePrincipal = CreateNewAdServicePrincipal(controllerAdmin, app.AppId);
                    return new[] { string.Format(scriptMethod, newServicePrincipal.DisplayName) };
                },
                // cleanup
                () =>
                {
                    DeleteAdServicePrincipal(controllerAdmin, newServicePrincipal);
                    DeleteAdApp(controllerAdmin, app);
                },
                MethodBase.GetCurrentMethod().ReflectedType?.ToString(),
                MethodBase.GetCurrentMethod().Name);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestGetADServicePrincipalWithBadSearchString()
        {
            TestRunner.RunTestScript("Test-GetADServicePrincipalWithBadSearchString");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestGetAllADUser()
        {
            const string scriptMethod = "Test-GetAllADUser";
            User newUser = null;
            var controllerAdmin = ResourcesController.NewInstance;

            controllerAdmin.RunPsTestWorkflow(
                interceptor,
                // scriptBuilder
                () =>
                {
                    newUser = CreateNewAdUser(controllerAdmin);
                    return new[] { string.Format(scriptMethod) };
                },
                // cleanup
                () =>
                {
                    DeleteAdUser(controllerAdmin, newUser);
                },
                MethodBase.GetCurrentMethod().ReflectedType?.ToString(),
                MethodBase.GetCurrentMethod().Name);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestGetADUserWithObjectId()
        {
            const string scriptMethod = "Test-GetADUserWithObjectId '{0}'";
            User newUser = null;
            var controllerAdmin = ResourcesController.NewInstance;

            controllerAdmin.RunPsTestWorkflow(
                interceptor,
                // scriptBuilder
                () =>
                {
                    newUser = CreateNewAdUser(controllerAdmin);
                    return new[] { string.Format(scriptMethod, newUser.ObjectId) };
                },
                // cleanup
                () =>
                {
                    DeleteAdUser(controllerAdmin, newUser);
                },
                MethodBase.GetCurrentMethod().ReflectedType?.ToString(),
                MethodBase.GetCurrentMethod().Name);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestGetADUserWithMail()
        {
            const string scriptMethod = "Test-GetADUserWithMail '{0}'";
            User newUser = null;
            var controllerAdmin = ResourcesController.NewInstance;

            controllerAdmin.RunPsTestWorkflow(
                interceptor,
                // scriptBuilder
                () =>
                {
                    newUser = CreateNewAdUser(controllerAdmin);
                    return new[] { string.Format(scriptMethod, newUser.UserPrincipalName) };
                },
                // cleanup
                () =>
                {
                    DeleteAdUser(controllerAdmin, newUser);
                },
                MethodBase.GetCurrentMethod().ReflectedType?.ToString(),
                MethodBase.GetCurrentMethod().Name);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestGetADUserWithBadObjectId()
        {
            TestRunner.RunTestScript("Test-GetADUserWithBadObjectId");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestGetADUserWithGroupObjectId()
        {
            const string scriptMethod = "Test-GetADUserWithGroupObjectId '{0}'";
            ADGroup newGroup = null;
            var controllerAdmin = ResourcesController.NewInstance;

            controllerAdmin.RunPsTestWorkflow(
                interceptor,
                // scriptBuilder
                () =>
                {
                    newGroup = CreateNewAdGroup(controllerAdmin);
                    return new[] { string.Format(scriptMethod, newGroup.ObjectId) };
                },
                // cleanup
                () =>
                {
                    DeleteAdGroup(controllerAdmin, newGroup);
                },
                MethodBase.GetCurrentMethod().ReflectedType?.ToString(),
                MethodBase.GetCurrentMethod().Name);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestGetADUserWithUPN()
        {
            const string scriptMethod = "Test-GetADUserWithUPN '{0}'";
            User newUser = null;
            var controllerAdmin = ResourcesController.NewInstance;

            controllerAdmin.RunPsTestWorkflow(
                interceptor,
                // scriptBuilder
                () =>
                {
                    newUser = CreateNewAdUser(controllerAdmin);
                    return new[] { string.Format(scriptMethod, newUser.UserPrincipalName) };
                },
                // cleanup
                () =>
                {
                    DeleteAdUser(controllerAdmin, newUser);
                },
                MethodBase.GetCurrentMethod().ReflectedType?.ToString(),
                MethodBase.GetCurrentMethod().Name);
        }

        [Fact(Skip = "Currently not working.")]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestGetADUserWithFPOUPN()
        {
            TestRunner.RunTestScript("Test-GetADUserWithFPOUPN");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestGetADUserWithBadUPN()
        {
            TestRunner.RunTestScript("Test-GetADUserWithBadUPN");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestGetADUserWithSearchString()
        {
            const string scriptMethod = "Test-GetADUserWithSearchString '{0}'";
            User newUser = null;
            var controllerAdmin = ResourcesController.NewInstance;

            controllerAdmin.RunPsTestWorkflow(
                interceptor,
                // scriptBuilder
                () =>
                {
                    newUser = CreateNewAdUser(controllerAdmin);
                    return new[] { string.Format(scriptMethod, newUser.DisplayName) };
                },
                // cleanup
                () =>
                {
                    DeleteAdUser(controllerAdmin, newUser);
                },
                MethodBase.GetCurrentMethod().ReflectedType?.ToString(),
                MethodBase.GetCurrentMethod().Name);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestGetADUserWithBadSearchString()
        {
            TestRunner.RunTestScript("Test-GetADUserWithBadSearchString");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestNewADApplication()
        {
            TestRunner.RunTestScript("Test-NewADApplication");
        }

        [Fact(Skip = "Currently not working.")]
        public void TestNewADServicePrincipalWithoutApp()
        {
            TestRunner.RunTestScript("Test-NewADServicePrincipalWithoutApp");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestNewADServicePrincipalWithReaderRole()
        {
            TestRunner.RunTestScript("Test-NewADServicePrincipalWithReaderRole");
        }

        [Fact(Skip = "Currently not working.")]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestNewADServicePrincipalWithCustomScope()
        {
            TestRunner.RunTestScript("Test-NewADServicePrincipalWithCustomScope");
        }
        
        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestCreateDeleteAppCredentials()
        {
            TestRunner.RunTestScript("Test-CreateDeleteAppCredentials");
        }
        
        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestCreateDeleteSpCredentials()
        {
            const string scriptMethod = "Test-CreateDeleteSpCredentials '{0}'";
            Application application = null;
            var controllerAdmin = ResourcesController.NewInstance;

            controllerAdmin.RunPsTestWorkflow(
                interceptor,
                // scriptBuilder
                () =>
                {
                    application = CreateNewAdApp(controllerAdmin);
                    return new[] { string.Format(scriptMethod, application.AppId) };
                },
                // cleanup
                () =>
                {
                    DeleteAdApp(controllerAdmin, application);
                },
                MethodBase.GetCurrentMethod().ReflectedType?.ToString(),
                MethodBase.GetCurrentMethod().Name);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestNewADServicePrincipal()
        {
            const string scriptMethod = "Test-NewADServicePrincipal '{0}'";
            Application application = null;
            var controllerAdmin = ResourcesController.NewInstance;

            controllerAdmin.RunPsTestWorkflow(
                interceptor,
                // scriptBuilder
                () =>
                {
                    application = CreateNewAdApp(controllerAdmin);
                    return new[] { string.Format(scriptMethod, application.AppId) };
                },
                // cleanup
                () =>
                {
                    DeleteAdApp(controllerAdmin, application);
                },
                MethodBase.GetCurrentMethod().ReflectedType?.ToString(),
                MethodBase.GetCurrentMethod().Name);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestRemoveServicePrincipalWithNameNotFound()
        {
            TestRunner.RunTestScript("Test-RemoveServicePrincipalWithNameNotFound");
        }

        private User CreateNewAdUser(ResourcesController controllerAdmin)
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

        private ADGroup CreateNewAdGroup(ResourcesController controllerAdmin)
        {
            var parameter = new GroupCreateParameters
            {
                DisplayName = TestUtilities.GenerateName("adgroup"),
                MailNickname = TestUtilities.GenerateName("adgroupmail")
            };
            return controllerAdmin.GraphClient.Groups.Create(parameter);
        }

        private Application CreateNewAdApp(ResourcesController controllerAdmin)
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

        private ServicePrincipal CreateNewAdServicePrincipal(ResourcesController controllerAdmin, string appId)
        {
            var spParam = new ServicePrincipalCreateParameters
            {
                AppId = appId,
                AccountEnabled = true
            };

            return controllerAdmin.GraphClient.ServicePrincipals.Create(spParam);
        }

        private void DeleteAdUser(ResourcesController controllerAdmin, User user)
        {
            if (user != null)
            {
                controllerAdmin.GraphClient.Users.Delete(user.ObjectId);
            }
        }
        private void DeleteAdGroup(ResourcesController controllerAdmin, ADGroup group)
        {
            if (group != null)
            {
                controllerAdmin.GraphClient.Groups.Delete(group.ObjectId);
            }
        }
        private void DeleteAdApp(ResourcesController controllerAdmin, Application app)
        {
            if (app != null)
            {
                controllerAdmin.GraphClient.Applications.Delete(app.ObjectId);
            }
        }

        private void DeleteAdServicePrincipal(ResourcesController controllerAdmin, ServicePrincipal newServicePrincipal)
        {
            if (newServicePrincipal != null)
            {
                controllerAdmin.GraphClient.ServicePrincipals.Delete(newServicePrincipal.ObjectId);
            }
        }
    }
}