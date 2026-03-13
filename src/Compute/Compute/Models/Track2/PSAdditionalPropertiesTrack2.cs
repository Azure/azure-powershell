// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;

namespace Microsoft.Azure.Commands.Compute.Models.Track2
{
    // Plan information for marketplace images
    public class PSComputePlan
    {
        public string Name { get; set; }
        public string Publisher { get; set; }
        public string Product { get; set; }
        public string PromotionCode { get; set; }
    }

    // Managed Service Identity
    public class PSManagedServiceIdentity
    {
        public string Type { get; set; }
        public string PrincipalId { get; set; }
        public string TenantId { get; set; }
        public IDictionary<string, PSUserAssignedIdentity> UserAssignedIdentities { get; set; }
    }

    public class PSUserAssignedIdentity
    {
        public string PrincipalId { get; set; }
        public string ClientId { get; set; }
    }

    // Extended Location
    public class PSExtendedLocation
    {
        public string Name { get; set; }
        public string Type { get; set; }
    }

    // Additional Capabilities
    public class PSAdditionalCapabilities
    {
        public bool? UltraSSDEnabled { get; set; }
        public bool? HibernationEnabled { get; set; }
    }

    // Scheduled Events Policy
    public class PSScheduledEventsPolicy
    {
        public PSUserInitiatedReboot UserInitiatedReboot { get; set; }
        public PSUserInitiatedRedeploy UserInitiatedRedeploy { get; set; }
        public PSScheduledEventsAdditionalPublishingTargets ScheduledEventsAdditionalPublishingTargets { get; set; }
    }

    public class PSUserInitiatedReboot
    {
        public bool? AutomaticallyApprove { get; set; }
    }

    public class PSUserInitiatedRedeploy
    {
        public bool? AutomaticallyApprove { get; set; }
    }

    public class PSScheduledEventsAdditionalPublishingTargets
    {
        public PSEventGridAndResourceGraph EventGridAndResourceGraph { get; set; }
    }

    public class PSEventGridAndResourceGraph
    {
        public bool? Enable { get; set; }
    }

    // Scheduled Events Profile
    public class PSComputeScheduledEventsProfile
    {
        public PSTerminateNotificationProfile TerminateNotificationProfile { get; set; }
        public PSOSImageNotificationProfile OSImageNotificationProfile { get; set; }
    }

    public class PSTerminateNotificationProfile
    {
        public bool? Enable { get; set; }
        public string NotBeforeTimeout { get; set; }
    }

    public class PSOSImageNotificationProfile
    {
        public bool? Enable { get; set; }
        public string NotBeforeTimeout { get; set; }
    }

    // VM Placement
    public class PSVirtualMachinePlacement
    {
        public int? PartitionCount { get; set; }
        public IList<string> HostIds { get; set; }
    }

    // Gallery Application
    public class PSVirtualMachineGalleryApplication
    {
        public string PackageReferenceId { get; set; }
        public string ConfigurationReference { get; set; }
        public string Tags { get; set; }
        public int? Order { get; set; }
        public bool? TreatFailureAsDeploymentFailure { get; set; }
        public bool? EnableAutomaticUpgrade { get; set; }
    }
}