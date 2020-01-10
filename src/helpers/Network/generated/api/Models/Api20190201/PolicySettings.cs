namespace Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Extensions;

    /// <summary>Defines contents of a web application firewall global configuration</summary>
    public partial class PolicySettings :
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IPolicySettings,
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IPolicySettingsInternal
    {

        /// <summary>Backing field for <see cref="EnabledState" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Network.Support.WebApplicationFirewallEnabledState? _enabledState;

        /// <summary>Describes if the policy is in enabled state or disabled state</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Network.Support.WebApplicationFirewallEnabledState? EnabledState { get => this._enabledState; set => this._enabledState = value; }

        /// <summary>Backing field for <see cref="Mode" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Network.Support.WebApplicationFirewallMode? _mode;

        /// <summary>Describes if it is in detection mode or prevention mode at policy level</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Network.Support.WebApplicationFirewallMode? Mode { get => this._mode; set => this._mode = value; }

        /// <summary>Creates an new <see cref="PolicySettings" /> instance.</summary>
        public PolicySettings()
        {

        }
    }
    /// Defines contents of a web application firewall global configuration
    public partial interface IPolicySettings :
        Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.IJsonSerializable
    {
        /// <summary>Describes if the policy is in enabled state or disabled state</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Describes if the policy is in enabled state or disabled state",
        SerializedName = @"enabledState",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Network.Support.WebApplicationFirewallEnabledState) })]
        Microsoft.Azure.PowerShell.Cmdlets.Network.Support.WebApplicationFirewallEnabledState? EnabledState { get; set; }
        /// <summary>Describes if it is in detection mode or prevention mode at policy level</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Describes if it is in detection mode  or prevention mode at policy level",
        SerializedName = @"mode",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Network.Support.WebApplicationFirewallMode) })]
        Microsoft.Azure.PowerShell.Cmdlets.Network.Support.WebApplicationFirewallMode? Mode { get; set; }

    }
    /// Defines contents of a web application firewall global configuration
    internal partial interface IPolicySettingsInternal

    {
        /// <summary>Describes if the policy is in enabled state or disabled state</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Support.WebApplicationFirewallEnabledState? EnabledState { get; set; }
        /// <summary>Describes if it is in detection mode or prevention mode at policy level</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Support.WebApplicationFirewallMode? Mode { get; set; }

    }
}