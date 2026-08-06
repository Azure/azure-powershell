// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.PowerShell.Cmdlets.Policy.Models
{
    public partial class PolicyExemption
    {
        /// <summary>
        /// The policy exemption metadata, exposed with its pre-migration named type
        /// <see cref="IPolicyExemptionPropertiesMetadata"/> instead of the raw <see cref="IAny"/>.
        /// The generated flattened property is renamed to <c>MetadataRaw</c> (see tspconfig.yaml)
        /// so this back-compatible accessor owns the <c>Metadata</c> name. It reads/writes the
        /// same underlying <c>Property.Metadata</c> storage, so behavior is unchanged.
        /// </summary>
        public Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IPolicyExemptionPropertiesMetadata Metadata
        {
            get => ((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IPolicyExemptionPropertiesInternal)Property).Metadata as Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IPolicyExemptionPropertiesMetadata;
            set => ((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IPolicyExemptionPropertiesInternal)Property).Metadata = value;
        }
    }

    public partial interface IPolicyExemption
    {
        /// <summary>The policy exemption metadata (restored named type, previously collapsed to IAny).</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IPolicyExemptionPropertiesMetadata Metadata { get; set; }
    }
}
