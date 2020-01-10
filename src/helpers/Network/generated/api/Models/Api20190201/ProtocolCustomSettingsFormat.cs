namespace Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Extensions;

    /// <summary>DDoS custom policy properties.</summary>
    public partial class ProtocolCustomSettingsFormat :
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IProtocolCustomSettingsFormat,
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IProtocolCustomSettingsFormatInternal
    {

        /// <summary>Backing field for <see cref="Protocol" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Network.Support.DdosCustomPolicyProtocol? _protocol;

        /// <summary>The protocol for which the DDoS protection policy is being customized.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Network.Support.DdosCustomPolicyProtocol? Protocol { get => this._protocol; set => this._protocol = value; }

        /// <summary>Backing field for <see cref="SourceRateOverride" /> property.</summary>
        private string _sourceRateOverride;

        /// <summary>The customized DDoS protection source rate.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public string SourceRateOverride { get => this._sourceRateOverride; set => this._sourceRateOverride = value; }

        /// <summary>Backing field for <see cref="TriggerRateOverride" /> property.</summary>
        private string _triggerRateOverride;

        /// <summary>The customized DDoS protection trigger rate.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public string TriggerRateOverride { get => this._triggerRateOverride; set => this._triggerRateOverride = value; }

        /// <summary>Backing field for <see cref="TriggerSensitivityOverride" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Network.Support.DdosCustomPolicyTriggerSensitivityOverride? _triggerSensitivityOverride;

        /// <summary>
        /// The customized DDoS protection trigger rate sensitivity degrees. High: Trigger rate set with most sensitivity w.r.t. normal
        /// traffic. Default: Trigger rate set with moderate sensitivity w.r.t. normal traffic. Low: Trigger rate set with less sensitivity
        /// w.r.t. normal traffic. Relaxed: Trigger rate set with least sensitivity w.r.t. normal traffic.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Network.Support.DdosCustomPolicyTriggerSensitivityOverride? TriggerSensitivityOverride { get => this._triggerSensitivityOverride; set => this._triggerSensitivityOverride = value; }

        /// <summary>Creates an new <see cref="ProtocolCustomSettingsFormat" /> instance.</summary>
        public ProtocolCustomSettingsFormat()
        {

        }
    }
    /// DDoS custom policy properties.
    public partial interface IProtocolCustomSettingsFormat :
        Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.IJsonSerializable
    {
        /// <summary>The protocol for which the DDoS protection policy is being customized.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The protocol for which the DDoS protection policy is being customized.",
        SerializedName = @"protocol",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Network.Support.DdosCustomPolicyProtocol) })]
        Microsoft.Azure.PowerShell.Cmdlets.Network.Support.DdosCustomPolicyProtocol? Protocol { get; set; }
        /// <summary>The customized DDoS protection source rate.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The customized DDoS protection source rate.",
        SerializedName = @"sourceRateOverride",
        PossibleTypes = new [] { typeof(string) })]
        string SourceRateOverride { get; set; }
        /// <summary>The customized DDoS protection trigger rate.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The customized DDoS protection trigger rate.",
        SerializedName = @"triggerRateOverride",
        PossibleTypes = new [] { typeof(string) })]
        string TriggerRateOverride { get; set; }
        /// <summary>
        /// The customized DDoS protection trigger rate sensitivity degrees. High: Trigger rate set with most sensitivity w.r.t. normal
        /// traffic. Default: Trigger rate set with moderate sensitivity w.r.t. normal traffic. Low: Trigger rate set with less sensitivity
        /// w.r.t. normal traffic. Relaxed: Trigger rate set with least sensitivity w.r.t. normal traffic.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The customized DDoS protection trigger rate sensitivity degrees. High: Trigger rate set with most sensitivity w.r.t. normal traffic. Default: Trigger rate set with moderate sensitivity w.r.t. normal traffic. Low: Trigger rate set with less sensitivity w.r.t. normal traffic. Relaxed: Trigger rate set with least sensitivity w.r.t. normal traffic.",
        SerializedName = @"triggerSensitivityOverride",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Network.Support.DdosCustomPolicyTriggerSensitivityOverride) })]
        Microsoft.Azure.PowerShell.Cmdlets.Network.Support.DdosCustomPolicyTriggerSensitivityOverride? TriggerSensitivityOverride { get; set; }

    }
    /// DDoS custom policy properties.
    internal partial interface IProtocolCustomSettingsFormatInternal

    {
        /// <summary>The protocol for which the DDoS protection policy is being customized.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Support.DdosCustomPolicyProtocol? Protocol { get; set; }
        /// <summary>The customized DDoS protection source rate.</summary>
        string SourceRateOverride { get; set; }
        /// <summary>The customized DDoS protection trigger rate.</summary>
        string TriggerRateOverride { get; set; }
        /// <summary>
        /// The customized DDoS protection trigger rate sensitivity degrees. High: Trigger rate set with most sensitivity w.r.t. normal
        /// traffic. Default: Trigger rate set with moderate sensitivity w.r.t. normal traffic. Low: Trigger rate set with less sensitivity
        /// w.r.t. normal traffic. Relaxed: Trigger rate set with least sensitivity w.r.t. normal traffic.
        /// </summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Support.DdosCustomPolicyTriggerSensitivityOverride? TriggerSensitivityOverride { get; set; }

    }
}