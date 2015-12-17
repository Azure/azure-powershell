using Microsoft.Azure.Management.Compute.Models;
using Newtonsoft.Json;

namespace Microsoft.Azure.Commands.Compute.Models
{
    class AzureDiskEncryptionStatusContext
    {
        public bool OsVolumeEncrypted { get; set; }
        public DiskEncryptionSettings OsVolumeEncryptionSettings { get; set; }

        [JsonIgnore]
        public string OsVolumeEncryptionSettingsText
        {
            get { return JsonConvert.SerializeObject(OsVolumeEncryptionSettings, Formatting.Indented); }
        }
        public bool DataVolumesEncrypted { get; set;}
    }
}
