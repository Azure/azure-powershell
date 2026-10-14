// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
// Changes may cause incorrect behavior and will be lost if the code is regenerated.
namespace Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Discovery.Runtime.Extensions;

    /// <summary>Bookshelf properties</summary>
    public partial class BookshelfProperties :
        Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IBookshelfProperties,
        Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IBookshelfPropertiesInternal
    {

        /// <summary>Backing field for <see cref="BookshelfUri" /> property.</summary>
        private string _bookshelfUri;

        /// <summary>The bookshelf data plane API URI</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Discovery.Origin(Microsoft.Azure.PowerShell.Cmdlets.Discovery.PropertyOrigin.Owned)]
        public string BookshelfUri { get => this._bookshelfUri; }

        /// <summary>Backing field for <see cref="CustomerManagedKey" /> property.</summary>
        private string _customerManagedKey;

        /// <summary>Whether or not to use a customer managed key when encrypting data at rest</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Discovery.Origin(Microsoft.Azure.PowerShell.Cmdlets.Discovery.PropertyOrigin.Owned)]
        public string CustomerManagedKey { get => this._customerManagedKey; set => this._customerManagedKey = value; }

        /// <summary>Backing field for <see cref="KeyVaultProperty" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IBookshelfKeyVaultProperties _keyVaultProperty;

        /// <summary>
        /// The key to use for encrypting data at rest when customer managed keys are enabled. Required if Customer Managed Keys is
        /// enabled.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Discovery.Origin(Microsoft.Azure.PowerShell.Cmdlets.Discovery.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IBookshelfKeyVaultProperties KeyVaultProperty { get => (this._keyVaultProperty = this._keyVaultProperty ?? new Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.BookshelfKeyVaultProperties()); set => this._keyVaultProperty = value; }

        /// <summary>
        /// The client ID of the identity to use for accessing the Key Vault. Must be a workload identity assigned to the Bookshelf
        /// resource.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Discovery.Origin(Microsoft.Azure.PowerShell.Cmdlets.Discovery.PropertyOrigin.Inlined)]
        public string KeyVaultPropertyIdentityClientId { get => ((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IBookshelfKeyVaultPropertiesInternal)KeyVaultProperty).IdentityClientId; set => ((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IBookshelfKeyVaultPropertiesInternal)KeyVaultProperty).IdentityClientId = value ?? null; }

        /// <summary>The Key Name in Key Vault</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Discovery.Origin(Microsoft.Azure.PowerShell.Cmdlets.Discovery.PropertyOrigin.Inlined)]
        public string KeyVaultPropertyKeyName { get => ((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IBookshelfKeyVaultPropertiesInternal)KeyVaultProperty).KeyName; set => ((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IBookshelfKeyVaultPropertiesInternal)KeyVaultProperty).KeyName = value ?? null; }

        /// <summary>The Key Vault URI</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Discovery.Origin(Microsoft.Azure.PowerShell.Cmdlets.Discovery.PropertyOrigin.Inlined)]
        public string KeyVaultPropertyKeyVaultUri { get => ((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IBookshelfKeyVaultPropertiesInternal)KeyVaultProperty).KeyVaultUri; set => ((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IBookshelfKeyVaultPropertiesInternal)KeyVaultProperty).KeyVaultUri = value ?? null; }

        /// <summary>The Key Version in Key Vault</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Discovery.Origin(Microsoft.Azure.PowerShell.Cmdlets.Discovery.PropertyOrigin.Inlined)]
        public string KeyVaultPropertyKeyVersion { get => ((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IBookshelfKeyVaultPropertiesInternal)KeyVaultProperty).KeyVersion; set => ((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IBookshelfKeyVaultPropertiesInternal)KeyVaultProperty).KeyVersion = value ?? null; }

        /// <summary>Backing field for <see cref="LogAnalyticsClusterId" /> property.</summary>
        private string _logAnalyticsClusterId;

        /// <summary>
        /// The Log Analytics Cluster to use for debug logs. This is required when Customer Managed Keys are enabled.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Discovery.Origin(Microsoft.Azure.PowerShell.Cmdlets.Discovery.PropertyOrigin.Owned)]
        public string LogAnalyticsClusterId { get => this._logAnalyticsClusterId; set => this._logAnalyticsClusterId = value; }

        /// <summary>Backing field for <see cref="ManagedOnBehalfOfConfiguration" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IWithMoboBrokerResources _managedOnBehalfOfConfiguration;

        /// <summary>
        /// Managed-On-Behalf-Of configuration properties. This configuration exists for the resources where a resource provider manages
        /// those resources on behalf of the resource owner.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Discovery.Origin(Microsoft.Azure.PowerShell.Cmdlets.Discovery.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IWithMoboBrokerResources ManagedOnBehalfOfConfiguration { get => (this._managedOnBehalfOfConfiguration = this._managedOnBehalfOfConfiguration ?? new Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.WithMoboBrokerResources()); }

        /// <summary>Managed-On-Behalf-Of broker resources</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Discovery.Origin(Microsoft.Azure.PowerShell.Cmdlets.Discovery.PropertyOrigin.Inlined)]
        public System.Collections.Generic.List<Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IMoboBrokerResource> ManagedOnBehalfOfConfigurationMoboBrokerResource { get => ((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IWithMoboBrokerResourcesInternal)ManagedOnBehalfOfConfiguration).MoboBrokerResource; }

        /// <summary>Backing field for <see cref="ManagedResourceGroup" /> property.</summary>
        private string _managedResourceGroup;

        /// <summary>The resource group for resources managed on behalf of customer.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Discovery.Origin(Microsoft.Azure.PowerShell.Cmdlets.Discovery.PropertyOrigin.Owned)]
        public string ManagedResourceGroup { get => this._managedResourceGroup; }

        /// <summary>Internal Acessors for BookshelfUri</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IBookshelfPropertiesInternal.BookshelfUri { get => this._bookshelfUri; set { {_bookshelfUri = value;} } }

        /// <summary>Internal Acessors for KeyVaultProperty</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IBookshelfKeyVaultProperties Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IBookshelfPropertiesInternal.KeyVaultProperty { get => (this._keyVaultProperty = this._keyVaultProperty ?? new Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.BookshelfKeyVaultProperties()); set { {_keyVaultProperty = value;} } }

        /// <summary>Internal Acessors for ManagedOnBehalfOfConfiguration</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IWithMoboBrokerResources Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IBookshelfPropertiesInternal.ManagedOnBehalfOfConfiguration { get => (this._managedOnBehalfOfConfiguration = this._managedOnBehalfOfConfiguration ?? new Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.WithMoboBrokerResources()); set { {_managedOnBehalfOfConfiguration = value;} } }

        /// <summary>Internal Acessors for ManagedOnBehalfOfConfigurationMoboBrokerResource</summary>
        System.Collections.Generic.List<Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IMoboBrokerResource> Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IBookshelfPropertiesInternal.ManagedOnBehalfOfConfigurationMoboBrokerResource { get => ((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IWithMoboBrokerResourcesInternal)ManagedOnBehalfOfConfiguration).MoboBrokerResource; set => ((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IWithMoboBrokerResourcesInternal)ManagedOnBehalfOfConfiguration).MoboBrokerResource = value ?? null /* arrayOf */; }

        /// <summary>Internal Acessors for ManagedResourceGroup</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IBookshelfPropertiesInternal.ManagedResourceGroup { get => this._managedResourceGroup; set { {_managedResourceGroup = value;} } }

        /// <summary>Internal Acessors for PrivateEndpointConnection</summary>
        System.Collections.Generic.List<Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IPrivateEndpointConnection> Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IBookshelfPropertiesInternal.PrivateEndpointConnection { get => this._privateEndpointConnection; set { {_privateEndpointConnection = value;} } }

        /// <summary>Internal Acessors for ProvisioningState</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IBookshelfPropertiesInternal.ProvisioningState { get => this._provisioningState; set { {_provisioningState = value;} } }

        /// <summary>Backing field for <see cref="PrivateEndpointConnection" /> property.</summary>
        private System.Collections.Generic.List<Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IPrivateEndpointConnection> _privateEndpointConnection;

        /// <summary>List of private endpoint connections.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Discovery.Origin(Microsoft.Azure.PowerShell.Cmdlets.Discovery.PropertyOrigin.Owned)]
        public System.Collections.Generic.List<Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IPrivateEndpointConnection> PrivateEndpointConnection { get => this._privateEndpointConnection; }

        /// <summary>Backing field for <see cref="PrivateEndpointSubnetId" /> property.</summary>
        private string _privateEndpointSubnetId;

        /// <summary>Private Endpoint Subnet ID for private endpoint connections.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Discovery.Origin(Microsoft.Azure.PowerShell.Cmdlets.Discovery.PropertyOrigin.Owned)]
        public string PrivateEndpointSubnetId { get => this._privateEndpointSubnetId; set => this._privateEndpointSubnetId = value; }

        /// <summary>Backing field for <see cref="ProvisioningState" /> property.</summary>
        private string _provisioningState;

        /// <summary>The status of the last operation.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Discovery.Origin(Microsoft.Azure.PowerShell.Cmdlets.Discovery.PropertyOrigin.Owned)]
        public string ProvisioningState { get => this._provisioningState; }

        /// <summary>Backing field for <see cref="PublicNetworkAccess" /> property.</summary>
        private string _publicNetworkAccess;

        /// <summary>
        /// Whether or not public network access is allowed for this resource. For security reasons, it is recommended to disable
        /// it whenever possible.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Discovery.Origin(Microsoft.Azure.PowerShell.Cmdlets.Discovery.PropertyOrigin.Owned)]
        public string PublicNetworkAccess { get => this._publicNetworkAccess; set => this._publicNetworkAccess = value; }

        /// <summary>Backing field for <see cref="SearchSubnetId" /> property.</summary>
        private string _searchSubnetId;

        /// <summary>Search Subnet ID for search resources.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Discovery.Origin(Microsoft.Azure.PowerShell.Cmdlets.Discovery.PropertyOrigin.Owned)]
        public string SearchSubnetId { get => this._searchSubnetId; set => this._searchSubnetId = value; }

        /// <summary>Backing field for <see cref="WorkloadIdentity" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IBookshelfPropertiesWorkloadIdentities _workloadIdentity;

        /// <summary>
        /// User assigned identity IDs to be used by knowledgebase workloads. The key value must be the resource ID of the identity
        /// resource.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Discovery.Origin(Microsoft.Azure.PowerShell.Cmdlets.Discovery.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IBookshelfPropertiesWorkloadIdentities WorkloadIdentity { get => (this._workloadIdentity = this._workloadIdentity ?? new Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.BookshelfPropertiesWorkloadIdentities()); set => this._workloadIdentity = value; }

        /// <summary>Creates an new <see cref="BookshelfProperties" /> instance.</summary>
        public BookshelfProperties()
        {

        }
    }
    /// Bookshelf properties
    public partial interface IBookshelfProperties :
        Microsoft.Azure.PowerShell.Cmdlets.Discovery.Runtime.IJsonSerializable
    {
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
        string BookshelfUri { get;  }
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
    /// Bookshelf properties
    internal partial interface IBookshelfPropertiesInternal

    {
        /// <summary>The bookshelf data plane API URI</summary>
        string BookshelfUri { get; set; }
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
        /// <summary>
        /// User assigned identity IDs to be used by knowledgebase workloads. The key value must be the resource ID of the identity
        /// resource.
        /// </summary>
        Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IBookshelfPropertiesWorkloadIdentities WorkloadIdentity { get; set; }

    }
}