namespace Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Extensions;

    /// <summary>DiagnosticAnalysis resource specific properties</summary>
    public partial class DiagnosticAnalysisProperties :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDiagnosticAnalysisProperties,
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDiagnosticAnalysisPropertiesInternal
    {

        /// <summary>Backing field for <see cref="AbnormalTimePeriod" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAbnormalTimePeriod[] _abnormalTimePeriod;

        /// <summary>List of time periods.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAbnormalTimePeriod[] AbnormalTimePeriod { get => this._abnormalTimePeriod; set => this._abnormalTimePeriod = value; }

        /// <summary>Backing field for <see cref="EndTime" /> property.</summary>
        private global::System.DateTime? _endTime;

        /// <summary>End time of the period</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public global::System.DateTime? EndTime { get => this._endTime; set => this._endTime = value; }

        /// <summary>Backing field for <see cref="NonCorrelatedDetector" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDetectorDefinition[] _nonCorrelatedDetector;

        /// <summary>Data by each detector for detectors that did not corelate</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDetectorDefinition[] NonCorrelatedDetector { get => this._nonCorrelatedDetector; set => this._nonCorrelatedDetector = value; }

        /// <summary>Backing field for <see cref="Payload" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAnalysisData[] _payload;

        /// <summary>Data by each detector</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAnalysisData[] Payload { get => this._payload; set => this._payload = value; }

        /// <summary>Backing field for <see cref="StartTime" /> property.</summary>
        private global::System.DateTime? _startTime;

        /// <summary>Start time of the period</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public global::System.DateTime? StartTime { get => this._startTime; set => this._startTime = value; }

        /// <summary>Creates an new <see cref="DiagnosticAnalysisProperties" /> instance.</summary>
        public DiagnosticAnalysisProperties()
        {

        }
    }
    /// DiagnosticAnalysis resource specific properties
    public partial interface IDiagnosticAnalysisProperties :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.IJsonSerializable
    {
        /// <summary>List of time periods.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"List of time periods.",
        SerializedName = @"abnormalTimePeriods",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAbnormalTimePeriod) })]
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAbnormalTimePeriod[] AbnormalTimePeriod { get; set; }
        /// <summary>End time of the period</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"End time of the period",
        SerializedName = @"endTime",
        PossibleTypes = new [] { typeof(global::System.DateTime) })]
        global::System.DateTime? EndTime { get; set; }
        /// <summary>Data by each detector for detectors that did not corelate</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Data by each detector for detectors that did not corelate",
        SerializedName = @"nonCorrelatedDetectors",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDetectorDefinition) })]
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDetectorDefinition[] NonCorrelatedDetector { get; set; }
        /// <summary>Data by each detector</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Data by each detector",
        SerializedName = @"payload",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAnalysisData) })]
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAnalysisData[] Payload { get; set; }
        /// <summary>Start time of the period</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Start time of the period",
        SerializedName = @"startTime",
        PossibleTypes = new [] { typeof(global::System.DateTime) })]
        global::System.DateTime? StartTime { get; set; }

    }
    /// DiagnosticAnalysis resource specific properties
    internal partial interface IDiagnosticAnalysisPropertiesInternal

    {
        /// <summary>List of time periods.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAbnormalTimePeriod[] AbnormalTimePeriod { get; set; }
        /// <summary>End time of the period</summary>
        global::System.DateTime? EndTime { get; set; }
        /// <summary>Data by each detector for detectors that did not corelate</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDetectorDefinition[] NonCorrelatedDetector { get; set; }
        /// <summary>Data by each detector</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAnalysisData[] Payload { get; set; }
        /// <summary>Start time of the period</summary>
        global::System.DateTime? StartTime { get; set; }

    }
}