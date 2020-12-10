namespace Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Extensions;

    /// <summary>Query parameter to enumerate jobs.</summary>
    public partial class JobQueryParameter :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IJobQueryParameter,
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IJobQueryParameterInternal
    {

        /// <summary>Backing field for <see cref="AffectedObjectType" /> property.</summary>
        private string _affectedObjectType;

        /// <summary>The type of objects.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string AffectedObjectType { get => this._affectedObjectType; set => this._affectedObjectType = value; }

        /// <summary>Backing field for <see cref="EndTime" /> property.</summary>
        private string _endTime;

        /// <summary>Date time to get jobs up to.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string EndTime { get => this._endTime; set => this._endTime = value; }

        /// <summary>Backing field for <see cref="FabricId" /> property.</summary>
        private string _fabricId;

        /// <summary>The Id of the fabric to search jobs under.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string FabricId { get => this._fabricId; set => this._fabricId = value; }

        /// <summary>Backing field for <see cref="JobStatus" /> property.</summary>
        private string _jobStatus;

        /// <summary>The states of the job to be filtered can be in.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string JobStatus { get => this._jobStatus; set => this._jobStatus = value; }

        /// <summary>Backing field for <see cref="StartTime" /> property.</summary>
        private string _startTime;

        /// <summary>Date time to get jobs from.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string StartTime { get => this._startTime; set => this._startTime = value; }

        /// <summary>Creates an new <see cref="JobQueryParameter" /> instance.</summary>
        public JobQueryParameter()
        {

        }
    }
    /// Query parameter to enumerate jobs.
    public partial interface IJobQueryParameter :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.IJsonSerializable
    {
        /// <summary>The type of objects.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The type of objects.",
        SerializedName = @"affectedObjectTypes",
        PossibleTypes = new [] { typeof(string) })]
        string AffectedObjectType { get; set; }
        /// <summary>Date time to get jobs up to.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Date time to get jobs up to.",
        SerializedName = @"endTime",
        PossibleTypes = new [] { typeof(string) })]
        string EndTime { get; set; }
        /// <summary>The Id of the fabric to search jobs under.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The Id of the fabric to search jobs under.",
        SerializedName = @"fabricId",
        PossibleTypes = new [] { typeof(string) })]
        string FabricId { get; set; }
        /// <summary>The states of the job to be filtered can be in.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The states of the job to be filtered can be in.",
        SerializedName = @"jobStatus",
        PossibleTypes = new [] { typeof(string) })]
        string JobStatus { get; set; }
        /// <summary>Date time to get jobs from.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Date time to get jobs from.",
        SerializedName = @"startTime",
        PossibleTypes = new [] { typeof(string) })]
        string StartTime { get; set; }

    }
    /// Query parameter to enumerate jobs.
    internal partial interface IJobQueryParameterInternal

    {
        /// <summary>The type of objects.</summary>
        string AffectedObjectType { get; set; }
        /// <summary>Date time to get jobs up to.</summary>
        string EndTime { get; set; }
        /// <summary>The Id of the fabric to search jobs under.</summary>
        string FabricId { get; set; }
        /// <summary>The states of the job to be filtered can be in.</summary>
        string JobStatus { get; set; }
        /// <summary>Date time to get jobs from.</summary>
        string StartTime { get; set; }

    }
}