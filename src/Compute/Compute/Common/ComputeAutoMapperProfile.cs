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
using Microsoft.Rest.Azure;
using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using FROM = Microsoft.Azure.Management.Compute.Models;
using TO = Microsoft.Azure.Commands.Compute.Models;
using FROMTrack2 = Azure.ResourceManager.Compute.Models;
using Azure.ResourceManager.Models;
using Azure.ResourceManager.Compute;
using Azure.ResourceManager.Resources.Models;
using Track2Models = Microsoft.Azure.Commands.Compute.Models.Track2;
using AutomationModels = Microsoft.Azure.Commands.Compute.Automation.Models;

namespace Microsoft.Azure.Commands.Compute
{
    public static class ComputeMapperExtension
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
                        s.Add(ComputeAutoMapperProfile.Mapper.Map<T>(t));
                    }
                }
            });

            return mapper;
        }
    }

    public class ComputeAutoMapperProfile : AutoMapper.Profile
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
            get { return "ComputeAutoMapperProfile"; }
        }

        private static void Initialize()
        {
            var config = new MapperConfiguration(cfg => {
                cfg.AddProfile<ComputeAutoMapperProfile>();

                // Track2 PSModels => Track1 PSModels
                // PSVirtualMachineTrack2 => PSVirtualMachine
                cfg.CreateMap<Track2Models.PSVirtualMachine, TO.PSVirtualMachine>()
                    // Direct property mappings
                    .ForMember(d => d.ResourceGroupName, opt => opt.MapFrom(s => s.ResourceGroupName))
                    .ForMember(d => d.Id, opt => opt.MapFrom(s => s.Id))
                    .ForMember(d => d.VmId, opt => opt.MapFrom(s => s.VmId))
                    .ForMember(d => d.Name, opt => opt.MapFrom(s => s.Name))
                    .ForMember(d => d.Type, opt => opt.MapFrom(s => s.ResourceType))
                    .ForMember(d => d.Location, opt => opt.MapFrom(s => s.Location))
                    .ForMember(d => d.Tags, opt => opt.MapFrom(s => s.Tags))
                    .ForMember(d => d.Zones, opt => opt.MapFrom(s => s.Zones))
                    // Convert flattened string IDs to SubResource objects
                    .ForMember(d => d.AvailabilitySetReference, opt => opt.MapFrom(s => 
                        !string.IsNullOrEmpty(s.AvailabilitySetId) ? new FROM.SubResource(s.AvailabilitySetId) : null))
                    .ForMember(d => d.VirtualMachineScaleSet, opt => opt.MapFrom(s => 
                        !string.IsNullOrEmpty(s.VirtualMachineScaleSetId) ? new FROM.SubResource(s.VirtualMachineScaleSetId) : null))
                    .ForMember(d => d.ProximityPlacementGroup, opt => opt.MapFrom(s => 
                        !string.IsNullOrEmpty(s.ProximityPlacementGroupId) ? new FROM.SubResource(s.ProximityPlacementGroupId) : null))
                    .ForMember(d => d.Host, opt => opt.MapFrom(s => 
                        !string.IsNullOrEmpty(s.HostId) ? new FROM.SubResource(s.HostId) : null))
                    .ForMember(d => d.HostGroup, opt => opt.MapFrom(s => 
                        !string.IsNullOrEmpty(s.HostGroupId) ? new FROM.SubResource(s.HostGroupId) : null))
                    // Convert BootDiagnostics to DiagnosticsProfile wrapper
                    .ForMember(d => d.DiagnosticsProfile, opt => opt.MapFrom(s => 
                        s.BootDiagnostics != null ? new FROM.DiagnosticsProfile 
                        { 
                            BootDiagnostics = new FROM.BootDiagnostics 
                            { 
                                Enabled = s.BootDiagnostics.Enabled,
                                StorageUri = s.BootDiagnostics.StorageUri
                            } 
                        } : null))
                    // Convert BillingMaxPrice to BillingProfile wrapper
                    .ForMember(d => d.BillingProfile, opt => opt.MapFrom(s => 
                        s.BillingMaxPrice.HasValue ? new FROM.BillingProfile { MaxPrice = s.BillingMaxPrice.Value } : null))
                    // Convert GalleryApplications list to ApplicationProfile wrapper
                    .ForMember(d => d.ApplicationProfile, opt => opt.MapFrom(s => 
                        s.GalleryApplications != null && s.GalleryApplications.Count > 0 
                            ? new AutomationModels.PSApplicationProfile 
                            { 
                                GalleryApplications = s.GalleryApplications.Select(ga => new AutomationModels.PSVMGalleryApplication
                                {
                                    PackageReferenceId = ga.PackageReferenceId,
                                    ConfigurationReference = ga.ConfigurationReference,
                                    Tags = ga.Tags,
                                    Order = ga.Order,
                                    TreatFailureAsDeploymentFailure = ga.TreatFailureAsDeploymentFailure,
                                    EnableAutomaticUpgrade = ga.EnableAutomaticUpgrade
                                }).ToList()
                            } 
                            : null))
                    // Convert CapacityReservationGroupId to CapacityReservationProfile
                    .ForMember(d => d.CapacityReservation, opt => opt.MapFrom(s => 
                        !string.IsNullOrEmpty(s.CapacityReservationGroupId) 
                            ? new FROM.CapacityReservationProfile 
                            { 
                                CapacityReservationGroup = new FROM.SubResource(s.CapacityReservationGroupId) 
                            } 
                            : null))
                    // Map profiles - AutoMapper will handle nested conversions if we set them up
                    .ForMember(d => d.HardwareProfile, opt => opt.MapFrom(s => s.HardwareProfile))
                    .ForMember(d => d.StorageProfile, opt => opt.MapFrom(s => s.StorageProfile))
                    .ForMember(d => d.NetworkProfile, opt => opt.MapFrom(s => s.NetworkProfile))
                    .ForMember(d => d.OSProfile, opt => opt.MapFrom(s => s.OSProfile))
                    .ForMember(d => d.SecurityProfile, opt => opt.MapFrom(s => s.SecurityProfile))
                    .ForMember(d => d.AdditionalCapabilities, opt => opt.MapFrom(s => s.AdditionalCapabilities))
                    // Map extensions (Resources -> Extensions)
                    .ForMember(d => d.Extensions, opt => opt.MapFrom(s => s.Resources))
                    // Map instance view and extract top-level properties
                    .ForMember(d => d.InstanceView, opt => opt.MapFrom(s => s.InstanceView))
                    .ForMember(d => d.OsName, opt => opt.MapFrom(s => s.InstanceView != null ? s.InstanceView.OsName : null))
                    .ForMember(d => d.OsVersion, opt => opt.MapFrom(s => s.InstanceView != null ? s.InstanceView.OsVersion : null))
                    .ForMember(d => d.HyperVGeneration, opt => opt.MapFrom(s => s.InstanceView != null ? s.InstanceView.HyperVGeneration : null))
                    // Map other properties
                    .ForMember(d => d.Plan, opt => opt.MapFrom(s => s.Plan))
                    .ForMember(d => d.Identity, opt => opt.MapFrom(s => s.Identity))
                    .ForMember(d => d.ExtendedLocation, opt => opt.MapFrom(s => s.ExtendedLocation))
                    .ForMember(d => d.LicenseType, opt => opt.MapFrom(s => s.LicenseType))
                    .ForMember(d => d.ProvisioningState, opt => opt.MapFrom(s => s.ProvisioningState))
                    .ForMember(d => d.Priority, opt => opt.MapFrom(s => s.Priority))
                    .ForMember(d => d.EvictionPolicy, opt => opt.MapFrom(s => s.EvictionPolicy))
                    .ForMember(d => d.UserData, opt => opt.MapFrom(s => s.UserData))
                    .ForMember(d => d.PlatformFaultDomain, opt => opt.MapFrom(s => s.PlatformFaultDomain))
                    .ForMember(d => d.TimeCreated, opt => opt.MapFrom(s => s.TimeCreated))
                    .ForMember(d => d.Etag, opt => opt.MapFrom(s => s.ETag))
                    .ForMember(d => d.Placement, opt => opt.MapFrom(s => s.Placement))
                    // Ignore properties not in Track2 or are response-only
                    .ForMember(d => d.StatusCode, opt => opt.Ignore())
                    .ForMember(d => d.RequestId, opt => opt.Ignore())
                    .ForMember(d => d.FullyQualifiedDomainName, opt => opt.Ignore())
                    .ForMember(d => d.DisplayHint, opt => opt.Ignore())
                    .ForMember(d => d.AddProxyAgentExtension, opt => opt.Ignore());

                // Explicit mappings for nested profile types used by Track2 PSVirtualMachine
                cfg.CreateMap<Track2Models.PSHardwareProfileTrack2, FROM.HardwareProfile>();
                cfg.CreateMap<Track2Models.PSStorageProfileTrack2, FROM.StorageProfile>();
                cfg.CreateMap<Track2Models.PSNetworkProfileTrack2, FROM.NetworkProfile>();
                cfg.CreateMap<Track2Models.PSOSProfileTrack2, FROM.OSProfile>();
                cfg.CreateMap<Track2Models.PSSecurityProfileTrack2, FROM.SecurityProfile>();
                cfg.CreateMap<Track2Models.PSDiagnosticsProfileTrack2, FROM.DiagnosticsProfile>();

                // => PSComputeLongrunningOperation
                cfg.CreateMap<Rest.Azure.AzureOperationResponse, TO.PSComputeLongRunningOperation>()
                    .ForMember(c => c.OperationId, o => o.MapFrom(r => ComputeClientBaseCmdlet.GetOperationIdFromUrlString(r.Request.RequestUri.ToString())))
                    .ForMember(c => c.Status, o => o.MapFrom(r => "Succeeded"));

                cfg.CreateMap<Rest.Azure.AzureOperationResponse<FROM.VirtualMachine>, TO.PSComputeLongRunningOperation>()
                    .ForMember(c => c.OperationId, o => o.MapFrom(r => ComputeClientBaseCmdlet.GetOperationIdFromUrlString(r.Request.RequestUri.ToString())))
                    .ForMember(c => c.Status, o => o.MapFrom(r => "Succeeded"));

                cfg.CreateMap<Rest.Azure.AzureOperationResponse<FROM.VirtualMachineCaptureResult>, TO.PSComputeLongRunningOperation>()
                    .ForMember(c => c.OperationId, o => o.MapFrom(r => ComputeClientBaseCmdlet.GetOperationIdFromUrlString(r.Request.RequestUri.ToString())))
                    .ForMember(c => c.Status, o => o.MapFrom(r => "Succeeded"));

                cfg.CreateMap<Rest.Azure.AzureOperationResponse<FROM.VirtualMachineExtension>, TO.PSComputeLongRunningOperation>()
                    .ForMember(c => c.OperationId, o => o.MapFrom(r => ComputeClientBaseCmdlet.GetOperationIdFromUrlString(r.Request.RequestUri.ToString())))
                    .ForMember(c => c.Status, o => o.MapFrom(r => "Succeeded"));

                // => PSAzureOperationResponse
                cfg.CreateMap<Rest.Azure.AzureOperationResponse, TO.PSAzureOperationResponse>()
                    .ForMember(c => c.StatusCode, o => o.MapFrom(r => r.Response.StatusCode))
                    .ForMember(c => c.IsSuccessStatusCode, o => o.MapFrom(r => r.Response.IsSuccessStatusCode))
                    .ForMember(c => c.ReasonPhrase, o => o.MapFrom(r => r.Response.ReasonPhrase));

                cfg.CreateMap<AzureOperationResponse<FROM.VirtualMachine>, TO.PSAzureOperationResponse>()
                    .ForMember(c => c.StatusCode, o => o.MapFrom(r => r.Response.StatusCode))
                    .ForMember(c => c.IsSuccessStatusCode, o => o.MapFrom(r => r.Response.IsSuccessStatusCode))
                    .ForMember(c => c.ReasonPhrase, o => o.MapFrom(r => r.Response.ReasonPhrase));

                cfg.CreateMap<AzureOperationResponse<FROM.VirtualMachineExtension, FROM.VirtualMachineExtensionsCreateOrUpdateHeaders>, TO.PSAzureOperationResponse>()
                    .ForMember(c => c.StatusCode, o => o.MapFrom(r => r.Response.StatusCode))
                    .ForMember(c => c.IsSuccessStatusCode, o => o.MapFrom(r => r.Response.IsSuccessStatusCode))
                    .ForMember(c => c.ReasonPhrase, o => o.MapFrom(r => r.Response.ReasonPhrase));

                cfg.CreateMap<AzureOperationResponse<FROM.VirtualMachine, FROM.VirtualMachinesCreateOrUpdateHeaders>, TO.PSAzureOperationResponse>()
                    .ForMember(c => c.StatusCode, o => o.MapFrom(r => r.Response.StatusCode))
                    .ForMember(c => c.IsSuccessStatusCode, o => o.MapFrom(r => r.Response.IsSuccessStatusCode))
                    .ForMember(c => c.ReasonPhrase, o => o.MapFrom(r => r.Response.ReasonPhrase));

                cfg.CreateMap<AzureOperationResponse<FROM.VirtualMachineCaptureResult>, TO.PSAzureOperationResponse>()
                    .ForMember(c => c.StatusCode, o => o.MapFrom(r => r.Response.StatusCode))
                    .ForMember(c => c.IsSuccessStatusCode, o => o.MapFrom(r => r.Response.IsSuccessStatusCode))
                    .ForMember(c => c.ReasonPhrase, o => o.MapFrom(r => r.Response.ReasonPhrase));

                cfg.CreateMap<AzureOperationResponse<FROM.VirtualMachineExtension>, TO.PSAzureOperationResponse>()
                    .ForMember(c => c.StatusCode, o => o.MapFrom(r => r.Response.StatusCode))
                    .ForMember(c => c.IsSuccessStatusCode, o => o.MapFrom(r => r.Response.IsSuccessStatusCode))
                    .ForMember(c => c.ReasonPhrase, o => o.MapFrom(r => r.Response.ReasonPhrase));

                // AvailabilitySet => PSAvailabilitySet
                cfg.CreateMap<FROM.AvailabilitySet, TO.PSAvailabilitySet>()
                    .ForMember(c => c.VirtualMachinesReferences, o => o.MapFrom(r => r.VirtualMachines))
                    .ForMember(c => c.Sku, o => o.MapFrom(r => r.Sku.Name));

                cfg.CreateMap<AzureOperationResponse<FROM.AvailabilitySet>, TO.PSAvailabilitySet>()
                    .ForMember(c => c.StatusCode, o => o.MapFrom(r => r.Response.StatusCode));

                cfg.CreateMap<AzureOperationResponse<IPage<FROM.AvailabilitySet>>, TO.PSAvailabilitySet>()
                    .ForMember(c => c.StatusCode, o => o.MapFrom(r => r.Response.StatusCode));

                // VirtualMachine => PSVirtualMachine
                cfg.CreateMap<FROM.VirtualMachine, TO.PSVirtualMachine>()
                    .ForMember(c => c.AvailabilitySetReference, o => o.MapFrom(r => r.AvailabilitySet))
                    .ForMember(c => c.Extensions, o => o.MapFrom(r => r.Resources))
                    .ForMember(c => c.OSProfile, o => o.MapFrom(r => r.OsProfile))
                    .ForMember(c => c.Zones, o => o.Condition(r => (r.Zones != null)));

                cfg.CreateMap<AzureOperationResponse<FROM.VirtualMachine>, TO.PSVirtualMachine>()
                    .ForMember(c => c.StatusCode, o => o.MapFrom(r => r.Response.StatusCode));

                cfg.CreateMap<AzureOperationResponse<IPage<FROM.VirtualMachine>>, TO.PSVirtualMachine>()
                    .ForMember(c => c.StatusCode, o => o.MapFrom(r => r.Response.StatusCode));

                cfg.CreateMap<AzureOperationResponse<IEnumerable<FROM.VirtualMachine>>, TO.PSVirtualMachine>()
                    .ForMember(c => c.StatusCode, o => o.MapFrom(r => r.Response.StatusCode));

                // VirtualMachine => PSVirtualMachineListStatusContext
                cfg.CreateMap<FROM.VirtualMachine, TO.PSVirtualMachineListStatus>()
                    .ForMember(c => c.AvailabilitySetReference, o => o.MapFrom(r => r.AvailabilitySet))
                    .ForMember(c => c.Extensions, o => o.MapFrom(r => r.Resources))
                    .ForMember(c => c.OSProfile, o => o.MapFrom(r => r.OsProfile))
                    .ForMember(c => c.Zones, o => o.Condition(r => (r.Zones != null)));

                cfg.CreateMap<AzureOperationResponse<FROM.VirtualMachine>, TO.PSVirtualMachineListStatus>()
                    .ForMember(c => c.StatusCode, o => o.MapFrom(r => r.Response.StatusCode));

                cfg.CreateMap<AzureOperationResponse<IPage<FROM.VirtualMachine>>, TO.PSVirtualMachineListStatus>()
                    .ForMember(c => c.StatusCode, o => o.MapFrom(r => r.Response.StatusCode));

                cfg.CreateMap<AzureOperationResponse<IEnumerable<FROM.VirtualMachine>>, TO.PSVirtualMachineListStatus>()
                    .ForMember(c => c.StatusCode, o => o.MapFrom(r => r.Response.StatusCode));

                cfg.CreateMap<TO.PSVirtualMachineListStatus, TO.PSVirtualMachineList>();

                // VirtualMachineSize => PSVirtualMachineSize
                cfg.CreateMap<FROM.VirtualMachineSize, TO.PSVirtualMachineSize>();

                cfg.CreateMap<AzureOperationResponse<FROM.VirtualMachineSize>, TO.PSVirtualMachineSize>()
                    .ForMember(c => c.StatusCode, o => o.MapFrom(r => r.Response.StatusCode));

                cfg.CreateMap<AzureOperationResponse<IEnumerable<FROM.VirtualMachineSize>>, TO.PSVirtualMachineSize>()
                    .ForMember(c => c.StatusCode, o => o.MapFrom(r => r.Response.StatusCode));

                // Usage => PSUsage
                cfg.CreateMap<FROM.Usage, TO.PSUsage>()
                    .ForMember(c => c.Unit, o => o.MapFrom(r => FROM.Usage.Unit));

                cfg.CreateMap<AzureOperationResponse<FROM.Usage>, TO.PSUsage>()
                    .ForMember(c => c.StatusCode, o => o.MapFrom(r => r.Response.StatusCode));

                cfg.CreateMap<AzureOperationResponse<IPage<FROM.Usage>>, TO.PSUsage>()
                    .ForMember(c => c.StatusCode, o => o.MapFrom(r => r.Response.StatusCode));

                // PSVirtualMachine <=> PSVirtualMachineList
                cfg.CreateMap<TO.PSVirtualMachine, TO.PSVirtualMachineList>()
                    .ForMember(c => c.Zones, o => o.Condition(r => (r.Zones != null)));
                cfg.CreateMap<TO.PSVirtualMachineList, TO.PSVirtualMachine>()
                    .ForMember(c => c.Zones, o => o.Condition(r => (r.Zones != null)));

                // PSVmssDiskEncryptionStatusContext <=> PSVmssDiskEncryptionStatusContextList
                cfg.CreateMap<TO.PSVmssDiskEncryptionStatusContext, TO.PSVmssDiskEncryptionStatusContextList>();
                cfg.CreateMap<TO.PSVmssVMDiskEncryptionStatusContext, TO.PSVmssVMDiskEncryptionStatusContextList>();
            });

            _mapper = config.CreateMapper();
        }
    }
}
