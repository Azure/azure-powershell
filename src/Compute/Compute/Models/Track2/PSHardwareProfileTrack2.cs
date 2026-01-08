// PSHardwareProfileTrack2.cs
namespace Microsoft.Azure.Commands.Compute.Models.Track2
{
    public class PSHardwareProfile
    {
        public string VmSize { get; set; }
        public PSVMSizeProperties VmSizeProperties { get; set; }
    }
    
    public class PSVMSizeProperties
    {
        public int? VCPUsAvailable { get; set; }
        public int? VCPUsPerCore { get; set; }
    }
}