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
    public class PSApplicationPackageReferenceTests
    {
        #region toMgmtApplicationPackageReference Tests

        [Fact]
        public void ToMgmtApplicationPackageReference_WithAllProperties_ReturnsCorrectMapping()
        {
            // Arrange
            var psAppPackageRef = new PSApplicationPackageReference
            {
                ApplicationId = "myapp",
                Version = "1.0.0"
            };

            // Act
            var result = psAppPackageRef.toMgmtApplicationPackageReference();

            // Assert
            Assert.NotNull(result);
            Assert.Equal("myapp", result.Id);
            Assert.Equal("1.0.0", result.Version);
        }

        [Fact]
        public void ToMgmtApplicationPackageReference_WithApplicationIdOnly_ReturnsCorrectMapping()
        {
            // Arrange
            var psAppPackageRef = new PSApplicationPackageReference
            {
                ApplicationId = "myapp",
                Version = null
            };

            // Act
            var result = psAppPackageRef.toMgmtApplicationPackageReference();

            // Assert
            Assert.NotNull(result);
            Assert.Equal("myapp", result.Id);
            Assert.Null(result.Version);
        }

        [Fact]
        public void ToMgmtApplicationPackageReference_WithEmptyVersion_ReturnsEmptyVersion()
        {
            // Arrange
            var psAppPackageRef = new PSApplicationPackageReference
            {
                ApplicationId = "myapp",
                Version = ""
            };

            // Act
            var result = psAppPackageRef.toMgmtApplicationPackageReference();

            // Assert
            Assert.NotNull(result);
            Assert.Equal("myapp", result.Id);
            Assert.Equal("", result.Version);
        }

        [Fact]
        public void ToMgmtApplicationPackageReference_WithNullApplicationId_ReturnsNullId()
        {
            // Arrange
            var psAppPackageRef = new PSApplicationPackageReference
            {
                ApplicationId = null,
                Version = "2.0.0"
            };

            // Act
            var result = psAppPackageRef.toMgmtApplicationPackageReference();

            // Assert
            Assert.NotNull(result);
            Assert.Null(result.Id);
            Assert.Equal("2.0.0", result.Version);
        }

        [Fact]
        public void ToMgmtApplicationPackageReference_WithEmptyApplicationId_ReturnsEmptyId()
        {
            // Arrange
            var psAppPackageRef = new PSApplicationPackageReference
            {
                ApplicationId = "",
                Version = "2.0.0"
            };

            // Act
            var result = psAppPackageRef.toMgmtApplicationPackageReference();

            // Assert
            Assert.NotNull(result);
            Assert.Equal("", result.Id);
            Assert.Equal("2.0.0", result.Version);
        }

        [Theory]
        [InlineData("myapp", "1.0.0")]
        [InlineData("batch-app", "2.1.5")]
        [InlineData("app_with_underscore", "3.0.0-beta")]
        [InlineData("app-with-dash", "1.0.0-rc1")]
        [InlineData("UPPERCASE_APP", "4.5.6")]
        [InlineData("app123", "1.2.3.4")]
        public void ToMgmtApplicationPackageReference_VariousApplicationPackages_ReturnsCorrectMapping(string applicationId, string version)
        {
            // Arrange
            var psAppPackageRef = new PSApplicationPackageReference
            {
                ApplicationId = applicationId,
                Version = version
            };

            // Act
            var result = psAppPackageRef.toMgmtApplicationPackageReference();

            // Assert
            Assert.NotNull(result);
            Assert.Equal(applicationId, result.Id);
            Assert.Equal(version, result.Version);
        }

        [Fact]
        public void ToMgmtApplicationPackageReference_AlwaysCreatesNewInstance()
        {
            // Arrange
            var psAppPackageRef = new PSApplicationPackageReference
            {
                ApplicationId = "myapp",
                Version = "1.0.0"
            };

            // Act
            var result1 = psAppPackageRef.toMgmtApplicationPackageReference();
            var result2 = psAppPackageRef.toMgmtApplicationPackageReference();

            // Assert
            Assert.NotNull(result1);
            Assert.NotNull(result2);
            Assert.NotSame(result1, result2);
        }

        [Fact]
        public void ToMgmtApplicationPackageReference_VerifyApplicationPackageReferenceType()
        {
            // Arrange
            var psAppPackageRef = new PSApplicationPackageReference
            {
                ApplicationId = "myapp",
                Version = "1.0.0"
            };

            // Act
            var result = psAppPackageRef.toMgmtApplicationPackageReference();

            // Assert
            Assert.NotNull(result);
            Assert.IsType<ApplicationPackageReference>(result);
        }

        [Fact]
        public void ToMgmtApplicationPackageReference_WithDefaultConstructor_HandlesNullValues()
        {
            // Arrange
            var psAppPackageRef = new PSApplicationPackageReference(); // Default constructor

            // Act
            var result = psAppPackageRef.toMgmtApplicationPackageReference();

            // Assert
            Assert.NotNull(result);
            Assert.Null(result.Id);
            Assert.Null(result.Version);
        }

        [Fact]
        public void ToMgmtApplicationPackageReference_WithComplexVersionNumbers_ReturnsCorrectMapping()
        {
            // Test with various version formats
            var versionFormats = new[]
            {
                "1.0",
                "1.0.0",
                "1.0.0.0",
                "2.1.3-beta",
                "3.0.0-alpha.1",
                "4.5.6-rc.2+build.123",
                "1.0.0-preview.1.2.3",
                "2021.12.15",
                "v1.0.0",
                "release-1.0"
            };

            foreach (var version in versionFormats)
            {
                // Arrange
                var psAppPackageRef = new PSApplicationPackageReference
                {
                    ApplicationId = "testapp",
                    Version = version
                };

                // Act
                var result = psAppPackageRef.toMgmtApplicationPackageReference();

                // Assert
                Assert.NotNull(result);
                Assert.Equal("testapp", result.Id);
                Assert.Equal(version, result.Version);
            }
        }

        #endregion

        #region fromMgmtApplicationPackageReference Tests

        [Fact]
        public void FromMgmtApplicationPackageReference_WithAllProperties_ReturnsCorrectMapping()
        {
            // Arrange
            var mgmtAppPackageRef = new ApplicationPackageReference
            {
                Id = "myapp",
                Version = "1.0.0"
            };

            // Act
            var result = PSApplicationPackageReference.fromMgmtApplicationPackageReference(mgmtAppPackageRef);

            // Assert
            Assert.NotNull(result);
            Assert.Equal("myapp", result.ApplicationId);
            Assert.Equal("1.0.0", result.Version);
        }

        [Fact]
        public void FromMgmtApplicationPackageReference_WithIdOnly_ReturnsCorrectMapping()
        {
            // Arrange
            var mgmtAppPackageRef = new ApplicationPackageReference
            {
                Id = "myapp",
                Version = null
            };

            // Act
            var result = PSApplicationPackageReference.fromMgmtApplicationPackageReference(mgmtAppPackageRef);

            // Assert
            Assert.NotNull(result);
            Assert.Equal("myapp", result.ApplicationId);
            Assert.Null(result.Version);
        }

        [Fact]
        public void FromMgmtApplicationPackageReference_WithNullMgmtReference_ReturnsNull()
        {
            // Act
            var result = PSApplicationPackageReference.fromMgmtApplicationPackageReference(null);

            // Assert
            Assert.Null(result);
        }

        [Fact]
        public void FromMgmtApplicationPackageReference_WithEmptyVersion_ReturnsEmptyVersion()
        {
            // Arrange
            var mgmtAppPackageRef = new ApplicationPackageReference
            {
                Id = "myapp",
                Version = ""
            };

            // Act
            var result = PSApplicationPackageReference.fromMgmtApplicationPackageReference(mgmtAppPackageRef);

            // Assert
            Assert.NotNull(result);
            Assert.Equal("myapp", result.ApplicationId);
            Assert.Equal("", result.Version);
        }

        [Fact]
        public void FromMgmtApplicationPackageReference_WithNullId_ReturnsNullApplicationId()
        {
            // Arrange
            var mgmtAppPackageRef = new ApplicationPackageReference
            {
                Id = null,
                Version = "2.0.0"
            };

            // Act
            var result = PSApplicationPackageReference.fromMgmtApplicationPackageReference(mgmtAppPackageRef);

            // Assert
            Assert.NotNull(result);
            Assert.Null(result.ApplicationId);
            Assert.Equal("2.0.0", result.Version);
        }

        [Fact]
        public void FromMgmtApplicationPackageReference_WithEmptyId_ReturnsEmptyApplicationId()
        {
            // Arrange
            var mgmtAppPackageRef = new ApplicationPackageReference
            {
                Id = "",
                Version = "2.0.0"
            };

            // Act
            var result = PSApplicationPackageReference.fromMgmtApplicationPackageReference(mgmtAppPackageRef);

            // Assert
            Assert.NotNull(result);
            Assert.Equal("", result.ApplicationId);
            Assert.Equal("2.0.0", result.Version);
        }

        [Theory]
        [InlineData("myapp", "1.0.0")]
        [InlineData("batch-app", "2.1.5")]
        [InlineData("app_with_underscore", "3.0.0-beta")]
        [InlineData("app-with-dash", "1.0.0-rc1")]
        [InlineData("UPPERCASE_APP", "4.5.6")]
        [InlineData("app123", "1.2.3.4")]
        public void FromMgmtApplicationPackageReference_VariousApplicationPackages_ReturnsCorrectMapping(string applicationId, string version)
        {
            // Arrange
            var mgmtAppPackageRef = new ApplicationPackageReference
            {
                Id = applicationId,
                Version = version
            };

            // Act
            var result = PSApplicationPackageReference.fromMgmtApplicationPackageReference(mgmtAppPackageRef);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(applicationId, result.ApplicationId);
            Assert.Equal(version, result.Version);
        }

        [Fact]
        public void FromMgmtApplicationPackageReference_StaticMethod_DoesNotRequireInstance()
        {
            // Arrange
            var mgmtAppPackageRef = new ApplicationPackageReference
            {
                Id = "myapp",
                Version = "1.0.0"
            };

            // Act - Call static method directly on class
            var result = PSApplicationPackageReference.fromMgmtApplicationPackageReference(mgmtAppPackageRef);

            // Assert
            Assert.NotNull(result);
            Assert.Equal("myapp", result.ApplicationId);
            Assert.Equal("1.0.0", result.Version);
        }

        [Fact]
        public void FromMgmtApplicationPackageReference_AlwaysCreatesNewInstance()
        {
            // Arrange
            var mgmtAppPackageRef = new ApplicationPackageReference
            {
                Id = "myapp",
                Version = "1.0.0"
            };

            // Act
            var result1 = PSApplicationPackageReference.fromMgmtApplicationPackageReference(mgmtAppPackageRef);
            var result2 = PSApplicationPackageReference.fromMgmtApplicationPackageReference(mgmtAppPackageRef);

            // Assert
            Assert.NotNull(result1);
            Assert.NotNull(result2);
            Assert.NotSame(result1, result2);
        }

        [Fact]
        public void FromMgmtApplicationPackageReference_VerifyPSApplicationPackageReferenceType()
        {
            // Arrange
            var mgmtAppPackageRef = new ApplicationPackageReference
            {
                Id = "myapp",
                Version = "1.0.0"
            };

            // Act
            var result = PSApplicationPackageReference.fromMgmtApplicationPackageReference(mgmtAppPackageRef);

            // Assert
            Assert.NotNull(result);
            Assert.IsType<PSApplicationPackageReference>(result);
        }

        [Fact]
        public void FromMgmtApplicationPackageReference_WithDefaultConstructor_HandlesNullValues()
        {
            // Arrange
            var mgmtAppPackageRef = new ApplicationPackageReference(); // Default constructor

            // Act
            var result = PSApplicationPackageReference.fromMgmtApplicationPackageReference(mgmtAppPackageRef);

            // Assert
            Assert.NotNull(result);
            Assert.Null(result.ApplicationId);
            Assert.Null(result.Version);
        }

        [Fact]
        public void FromMgmtApplicationPackageReference_WithParameterizedConstructor_ReturnsCorrectMapping()
        {
            // Arrange
            var mgmtAppPackageRef = new ApplicationPackageReference("testapp", "2.0.0");

            // Act
            var result = PSApplicationPackageReference.fromMgmtApplicationPackageReference(mgmtAppPackageRef);

            // Assert
            Assert.NotNull(result);
            Assert.Equal("testapp", result.ApplicationId);
            Assert.Equal("2.0.0", result.Version);
        }

        [Fact]
        public void FromMgmtApplicationPackageReference_WithComplexVersionNumbers_ReturnsCorrectMapping()
        {
            // Test with various version formats
            var versionFormats = new[]
            {
                "1.0",
                "1.0.0",
                "1.0.0.0",
                "2.1.3-beta",
                "3.0.0-alpha.1",
                "4.5.6-rc.2+build.123",
                "1.0.0-preview.1.2.3",
                "2021.12.15",
                "v1.0.0",
                "release-1.0"
            };

            foreach (var version in versionFormats)
            {
                // Arrange
                var mgmtAppPackageRef = new ApplicationPackageReference
                {
                    Id = "testapp",
                    Version = version
                };

                // Act
                var result = PSApplicationPackageReference.fromMgmtApplicationPackageReference(mgmtAppPackageRef);

                // Assert
                Assert.NotNull(result);
                Assert.Equal("testapp", result.ApplicationId);
                Assert.Equal(version, result.Version);
            }
        }

        #endregion

        #region Round-trip Conversion Tests

        [Fact]
        public void RoundTripConversion_ToMgmtAndFromMgmt_PreservesAllProperties()
        {
            // Arrange
            var originalPsAppPackageRef = new PSApplicationPackageReference
            {
                ApplicationId = "myapp",
                Version = "1.0.0"
            };

            // Act
            var mgmtAppPackageRef = originalPsAppPackageRef.toMgmtApplicationPackageReference();
            var roundTripPsAppPackageRef = PSApplicationPackageReference.fromMgmtApplicationPackageReference(mgmtAppPackageRef);

            // Assert
            Assert.NotNull(roundTripPsAppPackageRef);
            Assert.Equal(originalPsAppPackageRef.ApplicationId, roundTripPsAppPackageRef.ApplicationId);
            Assert.Equal(originalPsAppPackageRef.Version, roundTripPsAppPackageRef.Version);
        }

        [Fact]
        public void RoundTripConversion_ToMgmtAndFromMgmt_PreservesNullValues()
        {
            // Arrange
            var originalPsAppPackageRef = new PSApplicationPackageReference
            {
                ApplicationId = null,
                Version = null
            };

            // Act
            var mgmtAppPackageRef = originalPsAppPackageRef.toMgmtApplicationPackageReference();
            var roundTripPsAppPackageRef = PSApplicationPackageReference.fromMgmtApplicationPackageReference(mgmtAppPackageRef);

            // Assert
            Assert.NotNull(roundTripPsAppPackageRef);
            Assert.Null(roundTripPsAppPackageRef.ApplicationId);
            Assert.Null(roundTripPsAppPackageRef.Version);
        }

        [Fact]
        public void RoundTripConversion_ToMgmtAndFromMgmt_PreservesEmptyValues()
        {
            // Arrange
            var originalPsAppPackageRef = new PSApplicationPackageReference
            {
                ApplicationId = "",
                Version = ""
            };

            // Act
            var mgmtAppPackageRef = originalPsAppPackageRef.toMgmtApplicationPackageReference();
            var roundTripPsAppPackageRef = PSApplicationPackageReference.fromMgmtApplicationPackageReference(mgmtAppPackageRef);

            // Assert
            Assert.NotNull(roundTripPsAppPackageRef);
            Assert.Equal("", roundTripPsAppPackageRef.ApplicationId);
            Assert.Equal("", roundTripPsAppPackageRef.Version);
        }

        [Fact]
        public void RoundTripConversion_ToMgmtAndFromMgmt_PreservesApplicationIdOnly()
        {
            // Arrange
            var originalPsAppPackageRef = new PSApplicationPackageReference
            {
                ApplicationId = "myapp",
                Version = null
            };

            // Act
            var mgmtAppPackageRef = originalPsAppPackageRef.toMgmtApplicationPackageReference();
            var roundTripPsAppPackageRef = PSApplicationPackageReference.fromMgmtApplicationPackageReference(mgmtAppPackageRef);

            // Assert
            Assert.NotNull(roundTripPsAppPackageRef);
            Assert.Equal(originalPsAppPackageRef.ApplicationId, roundTripPsAppPackageRef.ApplicationId);
            Assert.Null(roundTripPsAppPackageRef.Version);
        }

        [Theory]
        [InlineData("myapp", "1.0.0")]
        [InlineData("batch-app", "2.1.5")]
        [InlineData("app_with_underscore", null)]
        [InlineData("", "3.0.0")]
        [InlineData(null, "4.0.0")]
        [InlineData("testapp", "")]
        public void RoundTripConversion_AllValidValues_PreservesOriginalValue(string applicationId, string version)
        {
            // Arrange
            var originalPsAppPackageRef = new PSApplicationPackageReference
            {
                ApplicationId = applicationId,
                Version = version
            };

            // Act
            var mgmtAppPackageRef = originalPsAppPackageRef.toMgmtApplicationPackageReference();
            var roundTripPsAppPackageRef = PSApplicationPackageReference.fromMgmtApplicationPackageReference(mgmtAppPackageRef);

            // Assert
            Assert.NotNull(roundTripPsAppPackageRef);
            Assert.Equal(originalPsAppPackageRef.ApplicationId, roundTripPsAppPackageRef.ApplicationId);
            Assert.Equal(originalPsAppPackageRef.Version, roundTripPsAppPackageRef.Version);
        }

        [Fact]
        public void RoundTripConversion_FromMgmtAndToMgmt_PreservesValues()
        {
            // Arrange
            var originalMgmtAppPackageRef = new ApplicationPackageReference
            {
                Id = "originalapp",
                Version = "2.5.0"
            };

            // Act
            var psAppPackageRef = PSApplicationPackageReference.fromMgmtApplicationPackageReference(originalMgmtAppPackageRef);
            var roundTripMgmtAppPackageRef = psAppPackageRef.toMgmtApplicationPackageReference();

            // Assert
            Assert.NotNull(roundTripMgmtAppPackageRef);
            Assert.Equal(originalMgmtAppPackageRef.Id, roundTripMgmtAppPackageRef.Id);
            Assert.Equal(originalMgmtAppPackageRef.Version, roundTripMgmtAppPackageRef.Version);
        }

        #endregion

        #region Integration Tests

        [Fact]
        public void ApplicationPackageReferenceConversions_BothDirections_MaintainSemanticEquivalence()
        {
            // This test ensures that the semantic meaning is preserved across conversions

            // Arrange - Test with realistic application package scenarios
            var psAppPackageRef = new PSApplicationPackageReference
            {
                ApplicationId = "blender",
                Version = "3.4.1"
            };

            // Act
            var mgmtAppPackageRef = psAppPackageRef.toMgmtApplicationPackageReference();
            var backToPs = PSApplicationPackageReference.fromMgmtApplicationPackageReference(mgmtAppPackageRef);

            // Assert
            Assert.NotNull(mgmtAppPackageRef);
            Assert.Equal("blender", mgmtAppPackageRef.Id);
            Assert.Equal("3.4.1", mgmtAppPackageRef.Version);

            Assert.NotNull(backToPs);
            Assert.Equal("blender", backToPs.ApplicationId);
            Assert.Equal("3.4.1", backToPs.Version);
        }

        [Fact]
        public void ApplicationPackageReferenceConversions_NullHandling_WorksCorrectly()
        {
            // Test null handling in conversions

            // Act
            var resultFromNull = PSApplicationPackageReference.fromMgmtApplicationPackageReference(null);

            // Assert
            Assert.Null(resultFromNull);
        }

        [Fact]
        public void ApplicationPackageReferenceConversions_BatchPoolContext_VerifyCorrectUsage()
        {
            // This test validates the conversions work correctly in the context of Batch pool configuration
            // ApplicationPackageReference is used to specify application packages for Batch pools

            // Arrange - Test with different application package scenarios
            var scenarios = new[]
            {
                // Standard application with specific version
                new {
                    ApplicationId = "ffmpeg",
                    Version = "4.4.0",
                    Description = "Video processing application with specific version"
                },
                // Application without version (uses default)
                new {
                    ApplicationId = "python",
                    Version = (string)null,
                    Description = "Python runtime using default version"
                },
                // Development application with prerelease version
                new {
                    ApplicationId = "myapp",
                    Version = "1.0.0-beta.2",
                    Description = "Custom application with prerelease version"
                },
                // System tool application
                new {
                    ApplicationId = "git",
                    Version = "2.40.1",
                    Description = "Version control system"
                }
            };

            foreach (var scenario in scenarios)
            {
                // Arrange
                var psAppPackageRef = new PSApplicationPackageReference
                {
                    ApplicationId = scenario.ApplicationId,
                    Version = scenario.Version
                };

                // Act
                var mgmtAppPackageRef = psAppPackageRef.toMgmtApplicationPackageReference();

                // Assert - Should convert correctly for Batch pool configuration
                Assert.NotNull(mgmtAppPackageRef);
                Assert.Equal(scenario.ApplicationId, mgmtAppPackageRef.Id);
                Assert.Equal(scenario.Version, mgmtAppPackageRef.Version);

                // Verify round-trip conversion maintains application package semantics
                var backToPs = PSApplicationPackageReference.fromMgmtApplicationPackageReference(mgmtAppPackageRef);
                Assert.NotNull(backToPs);
                Assert.Equal(scenario.ApplicationId, backToPs.ApplicationId);
                Assert.Equal(scenario.Version, backToPs.Version);
            }
        }

        [Fact]
        public void ApplicationPackageReferenceConversions_PropertyMapping_VerifyCorrectness()
        {
            // This test verifies the property mapping between PS and Management types
            // PSApplicationPackageReference.ApplicationId <-> ApplicationPackageReference.Id
            // PSApplicationPackageReference.Version <-> ApplicationPackageReference.Version

            // Test 1: PS to Management mapping
            var psAppPackageRef = new PSApplicationPackageReference
            {
                ApplicationId = "mapping-test-app",
                Version = "1.2.3"
            };

            var mgmtAppPackageRef = psAppPackageRef.toMgmtApplicationPackageReference();
            
            // Verify ApplicationId maps to Id
            Assert.Equal(psAppPackageRef.ApplicationId, mgmtAppPackageRef.Id);
            // Verify Version maps to Version
            Assert.Equal(psAppPackageRef.Version, mgmtAppPackageRef.Version);

            // Test 2: Management to PS mapping
            var originalMgmtRef = new ApplicationPackageReference
            {
                Id = "reverse-mapping-test",
                Version = "4.5.6"
            };

            var resultPsRef = PSApplicationPackageReference.fromMgmtApplicationPackageReference(originalMgmtRef);
            
            // Verify Id maps to ApplicationId
            Assert.Equal(originalMgmtRef.Id, resultPsRef.ApplicationId);
            // Verify Version maps to Version
            Assert.Equal(originalMgmtRef.Version, resultPsRef.Version);
        }

        [Fact]
        public void ApplicationPackageReferenceConversions_InstanceCreation_VerifyBehavior()
        {
            // This test verifies that the conversion methods create appropriate instances

            // Arrange
            var psAppPackageRef = new PSApplicationPackageReference
            {
                ApplicationId = "testapp",
                Version = "1.0.0"
            };

            var mgmtAppPackageRef = new ApplicationPackageReference
            {
                Id = "mgmtapp",
                Version = "2.0.0"
            };

            // Act
            var mgmtResult = psAppPackageRef.toMgmtApplicationPackageReference();
            var psResult = PSApplicationPackageReference.fromMgmtApplicationPackageReference(mgmtAppPackageRef);

            // Assert - Verify proper instance creation
            Assert.NotNull(mgmtResult);
            Assert.NotNull(psResult);
            Assert.IsType<ApplicationPackageReference>(mgmtResult);
            Assert.IsType<PSApplicationPackageReference>(psResult);

            // Verify new instances are created
            Assert.NotSame(mgmtAppPackageRef, mgmtResult);
            Assert.NotSame(psAppPackageRef, psResult);
        }

        #endregion

        #region Performance and Edge Case Tests

        [Fact]
        public void ApplicationPackageReferenceConversions_PerformanceTest_ExecutesQuickly()
        {
            // This test ensures the conversions are efficient

            // Arrange
            var psAppPackageRef = new PSApplicationPackageReference
            {
                ApplicationId = "perftest",
                Version = "1.0.0"
            };

            var mgmtAppPackageRef = new ApplicationPackageReference
            {
                Id = "mgmtperftest",
                Version = "2.0.0"
            };

            // Act & Assert - Multiple conversions should complete without delay
            for (int i = 0; i < 1000; i++)
            {
                var mgmtResult = psAppPackageRef.toMgmtApplicationPackageReference();
                var psResult = PSApplicationPackageReference.fromMgmtApplicationPackageReference(mgmtAppPackageRef);

                Assert.NotNull(mgmtResult);
                Assert.NotNull(psResult);
                Assert.Equal("perftest", mgmtResult.Id);
                Assert.Equal("mgmtperftest", psResult.ApplicationId);
            }
        }

        [Fact]
        public void ApplicationPackageReferenceConversions_EdgeCaseApplicationIds_HandleCorrectly()
        {
            // Test conversion with various edge case application IDs

            var testApplicationIds = new[]
            {
                // Standard application IDs
                "myapp",
                "batch-app",
                "test_app",
                
                // Special characters
                "app-with-dashes",
                "app_with_underscores",
                "app.with.dots",
                "app123",
                "123app",
                
                // Case variations
                "UPPERCASE",
                "lowercase",
                "MixedCase",
                
                // Azure/cloud specific patterns
                "microsoft-office",
                "azure-cli",
                "powershell-core",
                
                // Single character
                "a",
                
                // Long application ID
                "very-long-application-name-that-might-be-used-in-enterprise-scenarios",
                
                // Empty string
                "",
                
                // Null value
                null
            };

            foreach (var applicationId in testApplicationIds)
            {
                // Arrange
                var psAppPackageRef = new PSApplicationPackageReference
                {
                    ApplicationId = applicationId,
                    Version = "1.0.0"
                };

                // Act
                var mgmtResult = psAppPackageRef.toMgmtApplicationPackageReference();
                var roundTripResult = PSApplicationPackageReference.fromMgmtApplicationPackageReference(mgmtResult);

                // Assert
                Assert.NotNull(mgmtResult);
                Assert.NotNull(roundTripResult);
                Assert.Equal(applicationId, mgmtResult.Id);
                Assert.Equal("1.0.0", mgmtResult.Version);
                Assert.Equal(applicationId, roundTripResult.ApplicationId);
                Assert.Equal("1.0.0", roundTripResult.Version);
            }
        }

        [Fact]
        public void ApplicationPackageReferenceConversions_EdgeCaseVersions_HandleCorrectly()
        {
            // Test conversion with various edge case version strings

            var testVersions = new[]
            {
                // Standard semantic versions
                "1.0.0",
                "2.1.3",
                "10.20.30",
                
                // Prerelease versions
                "1.0.0-alpha",
                "1.0.0-beta.1",
                "1.0.0-rc.1.2.3",
                "2.0.0-preview.1",
                
                // Build metadata
                "1.0.0+build.1",
                "1.0.0-alpha+beta.1",
                "1.0.0+exp.sha.5114f85",
                
                // Date-based versions
                "2023.12.15",
                "20231215",
                
                // Legacy formats
                "v1.0.0",
                "release-1.0",
                "1.0",
                "1",
                
                // Special cases
                "latest",
                "stable",
                "dev",
                
                // Single character
                "1",
                
                // Empty string
                "",
                
                // Null value
                null
            };

            foreach (var version in testVersions)
            {
                // Arrange
                var psAppPackageRef = new PSApplicationPackageReference
                {
                    ApplicationId = "testapp",
                    Version = version
                };

                // Act
                var mgmtResult = psAppPackageRef.toMgmtApplicationPackageReference();
                var roundTripResult = PSApplicationPackageReference.fromMgmtApplicationPackageReference(mgmtResult);

                // Assert
                Assert.NotNull(mgmtResult);
                Assert.NotNull(roundTripResult);
                Assert.Equal("testapp", mgmtResult.Id);
                Assert.Equal(version, mgmtResult.Version);
                Assert.Equal("testapp", roundTripResult.ApplicationId);
                Assert.Equal(version, roundTripResult.Version);
            }
        }

        [Fact]
        public void ApplicationPackageReferenceConversions_DefaultValues_HandleCorrectly()
        {
            // Test conversion with default and null values

            // Scenario 1: Default PS constructor
            var defaultPsRef = new PSApplicationPackageReference();

            var mgmtFromDefault = defaultPsRef.toMgmtApplicationPackageReference();
            Assert.NotNull(mgmtFromDefault);
            Assert.Null(mgmtFromDefault.Id);
            Assert.Null(mgmtFromDefault.Version);

            // Scenario 2: Default management constructor
            var defaultMgmtRef = new ApplicationPackageReference();

            var psFromDefault = PSApplicationPackageReference.fromMgmtApplicationPackageReference(defaultMgmtRef);
            Assert.NotNull(psFromDefault);
            Assert.Null(psFromDefault.ApplicationId);
            Assert.Null(psFromDefault.Version);

            // Scenario 3: Parameterized management constructor with null version
            var paramMgmtRef = new ApplicationPackageReference("testapp", null);

            var psFromParam = PSApplicationPackageReference.fromMgmtApplicationPackageReference(paramMgmtRef);
            Assert.NotNull(psFromParam);
            Assert.Equal("testapp", psFromParam.ApplicationId);
            Assert.Null(psFromParam.Version);

            // Scenario 4: Round-trip with default values
            var roundTripMgmt = psFromDefault.toMgmtApplicationPackageReference();
            Assert.NotNull(roundTripMgmt);
            Assert.Null(roundTripMgmt.Id);
            Assert.Null(roundTripMgmt.Version);
        }

        #endregion
    }
}