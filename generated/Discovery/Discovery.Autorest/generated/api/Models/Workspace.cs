// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
// Changes may cause incorrect behavior and will be lost if the code is regenerated.
namespace Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Discovery.Runtime.Extensions;

    /// <summary>Workspace tracked resource</summary>
    public partial class Workspace :
        Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IWorkspace,
        Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IWorkspaceInternal,
        Microsoft.Azure.PowerShell.Cmdlets.Discovery.Runtime.IValidates
    {
        /// <summary>
        /// Backing field for Inherited model <see cref= "Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.ITrackedResource" />
        /// </summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.ITrackedResource __trackedResource = new Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.TrackedResource();

        /// <summary>Agent Subnet ID for agent resources.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Discovery.Origin(Microsoft.Azure.PowerShell.Cmdlets.Discovery.PropertyOrigin.Inlined)]
        public string AgentSubnetId { get => ((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IWorkspacePropertiesInternal)Property).AgentSubnetId; set => ((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IWorkspacePropertiesInternal)Property).AgentSubnetId = value ?? null; }

        /// <summary>workspace API endpoint Uri.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Discovery.Origin(Microsoft.Azure.PowerShell.Cmdlets.Discovery.PropertyOrigin.Inlined)]
        public string ApiUri { get => ((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IWorkspacePropertiesInternal)Property).WorkspaceApiUri; }

        /// <summary>Whether or not to use a customer managed key when encrypting data at rest</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Discovery.Origin(Microsoft.Azure.PowerShell.Cmdlets.Discovery.PropertyOrigin.Inlined)]
        public string CustomerManagedKey { get => ((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IWorkspacePropertiesInternal)Property).CustomerManagedKey; set => ((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IWorkspacePropertiesInternal)Property).CustomerManagedKey = value ?? null; }

        /// <summary>
        /// Fully qualified resource ID for the resource. Ex - /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/{resourceProviderNamespace}/{resourceType}/{resourceName}
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Discovery.Origin(Microsoft.Azure.PowerShell.Cmdlets.Discovery.PropertyOrigin.Inherited)]
        public string Id { get => ((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IResourceInternal)__trackedResource).Id; }

        /// <summary>The client ID of the assigned identity.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Discovery.Origin(Microsoft.Azure.PowerShell.Cmdlets.Discovery.PropertyOrigin.Inlined)]
        public string IdentityClientId { get => ((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IWorkspacePropertiesInternal)Property).WorkspaceIdentityClientId; }

        /// <summary>The resource ID of the user assigned identity.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Discovery.Origin(Microsoft.Azure.PowerShell.Cmdlets.Discovery.PropertyOrigin.Inlined)]
        public string IdentityId { get => ((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IWorkspacePropertiesInternal)Property).WorkspaceIdentityId; set => ((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IWorkspacePropertiesInternal)Property).WorkspaceIdentityId = value ?? null; }

        /// <summary>The principal ID of the assigned identity.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Discovery.Origin(Microsoft.Azure.PowerShell.Cmdlets.Discovery.PropertyOrigin.Inlined)]
        public string IdentityPrincipalId { get => ((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IWorkspacePropertiesInternal)Property).WorkspaceIdentityPrincipalId; }

        /// <summary>The Key Name in Key Vault</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Discovery.Origin(Microsoft.Azure.PowerShell.Cmdlets.Discovery.PropertyOrigin.Inlined)]
        public string KeyVaultPropertyKeyName { get => ((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IWorkspacePropertiesInternal)Property).KeyVaultPropertyKeyName; set => ((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IWorkspacePropertiesInternal)Property).KeyVaultPropertyKeyName = value ?? null; }

        /// <summary>The Key Vault URI</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Discovery.Origin(Microsoft.Azure.PowerShell.Cmdlets.Discovery.PropertyOrigin.Inlined)]
        public string KeyVaultPropertyKeyVaultUri { get => ((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IWorkspacePropertiesInternal)Property).KeyVaultPropertyKeyVaultUri; set => ((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IWorkspacePropertiesInternal)Property).KeyVaultPropertyKeyVaultUri = value ?? null; }

        /// <summary>The Key Version in Key Vault</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Discovery.Origin(Microsoft.Azure.PowerShell.Cmdlets.Discovery.PropertyOrigin.Inlined)]
        public string KeyVaultPropertyKeyVersion { get => ((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IWorkspacePropertiesInternal)Property).KeyVaultPropertyKeyVersion; set => ((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IWorkspacePropertiesInternal)Property).KeyVaultPropertyKeyVersion = value ?? null; }

        /// <summary>The geo-location where the resource lives</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Discovery.Origin(Microsoft.Azure.PowerShell.Cmdlets.Discovery.PropertyOrigin.Inherited)]
        public string Location { get => ((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.ITrackedResourceInternal)__trackedResource).Location; set => ((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.ITrackedResourceInternal)__trackedResource).Location = value ?? null; }

        /// <summary>
        /// The Log Analytics Cluster to use for debug logs. This is required when Customer Managed Keys are enabled.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Discovery.Origin(Microsoft.Azure.PowerShell.Cmdlets.Discovery.PropertyOrigin.Inlined)]
        public string LogAnalyticsClusterId { get => ((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IWorkspacePropertiesInternal)Property).LogAnalyticsClusterId; set => ((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IWorkspacePropertiesInternal)Property).LogAnalyticsClusterId = value ?? null; }

        /// <summary>Managed-On-Behalf-Of broker resources</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Discovery.Origin(Microsoft.Azure.PowerShell.Cmdlets.Discovery.PropertyOrigin.Inlined)]
        public System.Collections.Generic.List<Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IMoboBrokerResource> ManagedOnBehalfOfConfigurationMoboBrokerResource { get => ((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IWorkspacePropertiesInternal)Property).ManagedOnBehalfOfConfigurationMoboBrokerResource; }

        /// <summary>The resource group for resources managed on behalf of customer.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Discovery.Origin(Microsoft.Azure.PowerShell.Cmdlets.Discovery.PropertyOrigin.Inlined)]
        public string ManagedResourceGroup { get => ((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IWorkspacePropertiesInternal)Property).ManagedResourceGroup; }

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

        /// <summary>Internal Acessors for ApiUri</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IWorkspaceInternal.ApiUri { get => ((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IWorkspacePropertiesInternal)Property).WorkspaceApiUri; set => ((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IWorkspacePropertiesInternal)Property).WorkspaceApiUri = value ?? null; }

        /// <summary>Internal Acessors for Identity</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IIdentity Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IWorkspaceInternal.Identity { get => ((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IWorkspacePropertiesInternal)Property).WorkspaceIdentity; set => ((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IWorkspacePropertiesInternal)Property).WorkspaceIdentity = value ?? null /* model class */; }

        /// <summary>Internal Acessors for IdentityClientId</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IWorkspaceInternal.IdentityClientId { get => ((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IWorkspacePropertiesInternal)Property).WorkspaceIdentityClientId; set => ((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IWorkspacePropertiesInternal)Property).WorkspaceIdentityClientId = value ?? null; }

        /// <summary>Internal Acessors for IdentityPrincipalId</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IWorkspaceInternal.IdentityPrincipalId { get => ((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IWorkspacePropertiesInternal)Property).WorkspaceIdentityPrincipalId; set => ((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IWorkspacePropertiesInternal)Property).WorkspaceIdentityPrincipalId = value ?? null; }

        /// <summary>Internal Acessors for KeyVaultProperty</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IKeyVaultProperties Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IWorkspaceInternal.KeyVaultProperty { get => ((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IWorkspacePropertiesInternal)Property).KeyVaultProperty; set => ((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IWorkspacePropertiesInternal)Property).KeyVaultProperty = value ?? null /* model class */; }

        /// <summary>Internal Acessors for ManagedOnBehalfOfConfiguration</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IWithMoboBrokerResources Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IWorkspaceInternal.ManagedOnBehalfOfConfiguration { get => ((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IWorkspacePropertiesInternal)Property).ManagedOnBehalfOfConfiguration; set => ((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IWorkspacePropertiesInternal)Property).ManagedOnBehalfOfConfiguration = value ?? null /* model class */; }

        /// <summary>Internal Acessors for ManagedOnBehalfOfConfigurationMoboBrokerResource</summary>
        System.Collections.Generic.List<Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IMoboBrokerResource> Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IWorkspaceInternal.ManagedOnBehalfOfConfigurationMoboBrokerResource { get => ((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IWorkspacePropertiesInternal)Property).ManagedOnBehalfOfConfigurationMoboBrokerResource; set => ((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IWorkspacePropertiesInternal)Property).ManagedOnBehalfOfConfigurationMoboBrokerResource = value ?? null /* arrayOf */; }

        /// <summary>Internal Acessors for ManagedResourceGroup</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IWorkspaceInternal.ManagedResourceGroup { get => ((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IWorkspacePropertiesInternal)Property).ManagedResourceGroup; set => ((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IWorkspacePropertiesInternal)Property).ManagedResourceGroup = value ?? null; }

        /// <summary>Internal Acessors for PrivateEndpointConnection</summary>
        System.Collections.Generic.List<Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IPrivateEndpointConnection> Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IWorkspaceInternal.PrivateEndpointConnection { get => ((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IWorkspacePropertiesInternal)Property).PrivateEndpointConnection; set => ((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IWorkspacePropertiesInternal)Property).PrivateEndpointConnection = value ?? null /* arrayOf */; }

        /// <summary>Internal Acessors for Property</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IWorkspaceProperties Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IWorkspaceInternal.Property { get => (this._property = this._property ?? new Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.WorkspaceProperties()); set { {_property = value;} } }

        /// <summary>Internal Acessors for ProvisioningState</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IWorkspaceInternal.ProvisioningState { get => ((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IWorkspacePropertiesInternal)Property).ProvisioningState; set => ((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IWorkspacePropertiesInternal)Property).ProvisioningState = value ?? null; }

        /// <summary>Internal Acessors for UiUri</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IWorkspaceInternal.UiUri { get => ((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IWorkspacePropertiesInternal)Property).WorkspaceUiUri; set => ((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IWorkspacePropertiesInternal)Property).WorkspaceUiUri = value ?? null; }

        /// <summary>The name of the resource</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Discovery.Origin(Microsoft.Azure.PowerShell.Cmdlets.Discovery.PropertyOrigin.Inherited)]
        public string Name { get => ((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IResourceInternal)__trackedResource).Name; }

        /// <summary>List of private endpoint connections.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Discovery.Origin(Microsoft.Azure.PowerShell.Cmdlets.Discovery.PropertyOrigin.Inlined)]
        public System.Collections.Generic.List<Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IPrivateEndpointConnection> PrivateEndpointConnection { get => ((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IWorkspacePropertiesInternal)Property).PrivateEndpointConnection; }

        /// <summary>Private Endpoint Subnet ID for private endpoint connections.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Discovery.Origin(Microsoft.Azure.PowerShell.Cmdlets.Discovery.PropertyOrigin.Inlined)]
        public string PrivateEndpointSubnetId { get => ((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IWorkspacePropertiesInternal)Property).PrivateEndpointSubnetId; set => ((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IWorkspacePropertiesInternal)Property).PrivateEndpointSubnetId = value ?? null; }

        /// <summary>Backing field for <see cref="Property" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IWorkspaceProperties _property;

        /// <summary>The resource-specific properties for this resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Discovery.Origin(Microsoft.Azure.PowerShell.Cmdlets.Discovery.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IWorkspaceProperties Property { get => (this._property = this._property ?? new Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.WorkspaceProperties()); set => this._property = value; }

        /// <summary>The status of the last operation.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Discovery.Origin(Microsoft.Azure.PowerShell.Cmdlets.Discovery.PropertyOrigin.Inlined)]
        public string ProvisioningState { get => ((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IWorkspacePropertiesInternal)Property).ProvisioningState; }

        /// <summary>
        /// Whether or not public network access is allowed for this resource. For security reasons, it is recommended to disable
        /// it whenever possible.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Discovery.Origin(Microsoft.Azure.PowerShell.Cmdlets.Discovery.PropertyOrigin.Inlined)]
        public string PublicNetworkAccess { get => ((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IWorkspacePropertiesInternal)Property).PublicNetworkAccess; set => ((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IWorkspacePropertiesInternal)Property).PublicNetworkAccess = value ?? null; }

        /// <summary>Gets the resource group name</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Discovery.Origin(Microsoft.Azure.PowerShell.Cmdlets.Discovery.PropertyOrigin.Owned)]
        public string ResourceGroupName { get => (new global::System.Text.RegularExpressions.Regex("^/subscriptions/(?<subscriptionId>[^/]+)/resourceGroups/(?<resourceGroupName>[^/]+)/providers/", global::System.Text.RegularExpressions.RegexOptions.IgnoreCase).Match(this.Id).Success ? new global::System.Text.RegularExpressions.Regex("^/subscriptions/(?<subscriptionId>[^/]+)/resourceGroups/(?<resourceGroupName>[^/]+)/providers/", global::System.Text.RegularExpressions.RegexOptions.IgnoreCase).Match(this.Id).Groups["resourceGroupName"].Value : null); }

        /// <summary>Function Subnet ID for workspace resources.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Discovery.Origin(Microsoft.Azure.PowerShell.Cmdlets.Discovery.PropertyOrigin.Inlined)]
        public string SubnetId { get => ((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IWorkspacePropertiesInternal)Property).WorkspaceSubnetId; set => ((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IWorkspacePropertiesInternal)Property).WorkspaceSubnetId = value ?? null; }

        /// <summary>List of linked SuperComputers.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Discovery.Origin(Microsoft.Azure.PowerShell.Cmdlets.Discovery.PropertyOrigin.Inlined)]
        public System.Collections.Generic.List<string> SupercomputerId { get => ((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IWorkspacePropertiesInternal)Property).SupercomputerId; set => ((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IWorkspacePropertiesInternal)Property).SupercomputerId = value ?? null /* arrayOf */; }

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

        /// <summary>workspace User Interface Uri.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Discovery.Origin(Microsoft.Azure.PowerShell.Cmdlets.Discovery.PropertyOrigin.Inlined)]
        public string UiUri { get => ((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IWorkspacePropertiesInternal)Property).WorkspaceUiUri; }

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

        /// <summary>Creates an new <see cref="Workspace" /> instance.</summary>
        public Workspace()
        {

        }
    }
    /// Workspace tracked resource
    public partial interface IWorkspace :
        Microsoft.Azure.PowerShell.Cmdlets.Discovery.Runtime.IJsonSerializable,
        Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.ITrackedResource
    {
        /// <summary>Agent Subnet ID for agent resources.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Discovery.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = false,
        Description = @"Agent Subnet ID for agent resources.",
        SerializedName = @"agentSubnetId",
        PossibleTypes = new [] { typeof(string) })]
        string AgentSubnetId { get; set; }
        /// <summary>workspace API endpoint Uri.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Discovery.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Read = true,
        Create = false,
        Update = false,
        Description = @"workspace API endpoint Uri.",
        SerializedName = @"workspaceApiUri",
        PossibleTypes = new [] { typeof(string) })]
        string ApiUri { get;  }
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
        string IdentityClientId { get;  }
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
        string IdentityId { get; set; }
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
        string IdentityPrincipalId { get;  }
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
        /// <summary>Function Subnet ID for workspace resources.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Discovery.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = false,
        Description = @"Function Subnet ID for workspace resources.",
        SerializedName = @"workspaceSubnetId",
        PossibleTypes = new [] { typeof(string) })]
        string SubnetId { get; set; }
        /// <summary>List of linked SuperComputers.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Discovery.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"List of linked SuperComputers.",
        SerializedName = @"supercomputerIds",
        PossibleTypes = new [] { typeof(string) })]
        System.Collections.Generic.List<string> SupercomputerId { get; set; }
        /// <summary>workspace User Interface Uri.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Discovery.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Read = true,
        Create = false,
        Update = false,
        Description = @"workspace User Interface Uri.",
        SerializedName = @"workspaceUiUri",
        PossibleTypes = new [] { typeof(string) })]
        string UiUri { get;  }

    }
    /// Workspace tracked resource
    internal partial interface IWorkspaceInternal :
        Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.ITrackedResourceInternal
    {
        /// <summary>Agent Subnet ID for agent resources.</summary>
        string AgentSubnetId { get; set; }
        /// <summary>workspace API endpoint Uri.</summary>
        string ApiUri { get; set; }
        /// <summary>Whether or not to use a customer managed key when encrypting data at rest</summary>
        [global::Microsoft.Azure.PowerShell.Cmdlets.Discovery.PSArgumentCompleterAttribute("Enabled", "Disabled")]
        string CustomerManagedKey { get; set; }
        /// <summary>Identity IDs used for leveraging Workspace resources.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IIdentity Identity { get; set; }
        /// <summary>The client ID of the assigned identity.</summary>
        string IdentityClientId { get; set; }
        /// <summary>The resource ID of the user assigned identity.</summary>
        string IdentityId { get; set; }
        /// <summary>The principal ID of the assigned identity.</summary>
        string IdentityPrincipalId { get; set; }
        /// <summary>
        /// The key to use for encrypting data at rest when customer managed keys are enabled.
        /// </summary>
        Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IKeyVaultProperties KeyVaultProperty { get; set; }
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
        Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IWorkspaceProperties Property { get; set; }
        /// <summary>The status of the last operation.</summary>
        [global::Microsoft.Azure.PowerShell.Cmdlets.Discovery.PSArgumentCompleterAttribute("Succeeded", "Failed", "Canceled", "Accepted", "Provisioning", "Updating", "Deleting")]
        string ProvisioningState { get; set; }
        /// <summary>
        /// Whether or not public network access is allowed for this resource. For security reasons, it is recommended to disable
        /// it whenever possible.
        /// </summary>
        [global::Microsoft.Azure.PowerShell.Cmdlets.Discovery.PSArgumentCompleterAttribute("Enabled", "Disabled")]
        string PublicNetworkAccess { get; set; }
        /// <summary>Function Subnet ID for workspace resources.</summary>
        string SubnetId { get; set; }
        /// <summary>List of linked SuperComputers.</summary>
        System.Collections.Generic.List<string> SupercomputerId { get; set; }
        /// <summary>workspace User Interface Uri.</summary>
        string UiUri { get; set; }

    }
}