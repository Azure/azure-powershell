namespace Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Extensions;

    /// <summary>Availability of the metric.</summary>
    public partial class Availability :
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IAvailability,
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IAvailabilityInternal
    {

        /// <summary>Backing field for <see cref="BlobDuration" /> property.</summary>
        private string _blobDuration;

        /// <summary>Duration of the availability blob.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public string BlobDuration { get => this._blobDuration; set => this._blobDuration = value; }

        /// <summary>Backing field for <see cref="Retention" /> property.</summary>
        private string _retention;

        /// <summary>The retention of the availability.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public string Retention { get => this._retention; set => this._retention = value; }

        /// <summary>Backing field for <see cref="TimeGrain" /> property.</summary>
        private string _timeGrain;

        /// <summary>The time grain of the availability.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public string TimeGrain { get => this._timeGrain; set => this._timeGrain = value; }

        /// <summary>Creates an new <see cref="Availability" /> instance.</summary>
        public Availability()
        {

        }
    }
    /// Availability of the metric.
    public partial interface IAvailability :
        Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.IJsonSerializable
    {
        /// <summary>Duration of the availability blob.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Duration of the availability blob.",
        SerializedName = @"blobDuration",
        PossibleTypes = new [] { typeof(string) })]
        string BlobDuration { get; set; }
        /// <summary>The retention of the availability.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The retention of the availability.",
        SerializedName = @"retention",
        PossibleTypes = new [] { typeof(string) })]
        string Retention { get; set; }
        /// <summary>The time grain of the availability.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The time grain of the availability.",
        SerializedName = @"timeGrain",
        PossibleTypes = new [] { typeof(string) })]
        string TimeGrain { get; set; }

    }
    /// Availability of the metric.
    internal partial interface IAvailabilityInternal

    {
        /// <summary>Duration of the availability blob.</summary>
        string BlobDuration { get; set; }
        /// <summary>The retention of the availability.</summary>
        string Retention { get; set; }
        /// <summary>The time grain of the availability.</summary>
        string TimeGrain { get; set; }

    }
}