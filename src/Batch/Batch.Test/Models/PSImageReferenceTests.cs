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
    public class PSImageReferenceTests
    {
        #region toMgmtImageReference Tests

        [Fact]
        public void ToMgmtImageReference_WithMarketplaceImage_ReturnsCorrectMapping()
        {
            // Arrange
            var psImageRef = new PSImageReference("UbuntuServer", "Canonical", "18.04-LTS", "latest");

            // Act
            var result = psImageRef.toMgmtImageReference();

            // Assert
            Assert.NotNull(result);
            Assert.Equal("Canonical", result.Publisher);
            Assert.Equal("UbuntuServer", result.Offer);
            Assert.Equal("18.04-LTS", result.Sku);
            Assert.Equal("latest", result.Version);
            Assert.Null(result.Id);
            Assert.Null(result.CommunityGalleryImageId);
            Assert.Null(result.SharedGalleryImageId);
        }

        [Fact]
        public void ToMgmtImageReference_WithCustomVMImage_ReturnsCorrectMapping()
        {
            // Arrange
            var customImageId = "/subscriptions/12345678-1234-1234-1234-123456789abc/resourceGroups/myRG/providers/Microsoft.Compute/images/myCustomImage";
            var psImageRef = new PSImageReference(customImageId);

            // Act
            var result = psImageRef.toMgmtImageReference();

            // Assert
            Assert.NotNull(result);
            Assert.Equal(customImageId, result.Id);
            Assert.Null(result.Publisher);
            Assert.Null(result.Offer);
            Assert.Null(result.Sku);
            Assert.Null(result.Version);
            Assert.Null(result.CommunityGalleryImageId);
            Assert.Null(result.SharedGalleryImageId);
        }

        [Fact]
        public void ToMgmtImageReference_WithSharedGalleryImage_ReturnsCorrectMapping()
        {
            // Arrange
            var sharedGalleryImageId = "/subscriptions/12345678-1234-1234-1234-123456789abc/resourceGroups/myRG/providers/Microsoft.Compute/galleries/myGallery/images/myImage/versions/1.0.0";
            var psImageRef = new PSImageReference
            {
                SharedGalleryImageId = sharedGalleryImageId
            };

            // Act
            var result = psImageRef.toMgmtImageReference();

            // Assert
            Assert.NotNull(result);
            Assert.Equal(sharedGalleryImageId, result.SharedGalleryImageId);
            Assert.Null(result.Publisher);
            Assert.Null(result.Offer);
            Assert.Null(result.Sku);
            Assert.Null(result.Version);
            Assert.Null(result.Id);
            Assert.Null(result.CommunityGalleryImageId);
        }

        [Fact]
        public void ToMgmtImageReference_WithCommunityGalleryImage_ReturnsCorrectMapping()
        {
            // Arrange
            var communityGalleryImageId = "/CommunityGalleries/myPublicGallery/Images/myImage/Versions/1.0.0";
            var psImageRef = new PSImageReference
            {
                CommunityGalleryImageId = communityGalleryImageId
            };

            // Act
            var result = psImageRef.toMgmtImageReference();

            // Assert
            Assert.NotNull(result);
            Assert.Equal(communityGalleryImageId, result.CommunityGalleryImageId);
            Assert.Null(result.Publisher);
            Assert.Null(result.Offer);
            Assert.Null(result.Sku);
            Assert.Null(result.Version);
            Assert.Null(result.Id);
            Assert.Null(result.SharedGalleryImageId);
        }

        [Fact]
        public void ToMgmtImageReference_WithAllProperties_ReturnsCorrectMapping()
        {
            // Arrange - This scenario tests all properties set (though mutually exclusive in practice)
            var customImageId = "/subscriptions/12345678-1234-1234-1234-123456789abc/resourceGroups/myRG/providers/Microsoft.Compute/images/myCustomImage";
            var sharedGalleryImageId = "/subscriptions/12345678-1234-1234-1234-123456789abc/resourceGroups/myRG/providers/Microsoft.Compute/galleries/myGallery/images/myImage/versions/1.0.0";
            var communityGalleryImageId = "/CommunityGalleries/myPublicGallery/Images/myImage/Versions/1.0.0";
            
            var psImageRef = new PSImageReference
            {
                Publisher = "Canonical",
                Offer = "UbuntuServer",
                Sku = "18.04-LTS",
                Version = "latest",
                VirtualMachineImageId = customImageId,
                SharedGalleryImageId = sharedGalleryImageId,
                CommunityGalleryImageId = communityGalleryImageId
            };

            // Act
            var result = psImageRef.toMgmtImageReference();

            // Assert
            Assert.NotNull(result);
            Assert.Equal("Canonical", result.Publisher);
            Assert.Equal("UbuntuServer", result.Offer);
            Assert.Equal("18.04-LTS", result.Sku);
            Assert.Equal("latest", result.Version);
            Assert.Equal(customImageId, result.Id);
            Assert.Equal(sharedGalleryImageId, result.SharedGalleryImageId);
            Assert.Equal(communityGalleryImageId, result.CommunityGalleryImageId);
        }

        [Fact]
        public void ToMgmtImageReference_WithNullVersion_ReturnsNullVersion()
        {
            // Arrange
            var psImageRef = new PSImageReference("UbuntuServer", "Canonical", "18.04-LTS", null);

            // Act
            var result = psImageRef.toMgmtImageReference();

            // Assert
            Assert.NotNull(result);
            Assert.Equal("Canonical", result.Publisher);
            Assert.Equal("UbuntuServer", result.Offer);
            Assert.Equal("18.04-LTS", result.Sku);
            Assert.Null(result.Version);
        }

        [Theory]
        [InlineData("Canonical", "UbuntuServer", "18.04-LTS", "latest")]
        [InlineData("MicrosoftWindowsServer", "WindowsServer", "2022-datacenter", "latest")]
        [InlineData("RedHat", "RHEL", "8-gen2", "8.7.2022112201")]
        [InlineData("SUSE", "sles-15-sp4", "gen2", "2022.11.19")]
        [InlineData("microsoft-ads", "windows-data-science-vm", "windows2016", "19.01.14")]
        public void ToMgmtImageReference_VariousMarketplaceImages_ReturnsCorrectMapping(string publisher, string offer, string sku, string version)
        {
            // Arrange
            var psImageRef = new PSImageReference(offer, publisher, sku, version);

            // Act
            var result = psImageRef.toMgmtImageReference();

            // Assert
            Assert.NotNull(result);
            Assert.Equal(publisher, result.Publisher);
            Assert.Equal(offer, result.Offer);
            Assert.Equal(sku, result.Sku);
            Assert.Equal(version, result.Version);
            Assert.Null(result.Id);
        }

        [Fact]
        public void ToMgmtImageReference_AlwaysCreatesNewInstance()
        {
            // Arrange
            var psImageRef = new PSImageReference("UbuntuServer", "Canonical", "18.04-LTS", "latest");

            // Act
            var result1 = psImageRef.toMgmtImageReference();
            var result2 = psImageRef.toMgmtImageReference();

            // Assert
            Assert.NotNull(result1);
            Assert.NotNull(result2);
            Assert.NotSame(result1, result2);
        }

        [Fact]
        public void ToMgmtImageReference_VerifyImageReferenceType()
        {
            // Arrange
            var psImageRef = new PSImageReference("UbuntuServer", "Canonical", "18.04-LTS", "latest");

            // Act
            var result = psImageRef.toMgmtImageReference();

            // Assert
            Assert.NotNull(result);
            Assert.IsType<ImageReference>(result);
        }

        [Fact]
        public void ToMgmtImageReference_WithDefaultConstructor_HandlesNullValues()
        {
            // Arrange
            var psImageRef = new PSImageReference(); // Default constructor

            // Act
            var result = psImageRef.toMgmtImageReference();

            // Assert
            Assert.NotNull(result);
            Assert.Null(result.Publisher);
            Assert.Null(result.Offer);
            Assert.Null(result.Sku);
            Assert.Null(result.Version);
            Assert.Null(result.Id);
            Assert.Null(result.SharedGalleryImageId);
            Assert.Null(result.CommunityGalleryImageId);
        }

        #endregion

        #region fromMgmtImageReference Tests

        [Fact]
        public void FromMgmtImageReference_WithMarketplaceImage_ReturnsCorrectMapping()
        {
            // Arrange
            var mgmtImageRef = new ImageReference(
                publisher: "Canonical",
                offer: "UbuntuServer",
                sku: "18.04-LTS",
                version: "latest");

            // Act
            var result = PSImageReference.fromMgmtImageReference(mgmtImageRef);

            // Assert
            Assert.NotNull(result);
            Assert.Equal("Canonical", result.Publisher);
            Assert.Equal("UbuntuServer", result.Offer);
            Assert.Equal("18.04-LTS", result.Sku);
            Assert.Equal("latest", result.Version);
            Assert.Null(result.VirtualMachineImageId);
            Assert.Null(result.CommunityGalleryImageId);
            Assert.Null(result.SharedGalleryImageId);
        }

        [Fact]
        public void FromMgmtImageReference_WithCustomVMImage_ReturnsCorrectMapping()
        {
            // Arrange
            var customImageId = "/subscriptions/12345678-1234-1234-1234-123456789abc/resourceGroups/myRG/providers/Microsoft.Compute/images/myCustomImage";
            var mgmtImageRef = new ImageReference(id: customImageId);

            // Act
            var result = PSImageReference.fromMgmtImageReference(mgmtImageRef);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(customImageId, result.VirtualMachineImageId);
            Assert.Null(result.Publisher);
            Assert.Null(result.Offer);
            Assert.Null(result.Sku);
            Assert.Null(result.Version);
            Assert.Null(result.CommunityGalleryImageId);
            Assert.Null(result.SharedGalleryImageId);
        }

        [Fact]
        public void FromMgmtImageReference_WithSharedGalleryImage_ReturnsCorrectMapping()
        {
            // Arrange
            var sharedGalleryImageId = "/subscriptions/12345678-1234-1234-1234-123456789abc/resourceGroups/myRG/providers/Microsoft.Compute/galleries/myGallery/images/myImage/versions/1.0.0";
            var mgmtImageRef = new ImageReference(sharedGalleryImageId: sharedGalleryImageId);

            // Act
            var result = PSImageReference.fromMgmtImageReference(mgmtImageRef);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(sharedGalleryImageId, result.SharedGalleryImageId);
            Assert.Null(result.Publisher);
            Assert.Null(result.Offer);
            Assert.Null(result.Sku);
            Assert.Null(result.Version);
            Assert.Null(result.VirtualMachineImageId);
            Assert.Null(result.CommunityGalleryImageId);
        }

        [Fact]
        public void FromMgmtImageReference_WithCommunityGalleryImage_ReturnsCorrectMapping()
        {
            // Arrange
            var communityGalleryImageId = "/CommunityGalleries/myPublicGallery/Images/myImage/Versions/1.0.0";
            var mgmtImageRef = new ImageReference(communityGalleryImageId: communityGalleryImageId);

            // Act
            var result = PSImageReference.fromMgmtImageReference(mgmtImageRef);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(communityGalleryImageId, result.CommunityGalleryImageId);
            Assert.Null(result.Publisher);
            Assert.Null(result.Offer);
            Assert.Null(result.Sku);
            Assert.Null(result.Version);
            Assert.Null(result.VirtualMachineImageId);
            Assert.Null(result.SharedGalleryImageId);
        }

        [Fact]
        public void FromMgmtImageReference_WithNullMgmtImageReference_ReturnsNull()
        {
            // Act
            var result = PSImageReference.fromMgmtImageReference(null);

            // Assert
            Assert.Null(result);
        }

        [Fact]
        public void FromMgmtImageReference_WithAllProperties_ReturnsCorrectMapping()
        {
            // Arrange - This scenario tests all properties set (though mutually exclusive in practice)
            var customImageId = "/subscriptions/12345678-1234-1234-1234-123456789abc/resourceGroups/myRG/providers/Microsoft.Compute/images/myCustomImage";
            var sharedGalleryImageId = "/subscriptions/12345678-1234-1234-1234-123456789abc/resourceGroups/myRG/providers/Microsoft.Compute/galleries/myGallery/images/myImage/versions/1.0.0";
            var communityGalleryImageId = "/CommunityGalleries/myPublicGallery/Images/myImage/Versions/1.0.0";
            
            var mgmtImageRef = new ImageReference(
                publisher: "Canonical",
                offer: "UbuntuServer",
                sku: "18.04-LTS",
                version: "latest",
                id: customImageId,
                sharedGalleryImageId: sharedGalleryImageId,
                communityGalleryImageId: communityGalleryImageId);

            // Act
            var result = PSImageReference.fromMgmtImageReference(mgmtImageRef);

            // Assert
            Assert.NotNull(result);
            Assert.Equal("Canonical", result.Publisher);
            Assert.Equal("UbuntuServer", result.Offer);
            Assert.Equal("18.04-LTS", result.Sku);
            Assert.Equal("latest", result.Version);
            Assert.Equal(customImageId, result.VirtualMachineImageId);
            Assert.Equal(sharedGalleryImageId, result.SharedGalleryImageId);
            Assert.Equal(communityGalleryImageId, result.CommunityGalleryImageId);
        }

        [Theory]
        [InlineData("Canonical", "UbuntuServer", "18.04-LTS", "latest")]
        [InlineData("MicrosoftWindowsServer", "WindowsServer", "2022-datacenter", "latest")]
        [InlineData("RedHat", "RHEL", "8-gen2", "8.7.2022112201")]
        [InlineData("SUSE", "sles-15-sp4", "gen2", "2022.11.19")]
        [InlineData("microsoft-ads", "windows-data-science-vm", "windows2016", "19.01.14")]
        public void FromMgmtImageReference_VariousMarketplaceImages_ReturnsCorrectMapping(string publisher, string offer, string sku, string version)
        {
            // Arrange
            var mgmtImageRef = new ImageReference(
                publisher: publisher,
                offer: offer,
                sku: sku,
                version: version);

            // Act
            var result = PSImageReference.fromMgmtImageReference(mgmtImageRef);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(publisher, result.Publisher);
            Assert.Equal(offer, result.Offer);
            Assert.Equal(sku, result.Sku);
            Assert.Equal(version, result.Version);
            Assert.Null(result.VirtualMachineImageId);
        }

        [Fact]
        public void FromMgmtImageReference_StaticMethod_DoesNotRequireInstance()
        {
            // Arrange
            var mgmtImageRef = new ImageReference(
                publisher: "Canonical",
                offer: "UbuntuServer",
                sku: "18.04-LTS",
                version: "latest");

            // Act - Call static method directly on class
            var result = PSImageReference.fromMgmtImageReference(mgmtImageRef);

            // Assert
            Assert.NotNull(result);
            Assert.Equal("Canonical", result.Publisher);
            Assert.Equal("UbuntuServer", result.Offer);
            Assert.Equal("18.04-LTS", result.Sku);
            Assert.Equal("latest", result.Version);
        }

        [Fact]
        public void FromMgmtImageReference_AlwaysCreatesNewInstance()
        {
            // Arrange
            var mgmtImageRef = new ImageReference(
                publisher: "Canonical",
                offer: "UbuntuServer",
                sku: "18.04-LTS",
                version: "latest");

            // Act
            var result1 = PSImageReference.fromMgmtImageReference(mgmtImageRef);
            var result2 = PSImageReference.fromMgmtImageReference(mgmtImageRef);

            // Assert
            Assert.NotNull(result1);
            Assert.NotNull(result2);
            Assert.NotSame(result1, result2);
        }

        [Fact]
        public void FromMgmtImageReference_VerifyPSImageReferenceType()
        {
            // Arrange
            var mgmtImageRef = new ImageReference(
                publisher: "Canonical",
                offer: "UbuntuServer",
                sku: "18.04-LTS",
                version: "latest");

            // Act
            var result = PSImageReference.fromMgmtImageReference(mgmtImageRef);

            // Assert
            Assert.NotNull(result);
            Assert.IsType<PSImageReference>(result);
        }

        [Fact]
        public void FromMgmtImageReference_WithDefaultConstructor_HandlesNullValues()
        {
            // Arrange
            var mgmtImageRef = new ImageReference(); // Default constructor

            // Act
            var result = PSImageReference.fromMgmtImageReference(mgmtImageRef);

            // Assert
            Assert.NotNull(result);
            Assert.Null(result.Publisher);
            Assert.Null(result.Offer);
            Assert.Null(result.Sku);
            Assert.Null(result.Version);
            Assert.Null(result.VirtualMachineImageId);
            Assert.Null(result.SharedGalleryImageId);
            Assert.Null(result.CommunityGalleryImageId);
        }

        #endregion

        #region Round-trip Conversion Tests

        [Fact]
        public void RoundTripConversion_ToMgmtAndFromMgmt_PreservesMarketplaceImageProperties()
        {
            // Arrange
            var originalPsImageRef = new PSImageReference("UbuntuServer", "Canonical", "18.04-LTS", "latest");

            // Act
            var mgmtImageRef = originalPsImageRef.toMgmtImageReference();
            var roundTripPsImageRef = PSImageReference.fromMgmtImageReference(mgmtImageRef);

            // Assert
            Assert.NotNull(roundTripPsImageRef);
            Assert.Equal(originalPsImageRef.Publisher, roundTripPsImageRef.Publisher);
            Assert.Equal(originalPsImageRef.Offer, roundTripPsImageRef.Offer);
            Assert.Equal(originalPsImageRef.Sku, roundTripPsImageRef.Sku);
            Assert.Equal(originalPsImageRef.Version, roundTripPsImageRef.Version);
            Assert.Null(roundTripPsImageRef.VirtualMachineImageId);
        }

        [Fact]
        public void RoundTripConversion_ToMgmtAndFromMgmt_PreservesCustomImageProperties()
        {
            // Arrange
            var customImageId = "/subscriptions/12345678-1234-1234-1234-123456789abc/resourceGroups/myRG/providers/Microsoft.Compute/images/myCustomImage";
            var originalPsImageRef = new PSImageReference(customImageId);

            // Act
            var mgmtImageRef = originalPsImageRef.toMgmtImageReference();
            var roundTripPsImageRef = PSImageReference.fromMgmtImageReference(mgmtImageRef);

            // Assert
            Assert.NotNull(roundTripPsImageRef);
            Assert.Equal(originalPsImageRef.VirtualMachineImageId, roundTripPsImageRef.VirtualMachineImageId);
            Assert.Null(roundTripPsImageRef.Publisher);
            Assert.Null(roundTripPsImageRef.Offer);
            Assert.Null(roundTripPsImageRef.Sku);
            Assert.Null(roundTripPsImageRef.Version);
        }

        [Fact]
        public void RoundTripConversion_ToMgmtAndFromMgmt_PreservesGalleryImageProperties()
        {
            // Arrange
            var sharedGalleryImageId = "/subscriptions/12345678-1234-1234-1234-123456789abc/resourceGroups/myRG/providers/Microsoft.Compute/galleries/myGallery/images/myImage/versions/1.0.0";
            var communityGalleryImageId = "/CommunityGalleries/myPublicGallery/Images/myImage/Versions/1.0.0";
            
            var originalPsImageRef = new PSImageReference
            {
                SharedGalleryImageId = sharedGalleryImageId,
                CommunityGalleryImageId = communityGalleryImageId
            };

            // Act
            var mgmtImageRef = originalPsImageRef.toMgmtImageReference();
            var roundTripPsImageRef = PSImageReference.fromMgmtImageReference(mgmtImageRef);

            // Assert
            Assert.NotNull(roundTripPsImageRef);
            Assert.Equal(originalPsImageRef.SharedGalleryImageId, roundTripPsImageRef.SharedGalleryImageId);
            Assert.Equal(originalPsImageRef.CommunityGalleryImageId, roundTripPsImageRef.CommunityGalleryImageId);
        }

        [Fact]
        public void RoundTripConversion_ToMgmtAndFromMgmt_PreservesNullValues()
        {
            // Arrange
            var originalPsImageRef = new PSImageReference(); // Default constructor with null values

            // Act
            var mgmtImageRef = originalPsImageRef.toMgmtImageReference();
            var roundTripPsImageRef = PSImageReference.fromMgmtImageReference(mgmtImageRef);

            // Assert
            Assert.NotNull(roundTripPsImageRef);
            Assert.Null(roundTripPsImageRef.Publisher);
            Assert.Null(roundTripPsImageRef.Offer);
            Assert.Null(roundTripPsImageRef.Sku);
            Assert.Null(roundTripPsImageRef.Version);
            Assert.Null(roundTripPsImageRef.VirtualMachineImageId);
            Assert.Null(roundTripPsImageRef.SharedGalleryImageId);
            Assert.Null(roundTripPsImageRef.CommunityGalleryImageId);
        }

        [Theory]
        [InlineData("Canonical", "UbuntuServer", "18.04-LTS", "latest")]
        [InlineData("MicrosoftWindowsServer", "WindowsServer", "2022-datacenter", "latest")]
        [InlineData("RedHat", "RHEL", "8-gen2", null)]
        public void RoundTripConversion_AllValidMarketplaceValues_PreservesOriginalValue(string publisher, string offer, string sku, string version)
        {
            // Arrange
            var originalPsImageRef = new PSImageReference(offer, publisher, sku, version);

            // Act
            var mgmtImageRef = originalPsImageRef.toMgmtImageReference();
            var roundTripPsImageRef = PSImageReference.fromMgmtImageReference(mgmtImageRef);

            // Assert
            Assert.NotNull(roundTripPsImageRef);
            Assert.Equal(originalPsImageRef.Publisher, roundTripPsImageRef.Publisher);
            Assert.Equal(originalPsImageRef.Offer, roundTripPsImageRef.Offer);
            Assert.Equal(originalPsImageRef.Sku, roundTripPsImageRef.Sku);
            Assert.Equal(originalPsImageRef.Version, roundTripPsImageRef.Version);
        }

        [Fact]
        public void RoundTripConversion_FromMgmtAndToMgmt_PreservesValues()
        {
            // Arrange
            var customImageId = "/subscriptions/12345678-1234-1234-1234-123456789abc/resourceGroups/myRG/providers/Microsoft.Compute/images/myCustomImage";
            var originalMgmtImageRef = new ImageReference(
                publisher: "Canonical",
                offer: "UbuntuServer",
                sku: "18.04-LTS",
                version: "latest",
                id: customImageId);

            // Act
            var psImageRef = PSImageReference.fromMgmtImageReference(originalMgmtImageRef);
            var roundTripMgmtImageRef = psImageRef.toMgmtImageReference();

            // Assert
            Assert.NotNull(roundTripMgmtImageRef);
            Assert.Equal(originalMgmtImageRef.Publisher, roundTripMgmtImageRef.Publisher);
            Assert.Equal(originalMgmtImageRef.Offer, roundTripMgmtImageRef.Offer);
            Assert.Equal(originalMgmtImageRef.Sku, roundTripMgmtImageRef.Sku);
            Assert.Equal(originalMgmtImageRef.Version, roundTripMgmtImageRef.Version);
            Assert.Equal(originalMgmtImageRef.Id, roundTripMgmtImageRef.Id);
        }

        #endregion

        #region Integration Tests

        [Fact]
        public void ImageReferenceConversions_BothDirections_MaintainSemanticEquivalence()
        {
            // This test ensures that the semantic meaning is preserved across conversions

            // Scenario 1: Ubuntu marketplace image
            var psUbuntuImageRef = new PSImageReference("UbuntuServer", "Canonical", "18.04-LTS", "latest");

            var mgmtUbuntuImageRef = psUbuntuImageRef.toMgmtImageReference();
            var backToPs = PSImageReference.fromMgmtImageReference(mgmtUbuntuImageRef);

            Assert.NotNull(mgmtUbuntuImageRef);
            Assert.Equal("Canonical", mgmtUbuntuImageRef.Publisher);
            Assert.Equal("UbuntuServer", mgmtUbuntuImageRef.Offer);
            Assert.Equal("18.04-LTS", mgmtUbuntuImageRef.Sku);
            Assert.Equal("latest", mgmtUbuntuImageRef.Version);

            Assert.NotNull(backToPs);
            Assert.Equal("Canonical", backToPs.Publisher);
            Assert.Equal("UbuntuServer", backToPs.Offer);
            Assert.Equal("18.04-LTS", backToPs.Sku);
            Assert.Equal("latest", backToPs.Version);

            // Scenario 2: Custom VM image
            var customImageId = "/subscriptions/12345678-1234-1234-1234-123456789abc/resourceGroups/myRG/providers/Microsoft.Compute/images/myCustomImage";
            var psCustomImageRef = new PSImageReference(customImageId);

            var mgmtCustomImageRef = psCustomImageRef.toMgmtImageReference();
            var backToPsCustom = PSImageReference.fromMgmtImageReference(mgmtCustomImageRef);

            Assert.NotNull(mgmtCustomImageRef);
            Assert.Equal(customImageId, mgmtCustomImageRef.Id);
            Assert.Null(mgmtCustomImageRef.Publisher);

            Assert.NotNull(backToPsCustom);
            Assert.Equal(customImageId, backToPsCustom.VirtualMachineImageId);
            Assert.Null(backToPsCustom.Publisher);
        }

        [Fact]
        public void ImageReferenceConversions_NullHandling_WorksCorrectly()
        {
            // Test null handling in conversions

            // Act
            var resultFromNull = PSImageReference.fromMgmtImageReference(null);

            // Assert
            Assert.Null(resultFromNull);
        }

        [Fact]
        public void ImageReferenceConversions_BatchPoolContext_VerifyCorrectUsage()
        {
            // This test validates the conversions work correctly in the context of Batch pool configuration
            // ImageReference is used to specify VM images for Batch pool compute nodes

            // Arrange - Test with different image reference scenarios
            var scenarios = new[]
            {
                // Standard Ubuntu marketplace image
                new {
                    Type = "Marketplace",
                    Publisher = "Canonical",
                    Offer = "UbuntuServer",
                    Sku = "18.04-LTS",
                    Version = "latest",
                    CustomImageId = (string)null,
                    Description = "Standard Ubuntu LTS marketplace image"
                },
                // Windows Server marketplace image
                new {
                    Type = "Marketplace",
                    Publisher = "MicrosoftWindowsServer",
                    Offer = "WindowsServer",
                    Sku = "2022-datacenter",
                    Version = "latest",
                    CustomImageId = (string)null,
                    Description = "Windows Server 2022 Datacenter marketplace image"
                },
                // Custom VM image
                new {
                    Type = "Custom",
                    Publisher = (string)null,
                    Offer = (string)null,
                    Sku = (string)null,
                    Version = (string)null,
                    CustomImageId = "/subscriptions/12345678-1234-1234-1234-123456789abc/resourceGroups/myRG/providers/Microsoft.Compute/images/myCustomImage",
                    Description = "Custom VM image with pre-installed software"
                },
                // Data Science VM marketplace image
                new {
                    Type = "Marketplace",
                    Publisher = "microsoft-ads",
                    Offer = "windows-data-science-vm",
                    Sku = "windows2016",
                    Version = "19.01.14",
                    CustomImageId = (string)null,
                    Description = "Data Science VM with ML tools pre-installed"
                }
            };

            foreach (var scenario in scenarios)
            {
                // Arrange
                PSImageReference psImageRef;
                if (scenario.Type == "Custom")
                {
                    psImageRef = new PSImageReference(scenario.CustomImageId);
                }
                else
                {
                    psImageRef = new PSImageReference(scenario.Offer, scenario.Publisher, scenario.Sku, scenario.Version);
                }

                // Act
                var mgmtImageRef = psImageRef.toMgmtImageReference();

                // Assert - Should convert correctly for Batch pool configuration
                Assert.NotNull(mgmtImageRef);

                if (scenario.Type == "Custom")
                {
                    Assert.Equal(scenario.CustomImageId, mgmtImageRef.Id);
                    Assert.Null(mgmtImageRef.Publisher);
                    Assert.Null(mgmtImageRef.Offer);
                    Assert.Null(mgmtImageRef.Sku);
                    Assert.Null(mgmtImageRef.Version);
                }
                else
                {
                    Assert.Equal(scenario.Publisher, mgmtImageRef.Publisher);
                    Assert.Equal(scenario.Offer, mgmtImageRef.Offer);
                    Assert.Equal(scenario.Sku, mgmtImageRef.Sku);
                    Assert.Equal(scenario.Version, mgmtImageRef.Version);
                    Assert.Null(mgmtImageRef.Id);
                }

                // Verify round-trip conversion maintains image reference semantics
                var backToPs = PSImageReference.fromMgmtImageReference(mgmtImageRef);
                Assert.NotNull(backToPs);

                if (scenario.Type == "Custom")
                {
                    Assert.Equal(scenario.CustomImageId, backToPs.VirtualMachineImageId);
                    Assert.Null(backToPs.Publisher);
                }
                else
                {
                    Assert.Equal(scenario.Publisher, backToPs.Publisher);
                    Assert.Equal(scenario.Offer, backToPs.Offer);
                    Assert.Equal(scenario.Sku, backToPs.Sku);
                    Assert.Equal(scenario.Version, backToPs.Version);
                    Assert.Null(backToPs.VirtualMachineImageId);
                }
            }
        }

        [Fact]
        public void ImageReferenceConversions_PropertyMapping_VerifyCorrectness()
        {
            // This test verifies the property mapping between PS and Management types
            // PSImageReference.VirtualMachineImageId <-> ImageReference.Id
            // Other properties map directly

            // Test 1: PS to Management mapping
            var customImageId = "/subscriptions/12345678-1234-1234-1234-123456789abc/resourceGroups/myRG/providers/Microsoft.Compute/images/myCustomImage";
            var psImageRef = new PSImageReference
            {
                Publisher = "TestPublisher",
                Offer = "TestOffer",
                Sku = "TestSku",
                Version = "1.0.0",
                VirtualMachineImageId = customImageId,
                SharedGalleryImageId = "/subscriptions/test/resourceGroups/test/providers/Microsoft.Compute/galleries/test/images/test/versions/1.0.0",
                CommunityGalleryImageId = "/CommunityGalleries/test/Images/test/Versions/1.0.0"
            };

            var mgmtImageRef = psImageRef.toMgmtImageReference();
            
            // Verify VirtualMachineImageId maps to Id
            Assert.Equal(psImageRef.VirtualMachineImageId, mgmtImageRef.Id);
            // Verify direct mappings
            Assert.Equal(psImageRef.Publisher, mgmtImageRef.Publisher);
            Assert.Equal(psImageRef.Offer, mgmtImageRef.Offer);
            Assert.Equal(psImageRef.Sku, mgmtImageRef.Sku);
            Assert.Equal(psImageRef.Version, mgmtImageRef.Version);
            Assert.Equal(psImageRef.SharedGalleryImageId, mgmtImageRef.SharedGalleryImageId);
            Assert.Equal(psImageRef.CommunityGalleryImageId, mgmtImageRef.CommunityGalleryImageId);

            // Test 2: Management to PS mapping
            var originalMgmtRef = new ImageReference(
                publisher: "ReversePublisher",
                offer: "ReverseOffer",
                sku: "ReverseSku",
                version: "2.0.0",
                id: customImageId,
                sharedGalleryImageId: "/subscriptions/reverse/resourceGroups/reverse/providers/Microsoft.Compute/galleries/reverse/images/reverse/versions/2.0.0",
                communityGalleryImageId: "/CommunityGalleries/reverse/Images/reverse/Versions/2.0.0");

            var resultPsRef = PSImageReference.fromMgmtImageReference(originalMgmtRef);
            
            // Verify Id maps to VirtualMachineImageId
            Assert.Equal(originalMgmtRef.Id, resultPsRef.VirtualMachineImageId);
            // Verify direct mappings
            Assert.Equal(originalMgmtRef.Publisher, resultPsRef.Publisher);
            Assert.Equal(originalMgmtRef.Offer, resultPsRef.Offer);
            Assert.Equal(originalMgmtRef.Sku, resultPsRef.Sku);
            Assert.Equal(originalMgmtRef.Version, resultPsRef.Version);
            Assert.Equal(originalMgmtRef.SharedGalleryImageId, resultPsRef.SharedGalleryImageId);
            Assert.Equal(originalMgmtRef.CommunityGalleryImageId, resultPsRef.CommunityGalleryImageId);
        }

        [Fact]
        public void ImageReferenceConversions_MutualExclusivity_VerifyDocumentedBehavior()
        {
            // This test verifies the documented mutual exclusivity behavior
            // According to the documentation, Id, SharedGalleryImageId, and CommunityGalleryImageId 
            // are mutually exclusive with marketplace image properties

            // Test 1: Custom image (Id) should be used alone
            var customImageId = "/subscriptions/12345678-1234-1234-1234-123456789abc/resourceGroups/myRG/providers/Microsoft.Compute/images/myCustomImage";
            var customImageRef = new PSImageReference(customImageId);

            var mgmtCustomRef = customImageRef.toMgmtImageReference();
            Assert.Equal(customImageId, mgmtCustomRef.Id);
            Assert.Null(mgmtCustomRef.Publisher); // Should be null for custom images

            // Test 2: Shared gallery image should be used alone
            var sharedGalleryImageId = "/subscriptions/12345678-1234-1234-1234-123456789abc/resourceGroups/myRG/providers/Microsoft.Compute/galleries/myGallery/images/myImage/versions/1.0.0";
            var sharedGalleryRef = new PSImageReference { SharedGalleryImageId = sharedGalleryImageId };

            var mgmtSharedRef = sharedGalleryRef.toMgmtImageReference();
            Assert.Equal(sharedGalleryImageId, mgmtSharedRef.SharedGalleryImageId);
            Assert.Null(mgmtSharedRef.Publisher); // Should be null for gallery images

            // Test 3: Community gallery image should be used alone
            var communityGalleryImageId = "/CommunityGalleries/myPublicGallery/Images/myImage/Versions/1.0.0";
            var communityGalleryRef = new PSImageReference { CommunityGalleryImageId = communityGalleryImageId };

            var mgmtCommunityRef = communityGalleryRef.toMgmtImageReference();
            Assert.Equal(communityGalleryImageId, mgmtCommunityRef.CommunityGalleryImageId);
            Assert.Null(mgmtCommunityRef.Publisher); // Should be null for gallery images

            // Test 4: Marketplace image uses Publisher, Offer, Sku, Version
            var marketplaceRef = new PSImageReference("UbuntuServer", "Canonical", "18.04-LTS", "latest");

            var mgmtMarketplaceRef = marketplaceRef.toMgmtImageReference();
            Assert.Equal("Canonical", mgmtMarketplaceRef.Publisher);
            Assert.Equal("UbuntuServer", mgmtMarketplaceRef.Offer);
            Assert.Equal("18.04-LTS", mgmtMarketplaceRef.Sku);
            Assert.Equal("latest", mgmtMarketplaceRef.Version);
            Assert.Null(mgmtMarketplaceRef.Id); // Should be null for marketplace images
        }

        [Fact]
        public void ImageReferenceConversions_InstanceCreation_VerifyBehavior()
        {
            // This test verifies that the conversion methods create appropriate instances

            // Arrange
            var psImageRef = new PSImageReference("UbuntuServer", "Canonical", "18.04-LTS", "latest");

            var mgmtImageRef = new ImageReference(
                publisher: "MicrosoftWindowsServer",
                offer: "WindowsServer",
                sku: "2022-datacenter",
                version: "latest");

            // Act
            var mgmtResult = psImageRef.toMgmtImageReference();
            var psResult = PSImageReference.fromMgmtImageReference(mgmtImageRef);

            // Assert - Verify proper instance creation
            Assert.NotNull(mgmtResult);
            Assert.NotNull(psResult);
            Assert.IsType<ImageReference>(mgmtResult);
            Assert.IsType<PSImageReference>(psResult);

            // Verify new instances are created
            Assert.NotSame(mgmtImageRef, mgmtResult);
            Assert.NotSame(psImageRef, psResult);
        }

        #endregion

        #region Performance and Edge Case Tests

        [Fact]
        public void ImageReferenceConversions_PerformanceTest_ExecutesQuickly()
        {
            // This test ensures the conversions are efficient

            // Arrange
            var psImageRef = new PSImageReference("UbuntuServer", "Canonical", "18.04-LTS", "latest");

            var mgmtImageRef = new ImageReference(
                publisher: "MicrosoftWindowsServer",
                offer: "WindowsServer",
                sku: "2022-datacenter",
                version: "latest");

            // Act & Assert - Multiple conversions should complete without delay
            for (int i = 0; i < 1000; i++)
            {
                var mgmtResult = psImageRef.toMgmtImageReference();
                var psResult = PSImageReference.fromMgmtImageReference(mgmtImageRef);

                Assert.NotNull(mgmtResult);
                Assert.NotNull(psResult);
                Assert.Equal("Canonical", mgmtResult.Publisher);
                Assert.Equal("MicrosoftWindowsServer", psResult.Publisher);
            }
        }

        [Fact]
        public void ImageReferenceConversions_EdgeCaseImageIds_HandleCorrectly()
        {
            // Test conversion with various edge case image IDs

            var testImageIds = new[]
            {
                // Standard custom image
                "/subscriptions/12345678-1234-1234-1234-123456789abc/resourceGroups/myRG/providers/Microsoft.Compute/images/myImage",
                
                // Shared gallery image
                "/subscriptions/12345678-1234-1234-1234-123456789abc/resourceGroups/myRG/providers/Microsoft.Compute/galleries/myGallery/images/myImage/versions/1.0.0",
                
                // Community gallery image
                "/CommunityGalleries/myPublicGallery/Images/myImage/Versions/1.0.0",
                
                // Long image ID
                "/subscriptions/12345678-1234-1234-1234-123456789abc/resourceGroups/very-long-resource-group-name/providers/Microsoft.Compute/images/very-long-image-name-with-lots-of-details",
                
                // Image with special characters
                "/subscriptions/12345678-1234-1234-1234-123456789abc/resourceGroups/test-rg_123/providers/Microsoft.Compute/images/test-image_v2",
                
                // Empty string
                "",
                
                // Null value
                null
            };

            foreach (var imageId in testImageIds)
            {
                // Arrange
                var psImageRef = new PSImageReference { VirtualMachineImageId = imageId };

                // Act
                var mgmtResult = psImageRef.toMgmtImageReference();
                var roundTripResult = PSImageReference.fromMgmtImageReference(mgmtResult);

                // Assert
                Assert.NotNull(mgmtResult);
                Assert.NotNull(roundTripResult);
                Assert.Equal(imageId, mgmtResult.Id);
                Assert.Equal(imageId, roundTripResult.VirtualMachineImageId);
            }
        }

        [Fact]
        public void ImageReferenceConversions_EdgeCaseVersions_HandleCorrectly()
        {
            // Test conversion with various edge case version strings

            var testVersions = new[]
            {
                // Standard versions
                "latest",
                "1.0.0",
                "2022.11.19",
                
                // Date-based versions
                "20221119",
                "2022-11-19",
                
                // Build numbers
                "19041.928.210409-1908",
                
                // Special versions
                "latest-gen2",
                "latest-smalldisk",
                
                // Long version string
                "very-long-version-string-with-build-details-2022.11.19.123456789",
                
                // Empty string
                "",
                
                // Null value
                null
            };

            foreach (var version in testVersions)
            {
                // Arrange
                var psImageRef = new PSImageReference("UbuntuServer", "Canonical", "18.04-LTS", version);

                // Act
                var mgmtResult = psImageRef.toMgmtImageReference();
                var roundTripResult = PSImageReference.fromMgmtImageReference(mgmtResult);

                // Assert
                Assert.NotNull(mgmtResult);
                Assert.NotNull(roundTripResult);
                Assert.Equal("Canonical", mgmtResult.Publisher);
                Assert.Equal("UbuntuServer", mgmtResult.Offer);
                Assert.Equal("18.04-LTS", mgmtResult.Sku);
                Assert.Equal(version, mgmtResult.Version);
                Assert.Equal("Canonical", roundTripResult.Publisher);
                Assert.Equal("UbuntuServer", roundTripResult.Offer);
                Assert.Equal("18.04-LTS", roundTripResult.Sku);
                Assert.Equal(version, roundTripResult.Version);
            }
        }

        [Fact]
        public void ImageReferenceConversions_ToStringMethod_VerifyBehavior()
        {
            // This test verifies the ToString() method behavior to ensure it works correctly
            // with the converted objects

            // Test marketplace image ToString
            var marketplaceImageRef = new PSImageReference("UbuntuServer", "Canonical", "18.04-LTS", "latest");
            var marketplaceString = marketplaceImageRef.ToString();
            Assert.Equal("Canonical:UbuntuServer:18.04-LTS:latest", marketplaceString);

            // Test custom image ToString
            var customImageId = "/subscriptions/12345678-1234-1234-1234-123456789abc/resourceGroups/myRG/providers/Microsoft.Compute/images/myImage";
            var customImageRef = new PSImageReference(customImageId);
            var customImageString = customImageRef.ToString();
            Assert.Equal(customImageId, customImageString);

            // Test conversion preserves ToString behavior
            var mgmtMarketplaceRef = marketplaceImageRef.toMgmtImageReference();
            var roundTripMarketplaceRef = PSImageReference.fromMgmtImageReference(mgmtMarketplaceRef);
            Assert.Equal(marketplaceString, roundTripMarketplaceRef.ToString());

            var mgmtCustomRef = customImageRef.toMgmtImageReference();
            var roundTripCustomRef = PSImageReference.fromMgmtImageReference(mgmtCustomRef);
            Assert.Equal(customImageString, roundTripCustomRef.ToString());
        }

        #endregion
    }
}