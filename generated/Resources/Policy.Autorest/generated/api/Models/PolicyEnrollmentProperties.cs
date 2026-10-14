// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
// Changes may cause incorrect behavior and will be lost if the code is regenerated.
namespace Microsoft.Azure.PowerShell.Cmdlets.Policy.Models
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Policy.Runtime.Extensions;

    /// <summary>The policy enrollment properties.</summary>
    public partial class PolicyEnrollmentProperties :
        Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IPolicyEnrollmentProperties,
        Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IPolicyEnrollmentPropertiesInternal
    {

        /// <summary>Backing field for <see cref="AssignmentScopeValidation" /> property.</summary>
        private string _assignmentScopeValidation;

        /// <summary>
        /// The option whether to validate the enrollment is at or under the assignment scope.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Policy.Origin(Microsoft.Azure.PowerShell.Cmdlets.Policy.PropertyOrigin.Owned)]
        public string AssignmentScopeValidation { get => this._assignmentScopeValidation; set => this._assignmentScopeValidation = value; }

        /// <summary>Backing field for <see cref="Description" /> property.</summary>
        private string _description;

        /// <summary>The description of the policy enrollment.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Policy.Origin(Microsoft.Azure.PowerShell.Cmdlets.Policy.PropertyOrigin.Owned)]
        public string Description { get => this._description; set => this._description = value; }

        /// <summary>Backing field for <see cref="DisplayName" /> property.</summary>
        private string _displayName;

        /// <summary>The display name of the policy enrollment.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Policy.Origin(Microsoft.Azure.PowerShell.Cmdlets.Policy.PropertyOrigin.Owned)]
        public string DisplayName { get => this._displayName; set => this._displayName = value; }

        /// <summary>Backing field for <see cref="Metadata" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IAny _metadata;

        /// <summary>
        /// The policy enrollment metadata. Metadata is an open ended object and is typically a collection of key value pairs.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Policy.Origin(Microsoft.Azure.PowerShell.Cmdlets.Policy.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IAny Metadata { get => (this._metadata = this._metadata ?? new Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.Any()); set => this._metadata = value; }

        /// <summary>Internal Acessors for PolicyAssignmentInstanceId</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IPolicyEnrollmentPropertiesInternal.PolicyAssignmentInstanceId { get => this._policyAssignmentInstanceId; set { {_policyAssignmentInstanceId = value;} } }

        /// <summary>Backing field for <see cref="PolicyAssignmentId" /> property.</summary>
        private string _policyAssignmentId;

        /// <summary>The ID of the policy assignment that is being enrolled.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Policy.Origin(Microsoft.Azure.PowerShell.Cmdlets.Policy.PropertyOrigin.Owned)]
        public string PolicyAssignmentId { get => this._policyAssignmentId; set => this._policyAssignmentId = value; }

        /// <summary>Backing field for <see cref="PolicyAssignmentInstanceId" /> property.</summary>
        private string _policyAssignmentInstanceId;

        /// <summary>
        /// The policy assignment instance ID associated with this enrollment.
        /// The value is set to the instance ID of the policy assignment the policyAssignmentId references when the enrollment is
        /// created or updated.
        /// The format is a GUID string.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Policy.Origin(Microsoft.Azure.PowerShell.Cmdlets.Policy.PropertyOrigin.Owned)]
        public string PolicyAssignmentInstanceId { get => this._policyAssignmentInstanceId; }

        /// <summary>Backing field for <see cref="PolicyDefinitionReferenceId" /> property.</summary>
        private System.Collections.Generic.List<string> _policyDefinitionReferenceId;

        /// <summary>
        /// The policy definition reference IDs for policy definitions in an assigned policy set definition.
        /// These IDs correspond to a subset of `policyDefinitions[*].policyDefinitionReferenceId` in the policy set definition.
        /// When specified and not empty, only the referenced policy definitions will be enrolled to. Otherwise, the entire policy
        /// set is enrolled to
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Policy.Origin(Microsoft.Azure.PowerShell.Cmdlets.Policy.PropertyOrigin.Owned)]
        public System.Collections.Generic.List<string> PolicyDefinitionReferenceId { get => this._policyDefinitionReferenceId; set => this._policyDefinitionReferenceId = value; }

        /// <summary>Backing field for <see cref="ResourceSelector" /> property.</summary>
        private System.Collections.Generic.List<Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IResourceSelector> _resourceSelector;

        /// <summary>The resource selector list to filter policies by resource properties.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Policy.Origin(Microsoft.Azure.PowerShell.Cmdlets.Policy.PropertyOrigin.Owned)]
        public System.Collections.Generic.List<Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IResourceSelector> ResourceSelector { get => this._resourceSelector; set => this._resourceSelector = value; }

        /// <summary>Creates an new <see cref="PolicyEnrollmentProperties" /> instance.</summary>
        public PolicyEnrollmentProperties()
        {

        }
    }
    /// The policy enrollment properties.
    public partial interface IPolicyEnrollmentProperties :
        Microsoft.Azure.PowerShell.Cmdlets.Policy.Runtime.IJsonSerializable
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
        Required = true,
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
    /// The policy enrollment properties.
    internal partial interface IPolicyEnrollmentPropertiesInternal

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
        /// <summary>The resource selector list to filter policies by resource properties.</summary>
        System.Collections.Generic.List<Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IResourceSelector> ResourceSelector { get; set; }

    }
}