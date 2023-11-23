namespace Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview
{
    using static Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Runtime.Extensions;

    /// <summary>The properties that are associated with a streaming job.</summary>
    public partial class StreamingJobProperties :
        Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IStreamingJobProperties,
        Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IStreamingJobPropertiesInternal,
        Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Runtime.IHeaderSerializable
    {

        /// <summary>Backing field for <see cref="Cluster" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IClusterInfo _cluster;

        /// <summary>The cluster which streaming jobs will run on.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Origin(Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IClusterInfo Cluster { get => (this._cluster = this._cluster ?? new Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.ClusterInfo()); set => this._cluster = value; }

        /// <summary>The resource id of cluster.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Origin(Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.PropertyOrigin.Inlined)]
        public string ClusterId { get => ((Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IClusterInfoInternal)Cluster).Id; set => ((Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IClusterInfoInternal)Cluster).Id = value ?? null; }

        /// <summary>Backing field for <see cref="CompatibilityLevel" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Support.CompatibilityLevel? _compatibilityLevel;

        /// <summary>Controls certain runtime behaviors of the streaming job.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Origin(Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Support.CompatibilityLevel? CompatibilityLevel { get => this._compatibilityLevel; set => this._compatibilityLevel = value; }

        /// <summary>Backing field for <see cref="ContentStoragePolicy" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Support.ContentStoragePolicy? _contentStoragePolicy;

        /// <summary>
        /// Valid values are JobStorageAccount and SystemAccount. If set to JobStorageAccount, this requires the user to also specify
        /// jobStorageAccount property. .
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Origin(Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Support.ContentStoragePolicy? ContentStoragePolicy { get => this._contentStoragePolicy; set => this._contentStoragePolicy = value; }

        /// <summary>Backing field for <see cref="CreatedDate" /> property.</summary>
        private global::System.DateTime? _createdDate;

        /// <summary>
        /// Value is an ISO-8601 formatted UTC timestamp indicating when the streaming job was created.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Origin(Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.PropertyOrigin.Owned)]
        public global::System.DateTime? CreatedDate { get => this._createdDate; }

        /// <summary>Backing field for <see cref="DataLocale" /> property.</summary>
        private string _dataLocale;

        /// <summary>
        /// The data locale of the stream analytics job. Value should be the name of a supported .NET Culture from the set https://msdn.microsoft.com/en-us/library/system.globalization.culturetypes(v=vs.110).aspx.
        /// Defaults to 'en-US' if none specified.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Origin(Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.PropertyOrigin.Owned)]
        public string DataLocale { get => this._dataLocale; set => this._dataLocale = value; }

        /// <summary>Backing field for <see cref="EventsLateArrivalMaxDelayInSecond" /> property.</summary>
        private int? _eventsLateArrivalMaxDelayInSecond;

        /// <summary>
        /// The maximum tolerable delay in seconds where events arriving late could be included. Supported range is -1 to 1814399
        /// (20.23:59:59 days) and -1 is used to specify wait indefinitely. If the property is absent, it is interpreted to have a
        /// value of -1.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Origin(Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.PropertyOrigin.Owned)]
        public int? EventsLateArrivalMaxDelayInSecond { get => this._eventsLateArrivalMaxDelayInSecond; set => this._eventsLateArrivalMaxDelayInSecond = value; }

        /// <summary>Backing field for <see cref="EventsOutOfOrderMaxDelayInSecond" /> property.</summary>
        private int? _eventsOutOfOrderMaxDelayInSecond;

        /// <summary>
        /// The maximum tolerable delay in seconds where out-of-order events can be adjusted to be back in order.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Origin(Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.PropertyOrigin.Owned)]
        public int? EventsOutOfOrderMaxDelayInSecond { get => this._eventsOutOfOrderMaxDelayInSecond; set => this._eventsOutOfOrderMaxDelayInSecond = value; }

        /// <summary>Backing field for <see cref="EventsOutOfOrderPolicy" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Support.EventsOutOfOrderPolicy? _eventsOutOfOrderPolicy;

        /// <summary>
        /// Indicates the policy to apply to events that arrive out of order in the input event stream.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Origin(Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Support.EventsOutOfOrderPolicy? EventsOutOfOrderPolicy { get => this._eventsOutOfOrderPolicy; set => this._eventsOutOfOrderPolicy = value; }

        /// <summary>Backing field for <see cref="External" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IExternal _external;

        /// <summary>The storage account where the custom code artifacts are located.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Origin(Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IExternal External { get => (this._external = this._external ?? new Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.External()); set => this._external = value; }

        [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Origin(Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.PropertyOrigin.Inlined)]
        public string ExternalContainer { get => ((Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IExternalInternal)External).Container; set => ((Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IExternalInternal)External).Container = value ?? null; }

        [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Origin(Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.PropertyOrigin.Inlined)]
        public string ExternalPath { get => ((Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IExternalInternal)External).Path; set => ((Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IExternalInternal)External).Path = value ?? null; }

        /// <summary>Backing field for <see cref="Function" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IFunction[] _function;

        /// <summary>
        /// A list of one or more functions for the streaming job. The name property for each function is required when specifying
        /// this property in a PUT request. This property cannot be modify via a PATCH operation. You must use the PATCH API available
        /// for the individual transformation.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Origin(Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IFunction[] Function { get => this._function; set => this._function = value; }

        /// <summary>Backing field for <see cref="Input" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IInput[] _input;

        /// <summary>
        /// A list of one or more inputs to the streaming job. The name property for each input is required when specifying this property
        /// in a PUT request. This property cannot be modify via a PATCH operation. You must use the PATCH API available for the individual
        /// input.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Origin(Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IInput[] Input { get => this._input; set => this._input = value; }

        /// <summary>Backing field for <see cref="JobId" /> property.</summary>
        private string _jobId;

        /// <summary>
        /// A GUID uniquely identifying the streaming job. This GUID is generated upon creation of the streaming job.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Origin(Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.PropertyOrigin.Owned)]
        public string JobId { get => this._jobId; }

        /// <summary>Backing field for <see cref="JobState" /> property.</summary>
        private string _jobState;

        /// <summary>Describes the state of the streaming job.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Origin(Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.PropertyOrigin.Owned)]
        public string JobState { get => this._jobState; }

        /// <summary>Backing field for <see cref="JobStorageAccount" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IJobStorageAccount _jobStorageAccount;

        /// <summary>The properties that are associated with an Azure Storage account with MSI</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Origin(Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IJobStorageAccount JobStorageAccount { get => (this._jobStorageAccount = this._jobStorageAccount ?? new Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.JobStorageAccount()); set => this._jobStorageAccount = value; }

        /// <summary>Authentication Mode.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Origin(Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Support.AuthenticationMode? JobStorageAccountAuthenticationMode { get => ((Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IJobStorageAccountInternal)JobStorageAccount).AuthenticationMode; set => ((Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IJobStorageAccountInternal)JobStorageAccount).AuthenticationMode = value ?? ((Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Support.AuthenticationMode)""); }

        /// <summary>
        /// The account key for the Azure Storage account. Required on PUT (CreateOrReplace) requests.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Origin(Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.PropertyOrigin.Inlined)]
        public string JobStorageAccountKey { get => ((Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IStorageAccountInternal)JobStorageAccount).AccountKey; set => ((Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IStorageAccountInternal)JobStorageAccount).AccountKey = value ?? null; }

        /// <summary>
        /// The name of the Azure Storage account. Required on PUT (CreateOrReplace) requests.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Origin(Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.PropertyOrigin.Inlined)]
        public string JobStorageAccountName { get => ((Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IStorageAccountInternal)JobStorageAccount).AccountName; set => ((Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IStorageAccountInternal)JobStorageAccount).AccountName = value ?? null; }

        /// <summary>Backing field for <see cref="JobType" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Support.JobType? _jobType;

        /// <summary>Describes the type of the job. Valid modes are `Cloud` and 'Edge'.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Origin(Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Support.JobType? JobType { get => this._jobType; set => this._jobType = value; }

        /// <summary>Backing field for <see cref="LastOutputEventTime" /> property.</summary>
        private global::System.DateTime? _lastOutputEventTime;

        /// <summary>
        /// Value is either an ISO-8601 formatted timestamp indicating the last output event time of the streaming job or null indicating
        /// that output has not yet been produced. In case of multiple outputs or multiple streams, this shows the latest value in
        /// that set.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Origin(Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.PropertyOrigin.Owned)]
        public global::System.DateTime? LastOutputEventTime { get => this._lastOutputEventTime; }

        /// <summary>Internal Acessors for Cluster</summary>
        Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IClusterInfo Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IStreamingJobPropertiesInternal.Cluster { get => (this._cluster = this._cluster ?? new Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.ClusterInfo()); set { {_cluster = value;} } }

        /// <summary>Internal Acessors for CreatedDate</summary>
        global::System.DateTime? Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IStreamingJobPropertiesInternal.CreatedDate { get => this._createdDate; set { {_createdDate = value;} } }

        /// <summary>Internal Acessors for External</summary>
        Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IExternal Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IStreamingJobPropertiesInternal.External { get => (this._external = this._external ?? new Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.External()); set { {_external = value;} } }

        /// <summary>Internal Acessors for ExternalStorageAccount</summary>
        Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IStorageAccount Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IStreamingJobPropertiesInternal.ExternalStorageAccount { get => ((Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IExternalInternal)External).StorageAccount; set => ((Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IExternalInternal)External).StorageAccount = value; }

        /// <summary>Internal Acessors for JobId</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IStreamingJobPropertiesInternal.JobId { get => this._jobId; set { {_jobId = value;} } }

        /// <summary>Internal Acessors for JobState</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IStreamingJobPropertiesInternal.JobState { get => this._jobState; set { {_jobState = value;} } }

        /// <summary>Internal Acessors for JobStorageAccount</summary>
        Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IJobStorageAccount Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IStreamingJobPropertiesInternal.JobStorageAccount { get => (this._jobStorageAccount = this._jobStorageAccount ?? new Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.JobStorageAccount()); set { {_jobStorageAccount = value;} } }

        /// <summary>Internal Acessors for LastOutputEventTime</summary>
        global::System.DateTime? Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IStreamingJobPropertiesInternal.LastOutputEventTime { get => this._lastOutputEventTime; set { {_lastOutputEventTime = value;} } }

        /// <summary>Internal Acessors for ProvisioningState</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IStreamingJobPropertiesInternal.ProvisioningState { get => this._provisioningState; set { {_provisioningState = value;} } }

        /// <summary>Internal Acessors for Sku</summary>
        Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IStreamingJobSku Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IStreamingJobPropertiesInternal.Sku { get => (this._sku = this._sku ?? new Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.StreamingJobSku()); set { {_sku = value;} } }

        /// <summary>Internal Acessors for Transformation</summary>
        Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.ITransformation Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IStreamingJobPropertiesInternal.Transformation { get => (this._transformation = this._transformation ?? new Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.Transformation()); set { {_transformation = value;} } }

        /// <summary>Internal Acessors for TransformationId</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IStreamingJobPropertiesInternal.TransformationId { get => ((Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.ISubResourceInternal)Transformation).Id; set => ((Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.ISubResourceInternal)Transformation).Id = value; }

        /// <summary>Internal Acessors for TransformationName</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IStreamingJobPropertiesInternal.TransformationName { get => ((Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.ISubResourceInternal)Transformation).Name; set => ((Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.ISubResourceInternal)Transformation).Name = value; }

        /// <summary>Internal Acessors for TransformationProperty</summary>
        Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.ITransformationProperties Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IStreamingJobPropertiesInternal.TransformationProperty { get => ((Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.ITransformationInternal)Transformation).Property; set => ((Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.ITransformationInternal)Transformation).Property = value; }

        /// <summary>Internal Acessors for TransformationType</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IStreamingJobPropertiesInternal.TransformationType { get => ((Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.ISubResourceInternal)Transformation).Type; set => ((Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.ISubResourceInternal)Transformation).Type = value; }

        /// <summary>Backing field for <see cref="Output" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IOutput[] _output;

        /// <summary>
        /// A list of one or more outputs for the streaming job. The name property for each output is required when specifying this
        /// property in a PUT request. This property cannot be modify via a PATCH operation. You must use the PATCH API available
        /// for the individual output.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Origin(Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IOutput[] Output { get => this._output; set => this._output = value; }

        /// <summary>Backing field for <see cref="OutputErrorPolicy" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Support.OutputErrorPolicy? _outputErrorPolicy;

        /// <summary>
        /// Indicates the policy to apply to events that arrive at the output and cannot be written to the external storage due to
        /// being malformed (missing column values, column values of wrong type or size).
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Origin(Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Support.OutputErrorPolicy? OutputErrorPolicy { get => this._outputErrorPolicy; set => this._outputErrorPolicy = value; }

        /// <summary>Backing field for <see cref="OutputStartMode" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Support.OutputStartMode? _outputStartMode;

        /// <summary>
        /// This property should only be utilized when it is desired that the job be started immediately upon creation. Value may
        /// be JobStartTime, CustomTime, or LastOutputEventTime to indicate whether the starting point of the output event stream
        /// should start whenever the job is started, start at a custom user time stamp specified via the outputStartTime property,
        /// or start from the last event output time.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Origin(Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Support.OutputStartMode? OutputStartMode { get => this._outputStartMode; set => this._outputStartMode = value; }

        /// <summary>Backing field for <see cref="OutputStartTime" /> property.</summary>
        private global::System.DateTime? _outputStartTime;

        /// <summary>
        /// Value is either an ISO-8601 formatted time stamp that indicates the starting point of the output event stream, or null
        /// to indicate that the output event stream will start whenever the streaming job is started. This property must have a value
        /// if outputStartMode is set to CustomTime.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Origin(Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.PropertyOrigin.Owned)]
        public global::System.DateTime? OutputStartTime { get => this._outputStartTime; set => this._outputStartTime = value; }

        /// <summary>Backing field for <see cref="ProvisioningState" /> property.</summary>
        private string _provisioningState;

        /// <summary>Describes the provisioning status of the streaming job.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Origin(Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.PropertyOrigin.Owned)]
        public string ProvisioningState { get => this._provisioningState; }

        /// <summary>
        /// Specifies the query that will be run in the streaming job. You can learn more about the Stream Analytics Query Language
        /// (SAQL) here: https://msdn.microsoft.com/library/azure/dn834998 . Required on PUT (CreateOrReplace) requests.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Origin(Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.PropertyOrigin.Inlined)]
        public string Query { get => ((Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.ITransformationInternal)Transformation).Query; set => ((Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.ITransformationInternal)Transformation).Query = value ?? null; }

        /// <summary>Backing field for <see cref="Sku" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IStreamingJobSku _sku;

        /// <summary>
        /// Describes the SKU of the streaming job. Required on PUT (CreateOrReplace) requests.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Origin(Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IStreamingJobSku Sku { get => (this._sku = this._sku ?? new Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.StreamingJobSku()); set => this._sku = value; }

        /// <summary>The name of the SKU. Required on PUT (CreateOrReplace) requests.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Origin(Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Support.StreamingJobSkuName? SkuName { get => ((Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IStreamingJobSkuInternal)Sku).Name; set => ((Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IStreamingJobSkuInternal)Sku).Name = value ?? ((Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Support.StreamingJobSkuName)""); }

        /// <summary>
        /// The account key for the Azure Storage account. Required on PUT (CreateOrReplace) requests.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Origin(Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.PropertyOrigin.Inlined)]
        public string StorageAccountKey { get => ((Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IExternalInternal)External).StorageAccountKey; set => ((Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IExternalInternal)External).StorageAccountKey = value ?? null; }

        /// <summary>
        /// The name of the Azure Storage account. Required on PUT (CreateOrReplace) requests.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Origin(Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.PropertyOrigin.Inlined)]
        public string StorageAccountName { get => ((Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IExternalInternal)External).StorageAccountName; set => ((Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IExternalInternal)External).StorageAccountName = value ?? null; }

        /// <summary>Specifies the number of streaming units that the streaming job uses.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Origin(Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.PropertyOrigin.Inlined)]
        public int? StreamingUnit { get => ((Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.ITransformationInternal)Transformation).StreamingUnit; set => ((Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.ITransformationInternal)Transformation).StreamingUnit = value ?? default(int); }

        /// <summary>Backing field for <see cref="Transformation" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.ITransformation _transformation;

        /// <summary>
        /// Indicates the query and the number of streaming units to use for the streaming job. The name property of the transformation
        /// is required when specifying this property in a PUT request. This property cannot be modify via a PATCH operation. You
        /// must use the PATCH API available for the individual transformation.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Origin(Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.ITransformation Transformation { get => (this._transformation = this._transformation ?? new Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.Transformation()); set => this._transformation = value; }

        [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Origin(Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.PropertyOrigin.Inlined)]
        public string TransformationETag { get => ((Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.ITransformationInternal)Transformation).ETag; set => ((Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.ITransformationInternal)Transformation).ETag = value ?? null; }

        /// <summary>Resource Id</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Origin(Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.PropertyOrigin.Inlined)]
        public string TransformationId { get => ((Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.ISubResourceInternal)Transformation).Id; }

        /// <summary>Resource name</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Origin(Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.PropertyOrigin.Inlined)]
        public string TransformationName { get => ((Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.ISubResourceInternal)Transformation).Name; }

        /// <summary>Resource type</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Origin(Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.PropertyOrigin.Inlined)]
        public string TransformationType { get => ((Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.ISubResourceInternal)Transformation).Type; }

        /// <param name="headers"></param>
        void Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Runtime.IHeaderSerializable.ReadHeaders(global::System.Net.Http.Headers.HttpResponseHeaders headers)
        {
            if (headers.TryGetValues("ETag", out var __eTagHeader0))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IStreamingJobPropertiesInternal)this).TransformationETag = System.Linq.Enumerable.FirstOrDefault(__eTagHeader0) is string __headerETagHeader0 ? __headerETagHeader0 : (string)null;
            }
        }

        /// <summary>Creates an new <see cref="StreamingJobProperties" /> instance.</summary>
        public StreamingJobProperties()
        {

        }
    }
    /// The properties that are associated with a streaming job.
    public partial interface IStreamingJobProperties :
        Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Runtime.IJsonSerializable
    {
        /// <summary>The resource id of cluster.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The resource id of cluster.",
        SerializedName = @"id",
        PossibleTypes = new [] { typeof(string) })]
        string ClusterId { get; set; }
        /// <summary>Controls certain runtime behaviors of the streaming job.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Controls certain runtime behaviors of the streaming job.",
        SerializedName = @"compatibilityLevel",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Support.CompatibilityLevel) })]
        Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Support.CompatibilityLevel? CompatibilityLevel { get; set; }
        /// <summary>
        /// Valid values are JobStorageAccount and SystemAccount. If set to JobStorageAccount, this requires the user to also specify
        /// jobStorageAccount property. .
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Valid values are JobStorageAccount and SystemAccount. If set to JobStorageAccount, this requires the user to also specify jobStorageAccount property. .",
        SerializedName = @"contentStoragePolicy",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Support.ContentStoragePolicy) })]
        Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Support.ContentStoragePolicy? ContentStoragePolicy { get; set; }
        /// <summary>
        /// Value is an ISO-8601 formatted UTC timestamp indicating when the streaming job was created.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Value is an ISO-8601 formatted UTC timestamp indicating when the streaming job was created.",
        SerializedName = @"createdDate",
        PossibleTypes = new [] { typeof(global::System.DateTime) })]
        global::System.DateTime? CreatedDate { get;  }
        /// <summary>
        /// The data locale of the stream analytics job. Value should be the name of a supported .NET Culture from the set https://msdn.microsoft.com/en-us/library/system.globalization.culturetypes(v=vs.110).aspx.
        /// Defaults to 'en-US' if none specified.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The data locale of the stream analytics job. Value should be the name of a supported .NET Culture from the set https://msdn.microsoft.com/en-us/library/system.globalization.culturetypes(v=vs.110).aspx. Defaults to 'en-US' if none specified.",
        SerializedName = @"dataLocale",
        PossibleTypes = new [] { typeof(string) })]
        string DataLocale { get; set; }
        /// <summary>
        /// The maximum tolerable delay in seconds where events arriving late could be included. Supported range is -1 to 1814399
        /// (20.23:59:59 days) and -1 is used to specify wait indefinitely. If the property is absent, it is interpreted to have a
        /// value of -1.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The maximum tolerable delay in seconds where events arriving late could be included.  Supported range is -1 to 1814399 (20.23:59:59 days) and -1 is used to specify wait indefinitely. If the property is absent, it is interpreted to have a value of -1.",
        SerializedName = @"eventsLateArrivalMaxDelayInSeconds",
        PossibleTypes = new [] { typeof(int) })]
        int? EventsLateArrivalMaxDelayInSecond { get; set; }
        /// <summary>
        /// The maximum tolerable delay in seconds where out-of-order events can be adjusted to be back in order.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The maximum tolerable delay in seconds where out-of-order events can be adjusted to be back in order.",
        SerializedName = @"eventsOutOfOrderMaxDelayInSeconds",
        PossibleTypes = new [] { typeof(int) })]
        int? EventsOutOfOrderMaxDelayInSecond { get; set; }
        /// <summary>
        /// Indicates the policy to apply to events that arrive out of order in the input event stream.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Indicates the policy to apply to events that arrive out of order in the input event stream.",
        SerializedName = @"eventsOutOfOrderPolicy",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Support.EventsOutOfOrderPolicy) })]
        Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Support.EventsOutOfOrderPolicy? EventsOutOfOrderPolicy { get; set; }

        [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"",
        SerializedName = @"container",
        PossibleTypes = new [] { typeof(string) })]
        string ExternalContainer { get; set; }

        [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"",
        SerializedName = @"path",
        PossibleTypes = new [] { typeof(string) })]
        string ExternalPath { get; set; }
        /// <summary>
        /// A list of one or more functions for the streaming job. The name property for each function is required when specifying
        /// this property in a PUT request. This property cannot be modify via a PATCH operation. You must use the PATCH API available
        /// for the individual transformation.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"A list of one or more functions for the streaming job. The name property for each function is required when specifying this property in a PUT request. This property cannot be modify via a PATCH operation. You must use the PATCH API available for the individual transformation.",
        SerializedName = @"functions",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IFunction) })]
        Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IFunction[] Function { get; set; }
        /// <summary>
        /// A list of one or more inputs to the streaming job. The name property for each input is required when specifying this property
        /// in a PUT request. This property cannot be modify via a PATCH operation. You must use the PATCH API available for the individual
        /// input.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"A list of one or more inputs to the streaming job. The name property for each input is required when specifying this property in a PUT request. This property cannot be modify via a PATCH operation. You must use the PATCH API available for the individual input.",
        SerializedName = @"inputs",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IInput) })]
        Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IInput[] Input { get; set; }
        /// <summary>
        /// A GUID uniquely identifying the streaming job. This GUID is generated upon creation of the streaming job.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"A GUID uniquely identifying the streaming job. This GUID is generated upon creation of the streaming job.",
        SerializedName = @"jobId",
        PossibleTypes = new [] { typeof(string) })]
        string JobId { get;  }
        /// <summary>Describes the state of the streaming job.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Describes the state of the streaming job.",
        SerializedName = @"jobState",
        PossibleTypes = new [] { typeof(string) })]
        string JobState { get;  }
        /// <summary>Authentication Mode.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Authentication Mode.",
        SerializedName = @"authenticationMode",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Support.AuthenticationMode) })]
        Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Support.AuthenticationMode? JobStorageAccountAuthenticationMode { get; set; }
        /// <summary>
        /// The account key for the Azure Storage account. Required on PUT (CreateOrReplace) requests.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The account key for the Azure Storage account. Required on PUT (CreateOrReplace) requests.",
        SerializedName = @"accountKey",
        PossibleTypes = new [] { typeof(string) })]
        string JobStorageAccountKey { get; set; }
        /// <summary>
        /// The name of the Azure Storage account. Required on PUT (CreateOrReplace) requests.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The name of the Azure Storage account. Required on PUT (CreateOrReplace) requests.",
        SerializedName = @"accountName",
        PossibleTypes = new [] { typeof(string) })]
        string JobStorageAccountName { get; set; }
        /// <summary>Describes the type of the job. Valid modes are `Cloud` and 'Edge'.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Describes the type of the job. Valid modes are `Cloud` and 'Edge'.",
        SerializedName = @"jobType",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Support.JobType) })]
        Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Support.JobType? JobType { get; set; }
        /// <summary>
        /// Value is either an ISO-8601 formatted timestamp indicating the last output event time of the streaming job or null indicating
        /// that output has not yet been produced. In case of multiple outputs or multiple streams, this shows the latest value in
        /// that set.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Value is either an ISO-8601 formatted timestamp indicating the last output event time of the streaming job or null indicating that output has not yet been produced. In case of multiple outputs or multiple streams, this shows the latest value in that set.",
        SerializedName = @"lastOutputEventTime",
        PossibleTypes = new [] { typeof(global::System.DateTime) })]
        global::System.DateTime? LastOutputEventTime { get;  }
        /// <summary>
        /// A list of one or more outputs for the streaming job. The name property for each output is required when specifying this
        /// property in a PUT request. This property cannot be modify via a PATCH operation. You must use the PATCH API available
        /// for the individual output.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"A list of one or more outputs for the streaming job. The name property for each output is required when specifying this property in a PUT request. This property cannot be modify via a PATCH operation. You must use the PATCH API available for the individual output.",
        SerializedName = @"outputs",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IOutput) })]
        Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IOutput[] Output { get; set; }
        /// <summary>
        /// Indicates the policy to apply to events that arrive at the output and cannot be written to the external storage due to
        /// being malformed (missing column values, column values of wrong type or size).
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Indicates the policy to apply to events that arrive at the output and cannot be written to the external storage due to being malformed (missing column values, column values of wrong type or size).",
        SerializedName = @"outputErrorPolicy",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Support.OutputErrorPolicy) })]
        Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Support.OutputErrorPolicy? OutputErrorPolicy { get; set; }
        /// <summary>
        /// This property should only be utilized when it is desired that the job be started immediately upon creation. Value may
        /// be JobStartTime, CustomTime, or LastOutputEventTime to indicate whether the starting point of the output event stream
        /// should start whenever the job is started, start at a custom user time stamp specified via the outputStartTime property,
        /// or start from the last event output time.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"This property should only be utilized when it is desired that the job be started immediately upon creation. Value may be JobStartTime, CustomTime, or LastOutputEventTime to indicate whether the starting point of the output event stream should start whenever the job is started, start at a custom user time stamp specified via the outputStartTime property, or start from the last event output time.",
        SerializedName = @"outputStartMode",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Support.OutputStartMode) })]
        Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Support.OutputStartMode? OutputStartMode { get; set; }
        /// <summary>
        /// Value is either an ISO-8601 formatted time stamp that indicates the starting point of the output event stream, or null
        /// to indicate that the output event stream will start whenever the streaming job is started. This property must have a value
        /// if outputStartMode is set to CustomTime.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Value is either an ISO-8601 formatted time stamp that indicates the starting point of the output event stream, or null to indicate that the output event stream will start whenever the streaming job is started. This property must have a value if outputStartMode is set to CustomTime.",
        SerializedName = @"outputStartTime",
        PossibleTypes = new [] { typeof(global::System.DateTime) })]
        global::System.DateTime? OutputStartTime { get; set; }
        /// <summary>Describes the provisioning status of the streaming job.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Describes the provisioning status of the streaming job.",
        SerializedName = @"provisioningState",
        PossibleTypes = new [] { typeof(string) })]
        string ProvisioningState { get;  }
        /// <summary>
        /// Specifies the query that will be run in the streaming job. You can learn more about the Stream Analytics Query Language
        /// (SAQL) here: https://msdn.microsoft.com/library/azure/dn834998 . Required on PUT (CreateOrReplace) requests.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Specifies the query that will be run in the streaming job. You can learn more about the Stream Analytics Query Language (SAQL) here: https://msdn.microsoft.com/library/azure/dn834998 . Required on PUT (CreateOrReplace) requests.",
        SerializedName = @"query",
        PossibleTypes = new [] { typeof(string) })]
        string Query { get; set; }
        /// <summary>The name of the SKU. Required on PUT (CreateOrReplace) requests.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The name of the SKU. Required on PUT (CreateOrReplace) requests.",
        SerializedName = @"name",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Support.StreamingJobSkuName) })]
        Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Support.StreamingJobSkuName? SkuName { get; set; }
        /// <summary>
        /// The account key for the Azure Storage account. Required on PUT (CreateOrReplace) requests.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The account key for the Azure Storage account. Required on PUT (CreateOrReplace) requests.",
        SerializedName = @"accountKey",
        PossibleTypes = new [] { typeof(string) })]
        string StorageAccountKey { get; set; }
        /// <summary>
        /// The name of the Azure Storage account. Required on PUT (CreateOrReplace) requests.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The name of the Azure Storage account. Required on PUT (CreateOrReplace) requests.",
        SerializedName = @"accountName",
        PossibleTypes = new [] { typeof(string) })]
        string StorageAccountName { get; set; }
        /// <summary>Specifies the number of streaming units that the streaming job uses.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Specifies the number of streaming units that the streaming job uses.",
        SerializedName = @"streamingUnits",
        PossibleTypes = new [] { typeof(int) })]
        int? StreamingUnit { get; set; }

        [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"",
        SerializedName = @"ETag",
        PossibleTypes = new [] { typeof(string) })]
        string TransformationETag { get; set; }
        /// <summary>Resource Id</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Resource Id",
        SerializedName = @"id",
        PossibleTypes = new [] { typeof(string) })]
        string TransformationId { get;  }
        /// <summary>Resource name</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Resource name",
        SerializedName = @"name",
        PossibleTypes = new [] { typeof(string) })]
        string TransformationName { get;  }
        /// <summary>Resource type</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Resource type",
        SerializedName = @"type",
        PossibleTypes = new [] { typeof(string) })]
        string TransformationType { get;  }

    }
    /// The properties that are associated with a streaming job.
    internal partial interface IStreamingJobPropertiesInternal

    {
        /// <summary>The cluster which streaming jobs will run on.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IClusterInfo Cluster { get; set; }
        /// <summary>The resource id of cluster.</summary>
        string ClusterId { get; set; }
        /// <summary>Controls certain runtime behaviors of the streaming job.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Support.CompatibilityLevel? CompatibilityLevel { get; set; }
        /// <summary>
        /// Valid values are JobStorageAccount and SystemAccount. If set to JobStorageAccount, this requires the user to also specify
        /// jobStorageAccount property. .
        /// </summary>
        Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Support.ContentStoragePolicy? ContentStoragePolicy { get; set; }
        /// <summary>
        /// Value is an ISO-8601 formatted UTC timestamp indicating when the streaming job was created.
        /// </summary>
        global::System.DateTime? CreatedDate { get; set; }
        /// <summary>
        /// The data locale of the stream analytics job. Value should be the name of a supported .NET Culture from the set https://msdn.microsoft.com/en-us/library/system.globalization.culturetypes(v=vs.110).aspx.
        /// Defaults to 'en-US' if none specified.
        /// </summary>
        string DataLocale { get; set; }
        /// <summary>
        /// The maximum tolerable delay in seconds where events arriving late could be included. Supported range is -1 to 1814399
        /// (20.23:59:59 days) and -1 is used to specify wait indefinitely. If the property is absent, it is interpreted to have a
        /// value of -1.
        /// </summary>
        int? EventsLateArrivalMaxDelayInSecond { get; set; }
        /// <summary>
        /// The maximum tolerable delay in seconds where out-of-order events can be adjusted to be back in order.
        /// </summary>
        int? EventsOutOfOrderMaxDelayInSecond { get; set; }
        /// <summary>
        /// Indicates the policy to apply to events that arrive out of order in the input event stream.
        /// </summary>
        Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Support.EventsOutOfOrderPolicy? EventsOutOfOrderPolicy { get; set; }
        /// <summary>The storage account where the custom code artifacts are located.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IExternal External { get; set; }

        string ExternalContainer { get; set; }

        string ExternalPath { get; set; }
        /// <summary>The properties that are associated with an Azure Storage account</summary>
        Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IStorageAccount ExternalStorageAccount { get; set; }
        /// <summary>
        /// A list of one or more functions for the streaming job. The name property for each function is required when specifying
        /// this property in a PUT request. This property cannot be modify via a PATCH operation. You must use the PATCH API available
        /// for the individual transformation.
        /// </summary>
        Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IFunction[] Function { get; set; }
        /// <summary>
        /// A list of one or more inputs to the streaming job. The name property for each input is required when specifying this property
        /// in a PUT request. This property cannot be modify via a PATCH operation. You must use the PATCH API available for the individual
        /// input.
        /// </summary>
        Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IInput[] Input { get; set; }
        /// <summary>
        /// A GUID uniquely identifying the streaming job. This GUID is generated upon creation of the streaming job.
        /// </summary>
        string JobId { get; set; }
        /// <summary>Describes the state of the streaming job.</summary>
        string JobState { get; set; }
        /// <summary>The properties that are associated with an Azure Storage account with MSI</summary>
        Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IJobStorageAccount JobStorageAccount { get; set; }
        /// <summary>Authentication Mode.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Support.AuthenticationMode? JobStorageAccountAuthenticationMode { get; set; }
        /// <summary>
        /// The account key for the Azure Storage account. Required on PUT (CreateOrReplace) requests.
        /// </summary>
        string JobStorageAccountKey { get; set; }
        /// <summary>
        /// The name of the Azure Storage account. Required on PUT (CreateOrReplace) requests.
        /// </summary>
        string JobStorageAccountName { get; set; }
        /// <summary>Describes the type of the job. Valid modes are `Cloud` and 'Edge'.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Support.JobType? JobType { get; set; }
        /// <summary>
        /// Value is either an ISO-8601 formatted timestamp indicating the last output event time of the streaming job or null indicating
        /// that output has not yet been produced. In case of multiple outputs or multiple streams, this shows the latest value in
        /// that set.
        /// </summary>
        global::System.DateTime? LastOutputEventTime { get; set; }
        /// <summary>
        /// A list of one or more outputs for the streaming job. The name property for each output is required when specifying this
        /// property in a PUT request. This property cannot be modify via a PATCH operation. You must use the PATCH API available
        /// for the individual output.
        /// </summary>
        Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IOutput[] Output { get; set; }
        /// <summary>
        /// Indicates the policy to apply to events that arrive at the output and cannot be written to the external storage due to
        /// being malformed (missing column values, column values of wrong type or size).
        /// </summary>
        Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Support.OutputErrorPolicy? OutputErrorPolicy { get; set; }
        /// <summary>
        /// This property should only be utilized when it is desired that the job be started immediately upon creation. Value may
        /// be JobStartTime, CustomTime, or LastOutputEventTime to indicate whether the starting point of the output event stream
        /// should start whenever the job is started, start at a custom user time stamp specified via the outputStartTime property,
        /// or start from the last event output time.
        /// </summary>
        Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Support.OutputStartMode? OutputStartMode { get; set; }
        /// <summary>
        /// Value is either an ISO-8601 formatted time stamp that indicates the starting point of the output event stream, or null
        /// to indicate that the output event stream will start whenever the streaming job is started. This property must have a value
        /// if outputStartMode is set to CustomTime.
        /// </summary>
        global::System.DateTime? OutputStartTime { get; set; }
        /// <summary>Describes the provisioning status of the streaming job.</summary>
        string ProvisioningState { get; set; }
        /// <summary>
        /// Specifies the query that will be run in the streaming job. You can learn more about the Stream Analytics Query Language
        /// (SAQL) here: https://msdn.microsoft.com/library/azure/dn834998 . Required on PUT (CreateOrReplace) requests.
        /// </summary>
        string Query { get; set; }
        /// <summary>
        /// Describes the SKU of the streaming job. Required on PUT (CreateOrReplace) requests.
        /// </summary>
        Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IStreamingJobSku Sku { get; set; }
        /// <summary>The name of the SKU. Required on PUT (CreateOrReplace) requests.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Support.StreamingJobSkuName? SkuName { get; set; }
        /// <summary>
        /// The account key for the Azure Storage account. Required on PUT (CreateOrReplace) requests.
        /// </summary>
        string StorageAccountKey { get; set; }
        /// <summary>
        /// The name of the Azure Storage account. Required on PUT (CreateOrReplace) requests.
        /// </summary>
        string StorageAccountName { get; set; }
        /// <summary>Specifies the number of streaming units that the streaming job uses.</summary>
        int? StreamingUnit { get; set; }
        /// <summary>
        /// Indicates the query and the number of streaming units to use for the streaming job. The name property of the transformation
        /// is required when specifying this property in a PUT request. This property cannot be modify via a PATCH operation. You
        /// must use the PATCH API available for the individual transformation.
        /// </summary>
        Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.ITransformation Transformation { get; set; }

        string TransformationETag { get; set; }
        /// <summary>Resource Id</summary>
        string TransformationId { get; set; }
        /// <summary>Resource name</summary>
        string TransformationName { get; set; }
        /// <summary>
        /// The properties that are associated with a transformation. Required on PUT (CreateOrReplace) requests.
        /// </summary>
        Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.ITransformationProperties TransformationProperty { get; set; }
        /// <summary>Resource type</summary>
        string TransformationType { get; set; }

    }
}