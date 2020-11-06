namespace Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Extensions;

    /// <summary>
    /// This class contains the minimal job details required to navigate to the desired drill down.
    /// </summary>
    public partial class JobEntity :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IJobEntity,
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IJobEntityInternal
    {

        /// <summary>Backing field for <see cref="JobFriendlyName" /> property.</summary>
        private string _jobFriendlyName;

        /// <summary>The job display name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string JobFriendlyName { get => this._jobFriendlyName; set => this._jobFriendlyName = value; }

        /// <summary>Backing field for <see cref="JobId" /> property.</summary>
        private string _jobId;

        /// <summary>The job id.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string JobId { get => this._jobId; set => this._jobId = value; }

        /// <summary>Backing field for <see cref="JobScenarioName" /> property.</summary>
        private string _jobScenarioName;

        /// <summary>The job name. Enum type ScenarioName.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string JobScenarioName { get => this._jobScenarioName; set => this._jobScenarioName = value; }

        /// <summary>Backing field for <see cref="TargetInstanceType" /> property.</summary>
        private string _targetInstanceType;

        /// <summary>The workflow affected object type.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string TargetInstanceType { get => this._targetInstanceType; set => this._targetInstanceType = value; }

        /// <summary>Backing field for <see cref="TargetObjectId" /> property.</summary>
        private string _targetObjectId;

        /// <summary>The object id.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string TargetObjectId { get => this._targetObjectId; set => this._targetObjectId = value; }

        /// <summary>Backing field for <see cref="TargetObjectName" /> property.</summary>
        private string _targetObjectName;

        /// <summary>The object name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string TargetObjectName { get => this._targetObjectName; set => this._targetObjectName = value; }

        /// <summary>Creates an new <see cref="JobEntity" /> instance.</summary>
        public JobEntity()
        {

        }
    }
    /// This class contains the minimal job details required to navigate to the desired drill down.
    public partial interface IJobEntity :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.IJsonSerializable
    {
        /// <summary>The job display name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The job display name.",
        SerializedName = @"jobFriendlyName",
        PossibleTypes = new [] { typeof(string) })]
        string JobFriendlyName { get; set; }
        /// <summary>The job id.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The job id.",
        SerializedName = @"jobId",
        PossibleTypes = new [] { typeof(string) })]
        string JobId { get; set; }
        /// <summary>The job name. Enum type ScenarioName.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The job name. Enum type ScenarioName.",
        SerializedName = @"jobScenarioName",
        PossibleTypes = new [] { typeof(string) })]
        string JobScenarioName { get; set; }
        /// <summary>The workflow affected object type.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The workflow affected object type.",
        SerializedName = @"targetInstanceType",
        PossibleTypes = new [] { typeof(string) })]
        string TargetInstanceType { get; set; }
        /// <summary>The object id.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The object id.",
        SerializedName = @"targetObjectId",
        PossibleTypes = new [] { typeof(string) })]
        string TargetObjectId { get; set; }
        /// <summary>The object name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The object name.",
        SerializedName = @"targetObjectName",
        PossibleTypes = new [] { typeof(string) })]
        string TargetObjectName { get; set; }

    }
    /// This class contains the minimal job details required to navigate to the desired drill down.
    internal partial interface IJobEntityInternal

    {
        /// <summary>The job display name.</summary>
        string JobFriendlyName { get; set; }
        /// <summary>The job id.</summary>
        string JobId { get; set; }
        /// <summary>The job name. Enum type ScenarioName.</summary>
        string JobScenarioName { get; set; }
        /// <summary>The workflow affected object type.</summary>
        string TargetInstanceType { get; set; }
        /// <summary>The object id.</summary>
        string TargetObjectId { get; set; }
        /// <summary>The object name.</summary>
        string TargetObjectName { get; set; }

    }
}