using AutoMapper;
using Microsoft.Azure.Management.Monitor.Models;
using Microsoft.Azure.Commands.Insights.OutputClasses;

namespace Microsoft.Azure.Commands.Insights.Utils
{
    class PSMapper
    {
        private static readonly IMapper _instance;

        static PSMapper()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<AzureMonitorPrivateLinkScope, PSMonitorPrivateLinkScope>().ReverseMap();
            });
            _instance = config.CreateMapper();
        }

        public static IMapper Instance { get { return _instance; } }
    }
}
