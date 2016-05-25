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
    }
}
