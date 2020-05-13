namespace Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Extensions;

    /// <summary>SiteConfigurationSnapshotInfo resource specific properties</summary>
    public partial class SiteConfigurationSnapshotInfoProperties :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteConfigurationSnapshotInfoProperties,
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteConfigurationSnapshotInfoPropertiesInternal
    {

        /// <summary>Internal Acessors for SnapshotId</summary>
        int? Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteConfigurationSnapshotInfoPropertiesInternal.SnapshotId { get => this._snapshotId; set { {_snapshotId = value;} } }

        /// <summary>Internal Acessors for Time</summary>
        global::System.DateTime? Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteConfigurationSnapshotInfoPropertiesInternal.Time { get => this._time; set { {_time = value;} } }

        /// <summary>Backing field for <see cref="SnapshotId" /> property.</summary>
        private int? _snapshotId;

        /// <summary>The id of the snapshot</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public int? SnapshotId { get => this._snapshotId; }

        /// <summary>Backing field for <see cref="Time" /> property.</summary>
        private global::System.DateTime? _time;

        /// <summary>The time the snapshot was taken.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public global::System.DateTime? Time { get => this._time; }

        /// <summary>Creates an new <see cref="SiteConfigurationSnapshotInfoProperties" /> instance.</summary>
        public SiteConfigurationSnapshotInfoProperties()
        {

        }
    }
    /// SiteConfigurationSnapshotInfo resource specific properties
    public partial interface ISiteConfigurationSnapshotInfoProperties :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.IJsonSerializable
    {
        /// <summary>The id of the snapshot</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"The id of the snapshot",
        SerializedName = @"snapshotId",
        PossibleTypes = new [] { typeof(int) })]
        int? SnapshotId { get;  }
        /// <summary>The time the snapshot was taken.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"The time the snapshot was taken.",
        SerializedName = @"time",
        PossibleTypes = new [] { typeof(global::System.DateTime) })]
        global::System.DateTime? Time { get;  }

    }
    /// SiteConfigurationSnapshotInfo resource specific properties
    internal partial interface ISiteConfigurationSnapshotInfoPropertiesInternal

    {
        /// <summary>The id of the snapshot</summary>
        int? SnapshotId { get; set; }
        /// <summary>The time the snapshot was taken.</summary>
        global::System.DateTime? Time { get; set; }

    }
}