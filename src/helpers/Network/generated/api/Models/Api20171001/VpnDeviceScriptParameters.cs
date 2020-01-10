namespace Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Extensions;

    /// <summary>Vpn device configuration script generation parameters</summary>
    public partial class VpnDeviceScriptParameters :
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IVpnDeviceScriptParameters,
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IVpnDeviceScriptParametersInternal
    {

        /// <summary>Backing field for <see cref="DeviceFamily" /> property.</summary>
        private string _deviceFamily;

        /// <summary>The device family for the vpn device.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public string DeviceFamily { get => this._deviceFamily; set => this._deviceFamily = value; }

        /// <summary>Backing field for <see cref="FirmwareVersion" /> property.</summary>
        private string _firmwareVersion;

        /// <summary>The firmware version for the vpn device.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public string FirmwareVersion { get => this._firmwareVersion; set => this._firmwareVersion = value; }

        /// <summary>Backing field for <see cref="Vendor" /> property.</summary>
        private string _vendor;

        /// <summary>The vendor for the vpn device.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public string Vendor { get => this._vendor; set => this._vendor = value; }

        /// <summary>Creates an new <see cref="VpnDeviceScriptParameters" /> instance.</summary>
        public VpnDeviceScriptParameters()
        {

        }
    }
    /// Vpn device configuration script generation parameters
    public partial interface IVpnDeviceScriptParameters :
        Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.IJsonSerializable
    {
        /// <summary>The device family for the vpn device.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The device family for the vpn device.",
        SerializedName = @"deviceFamily",
        PossibleTypes = new [] { typeof(string) })]
        string DeviceFamily { get; set; }
        /// <summary>The firmware version for the vpn device.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The firmware version for the vpn device.",
        SerializedName = @"firmwareVersion",
        PossibleTypes = new [] { typeof(string) })]
        string FirmwareVersion { get; set; }
        /// <summary>The vendor for the vpn device.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The vendor for the vpn device.",
        SerializedName = @"vendor",
        PossibleTypes = new [] { typeof(string) })]
        string Vendor { get; set; }

    }
    /// Vpn device configuration script generation parameters
    internal partial interface IVpnDeviceScriptParametersInternal

    {
        /// <summary>The device family for the vpn device.</summary>
        string DeviceFamily { get; set; }
        /// <summary>The firmware version for the vpn device.</summary>
        string FirmwareVersion { get; set; }
        /// <summary>The vendor for the vpn device.</summary>
        string Vendor { get; set; }

    }
}