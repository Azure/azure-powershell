namespace Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview
{
    using static Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Runtime.Extensions;

    /// <summary>Parameters supplied to the Start Streaming Job operation.</summary>
    public partial class StartStreamingJobParameters :
        Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IStartStreamingJobParameters,
        Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IStartStreamingJobParametersInternal
    {

        /// <summary>Backing field for <see cref="OutputStartMode" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Support.OutputStartMode? _outputStartMode;

        /// <summary>
        /// Value may be JobStartTime, CustomTime, or LastOutputEventTime to indicate whether the starting point of the output event
        /// stream should start whenever the job is started, start at a custom user time stamp specified via the outputStartTime property,
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

        /// <summary>Creates an new <see cref="StartStreamingJobParameters" /> instance.</summary>
        public StartStreamingJobParameters()
        {

        }
    }
    /// Parameters supplied to the Start Streaming Job operation.
    public partial interface IStartStreamingJobParameters :
        Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Runtime.IJsonSerializable
    {
        /// <summary>
        /// Value may be JobStartTime, CustomTime, or LastOutputEventTime to indicate whether the starting point of the output event
        /// stream should start whenever the job is started, start at a custom user time stamp specified via the outputStartTime property,
        /// or start from the last event output time.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Value may be JobStartTime, CustomTime, or LastOutputEventTime to indicate whether the starting point of the output event stream should start whenever the job is started, start at a custom user time stamp specified via the outputStartTime property, or start from the last event output time.",
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

    }
    /// Parameters supplied to the Start Streaming Job operation.
    internal partial interface IStartStreamingJobParametersInternal

    {
        /// <summary>
        /// Value may be JobStartTime, CustomTime, or LastOutputEventTime to indicate whether the starting point of the output event
        /// stream should start whenever the job is started, start at a custom user time stamp specified via the outputStartTime property,
        /// or start from the last event output time.
        /// </summary>
        Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Support.OutputStartMode? OutputStartMode { get; set; }
        /// <summary>
        /// Value is either an ISO-8601 formatted time stamp that indicates the starting point of the output event stream, or null
        /// to indicate that the output event stream will start whenever the streaming job is started. This property must have a value
        /// if outputStartMode is set to CustomTime.
        /// </summary>
        global::System.DateTime? OutputStartTime { get; set; }

    }
}