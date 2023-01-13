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

using AutoMapper;
using Microsoft.Azure.Management.ContainerService.Models;

namespace Microsoft.Azure.Commands.Aks.Models
{
    public class PSMapper
    {
        private static readonly IMapper _instance;

        static PSMapper()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<ManagedCluster, PSKubernetesCluster>().ReverseMap();

                cfg.CreateMap<ContainerServiceLinuxProfile,PSContainerServiceLinuxProfile>().ReverseMap();
                cfg.CreateMap<ContainerServiceNetworkProfile, PSContainerServiceNetworkProfile>().ReverseMap();
                cfg.CreateMap<ManagedClusterServicePrincipalProfile,PSContainerServiceServicePrincipalProfile>().ReverseMap();
                cfg.CreateMap<ContainerServiceSshConfiguration, PSContainerServiceSshConfiguration>().ReverseMap();
                cfg.CreateMap<ContainerServiceSshPublicKey,PSContainerServiceSshPublicKey>().ReverseMap();
                cfg.CreateMap<ManagedClusterAADProfile, PSManagedClusterAadProfile>().ReverseMap();
                cfg.CreateMap<ManagedClusterAccessProfile,PSManagedClusterAccessProfile>().ReverseMap();
                cfg.CreateMap<ManagedClusterAddonProfile, PSManagedClusterAddonProfile>().ReverseMap();
                cfg.CreateMap<ManagedClusterAgentPoolProfile,PSContainerServiceAgentPoolProfile>().ReverseMap();
                cfg.CreateMap<ManagedClusterAPIServerAccessProfile, PSManagedClusterAPIServerAccessProfile>().ReverseMap();
                cfg.CreateMap<ManagedClusterIdentity,PSManagedClusterIdentity>().ReverseMap();
                cfg.CreateMap<ManagedClusterIdentityUserAssignedIdentitiesValue, PSManagedClusterIdentityUserAssignedIdentitiesValue>().ReverseMap();
                cfg.CreateMap<ManagedClusterLoadBalancerProfile, PSManagedClusterLoadBalancerProfile>().ReverseMap();
                cfg.CreateMap<ManagedClusterLoadBalancerProfileManagedOutboundIPs,PSManagedClusterLoadBalancerProfileManagedOutboundIPs>().ReverseMap();
                cfg.CreateMap<ManagedClusterLoadBalancerProfileOutboundIPPrefixes, PSManagedClusterLoadBalancerProfileOutboundIPPrefixes>().ReverseMap();
                cfg.CreateMap<ManagedClusterLoadBalancerProfileOutboundIPs,PSManagedClusterLoadBalancerProfileOutboundIPs>().ReverseMap();
                cfg.CreateMap<ManagedClusterPoolUpgradeProfile, PSManagedClusterPoolUpgradeProfile>().ReverseMap();
                cfg.CreateMap<ManagedClusterPoolUpgradeProfileUpgradesItem,PSManagedClusterPoolUpgradeProfileUpgradesItem>().ReverseMap();
                cfg.CreateMap<ManagedClusterUpgradeProfile,PSManagedClusterUpgradeProfile>().ReverseMap();
                cfg.CreateMap<ManagedClusterWindowsProfile, PSManagedClusterWindowsProfile>().ReverseMap();
                cfg.CreateMap<ManagedClusterAutoUpgradeProfile, PSManagedClusterAutoUpgradeProfile>().ReverseMap();
                cfg.CreateMap<ManagedClusterHTTPProxyConfig, PSManagedClusterHTTPProxyConfig>().ReverseMap();
                cfg.CreateMap<ManagedClusterPodIdentity, PSManagedClusterPodIdentity>().ReverseMap();
                cfg.CreateMap<ManagedClusterPodIdentityException, PSManagedClusterPodIdentityException>().ReverseMap();
                cfg.CreateMap<ManagedClusterPodIdentityProfile, PSManagedClusterPodIdentityProfile>().ReverseMap();
                cfg.CreateMap<UserAssignedIdentity, PSManagedClusterPodIdentityProfileUserAssignedIdentity>().ReverseMap();
                cfg.CreateMap<ManagedClusterPodIdentityProvisioningError, PSManagedClusterPodIdentityProvisioningError>().ReverseMap();
                cfg.CreateMap<ManagedClusterPodIdentityProvisioningErrorBody, PSManagedClusterPodIdentityProvisioningErrorBody>().ReverseMap();
                cfg.CreateMap<ManagedClusterPodIdentityProvisioningInfo, PSManagedClusterPodIdentityProvisioningInfo>().ReverseMap();
                cfg.CreateMap<ManagedClusterPropertiesAutoScalerProfile, PSManagedClusterAutoScalerProfile>().ReverseMap();
                cfg.CreateMap<Resource,PSResource>().ReverseMap();
                cfg.CreateMap<ResourceIdentityType, PSResourceIdentityType>().ReverseMap();
                cfg.CreateMap<AgentPool, PSNodePool>().ReverseMap();
                cfg.CreateMap<SubResource, PSSubResource>().ReverseMap();
                cfg.CreateMap<RunCommandResult, PSRunCommandResult>().ReverseMap();
            });
            _instance = config.CreateMapper();
        }

        public static IMapper Instance { get { return _instance; } }
    }

}