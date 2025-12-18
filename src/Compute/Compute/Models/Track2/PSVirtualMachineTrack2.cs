// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;
using Azure.ResourceManager.Compute.Models;
using Azure.ResourceManager.Models;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Microsoft.Azure.Commands.Compute.Models.Track2
{
    /// <summary>
    /// Track2 SDK-specific writable VM model for internal mapping from VirtualMachineData
    /// </summary>
    public class PSVirtualMachine
    {
        // ARM Resource Properties
        public string ResourceGroupName
        {
            get
            {
                if (string.IsNullOrEmpty(Id)) return null;
                Regex r = new Regex(@"(.*?)/resourcegroups/(?<rgname>\S+)/providers/(.*?)", RegexOptions.IgnoreCase);
                Match m = r.Match(Id);
                return m.Success ? m.Groups["rgname"].Value : null;
            }
        }
        public string Id { get; set; }
        public string Name { get; set; }
        public string ResourceType { get; set; }  // Maps from ResourceType, not Type
        public string Location { get; set; }
        public IDictionary<string, string> Tags { get; set; }
        
        // VM Properties
        public string VmId { get; set; }
        public IList<string> Zones { get; set; }
        
        // Plan
        public PSComputePlan Plan { get; set; }
        
        // Identity
        public PSManagedServiceIdentity Identity { get; set; }
        
        // Extended Location
        public PSExtendedLocation ExtendedLocation { get; set; }
        
        // Profiles
        public PSHardwareProfile HardwareProfile { get; set; }
        public PSStorageProfile StorageProfile { get; set; }
        public PSNetworkProfile NetworkProfile { get; set; }
        public PSOSProfile OSProfile { get; set; }
        public PSSecurityProfile SecurityProfile { get; set; }
        
        // Note: DiagnosticsProfile is internal in VirtualMachineData
        // Only BootDiagnostics is exposed publicly
        public PSBootDiagnostics BootDiagnostics { get; set; }
        
        // Additional Capabilities
        public PSAdditionalCapabilities AdditionalCapabilities { get; set; }
        
        // Flattened ResourceIdentifiers ( pattern)
        public string AvailabilitySetId { get; set; }
        public string VirtualMachineScaleSetId { get; set; }
        public string ProximityPlacementGroupId { get; set; }
        public string HostId { get; set; }
        public string HostGroupId { get; set; }
        public string CapacityReservationGroupId { get; set; }
        
        // Scheduling and Events
        public PSScheduledEventsPolicy ScheduledEventsPolicy { get; set; }
        public PSComputeScheduledEventsProfile ScheduledEventsProfile { get; set; }
        
        // Spot VM Properties
        public string Priority { get; set; }
        public string EvictionPolicy { get; set; }
        
        // Note: BillingProfile is internal in VirtualMachineData
        // Only MaxPrice is exposed publicly
        public double? BillingMaxPrice { get; set; }
        
        // Note: ApplicationProfile is internal in VirtualMachineData
        // Only GalleryApplications is exposed publicly
        public IList<PSVirtualMachineGalleryApplication> GalleryApplications { get; set; }
        
        // License and User Data
        public string LicenseType { get; set; }
        public string UserData { get; set; }
        
        // Placement
        public PSVirtualMachinePlacement Placement { get; set; }
        public int? PlatformFaultDomain { get; set; }
        
        // Instance View (read-only)
        public PSVirtualMachineInstanceView InstanceView { get; set; }
        
        // Extensions (Resources in Track2)
        public IList<PSVirtualMachineExtension> Resources { get; set; }
        
        // Metadata
        public string ProvisioningState { get; set; }
        public DateTimeOffset? TimeCreated { get; set; }
        public string ExtensionsTimeBudget { get; set; }
        public string ETag { get; set; }
        public string ManagedBy { get; set; }
    }
}