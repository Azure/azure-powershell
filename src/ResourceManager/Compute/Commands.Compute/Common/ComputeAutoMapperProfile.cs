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
using System;
using System.Collections;
using System.Collections.Generic;
using FROM = Microsoft.Azure.Management.Compute.Models;
using TO = Microsoft.Azure.Commands.Compute.Models;

namespace Microsoft.Azure.Commands.Compute
{
    public static class ComputeMapperExtension
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

    public class ComputeAutoMapperProfile : AutoMapper.Profile
    {
        private static readonly Lazy<bool> initialize;

        static ComputeAutoMapperProfile()
        {
            initialize = new Lazy<bool>(() =>
            {
                Mapper.AddProfile<ComputeAutoMapperProfile>();
                return true;
            });
        }

        public override string ProfileName
        {
            get { return "ComputeAutoMapperProfile"; }
        }

        public static bool Initialize()
        {
            return initialize.Value;
        }

        protected override void Configure()
        {
            Mapper.CreateMap<Microsoft.Azure.AzureOperationResponse, TO.PSOperation>();
            Mapper.CreateMap<FROM.ComputeLongRunningOperationResponse, TO.PSComputeLongRunningOperation>();
            Mapper.CreateMap<FROM.DeleteOperationResponse, TO.PSComputeLongRunningOperation>();

            Mapper.CreateMap<FROM.AvailabilitySet, TO.PSAvailabilitySet>();
            Mapper.CreateMap<Microsoft.Azure.AzureOperationResponse, TO.PSAvailabilitySet>();

            Mapper.CreateMap<FROM.VirtualMachine, TO.PSVirtualMachine>();
            Mapper.CreateMap<Microsoft.Azure.AzureOperationResponse, TO.PSVirtualMachine>();

            Mapper.CreateMap<FROM.VirtualMachineSize, TO.PSVirtualMachineSize>();
            Mapper.CreateMap<Microsoft.Azure.AzureOperationResponse, TO.PSVirtualMachineSize>();

            Mapper.CreateMap<FROM.Usage, TO.PSUsage>();
            Mapper.CreateMap<Microsoft.Azure.AzureOperationResponse, TO.PSUsage>();
        }
    }
}