namespace Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Extensions;

    /// <summary>The properties of the Failover Process Server request.</summary>
    public partial class FailoverProcessServerRequestProperties :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IFailoverProcessServerRequestProperties,
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IFailoverProcessServerRequestPropertiesInternal
    {

        /// <summary>Backing field for <see cref="ContainerName" /> property.</summary>
        private string _containerName;

        /// <summary>The container identifier.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string ContainerName { get => this._containerName; set => this._containerName = value; }

        /// <summary>Backing field for <see cref="SourceProcessServerId" /> property.</summary>
        private string _sourceProcessServerId;

        /// <summary>The source process server.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string SourceProcessServerId { get => this._sourceProcessServerId; set => this._sourceProcessServerId = value; }

        /// <summary>Backing field for <see cref="TargetProcessServerId" /> property.</summary>
        private string _targetProcessServerId;

        /// <summary>The new process server.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string TargetProcessServerId { get => this._targetProcessServerId; set => this._targetProcessServerId = value; }

        /// <summary>Backing field for <see cref="UpdateType" /> property.</summary>
        private string _updateType;

        /// <summary>A value for failover type. It can be systemlevel/serverlevel</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string UpdateType { get => this._updateType; set => this._updateType = value; }

        /// <summary>Backing field for <see cref="VmsToMigrate" /> property.</summary>
        private string[] _vmsToMigrate;

        /// <summary>The VMS to migrate.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string[] VmsToMigrate { get => this._vmsToMigrate; set => this._vmsToMigrate = value; }

        /// <summary>Creates an new <see cref="FailoverProcessServerRequestProperties" /> instance.</summary>
        public FailoverProcessServerRequestProperties()
        {

        }
    }
    /// The properties of the Failover Process Server request.
    public partial interface IFailoverProcessServerRequestProperties :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.IJsonSerializable
    {
        /// <summary>The container identifier.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The container identifier.",
        SerializedName = @"containerName",
        PossibleTypes = new [] { typeof(string) })]
        string ContainerName { get; set; }
        /// <summary>The source process server.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The source process server.",
        SerializedName = @"sourceProcessServerId",
        PossibleTypes = new [] { typeof(string) })]
        string SourceProcessServerId { get; set; }
        /// <summary>The new process server.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The new process server.",
        SerializedName = @"targetProcessServerId",
        PossibleTypes = new [] { typeof(string) })]
        string TargetProcessServerId { get; set; }
        /// <summary>A value for failover type. It can be systemlevel/serverlevel</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"A value for failover type. It can be systemlevel/serverlevel",
        SerializedName = @"updateType",
        PossibleTypes = new [] { typeof(string) })]
        string UpdateType { get; set; }
        /// <summary>The VMS to migrate.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The VMS to migrate.",
        SerializedName = @"vmsToMigrate",
        PossibleTypes = new [] { typeof(string) })]
        string[] VmsToMigrate { get; set; }

    }
    /// The properties of the Failover Process Server request.
    internal partial interface IFailoverProcessServerRequestPropertiesInternal

    {
        /// <summary>The container identifier.</summary>
        string ContainerName { get; set; }
        /// <summary>The source process server.</summary>
        string SourceProcessServerId { get; set; }
        /// <summary>The new process server.</summary>
        string TargetProcessServerId { get; set; }
        /// <summary>A value for failover type. It can be systemlevel/serverlevel</summary>
        string UpdateType { get; set; }
        /// <summary>The VMS to migrate.</summary>
        string[] VmsToMigrate { get; set; }

    }
}