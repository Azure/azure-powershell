// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
// Changes may cause incorrect behavior and will be lost if the code is regenerated.
namespace Microsoft.Azure.PowerShell.Cmdlets.Policy.Models
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Policy.Runtime.Extensions;

    /// <summary>The policy assignment properties for Patch request.</summary>
    public partial class PolicyAssignmentUpdateProperties :
        Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IPolicyAssignmentUpdateProperties,
        Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IPolicyAssignmentUpdatePropertiesInternal
    {

        /// <summary>Internal Acessors for SelfServeExemptionSetting</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.ISelfServeExemptionSettings Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IPolicyAssignmentUpdatePropertiesInternal.SelfServeExemptionSetting { get => (this._selfServeExemptionSetting = this._selfServeExemptionSetting ?? new Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.SelfServeExemptionSettings()); set { {_selfServeExemptionSetting = value;} } }

        /// <summary>Backing field for <see cref="Override" /> property.</summary>
        private System.Collections.Generic.List<Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IOverride> _override;

        /// <summary>The policy property value override.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Policy.Origin(Microsoft.Azure.PowerShell.Cmdlets.Policy.PropertyOrigin.Owned)]
        public System.Collections.Generic.List<Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IOverride> Override { get => this._override; set => this._override = value; }

        /// <summary>Backing field for <see cref="ResourceSelector" /> property.</summary>
        private System.Collections.Generic.List<Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IResourceSelector> _resourceSelector;

        /// <summary>The resource selector list to filter policies by resource properties.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Policy.Origin(Microsoft.Azure.PowerShell.Cmdlets.Policy.PropertyOrigin.Owned)]
        public System.Collections.Generic.List<Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IResourceSelector> ResourceSelector { get => this._resourceSelector; set => this._resourceSelector = value; }

        /// <summary>Backing field for <see cref="SelfServeExemptionSetting" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.ISelfServeExemptionSettings _selfServeExemptionSetting;

        /// <summary>The self-serve exemption settings for the policy assignment.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Policy.Origin(Microsoft.Azure.PowerShell.Cmdlets.Policy.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.ISelfServeExemptionSettings SelfServeExemptionSetting { get => (this._selfServeExemptionSetting = this._selfServeExemptionSetting ?? new Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.SelfServeExemptionSettings()); set => this._selfServeExemptionSetting = value; }

        /// <summary>Indicates whether self-serve exemption is enabled.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Policy.Origin(Microsoft.Azure.PowerShell.Cmdlets.Policy.PropertyOrigin.Inlined)]
        public bool? SelfServeExemptionSettingEnabled { get => ((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.ISelfServeExemptionSettingsInternal)SelfServeExemptionSetting).Enabled; set => ((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.ISelfServeExemptionSettingsInternal)SelfServeExemptionSetting).Enabled = value ?? default(bool); }

        /// <summary>The policy definition reference IDs for self-serve exemption.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Policy.Origin(Microsoft.Azure.PowerShell.Cmdlets.Policy.PropertyOrigin.Inlined)]
        public System.Collections.Generic.List<string> SelfServeExemptionSettingPolicyDefinitionReferenceId { get => ((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.ISelfServeExemptionSettingsInternal)SelfServeExemptionSetting).PolicyDefinitionReferenceId; set => ((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.ISelfServeExemptionSettingsInternal)SelfServeExemptionSetting).PolicyDefinitionReferenceId = value ?? null /* arrayOf */; }

        /// <summary>Creates an new <see cref="PolicyAssignmentUpdateProperties" /> instance.</summary>
        public PolicyAssignmentUpdateProperties()
        {

        }
    }
    /// The policy assignment properties for Patch request.
    public partial interface IPolicyAssignmentUpdateProperties :
        Microsoft.Azure.PowerShell.Cmdlets.Policy.Runtime.IJsonSerializable
    {
        /// <summary>The policy property value override.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Policy.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"The policy property value override.",
        SerializedName = @"overrides",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IOverride) })]
        System.Collections.Generic.List<Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IOverride> Override { get; set; }
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
        bool? SelfServeExemptionSettingEnabled { get; set; }
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
        System.Collections.Generic.List<string> SelfServeExemptionSettingPolicyDefinitionReferenceId { get; set; }

    }
    /// The policy assignment properties for Patch request.
    internal partial interface IPolicyAssignmentUpdatePropertiesInternal

    {
        /// <summary>The policy property value override.</summary>
        System.Collections.Generic.List<Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IOverride> Override { get; set; }
        /// <summary>The resource selector list to filter policies by resource properties.</summary>
        System.Collections.Generic.List<Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IResourceSelector> ResourceSelector { get; set; }
        /// <summary>The self-serve exemption settings for the policy assignment.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.ISelfServeExemptionSettings SelfServeExemptionSetting { get; set; }
        /// <summary>Indicates whether self-serve exemption is enabled.</summary>
        bool? SelfServeExemptionSettingEnabled { get; set; }
        /// <summary>The policy definition reference IDs for self-serve exemption.</summary>
        System.Collections.Generic.List<string> SelfServeExemptionSettingPolicyDefinitionReferenceId { get; set; }

    }
}