namespace Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Extensions;

    /// <summary>Properties of the machine resource.</summary>
    public partial class MachineProperties :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IMachineProperties,
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IMachinePropertiesInternal
    {

        /// <summary>Backing field for <see cref="AssessmentData" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IAssessmentDetails[] _assessmentData;

        /// <summary>
        /// Gets or sets the assessment details of the machine published by various sources.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IAssessmentDetails[] AssessmentData { get => this._assessmentData; set => this._assessmentData = value; }

        /// <summary>Backing field for <see cref="DiscoveryData" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IDiscoveryDetails[] _discoveryData;

        /// <summary>Gets or sets the discovery details of the machine published by various sources.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IDiscoveryDetails[] DiscoveryData { get => this._discoveryData; set => this._discoveryData = value; }

        /// <summary>Backing field for <see cref="LastUpdatedTime" /> property.</summary>
        private global::System.DateTime? _lastUpdatedTime;

        /// <summary>Gets or sets the time of the last modification of the machine.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public global::System.DateTime? LastUpdatedTime { get => this._lastUpdatedTime; set => this._lastUpdatedTime = value; }

        /// <summary>Backing field for <see cref="MigrationData" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IMigrationDetails[] _migrationData;

        /// <summary>Gets or sets the migration details of the machine published by various sources.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IMigrationDetails[] MigrationData { get => this._migrationData; set => this._migrationData = value; }

        /// <summary>Creates an new <see cref="MachineProperties" /> instance.</summary>
        public MachineProperties()
        {

        }
    }
    /// Properties of the machine resource.
    public partial interface IMachineProperties :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.IJsonSerializable
    {
        /// <summary>
        /// Gets or sets the assessment details of the machine published by various sources.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Gets or sets the assessment details of the machine published by various sources.",
        SerializedName = @"assessmentData",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IAssessmentDetails) })]
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IAssessmentDetails[] AssessmentData { get; set; }
        /// <summary>Gets or sets the discovery details of the machine published by various sources.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Gets or sets the discovery details of the machine published by various sources.",
        SerializedName = @"discoveryData",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IDiscoveryDetails) })]
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IDiscoveryDetails[] DiscoveryData { get; set; }
        /// <summary>Gets or sets the time of the last modification of the machine.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Gets or sets the time of the last modification of the machine.",
        SerializedName = @"lastUpdatedTime",
        PossibleTypes = new [] { typeof(global::System.DateTime) })]
        global::System.DateTime? LastUpdatedTime { get; set; }
        /// <summary>Gets or sets the migration details of the machine published by various sources.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Gets or sets the migration details of the machine published by various sources.",
        SerializedName = @"migrationData",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IMigrationDetails) })]
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IMigrationDetails[] MigrationData { get; set; }

    }
    /// Properties of the machine resource.
    internal partial interface IMachinePropertiesInternal

    {
        /// <summary>
        /// Gets or sets the assessment details of the machine published by various sources.
        /// </summary>
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IAssessmentDetails[] AssessmentData { get; set; }
        /// <summary>Gets or sets the discovery details of the machine published by various sources.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IDiscoveryDetails[] DiscoveryData { get; set; }
        /// <summary>Gets or sets the time of the last modification of the machine.</summary>
        global::System.DateTime? LastUpdatedTime { get; set; }
        /// <summary>Gets or sets the migration details of the machine published by various sources.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IMigrationDetails[] MigrationData { get; set; }

    }
}