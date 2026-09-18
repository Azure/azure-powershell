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
                   additionalDataDisks: nodeType.AdditionalDataDisks,
                   additionalNetworkInterfaceConfigurations: nodeType.AdditionalNetworkInterfaceConfigurations,
                   applicationPorts: nodeType.ApplicationPorts,
                   capacities: nodeType.Capacities,
                   computerNamePrefix: nodeType.ComputerNamePrefix,
                   dataDiskSizeGb: nodeType.DataDiskSizeGb,
                   dataDiskType: nodeType.DataDiskType,
                   dataDiskLetter: nodeType.DataDiskLetter,
                   dscpConfigurationId: nodeType.DscpConfigurationId,
                   enableAcceleratedNetworking: nodeType.EnableAcceleratedNetworking,
                   enableEncryptionAtHost: nodeType.EnableEncryptionAtHost,
                   enableNodePublicIP: nodeType.EnableNodePublicIP,
                   enableNodePublicIPv6: nodeType.EnableNodePublicIPv6,
                   enableOverProvisioning: nodeType.EnableOverProvisioning,
                   ephemeralPorts: nodeType.EphemeralPorts,
                   evictionPolicy: nodeType.EvictionPolicy,
                   frontendConfigurations: nodeType.FrontendConfigurations,
                   hostGroupId: nodeType.HostGroupId,
                   isPrimary: nodeType.IsPrimary,
                   isSpotVM: nodeType.IsSpotVM,
                   isStateless: nodeType.IsStateless,
                   multiplePlacementGroups: nodeType.MultiplePlacementGroups,
                   name: nodeType.Name,
                   natConfigurations: nodeType.NatConfigurations,
                   natGatewayId: nodeType.NatGatewayId,
                   networkSecurityRules: nodeType.NetworkSecurityRules,
                   placementProperties: nodeType.PlacementProperties,
                   provisioningState: nodeType.ProvisioningState,
                   securityEncryptionType: nodeType.SecurityEncryptionType,
                   securityType: nodeType.SecurityType,
                   secureBootEnabled: nodeType.SecureBootEnabled,
                   serviceArtifactReferenceId: nodeType.ServiceArtifactReferenceId,
                   sku: nodeType.Sku,
                   subnetId: nodeType.SubnetId,
                   spotRestoreTimeout: nodeType.SpotRestoreTimeout,
                   tags: nodeType.Tags,
                   type: nodeType.Type,
                   useDefaultPublicLoadBalancer: nodeType.UseDefaultPublicLoadBalancer,
                   useEphemeralOSDisk: nodeType.UseEphemeralOSDisk,
                   useTempDataDisk: nodeType.UseTempDataDisk,
                   vmApplications: nodeType.VMApplications,
                   vmExtensions: nodeType.VMExtensions,
                   vmImageOffer: nodeType.VMImageOffer,
                   vmImagePlan: nodeType.VMImagePlan,
                   vmImagePublisher: nodeType.VMImagePublisher,
                   vmImageResourceId: nodeType.VMImageResourceId,
                   vmImageSku: nodeType.VMImageSku,
                   vmImageVersion: nodeType.VMImageVersion,
                   vmInstanceCount: nodeType.VMInstanceCount,
                   vmManagedIdentity: nodeType.VMManagedIdentity,
                   vmSecrets: nodeType.VMSecrets,
                   vmSetupActions: nodeType.VMSetupActions,
                   vmSharedGalleryImageId: nodeType.VMSharedGalleryImageId,
                   vmSize: nodeType.VMSize,
                   zoneBalance: nodeType.ZoneBalance,
                   zones: nodeType.Zones)
        {
        }
    }
}
