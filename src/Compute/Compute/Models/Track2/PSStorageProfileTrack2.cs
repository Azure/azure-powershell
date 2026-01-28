// PSStorageProfileTrack2.cs
using System.Collections.Generic;

namespace Microsoft.Azure.Commands.Compute.Models.Track2
{
    public class PSStorageProfile
    {
        public PSImageReference ImageReference { get; set; }
        public PSOSDisk OsDisk { get; set; }
        public IList<PSDataDisk> DataDisks { get; set; }
        public PSDiskControllerType DiskControllerType { get; set; }
    }
    
    public class PSImageReference
    {
        public string Id { get; set; }
        public string Publisher { get; set; }
        public string Offer { get; set; }
        public string Sku { get; set; }
        public string Version { get; set; }
        public string ExactVersion { get; set; }
        public string SharedGalleryImageId { get; set; }
        public string CommunityGalleryImageId { get; set; }
    }
    
    public class PSOSDisk
    {
        public string OsType { get; set; }
        public PSVirtualHardDisk EncryptionSettings { get; set; }
        public string Name { get; set; }
        public PSVirtualHardDisk Vhd { get; set; }
        public PSVirtualHardDisk Image { get; set; }
        public string Caching { get; set; }
        public bool? WriteAcceleratorEnabled { get; set; }
        public string DiffDiskSettings { get; set; }
        public string CreateOption { get; set; }
        public int? DiskSizeGB { get; set; }
        public PSManagedDiskParameters ManagedDisk { get; set; }
        public bool? DeleteOption { get; set; }
    }
    
    public class PSDataDisk
    {
        public int Lun { get; set; }
        public string Name { get; set; }
        public PSVirtualHardDisk Vhd { get; set; }
        public PSVirtualHardDisk Image { get; set; }
        public string Caching { get; set; }
        public bool? WriteAcceleratorEnabled { get; set; }
        public string CreateOption { get; set; }
        public int? DiskSizeGB { get; set; }
        public PSManagedDiskParameters ManagedDisk { get; set; }
        public string ToBeDetached { get; set; }
        public long? DiskIOPSReadWrite { get; set; }
        public long? DiskMBpsReadWrite { get; set; }
        public string DetachOption { get; set; }
        public string DeleteOption { get; set; }
    }
    
    public class PSVirtualHardDisk
    {
        public string Uri { get; set; }
    }
    
    public class PSManagedDiskParameters
    {
        public string Id { get; set; }
        public string StorageAccountType { get; set; }
        public PSDiskEncryptionSetParameters DiskEncryptionSet { get; set; }
        public PSSecurityProfile SecurityProfile { get; set; }
    }
    
    public class PSDiskEncryptionSetParameters
    {
        public string Id { get; set; }
    }
    
    public class PSDiskControllerType
    {
        public string Type { get; set; }
    }
}