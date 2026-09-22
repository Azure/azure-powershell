namespace Microsoft.Azure.Management.Compute.Models
{
    using Newtonsoft.Json;

    public partial class VirtualMachineScaleSetUpdateVMProfile
    {
        /// <summary>
        /// Gets or sets specifies the capacity reservation related details of a scale set.
        /// </summary>
        [JsonProperty(PropertyName = "capacityReservation")]
        public CapacityReservationProfile CapacityReservation { get; set; }
    }
}
