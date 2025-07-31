namespace Microsoft.Azure.Management.KeyVault.Models
{
    public partial class ManagedHsmSku
    {
        public const string DefaultFamily = "B";

        public static ManagedHsmSku Create(ManagedHsmSkuName name)
        {
            return new ManagedHsmSku
            {
                Name = name,
                Family = InferFamilyFromSkuName(name)
            };
        }

        public static string InferFamilyFromSkuName(ManagedHsmSkuName name)
        {
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

        // @TODO: add unit test
    }
}