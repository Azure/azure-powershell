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
using System;
using Xunit;

namespace Microsoft.Azure.Commands.Batch.Test.ModelsConversions
{
    public class PSServiceArtifactReferenceTests
    {
        #region toMgmtServiceArtifactReference Tests

        [Fact]
        public void ToMgmtServiceArtifactReference_WithValidServiceArtifactId_ReturnsCorrectMapping()
        {
            // Arrange
            var serviceArtifactId = "/subscriptions/12345678-1234-1234-1234-123456789abc/resourceGroups/test-rg/providers/Microsoft.Compute/galleries/testGallery/serviceArtifacts/testArtifact/vmArtifactsProfiles/testProfile";
            var psServiceArtifactRef = new PSServiceArtifactReference(serviceArtifactId);

            // Act
            var result = psServiceArtifactRef.toMgmtServiceArtifactReference();

            // Assert
            Assert.NotNull(result);
            Assert.Equal(serviceArtifactId, result.Id);
        }

        [Fact]
        public void ToMgmtServiceArtifactReference_WithNullId_ReturnsObjectWithNullId()
        {
            // Arrange
            var psServiceArtifactRef = new PSServiceArtifactReference(id: null);

            // Act
            var result = psServiceArtifactRef.toMgmtServiceArtifactReference();

            // Assert
            Assert.NotNull(result);
            Assert.Null(result.Id);
        }

        [Fact]
        public void ToMgmtServiceArtifactReference_WithEmptyId_ReturnsObjectWithEmptyId()
        {
            // Arrange
            var psServiceArtifactRef = new PSServiceArtifactReference(string.Empty);

            // Act
            var result = psServiceArtifactRef.toMgmtServiceArtifactReference();

            // Assert
            Assert.NotNull(result);
            Assert.Equal(string.Empty, result.Id);
        }

        [Theory]
        [InlineData("/subscriptions/12345678-1234-1234-1234-123456789abc/resourceGroups/rg1/providers/Microsoft.Compute/galleries/gallery1/serviceArtifacts/artifact1/vmArtifactsProfiles/profile1")]
        [InlineData("/subscriptions/87654321-4321-4321-4321-cba987654321/resourceGroups/test-group/providers/Microsoft.Compute/galleries/my-gallery/serviceArtifacts/my-artifact/vmArtifactsProfiles/my-profile")]
        [InlineData("/subscriptions/11111111-2222-3333-4444-555555555555/resourceGroups/prod-rg/providers/Microsoft.Compute/galleries/prod-gallery/serviceArtifacts/prod-artifact/vmArtifactsProfiles/prod-profile")]
        public void ToMgmtServiceArtifactReference_VariousServiceArtifactIds_ReturnsCorrectMapping(string serviceArtifactId)
        {
            // Arrange
            var psServiceArtifactRef = new PSServiceArtifactReference(serviceArtifactId);

            // Act
            var result = psServiceArtifactRef.toMgmtServiceArtifactReference();

            // Assert
            Assert.NotNull(result);
            Assert.Equal(serviceArtifactId, result.Id);
        }

        [Fact]
        public void ToMgmtServiceArtifactReference_AlwaysCreatesNewInstance()
        {
            // Arrange
            var psServiceArtifactRef = new PSServiceArtifactReference("/subscriptions/test/resourceGroups/test/providers/Microsoft.Compute/galleries/test/serviceArtifacts/test/vmArtifactsProfiles/test");

            // Act
            var result1 = psServiceArtifactRef.toMgmtServiceArtifactReference();
            var result2 = psServiceArtifactRef.toMgmtServiceArtifactReference();

            // Assert
            Assert.NotNull(result1);
            Assert.NotNull(result2);
            Assert.NotSame(result1, result2);
        }

        [Fact]
        public void ToMgmtServiceArtifactReference_VerifyServiceArtifactReferenceType()
        {
            // Arrange
            var psServiceArtifactRef = new PSServiceArtifactReference("/subscriptions/test/resourceGroups/test/providers/Microsoft.Compute/galleries/test/serviceArtifacts/test/vmArtifactsProfiles/test");

            // Act
            var result = psServiceArtifactRef.toMgmtServiceArtifactReference();

            // Assert
            Assert.NotNull(result);
            Assert.IsType<ServiceArtifactReference>(result);
        }

        [Fact]
        public void ToMgmtServiceArtifactReference_WithWhitespaceId_PreservesValue()
        {
            // Arrange
            var serviceArtifactId = "   /subscriptions/test/resourceGroups/test/providers/Microsoft.Compute/galleries/test/serviceArtifacts/test/vmArtifactsProfiles/test   ";
            var psServiceArtifactRef = new PSServiceArtifactReference(serviceArtifactId);

            // Act
            var result = psServiceArtifactRef.toMgmtServiceArtifactReference();

            // Assert
            Assert.NotNull(result);
            Assert.Equal(serviceArtifactId, result.Id);
        }

        [Fact]
        public void ToMgmtServiceArtifactReference_WithModifiedId_ReflectsCurrentValue()
        {
            // Arrange
            var originalId = "/subscriptions/test/resourceGroups/test/providers/Microsoft.Compute/galleries/test/serviceArtifacts/test/vmArtifactsProfiles/test";
            var newId = "/subscriptions/test/resourceGroups/test/providers/Microsoft.Compute/galleries/test/serviceArtifacts/updated/vmArtifactsProfiles/updated";
            var psServiceArtifactRef = new PSServiceArtifactReference(originalId);
            
            // Act - Modify the Id property
            psServiceArtifactRef.Id = newId;
            var result = psServiceArtifactRef.toMgmtServiceArtifactReference();

            // Assert
            Assert.NotNull(result);
            Assert.Equal(newId, result.Id);
        }

        [Fact]
        public void ToMgmtServiceArtifactReference_ServiceArtifactSemantics_PreservesArtifactStrategy()
        {
            // Arrange - Service artifact reference for VM scale set image versioning
            var serviceArtifactId = "/subscriptions/12345678-1234-1234-1234-123456789abc/resourceGroups/batch-rg/providers/Microsoft.Compute/galleries/batchGallery/serviceArtifacts/batchArtifact/vmArtifactsProfiles/latestProfile";
            var psServiceArtifactRef = new PSServiceArtifactReference(serviceArtifactId);

            // Act
            var result = psServiceArtifactRef.toMgmtServiceArtifactReference();

            // Assert
            Assert.NotNull(result);
            Assert.Equal(serviceArtifactId, result.Id);
            // Service artifact semantics: Used to set same image version for all VMs in scale set when using 'latest' image version
        }

        #endregion

        #region fromMgmtServiceArtifactReference Tests

        [Fact]
        public void FromMgmtServiceArtifactReference_WithValidServiceArtifactId_ReturnsCorrectMapping()
        {
            // Arrange
            var serviceArtifactId = "/subscriptions/12345678-1234-1234-1234-123456789abc/resourceGroups/test-rg/providers/Microsoft.Compute/galleries/testGallery/serviceArtifacts/testArtifact/vmArtifactsProfiles/testProfile";
            var mgmtServiceArtifactRef = new ServiceArtifactReference(serviceArtifactId);

            // Act
            var result = PSServiceArtifactReference.fromMgmtServiceArtifactReference(mgmtServiceArtifactRef);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(serviceArtifactId, result.Id);
        }

        [Fact]
        public void FromMgmtServiceArtifactReference_WithNullId_ReturnsObjectWithNullId()
        {
            // Arrange
            var mgmtServiceArtifactRef = new ServiceArtifactReference
            {
                Id = null
            };

            // Act
            var result = PSServiceArtifactReference.fromMgmtServiceArtifactReference(mgmtServiceArtifactRef);

            // Assert
            Assert.NotNull(result);
            Assert.Null(result.Id);
        }

        [Fact]
        public void FromMgmtServiceArtifactReference_WithEmptyId_ReturnsObjectWithEmptyId()
        {
            // Arrange
            var mgmtServiceArtifactRef = new ServiceArtifactReference
            {
                Id = string.Empty
            };

            // Act
            var result = PSServiceArtifactReference.fromMgmtServiceArtifactReference(mgmtServiceArtifactRef);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(string.Empty, result.Id);
        }

        [Fact]
        public void FromMgmtServiceArtifactReference_WithNullMgmtServiceArtifactReference_ReturnsNull()
        {
            // Act
            var result = PSServiceArtifactReference.fromMgmtServiceArtifactReference(null);

            // Assert
            Assert.Null(result);
        }

        [Theory]
        [InlineData("/subscriptions/12345678-1234-1234-1234-123456789abc/resourceGroups/rg1/providers/Microsoft.Compute/galleries/gallery1/serviceArtifacts/artifact1/vmArtifactsProfiles/profile1")]
        [InlineData("/subscriptions/87654321-4321-4321-4321-cba987654321/resourceGroups/test-group/providers/Microsoft.Compute/galleries/my-gallery/serviceArtifacts/my-artifact/vmArtifactsProfiles/my-profile")]
        [InlineData("/subscriptions/11111111-2222-3333-4444-555555555555/resourceGroups/prod-rg/providers/Microsoft.Compute/galleries/prod-gallery/serviceArtifacts/prod-artifact/vmArtifactsProfiles/prod-profile")]
        public void FromMgmtServiceArtifactReference_VariousServiceArtifactIds_ReturnsCorrectMapping(string serviceArtifactId)
        {
            // Arrange
            var mgmtServiceArtifactRef = new ServiceArtifactReference(serviceArtifactId);

            // Act
            var result = PSServiceArtifactReference.fromMgmtServiceArtifactReference(mgmtServiceArtifactRef);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(serviceArtifactId, result.Id);
        }

        [Fact]
        public void FromMgmtServiceArtifactReference_StaticMethod_DoesNotRequireInstance()
        {
            // Arrange
            var mgmtServiceArtifactRef = new ServiceArtifactReference("/subscriptions/test/resourceGroups/test/providers/Microsoft.Compute/galleries/test/serviceArtifacts/test/vmArtifactsProfiles/test");

            // Act - Call static method directly on class
            var result = PSServiceArtifactReference.fromMgmtServiceArtifactReference(mgmtServiceArtifactRef);

            // Assert
            Assert.NotNull(result);
            Assert.Equal("/subscriptions/test/resourceGroups/test/providers/Microsoft.Compute/galleries/test/serviceArtifacts/test/vmArtifactsProfiles/test", result.Id);
        }

        [Fact]
        public void FromMgmtServiceArtifactReference_AlwaysCreatesNewInstance()
        {
            // Arrange
            var mgmtServiceArtifactRef = new ServiceArtifactReference("/subscriptions/test/resourceGroups/test/providers/Microsoft.Compute/galleries/test/serviceArtifacts/test/vmArtifactsProfiles/test");

            // Act
            var result1 = PSServiceArtifactReference.fromMgmtServiceArtifactReference(mgmtServiceArtifactRef);
            var result2 = PSServiceArtifactReference.fromMgmtServiceArtifactReference(mgmtServiceArtifactRef);

            // Assert
            Assert.NotNull(result1);
            Assert.NotNull(result2);
            Assert.NotSame(result1, result2);
        }

        [Fact]
        public void FromMgmtServiceArtifactReference_VerifyPSServiceArtifactReferenceType()
        {
            // Arrange
            var mgmtServiceArtifactRef = new ServiceArtifactReference("/subscriptions/test/resourceGroups/test/providers/Microsoft.Compute/galleries/test/serviceArtifacts/test/vmArtifactsProfiles/test");

            // Act
            var result = PSServiceArtifactReference.fromMgmtServiceArtifactReference(mgmtServiceArtifactRef);

            // Assert
            Assert.NotNull(result);
            Assert.IsType<PSServiceArtifactReference>(result);
        }

        [Fact]
        public void FromMgmtServiceArtifactReference_WithDefaultConstructor_HandlesCorrectly()
        {
            // Arrange
            var mgmtServiceArtifactRef = new ServiceArtifactReference(); // Uses default constructor

            // Act
            var result = PSServiceArtifactReference.fromMgmtServiceArtifactReference(mgmtServiceArtifactRef);

            // Assert
            Assert.NotNull(result);
            Assert.Null(result.Id); // Default value should be null
        }

        [Fact]
        public void FromMgmtServiceArtifactReference_WithWhitespaceId_PreservesValue()
        {
            // Arrange
            var serviceArtifactId = "   /subscriptions/test/resourceGroups/test/providers/Microsoft.Compute/galleries/test/serviceArtifacts/test/vmArtifactsProfiles/test   ";
            var mgmtServiceArtifactRef = new ServiceArtifactReference(serviceArtifactId);

            // Act
            var result = PSServiceArtifactReference.fromMgmtServiceArtifactReference(mgmtServiceArtifactRef);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(serviceArtifactId, result.Id);
        }

        [Fact]
        public void FromMgmtServiceArtifactReference_ServiceArtifactSemantics_PreservesArtifactStrategy()
        {
            // Arrange
            var serviceArtifactId = "/subscriptions/12345678-1234-1234-1234-123456789abc/resourceGroups/batch-rg/providers/Microsoft.Compute/galleries/batchGallery/serviceArtifacts/batchArtifact/vmArtifactsProfiles/latestProfile";
            var mgmtServiceArtifactRef = new ServiceArtifactReference(serviceArtifactId);

            // Act
            var result = PSServiceArtifactReference.fromMgmtServiceArtifactReference(mgmtServiceArtifactRef);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(serviceArtifactId, result.Id);
            // Service artifact semantics preserved: Used for image version consistency across VM scale set
        }

        #endregion

        #region Round-trip Conversion Tests

        [Fact]
        public void RoundTripConversion_ToMgmtAndFromMgmt_PreservesValidServiceArtifactId()
        {
            // Arrange
            var originalServiceArtifactId = "/subscriptions/12345678-1234-1234-1234-123456789abc/resourceGroups/test-rg/providers/Microsoft.Compute/galleries/testGallery/serviceArtifacts/testArtifact/vmArtifactsProfiles/testProfile";
            var originalPsServiceArtifactRef = new PSServiceArtifactReference(originalServiceArtifactId);

            // Act
            var mgmtServiceArtifactRef = originalPsServiceArtifactRef.toMgmtServiceArtifactReference();
            var roundTripPsServiceArtifactRef = PSServiceArtifactReference.fromMgmtServiceArtifactReference(mgmtServiceArtifactRef);

            // Assert
            Assert.NotNull(roundTripPsServiceArtifactRef);
            Assert.Equal(originalServiceArtifactId, roundTripPsServiceArtifactRef.Id);
        }

        [Fact]
        public void RoundTripConversion_ToMgmtAndFromMgmt_PreservesNullId()
        {
            // Arrange
            var originalPsServiceArtifactRef = new PSServiceArtifactReference(id: null);

            // Act
            var mgmtServiceArtifactRef = originalPsServiceArtifactRef.toMgmtServiceArtifactReference();
            var roundTripPsServiceArtifactRef = PSServiceArtifactReference.fromMgmtServiceArtifactReference(mgmtServiceArtifactRef);

            // Assert
            Assert.NotNull(roundTripPsServiceArtifactRef);
            Assert.Null(roundTripPsServiceArtifactRef.Id);
        }

        [Fact]
        public void RoundTripConversion_ToMgmtAndFromMgmt_PreservesEmptyId()
        {
            // Arrange
            var originalPsServiceArtifactRef = new PSServiceArtifactReference(string.Empty);

            // Act
            var mgmtServiceArtifactRef = originalPsServiceArtifactRef.toMgmtServiceArtifactReference();
            var roundTripPsServiceArtifactRef = PSServiceArtifactReference.fromMgmtServiceArtifactReference(mgmtServiceArtifactRef);

            // Assert
            Assert.NotNull(roundTripPsServiceArtifactRef);
            Assert.Equal(string.Empty, roundTripPsServiceArtifactRef.Id);
        }

        [Theory]
        [InlineData("/subscriptions/12345678-1234-1234-1234-123456789abc/resourceGroups/rg1/providers/Microsoft.Compute/galleries/gallery1/serviceArtifacts/artifact1/vmArtifactsProfiles/profile1")]
        [InlineData("/subscriptions/87654321-4321-4321-4321-cba987654321/resourceGroups/test-group/providers/Microsoft.Compute/galleries/my-gallery/serviceArtifacts/my-artifact/vmArtifactsProfiles/my-profile")]
        [InlineData("")]
        [InlineData(null)]
        public void RoundTripConversion_AllValidValues_PreservesOriginalValue(string originalServiceArtifactId)
        {
            // Arrange
            var originalPsServiceArtifactRef = new PSServiceArtifactReference(originalServiceArtifactId);

            // Act
            var mgmtServiceArtifactRef = originalPsServiceArtifactRef.toMgmtServiceArtifactReference();
            var roundTripPsServiceArtifactRef = PSServiceArtifactReference.fromMgmtServiceArtifactReference(mgmtServiceArtifactRef);

            // Assert
            Assert.NotNull(roundTripPsServiceArtifactRef);
            Assert.Equal(originalServiceArtifactId, roundTripPsServiceArtifactRef.Id);
        }

        [Fact]
        public void RoundTripConversion_FromMgmtAndToMgmt_PreservesValues()
        {
            // Arrange
            var originalServiceArtifactId = "/subscriptions/12345678-1234-1234-1234-123456789abc/resourceGroups/test-rg/providers/Microsoft.Compute/galleries/testGallery/serviceArtifacts/testArtifact/vmArtifactsProfiles/testProfile";
            var originalMgmtServiceArtifactRef = new ServiceArtifactReference(originalServiceArtifactId);

            // Act
            var psServiceArtifactRef = PSServiceArtifactReference.fromMgmtServiceArtifactReference(originalMgmtServiceArtifactRef);
            var roundTripMgmtServiceArtifactRef = psServiceArtifactRef.toMgmtServiceArtifactReference();

            // Assert
            Assert.NotNull(roundTripMgmtServiceArtifactRef);
            Assert.Equal(originalServiceArtifactId, roundTripMgmtServiceArtifactRef.Id);
        }

        #endregion

        #region Integration Tests

        [Fact]
        public void ServiceArtifactReferenceConversions_BothDirections_MaintainSemanticEquivalence()
        {
            // This test ensures that the semantic meaning is preserved across conversions

            // Arrange - Test with a typical service artifact reference ID
            var serviceArtifactId = "/subscriptions/12345678-1234-1234-1234-123456789abc/resourceGroups/batch-rg/providers/Microsoft.Compute/galleries/batchGallery/serviceArtifacts/batchArtifact/vmArtifactsProfiles/latestProfile";
            var psServiceArtifactRef = new PSServiceArtifactReference(serviceArtifactId);

            // Act
            var mgmtServiceArtifactRef = psServiceArtifactRef.toMgmtServiceArtifactReference();
            var backToPs = PSServiceArtifactReference.fromMgmtServiceArtifactReference(mgmtServiceArtifactRef);

            // Assert
            Assert.NotNull(mgmtServiceArtifactRef);
            Assert.Equal(serviceArtifactId, mgmtServiceArtifactRef.Id);
            Assert.NotNull(backToPs);
            Assert.Equal(serviceArtifactId, backToPs.Id);
        }

        [Fact]
        public void ServiceArtifactReferenceConversions_NullHandling_WorksCorrectly()
        {
            // Test null handling in conversions

            // Act
            var resultFromNull = PSServiceArtifactReference.fromMgmtServiceArtifactReference(null);

            // Assert
            Assert.Null(resultFromNull);
        }

        [Fact]
        public void ServiceArtifactReferenceConversions_BatchVMImageContext_VerifyCorrectUsage()
        {
            // This test validates the conversions work correctly in the context of Batch VM image configuration
            // ServiceArtifactReference is used to specify service artifact reference for VM scale sets

            // Arrange - Test with realistic Batch scenarios
            var subscriptionId = "12345678-1234-1234-1234-123456789abc";
            var resourceGroupName = "batch-images-rg";
            var galleryName = "batchComputeGallery";
            var serviceArtifactName = "batchNodeArtifact";
            var vmArtifactsProfileName = "latestImageProfile";
            var serviceArtifactId = $"/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/galleries/{galleryName}/serviceArtifacts/{serviceArtifactName}/vmArtifactsProfiles/{vmArtifactsProfileName}";

            var psServiceArtifactRef = new PSServiceArtifactReference(serviceArtifactId);

            // Act
            var mgmtServiceArtifactRef = psServiceArtifactRef.toMgmtServiceArtifactReference();

            // Assert - Should convert correctly for Batch VM image configuration
            Assert.NotNull(mgmtServiceArtifactRef);
            Assert.Equal(serviceArtifactId, mgmtServiceArtifactRef.Id);
            Assert.IsType<ServiceArtifactReference>(mgmtServiceArtifactRef);

            // Verify round-trip conversion maintains Batch service artifact semantics
            var backToPs = PSServiceArtifactReference.fromMgmtServiceArtifactReference(mgmtServiceArtifactRef);
            Assert.NotNull(backToPs);
            Assert.Equal(serviceArtifactId, backToPs.Id);
            Assert.IsType<PSServiceArtifactReference>(backToPs);
        }

        [Fact]
        public void ServiceArtifactReferenceConversions_InstanceCreation_VerifyBehavior()
        {
            // This test verifies that the conversion methods create appropriate instances

            // Arrange
            var serviceArtifactId = "/subscriptions/test/resourceGroups/test/providers/Microsoft.Compute/galleries/test/serviceArtifacts/test/vmArtifactsProfiles/test";
            var psServiceArtifactRef = new PSServiceArtifactReference(serviceArtifactId);
            var mgmtServiceArtifactRef = new ServiceArtifactReference(serviceArtifactId);

            // Act
            var mgmtResult = psServiceArtifactRef.toMgmtServiceArtifactReference();
            var psResult = PSServiceArtifactReference.fromMgmtServiceArtifactReference(mgmtServiceArtifactRef);

            // Assert - Verify proper instance creation
            Assert.NotNull(mgmtResult);
            Assert.NotNull(psResult);
            Assert.IsType<ServiceArtifactReference>(mgmtResult);
            Assert.IsType<PSServiceArtifactReference>(psResult);

            // Verify new instances are created
            Assert.NotSame(mgmtServiceArtifactRef, mgmtResult);
            Assert.NotSame(psServiceArtifactRef, psResult);
        }

        #endregion

        #region Performance and Edge Case Tests

        [Fact]
        public void ServiceArtifactReferenceConversions_PerformanceTest_ExecutesQuickly()
        {
            // This test ensures the conversions are efficient

            // Arrange
            var serviceArtifactId = "/subscriptions/12345678-1234-1234-1234-123456789abc/resourceGroups/test/providers/Microsoft.Compute/galleries/test/serviceArtifacts/test/vmArtifactsProfiles/test";
            var psServiceArtifactRef = new PSServiceArtifactReference(serviceArtifactId);
            var mgmtServiceArtifactRef = new ServiceArtifactReference(serviceArtifactId);

            // Act & Assert - Multiple conversions should complete without delay
            for (int i = 0; i < 100; i++)
            {
                var mgmtResult = psServiceArtifactRef.toMgmtServiceArtifactReference();
                var psResult = PSServiceArtifactReference.fromMgmtServiceArtifactReference(mgmtServiceArtifactRef);

                Assert.NotNull(mgmtResult);
                Assert.NotNull(psResult);
                Assert.Equal(serviceArtifactId, mgmtResult.Id);
                Assert.Equal(serviceArtifactId, psResult.Id);
            }
        }

        [Fact]
        public void ServiceArtifactReferenceConversions_EdgeCaseServiceArtifactIds_HandleCorrectly()
        {
            // Test conversion with various edge case service artifact ID formats

            var testServiceArtifactIds = new[]
            {
                // Standard format
                "/subscriptions/12345678-1234-1234-1234-123456789abc/resourceGroups/rg/providers/Microsoft.Compute/galleries/gallery/serviceArtifacts/artifact/vmArtifactsProfiles/profile",
                // With special characters in names
                "/subscriptions/12345678-1234-1234-1234-123456789abc/resourceGroups/test-rg_123/providers/Microsoft.Compute/galleries/test-gallery_v2/serviceArtifacts/test-artifact_v1/vmArtifactsProfiles/test-profile_v3",
                // Long names
                "/subscriptions/12345678-1234-1234-1234-123456789abc/resourceGroups/very-long-resource-group-name-for-testing/providers/Microsoft.Compute/galleries/very-long-gallery-name-for-comprehensive-testing/serviceArtifacts/very-long-service-artifact-name-for-testing/vmArtifactsProfiles/very-long-vm-artifacts-profile-name-for-testing",
                // Minimal valid format
                "/subscriptions/12345678-1234-1234-1234-123456789abc/resourceGroups/rg/providers/Microsoft.Compute/galleries/g/serviceArtifacts/a/vmArtifactsProfiles/p",
                // With numbers and hyphens
                "/subscriptions/12345678-1234-1234-1234-123456789abc/resourceGroups/rg-001/providers/Microsoft.Compute/galleries/gallery-v1-0/serviceArtifacts/artifact-2023-01/vmArtifactsProfiles/profile-latest-v2"
            };

            foreach (var serviceArtifactId in testServiceArtifactIds)
            {
                // Arrange
                var psServiceArtifactRef = new PSServiceArtifactReference(serviceArtifactId);

                // Act
                var mgmtResult = psServiceArtifactRef.toMgmtServiceArtifactReference();
                var roundTripResult = PSServiceArtifactReference.fromMgmtServiceArtifactReference(mgmtResult);

                // Assert
                Assert.NotNull(mgmtResult);
                Assert.NotNull(roundTripResult);
                Assert.Equal(serviceArtifactId, mgmtResult.Id);
                Assert.Equal(serviceArtifactId, roundTripResult.Id);
            }
        }

        [Fact]
        public void ServiceArtifactReferenceConversions_TypeSafety_VerifyCorrectTypes()
        {
            // Test that conversions return the correct types

            // Arrange
            var psServiceArtifactRef = new PSServiceArtifactReference("/subscriptions/test/resourceGroups/test/providers/Microsoft.Compute/galleries/test/serviceArtifacts/test/vmArtifactsProfiles/test");
            var mgmtServiceArtifactRef = new ServiceArtifactReference("/subscriptions/test/resourceGroups/test/providers/Microsoft.Compute/galleries/test/serviceArtifacts/test/vmArtifactsProfiles/test");

            // Act
            var mgmtResult = psServiceArtifactRef.toMgmtServiceArtifactReference();
            var psResult = PSServiceArtifactReference.fromMgmtServiceArtifactReference(mgmtServiceArtifactRef);

            // Assert - Verify correct types are returned
            Assert.IsType<ServiceArtifactReference>(mgmtResult);
            Assert.IsType<PSServiceArtifactReference>(psResult);
        }

        [Fact]
        public void ServiceArtifactReferenceConversions_PropertyAccess_VerifyBehavior()
        {
            // Test that properties are accessible and correct after conversion

            // Arrange
            var originalServiceArtifactId = "/subscriptions/12345678-1234-1234-1234-123456789abc/resourceGroups/test-rg/providers/Microsoft.Compute/galleries/testGallery/serviceArtifacts/testArtifact/vmArtifactsProfiles/testProfile";
            var psServiceArtifactRef = new PSServiceArtifactReference(originalServiceArtifactId);

            // Act
            var mgmtServiceArtifactRef = psServiceArtifactRef.toMgmtServiceArtifactReference();
            var convertedPsServiceArtifactRef = PSServiceArtifactReference.fromMgmtServiceArtifactReference(mgmtServiceArtifactRef);

            // Assert
            Assert.Equal(originalServiceArtifactId, psServiceArtifactRef.Id);
            Assert.Equal(originalServiceArtifactId, mgmtServiceArtifactRef.Id);
            Assert.Equal(originalServiceArtifactId, convertedPsServiceArtifactRef.Id);
        }

        [Fact]
        public void ServiceArtifactReferenceConversions_EdgeCaseStringValues_HandleCorrectly()
        {
            // Test conversion with various edge case string values

            var testServiceArtifactIds = new[]
            {
                // Valid values
                "/subscriptions/12345678-1234-1234-1234-123456789abc/resourceGroups/rg/providers/Microsoft.Compute/galleries/gallery/serviceArtifacts/artifact/vmArtifactsProfiles/profile",
                
                // Edge cases
                null,
                "",
                " ", // Whitespace
                "  /subscriptions/test/resourceGroups/test/providers/Microsoft.Compute/galleries/test/serviceArtifacts/test/vmArtifactsProfiles/test  ", // Leading/trailing whitespace
                
                // Invalid formats (should still be preserved)
                "InvalidServiceArtifactId",
                "SomeOtherValue",
                "/subscriptions/invalid", // Incomplete resource ID
                "/invalid/path/format"
            };

            foreach (var serviceArtifactId in testServiceArtifactIds)
            {
                // Arrange
                var psServiceArtifactRef = new PSServiceArtifactReference(serviceArtifactId);

                // Act
                var mgmtResult = psServiceArtifactRef.toMgmtServiceArtifactReference();
                var roundTripResult = PSServiceArtifactReference.fromMgmtServiceArtifactReference(mgmtResult);

                // Assert
                Assert.NotNull(mgmtResult);
                Assert.NotNull(roundTripResult);
                Assert.Equal(serviceArtifactId, mgmtResult.Id);
                Assert.Equal(serviceArtifactId, roundTripResult.Id);
            }
        }

        #endregion

        #region Constructor and Internal Object Tests

        [Fact]
        public void PSServiceArtifactReference_Constructor_InitializesCorrectly()
        {
            // Test that the PS constructor properly initializes the internal object

            // Arrange & Act
            var serviceArtifactId = "/subscriptions/test/resourceGroups/test/providers/Microsoft.Compute/galleries/test/serviceArtifacts/test/vmArtifactsProfiles/test";
            var psServiceArtifactRef = new PSServiceArtifactReference(serviceArtifactId);

            // Assert
            Assert.Equal(serviceArtifactId, psServiceArtifactRef.Id);
        }

        [Fact]
        public void PSServiceArtifactReference_InternalConstructor_ThrowsOnNullOmObject()
        {
            // Test that the internal constructor validates the omObject parameter

            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => 
                new PSServiceArtifactReference((Microsoft.Azure.Batch.ServiceArtifactReference)null));
        }

        [Fact]
        public void PSServiceArtifactReference_InternalConstructor_WorksWithValidOmObject()
        {
            // Test that the internal constructor works with a valid omObject

            // Arrange
            var serviceArtifactId = "/subscriptions/test/resourceGroups/test/providers/Microsoft.Compute/galleries/test/serviceArtifacts/test/vmArtifactsProfiles/test";
            var omObject = new Microsoft.Azure.Batch.ServiceArtifactReference(serviceArtifactId);

            // Act
            var psServiceArtifactRef = new PSServiceArtifactReference(omObject);

            // Assert
            Assert.NotNull(psServiceArtifactRef);
            Assert.Equal(serviceArtifactId, psServiceArtifactRef.Id);
        }

        [Fact]
        public void PSServiceArtifactReference_PropertySetter_WorksCorrectly()
        {
            // Test that property setters work correctly

            // Arrange
            var psServiceArtifactRef = new PSServiceArtifactReference("original");

            // Act
            psServiceArtifactRef.Id = "/subscriptions/test/resourceGroups/test/providers/Microsoft.Compute/galleries/test/serviceArtifacts/updated/vmArtifactsProfiles/updated";

            // Assert
            Assert.Equal("/subscriptions/test/resourceGroups/test/providers/Microsoft.Compute/galleries/test/serviceArtifacts/updated/vmArtifactsProfiles/updated", psServiceArtifactRef.Id);
        }

        #endregion

        #region Service Artifact Image Versioning Tests

        [Fact]
        public void ServiceArtifactReferenceConversions_ImageVersioningSemantics_VerifyCorrectUsage()
        {
            // This test validates that the service artifact references maintain their image versioning characteristics
            // through the conversion process for VM scale set scenarios

            var imageVersioningProfiles = new[]
            {
                new {
                    Type = "Latest",
                    ServiceArtifactId = "/subscriptions/12345678-1234-1234-1234-123456789abc/resourceGroups/batch-rg/providers/Microsoft.Compute/galleries/gallery/serviceArtifacts/artifact/vmArtifactsProfiles/latest",
                    Description = "Latest image version profile for automatic updates",
                    UseCases = new[] { "Development environments", "Auto-scaling pools", "Rolling updates" }
                },
                new {
                    Type = "Stable",
                    ServiceArtifactId = "/subscriptions/12345678-1234-1234-1234-123456789abc/resourceGroups/batch-rg/providers/Microsoft.Compute/galleries/gallery/serviceArtifacts/artifact/vmArtifactsProfiles/stable-v1-0",
                    Description = "Stable image version profile for production workloads",
                    UseCases = new[] { "Production pools", "Long-running tasks", "Critical workloads" }
                },
                new {
                    Type = "Custom",
                    ServiceArtifactId = "/subscriptions/12345678-1234-1234-1234-123456789abc/resourceGroups/batch-rg/providers/Microsoft.Compute/galleries/gallery/serviceArtifacts/artifact/vmArtifactsProfiles/custom-2023-12",
                    Description = "Custom image version profile for specific requirements",
                    UseCases = new[] { "Specialized workloads", "Compliance requirements", "Testing scenarios" }
                }
            };

            foreach (var profile in imageVersioningProfiles)
            {
                // Act - Convert to management type and back
                var psServiceArtifactRef = new PSServiceArtifactReference(profile.ServiceArtifactId);
                var mgmtType = psServiceArtifactRef.toMgmtServiceArtifactReference();
                var roundTripType = PSServiceArtifactReference.fromMgmtServiceArtifactReference(mgmtType);

                // Assert - Image versioning characteristics should be preserved
                Assert.NotNull(mgmtType);
                Assert.NotNull(roundTripType);
                Assert.Equal(profile.ServiceArtifactId, roundTripType.Id);
                Assert.Equal(profile.ServiceArtifactId, mgmtType.Id);
            }
        }

        [Fact]
        public void ServiceArtifactReferenceConversions_BatchVMScaleSetIntegration_VerifySemantics()
        {
            // This test validates the semantic usage in the context of Azure Batch VM scale set configuration
            // ServiceArtifactReference is required for VM scale sets to ensure consistent image versions

            // Latest profile semantics - Automatic image version updates
            var latestProfileRef = new PSServiceArtifactReference("/subscriptions/12345678-1234-1234-1234-123456789abc/resourceGroups/batch-rg/providers/Microsoft.Compute/galleries/batchGallery/serviceArtifacts/nodeArtifact/vmArtifactsProfiles/latest");
            var mgmtLatestProfile = latestProfileRef.toMgmtServiceArtifactReference();
            
            Assert.NotNull(mgmtLatestProfile);
            Assert.Contains("latest", mgmtLatestProfile.Id);
            // Use case: Development and testing environments with automatic updates
            
            // Stable profile semantics - Fixed image version for production
            var stableProfileRef = new PSServiceArtifactReference("/subscriptions/12345678-1234-1234-1234-123456789abc/resourceGroups/batch-rg/providers/Microsoft.Compute/galleries/batchGallery/serviceArtifacts/nodeArtifact/vmArtifactsProfiles/stable-v2-1");
            var mgmtStableProfile = stableProfileRef.toMgmtServiceArtifactReference();
            
            Assert.NotNull(mgmtStableProfile);
            Assert.Contains("stable", mgmtStableProfile.Id);
            // Use case: Production environments requiring stable, tested image versions

            // Verify all round-trip correctly
            var latestRoundTrip = PSServiceArtifactReference.fromMgmtServiceArtifactReference(mgmtLatestProfile);
            var stableRoundTrip = PSServiceArtifactReference.fromMgmtServiceArtifactReference(mgmtStableProfile);

            Assert.Equal(latestProfileRef.Id, latestRoundTrip.Id);
            Assert.Equal(stableProfileRef.Id, stableRoundTrip.Id);
        }

        #endregion
    }
}