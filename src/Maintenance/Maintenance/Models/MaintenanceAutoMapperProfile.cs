//
// Copyright (c) Microsoft and contributors.  All rights reserved.
//
//-----------------------------------------------------------------------
// <copyright company="Microsoft">
//     Copyright (c) Microsoft Corporation.  All rights reserved.
// </copyright>
// <summary>
//   Refer to the class documentation.
// </summary>
//-----------------------------------------------------------------------

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
