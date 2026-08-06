// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.PowerShell.Cmdlets.Policy.Models
{
    // ── Back-compatibility marker types ─────────────────────────────────────────
    // Before the TypeSpec migration these free-form object properties were exposed as
    // distinct named interfaces. The current emitter collapses them all to the shared
    // <see cref="IAny"/>, which is a breaking change for consumers that referenced the
    // named types. These interfaces restore those public surface names. They carry no
    // members of their own — each is simply a named view over the free-form IAny bag.
    // The corresponding generated property is renamed to <Name>Raw in tspconfig.yaml so
    // a custom partial (see custom/<Model>.cs) can re-expose the original name typed as
    // the marker interface below.

    public partial interface IPolicyAssignmentPropertiesMetadata : IAny { }

    public partial interface IPolicyDefinitionPropertiesMetadata : IAny { }

    public partial interface IPolicyExemptionPropertiesMetadata : IAny { }

    public partial interface IPolicySetDefinitionPropertiesMetadata : IAny { }

    public partial interface IPolicyDefinitionPropertiesPolicyRule : IAny { }

    public partial interface IExternalEvaluationEndpointSettingsDetails : IAny { }

    /// <summary>
    /// Make the concrete free-form <see cref="Any"/> dictionary satisfy every back-compat
    /// marker interface. Because each <see cref="IAny"/> value produced by generation and
    /// deserialization is an <see cref="Any"/> instance, the re-exposed strongly named
    /// properties can return the underlying value with a simple cast — no data copying or
    /// wrapper allocation required.
    /// </summary>
    public partial class Any :
        IPolicyAssignmentPropertiesMetadata,
        IPolicyDefinitionPropertiesMetadata,
        IPolicyExemptionPropertiesMetadata,
        IPolicySetDefinitionPropertiesMetadata,
        IPolicyDefinitionPropertiesPolicyRule,
        IExternalEvaluationEndpointSettingsDetails
    {
    }
}
