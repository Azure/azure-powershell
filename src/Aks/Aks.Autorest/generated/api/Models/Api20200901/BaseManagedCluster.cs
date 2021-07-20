namespace Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Aks.Runtime.Extensions;

    public partial class BaseManagedCluster :
        Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IBaseManagedCluster,
        Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IBaseManagedClusterInternal
    {

        /// <summary>AAD group object IDs that will have admin role of the cluster.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Aks.Origin(Microsoft.Azure.PowerShell.Cmdlets.Aks.PropertyOrigin.Inlined)]
        public string[] AadProfileAdminGroupObjectID { get => ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IManagedClusterPropertiesInternal)Property).AadProfileAdminGroupObjectID; set => ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IManagedClusterPropertiesInternal)Property).AadProfileAdminGroupObjectID = value ?? null /* arrayOf */; }

        /// <summary>The client AAD application ID.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Aks.Origin(Microsoft.Azure.PowerShell.Cmdlets.Aks.PropertyOrigin.Inlined)]
        public string AadProfileClientAppId { get => ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IManagedClusterPropertiesInternal)Property).AadProfileClientAppId; set => ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IManagedClusterPropertiesInternal)Property).AadProfileClientAppId = value ?? null; }

        /// <summary>Whether to enable Azure RBAC for Kubernetes authorization.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Aks.Origin(Microsoft.Azure.PowerShell.Cmdlets.Aks.PropertyOrigin.Inlined)]
        public bool? AadProfileEnableAzureRbac { get => ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IManagedClusterPropertiesInternal)Property).AadProfileEnableAzureRbac; set => ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IManagedClusterPropertiesInternal)Property).AadProfileEnableAzureRbac = value ?? default(bool); }

        /// <summary>Whether to enable managed AAD.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Aks.Origin(Microsoft.Azure.PowerShell.Cmdlets.Aks.PropertyOrigin.Inlined)]
        public bool? AadProfileManaged { get => ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IManagedClusterPropertiesInternal)Property).AadProfileManaged; set => ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IManagedClusterPropertiesInternal)Property).AadProfileManaged = value ?? default(bool); }

        /// <summary>The server AAD application ID.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Aks.Origin(Microsoft.Azure.PowerShell.Cmdlets.Aks.PropertyOrigin.Inlined)]
        public string AadProfileServerAppId { get => ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IManagedClusterPropertiesInternal)Property).AadProfileServerAppId; set => ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IManagedClusterPropertiesInternal)Property).AadProfileServerAppId = value ?? null; }

        /// <summary>The server AAD application secret.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Aks.Origin(Microsoft.Azure.PowerShell.Cmdlets.Aks.PropertyOrigin.Inlined)]
        public string AadProfileServerAppSecret { get => ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IManagedClusterPropertiesInternal)Property).AadProfileServerAppSecret; set => ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IManagedClusterPropertiesInternal)Property).AadProfileServerAppSecret = value ?? null; }

        /// <summary>
        /// The AAD tenant ID to use for authentication. If not specified, will use the tenant of the deployment subscription.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Aks.Origin(Microsoft.Azure.PowerShell.Cmdlets.Aks.PropertyOrigin.Inlined)]
        public string AadProfileTenantId { get => ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IManagedClusterPropertiesInternal)Property).AadProfileTenantId; set => ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IManagedClusterPropertiesInternal)Property).AadProfileTenantId = value ?? null; }

        /// <summary>Profile of managed cluster add-on.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Aks.Origin(Microsoft.Azure.PowerShell.Cmdlets.Aks.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IManagedClusterPropertiesAddonProfiles AddonProfile { get => ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IManagedClusterPropertiesInternal)Property).AddonProfile; set => ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IManagedClusterPropertiesInternal)Property).AddonProfile = value ?? null /* model class */; }

        /// <summary>Properties of the agent pool.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Aks.Origin(Microsoft.Azure.PowerShell.Cmdlets.Aks.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IManagedClusterAgentPoolProfile[] AgentPoolProfile { get => ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IManagedClusterPropertiesInternal)Property).AgentPoolProfile; set => ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IManagedClusterPropertiesInternal)Property).AgentPoolProfile = value ?? null /* arrayOf */; }

        /// <summary>Authorized IP Ranges to kubernetes API server.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Aks.Origin(Microsoft.Azure.PowerShell.Cmdlets.Aks.PropertyOrigin.Inlined)]
        public string[] ApiServerAccessProfileAuthorizedIPRange { get => ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IManagedClusterPropertiesInternal)Property).ApiServerAccessProfileAuthorizedIPRange; set => ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IManagedClusterPropertiesInternal)Property).ApiServerAccessProfileAuthorizedIPRange = value ?? null /* arrayOf */; }

        /// <summary>Whether to create the cluster as a private cluster or not.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Aks.Origin(Microsoft.Azure.PowerShell.Cmdlets.Aks.PropertyOrigin.Inlined)]
        public bool? ApiServerAccessProfileEnablePrivateCluster { get => ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IManagedClusterPropertiesInternal)Property).ApiServerAccessProfileEnablePrivateCluster; set => ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IManagedClusterPropertiesInternal)Property).ApiServerAccessProfileEnablePrivateCluster = value ?? default(bool); }

        [Microsoft.Azure.PowerShell.Cmdlets.Aks.Origin(Microsoft.Azure.PowerShell.Cmdlets.Aks.PropertyOrigin.Inlined)]
        public string AutoScalerProfileBalanceSimilarNodeGroup { get => ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IManagedClusterPropertiesInternal)Property).AutoScalerProfileBalanceSimilarNodeGroup; set => ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IManagedClusterPropertiesInternal)Property).AutoScalerProfileBalanceSimilarNodeGroup = value ?? null; }

        [Microsoft.Azure.PowerShell.Cmdlets.Aks.Origin(Microsoft.Azure.PowerShell.Cmdlets.Aks.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.Aks.Support.Expander? AutoScalerProfileExpander { get => ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IManagedClusterPropertiesInternal)Property).AutoScalerProfileExpander; set => ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IManagedClusterPropertiesInternal)Property).AutoScalerProfileExpander = value ?? ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Support.Expander)""); }

        [Microsoft.Azure.PowerShell.Cmdlets.Aks.Origin(Microsoft.Azure.PowerShell.Cmdlets.Aks.PropertyOrigin.Inlined)]
        public string AutoScalerProfileMaxEmptyBulkDelete { get => ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IManagedClusterPropertiesInternal)Property).AutoScalerProfileMaxEmptyBulkDelete; set => ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IManagedClusterPropertiesInternal)Property).AutoScalerProfileMaxEmptyBulkDelete = value ?? null; }

        [Microsoft.Azure.PowerShell.Cmdlets.Aks.Origin(Microsoft.Azure.PowerShell.Cmdlets.Aks.PropertyOrigin.Inlined)]
        public string AutoScalerProfileMaxGracefulTerminationSec { get => ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IManagedClusterPropertiesInternal)Property).AutoScalerProfileMaxGracefulTerminationSec; set => ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IManagedClusterPropertiesInternal)Property).AutoScalerProfileMaxGracefulTerminationSec = value ?? null; }

        [Microsoft.Azure.PowerShell.Cmdlets.Aks.Origin(Microsoft.Azure.PowerShell.Cmdlets.Aks.PropertyOrigin.Inlined)]
        public string AutoScalerProfileMaxTotalUnreadyPercentage { get => ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IManagedClusterPropertiesInternal)Property).AutoScalerProfileMaxTotalUnreadyPercentage; set => ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IManagedClusterPropertiesInternal)Property).AutoScalerProfileMaxTotalUnreadyPercentage = value ?? null; }

        [Microsoft.Azure.PowerShell.Cmdlets.Aks.Origin(Microsoft.Azure.PowerShell.Cmdlets.Aks.PropertyOrigin.Inlined)]
        public string AutoScalerProfileNewPodScaleUpDelay { get => ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IManagedClusterPropertiesInternal)Property).AutoScalerProfileNewPodScaleUpDelay; set => ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IManagedClusterPropertiesInternal)Property).AutoScalerProfileNewPodScaleUpDelay = value ?? null; }

        [Microsoft.Azure.PowerShell.Cmdlets.Aks.Origin(Microsoft.Azure.PowerShell.Cmdlets.Aks.PropertyOrigin.Inlined)]
        public string AutoScalerProfileOkTotalUnreadyCount { get => ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IManagedClusterPropertiesInternal)Property).AutoScalerProfileOkTotalUnreadyCount; set => ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IManagedClusterPropertiesInternal)Property).AutoScalerProfileOkTotalUnreadyCount = value ?? null; }

        [Microsoft.Azure.PowerShell.Cmdlets.Aks.Origin(Microsoft.Azure.PowerShell.Cmdlets.Aks.PropertyOrigin.Inlined)]
        public string AutoScalerProfileScaleDownDelayAfterAdd { get => ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IManagedClusterPropertiesInternal)Property).AutoScalerProfileScaleDownDelayAfterAdd; set => ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IManagedClusterPropertiesInternal)Property).AutoScalerProfileScaleDownDelayAfterAdd = value ?? null; }

        [Microsoft.Azure.PowerShell.Cmdlets.Aks.Origin(Microsoft.Azure.PowerShell.Cmdlets.Aks.PropertyOrigin.Inlined)]
        public string AutoScalerProfileScaleDownDelayAfterDelete { get => ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IManagedClusterPropertiesInternal)Property).AutoScalerProfileScaleDownDelayAfterDelete; set => ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IManagedClusterPropertiesInternal)Property).AutoScalerProfileScaleDownDelayAfterDelete = value ?? null; }

        [Microsoft.Azure.PowerShell.Cmdlets.Aks.Origin(Microsoft.Azure.PowerShell.Cmdlets.Aks.PropertyOrigin.Inlined)]
        public string AutoScalerProfileScaleDownDelayAfterFailure { get => ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IManagedClusterPropertiesInternal)Property).AutoScalerProfileScaleDownDelayAfterFailure; set => ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IManagedClusterPropertiesInternal)Property).AutoScalerProfileScaleDownDelayAfterFailure = value ?? null; }

        [Microsoft.Azure.PowerShell.Cmdlets.Aks.Origin(Microsoft.Azure.PowerShell.Cmdlets.Aks.PropertyOrigin.Inlined)]
        public string AutoScalerProfileScaleDownUnneededTime { get => ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IManagedClusterPropertiesInternal)Property).AutoScalerProfileScaleDownUnneededTime; set => ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IManagedClusterPropertiesInternal)Property).AutoScalerProfileScaleDownUnneededTime = value ?? null; }

        [Microsoft.Azure.PowerShell.Cmdlets.Aks.Origin(Microsoft.Azure.PowerShell.Cmdlets.Aks.PropertyOrigin.Inlined)]
        public string AutoScalerProfileScaleDownUnreadyTime { get => ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IManagedClusterPropertiesInternal)Property).AutoScalerProfileScaleDownUnreadyTime; set => ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IManagedClusterPropertiesInternal)Property).AutoScalerProfileScaleDownUnreadyTime = value ?? null; }

        [Microsoft.Azure.PowerShell.Cmdlets.Aks.Origin(Microsoft.Azure.PowerShell.Cmdlets.Aks.PropertyOrigin.Inlined)]
        public string AutoScalerProfileScaleDownUtilizationThreshold { get => ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IManagedClusterPropertiesInternal)Property).AutoScalerProfileScaleDownUtilizationThreshold; set => ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IManagedClusterPropertiesInternal)Property).AutoScalerProfileScaleDownUtilizationThreshold = value ?? null; }

        [Microsoft.Azure.PowerShell.Cmdlets.Aks.Origin(Microsoft.Azure.PowerShell.Cmdlets.Aks.PropertyOrigin.Inlined)]
        public string AutoScalerProfileScanInterval { get => ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IManagedClusterPropertiesInternal)Property).AutoScalerProfileScanInterval; set => ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IManagedClusterPropertiesInternal)Property).AutoScalerProfileScanInterval = value ?? null; }

        [Microsoft.Azure.PowerShell.Cmdlets.Aks.Origin(Microsoft.Azure.PowerShell.Cmdlets.Aks.PropertyOrigin.Inlined)]
        public string AutoScalerProfileSkipNodesWithLocalStorage { get => ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IManagedClusterPropertiesInternal)Property).AutoScalerProfileSkipNodesWithLocalStorage; set => ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IManagedClusterPropertiesInternal)Property).AutoScalerProfileSkipNodesWithLocalStorage = value ?? null; }

        [Microsoft.Azure.PowerShell.Cmdlets.Aks.Origin(Microsoft.Azure.PowerShell.Cmdlets.Aks.PropertyOrigin.Inlined)]
        public string AutoScalerProfileSkipNodesWithSystemPod { get => ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IManagedClusterPropertiesInternal)Property).AutoScalerProfileSkipNodesWithSystemPod; set => ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IManagedClusterPropertiesInternal)Property).AutoScalerProfileSkipNodesWithSystemPod = value ?? null; }

        /// <summary>ResourceId of the disk encryption set to use for enabling encryption at rest.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Aks.Origin(Microsoft.Azure.PowerShell.Cmdlets.Aks.PropertyOrigin.Inlined)]
        public string DiskEncryptionSetId { get => ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IManagedClusterPropertiesInternal)Property).DiskEncryptionSetId; set => ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IManagedClusterPropertiesInternal)Property).DiskEncryptionSetId = value ?? null; }

        /// <summary>DNS prefix specified when creating the managed cluster.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Aks.Origin(Microsoft.Azure.PowerShell.Cmdlets.Aks.PropertyOrigin.Inlined)]
        public string DnsPrefix { get => ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IManagedClusterPropertiesInternal)Property).DnsPrefix; set => ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IManagedClusterPropertiesInternal)Property).DnsPrefix = value ?? null; }

        /// <summary>
        /// (DEPRECATING) Whether to enable Kubernetes pod security policy (preview). This feature is set for removal on October 15th,
        /// 2020. Learn more at aka.ms/aks/azpodpolicy.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Aks.Origin(Microsoft.Azure.PowerShell.Cmdlets.Aks.PropertyOrigin.Inlined)]
        public bool? EnablePodSecurityPolicy { get => ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IManagedClusterPropertiesInternal)Property).EnablePodSecurityPolicy; set => ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IManagedClusterPropertiesInternal)Property).EnablePodSecurityPolicy = value ?? default(bool); }

        /// <summary>Whether to enable Kubernetes Role-Based Access Control.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Aks.Origin(Microsoft.Azure.PowerShell.Cmdlets.Aks.PropertyOrigin.Inlined)]
        public bool? EnableRbac { get => ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IManagedClusterPropertiesInternal)Property).EnableRbac; set => ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IManagedClusterPropertiesInternal)Property).EnableRbac = value ?? default(bool); }

        /// <summary>FQDN for the master pool.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Aks.Origin(Microsoft.Azure.PowerShell.Cmdlets.Aks.PropertyOrigin.Inlined)]
        public string Fqdn { get => ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IManagedClusterPropertiesInternal)Property).Fqdn; }

        /// <summary>Backing field for <see cref="Identity" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IManagedClusterIdentity _identity;

        /// <summary>The identity of the managed cluster, if configured.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Aks.Origin(Microsoft.Azure.PowerShell.Cmdlets.Aks.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IManagedClusterIdentity Identity { get => (this._identity = this._identity ?? new Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.ManagedClusterIdentity()); set => this._identity = value; }

        /// <summary>
        /// The principal id of the system assigned identity which is used by master components.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Aks.Origin(Microsoft.Azure.PowerShell.Cmdlets.Aks.PropertyOrigin.Inlined)]
        public string IdentityPrincipalId { get => ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IManagedClusterIdentityInternal)Identity).PrincipalId; }

        /// <summary>Identities associated with the cluster.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Aks.Origin(Microsoft.Azure.PowerShell.Cmdlets.Aks.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IManagedClusterPropertiesIdentityProfile IdentityProfile { get => ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IManagedClusterPropertiesInternal)Property).IdentityProfile; set => ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IManagedClusterPropertiesInternal)Property).IdentityProfile = value ?? null /* model class */; }

        /// <summary>
        /// The tenant id of the system assigned identity which is used by master components.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Aks.Origin(Microsoft.Azure.PowerShell.Cmdlets.Aks.PropertyOrigin.Inlined)]
        public string IdentityTenantId { get => ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IManagedClusterIdentityInternal)Identity).TenantId; }

        /// <summary>
        /// The type of identity used for the managed cluster. Type 'SystemAssigned' will use an implicitly created identity in master
        /// components and an auto-created user assigned identity in MC_ resource group in agent nodes. Type 'None' will not use MSI
        /// for the managed cluster, service principal will be used instead.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Aks.Origin(Microsoft.Azure.PowerShell.Cmdlets.Aks.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.Aks.Support.ResourceIdentityType? IdentityType { get => ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IManagedClusterIdentityInternal)Identity).Type; set => ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IManagedClusterIdentityInternal)Identity).Type = value ?? ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Support.ResourceIdentityType)""); }

        /// <summary>
        /// The user identity associated with the managed cluster. This identity will be used in control plane and only one user assigned
        /// identity is allowed. The user identity dictionary key references will be ARM resource ids in the form: '/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ManagedIdentity/userAssignedIdentities/{identityName}'.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Aks.Origin(Microsoft.Azure.PowerShell.Cmdlets.Aks.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IManagedClusterIdentityUserAssignedIdentities IdentityUserAssignedIdentity { get => ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IManagedClusterIdentityInternal)Identity).UserAssignedIdentity; set => ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IManagedClusterIdentityInternal)Identity).UserAssignedIdentity = value ?? null /* model class */; }

        /// <summary>Version of Kubernetes specified when creating the managed cluster.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Aks.Origin(Microsoft.Azure.PowerShell.Cmdlets.Aks.PropertyOrigin.Inlined)]
        public string KubernetesVersion { get => ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IManagedClusterPropertiesInternal)Property).KubernetesVersion; set => ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IManagedClusterPropertiesInternal)Property).KubernetesVersion = value ?? null; }

        /// <summary>The administrator username to use for Linux VMs.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Aks.Origin(Microsoft.Azure.PowerShell.Cmdlets.Aks.PropertyOrigin.Inlined)]
        public string LinuxProfileAdminUsername { get => ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IManagedClusterPropertiesInternal)Property).LinuxProfileAdminUsername; set => ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IManagedClusterPropertiesInternal)Property).LinuxProfileAdminUsername = value ?? null; }

        /// <summary>
        /// Desired number of allocated SNAT ports per VM. Allowed values must be in the range of 0 to 64000 (inclusive). The default
        /// value is 0 which results in Azure dynamically allocating ports.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Aks.Origin(Microsoft.Azure.PowerShell.Cmdlets.Aks.PropertyOrigin.Inlined)]
        public int? LoadBalancerProfileAllocatedOutboundPort { get => ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IManagedClusterPropertiesInternal)Property).LoadBalancerProfileAllocatedOutboundPort; set => ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IManagedClusterPropertiesInternal)Property).LoadBalancerProfileAllocatedOutboundPort = value ?? default(int); }

        /// <summary>The effective outbound IP resources of the cluster load balancer.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Aks.Origin(Microsoft.Azure.PowerShell.Cmdlets.Aks.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IResourceReference[] LoadBalancerProfileEffectiveOutboundIP { get => ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IManagedClusterPropertiesInternal)Property).LoadBalancerProfileEffectiveOutboundIP; set => ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IManagedClusterPropertiesInternal)Property).LoadBalancerProfileEffectiveOutboundIP = value ?? null /* arrayOf */; }

        /// <summary>
        /// Desired outbound flow idle timeout in minutes. Allowed values must be in the range of 4 to 120 (inclusive). The default
        /// value is 30 minutes.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Aks.Origin(Microsoft.Azure.PowerShell.Cmdlets.Aks.PropertyOrigin.Inlined)]
        public int? LoadBalancerProfileIdleTimeoutInMinute { get => ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IManagedClusterPropertiesInternal)Property).LoadBalancerProfileIdleTimeoutInMinute; set => ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IManagedClusterPropertiesInternal)Property).LoadBalancerProfileIdleTimeoutInMinute = value ?? default(int); }

        /// <summary>
        /// Desired number of outbound IP created/managed by Azure for the cluster load balancer. Allowed values must be in the range
        /// of 1 to 100 (inclusive). The default value is 1.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Aks.Origin(Microsoft.Azure.PowerShell.Cmdlets.Aks.PropertyOrigin.Inlined)]
        public int? ManagedOutboundIPCount { get => ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IManagedClusterPropertiesInternal)Property).ManagedOutboundIPCount; set => ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IManagedClusterPropertiesInternal)Property).ManagedOutboundIPCount = value ?? default(int); }

        /// <summary>The max number of agent pools for the managed cluster.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Aks.Origin(Microsoft.Azure.PowerShell.Cmdlets.Aks.PropertyOrigin.Inlined)]
        public int? MaxAgentPool { get => ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IManagedClusterPropertiesInternal)Property).MaxAgentPool; }

        /// <summary>Internal Acessors for AadProfile</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IManagedClusterAadProfile Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IBaseManagedClusterInternal.AadProfile { get => ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IManagedClusterPropertiesInternal)Property).AadProfile; set => ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IManagedClusterPropertiesInternal)Property).AadProfile = value; }

        /// <summary>Internal Acessors for ApiServerAccessProfile</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IManagedClusterApiServerAccessProfile Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IBaseManagedClusterInternal.ApiServerAccessProfile { get => ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IManagedClusterPropertiesInternal)Property).ApiServerAccessProfile; set => ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IManagedClusterPropertiesInternal)Property).ApiServerAccessProfile = value; }

        /// <summary>Internal Acessors for AutoScalerProfile</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IManagedClusterPropertiesAutoScalerProfile Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IBaseManagedClusterInternal.AutoScalerProfile { get => ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IManagedClusterPropertiesInternal)Property).AutoScalerProfile; set => ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IManagedClusterPropertiesInternal)Property).AutoScalerProfile = value; }

        /// <summary>Internal Acessors for Fqdn</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IBaseManagedClusterInternal.Fqdn { get => ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IManagedClusterPropertiesInternal)Property).Fqdn; set => ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IManagedClusterPropertiesInternal)Property).Fqdn = value; }

        /// <summary>Internal Acessors for Identity</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IManagedClusterIdentity Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IBaseManagedClusterInternal.Identity { get => (this._identity = this._identity ?? new Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.ManagedClusterIdentity()); set { {_identity = value;} } }

        /// <summary>Internal Acessors for IdentityPrincipalId</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IBaseManagedClusterInternal.IdentityPrincipalId { get => ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IManagedClusterIdentityInternal)Identity).PrincipalId; set => ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IManagedClusterIdentityInternal)Identity).PrincipalId = value; }

        /// <summary>Internal Acessors for IdentityTenantId</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IBaseManagedClusterInternal.IdentityTenantId { get => ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IManagedClusterIdentityInternal)Identity).TenantId; set => ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IManagedClusterIdentityInternal)Identity).TenantId = value; }

        /// <summary>Internal Acessors for LinuxProfile</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IContainerServiceLinuxProfile Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IBaseManagedClusterInternal.LinuxProfile { get => ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IManagedClusterPropertiesInternal)Property).LinuxProfile; set => ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IManagedClusterPropertiesInternal)Property).LinuxProfile = value; }

        /// <summary>Internal Acessors for LinuxProfileSsh</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IContainerServiceSshConfiguration Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IBaseManagedClusterInternal.LinuxProfileSsh { get => ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IManagedClusterPropertiesInternal)Property).LinuxProfileSsh; set => ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IManagedClusterPropertiesInternal)Property).LinuxProfileSsh = value; }

        /// <summary>Internal Acessors for LoadBalancerProfileManagedOutboundIP</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IManagedClusterLoadBalancerProfileManagedOutboundIPs Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IBaseManagedClusterInternal.LoadBalancerProfileManagedOutboundIP { get => ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IManagedClusterPropertiesInternal)Property).LoadBalancerProfileManagedOutboundIP; set => ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IManagedClusterPropertiesInternal)Property).LoadBalancerProfileManagedOutboundIP = value; }

        /// <summary>Internal Acessors for LoadBalancerProfileOutboundIP</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IManagedClusterLoadBalancerProfileOutboundIPs Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IBaseManagedClusterInternal.LoadBalancerProfileOutboundIP { get => ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IManagedClusterPropertiesInternal)Property).LoadBalancerProfileOutboundIP; set => ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IManagedClusterPropertiesInternal)Property).LoadBalancerProfileOutboundIP = value; }

        /// <summary>Internal Acessors for LoadBalancerProfileOutboundIPPrefix</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IManagedClusterLoadBalancerProfileOutboundIPPrefixes Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IBaseManagedClusterInternal.LoadBalancerProfileOutboundIPPrefix { get => ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IManagedClusterPropertiesInternal)Property).LoadBalancerProfileOutboundIPPrefix; set => ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IManagedClusterPropertiesInternal)Property).LoadBalancerProfileOutboundIPPrefix = value; }

        /// <summary>Internal Acessors for MaxAgentPool</summary>
        int? Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IBaseManagedClusterInternal.MaxAgentPool { get => ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IManagedClusterPropertiesInternal)Property).MaxAgentPool; set => ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IManagedClusterPropertiesInternal)Property).MaxAgentPool = value; }

        /// <summary>Internal Acessors for NetworkProfile</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IContainerServiceNetworkProfile Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IBaseManagedClusterInternal.NetworkProfile { get => ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IManagedClusterPropertiesInternal)Property).NetworkProfile; set => ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IManagedClusterPropertiesInternal)Property).NetworkProfile = value; }

        /// <summary>Internal Acessors for NetworkProfileLoadBalancerProfile</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IManagedClusterLoadBalancerProfile Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IBaseManagedClusterInternal.NetworkProfileLoadBalancerProfile { get => ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IManagedClusterPropertiesInternal)Property).NetworkProfileLoadBalancerProfile; set => ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IManagedClusterPropertiesInternal)Property).NetworkProfileLoadBalancerProfile = value; }

        /// <summary>Internal Acessors for PowerState</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IPowerState Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IBaseManagedClusterInternal.PowerState { get => ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IManagedClusterPropertiesInternal)Property).PowerState; set => ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IManagedClusterPropertiesInternal)Property).PowerState = value; }

        /// <summary>Internal Acessors for PrivateFqdn</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IBaseManagedClusterInternal.PrivateFqdn { get => ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IManagedClusterPropertiesInternal)Property).PrivateFqdn; set => ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IManagedClusterPropertiesInternal)Property).PrivateFqdn = value; }

        /// <summary>Internal Acessors for Property</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IManagedClusterProperties Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IBaseManagedClusterInternal.Property { get => (this._property = this._property ?? new Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.ManagedClusterProperties()); set { {_property = value;} } }

        /// <summary>Internal Acessors for ProvisioningState</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IBaseManagedClusterInternal.ProvisioningState { get => ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IManagedClusterPropertiesInternal)Property).ProvisioningState; set => ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IManagedClusterPropertiesInternal)Property).ProvisioningState = value; }

        /// <summary>Internal Acessors for ServicePrincipalProfile</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IManagedClusterServicePrincipalProfile Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IBaseManagedClusterInternal.ServicePrincipalProfile { get => ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IManagedClusterPropertiesInternal)Property).ServicePrincipalProfile; set => ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IManagedClusterPropertiesInternal)Property).ServicePrincipalProfile = value; }

        /// <summary>Internal Acessors for WindowsProfile</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IManagedClusterWindowsProfile Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IBaseManagedClusterInternal.WindowsProfile { get => ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IManagedClusterPropertiesInternal)Property).WindowsProfile; set => ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IManagedClusterPropertiesInternal)Property).WindowsProfile = value; }

        /// <summary>
        /// An IP address assigned to the Kubernetes DNS service. It must be within the Kubernetes service address range specified
        /// in serviceCidr.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Aks.Origin(Microsoft.Azure.PowerShell.Cmdlets.Aks.PropertyOrigin.Inlined)]
        public string NetworkProfileDnsServiceIP { get => ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IManagedClusterPropertiesInternal)Property).NetworkProfileDnsServiceIP; set => ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IManagedClusterPropertiesInternal)Property).NetworkProfileDnsServiceIP = value ?? null; }

        /// <summary>
        /// A CIDR notation IP range assigned to the Docker bridge network. It must not overlap with any Subnet IP ranges or the Kubernetes
        /// service address range.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Aks.Origin(Microsoft.Azure.PowerShell.Cmdlets.Aks.PropertyOrigin.Inlined)]
        public string NetworkProfileDockerBridgeCidr { get => ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IManagedClusterPropertiesInternal)Property).NetworkProfileDockerBridgeCidr; set => ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IManagedClusterPropertiesInternal)Property).NetworkProfileDockerBridgeCidr = value ?? null; }

        /// <summary>The load balancer sku for the managed cluster.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Aks.Origin(Microsoft.Azure.PowerShell.Cmdlets.Aks.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.Aks.Support.LoadBalancerSku? NetworkProfileLoadBalancerSku { get => ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IManagedClusterPropertiesInternal)Property).NetworkProfileLoadBalancerSku; set => ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IManagedClusterPropertiesInternal)Property).NetworkProfileLoadBalancerSku = value ?? ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Support.LoadBalancerSku)""); }

        /// <summary>Network mode used for building Kubernetes network.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Aks.Origin(Microsoft.Azure.PowerShell.Cmdlets.Aks.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.Aks.Support.NetworkMode? NetworkProfileNetworkMode { get => ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IManagedClusterPropertiesInternal)Property).NetworkProfileNetworkMode; set => ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IManagedClusterPropertiesInternal)Property).NetworkProfileNetworkMode = value ?? ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Support.NetworkMode)""); }

        /// <summary>Network plugin used for building Kubernetes network.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Aks.Origin(Microsoft.Azure.PowerShell.Cmdlets.Aks.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.Aks.Support.NetworkPlugin? NetworkProfileNetworkPlugin { get => ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IManagedClusterPropertiesInternal)Property).NetworkProfileNetworkPlugin; set => ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IManagedClusterPropertiesInternal)Property).NetworkProfileNetworkPlugin = value ?? ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Support.NetworkPlugin)""); }

        /// <summary>Network policy used for building Kubernetes network.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Aks.Origin(Microsoft.Azure.PowerShell.Cmdlets.Aks.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.Aks.Support.NetworkPolicy? NetworkProfileNetworkPolicy { get => ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IManagedClusterPropertiesInternal)Property).NetworkProfileNetworkPolicy; set => ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IManagedClusterPropertiesInternal)Property).NetworkProfileNetworkPolicy = value ?? ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Support.NetworkPolicy)""); }

        /// <summary>The outbound (egress) routing method.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Aks.Origin(Microsoft.Azure.PowerShell.Cmdlets.Aks.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.Aks.Support.OutboundType? NetworkProfileOutboundType { get => ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IManagedClusterPropertiesInternal)Property).NetworkProfileOutboundType; set => ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IManagedClusterPropertiesInternal)Property).NetworkProfileOutboundType = value ?? ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Support.OutboundType)""); }

        /// <summary>A CIDR notation IP range from which to assign pod IPs when kubenet is used.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Aks.Origin(Microsoft.Azure.PowerShell.Cmdlets.Aks.PropertyOrigin.Inlined)]
        public string NetworkProfilePodCidr { get => ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IManagedClusterPropertiesInternal)Property).NetworkProfilePodCidr; set => ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IManagedClusterPropertiesInternal)Property).NetworkProfilePodCidr = value ?? null; }

        /// <summary>
        /// A CIDR notation IP range from which to assign service cluster IPs. It must not overlap with any Subnet IP ranges.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Aks.Origin(Microsoft.Azure.PowerShell.Cmdlets.Aks.PropertyOrigin.Inlined)]
        public string NetworkProfileServiceCidr { get => ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IManagedClusterPropertiesInternal)Property).NetworkProfileServiceCidr; set => ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IManagedClusterPropertiesInternal)Property).NetworkProfileServiceCidr = value ?? null; }

        /// <summary>Name of the resource group containing agent pool nodes.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Aks.Origin(Microsoft.Azure.PowerShell.Cmdlets.Aks.PropertyOrigin.Inlined)]
        public string NodeResourceGroup { get => ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IManagedClusterPropertiesInternal)Property).NodeResourceGroup; set => ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IManagedClusterPropertiesInternal)Property).NodeResourceGroup = value ?? null; }

        /// <summary>A list of public IP prefix resources.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Aks.Origin(Microsoft.Azure.PowerShell.Cmdlets.Aks.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IResourceReference[] OutboundIPPrefixPublicIpprefix { get => ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IManagedClusterPropertiesInternal)Property).OutboundIPPrefixPublicIpprefix; set => ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IManagedClusterPropertiesInternal)Property).OutboundIPPrefixPublicIpprefix = value ?? null /* arrayOf */; }

        /// <summary>A list of public IP resources.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Aks.Origin(Microsoft.Azure.PowerShell.Cmdlets.Aks.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IResourceReference[] OutboundIPPublicIP { get => ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IManagedClusterPropertiesInternal)Property).OutboundIPPublicIP; set => ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IManagedClusterPropertiesInternal)Property).OutboundIPPublicIP = value ?? null /* arrayOf */; }

        /// <summary>Tells whether the cluster is Running or Stopped</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Aks.Origin(Microsoft.Azure.PowerShell.Cmdlets.Aks.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.Aks.Support.Code? PowerStateCode { get => ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IManagedClusterPropertiesInternal)Property).PowerStateCode; set => ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IManagedClusterPropertiesInternal)Property).PowerStateCode = value ?? ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Support.Code)""); }

        /// <summary>FQDN of private cluster.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Aks.Origin(Microsoft.Azure.PowerShell.Cmdlets.Aks.PropertyOrigin.Inlined)]
        public string PrivateFqdn { get => ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IManagedClusterPropertiesInternal)Property).PrivateFqdn; }

        /// <summary>Backing field for <see cref="Property" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IManagedClusterProperties _property;

        /// <summary>Properties of a managed cluster.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Aks.Origin(Microsoft.Azure.PowerShell.Cmdlets.Aks.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IManagedClusterProperties Property { get => (this._property = this._property ?? new Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.ManagedClusterProperties()); set => this._property = value; }

        /// <summary>
        /// The current deployment or provisioning state, which only appears in the response.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Aks.Origin(Microsoft.Azure.PowerShell.Cmdlets.Aks.PropertyOrigin.Inlined)]
        public string ProvisioningState { get => ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IManagedClusterPropertiesInternal)Property).ProvisioningState; }

        /// <summary>The ID for the service principal.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Aks.Origin(Microsoft.Azure.PowerShell.Cmdlets.Aks.PropertyOrigin.Inlined)]
        public string ServicePrincipalProfileClientId { get => ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IManagedClusterPropertiesInternal)Property).ServicePrincipalProfileClientId; set => ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IManagedClusterPropertiesInternal)Property).ServicePrincipalProfileClientId = value ?? null; }

        /// <summary>The secret password associated with the service principal in plain text.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Aks.Origin(Microsoft.Azure.PowerShell.Cmdlets.Aks.PropertyOrigin.Inlined)]
        public string ServicePrincipalProfileSecret { get => ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IManagedClusterPropertiesInternal)Property).ServicePrincipalProfileSecret; set => ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IManagedClusterPropertiesInternal)Property).ServicePrincipalProfileSecret = value ?? null; }

        /// <summary>
        /// The list of SSH public keys used to authenticate with Linux-based VMs. Only expect one key specified.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Aks.Origin(Microsoft.Azure.PowerShell.Cmdlets.Aks.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IContainerServiceSshPublicKey[] SshPublicKey { get => ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IManagedClusterPropertiesInternal)Property).SshPublicKey; set => ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IManagedClusterPropertiesInternal)Property).SshPublicKey = value ?? null /* arrayOf */; }

        /// <summary>
        /// Specifies the password of the administrator account. <br><br> **Minimum-length:** 8 characters <br><br> **Max-length:**
        /// 123 characters <br><br> **Complexity requirements:** 3 out of 4 conditions below need to be fulfilled <br> Has lower characters
        /// <br>Has upper characters <br> Has a digit <br> Has a special character (Regex match [\W_]) <br><br> **Disallowed values:**
        /// "abc@123", "P@$$w0rd", "P@ssw0rd", "P@ssword123", "Pa$$word", "pass@word1", "Password!", "Password1", "Password22", "iloveyou!"
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Aks.Origin(Microsoft.Azure.PowerShell.Cmdlets.Aks.PropertyOrigin.Inlined)]
        public string WindowProfileAdminPassword { get => ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IManagedClusterPropertiesInternal)Property).WindowProfileAdminPassword; set => ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IManagedClusterPropertiesInternal)Property).WindowProfileAdminPassword = value ?? null; }

        /// <summary>
        /// Specifies the name of the administrator account. <br><br> **restriction:** Cannot end in "." <br><br> **Disallowed values:**
        /// "administrator", "admin", "user", "user1", "test", "user2", "test1", "user3", "admin1", "1", "123", "a", "actuser", "adm",
        /// "admin2", "aspnet", "backup", "console", "david", "guest", "john", "owner", "root", "server", "sql", "support", "support_388945a0",
        /// "sys", "test2", "test3", "user4", "user5". <br><br> **Minimum-length:** 1 character <br><br> **Max-length:** 20 characters
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Aks.Origin(Microsoft.Azure.PowerShell.Cmdlets.Aks.PropertyOrigin.Inlined)]
        public string WindowProfileAdminUsername { get => ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IManagedClusterPropertiesInternal)Property).WindowProfileAdminUsername; set => ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IManagedClusterPropertiesInternal)Property).WindowProfileAdminUsername = value ?? null; }

        /// <summary>
        /// The licenseType to use for Windows VMs. Windows_Server is used to enable Azure Hybrid User Benefits for Windows VMs.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Aks.Origin(Microsoft.Azure.PowerShell.Cmdlets.Aks.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.Aks.Support.LicenseType? WindowProfileLicenseType { get => ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IManagedClusterPropertiesInternal)Property).WindowProfileLicenseType; set => ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IManagedClusterPropertiesInternal)Property).WindowProfileLicenseType = value ?? ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Support.LicenseType)""); }

        /// <summary>Creates an new <see cref="BaseManagedCluster" /> instance.</summary>
        public BaseManagedCluster()
        {

        }
    }
    public partial interface IBaseManagedCluster :
        Microsoft.Azure.PowerShell.Cmdlets.Aks.Runtime.IJsonSerializable
    {
        /// <summary>AAD group object IDs that will have admin role of the cluster.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Aks.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"AAD group object IDs that will have admin role of the cluster.",
        SerializedName = @"adminGroupObjectIDs",
        PossibleTypes = new [] { typeof(string) })]
        string[] AadProfileAdminGroupObjectID { get; set; }
        /// <summary>The client AAD application ID.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Aks.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The client AAD application ID.",
        SerializedName = @"clientAppID",
        PossibleTypes = new [] { typeof(string) })]
        string AadProfileClientAppId { get; set; }
        /// <summary>Whether to enable Azure RBAC for Kubernetes authorization.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Aks.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Whether to enable Azure RBAC for Kubernetes authorization.",
        SerializedName = @"enableAzureRBAC",
        PossibleTypes = new [] { typeof(bool) })]
        bool? AadProfileEnableAzureRbac { get; set; }
        /// <summary>Whether to enable managed AAD.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Aks.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Whether to enable managed AAD.",
        SerializedName = @"managed",
        PossibleTypes = new [] { typeof(bool) })]
        bool? AadProfileManaged { get; set; }
        /// <summary>The server AAD application ID.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Aks.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The server AAD application ID.",
        SerializedName = @"serverAppID",
        PossibleTypes = new [] { typeof(string) })]
        string AadProfileServerAppId { get; set; }
        /// <summary>The server AAD application secret.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Aks.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The server AAD application secret.",
        SerializedName = @"serverAppSecret",
        PossibleTypes = new [] { typeof(string) })]
        string AadProfileServerAppSecret { get; set; }
        /// <summary>
        /// The AAD tenant ID to use for authentication. If not specified, will use the tenant of the deployment subscription.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Aks.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The AAD tenant ID to use for authentication. If not specified, will use the tenant of the deployment subscription.",
        SerializedName = @"tenantID",
        PossibleTypes = new [] { typeof(string) })]
        string AadProfileTenantId { get; set; }
        /// <summary>Profile of managed cluster add-on.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Aks.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Profile of managed cluster add-on.",
        SerializedName = @"addonProfiles",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IManagedClusterPropertiesAddonProfiles) })]
        Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IManagedClusterPropertiesAddonProfiles AddonProfile { get; set; }
        /// <summary>Properties of the agent pool.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Aks.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Properties of the agent pool.",
        SerializedName = @"agentPoolProfiles",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IManagedClusterAgentPoolProfile) })]
        Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IManagedClusterAgentPoolProfile[] AgentPoolProfile { get; set; }
        /// <summary>Authorized IP Ranges to kubernetes API server.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Aks.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Authorized IP Ranges to kubernetes API server.",
        SerializedName = @"authorizedIPRanges",
        PossibleTypes = new [] { typeof(string) })]
        string[] ApiServerAccessProfileAuthorizedIPRange { get; set; }
        /// <summary>Whether to create the cluster as a private cluster or not.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Aks.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Whether to create the cluster as a private cluster or not.",
        SerializedName = @"enablePrivateCluster",
        PossibleTypes = new [] { typeof(bool) })]
        bool? ApiServerAccessProfileEnablePrivateCluster { get; set; }

        [Microsoft.Azure.PowerShell.Cmdlets.Aks.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"",
        SerializedName = @"balance-similar-node-groups",
        PossibleTypes = new [] { typeof(string) })]
        string AutoScalerProfileBalanceSimilarNodeGroup { get; set; }

        [Microsoft.Azure.PowerShell.Cmdlets.Aks.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"",
        SerializedName = @"expander",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Aks.Support.Expander) })]
        Microsoft.Azure.PowerShell.Cmdlets.Aks.Support.Expander? AutoScalerProfileExpander { get; set; }

        [Microsoft.Azure.PowerShell.Cmdlets.Aks.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"",
        SerializedName = @"max-empty-bulk-delete",
        PossibleTypes = new [] { typeof(string) })]
        string AutoScalerProfileMaxEmptyBulkDelete { get; set; }

        [Microsoft.Azure.PowerShell.Cmdlets.Aks.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"",
        SerializedName = @"max-graceful-termination-sec",
        PossibleTypes = new [] { typeof(string) })]
        string AutoScalerProfileMaxGracefulTerminationSec { get; set; }

        [Microsoft.Azure.PowerShell.Cmdlets.Aks.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"",
        SerializedName = @"max-total-unready-percentage",
        PossibleTypes = new [] { typeof(string) })]
        string AutoScalerProfileMaxTotalUnreadyPercentage { get; set; }

        [Microsoft.Azure.PowerShell.Cmdlets.Aks.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"",
        SerializedName = @"new-pod-scale-up-delay",
        PossibleTypes = new [] { typeof(string) })]
        string AutoScalerProfileNewPodScaleUpDelay { get; set; }

        [Microsoft.Azure.PowerShell.Cmdlets.Aks.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"",
        SerializedName = @"ok-total-unready-count",
        PossibleTypes = new [] { typeof(string) })]
        string AutoScalerProfileOkTotalUnreadyCount { get; set; }

        [Microsoft.Azure.PowerShell.Cmdlets.Aks.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"",
        SerializedName = @"scale-down-delay-after-add",
        PossibleTypes = new [] { typeof(string) })]
        string AutoScalerProfileScaleDownDelayAfterAdd { get; set; }

        [Microsoft.Azure.PowerShell.Cmdlets.Aks.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"",
        SerializedName = @"scale-down-delay-after-delete",
        PossibleTypes = new [] { typeof(string) })]
        string AutoScalerProfileScaleDownDelayAfterDelete { get; set; }

        [Microsoft.Azure.PowerShell.Cmdlets.Aks.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"",
        SerializedName = @"scale-down-delay-after-failure",
        PossibleTypes = new [] { typeof(string) })]
        string AutoScalerProfileScaleDownDelayAfterFailure { get; set; }

        [Microsoft.Azure.PowerShell.Cmdlets.Aks.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"",
        SerializedName = @"scale-down-unneeded-time",
        PossibleTypes = new [] { typeof(string) })]
        string AutoScalerProfileScaleDownUnneededTime { get; set; }

        [Microsoft.Azure.PowerShell.Cmdlets.Aks.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"",
        SerializedName = @"scale-down-unready-time",
        PossibleTypes = new [] { typeof(string) })]
        string AutoScalerProfileScaleDownUnreadyTime { get; set; }

        [Microsoft.Azure.PowerShell.Cmdlets.Aks.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"",
        SerializedName = @"scale-down-utilization-threshold",
        PossibleTypes = new [] { typeof(string) })]
        string AutoScalerProfileScaleDownUtilizationThreshold { get; set; }

        [Microsoft.Azure.PowerShell.Cmdlets.Aks.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"",
        SerializedName = @"scan-interval",
        PossibleTypes = new [] { typeof(string) })]
        string AutoScalerProfileScanInterval { get; set; }

        [Microsoft.Azure.PowerShell.Cmdlets.Aks.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"",
        SerializedName = @"skip-nodes-with-local-storage",
        PossibleTypes = new [] { typeof(string) })]
        string AutoScalerProfileSkipNodesWithLocalStorage { get; set; }

        [Microsoft.Azure.PowerShell.Cmdlets.Aks.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"",
        SerializedName = @"skip-nodes-with-system-pods",
        PossibleTypes = new [] { typeof(string) })]
        string AutoScalerProfileSkipNodesWithSystemPod { get; set; }
        /// <summary>ResourceId of the disk encryption set to use for enabling encryption at rest.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Aks.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"ResourceId of the disk encryption set to use for enabling encryption at rest.",
        SerializedName = @"diskEncryptionSetID",
        PossibleTypes = new [] { typeof(string) })]
        string DiskEncryptionSetId { get; set; }
        /// <summary>DNS prefix specified when creating the managed cluster.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Aks.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"DNS prefix specified when creating the managed cluster.",
        SerializedName = @"dnsPrefix",
        PossibleTypes = new [] { typeof(string) })]
        string DnsPrefix { get; set; }
        /// <summary>
        /// (DEPRECATING) Whether to enable Kubernetes pod security policy (preview). This feature is set for removal on October 15th,
        /// 2020. Learn more at aka.ms/aks/azpodpolicy.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Aks.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"(DEPRECATING) Whether to enable Kubernetes pod security policy (preview). This feature is set for removal on October 15th, 2020. Learn more at aka.ms/aks/azpodpolicy.",
        SerializedName = @"enablePodSecurityPolicy",
        PossibleTypes = new [] { typeof(bool) })]
        bool? EnablePodSecurityPolicy { get; set; }
        /// <summary>Whether to enable Kubernetes Role-Based Access Control.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Aks.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Whether to enable Kubernetes Role-Based Access Control.",
        SerializedName = @"enableRBAC",
        PossibleTypes = new [] { typeof(bool) })]
        bool? EnableRbac { get; set; }
        /// <summary>FQDN for the master pool.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Aks.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"FQDN for the master pool.",
        SerializedName = @"fqdn",
        PossibleTypes = new [] { typeof(string) })]
        string Fqdn { get;  }
        /// <summary>
        /// The principal id of the system assigned identity which is used by master components.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Aks.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"The principal id of the system assigned identity which is used by master components.",
        SerializedName = @"principalId",
        PossibleTypes = new [] { typeof(string) })]
        string IdentityPrincipalId { get;  }
        /// <summary>Identities associated with the cluster.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Aks.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Identities associated with the cluster.",
        SerializedName = @"identityProfile",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IManagedClusterPropertiesIdentityProfile) })]
        Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IManagedClusterPropertiesIdentityProfile IdentityProfile { get; set; }
        /// <summary>
        /// The tenant id of the system assigned identity which is used by master components.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Aks.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"The tenant id of the system assigned identity which is used by master components.",
        SerializedName = @"tenantId",
        PossibleTypes = new [] { typeof(string) })]
        string IdentityTenantId { get;  }
        /// <summary>
        /// The type of identity used for the managed cluster. Type 'SystemAssigned' will use an implicitly created identity in master
        /// components and an auto-created user assigned identity in MC_ resource group in agent nodes. Type 'None' will not use MSI
        /// for the managed cluster, service principal will be used instead.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Aks.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The type of identity used for the managed cluster. Type 'SystemAssigned' will use an implicitly created identity in master components and an auto-created user assigned identity in MC_ resource group in agent nodes. Type 'None' will not use MSI for the managed cluster, service principal will be used instead.",
        SerializedName = @"type",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Aks.Support.ResourceIdentityType) })]
        Microsoft.Azure.PowerShell.Cmdlets.Aks.Support.ResourceIdentityType? IdentityType { get; set; }
        /// <summary>
        /// The user identity associated with the managed cluster. This identity will be used in control plane and only one user assigned
        /// identity is allowed. The user identity dictionary key references will be ARM resource ids in the form: '/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ManagedIdentity/userAssignedIdentities/{identityName}'.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Aks.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The user identity associated with the managed cluster. This identity will be used in control plane and only one user assigned identity is allowed. The user identity dictionary key references will be ARM resource ids in the form: '/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ManagedIdentity/userAssignedIdentities/{identityName}'.",
        SerializedName = @"userAssignedIdentities",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IManagedClusterIdentityUserAssignedIdentities) })]
        Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IManagedClusterIdentityUserAssignedIdentities IdentityUserAssignedIdentity { get; set; }
        /// <summary>Version of Kubernetes specified when creating the managed cluster.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Aks.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Version of Kubernetes specified when creating the managed cluster.",
        SerializedName = @"kubernetesVersion",
        PossibleTypes = new [] { typeof(string) })]
        string KubernetesVersion { get; set; }
        /// <summary>The administrator username to use for Linux VMs.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Aks.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The administrator username to use for Linux VMs.",
        SerializedName = @"adminUsername",
        PossibleTypes = new [] { typeof(string) })]
        string LinuxProfileAdminUsername { get; set; }
        /// <summary>
        /// Desired number of allocated SNAT ports per VM. Allowed values must be in the range of 0 to 64000 (inclusive). The default
        /// value is 0 which results in Azure dynamically allocating ports.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Aks.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Desired number of allocated SNAT ports per VM. Allowed values must be in the range of 0 to 64000 (inclusive). The default value is 0 which results in Azure dynamically allocating ports.",
        SerializedName = @"allocatedOutboundPorts",
        PossibleTypes = new [] { typeof(int) })]
        int? LoadBalancerProfileAllocatedOutboundPort { get; set; }
        /// <summary>The effective outbound IP resources of the cluster load balancer.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Aks.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The effective outbound IP resources of the cluster load balancer.",
        SerializedName = @"effectiveOutboundIPs",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IResourceReference) })]
        Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IResourceReference[] LoadBalancerProfileEffectiveOutboundIP { get; set; }
        /// <summary>
        /// Desired outbound flow idle timeout in minutes. Allowed values must be in the range of 4 to 120 (inclusive). The default
        /// value is 30 minutes.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Aks.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Desired outbound flow idle timeout in minutes. Allowed values must be in the range of 4 to 120 (inclusive). The default value is 30 minutes.",
        SerializedName = @"idleTimeoutInMinutes",
        PossibleTypes = new [] { typeof(int) })]
        int? LoadBalancerProfileIdleTimeoutInMinute { get; set; }
        /// <summary>
        /// Desired number of outbound IP created/managed by Azure for the cluster load balancer. Allowed values must be in the range
        /// of 1 to 100 (inclusive). The default value is 1.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Aks.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Desired number of outbound IP created/managed by Azure for the cluster load balancer. Allowed values must be in the range of 1 to 100 (inclusive). The default value is 1. ",
        SerializedName = @"count",
        PossibleTypes = new [] { typeof(int) })]
        int? ManagedOutboundIPCount { get; set; }
        /// <summary>The max number of agent pools for the managed cluster.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Aks.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"The max number of agent pools for the managed cluster.",
        SerializedName = @"maxAgentPools",
        PossibleTypes = new [] { typeof(int) })]
        int? MaxAgentPool { get;  }
        /// <summary>
        /// An IP address assigned to the Kubernetes DNS service. It must be within the Kubernetes service address range specified
        /// in serviceCidr.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Aks.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"An IP address assigned to the Kubernetes DNS service. It must be within the Kubernetes service address range specified in serviceCidr.",
        SerializedName = @"dnsServiceIP",
        PossibleTypes = new [] { typeof(string) })]
        string NetworkProfileDnsServiceIP { get; set; }
        /// <summary>
        /// A CIDR notation IP range assigned to the Docker bridge network. It must not overlap with any Subnet IP ranges or the Kubernetes
        /// service address range.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Aks.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"A CIDR notation IP range assigned to the Docker bridge network. It must not overlap with any Subnet IP ranges or the Kubernetes service address range.",
        SerializedName = @"dockerBridgeCidr",
        PossibleTypes = new [] { typeof(string) })]
        string NetworkProfileDockerBridgeCidr { get; set; }
        /// <summary>The load balancer sku for the managed cluster.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Aks.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The load balancer sku for the managed cluster.",
        SerializedName = @"loadBalancerSku",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Aks.Support.LoadBalancerSku) })]
        Microsoft.Azure.PowerShell.Cmdlets.Aks.Support.LoadBalancerSku? NetworkProfileLoadBalancerSku { get; set; }
        /// <summary>Network mode used for building Kubernetes network.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Aks.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Network mode used for building Kubernetes network.",
        SerializedName = @"networkMode",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Aks.Support.NetworkMode) })]
        Microsoft.Azure.PowerShell.Cmdlets.Aks.Support.NetworkMode? NetworkProfileNetworkMode { get; set; }
        /// <summary>Network plugin used for building Kubernetes network.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Aks.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Network plugin used for building Kubernetes network.",
        SerializedName = @"networkPlugin",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Aks.Support.NetworkPlugin) })]
        Microsoft.Azure.PowerShell.Cmdlets.Aks.Support.NetworkPlugin? NetworkProfileNetworkPlugin { get; set; }
        /// <summary>Network policy used for building Kubernetes network.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Aks.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Network policy used for building Kubernetes network.",
        SerializedName = @"networkPolicy",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Aks.Support.NetworkPolicy) })]
        Microsoft.Azure.PowerShell.Cmdlets.Aks.Support.NetworkPolicy? NetworkProfileNetworkPolicy { get; set; }
        /// <summary>The outbound (egress) routing method.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Aks.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The outbound (egress) routing method.",
        SerializedName = @"outboundType",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Aks.Support.OutboundType) })]
        Microsoft.Azure.PowerShell.Cmdlets.Aks.Support.OutboundType? NetworkProfileOutboundType { get; set; }
        /// <summary>A CIDR notation IP range from which to assign pod IPs when kubenet is used.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Aks.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"A CIDR notation IP range from which to assign pod IPs when kubenet is used.",
        SerializedName = @"podCidr",
        PossibleTypes = new [] { typeof(string) })]
        string NetworkProfilePodCidr { get; set; }
        /// <summary>
        /// A CIDR notation IP range from which to assign service cluster IPs. It must not overlap with any Subnet IP ranges.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Aks.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"A CIDR notation IP range from which to assign service cluster IPs. It must not overlap with any Subnet IP ranges.",
        SerializedName = @"serviceCidr",
        PossibleTypes = new [] { typeof(string) })]
        string NetworkProfileServiceCidr { get; set; }
        /// <summary>Name of the resource group containing agent pool nodes.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Aks.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Name of the resource group containing agent pool nodes.",
        SerializedName = @"nodeResourceGroup",
        PossibleTypes = new [] { typeof(string) })]
        string NodeResourceGroup { get; set; }
        /// <summary>A list of public IP prefix resources.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Aks.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"A list of public IP prefix resources.",
        SerializedName = @"publicIPPrefixes",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IResourceReference) })]
        Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IResourceReference[] OutboundIPPrefixPublicIpprefix { get; set; }
        /// <summary>A list of public IP resources.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Aks.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"A list of public IP resources.",
        SerializedName = @"publicIPs",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IResourceReference) })]
        Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IResourceReference[] OutboundIPPublicIP { get; set; }
        /// <summary>Tells whether the cluster is Running or Stopped</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Aks.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Tells whether the cluster is Running or Stopped",
        SerializedName = @"code",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Aks.Support.Code) })]
        Microsoft.Azure.PowerShell.Cmdlets.Aks.Support.Code? PowerStateCode { get; set; }
        /// <summary>FQDN of private cluster.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Aks.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"FQDN of private cluster.",
        SerializedName = @"privateFQDN",
        PossibleTypes = new [] { typeof(string) })]
        string PrivateFqdn { get;  }
        /// <summary>
        /// The current deployment or provisioning state, which only appears in the response.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Aks.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"The current deployment or provisioning state, which only appears in the response.",
        SerializedName = @"provisioningState",
        PossibleTypes = new [] { typeof(string) })]
        string ProvisioningState { get;  }
        /// <summary>The ID for the service principal.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Aks.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The ID for the service principal.",
        SerializedName = @"clientId",
        PossibleTypes = new [] { typeof(string) })]
        string ServicePrincipalProfileClientId { get; set; }
        /// <summary>The secret password associated with the service principal in plain text.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Aks.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The secret password associated with the service principal in plain text.",
        SerializedName = @"secret",
        PossibleTypes = new [] { typeof(string) })]
        string ServicePrincipalProfileSecret { get; set; }
        /// <summary>
        /// The list of SSH public keys used to authenticate with Linux-based VMs. Only expect one key specified.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Aks.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The list of SSH public keys used to authenticate with Linux-based VMs. Only expect one key specified.",
        SerializedName = @"publicKeys",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IContainerServiceSshPublicKey) })]
        Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IContainerServiceSshPublicKey[] SshPublicKey { get; set; }
        /// <summary>
        /// Specifies the password of the administrator account. <br><br> **Minimum-length:** 8 characters <br><br> **Max-length:**
        /// 123 characters <br><br> **Complexity requirements:** 3 out of 4 conditions below need to be fulfilled <br> Has lower characters
        /// <br>Has upper characters <br> Has a digit <br> Has a special character (Regex match [\W_]) <br><br> **Disallowed values:**
        /// "abc@123", "P@$$w0rd", "P@ssw0rd", "P@ssword123", "Pa$$word", "pass@word1", "Password!", "Password1", "Password22", "iloveyou!"
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Aks.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Specifies the password of the administrator account. <br><br> **Minimum-length:** 8 characters <br><br> **Max-length:** 123 characters <br><br> **Complexity requirements:** 3 out of 4 conditions below need to be fulfilled <br> Has lower characters <br>Has upper characters <br> Has a digit <br> Has a special character (Regex match [\W_]) <br><br> **Disallowed values:** ""abc@123"", ""P@$$w0rd"", ""P@ssw0rd"", ""P@ssword123"", ""Pa$$word"", ""pass@word1"", ""Password!"", ""Password1"", ""Password22"", ""iloveyou!""",
        SerializedName = @"adminPassword",
        PossibleTypes = new [] { typeof(string) })]
        string WindowProfileAdminPassword { get; set; }
        /// <summary>
        /// Specifies the name of the administrator account. <br><br> **restriction:** Cannot end in "." <br><br> **Disallowed values:**
        /// "administrator", "admin", "user", "user1", "test", "user2", "test1", "user3", "admin1", "1", "123", "a", "actuser", "adm",
        /// "admin2", "aspnet", "backup", "console", "david", "guest", "john", "owner", "root", "server", "sql", "support", "support_388945a0",
        /// "sys", "test2", "test3", "user4", "user5". <br><br> **Minimum-length:** 1 character <br><br> **Max-length:** 20 characters
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Aks.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Specifies the name of the administrator account. <br><br> **restriction:** Cannot end in ""."" <br><br> **Disallowed values:** ""administrator"", ""admin"", ""user"", ""user1"", ""test"", ""user2"", ""test1"", ""user3"", ""admin1"", ""1"", ""123"", ""a"", ""actuser"", ""adm"", ""admin2"", ""aspnet"", ""backup"", ""console"", ""david"", ""guest"", ""john"", ""owner"", ""root"", ""server"", ""sql"", ""support"", ""support_388945a0"", ""sys"", ""test2"", ""test3"", ""user4"", ""user5"". <br><br> **Minimum-length:** 1 character <br><br> **Max-length:** 20 characters",
        SerializedName = @"adminUsername",
        PossibleTypes = new [] { typeof(string) })]
        string WindowProfileAdminUsername { get; set; }
        /// <summary>
        /// The licenseType to use for Windows VMs. Windows_Server is used to enable Azure Hybrid User Benefits for Windows VMs.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Aks.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The licenseType to use for Windows VMs. Windows_Server is used to enable Azure Hybrid User Benefits for Windows VMs.",
        SerializedName = @"licenseType",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Aks.Support.LicenseType) })]
        Microsoft.Azure.PowerShell.Cmdlets.Aks.Support.LicenseType? WindowProfileLicenseType { get; set; }

    }
    internal partial interface IBaseManagedClusterInternal

    {
        /// <summary>Profile of Azure Active Directory configuration.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IManagedClusterAadProfile AadProfile { get; set; }
        /// <summary>AAD group object IDs that will have admin role of the cluster.</summary>
        string[] AadProfileAdminGroupObjectID { get; set; }
        /// <summary>The client AAD application ID.</summary>
        string AadProfileClientAppId { get; set; }
        /// <summary>Whether to enable Azure RBAC for Kubernetes authorization.</summary>
        bool? AadProfileEnableAzureRbac { get; set; }
        /// <summary>Whether to enable managed AAD.</summary>
        bool? AadProfileManaged { get; set; }
        /// <summary>The server AAD application ID.</summary>
        string AadProfileServerAppId { get; set; }
        /// <summary>The server AAD application secret.</summary>
        string AadProfileServerAppSecret { get; set; }
        /// <summary>
        /// The AAD tenant ID to use for authentication. If not specified, will use the tenant of the deployment subscription.
        /// </summary>
        string AadProfileTenantId { get; set; }
        /// <summary>Profile of managed cluster add-on.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IManagedClusterPropertiesAddonProfiles AddonProfile { get; set; }
        /// <summary>Properties of the agent pool.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IManagedClusterAgentPoolProfile[] AgentPoolProfile { get; set; }
        /// <summary>Access profile for managed cluster API server.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IManagedClusterApiServerAccessProfile ApiServerAccessProfile { get; set; }
        /// <summary>Authorized IP Ranges to kubernetes API server.</summary>
        string[] ApiServerAccessProfileAuthorizedIPRange { get; set; }
        /// <summary>Whether to create the cluster as a private cluster or not.</summary>
        bool? ApiServerAccessProfileEnablePrivateCluster { get; set; }
        /// <summary>Parameters to be applied to the cluster-autoscaler when enabled</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IManagedClusterPropertiesAutoScalerProfile AutoScalerProfile { get; set; }

        string AutoScalerProfileBalanceSimilarNodeGroup { get; set; }

        Microsoft.Azure.PowerShell.Cmdlets.Aks.Support.Expander? AutoScalerProfileExpander { get; set; }

        string AutoScalerProfileMaxEmptyBulkDelete { get; set; }

        string AutoScalerProfileMaxGracefulTerminationSec { get; set; }

        string AutoScalerProfileMaxTotalUnreadyPercentage { get; set; }

        string AutoScalerProfileNewPodScaleUpDelay { get; set; }

        string AutoScalerProfileOkTotalUnreadyCount { get; set; }

        string AutoScalerProfileScaleDownDelayAfterAdd { get; set; }

        string AutoScalerProfileScaleDownDelayAfterDelete { get; set; }

        string AutoScalerProfileScaleDownDelayAfterFailure { get; set; }

        string AutoScalerProfileScaleDownUnneededTime { get; set; }

        string AutoScalerProfileScaleDownUnreadyTime { get; set; }

        string AutoScalerProfileScaleDownUtilizationThreshold { get; set; }

        string AutoScalerProfileScanInterval { get; set; }

        string AutoScalerProfileSkipNodesWithLocalStorage { get; set; }

        string AutoScalerProfileSkipNodesWithSystemPod { get; set; }
        /// <summary>ResourceId of the disk encryption set to use for enabling encryption at rest.</summary>
        string DiskEncryptionSetId { get; set; }
        /// <summary>DNS prefix specified when creating the managed cluster.</summary>
        string DnsPrefix { get; set; }
        /// <summary>
        /// (DEPRECATING) Whether to enable Kubernetes pod security policy (preview). This feature is set for removal on October 15th,
        /// 2020. Learn more at aka.ms/aks/azpodpolicy.
        /// </summary>
        bool? EnablePodSecurityPolicy { get; set; }
        /// <summary>Whether to enable Kubernetes Role-Based Access Control.</summary>
        bool? EnableRbac { get; set; }
        /// <summary>FQDN for the master pool.</summary>
        string Fqdn { get; set; }
        /// <summary>The identity of the managed cluster, if configured.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IManagedClusterIdentity Identity { get; set; }
        /// <summary>
        /// The principal id of the system assigned identity which is used by master components.
        /// </summary>
        string IdentityPrincipalId { get; set; }
        /// <summary>Identities associated with the cluster.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IManagedClusterPropertiesIdentityProfile IdentityProfile { get; set; }
        /// <summary>
        /// The tenant id of the system assigned identity which is used by master components.
        /// </summary>
        string IdentityTenantId { get; set; }
        /// <summary>
        /// The type of identity used for the managed cluster. Type 'SystemAssigned' will use an implicitly created identity in master
        /// components and an auto-created user assigned identity in MC_ resource group in agent nodes. Type 'None' will not use MSI
        /// for the managed cluster, service principal will be used instead.
        /// </summary>
        Microsoft.Azure.PowerShell.Cmdlets.Aks.Support.ResourceIdentityType? IdentityType { get; set; }
        /// <summary>
        /// The user identity associated with the managed cluster. This identity will be used in control plane and only one user assigned
        /// identity is allowed. The user identity dictionary key references will be ARM resource ids in the form: '/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ManagedIdentity/userAssignedIdentities/{identityName}'.
        /// </summary>
        Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IManagedClusterIdentityUserAssignedIdentities IdentityUserAssignedIdentity { get; set; }
        /// <summary>Version of Kubernetes specified when creating the managed cluster.</summary>
        string KubernetesVersion { get; set; }
        /// <summary>Profile for Linux VMs in the container service cluster.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IContainerServiceLinuxProfile LinuxProfile { get; set; }
        /// <summary>The administrator username to use for Linux VMs.</summary>
        string LinuxProfileAdminUsername { get; set; }
        /// <summary>SSH configuration for Linux-based VMs running on Azure.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IContainerServiceSshConfiguration LinuxProfileSsh { get; set; }
        /// <summary>
        /// Desired number of allocated SNAT ports per VM. Allowed values must be in the range of 0 to 64000 (inclusive). The default
        /// value is 0 which results in Azure dynamically allocating ports.
        /// </summary>
        int? LoadBalancerProfileAllocatedOutboundPort { get; set; }
        /// <summary>The effective outbound IP resources of the cluster load balancer.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IResourceReference[] LoadBalancerProfileEffectiveOutboundIP { get; set; }
        /// <summary>
        /// Desired outbound flow idle timeout in minutes. Allowed values must be in the range of 4 to 120 (inclusive). The default
        /// value is 30 minutes.
        /// </summary>
        int? LoadBalancerProfileIdleTimeoutInMinute { get; set; }
        /// <summary>Desired managed outbound IPs for the cluster load balancer.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IManagedClusterLoadBalancerProfileManagedOutboundIPs LoadBalancerProfileManagedOutboundIP { get; set; }
        /// <summary>Desired outbound IP resources for the cluster load balancer.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IManagedClusterLoadBalancerProfileOutboundIPs LoadBalancerProfileOutboundIP { get; set; }
        /// <summary>Desired outbound IP Prefix resources for the cluster load balancer.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IManagedClusterLoadBalancerProfileOutboundIPPrefixes LoadBalancerProfileOutboundIPPrefix { get; set; }
        /// <summary>
        /// Desired number of outbound IP created/managed by Azure for the cluster load balancer. Allowed values must be in the range
        /// of 1 to 100 (inclusive). The default value is 1.
        /// </summary>
        int? ManagedOutboundIPCount { get; set; }
        /// <summary>The max number of agent pools for the managed cluster.</summary>
        int? MaxAgentPool { get; set; }
        /// <summary>Profile of network configuration.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IContainerServiceNetworkProfile NetworkProfile { get; set; }
        /// <summary>
        /// An IP address assigned to the Kubernetes DNS service. It must be within the Kubernetes service address range specified
        /// in serviceCidr.
        /// </summary>
        string NetworkProfileDnsServiceIP { get; set; }
        /// <summary>
        /// A CIDR notation IP range assigned to the Docker bridge network. It must not overlap with any Subnet IP ranges or the Kubernetes
        /// service address range.
        /// </summary>
        string NetworkProfileDockerBridgeCidr { get; set; }
        /// <summary>Profile of the cluster load balancer.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IManagedClusterLoadBalancerProfile NetworkProfileLoadBalancerProfile { get; set; }
        /// <summary>The load balancer sku for the managed cluster.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Aks.Support.LoadBalancerSku? NetworkProfileLoadBalancerSku { get; set; }
        /// <summary>Network mode used for building Kubernetes network.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Aks.Support.NetworkMode? NetworkProfileNetworkMode { get; set; }
        /// <summary>Network plugin used for building Kubernetes network.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Aks.Support.NetworkPlugin? NetworkProfileNetworkPlugin { get; set; }
        /// <summary>Network policy used for building Kubernetes network.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Aks.Support.NetworkPolicy? NetworkProfileNetworkPolicy { get; set; }
        /// <summary>The outbound (egress) routing method.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Aks.Support.OutboundType? NetworkProfileOutboundType { get; set; }
        /// <summary>A CIDR notation IP range from which to assign pod IPs when kubenet is used.</summary>
        string NetworkProfilePodCidr { get; set; }
        /// <summary>
        /// A CIDR notation IP range from which to assign service cluster IPs. It must not overlap with any Subnet IP ranges.
        /// </summary>
        string NetworkProfileServiceCidr { get; set; }
        /// <summary>Name of the resource group containing agent pool nodes.</summary>
        string NodeResourceGroup { get; set; }
        /// <summary>A list of public IP prefix resources.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IResourceReference[] OutboundIPPrefixPublicIpprefix { get; set; }
        /// <summary>A list of public IP resources.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IResourceReference[] OutboundIPPublicIP { get; set; }
        /// <summary>Represents the Power State of the cluster</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IPowerState PowerState { get; set; }
        /// <summary>Tells whether the cluster is Running or Stopped</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Aks.Support.Code? PowerStateCode { get; set; }
        /// <summary>FQDN of private cluster.</summary>
        string PrivateFqdn { get; set; }
        /// <summary>Properties of a managed cluster.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IManagedClusterProperties Property { get; set; }
        /// <summary>
        /// The current deployment or provisioning state, which only appears in the response.
        /// </summary>
        string ProvisioningState { get; set; }
        /// <summary>
        /// Information about a service principal identity for the cluster to use for manipulating Azure APIs.
        /// </summary>
        Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IManagedClusterServicePrincipalProfile ServicePrincipalProfile { get; set; }
        /// <summary>The ID for the service principal.</summary>
        string ServicePrincipalProfileClientId { get; set; }
        /// <summary>The secret password associated with the service principal in plain text.</summary>
        string ServicePrincipalProfileSecret { get; set; }
        /// <summary>
        /// The list of SSH public keys used to authenticate with Linux-based VMs. Only expect one key specified.
        /// </summary>
        Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IContainerServiceSshPublicKey[] SshPublicKey { get; set; }
        /// <summary>
        /// Specifies the password of the administrator account. <br><br> **Minimum-length:** 8 characters <br><br> **Max-length:**
        /// 123 characters <br><br> **Complexity requirements:** 3 out of 4 conditions below need to be fulfilled <br> Has lower characters
        /// <br>Has upper characters <br> Has a digit <br> Has a special character (Regex match [\W_]) <br><br> **Disallowed values:**
        /// "abc@123", "P@$$w0rd", "P@ssw0rd", "P@ssword123", "Pa$$word", "pass@word1", "Password!", "Password1", "Password22", "iloveyou!"
        /// </summary>
        string WindowProfileAdminPassword { get; set; }
        /// <summary>
        /// Specifies the name of the administrator account. <br><br> **restriction:** Cannot end in "." <br><br> **Disallowed values:**
        /// "administrator", "admin", "user", "user1", "test", "user2", "test1", "user3", "admin1", "1", "123", "a", "actuser", "adm",
        /// "admin2", "aspnet", "backup", "console", "david", "guest", "john", "owner", "root", "server", "sql", "support", "support_388945a0",
        /// "sys", "test2", "test3", "user4", "user5". <br><br> **Minimum-length:** 1 character <br><br> **Max-length:** 20 characters
        /// </summary>
        string WindowProfileAdminUsername { get; set; }
        /// <summary>
        /// The licenseType to use for Windows VMs. Windows_Server is used to enable Azure Hybrid User Benefits for Windows VMs.
        /// </summary>
        Microsoft.Azure.PowerShell.Cmdlets.Aks.Support.LicenseType? WindowProfileLicenseType { get; set; }
        /// <summary>Profile for Windows VMs in the container service cluster.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IManagedClusterWindowsProfile WindowsProfile { get; set; }

    }
}