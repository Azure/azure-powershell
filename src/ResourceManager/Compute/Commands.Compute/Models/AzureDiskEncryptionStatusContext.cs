using Microsoft.Azure.Management.Compute.Models;
using Newtonsoft.Json;

namespace Microsoft.Azure.Commands.Compute.Models
{
    enum EncryptionStatus
    {
        Encrypted,
        NotEncrypted,
        Unknown
    }

    class AzureDiskEncryptionStatusContext
    {
        public EncryptionStatus OsVolumeEncrypted { get; set; }
        public DiskEncryptionSettings OsVolumeEncryptionSettings { get; set; }
        public EncryptionStatus DataVolumesEncrypted { get; set; }
        [JsonIgnore]
        public string OsVolumeEncryptionSettingsText
        {
            get { return JsonConvert.SerializeObject(OsVolumeEncryptionSettings, Formatting.Indented); }
        }
    }
    class AzureDiskEncryptionStatusLinuxContext
    {
        public EncryptionStatus OsVolumeEncrypted { get; set; }
        public DiskEncryptionSettings OsVolumeEncryptionSettings { get; set; }
        public DiskEncryptionSettings DataVolumeEncryptionSettings { get; set; }

        [JsonIgnore]
        public string OsVolumeEncryptionSettingsText
        {
            get { return JsonConvert.SerializeObject(OsVolumeEncryptionSettings, Formatting.Indented); }
        }
        [JsonIgnore]
        public string DataVolumeEncryptionSettingsText
        {
            get { return JsonConvert.SerializeObject(DataVolumeEncryptionSettings, Formatting.Indented); }
        }
        public EncryptionStatus DataVolumesEncrypted { get; set; }
    }
}
