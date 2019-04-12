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
namespace Microsoft.Azure.PowerShell.Cmdlets.Peering.Common
{
    using AutoMapper;

    using CNM = Models;
    using MNM = Management.Peering.Models;
    using Profile = AutoMapper.Profile;

    /// <summary>
    /// The network resource manager profile
    /// </summary>
    public class PeeringResourceManagerProfile : Profile
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
        public override string ProfileName => "PeeringResourceManagerProfile";

        /// <summary>
        /// The initialize.
        /// </summary>
        private static void Initialize()
        {
            var config = new MapperConfiguration(
                cfg =>
                    {
                        cfg.AddProfile<PeeringResourceManagerProfile>();
                        // MNM to CNM 
                        cfg.CreateMap<MNM.BgpSession, CNM.PSBgpSession>();
                        cfg.CreateMap<MNM.DirectConnection, CNM.PSDirectConnection>();
                        cfg.CreateMap<MNM.DirectPeeringFacility, CNM.PSDirectPeeringFacility>();
                        cfg.CreateMap<MNM.ExchangeConnection, CNM.PSExchangeConnection>();
                        cfg.CreateMap<MNM.ExchangePeeringFacility, CNM.PSExchangePeeringFacility>();
                        cfg.CreateMap<MNM.PeeringBandwidthOffer, CNM.PSPeeringBandwidthOffer>();
                        cfg.CreateMap<MNM.PeeringModel, CNM.PSPeering>();
                        cfg.CreateMap<MNM.PeeringLocationPropertiesExchange, CNM.PSPeeringLocationPropertiesExchange>();
                        cfg.CreateMap<MNM.PeeringLocationPropertiesDirect, CNM.PSPeeringLocationPropertiesDirect>();
                        cfg.CreateMap<MNM.PeeringLocation, CNM.PSPeeringLocation>();
                        cfg.CreateMap<MNM.PeeringPropertiesDirect, CNM.PSPeeringPropertiesDirect>();
                        cfg.CreateMap<MNM.PeeringPropertiesExchange, CNM.PSPeeringPropertiesExchange>();
                        cfg.CreateMap<MNM.PeeringSku, CNM.PSPeeringSku>();
                        cfg.CreateMap<MNM.PeerAsn, CNM.PSPeerAsn>();
                        cfg.CreateMap<MNM.Resource, CNM.PSResource>();
                        cfg.CreateMap<MNM.SubResource, CNM.PSSubResource>();
                        cfg.CreateMap<MNM.ContactInfo, CNM.PSContactInfo>();
                        // CNM to MNM
                        cfg.CreateMap<CNM.PSBgpSession, MNM.BgpSession>();
                        cfg.CreateMap<CNM.PSDirectConnection, MNM.DirectConnection>();
                        cfg.CreateMap<CNM.PSDirectPeeringFacility, MNM.DirectPeeringFacility>();
                        cfg.CreateMap<CNM.PSExchangeConnection, MNM.ExchangeConnection>();
                        cfg.CreateMap<CNM.PSExchangePeeringFacility, MNM.ExchangePeeringFacility>();
                        cfg.CreateMap<CNM.PSPeering, MNM.PeeringModel>();
                        cfg.CreateMap<CNM.PSPeeringBandwidthOffer, MNM.PeeringBandwidthOffer>();
                        cfg.CreateMap<CNM.PSPeeringLocation, MNM.PeeringLocation>();
                        cfg.CreateMap<CNM.PSPeeringPropertiesDirect, MNM.PeeringPropertiesDirect>();
                        cfg.CreateMap<CNM.PSPeeringPropertiesExchange, MNM.PeeringPropertiesExchange>();
                        cfg.CreateMap<CNM.PSPeeringSku, MNM.PeeringSku>();
                        cfg.CreateMap<CNM.PSPeeringLocationPropertiesExchange, MNM.PeeringLocationPropertiesExchange>();
                        cfg.CreateMap<CNM.PSPeeringLocationPropertiesDirect, MNM.PeeringLocationPropertiesExchange>();
                        cfg.CreateMap<CNM.PSPeerAsn, MNM.PeerAsn>();
                        cfg.CreateMap<CNM.PSResource, MNM.Resource>();
                        cfg.CreateMap<CNM.PSSubResource, MNM.SubResource>();
                        cfg.CreateMap<CNM.PSContactInfo, MNM.ContactInfo>();
                    });
            mapper = config.CreateMapper();
        }
    }
}