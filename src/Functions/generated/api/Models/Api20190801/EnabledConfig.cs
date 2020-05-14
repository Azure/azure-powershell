namespace Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Extensions;

    /// <summary>Enabled configuration.</summary>
    public partial class EnabledConfig :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IEnabledConfig,
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IEnabledConfigInternal
    {

        /// <summary>Backing field for <see cref="Enabled" /> property.</summary>
        private bool? _enabled;

        /// <summary>
        /// True if configuration is enabled, false if it is disabled and null if configuration is not set.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public bool? Enabled { get => this._enabled; set => this._enabled = value; }

        /// <summary>Creates an new <see cref="EnabledConfig" /> instance.</summary>
        public EnabledConfig()
        {

        }
    }
    /// Enabled configuration.
    public partial interface IEnabledConfig :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.IJsonSerializable
    {
        /// <summary>
        /// True if configuration is enabled, false if it is disabled and null if configuration is not set.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"True if configuration is enabled, false if it is disabled and null if configuration is not set.",
        SerializedName = @"enabled",
        PossibleTypes = new [] { typeof(bool) })]
        bool? Enabled { get; set; }

    }
    /// Enabled configuration.
    internal partial interface IEnabledConfigInternal

    {
        /// <summary>
        /// True if configuration is enabled, false if it is disabled and null if configuration is not set.
        /// </summary>
        bool? Enabled { get; set; }

    }
}