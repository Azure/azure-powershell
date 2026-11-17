// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.PowerShell.Cmdlets.Policy.Models
{
    public partial class PolicyAssignment
    {
        /// <summary>
        /// The policy assignment metadata, exposed with its pre-migration named type
        /// <see cref="IPolicyAssignmentPropertiesMetadata"/> instead of the raw <see cref="IAny"/>.
        /// The generated flattened property is renamed to <c>MetadataRaw</c> (see tspconfig.yaml)
        /// so this back-compatible accessor can own the <c>Metadata</c> name. It reads/writes the
        /// same underlying <c>Property.Metadata</c> storage, so behavior is unchanged.
        /// </summary>
        public Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IPolicyAssignmentPropertiesMetadata Metadata
        {
            get => ((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IPolicyAssignmentPropertiesInternal)Property).Metadata as Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IPolicyAssignmentPropertiesMetadata;
            set => ((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IPolicyAssignmentPropertiesInternal)Property).Metadata = value;
        }

        /// <summary>
        /// The policy assignment parameter values, exposed with its pre-migration named type
        /// <see cref="IParameterValues"/> (the emitter renamed it to
        /// <see cref="IPolicyAssignmentPropertiesParameters"/>). The generated flattened property
        /// is renamed to <c>ParameterRaw</c> (see tspconfig.yaml) so this back-compatible accessor
        /// owns the <c>Parameter</c> name. It reads/writes the same underlying
        /// <c>Property.Parameter</c> storage, so behavior is unchanged.
        /// </summary>
        public Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IParameterValues Parameter
        {
            get => ((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IPolicyAssignmentPropertiesInternal)Property).Parameter as Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IParameterValues;
            set => ((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IPolicyAssignmentPropertiesInternal)Property).Parameter = value as Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IPolicyAssignmentPropertiesParameters;
        }
    }

    public partial interface IPolicyAssignment
    {
        /// <summary>
        /// The policy assignment metadata. Restored to its pre-migration named type
        /// <see cref="IPolicyAssignmentPropertiesMetadata"/> (previously collapsed to <see cref="IAny"/>).
        /// </summary>
        Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IPolicyAssignmentPropertiesMetadata Metadata { get; set; }

        /// <summary>
        /// The policy assignment parameter values. Restored to its pre-migration named type
        /// <see cref="IParameterValues"/> (renamed to <see cref="IPolicyAssignmentPropertiesParameters"/>).
        /// </summary>
        Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IParameterValues Parameter { get; set; }
    }
}
