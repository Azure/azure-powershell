// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.PowerShell.Cmdlets.Policy.Models
{
    public partial class PolicySetDefinition
    {
        /// <summary>
        /// The policy set definition metadata, exposed with its pre-migration named type
        /// <see cref="IPolicySetDefinitionPropertiesMetadata"/> instead of the raw <see cref="IAny"/>.
        /// The generated flattened property is renamed to <c>MetadataRaw</c> (see tspconfig.yaml)
        /// so this back-compatible accessor owns the <c>Metadata</c> name. It reads/writes the
        /// same underlying <c>Property.Metadata</c> storage, so behavior is unchanged.
        /// </summary>
        public Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IPolicySetDefinitionPropertiesMetadata Metadata
        {
            get => ((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IPolicySetDefinitionPropertiesInternal)Property).Metadata as Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IPolicySetDefinitionPropertiesMetadata;
            set => ((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IPolicySetDefinitionPropertiesInternal)Property).Metadata = value;
        }

        /// <summary>
        /// The policy set definition parameter definitions, exposed with its pre-migration named type
        /// <see cref="IParameterDefinitions"/> (the emitter renamed it to
        /// <see cref="IPolicySetDefinitionPropertiesParameters"/>). The generated flattened property is
        /// renamed to <c>ParameterRaw</c> (see tspconfig.yaml) so this back-compatible accessor owns
        /// the <c>Parameter</c> name, reading/writing the same <c>Property.Parameter</c> storage.
        /// </summary>
        public Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IParameterDefinitions Parameter
        {
            get => ((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IPolicySetDefinitionPropertiesInternal)Property).Parameter as Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IParameterDefinitions;
            set => ((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IPolicySetDefinitionPropertiesInternal)Property).Parameter = value as Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IPolicySetDefinitionPropertiesParameters;
        }
    }

    public partial interface IPolicySetDefinition
    {
        /// <summary>The policy set definition metadata (restored named type, previously collapsed to IAny).</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IPolicySetDefinitionPropertiesMetadata Metadata { get; set; }

        /// <summary>
        /// The policy set definition parameter definitions. Restored to its pre-migration named type
        /// <see cref="IParameterDefinitions"/> (renamed to <see cref="IPolicySetDefinitionPropertiesParameters"/>).
        /// </summary>
        Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IParameterDefinitions Parameter { get; set; }
    }
}
