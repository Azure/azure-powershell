namespace Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Extensions;

    /// <summary>Request to failover a process server.</summary>
    public partial class FailoverProcessServerRequest :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IFailoverProcessServerRequest,
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IFailoverProcessServerRequestInternal
    {

        /// <summary>The container identifier.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Inlined)]
        public string ContainerName { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IFailoverProcessServerRequestPropertiesInternal)Property).ContainerName; set => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IFailoverProcessServerRequestPropertiesInternal)Property).ContainerName = value ?? null; }

        /// <summary>Internal Acessors for Property</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IFailoverProcessServerRequestProperties Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IFailoverProcessServerRequestInternal.Property { get => (this._property = this._property ?? new Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.FailoverProcessServerRequestProperties()); set { {_property = value;} } }

        /// <summary>Backing field for <see cref="Property" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IFailoverProcessServerRequestProperties _property;

        /// <summary>The properties of the PS Failover request.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IFailoverProcessServerRequestProperties Property { get => (this._property = this._property ?? new Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.FailoverProcessServerRequestProperties()); set => this._property = value; }

        /// <summary>The source process server.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Inlined)]
        public string SourceProcessServerId { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IFailoverProcessServerRequestPropertiesInternal)Property).SourceProcessServerId; set => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IFailoverProcessServerRequestPropertiesInternal)Property).SourceProcessServerId = value ?? null; }

        /// <summary>The new process server.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Inlined)]
        public string TargetProcessServerId { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IFailoverProcessServerRequestPropertiesInternal)Property).TargetProcessServerId; set => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IFailoverProcessServerRequestPropertiesInternal)Property).TargetProcessServerId = value ?? null; }

        /// <summary>A value for failover type. It can be systemlevel/serverlevel</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Inlined)]
        public string UpdateType { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IFailoverProcessServerRequestPropertiesInternal)Property).UpdateType; set => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IFailoverProcessServerRequestPropertiesInternal)Property).UpdateType = value ?? null; }

        /// <summary>The VMS to migrate.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Inlined)]
        public string[] VmsToMigrate { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IFailoverProcessServerRequestPropertiesInternal)Property).VmsToMigrate; set => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IFailoverProcessServerRequestPropertiesInternal)Property).VmsToMigrate = value ?? null /* arrayOf */; }

        /// <summary>Creates an new <see cref="FailoverProcessServerRequest" /> instance.</summary>
        public FailoverProcessServerRequest()
        {

        }
    }
    /// Request to failover a process server.
    public partial interface IFailoverProcessServerRequest :
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
    /// Request to failover a process server.
    internal partial interface IFailoverProcessServerRequestInternal

    {
        /// <summary>The container identifier.</summary>
        string ContainerName { get; set; }
        /// <summary>The properties of the PS Failover request.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IFailoverProcessServerRequestProperties Property { get; set; }
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