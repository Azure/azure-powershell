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
using System.Linq;
using Microsoft.Azure.Graph.RBAC;
using Microsoft.Azure.Graph.RBAC.Models;
using Microsoft.Azure.Management.Authorization;
using Microsoft.Azure.Management.Resources;
using Microsoft.Azure.Management.Resources.Models;
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using Microsoft.Azure.Test;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using Xunit;
using Microsoft.WindowsAzure.Commands.Test.Utilities.Common;

namespace Microsoft.Azure.Commands.Resources.Test.ScenarioTests
{
    public class RoleAssignmentTests : RMTestBase
    {
        [Fact(Skip = "http://vstfrd:8080/Azure/RD/_workitems/edit/4616537")]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void RaAuthorizationChangeLog()
        {
           ResourcesController.NewInstance.RunPsTest("Test-RaAuthorizationChangeLog");
        }

        [Fact(Skip = "Need to re-record test")]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void RaClassicAdmins()
        {
            ResourcesController.NewInstance.RunPsTest("Test-RaClassicAdmins");
        }

        [Fact(Skip = "Need to re-record test")]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void RaNegativeScenarios()
        {
            ResourcesController.NewInstance.RunPsTest("Test-RaNegativeScenarios");
        }

        [Fact(Skip = "Need to re-record test")]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void RaByScope()
        {
            ResourcesController.NewInstance.RunPsTest("Test-RaByScope");
        }

        [Fact(Skip = "Need to re-record test")]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void RaByResourceGroup()
        {
            ResourcesController.NewInstance.RunPsTest("Test-RaByResourceGroup");
        }

        [Fact(Skip = "Need to re-record test")]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void RaByResource()
        {
            ResourcesController.NewInstance.RunPsTest("Test-RaByResource");
        }

        [Fact(Skip = "PSGet Migration: TODO: Get-AzureRmSubscription")]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void RaByServicePrincipal()
        {
            ResourcesController.NewInstance.RunPsTest("Test-RaByServicePrincipal");
        }

        [Fact(Skip = "Need to re-record test")]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void RaByUpn()
        {
            ResourcesController.NewInstance.RunPsTest("Test-RaByUpn");
        }

        [Fact(Skip="Need to re-record test")]
        public void RaUserPermissions()
        {
            User newUser = null;
            ResourceGroupExtended resourceGroup = null;
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
