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
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net;
using AutoMapper;
using Microsoft.WindowsAzure.Commands.ServiceManagement.Extensions;
using Microsoft.WindowsAzure.Commands.ServiceManagement.Helpers;
using Microsoft.WindowsAzure.Commands.ServiceManagement.IaaS.Extensions;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using Microsoft.WindowsAzure.Management.Models;
using Microsoft.WindowsAzure.Management.Storage.Models;

namespace Microsoft.WindowsAzure.Commands.ServiceManagement
{
    using NSM = Management.Compute.Models;
    using NVM = Management.Network.Models;
    using PVM = Model;
    using Microsoft.Azure;

    public class ServiceManagementProfile : Profile
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
            get { return "ServiceManagementProfile"; }
        }

        public static void Initialize()
        {
            var config = new MapperConfiguration(cfg => {
                cfg.AddProfile<ServiceManagementProfile>();

                // Service Extension Image
                cfg.CreateMap<OperationStatusResponse, ExtensionImageContext>()
                      .ForMember(c => c.OperationId, o => o.MapFrom(r => r.Id))
                      .ForMember(c => c.OperationStatus, o => o.MapFrom(r => r.Status.ToString()));

                cfg.CreateMap<NSM.ExtensionImage, ExtensionImageContext>()
                      .ForMember(c => c.ThumbprintAlgorithm, o => o.MapFrom(r => r.Certificate.ThumbprintAlgorithm))
                      .ForMember(c => c.ExtensionName, o => o.MapFrom(r => r.Type));

                // VM Extension Image
                cfg.CreateMap<OperationStatusResponse, VirtualMachineExtensionImageContext>()
                      .ForMember(c => c.OperationId, o => o.MapFrom(r => r.Id))
                      .ForMember(c => c.OperationStatus, o => o.MapFrom(r => r.Status.ToString()));

                cfg.CreateMap<NSM.VirtualMachineExtensionListResponse.ResourceExtension, VirtualMachineExtensionImageContext>()
                      .ForMember(c => c.ExtensionName, o => o.MapFrom(r => r.Name));

                //Image mapping
                cfg.CreateMap<NSM.VirtualMachineOSImageListResponse.VirtualMachineOSImage, PVM.OSImageContext>()
                      .ForMember(c => c.MediaLink, o => o.MapFrom(r => r.MediaLinkUri))
                      .ForMember(c => c.ImageName, o => o.MapFrom(r => r.Name))
                      .ForMember(c => c.OS, o => o.MapFrom(r => r.OperatingSystemType))
                      .ForMember(c => c.PublishedDate, o => o.MapFrom(r => new DateTime?(r.PublishedDate)))
                      .ForMember(c => c.IconUri, o => o.MapFrom(r => r.SmallIconUri))
                      .ForMember(c => c.LogicalSizeInGB, o => o.MapFrom(r => (int)r.LogicalSizeInGB));

                cfg.CreateMap<NSM.VirtualMachineOSImageGetResponse, PVM.OSImageContext>()
                      .ForMember(c => c.ImageName, o => o.MapFrom(r => r.Name))
                      .ForMember(c => c.MediaLink, o => o.MapFrom(r => r.MediaLinkUri))
                      .ForMember(c => c.OS, o => o.MapFrom(r => r.OperatingSystemType))
                      .ForMember(c => c.PublishedDate, o => o.MapFrom(r => new DateTime?(r.PublishedDate)))
                      .ForMember(c => c.LogicalSizeInGB, o => o.MapFrom(r => (int)r.LogicalSizeInGB));

                cfg.CreateMap<NSM.VirtualMachineOSImageCreateResponse, PVM.OSImageContext>()
                      .ForMember(c => c.ImageName, o => o.MapFrom(r => r.Name))
                      .ForMember(c => c.MediaLink, o => o.MapFrom(r => r.MediaLinkUri))
                      .ForMember(c => c.IconUri, o => o.MapFrom(r => r.SmallIconUri))
                      .ForMember(c => c.OS, o => o.MapFrom(r => r.OperatingSystemType))
                      .ForMember(c => c.PublishedDate, o => o.MapFrom(r => r.PublishedDate))
                      .ForMember(c => c.LogicalSizeInGB, o => o.MapFrom(r => (int)r.LogicalSizeInGB));

                cfg.CreateMap<NSM.VirtualMachineOSImageUpdateResponse, PVM.OSImageContext>()
                      .ForMember(c => c.ImageName, o => o.MapFrom(r => r.Name))
                      .ForMember(c => c.MediaLink, o => o.MapFrom(r => r.MediaLinkUri))
                      .ForMember(c => c.IconUri, o => o.MapFrom(r => r.SmallIconUri))
                      .ForMember(c => c.OS, o => o.MapFrom(r => r.OperatingSystemType))
                      .ForMember(c => c.PublishedDate, o => o.MapFrom(r => r.PublishedDate))
                      .ForMember(c => c.LogicalSizeInGB, o => o.MapFrom(r => (int)r.LogicalSizeInGB));

                cfg.CreateMap<OperationStatusResponse, PVM.OSImageContext>()
                      .ForMember(c => c.OperationId, o => o.MapFrom(r => r.Id))
                      .ForMember(c => c.OperationStatus, o => o.MapFrom(r => r.Status.ToString()));

                cfg.CreateMap<NSM.VirtualMachineDiskCreateResponse, PVM.OSImageContext>()
                      .ForMember(c => c.MediaLink, o => o.MapFrom(r => r.MediaLinkUri))
                      .ForMember(c => c.ImageName, o => o.MapFrom(r => r.Name))
                      .ForMember(c => c.OS, o => o.MapFrom(r => r.OperatingSystem));

                // VM Image mapping
                cfg.CreateMap<NSM.VirtualMachineOSImageListResponse.VirtualMachineOSImage, PVM.VMImageContext>()
                      .ForMember(c => c.MediaLink, o => o.MapFrom(r => r.MediaLinkUri))
                      .ForMember(c => c.ImageName, o => o.MapFrom(r => r.Name))
                      .ForMember(c => c.OS, o => o.MapFrom(r => r.OperatingSystemType))
                      .ForMember(c => c.PublishedDate, o => o.MapFrom(r => new DateTime?(r.PublishedDate)))
                      .ForMember(c => c.IconUri, o => o.MapFrom(r => r.SmallIconUri))
                      .ForMember(c => c.LogicalSizeInGB, o => o.MapFrom(r => (int)r.LogicalSizeInGB));

                cfg.CreateMap<NSM.VirtualMachineOSImageGetResponse, PVM.VMImageContext>()
                      .ForMember(c => c.ImageName, o => o.MapFrom(r => r.Name))
                      .ForMember(c => c.MediaLink, o => o.MapFrom(r => r.MediaLinkUri))
                      .ForMember(c => c.OS, o => o.MapFrom(r => r.OperatingSystemType))
                      .ForMember(c => c.PublishedDate, o => o.MapFrom(r => new DateTime?(r.PublishedDate)))
                      .ForMember(c => c.LogicalSizeInGB, o => o.MapFrom(r => (int)r.LogicalSizeInGB));

                cfg.CreateMap<NSM.VirtualMachineOSImageCreateResponse, PVM.VMImageContext>()
                      .ForMember(c => c.ImageName, o => o.MapFrom(r => r.Name))
                      .ForMember(c => c.MediaLink, o => o.MapFrom(r => r.MediaLinkUri))
                      .ForMember(c => c.IconUri, o => o.MapFrom(r => r.SmallIconUri))
                      .ForMember(c => c.OS, o => o.MapFrom(r => r.OperatingSystemType))
                      .ForMember(c => c.PublishedDate, o => o.MapFrom(r => r.PublishedDate))
                      .ForMember(c => c.LogicalSizeInGB, o => o.MapFrom(r => (int)r.LogicalSizeInGB));

                cfg.CreateMap<NSM.VirtualMachineOSImageUpdateResponse, PVM.VMImageContext>()
                      .ForMember(c => c.ImageName, o => o.MapFrom(r => r.Name))
                      .ForMember(c => c.MediaLink, o => o.MapFrom(r => r.MediaLinkUri))
                      .ForMember(c => c.IconUri, o => o.MapFrom(r => r.SmallIconUri))
                      .ForMember(c => c.OS, o => o.MapFrom(r => r.OperatingSystemType))
                      .ForMember(c => c.PublishedDate, o => o.MapFrom(r => r.PublishedDate))
                      .ForMember(c => c.LogicalSizeInGB, o => o.MapFrom(r => (int)r.LogicalSizeInGB));

                cfg.CreateMap<OperationStatusResponse, PVM.VMImageContext>()
                      .ForMember(c => c.OperationId, o => o.MapFrom(r => r.Id))
                      .ForMember(c => c.OperationStatus, o => o.MapFrom(r => r.Status.ToString()));

                cfg.CreateMap<NSM.VirtualMachineDiskCreateResponse, PVM.VMImageContext>()
                      .ForMember(c => c.MediaLink, o => o.MapFrom(r => r.MediaLinkUri))
                      .ForMember(c => c.ImageName, o => o.MapFrom(r => r.Name))
                      .ForMember(c => c.OS, o => o.MapFrom(r => r.OperatingSystem));

                // VM Image Disk Mapping
                cfg.CreateMap<NSM.VirtualMachineVMImageListResponse.OSDiskConfiguration, PVM.OSDiskConfiguration>()
                      .ForMember(c => c.OS, o => o.MapFrom(r => r.OperatingSystem));
                cfg.CreateMap<NSM.VirtualMachineVMImageListResponse.DataDiskConfiguration, PVM.DataDiskConfiguration>()
                      .ForMember(c => c.Lun, o => o.MapFrom(r => r.LogicalUnitNumber));

                cfg.CreateMap<IList<NSM.DataDiskConfigurationCreateParameters>, List<PVM.DataDiskConfiguration>>();
                cfg.CreateMap<List<NSM.DataDiskConfigurationCreateParameters>, List<PVM.DataDiskConfiguration>>();
                cfg.CreateMap<IList<NSM.DataDiskConfigurationCreateParameters>, PVM.DataDiskConfigurationList>();
                cfg.CreateMap<IList<NSM.DataDiskConfigurationUpdateParameters>, List<PVM.DataDiskConfiguration>>();
                cfg.CreateMap<List<NSM.DataDiskConfigurationUpdateParameters>, List<PVM.DataDiskConfiguration>>();
                cfg.CreateMap<IList<NSM.DataDiskConfigurationUpdateParameters>, PVM.DataDiskConfigurationList>();

                cfg.CreateMap<PVM.OSDiskConfiguration, NSM.OSDiskConfigurationCreateParameters>()
                      .ForMember(c => c.HostCaching, o => o.MapFrom(r => r.HostCaching))
                      .ForMember(c => c.MediaLink, o => o.MapFrom(r => r.MediaLink))
                      .ForMember(c => c.OS, o => o.MapFrom(r => r.OS))
                      .ForMember(c => c.OSState, o => o.MapFrom(r => r.OSState));
                cfg.CreateMap<PVM.DataDiskConfiguration, NSM.DataDiskConfigurationCreateParameters>()
                      .ForMember(c => c.LogicalUnitNumber, o => o.MapFrom(r => r.Lun));
                cfg.CreateMap<PVM.OSDiskConfiguration, NSM.OSDiskConfigurationUpdateParameters>();
                cfg.CreateMap<PVM.DataDiskConfiguration, NSM.DataDiskConfigurationUpdateParameters>()
                      .ForMember(c => c.LogicalUnitNumber, o => o.MapFrom(r => r.Lun));

                cfg.CreateMap<IList<PVM.DataDiskConfiguration>, IList<NSM.DataDiskConfigurationCreateParameters>>();
                cfg.CreateMap<List<PVM.DataDiskConfiguration>, List<NSM.DataDiskConfigurationCreateParameters>>();
                cfg.CreateMap<PVM.DataDiskConfigurationList, Collection<PVM.DataDiskConfiguration>>();
                cfg.CreateMap<Collection<PVM.DataDiskConfiguration>, IList<NSM.DataDiskConfigurationCreateParameters>>();
                cfg.CreateMap<Collection<PVM.DataDiskConfiguration>, List<NSM.DataDiskConfigurationCreateParameters>>();
                cfg.CreateMap<PVM.DataDiskConfigurationList, IList<NSM.DataDiskConfigurationCreateParameters>>();
                cfg.CreateMap<PVM.DataDiskConfigurationList, List<NSM.DataDiskConfigurationCreateParameters>>();
                cfg.CreateMap<IList<PVM.DataDiskConfiguration>, IList<NSM.DataDiskConfigurationUpdateParameters>>();
                cfg.CreateMap<List<PVM.DataDiskConfiguration>, List<NSM.DataDiskConfigurationUpdateParameters>>();
                cfg.CreateMap<PVM.DataDiskConfigurationList, Collection<PVM.DataDiskConfiguration>>();
                cfg.CreateMap<Collection<PVM.DataDiskConfiguration>, IList<NSM.DataDiskConfigurationUpdateParameters>>();
                cfg.CreateMap<Collection<PVM.DataDiskConfiguration>, List<NSM.DataDiskConfigurationUpdateParameters>>();
                cfg.CreateMap<PVM.DataDiskConfigurationList, IList<NSM.DataDiskConfigurationUpdateParameters>>();
                cfg.CreateMap<PVM.DataDiskConfigurationList, List<NSM.DataDiskConfigurationUpdateParameters>>();

                cfg.CreateMap<NSM.VirtualMachineVMImageListResponse.VirtualMachineVMImage, PVM.VMImageContext>()
                      .ForMember(c => c.ImageName, o => o.MapFrom(r => r.Name));

                cfg.CreateMap<OperationStatusResponse, PVM.VMImageContext>()
                      .ForMember(c => c.OS, o => o.Ignore())
                      .ForMember(c => c.LogicalSizeInGB, o => o.Ignore())
                      .ForMember(c => c.OperationId, o => o.MapFrom(r => r.Id))
                      .ForMember(c => c.OperationStatus, o => o.MapFrom(r => r.Status.ToString()));

                // VM Resource Extensions
                cfg.CreateMap<NSM.GuestAgentMessage, PVM.GuestAgentMessage>();
                cfg.CreateMap<NSM.GuestAgentFormattedMessage, PVM.GuestAgentFormattedMessage>();
                cfg.CreateMap<NSM.GuestAgentStatus, PVM.GuestAgentStatus>()
                      .ForMember(c => c.TimestampUtc, o => o.MapFrom(r => r.Timestamp));
                cfg.CreateMap<NSM.MaintenanceStatus, PVM.MaintenanceStatus>();

                cfg.CreateMap<NSM.ResourceExtensionConfigurationStatus, PVM.ResourceExtensionConfigurationStatus>()
                      .ForMember(c => c.TimestampUtc, o => o.MapFrom(r => r.Timestamp))
                      .ForMember(c => c.ConfigurationAppliedTimeUtc, o => o.MapFrom(r => r.ConfigurationAppliedTime));

                cfg.CreateMap<NSM.ResourceExtensionSubStatus, PVM.ResourceExtensionSubStatus>();
                cfg.CreateMap<IList<NSM.ResourceExtensionSubStatus>, PVM.ResourceExtensionStatusList>();
                cfg.CreateMap<IEnumerable<NSM.ResourceExtensionSubStatus>, PVM.ResourceExtensionStatusList>();
                cfg.CreateMap<List<NSM.ResourceExtensionSubStatus>, PVM.ResourceExtensionStatusList>();

                cfg.CreateMap<NSM.ResourceExtensionStatus, PVM.ResourceExtensionStatus>();
                cfg.CreateMap<IList<NSM.ResourceExtensionStatus>, PVM.ResourceExtensionStatusList>();
                cfg.CreateMap<IEnumerable<NSM.ResourceExtensionStatus>, PVM.ResourceExtensionStatusList>();
                cfg.CreateMap<List<NSM.ResourceExtensionStatus>, PVM.ResourceExtensionStatusList>();

                //SM to NewSM mapping
                cfg.CreateMap<PVM.LoadBalancerProbe, NSM.LoadBalancerProbe>()
                      .ForMember(c => c.Protocol, o => o.MapFrom(r => r.Protocol));
                cfg.CreateMap<PVM.AccessControlListRule, NSM.AccessControlListRule>();
                cfg.CreateMap<PVM.EndpointAccessControlList, NSM.EndpointAcl>()
                      .ForMember(c => c.Rules, o => o.MapFrom(r => r.Rules.ToList()));
                cfg.CreateMap<PVM.InputEndpoint, NSM.InputEndpoint>()
                      .ForMember(c => c.VirtualIPAddress, o => o.MapFrom(r => r.Vip != null ? IPAddress.Parse(r.Vip) : null))
                      .ForMember(c => c.EndpointAcl, o => o.MapFrom(r => r.EndpointAccessControlList))
                      .ForMember(c => c.LoadBalancerName, o => o.MapFrom(r => r.LoadBalancerName));
                cfg.CreateMap<PVM.DataVirtualHardDisk, NSM.DataVirtualHardDisk>()
                      .ForMember(c => c.Name, o => o.MapFrom(r => r.DiskName))
                      .ForMember(c => c.Label, o => o.MapFrom(r => r.DiskLabel))
                      .ForMember(c => c.LogicalUnitNumber, o => o.MapFrom(r => r.Lun));
                cfg.CreateMap<PVM.OSVirtualHardDisk, NSM.OSVirtualHardDisk>()
                      .ForMember(c => c.Name, o => o.MapFrom(r => r.DiskName))
                      .ForMember(c => c.Label, o => o.MapFrom(r => r.DiskLabel))
                      .ForMember(c => c.OperatingSystem, o => o.MapFrom(r => r.OS));
                cfg.CreateMap<PVM.NetworkConfigurationSet, NSM.ConfigurationSet>()
                      .ForMember(c => c.InputEndpoints, o => o.MapFrom(r => r.InputEndpoints != null ? r.InputEndpoints.ToList() : null))
                      .ForMember(c => c.SubnetNames, o => o.MapFrom(r => r.SubnetNames != null ? r.SubnetNames.ToList() : null))
                      .ForMember(c => c.PublicIPs, o => o.MapFrom(r => r.PublicIPs != null ? r.PublicIPs.ToList() : null));
                cfg.CreateMap<PVM.DebugSettings, NSM.DebugSettings>();

                cfg.CreateMap<PVM.LinuxProvisioningConfigurationSet.SSHKeyPair, NSM.SshSettingKeyPair>();
                cfg.CreateMap<PVM.LinuxProvisioningConfigurationSet.SSHPublicKey, NSM.SshSettingPublicKey>();
                cfg.CreateMap<PVM.LinuxProvisioningConfigurationSet.SSHSettings, NSM.SshSettings>();
                cfg.CreateMap<PVM.LinuxProvisioningConfigurationSet, NSM.ConfigurationSet>()
                      .ForMember(c => c.PublicIPs, o => o.Ignore())
                      .ForMember(c => c.UserPassword, o => o.MapFrom(r => r.UserPassword == null ? null : r.UserPassword.ConvertToUnsecureString()))
                      .ForMember(c => c.SshSettings, o => o.MapFrom(r => r.SSH));
                cfg.CreateMap<PVM.WindowsProvisioningConfigurationSet, NSM.ConfigurationSet>()
                      .ForMember(c => c.PublicIPs, o => o.Ignore())
                      .ForMember(c => c.StoredCertificateSettings, o => o.Ignore())
                      .ForMember(c => c.AdminPassword, o => o.MapFrom(r => r.AdminPassword == null ? null : r.AdminPassword.ConvertToUnsecureString()));
                cfg.CreateMap<PVM.ProvisioningConfigurationSet, NSM.ConfigurationSet>()
                      .ForMember(c => c.PublicIPs, o => o.Ignore());
                cfg.CreateMap<PVM.ConfigurationSet, NSM.ConfigurationSet>()
                      .ForMember(c => c.PublicIPs, o => o.Ignore());
                cfg.CreateMap<PVM.InstanceEndpoint, NSM.InstanceEndpoint>()
                      .ForMember(c => c.VirtualIPAddress, o => o.MapFrom(r => r.Vip != null ? IPAddress.Parse(r.Vip) : null))
                      .ForMember(c => c.Port, o => o.MapFrom(r => r.PublicPort));

                cfg.CreateMap<PVM.WindowsProvisioningConfigurationSet.WinRmConfiguration, NSM.WindowsRemoteManagementSettings>();
                cfg.CreateMap<PVM.WindowsProvisioningConfigurationSet.WinRmListenerProperties, NSM.WindowsRemoteManagementListener>()
                      .ForMember(c => c.ListenerType, o => o.MapFrom(r => r.Protocol));
                cfg.CreateMap<PVM.WindowsProvisioningConfigurationSet.WinRmListenerCollection, IList<NSM.WindowsRemoteManagementListener>>();

                //NewSM to SM mapping
                cfg.CreateMap<NSM.LoadBalancerProbe, PVM.LoadBalancerProbe>()
                      .ForMember(c => c.Protocol, o => o.MapFrom(r => r.Protocol.ToString().ToLower()));
                cfg.CreateMap<NSM.AccessControlListRule, PVM.AccessControlListRule>();
                cfg.CreateMap<NSM.EndpointAcl, PVM.EndpointAccessControlList>()
                      .ForMember(c => c.Rules, o => o.MapFrom(r => r.Rules));
                cfg.CreateMap<NSM.InputEndpoint, PVM.InputEndpoint>()
                      .ForMember(c => c.LoadBalancerName, o => o.MapFrom(r => r.LoadBalancerName))
                      .ForMember(c => c.Vip, o => o.MapFrom(r => r.VirtualIPAddress != null ? r.VirtualIPAddress.ToString() : null))
                      .ForMember(c => c.EndpointAccessControlList, o => o.MapFrom(r => r.EndpointAcl));
                cfg.CreateMap<NSM.DataVirtualHardDisk, PVM.DataVirtualHardDisk>()
                      .ForMember(c => c.DiskName, o => o.MapFrom(r => r.Name))
                      .ForMember(c => c.DiskLabel, o => o.MapFrom(r => r.Label))
                      .ForMember(c => c.Lun, o => o.MapFrom(r => r.LogicalUnitNumber));
                cfg.CreateMap<NSM.OSVirtualHardDisk, PVM.OSVirtualHardDisk>()
                      .ForMember(c => c.DiskName, o => o.MapFrom(r => r.Name))
                      .ForMember(c => c.DiskLabel, o => o.MapFrom(r => r.Label))
                      .ForMember(c => c.OS, o => o.MapFrom(r => r.OperatingSystem));
                cfg.CreateMap<NSM.ConfigurationSet, PVM.ConfigurationSet>();
                cfg.CreateMap<NSM.ConfigurationSet, PVM.NetworkConfigurationSet>();
                cfg.CreateMap<NSM.DebugSettings, PVM.DebugSettings>();

                cfg.CreateMap<NSM.SshSettingKeyPair, PVM.LinuxProvisioningConfigurationSet.SSHKeyPair>();
                cfg.CreateMap<NSM.SshSettingPublicKey, PVM.LinuxProvisioningConfigurationSet.SSHPublicKey>();
                cfg.CreateMap<NSM.SshSettings, PVM.LinuxProvisioningConfigurationSet.SSHSettings>();
                cfg.CreateMap<NSM.ConfigurationSet, PVM.LinuxProvisioningConfigurationSet>()
                      .ForMember(c => c.UserPassword, o => o.MapFrom(r => SecureStringHelper.GetSecureString(r.UserPassword)))
                      .ForMember(c => c.SSH, o => o.MapFrom(r => r.SshSettings));
                cfg.CreateMap<NSM.ConfigurationSet, PVM.WindowsProvisioningConfigurationSet>()
                      .ForMember(c => c.AdminPassword, o => o.MapFrom(r => SecureStringHelper.GetSecureString(r.AdminPassword)));
                cfg.CreateMap<NSM.InstanceEndpoint, PVM.InstanceEndpoint>()
                      .ForMember(c => c.Vip, o => o.MapFrom(r => r.VirtualIPAddress != null ? r.VirtualIPAddress.ToString() : null))
                      .ForMember(c => c.PublicPort, o => o.MapFrom(r => r.Port));

                cfg.CreateMap<NSM.WindowsRemoteManagementSettings, PVM.WindowsProvisioningConfigurationSet.WinRmConfiguration>();
                cfg.CreateMap<NSM.WindowsRemoteManagementListener, PVM.WindowsProvisioningConfigurationSet.WinRmListenerProperties>()
                      .ForMember(c => c.Protocol, o => o.MapFrom(r => r.ListenerType.ToString()));
                cfg.CreateMap<IList<NSM.WindowsRemoteManagementListener>, PVM.WindowsProvisioningConfigurationSet.WinRmListenerCollection>();

                // LoadBalancedEndpointList mapping
                cfg.CreateMap<PVM.AccessControlListRule, NSM.AccessControlListRule>();
                cfg.CreateMap<PVM.EndpointAccessControlList, NSM.EndpointAcl>();
                cfg.CreateMap<PVM.InputEndpoint, NSM.VirtualMachineUpdateLoadBalancedSetParameters.InputEndpoint>()
                      .ForMember(c => c.Rules, o => o.MapFrom(r => r.EndpointAccessControlList == null ? null : r.EndpointAccessControlList.Rules))
                      .ForMember(c => c.VirtualIPAddress, o => o.MapFrom(r => r.Vip));

                cfg.CreateMap<NSM.AccessControlListRule, PVM.AccessControlListRule>();
                cfg.CreateMap<NSM.EndpointAcl, PVM.EndpointAccessControlList>();
                cfg.CreateMap<NSM.VirtualMachineUpdateLoadBalancedSetParameters.InputEndpoint, PVM.InputEndpoint>()
                      .ForMember(c => c.EndpointAccessControlList, o => o.MapFrom(r => r.Rules == null ? null : r.Rules))
                      .ForMember(c => c.Vip, o => o.MapFrom(r => r.VirtualIPAddress));

                //Common mapping
                cfg.CreateMap<AzureOperationResponse, ManagementOperationContext>()
                      .ForMember(c => c.OperationId, o => o.MapFrom(r => r.RequestId))
                      .ForMember(c => c.OperationStatus, o => o.MapFrom(r => r.StatusCode.ToString()));

                cfg.CreateMap<OperationStatusResponse, ManagementOperationContext>()
                      .ForMember(c => c.OperationId, o => o.MapFrom(r => r.Id))
                      .ForMember(c => c.OperationStatus, o => o.MapFrom(r => r.Status.ToString()));

                //AffinityGroup mapping
                cfg.CreateMap<AffinityGroupGetResponse, PVM.AffinityGroupContext>()
                      .ForMember(c => c.VirtualMachineRoleSizes, o => o.MapFrom(r => r.ComputeCapabilities == null ? null : r.ComputeCapabilities.VirtualMachinesRoleSizes))
                      .ForMember(c => c.WebWorkerRoleSizes, o => o.MapFrom(r => r.ComputeCapabilities == null ? null : r.ComputeCapabilities.WebWorkerRoleSizes));
                cfg.CreateMap<AffinityGroupListResponse.AffinityGroup, PVM.AffinityGroupContext>()
                      .ForMember(c => c.VirtualMachineRoleSizes, o => o.MapFrom(r => r.ComputeCapabilities == null ? null : r.ComputeCapabilities.VirtualMachinesRoleSizes))
                      .ForMember(c => c.WebWorkerRoleSizes, o => o.MapFrom(r => r.ComputeCapabilities == null ? null : r.ComputeCapabilities.WebWorkerRoleSizes));
                cfg.CreateMap<AffinityGroupGetResponse.HostedServiceReference, PVM.AffinityGroupContext.Service>()
                      .ForMember(c => c.Url, o => o.MapFrom(r => r.Uri));
                cfg.CreateMap<AffinityGroupGetResponse.StorageServiceReference, PVM.AffinityGroupContext.Service>()
                      .ForMember(c => c.Url, o => o.MapFrom(r => r.Uri));
                cfg.CreateMap<OperationStatusResponse, PVM.AffinityGroupContext>()
                      .ForMember(c => c.OperationId, o => o.MapFrom(r => r.Id))
                      .ForMember(c => c.OperationStatus, o => o.MapFrom(r => r.Status.ToString()));

                //Location mapping
                cfg.CreateMap<LocationsListResponse.Location, PVM.LocationsContext>()
                      .ForMember(c => c.VirtualMachineRoleSizes, o => o.MapFrom(r => r.ComputeCapabilities == null ? null : r.ComputeCapabilities.VirtualMachinesRoleSizes))
                      .ForMember(c => c.WebWorkerRoleSizes, o => o.MapFrom(r => r.ComputeCapabilities == null ? null : r.ComputeCapabilities.WebWorkerRoleSizes))
                      .ForMember(c => c.StorageAccountTypes, o => o.MapFrom(r => r.StorageCapabilities == null ? null : r.StorageCapabilities.StorageAccountTypes));
                cfg.CreateMap<OperationStatusResponse, PVM.LocationsContext>()
                      .ForMember(c => c.OperationId, o => o.MapFrom(r => r.Id))
                      .ForMember(c => c.OperationStatus, o => o.MapFrom(r => r.Status.ToString()));

                //Role sizes mapping
                cfg.CreateMap<RoleSizeListResponse.RoleSize, PVM.RoleSizeContext>()
                      .ForMember(c => c.InstanceSize, o => o.MapFrom(r => r.Name))
                      .ForMember(c => c.RoleSizeLabel, o => o.MapFrom(r => r.Label));
                cfg.CreateMap<OperationStatusResponse, PVM.RoleSizeContext>()
                      .ForMember(c => c.OperationId, o => o.MapFrom(r => r.Id))
                      .ForMember(c => c.OperationStatus, o => o.MapFrom(r => r.Status.ToString()));

                //ServiceCertificate mapping
                cfg.CreateMap<NSM.ServiceCertificateGetResponse, PVM.CertificateContext>()
                      .ForMember(c => c.Data, o => o.MapFrom(r => r.Data != null ? Convert.ToBase64String(r.Data) : null));
                cfg.CreateMap<NSM.ServiceCertificateListResponse.Certificate, PVM.CertificateContext>()
                      .ForMember(c => c.Url, o => o.MapFrom(r => r.CertificateUri))
                      .ForMember(c => c.Data, o => o.MapFrom(r => r.Data != null ? Convert.ToBase64String(r.Data) : null));
                cfg.CreateMap<OperationStatusResponse, PVM.CertificateContext>()
                      .ForMember(c => c.OperationId, o => o.MapFrom(r => r.Id))
                      .ForMember(c => c.OperationStatus, o => o.MapFrom(r => r.Status.ToString()));
                cfg.CreateMap<OperationStatusResponse, ManagementOperationContext>()
                      .ForMember(c => c.OperationId, o => o.MapFrom(r => r.Id))
                      .ForMember(c => c.OperationStatus, o => o.MapFrom(r => r.Status.ToString()));

                //OperatingSystems mapping
                cfg.CreateMap<NSM.OperatingSystemListResponse.OperatingSystem, PVM.OSVersionsContext>();
                cfg.CreateMap<OperationStatusResponse, PVM.OSVersionsContext>()
                      .ForMember(c => c.OperationId, o => o.MapFrom(r => r.Id))
                      .ForMember(c => c.OperationStatus, o => o.MapFrom(r => r.Status.ToString()));

                //Service mapping
                cfg.CreateMap<NSM.HostedServiceProperties, PVM.HostedServiceDetailedContext>()
                      .ForMember(c => c.Description, o => o.MapFrom(r => string.IsNullOrEmpty(r.Description) ? null : r.Description))
                      .ForMember(c => c.DateModified, o => o.MapFrom(r => r.DateLastModified));
                cfg.CreateMap<NSM.HostedServiceGetResponse, PVM.HostedServiceDetailedContext>()
                      .ForMember(c => c.ExtendedProperties, o => o.MapFrom(r => r.Properties == null ? null : r.Properties.ExtendedProperties))
                      .ForMember(c => c.VirtualMachineRoleSizes, o => o.MapFrom(r => r.ComputeCapabilities == null ? null : r.ComputeCapabilities.VirtualMachinesRoleSizes))
                      .ForMember(c => c.WebWorkerRoleSizes, o => o.MapFrom(r => r.ComputeCapabilities == null ? null : r.ComputeCapabilities.WebWorkerRoleSizes))
                      .ForMember(c => c.Url, o => o.MapFrom(r => r.Uri));
                cfg.CreateMap<NSM.HostedServiceListResponse.HostedService, PVM.HostedServiceDetailedContext>()
                      .ForMember(c => c.ExtendedProperties, o => o.MapFrom(r => r.Properties == null ? null : r.Properties.ExtendedProperties))
                      .ForMember(c => c.VirtualMachineRoleSizes, o => o.MapFrom(r => r.ComputeCapabilities == null ? null : r.ComputeCapabilities.VirtualMachinesRoleSizes))
                      .ForMember(c => c.WebWorkerRoleSizes, o => o.MapFrom(r => r.ComputeCapabilities == null ? null : r.ComputeCapabilities.WebWorkerRoleSizes))
                      .ForMember(c => c.Url, o => o.MapFrom(r => r.Uri));
                cfg.CreateMap<OperationStatusResponse, PVM.HostedServiceDetailedContext>()
                      .ForMember(c => c.OperationId, o => o.MapFrom(r => r.Id))
                      .ForMember(c => c.OperationStatus, o => o.MapFrom(r => r.Status.ToString()));

                //Disk mapping
                cfg.CreateMap<NSM.VirtualMachineDiskListResponse.VirtualMachineDisk, PVM.DiskContext>()
                      .ForMember(c => c.MediaLink, o => o.MapFrom(r => r.MediaLinkUri))
                      .ForMember(c => c.DiskSizeInGB, o => o.MapFrom(r => r.LogicalSizeInGB))
                      .ForMember(c => c.OS, o => o.MapFrom(r => r.OperatingSystemType))
                      .ForMember(c => c.DiskName, o => o.MapFrom(r => r.Name))
                      .ForMember(c => c.AttachedTo, o => o.MapFrom(r => r.UsageDetails));
                cfg.CreateMap<NSM.VirtualMachineDiskListResponse.VirtualMachineDiskUsageDetails, PVM.DiskContext.RoleReference>();

                cfg.CreateMap<NSM.VirtualMachineDiskGetResponse, PVM.DiskContext>()
                      .ForMember(c => c.AttachedTo, o => o.MapFrom(r => r.UsageDetails))
                      .ForMember(c => c.DiskName, o => o.MapFrom(r => r.Name))
                      .ForMember(c => c.DiskSizeInGB, o => o.MapFrom(r => r.LogicalSizeInGB))
                      .ForMember(c => c.IsCorrupted, o => o.MapFrom(r => r.IsCorrupted))
                      .ForMember(c => c.MediaLink, o => o.MapFrom(r => r.MediaLinkUri))
                      .ForMember(c => c.OS, o => o.MapFrom(r => r.OperatingSystemType));
                cfg.CreateMap<NSM.VirtualMachineDiskGetResponse.VirtualMachineDiskUsageDetails, PVM.DiskContext.RoleReference>();

                cfg.CreateMap<NSM.VirtualMachineDiskCreateResponse, PVM.DiskContext>()
                      .ForMember(c => c.DiskName, o => o.MapFrom(r => r.Name))
                      .ForMember(c => c.OS, o => o.MapFrom(r => r.OperatingSystem))
                      .ForMember(c => c.MediaLink, o => o.MapFrom(r => r.MediaLinkUri))
                      .ForMember(c => c.DiskSizeInGB, o => o.MapFrom(r => r.LogicalSizeInGB))
                      .ForMember(c => c.AttachedTo, o => o.MapFrom(r => r.UsageDetails));
                cfg.CreateMap<NSM.VirtualMachineDiskCreateResponse.VirtualMachineDiskUsageDetails, PVM.DiskContext.RoleReference>();

                cfg.CreateMap<NSM.VirtualMachineDiskUpdateResponse, PVM.DiskContext>()
                      .ForMember(c => c.DiskName, o => o.MapFrom(r => r.Name))
                      .ForMember(c => c.MediaLink, o => o.MapFrom(r => r.MediaLinkUri))
                      .ForMember(c => c.DiskSizeInGB, o => o.MapFrom(r => r.LogicalSizeInGB));

                cfg.CreateMap<OperationStatusResponse, PVM.DiskContext>()
                      .ForMember(c => c.OperationId, o => o.MapFrom(r => r.Id))
                      .ForMember(c => c.OperationStatus, o => o.MapFrom(r => r.Status.ToString()));

                //Storage mapping
                cfg.CreateMap<StorageAccountGetResponse, PVM.StorageServicePropertiesOperationContext>()
                      .ForMember(c => c.StorageAccountDescription, o => o.MapFrom(r => r.StorageAccount.Properties == null ? null : r.StorageAccount.Properties.Description))
                      .ForMember(c => c.StorageAccountName, o => o.MapFrom(r => r.StorageAccount.Name))
                      .ForMember(c => c.MigrationState, o => o.MapFrom(r => r.StorageAccount.MigrationState));
                cfg.CreateMap<StorageAccountProperties, PVM.StorageServicePropertiesOperationContext>()
                      .ForMember(c => c.StorageAccountDescription, o => o.MapFrom(r => r.Description))
                      .ForMember(c => c.GeoPrimaryLocation, o => o.MapFrom(r => r.GeoPrimaryRegion))
                      .ForMember(c => c.GeoSecondaryLocation, o => o.MapFrom(r => r.GeoSecondaryRegion))
                      .ForMember(c => c.StorageAccountStatus, o => o.MapFrom(r => r.Status))
                      .ForMember(c => c.StatusOfPrimary, o => o.MapFrom(r => r.StatusOfGeoPrimaryRegion))
                      .ForMember(c => c.StatusOfSecondary, o => o.MapFrom(r => r.StatusOfGeoSecondaryRegion));
                cfg.CreateMap<StorageAccount, PVM.StorageServicePropertiesOperationContext>()
                      .ForMember(c => c.StorageAccountDescription, o => o.MapFrom(r => r.Properties == null ? null : r.Properties.Description))
                      .ForMember(c => c.StorageAccountName, o => o.MapFrom(r => r.Name));
                cfg.CreateMap<OperationStatusResponse, PVM.StorageServicePropertiesOperationContext>()
                      .ForMember(c => c.OperationId, o => o.MapFrom(r => r.Id))
                      .ForMember(c => c.OperationStatus, o => o.MapFrom(r => r.Status.ToString()));

                cfg.CreateMap<StorageAccountGetKeysResponse, PVM.StorageServiceKeyOperationContext>()
                      .ForMember(c => c.Primary, o => o.MapFrom(r => r.PrimaryKey))
                      .ForMember(c => c.Secondary, o => o.MapFrom(r => r.SecondaryKey));
                cfg.CreateMap<OperationStatusResponse, PVM.StorageServiceKeyOperationContext>()
                      .ForMember(c => c.OperationId, o => o.MapFrom(r => r.Id))
                      .ForMember(c => c.OperationStatus, o => o.MapFrom(r => r.Status.ToString()));

                cfg.CreateMap<OperationStatusResponse, ManagementOperationContext>()
                      .ForMember(c => c.OperationId, o => o.MapFrom(r => r.Id))
                      .ForMember(c => c.OperationStatus, o => o.MapFrom(r => r.Status.ToString()));

                // DomainJoinSettings mapping for IaaS
                cfg.CreateMap<NSM.DomainJoinCredentials, PVM.WindowsProvisioningConfigurationSet.DomainJoinCredentials>()
                      .ForMember(c => c.Domain, o => o.MapFrom(r => r.Domain))
                      .ForMember(c => c.Username, o => o.MapFrom(r => r.UserName))
                      .ForMember(c => c.Password, o => o.MapFrom(r => SecureStringHelper.GetSecureString(r.Password)));
                cfg.CreateMap<NSM.DomainJoinProvisioning, PVM.WindowsProvisioningConfigurationSet.DomainJoinProvisioning>()
                      .ForMember(c => c.AccountData, o => o.MapFrom(r => r.AccountData));
                cfg.CreateMap<NSM.DomainJoinSettings, PVM.WindowsProvisioningConfigurationSet.DomainJoinSettings>()
                      .ForMember(c => c.Credentials, o => o.MapFrom(r => r.Credentials))
                      .ForMember(c => c.JoinDomain, o => o.MapFrom(r => r.DomainToJoin))
                      .ForMember(c => c.MachineObjectOU, o => o.MapFrom(r => r.LdapMachineObjectOU))
                      .ForMember(c => c.Provisioning, o => o.MapFrom(r => r.Provisioning));

                cfg.CreateMap<PVM.WindowsProvisioningConfigurationSet.DomainJoinCredentials, NSM.DomainJoinCredentials>()
                      .ForMember(c => c.Domain, o => o.MapFrom(r => r.Domain))
                      .ForMember(c => c.UserName, o => o.MapFrom(r => r.Username))
                      .ForMember(c => c.Password, o => o.MapFrom(r => r.Password.ConvertToUnsecureString()));
                cfg.CreateMap<PVM.WindowsProvisioningConfigurationSet.DomainJoinProvisioning, NSM.DomainJoinProvisioning>()
                      .ForMember(c => c.AccountData, o => o.MapFrom(r => r.AccountData));
                cfg.CreateMap<PVM.WindowsProvisioningConfigurationSet.DomainJoinSettings, NSM.DomainJoinSettings>()
                      .ForMember(c => c.Credentials, o => o.MapFrom(r => r.Credentials))
                      .ForMember(c => c.DomainToJoin, o => o.MapFrom(r => r.JoinDomain))
                      .ForMember(c => c.LdapMachineObjectOU, o => o.MapFrom(r => r.MachineObjectOU))
                      .ForMember(c => c.Provisioning, o => o.MapFrom(r => r.Provisioning));

                // Networks mapping
                cfg.CreateMap<NVM.NetworkListResponse.AddressSpace, PVM.AddressSpace>();
                cfg.CreateMap<NVM.NetworkListResponse.Connection, PVM.Connection>();
                cfg.CreateMap<NVM.NetworkListResponse.LocalNetworkSite, PVM.LocalNetworkSite>();
                cfg.CreateMap<NVM.NetworkListResponse.DnsServer, PVM.DnsServer>();
                cfg.CreateMap<NVM.NetworkListResponse.Subnet, PVM.Subnet>();
                cfg.CreateMap<IList<NVM.NetworkListResponse.DnsServer>, PVM.DnsSettings>()
                      .ForMember(c => c.DnsServers, o => o.MapFrom(r => r));
                cfg.CreateMap<IList<NVM.NetworkListResponse.Gateway>, PVM.Gateway>();
                cfg.CreateMap<NVM.NetworkListResponse.VirtualNetworkSite, PVM.VirtualNetworkSite>();
                cfg.CreateMap<NVM.NetworkListResponse.VirtualNetworkSite, PVM.VirtualNetworkSiteContext>()
                      .ForMember(c => c.AddressSpacePrefixes, o => o.MapFrom(r => r.AddressSpace == null ? null : r.AddressSpace.AddressPrefixes == null ? null :
                                                                                  r.AddressSpace.AddressPrefixes.Select(p => p)))
                      .ForMember(c => c.DnsServers, o => o.MapFrom(r => r.DnsServers.AsEnumerable()))
                      .ForMember(c => c.GatewayProfile, o => o.MapFrom(r => r.Gateway.Profile))
                      .ForMember(c => c.GatewaySites, o => o.MapFrom(r => r.Gateway.Sites));
                cfg.CreateMap<OperationStatusResponse, PVM.VirtualNetworkSiteContext>()
                      .ForMember(c => c.OperationId, o => o.MapFrom(r => r.Id))
                      .ForMember(c => c.OperationStatus, o => o.MapFrom(r => r.Status.ToString()))
                      .ForMember(c => c.Id, o => o.Ignore());

                // Check Static IP Availability Response Mapping
                cfg.CreateMap<NVM.NetworkStaticIPAvailabilityResponse, PVM.VirtualNetworkStaticIPAvailabilityContext>();
                cfg.CreateMap<OperationStatusResponse, PVM.VirtualNetworkStaticIPAvailabilityContext>()
                      .ForMember(c => c.OperationId, o => o.MapFrom(r => r.Id))
                      .ForMember(c => c.OperationStatus, o => o.MapFrom(r => r.Status.ToString()));

                // New SM to Model
                cfg.CreateMap<NSM.StoredCertificateSettings, PVM.CertificateSetting>();

                // Model to New SM
                cfg.CreateMap<PVM.CertificateSetting, NSM.StoredCertificateSettings>();

                // Resource Extensions
                cfg.CreateMap<NSM.ResourceExtensionParameterValue, PVM.ResourceExtensionParameterValue>()
                      .ForMember(c => c.SecureValue, o => o.MapFrom(r => SecureStringHelper.GetSecureString(r)))
                      .ForMember(c => c.Value, o => o.MapFrom(r => SecureStringHelper.GetPlainString(r)));
                cfg.CreateMap<NSM.ResourceExtensionReference, PVM.ResourceExtensionReference>();

                cfg.CreateMap<PVM.ResourceExtensionParameterValue, NSM.ResourceExtensionParameterValue>()
                      .ForMember(c => c.Value, o => o.MapFrom(r => SecureStringHelper.GetPlainString(r)));
                cfg.CreateMap<PVM.ResourceExtensionReference, NSM.ResourceExtensionReference>();

                // Reserved IP
                cfg.CreateMap<OperationStatusResponse, PVM.ReservedIPContext>()
                      .ForMember(c => c.OperationId, o => o.MapFrom(r => r.Id))
                      .ForMember(c => c.OperationStatus, o => o.MapFrom(r => r.Status.ToString()))
                      .ForMember(c => c.Id, o => o.Ignore());
                cfg.CreateMap<NVM.NetworkReservedIPGetResponse, PVM.ReservedIPContext>()
                      .ForMember(c => c.ReservedIPName, o => o.MapFrom(r => r.Name));
                cfg.CreateMap<NVM.NetworkReservedIPListResponse.ReservedIP, PVM.ReservedIPContext>()
                      .ForMember(c => c.ReservedIPName, o => o.MapFrom(r => r.Name));

                // Public IP
                cfg.CreateMap<PVM.PublicIP, NSM.RoleInstance.PublicIP>();
                cfg.CreateMap<PVM.AssignPublicIP, NSM.ConfigurationSet.PublicIP>();

                cfg.CreateMap<NSM.RoleInstance.PublicIP, PVM.PublicIP>();
                cfg.CreateMap<NSM.ConfigurationSet.PublicIP, PVM.AssignPublicIP>();

                // NetworkInterface
                cfg.CreateMap<PVM.AssignNetworkInterface, NSM.NetworkInterface>();
                cfg.CreateMap<PVM.AssignIPConfiguration, NSM.IPConfiguration>();
                cfg.CreateMap<PVM.NetworkInterface, NSM.NetworkInterfaceInstance>();
                cfg.CreateMap<PVM.IPConfiguration, NSM.IPConfigurationInstance>();

                cfg.CreateMap<NSM.NetworkInterface, PVM.AssignNetworkInterface>();
                cfg.CreateMap<NSM.IPConfiguration, PVM.AssignIPConfiguration>();
                cfg.CreateMap<NSM.NetworkInterfaceInstance, PVM.NetworkInterface>();
                cfg.CreateMap<NSM.IPConfigurationInstance, PVM.IPConfiguration>();
            });

            _mapper = config.CreateMapper();
        }
    }
}