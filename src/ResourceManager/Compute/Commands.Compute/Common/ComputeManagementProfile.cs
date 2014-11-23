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

namespace Microsoft.Azure.Commands.Compute
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using AutoMapper;
    using Common;
    using CCM = Microsoft.Azure.Commands.Compute.Models;
    using MCM = Microsoft.Azure.Management.Compute.Models;

    public static class ComputeManagementMapperExtension
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

    public class ComputeManagementProfile : Profile
    {
        private static readonly Lazy<bool> initialize;

        static ComputeManagementProfile()
        {
            initialize = new Lazy<bool>(() =>
            {
                Mapper.AddProfile<ComputeManagementProfile>();
                return true;
            });
        }

        public override string ProfileName
        {
            get { return "ComputeManagementProfile"; }
        }

        public static bool Initialize()
        {
            return initialize.Value;
        }

        protected override void Configure()
        {
            // CCM to MCM
            Mapper.CreateMap<CCM.ApiEntityReference, MCM.ApiEntityReference>();

            Mapper.CreateMap<CCM.Disk, MCM.Disk>();
            Mapper.CreateMap<CCM.DataDisk, MCM.DataDisk>();
            Mapper.CreateMap<CCM.OSDisk, MCM.OSDisk>()
                  .ConstructUsing((Func<CCM.OSDisk, MCM.OSDisk>)(x => new MCM.OSDisk()));
            Mapper.CreateMap<CCM.SourceImageReference, MCM.SourceImageReference>();
            Mapper.CreateMap<CCM.StorageProfile, MCM.StorageProfile>()
                  .ForMember(c => c.OSDisk, o => o.MapFrom(r => r.OSDisk == null ? null : r.OSDisk));

            Mapper.CreateMap<CCM.OSProfile, MCM.OSProfile>().ForMember(
                c => c.AdminPassword, o => o.MapFrom(r => r.AdminPassword == null ? null : r.AdminPassword.ConvertToUnsecureString()));

            Mapper.CreateMap<CCM.HardwareProfile, MCM.HardwareProfile>();

            Mapper.CreateMap<CCM.PublicIPAddress, MCM.PublicIPAddress>();
            Mapper.CreateMap<CCM.IPConfiguration, MCM.IPConfiguration>();
            Mapper.CreateMap<CCM.NetworkInterfaceProperties, MCM.NetworkInterfaceProperties>();
            Mapper.CreateMap<CCM.NetworkInterface, MCM.NetworkInterface>();
            Mapper.CreateMap<CCM.NetworkProfile, MCM.NetworkProfile>();

            Mapper.CreateMap<CCM.PSVirtualMachineProfile, MCM.VirtualMachineProperties>();
            Mapper.CreateMap<CCM.VirtualMachine, MCM.VirtualMachine>().ForMember(
                c => c.VirtualMachineProperties, o => o.MapFrom(r => r.VMProfile));

            // MCM to CCM
            Mapper.CreateMap<MCM.ApiEntityReference, CCM.ApiEntityReference>();

            Mapper.CreateMap<MCM.Disk, CCM.Disk>();
            Mapper.CreateMap<MCM.DataDisk, CCM.DataDisk>();
            Mapper.CreateMap<MCM.OSDisk, CCM.OSDisk>()
                  .ConstructUsing((Func<MCM.OSDisk, CCM.OSDisk>)(x => new CCM.OSDisk()));
            Mapper.CreateMap<MCM.SourceImageReference, CCM.SourceImageReference>();
            Mapper.CreateMap<MCM.StorageProfile, CCM.StorageProfile>()
                  .ForMember(c => c.OSDisk, o => o.MapFrom(r => r.OSDisk == null ? null : r.OSDisk));

            Mapper.CreateMap<MCM.OSProfile, CCM.OSProfile>().ForMember(
                c => c.AdminPassword, o => o.MapFrom(r => SecureStringExtension.GetSecureString(r.AdminPassword)));

            Mapper.CreateMap<MCM.HardwareProfile, CCM.HardwareProfile>();

            Mapper.CreateMap<MCM.PublicIPAddress, CCM.PublicIPAddress>();
            Mapper.CreateMap<MCM.IPConfiguration, CCM.IPConfiguration>();
            Mapper.CreateMap<MCM.NetworkInterfaceProperties, CCM.NetworkInterfaceProperties>();
            Mapper.CreateMap<MCM.NetworkInterface, CCM.NetworkInterface>();
            Mapper.CreateMap<MCM.NetworkProfile, CCM.NetworkProfile>();

            Mapper.CreateMap<MCM.VirtualMachineProperties, CCM.PSVirtualMachineProfile>();
            Mapper.CreateMap<MCM.VirtualMachine, CCM.VirtualMachine>().ForMember(
                c => c.VMProfile, o => o.MapFrom(r => r.VirtualMachineProperties));

            // PS Profile to Models
            Mapper.CreateMap<CCM.PSVirtualMachineProfile, CCM.VirtualMachine>()
                  .ForMember(c => c.Type, o => o.Ignore());

            Mapper.CreateMap<CCM.PSVirtualMachineProfile, CCM.PSVirtualMachineProfile>();
            Mapper.CreateMap<CCM.PSVirtualMachineProfile, MCM.VirtualMachineProperties>();

            // Cmdlets to Models
            Mapper.CreateMap<NewAzureVMCommand, CCM.PSVirtualMachineProfile>();
            Mapper.CreateMap<NewAzureVMCommand, MCM.VirtualMachineProperties>();
            Mapper.CreateMap<SetAzureVMCommand, CCM.PSVirtualMachineProfile>();
            Mapper.CreateMap<SetAzureVMCommand, MCM.VirtualMachineProperties>();
        }
    }
}