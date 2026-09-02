// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
// Changes may cause incorrect behavior and will be lost if the code is regenerated.
namespace Microsoft.Azure.PowerShell.Cmdlets.Policy.Models
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Policy.Runtime.Extensions;

    /// <summary>The self-serve exemption settings for a policy assignment.</summary>
    public partial class SelfServeExemptionSettings :
        Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.ISelfServeExemptionSettings,
        Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.ISelfServeExemptionSettingsInternal
    {

        /// <summary>Backing field for <see cref="Enabled" /> property.</summary>
        private bool? _enabled;

        /// <summary>Indicates whether self-serve exemption is enabled.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Policy.Origin(Microsoft.Azure.PowerShell.Cmdlets.Policy.PropertyOrigin.Owned)]
        public bool? Enabled { get => this._enabled; set => this._enabled = value; }

        /// <summary>Backing field for <see cref="PolicyDefinitionReferenceId" /> property.</summary>
        private System.Collections.Generic.List<string> _policyDefinitionReferenceId;

        /// <summary>The policy definition reference IDs for self-serve exemption.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Policy.Origin(Microsoft.Azure.PowerShell.Cmdlets.Policy.PropertyOrigin.Owned)]
        public System.Collections.Generic.List<string> PolicyDefinitionReferenceId { get => this._policyDefinitionReferenceId; set => this._policyDefinitionReferenceId = value; }

        /// <summary>Creates an new <see cref="SelfServeExemptionSettings" /> instance.</summary>
        public SelfServeExemptionSettings()
        {

        }
    }
    /// The self-serve exemption settings for a policy assignment.
    public partial interface ISelfServeExemptionSettings :
        Microsoft.Azure.PowerShell.Cmdlets.Policy.Runtime.IJsonSerializable
    {
        /// <summary>Indicates whether self-serve exemption is enabled.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Policy.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"Indicates whether self-serve exemption is enabled.",
        SerializedName = @"enabled",
        PossibleTypes = new [] { typeof(bool) })]
        bool? Enabled { get; set; }
        /// <summary>The policy definition reference IDs for self-serve exemption.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Policy.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"The policy definition reference IDs for self-serve exemption.",
        SerializedName = @"policyDefinitionReferenceIds",
        PossibleTypes = new [] { typeof(string) })]
        System.Collections.Generic.List<string> PolicyDefinitionReferenceId { get; set; }

    }
    /// The self-serve exemption settings for a policy assignment.
    internal partial interface ISelfServeExemptionSettingsInternal

    {
        /// <summary>Indicates whether self-serve exemption is enabled.</summary>
        bool? Enabled { get; set; }
        /// <summary>The policy definition reference IDs for self-serve exemption.</summary>
        System.Collections.Generic.List<string> PolicyDefinitionReferenceId { get; set; }

    }
}