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
using Microsoft.Azure.Management.ResourceManager;
using Microsoft.Azure.Management.ResourceManager.Models;
using Microsoft.Azure.ServiceManagemenet.Common.Models;
using Microsoft.Azure.Test;
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using Microsoft.WindowsAzure.Commands.Test.Utilities.Common;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using System;
using System.Linq;
using Xunit;
using Xunit.Abstractions;

namespace Microsoft.Azure.Commands.Resources.Test.ScenarioTests
{
    public class RoleAssignmentTests : RMTestBase
    {
        public RoleAssignmentTests(ITestOutputHelper output)
        {
            XunitTracingInterceptor.AddToContext(new XunitTracingInterceptor(output));
        }

        [Fact(Skip = "Test is failing in CI build for no matching request found but passes locally.")]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void RaAuthorizationChangeLog()
        {
           ResourcesController.NewInstance.RunPsTest("Test-RaAuthorizationChangeLog");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void RaClassicAdmins()
        {
            ResourcesController.NewInstance.RunPsTest("Test-RaClassicAdmins");
        }

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
        public void RaValidateInputParameters()
        {
            var instance = ResourcesController.NewInstance;
            instance.RunPsTest("Test-RaValidateInputParameters Get-AzureRmRoleAssignment");
            instance.RunPsTest("Test-RaValidateInputParameters New-AzureRmRoleAssignment");
            instance.RunPsTest("Test-RaValidateInputParameters Remove-AzureRmRoleAssignment");
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

        [Fact(Skip = "Fix the flaky test and token error and then re-record the test. Token from admin user is being used even when trying to use newly created user.")]
        public void RaUserPermissions()
        {
            User newUser = null;
            ResourceGroup resourceGroup = null;
            string roleAssignmentId = "A807281A-2F74-44B9-B862-C0D3683ADCC9";
            string userName = null;
            string userPass = null;
            string userPermission = "*/read";
            string roleDefinitionName = "Reader";
            string newUserObjectId = null;

            var controllerAdmin = ResourcesController.NewInstance;

            try
            {
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
                            PasswordProfile = new PasswordProfile
                            {
                                ForceChangePasswordNextLogin = false,
                                Password = userPass
                            }
                        };

                        newUser = controllerAdmin.GraphClient.Users.Create(parameter);
                        newUserObjectId = newUser.ObjectId;

                        resourceGroup = controllerAdmin.ResourceManagementClient.ResourceGroups
                                            .List()
                                            .First();

                    // Wait to allow newly created object changes to propagate
                    TestMockSupport.Delay(20000);

                        return new[]
                        {
                        string.Format(
                            "CreateRoleAssignment '{0}' '{1}' '{2}' '{3}'",
                                roleAssignmentId,
                                newUserObjectId,
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
                    // Wait to allow for the role assignment to propagate
                    TestMockSupport.Delay(20000);

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
            }
            finally
            {
                // remove created user and assignment
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
                            controllerAdmin.GraphClient.Users.Delete(newUser.ObjectId);
                        }

                        if (resourceGroup != null)
                        {
                            controllerAdmin.AuthorizationManagementClient.RoleAssignments.Delete(resourceGroup.Id, new Guid(roleAssignmentId));
                        }                        
                    },
                    TestUtilities.GetCallingClass(),
                    TestUtilities.GetCurrentMethodName() + "_Cleanup");
            }                       
        }
    }
}
