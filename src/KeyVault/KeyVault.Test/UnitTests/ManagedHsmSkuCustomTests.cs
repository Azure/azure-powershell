
using Microsoft.Azure.Management.KeyVault.Models;
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using Xunit;

namespace Microsoft.Azure.Commands.KeyVault.Test.UnitTests
{
    public class ManagedHsmSkuCustomTests: KeyVaultUnitTestBase
    {
        [Theory]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [InlineData(ManagedHsmSkuName.StandardB1, "B")]
        [InlineData(ManagedHsmSkuName.CustomB32, "B")]
        [InlineData(ManagedHsmSkuName.CustomB6, "B")]
        [InlineData(ManagedHsmSkuName.CustomC42, "C")]
        [InlineData(ManagedHsmSkuName.CustomC10, "C")]
        public void CanInferFamilyFromSkuName(ManagedHsmSkuName skuSerializedValue, string expectedFamily)
        {
            // Act
            var result = ManagedHsmSku.InferFamilyFromSkuName(skuSerializedValue);

            // Assert
            Assert.Equal(expectedFamily, result);
        }

        [Theory]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [InlineData(ManagedHsmSkuName.StandardB1, "B")]
        [InlineData(ManagedHsmSkuName.CustomB32, "B")]
        [InlineData(ManagedHsmSkuName.CustomB6, "B")]
        [InlineData(ManagedHsmSkuName.CustomC42, "C")]
        [InlineData(ManagedHsmSkuName.CustomC10, "C")]
        public void CanCreateSkuWithCorrectFamily(ManagedHsmSkuName skuSerializedValue, string expectedFamily)
        {

            // Act
            var sku = ManagedHsmSku.Create(skuSerializedValue);

            // Assert
            Assert.Equal(expectedFamily, sku.Family);
            Assert.Equal(skuSerializedValue, sku.Name);
        }

        [Fact]
        public void Create_WithNullName_ReturnsDefaultSku()
        {
            // Act
            var sku = ManagedHsmSku.Create(null);

            // Assert
            Assert.Equal(ManagedHsmSku.DefaultSkuName, sku.Name);
            Assert.Equal(ManagedHsmSku.DefaultFamily, sku.Family);
        }
    }
}
