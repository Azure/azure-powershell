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

using Microsoft.Azure.Commands.Resources.Models.Authorization;
using Microsoft.Azure.Management.Authorization.Models;
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Microsoft.Azure.Commands.Resources.Test.UnitTests.Authorization
{
    public class AuthorizationClientExtensionsTests
    {
        #region Helper Methods

        private static RoleDefinition CreateRoleDefinition(
            string id,
            string roleName,
            string roleType,
            List<Permission> permissions,
            string description = "Test role")
        {
            var guid = id.Split('/').Last();
            return new RoleDefinition(
                id: id,
                name: guid,
                type: "Microsoft.Authorization/roleDefinitions",
                roleName: roleName,
                description: description,
                roleType: roleType,
                permissions: permissions,
                assignableScopes: ["/"]
            );
        }

        private static Permission CreatePermission(
            List<string> actions = null,
            List<string> notActions = null,
            List<string> dataActions = null,
            List<string> notDataActions = null,
            string condition = null,
            string conditionVersion = null)
        {
            return new Permission(
                actions: actions ?? [],
                notActions: notActions ?? [],
                dataActions: dataActions ?? [],
                notDataActions: notDataActions ?? [],
                condition: condition,
                conditionVersion: conditionVersion);
        }

        #endregion

        #region ToPSRoleDefinition - Null handling

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void ToPSRoleDefinition_NullRole_ReturnsNull()
        {
            RoleDefinition roleDefinition = null;
            Assert.Null(roleDefinition.ToPSRoleDefinition());
        }

        #endregion

        #region ToPSRoleDefinition - Role Type Tests

        [Theory]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [InlineData("BuiltInRole", false)]
        [InlineData("CustomRole", true)]
        public void ToPSRoleDefinition_RoleType_SetsIsCustomCorrectly(string roleType, bool expectedIsCustom)
        {
            var roleDefinition = CreateRoleDefinition(
                id: "/providers/Microsoft.Authorization/roleDefinitions/12345678-1234-1234-1234-123456789012",
                roleName: "Test Role",
                roleType: roleType,
                permissions: [CreatePermission(actions: ["*/read"])]
            );

            var result = roleDefinition.ToPSRoleDefinition();

            Assert.Equal(expectedIsCustom, result.IsCustom);
        }

        #endregion

        #region ToPSRoleDefinition - ID Extraction Tests

        [Theory]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [InlineData("/providers/Microsoft.Authorization/roleDefinitions/acdd72a7-3385-48ef-bd42-f606fba81ae7", "acdd72a7-3385-48ef-bd42-f606fba81ae7")]
        [InlineData("/subscriptions/00000000-0000-0000-0000-000000000000/providers/Microsoft.Authorization/roleDefinitions/11111111-1111-1111-1111-111111111111", "11111111-1111-1111-1111-111111111111")]
        public void ToPSRoleDefinition_ExtractsIdFromFullyQualifiedPath(string fullId, string expectedId)
        {
            var roleDefinition = CreateRoleDefinition(
                id: fullId,
                roleName: "Test Role",
                roleType: "BuiltInRole",
                permissions: [CreatePermission(actions: ["*/read"])]
            );

            var result = roleDefinition.ToPSRoleDefinition();

            Assert.Equal(expectedId, result.Id);
        }

        #endregion

        #region ToPSRoleDefinition - Permission Structure Tests

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void ToPSRoleDefinition_SinglePermission_PreservesAllActionTypes()
        {
            var roleDefinition = CreateRoleDefinition(
                id: "/providers/Microsoft.Authorization/roleDefinitions/12345678-1234-1234-1234-123456789012",
                roleName: "Full Permission Role",
                roleType: "CustomRole",
                permissions:
                [
                    CreatePermission(
                        actions: ["Microsoft.Storage/*/read", "Microsoft.Compute/*/read"],
                        notActions: ["Microsoft.Storage/storageAccounts/delete"],
                        dataActions: ["Microsoft.Storage/storageAccounts/blobServices/containers/blobs/read"],
                        notDataActions: ["Microsoft.Storage/storageAccounts/blobServices/containers/blobs/delete"])
                ]
            );

            var result = roleDefinition.ToPSRoleDefinition();

            Assert.Single(result.Permissions);
            var perm = result.Permissions[0];
            Assert.Equal(2, perm.Actions.Count);
            Assert.Single(perm.NotActions);
            Assert.Single(perm.DataActions);
            Assert.Single(perm.NotDataActions);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void ToPSRoleDefinition_MultiplePermissions_PreservesAllPermissions()
        {
            var roleDefinition = CreateRoleDefinition(
                id: "/providers/Microsoft.Authorization/roleDefinitions/95dd08a6-00bd-4661-84bf-f6726f83a4d0",
                roleName: "Azure Container Storage Contributor",
                roleType: "BuiltInRole",
                permissions:
                [
                    CreatePermission(
                        actions:
                        [
                            "Microsoft.KubernetesConfiguration/extensions/write",
                            "Microsoft.KubernetesConfiguration/extensions/read",
                            "Microsoft.Authorization/*/read"
                        ]),
                    CreatePermission(
                        actions:
                        [
                            "Microsoft.Authorization/roleAssignments/write",
                            "Microsoft.Authorization/roleAssignments/delete"
                        ],
                        condition: "((!(ActionMatches{'Microsoft.Authorization/roleAssignments/write'})))",
                        conditionVersion: "2.0")
                ]
            );

            var result = roleDefinition.ToPSRoleDefinition();

            Assert.Equal(2, result.Permissions.Count);
            
            // First permission - no condition
            Assert.Equal(3, result.Permissions[0].Actions.Count);
            Assert.Null(result.Permissions[0].Condition);
            Assert.Null(result.Permissions[0].ConditionVersion);
            
            // Second permission - with condition
            Assert.Equal(2, result.Permissions[1].Actions.Count);
            Assert.NotNull(result.Permissions[1].Condition);
            Assert.Equal("2.0", result.Permissions[1].ConditionVersion);
        }

        #endregion

        #region ToPSRoleDefinition - Condition Tests

        [Theory]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [InlineData(null, null)]
        [InlineData("((!(ActionMatches{'Microsoft.Authorization/roleAssignments/write'})))", "2.0")]
        public void ToPSRoleDefinition_ConditionAndVersion_PreservedCorrectly(string condition, string conditionVersion)
        {
            var roleDefinition = CreateRoleDefinition(
                id: "/providers/Microsoft.Authorization/roleDefinitions/12345678-1234-1234-1234-123456789012",
                roleName: "Test Role",
                roleType: "BuiltInRole",
                permissions:
                [
                    CreatePermission(
                        actions: ["Microsoft.Authorization/roleAssignments/write"],
                        condition: condition,
                        conditionVersion: conditionVersion)
                ]
            );

            var result = roleDefinition.ToPSRoleDefinition();

            Assert.Single(result.Permissions);
            Assert.Equal(condition, result.Permissions[0].Condition);
            Assert.Equal(conditionVersion, result.Permissions[0].ConditionVersion);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void ToPSRoleDefinition_ConditionOnlyOnSecondPermission_PreservesCorrectAssociation()
        {
            // This is the key bug fix test: condition should stay with its permission
            var roleDefinition = CreateRoleDefinition(
                id: "/providers/Microsoft.Authorization/roleDefinitions/95dd08a6-00bd-4661-84bf-f6726f83a4d0",
                roleName: "Azure Container Storage Contributor",
                roleType: "BuiltInRole",
                permissions:
                [
                    CreatePermission(actions: ["Microsoft.KubernetesConfiguration/extensions/write"]),
                    CreatePermission(
                        actions: ["Microsoft.Authorization/roleAssignments/write"],
                        condition: "ABAC condition here",
                        conditionVersion: "2.0")
                ]
            );

            var result = roleDefinition.ToPSRoleDefinition();

            // The condition must be on the SECOND permission, not flattened or on the first
            Assert.Null(result.Permissions[0].Condition);
            Assert.Null(result.Permissions[0].ConditionVersion);
            Assert.Equal("ABAC condition here", result.Permissions[1].Condition);
            Assert.Equal("2.0", result.Permissions[1].ConditionVersion);
            
            // Also verify actions are correctly associated
            Assert.Contains("Microsoft.KubernetesConfiguration/extensions/write", result.Permissions[0].Actions);
            Assert.Contains("Microsoft.Authorization/roleAssignments/write", result.Permissions[1].Actions);
        }

        #endregion

        #region PSPermission Tests

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void PSPermission_AllProperties_CanBeSetAndRetrieved()
        {
            var permission = new PSPermission
            {
                Actions = ["action1", "action2"],
                NotActions = ["notAction1"],
                DataActions = ["dataAction1"],
                NotDataActions = ["notDataAction1"],
                Condition = "test condition",
                ConditionVersion = "2.0"
            };

            Assert.Equal(2, permission.Actions.Count);
            Assert.Single(permission.NotActions);
            Assert.Single(permission.DataActions);
            Assert.Single(permission.NotDataActions);
            Assert.Equal("test condition", permission.Condition);
            Assert.Equal("2.0", permission.ConditionVersion);
        }

        #endregion

        #region Known Azure Role Tests

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void ToPSRoleDefinition_ReaderRole_CorrectlyConverted()
        {
            var roleDefinition = CreateRoleDefinition(
                id: "/providers/Microsoft.Authorization/roleDefinitions/acdd72a7-3385-48ef-bd42-f606fba81ae7",
                roleName: "Reader",
                roleType: "BuiltInRole",
                permissions: [CreatePermission(actions: ["*/read"])],
                description: "View all resources, but does not allow you to make any changes."
            );

            var result = roleDefinition.ToPSRoleDefinition();

            Assert.Equal("Reader", result.Name);
            Assert.Equal("acdd72a7-3385-48ef-bd42-f606fba81ae7", result.Id);
            Assert.False(result.IsCustom);
            Assert.Single(result.Permissions);
            Assert.Single(result.Permissions[0].Actions);
            Assert.Equal("*/read", result.Permissions[0].Actions[0]);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void ToPSRoleDefinition_KeyVaultDataAccessAdministrator_HasCondition()
        {
            var roleDefinition = CreateRoleDefinition(
                id: "/providers/Microsoft.Authorization/roleDefinitions/8b54135c-b56d-4d72-a534-26097cfdc8d8",
                roleName: "Key Vault Data Access Administrator",
                roleType: "BuiltInRole",
                permissions:
                [
                    CreatePermission(
                        actions:
                        [
                            "Microsoft.Authorization/roleAssignments/write",
                            "Microsoft.Authorization/roleAssignments/delete"
                        ],
                        condition: "((!(ActionMatches{'Microsoft.Authorization/roleAssignments/write'})) OR ...)",
                        conditionVersion: "2.0")
                ]
            );

            var result = roleDefinition.ToPSRoleDefinition();

            Assert.Single(result.Permissions);
            Assert.NotNull(result.Permissions[0].Condition);
            Assert.Equal("2.0", result.Permissions[0].ConditionVersion);
        }

        #endregion

        #region Edge Case Tests

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void ToPSRoleDefinition_NullPermissions_ReturnsNullPermissionsList()
        {
            var roleDefinition = new RoleDefinition(
                id: "/providers/Microsoft.Authorization/roleDefinitions/12345678-1234-1234-1234-123456789012",
                name: "12345678-1234-1234-1234-123456789012",
                type: "Microsoft.Authorization/roleDefinitions",
                roleName: "Test Role",
                description: "Test",
                roleType: "CustomRole",
                permissions: null,
                assignableScopes: ["/"]
            );

            var result = roleDefinition.ToPSRoleDefinition();

            Assert.Null(result.Permissions);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void ToPSRoleDefinition_EmptyPermissionsList_ReturnsEmptyList()
        {
            var roleDefinition = CreateRoleDefinition(
                id: "/providers/Microsoft.Authorization/roleDefinitions/12345678-1234-1234-1234-123456789012",
                roleName: "Test Role",
                roleType: "CustomRole",
                permissions: []
            );

            var result = roleDefinition.ToPSRoleDefinition();

            Assert.NotNull(result.Permissions);
            Assert.Empty(result.Permissions);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void ToPSRoleDefinition_PermissionWithEmptyActionLists_PreservesEmptyLists()
        {
            var roleDefinition = CreateRoleDefinition(
                id: "/providers/Microsoft.Authorization/roleDefinitions/12345678-1234-1234-1234-123456789012",
                roleName: "Test Role",
                roleType: "CustomRole",
                permissions:
                [
                    CreatePermission(
                        actions: [],
                        notActions: [],
                        dataActions: [],
                        notDataActions: [])
                ]
            );

            var result = roleDefinition.ToPSRoleDefinition();

            Assert.Single(result.Permissions);
            Assert.Empty(result.Permissions[0].Actions);
            Assert.Empty(result.Permissions[0].NotActions);
            Assert.Empty(result.Permissions[0].DataActions);
            Assert.Empty(result.Permissions[0].NotDataActions);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void ToPSRoleDefinition_ThreePermissions_AllPreservedInOrder()
        {
            var roleDefinition = CreateRoleDefinition(
                id: "/providers/Microsoft.Authorization/roleDefinitions/12345678-1234-1234-1234-123456789012",
                roleName: "Complex Role",
                roleType: "CustomRole",
                permissions:
                [
                    CreatePermission(actions: ["action1"]),
                    CreatePermission(actions: ["action2"], condition: "cond2"),
                    CreatePermission(actions: ["action3"], condition: "cond3", conditionVersion: "2.0")
                ]
            );

            var result = roleDefinition.ToPSRoleDefinition();

            Assert.Equal(3, result.Permissions.Count);
            Assert.Contains("action1", result.Permissions[0].Actions);
            Assert.Null(result.Permissions[0].Condition);
            Assert.Contains("action2", result.Permissions[1].Actions);
            Assert.Equal("cond2", result.Permissions[1].Condition);
            Assert.Contains("action3", result.Permissions[2].Actions);
            Assert.Equal("cond3", result.Permissions[2].Condition);
            Assert.Equal("2.0", result.Permissions[2].ConditionVersion);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void ToPSRoleDefinition_DataActionsOnlyPermission_PreservesCorrectly()
        {
            var roleDefinition = CreateRoleDefinition(
                id: "/providers/Microsoft.Authorization/roleDefinitions/12345678-1234-1234-1234-123456789012",
                roleName: "Data Actions Only Role",
                roleType: "CustomRole",
                permissions:
                [
                    CreatePermission(
                        dataActions: ["Microsoft.Storage/storageAccounts/blobServices/containers/blobs/*"],
                        notDataActions: ["Microsoft.Storage/storageAccounts/blobServices/containers/blobs/delete"])
                ]
            );

            var result = roleDefinition.ToPSRoleDefinition();

            Assert.Single(result.Permissions);
            Assert.Empty(result.Permissions[0].Actions);
            Assert.Single(result.Permissions[0].DataActions);
            Assert.Single(result.Permissions[0].NotDataActions);
        }

        #endregion
    }
}
