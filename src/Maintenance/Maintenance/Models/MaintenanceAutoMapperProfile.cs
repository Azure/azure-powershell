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
                cfg.CreateMap<TO.PSApplyUpdate, FROM.ApplyUpdate>();
                cfg.CreateMap<FROM.ConfigurationAssignment, TO.PSConfigurationAssignment>();
                cfg.CreateMap<TO.PSConfigurationAssignment, FROM.ConfigurationAssignment>();
                cfg.CreateMap<FROM.MaintenanceConfiguration, TO.PSMaintenanceConfiguration>();
                cfg.CreateMap<TO.PSMaintenanceConfiguration, FROM.MaintenanceConfiguration>();
                cfg.CreateMap<FROM.Update, TO.PSUpdate>();
                cfg.CreateMap<TO.PSUpdate, FROM.Update>();

            });
            _mapper = config.CreateMapper();
        }
    }
}
