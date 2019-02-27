using Microsoft.Azure.Management.NetApp.Models;
using Microsoft.Azure.Commands.Anf.Models;

namespace Microsoft.Azure.Commands.Anf.Helpers
{
    public static class ModelExtensions
    {
        public static PSAnfAccount ToPsAnfAccount(this NetAppAccount netAppAccount)
        {
            return new PSAnfAccount
            {
                Location = netAppAccount.Location,
                Id = netAppAccount.Id,
                Name = netAppAccount.Name,
                Type = netAppAccount.Type,
                Tags = netAppAccount.Tags,
                ProvisioningState = netAppAccount.ProvisioningState
            };
        }

        public static PSAnfPool ToPsAnfPool(this CapacityPool capacityPool)
        {
            return new PSAnfPool
            {
                Location = capacityPool.Location,
                Id = capacityPool.Id,
                Name = capacityPool.Name,
                Type = capacityPool.Type,
                Tags = capacityPool.Tags,
                PoolId = capacityPool.PoolId,
                Size = capacityPool.Size,
                ServiceLevel = capacityPool.ServiceLevel,
                ProvisioningState = capacityPool.ProvisioningState
            };
        }

        public static PSAnfVolume ToPsAnfVolume(this Management.NetApp.Models.Volume volume)
        {
            return new PSAnfVolume
            {
                Location = volume.Location,
                Id = volume.Id,
                Name = volume.Name,
                Type = volume.Type,
                Tags = volume.Tags,
                FileSystemId = volume.FileSystemId,
                UsageThreshold = volume.UsageThreshold,
                ServiceLevel = volume.ServiceLevel,
                ProvisioningState = volume.ProvisioningState,
                SubnetId = volume.SubnetId
            };
        }

        public static PSAnfSnapshot ToPsAnfSnapshot(this Management.NetApp.Models.Snapshot snapshot)
        {
            return new PSAnfSnapshot
            {
                Location = snapshot.Location,
                Id = snapshot.Id,
                Name = snapshot.Name,
                Type = snapshot.Type,
                Tags = snapshot.Tags,
                FileSystemId = snapshot.FileSystemId,
                SnapshotId = snapshot.SnapshotId,
                CreationDate = snapshot.CreationDate,
                ProvisioningState = snapshot.ProvisioningState,
            };
        }
    }
}