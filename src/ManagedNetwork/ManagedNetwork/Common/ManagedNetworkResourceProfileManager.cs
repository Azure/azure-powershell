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
namespace Microsoft.Azure.Commands.ManagedNetwork.Common
{
    using AutoMapper;

    using PS = Models;
    using SDK = Management.ManagedNetwork.Models;
    using Profile = AutoMapper.Profile;
    using Microsoft.Azure.Commands.ResourceManager.Common.Tags;
    using System.Linq;

    /// <summary>
    /// The network resource manager profile
    /// </summary>
    public class ManagedNetworkResourceManagerProfile : Profile
    {
        /// <summary>
        /// The lock.
        /// </summary>
        private static readonly object Lock = new object();

        /// <summary>
        /// The mapper.
        /// </summary>
        private static IMapper mapper;

        /// <summary>
        /// Gets The network resource manager mapper
        /// </summary>
        public static IMapper Mapper
        {
            get
            {
                lock (Lock)
                {
                    if (mapper == null) Initialize();
                    return mapper;
                }
            }
        }

        /// <summary>
        /// The profile name for Network manager.
        /// </summary>
        public override string ProfileName => "ManagedNetworkResourceManagerProfile";

        /// <summary>
        /// The initialize.
        /// </summary>
        private static void Initialize()
        {
            var config = new MapperConfiguration(
                cfg =>
                {
                    cfg.AddProfile<ManagedNetworkResourceManagerProfile>();

                    cfg.CreateMap<SDK.ResourceId, PS.PSResourceId>();
                    cfg.CreateMap<PS.PSResourceId, SDK.ResourceId>();

                    cfg.CreateMap<SDK.Resource, PS.PSResource>();
                    cfg.CreateMap<PS.PSResource, SDK.Resource>();

                    cfg.CreateMap<SDK.ProxyResource, PS.PSProxyResource>();
                    cfg.CreateMap<PS.PSProxyResource, SDK.ProxyResource>();

                    cfg.CreateMap<SDK.TrackedResource, PS.PSTrackedResource>();
                    cfg.CreateMap<PS.PSTrackedResource, SDK.TrackedResource>();

                    cfg.CreateMap<SDK.ManagedNetworkModel, PS.PSManagedNetwork>();
                    cfg.CreateMap<PS.PSManagedNetwork, SDK.ManagedNetworkModel>();

                    cfg.CreateMap<SDK.Scope, PS.PSScope>();
                    cfg.CreateMap<PS.PSScope, SDK.Scope>();

                    cfg.CreateMap<SDK.ConnectivityCollection, PS.PSConnectivityCollection>();
                    cfg.CreateMap<PS.PSConnectivityCollection, SDK.ConnectivityCollection>();

                    cfg.CreateMap<SDK.ManagedNetworkGroup, PS.PSManagedNetworkGroup>();
                    cfg.CreateMap<PS.PSManagedNetworkGroup, SDK.ManagedNetworkGroup>();

                    cfg.CreateMap<SDK.ManagedNetworkPeeringPolicy, PS.PSManagedNetworkPeeringPolicy>();
                    cfg.CreateMap<PS.PSManagedNetworkPeeringPolicy, SDK.ManagedNetworkPeeringPolicy>();

                    cfg.CreateMap<SDK.ManagedNetworkPeeringPolicyProperties, PS.PSManagedNetworkPeeringPolicyProperties>();
                    cfg.CreateMap<PS.PSManagedNetworkPeeringPolicyProperties, SDK.ManagedNetworkPeeringPolicyProperties>();

                });
            mapper = config.CreateMapper();
        }
    }
}