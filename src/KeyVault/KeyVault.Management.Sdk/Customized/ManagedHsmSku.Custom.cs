namespace Microsoft.Azure.Management.KeyVault.Models
{
    public partial class ManagedHsmSku
    {
        public const string DefaultFamily = "B";
        public const ManagedHsmSkuName DefaultSkuName = ManagedHsmSkuName.StandardB1;

        public static ManagedHsmSku Create(ManagedHsmSkuName? name)
        {
            // @TODO: update test condition for default.
            return new ManagedHsmSku
            {
                Name = name?? DefaultSkuName,
                Family = InferFamilyFromSkuName(name)
            };
        }

        public static string InferFamilyFromSkuName(ManagedHsmSkuName? name)
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
    }
}