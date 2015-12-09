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


using Microsoft.Azure.Commands.ScenarioTest;
using Microsoft.Azure.Commands.Test.Utilities.Common;
using Microsoft.Azure.Commands.Utilities.Common;
using Microsoft.Azure.Graph.RBAC;
using Microsoft.Azure.Graph.RBAC.Models;
using Microsoft.Azure.Management.Authorization;
using Microsoft.Azure.Management.Resources;
using Microsoft.Azure.Management.Resources.Models;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using System;
using System.Linq;
using Xunit;

namespace Microsoft.Azure.Commands.Resources.Test.ScenarioTests
{
    public class RoleAssignmentTests : RMTestBase
    {
        private const string CallingClass = "Microsoft.Azure.Commands.Resources.Test.ScenarioTests.RoleAssignmentTests";

        [Fact(Skip = "http://vstfrd:8080/Azure/RD/_workitems/edit/4616537")]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void RaAuthorizationChangeLog()
        {
           ResourcesController.NewInstance.RunPsTest(
               CallingClass,
               "RaAuthorizationChangeLog",
               "Test-RaAuthorizationChangeLog");
        }

        [Fact(Skip = "tenantID NullException")]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void RaClassicAdmins()
        {
            ResourcesController.NewInstance.RunPsTest(
                CallingClass,
                "RaClassicAdmins",
                "Test-RaClassicAdmins");
        }

        [Fact(Skip = "tenantID NullException")]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void RaNegativeScenarios()
        {
            ResourcesController.NewInstance.RunPsTest(
                CallingClass,
                "RaNegativeScenarios",
                "Test-RaNegativeScenarios");
        }

        [Fact(Skip = "tenantID NullException")]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void RaByScope()
        {
            ResourcesController.NewInstance.RunPsTest(
                CallingClass,
                "RaByScope",
                "Test-RaByScope");
        }

        [Fact(Skip = "tenantID NullException")]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void RaByResourceGroup()
        {
            ResourcesController.NewInstance.RunPsTest(
                CallingClass,
                "RaByResourceGroup",
                "Test-RaByResourceGroup");
        }

        [Fact(Skip = "tenantID NullException")]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void RaByResource()
        {
            ResourcesController.NewInstance.RunPsTest(
                CallingClass,
                "RaByResource",
                "Test-RaByResource");
        }

        [Fact(Skip = "tenantID NullException")]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void RaByServicePrincipal()
        {
            ResourcesController.NewInstance.RunPsTest(
                CallingClass,
                "RaByServicePrincipal",
                "Test-RaByServicePrincipal");
        }

        [Fact(Skip = "tenantID NullException")]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void RaByUpn()
        {
            ResourcesController.NewInstance.RunPsTest(
                CallingClass,
                "RaByUpn",
                "Test-RaByUpn");
        }

        [Fact(Skip = "Need to re-record test")]
        public void RaUserPermissions()
        {
            User newUser = null;
            ResourceGroup resourceGroup = null;
            string roleAssignmentId = "1BAF0B29-608A-424F-B54F-92FCDB343FFF";
            string userName = null;
            string userPass = null;
            string userPermission = "*/read";
            string roleDefinitionName = "Reader";

            var controllerAdmin = ResourcesController.NewInstance;

            // Generate new user under admin account
            controllerAdmin.RunPsTestWorkflow(
                // scriptBuilder
                () =>
                {
                    userName = TestUtilities.GenerateName("aduser");
                    userPass = TestUtilities.GenerateName("adpass") + "0#$";

                    var upn = userName + "@" + controllerAdmin.UserDomain;
                    
                    var parameter = new UserCreateParameters
                    {
                        UserPrincipalName = upn,
                        DisplayName = userName,
                        AccountEnabled = true,
                        MailNickname = userName + "test",
                        PasswordProfile = new UserCreateParametersPasswordProfile()
                        {
                            ForceChangePasswordNextLogin = false,
                            Password = userPass
                        }
                    };

                    newUser = controllerAdmin.GraphClient.User.Create(parameter);

                    resourceGroup = controllerAdmin.ResourceManagementClient.ResourceGroups
                                        .List(null)
                                        .First();

                    // Wait to allow newly created object changes to propagate
                    TestMockSupport.Delay(20000);

                    return new[] 
                    { 
                        string.Format(
                            "CreateRoleAssignment '{0}' '{1}' '{2}' '{3}'", 
                                roleAssignmentId, 
                                newUser.ObjectId, 
                                roleDefinitionName, 
                                resourceGroup.Name)
                    };
                },
                // initialize
                null,
                // cleanup 
                null,
                CallingClass,
                "RaUserPermissions" + "_Setup");

            // login as different user and run the test
            var controllerUser = ResourcesController.NewInstance;
            controllerUser.RunPsTestWorkflow(
                // scriptBuilder
                () =>
                {
                    return new[] 
                    { 
                        string.Format(
                            "Test-RaUserPermissions '{0}' '{1}'", 
                            resourceGroup.Name, 
                            userPermission) 
                    };
                },
                // initialize
                (testFactory) =>
                {
                    if (newUser != null)
                    {
                        TestEnvironmentFactory.CustomEnvValues[TestEnvironment.UserIdKey] = userName + "@" + controllerAdmin.UserDomain;
                        TestEnvironmentFactory.CustomEnvValues[TestEnvironment.AADPasswordKey] = userPass;
                    }
                },
                // cleanup 
                null,
                CallingClass,
                "RaUserPermissions" + "_Test");

            // remove created user
            controllerAdmin = ResourcesController.NewInstance;
            controllerAdmin.RunPsTestWorkflow(
                // scriptBuilder
                null,
                // initialize
                null,
                // cleanup 
                () =>
                {
                    if (newUser != null)
                    {
                        controllerAdmin.GraphClient.User.Delete(newUser.ObjectId);
                    }
                    controllerAdmin.AuthorizationManagementClient.RoleAssignments.Delete(resourceGroup.Id, roleAssignmentId);
                },
                CallingClass,
                "RaUserPermissions" + "_Cleanup");
        }
    }
}
