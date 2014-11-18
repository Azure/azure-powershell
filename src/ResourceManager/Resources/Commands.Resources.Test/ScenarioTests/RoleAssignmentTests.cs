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
using Microsoft.Azure.Management.Authorization;
using Microsoft.Azure.Management.Authorization.Models;
using Microsoft.Azure.Management.Resources;
using Microsoft.Azure.Management.Resources.Models;
using Microsoft.Azure.Utilities.HttpRecorder;
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using Microsoft.WindowsAzure.Testing;
using Microsoft.WindowsAzure.Testing.TestCategories;
using System;
using System.Linq;
using Xunit;

namespace Microsoft.Azure.Commands.Resources.Test.ScenarioTests
{
    public class RoleAssignmentTests
    {
        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void RaNegativeScenarios()
        {
            ResourcesController.NewInstance.RunPsTest("Test-RaNegativeScenarios");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void RaByScope()
        {
            ResourcesController.NewInstance.RunPsTest("Test-RaByScope");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void RaByResourceGroup()
        {
            ResourcesController.NewInstance.RunPsTest("Test-RaByResourceGroup");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void RaByResource()
        {
            ResourcesController.NewInstance.RunPsTest("Test-RaByResource");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void RaByServicePrincipal()
        {
            ResourcesController.NewInstance.RunPsTest("Test-RaByServicePrincipal");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void RaByUpn()
        {
            ResourcesController.NewInstance.RunPsTest("Test-RaByUpn");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void RaUserPermissions()
        {
            User newUser = null;
            ResourceGroup resourceGroup = null;
            string roleAssignmentId = "6A26D717-ABA9-44E3-B971-C53694E413B2";
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
                        PasswordProfileSettings = new UserCreateParameters.PasswordProfile
                        {
                            ForceChangePasswordNextLogin = false,
                            Password = userPass
                        }
                    };

                    newUser = controllerAdmin.GraphClient.User.Create(parameter).User;

                    resourceGroup = controllerAdmin.ResourceManagementClient.ResourceGroups
                                        .List(new ResourceGroupListParameters())
                                        .ResourceGroups
                                        .First();

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
                TestUtilities.GetCallingClass(),
                TestUtilities.GetCurrentMethodName() + "_Setup");

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
                        testFactory.CustomEnvValues[TestEnvironment.UserIdKey] = userName + "@" + controllerAdmin.UserDomain;
                        testFactory.CustomEnvValues[TestEnvironment.AADPasswordKey] = userPass;
                    }
                },
                // cleanup 
                null,
                TestUtilities.GetCallingClass(),
                TestUtilities.GetCurrentMethodName() + "_Test");

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
                    controllerAdmin.AuthorizationManagementClient.RoleAssignments.Delete(resourceGroup.Id, new Guid(roleAssignmentId));
                },
                TestUtilities.GetCallingClass(),
                TestUtilities.GetCurrentMethodName() + "_Cleanup");
        }
    }
}
