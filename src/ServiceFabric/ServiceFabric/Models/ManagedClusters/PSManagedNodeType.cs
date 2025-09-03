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

using Microsoft.Azure.Management.ServiceFabricManagedClusters.Models;

namespace Microsoft.Azure.Commands.ServiceFabric.Models
{
    public class PSManagedNodeType : NodeType
    {
        public PSManagedNodeType(NodeType nodeType)
            : base(id: nodeType.Id,
                   applicationPorts: nodeType.ApplicationPorts,
                   capacities: nodeType.Capacities,
                   enableNodePublicIP: nodeType.EnableNodePublicIP,
                   ephemeralPorts: nodeType.EphemeralPorts,
                   dataDiskSizeGb: nodeType.DataDiskSizeGb,
                   dataDiskType: nodeType.DataDiskType,
                   dataDiskLetter: nodeType.DataDiskLetter,
                   isPrimary: nodeType.IsPrimary,
                   isStateless: nodeType.IsStateless,
                   multiplePlacementGroups: nodeType.MultiplePlacementGroups,
                   name: nodeType.Name,
                   natGatewayId: nodeType.NatGatewayId,
                   placementProperties: nodeType.PlacementProperties,
                   provisioningState: nodeType.ProvisioningState,
                   securityType: nodeType.SecurityType,
                   secureBootEnabled: nodeType.SecureBootEnabled,
                   tags: nodeType.Tags,
                   type: nodeType.Type,
                   vmExtensions: nodeType.VMExtensions,
                   vmImageOffer: nodeType.VMImageOffer,
                   vmImagePlan: nodeType.VMImagePlan,
                   vmImagePublisher: nodeType.VMImagePublisher,
                   vmImageSku: nodeType.VMImageSku,
                   vmImageVersion: nodeType.VMImageVersion,
                   vmInstanceCount: nodeType.VMInstanceCount,
                   vmManagedIdentity: nodeType.VMManagedIdentity,
                   vmSecrets: nodeType.VMSecrets,
                   vmSharedGalleryImageId: nodeType.VMSharedGalleryImageId,
                   vmSize: nodeType.VMSize)
        {
        }
    }
}
