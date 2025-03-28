// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
// Changes may cause incorrect behavior and will be lost if the code is regenerated.
namespace Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models
{
    using static Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Runtime.Extensions;

    /// <summary>
    /// Schema of the AgriService resource from Microsoft.AgriculturePlatform resource provider.
    /// </summary>
    public partial class AgriServiceResource :
        Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.IAgriServiceResource,
        Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.IAgriServiceResourceInternal,
        Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Runtime.IValidates
    {
        /// <summary>
        /// Backing field for Inherited model <see cref= "Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.ITrackedResource"
        /// />
        /// </summary>
        private Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.ITrackedResource __trackedResource = new Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.TrackedResource();

        /// <summary>App service resource Id.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Origin(Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.PropertyOrigin.Inlined)]
        public string ConfigAppServiceResourceId { get => ((Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.IAgriServiceResourcePropertiesInternal)Property).ConfigAppServiceResourceId; }

        /// <summary>Cosmos Db resource Id.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Origin(Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.PropertyOrigin.Inlined)]
        public string ConfigCosmosDbResourceId { get => ((Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.IAgriServiceResourcePropertiesInternal)Property).ConfigCosmosDbResourceId; }

        /// <summary>Instance URI of the AgriService instance.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Origin(Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.PropertyOrigin.Inlined)]
        public string ConfigInstanceUri { get => ((Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.IAgriServiceResourcePropertiesInternal)Property).ConfigInstanceUri; }

        /// <summary>Key vault resource Id.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Origin(Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.PropertyOrigin.Inlined)]
        public string ConfigKeyVaultResourceId { get => ((Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.IAgriServiceResourcePropertiesInternal)Property).ConfigKeyVaultResourceId; }

        /// <summary>Redis cache resource Id.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Origin(Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.PropertyOrigin.Inlined)]
        public string ConfigRedisCacheResourceId { get => ((Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.IAgriServiceResourcePropertiesInternal)Property).ConfigRedisCacheResourceId; }

        /// <summary>Storage account resource Id.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Origin(Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.PropertyOrigin.Inlined)]
        public string ConfigStorageAccountResourceId { get => ((Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.IAgriServiceResourcePropertiesInternal)Property).ConfigStorageAccountResourceId; }

        /// <summary>Version of AgriService instance.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Origin(Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.PropertyOrigin.Inlined)]
        public string ConfigVersion { get => ((Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.IAgriServiceResourcePropertiesInternal)Property).ConfigVersion; }

        /// <summary>Data connector credentials of AgriService instance.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Origin(Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.PropertyOrigin.Inlined)]
        public System.Collections.Generic.List<Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.IDataConnectorCredentialMap> DataConnectorCredentials { get => ((Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.IAgriServiceResourcePropertiesInternal)Property).DataConnectorCredentials; set => ((Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.IAgriServiceResourcePropertiesInternal)Property).DataConnectorCredentials = value ?? null /* arrayOf */; }

        /// <summary>
        /// Fully qualified resource ID for the resource. Ex - /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/{resourceProviderNamespace}/{resourceType}/{resourceName}
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Origin(Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.PropertyOrigin.Inherited)]
        public string Id { get => ((Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.IResourceInternal)__trackedResource).Id; }

        /// <summary>Backing field for <see cref="Identity" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.IManagedServiceIdentity _identity;

        /// <summary>The managed service identities assigned to this resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Origin(Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.IManagedServiceIdentity Identity { get => (this._identity = this._identity ?? new Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.ManagedServiceIdentity()); set => this._identity = value; }

        /// <summary>
        /// The service principal ID of the system assigned identity. This property will only be provided for a system assigned identity.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Origin(Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.PropertyOrigin.Inlined)]
        public string IdentityPrincipalId { get => ((Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.IManagedServiceIdentityInternal)Identity).PrincipalId; }

        /// <summary>
        /// The tenant ID of the system assigned identity. This property will only be provided for a system assigned identity.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Origin(Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.PropertyOrigin.Inlined)]
        public string IdentityTenantId { get => ((Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.IManagedServiceIdentityInternal)Identity).TenantId; }

        /// <summary>The type of managed identity assigned to this resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Origin(Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.PropertyOrigin.Inlined)]
        public string IdentityType { get => ((Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.IManagedServiceIdentityInternal)Identity).Type; set => ((Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.IManagedServiceIdentityInternal)Identity).Type = value ?? null; }

        /// <summary>The identities assigned to this resource by the user.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Origin(Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.IUserAssignedIdentities IdentityUserAssignedIdentity { get => ((Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.IManagedServiceIdentityInternal)Identity).UserAssignedIdentity; set => ((Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.IManagedServiceIdentityInternal)Identity).UserAssignedIdentity = value ?? null /* model class */; }

        /// <summary>AgriService installed solutions.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Origin(Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.PropertyOrigin.Inlined)]
        public System.Collections.Generic.List<Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.IInstalledSolutionMap> InstalledSolution { get => ((Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.IAgriServiceResourcePropertiesInternal)Property).InstalledSolution; set => ((Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.IAgriServiceResourcePropertiesInternal)Property).InstalledSolution = value ?? null /* arrayOf */; }

        /// <summary>The geo-location where the resource lives</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Origin(Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.PropertyOrigin.Inherited)]
        public string Location { get => ((Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.ITrackedResourceInternal)__trackedResource).Location; set => ((Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.ITrackedResourceInternal)__trackedResource).Location = value ; }

        /// <summary>Associated MoboBrokerResources.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Origin(Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.PropertyOrigin.Inlined)]
        public System.Collections.Generic.List<Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.IMoboBrokerResource> ManagedOnBehalfOfConfigurationMoboBrokerResource { get => ((Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.IAgriServiceResourcePropertiesInternal)Property).ManagedOnBehalfOfConfigurationMoboBrokerResource; }

        /// <summary>Internal Acessors for Config</summary>
        Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.IAgriServiceConfig Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.IAgriServiceResourceInternal.Config { get => ((Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.IAgriServiceResourcePropertiesInternal)Property).Config; set => ((Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.IAgriServiceResourcePropertiesInternal)Property).Config = value; }

        /// <summary>Internal Acessors for ConfigAppServiceResourceId</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.IAgriServiceResourceInternal.ConfigAppServiceResourceId { get => ((Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.IAgriServiceResourcePropertiesInternal)Property).ConfigAppServiceResourceId; set => ((Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.IAgriServiceResourcePropertiesInternal)Property).ConfigAppServiceResourceId = value; }

        /// <summary>Internal Acessors for ConfigCosmosDbResourceId</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.IAgriServiceResourceInternal.ConfigCosmosDbResourceId { get => ((Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.IAgriServiceResourcePropertiesInternal)Property).ConfigCosmosDbResourceId; set => ((Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.IAgriServiceResourcePropertiesInternal)Property).ConfigCosmosDbResourceId = value; }

        /// <summary>Internal Acessors for ConfigInstanceUri</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.IAgriServiceResourceInternal.ConfigInstanceUri { get => ((Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.IAgriServiceResourcePropertiesInternal)Property).ConfigInstanceUri; set => ((Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.IAgriServiceResourcePropertiesInternal)Property).ConfigInstanceUri = value; }

        /// <summary>Internal Acessors for ConfigKeyVaultResourceId</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.IAgriServiceResourceInternal.ConfigKeyVaultResourceId { get => ((Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.IAgriServiceResourcePropertiesInternal)Property).ConfigKeyVaultResourceId; set => ((Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.IAgriServiceResourcePropertiesInternal)Property).ConfigKeyVaultResourceId = value; }

        /// <summary>Internal Acessors for ConfigRedisCacheResourceId</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.IAgriServiceResourceInternal.ConfigRedisCacheResourceId { get => ((Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.IAgriServiceResourcePropertiesInternal)Property).ConfigRedisCacheResourceId; set => ((Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.IAgriServiceResourcePropertiesInternal)Property).ConfigRedisCacheResourceId = value; }

        /// <summary>Internal Acessors for ConfigStorageAccountResourceId</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.IAgriServiceResourceInternal.ConfigStorageAccountResourceId { get => ((Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.IAgriServiceResourcePropertiesInternal)Property).ConfigStorageAccountResourceId; set => ((Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.IAgriServiceResourcePropertiesInternal)Property).ConfigStorageAccountResourceId = value; }

        /// <summary>Internal Acessors for ConfigVersion</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.IAgriServiceResourceInternal.ConfigVersion { get => ((Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.IAgriServiceResourcePropertiesInternal)Property).ConfigVersion; set => ((Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.IAgriServiceResourcePropertiesInternal)Property).ConfigVersion = value; }

        /// <summary>Internal Acessors for Identity</summary>
        Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.IManagedServiceIdentity Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.IAgriServiceResourceInternal.Identity { get => (this._identity = this._identity ?? new Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.ManagedServiceIdentity()); set { {_identity = value;} } }

        /// <summary>Internal Acessors for IdentityPrincipalId</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.IAgriServiceResourceInternal.IdentityPrincipalId { get => ((Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.IManagedServiceIdentityInternal)Identity).PrincipalId; set => ((Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.IManagedServiceIdentityInternal)Identity).PrincipalId = value; }

        /// <summary>Internal Acessors for IdentityTenantId</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.IAgriServiceResourceInternal.IdentityTenantId { get => ((Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.IManagedServiceIdentityInternal)Identity).TenantId; set => ((Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.IManagedServiceIdentityInternal)Identity).TenantId = value; }

        /// <summary>Internal Acessors for ManagedOnBehalfOfConfiguration</summary>
        Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.IManagedOnBehalfOfConfiguration Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.IAgriServiceResourceInternal.ManagedOnBehalfOfConfiguration { get => ((Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.IAgriServiceResourcePropertiesInternal)Property).ManagedOnBehalfOfConfiguration; set => ((Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.IAgriServiceResourcePropertiesInternal)Property).ManagedOnBehalfOfConfiguration = value; }

        /// <summary>Internal Acessors for ManagedOnBehalfOfConfigurationMoboBrokerResource</summary>
        System.Collections.Generic.List<Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.IMoboBrokerResource> Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.IAgriServiceResourceInternal.ManagedOnBehalfOfConfigurationMoboBrokerResource { get => ((Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.IAgriServiceResourcePropertiesInternal)Property).ManagedOnBehalfOfConfigurationMoboBrokerResource; set => ((Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.IAgriServiceResourcePropertiesInternal)Property).ManagedOnBehalfOfConfigurationMoboBrokerResource = value; }

        /// <summary>Internal Acessors for Property</summary>
        Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.IAgriServiceResourceProperties Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.IAgriServiceResourceInternal.Property { get => (this._property = this._property ?? new Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.AgriServiceResourceProperties()); set { {_property = value;} } }

        /// <summary>Internal Acessors for ProvisioningState</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.IAgriServiceResourceInternal.ProvisioningState { get => ((Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.IAgriServiceResourcePropertiesInternal)Property).ProvisioningState; set => ((Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.IAgriServiceResourcePropertiesInternal)Property).ProvisioningState = value; }

        /// <summary>Internal Acessors for Sku</summary>
        Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.ISku Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.IAgriServiceResourceInternal.Sku { get => (this._sku = this._sku ?? new Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.Sku()); set { {_sku = value;} } }

        /// <summary>Internal Acessors for Id</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.IResourceInternal.Id { get => ((Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.IResourceInternal)__trackedResource).Id; set => ((Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.IResourceInternal)__trackedResource).Id = value; }

        /// <summary>Internal Acessors for Name</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.IResourceInternal.Name { get => ((Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.IResourceInternal)__trackedResource).Name; set => ((Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.IResourceInternal)__trackedResource).Name = value; }

        /// <summary>Internal Acessors for SystemData</summary>
        Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.ISystemData Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.IResourceInternal.SystemData { get => ((Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.IResourceInternal)__trackedResource).SystemData; set => ((Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.IResourceInternal)__trackedResource).SystemData = value; }

        /// <summary>Internal Acessors for Type</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.IResourceInternal.Type { get => ((Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.IResourceInternal)__trackedResource).Type; set => ((Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.IResourceInternal)__trackedResource).Type = value; }

        /// <summary>The name of the resource</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Origin(Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.PropertyOrigin.Inherited)]
        public string Name { get => ((Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.IResourceInternal)__trackedResource).Name; }

        /// <summary>Backing field for <see cref="Property" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.IAgriServiceResourceProperties _property;

        /// <summary>The resource-specific properties for this resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Origin(Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.IAgriServiceResourceProperties Property { get => (this._property = this._property ?? new Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.AgriServiceResourceProperties()); set => this._property = value; }

        /// <summary>The status of the last operation.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Origin(Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.PropertyOrigin.Inlined)]
        public string ProvisioningState { get => ((Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.IAgriServiceResourcePropertiesInternal)Property).ProvisioningState; }

        /// <summary>Gets the resource group name</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Origin(Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.PropertyOrigin.Owned)]
        public string ResourceGroupName { get => (new global::System.Text.RegularExpressions.Regex("^/subscriptions/(?<subscriptionId>[^/]+)/resourceGroups/(?<resourceGroupName>[^/]+)/providers/", global::System.Text.RegularExpressions.RegexOptions.IgnoreCase).Match(this.Id).Success ? new global::System.Text.RegularExpressions.Regex("^/subscriptions/(?<subscriptionId>[^/]+)/resourceGroups/(?<resourceGroupName>[^/]+)/providers/", global::System.Text.RegularExpressions.RegexOptions.IgnoreCase).Match(this.Id).Groups["resourceGroupName"].Value : null); }

        /// <summary>Backing field for <see cref="Sku" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.ISku _sku;

        /// <summary>The SKU (Stock Keeping Unit) assigned to this resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Origin(Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.ISku Sku { get => (this._sku = this._sku ?? new Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.Sku()); set => this._sku = value; }

        /// <summary>
        /// If the SKU supports scale out/in then the capacity integer should be included. If scale out/in is not possible for the
        /// resource this may be omitted.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Origin(Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.PropertyOrigin.Inlined)]
        public int? SkuCapacity { get => ((Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.ISkuInternal)Sku).Capacity; set => ((Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.ISkuInternal)Sku).Capacity = value ?? default(int); }

        /// <summary>
        /// If the service has different generations of hardware, for the same SKU, then that can be captured here.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Origin(Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.PropertyOrigin.Inlined)]
        public string SkuFamily { get => ((Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.ISkuInternal)Sku).Family; set => ((Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.ISkuInternal)Sku).Family = value ?? null; }

        /// <summary>The name of the SKU. Ex - P3. It is typically a letter+number code</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Origin(Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.PropertyOrigin.Inlined)]
        public string SkuName { get => ((Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.ISkuInternal)Sku).Name; set => ((Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.ISkuInternal)Sku).Name = value ?? null; }

        /// <summary>
        /// The SKU size. When the name field is the combination of tier and some other value, this would be the standalone code.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Origin(Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.PropertyOrigin.Inlined)]
        public string SkuSize { get => ((Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.ISkuInternal)Sku).Size; set => ((Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.ISkuInternal)Sku).Size = value ?? null; }

        /// <summary>
        /// This field is required to be implemented by the Resource Provider if the service has more than one tier, but is not required
        /// on a PUT.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Origin(Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.PropertyOrigin.Inlined)]
        public string SkuTier { get => ((Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.ISkuInternal)Sku).Tier; set => ((Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.ISkuInternal)Sku).Tier = value ?? null; }

        /// <summary>
        /// Azure Resource Manager metadata containing createdBy and modifiedBy information.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Origin(Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.PropertyOrigin.Inherited)]
        internal Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.ISystemData SystemData { get => ((Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.IResourceInternal)__trackedResource).SystemData; }

        /// <summary>The timestamp of resource creation (UTC).</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Origin(Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.PropertyOrigin.Inherited)]
        public global::System.DateTime? SystemDataCreatedAt { get => ((Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.IResourceInternal)__trackedResource).SystemDataCreatedAt; set => ((Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.IResourceInternal)__trackedResource).SystemDataCreatedAt = value ?? default(global::System.DateTime); }

        /// <summary>The identity that created the resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Origin(Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.PropertyOrigin.Inherited)]
        public string SystemDataCreatedBy { get => ((Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.IResourceInternal)__trackedResource).SystemDataCreatedBy; set => ((Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.IResourceInternal)__trackedResource).SystemDataCreatedBy = value ?? null; }

        /// <summary>The type of identity that created the resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Origin(Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.PropertyOrigin.Inherited)]
        public string SystemDataCreatedByType { get => ((Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.IResourceInternal)__trackedResource).SystemDataCreatedByType; set => ((Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.IResourceInternal)__trackedResource).SystemDataCreatedByType = value ?? null; }

        /// <summary>The timestamp of resource last modification (UTC)</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Origin(Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.PropertyOrigin.Inherited)]
        public global::System.DateTime? SystemDataLastModifiedAt { get => ((Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.IResourceInternal)__trackedResource).SystemDataLastModifiedAt; set => ((Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.IResourceInternal)__trackedResource).SystemDataLastModifiedAt = value ?? default(global::System.DateTime); }

        /// <summary>The identity that last modified the resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Origin(Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.PropertyOrigin.Inherited)]
        public string SystemDataLastModifiedBy { get => ((Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.IResourceInternal)__trackedResource).SystemDataLastModifiedBy; set => ((Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.IResourceInternal)__trackedResource).SystemDataLastModifiedBy = value ?? null; }

        /// <summary>The type of identity that last modified the resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Origin(Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.PropertyOrigin.Inherited)]
        public string SystemDataLastModifiedByType { get => ((Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.IResourceInternal)__trackedResource).SystemDataLastModifiedByType; set => ((Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.IResourceInternal)__trackedResource).SystemDataLastModifiedByType = value ?? null; }

        /// <summary>Resource tags.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Origin(Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.PropertyOrigin.Inherited)]
        public Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.ITags Tag { get => ((Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.ITrackedResourceInternal)__trackedResource).Tag; set => ((Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.ITrackedResourceInternal)__trackedResource).Tag = value ?? null /* model class */; }

        /// <summary>
        /// The type of the resource. E.g. "Microsoft.Compute/virtualMachines" or "Microsoft.Storage/storageAccounts"
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Origin(Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.PropertyOrigin.Inherited)]
        public string Type { get => ((Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.IResourceInternal)__trackedResource).Type; }

        /// <summary>Creates an new <see cref="AgriServiceResource" /> instance.</summary>
        public AgriServiceResource()
        {

        }

        /// <summary>Validates that this object meets the validation criteria.</summary>
        /// <param name="eventListener">an <see cref="Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Runtime.IEventListener" /> instance that will receive validation
        /// events.</param>
        /// <returns>
        /// A <see cref = "global::System.Threading.Tasks.Task" /> that will be complete when validation is completed.
        /// </returns>
        public async global::System.Threading.Tasks.Task Validate(Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Runtime.IEventListener eventListener)
        {
            await eventListener.AssertNotNull(nameof(__trackedResource), __trackedResource);
            await eventListener.AssertObjectIsValid(nameof(__trackedResource), __trackedResource);
        }
    }
    /// Schema of the AgriService resource from Microsoft.AgriculturePlatform resource provider.
    public partial interface IAgriServiceResource :
        Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Runtime.IJsonSerializable,
        Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.ITrackedResource
    {
        /// <summary>App service resource Id.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Read = true,
        Create = false,
        Update = false,
        Description = @"App service resource Id.",
        SerializedName = @"appServiceResourceId",
        PossibleTypes = new [] { typeof(string) })]
        string ConfigAppServiceResourceId { get;  }
        /// <summary>Cosmos Db resource Id.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Read = true,
        Create = false,
        Update = false,
        Description = @"Cosmos Db resource Id.",
        SerializedName = @"cosmosDbResourceId",
        PossibleTypes = new [] { typeof(string) })]
        string ConfigCosmosDbResourceId { get;  }
        /// <summary>Instance URI of the AgriService instance.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Read = true,
        Create = false,
        Update = false,
        Description = @"Instance URI of the AgriService instance.",
        SerializedName = @"instanceUri",
        PossibleTypes = new [] { typeof(string) })]
        string ConfigInstanceUri { get;  }
        /// <summary>Key vault resource Id.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Read = true,
        Create = false,
        Update = false,
        Description = @"Key vault resource Id.",
        SerializedName = @"keyVaultResourceId",
        PossibleTypes = new [] { typeof(string) })]
        string ConfigKeyVaultResourceId { get;  }
        /// <summary>Redis cache resource Id.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Read = true,
        Create = false,
        Update = false,
        Description = @"Redis cache resource Id.",
        SerializedName = @"redisCacheResourceId",
        PossibleTypes = new [] { typeof(string) })]
        string ConfigRedisCacheResourceId { get;  }
        /// <summary>Storage account resource Id.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Read = true,
        Create = false,
        Update = false,
        Description = @"Storage account resource Id.",
        SerializedName = @"storageAccountResourceId",
        PossibleTypes = new [] { typeof(string) })]
        string ConfigStorageAccountResourceId { get;  }
        /// <summary>Version of AgriService instance.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Read = true,
        Create = false,
        Update = false,
        Description = @"Version of AgriService instance.",
        SerializedName = @"version",
        PossibleTypes = new [] { typeof(string) })]
        string ConfigVersion { get;  }
        /// <summary>Data connector credentials of AgriService instance.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"Data connector credentials of AgriService instance.",
        SerializedName = @"dataConnectorCredentials",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.IDataConnectorCredentialMap) })]
        System.Collections.Generic.List<Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.IDataConnectorCredentialMap> DataConnectorCredentials { get; set; }
        /// <summary>
        /// The service principal ID of the system assigned identity. This property will only be provided for a system assigned identity.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Runtime.Info(
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
        [Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Runtime.Info(
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
        [Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"The type of managed identity assigned to this resource.",
        SerializedName = @"type",
        PossibleTypes = new [] { typeof(string) })]
        [global::Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.PSArgumentCompleterAttribute("None", "SystemAssigned", "UserAssigned", "SystemAssigned,UserAssigned")]
        string IdentityType { get; set; }
        /// <summary>The identities assigned to this resource by the user.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"The identities assigned to this resource by the user.",
        SerializedName = @"userAssignedIdentities",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.IUserAssignedIdentities) })]
        Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.IUserAssignedIdentities IdentityUserAssignedIdentity { get; set; }
        /// <summary>AgriService installed solutions.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"AgriService installed solutions.",
        SerializedName = @"installedSolutions",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.IInstalledSolutionMap) })]
        System.Collections.Generic.List<Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.IInstalledSolutionMap> InstalledSolution { get; set; }
        /// <summary>Associated MoboBrokerResources.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Read = true,
        Create = false,
        Update = false,
        Description = @"Associated MoboBrokerResources.",
        SerializedName = @"moboBrokerResources",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.IMoboBrokerResource) })]
        System.Collections.Generic.List<Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.IMoboBrokerResource> ManagedOnBehalfOfConfigurationMoboBrokerResource { get;  }
        /// <summary>The status of the last operation.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Read = true,
        Create = false,
        Update = false,
        Description = @"The status of the last operation.",
        SerializedName = @"provisioningState",
        PossibleTypes = new [] { typeof(string) })]
        [global::Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.PSArgumentCompleterAttribute("Succeeded", "Failed", "Canceled", "Provisioning", "Updating", "Deleting", "Accepted")]
        string ProvisioningState { get;  }
        /// <summary>
        /// If the SKU supports scale out/in then the capacity integer should be included. If scale out/in is not possible for the
        /// resource this may be omitted.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"If the SKU supports scale out/in then the capacity integer should be included. If scale out/in is not possible for the resource this may be omitted.",
        SerializedName = @"capacity",
        PossibleTypes = new [] { typeof(int) })]
        int? SkuCapacity { get; set; }
        /// <summary>
        /// If the service has different generations of hardware, for the same SKU, then that can be captured here.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"If the service has different generations of hardware, for the same SKU, then that can be captured here.",
        SerializedName = @"family",
        PossibleTypes = new [] { typeof(string) })]
        string SkuFamily { get; set; }
        /// <summary>The name of the SKU. Ex - P3. It is typically a letter+number code</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"The name of the SKU. Ex - P3. It is typically a letter+number code",
        SerializedName = @"name",
        PossibleTypes = new [] { typeof(string) })]
        string SkuName { get; set; }
        /// <summary>
        /// The SKU size. When the name field is the combination of tier and some other value, this would be the standalone code.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"The SKU size. When the name field is the combination of tier and some other value, this would be the standalone code.",
        SerializedName = @"size",
        PossibleTypes = new [] { typeof(string) })]
        string SkuSize { get; set; }
        /// <summary>
        /// This field is required to be implemented by the Resource Provider if the service has more than one tier, but is not required
        /// on a PUT.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"This field is required to be implemented by the Resource Provider if the service has more than one tier, but is not required on a PUT.",
        SerializedName = @"tier",
        PossibleTypes = new [] { typeof(string) })]
        [global::Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.PSArgumentCompleterAttribute("Free", "Basic", "Standard", "Premium")]
        string SkuTier { get; set; }

    }
    /// Schema of the AgriService resource from Microsoft.AgriculturePlatform resource provider.
    internal partial interface IAgriServiceResourceInternal :
        Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.ITrackedResourceInternal
    {
        /// <summary>Config of the AgriService instance.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.IAgriServiceConfig Config { get; set; }
        /// <summary>App service resource Id.</summary>
        string ConfigAppServiceResourceId { get; set; }
        /// <summary>Cosmos Db resource Id.</summary>
        string ConfigCosmosDbResourceId { get; set; }
        /// <summary>Instance URI of the AgriService instance.</summary>
        string ConfigInstanceUri { get; set; }
        /// <summary>Key vault resource Id.</summary>
        string ConfigKeyVaultResourceId { get; set; }
        /// <summary>Redis cache resource Id.</summary>
        string ConfigRedisCacheResourceId { get; set; }
        /// <summary>Storage account resource Id.</summary>
        string ConfigStorageAccountResourceId { get; set; }
        /// <summary>Version of AgriService instance.</summary>
        string ConfigVersion { get; set; }
        /// <summary>Data connector credentials of AgriService instance.</summary>
        System.Collections.Generic.List<Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.IDataConnectorCredentialMap> DataConnectorCredentials { get; set; }
        /// <summary>The managed service identities assigned to this resource.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.IManagedServiceIdentity Identity { get; set; }
        /// <summary>
        /// The service principal ID of the system assigned identity. This property will only be provided for a system assigned identity.
        /// </summary>
        string IdentityPrincipalId { get; set; }
        /// <summary>
        /// The tenant ID of the system assigned identity. This property will only be provided for a system assigned identity.
        /// </summary>
        string IdentityTenantId { get; set; }
        /// <summary>The type of managed identity assigned to this resource.</summary>
        [global::Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.PSArgumentCompleterAttribute("None", "SystemAssigned", "UserAssigned", "SystemAssigned,UserAssigned")]
        string IdentityType { get; set; }
        /// <summary>The identities assigned to this resource by the user.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.IUserAssignedIdentities IdentityUserAssignedIdentity { get; set; }
        /// <summary>AgriService installed solutions.</summary>
        System.Collections.Generic.List<Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.IInstalledSolutionMap> InstalledSolution { get; set; }
        /// <summary>Managed On Behalf Of Configuration.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.IManagedOnBehalfOfConfiguration ManagedOnBehalfOfConfiguration { get; set; }
        /// <summary>Associated MoboBrokerResources.</summary>
        System.Collections.Generic.List<Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.IMoboBrokerResource> ManagedOnBehalfOfConfigurationMoboBrokerResource { get; set; }
        /// <summary>The resource-specific properties for this resource.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.IAgriServiceResourceProperties Property { get; set; }
        /// <summary>The status of the last operation.</summary>
        [global::Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.PSArgumentCompleterAttribute("Succeeded", "Failed", "Canceled", "Provisioning", "Updating", "Deleting", "Accepted")]
        string ProvisioningState { get; set; }
        /// <summary>The SKU (Stock Keeping Unit) assigned to this resource.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.ISku Sku { get; set; }
        /// <summary>
        /// If the SKU supports scale out/in then the capacity integer should be included. If scale out/in is not possible for the
        /// resource this may be omitted.
        /// </summary>
        int? SkuCapacity { get; set; }
        /// <summary>
        /// If the service has different generations of hardware, for the same SKU, then that can be captured here.
        /// </summary>
        string SkuFamily { get; set; }
        /// <summary>The name of the SKU. Ex - P3. It is typically a letter+number code</summary>
        string SkuName { get; set; }
        /// <summary>
        /// The SKU size. When the name field is the combination of tier and some other value, this would be the standalone code.
        /// </summary>
        string SkuSize { get; set; }
        /// <summary>
        /// This field is required to be implemented by the Resource Provider if the service has more than one tier, but is not required
        /// on a PUT.
        /// </summary>
        [global::Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.PSArgumentCompleterAttribute("Free", "Basic", "Standard", "Premium")]
        string SkuTier { get; set; }

    }
}