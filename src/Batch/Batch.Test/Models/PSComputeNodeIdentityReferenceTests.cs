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
    public class PSComputeNodeIdentityReferenceTests
    {
        #region toMgmtIdentityReference Tests

        [Fact]
        public void ToMgmtIdentityReference_WithValidResourceId_ReturnsCorrectMapping()
        {
            // Arrange
            var resourceId = "/subscriptions/12345678-1234-1234-1234-123456789abc/resourceGroups/test-rg/providers/Microsoft.ManagedIdentity/userAssignedIdentities/test-identity";
            var psIdentityRef = new PSComputeNodeIdentityReference
            {
                ResourceId = resourceId
            };

            // Act
            var result = psIdentityRef.toMgmtIdentityReference();

            // Assert
            Assert.NotNull(result);
            Assert.Equal(resourceId, result.ResourceId);
        }

        [Fact]
        public void ToMgmtIdentityReference_WithNullResourceId_ReturnsObjectWithNullResourceId()
        {
            // Arrange
            var psIdentityRef = new PSComputeNodeIdentityReference
            {
                ResourceId = null
            };

            // Act
            var result = psIdentityRef.toMgmtIdentityReference();

            // Assert
            Assert.NotNull(result);
            Assert.Null(result.ResourceId);
        }

        [Fact]
        public void ToMgmtIdentityReference_WithEmptyResourceId_ReturnsObjectWithEmptyResourceId()
        {
            // Arrange
            var psIdentityRef = new PSComputeNodeIdentityReference
            {
                ResourceId = string.Empty
            };

            // Act
            var result = psIdentityRef.toMgmtIdentityReference();

            // Assert
            Assert.NotNull(result);
            Assert.Equal(string.Empty, result.ResourceId);
        }

        [Fact]
        public void ToMgmtIdentityReference_WithNullOmObject_ReturnsNull()
        {
            // Arrange
            var psIdentityRef = new PSComputeNodeIdentityReference();
            // Set omObject to null using reflection to simulate the condition
            psIdentityRef.GetType().GetField("omObject", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance)
                ?.SetValue(psIdentityRef, null);

            // Act
            var result = psIdentityRef.toMgmtIdentityReference();

            // Assert
            Assert.Null(result);
        }

        [Theory]
        [InlineData("/subscriptions/12345678-1234-1234-1234-123456789abc/resourceGroups/rg1/providers/Microsoft.ManagedIdentity/userAssignedIdentities/identity1")]
        [InlineData("/subscriptions/87654321-4321-4321-4321-cba987654321/resourceGroups/test-group/providers/Microsoft.ManagedIdentity/userAssignedIdentities/my-identity")]
        [InlineData("/subscriptions/11111111-2222-3333-4444-555555555555/resourceGroups/prod-rg/providers/Microsoft.ManagedIdentity/userAssignedIdentities/prod-identity")]
        public void ToMgmtIdentityReference_VariousResourceIds_ReturnsCorrectMapping(string resourceId)
        {
            // Arrange
            var psIdentityRef = new PSComputeNodeIdentityReference
            {
                ResourceId = resourceId
            };

            // Act
            var result = psIdentityRef.toMgmtIdentityReference();

            // Assert
            Assert.NotNull(result);
            Assert.Equal(resourceId, result.ResourceId);
        }

        [Fact]
        public void ToMgmtIdentityReference_AlwaysCreatesNewInstance()
        {
            // Arrange
            var psIdentityRef = new PSComputeNodeIdentityReference
            {
                ResourceId = "/subscriptions/test/resourceGroups/test/providers/Microsoft.ManagedIdentity/userAssignedIdentities/test"
            };

            // Act
            var result1 = psIdentityRef.toMgmtIdentityReference();
            var result2 = psIdentityRef.toMgmtIdentityReference();

            // Assert
            Assert.NotNull(result1);
            Assert.NotNull(result2);
            Assert.NotSame(result1, result2);
        }

        [Fact]
        public void ToMgmtIdentityReference_VerifyComputeNodeIdentityReferenceType()
        {
            // Arrange
            var psIdentityRef = new PSComputeNodeIdentityReference
            {
                ResourceId = "/subscriptions/test/resourceGroups/test/providers/Microsoft.ManagedIdentity/userAssignedIdentities/test"
            };

            // Act
            var result = psIdentityRef.toMgmtIdentityReference();

            // Assert
            Assert.NotNull(result);
            Assert.IsType<ComputeNodeIdentityReference>(result);
        }

        [Fact]
        public void ToMgmtIdentityReference_WithWhitespaceResourceId_PreservesValue()
        {
            // Arrange
            var resourceId = "   /subscriptions/test/resourceGroups/test/providers/Microsoft.ManagedIdentity/userAssignedIdentities/test   ";
            var psIdentityRef = new PSComputeNodeIdentityReference
            {
                ResourceId = resourceId
            };

            // Act
            var result = psIdentityRef.toMgmtIdentityReference();

            // Assert
            Assert.NotNull(result);
            Assert.Equal(resourceId, result.ResourceId);
        }

        #endregion

        #region fromMgmtIdentityReference Tests

        [Fact]
        public void FromMgmtIdentityReference_WithValidResourceId_ReturnsCorrectMapping()
        {
            // Arrange
            var resourceId = "/subscriptions/12345678-1234-1234-1234-123456789abc/resourceGroups/test-rg/providers/Microsoft.ManagedIdentity/userAssignedIdentities/test-identity";
            var mgmtIdentityRef = new ComputeNodeIdentityReference(resourceId);

            // Act
            var result = PSComputeNodeIdentityReference.fromMgmtIdentityReference(mgmtIdentityRef);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(resourceId, result.ResourceId);
        }

        [Fact]
        public void FromMgmtIdentityReference_WithNullResourceId_ReturnsObjectWithNullResourceId()
        {
            // Arrange
            var mgmtIdentityRef = new ComputeNodeIdentityReference
            {
                ResourceId = null
            };

            // Act
            var result = PSComputeNodeIdentityReference.fromMgmtIdentityReference(mgmtIdentityRef);

            // Assert
            Assert.NotNull(result);
            Assert.Null(result.ResourceId);
        }

        [Fact]
        public void FromMgmtIdentityReference_WithEmptyResourceId_ReturnsObjectWithEmptyResourceId()
        {
            // Arrange
            var mgmtIdentityRef = new ComputeNodeIdentityReference
            {
                ResourceId = string.Empty
            };

            // Act
            var result = PSComputeNodeIdentityReference.fromMgmtIdentityReference(mgmtIdentityRef);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(string.Empty, result.ResourceId);
        }

        [Fact]
        public void FromMgmtIdentityReference_WithNullMgmtIdentityReference_ReturnsNull()
        {
            // Act
            var result = PSComputeNodeIdentityReference.fromMgmtIdentityReference(null);

            // Assert
            Assert.Null(result);
        }

        [Theory]
        [InlineData("/subscriptions/12345678-1234-1234-1234-123456789abc/resourceGroups/rg1/providers/Microsoft.ManagedIdentity/userAssignedIdentities/identity1")]
        [InlineData("/subscriptions/87654321-4321-4321-4321-cba987654321/resourceGroups/test-group/providers/Microsoft.ManagedIdentity/userAssignedIdentities/my-identity")]
        [InlineData("/subscriptions/11111111-2222-3333-4444-555555555555/resourceGroups/prod-rg/providers/Microsoft.ManagedIdentity/userAssignedIdentities/prod-identity")]
        public void FromMgmtIdentityReference_VariousResourceIds_ReturnsCorrectMapping(string resourceId)
        {
            // Arrange
            var mgmtIdentityRef = new ComputeNodeIdentityReference(resourceId);

            // Act
            var result = PSComputeNodeIdentityReference.fromMgmtIdentityReference(mgmtIdentityRef);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(resourceId, result.ResourceId);
        }

        [Fact]
        public void FromMgmtIdentityReference_StaticMethod_DoesNotRequireInstance()
        {
            // Arrange
            var mgmtIdentityRef = new ComputeNodeIdentityReference("/subscriptions/test/resourceGroups/test/providers/Microsoft.ManagedIdentity/userAssignedIdentities/test");

            // Act - Call static method directly on class
            var result = PSComputeNodeIdentityReference.fromMgmtIdentityReference(mgmtIdentityRef);

            // Assert
            Assert.NotNull(result);
            Assert.Equal("/subscriptions/test/resourceGroups/test/providers/Microsoft.ManagedIdentity/userAssignedIdentities/test", result.ResourceId);
        }

        [Fact]
        public void FromMgmtIdentityReference_AlwaysCreatesNewInstance()
        {
            // Arrange
            var mgmtIdentityRef = new ComputeNodeIdentityReference("/subscriptions/test/resourceGroups/test/providers/Microsoft.ManagedIdentity/userAssignedIdentities/test");

            // Act
            var result1 = PSComputeNodeIdentityReference.fromMgmtIdentityReference(mgmtIdentityRef);
            var result2 = PSComputeNodeIdentityReference.fromMgmtIdentityReference(mgmtIdentityRef);

            // Assert
            Assert.NotNull(result1);
            Assert.NotNull(result2);
            Assert.NotSame(result1, result2);
        }

        [Fact]
        public void FromMgmtIdentityReference_VerifyPSComputeNodeIdentityReferenceType()
        {
            // Arrange
            var mgmtIdentityRef = new ComputeNodeIdentityReference("/subscriptions/test/resourceGroups/test/providers/Microsoft.ManagedIdentity/userAssignedIdentities/test");

            // Act
            var result = PSComputeNodeIdentityReference.fromMgmtIdentityReference(mgmtIdentityRef);

            // Assert
            Assert.NotNull(result);
            Assert.IsType<Microsoft.Azure.Batch.ComputeNodeIdentityReference>(result);
        }

        [Fact]
        public void FromMgmtIdentityReference_WithDefaultConstructor_HandlesCorrectly()
        {
            // Arrange
            var mgmtIdentityRef = new ComputeNodeIdentityReference(); // Uses default constructor

            // Act
            var result = PSComputeNodeIdentityReference.fromMgmtIdentityReference(mgmtIdentityRef);

            // Assert
            Assert.NotNull(result);
            Assert.Null(result.ResourceId); // Default value should be null
        }

        [Fact]
        public void FromMgmtIdentityReference_WithWhitespaceResourceId_PreservesValue()
        {
            // Arrange
            var resourceId = "   /subscriptions/test/resourceGroups/test/providers/Microsoft.ManagedIdentity/userAssignedIdentities/test   ";
            var mgmtIdentityRef = new ComputeNodeIdentityReference(resourceId);

            // Act
            var result = PSComputeNodeIdentityReference.fromMgmtIdentityReference(mgmtIdentityRef);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(resourceId, result.ResourceId);
        }

        #endregion

        #region Round-trip Conversion Tests

        [Fact]
        public void RoundTripConversion_ToMgmtAndFromMgmt_PreservesValidResourceId()
        {
            // Arrange
            var originalResourceId = "/subscriptions/12345678-1234-1234-1234-123456789abc/resourceGroups/test-rg/providers/Microsoft.ManagedIdentity/userAssignedIdentities/test-identity";
            var originalPsIdentityRef = new PSComputeNodeIdentityReference
            {
                ResourceId = originalResourceId
            };

            // Act
            var mgmtIdentityRef = originalPsIdentityRef.toMgmtIdentityReference();
            var roundTripPsIdentityRef = PSComputeNodeIdentityReference.fromMgmtIdentityReference(mgmtIdentityRef);

            // Assert
            Assert.NotNull(roundTripPsIdentityRef);
            Assert.Equal(originalResourceId, roundTripPsIdentityRef.ResourceId);
        }

        [Fact]
        public void RoundTripConversion_ToMgmtAndFromMgmt_PreservesNullResourceId()
        {
            // Arrange
            var originalPsIdentityRef = new PSComputeNodeIdentityReference
            {
                ResourceId = null
            };

            // Act
            var mgmtIdentityRef = originalPsIdentityRef.toMgmtIdentityReference();
            var roundTripPsIdentityRef = PSComputeNodeIdentityReference.fromMgmtIdentityReference(mgmtIdentityRef);

            // Assert
            Assert.NotNull(roundTripPsIdentityRef);
            Assert.Null(roundTripPsIdentityRef.ResourceId);
        }

        [Fact]
        public void RoundTripConversion_ToMgmtAndFromMgmt_PreservesEmptyResourceId()
        {
            // Arrange
            var originalPsIdentityRef = new PSComputeNodeIdentityReference
            {
                ResourceId = string.Empty
            };

            // Act
            var mgmtIdentityRef = originalPsIdentityRef.toMgmtIdentityReference();
            var roundTripPsIdentityRef = PSComputeNodeIdentityReference.fromMgmtIdentityReference(mgmtIdentityRef);

            // Assert
            Assert.NotNull(roundTripPsIdentityRef);
            Assert.Equal(string.Empty, roundTripPsIdentityRef.ResourceId);
        }

        [Theory]
        [InlineData("/subscriptions/12345678-1234-1234-1234-123456789abc/resourceGroups/rg1/providers/Microsoft.ManagedIdentity/userAssignedIdentities/identity1")]
        [InlineData("/subscriptions/87654321-4321-4321-4321-cba987654321/resourceGroups/test-group/providers/Microsoft.ManagedIdentity/userAssignedIdentities/my-identity")]
        [InlineData("")]
        [InlineData(null)]
        public void RoundTripConversion_AllValidValues_PreservesOriginalValue(string originalResourceId)
        {
            // Arrange
            var originalPsIdentityRef = new PSComputeNodeIdentityReference
            {
                ResourceId = originalResourceId
            };

            // Act
            var mgmtIdentityRef = originalPsIdentityRef.toMgmtIdentityReference();
            if (mgmtIdentityRef != null)
            {
                var roundTripPsIdentityRef = PSComputeNodeIdentityReference.fromMgmtIdentityReference(mgmtIdentityRef);

                // Assert
                Assert.NotNull(roundTripPsIdentityRef);
                Assert.Equal(originalResourceId, roundTripPsIdentityRef.ResourceId);
            }
        }

        [Fact]
        public void RoundTripConversion_FromMgmtAndToMgmt_PreservesValues()
        {
            // Arrange
            var originalResourceId = "/subscriptions/12345678-1234-1234-1234-123456789abc/resourceGroups/test-rg/providers/Microsoft.ManagedIdentity/userAssignedIdentities/test-identity";
            var originalMgmtIdentityRef = new ComputeNodeIdentityReference(originalResourceId);

            // Act
            var psIdentityRef =  new PSComputeNodeIdentityReference(PSComputeNodeIdentityReference.fromMgmtIdentityReference(originalMgmtIdentityRef));
            var roundTripMgmtIdentityRef = psIdentityRef.toMgmtIdentityReference();

            // Assert
            Assert.NotNull(roundTripMgmtIdentityRef);
            Assert.Equal(originalResourceId, roundTripMgmtIdentityRef.ResourceId);
        }

        #endregion

        #region Integration Tests

        [Fact]
        public void IdentityReferenceConversions_BothDirections_MaintainSemanticEquivalence()
        {
            // This test ensures that the semantic meaning is preserved across conversions

            // Arrange - Test with a typical managed identity resource ID
            var resourceId = "/subscriptions/12345678-1234-1234-1234-123456789abc/resourceGroups/batch-rg/providers/Microsoft.ManagedIdentity/userAssignedIdentities/batch-identity";
            var psIdentityRef = new PSComputeNodeIdentityReference { ResourceId = resourceId };

            // Act
            var mgmtIdentityRef = psIdentityRef.toMgmtIdentityReference();
            var backToPs = PSComputeNodeIdentityReference.fromMgmtIdentityReference(mgmtIdentityRef);

            // Assert
            Assert.NotNull(mgmtIdentityRef);
            Assert.Equal(resourceId, mgmtIdentityRef.ResourceId);
            Assert.NotNull(backToPs);
            Assert.Equal(resourceId, backToPs.ResourceId);
        }

        [Fact]
        public void IdentityReferenceConversions_NullHandling_WorksCorrectly()
        {
            // Test null handling in conversions

            // Arrange
            PSComputeNodeIdentityReference psIdentityRefWithNullOmObject = new PSComputeNodeIdentityReference();
            psIdentityRefWithNullOmObject.GetType().GetField("omObject", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance)
                ?.SetValue(psIdentityRefWithNullOmObject, null);

            // Act
            var resultFromNullOmObject = psIdentityRefWithNullOmObject.toMgmtIdentityReference();
            var resultFromNullMgmt = PSComputeNodeIdentityReference.fromMgmtIdentityReference(null);

            // Assert
            Assert.Null(resultFromNullOmObject);
            Assert.Null(resultFromNullMgmt);
        }

        [Fact]
        public void IdentityReferenceConversions_BatchIdentityContext_VerifyCorrectUsage()
        {
            // This test validates the conversions work correctly in the context of Batch compute node identity
            // ComputeNodeIdentityReference is used to assign user-assigned managed identities to Batch pool compute nodes

            // Arrange - Test with realistic Batch scenarios
            var subscriptionId = "12345678-1234-1234-1234-123456789abc";
            var resourceGroupName = "batch-pool-rg";
            var identityName = "batch-compute-node-identity";
            var resourceId = $"/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ManagedIdentity/userAssignedIdentities/{identityName}";

            var psIdentityRef = new PSComputeNodeIdentityReference { ResourceId = resourceId };

            // Act
            var mgmtIdentityRef = psIdentityRef.toMgmtIdentityReference();

            // Assert - Should convert correctly for Batch pool configuration
            Assert.NotNull(mgmtIdentityRef);
            Assert.Equal(resourceId, mgmtIdentityRef.ResourceId);
            Assert.IsType<ComputeNodeIdentityReference>(mgmtIdentityRef);

            // Verify round-trip conversion maintains Batch identity semantics
            var backToPs = PSComputeNodeIdentityReference.fromMgmtIdentityReference(mgmtIdentityRef);
            Assert.NotNull(backToPs);
            Assert.Equal(resourceId, backToPs.ResourceId);
            Assert.IsType<Microsoft.Azure.Batch.ComputeNodeIdentityReference>(backToPs);
        }

        [Fact]
        public void IdentityReferenceConversions_InstanceCreation_VerifyBehavior()
        {
            // This test verifies that the conversion methods create appropriate instances

            // Arrange
            var resourceId = "/subscriptions/test/resourceGroups/test/providers/Microsoft.ManagedIdentity/userAssignedIdentities/test";
            var psIdentityRef = new PSComputeNodeIdentityReference { ResourceId = resourceId };
            var mgmtIdentityRef = new ComputeNodeIdentityReference(resourceId);

            // Act
            var mgmtResult = psIdentityRef.toMgmtIdentityReference();
            var psResult = PSComputeNodeIdentityReference.fromMgmtIdentityReference(mgmtIdentityRef);

            // Assert - Verify proper instance creation
            Assert.NotNull(mgmtResult);
            Assert.NotNull(psResult);
            Assert.IsType<ComputeNodeIdentityReference>(mgmtResult);
            Assert.IsType<Microsoft.Azure.Batch.ComputeNodeIdentityReference>(psResult);

            // Verify new instances are created
            Assert.NotSame(mgmtIdentityRef, mgmtResult);
            Assert.NotSame(psIdentityRef, psResult);
        }

        #endregion

        #region Performance and Edge Case Tests

        [Fact]
        public void IdentityReferenceConversions_PerformanceTest_ExecutesQuickly()
        {
            // This test ensures the conversions are efficient

            // Arrange
            var resourceId = "/subscriptions/12345678-1234-1234-1234-123456789abc/resourceGroups/test/providers/Microsoft.ManagedIdentity/userAssignedIdentities/test";
            var psIdentityRef = new PSComputeNodeIdentityReference { ResourceId = resourceId };
            var mgmtIdentityRef = new ComputeNodeIdentityReference(resourceId);

            // Act & Assert - Multiple conversions should complete without delay
            for (int i = 0; i < 100; i++)
            {
                var mgmtResult = psIdentityRef.toMgmtIdentityReference();
                var psResult = PSComputeNodeIdentityReference.fromMgmtIdentityReference(mgmtIdentityRef);

                Assert.NotNull(mgmtResult);
                Assert.NotNull(psResult);
                Assert.Equal(resourceId, mgmtResult.ResourceId);
                Assert.Equal(resourceId, psResult.ResourceId);
            }
        }

        [Fact]
        public void IdentityReferenceConversions_EdgeCaseResourceIds_HandleCorrectly()
        {
            // Test conversion with various edge case resource ID formats

            var testResourceIds = new[]
            {
                // Standard format
                "/subscriptions/12345678-1234-1234-1234-123456789abc/resourceGroups/rg/providers/Microsoft.ManagedIdentity/userAssignedIdentities/identity",
                // With special characters in names
                "/subscriptions/12345678-1234-1234-1234-123456789abc/resourceGroups/test-rg_123/providers/Microsoft.ManagedIdentity/userAssignedIdentities/test-identity_v2",
                // Long names
                "/subscriptions/12345678-1234-1234-1234-123456789abc/resourceGroups/very-long-resource-group-name-for-testing/providers/Microsoft.ManagedIdentity/userAssignedIdentities/very-long-identity-name-for-comprehensive-testing",
                // Minimal valid format
                "/subscriptions/12345678-1234-1234-1234-123456789abc/resourceGroups/rg/providers/Microsoft.ManagedIdentity/userAssignedIdentities/id"
            };

            foreach (var resourceId in testResourceIds)
            {
                // Arrange
                var psIdentityRef = new PSComputeNodeIdentityReference { ResourceId = resourceId };

                // Act
                var mgmtResult = psIdentityRef.toMgmtIdentityReference();
                var roundTripResult = PSComputeNodeIdentityReference.fromMgmtIdentityReference(mgmtResult);

                // Assert
                Assert.NotNull(mgmtResult);
                Assert.NotNull(roundTripResult);
                Assert.Equal(resourceId, mgmtResult.ResourceId);
                Assert.Equal(resourceId, roundTripResult.ResourceId);
            }
        }

        #endregion
    }
}