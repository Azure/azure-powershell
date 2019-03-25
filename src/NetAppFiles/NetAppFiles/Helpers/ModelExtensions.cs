// ----------------------------------------------------------------------------------
//
// Copyright Microsoft Corporation
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// http://www.apache.org/licenses/LICENSE-2.0
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// ----------------------------------------------------------------------------------

using Microsoft.Azure.Management.Internal.Resources.Utilities.Models;
using Microsoft.Azure.Management.NetApp.Models;
using Microsoft.Azure.Commands.NetAppFiles.Models;

namespace Microsoft.Azure.Commands.NetAppFiles.Helpers
{
    public static class ModelExtensions
    {
        public static PSNetAppFilesAccount ToPsNetAppFilesAccount(this NetAppAccount netAppAccount)
        {
            return new PSNetAppFilesAccount
            {
                ResourceGroupName = new ResourceIdentifier(netAppAccount.Id).ResourceGroupName,
                Location = netAppAccount.Location,
                Id = netAppAccount.Id,
                Name = netAppAccount.Name,
                Type = netAppAccount.Type,
                Tags = netAppAccount.Tags,
                ProvisioningState = netAppAccount.ProvisioningState
            };
        }

        public static PSNetAppFilesPool ToPsNetAppFilesPool(this CapacityPool capacityPool)
        {
            return new PSNetAppFilesPool
            {
                ResourceGroupName = new ResourceIdentifier(capacityPool.Id).ResourceGroupName,
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

        public static PSNetAppFilesVolume ToPsNetAppFilesVolume(this Management.NetApp.Models.Volume volume)
        {
            return new PSNetAppFilesVolume
            {
                ResourceGroupName = new ResourceIdentifier(volume.Id).ResourceGroupName,
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

        public static PSNetAppFilesSnapshot ToPsNetAppFilesSnapshot(this Management.NetApp.Models.Snapshot snapshot)
        {
            return new PSNetAppFilesSnapshot
            {
                ResourceGroupName = new ResourceIdentifier(snapshot.Id).ResourceGroupName,
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