namespace Microsoft.Azure.PowerShell.Cmdlets.WindowsIotServices.Models.Api20190601
{
    using static Microsoft.Azure.PowerShell.Cmdlets.WindowsIotServices.Runtime.Extensions;

    /// <summary>
    /// The properties indicating whether a given Windows IoT Device Service name is available.
    /// </summary>
    public partial class DeviceServiceNameAvailabilityInfo :
        Microsoft.Azure.PowerShell.Cmdlets.WindowsIotServices.Models.Api20190601.IDeviceServiceNameAvailabilityInfo,
        Microsoft.Azure.PowerShell.Cmdlets.WindowsIotServices.Models.Api20190601.IDeviceServiceNameAvailabilityInfoInternal
    {

        /// <summary>Backing field for <see cref="Message" /> property.</summary>
        private string _message;

        /// <summary>The detailed reason message.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.WindowsIotServices.Origin(Microsoft.Azure.PowerShell.Cmdlets.WindowsIotServices.PropertyOrigin.Owned)]
        public string Message { get => this._message; set => this._message = value; }

        /// <summary>Internal Acessors for NameAvailable</summary>
        bool? Microsoft.Azure.PowerShell.Cmdlets.WindowsIotServices.Models.Api20190601.IDeviceServiceNameAvailabilityInfoInternal.NameAvailable { get => this._nameAvailable; set { {_nameAvailable = value;} } }

        /// <summary>Internal Acessors for Reason</summary>
        Microsoft.Azure.PowerShell.Cmdlets.WindowsIotServices.Support.ServiceNameUnavailabilityReason? Microsoft.Azure.PowerShell.Cmdlets.WindowsIotServices.Models.Api20190601.IDeviceServiceNameAvailabilityInfoInternal.Reason { get => this._reason; set { {_reason = value;} } }

        /// <summary>Backing field for <see cref="NameAvailable" /> property.</summary>
        private bool? _nameAvailable;

        /// <summary>The value which indicates whether the provided name is available.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.WindowsIotServices.Origin(Microsoft.Azure.PowerShell.Cmdlets.WindowsIotServices.PropertyOrigin.Owned)]
        public bool? NameAvailable { get => this._nameAvailable; }

        /// <summary>Backing field for <see cref="Reason" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.WindowsIotServices.Support.ServiceNameUnavailabilityReason? _reason;

        /// <summary>The reason for unavailability.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.WindowsIotServices.Origin(Microsoft.Azure.PowerShell.Cmdlets.WindowsIotServices.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.WindowsIotServices.Support.ServiceNameUnavailabilityReason? Reason { get => this._reason; }

        /// <summary>Creates an new <see cref="DeviceServiceNameAvailabilityInfo" /> instance.</summary>
        public DeviceServiceNameAvailabilityInfo()
        {

        }
    }
    /// The properties indicating whether a given Windows IoT Device Service name is available.
    public partial interface IDeviceServiceNameAvailabilityInfo :
        Microsoft.Azure.PowerShell.Cmdlets.WindowsIotServices.Runtime.IJsonSerializable
    {
        /// <summary>The detailed reason message.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.WindowsIotServices.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The detailed reason message.",
        SerializedName = @"message",
        PossibleTypes = new [] { typeof(string) })]
        string Message { get; set; }
        /// <summary>The value which indicates whether the provided name is available.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.WindowsIotServices.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"The value which indicates whether the provided name is available.",
        SerializedName = @"nameAvailable",
        PossibleTypes = new [] { typeof(bool) })]
        bool? NameAvailable { get;  }
        /// <summary>The reason for unavailability.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.WindowsIotServices.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"The reason for unavailability.",
        SerializedName = @"reason",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.WindowsIotServices.Support.ServiceNameUnavailabilityReason) })]
        Microsoft.Azure.PowerShell.Cmdlets.WindowsIotServices.Support.ServiceNameUnavailabilityReason? Reason { get;  }

    }
    /// The properties indicating whether a given Windows IoT Device Service name is available.
    internal partial interface IDeviceServiceNameAvailabilityInfoInternal

    {
        /// <summary>The detailed reason message.</summary>
        string Message { get; set; }
        /// <summary>The value which indicates whether the provided name is available.</summary>
        bool? NameAvailable { get; set; }
        /// <summary>The reason for unavailability.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.WindowsIotServices.Support.ServiceNameUnavailabilityReason? Reason { get; set; }

    }
}