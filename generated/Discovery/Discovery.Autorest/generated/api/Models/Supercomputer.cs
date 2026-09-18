// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
// Changes may cause incorrect behavior and will be lost if the code is regenerated.
namespace Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Discovery.Runtime.Extensions;

    /// <summary>Supercomputer tracked resource</summary>
    public partial class Supercomputer :
        Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.ISupercomputer,
        Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.ISupercomputerInternal,
        Microsoft.Azure.PowerShell.Cmdlets.Discovery.Runtime.IValidates
    {
        /// <summary>
        /// Backing field for Inherited model <see cref= "Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.ITrackedResource" />
        /// </summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.ITrackedResource __trackedResource = new Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.TrackedResource();

        /// <summary>The client ID of the assigned identity.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Discovery.Origin(Microsoft.Azure.PowerShell.Cmdlets.Discovery.PropertyOrigin.Inlined)]
        public string ClusterIdentityClientId { get => ((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.ISupercomputerPropertiesInternal)Property).ClusterIdentityClientId; }

        /// <summary>The resource ID of the user assigned identity.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Discovery.Origin(Microsoft.Azure.PowerShell.Cmdlets.Discovery.PropertyOrigin.Inlined)]
        public string ClusterIdentityId { get => ((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.ISupercomputerPropertiesInternal)Property).ClusterIdentityId; set => ((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.ISupercomputerPropertiesInternal)Property).ClusterIdentityId = value ?? null; }

        /// <summary>The principal ID of the assigned identity.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Discovery.Origin(Microsoft.Azure.PowerShell.Cmdlets.Discovery.PropertyOrigin.Inlined)]
        public string ClusterIdentityPrincipalId { get => ((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.ISupercomputerPropertiesInternal)Property).ClusterIdentityPrincipalId; }

        /// <summary>Whether or not to use a customer managed key when encrypting data at rest</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Discovery.Origin(Microsoft.Azure.PowerShell.Cmdlets.Discovery.PropertyOrigin.Inlined)]
        public string CustomerManagedKey { get => ((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.ISupercomputerPropertiesInternal)Property).CustomerManagedKey; set => ((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.ISupercomputerPropertiesInternal)Property).CustomerManagedKey = value ?? null; }

        /// <summary>
        /// Disk Encryption Set ID to use for Customer Managed Keys encryption. Required if Customer Managed Keys is enabled.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Discovery.Origin(Microsoft.Azure.PowerShell.Cmdlets.Discovery.PropertyOrigin.Inlined)]
        public string DiskEncryptionSetId { get => ((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.ISupercomputerPropertiesInternal)Property).DiskEncryptionSetId; set => ((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.ISupercomputerPropertiesInternal)Property).DiskEncryptionSetId = value ?? null; }

        /// <summary>
        /// Fully qualified resource ID for the resource. Ex - /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/{resourceProviderNamespace}/{resourceType}/{resourceName}
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Discovery.Origin(Microsoft.Azure.PowerShell.Cmdlets.Discovery.PropertyOrigin.Inherited)]
        public string Id { get => ((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IResourceInternal)__trackedResource).Id; }

        /// <summary>Backing field for <see cref="Identity" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.ISystemAssignedServiceIdentity _identity;

        /// <summary>The managed service identities assigned to this resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Discovery.Origin(Microsoft.Azure.PowerShell.Cmdlets.Discovery.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.ISystemAssignedServiceIdentity Identity { get => (this._identity = this._identity ?? new Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.SystemAssignedServiceIdentity()); set => this._identity = value; }

        /// <summary>
        /// The service principal ID of the system assigned identity. This property will only be provided for a system assigned identity.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Discovery.Origin(Microsoft.Azure.PowerShell.Cmdlets.Discovery.PropertyOrigin.Inlined)]
        public string IdentityPrincipalId { get => ((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.ISystemAssignedServiceIdentityInternal)Identity).PrincipalId; }

        /// <summary>
        /// The tenant ID of the system assigned identity. This property will only be provided for a system assigned identity.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Discovery.Origin(Microsoft.Azure.PowerShell.Cmdlets.Discovery.PropertyOrigin.Inlined)]
        public string IdentityTenantId { get => ((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.ISystemAssignedServiceIdentityInternal)Identity).TenantId; }

        /// <summary>The type of managed identity assigned to this resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Discovery.Origin(Microsoft.Azure.PowerShell.Cmdlets.Discovery.PropertyOrigin.Inlined)]
        public string IdentityType { get => ((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.ISystemAssignedServiceIdentityInternal)Identity).Type; set => ((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.ISystemAssignedServiceIdentityInternal)Identity).Type = value ?? null; }

        /// <summary>
        /// User assigned identity IDs to be used by workloads as federated credentials running on supercomputer. The key value must
        /// be the resource ID of the identity resource.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Discovery.Origin(Microsoft.Azure.PowerShell.Cmdlets.Discovery.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.ISupercomputerIdentitiesWorkloadIdentities IdentityWorkloadIdentity { get => ((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.ISupercomputerPropertiesInternal)Property).IdentityWorkloadIdentity; set => ((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.ISupercomputerPropertiesInternal)Property).IdentityWorkloadIdentity = value ?? null /* model class */; }

        /// <summary>The client ID of the assigned identity.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Discovery.Origin(Microsoft.Azure.PowerShell.Cmdlets.Discovery.PropertyOrigin.Inlined)]
        public string KubeletIdentityClientId { get => ((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.ISupercomputerPropertiesInternal)Property).KubeletIdentityClientId; }

        /// <summary>The resource ID of the user assigned identity.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Discovery.Origin(Microsoft.Azure.PowerShell.Cmdlets.Discovery.PropertyOrigin.Inlined)]
        public string KubeletIdentityId { get => ((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.ISupercomputerPropertiesInternal)Property).KubeletIdentityId; set => ((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.ISupercomputerPropertiesInternal)Property).KubeletIdentityId = value ?? null; }

        /// <summary>The principal ID of the assigned identity.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Discovery.Origin(Microsoft.Azure.PowerShell.Cmdlets.Discovery.PropertyOrigin.Inlined)]
        public string KubeletIdentityPrincipalId { get => ((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.ISupercomputerPropertiesInternal)Property).KubeletIdentityPrincipalId; }

        /// <summary>The geo-location where the resource lives</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Discovery.Origin(Microsoft.Azure.PowerShell.Cmdlets.Discovery.PropertyOrigin.Inherited)]
        public string Location { get => ((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.ITrackedResourceInternal)__trackedResource).Location; set => ((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.ITrackedResourceInternal)__trackedResource).Location = value ?? null; }

        /// <summary>
        /// The Log Analytics Cluster to use for debug logs. This is required when Customer Managed Keys are enabled.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Discovery.Origin(Microsoft.Azure.PowerShell.Cmdlets.Discovery.PropertyOrigin.Inlined)]
        public string LogAnalyticsClusterId { get => ((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.ISupercomputerPropertiesInternal)Property).LogAnalyticsClusterId; set => ((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.ISupercomputerPropertiesInternal)Property).LogAnalyticsClusterId = value ?? null; }

        /// <summary>Managed-On-Behalf-Of broker resources</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Discovery.Origin(Microsoft.Azure.PowerShell.Cmdlets.Discovery.PropertyOrigin.Inlined)]
        public System.Collections.Generic.List<Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IMoboBrokerResource> ManagedOnBehalfOfConfigurationMoboBrokerResource { get => ((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.ISupercomputerPropertiesInternal)Property).ManagedOnBehalfOfConfigurationMoboBrokerResource; }

        /// <summary>The resource group for resources managed on behalf of customer.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Discovery.Origin(Microsoft.Azure.PowerShell.Cmdlets.Discovery.PropertyOrigin.Inlined)]
        public string ManagedResourceGroup { get => ((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.ISupercomputerPropertiesInternal)Property).ManagedResourceGroup; }

        /// <summary>
        /// System Subnet ID associated with AKS apiserver. Must be delegated to Microsoft.ContainerService/managedClusters.
        /// It should have connectivity to the system subnet and nodepool subnets.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Discovery.Origin(Microsoft.Azure.PowerShell.Cmdlets.Discovery.PropertyOrigin.Inlined)]
        public string ManagementSubnetId { get => ((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.ISupercomputerPropertiesInternal)Property).ManagementSubnetId; set => ((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.ISupercomputerPropertiesInternal)Property).ManagementSubnetId = value ?? null; }

        /// <summary>Internal Acessors for Id</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IResourceInternal.Id { get => ((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IResourceInternal)__trackedResource).Id; set => ((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IResourceInternal)__trackedResource).Id = value ?? null; }

        /// <summary>Internal Acessors for Name</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IResourceInternal.Name { get => ((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IResourceInternal)__trackedResource).Name; set => ((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IResourceInternal)__trackedResource).Name = value ?? null; }

        /// <summary>Internal Acessors for SystemData</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.ISystemData Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IResourceInternal.SystemData { get => ((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IResourceInternal)__trackedResource).SystemData; set => ((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IResourceInternal)__trackedResource).SystemData = value ?? null /* model class */; }

        /// <summary>Internal Acessors for SystemDataCreatedAt</summary>
        global::System.DateTime? Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IResourceInternal.SystemDataCreatedAt { get => ((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IResourceInternal)__trackedResource).SystemDataCreatedAt; set => ((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IResourceInternal)__trackedResource).SystemDataCreatedAt = value ?? default(global::System.DateTime); }

        /// <summary>Internal Acessors for SystemDataCreatedBy</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IResourceInternal.SystemDataCreatedBy { get => ((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IResourceInternal)__trackedResource).SystemDataCreatedBy; set => ((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IResourceInternal)__trackedResource).SystemDataCreatedBy = value ?? null; }

        /// <summary>Internal Acessors for SystemDataCreatedByType</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IResourceInternal.SystemDataCreatedByType { get => ((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IResourceInternal)__trackedResource).SystemDataCreatedByType; set => ((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IResourceInternal)__trackedResource).SystemDataCreatedByType = value ?? null; }

        /// <summary>Internal Acessors for SystemDataLastModifiedAt</summary>
        global::System.DateTime? Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IResourceInternal.SystemDataLastModifiedAt { get => ((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IResourceInternal)__trackedResource).SystemDataLastModifiedAt; set => ((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IResourceInternal)__trackedResource).SystemDataLastModifiedAt = value ?? default(global::System.DateTime); }

        /// <summary>Internal Acessors for SystemDataLastModifiedBy</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IResourceInternal.SystemDataLastModifiedBy { get => ((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IResourceInternal)__trackedResource).SystemDataLastModifiedBy; set => ((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IResourceInternal)__trackedResource).SystemDataLastModifiedBy = value ?? null; }

        /// <summary>Internal Acessors for SystemDataLastModifiedByType</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IResourceInternal.SystemDataLastModifiedByType { get => ((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IResourceInternal)__trackedResource).SystemDataLastModifiedByType; set => ((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IResourceInternal)__trackedResource).SystemDataLastModifiedByType = value ?? null; }

        /// <summary>Internal Acessors for Type</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IResourceInternal.Type { get => ((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IResourceInternal)__trackedResource).Type; set => ((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IResourceInternal)__trackedResource).Type = value ?? null; }

        /// <summary>Internal Acessors for ClusterIdentityClientId</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.ISupercomputerInternal.ClusterIdentityClientId { get => ((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.ISupercomputerPropertiesInternal)Property).ClusterIdentityClientId; set => ((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.ISupercomputerPropertiesInternal)Property).ClusterIdentityClientId = value ?? null; }

        /// <summary>Internal Acessors for ClusterIdentityPrincipalId</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.ISupercomputerInternal.ClusterIdentityPrincipalId { get => ((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.ISupercomputerPropertiesInternal)Property).ClusterIdentityPrincipalId; set => ((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.ISupercomputerPropertiesInternal)Property).ClusterIdentityPrincipalId = value ?? null; }

        /// <summary>Internal Acessors for Identities</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.ISupercomputerIdentities Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.ISupercomputerInternal.Identities { get => ((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.ISupercomputerPropertiesInternal)Property).Identity; set => ((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.ISupercomputerPropertiesInternal)Property).Identity = value ?? null /* model class */; }

        /// <summary>Internal Acessors for Identity</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.ISystemAssignedServiceIdentity Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.ISupercomputerInternal.Identity { get => (this._identity = this._identity ?? new Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.SystemAssignedServiceIdentity()); set { {_identity = value;} } }

        /// <summary>Internal Acessors for IdentityClusterIdentity</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IIdentity Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.ISupercomputerInternal.IdentityClusterIdentity { get => ((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.ISupercomputerPropertiesInternal)Property).IdentityClusterIdentity; set => ((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.ISupercomputerPropertiesInternal)Property).IdentityClusterIdentity = value ?? null /* model class */; }

        /// <summary>Internal Acessors for IdentityKubeletIdentity</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IIdentity Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.ISupercomputerInternal.IdentityKubeletIdentity { get => ((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.ISupercomputerPropertiesInternal)Property).IdentityKubeletIdentity; set => ((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.ISupercomputerPropertiesInternal)Property).IdentityKubeletIdentity = value ?? null /* model class */; }

        /// <summary>Internal Acessors for IdentityPrincipalId</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.ISupercomputerInternal.IdentityPrincipalId { get => ((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.ISystemAssignedServiceIdentityInternal)Identity).PrincipalId; set => ((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.ISystemAssignedServiceIdentityInternal)Identity).PrincipalId = value ?? null; }

        /// <summary>Internal Acessors for IdentityTenantId</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.ISupercomputerInternal.IdentityTenantId { get => ((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.ISystemAssignedServiceIdentityInternal)Identity).TenantId; set => ((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.ISystemAssignedServiceIdentityInternal)Identity).TenantId = value ?? null; }

        /// <summary>Internal Acessors for KubeletIdentityClientId</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.ISupercomputerInternal.KubeletIdentityClientId { get => ((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.ISupercomputerPropertiesInternal)Property).KubeletIdentityClientId; set => ((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.ISupercomputerPropertiesInternal)Property).KubeletIdentityClientId = value ?? null; }

        /// <summary>Internal Acessors for KubeletIdentityPrincipalId</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.ISupercomputerInternal.KubeletIdentityPrincipalId { get => ((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.ISupercomputerPropertiesInternal)Property).KubeletIdentityPrincipalId; set => ((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.ISupercomputerPropertiesInternal)Property).KubeletIdentityPrincipalId = value ?? null; }

        /// <summary>Internal Acessors for ManagedOnBehalfOfConfiguration</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IWithMoboBrokerResources Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.ISupercomputerInternal.ManagedOnBehalfOfConfiguration { get => ((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.ISupercomputerPropertiesInternal)Property).ManagedOnBehalfOfConfiguration; set => ((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.ISupercomputerPropertiesInternal)Property).ManagedOnBehalfOfConfiguration = value ?? null /* model class */; }

        /// <summary>Internal Acessors for ManagedOnBehalfOfConfigurationMoboBrokerResource</summary>
        System.Collections.Generic.List<Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IMoboBrokerResource> Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.ISupercomputerInternal.ManagedOnBehalfOfConfigurationMoboBrokerResource { get => ((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.ISupercomputerPropertiesInternal)Property).ManagedOnBehalfOfConfigurationMoboBrokerResource; set => ((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.ISupercomputerPropertiesInternal)Property).ManagedOnBehalfOfConfigurationMoboBrokerResource = value ?? null /* arrayOf */; }

        /// <summary>Internal Acessors for ManagedResourceGroup</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.ISupercomputerInternal.ManagedResourceGroup { get => ((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.ISupercomputerPropertiesInternal)Property).ManagedResourceGroup; set => ((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.ISupercomputerPropertiesInternal)Property).ManagedResourceGroup = value ?? null; }

        /// <summary>Internal Acessors for Property</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.ISupercomputerProperties Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.ISupercomputerInternal.Property { get => (this._property = this._property ?? new Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.SupercomputerProperties()); set { {_property = value;} } }

        /// <summary>Internal Acessors for ProvisioningState</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.ISupercomputerInternal.ProvisioningState { get => ((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.ISupercomputerPropertiesInternal)Property).ProvisioningState; set => ((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.ISupercomputerPropertiesInternal)Property).ProvisioningState = value ?? null; }

        /// <summary>The name of the resource</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Discovery.Origin(Microsoft.Azure.PowerShell.Cmdlets.Discovery.PropertyOrigin.Inherited)]
        public string Name { get => ((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IResourceInternal)__trackedResource).Name; }

        /// <summary>
        /// Network egress type provisioned for the supercomputer workloads.
        /// Defaults to LoadBalancer if not specified.
        /// If None is specified, the customer is responsible for providing outbound connectivity for Supercomputer functionality.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Discovery.Origin(Microsoft.Azure.PowerShell.Cmdlets.Discovery.PropertyOrigin.Inlined)]
        public string OutboundType { get => ((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.ISupercomputerPropertiesInternal)Property).OutboundType; set => ((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.ISupercomputerPropertiesInternal)Property).OutboundType = value ?? null; }

        /// <summary>Backing field for <see cref="Property" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.ISupercomputerProperties _property;

        /// <summary>The resource-specific properties for this resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Discovery.Origin(Microsoft.Azure.PowerShell.Cmdlets.Discovery.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.ISupercomputerProperties Property { get => (this._property = this._property ?? new Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.SupercomputerProperties()); set => this._property = value; }

        /// <summary>The status of the last operation.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Discovery.Origin(Microsoft.Azure.PowerShell.Cmdlets.Discovery.PropertyOrigin.Inlined)]
        public string ProvisioningState { get => ((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.ISupercomputerPropertiesInternal)Property).ProvisioningState; }

        /// <summary>Gets the resource group name</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Discovery.Origin(Microsoft.Azure.PowerShell.Cmdlets.Discovery.PropertyOrigin.Owned)]
        public string ResourceGroupName { get => (new global::System.Text.RegularExpressions.Regex("^/subscriptions/(?<subscriptionId>[^/]+)/resourceGroups/(?<resourceGroupName>[^/]+)/providers/", global::System.Text.RegularExpressions.RegexOptions.IgnoreCase).Match(this.Id).Success ? new global::System.Text.RegularExpressions.Regex("^/subscriptions/(?<subscriptionId>[^/]+)/resourceGroups/(?<resourceGroupName>[^/]+)/providers/", global::System.Text.RegularExpressions.RegexOptions.IgnoreCase).Match(this.Id).Groups["resourceGroupName"].Value : null); }

        /// <summary>
        /// System Subnet ID associated with managed NodePool for system resources.
        /// It should have connectivity to the child NodePool subnets.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Discovery.Origin(Microsoft.Azure.PowerShell.Cmdlets.Discovery.PropertyOrigin.Inlined)]
        public string SubnetId { get => ((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.ISupercomputerPropertiesInternal)Property).SubnetId; set => ((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.ISupercomputerPropertiesInternal)Property).SubnetId = value ?? null; }

        /// <summary>
        /// Azure Resource Manager metadata containing createdBy and modifiedBy information.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Discovery.Origin(Microsoft.Azure.PowerShell.Cmdlets.Discovery.PropertyOrigin.Inherited)]
        internal Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.ISystemData SystemData { get => ((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IResourceInternal)__trackedResource).SystemData; set => ((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IResourceInternal)__trackedResource).SystemData = value ?? null /* model class */; }

        /// <summary>The timestamp of resource creation (UTC).</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Discovery.Origin(Microsoft.Azure.PowerShell.Cmdlets.Discovery.PropertyOrigin.Inherited)]
        public global::System.DateTime? SystemDataCreatedAt { get => ((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IResourceInternal)__trackedResource).SystemDataCreatedAt; }

        /// <summary>The identity that created the resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Discovery.Origin(Microsoft.Azure.PowerShell.Cmdlets.Discovery.PropertyOrigin.Inherited)]
        public string SystemDataCreatedBy { get => ((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IResourceInternal)__trackedResource).SystemDataCreatedBy; }

        /// <summary>The type of identity that created the resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Discovery.Origin(Microsoft.Azure.PowerShell.Cmdlets.Discovery.PropertyOrigin.Inherited)]
        public string SystemDataCreatedByType { get => ((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IResourceInternal)__trackedResource).SystemDataCreatedByType; }

        /// <summary>The timestamp of resource last modification (UTC)</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Discovery.Origin(Microsoft.Azure.PowerShell.Cmdlets.Discovery.PropertyOrigin.Inherited)]
        public global::System.DateTime? SystemDataLastModifiedAt { get => ((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IResourceInternal)__trackedResource).SystemDataLastModifiedAt; }

        /// <summary>The identity that last modified the resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Discovery.Origin(Microsoft.Azure.PowerShell.Cmdlets.Discovery.PropertyOrigin.Inherited)]
        public string SystemDataLastModifiedBy { get => ((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IResourceInternal)__trackedResource).SystemDataLastModifiedBy; }

        /// <summary>The type of identity that last modified the resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Discovery.Origin(Microsoft.Azure.PowerShell.Cmdlets.Discovery.PropertyOrigin.Inherited)]
        public string SystemDataLastModifiedByType { get => ((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IResourceInternal)__trackedResource).SystemDataLastModifiedByType; }

        /// <summary>The SKU to use for the system node pool.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Discovery.Origin(Microsoft.Azure.PowerShell.Cmdlets.Discovery.PropertyOrigin.Inlined)]
        public string SystemSku { get => ((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.ISupercomputerPropertiesInternal)Property).SystemSku; set => ((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.ISupercomputerPropertiesInternal)Property).SystemSku = value ?? null; }

        /// <summary>Resource tags.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Discovery.Origin(Microsoft.Azure.PowerShell.Cmdlets.Discovery.PropertyOrigin.Inherited)]
        public Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.ITrackedResourceTags Tag { get => ((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.ITrackedResourceInternal)__trackedResource).Tag; set => ((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.ITrackedResourceInternal)__trackedResource).Tag = value ?? null /* model class */; }

        /// <summary>
        /// The type of the resource. E.g. "Microsoft.Compute/virtualMachines" or "Microsoft.Storage/storageAccounts"
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Discovery.Origin(Microsoft.Azure.PowerShell.Cmdlets.Discovery.PropertyOrigin.Inherited)]
        public string Type { get => ((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IResourceInternal)__trackedResource).Type; }

        /// <summary>Creates an new <see cref="Supercomputer" /> instance.</summary>
        public Supercomputer()
        {

        }

        /// <summary>Validates that this object meets the validation criteria.</summary>
        /// <param name="eventListener">an <see cref="Microsoft.Azure.PowerShell.Cmdlets.Discovery.Runtime.IEventListener" /> instance that will receive validation
        /// events.</param>
        /// <returns>
        /// A <see cref = "global::System.Threading.Tasks.Task" /> that will be complete when validation is completed.
        /// </returns>
        public async global::System.Threading.Tasks.Task Validate(Microsoft.Azure.PowerShell.Cmdlets.Discovery.Runtime.IEventListener eventListener)
        {
            await eventListener.AssertNotNull(nameof(__trackedResource), __trackedResource);
            await eventListener.AssertObjectIsValid(nameof(__trackedResource), __trackedResource);
        }
    }
    /// Supercomputer tracked resource
    public partial interface ISupercomputer :
        Microsoft.Azure.PowerShell.Cmdlets.Discovery.Runtime.IJsonSerializable,
        Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.ITrackedResource
    {
        /// <summary>The client ID of the assigned identity.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Discovery.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Read = true,
        Create = false,
        Update = false,
        Description = @"The client ID of the assigned identity.",
        SerializedName = @"clientId",
        PossibleTypes = new [] { typeof(string) })]
        string ClusterIdentityClientId { get;  }
        /// <summary>The resource ID of the user assigned identity.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Discovery.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = false,
        Description = @"The resource ID of the user assigned identity.",
        SerializedName = @"id",
        PossibleTypes = new [] { typeof(string) })]
        string ClusterIdentityId { get; set; }
        /// <summary>The principal ID of the assigned identity.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Discovery.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Read = true,
        Create = false,
        Update = false,
        Description = @"The principal ID of the assigned identity.",
        SerializedName = @"principalId",
        PossibleTypes = new [] { typeof(string) })]
        string ClusterIdentityPrincipalId { get;  }
        /// <summary>Whether or not to use a customer managed key when encrypting data at rest</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Discovery.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = false,
        Description = @"Whether or not to use a customer managed key when encrypting data at rest",
        SerializedName = @"customerManagedKeys",
        PossibleTypes = new [] { typeof(string) })]
        [global::Microsoft.Azure.PowerShell.Cmdlets.Discovery.PSArgumentCompleterAttribute("Enabled", "Disabled")]
        string CustomerManagedKey { get; set; }
        /// <summary>
        /// Disk Encryption Set ID to use for Customer Managed Keys encryption. Required if Customer Managed Keys is enabled.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Discovery.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = false,
        Description = @"Disk Encryption Set ID to use for Customer Managed Keys encryption. Required if Customer Managed Keys is enabled.",
        SerializedName = @"diskEncryptionSetId",
        PossibleTypes = new [] { typeof(string) })]
        string DiskEncryptionSetId { get; set; }
        /// <summary>
        /// The service principal ID of the system assigned identity. This property will only be provided for a system assigned identity.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Discovery.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Read = true,
        Create = false,
        Update = false,
        Description = @"The service principal ID of the system assigned identity. This property will only be provided for a system assigned identity.",
        SerializedName = @"principalId",
        PossibleTypes = new [] { typeof(string) })]
        string IdentityPrincipalId { get;  }
        /// <summary>
        /// The tenant ID of the system assigned identity. This property will only be provided for a system assigned identity.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Discovery.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Read = true,
        Create = false,
        Update = false,
        Description = @"The tenant ID of the system assigned identity. This property will only be provided for a system assigned identity.",
        SerializedName = @"tenantId",
        PossibleTypes = new [] { typeof(string) })]
        string IdentityTenantId { get;  }
        /// <summary>The type of managed identity assigned to this resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Discovery.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"The type of managed identity assigned to this resource.",
        SerializedName = @"type",
        PossibleTypes = new [] { typeof(string) })]
        [global::Microsoft.Azure.PowerShell.Cmdlets.Discovery.PSArgumentCompleterAttribute("None", "SystemAssigned")]
        string IdentityType { get; set; }
        /// <summary>
        /// User assigned identity IDs to be used by workloads as federated credentials running on supercomputer. The key value must
        /// be the resource ID of the identity resource.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Discovery.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"User assigned identity IDs to be used by workloads as federated credentials running on supercomputer. The key value must be the resource ID of the identity resource.",
        SerializedName = @"workloadIdentities",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.ISupercomputerIdentitiesWorkloadIdentities) })]
        Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.ISupercomputerIdentitiesWorkloadIdentities IdentityWorkloadIdentity { get; set; }
        /// <summary>The client ID of the assigned identity.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Discovery.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Read = true,
        Create = false,
        Update = false,
        Description = @"The client ID of the assigned identity.",
        SerializedName = @"clientId",
        PossibleTypes = new [] { typeof(string) })]
        string KubeletIdentityClientId { get;  }
        /// <summary>The resource ID of the user assigned identity.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Discovery.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = false,
        Description = @"The resource ID of the user assigned identity.",
        SerializedName = @"id",
        PossibleTypes = new [] { typeof(string) })]
        string KubeletIdentityId { get; set; }
        /// <summary>The principal ID of the assigned identity.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Discovery.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Read = true,
        Create = false,
        Update = false,
        Description = @"The principal ID of the assigned identity.",
        SerializedName = @"principalId",
        PossibleTypes = new [] { typeof(string) })]
        string KubeletIdentityPrincipalId { get;  }
        /// <summary>
        /// The Log Analytics Cluster to use for debug logs. This is required when Customer Managed Keys are enabled.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Discovery.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = false,
        Description = @"The Log Analytics Cluster to use for debug logs. This is required when Customer Managed Keys are enabled.",
        SerializedName = @"logAnalyticsClusterId",
        PossibleTypes = new [] { typeof(string) })]
        string LogAnalyticsClusterId { get; set; }
        /// <summary>Managed-On-Behalf-Of broker resources</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Discovery.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Read = true,
        Create = false,
        Update = false,
        Description = @"Managed-On-Behalf-Of broker resources",
        SerializedName = @"moboBrokerResources",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IMoboBrokerResource) })]
        System.Collections.Generic.List<Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IMoboBrokerResource> ManagedOnBehalfOfConfigurationMoboBrokerResource { get;  }
        /// <summary>The resource group for resources managed on behalf of customer.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Discovery.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Read = true,
        Create = false,
        Update = false,
        Description = @"The resource group for resources managed on behalf of customer.",
        SerializedName = @"managedResourceGroup",
        PossibleTypes = new [] { typeof(string) })]
        string ManagedResourceGroup { get;  }
        /// <summary>
        /// System Subnet ID associated with AKS apiserver. Must be delegated to Microsoft.ContainerService/managedClusters.
        /// It should have connectivity to the system subnet and nodepool subnets.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Discovery.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = false,
        Description = @"System Subnet ID associated with AKS apiserver. Must be delegated to Microsoft.ContainerService/managedClusters.
            It should have connectivity to the system subnet and nodepool subnets.",
        SerializedName = @"managementSubnetId",
        PossibleTypes = new [] { typeof(string) })]
        string ManagementSubnetId { get; set; }
        /// <summary>
        /// Network egress type provisioned for the supercomputer workloads.
        /// Defaults to LoadBalancer if not specified.
        /// If None is specified, the customer is responsible for providing outbound connectivity for Supercomputer functionality.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Discovery.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = false,
        Description = @"Network egress type provisioned for the supercomputer workloads.
            Defaults to LoadBalancer if not specified.
            If None is specified, the customer is responsible for providing outbound connectivity for Supercomputer functionality.",
        SerializedName = @"outboundType",
        PossibleTypes = new [] { typeof(string) })]
        [global::Microsoft.Azure.PowerShell.Cmdlets.Discovery.PSArgumentCompleterAttribute("LoadBalancer", "None")]
        string OutboundType { get; set; }
        /// <summary>The status of the last operation.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Discovery.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Read = true,
        Create = false,
        Update = false,
        Description = @"The status of the last operation.",
        SerializedName = @"provisioningState",
        PossibleTypes = new [] { typeof(string) })]
        [global::Microsoft.Azure.PowerShell.Cmdlets.Discovery.PSArgumentCompleterAttribute("Succeeded", "Failed", "Canceled", "Accepted", "Provisioning", "Updating", "Deleting")]
        string ProvisioningState { get;  }
        /// <summary>
        /// System Subnet ID associated with managed NodePool for system resources.
        /// It should have connectivity to the child NodePool subnets.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Discovery.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = false,
        Description = @"System Subnet ID associated with managed NodePool for system resources.
            It should have connectivity to the child NodePool subnets.",
        SerializedName = @"subnetId",
        PossibleTypes = new [] { typeof(string) })]
        string SubnetId { get; set; }
        /// <summary>The SKU to use for the system node pool.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Discovery.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = false,
        Description = @"The SKU to use for the system node pool.",
        SerializedName = @"systemSku",
        PossibleTypes = new [] { typeof(string) })]
        [global::Microsoft.Azure.PowerShell.Cmdlets.Discovery.PSArgumentCompleterAttribute("Standard_D4s_v6", "Standard_D4s_v5", "Standard_D4s_v4")]
        string SystemSku { get; set; }

    }
    /// Supercomputer tracked resource
    internal partial interface ISupercomputerInternal :
        Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.ITrackedResourceInternal
    {
        /// <summary>The client ID of the assigned identity.</summary>
        string ClusterIdentityClientId { get; set; }
        /// <summary>The resource ID of the user assigned identity.</summary>
        string ClusterIdentityId { get; set; }
        /// <summary>The principal ID of the assigned identity.</summary>
        string ClusterIdentityPrincipalId { get; set; }
        /// <summary>Whether or not to use a customer managed key when encrypting data at rest</summary>
        [global::Microsoft.Azure.PowerShell.Cmdlets.Discovery.PSArgumentCompleterAttribute("Enabled", "Disabled")]
        string CustomerManagedKey { get; set; }
        /// <summary>
        /// Disk Encryption Set ID to use for Customer Managed Keys encryption. Required if Customer Managed Keys is enabled.
        /// </summary>
        string DiskEncryptionSetId { get; set; }
        /// <summary>Dictionary of identity properties.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.ISupercomputerIdentities Identities { get; set; }
        /// <summary>The managed service identities assigned to this resource.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.ISystemAssignedServiceIdentity Identity { get; set; }
        /// <summary>Cluster identity ID.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IIdentity IdentityClusterIdentity { get; set; }
        /// <summary>
        /// Kubelet identity ID used by the supercomputer.
        /// This identity is used by the supercomputer at node level to access Azure resources.
        /// This identity must have ManagedIdentityOperator role on the clusterIdentity.
        /// </summary>
        Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IIdentity IdentityKubeletIdentity { get; set; }
        /// <summary>
        /// The service principal ID of the system assigned identity. This property will only be provided for a system assigned identity.
        /// </summary>
        string IdentityPrincipalId { get; set; }
        /// <summary>
        /// The tenant ID of the system assigned identity. This property will only be provided for a system assigned identity.
        /// </summary>
        string IdentityTenantId { get; set; }
        /// <summary>The type of managed identity assigned to this resource.</summary>
        [global::Microsoft.Azure.PowerShell.Cmdlets.Discovery.PSArgumentCompleterAttribute("None", "SystemAssigned")]
        string IdentityType { get; set; }
        /// <summary>
        /// User assigned identity IDs to be used by workloads as federated credentials running on supercomputer. The key value must
        /// be the resource ID of the identity resource.
        /// </summary>
        Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.ISupercomputerIdentitiesWorkloadIdentities IdentityWorkloadIdentity { get; set; }
        /// <summary>The client ID of the assigned identity.</summary>
        string KubeletIdentityClientId { get; set; }
        /// <summary>The resource ID of the user assigned identity.</summary>
        string KubeletIdentityId { get; set; }
        /// <summary>The principal ID of the assigned identity.</summary>
        string KubeletIdentityPrincipalId { get; set; }
        /// <summary>
        /// The Log Analytics Cluster to use for debug logs. This is required when Customer Managed Keys are enabled.
        /// </summary>
        string LogAnalyticsClusterId { get; set; }
        /// <summary>
        /// Managed-On-Behalf-Of configuration properties. This configuration exists for the resources where a resource provider manages
        /// those resources on behalf of the resource owner.
        /// </summary>
        Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IWithMoboBrokerResources ManagedOnBehalfOfConfiguration { get; set; }
        /// <summary>Managed-On-Behalf-Of broker resources</summary>
        System.Collections.Generic.List<Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IMoboBrokerResource> ManagedOnBehalfOfConfigurationMoboBrokerResource { get; set; }
        /// <summary>The resource group for resources managed on behalf of customer.</summary>
        string ManagedResourceGroup { get; set; }
        /// <summary>
        /// System Subnet ID associated with AKS apiserver. Must be delegated to Microsoft.ContainerService/managedClusters.
        /// It should have connectivity to the system subnet and nodepool subnets.
        /// </summary>
        string ManagementSubnetId { get; set; }
        /// <summary>
        /// Network egress type provisioned for the supercomputer workloads.
        /// Defaults to LoadBalancer if not specified.
        /// If None is specified, the customer is responsible for providing outbound connectivity for Supercomputer functionality.
        /// </summary>
        [global::Microsoft.Azure.PowerShell.Cmdlets.Discovery.PSArgumentCompleterAttribute("LoadBalancer", "None")]
        string OutboundType { get; set; }
        /// <summary>The resource-specific properties for this resource.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.ISupercomputerProperties Property { get; set; }
        /// <summary>The status of the last operation.</summary>
        [global::Microsoft.Azure.PowerShell.Cmdlets.Discovery.PSArgumentCompleterAttribute("Succeeded", "Failed", "Canceled", "Accepted", "Provisioning", "Updating", "Deleting")]
        string ProvisioningState { get; set; }
        /// <summary>
        /// System Subnet ID associated with managed NodePool for system resources.
        /// It should have connectivity to the child NodePool subnets.
        /// </summary>
        string SubnetId { get; set; }
        /// <summary>The SKU to use for the system node pool.</summary>
        [global::Microsoft.Azure.PowerShell.Cmdlets.Discovery.PSArgumentCompleterAttribute("Standard_D4s_v6", "Standard_D4s_v5", "Standard_D4s_v4")]
        string SystemSku { get; set; }

    }
}