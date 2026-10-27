// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
// Changes may cause incorrect behavior and will be lost if the code is regenerated.
namespace Microsoft.Azure.PowerShell.Cmdlets.Policy.Models
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Policy.Runtime.Extensions;

    /// <summary>The policy enrollment for Patch request.</summary>
    public partial class PolicyEnrollmentUpdate :
        Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IPolicyEnrollmentUpdate,
        Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IPolicyEnrollmentUpdateInternal
    {

        /// <summary>
        /// The option whether to validate the enrollment is at or under the assignment scope.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Policy.Origin(Microsoft.Azure.PowerShell.Cmdlets.Policy.PropertyOrigin.Inlined)]
        public string AssignmentScopeValidation { get => ((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IPolicyEnrollmentUpdatePropertiesInternal)Property).AssignmentScopeValidation; set => ((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IPolicyEnrollmentUpdatePropertiesInternal)Property).AssignmentScopeValidation = value ?? null; }

        /// <summary>Internal Acessors for Property</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IPolicyEnrollmentUpdateProperties Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IPolicyEnrollmentUpdateInternal.Property { get => (this._property = this._property ?? new Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.PolicyEnrollmentUpdateProperties()); set { {_property = value;} } }

        /// <summary>Backing field for <see cref="Property" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IPolicyEnrollmentUpdateProperties _property;

        /// <summary>The policy enrollment properties for Patch request.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Policy.Origin(Microsoft.Azure.PowerShell.Cmdlets.Policy.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IPolicyEnrollmentUpdateProperties Property { get => (this._property = this._property ?? new Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.PolicyEnrollmentUpdateProperties()); set => this._property = value; }

        /// <summary>The resource selector list to filter policies by resource properties.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Policy.Origin(Microsoft.Azure.PowerShell.Cmdlets.Policy.PropertyOrigin.Inlined)]
        public System.Collections.Generic.List<Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IResourceSelector> ResourceSelector { get => ((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IPolicyEnrollmentUpdatePropertiesInternal)Property).ResourceSelector; set => ((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IPolicyEnrollmentUpdatePropertiesInternal)Property).ResourceSelector = value ?? null /* arrayOf */; }

        /// <summary>Creates an new <see cref="PolicyEnrollmentUpdate" /> instance.</summary>
        public PolicyEnrollmentUpdate()
        {

        }
    }
    /// The policy enrollment for Patch request.
    public partial interface IPolicyEnrollmentUpdate :
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
    /// The policy enrollment for Patch request.
    internal partial interface IPolicyEnrollmentUpdateInternal

    {
        /// <summary>
        /// The option whether to validate the enrollment is at or under the assignment scope.
        /// </summary>
        [global::Microsoft.Azure.PowerShell.Cmdlets.Policy.PSArgumentCompleterAttribute("Default", "DoNotValidate")]
        string AssignmentScopeValidation { get; set; }
        /// <summary>The policy enrollment properties for Patch request.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IPolicyEnrollmentUpdateProperties Property { get; set; }
        /// <summary>The resource selector list to filter policies by resource properties.</summary>
        System.Collections.Generic.List<Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IResourceSelector> ResourceSelector { get; set; }

    }
}