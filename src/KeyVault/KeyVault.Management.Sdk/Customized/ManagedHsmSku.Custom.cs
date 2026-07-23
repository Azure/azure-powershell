namespace Microsoft.Azure.Management.KeyVault.Models
{
    /// <summary>
    /// This partial class extends the generated ManagedHsmSku class in the KeyVault SDK
    /// to provide default SKU values and helper methods for inferring the Family
    /// from the SKU name.
    /// Example: if Name is "Custom_C42", then Family will be "C".
    /// Name and family are required by the Swagger contract
    /// </summary>
    public partial class ManagedHsmSku
    {
        public const string DefaultFamily = "B";
        public const ManagedHsmSkuName DefaultSkuName = ManagedHsmSkuName.StandardB1;

        public static ManagedHsmSku Create(ManagedHsmSkuName? name)
        {
            return new ManagedHsmSku
            {
                Name = name ?? DefaultSkuName,
                Family = InferFamilyFromSkuName(name)
            };
        }

        public static string InferFamilyFromSkuName(ManagedHsmSkuName? name)
        {
            if (!name.HasValue)
            {
                return DefaultFamily;
            }

            var skuValue = name.ToSerializedValue();

            if (skuValue.Contains("_B"))
            {
                return "B";
            }
            else if (skuValue.Contains("_C"))
            {
                return "C";
            }

            return DefaultFamily;
        }
    }
}