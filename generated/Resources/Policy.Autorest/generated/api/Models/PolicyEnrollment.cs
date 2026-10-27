// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
// Changes may cause incorrect behavior and will be lost if the code is regenerated.
namespace Microsoft.Azure.PowerShell.Cmdlets.Policy.Models
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Policy.Runtime.Extensions;

    /// <summary>The policy enrollment.</summary>
    public partial class PolicyEnrollment :
        Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IPolicyEnrollment,
        Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IPolicyEnrollmentInternal,
        Microsoft.Azure.PowerShell.Cmdlets.Policy.Runtime.IValidates
    {
        /// <summary>
        /// Backing field for Inherited model <see cref= "Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IExtensionResource" />
        /// </summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IExtensionResource __extensionResource = new Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.ExtensionResource();

        /// <summary>
        /// The option whether to validate the enrollment is at or under the assignment scope.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Policy.Origin(Microsoft.Azure.PowerShell.Cmdlets.Policy.PropertyOrigin.Inlined)]
        public string AssignmentScopeValidation { get => ((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IPolicyEnrollmentPropertiesInternal)Property).AssignmentScopeValidation; set => ((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IPolicyEnrollmentPropertiesInternal)Property).AssignmentScopeValidation = value ?? null; }

        /// <summary>The description of the policy enrollment.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Policy.Origin(Microsoft.Azure.PowerShell.Cmdlets.Policy.PropertyOrigin.Inlined)]
        public string Description { get => ((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IPolicyEnrollmentPropertiesInternal)Property).Description; set => ((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IPolicyEnrollmentPropertiesInternal)Property).Description = value ?? null; }

        /// <summary>The display name of the policy enrollment.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Policy.Origin(Microsoft.Azure.PowerShell.Cmdlets.Policy.PropertyOrigin.Inlined)]
        public string DisplayName { get => ((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IPolicyEnrollmentPropertiesInternal)Property).DisplayName; set => ((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IPolicyEnrollmentPropertiesInternal)Property).DisplayName = value ?? null; }

        /// <summary>Backing field for <see cref="ETag" /> property.</summary>
        private string _eTag;

        /// <summary>The ETag for the policy enrollment.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Policy.Origin(Microsoft.Azure.PowerShell.Cmdlets.Policy.PropertyOrigin.Owned)]
        public string ETag { get => this._eTag; set => this._eTag = value; }

        /// <summary>
        /// Fully qualified resource ID for the resource. Ex - /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/{resourceProviderNamespace}/{resourceType}/{resourceName}
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Policy.Origin(Microsoft.Azure.PowerShell.Cmdlets.Policy.PropertyOrigin.Inherited)]
        public string Id { get => ((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IResourceInternal)__extensionResource).Id; }

        /// <summary>
        /// The policy enrollment metadata. Metadata is an open ended object and is typically a collection of key value pairs.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Policy.Origin(Microsoft.Azure.PowerShell.Cmdlets.Policy.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IAny Metadata { get => ((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IPolicyEnrollmentPropertiesInternal)Property).Metadata; set => ((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IPolicyEnrollmentPropertiesInternal)Property).Metadata = value ?? null /* model class */; }

        /// <summary>Internal Acessors for PolicyAssignmentInstanceId</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IPolicyEnrollmentInternal.PolicyAssignmentInstanceId { get => ((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IPolicyEnrollmentPropertiesInternal)Property).PolicyAssignmentInstanceId; set => ((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IPolicyEnrollmentPropertiesInternal)Property).PolicyAssignmentInstanceId = value ?? null; }

        /// <summary>Internal Acessors for Property</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IPolicyEnrollmentProperties Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IPolicyEnrollmentInternal.Property { get => (this._property = this._property ?? new Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.PolicyEnrollmentProperties()); set { {_property = value;} } }

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
        public string Name { get => ((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IResourceInternal)__extensionResource).Name; }

        /// <summary>The ID of the policy assignment that is being enrolled.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Policy.Origin(Microsoft.Azure.PowerShell.Cmdlets.Policy.PropertyOrigin.Inlined)]
        public string PolicyAssignmentId { get => ((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IPolicyEnrollmentPropertiesInternal)Property).PolicyAssignmentId; set => ((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IPolicyEnrollmentPropertiesInternal)Property).PolicyAssignmentId = value ?? null; }

        /// <summary>
        /// The policy assignment instance ID associated with this enrollment.
        /// The value is set to the instance ID of the policy assignment the policyAssignmentId references when the enrollment is
        /// created or updated.
        /// The format is a GUID string.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Policy.Origin(Microsoft.Azure.PowerShell.Cmdlets.Policy.PropertyOrigin.Inlined)]
        public string PolicyAssignmentInstanceId { get => ((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IPolicyEnrollmentPropertiesInternal)Property).PolicyAssignmentInstanceId; }

        /// <summary>
        /// The policy definition reference IDs for policy definitions in an assigned policy set definition.
        /// These IDs correspond to a subset of `policyDefinitions[*].policyDefinitionReferenceId` in the policy set definition.
        /// When specified and not empty, only the referenced policy definitions will be enrolled to. Otherwise, the entire policy
        /// set is enrolled to
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Policy.Origin(Microsoft.Azure.PowerShell.Cmdlets.Policy.PropertyOrigin.Inlined)]
        public System.Collections.Generic.List<string> PolicyDefinitionReferenceId { get => ((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IPolicyEnrollmentPropertiesInternal)Property).PolicyDefinitionReferenceId; set => ((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IPolicyEnrollmentPropertiesInternal)Property).PolicyDefinitionReferenceId = value ?? null /* arrayOf */; }

        /// <summary>Backing field for <see cref="Property" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IPolicyEnrollmentProperties _property;

        /// <summary>The properties of the policy enrollment.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Policy.Origin(Microsoft.Azure.PowerShell.Cmdlets.Policy.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IPolicyEnrollmentProperties Property { get => (this._property = this._property ?? new Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.PolicyEnrollmentProperties()); set => this._property = value; }

        /// <summary>The resource selector list to filter policies by resource properties.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Policy.Origin(Microsoft.Azure.PowerShell.Cmdlets.Policy.PropertyOrigin.Inlined)]
        public System.Collections.Generic.List<Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IResourceSelector> ResourceSelector { get => ((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IPolicyEnrollmentPropertiesInternal)Property).ResourceSelector; set => ((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IPolicyEnrollmentPropertiesInternal)Property).ResourceSelector = value ?? null /* arrayOf */; }

        /// <summary>
        /// Azure Resource Manager metadata containing createdBy and modifiedBy information.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Policy.Origin(Microsoft.Azure.PowerShell.Cmdlets.Policy.PropertyOrigin.Inherited)]
        internal Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.ISystemData SystemData { get => ((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IResourceInternal)__extensionResource).SystemData; set => ((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IResourceInternal)__extensionResource).SystemData = value ?? null /* model class */; }

        /// <summary>The timestamp of resource creation (UTC).</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Policy.Origin(Microsoft.Azure.PowerShell.Cmdlets.Policy.PropertyOrigin.Inherited)]
        public global::System.DateTime? SystemDataCreatedAt { get => ((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IResourceInternal)__extensionResource).SystemDataCreatedAt; }

        /// <summary>The identity that created the resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Policy.Origin(Microsoft.Azure.PowerShell.Cmdlets.Policy.PropertyOrigin.Inherited)]
        public string SystemDataCreatedBy { get => ((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IResourceInternal)__extensionResource).SystemDataCreatedBy; }

        /// <summary>The type of identity that created the resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Policy.Origin(Microsoft.Azure.PowerShell.Cmdlets.Policy.PropertyOrigin.Inherited)]
        public string SystemDataCreatedByType { get => ((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IResourceInternal)__extensionResource).SystemDataCreatedByType; }

        /// <summary>The timestamp of resource last modification (UTC)</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Policy.Origin(Microsoft.Azure.PowerShell.Cmdlets.Policy.PropertyOrigin.Inherited)]
        public global::System.DateTime? SystemDataLastModifiedAt { get => ((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IResourceInternal)__extensionResource).SystemDataLastModifiedAt; }

        /// <summary>The identity that last modified the resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Policy.Origin(Microsoft.Azure.PowerShell.Cmdlets.Policy.PropertyOrigin.Inherited)]
        public string SystemDataLastModifiedBy { get => ((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IResourceInternal)__extensionResource).SystemDataLastModifiedBy; }

        /// <summary>The type of identity that last modified the resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Policy.Origin(Microsoft.Azure.PowerShell.Cmdlets.Policy.PropertyOrigin.Inherited)]
        public string SystemDataLastModifiedByType { get => ((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IResourceInternal)__extensionResource).SystemDataLastModifiedByType; }

        /// <summary>
        /// The type of the resource. E.g. "Microsoft.Compute/virtualMachines" or "Microsoft.Storage/storageAccounts"
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Policy.Origin(Microsoft.Azure.PowerShell.Cmdlets.Policy.PropertyOrigin.Inherited)]
        public string Type { get => ((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IResourceInternal)__extensionResource).Type; }

        /// <summary>Creates an new <see cref="PolicyEnrollment" /> instance.</summary>
        public PolicyEnrollment()
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
    /// The policy enrollment.
    public partial interface IPolicyEnrollment :
        Microsoft.Azure.PowerShell.Cmdlets.Policy.Runtime.IJsonSerializable,
        Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IExtensionResource
    {
        /// <summary>
        /// The option whether to validate the enrollment is at or under the assignment scope.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Policy.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"The option whether to validate the enrollment is at or under the assignment scope.",
        SerializedName = @"assignmentScopeValidation",
        PossibleTypes = new [] { typeof(string) })]
        [global::Microsoft.Azure.PowerShell.Cmdlets.Policy.PSArgumentCompleterAttribute("Default", "DoNotValidate")]
        string AssignmentScopeValidation { get; set; }
        /// <summary>The description of the policy enrollment.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Policy.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"The description of the policy enrollment.",
        SerializedName = @"description",
        PossibleTypes = new [] { typeof(string) })]
        string Description { get; set; }
        /// <summary>The display name of the policy enrollment.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Policy.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"The display name of the policy enrollment.",
        SerializedName = @"displayName",
        PossibleTypes = new [] { typeof(string) })]
        string DisplayName { get; set; }
        /// <summary>The ETag for the policy enrollment.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Policy.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"The ETag for the policy enrollment.",
        SerializedName = @"eTag",
        PossibleTypes = new [] { typeof(string) })]
        string ETag { get; set; }
        /// <summary>
        /// The policy enrollment metadata. Metadata is an open ended object and is typically a collection of key value pairs.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Policy.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"The policy enrollment metadata. Metadata is an open ended object and is typically a collection of key value pairs.",
        SerializedName = @"metadata",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IAny) })]
        Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IAny Metadata { get; set; }
        /// <summary>The ID of the policy assignment that is being enrolled.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Policy.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"The ID of the policy assignment that is being enrolled.",
        SerializedName = @"policyAssignmentId",
        PossibleTypes = new [] { typeof(string) })]
        string PolicyAssignmentId { get; set; }
        /// <summary>
        /// The policy assignment instance ID associated with this enrollment.
        /// The value is set to the instance ID of the policy assignment the policyAssignmentId references when the enrollment is
        /// created or updated.
        /// The format is a GUID string.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Policy.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Read = true,
        Create = false,
        Update = false,
        Description = @"The policy assignment instance ID associated with this enrollment.
        The value is set to the instance ID of the policy assignment the policyAssignmentId references when the enrollment is created or updated.
        The format is a GUID string.",
        SerializedName = @"policyAssignmentInstanceId",
        PossibleTypes = new [] { typeof(string) })]
        string PolicyAssignmentInstanceId { get;  }
        /// <summary>
        /// The policy definition reference IDs for policy definitions in an assigned policy set definition.
        /// These IDs correspond to a subset of `policyDefinitions[*].policyDefinitionReferenceId` in the policy set definition.
        /// When specified and not empty, only the referenced policy definitions will be enrolled to. Otherwise, the entire policy
        /// set is enrolled to
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Policy.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"The policy definition reference IDs for policy definitions in an assigned policy set definition.
        These IDs correspond to a subset of `policyDefinitions[*].policyDefinitionReferenceId` in the policy set definition.
        When specified and not empty, only the referenced policy definitions will be enrolled to. Otherwise, the entire policy set is enrolled to",
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
        System.Collections.Generic.List<Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IResourceSelector> ResourceSelector { get; set; }

    }
    /// The policy enrollment.
    internal partial interface IPolicyEnrollmentInternal :
        Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IExtensionResourceInternal
    {
        /// <summary>
        /// The option whether to validate the enrollment is at or under the assignment scope.
        /// </summary>
        [global::Microsoft.Azure.PowerShell.Cmdlets.Policy.PSArgumentCompleterAttribute("Default", "DoNotValidate")]
        string AssignmentScopeValidation { get; set; }
        /// <summary>The description of the policy enrollment.</summary>
        string Description { get; set; }
        /// <summary>The display name of the policy enrollment.</summary>
        string DisplayName { get; set; }
        /// <summary>The ETag for the policy enrollment.</summary>
        string ETag { get; set; }
        /// <summary>
        /// The policy enrollment metadata. Metadata is an open ended object and is typically a collection of key value pairs.
        /// </summary>
        Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IAny Metadata { get; set; }
        /// <summary>The ID of the policy assignment that is being enrolled.</summary>
        string PolicyAssignmentId { get; set; }
        /// <summary>
        /// The policy assignment instance ID associated with this enrollment.
        /// The value is set to the instance ID of the policy assignment the policyAssignmentId references when the enrollment is
        /// created or updated.
        /// The format is a GUID string.
        /// </summary>
        string PolicyAssignmentInstanceId { get; set; }
        /// <summary>
        /// The policy definition reference IDs for policy definitions in an assigned policy set definition.
        /// These IDs correspond to a subset of `policyDefinitions[*].policyDefinitionReferenceId` in the policy set definition.
        /// When specified and not empty, only the referenced policy definitions will be enrolled to. Otherwise, the entire policy
        /// set is enrolled to
        /// </summary>
        System.Collections.Generic.List<string> PolicyDefinitionReferenceId { get; set; }
        /// <summary>The properties of the policy enrollment.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IPolicyEnrollmentProperties Property { get; set; }
        /// <summary>The resource selector list to filter policies by resource properties.</summary>
        System.Collections.Generic.List<Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IResourceSelector> ResourceSelector { get; set; }

    }
}