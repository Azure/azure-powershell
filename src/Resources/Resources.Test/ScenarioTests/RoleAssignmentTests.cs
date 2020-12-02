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
using Microsoft.Azure.ServiceManagement.Common.Models;
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using System.Linq;
using System.Reflection;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using Xunit;
using Xunit.Abstractions;

namespace Microsoft.Azure.Commands.Resources.Test.ScenarioTests
{
    public class RoleAssignmentTests : ResourceTestRunner
    {
        public XunitTracingInterceptor _logger;

        public RoleAssignmentTests(ITestOutputHelper output) : base(output)
        {
            _logger = new XunitTracingInterceptor(output);
            XunitTracingInterceptor.AddToContext(_logger);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void RaClassicAdmins()
        {
            TestRunner.RunTestScript("Test-RaClassicAdmins");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void RaClassicAdminsWithScope()
        {
            ResourcesController.NewInstance.RunPsTest(_logger, "Test-RaClassicAdminsWithScope");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void RaDeletedPrincipals()
        {
            TestRunner.RunTestScript("Test-RaDeletedPrincipals");
        }

        [Fact(Skip = "Test fails during parallelization. Test uses RoleDefinitionNames statically.")]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void RaPropertiesValidation()
        {
            TestRunner.RunTestScript("Test-RaPropertiesValidation");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void RaNegativeScenarios()
        {
            TestRunner.RunTestScript("Test-RaNegativeScenarios");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void RaByScope()
        {
            TestRunner.RunTestScript("Test-RaByScope");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void RaDeleteByPSRoleAssignment()
        {
            TestRunner.RunTestScript("Test-RaDeleteByPSRoleAssignment");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void RaByResourceGroup()
        {
            TestRunner.RunTestScript("Test-RaByResourceGroup");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void RaByResource()
        {
            TestRunner.RunTestScript("Test-RaByResource");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void RaValidateInputParameters()
        {
            TestRunner.RunTestScript("Test-RaValidateInputParameters Get-AzureRmRoleAssignment");
            TestRunner.RunTestScript("Test-RaValidateInputParameters New-AzureRmRoleAssignment");
            TestRunner.RunTestScript("Test-RaValidateInputParameters Remove-AzureRmRoleAssignment");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void RaByServicePrincipal()
        {
            TestRunner.RunTestScript("Test-RaByServicePrincipal");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void RaById()
        {
            TestRunner.RunTestScript("Test-RaById");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void RaDeletionByScope()
        {
            TestRunner.RunTestScript("Test-RaDeletionByScope");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void RaDeletionByScopeAtRootScope()
        {
            TestRunner.RunTestScript("Test-RaDeletionByScopeAtRootScope");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void RaDelegation()
        {
            TestRunner.RunTestScript("Test-RaDelegation");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void RaByUpn()
        {
            TestRunner.RunTestScript("Test-RaByUpn");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void RaGetByScope()
        {
            TestRunner.RunTestScript("Test-RaGetByScope");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void RaGetOnlyByRoleDefinitionName()
        {
            TestRunner.RunTestScript("Test-RaGetOnlyByRoleDefinitionName");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void RaGetByUPNWithExpandPrincipalGroups()
        {
            TestRunner.RunTestScript("Test-RaGetByUPNWithExpandPrincipalGroups");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void RaCreatedBySP()
        {
            TestRunner.RunTestScript("Test-RaCreatedBySP");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void RaWithV1Conditions()
        {
            TestRunner.RunTestScript("Test-RaWithV1Conditions");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void RaWithV2Conditions()
        {
            TestRunner.RunTestScript("Test-RaWithV2Conditions");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void RaWithV2ConditionsOnly()
        {
            TestRunner.RunTestScript("Test-RaWithV2ConditionsOnly");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void RaWithV2ConditionVersionOnly()
        {
            TestRunner.RunTestScript("Test-RaWithV2ConditionVersionOnly");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void UpdateRa()
        {
            TestRunner.RunTestScript("Test-UpdateRa");
        }

        [Fact(Skip = "Fix the flaky test and token error and then re-record the test. Token from admin user is being used even when trying to use newly created user.")]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
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
                    _logger,
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
                    // cleanup
                    null,
                    MethodBase.GetCurrentMethod().ReflectedType?.ToString(),
                    MethodBase.GetCurrentMethod().Name + "_Setup");

                // login as different user and run the test
                var controllerUser = ResourcesController.NewInstance;
                controllerUser.RunPsTestWorkflow(
                    _logger,
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
                    // cleanup
                    null,
                    MethodBase.GetCurrentMethod().ReflectedType?.ToString(),
                    MethodBase.GetCurrentMethod().Name + "_Test");
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
                            controllerAdmin.AuthorizationManagementClient.RoleAssignments.Delete(resourceGroup.Id, roleAssignmentId).ToString();
                        }
                    },
                    MethodBase.GetCurrentMethod().ReflectedType?.ToString(),
                    MethodBase.GetCurrentMethod().Name + "_Cleanup");
            }
        }
    }
}
