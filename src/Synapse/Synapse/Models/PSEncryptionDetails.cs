using Microsoft.Azure.Management.Synapse.Models;

namespace Microsoft.Azure.Commands.Synapse.Models
{
    public class PSEncryptionDetails
    {
        public PSEncryptionDetails(EncryptionDetails encryption)
        {
            this.DoubleEncryptionEnabled = encryption?.DoubleEncryptionEnabled;
            this.CustomerManagedKeyDetails = encryption?.Cmk != null ? new PSCustomerManagedKeyDetails(encryption?.Cmk) : null;
        }

        /// <summary>
        /// Gets double Encryption enabled
        /// </summary>
        public bool? DoubleEncryptionEnabled { get; set; }

        /// <summary>
        /// Gets or sets customer Managed Key Details
        /// </summary>
        public PSCustomerManagedKeyDetails CustomerManagedKeyDetails { get; set; }
    }
}