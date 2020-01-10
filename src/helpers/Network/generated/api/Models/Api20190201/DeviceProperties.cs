namespace Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Extensions;

    /// <summary>List of properties of the device.</summary>
    public partial class DeviceProperties :
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IDeviceProperties,
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IDevicePropertiesInternal
    {

        /// <summary>Backing field for <see cref="DeviceModel" /> property.</summary>
        private string _deviceModel;

        /// <summary>Model of the device.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public string DeviceModel { get => this._deviceModel; set => this._deviceModel = value; }

        /// <summary>Backing field for <see cref="DeviceVendor" /> property.</summary>
        private string _deviceVendor;

        /// <summary>Name of the device Vendor.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public string DeviceVendor { get => this._deviceVendor; set => this._deviceVendor = value; }

        /// <summary>Backing field for <see cref="LinkSpeedInMbps" /> property.</summary>
        private int? _linkSpeedInMbps;

        /// <summary>Link speed.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public int? LinkSpeedInMbps { get => this._linkSpeedInMbps; set => this._linkSpeedInMbps = value; }

        /// <summary>Creates an new <see cref="DeviceProperties" /> instance.</summary>
        public DeviceProperties()
        {

        }
    }
    /// List of properties of the device.
    public partial interface IDeviceProperties :
        Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.IJsonSerializable
    {
        /// <summary>Model of the device.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Model of the device.",
        SerializedName = @"deviceModel",
        PossibleTypes = new [] { typeof(string) })]
        string DeviceModel { get; set; }
        /// <summary>Name of the device Vendor.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Name of the device Vendor.",
        SerializedName = @"deviceVendor",
        PossibleTypes = new [] { typeof(string) })]
        string DeviceVendor { get; set; }
        /// <summary>Link speed.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Link speed.",
        SerializedName = @"linkSpeedInMbps",
        PossibleTypes = new [] { typeof(int) })]
        int? LinkSpeedInMbps { get; set; }

    }
    /// List of properties of the device.
    internal partial interface IDevicePropertiesInternal

    {
        /// <summary>Model of the device.</summary>
        string DeviceModel { get; set; }
        /// <summary>Name of the device Vendor.</summary>
        string DeviceVendor { get; set; }
        /// <summary>Link speed.</summary>
        int? LinkSpeedInMbps { get; set; }

    }
}