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
using Microsoft.Rest.Azure;
using Newtonsoft.Json;
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
            // => PSComputeLongrunningOperation
            Mapper.CreateMap<Rest.Azure.AzureOperationResponse, TO.PSComputeLongRunningOperation>()
                .ForMember(c => c.OperationId, o => o.MapFrom(r => JsonConvert.DeserializeObject<TO.PSComputeLongRunningOperation>(
                    r.Response.Content.ReadAsStringAsync().Result).OperationId))
                .ForMember(c => c.Status, o => o.MapFrom(r => JsonConvert.DeserializeObject<TO.PSComputeLongRunningOperation>(
                    r.Response.Content.ReadAsStringAsync().Result).Status))
                .ForMember(c => c.StartTime, o => o.MapFrom(r => JsonConvert.DeserializeObject<TO.PSComputeLongRunningOperation>(
                    r.Response.Content.ReadAsStringAsync().Result).StartTime))
                .ForMember(c => c.EndTime, o => o.MapFrom(r => JsonConvert.DeserializeObject<TO.PSComputeLongRunningOperation>(
                    r.Response.Content.ReadAsStringAsync().Result).EndTime))
                .ForMember(c => c.Error, o => o.MapFrom(r => JsonConvert.DeserializeObject<TO.PSComputeLongRunningOperation>(
                    r.Response.Content.ReadAsStringAsync().Result).Error));

            Mapper.CreateMap<Rest.Azure.AzureOperationResponse<FROM.VirtualMachine>, TO.PSComputeLongRunningOperation>()
                .ForMember(c => c.OperationId, o => o.MapFrom(r => JsonConvert.DeserializeObject<TO.PSComputeLongRunningOperation>(
                    r.Response.Content.ReadAsStringAsync().Result).OperationId))
                .ForMember(c => c.Status, o => o.MapFrom(r => JsonConvert.DeserializeObject<TO.PSComputeLongRunningOperation>(
                    r.Response.Content.ReadAsStringAsync().Result).Status))
                .ForMember(c => c.StartTime, o => o.MapFrom(r => JsonConvert.DeserializeObject<TO.PSComputeLongRunningOperation>(
                    r.Response.Content.ReadAsStringAsync().Result).StartTime))
                .ForMember(c => c.EndTime, o => o.MapFrom(r => JsonConvert.DeserializeObject<TO.PSComputeLongRunningOperation>(
                    r.Response.Content.ReadAsStringAsync().Result).EndTime))
                .ForMember(c => c.Error, o => o.MapFrom(r => JsonConvert.DeserializeObject<TO.PSComputeLongRunningOperation>(
                    r.Response.Content.ReadAsStringAsync().Result).Error));

            Mapper.CreateMap<Rest.Azure.AzureOperationResponse<FROM.VirtualMachineCaptureResult>, TO.PSComputeLongRunningOperation>()
                .ForMember(c => c.OperationId, o => o.MapFrom(r => JsonConvert.DeserializeObject<TO.PSComputeLongRunningOperation>(
                    r.Response.Content.ReadAsStringAsync().Result).OperationId))
                .ForMember(c => c.Status, o => o.MapFrom(r => JsonConvert.DeserializeObject<TO.PSComputeLongRunningOperation>(
                    r.Response.Content.ReadAsStringAsync().Result).Status))
                .ForMember(c => c.StartTime, o => o.MapFrom(r => JsonConvert.DeserializeObject<TO.PSComputeLongRunningOperation>(
                    r.Response.Content.ReadAsStringAsync().Result).StartTime))
                .ForMember(c => c.EndTime, o => o.MapFrom(r => JsonConvert.DeserializeObject<TO.PSComputeLongRunningOperation>(
                    r.Response.Content.ReadAsStringAsync().Result).EndTime))
                .ForMember(c => c.Error, o => o.MapFrom(r => JsonConvert.DeserializeObject<TO.PSComputeLongRunningOperation>(
                    r.Response.Content.ReadAsStringAsync().Result).Error));

            Mapper.CreateMap<Rest.Azure.AzureOperationResponse<FROM.VirtualMachineExtension>, TO.PSComputeLongRunningOperation>()
                .ForMember(c => c.OperationId, o => o.MapFrom(r => JsonConvert.DeserializeObject<TO.PSComputeLongRunningOperation>(
                    r.Response.Content.ReadAsStringAsync().Result).OperationId))
                .ForMember(c => c.Status, o => o.MapFrom(r => JsonConvert.DeserializeObject<TO.PSComputeLongRunningOperation>(
                    r.Response.Content.ReadAsStringAsync().Result).Status))
                .ForMember(c => c.StartTime, o => o.MapFrom(r => JsonConvert.DeserializeObject<TO.PSComputeLongRunningOperation>(
                    r.Response.Content.ReadAsStringAsync().Result).StartTime))
                .ForMember(c => c.EndTime, o => o.MapFrom(r => JsonConvert.DeserializeObject<TO.PSComputeLongRunningOperation>(
                    r.Response.Content.ReadAsStringAsync().Result).EndTime))
                .ForMember(c => c.Error, o => o.MapFrom(r => JsonConvert.DeserializeObject<TO.PSComputeLongRunningOperation>(
                    r.Response.Content.ReadAsStringAsync().Result).Error));

            // => PSAzureOperationResponse
            Mapper.CreateMap<Rest.Azure.AzureOperationResponse, TO.PSAzureOperationResponse>()
                .ForMember(c => c.StatusCode, o => o.MapFrom(r => r.Response.StatusCode))
                .ForMember(c => c.IsSuccessStatusCode, o => o.MapFrom(r => r.Response.IsSuccessStatusCode))
                .ForMember(c => c.ReasonPhrase, o => o.MapFrom(r => r.Response.ReasonPhrase));

            Mapper.CreateMap<AzureOperationResponse<FROM.VirtualMachine>, TO.PSAzureOperationResponse>()
                .ForMember(c => c.StatusCode, o => o.MapFrom(r => r.Response.StatusCode))
                .ForMember(c => c.IsSuccessStatusCode, o => o.MapFrom(r => r.Response.IsSuccessStatusCode))
                .ForMember(c => c.ReasonPhrase, o => o.MapFrom(r => r.Response.ReasonPhrase));

            Mapper.CreateMap<AzureOperationResponse<FROM.VirtualMachineCaptureResult>, TO.PSAzureOperationResponse>()
                .ForMember(c => c.StatusCode, o => o.MapFrom(r => r.Response.StatusCode))
                .ForMember(c => c.IsSuccessStatusCode, o => o.MapFrom(r => r.Response.IsSuccessStatusCode))
                .ForMember(c => c.ReasonPhrase, o => o.MapFrom(r => r.Response.ReasonPhrase));

            Mapper.CreateMap<AzureOperationResponse<FROM.VirtualMachineExtension>, TO.PSAzureOperationResponse>()
                .ForMember(c => c.StatusCode, o => o.MapFrom(r => r.Response.StatusCode))
                .ForMember(c => c.IsSuccessStatusCode, o => o.MapFrom(r => r.Response.IsSuccessStatusCode))
                .ForMember(c => c.ReasonPhrase, o => o.MapFrom(r => r.Response.ReasonPhrase));

            // AvailabilitySet => PSAvailabilitySet
            Mapper.CreateMap<FROM.AvailabilitySet, TO.PSAvailabilitySet>()
                .ForMember(c => c.VirtualMachinesReferences, o => o.MapFrom(r => r.VirtualMachines));

            Mapper.CreateMap<AzureOperationResponse<FROM.AvailabilitySet>, TO.PSAvailabilitySet>()
                .ForMember(c => c.StatusCode, o => o.MapFrom(r => r.Response.StatusCode));

            Mapper.CreateMap<AzureOperationResponse<IEnumerable<FROM.AvailabilitySet>>, TO.PSAvailabilitySet>()
                .ForMember(c => c.StatusCode, o => o.MapFrom(r => r.Response.StatusCode));

            // VirtualMachine => PSVirtualMachine
            Mapper.CreateMap<FROM.VirtualMachine, TO.PSVirtualMachine>()
                .ForMember(c => c.AvailabilitySetReference, o => o.MapFrom(r => r.AvailabilitySet))
                .ForMember(c => c.Extensions, o => o.MapFrom(r => r.Resources))
                .ForMember(c => c.OSProfile, o => o.MapFrom(r => r.OsProfile));

            Mapper.CreateMap<AzureOperationResponse<FROM.VirtualMachine>, TO.PSVirtualMachine>()
                .ForMember(c => c.StatusCode, o => o.MapFrom(r => r.Response.StatusCode));

            Mapper.CreateMap<AzureOperationResponse<IPage<FROM.VirtualMachine>>, TO.PSVirtualMachine>()
                .ForMember(c => c.StatusCode, o => o.MapFrom(r => r.Response.StatusCode));

            Mapper.CreateMap<AzureOperationResponse<IEnumerable<FROM.VirtualMachine>>, TO.PSVirtualMachine>()
                .ForMember(c => c.StatusCode, o => o.MapFrom(r => r.Response.StatusCode));

            // VirtualMachineSize => PSVirtualMachineSize
            Mapper.CreateMap<FROM.VirtualMachineSize, TO.PSVirtualMachineSize>();

            Mapper.CreateMap<AzureOperationResponse<FROM.VirtualMachineSize>, TO.PSVirtualMachineSize>()
                .ForMember(c => c.StatusCode, o => o.MapFrom(r => r.Response.StatusCode));

            Mapper.CreateMap<AzureOperationResponse<IEnumerable<FROM.VirtualMachineSize>>, TO.PSVirtualMachineSize>()
                .ForMember(c => c.StatusCode, o => o.MapFrom(r => r.Response.StatusCode));

            // Usage => PSUsage
            Mapper.CreateMap<FROM.Usage, TO.PSUsage>()
                .ForMember(c => c.Unit, o => o.MapFrom(r => Microsoft.Azure.Management.Compute.Models.Usage.Unit));

            Mapper.CreateMap<AzureOperationResponse<FROM.Usage>, TO.PSUsage>()
                .ForMember(c => c.StatusCode, o => o.MapFrom(r => r.Response.StatusCode));

            Mapper.CreateMap<AzureOperationResponse<IPage<FROM.Usage>>, TO.PSUsage>()
                .ForMember(c => c.StatusCode, o => o.MapFrom(r => r.Response.StatusCode));
        }
    }
}
