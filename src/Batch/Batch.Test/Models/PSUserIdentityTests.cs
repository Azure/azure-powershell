// -----------------------------------------------------------------------------
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
// -----------------------------------------------------------------------------

using Microsoft.Azure.Commands.Batch.Models;
using Microsoft.Azure.Management.Batch.Models;
using Xunit;

namespace Microsoft.Azure.Commands.Batch.Test.ModelsConversions
{
    public class PSUserIdentityTests
    {
        #region toMgmtUserIdentity Tests

        [Fact]
        public void ToMgmtUserIdentity_WithAutoUser_ReturnsCorrectMapping()
        {
            // Arrange
            var psAutoUserSpec = new PSAutoUserSpecification(
                scope: Microsoft.Azure.Batch.Common.AutoUserScope.Task,
                elevationLevel: Microsoft.Azure.Batch.Common.ElevationLevel.Admin);
            var psUserIdentity = new PSUserIdentity(psAutoUserSpec);

            // Act
            var result = psUserIdentity.toMgmtUserIdentity();

            // Assert
            Assert.NotNull(result);
            Assert.NotNull(result.AutoUser);
            Assert.Equal(AutoUserScope.Task, result.AutoUser.Scope);
            Assert.Equal(ElevationLevel.Admin, result.AutoUser.ElevationLevel);
            Assert.Null(result.UserName);
        }

        [Fact]
        public void ToMgmtUserIdentity_WithUserName_ReturnsCorrectMapping()
        {
            // Arrange
            var psUserIdentity = new PSUserIdentity("testuser");

            // Act
            var result = psUserIdentity.toMgmtUserIdentity();

            // Assert
            Assert.NotNull(result);
            Assert.Equal("testuser", result.UserName);
            Assert.Null(result.AutoUser);
        }

        [Fact]
        public void ToMgmtUserIdentity_WithAutoUserPoolScopeNonAdmin_ReturnsCorrectMapping()
        {
            // Arrange
            var psAutoUserSpec = new PSAutoUserSpecification(
                scope: Microsoft.Azure.Batch.Common.AutoUserScope.Pool,
                elevationLevel: Microsoft.Azure.Batch.Common.ElevationLevel.NonAdmin);
            var psUserIdentity = new PSUserIdentity(psAutoUserSpec);

            // Act
            var result = psUserIdentity.toMgmtUserIdentity();

            // Assert
            Assert.NotNull(result);
            Assert.NotNull(result.AutoUser);
            Assert.Equal(AutoUserScope.Pool, result.AutoUser.Scope);
            Assert.Equal(ElevationLevel.NonAdmin, result.AutoUser.ElevationLevel);
            Assert.Null(result.UserName);
        }

        [Fact]
        public void ToMgmtUserIdentity_WithAutoUserNullValues_ReturnsNullValues()
        {
            // Arrange
            var psAutoUserSpec = new PSAutoUserSpecification(
                scope: null,
                elevationLevel: null);
            var psUserIdentity = new PSUserIdentity(psAutoUserSpec);

            // Act
            var result = psUserIdentity.toMgmtUserIdentity();

            // Assert
            Assert.NotNull(result);
            Assert.NotNull(result.AutoUser);
            Assert.Null(result.AutoUser.Scope);
            Assert.Null(result.AutoUser.ElevationLevel);
            Assert.Null(result.UserName);
        }

        [Fact]
        public void ToMgmtUserIdentity_WithEmptyUserName_ReturnsNull()
        {
            // Arrange
            var psUserIdentity = new PSUserIdentity("");

            // Act
            var result = psUserIdentity.toMgmtUserIdentity();

            // Assert
            Assert.Null(result);
        }

        [Fact]
        public void ToMgmtUserIdentity_WithNullUserName_ReturnsNull()
        {
            // Arrange
            var psUserIdentity = new PSUserIdentity((string)null);

            // Act
            var result = psUserIdentity.toMgmtUserIdentity();

            // Assert
            Assert.Null(result);
        }

        [Theory]
        [InlineData("admin")]
        [InlineData("batchuser")]
        [InlineData("test-user_123")]
        [InlineData("user@domain.com")]
        public void ToMgmtUserIdentity_VariousUserNames_ReturnsCorrectMapping(string userName)
        {
            // Arrange
            var psUserIdentity = new PSUserIdentity(userName);

            // Act
            var result = psUserIdentity.toMgmtUserIdentity();

            // Assert
            Assert.NotNull(result);
            Assert.Equal(userName, result.UserName);
            Assert.Null(result.AutoUser);
        }

        [Fact]
        public void ToMgmtUserIdentity_AlwaysCreatesNewInstance()
        {
            // Arrange
            var psUserIdentity = new PSUserIdentity("testuser");

            // Act
            var result1 = psUserIdentity.toMgmtUserIdentity();
            var result2 = psUserIdentity.toMgmtUserIdentity();

            // Assert
            Assert.NotNull(result1);
            Assert.NotNull(result2);
            Assert.NotSame(result1, result2);
        }

        [Fact]
        public void ToMgmtUserIdentity_VerifyUserIdentityType()
        {
            // Arrange
            var psUserIdentity = new PSUserIdentity("testuser");

            // Act
            var result = psUserIdentity.toMgmtUserIdentity();

            // Assert
            Assert.NotNull(result);
            Assert.IsType<UserIdentity>(result);
        }

        [Fact]
        public void ToMgmtUserIdentity_WithDefaultAutoUserSpec_ReturnsCorrectMapping()
        {
            // Arrange
            var psAutoUserSpec = new PSAutoUserSpecification(); // Default constructor
            var psUserIdentity = new PSUserIdentity(psAutoUserSpec);

            // Act
            var result = psUserIdentity.toMgmtUserIdentity();

            // Assert
            Assert.NotNull(result);
            Assert.NotNull(result.AutoUser);
            Assert.Null(result.AutoUser.Scope);
            Assert.Null(result.AutoUser.ElevationLevel);
            Assert.Null(result.UserName);
        }

        #endregion

        #region fromMgmtUserIdentity Tests

        [Fact]
        public void FromMgmtUserIdentity_WithAutoUser_ReturnsCorrectMapping()
        {
            // Arrange
            var mgmtAutoUserSpec = new AutoUserSpecification(
                scope: AutoUserScope.Task,
                elevationLevel: ElevationLevel.Admin);
            var mgmtUserIdentity = new UserIdentity(autoUser: mgmtAutoUserSpec);

            // Act
            var result = PSUserIdentity.fromMgmtUserIdentity(mgmtUserIdentity);

            // Assert
            Assert.NotNull(result);
            Assert.NotNull(result.AutoUser);
            Assert.Equal(Microsoft.Azure.Batch.Common.AutoUserScope.Task, result.AutoUser.Scope);
            Assert.Equal(Microsoft.Azure.Batch.Common.ElevationLevel.Admin, result.AutoUser.ElevationLevel);
            Assert.Null(result.UserName);
        }

        [Fact]
        public void FromMgmtUserIdentity_WithUserName_ReturnsCorrectMapping()
        {
            // Arrange
            var mgmtUserIdentity = new UserIdentity(userName: "testuser");

            // Act
            var result = PSUserIdentity.fromMgmtUserIdentity(mgmtUserIdentity);

            // Assert
            Assert.NotNull(result);
            Assert.Equal("testuser", result.UserName);
            Assert.Null(result.AutoUser);
        }

        [Fact]
        public void FromMgmtUserIdentity_WithNullMgmtUserIdentity_ReturnsNull()
        {
            // Act
            var result = PSUserIdentity.fromMgmtUserIdentity(null);

            // Assert
            Assert.Null(result);
        }

        [Fact]
        public void FromMgmtUserIdentity_WithAutoUserPoolScopeNonAdmin_ReturnsCorrectMapping()
        {
            // Arrange
            var mgmtAutoUserSpec = new AutoUserSpecification(
                scope: AutoUserScope.Pool,
                elevationLevel: ElevationLevel.NonAdmin);
            var mgmtUserIdentity = new UserIdentity(autoUser: mgmtAutoUserSpec);

            // Act
            var result = PSUserIdentity.fromMgmtUserIdentity(mgmtUserIdentity);

            // Assert
            Assert.NotNull(result);
            Assert.NotNull(result.AutoUser);
            Assert.Equal(Microsoft.Azure.Batch.Common.AutoUserScope.Pool, result.AutoUser.Scope);
            Assert.Equal(Microsoft.Azure.Batch.Common.ElevationLevel.NonAdmin, result.AutoUser.ElevationLevel);
            Assert.Null(result.UserName);
        }

        [Fact]
        public void FromMgmtUserIdentity_WithAutoUserNullValues_ReturnsNullValues()
        {
            // Arrange
            var mgmtAutoUserSpec = new AutoUserSpecification(
                scope: null,
                elevationLevel: null);
            var mgmtUserIdentity = new UserIdentity(autoUser: mgmtAutoUserSpec);

            // Act
            var result = PSUserIdentity.fromMgmtUserIdentity(mgmtUserIdentity);

            // Assert
            Assert.NotNull(result);
            Assert.NotNull(result.AutoUser);
            Assert.Null(result.AutoUser.Scope);
            Assert.Null(result.AutoUser.ElevationLevel);
            Assert.Null(result.UserName);
        }

        [Fact]
        public void FromMgmtUserIdentity_WithEmptyUserName_ReturnsNull()
        {
            // Arrange
            var mgmtUserIdentity = new UserIdentity(userName: "");

            // Act
            var result = PSUserIdentity.fromMgmtUserIdentity(mgmtUserIdentity);

            // Assert
            Assert.Null(result);
        }

        [Fact]
        public void FromMgmtUserIdentity_WithNullUserName_ReturnsNull()
        {
            // Arrange
            var mgmtUserIdentity = new UserIdentity(userName: null);

            // Act
            var result = PSUserIdentity.fromMgmtUserIdentity(mgmtUserIdentity);

            // Assert
            Assert.Null(result);
        }

        [Theory]
        [InlineData("admin")]
        [InlineData("batchuser")]
        [InlineData("test-user_123")]
        [InlineData("user@domain.com")]
        public void FromMgmtUserIdentity_VariousUserNames_ReturnsCorrectMapping(string userName)
        {
            // Arrange
            var mgmtUserIdentity = new UserIdentity(userName: userName);

            // Act
            var result = PSUserIdentity.fromMgmtUserIdentity(mgmtUserIdentity);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(userName, result.UserName);
            Assert.Null(result.AutoUser);
        }

        [Fact]
        public void FromMgmtUserIdentity_StaticMethod_DoesNotRequireInstance()
        {
            // Arrange
            var mgmtUserIdentity = new UserIdentity(userName: "testuser");

            // Act - Call static method directly on class
            var result = PSUserIdentity.fromMgmtUserIdentity(mgmtUserIdentity);

            // Assert
            Assert.NotNull(result);
            Assert.Equal("testuser", result.UserName);
        }

        [Fact]
        public void FromMgmtUserIdentity_AlwaysCreatesNewInstance()
        {
            // Arrange
            var mgmtUserIdentity = new UserIdentity(userName: "testuser");

            // Act
            var result1 = PSUserIdentity.fromMgmtUserIdentity(mgmtUserIdentity);
            var result2 = PSUserIdentity.fromMgmtUserIdentity(mgmtUserIdentity);

            // Assert
            Assert.NotNull(result1);
            Assert.NotNull(result2);
            Assert.NotSame(result1, result2);
        }

        [Fact]
        public void FromMgmtUserIdentity_VerifyPSUserIdentityType()
        {
            // Arrange
            var mgmtUserIdentity = new UserIdentity(userName: "testuser");

            // Act
            var result = PSUserIdentity.fromMgmtUserIdentity(mgmtUserIdentity);

            // Assert
            Assert.NotNull(result);
            Assert.IsType<PSUserIdentity>(result);
        }

        [Fact]
        public void FromMgmtUserIdentity_WithDefaultConstructor_ReturnsNull()
        {
            // Arrange
            var mgmtUserIdentity = new UserIdentity(); // Uses default constructor

            // Act
            var result = PSUserIdentity.fromMgmtUserIdentity(mgmtUserIdentity);

            // Assert
            Assert.Null(result);
        }

        [Fact]
        public void FromMgmtUserIdentity_WithDefaultAutoUserSpec_ReturnsCorrectMapping()
        {
            // Arrange
            var mgmtAutoUserSpec = new AutoUserSpecification(); // Default constructor
            var mgmtUserIdentity = new UserIdentity(autoUser: mgmtAutoUserSpec);

            // Act
            var result = PSUserIdentity.fromMgmtUserIdentity(mgmtUserIdentity);

            // Assert
            Assert.NotNull(result);
            Assert.NotNull(result.AutoUser);
            Assert.Null(result.AutoUser.Scope);
            Assert.Null(result.AutoUser.ElevationLevel);
            Assert.Null(result.UserName);
        }

        #endregion

        #region Round-trip Conversion Tests

        [Fact]
        public void RoundTripConversion_ToMgmtAndFromMgmt_PreservesAutoUserProperties()
        {
            // Arrange
            var originalAutoUserSpec = new PSAutoUserSpecification(
                scope: Microsoft.Azure.Batch.Common.AutoUserScope.Task,
                elevationLevel: Microsoft.Azure.Batch.Common.ElevationLevel.Admin);
            var originalPsUserIdentity = new PSUserIdentity(originalAutoUserSpec);

            // Act
            var mgmtUserIdentity = originalPsUserIdentity.toMgmtUserIdentity();
            var roundTripPsUserIdentity = PSUserIdentity.fromMgmtUserIdentity(mgmtUserIdentity);

            // Assert
            Assert.NotNull(roundTripPsUserIdentity);
            Assert.NotNull(roundTripPsUserIdentity.AutoUser);
            Assert.Equal(originalPsUserIdentity.AutoUser.Scope, roundTripPsUserIdentity.AutoUser.Scope);
            Assert.Equal(originalPsUserIdentity.AutoUser.ElevationLevel, roundTripPsUserIdentity.AutoUser.ElevationLevel);
            Assert.Null(roundTripPsUserIdentity.UserName);
        }

        [Fact]
        public void RoundTripConversion_ToMgmtAndFromMgmt_PreservesUserNameProperties()
        {
            // Arrange
            var originalPsUserIdentity = new PSUserIdentity("testuser");

            // Act
            var mgmtUserIdentity = originalPsUserIdentity.toMgmtUserIdentity();
            var roundTripPsUserIdentity = PSUserIdentity.fromMgmtUserIdentity(mgmtUserIdentity);

            // Assert
            Assert.NotNull(roundTripPsUserIdentity);
            Assert.Equal(originalPsUserIdentity.UserName, roundTripPsUserIdentity.UserName);
            Assert.Null(roundTripPsUserIdentity.AutoUser);
        }

        [Fact]
        public void RoundTripConversion_ToMgmtAndFromMgmt_PreservesAutoUserNullValues()
        {
            // Arrange
            var originalAutoUserSpec = new PSAutoUserSpecification(
                scope: null,
                elevationLevel: null);
            var originalPsUserIdentity = new PSUserIdentity(originalAutoUserSpec);

            // Act
            var mgmtUserIdentity = originalPsUserIdentity.toMgmtUserIdentity();
            var roundTripPsUserIdentity = PSUserIdentity.fromMgmtUserIdentity(mgmtUserIdentity);

            // Assert
            Assert.NotNull(roundTripPsUserIdentity);
            Assert.NotNull(roundTripPsUserIdentity.AutoUser);
            Assert.Null(roundTripPsUserIdentity.AutoUser.Scope);
            Assert.Null(roundTripPsUserIdentity.AutoUser.ElevationLevel);
            Assert.Null(roundTripPsUserIdentity.UserName);
        }

        [Theory]
        [InlineData("admin")]
        [InlineData("batchuser")]
        [InlineData("user@domain.com")]
        public void RoundTripConversion_UserNameValues_PreservesOriginalValue(string userName)
        {
            // Arrange
            var originalPsUserIdentity = new PSUserIdentity(userName);

            // Act
            var mgmtUserIdentity = originalPsUserIdentity.toMgmtUserIdentity();
            var roundTripPsUserIdentity = PSUserIdentity.fromMgmtUserIdentity(mgmtUserIdentity);

            // Assert
            Assert.NotNull(roundTripPsUserIdentity);
            Assert.Equal(userName, roundTripPsUserIdentity.UserName);
            Assert.Null(roundTripPsUserIdentity.AutoUser);
        }

        [Fact]
        public void RoundTripConversion_FromMgmtAndToMgmt_PreservesAutoUserValues()
        {
            // Arrange
            var originalAutoUserSpec = new AutoUserSpecification(
                scope: AutoUserScope.Pool,
                elevationLevel: ElevationLevel.NonAdmin);
            var originalMgmtUserIdentity = new UserIdentity(autoUser: originalAutoUserSpec);

            // Act
            var psUserIdentity = PSUserIdentity.fromMgmtUserIdentity(originalMgmtUserIdentity);
            var roundTripMgmtUserIdentity = psUserIdentity.toMgmtUserIdentity();

            // Assert
            Assert.NotNull(roundTripMgmtUserIdentity);
            Assert.NotNull(roundTripMgmtUserIdentity.AutoUser);
            Assert.Equal(originalMgmtUserIdentity.AutoUser.Scope, roundTripMgmtUserIdentity.AutoUser.Scope);
            Assert.Equal(originalMgmtUserIdentity.AutoUser.ElevationLevel, roundTripMgmtUserIdentity.AutoUser.ElevationLevel);
            Assert.Null(roundTripMgmtUserIdentity.UserName);
        }

        [Fact]
        public void RoundTripConversion_FromMgmtAndToMgmt_PreservesUserNameValues()
        {
            // Arrange
            var originalMgmtUserIdentity = new UserIdentity(userName: "testuser");

            // Act
            var psUserIdentity = PSUserIdentity.fromMgmtUserIdentity(originalMgmtUserIdentity);
            var roundTripMgmtUserIdentity = psUserIdentity.toMgmtUserIdentity();

            // Assert
            Assert.NotNull(roundTripMgmtUserIdentity);
            Assert.Equal(originalMgmtUserIdentity.UserName, roundTripMgmtUserIdentity.UserName);
            Assert.Null(roundTripMgmtUserIdentity.AutoUser);
        }

        #endregion

        #region Integration Tests

        [Fact]
        public void UserIdentityConversions_BothDirections_MaintainSemanticEquivalence()
        {
            // This test ensures that the semantic meaning is preserved across conversions

            // Scenario 1: AutoUser with Task scope and Admin elevation
            var psAutoUserSpec = new PSAutoUserSpecification(
                scope: Microsoft.Azure.Batch.Common.AutoUserScope.Task,
                elevationLevel: Microsoft.Azure.Batch.Common.ElevationLevel.Admin);
            var psUserIdentity = new PSUserIdentity(psAutoUserSpec);

            var mgmtUserIdentity = psUserIdentity.toMgmtUserIdentity();
            var backToPs = PSUserIdentity.fromMgmtUserIdentity(mgmtUserIdentity);

            Assert.NotNull(mgmtUserIdentity);
            Assert.NotNull(mgmtUserIdentity.AutoUser);
            Assert.Equal(AutoUserScope.Task, mgmtUserIdentity.AutoUser.Scope);
            Assert.Equal(ElevationLevel.Admin, mgmtUserIdentity.AutoUser.ElevationLevel);
            Assert.Null(mgmtUserIdentity.UserName);

            Assert.NotNull(backToPs);
            Assert.NotNull(backToPs.AutoUser);
            Assert.Equal(Microsoft.Azure.Batch.Common.AutoUserScope.Task, backToPs.AutoUser.Scope);
            Assert.Equal(Microsoft.Azure.Batch.Common.ElevationLevel.Admin, backToPs.AutoUser.ElevationLevel);
            Assert.Null(backToPs.UserName);

            // Scenario 2: Named user
            var psNamedUserIdentity = new PSUserIdentity("batchuser");

            var mgmtNamedUserIdentity = psNamedUserIdentity.toMgmtUserIdentity();
            var backToPsNamed = PSUserIdentity.fromMgmtUserIdentity(mgmtNamedUserIdentity);

            Assert.NotNull(mgmtNamedUserIdentity);
            Assert.Equal("batchuser", mgmtNamedUserIdentity.UserName);
            Assert.Null(mgmtNamedUserIdentity.AutoUser);

            Assert.NotNull(backToPsNamed);
            Assert.Equal("batchuser", backToPsNamed.UserName);
            Assert.Null(backToPsNamed.AutoUser);
        }

        [Fact]
        public void UserIdentityConversions_NullHandling_WorksCorrectly()
        {
            // Test null handling in conversions

            // Act
            var resultFromNull = PSUserIdentity.fromMgmtUserIdentity(null);

            // Assert
            Assert.Null(resultFromNull);

            // Test empty/null username handling
            var emptyUserNamePs = new PSUserIdentity("");
            var emptyUserNameMgmt = emptyUserNamePs.toMgmtUserIdentity();
            Assert.Null(emptyUserNameMgmt);

            var nullUserNamePs = new PSUserIdentity((string)null);
            var nullUserNameMgmt = nullUserNamePs.toMgmtUserIdentity();
            Assert.Null(nullUserNameMgmt);
        }

        [Fact]
        public void UserIdentityConversions_BatchTaskContext_VerifyCorrectUsage()
        {
            // This test validates the conversions work correctly in the context of Batch task configuration
            // UserIdentity is used to specify the user context for task execution

            // Arrange - Test with different user identity scenarios
            var scenarios = new[]
            {
                // Task-scoped admin auto user for isolated privileged operations
                new {
                    UserType = "AutoUser",
                    Scope = Microsoft.Azure.Batch.Common.AutoUserScope.Task,
                    ElevationLevel = Microsoft.Azure.Batch.Common.ElevationLevel.Admin,
                    UserName = (string)null,
                    Description = "Task-scoped admin auto user for privileged operations"
                },
                // Pool-scoped non-admin auto user for shared standard operations
                new {
                    UserType = "AutoUser",
                    Scope = Microsoft.Azure.Batch.Common.AutoUserScope.Pool,
                    ElevationLevel = Microsoft.Azure.Batch.Common.ElevationLevel.NonAdmin,
                    UserName = (string)null,
                    Description = "Pool-scoped non-admin auto user for shared operations"
                },
                // Named user for specific user context
                new {
                    UserType = "NamedUser",
                    Scope = Microsoft.Azure.Batch.Common.AutoUserScope.Pool,
                    ElevationLevel = Microsoft.Azure.Batch.Common.ElevationLevel.NonAdmin,
                    UserName = "batchuser",
                    Description = "Named user account for specific user context"
                },
                // Named admin user
                new {
                    UserType = "NamedUser",
                    Scope = Microsoft.Azure.Batch.Common.AutoUserScope.Pool,
                    ElevationLevel = Microsoft.Azure.Batch.Common.ElevationLevel.NonAdmin,
                    UserName = "admin",
                    Description = "Named admin user account"
                }
            };

            foreach (var scenario in scenarios)
            {
                // Arrange
                PSUserIdentity psUserIdentity;
                if (scenario.UserType == "AutoUser")
                {
                    var autoUserSpec = new PSAutoUserSpecification(
                        scope: scenario.Scope,
                        elevationLevel: scenario.ElevationLevel);
                    psUserIdentity = new PSUserIdentity(autoUserSpec);
                }
                else
                {
                    psUserIdentity = new PSUserIdentity(scenario.UserName);
                }

                // Act
                var mgmtUserIdentity = psUserIdentity.toMgmtUserIdentity();

                // Assert - Should convert correctly for Batch task configuration
                Assert.NotNull(mgmtUserIdentity);

                if (scenario.UserType == "AutoUser")
                {
                    Assert.NotNull(mgmtUserIdentity.AutoUser);
                    Assert.Null(mgmtUserIdentity.UserName);
                    
                    var expectedMgmtScope = scenario.Scope == Microsoft.Azure.Batch.Common.AutoUserScope.Task
                        ? AutoUserScope.Task
                        : AutoUserScope.Pool;
                    var expectedMgmtElevationLevel = scenario.ElevationLevel == Microsoft.Azure.Batch.Common.ElevationLevel.Admin
                        ? ElevationLevel.Admin
                        : ElevationLevel.NonAdmin;
                        
                    Assert.Equal(expectedMgmtScope, mgmtUserIdentity.AutoUser.Scope);
                    Assert.Equal(expectedMgmtElevationLevel, mgmtUserIdentity.AutoUser.ElevationLevel);
                }
                else
                {
                    Assert.Equal(scenario.UserName, mgmtUserIdentity.UserName);
                    Assert.Null(mgmtUserIdentity.AutoUser);
                }

                // Verify round-trip conversion maintains user identity semantics
                var backToPs = PSUserIdentity.fromMgmtUserIdentity(mgmtUserIdentity);
                Assert.NotNull(backToPs);

                if (scenario.UserType == "AutoUser")
                {
                    Assert.NotNull(backToPs.AutoUser);
                    Assert.Null(backToPs.UserName);
                    Assert.Equal(scenario.Scope, backToPs.AutoUser.Scope);
                    Assert.Equal(scenario.ElevationLevel, backToPs.AutoUser.ElevationLevel);
                }
                else
                {
                    Assert.Equal(scenario.UserName, backToPs.UserName);
                    Assert.Null(backToPs.AutoUser);
                }
            }
        }

        [Fact]
        public void UserIdentityConversions_MutualExclusivity_VerifyBehavior()
        {
            // This test verifies that the conversion methods properly handle the mutual exclusivity
            // of UserName and AutoUser properties as documented in the UserIdentity class

            // Test 1: AutoUser specified (UserName should be null)
            var autoUserSpec = new PSAutoUserSpecification(
                scope: Microsoft.Azure.Batch.Common.AutoUserScope.Task,
                elevationLevel: Microsoft.Azure.Batch.Common.ElevationLevel.Admin);
            var autoUserIdentity = new PSUserIdentity(autoUserSpec);

            var mgmtAutoUserIdentity = autoUserIdentity.toMgmtUserIdentity();
            Assert.NotNull(mgmtAutoUserIdentity.AutoUser);
            Assert.Null(mgmtAutoUserIdentity.UserName);

            // Test 2: UserName specified (AutoUser should be null)
            var namedUserIdentity = new PSUserIdentity("testuser");

            var mgmtNamedUserIdentity = namedUserIdentity.toMgmtUserIdentity();
            Assert.Equal("testuser", mgmtNamedUserIdentity.UserName);
            Assert.Null(mgmtNamedUserIdentity.AutoUser);

            // Test 3: Verify round-trip maintains mutual exclusivity
            var roundTripAutoUser = PSUserIdentity.fromMgmtUserIdentity(mgmtAutoUserIdentity);
            Assert.NotNull(roundTripAutoUser.AutoUser);
            Assert.Null(roundTripAutoUser.UserName);

            var roundTripNamedUser = PSUserIdentity.fromMgmtUserIdentity(mgmtNamedUserIdentity);
            Assert.Equal("testuser", roundTripNamedUser.UserName);
            Assert.Null(roundTripNamedUser.AutoUser);
        }

        [Fact]
        public void UserIdentityConversions_InstanceCreation_VerifyBehavior()
        {
            // This test verifies that the conversion methods create appropriate instances

            // Arrange
            var autoUserSpec = new PSAutoUserSpecification(
                scope: Microsoft.Azure.Batch.Common.AutoUserScope.Pool,
                elevationLevel: Microsoft.Azure.Batch.Common.ElevationLevel.NonAdmin);
            var psUserIdentity = new PSUserIdentity(autoUserSpec);

            var mgmtAutoUserSpec = new AutoUserSpecification(
                scope: AutoUserScope.Task,
                elevationLevel: ElevationLevel.Admin);
            var mgmtUserIdentity = new UserIdentity(autoUser: mgmtAutoUserSpec);

            // Act
            var mgmtResult = psUserIdentity.toMgmtUserIdentity();
            var psResult = PSUserIdentity.fromMgmtUserIdentity(mgmtUserIdentity);

            // Assert - Verify proper instance creation
            Assert.NotNull(mgmtResult);
            Assert.NotNull(psResult);
            Assert.IsType<UserIdentity>(mgmtResult);
            Assert.IsType<PSUserIdentity>(psResult);

            // Verify new instances are created
            Assert.NotSame(mgmtUserIdentity, mgmtResult);
            Assert.NotSame(psUserIdentity, psResult);
        }

        #endregion

        #region Performance and Edge Case Tests

        [Fact]
        public void UserIdentityConversions_PerformanceTest_ExecutesQuickly()
        {
            // This test ensures the conversions are efficient

            // Arrange
            var autoUserSpec = new PSAutoUserSpecification(
                scope: Microsoft.Azure.Batch.Common.AutoUserScope.Task,
                elevationLevel: Microsoft.Azure.Batch.Common.ElevationLevel.Admin);
            var psUserIdentity = new PSUserIdentity(autoUserSpec);

            var mgmtAutoUserSpec = new AutoUserSpecification(
                scope: AutoUserScope.Pool,
                elevationLevel: ElevationLevel.NonAdmin);
            var mgmtUserIdentity = new UserIdentity(autoUser: mgmtAutoUserSpec);

            // Act & Assert - Multiple conversions should complete without delay
            for (int i = 0; i < 100; i++)
            {
                var mgmtResult = psUserIdentity.toMgmtUserIdentity();
                var psResult = PSUserIdentity.fromMgmtUserIdentity(mgmtUserIdentity);

                Assert.NotNull(mgmtResult);
                Assert.NotNull(psResult);
                Assert.NotNull(mgmtResult.AutoUser);
                Assert.NotNull(psResult.AutoUser);
            }
        }

        [Fact]
        public void UserIdentityConversions_EdgeCaseUserNames_HandleCorrectly()
        {
            // Test conversion with various edge case user names

            var testUserNames = new[]
            {
                // Standard user names
                "admin",
                "batchuser",
                "testuser",
                
                // User names with special characters
                "user-123",
                "user_test",
                "user@domain.com",
                "domain\\user",
                "user.name",
                
                // Azure Active Directory formats
                "user@tenant.onmicrosoft.com",
                "12345678-1234-1234-1234-123456789abc", // GUID format
                
                // Long user names
                "very-long-user-name-for-testing-purposes-that-exceeds-normal-length",
                
                // Single character
                "a",
                
                // Numeric user names
                "123456",
                "user123"
            };

            foreach (var userName in testUserNames)
            {
                // Arrange
                var psUserIdentity = new PSUserIdentity(userName);

                // Act
                var mgmtResult = psUserIdentity.toMgmtUserIdentity();
                var roundTripResult = PSUserIdentity.fromMgmtUserIdentity(mgmtResult);

                // Assert
                Assert.NotNull(mgmtResult);
                Assert.NotNull(roundTripResult);
                Assert.Equal(userName, mgmtResult.UserName);
                Assert.Null(mgmtResult.AutoUser);
                Assert.Equal(userName, roundTripResult.UserName);
                Assert.Null(roundTripResult.AutoUser);
            }
        }

        [Fact]
        public void UserIdentityConversions_DefaultAndNullValues_HandleCorrectly()
        {
            // Test conversion with default and null values

            // Scenario 1: Default AutoUserSpecification
            var defaultAutoUserSpec = new PSAutoUserSpecification(); // Default constructor
            var defaultAutoUserIdentity = new PSUserIdentity(defaultAutoUserSpec);

            var mgmtDefaultResult = defaultAutoUserIdentity.toMgmtUserIdentity();
            Assert.NotNull(mgmtDefaultResult);
            Assert.NotNull(mgmtDefaultResult.AutoUser);
            Assert.Null(mgmtDefaultResult.AutoUser.Scope);
            Assert.Null(mgmtDefaultResult.AutoUser.ElevationLevel);
            Assert.Null(mgmtDefaultResult.UserName);

            // Scenario 2: Empty UserIdentity from management side
            var emptyMgmtUserIdentity = new UserIdentity(); // Default constructor
            var psFromEmpty = PSUserIdentity.fromMgmtUserIdentity(emptyMgmtUserIdentity);
            Assert.Null(psFromEmpty); // Should return null when no valid properties are set

            // Scenario 3: Null values in AutoUserSpecification
            var nullValuesAutoUserSpec = new PSAutoUserSpecification(
                scope: null,
                elevationLevel: null);
            var nullValuesUserIdentity = new PSUserIdentity(nullValuesAutoUserSpec);

            var mgmtNullValuesResult = nullValuesUserIdentity.toMgmtUserIdentity();
            Assert.NotNull(mgmtNullValuesResult);
            Assert.NotNull(mgmtNullValuesResult.AutoUser);
            Assert.Null(mgmtNullValuesResult.AutoUser.Scope);
            Assert.Null(mgmtNullValuesResult.AutoUser.ElevationLevel);

            var roundTripNullValues = PSUserIdentity.fromMgmtUserIdentity(mgmtNullValuesResult);
            Assert.NotNull(roundTripNullValues);
            Assert.NotNull(roundTripNullValues.AutoUser);
            Assert.Null(roundTripNullValues.AutoUser.Scope);
            Assert.Null(roundTripNullValues.AutoUser.ElevationLevel);
        }

        #endregion
    }
}