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

namespace Microsoft.Azure.Commands.Network
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using AutoMapper;
    using CNM = Microsoft.Azure.Commands.Network.Models;
    using MNM = Microsoft.WindowsAzure.Management.NetworkResourceProvider.Models;

    public static class NetworkManagementMapperExtension
    {
        public static IMappingExpression<TSource, TDestination> ForItems<TSource, TDestination, T>(
                 this IMappingExpression<TSource, TDestination> mapper)
            where TSource : IEnumerable
            where TDestination : ICollection<T>
        {
            mapper.AfterMap((c, s) =>
            {
                if (c != null && s != null)
                {
                    foreach (var t in c)
                    {
                        s.Add(Mapper.Map<T>(t));
                    }
                }
            });

            return mapper;
        }
    }

    public class NetworkManagementProfile : Profile
    {
        private static readonly Lazy<bool> initialize;

        static NetworkManagementProfile()
        {
            initialize = new Lazy<bool>(() =>
            {
                Mapper.AddProfile<NetworkManagementProfile>();
                return true;
            });
        }

        public override string ProfileName
        {
            get { return "NetworkManagementProfile"; }
        }

        public static bool Initialize()
        {
            return initialize.Value;
        }

        protected override void Configure()
        {
            // CNM to MCM
            Mapper.CreateMap<CNM.DnsRecord, MNM.DnsRecord>();
            Mapper.CreateMap<CNM.ResourceId, MNM.ResourceId>();
            Mapper.CreateMap<CNM.CreatePublicIpAddressProperties, MNM.CreatePublicIpAddressProperties>();
            Mapper.CreateMap<CNM.PublicIpAddressProperties, MNM.PublicIpAddressProperties>();
            Mapper.CreateMap<CNM.PublicIpAddress, MNM.PublicIpAddress>();

            // MCM to CNM
            Mapper.CreateMap<MNM.DnsRecord, CNM.DnsRecord>();
            Mapper.CreateMap<MNM.ResourceId, CNM.ResourceId>();
            Mapper.CreateMap<MNM.CreatePublicIpAddressProperties, CNM.CreatePublicIpAddressProperties>();
            Mapper.CreateMap<MNM.PublicIpAddressProperties, CNM.PublicIpAddressProperties>();
            Mapper.CreateMap<MNM.PublicIpAddress, CNM.PublicIpAddress>();

        }
    }
}