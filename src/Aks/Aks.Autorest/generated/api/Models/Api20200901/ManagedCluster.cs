namespace Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Aks.Runtime.Extensions;

    /// <summary>Managed cluster.</summary>
    public partial class ManagedCluster :
        Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IManagedCluster,
        Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IManagedClusterInternal,
        Microsoft.Azure.PowerShell.Cmdlets.Aks.Runtime.IValidates
    {
        /// <summary>
        /// Backing field for Inherited model <see cref= "Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IBaseManagedCluster"
        /// />
        /// </summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IBaseManagedCluster __baseManagedCluster = new Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.BaseManagedCluster();

        /// <summary>
        /// Backing field for Inherited model <see cref= "Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IResource" />
        /// </summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IResource __resource = new Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.Resource();

        /// <summary>Profile of Azure Active Directory configuration.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Aks.Origin(Microsoft.Azure.PowerShell.Cmdlets.Aks.PropertyOrigin.Inherited)]
        public Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IManagedClusterAadProfile AadProfile { get => ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IBaseManagedClusterInternal)__baseManagedCluster).AadProfile; set => ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IBaseManagedClusterInternal)__baseManagedCluster).AadProfile = value ?? null /* model class */; }

        /// <summary>AAD group object IDs that will have admin role of the cluster.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Aks.Origin(Microsoft.Azure.PowerShell.Cmdlets.Aks.PropertyOrigin.Inherited)]
        public string[] AadProfileAdminGroupObjectID { get => ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IBaseManagedClusterInternal)__baseManagedCluster).AadProfileAdminGroupObjectID; set => ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IBaseManagedClusterInternal)__baseManagedCluster).AadProfileAdminGroupObjectID = value ?? null /* arrayOf */; }

        /// <summary>The client AAD application ID.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Aks.Origin(Microsoft.Azure.PowerShell.Cmdlets.Aks.PropertyOrigin.Inherited)]
        public string AadProfileClientAppId { get => ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IBaseManagedClusterInternal)__baseManagedCluster).AadProfileClientAppId; set => ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IBaseManagedClusterInternal)__baseManagedCluster).AadProfileClientAppId = value ?? null; }

        /// <summary>Whether to enable Azure RBAC for Kubernetes authorization.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Aks.Origin(Microsoft.Azure.PowerShell.Cmdlets.Aks.PropertyOrigin.Inherited)]
        public bool? AadProfileEnableAzureRbac { get => ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IBaseManagedClusterInternal)__baseManagedCluster).AadProfileEnableAzureRbac; set => ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IBaseManagedClusterInternal)__baseManagedCluster).AadProfileEnableAzureRbac = value ?? default(bool); }

        /// <summary>Whether to enable managed AAD.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Aks.Origin(Microsoft.Azure.PowerShell.Cmdlets.Aks.PropertyOrigin.Inherited)]
        public bool? AadProfileManaged { get => ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IBaseManagedClusterInternal)__baseManagedCluster).AadProfileManaged; set => ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IBaseManagedClusterInternal)__baseManagedCluster).AadProfileManaged = value ?? default(bool); }

        /// <summary>The server AAD application ID.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Aks.Origin(Microsoft.Azure.PowerShell.Cmdlets.Aks.PropertyOrigin.Inherited)]
        public string AadProfileServerAppId { get => ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IBaseManagedClusterInternal)__baseManagedCluster).AadProfileServerAppId; set => ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IBaseManagedClusterInternal)__baseManagedCluster).AadProfileServerAppId = value ?? null; }

        /// <summary>The server AAD application secret.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Aks.Origin(Microsoft.Azure.PowerShell.Cmdlets.Aks.PropertyOrigin.Inherited)]
        public string AadProfileServerAppSecret { get => ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IBaseManagedClusterInternal)__baseManagedCluster).AadProfileServerAppSecret; set => ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IBaseManagedClusterInternal)__baseManagedCluster).AadProfileServerAppSecret = value ?? null; }

        /// <summary>
        /// The AAD tenant ID to use for authentication. If not specified, will use the tenant of the deployment subscription.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Aks.Origin(Microsoft.Azure.PowerShell.Cmdlets.Aks.PropertyOrigin.Inherited)]
        public string AadProfileTenantId { get => ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IBaseManagedClusterInternal)__baseManagedCluster).AadProfileTenantId; set => ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IBaseManagedClusterInternal)__baseManagedCluster).AadProfileTenantId = value ?? null; }

        /// <summary>Profile of managed cluster add-on.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Aks.Origin(Microsoft.Azure.PowerShell.Cmdlets.Aks.PropertyOrigin.Inherited)]
        public Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IManagedClusterPropertiesAddonProfiles AddonProfile { get => ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IBaseManagedClusterInternal)__baseManagedCluster).AddonProfile; set => ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IBaseManagedClusterInternal)__baseManagedCluster).AddonProfile = value ?? null /* model class */; }

        /// <summary>Properties of the agent pool.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Aks.Origin(Microsoft.Azure.PowerShell.Cmdlets.Aks.PropertyOrigin.Inherited)]
        public Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IManagedClusterAgentPoolProfile[] AgentPoolProfile { get => ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IBaseManagedClusterInternal)__baseManagedCluster).AgentPoolProfile; set => ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IBaseManagedClusterInternal)__baseManagedCluster).AgentPoolProfile = value ?? null /* arrayOf */; }

        /// <summary>Access profile for managed cluster API server.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Aks.Origin(Microsoft.Azure.PowerShell.Cmdlets.Aks.PropertyOrigin.Inherited)]
        public Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IManagedClusterApiServerAccessProfile ApiServerAccessProfile { get => ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IBaseManagedClusterInternal)__baseManagedCluster).ApiServerAccessProfile; set => ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IBaseManagedClusterInternal)__baseManagedCluster).ApiServerAccessProfile = value ?? null /* model class */; }

        /// <summary>Authorized IP Ranges to kubernetes API server.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Aks.Origin(Microsoft.Azure.PowerShell.Cmdlets.Aks.PropertyOrigin.Inherited)]
        public string[] ApiServerAccessProfileAuthorizedIPRange { get => ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IBaseManagedClusterInternal)__baseManagedCluster).ApiServerAccessProfileAuthorizedIPRange; set => ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IBaseManagedClusterInternal)__baseManagedCluster).ApiServerAccessProfileAuthorizedIPRange = value ?? null /* arrayOf */; }

        /// <summary>Whether to create the cluster as a private cluster or not.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Aks.Origin(Microsoft.Azure.PowerShell.Cmdlets.Aks.PropertyOrigin.Inherited)]
        public bool? ApiServerAccessProfileEnablePrivateCluster { get => ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IBaseManagedClusterInternal)__baseManagedCluster).ApiServerAccessProfileEnablePrivateCluster; set => ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IBaseManagedClusterInternal)__baseManagedCluster).ApiServerAccessProfileEnablePrivateCluster = value ?? default(bool); }

        /// <summary>Parameters to be applied to the cluster-autoscaler when enabled</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Aks.Origin(Microsoft.Azure.PowerShell.Cmdlets.Aks.PropertyOrigin.Inherited)]
        public Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IManagedClusterPropertiesAutoScalerProfile AutoScalerProfile { get => ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IBaseManagedClusterInternal)__baseManagedCluster).AutoScalerProfile; set => ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IBaseManagedClusterInternal)__baseManagedCluster).AutoScalerProfile = value ?? null /* model class */; }

        [Microsoft.Azure.PowerShell.Cmdlets.Aks.Origin(Microsoft.Azure.PowerShell.Cmdlets.Aks.PropertyOrigin.Inherited)]
        public string AutoScalerProfileBalanceSimilarNodeGroup { get => ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IBaseManagedClusterInternal)__baseManagedCluster).AutoScalerProfileBalanceSimilarNodeGroup; set => ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IBaseManagedClusterInternal)__baseManagedCluster).AutoScalerProfileBalanceSimilarNodeGroup = value ?? null; }

        [Microsoft.Azure.PowerShell.Cmdlets.Aks.Origin(Microsoft.Azure.PowerShell.Cmdlets.Aks.PropertyOrigin.Inherited)]
        public Microsoft.Azure.PowerShell.Cmdlets.Aks.Support.Expander? AutoScalerProfileExpander { get => ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IBaseManagedClusterInternal)__baseManagedCluster).AutoScalerProfileExpander; set => ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IBaseManagedClusterInternal)__baseManagedCluster).AutoScalerProfileExpander = value ?? ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Support.Expander)""); }

        [Microsoft.Azure.PowerShell.Cmdlets.Aks.Origin(Microsoft.Azure.PowerShell.Cmdlets.Aks.PropertyOrigin.Inherited)]
        public string AutoScalerProfileMaxEmptyBulkDelete { get => ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IBaseManagedClusterInternal)__baseManagedCluster).AutoScalerProfileMaxEmptyBulkDelete; set => ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IBaseManagedClusterInternal)__baseManagedCluster).AutoScalerProfileMaxEmptyBulkDelete = value ?? null; }

        [Microsoft.Azure.PowerShell.Cmdlets.Aks.Origin(Microsoft.Azure.PowerShell.Cmdlets.Aks.PropertyOrigin.Inherited)]
        public string AutoScalerProfileMaxGracefulTerminationSec { get => ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IBaseManagedClusterInternal)__baseManagedCluster).AutoScalerProfileMaxGracefulTerminationSec; set => ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IBaseManagedClusterInternal)__baseManagedCluster).AutoScalerProfileMaxGracefulTerminationSec = value ?? null; }

        [Microsoft.Azure.PowerShell.Cmdlets.Aks.Origin(Microsoft.Azure.PowerShell.Cmdlets.Aks.PropertyOrigin.Inherited)]
        public string AutoScalerProfileMaxTotalUnreadyPercentage { get => ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IBaseManagedClusterInternal)__baseManagedCluster).AutoScalerProfileMaxTotalUnreadyPercentage; set => ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IBaseManagedClusterInternal)__baseManagedCluster).AutoScalerProfileMaxTotalUnreadyPercentage = value ?? null; }

        [Microsoft.Azure.PowerShell.Cmdlets.Aks.Origin(Microsoft.Azure.PowerShell.Cmdlets.Aks.PropertyOrigin.Inherited)]
        public string AutoScalerProfileNewPodScaleUpDelay { get => ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IBaseManagedClusterInternal)__baseManagedCluster).AutoScalerProfileNewPodScaleUpDelay; set => ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IBaseManagedClusterInternal)__baseManagedCluster).AutoScalerProfileNewPodScaleUpDelay = value ?? null; }

        [Microsoft.Azure.PowerShell.Cmdlets.Aks.Origin(Microsoft.Azure.PowerShell.Cmdlets.Aks.PropertyOrigin.Inherited)]
        public string AutoScalerProfileOkTotalUnreadyCount { get => ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IBaseManagedClusterInternal)__baseManagedCluster).AutoScalerProfileOkTotalUnreadyCount; set => ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IBaseManagedClusterInternal)__baseManagedCluster).AutoScalerProfileOkTotalUnreadyCount = value ?? null; }

        [Microsoft.Azure.PowerShell.Cmdlets.Aks.Origin(Microsoft.Azure.PowerShell.Cmdlets.Aks.PropertyOrigin.Inherited)]
        public string AutoScalerProfileScaleDownDelayAfterAdd { get => ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IBaseManagedClusterInternal)__baseManagedCluster).AutoScalerProfileScaleDownDelayAfterAdd; set => ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IBaseManagedClusterInternal)__baseManagedCluster).AutoScalerProfileScaleDownDelayAfterAdd = value ?? null; }

        [Microsoft.Azure.PowerShell.Cmdlets.Aks.Origin(Microsoft.Azure.PowerShell.Cmdlets.Aks.PropertyOrigin.Inherited)]
        public string AutoScalerProfileScaleDownDelayAfterDelete { get => ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IBaseManagedClusterInternal)__baseManagedCluster).AutoScalerProfileScaleDownDelayAfterDelete; set => ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IBaseManagedClusterInternal)__baseManagedCluster).AutoScalerProfileScaleDownDelayAfterDelete = value ?? null; }

        [Microsoft.Azure.PowerShell.Cmdlets.Aks.Origin(Microsoft.Azure.PowerShell.Cmdlets.Aks.PropertyOrigin.Inherited)]
        public string AutoScalerProfileScaleDownDelayAfterFailure { get => ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IBaseManagedClusterInternal)__baseManagedCluster).AutoScalerProfileScaleDownDelayAfterFailure; set => ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IBaseManagedClusterInternal)__baseManagedCluster).AutoScalerProfileScaleDownDelayAfterFailure = value ?? null; }

        [Microsoft.Azure.PowerShell.Cmdlets.Aks.Origin(Microsoft.Azure.PowerShell.Cmdlets.Aks.PropertyOrigin.Inherited)]
        public string AutoScalerProfileScaleDownUnneededTime { get => ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IBaseManagedClusterInternal)__baseManagedCluster).AutoScalerProfileScaleDownUnneededTime; set => ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IBaseManagedClusterInternal)__baseManagedCluster).AutoScalerProfileScaleDownUnneededTime = value ?? null; }

        [Microsoft.Azure.PowerShell.Cmdlets.Aks.Origin(Microsoft.Azure.PowerShell.Cmdlets.Aks.PropertyOrigin.Inherited)]
        public string AutoScalerProfileScaleDownUnreadyTime { get => ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IBaseManagedClusterInternal)__baseManagedCluster).AutoScalerProfileScaleDownUnreadyTime; set => ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IBaseManagedClusterInternal)__baseManagedCluster).AutoScalerProfileScaleDownUnreadyTime = value ?? null; }

        [Microsoft.Azure.PowerShell.Cmdlets.Aks.Origin(Microsoft.Azure.PowerShell.Cmdlets.Aks.PropertyOrigin.Inherited)]
        public string AutoScalerProfileScaleDownUtilizationThreshold { get => ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IBaseManagedClusterInternal)__baseManagedCluster).AutoScalerProfileScaleDownUtilizationThreshold; set => ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IBaseManagedClusterInternal)__baseManagedCluster).AutoScalerProfileScaleDownUtilizationThreshold = value ?? null; }

        [Microsoft.Azure.PowerShell.Cmdlets.Aks.Origin(Microsoft.Azure.PowerShell.Cmdlets.Aks.PropertyOrigin.Inherited)]
        public string AutoScalerProfileScanInterval { get => ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IBaseManagedClusterInternal)__baseManagedCluster).AutoScalerProfileScanInterval; set => ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IBaseManagedClusterInternal)__baseManagedCluster).AutoScalerProfileScanInterval = value ?? null; }

        [Microsoft.Azure.PowerShell.Cmdlets.Aks.Origin(Microsoft.Azure.PowerShell.Cmdlets.Aks.PropertyOrigin.Inherited)]
        public string AutoScalerProfileSkipNodesWithLocalStorage { get => ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IBaseManagedClusterInternal)__baseManagedCluster).AutoScalerProfileSkipNodesWithLocalStorage; set => ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IBaseManagedClusterInternal)__baseManagedCluster).AutoScalerProfileSkipNodesWithLocalStorage = value ?? null; }

        [Microsoft.Azure.PowerShell.Cmdlets.Aks.Origin(Microsoft.Azure.PowerShell.Cmdlets.Aks.PropertyOrigin.Inherited)]
        public string AutoScalerProfileSkipNodesWithSystemPod { get => ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IBaseManagedClusterInternal)__baseManagedCluster).AutoScalerProfileSkipNodesWithSystemPod; set => ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IBaseManagedClusterInternal)__baseManagedCluster).AutoScalerProfileSkipNodesWithSystemPod = value ?? null; }

        /// <summary>ResourceId of the disk encryption set to use for enabling encryption at rest.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Aks.Origin(Microsoft.Azure.PowerShell.Cmdlets.Aks.PropertyOrigin.Inherited)]
        public string DiskEncryptionSetId { get => ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IBaseManagedClusterInternal)__baseManagedCluster).DiskEncryptionSetId; set => ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IBaseManagedClusterInternal)__baseManagedCluster).DiskEncryptionSetId = value ?? null; }

        /// <summary>DNS prefix specified when creating the managed cluster.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Aks.Origin(Microsoft.Azure.PowerShell.Cmdlets.Aks.PropertyOrigin.Inherited)]
        public string DnsPrefix { get => ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IBaseManagedClusterInternal)__baseManagedCluster).DnsPrefix; set => ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IBaseManagedClusterInternal)__baseManagedCluster).DnsPrefix = value ?? null; }

        /// <summary>
        /// (DEPRECATING) Whether to enable Kubernetes pod security policy (preview). This feature is set for removal on October 15th,
        /// 2020. Learn more at aka.ms/aks/azpodpolicy.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Aks.Origin(Microsoft.Azure.PowerShell.Cmdlets.Aks.PropertyOrigin.Inherited)]
        public bool? EnablePodSecurityPolicy { get => ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IBaseManagedClusterInternal)__baseManagedCluster).EnablePodSecurityPolicy; set => ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IBaseManagedClusterInternal)__baseManagedCluster).EnablePodSecurityPolicy = value ?? default(bool); }

        /// <summary>Whether to enable Kubernetes Role-Based Access Control.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Aks.Origin(Microsoft.Azure.PowerShell.Cmdlets.Aks.PropertyOrigin.Inherited)]
        public bool? EnableRbac { get => ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IBaseManagedClusterInternal)__baseManagedCluster).EnableRbac; set => ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IBaseManagedClusterInternal)__baseManagedCluster).EnableRbac = value ?? default(bool); }

        /// <summary>FQDN for the master pool.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Aks.Origin(Microsoft.Azure.PowerShell.Cmdlets.Aks.PropertyOrigin.Inherited)]
        public string Fqdn { get => ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IBaseManagedClusterInternal)__baseManagedCluster).Fqdn; }

        /// <summary>Resource Id</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Aks.Origin(Microsoft.Azure.PowerShell.Cmdlets.Aks.PropertyOrigin.Inherited)]
        public string Id { get => ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IResourceInternal)__resource).Id; }

        /// <summary>The identity of the managed cluster, if configured.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Aks.Origin(Microsoft.Azure.PowerShell.Cmdlets.Aks.PropertyOrigin.Inherited)]
        public Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IManagedClusterIdentity Identity { get => ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IBaseManagedClusterInternal)__baseManagedCluster).Identity; set => ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IBaseManagedClusterInternal)__baseManagedCluster).Identity = value ?? null /* model class */; }

        /// <summary>
        /// The principal id of the system assigned identity which is used by master components.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Aks.Origin(Microsoft.Azure.PowerShell.Cmdlets.Aks.PropertyOrigin.Inherited)]
        public string IdentityPrincipalId { get => ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IBaseManagedClusterInternal)__baseManagedCluster).IdentityPrincipalId; }

        /// <summary>Identities associated with the cluster.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Aks.Origin(Microsoft.Azure.PowerShell.Cmdlets.Aks.PropertyOrigin.Inherited)]
        public Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IManagedClusterPropertiesIdentityProfile IdentityProfile { get => ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IBaseManagedClusterInternal)__baseManagedCluster).IdentityProfile; set => ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IBaseManagedClusterInternal)__baseManagedCluster).IdentityProfile = value ?? null /* model class */; }

        /// <summary>
        /// The tenant id of the system assigned identity which is used by master components.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Aks.Origin(Microsoft.Azure.PowerShell.Cmdlets.Aks.PropertyOrigin.Inherited)]
        public string IdentityTenantId { get => ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IBaseManagedClusterInternal)__baseManagedCluster).IdentityTenantId; }

        /// <summary>
        /// The type of identity used for the managed cluster. Type 'SystemAssigned' will use an implicitly created identity in master
        /// components and an auto-created user assigned identity in MC_ resource group in agent nodes. Type 'None' will not use MSI
        /// for the managed cluster, service principal will be used instead.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Aks.Origin(Microsoft.Azure.PowerShell.Cmdlets.Aks.PropertyOrigin.Inherited)]
        public Microsoft.Azure.PowerShell.Cmdlets.Aks.Support.ResourceIdentityType? IdentityType { get => ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IBaseManagedClusterInternal)__baseManagedCluster).IdentityType; set => ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IBaseManagedClusterInternal)__baseManagedCluster).IdentityType = value ?? ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Support.ResourceIdentityType)""); }

        /// <summary>
        /// The user identity associated with the managed cluster. This identity will be used in control plane and only one user assigned
        /// identity is allowed. The user identity dictionary key references will be ARM resource ids in the form: '/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ManagedIdentity/userAssignedIdentities/{identityName}'.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Aks.Origin(Microsoft.Azure.PowerShell.Cmdlets.Aks.PropertyOrigin.Inherited)]
        public Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IManagedClusterIdentityUserAssignedIdentities IdentityUserAssignedIdentity { get => ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IBaseManagedClusterInternal)__baseManagedCluster).IdentityUserAssignedIdentity; set => ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IBaseManagedClusterInternal)__baseManagedCluster).IdentityUserAssignedIdentity = value ?? null /* model class */; }

        /// <summary>Version of Kubernetes specified when creating the managed cluster.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Aks.Origin(Microsoft.Azure.PowerShell.Cmdlets.Aks.PropertyOrigin.Inherited)]
        public string KubernetesVersion { get => ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IBaseManagedClusterInternal)__baseManagedCluster).KubernetesVersion; set => ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IBaseManagedClusterInternal)__baseManagedCluster).KubernetesVersion = value ?? null; }

        /// <summary>Profile for Linux VMs in the container service cluster.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Aks.Origin(Microsoft.Azure.PowerShell.Cmdlets.Aks.PropertyOrigin.Inherited)]
        public Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IContainerServiceLinuxProfile LinuxProfile { get => ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IBaseManagedClusterInternal)__baseManagedCluster).LinuxProfile; set => ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IBaseManagedClusterInternal)__baseManagedCluster).LinuxProfile = value ?? null /* model class */; }

        /// <summary>The administrator username to use for Linux VMs.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Aks.Origin(Microsoft.Azure.PowerShell.Cmdlets.Aks.PropertyOrigin.Inherited)]
        public string LinuxProfileAdminUsername { get => ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IBaseManagedClusterInternal)__baseManagedCluster).LinuxProfileAdminUsername; set => ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IBaseManagedClusterInternal)__baseManagedCluster).LinuxProfileAdminUsername = value ?? null; }

        /// <summary>SSH configuration for Linux-based VMs running on Azure.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Aks.Origin(Microsoft.Azure.PowerShell.Cmdlets.Aks.PropertyOrigin.Inherited)]
        public Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IContainerServiceSshConfiguration LinuxProfileSsh { get => ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IBaseManagedClusterInternal)__baseManagedCluster).LinuxProfileSsh; set => ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IBaseManagedClusterInternal)__baseManagedCluster).LinuxProfileSsh = value ?? null /* model class */; }

        /// <summary>
        /// Desired number of allocated SNAT ports per VM. Allowed values must be in the range of 0 to 64000 (inclusive). The default
        /// value is 0 which results in Azure dynamically allocating ports.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Aks.Origin(Microsoft.Azure.PowerShell.Cmdlets.Aks.PropertyOrigin.Inherited)]
        public int? LoadBalancerProfileAllocatedOutboundPort { get => ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IBaseManagedClusterInternal)__baseManagedCluster).LoadBalancerProfileAllocatedOutboundPort; set => ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IBaseManagedClusterInternal)__baseManagedCluster).LoadBalancerProfileAllocatedOutboundPort = value ?? default(int); }

        /// <summary>The effective outbound IP resources of the cluster load balancer.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Aks.Origin(Microsoft.Azure.PowerShell.Cmdlets.Aks.PropertyOrigin.Inherited)]
        public Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IResourceReference[] LoadBalancerProfileEffectiveOutboundIP { get => ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IBaseManagedClusterInternal)__baseManagedCluster).LoadBalancerProfileEffectiveOutboundIP; set => ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IBaseManagedClusterInternal)__baseManagedCluster).LoadBalancerProfileEffectiveOutboundIP = value ?? null /* arrayOf */; }

        /// <summary>
        /// Desired outbound flow idle timeout in minutes. Allowed values must be in the range of 4 to 120 (inclusive). The default
        /// value is 30 minutes.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Aks.Origin(Microsoft.Azure.PowerShell.Cmdlets.Aks.PropertyOrigin.Inherited)]
        public int? LoadBalancerProfileIdleTimeoutInMinute { get => ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IBaseManagedClusterInternal)__baseManagedCluster).LoadBalancerProfileIdleTimeoutInMinute; set => ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IBaseManagedClusterInternal)__baseManagedCluster).LoadBalancerProfileIdleTimeoutInMinute = value ?? default(int); }

        /// <summary>Desired managed outbound IPs for the cluster load balancer.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Aks.Origin(Microsoft.Azure.PowerShell.Cmdlets.Aks.PropertyOrigin.Inherited)]
        public Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IManagedClusterLoadBalancerProfileManagedOutboundIPs LoadBalancerProfileManagedOutboundIP { get => ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IBaseManagedClusterInternal)__baseManagedCluster).LoadBalancerProfileManagedOutboundIP; set => ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IBaseManagedClusterInternal)__baseManagedCluster).LoadBalancerProfileManagedOutboundIP = value ?? null /* model class */; }

        /// <summary>Desired outbound IP resources for the cluster load balancer.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Aks.Origin(Microsoft.Azure.PowerShell.Cmdlets.Aks.PropertyOrigin.Inherited)]
        public Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IManagedClusterLoadBalancerProfileOutboundIPs LoadBalancerProfileOutboundIP { get => ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IBaseManagedClusterInternal)__baseManagedCluster).LoadBalancerProfileOutboundIP; set => ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IBaseManagedClusterInternal)__baseManagedCluster).LoadBalancerProfileOutboundIP = value ?? null /* model class */; }

        /// <summary>Desired outbound IP Prefix resources for the cluster load balancer.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Aks.Origin(Microsoft.Azure.PowerShell.Cmdlets.Aks.PropertyOrigin.Inherited)]
        public Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IManagedClusterLoadBalancerProfileOutboundIPPrefixes LoadBalancerProfileOutboundIPPrefix { get => ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IBaseManagedClusterInternal)__baseManagedCluster).LoadBalancerProfileOutboundIPPrefix; set => ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IBaseManagedClusterInternal)__baseManagedCluster).LoadBalancerProfileOutboundIPPrefix = value ?? null /* model class */; }

        /// <summary>Resource location</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Aks.Origin(Microsoft.Azure.PowerShell.Cmdlets.Aks.PropertyOrigin.Inherited)]
        public string Location { get => ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IResourceInternal)__resource).Location; set => ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IResourceInternal)__resource).Location = value ; }

        /// <summary>
        /// Desired number of outbound IP created/managed by Azure for the cluster load balancer. Allowed values must be in the range
        /// of 1 to 100 (inclusive). The default value is 1.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Aks.Origin(Microsoft.Azure.PowerShell.Cmdlets.Aks.PropertyOrigin.Inherited)]
        public int? ManagedOutboundIPCount { get => ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IBaseManagedClusterInternal)__baseManagedCluster).ManagedOutboundIPCount; set => ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IBaseManagedClusterInternal)__baseManagedCluster).ManagedOutboundIPCount = value ?? default(int); }

        /// <summary>The max number of agent pools for the managed cluster.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Aks.Origin(Microsoft.Azure.PowerShell.Cmdlets.Aks.PropertyOrigin.Inherited)]
        public int? MaxAgentPool { get => ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IBaseManagedClusterInternal)__baseManagedCluster).MaxAgentPool; }

        /// <summary>Internal Acessors for Fqdn</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IBaseManagedClusterInternal.Fqdn { get => ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IBaseManagedClusterInternal)__baseManagedCluster).Fqdn; set => ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IBaseManagedClusterInternal)__baseManagedCluster).Fqdn = value; }

        /// <summary>Internal Acessors for IdentityPrincipalId</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IBaseManagedClusterInternal.IdentityPrincipalId { get => ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IBaseManagedClusterInternal)__baseManagedCluster).IdentityPrincipalId; set => ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IBaseManagedClusterInternal)__baseManagedCluster).IdentityPrincipalId = value; }

        /// <summary>Internal Acessors for IdentityTenantId</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IBaseManagedClusterInternal.IdentityTenantId { get => ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IBaseManagedClusterInternal)__baseManagedCluster).IdentityTenantId; set => ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IBaseManagedClusterInternal)__baseManagedCluster).IdentityTenantId = value; }

        /// <summary>Internal Acessors for MaxAgentPool</summary>
        int? Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IBaseManagedClusterInternal.MaxAgentPool { get => ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IBaseManagedClusterInternal)__baseManagedCluster).MaxAgentPool; set => ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IBaseManagedClusterInternal)__baseManagedCluster).MaxAgentPool = value; }

        /// <summary>Internal Acessors for PowerState</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IPowerState Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IBaseManagedClusterInternal.PowerState { get => ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IBaseManagedClusterInternal)__baseManagedCluster).PowerState; set => ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IBaseManagedClusterInternal)__baseManagedCluster).PowerState = value; }

        /// <summary>Internal Acessors for PrivateFqdn</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IBaseManagedClusterInternal.PrivateFqdn { get => ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IBaseManagedClusterInternal)__baseManagedCluster).PrivateFqdn; set => ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IBaseManagedClusterInternal)__baseManagedCluster).PrivateFqdn = value; }

        /// <summary>Internal Acessors for ProvisioningState</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IBaseManagedClusterInternal.ProvisioningState { get => ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IBaseManagedClusterInternal)__baseManagedCluster).ProvisioningState; set => ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IBaseManagedClusterInternal)__baseManagedCluster).ProvisioningState = value; }

        /// <summary>Internal Acessors for Sku</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IManagedClusterSku Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IManagedClusterInternal.Sku { get => (this._sku = this._sku ?? new Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.ManagedClusterSku()); set { {_sku = value;} } }

        /// <summary>Internal Acessors for Id</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IResourceInternal.Id { get => ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IResourceInternal)__resource).Id; set => ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IResourceInternal)__resource).Id = value; }

        /// <summary>Internal Acessors for Name</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IResourceInternal.Name { get => ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IResourceInternal)__resource).Name; set => ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IResourceInternal)__resource).Name = value; }

        /// <summary>Internal Acessors for Type</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IResourceInternal.Type { get => ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IResourceInternal)__resource).Type; set => ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IResourceInternal)__resource).Type = value; }

        /// <summary>Resource name</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Aks.Origin(Microsoft.Azure.PowerShell.Cmdlets.Aks.PropertyOrigin.Inherited)]
        public string Name { get => ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IResourceInternal)__resource).Name; }

        /// <summary>Profile of network configuration.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Aks.Origin(Microsoft.Azure.PowerShell.Cmdlets.Aks.PropertyOrigin.Inherited)]
        public Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IContainerServiceNetworkProfile NetworkProfile { get => ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IBaseManagedClusterInternal)__baseManagedCluster).NetworkProfile; set => ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IBaseManagedClusterInternal)__baseManagedCluster).NetworkProfile = value ?? null /* model class */; }

        /// <summary>
        /// An IP address assigned to the Kubernetes DNS service. It must be within the Kubernetes service address range specified
        /// in serviceCidr.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Aks.Origin(Microsoft.Azure.PowerShell.Cmdlets.Aks.PropertyOrigin.Inherited)]
        public string NetworkProfileDnsServiceIP { get => ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IBaseManagedClusterInternal)__baseManagedCluster).NetworkProfileDnsServiceIP; set => ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IBaseManagedClusterInternal)__baseManagedCluster).NetworkProfileDnsServiceIP = value ?? null; }

        /// <summary>
        /// A CIDR notation IP range assigned to the Docker bridge network. It must not overlap with any Subnet IP ranges or the Kubernetes
        /// service address range.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Aks.Origin(Microsoft.Azure.PowerShell.Cmdlets.Aks.PropertyOrigin.Inherited)]
        public string NetworkProfileDockerBridgeCidr { get => ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IBaseManagedClusterInternal)__baseManagedCluster).NetworkProfileDockerBridgeCidr; set => ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IBaseManagedClusterInternal)__baseManagedCluster).NetworkProfileDockerBridgeCidr = value ?? null; }

        /// <summary>Profile of the cluster load balancer.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Aks.Origin(Microsoft.Azure.PowerShell.Cmdlets.Aks.PropertyOrigin.Inherited)]
        public Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IManagedClusterLoadBalancerProfile NetworkProfileLoadBalancerProfile { get => ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IBaseManagedClusterInternal)__baseManagedCluster).NetworkProfileLoadBalancerProfile; set => ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IBaseManagedClusterInternal)__baseManagedCluster).NetworkProfileLoadBalancerProfile = value ?? null /* model class */; }

        /// <summary>The load balancer sku for the managed cluster.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Aks.Origin(Microsoft.Azure.PowerShell.Cmdlets.Aks.PropertyOrigin.Inherited)]
        public Microsoft.Azure.PowerShell.Cmdlets.Aks.Support.LoadBalancerSku? NetworkProfileLoadBalancerSku { get => ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IBaseManagedClusterInternal)__baseManagedCluster).NetworkProfileLoadBalancerSku; set => ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IBaseManagedClusterInternal)__baseManagedCluster).NetworkProfileLoadBalancerSku = value ?? ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Support.LoadBalancerSku)""); }

        /// <summary>Network mode used for building Kubernetes network.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Aks.Origin(Microsoft.Azure.PowerShell.Cmdlets.Aks.PropertyOrigin.Inherited)]
        public Microsoft.Azure.PowerShell.Cmdlets.Aks.Support.NetworkMode? NetworkProfileNetworkMode { get => ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IBaseManagedClusterInternal)__baseManagedCluster).NetworkProfileNetworkMode; set => ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IBaseManagedClusterInternal)__baseManagedCluster).NetworkProfileNetworkMode = value ?? ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Support.NetworkMode)""); }

        /// <summary>Network plugin used for building Kubernetes network.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Aks.Origin(Microsoft.Azure.PowerShell.Cmdlets.Aks.PropertyOrigin.Inherited)]
        public Microsoft.Azure.PowerShell.Cmdlets.Aks.Support.NetworkPlugin? NetworkProfileNetworkPlugin { get => ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IBaseManagedClusterInternal)__baseManagedCluster).NetworkProfileNetworkPlugin; set => ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IBaseManagedClusterInternal)__baseManagedCluster).NetworkProfileNetworkPlugin = value ?? ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Support.NetworkPlugin)""); }

        /// <summary>Network policy used for building Kubernetes network.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Aks.Origin(Microsoft.Azure.PowerShell.Cmdlets.Aks.PropertyOrigin.Inherited)]
        public Microsoft.Azure.PowerShell.Cmdlets.Aks.Support.NetworkPolicy? NetworkProfileNetworkPolicy { get => ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IBaseManagedClusterInternal)__baseManagedCluster).NetworkProfileNetworkPolicy; set => ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IBaseManagedClusterInternal)__baseManagedCluster).NetworkProfileNetworkPolicy = value ?? ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Support.NetworkPolicy)""); }

        /// <summary>The outbound (egress) routing method.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Aks.Origin(Microsoft.Azure.PowerShell.Cmdlets.Aks.PropertyOrigin.Inherited)]
        public Microsoft.Azure.PowerShell.Cmdlets.Aks.Support.OutboundType? NetworkProfileOutboundType { get => ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IBaseManagedClusterInternal)__baseManagedCluster).NetworkProfileOutboundType; set => ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IBaseManagedClusterInternal)__baseManagedCluster).NetworkProfileOutboundType = value ?? ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Support.OutboundType)""); }

        /// <summary>A CIDR notation IP range from which to assign pod IPs when kubenet is used.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Aks.Origin(Microsoft.Azure.PowerShell.Cmdlets.Aks.PropertyOrigin.Inherited)]
        public string NetworkProfilePodCidr { get => ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IBaseManagedClusterInternal)__baseManagedCluster).NetworkProfilePodCidr; set => ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IBaseManagedClusterInternal)__baseManagedCluster).NetworkProfilePodCidr = value ?? null; }

        /// <summary>
        /// A CIDR notation IP range from which to assign service cluster IPs. It must not overlap with any Subnet IP ranges.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Aks.Origin(Microsoft.Azure.PowerShell.Cmdlets.Aks.PropertyOrigin.Inherited)]
        public string NetworkProfileServiceCidr { get => ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IBaseManagedClusterInternal)__baseManagedCluster).NetworkProfileServiceCidr; set => ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IBaseManagedClusterInternal)__baseManagedCluster).NetworkProfileServiceCidr = value ?? null; }

        /// <summary>Name of the resource group containing agent pool nodes.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Aks.Origin(Microsoft.Azure.PowerShell.Cmdlets.Aks.PropertyOrigin.Inherited)]
        public string NodeResourceGroup { get => ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IBaseManagedClusterInternal)__baseManagedCluster).NodeResourceGroup; set => ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IBaseManagedClusterInternal)__baseManagedCluster).NodeResourceGroup = value ?? null; }

        /// <summary>A list of public IP prefix resources.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Aks.Origin(Microsoft.Azure.PowerShell.Cmdlets.Aks.PropertyOrigin.Inherited)]
        public Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IResourceReference[] OutboundIPPrefixPublicIpprefix { get => ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IBaseManagedClusterInternal)__baseManagedCluster).OutboundIPPrefixPublicIpprefix; set => ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IBaseManagedClusterInternal)__baseManagedCluster).OutboundIPPrefixPublicIpprefix = value ?? null /* arrayOf */; }

        /// <summary>A list of public IP resources.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Aks.Origin(Microsoft.Azure.PowerShell.Cmdlets.Aks.PropertyOrigin.Inherited)]
        public Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IResourceReference[] OutboundIPPublicIP { get => ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IBaseManagedClusterInternal)__baseManagedCluster).OutboundIPPublicIP; set => ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IBaseManagedClusterInternal)__baseManagedCluster).OutboundIPPublicIP = value ?? null /* arrayOf */; }

        /// <summary>Represents the Power State of the cluster</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Aks.Origin(Microsoft.Azure.PowerShell.Cmdlets.Aks.PropertyOrigin.Inherited)]
        public Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IPowerState PowerState { get => ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IBaseManagedClusterInternal)__baseManagedCluster).PowerState; }

        /// <summary>Tells whether the cluster is Running or Stopped</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Aks.Origin(Microsoft.Azure.PowerShell.Cmdlets.Aks.PropertyOrigin.Inherited)]
        public Microsoft.Azure.PowerShell.Cmdlets.Aks.Support.Code? PowerStateCode { get => ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IBaseManagedClusterInternal)__baseManagedCluster).PowerStateCode; set => ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IBaseManagedClusterInternal)__baseManagedCluster).PowerStateCode = value ?? ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Support.Code)""); }

        /// <summary>FQDN of private cluster.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Aks.Origin(Microsoft.Azure.PowerShell.Cmdlets.Aks.PropertyOrigin.Inherited)]
        public string PrivateFqdn { get => ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IBaseManagedClusterInternal)__baseManagedCluster).PrivateFqdn; }

        /// <summary>Properties of a managed cluster.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Aks.Origin(Microsoft.Azure.PowerShell.Cmdlets.Aks.PropertyOrigin.Inherited)]
        public Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IManagedClusterProperties Property { get => ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IBaseManagedClusterInternal)__baseManagedCluster).Property; set => ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IBaseManagedClusterInternal)__baseManagedCluster).Property = value ?? null /* model class */; }

        /// <summary>
        /// The current deployment or provisioning state, which only appears in the response.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Aks.Origin(Microsoft.Azure.PowerShell.Cmdlets.Aks.PropertyOrigin.Inherited)]
        public string ProvisioningState { get => ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IBaseManagedClusterInternal)__baseManagedCluster).ProvisioningState; }

        /// <summary>
        /// Information about a service principal identity for the cluster to use for manipulating Azure APIs.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Aks.Origin(Microsoft.Azure.PowerShell.Cmdlets.Aks.PropertyOrigin.Inherited)]
        public Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IManagedClusterServicePrincipalProfile ServicePrincipalProfile { get => ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IBaseManagedClusterInternal)__baseManagedCluster).ServicePrincipalProfile; set => ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IBaseManagedClusterInternal)__baseManagedCluster).ServicePrincipalProfile = value ?? null /* model class */; }

        /// <summary>The ID for the service principal.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Aks.Origin(Microsoft.Azure.PowerShell.Cmdlets.Aks.PropertyOrigin.Inherited)]
        public string ServicePrincipalProfileClientId { get => ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IBaseManagedClusterInternal)__baseManagedCluster).ServicePrincipalProfileClientId; set => ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IBaseManagedClusterInternal)__baseManagedCluster).ServicePrincipalProfileClientId = value ?? null; }

        /// <summary>The secret password associated with the service principal in plain text.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Aks.Origin(Microsoft.Azure.PowerShell.Cmdlets.Aks.PropertyOrigin.Inherited)]
        public string ServicePrincipalProfileSecret { get => ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IBaseManagedClusterInternal)__baseManagedCluster).ServicePrincipalProfileSecret; set => ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IBaseManagedClusterInternal)__baseManagedCluster).ServicePrincipalProfileSecret = value ?? null; }

        /// <summary>Backing field for <see cref="Sku" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IManagedClusterSku _sku;

        /// <summary>The managed cluster SKU.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Aks.Origin(Microsoft.Azure.PowerShell.Cmdlets.Aks.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IManagedClusterSku Sku { get => (this._sku = this._sku ?? new Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.ManagedClusterSku()); set => this._sku = value; }

        /// <summary>Name of a managed cluster SKU.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Aks.Origin(Microsoft.Azure.PowerShell.Cmdlets.Aks.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.Aks.Support.ManagedClusterSkuName? SkuName { get => ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IManagedClusterSkuInternal)Sku).Name; set => ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IManagedClusterSkuInternal)Sku).Name = value ?? ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Support.ManagedClusterSkuName)""); }

        /// <summary>Tier of a managed cluster SKU.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Aks.Origin(Microsoft.Azure.PowerShell.Cmdlets.Aks.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.Aks.Support.ManagedClusterSkuTier? SkuTier { get => ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IManagedClusterSkuInternal)Sku).Tier; set => ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IManagedClusterSkuInternal)Sku).Tier = value ?? ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Support.ManagedClusterSkuTier)""); }

        /// <summary>
        /// The list of SSH public keys used to authenticate with Linux-based VMs. Only expect one key specified.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Aks.Origin(Microsoft.Azure.PowerShell.Cmdlets.Aks.PropertyOrigin.Inherited)]
        public Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IContainerServiceSshPublicKey[] SshPublicKey { get => ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IBaseManagedClusterInternal)__baseManagedCluster).SshPublicKey; set => ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IBaseManagedClusterInternal)__baseManagedCluster).SshPublicKey = value ?? null /* arrayOf */; }

        /// <summary>Resource tags</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Aks.Origin(Microsoft.Azure.PowerShell.Cmdlets.Aks.PropertyOrigin.Inherited)]
        public Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IResourceTags Tag { get => ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IResourceInternal)__resource).Tag; set => ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IResourceInternal)__resource).Tag = value ?? null /* model class */; }

        /// <summary>Resource type</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Aks.Origin(Microsoft.Azure.PowerShell.Cmdlets.Aks.PropertyOrigin.Inherited)]
        public string Type { get => ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IResourceInternal)__resource).Type; }

        /// <summary>
        /// Specifies the password of the administrator account. <br><br> **Minimum-length:** 8 characters <br><br> **Max-length:**
        /// 123 characters <br><br> **Complexity requirements:** 3 out of 4 conditions below need to be fulfilled <br> Has lower characters
        /// <br>Has upper characters <br> Has a digit <br> Has a special character (Regex match [\W_]) <br><br> **Disallowed values:**
        /// "abc@123", "P@$$w0rd", "P@ssw0rd", "P@ssword123", "Pa$$word", "pass@word1", "Password!", "Password1", "Password22", "iloveyou!"
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Aks.Origin(Microsoft.Azure.PowerShell.Cmdlets.Aks.PropertyOrigin.Inherited)]
        public string WindowProfileAdminPassword { get => ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IBaseManagedClusterInternal)__baseManagedCluster).WindowProfileAdminPassword; set => ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IBaseManagedClusterInternal)__baseManagedCluster).WindowProfileAdminPassword = value ?? null; }

        /// <summary>
        /// Specifies the name of the administrator account. <br><br> **restriction:** Cannot end in "." <br><br> **Disallowed values:**
        /// "administrator", "admin", "user", "user1", "test", "user2", "test1", "user3", "admin1", "1", "123", "a", "actuser", "adm",
        /// "admin2", "aspnet", "backup", "console", "david", "guest", "john", "owner", "root", "server", "sql", "support", "support_388945a0",
        /// "sys", "test2", "test3", "user4", "user5". <br><br> **Minimum-length:** 1 character <br><br> **Max-length:** 20 characters
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Aks.Origin(Microsoft.Azure.PowerShell.Cmdlets.Aks.PropertyOrigin.Inherited)]
        public string WindowProfileAdminUsername { get => ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IBaseManagedClusterInternal)__baseManagedCluster).WindowProfileAdminUsername; set => ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IBaseManagedClusterInternal)__baseManagedCluster).WindowProfileAdminUsername = value ?? null; }

        /// <summary>
        /// The licenseType to use for Windows VMs. Windows_Server is used to enable Azure Hybrid User Benefits for Windows VMs.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Aks.Origin(Microsoft.Azure.PowerShell.Cmdlets.Aks.PropertyOrigin.Inherited)]
        public Microsoft.Azure.PowerShell.Cmdlets.Aks.Support.LicenseType? WindowProfileLicenseType { get => ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IBaseManagedClusterInternal)__baseManagedCluster).WindowProfileLicenseType; set => ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IBaseManagedClusterInternal)__baseManagedCluster).WindowProfileLicenseType = value ?? ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Support.LicenseType)""); }

        /// <summary>Profile for Windows VMs in the container service cluster.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Aks.Origin(Microsoft.Azure.PowerShell.Cmdlets.Aks.PropertyOrigin.Inherited)]
        public Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IManagedClusterWindowsProfile WindowsProfile { get => ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IBaseManagedClusterInternal)__baseManagedCluster).WindowsProfile; set => ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IBaseManagedClusterInternal)__baseManagedCluster).WindowsProfile = value ?? null /* model class */; }

        /// <summary>Creates an new <see cref="ManagedCluster" /> instance.</summary>
        public ManagedCluster()
        {

        }

        /// <summary>Validates that this object meets the validation criteria.</summary>
        /// <param name="eventListener">an <see cref="Microsoft.Azure.PowerShell.Cmdlets.Aks.Runtime.IEventListener" /> instance that will receive validation
        /// events.</param>
        /// <returns>
        /// A < see cref = "global::System.Threading.Tasks.Task" /> that will be complete when validation is completed.
        /// </returns>
        public async global::System.Threading.Tasks.Task Validate(Microsoft.Azure.PowerShell.Cmdlets.Aks.Runtime.IEventListener eventListener)
        {
            await eventListener.AssertNotNull(nameof(__resource), __resource);
            await eventListener.AssertObjectIsValid(nameof(__resource), __resource);
            await eventListener.AssertNotNull(nameof(__baseManagedCluster), __baseManagedCluster);
            await eventListener.AssertObjectIsValid(nameof(__baseManagedCluster), __baseManagedCluster);
        }
    }
    /// Managed cluster.
    public partial interface IManagedCluster :
        Microsoft.Azure.PowerShell.Cmdlets.Aks.Runtime.IJsonSerializable,
        Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IResource,
        Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IBaseManagedCluster
    {
        /// <summary>Name of a managed cluster SKU.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Aks.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Name of a managed cluster SKU.",
        SerializedName = @"name",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Aks.Support.ManagedClusterSkuName) })]
        Microsoft.Azure.PowerShell.Cmdlets.Aks.Support.ManagedClusterSkuName? SkuName { get; set; }
        /// <summary>Tier of a managed cluster SKU.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Aks.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Tier of a managed cluster SKU.",
        SerializedName = @"tier",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Aks.Support.ManagedClusterSkuTier) })]
        Microsoft.Azure.PowerShell.Cmdlets.Aks.Support.ManagedClusterSkuTier? SkuTier { get; set; }

    }
    /// Managed cluster.
    internal partial interface IManagedClusterInternal :
        Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IResourceInternal,
        Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IBaseManagedClusterInternal
    {
        /// <summary>The managed cluster SKU.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IManagedClusterSku Sku { get; set; }
        /// <summary>Name of a managed cluster SKU.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Aks.Support.ManagedClusterSkuName? SkuName { get; set; }
        /// <summary>Tier of a managed cluster SKU.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Aks.Support.ManagedClusterSkuTier? SkuTier { get; set; }

    }
}