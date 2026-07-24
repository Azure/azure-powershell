// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
// Changes may cause incorrect behavior and will be lost if the code is regenerated.
namespace Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Discovery.Runtime.Extensions;

    /// <summary>Bookshelf tracked resource</summary>
    public partial class Bookshelf :
        Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IBookshelf,
        Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IBookshelfInternal,
        Microsoft.Azure.PowerShell.Cmdlets.Discovery.Runtime.IValidates
    {
        /// <summary>
        /// Backing field for Inherited model <see cref= "Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.ITrackedResource" />
        /// </summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.ITrackedResource __trackedResource = new Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.TrackedResource();

        /// <summary>Whether or not to use a customer managed key when encrypting data at rest</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Discovery.Origin(Microsoft.Azure.PowerShell.Cmdlets.Discovery.PropertyOrigin.Inlined)]
        public string CustomerManagedKey { get => ((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IBookshelfPropertiesInternal)Property).CustomerManagedKey; set => ((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IBookshelfPropertiesInternal)Property).CustomerManagedKey = value ?? null; }

        /// <summary>
        /// Fully qualified resource ID for the resource. Ex - /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/{resourceProviderNamespace}/{resourceType}/{resourceName}
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Discovery.Origin(Microsoft.Azure.PowerShell.Cmdlets.Discovery.PropertyOrigin.Inherited)]
        public string Id { get => ((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IResourceInternal)__trackedResource).Id; }

        /// <summary>
        /// The client ID of the identity to use for accessing the Key Vault. Must be a workload identity assigned to the Bookshelf
        /// resource.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Discovery.Origin(Microsoft.Azure.PowerShell.Cmdlets.Discovery.PropertyOrigin.Inlined)]
        public string KeyVaultPropertyIdentityClientId { get => ((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IBookshelfPropertiesInternal)Property).KeyVaultPropertyIdentityClientId; set => ((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IBookshelfPropertiesInternal)Property).KeyVaultPropertyIdentityClientId = value ?? null; }

        /// <summary>The Key Name in Key Vault</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Discovery.Origin(Microsoft.Azure.PowerShell.Cmdlets.Discovery.PropertyOrigin.Inlined)]
        public string KeyVaultPropertyKeyName { get => ((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IBookshelfPropertiesInternal)Property).KeyVaultPropertyKeyName; set => ((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IBookshelfPropertiesInternal)Property).KeyVaultPropertyKeyName = value ?? null; }

        /// <summary>The Key Vault URI</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Discovery.Origin(Microsoft.Azure.PowerShell.Cmdlets.Discovery.PropertyOrigin.Inlined)]
        public string KeyVaultPropertyKeyVaultUri { get => ((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IBookshelfPropertiesInternal)Property).KeyVaultPropertyKeyVaultUri; set => ((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IBookshelfPropertiesInternal)Property).KeyVaultPropertyKeyVaultUri = value ?? null; }

        /// <summary>The Key Version in Key Vault</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Discovery.Origin(Microsoft.Azure.PowerShell.Cmdlets.Discovery.PropertyOrigin.Inlined)]
        public string KeyVaultPropertyKeyVersion { get => ((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IBookshelfPropertiesInternal)Property).KeyVaultPropertyKeyVersion; set => ((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IBookshelfPropertiesInternal)Property).KeyVaultPropertyKeyVersion = value ?? null; }

        /// <summary>The geo-location where the resource lives</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Discovery.Origin(Microsoft.Azure.PowerShell.Cmdlets.Discovery.PropertyOrigin.Inherited)]
        public string Location { get => ((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.ITrackedResourceInternal)__trackedResource).Location; set => ((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.ITrackedResourceInternal)__trackedResource).Location = value ?? null; }

        /// <summary>
        /// The Log Analytics Cluster to use for debug logs. This is required when Customer Managed Keys are enabled.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Discovery.Origin(Microsoft.Azure.PowerShell.Cmdlets.Discovery.PropertyOrigin.Inlined)]
        public string LogAnalyticsClusterId { get => ((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IBookshelfPropertiesInternal)Property).LogAnalyticsClusterId; set => ((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IBookshelfPropertiesInternal)Property).LogAnalyticsClusterId = value ?? null; }

        /// <summary>Managed-On-Behalf-Of broker resources</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Discovery.Origin(Microsoft.Azure.PowerShell.Cmdlets.Discovery.PropertyOrigin.Inlined)]
        public System.Collections.Generic.List<Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IMoboBrokerResource> ManagedOnBehalfOfConfigurationMoboBrokerResource { get => ((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IBookshelfPropertiesInternal)Property).ManagedOnBehalfOfConfigurationMoboBrokerResource; }

        /// <summary>The resource group for resources managed on behalf of customer.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Discovery.Origin(Microsoft.Azure.PowerShell.Cmdlets.Discovery.PropertyOrigin.Inlined)]
        public string ManagedResourceGroup { get => ((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IBookshelfPropertiesInternal)Property).ManagedResourceGroup; }

        /// <summary>Internal Acessors for KeyVaultProperty</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IBookshelfKeyVaultProperties Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IBookshelfInternal.KeyVaultProperty { get => ((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IBookshelfPropertiesInternal)Property).KeyVaultProperty; set => ((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IBookshelfPropertiesInternal)Property).KeyVaultProperty = value ?? null /* model class */; }

        /// <summary>Internal Acessors for ManagedOnBehalfOfConfiguration</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IWithMoboBrokerResources Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IBookshelfInternal.ManagedOnBehalfOfConfiguration { get => ((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IBookshelfPropertiesInternal)Property).ManagedOnBehalfOfConfiguration; set => ((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IBookshelfPropertiesInternal)Property).ManagedOnBehalfOfConfiguration = value ?? null /* model class */; }

        /// <summary>Internal Acessors for ManagedOnBehalfOfConfigurationMoboBrokerResource</summary>
        System.Collections.Generic.List<Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IMoboBrokerResource> Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IBookshelfInternal.ManagedOnBehalfOfConfigurationMoboBrokerResource { get => ((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IBookshelfPropertiesInternal)Property).ManagedOnBehalfOfConfigurationMoboBrokerResource; set => ((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IBookshelfPropertiesInternal)Property).ManagedOnBehalfOfConfigurationMoboBrokerResource = value ?? null /* arrayOf */; }

        /// <summary>Internal Acessors for ManagedResourceGroup</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IBookshelfInternal.ManagedResourceGroup { get => ((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IBookshelfPropertiesInternal)Property).ManagedResourceGroup; set => ((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IBookshelfPropertiesInternal)Property).ManagedResourceGroup = value ?? null; }

        /// <summary>Internal Acessors for PrivateEndpointConnection</summary>
        System.Collections.Generic.List<Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IPrivateEndpointConnection> Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IBookshelfInternal.PrivateEndpointConnection { get => ((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IBookshelfPropertiesInternal)Property).PrivateEndpointConnection; set => ((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IBookshelfPropertiesInternal)Property).PrivateEndpointConnection = value ?? null /* arrayOf */; }

        /// <summary>Internal Acessors for Property</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IBookshelfProperties Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IBookshelfInternal.Property { get => (this._property = this._property ?? new Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.BookshelfProperties()); set { {_property = value;} } }

        /// <summary>Internal Acessors for ProvisioningState</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IBookshelfInternal.ProvisioningState { get => ((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IBookshelfPropertiesInternal)Property).ProvisioningState; set => ((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IBookshelfPropertiesInternal)Property).ProvisioningState = value ?? null; }

        /// <summary>Internal Acessors for Uri</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IBookshelfInternal.Uri { get => ((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IBookshelfPropertiesInternal)Property).BookshelfUri; set => ((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IBookshelfPropertiesInternal)Property).BookshelfUri = value ?? null; }

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

        /// <summary>The name of the resource</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Discovery.Origin(Microsoft.Azure.PowerShell.Cmdlets.Discovery.PropertyOrigin.Inherited)]
        public string Name { get => ((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IResourceInternal)__trackedResource).Name; }

        /// <summary>List of private endpoint connections.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Discovery.Origin(Microsoft.Azure.PowerShell.Cmdlets.Discovery.PropertyOrigin.Inlined)]
        public System.Collections.Generic.List<Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IPrivateEndpointConnection> PrivateEndpointConnection { get => ((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IBookshelfPropertiesInternal)Property).PrivateEndpointConnection; }

        /// <summary>Private Endpoint Subnet ID for private endpoint connections.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Discovery.Origin(Microsoft.Azure.PowerShell.Cmdlets.Discovery.PropertyOrigin.Inlined)]
        public string PrivateEndpointSubnetId { get => ((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IBookshelfPropertiesInternal)Property).PrivateEndpointSubnetId; set => ((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IBookshelfPropertiesInternal)Property).PrivateEndpointSubnetId = value ?? null; }

        /// <summary>Backing field for <see cref="Property" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IBookshelfProperties _property;

        /// <summary>The resource-specific properties for this resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Discovery.Origin(Microsoft.Azure.PowerShell.Cmdlets.Discovery.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IBookshelfProperties Property { get => (this._property = this._property ?? new Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.BookshelfProperties()); set => this._property = value; }

        /// <summary>The status of the last operation.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Discovery.Origin(Microsoft.Azure.PowerShell.Cmdlets.Discovery.PropertyOrigin.Inlined)]
        public string ProvisioningState { get => ((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IBookshelfPropertiesInternal)Property).ProvisioningState; }

        /// <summary>
        /// Whether or not public network access is allowed for this resource. For security reasons, it is recommended to disable
        /// it whenever possible.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Discovery.Origin(Microsoft.Azure.PowerShell.Cmdlets.Discovery.PropertyOrigin.Inlined)]
        public string PublicNetworkAccess { get => ((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IBookshelfPropertiesInternal)Property).PublicNetworkAccess; set => ((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IBookshelfPropertiesInternal)Property).PublicNetworkAccess = value ?? null; }

        /// <summary>Gets the resource group name</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Discovery.Origin(Microsoft.Azure.PowerShell.Cmdlets.Discovery.PropertyOrigin.Owned)]
        public string ResourceGroupName { get => (new global::System.Text.RegularExpressions.Regex("^/subscriptions/(?<subscriptionId>[^/]+)/resourceGroups/(?<resourceGroupName>[^/]+)/providers/", global::System.Text.RegularExpressions.RegexOptions.IgnoreCase).Match(this.Id).Success ? new global::System.Text.RegularExpressions.Regex("^/subscriptions/(?<subscriptionId>[^/]+)/resourceGroups/(?<resourceGroupName>[^/]+)/providers/", global::System.Text.RegularExpressions.RegexOptions.IgnoreCase).Match(this.Id).Groups["resourceGroupName"].Value : null); }

        /// <summary>Search Subnet ID for search resources.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Discovery.Origin(Microsoft.Azure.PowerShell.Cmdlets.Discovery.PropertyOrigin.Inlined)]
        public string SearchSubnetId { get => ((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IBookshelfPropertiesInternal)Property).SearchSubnetId; set => ((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IBookshelfPropertiesInternal)Property).SearchSubnetId = value ?? null; }

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

        /// <summary>Resource tags.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Discovery.Origin(Microsoft.Azure.PowerShell.Cmdlets.Discovery.PropertyOrigin.Inherited)]
        public Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.ITrackedResourceTags Tag { get => ((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.ITrackedResourceInternal)__trackedResource).Tag; set => ((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.ITrackedResourceInternal)__trackedResource).Tag = value ?? null /* model class */; }

        /// <summary>
        /// The type of the resource. E.g. "Microsoft.Compute/virtualMachines" or "Microsoft.Storage/storageAccounts"
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Discovery.Origin(Microsoft.Azure.PowerShell.Cmdlets.Discovery.PropertyOrigin.Inherited)]
        public string Type { get => ((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IResourceInternal)__trackedResource).Type; }

        /// <summary>The bookshelf data plane API URI</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Discovery.Origin(Microsoft.Azure.PowerShell.Cmdlets.Discovery.PropertyOrigin.Inlined)]
        public string Uri { get => ((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IBookshelfPropertiesInternal)Property).BookshelfUri; }

        /// <summary>
        /// User assigned identity IDs to be used by knowledgebase workloads. The key value must be the resource ID of the identity
        /// resource.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Discovery.Origin(Microsoft.Azure.PowerShell.Cmdlets.Discovery.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IBookshelfPropertiesWorkloadIdentities WorkloadIdentity { get => ((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IBookshelfPropertiesInternal)Property).WorkloadIdentity; set => ((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IBookshelfPropertiesInternal)Property).WorkloadIdentity = value ?? null /* model class */; }

        /// <summary>Creates an new <see cref="Bookshelf" /> instance.</summary>
        public Bookshelf()
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
    /// Bookshelf tracked resource
    public partial interface IBookshelf :
        Microsoft.Azure.PowerShell.Cmdlets.Discovery.Runtime.IJsonSerializable,
        Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.ITrackedResource
    {
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
        /// The client ID of the identity to use for accessing the Key Vault. Must be a workload identity assigned to the Bookshelf
        /// resource.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Discovery.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = false,
        Description = @"The client ID of the identity to use for accessing the Key Vault. Must be a workload identity assigned to the Bookshelf resource.",
        SerializedName = @"identityClientId",
        PossibleTypes = new [] { typeof(string) })]
        string KeyVaultPropertyIdentityClientId { get; set; }
        /// <summary>The Key Name in Key Vault</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Discovery.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"The Key Name in Key Vault",
        SerializedName = @"keyName",
        PossibleTypes = new [] { typeof(string) })]
        string KeyVaultPropertyKeyName { get; set; }
        /// <summary>The Key Vault URI</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Discovery.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = false,
        Description = @"The Key Vault URI",
        SerializedName = @"keyVaultUri",
        PossibleTypes = new [] { typeof(string) })]
        string KeyVaultPropertyKeyVaultUri { get; set; }
        /// <summary>The Key Version in Key Vault</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Discovery.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"The Key Version in Key Vault",
        SerializedName = @"keyVersion",
        PossibleTypes = new [] { typeof(string) })]
        string KeyVaultPropertyKeyVersion { get; set; }
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
        /// <summary>List of private endpoint connections.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Discovery.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Read = true,
        Create = false,
        Update = false,
        Description = @"List of private endpoint connections.",
        SerializedName = @"privateEndpointConnections",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IPrivateEndpointConnection) })]
        System.Collections.Generic.List<Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IPrivateEndpointConnection> PrivateEndpointConnection { get;  }
        /// <summary>Private Endpoint Subnet ID for private endpoint connections.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Discovery.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = false,
        Description = @"Private Endpoint Subnet ID for private endpoint connections.",
        SerializedName = @"privateEndpointSubnetId",
        PossibleTypes = new [] { typeof(string) })]
        string PrivateEndpointSubnetId { get; set; }
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
        /// Whether or not public network access is allowed for this resource. For security reasons, it is recommended to disable
        /// it whenever possible.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Discovery.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"Whether or not public network access is allowed for this resource. For security reasons, it is recommended to disable it whenever possible.",
        SerializedName = @"publicNetworkAccess",
        PossibleTypes = new [] { typeof(string) })]
        [global::Microsoft.Azure.PowerShell.Cmdlets.Discovery.PSArgumentCompleterAttribute("Enabled", "Disabled")]
        string PublicNetworkAccess { get; set; }
        /// <summary>Search Subnet ID for search resources.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Discovery.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = false,
        Description = @"Search Subnet ID for search resources.",
        SerializedName = @"searchSubnetId",
        PossibleTypes = new [] { typeof(string) })]
        string SearchSubnetId { get; set; }
        /// <summary>The bookshelf data plane API URI</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Discovery.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Read = true,
        Create = false,
        Update = false,
        Description = @"The bookshelf data plane API URI",
        SerializedName = @"bookshelfUri",
        PossibleTypes = new [] { typeof(string) })]
        string Uri { get;  }
        /// <summary>
        /// User assigned identity IDs to be used by knowledgebase workloads. The key value must be the resource ID of the identity
        /// resource.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Discovery.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = false,
        Description = @"User assigned identity IDs to be used by knowledgebase workloads. The key value must be the resource ID of the identity resource.",
        SerializedName = @"workloadIdentities",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IBookshelfPropertiesWorkloadIdentities) })]
        Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IBookshelfPropertiesWorkloadIdentities WorkloadIdentity { get; set; }

    }
    /// Bookshelf tracked resource
    internal partial interface IBookshelfInternal :
        Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.ITrackedResourceInternal
    {
        /// <summary>Whether or not to use a customer managed key when encrypting data at rest</summary>
        [global::Microsoft.Azure.PowerShell.Cmdlets.Discovery.PSArgumentCompleterAttribute("Enabled", "Disabled")]
        string CustomerManagedKey { get; set; }
        /// <summary>
        /// The key to use for encrypting data at rest when customer managed keys are enabled. Required if Customer Managed Keys is
        /// enabled.
        /// </summary>
        Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IBookshelfKeyVaultProperties KeyVaultProperty { get; set; }
        /// <summary>
        /// The client ID of the identity to use for accessing the Key Vault. Must be a workload identity assigned to the Bookshelf
        /// resource.
        /// </summary>
        string KeyVaultPropertyIdentityClientId { get; set; }
        /// <summary>The Key Name in Key Vault</summary>
        string KeyVaultPropertyKeyName { get; set; }
        /// <summary>The Key Vault URI</summary>
        string KeyVaultPropertyKeyVaultUri { get; set; }
        /// <summary>The Key Version in Key Vault</summary>
        string KeyVaultPropertyKeyVersion { get; set; }
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
        /// <summary>List of private endpoint connections.</summary>
        System.Collections.Generic.List<Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IPrivateEndpointConnection> PrivateEndpointConnection { get; set; }
        /// <summary>Private Endpoint Subnet ID for private endpoint connections.</summary>
        string PrivateEndpointSubnetId { get; set; }
        /// <summary>The resource-specific properties for this resource.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IBookshelfProperties Property { get; set; }
        /// <summary>The status of the last operation.</summary>
        [global::Microsoft.Azure.PowerShell.Cmdlets.Discovery.PSArgumentCompleterAttribute("Succeeded", "Failed", "Canceled", "Accepted", "Provisioning", "Updating", "Deleting")]
        string ProvisioningState { get; set; }
        /// <summary>
        /// Whether or not public network access is allowed for this resource. For security reasons, it is recommended to disable
        /// it whenever possible.
        /// </summary>
        [global::Microsoft.Azure.PowerShell.Cmdlets.Discovery.PSArgumentCompleterAttribute("Enabled", "Disabled")]
        string PublicNetworkAccess { get; set; }
        /// <summary>Search Subnet ID for search resources.</summary>
        string SearchSubnetId { get; set; }
        /// <summary>The bookshelf data plane API URI</summary>
        string Uri { get; set; }
        /// <summary>
        /// User assigned identity IDs to be used by knowledgebase workloads. The key value must be the resource ID of the identity
        /// resource.
        /// </summary>
        Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IBookshelfPropertiesWorkloadIdentities WorkloadIdentity { get; set; }

    }
}