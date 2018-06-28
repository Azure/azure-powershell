using System;

namespace Microsoft.Azure.Commands.RecoveryServices.Backup.Cmdlets.Models
{
    /// <summary>
    /// Backup status of a resource.
    /// </summary>
    public class ResourceBackupStatus
    {
        /// <summary>
        /// The Resource Name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The Resource Group Name.
        /// </summary>
        public string ResourceGroupName { get; set; }

        /// <summary>
        /// If the resource is protected by some vault in the subscription, this contains the resource ID of that vault.
        /// </summary>
        public string VaultId { get; set; }

        /// <summary>
        /// Specifies whether the resource is protected by some vault in the subscription.
        /// </summary>
        public bool BackedUp { get; set; }

        public ResourceBackupStatus(string name, string resourceGroupName, string vaultId, bool backedUp)
        {
            if (backedUp && string.IsNullOrEmpty(vaultId) ||
                !backedUp && !string.IsNullOrEmpty(vaultId))
            {
                throw new ArgumentException($"Inconsistent parameters specified. backedUp: {backedUp} and vaultId: {vaultId}.");
            }

            Name = name;
            ResourceGroupName = resourceGroupName;
            VaultId = vaultId;
            BackedUp = backedUp;
        }
    }
}
