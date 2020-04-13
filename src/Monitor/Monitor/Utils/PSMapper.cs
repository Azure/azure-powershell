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
                cfg.CreateMap<ScopedResource, PSMonitorPrivateLinkScopedResource>().ReverseMap();
                cfg.CreateMap<PrivateEndpointConnection, PSPrivateEndpointConnection>().ReverseMap();
                cfg.CreateMap<PrivateEndpointProperty, PSPrivateEndpointProperty>().ReverseMap();
                cfg.CreateMap<PrivateLinkServiceConnectionStateProperty, PSPrivateLinkServiceConnectionStateProperty>().ReverseMap();
            });
            _instance = config.CreateMapper();
        }

        public static IMapper Instance { get { return _instance; } }
    }
}
