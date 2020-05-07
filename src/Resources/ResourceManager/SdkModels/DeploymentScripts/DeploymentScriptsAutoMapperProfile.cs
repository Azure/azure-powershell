using AutoMapper;
using Microsoft.Azure.Management.ResourceManager.Models;

namespace Microsoft.Azure.Commands.ResourceManager.Cmdlets.SdkModels
{
    class DeploymentScriptsAutoMapperProfile : AutoMapper.Profile
    {
        private static IMapper _mapper = null;

        private static readonly object _lock = new object();

        public static IMapper Mapper
        {
            get
            {
                lock (_lock)
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
            get { return "DeploymentScriptsAutoMapperProfile"; }
        }

        private static void Initialize()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<ScriptStatus, PsScriptStatus>();              
            });

            _mapper = config.CreateMapper();
        }
    }
}
