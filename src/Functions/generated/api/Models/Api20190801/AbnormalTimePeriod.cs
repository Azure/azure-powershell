namespace Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Extensions;

    /// <summary>Class representing Abnormal Time Period identified in diagnosis</summary>
    public partial class AbnormalTimePeriod :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAbnormalTimePeriod,
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAbnormalTimePeriodInternal
    {

        /// <summary>Backing field for <see cref="EndTime" /> property.</summary>
        private global::System.DateTime? _endTime;

        /// <summary>End time of the downtime</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public global::System.DateTime? EndTime { get => this._endTime; set => this._endTime = value; }

        /// <summary>Backing field for <see cref="Event" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDetectorAbnormalTimePeriod[] _event;

        /// <summary>List of Possible Cause of downtime</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDetectorAbnormalTimePeriod[] Event { get => this._event; set => this._event = value; }

        /// <summary>Backing field for <see cref="Solution" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISolution[] _solution;

        /// <summary>List of proposed solutions</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISolution[] Solution { get => this._solution; set => this._solution = value; }

        /// <summary>Backing field for <see cref="StartTime" /> property.</summary>
        private global::System.DateTime? _startTime;

        /// <summary>Start time of the downtime</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public global::System.DateTime? StartTime { get => this._startTime; set => this._startTime = value; }

        /// <summary>Creates an new <see cref="AbnormalTimePeriod" /> instance.</summary>
        public AbnormalTimePeriod()
        {

        }
    }
    /// Class representing Abnormal Time Period identified in diagnosis
    public partial interface IAbnormalTimePeriod :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.IJsonSerializable
    {
        /// <summary>End time of the downtime</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"End time of the downtime",
        SerializedName = @"endTime",
        PossibleTypes = new [] { typeof(global::System.DateTime) })]
        global::System.DateTime? EndTime { get; set; }
        /// <summary>List of Possible Cause of downtime</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"List of Possible Cause of downtime",
        SerializedName = @"events",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDetectorAbnormalTimePeriod) })]
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDetectorAbnormalTimePeriod[] Event { get; set; }
        /// <summary>List of proposed solutions</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"List of proposed solutions",
        SerializedName = @"solutions",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISolution) })]
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISolution[] Solution { get; set; }
        /// <summary>Start time of the downtime</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Start time of the downtime",
        SerializedName = @"startTime",
        PossibleTypes = new [] { typeof(global::System.DateTime) })]
        global::System.DateTime? StartTime { get; set; }

    }
    /// Class representing Abnormal Time Period identified in diagnosis
    internal partial interface IAbnormalTimePeriodInternal

    {
        /// <summary>End time of the downtime</summary>
        global::System.DateTime? EndTime { get; set; }
        /// <summary>List of Possible Cause of downtime</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDetectorAbnormalTimePeriod[] Event { get; set; }
        /// <summary>List of proposed solutions</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISolution[] Solution { get; set; }
        /// <summary>Start time of the downtime</summary>
        global::System.DateTime? StartTime { get; set; }

    }
}