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
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using FROM = Microsoft.Azure.Management.Maintenance.Models;
using TO = Microsoft.Azure.Commands.Maintenance.Models;

namespace Microsoft.Azure.Commands.Maintenance.Models
{
    public class MaintenanceAutomationAutoMapperProfile : AutoMapper.Profile
    {
        private static IMapper _mapper = null;

        private static readonly object _lock = new object();

        public static IMapper Mapper
        {
            get
            {
                lock(_lock)
                {
                    if (_mapper == null)
                    {
                        Initialize();
                    }

                    return _mapper;
                }
            }
        }

        public override string ProfileName
        {
            get { return "MaintenanceAutomationAutoMapperProfile"; }
        }

        private static void Initialize()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<FROM.ApplyUpdate, TO.PSApplyUpdate>()
                    .ForMember(dest => dest.Status, src => src.MapFrom(o => o.Status));
                cfg.CreateMap<TO.PSApplyUpdate, FROM.ApplyUpdate>()
                    .ForMember(dest => dest.Status, src => src.MapFrom(o => o.Status))
                    .ForMember(src => src.SystemData, s => s.Ignore());
                cfg.CreateMap<FROM.ConfigurationAssignment, TO.PSConfigurationAssignment>()
                    .ForMember(dest => dest.FilterResourceGroup, src => src.MapFrom(o => o.Filter.ResourceGroups))
                    .ForMember(dest => dest.FilterLocation, src => src.MapFrom(o => o.Filter.Locations))
                    .ForMember(dest => dest.FilterOsType, src => src.MapFrom(o => o.Filter.OsTypes))
                    .ForMember(dest => dest.FilterTag, src => src.MapFrom(o => o.Filter.TagSettings.Tags))
                    .ForMember(dest => dest.FilterOperator, src => src.MapFrom(o => o.Filter.TagSettings.FilterOperator))
                    .ForMember(dest => dest.FilterResourceType, src => src.MapFrom(o => o.Filter.ResourceTypes))
                    .AfterMap((src, dst) => {
                         if (src?.Filter?.TagSettings?.Tags?.Any() ?? false)
                         {
                             dst.FilterTag = Newtonsoft.Json.JsonConvert.SerializeObject(src.Filter.TagSettings.Tags);
                         }
                    });
                cfg.CreateMap<TO.PSConfigurationAssignment, FROM.ConfigurationAssignment>()
                    .ForMember(src => src.SystemData, s => s.Ignore())
                    .ForPath(dest => dest.Filter.ResourceGroups, src => src.MapFrom(o => o.FilterResourceGroup))
                    .ForPath(dest => dest.Filter.Locations, src => src.MapFrom(o => o.FilterLocation))
                    .ForPath(dest => dest.Filter.OsTypes, src => src.MapFrom(o => o.FilterOsType))
                    .ForPath(dest => dest.Filter.TagSettings.Tags, src => src.MapFrom(o => o.FilterTag))
                    .ForPath(dest => dest.Filter.TagSettings.FilterOperator, src => src.MapFrom(o => o.FilterOperator))
                    .ForPath(dest => dest.Filter.ResourceTypes, src => src.MapFrom(o => o.FilterResourceType));
                cfg.CreateMap<FROM.MaintenanceConfiguration, TO.PSMaintenanceConfiguration>()
                    .ForMember(dest => dest.InstallPatchRebootSetting, opt => opt.MapFrom(src => src.InstallPatches.RebootSetting))
                    .ForMember(dest => dest.LinuxParameterClassificationToInclude, opt => opt.MapFrom(src => src.InstallPatches.LinuxParameters.ClassificationsToInclude))
                    .ForMember(dest => dest.LinuxParameterPackageNameMaskToExclude, opt => opt.MapFrom(src => src.InstallPatches.LinuxParameters.PackageNameMasksToExclude))
                    .ForMember(dest => dest.LinuxParameterPackageNameMaskToInclude, opt => opt.MapFrom(src => src.InstallPatches.LinuxParameters.PackageNameMasksToInclude))
                    .ForMember(dest => dest.WindowParameterClassificationToInclude, opt => opt.MapFrom(src => src.InstallPatches.WindowsParameters.ClassificationsToInclude))
                    .ForMember(dest => dest.WindowParameterExcludeKbRequiringReboot, opt => opt.MapFrom(src => src.InstallPatches.WindowsParameters.ExcludeKbsRequiringReboot))
                    .ForMember(dest => dest.WindowParameterKbNumberToExclude, opt => opt.MapFrom(src => src.InstallPatches.WindowsParameters.KbNumbersToExclude))
                    .ForMember(dest => dest.WindowParameterKbNumberToInclude, opt => opt.MapFrom(src => src.InstallPatches.WindowsParameters.KbNumbersToInclude))
                    .ForMember(dest => dest.PreTask, opt => opt.Ignore())
                    .ForMember(dest => dest.PostTask, opt => opt.Ignore())
                    .ForSourceMember(src => src.SystemData, s => s.Ignore());
                cfg.CreateMap<TO.PSMaintenanceConfiguration, FROM.MaintenanceConfiguration>()
                    .ForPath(dest => dest.InstallPatches.LinuxParameters.ClassificationsToInclude, src => src.MapFrom(o => o.LinuxParameterClassificationToInclude))
                    .ForPath(dest => dest.InstallPatches.LinuxParameters.PackageNameMasksToInclude, src => src.MapFrom(o => o.LinuxParameterPackageNameMaskToInclude))
                    .ForPath(dest => dest.InstallPatches.LinuxParameters.PackageNameMasksToExclude, src => src.MapFrom(o => o.LinuxParameterPackageNameMaskToExclude))
                    .ForPath(dest => dest.InstallPatches.WindowsParameters.ClassificationsToInclude, src => src.MapFrom(o => o.WindowParameterClassificationToInclude))
                    .ForPath(dest => dest.InstallPatches.WindowsParameters.ExcludeKbsRequiringReboot, src => src.MapFrom(o => o.WindowParameterExcludeKbRequiringReboot))
                    .ForPath(dest => dest.InstallPatches.WindowsParameters.KbNumbersToExclude, src => src.MapFrom(o => o.WindowParameterKbNumberToExclude))
                    .ForPath(dest => dest.InstallPatches.WindowsParameters.KbNumbersToInclude, src => src.MapFrom(o => o.WindowParameterKbNumberToInclude))
                    .ForPath(dest => dest.InstallPatches.RebootSetting, src => src.MapFrom(o => o.InstallPatchRebootSetting))
                    .AfterMap((src, dst) => {
                        if (string.IsNullOrEmpty(src.InstallPatchRebootSetting) &&
                            !src.WindowParameterExcludeKbRequiringReboot.HasValue &&
                            IsEmpty(src.LinuxParameterClassificationToInclude) &&
                            IsEmpty(src.LinuxParameterPackageNameMaskToExclude) &&
                            IsEmpty(src.LinuxParameterPackageNameMaskToInclude) &&
                            IsEmpty(src.WindowParameterClassificationToInclude) &&
                            IsEmpty(src.WindowParameterKbNumberToExclude) &&
                            IsEmpty(src.WindowParameterKbNumberToInclude))
                        {
                            dst.InstallPatches = null;
                        }
                    })
                    .ForMember(dest => dest.SystemData, s => s.Ignore());
                cfg.CreateMap<FROM.Update, TO.PSUpdate>();
                cfg.CreateMap<TO.PSUpdate, FROM.Update>();

            });
            _mapper = config.CreateMapper();
            config.AssertConfigurationIsValid();
        }
        public static bool IsEmpty<T>(IEnumerable<T> collection)
        {
            return !(collection != null && collection.Any());
        }
    }
}
