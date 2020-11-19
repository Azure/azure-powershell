namespace Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Extensions;

    /// <summary>Collection of migration recovery points.</summary>
    public partial class MigrationRecoveryPointCollection :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IMigrationRecoveryPointCollection,
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IMigrationRecoveryPointCollectionInternal
    {

        /// <summary>Backing field for <see cref="NextLink" /> property.</summary>
        private string _nextLink;

        /// <summary>The value of next link.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string NextLink { get => this._nextLink; set => this._nextLink = value; }

        /// <summary>Backing field for <see cref="Value" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IMigrationRecoveryPoint[] _value;

        /// <summary>The migration recovery point details.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IMigrationRecoveryPoint[] Value { get => this._value; set => this._value = value; }

        /// <summary>Creates an new <see cref="MigrationRecoveryPointCollection" /> instance.</summary>
        public MigrationRecoveryPointCollection()
        {

        }
    }
    /// Collection of migration recovery points.
    public partial interface IMigrationRecoveryPointCollection :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.IJsonSerializable
    {
        /// <summary>The value of next link.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The value of next link.",
        SerializedName = @"nextLink",
        PossibleTypes = new [] { typeof(string) })]
        string NextLink { get; set; }
        /// <summary>The migration recovery point details.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The migration recovery point details.",
        SerializedName = @"value",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IMigrationRecoveryPoint) })]
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IMigrationRecoveryPoint[] Value { get; set; }

    }
    /// Collection of migration recovery points.
    internal partial interface IMigrationRecoveryPointCollectionInternal

    {
        /// <summary>The value of next link.</summary>
        string NextLink { get; set; }
        /// <summary>The migration recovery point details.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IMigrationRecoveryPoint[] Value { get; set; }

    }
}