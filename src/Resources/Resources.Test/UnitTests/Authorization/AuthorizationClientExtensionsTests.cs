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
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
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

        #region ValidateRoleDefinition Tests

        private static PSRoleDefinition CreatePSRoleDefinition(
            string name = "Test Role",
            string description = "Test Description",
            List<string> assignableScopes = null,
            List<PSPermission> permissions = null)
        {
            return new PSRoleDefinition
            {
                Name = name,
                Description = description,
                AssignableScopes = assignableScopes ?? ["/subscriptions/00000000-0000-0000-0000-000000000000"],
                Permissions = permissions ?? [new PSPermission { Actions = ["*/read"] }]
            };
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void ValidateRoleDefinition_ValidRole_NoException()
        {
            var roleDef = CreatePSRoleDefinition();

            var exception = Record.Exception(() => AuthorizationClient.ValidateRoleDefinition(roleDef));

            Assert.Null(exception);
        }

        [Theory]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("   ")]
        public void ValidateRoleDefinition_InvalidName_ThrowsException(string name)
        {
            var roleDef = CreatePSRoleDefinition(name: name);

            Assert.Throws<ArgumentException>(() => AuthorizationClient.ValidateRoleDefinition(roleDef));
        }

        [Theory]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("   ")]
        public void ValidateRoleDefinition_InvalidDescription_ThrowsException(string description)
        {
            var roleDef = CreatePSRoleDefinition(description: description);

            Assert.Throws<ArgumentException>(() => AuthorizationClient.ValidateRoleDefinition(roleDef));
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void ValidateRoleDefinition_NullAssignableScopes_ThrowsException()
        {
            var roleDef = new PSRoleDefinition
            {
                Name = "Test Role",
                Description = "Test Description",
                AssignableScopes = null,
                Permissions = [new PSPermission { Actions = ["*/read"] }]
            };

            Assert.Throws<ArgumentException>(() => AuthorizationClient.ValidateRoleDefinition(roleDef));
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void ValidateRoleDefinition_EmptyAssignableScopes_ThrowsException()
        {
            var roleDef = CreatePSRoleDefinition(assignableScopes: []);

            Assert.Throws<ArgumentException>(() => AuthorizationClient.ValidateRoleDefinition(roleDef));
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void ValidateRoleDefinition_NullPermissions_ThrowsException()
        {
            var roleDef = new PSRoleDefinition
            {
                Name = "Test Role",
                Description = "Test Description",
                AssignableScopes = ["/subscriptions/00000000-0000-0000-0000-000000000000"],
                Permissions = null
            };

            Assert.Throws<ArgumentException>(() => AuthorizationClient.ValidateRoleDefinition(roleDef));
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void ValidateRoleDefinition_EmptyPermissions_ThrowsException()
        {
            var roleDef = CreatePSRoleDefinition(permissions: []);

            Assert.Throws<ArgumentException>(() => AuthorizationClient.ValidateRoleDefinition(roleDef));
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void ValidateRoleDefinition_PermissionsWithNoActions_ThrowsException()
        {
            var roleDef = CreatePSRoleDefinition(permissions:
            [
                new PSPermission { Actions = [], DataActions = [] }
            ]);

            Assert.Throws<ArgumentException>(() => AuthorizationClient.ValidateRoleDefinition(roleDef));
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void ValidateRoleDefinition_PermissionsWithOnlyDataActions_NoException()
        {
            var roleDef = CreatePSRoleDefinition(permissions:
            [
                new PSPermission { DataActions = ["Microsoft.Storage/*/read"] }
            ]);

            var exception = Record.Exception(() => AuthorizationClient.ValidateRoleDefinition(roleDef));

            Assert.Null(exception);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void ValidateRoleDefinition_PermissionsCollectionContainsNullEntry_ThrowsArgumentException()
        {
            // Defensive guard: a JSON input file with `"Permissions": [null]` deserializes
            // to a list containing a literal null element, which would otherwise NRE in the
            // subsequent Actions/DataActions check.
            var roleDef = CreatePSRoleDefinition(permissions:
            [
                null,
                new PSPermission { Actions = ["*/read"] }
            ]);

            Assert.Throws<ArgumentException>(() => AuthorizationClient.ValidateRoleDefinition(roleDef));
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void ValidateRoleDefinition_TwoPermissionEntries_ThrowsRoleDefinitionMultiplePermissionsNotAllowed()
        {
            // The Azure RBAC service currently rejects custom role create/update requests with
            // more than one permission entry. We mirror this client-side so users get a clear,
            // descriptive error instead of an HTTP round-trip. Note: this restriction is scoped
            // to create/update via these cmdlets; existing built-in role definitions can
            // legitimately expose multiple permission entries on read.
            var roleDef = CreatePSRoleDefinition(permissions:
            [
                new PSPermission { Actions = ["a1"] },
                new PSPermission { Actions = ["a2"] }
            ]);

            var ex = Assert.Throws<ArgumentException>(() => AuthorizationClient.ValidateRoleDefinition(roleDef));
            Assert.Contains("more than one permission entry", ex.Message, StringComparison.OrdinalIgnoreCase);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void ValidateRoleDefinition_SinglePermissionEntry_NoException()
        {
            // Positive: exactly one permission entry is the supported shape.
            var roleDef = CreatePSRoleDefinition(permissions:
            [
                new PSPermission { Actions = ["*/read"], Condition = "cond", ConditionVersion = "2.0" }
            ]);

            var exception = Record.Exception(() => AuthorizationClient.ValidateRoleDefinition(roleDef));

            Assert.Null(exception);
        }

        #endregion

        #region ToRoleDefinitionPermissions Tests (PSRoleDefinition -> SDK Permission, outbound direction)

        public static IEnumerable<object[]> NullOrEmptyRoleDefinitions => new[]
        {
            new object[] { null },                                              // entire role is null
            new object[] { new PSRoleDefinition { Permissions = null } },       // Permissions collection is null
            new object[] { new PSRoleDefinition { Permissions = new List<PSPermission>() } }, // Permissions is empty
        };

        [Theory]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [MemberData(nameof(NullOrEmptyRoleDefinitions))]
        public void ToRoleDefinitionPermissions_NullOrEmptyInput_ReturnsEmptyList(PSRoleDefinition roleDef)
        {
            var result = AuthorizationClient.ToRoleDefinitionPermissions(roleDef);

            Assert.NotNull(result);
            Assert.Empty(result);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void ToRoleDefinitionPermissions_SinglePermission_AllFieldsCopied()
        {
            var roleDef = new PSRoleDefinition
            {
                Permissions =
                [
                    new PSPermission
                    {
                        Actions = ["a1", "a2"],
                        NotActions = ["na1"],
                        DataActions = ["da1"],
                        NotDataActions = ["nda1"],
                        Condition = "cond",
                        ConditionVersion = "2.0"
                    }
                ]
            };

            var result = AuthorizationClient.ToRoleDefinitionPermissions(roleDef);

            Assert.Single(result);
            var p = result[0];
            Assert.Equal(["a1", "a2"], p.Actions);
            Assert.Equal(["na1"], p.NotActions);
            Assert.Equal(["da1"], p.DataActions);
            Assert.Equal(["nda1"], p.NotDataActions);
            Assert.Equal("cond", p.Condition);
            Assert.Equal("2.0", p.ConditionVersion);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void ToRoleDefinitionPermissions_NullActionLists_BecomeEmptyLists()
        {
            // PSPermission with all action collections null - outbound conversion must not propagate nulls
            // because the Azure RBAC service rejects null collections.
            var roleDef = new PSRoleDefinition
            {
                Permissions =
                [
                    new PSPermission
                    {
                        Actions = null,
                        NotActions = null,
                        DataActions = null,
                        NotDataActions = null,
                        Condition = null,
                        ConditionVersion = null
                    }
                ]
            };

            var result = AuthorizationClient.ToRoleDefinitionPermissions(roleDef);

            Assert.Single(result);
            var p = result[0];
            Assert.NotNull(p.Actions);
            Assert.Empty(p.Actions);
            Assert.NotNull(p.NotActions);
            Assert.Empty(p.NotActions);
            Assert.NotNull(p.DataActions);
            Assert.Empty(p.DataActions);
            Assert.NotNull(p.NotDataActions);
            Assert.Empty(p.NotDataActions);
            Assert.Null(p.Condition);
            Assert.Null(p.ConditionVersion);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void ToRoleDefinitionPermissions_MultiplePermissions_PreservesOrderAndConditionAssociation()
        {
            // Outbound mirror of the inbound bug-fix: each permission's Condition must stay
            // with its own permission entry and not bleed across.
            var roleDef = new PSRoleDefinition
            {
                Permissions =
                [
                    new PSPermission { Actions = ["a1"] },
                    new PSPermission { Actions = ["a2"], Condition = "cond-2", ConditionVersion = "2.0" },
                    new PSPermission { Actions = ["a3"], Condition = "cond-3", ConditionVersion = "2.0" }
                ]
            };

            var result = AuthorizationClient.ToRoleDefinitionPermissions(roleDef);

            Assert.Equal(3, result.Count);
            Assert.Contains("a1", result[0].Actions);
            Assert.Null(result[0].Condition);
            Assert.Null(result[0].ConditionVersion);
            Assert.Contains("a2", result[1].Actions);
            Assert.Equal("cond-2", result[1].Condition);
            Assert.Equal("2.0", result[1].ConditionVersion);
            Assert.Contains("a3", result[2].Actions);
            Assert.Equal("cond-3", result[2].Condition);
            Assert.Equal("2.0", result[2].ConditionVersion);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void RoleDefinition_RoundTrip_PreservesPermissionsShapeAndConditions()
        {
            // SDK Permission -> PSPermission (via ToPSRoleDefinition) -> SDK Permission
            // (via ToRoleDefinitionPermissions) must be a faithful round-trip for the new
            // multi-permission/per-permission-condition shape.
            var sdkRole = CreateRoleDefinition(
                id: "/providers/Microsoft.Authorization/roleDefinitions/95dd08a6-00bd-4661-84bf-f6726f83a4d0",
                roleName: "Round Trip Role",
                roleType: "CustomRole",
                permissions:
                [
                    CreatePermission(actions: ["a1", "a2"], notActions: ["na1"]),
                    CreatePermission(
                        actions: ["a3"],
                        dataActions: ["da1"],
                        notDataActions: ["nda1"],
                        condition: "((!(ActionMatches{'X/write'})))",
                        conditionVersion: "2.0")
                ]
            );

            var ps = sdkRole.ToPSRoleDefinition();
            var back = AuthorizationClient.ToRoleDefinitionPermissions(ps);

            Assert.Equal(2, back.Count);
            Assert.Equal(["a1", "a2"], back[0].Actions);
            Assert.Equal(["na1"], back[0].NotActions);
            Assert.Null(back[0].Condition);
            Assert.Null(back[0].ConditionVersion);
            Assert.Equal(["a3"], back[1].Actions);
            Assert.Equal(["da1"], back[1].DataActions);
            Assert.Equal(["nda1"], back[1].NotDataActions);
            Assert.Equal("((!(ActionMatches{'X/write'})))", back[1].Condition);
            Assert.Equal("2.0", back[1].ConditionVersion);
        }

        #endregion

        #region PSPermission JSON Serialization Tests

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void PSPermission_JsonSerialize_ExcludesStringHelperProperties()
        {
            // The *String helper properties on PSPermission are decorated with [JsonIgnore]
            // so JSON output (used by piping, ConvertTo-Json, and InputFile round-trips)
            // does not duplicate the action collections as comma-joined strings.
            var permission = new PSPermission
            {
                Actions = ["a1", "a2"],
                NotActions = ["na1"],
                DataActions = ["da1"],
                NotDataActions = ["nda1"],
                Condition = "cond",
                ConditionVersion = "2.0"
            };

            var json = JsonConvert.SerializeObject(permission);
            var jObject = JObject.Parse(json);

            Assert.False(jObject.ContainsKey("ActionsString"), "ActionsString must not appear in serialized PSPermission JSON");
            Assert.False(jObject.ContainsKey("NotActionsString"), "NotActionsString must not appear in serialized PSPermission JSON");
            Assert.False(jObject.ContainsKey("DataActionsString"), "DataActionsString must not appear in serialized PSPermission JSON");
            Assert.False(jObject.ContainsKey("NotDataActionsString"), "NotDataActionsString must not appear in serialized PSPermission JSON");

            // And the real properties must still be there
            Assert.True(jObject.ContainsKey("Actions"));
            Assert.True(jObject.ContainsKey("Condition"));
            Assert.True(jObject.ContainsKey("ConditionVersion"));
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void PSPermission_StringHelpers_HandleNullCollectionsWithoutThrowing()
        {
            // Defensive null-safety: the *String getters must not throw when the underlying
            // collections are null (e.g. when PSPermission is constructed without setting them).
            var permission = new PSPermission();

            Assert.Equal(string.Empty, permission.ActionsString);
            Assert.Equal(string.Empty, permission.NotActionsString);
            Assert.Equal(string.Empty, permission.DataActionsString);
            Assert.Equal(string.Empty, permission.NotDataActionsString);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void PSRoleDefinition_JsonRoundTrip_PreservesPermissionsShape()
        {
            // A PSRoleDefinition with the new Permissions shape must survive serialization
            // and deserialization intact - this protects the Set-AzRoleDefinition -InputFile
            // and pipeline-as-JSON scenarios.
            var original = new PSRoleDefinition
            {
                Name = "Custom Role",
                Id = "12345678-1234-1234-1234-123456789012",
                IsCustom = true,
                Description = "desc",
                AssignableScopes = ["/subscriptions/00000000-0000-0000-0000-000000000000"],
                Permissions =
                [
                    new PSPermission
                    {
                        Actions = ["a1"],
                        NotActions = ["na1"],
                        DataActions = ["da1"],
                        NotDataActions = ["nda1"],
                        Condition = "cond",
                        ConditionVersion = "2.0"
                    }
                ]
            };

            var json = JsonConvert.SerializeObject(original);
            var deserialized = JsonConvert.DeserializeObject<PSRoleDefinition>(json);

            Assert.NotNull(deserialized);
            Assert.Equal(original.Name, deserialized.Name);
            Assert.Equal(original.Id, deserialized.Id);
            Assert.Equal(original.IsCustom, deserialized.IsCustom);
            Assert.Equal(original.Description, deserialized.Description);
            Assert.Equal(original.AssignableScopes, deserialized.AssignableScopes);
            Assert.NotNull(deserialized.Permissions);
            Assert.Single(deserialized.Permissions);
            var p = deserialized.Permissions[0];
            Assert.Equal(["a1"], p.Actions);
            Assert.Equal(["na1"], p.NotActions);
            Assert.Equal(["da1"], p.DataActions);
            Assert.Equal(["nda1"], p.NotDataActions);
            Assert.Equal("cond", p.Condition);
            Assert.Equal("2.0", p.ConditionVersion);
        }

        #endregion
    }
}
