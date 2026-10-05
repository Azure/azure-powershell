// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
// Changes may cause incorrect behavior and will be lost if the code is regenerated.
namespace Microsoft.Azure.PowerShell.Cmdlets.Relationships.Models
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Relationships.Runtime.Extensions;

    /// <summary>Defines a ServiceGroupMember relationship resource.</summary>
    public partial class ServiceGroupMemberRelationship :
        Microsoft.Azure.PowerShell.Cmdlets.Relationships.Models.IServiceGroupMemberRelationship,
        Microsoft.Azure.PowerShell.Cmdlets.Relationships.Models.IServiceGroupMemberRelationshipInternal,
        Microsoft.Azure.PowerShell.Cmdlets.Relationships.Runtime.IValidates
    {
        /// <summary>
        /// Backing field for Inherited model <see cref= "Microsoft.Azure.PowerShell.Cmdlets.Relationships.Models.IExtensionResource"
        /// />
        /// </summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Relationships.Models.IExtensionResource __extensionResource = new Microsoft.Azure.PowerShell.Cmdlets.Relationships.Models.ExtensionResource();

        /// <summary>
        /// Fully qualified resource ID for the resource. Ex - /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/{resourceProviderNamespace}/{resourceType}/{resourceName}
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Relationships.Origin(Microsoft.Azure.PowerShell.Cmdlets.Relationships.PropertyOrigin.Inherited)]
        public string Id { get => ((Microsoft.Azure.PowerShell.Cmdlets.Relationships.Models.IResourceInternal)__extensionResource).Id; }

        /// <summary>The type of the relationship source resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Relationships.Origin(Microsoft.Azure.PowerShell.Cmdlets.Relationships.PropertyOrigin.Inlined)]
        public string MetadataSourceType { get => ((Microsoft.Azure.PowerShell.Cmdlets.Relationships.Models.IServiceGroupMemberRelationshipPropertiesInternal)Property).MetadataSourceType; }

        /// <summary>The type of the relationship target resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Relationships.Origin(Microsoft.Azure.PowerShell.Cmdlets.Relationships.PropertyOrigin.Inlined)]
        public string MetadataTargetType { get => ((Microsoft.Azure.PowerShell.Cmdlets.Relationships.Models.IServiceGroupMemberRelationshipPropertiesInternal)Property).MetadataTargetType; }

        /// <summary>Internal Acessors for Id</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Relationships.Models.IResourceInternal.Id { get => ((Microsoft.Azure.PowerShell.Cmdlets.Relationships.Models.IResourceInternal)__extensionResource).Id; set => ((Microsoft.Azure.PowerShell.Cmdlets.Relationships.Models.IResourceInternal)__extensionResource).Id = value ?? null; }

        /// <summary>Internal Acessors for Name</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Relationships.Models.IResourceInternal.Name { get => ((Microsoft.Azure.PowerShell.Cmdlets.Relationships.Models.IResourceInternal)__extensionResource).Name; set => ((Microsoft.Azure.PowerShell.Cmdlets.Relationships.Models.IResourceInternal)__extensionResource).Name = value ?? null; }

        /// <summary>Internal Acessors for SystemData</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Relationships.Models.ISystemData Microsoft.Azure.PowerShell.Cmdlets.Relationships.Models.IResourceInternal.SystemData { get => ((Microsoft.Azure.PowerShell.Cmdlets.Relationships.Models.IResourceInternal)__extensionResource).SystemData; set => ((Microsoft.Azure.PowerShell.Cmdlets.Relationships.Models.IResourceInternal)__extensionResource).SystemData = value ?? null /* model class */; }

        /// <summary>Internal Acessors for SystemDataCreatedAt</summary>
        global::System.DateTime? Microsoft.Azure.PowerShell.Cmdlets.Relationships.Models.IResourceInternal.SystemDataCreatedAt { get => ((Microsoft.Azure.PowerShell.Cmdlets.Relationships.Models.IResourceInternal)__extensionResource).SystemDataCreatedAt; set => ((Microsoft.Azure.PowerShell.Cmdlets.Relationships.Models.IResourceInternal)__extensionResource).SystemDataCreatedAt = value ?? default(global::System.DateTime); }

        /// <summary>Internal Acessors for SystemDataCreatedBy</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Relationships.Models.IResourceInternal.SystemDataCreatedBy { get => ((Microsoft.Azure.PowerShell.Cmdlets.Relationships.Models.IResourceInternal)__extensionResource).SystemDataCreatedBy; set => ((Microsoft.Azure.PowerShell.Cmdlets.Relationships.Models.IResourceInternal)__extensionResource).SystemDataCreatedBy = value ?? null; }

        /// <summary>Internal Acessors for SystemDataCreatedByType</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Relationships.Models.IResourceInternal.SystemDataCreatedByType { get => ((Microsoft.Azure.PowerShell.Cmdlets.Relationships.Models.IResourceInternal)__extensionResource).SystemDataCreatedByType; set => ((Microsoft.Azure.PowerShell.Cmdlets.Relationships.Models.IResourceInternal)__extensionResource).SystemDataCreatedByType = value ?? null; }

        /// <summary>Internal Acessors for SystemDataLastModifiedAt</summary>
        global::System.DateTime? Microsoft.Azure.PowerShell.Cmdlets.Relationships.Models.IResourceInternal.SystemDataLastModifiedAt { get => ((Microsoft.Azure.PowerShell.Cmdlets.Relationships.Models.IResourceInternal)__extensionResource).SystemDataLastModifiedAt; set => ((Microsoft.Azure.PowerShell.Cmdlets.Relationships.Models.IResourceInternal)__extensionResource).SystemDataLastModifiedAt = value ?? default(global::System.DateTime); }

        /// <summary>Internal Acessors for SystemDataLastModifiedBy</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Relationships.Models.IResourceInternal.SystemDataLastModifiedBy { get => ((Microsoft.Azure.PowerShell.Cmdlets.Relationships.Models.IResourceInternal)__extensionResource).SystemDataLastModifiedBy; set => ((Microsoft.Azure.PowerShell.Cmdlets.Relationships.Models.IResourceInternal)__extensionResource).SystemDataLastModifiedBy = value ?? null; }

        /// <summary>Internal Acessors for SystemDataLastModifiedByType</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Relationships.Models.IResourceInternal.SystemDataLastModifiedByType { get => ((Microsoft.Azure.PowerShell.Cmdlets.Relationships.Models.IResourceInternal)__extensionResource).SystemDataLastModifiedByType; set => ((Microsoft.Azure.PowerShell.Cmdlets.Relationships.Models.IResourceInternal)__extensionResource).SystemDataLastModifiedByType = value ?? null; }

        /// <summary>Internal Acessors for Type</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Relationships.Models.IResourceInternal.Type { get => ((Microsoft.Azure.PowerShell.Cmdlets.Relationships.Models.IResourceInternal)__extensionResource).Type; set => ((Microsoft.Azure.PowerShell.Cmdlets.Relationships.Models.IResourceInternal)__extensionResource).Type = value ?? null; }

        /// <summary>Internal Acessors for Metadata</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Relationships.Models.IRelationshipMetadata Microsoft.Azure.PowerShell.Cmdlets.Relationships.Models.IServiceGroupMemberRelationshipInternal.Metadata { get => ((Microsoft.Azure.PowerShell.Cmdlets.Relationships.Models.IServiceGroupMemberRelationshipPropertiesInternal)Property).Metadata; set => ((Microsoft.Azure.PowerShell.Cmdlets.Relationships.Models.IServiceGroupMemberRelationshipPropertiesInternal)Property).Metadata = value ?? null /* model class */; }

        /// <summary>Internal Acessors for MetadataSourceType</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Relationships.Models.IServiceGroupMemberRelationshipInternal.MetadataSourceType { get => ((Microsoft.Azure.PowerShell.Cmdlets.Relationships.Models.IServiceGroupMemberRelationshipPropertiesInternal)Property).MetadataSourceType; set => ((Microsoft.Azure.PowerShell.Cmdlets.Relationships.Models.IServiceGroupMemberRelationshipPropertiesInternal)Property).MetadataSourceType = value ?? null; }

        /// <summary>Internal Acessors for MetadataTargetType</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Relationships.Models.IServiceGroupMemberRelationshipInternal.MetadataTargetType { get => ((Microsoft.Azure.PowerShell.Cmdlets.Relationships.Models.IServiceGroupMemberRelationshipPropertiesInternal)Property).MetadataTargetType; set => ((Microsoft.Azure.PowerShell.Cmdlets.Relationships.Models.IServiceGroupMemberRelationshipPropertiesInternal)Property).MetadataTargetType = value ?? null; }

        /// <summary>Internal Acessors for OriginInformation</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Relationships.Models.IRelationshipOriginInformation Microsoft.Azure.PowerShell.Cmdlets.Relationships.Models.IServiceGroupMemberRelationshipInternal.OriginInformation { get => ((Microsoft.Azure.PowerShell.Cmdlets.Relationships.Models.IServiceGroupMemberRelationshipPropertiesInternal)Property).OriginInformation; set => ((Microsoft.Azure.PowerShell.Cmdlets.Relationships.Models.IServiceGroupMemberRelationshipPropertiesInternal)Property).OriginInformation = value ?? null /* model class */; }

        /// <summary>Internal Acessors for OriginInformationDiscoveryEngine</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Relationships.Models.IServiceGroupMemberRelationshipInternal.OriginInformationDiscoveryEngine { get => ((Microsoft.Azure.PowerShell.Cmdlets.Relationships.Models.IServiceGroupMemberRelationshipPropertiesInternal)Property).OriginInformationDiscoveryEngine; set => ((Microsoft.Azure.PowerShell.Cmdlets.Relationships.Models.IServiceGroupMemberRelationshipPropertiesInternal)Property).OriginInformationDiscoveryEngine = value ?? null; }

        /// <summary>Internal Acessors for OriginInformationRelationshipOriginType</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Relationships.Models.IServiceGroupMemberRelationshipInternal.OriginInformationRelationshipOriginType { get => ((Microsoft.Azure.PowerShell.Cmdlets.Relationships.Models.IServiceGroupMemberRelationshipPropertiesInternal)Property).OriginInformationRelationshipOriginType; set => ((Microsoft.Azure.PowerShell.Cmdlets.Relationships.Models.IServiceGroupMemberRelationshipPropertiesInternal)Property).OriginInformationRelationshipOriginType = value ?? null; }

        /// <summary>Internal Acessors for Property</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Relationships.Models.IServiceGroupMemberRelationshipProperties Microsoft.Azure.PowerShell.Cmdlets.Relationships.Models.IServiceGroupMemberRelationshipInternal.Property { get => (this._property = this._property ?? new Microsoft.Azure.PowerShell.Cmdlets.Relationships.Models.ServiceGroupMemberRelationshipProperties()); set { {_property = value;} } }

        /// <summary>Internal Acessors for ProvisioningState</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Relationships.Models.IServiceGroupMemberRelationshipInternal.ProvisioningState { get => ((Microsoft.Azure.PowerShell.Cmdlets.Relationships.Models.IServiceGroupMemberRelationshipPropertiesInternal)Property).ProvisioningState; set => ((Microsoft.Azure.PowerShell.Cmdlets.Relationships.Models.IServiceGroupMemberRelationshipPropertiesInternal)Property).ProvisioningState = value ?? null; }

        /// <summary>Internal Acessors for SourceId</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Relationships.Models.IServiceGroupMemberRelationshipInternal.SourceId { get => ((Microsoft.Azure.PowerShell.Cmdlets.Relationships.Models.IServiceGroupMemberRelationshipPropertiesInternal)Property).SourceId; set => ((Microsoft.Azure.PowerShell.Cmdlets.Relationships.Models.IServiceGroupMemberRelationshipPropertiesInternal)Property).SourceId = value ?? null; }

        /// <summary>The name of the resource</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Relationships.Origin(Microsoft.Azure.PowerShell.Cmdlets.Relationships.PropertyOrigin.Inherited)]
        public string Name { get => ((Microsoft.Azure.PowerShell.Cmdlets.Relationships.Models.IResourceInternal)__extensionResource).Name; }

        /// <summary>The name of the discovery engine that created the relationship.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Relationships.Origin(Microsoft.Azure.PowerShell.Cmdlets.Relationships.PropertyOrigin.Inlined)]
        public string OriginInformationDiscoveryEngine { get => ((Microsoft.Azure.PowerShell.Cmdlets.Relationships.Models.IServiceGroupMemberRelationshipPropertiesInternal)Property).OriginInformationDiscoveryEngine; }

        /// <summary>Identifies the origin type of the relationship.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Relationships.Origin(Microsoft.Azure.PowerShell.Cmdlets.Relationships.PropertyOrigin.Inlined)]
        public string OriginInformationRelationshipOriginType { get => ((Microsoft.Azure.PowerShell.Cmdlets.Relationships.Models.IServiceGroupMemberRelationshipPropertiesInternal)Property).OriginInformationRelationshipOriginType; }

        /// <summary>Backing field for <see cref="Property" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Relationships.Models.IServiceGroupMemberRelationshipProperties _property;

        /// <summary>The resource-specific properties for this resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Relationships.Origin(Microsoft.Azure.PowerShell.Cmdlets.Relationships.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.Relationships.Models.IServiceGroupMemberRelationshipProperties Property { get => (this._property = this._property ?? new Microsoft.Azure.PowerShell.Cmdlets.Relationships.Models.ServiceGroupMemberRelationshipProperties()); set => this._property = value; }

        /// <summary>The provisioning state of the relationship.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Relationships.Origin(Microsoft.Azure.PowerShell.Cmdlets.Relationships.PropertyOrigin.Inlined)]
        public string ProvisioningState { get => ((Microsoft.Azure.PowerShell.Cmdlets.Relationships.Models.IServiceGroupMemberRelationshipPropertiesInternal)Property).ProvisioningState; }

        /// <summary>Gets the resource group name</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Relationships.Origin(Microsoft.Azure.PowerShell.Cmdlets.Relationships.PropertyOrigin.Owned)]
        public string ResourceGroupName { get => (new global::System.Text.RegularExpressions.Regex("^/subscriptions/(?<subscriptionId>[^/]+)/resourceGroups/(?<resourceGroupName>[^/]+)/providers/", global::System.Text.RegularExpressions.RegexOptions.IgnoreCase).Match(this.Id).Success ? new global::System.Text.RegularExpressions.Regex("^/subscriptions/(?<subscriptionId>[^/]+)/resourceGroups/(?<resourceGroupName>[^/]+)/providers/", global::System.Text.RegularExpressions.RegexOptions.IgnoreCase).Match(this.Id).Groups["resourceGroupName"].Value : null); }

        /// <summary>The relationship source resource id.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Relationships.Origin(Microsoft.Azure.PowerShell.Cmdlets.Relationships.PropertyOrigin.Inlined)]
        public string SourceId { get => ((Microsoft.Azure.PowerShell.Cmdlets.Relationships.Models.IServiceGroupMemberRelationshipPropertiesInternal)Property).SourceId; }

        /// <summary>
        /// Azure Resource Manager metadata containing createdBy and modifiedBy information.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Relationships.Origin(Microsoft.Azure.PowerShell.Cmdlets.Relationships.PropertyOrigin.Inherited)]
        internal Microsoft.Azure.PowerShell.Cmdlets.Relationships.Models.ISystemData SystemData { get => ((Microsoft.Azure.PowerShell.Cmdlets.Relationships.Models.IResourceInternal)__extensionResource).SystemData; set => ((Microsoft.Azure.PowerShell.Cmdlets.Relationships.Models.IResourceInternal)__extensionResource).SystemData = value ?? null /* model class */; }

        /// <summary>The timestamp of resource creation (UTC).</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Relationships.Origin(Microsoft.Azure.PowerShell.Cmdlets.Relationships.PropertyOrigin.Inherited)]
        public global::System.DateTime? SystemDataCreatedAt { get => ((Microsoft.Azure.PowerShell.Cmdlets.Relationships.Models.IResourceInternal)__extensionResource).SystemDataCreatedAt; }

        /// <summary>The identity that created the resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Relationships.Origin(Microsoft.Azure.PowerShell.Cmdlets.Relationships.PropertyOrigin.Inherited)]
        public string SystemDataCreatedBy { get => ((Microsoft.Azure.PowerShell.Cmdlets.Relationships.Models.IResourceInternal)__extensionResource).SystemDataCreatedBy; }

        /// <summary>The type of identity that created the resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Relationships.Origin(Microsoft.Azure.PowerShell.Cmdlets.Relationships.PropertyOrigin.Inherited)]
        public string SystemDataCreatedByType { get => ((Microsoft.Azure.PowerShell.Cmdlets.Relationships.Models.IResourceInternal)__extensionResource).SystemDataCreatedByType; }

        /// <summary>The timestamp of resource last modification (UTC)</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Relationships.Origin(Microsoft.Azure.PowerShell.Cmdlets.Relationships.PropertyOrigin.Inherited)]
        public global::System.DateTime? SystemDataLastModifiedAt { get => ((Microsoft.Azure.PowerShell.Cmdlets.Relationships.Models.IResourceInternal)__extensionResource).SystemDataLastModifiedAt; }

        /// <summary>The identity that last modified the resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Relationships.Origin(Microsoft.Azure.PowerShell.Cmdlets.Relationships.PropertyOrigin.Inherited)]
        public string SystemDataLastModifiedBy { get => ((Microsoft.Azure.PowerShell.Cmdlets.Relationships.Models.IResourceInternal)__extensionResource).SystemDataLastModifiedBy; }

        /// <summary>The type of identity that last modified the resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Relationships.Origin(Microsoft.Azure.PowerShell.Cmdlets.Relationships.PropertyOrigin.Inherited)]
        public string SystemDataLastModifiedByType { get => ((Microsoft.Azure.PowerShell.Cmdlets.Relationships.Models.IResourceInternal)__extensionResource).SystemDataLastModifiedByType; }

        /// <summary>The relationship target resource id.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Relationships.Origin(Microsoft.Azure.PowerShell.Cmdlets.Relationships.PropertyOrigin.Inlined)]
        public string TargetId { get => ((Microsoft.Azure.PowerShell.Cmdlets.Relationships.Models.IServiceGroupMemberRelationshipPropertiesInternal)Property).TargetId; set => ((Microsoft.Azure.PowerShell.Cmdlets.Relationships.Models.IServiceGroupMemberRelationshipPropertiesInternal)Property).TargetId = value ?? null; }

        /// <summary>The relationship target tenant id.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Relationships.Origin(Microsoft.Azure.PowerShell.Cmdlets.Relationships.PropertyOrigin.Inlined)]
        public string TargetTenant { get => ((Microsoft.Azure.PowerShell.Cmdlets.Relationships.Models.IServiceGroupMemberRelationshipPropertiesInternal)Property).TargetTenant; set => ((Microsoft.Azure.PowerShell.Cmdlets.Relationships.Models.IServiceGroupMemberRelationshipPropertiesInternal)Property).TargetTenant = value ?? null; }

        /// <summary>
        /// The type of the resource. E.g. "Microsoft.Compute/virtualMachines" or "Microsoft.Storage/storageAccounts"
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Relationships.Origin(Microsoft.Azure.PowerShell.Cmdlets.Relationships.PropertyOrigin.Inherited)]
        public string Type { get => ((Microsoft.Azure.PowerShell.Cmdlets.Relationships.Models.IResourceInternal)__extensionResource).Type; }

        /// <summary>Creates an new <see cref="ServiceGroupMemberRelationship" /> instance.</summary>
        public ServiceGroupMemberRelationship()
        {

        }

        /// <summary>Validates that this object meets the validation criteria.</summary>
        /// <param name="eventListener">an <see cref="Microsoft.Azure.PowerShell.Cmdlets.Relationships.Runtime.IEventListener" /> instance that will receive validation
        /// events.</param>
        /// <returns>
        /// A <see cref = "global::System.Threading.Tasks.Task" /> that will be complete when validation is completed.
        /// </returns>
        public async global::System.Threading.Tasks.Task Validate(Microsoft.Azure.PowerShell.Cmdlets.Relationships.Runtime.IEventListener eventListener)
        {
            await eventListener.AssertNotNull(nameof(__extensionResource), __extensionResource);
            await eventListener.AssertObjectIsValid(nameof(__extensionResource), __extensionResource);
        }
    }
    /// Defines a ServiceGroupMember relationship resource.
    public partial interface IServiceGroupMemberRelationship :
        Microsoft.Azure.PowerShell.Cmdlets.Relationships.Runtime.IJsonSerializable,
        Microsoft.Azure.PowerShell.Cmdlets.Relationships.Models.IExtensionResource
    {
        /// <summary>The type of the relationship source resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Relationships.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Read = true,
        Create = false,
        Update = false,
        Description = @"The type of the relationship source resource.",
        SerializedName = @"sourceType",
        PossibleTypes = new [] { typeof(string) })]
        string MetadataSourceType { get;  }
        /// <summary>The type of the relationship target resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Relationships.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Read = true,
        Create = false,
        Update = false,
        Description = @"The type of the relationship target resource.",
        SerializedName = @"targetType",
        PossibleTypes = new [] { typeof(string) })]
        string MetadataTargetType { get;  }
        /// <summary>The name of the discovery engine that created the relationship.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Relationships.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Read = true,
        Create = false,
        Update = false,
        Description = @"The name of the discovery engine that created the relationship.",
        SerializedName = @"discoveryEngine",
        PossibleTypes = new [] { typeof(string) })]
        string OriginInformationDiscoveryEngine { get;  }
        /// <summary>Identifies the origin type of the relationship.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Relationships.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Read = true,
        Create = false,
        Update = false,
        Description = @"Identifies the origin type of the relationship.",
        SerializedName = @"relationshipOriginType",
        PossibleTypes = new [] { typeof(string) })]
        [global::Microsoft.Azure.PowerShell.Cmdlets.Relationships.PSArgumentCompleterAttribute("ServiceExplicitlyCreated", "SystemDiscoveredByRule", "UserExplicitlyCreated", "UserDiscoveredByRule")]
        string OriginInformationRelationshipOriginType { get;  }
        /// <summary>The provisioning state of the relationship.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Relationships.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Read = true,
        Create = false,
        Update = false,
        Description = @"The provisioning state of the relationship.",
        SerializedName = @"provisioningState",
        PossibleTypes = new [] { typeof(string) })]
        [global::Microsoft.Azure.PowerShell.Cmdlets.Relationships.PSArgumentCompleterAttribute("Succeeded", "Failed", "Canceled", "Provisioning", "Updating", "Deleting", "Accepted")]
        string ProvisioningState { get;  }
        /// <summary>The relationship source resource id.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Relationships.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Read = true,
        Create = false,
        Update = false,
        Description = @"The relationship source resource id.",
        SerializedName = @"sourceId",
        PossibleTypes = new [] { typeof(string) })]
        string SourceId { get;  }
        /// <summary>The relationship target resource id.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Relationships.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"The relationship target resource id.",
        SerializedName = @"targetId",
        PossibleTypes = new [] { typeof(string) })]
        string TargetId { get; set; }
        /// <summary>The relationship target tenant id.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Relationships.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"The relationship target tenant id.",
        SerializedName = @"targetTenant",
        PossibleTypes = new [] { typeof(string) })]
        string TargetTenant { get; set; }

    }
    /// Defines a ServiceGroupMember relationship resource.
    internal partial interface IServiceGroupMemberRelationshipInternal :
        Microsoft.Azure.PowerShell.Cmdlets.Relationships.Models.IExtensionResourceInternal
    {
        /// <summary>Metadata about the relationship.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Relationships.Models.IRelationshipMetadata Metadata { get; set; }
        /// <summary>The type of the relationship source resource.</summary>
        string MetadataSourceType { get; set; }
        /// <summary>The type of the relationship target resource.</summary>
        string MetadataTargetType { get; set; }
        /// <summary>Information about the origin of the relationship.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Relationships.Models.IRelationshipOriginInformation OriginInformation { get; set; }
        /// <summary>The name of the discovery engine that created the relationship.</summary>
        string OriginInformationDiscoveryEngine { get; set; }
        /// <summary>Identifies the origin type of the relationship.</summary>
        [global::Microsoft.Azure.PowerShell.Cmdlets.Relationships.PSArgumentCompleterAttribute("ServiceExplicitlyCreated", "SystemDiscoveredByRule", "UserExplicitlyCreated", "UserDiscoveredByRule")]
        string OriginInformationRelationshipOriginType { get; set; }
        /// <summary>The resource-specific properties for this resource.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Relationships.Models.IServiceGroupMemberRelationshipProperties Property { get; set; }
        /// <summary>The provisioning state of the relationship.</summary>
        [global::Microsoft.Azure.PowerShell.Cmdlets.Relationships.PSArgumentCompleterAttribute("Succeeded", "Failed", "Canceled", "Provisioning", "Updating", "Deleting", "Accepted")]
        string ProvisioningState { get; set; }
        /// <summary>The relationship source resource id.</summary>
        string SourceId { get; set; }
        /// <summary>The relationship target resource id.</summary>
        string TargetId { get; set; }
        /// <summary>The relationship target tenant id.</summary>
        string TargetTenant { get; set; }

    }
}