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
                cfg.CreateMap<FROM.ApplyUpdate, TO.PSApplyUpdate>();
                cfg.CreateMap<TO.PSApplyUpdate, FROM.ApplyUpdate>()
                    .ForMember(src => src.SystemData, s => s.Ignore());
                cfg.CreateMap<FROM.ConfigurationAssignment, TO.PSConfigurationAssignment>();
                cfg.CreateMap<TO.PSConfigurationAssignment, FROM.ConfigurationAssignment>()
                    .ForMember(src => src.SystemData, s => s.Ignore());
                cfg.CreateMap<FROM.MaintenanceConfiguration, TO.PSMaintenanceConfiguration>()
                    .ForMember(dest => dest.InstallPatchRebootSetting, opt => opt.MapFrom(src => src.InstallPatches.RebootSetting))
                    .ForMember(dest => dest.LinuxParameterClassificationToInclude, opt => opt.MapFrom(src => src.InstallPatches.LinuxParameters.ClassificationsToInclude))
                    .ForMember(dest => dest.LinuxParameterPackageNameMaskToExclude, opt => opt.MapFrom(src => src.InstallPatches.LinuxParameters.PackageNameMasksToExclude))
                    .ForMember(dest => dest.LinuxParameterPackageNameMaskToInclude, opt => opt.MapFrom(src => src.InstallPatches.LinuxParameters.PackageNameMasksToInclude))
                    .ForMember(dest => dest.WindowParameterClassificationToInclude, opt => opt.MapFrom(src => src.InstallPatches.WindowsParameters.ClassificationsToInclude))
                    .ForMember(dest => dest.WindowParameterExcludeKbRequiringReboot, opt => opt.MapFrom(src => src.InstallPatches.WindowsParameters.ExcludeKbsRequiringReboot))
                    .ForMember(dest => dest.WindowParameterKbNumberToExclude, opt => opt.MapFrom(src => src.InstallPatches.WindowsParameters.KbNumbersToExclude))
                    .ForMember(dest => dest.WindowParameterKbNumberToInclude, opt => opt.MapFrom(src => src.InstallPatches.WindowsParameters.KbNumbersToInclude))
                    .ForMember(dest => dest.PreTask, opt => opt.MapFrom(src => src.InstallPatches.PreTasks))
                    .ForMember(dest => dest.PostTask, opt => opt.MapFrom(src => src.InstallPatches.PostTasks))
                    .ForMember(dest => dest.InstallPatchRebootSetting, opt => opt.MapFrom(src => src.InstallPatches.RebootSetting))
                    .ForSourceMember(src => src.SystemData, s => s.Ignore())
                    .ForSourceMember(src => src.InstallPatches, s => s.Ignore())
                                        .ForPath(dst => dst.PostTask, s => s.Ignore())
                    .ForPath(dst => dst.PreTask, s => s.Ignore())
                    .AfterMap((src, dst) => {
                        if (src?.InstallPatches?.PreTasks?.Any() ?? false)
                        {
                            dst.PreTask = Newtonsoft.Json.JsonConvert.SerializeObject(src.InstallPatches.PreTasks);
                        }
                        if (src?.InstallPatches?.PostTasks?.Any() ?? false)
                        {
                            dst.PostTask = Newtonsoft.Json.JsonConvert.SerializeObject(src.InstallPatches.PostTasks);
                        }
                    });
                cfg.CreateMap<TO.PSMaintenanceConfiguration, FROM.MaintenanceConfiguration>()
                    .ForPath(dest => dest.InstallPatches.LinuxParameters.ClassificationsToInclude, src => src.MapFrom(o => o.LinuxParameterClassificationToInclude))
                    .ForPath(dest => dest.InstallPatches.LinuxParameters.PackageNameMasksToInclude, src => src.MapFrom(o => o.LinuxParameterPackageNameMaskToInclude))
                    .ForPath(dest => dest.InstallPatches.LinuxParameters.PackageNameMasksToExclude, src => src.MapFrom(o => o.LinuxParameterPackageNameMaskToExclude))
                    .ForPath(dest => dest.InstallPatches.WindowsParameters.ClassificationsToInclude, src => src.MapFrom(o => o.WindowParameterClassificationToInclude))
                    .ForPath(dest => dest.InstallPatches.WindowsParameters.ExcludeKbsRequiringReboot, src => src.MapFrom(o => o.WindowParameterExcludeKbRequiringReboot))
                    .ForPath(dest => dest.InstallPatches.WindowsParameters.KbNumbersToExclude, src => src.MapFrom(o => o.WindowParameterKbNumberToExclude))
                    .ForPath(dest => dest.InstallPatches.WindowsParameters.KbNumbersToInclude, src => src.MapFrom(o => o.WindowParameterKbNumberToInclude))
                    .AfterMap((src, dst) => {
                        if (string.IsNullOrEmpty(src.InstallPatchRebootSetting) &&
                            string.IsNullOrEmpty(src.PostTask) &&
                            string.IsNullOrEmpty(src.PreTask) &&
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
                        else
                        {
                            if(string.IsNullOrEmpty(src.PreTask))
                            {
                                dst.InstallPatches.PreTasks = Newtonsoft.Json.JsonConvert.DeserializeObject<List<FROM.TaskProperties>>(src.PreTask);
                                dst.InstallPatches.PostTasks = Newtonsoft.Json.JsonConvert.DeserializeObject<List<FROM.TaskProperties>>(src.PostTask);
                            }
                        }
                    })
                    .ForPath(dest => dest.InstallPatches.PostTasks, s => s.Ignore())
                    .ForPath(dest => dest.InstallPatches.PreTasks, s => s.Ignore())
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
