namespace Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Extensions;

    /// <summary>TriggeredWebJob resource specific properties</summary>
    public partial class TriggeredWebJobProperties :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ITriggeredWebJobProperties,
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ITriggeredWebJobPropertiesInternal
    {

        /// <summary>Job duration.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string Duration { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ITriggeredJobRunInternal)LatestRun).Duration; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ITriggeredJobRunInternal)LatestRun).Duration = value; }

        /// <summary>End time.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public global::System.DateTime? EndTime { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ITriggeredJobRunInternal)LatestRun).EndTime; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ITriggeredJobRunInternal)LatestRun).EndTime = value; }

        /// <summary>Backing field for <see cref="Error" /> property.</summary>
        private string _error;

        /// <summary>Error information.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public string Error { get => this._error; set => this._error = value; }

        /// <summary>Error URL.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string ErrorUrl { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ITriggeredJobRunInternal)LatestRun).ErrorUrl; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ITriggeredJobRunInternal)LatestRun).ErrorUrl = value; }

        /// <summary>Backing field for <see cref="ExtraInfoUrl" /> property.</summary>
        private string _extraInfoUrl;

        /// <summary>Extra Info URL.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public string ExtraInfoUrl { get => this._extraInfoUrl; set => this._extraInfoUrl = value; }

        /// <summary>Backing field for <see cref="HistoryUrl" /> property.</summary>
        private string _historyUrl;

        /// <summary>History URL.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public string HistoryUrl { get => this._historyUrl; set => this._historyUrl = value; }

        /// <summary>Job name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string JobName { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ITriggeredJobRunInternal)LatestRun).JobName; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ITriggeredJobRunInternal)LatestRun).JobName = value; }

        /// <summary>Backing field for <see cref="LatestRun" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ITriggeredJobRun _latestRun;

        /// <summary>Latest job run information.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ITriggeredJobRun LatestRun { get => (this._latestRun = this._latestRun ?? new Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.TriggeredJobRun()); set => this._latestRun = value; }

        /// <summary>Resource Id.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string LatestRunId { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)LatestRun).Id; }

        /// <summary>Kind of resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string LatestRunKind { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)LatestRun).Kind; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)LatestRun).Kind = value; }

        /// <summary>Resource Name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string LatestRunName { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)LatestRun).Name; }

        /// <summary>Job URL.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string LatestRunPropertiesUrl { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ITriggeredJobRunInternal)LatestRun).Url; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ITriggeredJobRunInternal)LatestRun).Url = value; }

        /// <summary>Resource type.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string LatestRunType { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)LatestRun).Type; }

        /// <summary>Internal Acessors for LatestRun</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ITriggeredJobRun Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ITriggeredWebJobPropertiesInternal.LatestRun { get => (this._latestRun = this._latestRun ?? new Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.TriggeredJobRun()); set { {_latestRun = value;} } }

        /// <summary>Internal Acessors for LatestRunId</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ITriggeredWebJobPropertiesInternal.LatestRunId { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)LatestRun).Id; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)LatestRun).Id = value; }

        /// <summary>Internal Acessors for LatestRunName</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ITriggeredWebJobPropertiesInternal.LatestRunName { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)LatestRun).Name; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)LatestRun).Name = value; }

        /// <summary>Internal Acessors for LatestRunProperty</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ITriggeredJobRunProperties Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ITriggeredWebJobPropertiesInternal.LatestRunProperty { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ITriggeredJobRunInternal)LatestRun).Property; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ITriggeredJobRunInternal)LatestRun).Property = value; }

        /// <summary>Internal Acessors for LatestRunType</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ITriggeredWebJobPropertiesInternal.LatestRunType { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)LatestRun).Type; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)LatestRun).Type = value; }

        /// <summary>Output URL.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string OutputUrl { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ITriggeredJobRunInternal)LatestRun).OutputUrl; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ITriggeredJobRunInternal)LatestRun).OutputUrl = value; }

        /// <summary>Backing field for <see cref="RunCommand" /> property.</summary>
        private string _runCommand;

        /// <summary>Run command.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public string RunCommand { get => this._runCommand; set => this._runCommand = value; }

        /// <summary>Backing field for <see cref="SchedulerLogsUrl" /> property.</summary>
        private string _schedulerLogsUrl;

        /// <summary>Scheduler Logs URL.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public string SchedulerLogsUrl { get => this._schedulerLogsUrl; set => this._schedulerLogsUrl = value; }

        /// <summary>Backing field for <see cref="Setting" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ITriggeredWebJobPropertiesSettings _setting;

        /// <summary>Job settings.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ITriggeredWebJobPropertiesSettings Setting { get => (this._setting = this._setting ?? new Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.TriggeredWebJobPropertiesSettings()); set => this._setting = value; }

        /// <summary>Start time.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public global::System.DateTime? StartTime { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ITriggeredJobRunInternal)LatestRun).StartTime; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ITriggeredJobRunInternal)LatestRun).StartTime = value; }

        /// <summary>Job status.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.TriggeredWebJobStatus? Status { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ITriggeredJobRunInternal)LatestRun).Status; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ITriggeredJobRunInternal)LatestRun).Status = value; }

        /// <summary>Job trigger.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string Trigger { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ITriggeredJobRunInternal)LatestRun).Trigger; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ITriggeredJobRunInternal)LatestRun).Trigger = value; }

        /// <summary>Backing field for <see cref="Url" /> property.</summary>
        private string _url;

        /// <summary>Job URL.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public string Url { get => this._url; set => this._url = value; }

        /// <summary>Backing field for <see cref="UsingSdk" /> property.</summary>
        private bool? _usingSdk;

        /// <summary>Using SDK?</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public bool? UsingSdk { get => this._usingSdk; set => this._usingSdk = value; }

        /// <summary>Job ID.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string WebJobId { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ITriggeredJobRunInternal)LatestRun).WebJobId; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ITriggeredJobRunInternal)LatestRun).WebJobId = value; }

        /// <summary>Job name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string WebJobName { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ITriggeredJobRunInternal)LatestRun).WebJobName; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ITriggeredJobRunInternal)LatestRun).WebJobName = value; }

        /// <summary>Backing field for <see cref="WebJobType" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.WebJobType? _webJobType;

        /// <summary>Job type.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.WebJobType? WebJobType { get => this._webJobType; set => this._webJobType = value; }

        /// <summary>Creates an new <see cref="TriggeredWebJobProperties" /> instance.</summary>
        public TriggeredWebJobProperties()
        {

        }
    }
    /// TriggeredWebJob resource specific properties
    public partial interface ITriggeredWebJobProperties :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.IJsonSerializable
    {
        /// <summary>Job duration.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Job duration.",
        SerializedName = @"duration",
        PossibleTypes = new [] { typeof(string) })]
        string Duration { get; set; }
        /// <summary>End time.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"End time.",
        SerializedName = @"end_time",
        PossibleTypes = new [] { typeof(global::System.DateTime) })]
        global::System.DateTime? EndTime { get; set; }
        /// <summary>Error information.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Error information.",
        SerializedName = @"error",
        PossibleTypes = new [] { typeof(string) })]
        string Error { get; set; }
        /// <summary>Error URL.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Error URL.",
        SerializedName = @"error_url",
        PossibleTypes = new [] { typeof(string) })]
        string ErrorUrl { get; set; }
        /// <summary>Extra Info URL.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Extra Info URL.",
        SerializedName = @"extra_info_url",
        PossibleTypes = new [] { typeof(string) })]
        string ExtraInfoUrl { get; set; }
        /// <summary>History URL.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"History URL.",
        SerializedName = @"history_url",
        PossibleTypes = new [] { typeof(string) })]
        string HistoryUrl { get; set; }
        /// <summary>Job name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Job name.",
        SerializedName = @"job_name",
        PossibleTypes = new [] { typeof(string) })]
        string JobName { get; set; }
        /// <summary>Resource Id.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Resource Id.",
        SerializedName = @"id",
        PossibleTypes = new [] { typeof(string) })]
        string LatestRunId { get;  }
        /// <summary>Kind of resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Kind of resource.",
        SerializedName = @"kind",
        PossibleTypes = new [] { typeof(string) })]
        string LatestRunKind { get; set; }
        /// <summary>Resource Name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Resource Name.",
        SerializedName = @"name",
        PossibleTypes = new [] { typeof(string) })]
        string LatestRunName { get;  }
        /// <summary>Job URL.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Job URL.",
        SerializedName = @"url",
        PossibleTypes = new [] { typeof(string) })]
        string LatestRunPropertiesUrl { get; set; }
        /// <summary>Resource type.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Resource type.",
        SerializedName = @"type",
        PossibleTypes = new [] { typeof(string) })]
        string LatestRunType { get;  }
        /// <summary>Output URL.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Output URL.",
        SerializedName = @"output_url",
        PossibleTypes = new [] { typeof(string) })]
        string OutputUrl { get; set; }
        /// <summary>Run command.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Run command.",
        SerializedName = @"run_command",
        PossibleTypes = new [] { typeof(string) })]
        string RunCommand { get; set; }
        /// <summary>Scheduler Logs URL.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Scheduler Logs URL.",
        SerializedName = @"scheduler_logs_url",
        PossibleTypes = new [] { typeof(string) })]
        string SchedulerLogsUrl { get; set; }
        /// <summary>Job settings.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Job settings.",
        SerializedName = @"settings",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ITriggeredWebJobPropertiesSettings) })]
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ITriggeredWebJobPropertiesSettings Setting { get; set; }
        /// <summary>Start time.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Start time.",
        SerializedName = @"start_time",
        PossibleTypes = new [] { typeof(global::System.DateTime) })]
        global::System.DateTime? StartTime { get; set; }
        /// <summary>Job status.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Job status.",
        SerializedName = @"status",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.TriggeredWebJobStatus) })]
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.TriggeredWebJobStatus? Status { get; set; }
        /// <summary>Job trigger.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Job trigger.",
        SerializedName = @"trigger",
        PossibleTypes = new [] { typeof(string) })]
        string Trigger { get; set; }
        /// <summary>Job URL.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Job URL.",
        SerializedName = @"url",
        PossibleTypes = new [] { typeof(string) })]
        string Url { get; set; }
        /// <summary>Using SDK?</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Using SDK?",
        SerializedName = @"using_sdk",
        PossibleTypes = new [] { typeof(bool) })]
        bool? UsingSdk { get; set; }
        /// <summary>Job ID.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Job ID.",
        SerializedName = @"web_job_id",
        PossibleTypes = new [] { typeof(string) })]
        string WebJobId { get; set; }
        /// <summary>Job name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Job name.",
        SerializedName = @"web_job_name",
        PossibleTypes = new [] { typeof(string) })]
        string WebJobName { get; set; }
        /// <summary>Job type.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Job type.",
        SerializedName = @"web_job_type",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.WebJobType) })]
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.WebJobType? WebJobType { get; set; }

    }
    /// TriggeredWebJob resource specific properties
    internal partial interface ITriggeredWebJobPropertiesInternal

    {
        /// <summary>Job duration.</summary>
        string Duration { get; set; }
        /// <summary>End time.</summary>
        global::System.DateTime? EndTime { get; set; }
        /// <summary>Error information.</summary>
        string Error { get; set; }
        /// <summary>Error URL.</summary>
        string ErrorUrl { get; set; }
        /// <summary>Extra Info URL.</summary>
        string ExtraInfoUrl { get; set; }
        /// <summary>History URL.</summary>
        string HistoryUrl { get; set; }
        /// <summary>Job name.</summary>
        string JobName { get; set; }
        /// <summary>Latest job run information.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ITriggeredJobRun LatestRun { get; set; }
        /// <summary>Resource Id.</summary>
        string LatestRunId { get; set; }
        /// <summary>Kind of resource.</summary>
        string LatestRunKind { get; set; }
        /// <summary>Resource Name.</summary>
        string LatestRunName { get; set; }
        /// <summary>Job URL.</summary>
        string LatestRunPropertiesUrl { get; set; }
        /// <summary>TriggeredJobRun resource specific properties</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ITriggeredJobRunProperties LatestRunProperty { get; set; }
        /// <summary>Resource type.</summary>
        string LatestRunType { get; set; }
        /// <summary>Output URL.</summary>
        string OutputUrl { get; set; }
        /// <summary>Run command.</summary>
        string RunCommand { get; set; }
        /// <summary>Scheduler Logs URL.</summary>
        string SchedulerLogsUrl { get; set; }
        /// <summary>Job settings.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ITriggeredWebJobPropertiesSettings Setting { get; set; }
        /// <summary>Start time.</summary>
        global::System.DateTime? StartTime { get; set; }
        /// <summary>Job status.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.TriggeredWebJobStatus? Status { get; set; }
        /// <summary>Job trigger.</summary>
        string Trigger { get; set; }
        /// <summary>Job URL.</summary>
        string Url { get; set; }
        /// <summary>Using SDK?</summary>
        bool? UsingSdk { get; set; }
        /// <summary>Job ID.</summary>
        string WebJobId { get; set; }
        /// <summary>Job name.</summary>
        string WebJobName { get; set; }
        /// <summary>Job type.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.WebJobType? WebJobType { get; set; }

    }
}