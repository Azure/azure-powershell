namespace Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Kusto.Runtime.Extensions;

    /// <summary>Class representing a Kusto cluster.</summary>
    public partial class Cluster :
        Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.ICluster,
        Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IClusterInternal,
        Microsoft.Azure.PowerShell.Cmdlets.Kusto.Runtime.IValidates
    {
        /// <summary>
        /// Backing field for Inherited model <see cref= "Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api10.ITrackedResource"
        /// />
        /// </summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api10.ITrackedResource __trackedResource = new Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api10.TrackedResource();

        /// <summary>The cluster data ingestion URI.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Kusto.Origin(Microsoft.Azure.PowerShell.Cmdlets.Kusto.PropertyOrigin.Inlined)]
        public string DataIngestionUri { get => ((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IClusterPropertiesInternal)Property).DataIngestionUri; }

        /// <summary>A boolean value that indicates if the cluster's disks are encrypted.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Kusto.Origin(Microsoft.Azure.PowerShell.Cmdlets.Kusto.PropertyOrigin.Inlined)]
        public bool? EnableDiskEncryption { get => ((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IClusterPropertiesInternal)Property).EnableDiskEncryption; set => ((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IClusterPropertiesInternal)Property).EnableDiskEncryption = value; }

        /// <summary>A boolean value that indicates if double encryption is enabled.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Kusto.Origin(Microsoft.Azure.PowerShell.Cmdlets.Kusto.PropertyOrigin.Inlined)]
        public bool? EnableDoubleEncryption { get => ((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IClusterPropertiesInternal)Property).EnableDoubleEncryption; set => ((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IClusterPropertiesInternal)Property).EnableDoubleEncryption = value; }

        /// <summary>A boolean value that indicates if the purge operations are enabled.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Kusto.Origin(Microsoft.Azure.PowerShell.Cmdlets.Kusto.PropertyOrigin.Inlined)]
        public bool? EnablePurge { get => ((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IClusterPropertiesInternal)Property).EnablePurge; set => ((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IClusterPropertiesInternal)Property).EnablePurge = value; }

        /// <summary>A boolean value that indicates if the streaming ingest is enabled.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Kusto.Origin(Microsoft.Azure.PowerShell.Cmdlets.Kusto.PropertyOrigin.Inlined)]
        public bool? EnableStreamingIngest { get => ((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IClusterPropertiesInternal)Property).EnableStreamingIngest; set => ((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IClusterPropertiesInternal)Property).EnableStreamingIngest = value; }

        /// <summary>
        /// Fully qualified resource Id for the resource. Ex - /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/{resourceProviderNamespace}/{resourceType}/{resourceName}
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Kusto.Origin(Microsoft.Azure.PowerShell.Cmdlets.Kusto.PropertyOrigin.Inherited)]
        public string Id { get => ((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api10.IResourceInternal)__trackedResource).Id; }

        /// <summary>Backing field for <see cref="Identity" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IIdentity _identity;

        /// <summary>The identity of the cluster, if configured.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Kusto.Origin(Microsoft.Azure.PowerShell.Cmdlets.Kusto.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IIdentity Identity { get => (this._identity = this._identity ?? new Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.Identity()); set => this._identity = value; }

        /// <summary>The principal ID of resource identity.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Kusto.Origin(Microsoft.Azure.PowerShell.Cmdlets.Kusto.PropertyOrigin.Inlined)]
        public string IdentityPrincipalId { get => ((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IIdentityInternal)Identity).PrincipalId; }

        /// <summary>The tenant ID of resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Kusto.Origin(Microsoft.Azure.PowerShell.Cmdlets.Kusto.PropertyOrigin.Inlined)]
        public string IdentityTenantId { get => ((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IIdentityInternal)Identity).TenantId; }

        /// <summary>The identity type.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Kusto.Origin(Microsoft.Azure.PowerShell.Cmdlets.Kusto.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.Kusto.Support.IdentityType IdentityType { get => ((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IIdentityInternal)Identity).Type; set => ((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IIdentityInternal)Identity).Type = value; }

        /// <summary>
        /// The list of user identities associated with the Kusto cluster. The user identity dictionary key references will be ARM
        /// resource ids in the form: '/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ManagedIdentity/userAssignedIdentities/{identityName}'.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Kusto.Origin(Microsoft.Azure.PowerShell.Cmdlets.Kusto.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IIdentityUserAssignedIdentities IdentityUserAssignedIdentity { get => ((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IIdentityInternal)Identity).UserAssignedIdentity; set => ((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IIdentityInternal)Identity).UserAssignedIdentity = value; }

        /// <summary>The name of the key vault key.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Kusto.Origin(Microsoft.Azure.PowerShell.Cmdlets.Kusto.PropertyOrigin.Inlined)]
        public string KeyVaultPropertyKeyName { get => ((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IClusterPropertiesInternal)Property).KeyVaultPropertyKeyName; set => ((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IClusterPropertiesInternal)Property).KeyVaultPropertyKeyName = value; }

        /// <summary>The Uri of the key vault.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Kusto.Origin(Microsoft.Azure.PowerShell.Cmdlets.Kusto.PropertyOrigin.Inlined)]
        public string KeyVaultPropertyKeyVaultUri { get => ((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IClusterPropertiesInternal)Property).KeyVaultPropertyKeyVaultUri; set => ((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IClusterPropertiesInternal)Property).KeyVaultPropertyKeyVaultUri = value; }

        /// <summary>The version of the key vault key.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Kusto.Origin(Microsoft.Azure.PowerShell.Cmdlets.Kusto.PropertyOrigin.Inlined)]
        public string KeyVaultPropertyKeyVersion { get => ((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IClusterPropertiesInternal)Property).KeyVaultPropertyKeyVersion; set => ((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IClusterPropertiesInternal)Property).KeyVaultPropertyKeyVersion = value; }

        /// <summary>The list of language extensions.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Kusto.Origin(Microsoft.Azure.PowerShell.Cmdlets.Kusto.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.ILanguageExtension[] LanguageExtensionValue { get => ((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IClusterPropertiesInternal)Property).LanguageExtensionValue; set => ((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IClusterPropertiesInternal)Property).LanguageExtensionValue = value; }

        /// <summary>The geo-location where the resource lives</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Kusto.Origin(Microsoft.Azure.PowerShell.Cmdlets.Kusto.PropertyOrigin.Inherited)]
        public string Location { get => ((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api10.ITrackedResourceInternal)__trackedResource).Location; set => ((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api10.ITrackedResourceInternal)__trackedResource).Location = value; }

        /// <summary>Internal Acessors for Id</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api10.IResourceInternal.Id { get => ((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api10.IResourceInternal)__trackedResource).Id; set => ((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api10.IResourceInternal)__trackedResource).Id = value; }

        /// <summary>Internal Acessors for Name</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api10.IResourceInternal.Name { get => ((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api10.IResourceInternal)__trackedResource).Name; set => ((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api10.IResourceInternal)__trackedResource).Name = value; }

        /// <summary>Internal Acessors for Type</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api10.IResourceInternal.Type { get => ((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api10.IResourceInternal)__trackedResource).Type; set => ((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api10.IResourceInternal)__trackedResource).Type = value; }

        /// <summary>Internal Acessors for DataIngestionUri</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IClusterInternal.DataIngestionUri { get => ((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IClusterPropertiesInternal)Property).DataIngestionUri; set => ((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IClusterPropertiesInternal)Property).DataIngestionUri = value; }

        /// <summary>Internal Acessors for Identity</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IIdentity Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IClusterInternal.Identity { get => (this._identity = this._identity ?? new Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.Identity()); set { {_identity = value;} } }

        /// <summary>Internal Acessors for IdentityPrincipalId</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IClusterInternal.IdentityPrincipalId { get => ((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IIdentityInternal)Identity).PrincipalId; set => ((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IIdentityInternal)Identity).PrincipalId = value; }

        /// <summary>Internal Acessors for IdentityTenantId</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IClusterInternal.IdentityTenantId { get => ((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IIdentityInternal)Identity).TenantId; set => ((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IIdentityInternal)Identity).TenantId = value; }

        /// <summary>Internal Acessors for KeyVaultProperty</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IKeyVaultProperties Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IClusterInternal.KeyVaultProperty { get => ((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IClusterPropertiesInternal)Property).KeyVaultProperty; set => ((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IClusterPropertiesInternal)Property).KeyVaultProperty = value; }

        /// <summary>Internal Acessors for LanguageExtension</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.ILanguageExtensionsList Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IClusterInternal.LanguageExtension { get => ((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IClusterPropertiesInternal)Property).LanguageExtension; set => ((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IClusterPropertiesInternal)Property).LanguageExtension = value; }

        /// <summary>Internal Acessors for OptimizedAutoscale</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IOptimizedAutoscale Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IClusterInternal.OptimizedAutoscale { get => ((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IClusterPropertiesInternal)Property).OptimizedAutoscale; set => ((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IClusterPropertiesInternal)Property).OptimizedAutoscale = value; }

        /// <summary>Internal Acessors for Property</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IClusterProperties Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IClusterInternal.Property { get => (this._property = this._property ?? new Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.ClusterProperties()); set { {_property = value;} } }

        /// <summary>Internal Acessors for ProvisioningState</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Kusto.Support.ProvisioningState? Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IClusterInternal.ProvisioningState { get => ((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IClusterPropertiesInternal)Property).ProvisioningState; set => ((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IClusterPropertiesInternal)Property).ProvisioningState = value; }

        /// <summary>Internal Acessors for Sku</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IAzureSku Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IClusterInternal.Sku { get => (this._sku = this._sku ?? new Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.AzureSku()); set { {_sku = value;} } }

        /// <summary>Internal Acessors for State</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Kusto.Support.State? Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IClusterInternal.State { get => ((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IClusterPropertiesInternal)Property).State; set => ((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IClusterPropertiesInternal)Property).State = value; }

        /// <summary>Internal Acessors for StateReason</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IClusterInternal.StateReason { get => ((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IClusterPropertiesInternal)Property).StateReason; set => ((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IClusterPropertiesInternal)Property).StateReason = value; }

        /// <summary>Internal Acessors for Uri</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IClusterInternal.Uri { get => ((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IClusterPropertiesInternal)Property).Uri; set => ((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IClusterPropertiesInternal)Property).Uri = value; }

        /// <summary>Internal Acessors for VirtualNetworkConfiguration</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IVirtualNetworkConfiguration Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IClusterInternal.VirtualNetworkConfiguration { get => ((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IClusterPropertiesInternal)Property).VirtualNetworkConfiguration; set => ((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IClusterPropertiesInternal)Property).VirtualNetworkConfiguration = value; }

        /// <summary>The name of the resource</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Kusto.Origin(Microsoft.Azure.PowerShell.Cmdlets.Kusto.PropertyOrigin.Inherited)]
        public string Name { get => ((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api10.IResourceInternal)__trackedResource).Name; }

        /// <summary>
        /// A boolean value that indicate if the optimized autoscale feature is enabled or not.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Kusto.Origin(Microsoft.Azure.PowerShell.Cmdlets.Kusto.PropertyOrigin.Inlined)]
        public bool OptimizedAutoscaleIsEnabled { get => ((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IClusterPropertiesInternal)Property).OptimizedAutoscaleIsEnabled; set => ((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IClusterPropertiesInternal)Property).OptimizedAutoscaleIsEnabled = value; }

        /// <summary>Maximum allowed instances count.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Kusto.Origin(Microsoft.Azure.PowerShell.Cmdlets.Kusto.PropertyOrigin.Inlined)]
        public int OptimizedAutoscaleMaximum { get => ((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IClusterPropertiesInternal)Property).OptimizedAutoscaleMaximum; set => ((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IClusterPropertiesInternal)Property).OptimizedAutoscaleMaximum = value; }

        /// <summary>Minimum allowed instances count.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Kusto.Origin(Microsoft.Azure.PowerShell.Cmdlets.Kusto.PropertyOrigin.Inlined)]
        public int OptimizedAutoscaleMinimum { get => ((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IClusterPropertiesInternal)Property).OptimizedAutoscaleMinimum; set => ((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IClusterPropertiesInternal)Property).OptimizedAutoscaleMinimum = value; }

        /// <summary>The version of the template defined, for instance 1.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Kusto.Origin(Microsoft.Azure.PowerShell.Cmdlets.Kusto.PropertyOrigin.Inlined)]
        public int OptimizedAutoscaleVersion { get => ((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IClusterPropertiesInternal)Property).OptimizedAutoscaleVersion; set => ((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IClusterPropertiesInternal)Property).OptimizedAutoscaleVersion = value; }

        /// <summary>Backing field for <see cref="Property" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IClusterProperties _property;

        /// <summary>The cluster properties.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Kusto.Origin(Microsoft.Azure.PowerShell.Cmdlets.Kusto.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IClusterProperties Property { get => (this._property = this._property ?? new Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.ClusterProperties()); set => this._property = value; }

        /// <summary>The provisioned state of the resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Kusto.Origin(Microsoft.Azure.PowerShell.Cmdlets.Kusto.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.Kusto.Support.ProvisioningState? ProvisioningState { get => ((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IClusterPropertiesInternal)Property).ProvisioningState; }

        /// <summary>Backing field for <see cref="Sku" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IAzureSku _sku;

        /// <summary>The SKU of the cluster.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Kusto.Origin(Microsoft.Azure.PowerShell.Cmdlets.Kusto.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IAzureSku Sku { get => (this._sku = this._sku ?? new Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.AzureSku()); set => this._sku = value; }

        /// <summary>The number of instances of the cluster.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Kusto.Origin(Microsoft.Azure.PowerShell.Cmdlets.Kusto.PropertyOrigin.Inlined)]
        public int? SkuCapacity { get => ((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IAzureSkuInternal)Sku).Capacity; set => ((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IAzureSkuInternal)Sku).Capacity = value; }

        /// <summary>SKU name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Kusto.Origin(Microsoft.Azure.PowerShell.Cmdlets.Kusto.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.Kusto.Support.AzureSkuName SkuName { get => ((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IAzureSkuInternal)Sku).Name; set => ((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IAzureSkuInternal)Sku).Name = value; }

        /// <summary>SKU tier.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Kusto.Origin(Microsoft.Azure.PowerShell.Cmdlets.Kusto.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.Kusto.Support.AzureSkuTier SkuTier { get => ((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IAzureSkuInternal)Sku).Tier; set => ((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IAzureSkuInternal)Sku).Tier = value; }

        /// <summary>The state of the resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Kusto.Origin(Microsoft.Azure.PowerShell.Cmdlets.Kusto.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.Kusto.Support.State? State { get => ((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IClusterPropertiesInternal)Property).State; }

        /// <summary>The reason for the cluster's current state.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Kusto.Origin(Microsoft.Azure.PowerShell.Cmdlets.Kusto.PropertyOrigin.Inlined)]
        public string StateReason { get => ((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IClusterPropertiesInternal)Property).StateReason; }

        /// <summary>Resource tags.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Kusto.Origin(Microsoft.Azure.PowerShell.Cmdlets.Kusto.PropertyOrigin.Inherited)]
        public Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api10.ITrackedResourceTags Tag { get => ((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api10.ITrackedResourceInternal)__trackedResource).Tag; set => ((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api10.ITrackedResourceInternal)__trackedResource).Tag = value; }

        /// <summary>The cluster's external tenants.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Kusto.Origin(Microsoft.Azure.PowerShell.Cmdlets.Kusto.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.ITrustedExternalTenant[] TrustedExternalTenant { get => ((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IClusterPropertiesInternal)Property).TrustedExternalTenant; set => ((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IClusterPropertiesInternal)Property).TrustedExternalTenant = value; }

        /// <summary>
        /// The type of the resource. Ex- Microsoft.Compute/virtualMachines or Microsoft.Storage/storageAccounts.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Kusto.Origin(Microsoft.Azure.PowerShell.Cmdlets.Kusto.PropertyOrigin.Inherited)]
        public string Type { get => ((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api10.IResourceInternal)__trackedResource).Type; }

        /// <summary>The cluster URI.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Kusto.Origin(Microsoft.Azure.PowerShell.Cmdlets.Kusto.PropertyOrigin.Inlined)]
        public string Uri { get => ((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IClusterPropertiesInternal)Property).Uri; }

        /// <summary>Data management's service public IP address resource id.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Kusto.Origin(Microsoft.Azure.PowerShell.Cmdlets.Kusto.PropertyOrigin.Inlined)]
        public string VirtualNetworkConfigurationDataManagementPublicIPId { get => ((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IClusterPropertiesInternal)Property).VirtualNetworkConfigurationDataManagementPublicIPId; set => ((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IClusterPropertiesInternal)Property).VirtualNetworkConfigurationDataManagementPublicIPId = value; }

        /// <summary>Engine service's public IP address resource id.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Kusto.Origin(Microsoft.Azure.PowerShell.Cmdlets.Kusto.PropertyOrigin.Inlined)]
        public string VirtualNetworkConfigurationEnginePublicIPId { get => ((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IClusterPropertiesInternal)Property).VirtualNetworkConfigurationEnginePublicIPId; set => ((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IClusterPropertiesInternal)Property).VirtualNetworkConfigurationEnginePublicIPId = value; }

        /// <summary>The subnet resource id.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Kusto.Origin(Microsoft.Azure.PowerShell.Cmdlets.Kusto.PropertyOrigin.Inlined)]
        public string VirtualNetworkConfigurationSubnetId { get => ((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IClusterPropertiesInternal)Property).VirtualNetworkConfigurationSubnetId; set => ((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IClusterPropertiesInternal)Property).VirtualNetworkConfigurationSubnetId = value; }

        /// <summary>Backing field for <see cref="Zone" /> property.</summary>
        private string[] _zone;

        /// <summary>The availability zones of the cluster.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Kusto.Origin(Microsoft.Azure.PowerShell.Cmdlets.Kusto.PropertyOrigin.Owned)]
        public string[] Zone { get => this._zone; set => this._zone = value; }

        /// <summary>Creates an new <see cref="Cluster" /> instance.</summary>
        public Cluster()
        {

        }

        /// <summary>Validates that this object meets the validation criteria.</summary>
        /// <param name="eventListener">an <see cref="Microsoft.Azure.PowerShell.Cmdlets.Kusto.Runtime.IEventListener" /> instance that will receive validation
        /// events.</param>
        /// <returns>
        /// A < see cref = "global::System.Threading.Tasks.Task" /> that will be complete when validation is completed.
        /// </returns>
        public async global::System.Threading.Tasks.Task Validate(Microsoft.Azure.PowerShell.Cmdlets.Kusto.Runtime.IEventListener eventListener)
        {
            await eventListener.AssertNotNull(nameof(__trackedResource), __trackedResource);
            await eventListener.AssertObjectIsValid(nameof(__trackedResource), __trackedResource);
        }
    }
    /// Class representing a Kusto cluster.
    public partial interface ICluster :
        Microsoft.Azure.PowerShell.Cmdlets.Kusto.Runtime.IJsonSerializable,
        Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api10.ITrackedResource
    {
        /// <summary>The cluster data ingestion URI.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Kusto.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"The cluster data ingestion URI.",
        SerializedName = @"dataIngestionUri",
        PossibleTypes = new [] { typeof(string) })]
        string DataIngestionUri { get;  }
        /// <summary>A boolean value that indicates if the cluster's disks are encrypted.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Kusto.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"A boolean value that indicates if the cluster's disks are encrypted.",
        SerializedName = @"enableDiskEncryption",
        PossibleTypes = new [] { typeof(bool) })]
        bool? EnableDiskEncryption { get; set; }
        /// <summary>A boolean value that indicates if double encryption is enabled.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Kusto.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"A boolean value that indicates if double encryption is enabled.",
        SerializedName = @"enableDoubleEncryption",
        PossibleTypes = new [] { typeof(bool) })]
        bool? EnableDoubleEncryption { get; set; }
        /// <summary>A boolean value that indicates if the purge operations are enabled.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Kusto.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"A boolean value that indicates if the purge operations are enabled.",
        SerializedName = @"enablePurge",
        PossibleTypes = new [] { typeof(bool) })]
        bool? EnablePurge { get; set; }
        /// <summary>A boolean value that indicates if the streaming ingest is enabled.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Kusto.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"A boolean value that indicates if the streaming ingest is enabled.",
        SerializedName = @"enableStreamingIngest",
        PossibleTypes = new [] { typeof(bool) })]
        bool? EnableStreamingIngest { get; set; }
        /// <summary>The principal ID of resource identity.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Kusto.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"The principal ID of resource identity.",
        SerializedName = @"principalId",
        PossibleTypes = new [] { typeof(string) })]
        string IdentityPrincipalId { get;  }
        /// <summary>The tenant ID of resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Kusto.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"The tenant ID of resource.",
        SerializedName = @"tenantId",
        PossibleTypes = new [] { typeof(string) })]
        string IdentityTenantId { get;  }
        /// <summary>The identity type.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Kusto.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"The identity type.",
        SerializedName = @"type",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Kusto.Support.IdentityType) })]
        Microsoft.Azure.PowerShell.Cmdlets.Kusto.Support.IdentityType IdentityType { get; set; }
        /// <summary>
        /// The list of user identities associated with the Kusto cluster. The user identity dictionary key references will be ARM
        /// resource ids in the form: '/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ManagedIdentity/userAssignedIdentities/{identityName}'.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Kusto.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The list of user identities associated with the Kusto cluster. The user identity dictionary key references will be ARM resource ids in the form: '/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ManagedIdentity/userAssignedIdentities/{identityName}'.",
        SerializedName = @"userAssignedIdentities",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IIdentityUserAssignedIdentities) })]
        Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IIdentityUserAssignedIdentities IdentityUserAssignedIdentity { get; set; }
        /// <summary>The name of the key vault key.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Kusto.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"The name of the key vault key.",
        SerializedName = @"keyName",
        PossibleTypes = new [] { typeof(string) })]
        string KeyVaultPropertyKeyName { get; set; }
        /// <summary>The Uri of the key vault.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Kusto.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"The Uri of the key vault.",
        SerializedName = @"keyVaultUri",
        PossibleTypes = new [] { typeof(string) })]
        string KeyVaultPropertyKeyVaultUri { get; set; }
        /// <summary>The version of the key vault key.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Kusto.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"The version of the key vault key.",
        SerializedName = @"keyVersion",
        PossibleTypes = new [] { typeof(string) })]
        string KeyVaultPropertyKeyVersion { get; set; }
        /// <summary>The list of language extensions.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Kusto.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The list of language extensions.",
        SerializedName = @"value",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.ILanguageExtension) })]
        Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.ILanguageExtension[] LanguageExtensionValue { get; set; }
        /// <summary>
        /// A boolean value that indicate if the optimized autoscale feature is enabled or not.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Kusto.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"A boolean value that indicate if the optimized autoscale feature is enabled or not.",
        SerializedName = @"isEnabled",
        PossibleTypes = new [] { typeof(bool) })]
        bool OptimizedAutoscaleIsEnabled { get; set; }
        /// <summary>Maximum allowed instances count.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Kusto.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"Maximum allowed instances count.",
        SerializedName = @"maximum",
        PossibleTypes = new [] { typeof(int) })]
        int OptimizedAutoscaleMaximum { get; set; }
        /// <summary>Minimum allowed instances count.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Kusto.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"Minimum allowed instances count.",
        SerializedName = @"minimum",
        PossibleTypes = new [] { typeof(int) })]
        int OptimizedAutoscaleMinimum { get; set; }
        /// <summary>The version of the template defined, for instance 1.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Kusto.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"The version of the template defined, for instance 1.",
        SerializedName = @"version",
        PossibleTypes = new [] { typeof(int) })]
        int OptimizedAutoscaleVersion { get; set; }
        /// <summary>The provisioned state of the resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Kusto.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"The provisioned state of the resource.",
        SerializedName = @"provisioningState",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Kusto.Support.ProvisioningState) })]
        Microsoft.Azure.PowerShell.Cmdlets.Kusto.Support.ProvisioningState? ProvisioningState { get;  }
        /// <summary>The number of instances of the cluster.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Kusto.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The number of instances of the cluster.",
        SerializedName = @"capacity",
        PossibleTypes = new [] { typeof(int) })]
        int? SkuCapacity { get; set; }
        /// <summary>SKU name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Kusto.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"SKU name.",
        SerializedName = @"name",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Kusto.Support.AzureSkuName) })]
        Microsoft.Azure.PowerShell.Cmdlets.Kusto.Support.AzureSkuName SkuName { get; set; }
        /// <summary>SKU tier.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Kusto.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"SKU tier.",
        SerializedName = @"tier",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Kusto.Support.AzureSkuTier) })]
        Microsoft.Azure.PowerShell.Cmdlets.Kusto.Support.AzureSkuTier SkuTier { get; set; }
        /// <summary>The state of the resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Kusto.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"The state of the resource.",
        SerializedName = @"state",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Kusto.Support.State) })]
        Microsoft.Azure.PowerShell.Cmdlets.Kusto.Support.State? State { get;  }
        /// <summary>The reason for the cluster's current state.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Kusto.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"The reason for the cluster's current state.",
        SerializedName = @"stateReason",
        PossibleTypes = new [] { typeof(string) })]
        string StateReason { get;  }
        /// <summary>The cluster's external tenants.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Kusto.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The cluster's external tenants.",
        SerializedName = @"trustedExternalTenants",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.ITrustedExternalTenant) })]
        Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.ITrustedExternalTenant[] TrustedExternalTenant { get; set; }
        /// <summary>The cluster URI.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Kusto.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"The cluster URI.",
        SerializedName = @"uri",
        PossibleTypes = new [] { typeof(string) })]
        string Uri { get;  }
        /// <summary>Data management's service public IP address resource id.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Kusto.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"Data management's service public IP address resource id.",
        SerializedName = @"dataManagementPublicIpId",
        PossibleTypes = new [] { typeof(string) })]
        string VirtualNetworkConfigurationDataManagementPublicIPId { get; set; }
        /// <summary>Engine service's public IP address resource id.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Kusto.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"Engine service's public IP address resource id.",
        SerializedName = @"enginePublicIpId",
        PossibleTypes = new [] { typeof(string) })]
        string VirtualNetworkConfigurationEnginePublicIPId { get; set; }
        /// <summary>The subnet resource id.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Kusto.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"The subnet resource id.",
        SerializedName = @"subnetId",
        PossibleTypes = new [] { typeof(string) })]
        string VirtualNetworkConfigurationSubnetId { get; set; }
        /// <summary>The availability zones of the cluster.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Kusto.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The availability zones of the cluster.",
        SerializedName = @"zones",
        PossibleTypes = new [] { typeof(string) })]
        string[] Zone { get; set; }

    }
    /// Class representing a Kusto cluster.
    internal partial interface IClusterInternal :
        Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api10.ITrackedResourceInternal
    {
        /// <summary>The cluster data ingestion URI.</summary>
        string DataIngestionUri { get; set; }
        /// <summary>A boolean value that indicates if the cluster's disks are encrypted.</summary>
        bool? EnableDiskEncryption { get; set; }
        /// <summary>A boolean value that indicates if double encryption is enabled.</summary>
        bool? EnableDoubleEncryption { get; set; }
        /// <summary>A boolean value that indicates if the purge operations are enabled.</summary>
        bool? EnablePurge { get; set; }
        /// <summary>A boolean value that indicates if the streaming ingest is enabled.</summary>
        bool? EnableStreamingIngest { get; set; }
        /// <summary>The identity of the cluster, if configured.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IIdentity Identity { get; set; }
        /// <summary>The principal ID of resource identity.</summary>
        string IdentityPrincipalId { get; set; }
        /// <summary>The tenant ID of resource.</summary>
        string IdentityTenantId { get; set; }
        /// <summary>The identity type.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Kusto.Support.IdentityType IdentityType { get; set; }
        /// <summary>
        /// The list of user identities associated with the Kusto cluster. The user identity dictionary key references will be ARM
        /// resource ids in the form: '/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ManagedIdentity/userAssignedIdentities/{identityName}'.
        /// </summary>
        Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IIdentityUserAssignedIdentities IdentityUserAssignedIdentity { get; set; }
        /// <summary>KeyVault properties for the cluster encryption.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IKeyVaultProperties KeyVaultProperty { get; set; }
        /// <summary>The name of the key vault key.</summary>
        string KeyVaultPropertyKeyName { get; set; }
        /// <summary>The Uri of the key vault.</summary>
        string KeyVaultPropertyKeyVaultUri { get; set; }
        /// <summary>The version of the key vault key.</summary>
        string KeyVaultPropertyKeyVersion { get; set; }
        /// <summary>List of the cluster's language extensions.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.ILanguageExtensionsList LanguageExtension { get; set; }
        /// <summary>The list of language extensions.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.ILanguageExtension[] LanguageExtensionValue { get; set; }
        /// <summary>Optimized auto scale definition.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IOptimizedAutoscale OptimizedAutoscale { get; set; }
        /// <summary>
        /// A boolean value that indicate if the optimized autoscale feature is enabled or not.
        /// </summary>
        bool OptimizedAutoscaleIsEnabled { get; set; }
        /// <summary>Maximum allowed instances count.</summary>
        int OptimizedAutoscaleMaximum { get; set; }
        /// <summary>Minimum allowed instances count.</summary>
        int OptimizedAutoscaleMinimum { get; set; }
        /// <summary>The version of the template defined, for instance 1.</summary>
        int OptimizedAutoscaleVersion { get; set; }
        /// <summary>The cluster properties.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IClusterProperties Property { get; set; }
        /// <summary>The provisioned state of the resource.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Kusto.Support.ProvisioningState? ProvisioningState { get; set; }
        /// <summary>The SKU of the cluster.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IAzureSku Sku { get; set; }
        /// <summary>The number of instances of the cluster.</summary>
        int? SkuCapacity { get; set; }
        /// <summary>SKU name.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Kusto.Support.AzureSkuName SkuName { get; set; }
        /// <summary>SKU tier.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Kusto.Support.AzureSkuTier SkuTier { get; set; }
        /// <summary>The state of the resource.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Kusto.Support.State? State { get; set; }
        /// <summary>The reason for the cluster's current state.</summary>
        string StateReason { get; set; }
        /// <summary>The cluster's external tenants.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.ITrustedExternalTenant[] TrustedExternalTenant { get; set; }
        /// <summary>The cluster URI.</summary>
        string Uri { get; set; }
        /// <summary>Virtual network definition.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IVirtualNetworkConfiguration VirtualNetworkConfiguration { get; set; }
        /// <summary>Data management's service public IP address resource id.</summary>
        string VirtualNetworkConfigurationDataManagementPublicIPId { get; set; }
        /// <summary>Engine service's public IP address resource id.</summary>
        string VirtualNetworkConfigurationEnginePublicIPId { get; set; }
        /// <summary>The subnet resource id.</summary>
        string VirtualNetworkConfigurationSubnetId { get; set; }
        /// <summary>The availability zones of the cluster.</summary>
        string[] Zone { get; set; }

    }
}