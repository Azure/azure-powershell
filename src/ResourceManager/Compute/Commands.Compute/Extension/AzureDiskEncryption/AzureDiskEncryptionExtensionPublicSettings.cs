using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.Azure.Commands.Compute.Extension.AzureDiskEncryption
{
    public class AzureDiskEncryptionExtensionPublicSettings
    {
        public string AadClientID { get; set; }
        public string KeyVaultURL { get; set; }
        public string KeyEncryptionKeyURL { get; set; }
        public string KeyEncryptionAlgorithm { get; set; }
        public string VolumeType { get; set; }
        public string AadClientCertThumbprint { get; set; }
        public string SequenceVersion { get; set; }
    }
}
