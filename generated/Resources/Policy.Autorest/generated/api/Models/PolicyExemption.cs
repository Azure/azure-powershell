// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
// Changes may cause incorrect behavior and will be lost if the code is regenerated.
namespace Microsoft.Azure.PowerShell.Cmdlets.Policy.Models
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Policy.Runtime.Extensions;

    /// <summary>The policy exemption.</summary>
    public partial class PolicyExemption :
        Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IPolicyExemption,
        Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IPolicyExemptionInternal,
        Microsoft.Azure.PowerShell.Cmdlets.Policy.Runtime.IValidates
    {
        /// <summary>
        /// Backing field for Inherited model <see cref= "Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IExtensionResource" />
        /// </summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IExtensionResource __extensionResource = new Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.ExtensionResource();

        /// <summary>The option whether validate the exemption is at or under the assignment scope.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Policy.Origin(Microsoft.Azure.PowerShell.Cmdlets.Policy.PropertyOrigin.Inlined)]
        [Microsoft.Azure.PowerShell.Cmdlets.Policy.DoNotFormat]
        public string AssignmentScopeValidation { get => ((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IPolicyExemptionPropertiesInternal)Property).AssignmentScopeValidation; set => ((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IPolicyExemptionPropertiesInternal)Property).AssignmentScopeValidation = value ?? null; }

        /// <summary>The description of the policy exemption.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Policy.Origin(Microsoft.Azure.PowerShell.Cmdlets.Policy.PropertyOrigin.Inlined)]
        [Microsoft.Azure.PowerShell.Cmdlets.Policy.DoNotFormat]
        public string Description { get => ((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IPolicyExemptionPropertiesInternal)Property).Description; set => ((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IPolicyExemptionPropertiesInternal)Property).Description = value ?? null; }

        /// <summary>The display name of the policy exemption.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Policy.Origin(Microsoft.Azure.PowerShell.Cmdlets.Policy.PropertyOrigin.Inlined)]
        [Microsoft.Azure.PowerShell.Cmdlets.Policy.FormatTable(Index = 2)]
        public string DisplayName { get => ((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IPolicyExemptionPropertiesInternal)Property).DisplayName; set => ((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IPolicyExemptionPropertiesInternal)Property).DisplayName = value ?? null; }

        /// <summary>The policy exemption category. Possible values are Waiver and Mitigated.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Policy.Origin(Microsoft.Azure.PowerShell.Cmdlets.Policy.PropertyOrigin.Inlined)]
        [Microsoft.Azure.PowerShell.Cmdlets.Policy.DoNotFormat]
        public string ExemptionCategory { get => ((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IPolicyExemptionPropertiesInternal)Property).ExemptionCategory; set => ((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IPolicyExemptionPropertiesInternal)Property).ExemptionCategory = value ?? null; }

        /// <summary>
        /// The expiration date and time (in UTC ISO 8601 format yyyy-MM-ddTHH:mm:ssZ) of the policy exemption.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Policy.Origin(Microsoft.Azure.PowerShell.Cmdlets.Policy.PropertyOrigin.Inlined)]
        [Microsoft.Azure.PowerShell.Cmdlets.Policy.DoNotFormat]
        public global::System.DateTime? ExpiresOn { get => ((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IPolicyExemptionPropertiesInternal)Property).ExpiresOn; set => ((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IPolicyExemptionPropertiesInternal)Property).ExpiresOn = value ?? default(global::System.DateTime); }

        /// <summary>
        /// Fully qualified resource ID for the resource. Ex - /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/{resourceProviderNamespace}/{resourceType}/{resourceName}
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Policy.Origin(Microsoft.Azure.PowerShell.Cmdlets.Policy.PropertyOrigin.Inherited)]
        [Microsoft.Azure.PowerShell.Cmdlets.Policy.DoNotFormat]
        public string Id { get => ((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IResourceInternal)__extensionResource).Id; }

        /// <summary>
        /// The policy exemption metadata. Metadata is an open ended object and is typically a collection of key value pairs.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Policy.Origin(Microsoft.Azure.PowerShell.Cmdlets.Policy.PropertyOrigin.Inlined)]
        [Microsoft.Azure.PowerShell.Cmdlets.Policy.DoNotFormat]
        public Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IAny MetadataRaw { get => ((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IPolicyExemptionPropertiesInternal)Property).Metadata; set => ((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IPolicyExemptionPropertiesInternal)Property).Metadata = value ?? null /* model class */; }

        /// <summary>Internal Acessors for Property</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IPolicyExemptionProperties Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IPolicyExemptionInternal.Property { get => (this._property = this._property ?? new Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.PolicyExemptionProperties()); set { {_property = value;} } }

        /// <summary>Internal Acessors for Id</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IResourceInternal.Id { get => ((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IResourceInternal)__extensionResource).Id; set => ((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IResourceInternal)__extensionResource).Id = value ?? null; }

        /// <summary>Internal Acessors for Name</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IResourceInternal.Name { get => ((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IResourceInternal)__extensionResource).Name; set => ((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IResourceInternal)__extensionResource).Name = value ?? null; }

        /// <summary>Internal Acessors for SystemData</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.ISystemData Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IResourceInternal.SystemData { get => ((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IResourceInternal)__extensionResource).SystemData; set => ((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IResourceInternal)__extensionResource).SystemData = value ?? null /* model class */; }

        /// <summary>Internal Acessors for SystemDataCreatedAt</summary>
        global::System.DateTime? Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IResourceInternal.SystemDataCreatedAt { get => ((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IResourceInternal)__extensionResource).SystemDataCreatedAt; set => ((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IResourceInternal)__extensionResource).SystemDataCreatedAt = value ?? default(global::System.DateTime); }

        /// <summary>Internal Acessors for SystemDataCreatedBy</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IResourceInternal.SystemDataCreatedBy { get => ((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IResourceInternal)__extensionResource).SystemDataCreatedBy; set => ((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IResourceInternal)__extensionResource).SystemDataCreatedBy = value ?? null; }

        /// <summary>Internal Acessors for SystemDataCreatedByType</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IResourceInternal.SystemDataCreatedByType { get => ((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IResourceInternal)__extensionResource).SystemDataCreatedByType; set => ((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IResourceInternal)__extensionResource).SystemDataCreatedByType = value ?? null; }

        /// <summary>Internal Acessors for SystemDataLastModifiedAt</summary>
        global::System.DateTime? Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IResourceInternal.SystemDataLastModifiedAt { get => ((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IResourceInternal)__extensionResource).SystemDataLastModifiedAt; set => ((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IResourceInternal)__extensionResource).SystemDataLastModifiedAt = value ?? default(global::System.DateTime); }

        /// <summary>Internal Acessors for SystemDataLastModifiedBy</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IResourceInternal.SystemDataLastModifiedBy { get => ((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IResourceInternal)__extensionResource).SystemDataLastModifiedBy; set => ((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IResourceInternal)__extensionResource).SystemDataLastModifiedBy = value ?? null; }

        /// <summary>Internal Acessors for SystemDataLastModifiedByType</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IResourceInternal.SystemDataLastModifiedByType { get => ((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IResourceInternal)__extensionResource).SystemDataLastModifiedByType; set => ((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IResourceInternal)__extensionResource).SystemDataLastModifiedByType = value ?? null; }

        /// <summary>Internal Acessors for Type</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IResourceInternal.Type { get => ((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IResourceInternal)__extensionResource).Type; set => ((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IResourceInternal)__extensionResource).Type = value ?? null; }

        /// <summary>The name of the resource</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Policy.Origin(Microsoft.Azure.PowerShell.Cmdlets.Policy.PropertyOrigin.Inherited)]
        [Microsoft.Azure.PowerShell.Cmdlets.Policy.FormatTable(Index = 0)]
        public string Name { get => ((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IResourceInternal)__extensionResource).Name; }

        /// <summary>The ID of the policy assignment that is being exempted.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Policy.Origin(Microsoft.Azure.PowerShell.Cmdlets.Policy.PropertyOrigin.Inlined)]
        [Microsoft.Azure.PowerShell.Cmdlets.Policy.FormatTable(Index = 1)]
        public string PolicyAssignmentId { get => ((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IPolicyExemptionPropertiesInternal)Property).PolicyAssignmentId; set => ((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IPolicyExemptionPropertiesInternal)Property).PolicyAssignmentId = value ?? null; }

        /// <summary>
        /// The policy definition reference ID list when the associated policy assignment is an assignment of a policy set definition.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Policy.Origin(Microsoft.Azure.PowerShell.Cmdlets.Policy.PropertyOrigin.Inlined)]
        [Microsoft.Azure.PowerShell.Cmdlets.Policy.DoNotFormat]
        public System.Collections.Generic.List<string> PolicyDefinitionReferenceId { get => ((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IPolicyExemptionPropertiesInternal)Property).PolicyDefinitionReferenceId; set => ((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IPolicyExemptionPropertiesInternal)Property).PolicyDefinitionReferenceId = value ?? null /* arrayOf */; }

        /// <summary>Backing field for <see cref="Property" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IPolicyExemptionProperties _property;

        /// <summary>Properties for the policy exemption.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Policy.Origin(Microsoft.Azure.PowerShell.Cmdlets.Policy.PropertyOrigin.Owned)]
        [Microsoft.Azure.PowerShell.Cmdlets.Policy.DoNotFormat]
        internal Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IPolicyExemptionProperties Property { get => (this._property = this._property ?? new Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.PolicyExemptionProperties()); set => this._property = value; }

        /// <summary>The resource selector list to filter policies by resource properties.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Policy.Origin(Microsoft.Azure.PowerShell.Cmdlets.Policy.PropertyOrigin.Inlined)]
        [Microsoft.Azure.PowerShell.Cmdlets.Policy.DoNotFormat]
        public System.Collections.Generic.List<Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IResourceSelector> ResourceSelectorRaw { get => ((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IPolicyExemptionPropertiesInternal)Property).ResourceSelector; set => ((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IPolicyExemptionPropertiesInternal)Property).ResourceSelector = value ?? null /* arrayOf */; }

        /// <summary>
        /// Azure Resource Manager metadata containing createdBy and modifiedBy information.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Policy.Origin(Microsoft.Azure.PowerShell.Cmdlets.Policy.PropertyOrigin.Inherited)]
        [Microsoft.Azure.PowerShell.Cmdlets.Policy.DoNotFormat]
        internal Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.ISystemData SystemData { get => ((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IResourceInternal)__extensionResource).SystemData; set => ((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IResourceInternal)__extensionResource).SystemData = value ?? null /* model class */; }

        /// <summary>The timestamp of resource creation (UTC).</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Policy.Origin(Microsoft.Azure.PowerShell.Cmdlets.Policy.PropertyOrigin.Inherited)]
        [Microsoft.Azure.PowerShell.Cmdlets.Policy.DoNotFormat]
        public global::System.DateTime? SystemDataCreatedAt { get => ((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IResourceInternal)__extensionResource).SystemDataCreatedAt; }

        /// <summary>The identity that created the resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Policy.Origin(Microsoft.Azure.PowerShell.Cmdlets.Policy.PropertyOrigin.Inherited)]
        [Microsoft.Azure.PowerShell.Cmdlets.Policy.DoNotFormat]
        public string SystemDataCreatedBy { get => ((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IResourceInternal)__extensionResource).SystemDataCreatedBy; }

        /// <summary>The type of identity that created the resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Policy.Origin(Microsoft.Azure.PowerShell.Cmdlets.Policy.PropertyOrigin.Inherited)]
        [Microsoft.Azure.PowerShell.Cmdlets.Policy.DoNotFormat]
        public string SystemDataCreatedByType { get => ((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IResourceInternal)__extensionResource).SystemDataCreatedByType; }

        /// <summary>The timestamp of resource last modification (UTC)</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Policy.Origin(Microsoft.Azure.PowerShell.Cmdlets.Policy.PropertyOrigin.Inherited)]
        [Microsoft.Azure.PowerShell.Cmdlets.Policy.DoNotFormat]
        public global::System.DateTime? SystemDataLastModifiedAt { get => ((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IResourceInternal)__extensionResource).SystemDataLastModifiedAt; }

        /// <summary>The identity that last modified the resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Policy.Origin(Microsoft.Azure.PowerShell.Cmdlets.Policy.PropertyOrigin.Inherited)]
        [Microsoft.Azure.PowerShell.Cmdlets.Policy.DoNotFormat]
        public string SystemDataLastModifiedBy { get => ((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IResourceInternal)__extensionResource).SystemDataLastModifiedBy; }

        /// <summary>The type of identity that last modified the resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Policy.Origin(Microsoft.Azure.PowerShell.Cmdlets.Policy.PropertyOrigin.Inherited)]
        [Microsoft.Azure.PowerShell.Cmdlets.Policy.DoNotFormat]
        public string SystemDataLastModifiedByType { get => ((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IResourceInternal)__extensionResource).SystemDataLastModifiedByType; }

        /// <summary>
        /// The type of the resource. E.g. "Microsoft.Compute/virtualMachines" or "Microsoft.Storage/storageAccounts"
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Policy.Origin(Microsoft.Azure.PowerShell.Cmdlets.Policy.PropertyOrigin.Inherited)]
        [Microsoft.Azure.PowerShell.Cmdlets.Policy.DoNotFormat]
        public string Type { get => ((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IResourceInternal)__extensionResource).Type; }

        /// <summary>Creates an new <see cref="PolicyExemption" /> instance.</summary>
        public PolicyExemption()
        {

        }

        /// <summary>Validates that this object meets the validation criteria.</summary>
        /// <param name="eventListener">an <see cref="Microsoft.Azure.PowerShell.Cmdlets.Policy.Runtime.IEventListener" /> instance that will receive validation
        /// events.</param>
        /// <returns>
        /// A <see cref = "global::System.Threading.Tasks.Task" /> that will be complete when validation is completed.
        /// </returns>
        public async global::System.Threading.Tasks.Task Validate(Microsoft.Azure.PowerShell.Cmdlets.Policy.Runtime.IEventListener eventListener)
        {
            await eventListener.AssertNotNull(nameof(__extensionResource), __extensionResource);
            await eventListener.AssertObjectIsValid(nameof(__extensionResource), __extensionResource);
        }
    }
    /// The policy exemption.
    public partial interface IPolicyExemption :
        Microsoft.Azure.PowerShell.Cmdlets.Policy.Runtime.IJsonSerializable,
        Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IExtensionResource
    {
        /// <summary>The option whether validate the exemption is at or under the assignment scope.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Policy.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"The option whether validate the exemption is at or under the assignment scope.",
        SerializedName = @"assignmentScopeValidation",
        PossibleTypes = new [] { typeof(string) })]
        [global::Microsoft.Azure.PowerShell.Cmdlets.Policy.PSArgumentCompleterAttribute("Default", "DoNotValidate")]
        string AssignmentScopeValidation { get; set; }
        /// <summary>The description of the policy exemption.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Policy.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"The description of the policy exemption.",
        SerializedName = @"description",
        PossibleTypes = new [] { typeof(string) })]
        string Description { get; set; }
        /// <summary>The display name of the policy exemption.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Policy.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"The display name of the policy exemption.",
        SerializedName = @"displayName",
        PossibleTypes = new [] { typeof(string) })]
        string DisplayName { get; set; }
        /// <summary>The policy exemption category. Possible values are Waiver and Mitigated.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Policy.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"The policy exemption category. Possible values are Waiver and Mitigated.",
        SerializedName = @"exemptionCategory",
        PossibleTypes = new [] { typeof(string) })]
        [global::Microsoft.Azure.PowerShell.Cmdlets.Policy.PSArgumentCompleterAttribute("Waiver", "Mitigated")]
        string ExemptionCategory { get; set; }
        /// <summary>
        /// The expiration date and time (in UTC ISO 8601 format yyyy-MM-ddTHH:mm:ssZ) of the policy exemption.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Policy.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"The expiration date and time (in UTC ISO 8601 format yyyy-MM-ddTHH:mm:ssZ) of the policy exemption.",
        SerializedName = @"expiresOn",
        PossibleTypes = new [] { typeof(global::System.DateTime) })]
        global::System.DateTime? ExpiresOn { get; set; }
        /// <summary>
        /// The policy exemption metadata. Metadata is an open ended object and is typically a collection of key value pairs.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Policy.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"The policy exemption metadata. Metadata is an open ended object and is typically a collection of key value pairs.",
        SerializedName = @"metadata",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IAny) })]
        Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IAny MetadataRaw { get; set; }
        /// <summary>The ID of the policy assignment that is being exempted.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Policy.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"The ID of the policy assignment that is being exempted.",
        SerializedName = @"policyAssignmentId",
        PossibleTypes = new [] { typeof(string) })]
        string PolicyAssignmentId { get; set; }
        /// <summary>
        /// The policy definition reference ID list when the associated policy assignment is an assignment of a policy set definition.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Policy.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"The policy definition reference ID list when the associated policy assignment is an assignment of a policy set definition.",
        SerializedName = @"policyDefinitionReferenceIds",
        PossibleTypes = new [] { typeof(string) })]
        System.Collections.Generic.List<string> PolicyDefinitionReferenceId { get; set; }
        /// <summary>The resource selector list to filter policies by resource properties.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Policy.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"The resource selector list to filter policies by resource properties.",
        SerializedName = @"resourceSelectors",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IResourceSelector) })]
        System.Collections.Generic.List<Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IResourceSelector> ResourceSelectorRaw { get; set; }

    }
    /// The policy exemption.
    internal partial interface IPolicyExemptionInternal :
        Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IExtensionResourceInternal
    {
        /// <summary>The option whether validate the exemption is at or under the assignment scope.</summary>
        [global::Microsoft.Azure.PowerShell.Cmdlets.Policy.PSArgumentCompleterAttribute("Default", "DoNotValidate")]
        string AssignmentScopeValidation { get; set; }
        /// <summary>The description of the policy exemption.</summary>
        string Description { get; set; }
        /// <summary>The display name of the policy exemption.</summary>
        string DisplayName { get; set; }
        /// <summary>The policy exemption category. Possible values are Waiver and Mitigated.</summary>
        [global::Microsoft.Azure.PowerShell.Cmdlets.Policy.PSArgumentCompleterAttribute("Waiver", "Mitigated")]
        string ExemptionCategory { get; set; }
        /// <summary>
        /// The expiration date and time (in UTC ISO 8601 format yyyy-MM-ddTHH:mm:ssZ) of the policy exemption.
        /// </summary>
        global::System.DateTime? ExpiresOn { get; set; }
        /// <summary>
        /// The policy exemption metadata. Metadata is an open ended object and is typically a collection of key value pairs.
        /// </summary>
        Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IAny MetadataRaw { get; set; }
        /// <summary>The ID of the policy assignment that is being exempted.</summary>
        string PolicyAssignmentId { get; set; }
        /// <summary>
        /// The policy definition reference ID list when the associated policy assignment is an assignment of a policy set definition.
        /// </summary>
        System.Collections.Generic.List<string> PolicyDefinitionReferenceId { get; set; }
        /// <summary>Properties for the policy exemption.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IPolicyExemptionProperties Property { get; set; }
        /// <summary>The resource selector list to filter policies by resource properties.</summary>
        System.Collections.Generic.List<Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IResourceSelector> ResourceSelectorRaw { get; set; }

    }
}