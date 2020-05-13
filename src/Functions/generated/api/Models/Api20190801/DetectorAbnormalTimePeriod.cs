namespace Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Extensions;

    /// <summary>Class representing Abnormal Time Period detected.</summary>
    public partial class DetectorAbnormalTimePeriod :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDetectorAbnormalTimePeriod,
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDetectorAbnormalTimePeriodInternal
    {

        /// <summary>Backing field for <see cref="EndTime" /> property.</summary>
        private global::System.DateTime? _endTime;

        /// <summary>End time of the correlated event</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public global::System.DateTime? EndTime { get => this._endTime; set => this._endTime = value; }

        /// <summary>Backing field for <see cref="Message" /> property.</summary>
        private string _message;

        /// <summary>Message describing the event</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public string Message { get => this._message; set => this._message = value; }

        /// <summary>Backing field for <see cref="MetaData" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.INameValuePair[][] _metaData;

        /// <summary>Downtime metadata</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.INameValuePair[][] MetaData { get => this._metaData; set => this._metaData = value; }

        /// <summary>Backing field for <see cref="Priority" /> property.</summary>
        private double? _priority;

        /// <summary>Represents the rank of the Detector</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public double? Priority { get => this._priority; set => this._priority = value; }

        /// <summary>Backing field for <see cref="Solution" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISolution[] _solution;

        /// <summary>List of proposed solutions</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISolution[] Solution { get => this._solution; set => this._solution = value; }

        /// <summary>Backing field for <see cref="Source" /> property.</summary>
        private string _source;

        /// <summary>Represents the name of the Detector</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public string Source { get => this._source; set => this._source = value; }

        /// <summary>Backing field for <see cref="StartTime" /> property.</summary>
        private global::System.DateTime? _startTime;

        /// <summary>Start time of the correlated event</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public global::System.DateTime? StartTime { get => this._startTime; set => this._startTime = value; }

        /// <summary>Backing field for <see cref="Type" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.IssueType? _type;

        /// <summary>Represents the type of the Detector</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.IssueType? Type { get => this._type; set => this._type = value; }

        /// <summary>Creates an new <see cref="DetectorAbnormalTimePeriod" /> instance.</summary>
        public DetectorAbnormalTimePeriod()
        {

        }
    }
    /// Class representing Abnormal Time Period detected.
    public partial interface IDetectorAbnormalTimePeriod :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.IJsonSerializable
    {
        /// <summary>End time of the correlated event</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"End time of the correlated event",
        SerializedName = @"endTime",
        PossibleTypes = new [] { typeof(global::System.DateTime) })]
        global::System.DateTime? EndTime { get; set; }
        /// <summary>Message describing the event</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Message describing the event",
        SerializedName = @"message",
        PossibleTypes = new [] { typeof(string) })]
        string Message { get; set; }
        /// <summary>Downtime metadata</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Downtime metadata",
        SerializedName = @"metaData",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.INameValuePair) })]
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.INameValuePair[][] MetaData { get; set; }
        /// <summary>Represents the rank of the Detector</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Represents the rank of the Detector",
        SerializedName = @"priority",
        PossibleTypes = new [] { typeof(double) })]
        double? Priority { get; set; }
        /// <summary>List of proposed solutions</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"List of proposed solutions",
        SerializedName = @"solutions",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISolution) })]
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISolution[] Solution { get; set; }
        /// <summary>Represents the name of the Detector</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Represents the name of the Detector",
        SerializedName = @"source",
        PossibleTypes = new [] { typeof(string) })]
        string Source { get; set; }
        /// <summary>Start time of the correlated event</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Start time of the correlated event",
        SerializedName = @"startTime",
        PossibleTypes = new [] { typeof(global::System.DateTime) })]
        global::System.DateTime? StartTime { get; set; }
        /// <summary>Represents the type of the Detector</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Represents the type of the Detector",
        SerializedName = @"type",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.IssueType) })]
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.IssueType? Type { get; set; }

    }
    /// Class representing Abnormal Time Period detected.
    internal partial interface IDetectorAbnormalTimePeriodInternal

    {
        /// <summary>End time of the correlated event</summary>
        global::System.DateTime? EndTime { get; set; }
        /// <summary>Message describing the event</summary>
        string Message { get; set; }
        /// <summary>Downtime metadata</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.INameValuePair[][] MetaData { get; set; }
        /// <summary>Represents the rank of the Detector</summary>
        double? Priority { get; set; }
        /// <summary>List of proposed solutions</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISolution[] Solution { get; set; }
        /// <summary>Represents the name of the Detector</summary>
        string Source { get; set; }
        /// <summary>Start time of the correlated event</summary>
        global::System.DateTime? StartTime { get; set; }
        /// <summary>Represents the type of the Detector</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.IssueType? Type { get; set; }

    }
}