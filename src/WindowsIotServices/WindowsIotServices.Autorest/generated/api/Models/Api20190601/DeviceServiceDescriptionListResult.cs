namespace Microsoft.Azure.PowerShell.Cmdlets.WindowsIotServices.Models.Api20190601
{
    using static Microsoft.Azure.PowerShell.Cmdlets.WindowsIotServices.Runtime.Extensions;

    /// <summary>The JSON-serialized array of DeviceService objects with a next link.</summary>
    public partial class DeviceServiceDescriptionListResult :
        Microsoft.Azure.PowerShell.Cmdlets.WindowsIotServices.Models.Api20190601.IDeviceServiceDescriptionListResult,
        Microsoft.Azure.PowerShell.Cmdlets.WindowsIotServices.Models.Api20190601.IDeviceServiceDescriptionListResultInternal
    {

        /// <summary>Internal Acessors for NextLink</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.WindowsIotServices.Models.Api20190601.IDeviceServiceDescriptionListResultInternal.NextLink { get => this._nextLink; set { {_nextLink = value;} } }

        /// <summary>Backing field for <see cref="NextLink" /> property.</summary>
        private string _nextLink;

        /// <summary>The next link.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.WindowsIotServices.Origin(Microsoft.Azure.PowerShell.Cmdlets.WindowsIotServices.PropertyOrigin.Owned)]
        public string NextLink { get => this._nextLink; }

        /// <summary>Backing field for <see cref="Value" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.WindowsIotServices.Models.Api20190601.IDeviceService[] _value;

        /// <summary>The array of DeviceService objects.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.WindowsIotServices.Origin(Microsoft.Azure.PowerShell.Cmdlets.WindowsIotServices.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.WindowsIotServices.Models.Api20190601.IDeviceService[] Value { get => this._value; set => this._value = value; }

        /// <summary>Creates an new <see cref="DeviceServiceDescriptionListResult" /> instance.</summary>
        public DeviceServiceDescriptionListResult()
        {

        }
    }
    /// The JSON-serialized array of DeviceService objects with a next link.
    public partial interface IDeviceServiceDescriptionListResult :
        Microsoft.Azure.PowerShell.Cmdlets.WindowsIotServices.Runtime.IJsonSerializable
    {
        /// <summary>The next link.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.WindowsIotServices.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"The next link.",
        SerializedName = @"nextLink",
        PossibleTypes = new [] { typeof(string) })]
        string NextLink { get;  }
        /// <summary>The array of DeviceService objects.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.WindowsIotServices.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The array of DeviceService objects.",
        SerializedName = @"value",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.WindowsIotServices.Models.Api20190601.IDeviceService) })]
        Microsoft.Azure.PowerShell.Cmdlets.WindowsIotServices.Models.Api20190601.IDeviceService[] Value { get; set; }

    }
    /// The JSON-serialized array of DeviceService objects with a next link.
    internal partial interface IDeviceServiceDescriptionListResultInternal

    {
        /// <summary>The next link.</summary>
        string NextLink { get; set; }
        /// <summary>The array of DeviceService objects.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.WindowsIotServices.Models.Api20190601.IDeviceService[] Value { get; set; }

    }
}