namespace Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Extensions;

    /// <summary>Snapshot resource specific properties</summary>
    public partial class SnapshotProperties :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISnapshotProperties,
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISnapshotPropertiesInternal
    {

        /// <summary>Internal Acessors for Time</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISnapshotPropertiesInternal.Time { get => this._time; set { {_time = value;} } }

        /// <summary>Backing field for <see cref="Time" /> property.</summary>
        private string _time;

        /// <summary>The time the snapshot was taken.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public string Time { get => this._time; }

        /// <summary>Creates an new <see cref="SnapshotProperties" /> instance.</summary>
        public SnapshotProperties()
        {

        }
    }
    /// Snapshot resource specific properties
    public partial interface ISnapshotProperties :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.IJsonSerializable
    {
        /// <summary>The time the snapshot was taken.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"The time the snapshot was taken.",
        SerializedName = @"time",
        PossibleTypes = new [] { typeof(string) })]
        string Time { get;  }

    }
    /// Snapshot resource specific properties
    internal partial interface ISnapshotPropertiesInternal

    {
        /// <summary>The time the snapshot was taken.</summary>
        string Time { get; set; }

    }
}