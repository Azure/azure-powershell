namespace Microsoft.Azure.Commands.Batch.Models
{
    public partial class PSImageReference
    {
        public override string ToString()
        {
            if (string.IsNullOrEmpty(VirtualMachineImageId))
            {
                return $"{Publisher}:{Offer}:{Sku}:{Version}";
            }
            else
            {
                return VirtualMachineImageId;
            }
        }
    }
}
