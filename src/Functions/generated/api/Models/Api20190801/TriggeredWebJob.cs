namespace Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Extensions;

    /// <summary>Triggered Web Job Information.</summary>
    public partial class TriggeredWebJob :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ITriggeredWebJob,
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ITriggeredWebJobInternal,
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.IValidates
    {
        /// <summary>
        /// Backing field for Inherited model <see cref= "Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResource"
        /// />
        /// </summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResource __proxyOnlyResource = new Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ProxyOnlyResource();

        /// <summary>Job duration.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string Duration { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ITriggeredWebJobPropertiesInternal)Property).Duration; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ITriggeredWebJobPropertiesInternal)Property).Duration = value; }

        /// <summary>End time.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public global::System.DateTime? EndTime { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ITriggeredWebJobPropertiesInternal)Property).EndTime; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ITriggeredWebJobPropertiesInternal)Property).EndTime = value; }

        /// <summary>Error information.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string Error { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ITriggeredWebJobPropertiesInternal)Property).Error; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ITriggeredWebJobPropertiesInternal)Property).Error = value; }

        /// <summary>Error URL.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string ErrorUrl { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ITriggeredWebJobPropertiesInternal)Property).ErrorUrl; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ITriggeredWebJobPropertiesInternal)Property).ErrorUrl = value; }

        /// <summary>Extra Info URL.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string ExtraInfoUrl { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ITriggeredWebJobPropertiesInternal)Property).ExtraInfoUrl; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ITriggeredWebJobPropertiesInternal)Property).ExtraInfoUrl = value; }

        /// <summary>History URL.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string HistoryUrl { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ITriggeredWebJobPropertiesInternal)Property).HistoryUrl; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ITriggeredWebJobPropertiesInternal)Property).HistoryUrl = value; }

        /// <summary>Resource Id.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inherited)]
        public string Id { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)__proxyOnlyResource).Id; }

        /// <summary>Job name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string JobName { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ITriggeredWebJobPropertiesInternal)Property).JobName; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ITriggeredWebJobPropertiesInternal)Property).JobName = value; }

        /// <summary>Kind of resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inherited)]
        public string Kind { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)__proxyOnlyResource).Kind; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)__proxyOnlyResource).Kind = value; }

        /// <summary>Resource Id.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string LatestRunId { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ITriggeredWebJobPropertiesInternal)Property).LatestRunId; }

        /// <summary>Kind of resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string LatestRunKind { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ITriggeredWebJobPropertiesInternal)Property).LatestRunKind; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ITriggeredWebJobPropertiesInternal)Property).LatestRunKind = value; }

        /// <summary>Resource Name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string LatestRunName { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ITriggeredWebJobPropertiesInternal)Property).LatestRunName; }

        /// <summary>Job URL.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string LatestRunPropertiesUrl { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ITriggeredWebJobPropertiesInternal)Property).LatestRunPropertiesUrl; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ITriggeredWebJobPropertiesInternal)Property).LatestRunPropertiesUrl = value; }

        /// <summary>Resource type.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string LatestRunType { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ITriggeredWebJobPropertiesInternal)Property).LatestRunType; }

        /// <summary>Internal Acessors for Id</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal.Id { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)__proxyOnlyResource).Id; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)__proxyOnlyResource).Id = value; }

        /// <summary>Internal Acessors for Name</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal.Name { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)__proxyOnlyResource).Name; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)__proxyOnlyResource).Name = value; }

        /// <summary>Internal Acessors for Type</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal.Type { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)__proxyOnlyResource).Type; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)__proxyOnlyResource).Type = value; }

        /// <summary>Internal Acessors for LatestRun</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ITriggeredJobRun Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ITriggeredWebJobInternal.LatestRun { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ITriggeredWebJobPropertiesInternal)Property).LatestRun; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ITriggeredWebJobPropertiesInternal)Property).LatestRun = value; }

        /// <summary>Internal Acessors for LatestRunId</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ITriggeredWebJobInternal.LatestRunId { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ITriggeredWebJobPropertiesInternal)Property).LatestRunId; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ITriggeredWebJobPropertiesInternal)Property).LatestRunId = value; }

        /// <summary>Internal Acessors for LatestRunName</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ITriggeredWebJobInternal.LatestRunName { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ITriggeredWebJobPropertiesInternal)Property).LatestRunName; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ITriggeredWebJobPropertiesInternal)Property).LatestRunName = value; }

        /// <summary>Internal Acessors for LatestRunProperty</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ITriggeredJobRunProperties Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ITriggeredWebJobInternal.LatestRunProperty { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ITriggeredWebJobPropertiesInternal)Property).LatestRunProperty; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ITriggeredWebJobPropertiesInternal)Property).LatestRunProperty = value; }

        /// <summary>Internal Acessors for LatestRunType</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ITriggeredWebJobInternal.LatestRunType { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ITriggeredWebJobPropertiesInternal)Property).LatestRunType; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ITriggeredWebJobPropertiesInternal)Property).LatestRunType = value; }

        /// <summary>Internal Acessors for Property</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ITriggeredWebJobProperties Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ITriggeredWebJobInternal.Property { get => (this._property = this._property ?? new Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.TriggeredWebJobProperties()); set { {_property = value;} } }

        /// <summary>Resource Name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inherited)]
        public string Name { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)__proxyOnlyResource).Name; }

        /// <summary>Output URL.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string OutputUrl { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ITriggeredWebJobPropertiesInternal)Property).OutputUrl; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ITriggeredWebJobPropertiesInternal)Property).OutputUrl = value; }

        /// <summary>Backing field for <see cref="Property" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ITriggeredWebJobProperties _property;

        /// <summary>TriggeredWebJob resource specific properties</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ITriggeredWebJobProperties Property { get => (this._property = this._property ?? new Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.TriggeredWebJobProperties()); set => this._property = value; }

        /// <summary>Run command.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string RunCommand { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ITriggeredWebJobPropertiesInternal)Property).RunCommand; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ITriggeredWebJobPropertiesInternal)Property).RunCommand = value; }

        /// <summary>Scheduler Logs URL.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string SchedulerLogsUrl { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ITriggeredWebJobPropertiesInternal)Property).SchedulerLogsUrl; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ITriggeredWebJobPropertiesInternal)Property).SchedulerLogsUrl = value; }

        /// <summary>Job settings.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ITriggeredWebJobPropertiesSettings Setting { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ITriggeredWebJobPropertiesInternal)Property).Setting; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ITriggeredWebJobPropertiesInternal)Property).Setting = value; }

        /// <summary>Start time.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public global::System.DateTime? StartTime { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ITriggeredWebJobPropertiesInternal)Property).StartTime; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ITriggeredWebJobPropertiesInternal)Property).StartTime = value; }

        /// <summary>Job status.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.TriggeredWebJobStatus? Status { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ITriggeredWebJobPropertiesInternal)Property).Status; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ITriggeredWebJobPropertiesInternal)Property).Status = value; }

        /// <summary>Job trigger.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string Trigger { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ITriggeredWebJobPropertiesInternal)Property).Trigger; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ITriggeredWebJobPropertiesInternal)Property).Trigger = value; }

        /// <summary>Resource type.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inherited)]
        public string Type { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)__proxyOnlyResource).Type; }

        /// <summary>Job URL.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string Url { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ITriggeredWebJobPropertiesInternal)Property).Url; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ITriggeredWebJobPropertiesInternal)Property).Url = value; }

        /// <summary>Using SDK?</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public bool? UsingSdk { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ITriggeredWebJobPropertiesInternal)Property).UsingSdk; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ITriggeredWebJobPropertiesInternal)Property).UsingSdk = value; }

        /// <summary>Job ID.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string WebJobId { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ITriggeredWebJobPropertiesInternal)Property).WebJobId; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ITriggeredWebJobPropertiesInternal)Property).WebJobId = value; }

        /// <summary>Job name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string WebJobName { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ITriggeredWebJobPropertiesInternal)Property).WebJobName; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ITriggeredWebJobPropertiesInternal)Property).WebJobName = value; }

        /// <summary>Job type.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.WebJobType? WebJobType { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ITriggeredWebJobPropertiesInternal)Property).WebJobType; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ITriggeredWebJobPropertiesInternal)Property).WebJobType = value; }

        /// <summary>Creates an new <see cref="TriggeredWebJob" /> instance.</summary>
        public TriggeredWebJob()
        {

        }

        /// <summary>Validates that this object meets the validation criteria.</summary>
        /// <param name="eventListener">an <see cref="Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.IEventListener" /> instance that will receive validation
        /// events.</param>
        /// <returns>
        /// A < see cref = "global::System.Threading.Tasks.Task" /> that will be complete when validation is completed.
        /// </returns>
        public async global::System.Threading.Tasks.Task Validate(Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.IEventListener eventListener)
        {
            await eventListener.AssertNotNull(nameof(__proxyOnlyResource), __proxyOnlyResource);
            await eventListener.AssertObjectIsValid(nameof(__proxyOnlyResource), __proxyOnlyResource);
        }
    }
    /// Triggered Web Job Information.
    public partial interface ITriggeredWebJob :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.IJsonSerializable,
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResource
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
    /// Triggered Web Job Information.
    internal partial interface ITriggeredWebJobInternal :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal
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
        /// <summary>TriggeredWebJob resource specific properties</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ITriggeredWebJobProperties Property { get; set; }
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