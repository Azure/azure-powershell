namespace Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Extensions;

    /// <summary>Initial replication details.</summary>
    public partial class InitialReplicationDetails :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IInitialReplicationDetails,
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IInitialReplicationDetailsInternal
    {

        /// <summary>Backing field for <see cref="InitialReplicationProgressPercentage" /> property.</summary>
        private string _initialReplicationProgressPercentage;

        /// <summary>The initial replication progress percentage.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string InitialReplicationProgressPercentage { get => this._initialReplicationProgressPercentage; set => this._initialReplicationProgressPercentage = value; }

        /// <summary>Backing field for <see cref="InitialReplicationType" /> property.</summary>
        private string _initialReplicationType;

        /// <summary>Initial replication type.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string InitialReplicationType { get => this._initialReplicationType; set => this._initialReplicationType = value; }

        /// <summary>Creates an new <see cref="InitialReplicationDetails" /> instance.</summary>
        public InitialReplicationDetails()
        {

        }
    }
    /// Initial replication details.
    public partial interface IInitialReplicationDetails :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.IJsonSerializable
    {
        /// <summary>The initial replication progress percentage.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The initial replication progress percentage.",
        SerializedName = @"initialReplicationProgressPercentage",
        PossibleTypes = new [] { typeof(string) })]
        string InitialReplicationProgressPercentage { get; set; }
        /// <summary>Initial replication type.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Initial replication type.",
        SerializedName = @"initialReplicationType",
        PossibleTypes = new [] { typeof(string) })]
        string InitialReplicationType { get; set; }

    }
    /// Initial replication details.
    internal partial interface IInitialReplicationDetailsInternal

    {
        /// <summary>The initial replication progress percentage.</summary>
        string InitialReplicationProgressPercentage { get; set; }
        /// <summary>Initial replication type.</summary>
        string InitialReplicationType { get; set; }

    }
}