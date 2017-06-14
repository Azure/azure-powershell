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

using System;
using AutoMapper;
using Microsoft.WindowsAzure.Commands.ServiceManagement.Extensions;
using Microsoft.WindowsAzure.Commands.ServiceManagement.PlatformImageRepository.ExtensionPublishing;
using Microsoft.WindowsAzure.Commands.ServiceManagement.PlatformImageRepository.Model;
using Microsoft.WindowsAzure.Management.Compute.Models;

namespace Microsoft.WindowsAzure.Commands.ServiceManagement.PlatformImageRepository
{
    public class ServiceManagementPlatformImageRepositoryProfile : Profile
    {
        private static readonly Lazy<bool> initialize;

        static ServiceManagementPlatformImageRepositoryProfile()
        {
            initialize = new Lazy<bool>(() =>
            {
                Mapper.AddProfile<ServiceManagementPlatformImageRepositoryProfile>();
                return true;
            });
        }

        public static bool Initialize()
        {
            return ServiceManagementProfile.Initialize() && initialize.Value;
        }

        public override string ProfileName
        {
            get { return "ServiceManagementPlatformImageRepositoryProfile"; }
        }

        protected override void Configure()
        {
            Mapper.CreateMap<NewAzurePlatformExtensionCertificateConfigCommand, ExtensionCertificateConfig>()
                  .ForMember(c => c.ThumbprintRequired, o => o.MapFrom(r => r.ThumbprintRequired.IsPresent));

            Mapper.CreateMap<ExtensionCertificateConfig, ExtensionCertificateConfiguration>();
            Mapper.CreateMap<ExtensionLocalResourceConfig, ExtensionLocalResourceConfiguration>();
            Mapper.CreateMap<ExtensionInternalEndpoint, ExtensionEndpointConfiguration.InternalEndpoint>();
            Mapper.CreateMap<ExtensionInputEndpoint, ExtensionEndpointConfiguration.InputEndpoint>();
            Mapper.CreateMap<ExtensionInstanceInputEndpoint, ExtensionEndpointConfiguration.InstanceInputEndpoint>();
            Mapper.CreateMap<ExtensionEndpointConfigSet, ExtensionEndpointConfiguration>();

            Mapper.CreateMap<ExtensionImage, ExtensionImageContext>()
                  .ForMember(c => c.ThumbprintAlgorithm, o => o.MapFrom(r => r.Certificate.ThumbprintAlgorithm))
                  .ForMember(c => c.ExtensionName, o => o.MapFrom(r => r.Type));

            Mapper.CreateMap<PublishAzurePlatformExtensionCommand, ExtensionImageRegisterParameters>()
                  .ForMember(c => c.IsJsonExtension, o => o.MapFrom(r => !r.XmlExtension.IsPresent))
                  .ForMember(c => c.Type, o => o.MapFrom(r => r.ExtensionName))
                  .ForMember(c => c.ProviderNameSpace, o => o.MapFrom(r => r.Publisher))
                  .ForMember(c => c.BlockRoleUponFailure, o => o.MapFrom(r => r.BlockRoleUponFailure.IsPresent))
                  .ForMember(c => c.DisallowMajorVersionUpgrade, o => o.MapFrom(r => r.DisallowMajorVersionUpgrade.IsPresent))
                  .ForMember(c => c.Certificate, o => o.MapFrom(r => r.CertificateConfig))
                  .ForMember(c => c.ExtensionEndpoints, o => o.MapFrom(r => r.EndpointConfig))
                  .ForMember(c => c.LocalResources, o => o.MapFrom(r => r.LocalResourceConfig == null ? null : r.LocalResourceConfig.LocalResources))
                  .ForMember(c => c.PublisherName, o => o.MapFrom(r => r != null ? (string)null : null))
                  .ForMember(c => c.SupportedOS, o => o.MapFrom(r => r.SupportedOS ?? ExtensionImageSupportedOperatingSystemType.Windows));

            Mapper.CreateMap<PublishAzurePlatformExtensionCommand, ExtensionImageUpdateParameters>()
                  .ForMember(c => c.IsJsonExtension, o => o.MapFrom(r => !r.XmlExtension.IsPresent))
                  .ForMember(c => c.Type, o => o.MapFrom(r => r.ExtensionName))
                  .ForMember(c => c.ProviderNameSpace, o => o.MapFrom(r => r.Publisher))
                  .ForMember(c => c.BlockRoleUponFailure, o => o.MapFrom(r => r.BlockRoleUponFailure.IsPresent))
                  .ForMember(c => c.DisallowMajorVersionUpgrade, o => o.MapFrom(r => r.DisallowMajorVersionUpgrade.IsPresent))
                  .ForMember(c => c.Certificate, o => o.MapFrom(r => r.CertificateConfig))
                  .ForMember(c => c.ExtensionEndpoints, o => o.MapFrom(r => r.EndpointConfig))
                  .ForMember(c => c.LocalResources, o => o.MapFrom(r => r.LocalResourceConfig == null ? null : r.LocalResourceConfig.LocalResources))
                  .ForMember(c => c.PublisherName, o => o.MapFrom(r => r != null ? (string)null : null))
                  .ForMember(c => c.SupportedOS, o => o.MapFrom(r => r.SupportedOS ?? ExtensionImageSupportedOperatingSystemType.Windows));

            Mapper.CreateMap<SetAzurePlatformExtensionCommand, ExtensionImageUpdateParameters>()
                  .ForMember(c => c.Type, o => o.MapFrom(r => r.ExtensionName))
                  .ForMember(c => c.ProviderNameSpace, o => o.MapFrom(r => r.Publisher))
                  .ForMember(c => c.PublisherName, o => o.MapFrom(r => r != null ? (string)null : null));
        }
    }
}