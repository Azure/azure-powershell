// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.PowerShell.Cmdlets.Policy.Models
{
    public partial class PolicyDefinition
    {
        /// <summary>
        /// The policy definition metadata, exposed with its pre-migration named type
        /// <see cref="IPolicyDefinitionPropertiesMetadata"/> instead of the raw <see cref="IAny"/>.
        /// The generated flattened property is renamed to <c>MetadataRaw</c> (see tspconfig.yaml)
        /// so this back-compatible accessor owns the <c>Metadata</c> name. It reads/writes the
        /// same underlying <c>Property.Metadata</c> storage, so behavior is unchanged.
        /// </summary>
        public Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IPolicyDefinitionPropertiesMetadata Metadata
        {
            get => ((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IPolicyDefinitionPropertiesInternal)Property).Metadata as Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IPolicyDefinitionPropertiesMetadata;
            set => ((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IPolicyDefinitionPropertiesInternal)Property).Metadata = value;
        }

        /// <summary>
        /// The policy rule, exposed with its pre-migration named type
        /// <see cref="IPolicyDefinitionPropertiesPolicyRule"/> instead of the raw <see cref="IAny"/>.
        /// </summary>
        public Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IPolicyDefinitionPropertiesPolicyRule PolicyRule
        {
            get => ((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IPolicyDefinitionPropertiesInternal)Property).PolicyRule as Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IPolicyDefinitionPropertiesPolicyRule;
            set => ((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IPolicyDefinitionPropertiesInternal)Property).PolicyRule = value;
        }

        /// <summary>
        /// The external evaluation endpoint settings detail, exposed with its pre-migration named
        /// type <see cref="IExternalEvaluationEndpointSettingsDetails"/> instead of the raw
        /// <see cref="IAny"/>.
        /// </summary>
        public Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IExternalEvaluationEndpointSettingsDetails EndpointSettingDetail
        {
            get => ((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IPolicyDefinitionPropertiesInternal)Property).EndpointSettingDetail as Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IExternalEvaluationEndpointSettingsDetails;
            set => ((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IPolicyDefinitionPropertiesInternal)Property).EndpointSettingDetail = value;
        }
    }

    public partial interface IPolicyDefinition
    {
        /// <summary>The policy definition metadata (restored named type, previously collapsed to IAny).</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IPolicyDefinitionPropertiesMetadata Metadata { get; set; }

        /// <summary>The policy rule (restored named type, previously collapsed to IAny).</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IPolicyDefinitionPropertiesPolicyRule PolicyRule { get; set; }

        /// <summary>The external evaluation endpoint settings detail (restored named type, previously collapsed to IAny).</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IExternalEvaluationEndpointSettingsDetails EndpointSettingDetail { get; set; }
    }
}
