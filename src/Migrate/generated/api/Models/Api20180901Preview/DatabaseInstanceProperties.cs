namespace Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Extensions;

    /// <summary>Properties of the database instance resource.</summary>
    public partial class DatabaseInstanceProperties :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IDatabaseInstanceProperties,
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IDatabaseInstancePropertiesInternal
    {

        /// <summary>Backing field for <see cref="DiscoveryData" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IDatabaseInstanceDiscoveryDetails[] _discoveryData;

        /// <summary>
        /// Gets or sets the assessment details of the database instance published by various sources.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IDatabaseInstanceDiscoveryDetails[] DiscoveryData { get => this._discoveryData; set => this._discoveryData = value; }

        /// <summary>Backing field for <see cref="LastUpdatedTime" /> property.</summary>
        private global::System.DateTime? _lastUpdatedTime;

        /// <summary>Gets or sets the time of the last modification of the database.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public global::System.DateTime? LastUpdatedTime { get => this._lastUpdatedTime; set => this._lastUpdatedTime = value; }

        /// <summary>Backing field for <see cref="Summary" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IDatabaseInstancePropertiesSummary _summary;

        /// <summary>
        /// Gets or sets the database instances summary per solution. The key of dictionary is the solution name and value is the
        /// corresponding database instance summary object.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IDatabaseInstancePropertiesSummary Summary { get => (this._summary = this._summary ?? new Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.DatabaseInstancePropertiesSummary()); set => this._summary = value; }

        /// <summary>Creates an new <see cref="DatabaseInstanceProperties" /> instance.</summary>
        public DatabaseInstanceProperties()
        {

        }
    }
    /// Properties of the database instance resource.
    public partial interface IDatabaseInstanceProperties :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.IJsonSerializable
    {
        /// <summary>
        /// Gets or sets the assessment details of the database instance published by various sources.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Gets or sets the assessment details of the database instance published by various sources.",
        SerializedName = @"discoveryData",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IDatabaseInstanceDiscoveryDetails) })]
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IDatabaseInstanceDiscoveryDetails[] DiscoveryData { get; set; }
        /// <summary>Gets or sets the time of the last modification of the database.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Gets or sets the time of the last modification of the database.",
        SerializedName = @"lastUpdatedTime",
        PossibleTypes = new [] { typeof(global::System.DateTime) })]
        global::System.DateTime? LastUpdatedTime { get; set; }
        /// <summary>
        /// Gets or sets the database instances summary per solution. The key of dictionary is the solution name and value is the
        /// corresponding database instance summary object.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Gets or sets the database instances summary per solution. The key of dictionary is the solution name and value is the corresponding database instance summary object.",
        SerializedName = @"summary",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IDatabaseInstancePropertiesSummary) })]
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IDatabaseInstancePropertiesSummary Summary { get; set; }

    }
    /// Properties of the database instance resource.
    internal partial interface IDatabaseInstancePropertiesInternal

    {
        /// <summary>
        /// Gets or sets the assessment details of the database instance published by various sources.
        /// </summary>
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IDatabaseInstanceDiscoveryDetails[] DiscoveryData { get; set; }
        /// <summary>Gets or sets the time of the last modification of the database.</summary>
        global::System.DateTime? LastUpdatedTime { get; set; }
        /// <summary>
        /// Gets or sets the database instances summary per solution. The key of dictionary is the solution name and value is the
        /// corresponding database instance summary object.
        /// </summary>
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IDatabaseInstancePropertiesSummary Summary { get; set; }

    }
}