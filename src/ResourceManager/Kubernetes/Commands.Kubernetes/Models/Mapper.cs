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
using Microsoft.Azure.Commands.Kubernetes.Generated.Models;

namespace Microsoft.Azure.Commands.Kubernetes.Models
{
    public class PSMapper
    {
        private static readonly IMapper _instance;

        static PSMapper()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<ManagedCluster, PSKubernetesCluster>().ReverseMap();
                cfg.CreateMap<KeyVaultSecretRef, PSKeyVaultSecretRef>().ReverseMap();
                cfg.CreateMap<ContainerServiceAgentPoolProfile, PSContainerServiceAgentPoolProfile>().ReverseMap();
                cfg.CreateMap<ContainerServiceLinuxProfile, PSContainerServiceLinuxProfile>().ReverseMap();
                cfg.CreateMap<ContainerServiceServicePrincipalProfile, PSContainerServiceServicePrincipalProfile>().ReverseMap();
                cfg.CreateMap<ContainerServiceSshConfiguration, PSContainerServiceSshConfiguration>().ReverseMap();
                cfg.CreateMap<ContainerServiceSshPublicKey, PSContainerServiceSshPublicKey>().ReverseMap();
            });
            _instance = config.CreateMapper();
        }

        public static IMapper Instance { get { return _instance; } }
    }

}