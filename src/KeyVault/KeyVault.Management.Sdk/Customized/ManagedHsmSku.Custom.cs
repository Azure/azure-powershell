namespace Microsoft.Azure.Management.KeyVault.Models
{
    public partial class ManagedHsmSku
    {
        public const string DefaultFamily = "B";

        partial void CustomInit()
        {
            if (Family == null)
            {
                Family = DefaultFamily;
            }

        }
    }
}
