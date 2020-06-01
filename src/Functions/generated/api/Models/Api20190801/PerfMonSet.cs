namespace Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Extensions;

    /// <summary>Metric information.</summary>
    public partial class PerfMonSet :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IPerfMonSet,
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IPerfMonSetInternal
    {

        /// <summary>Backing field for <see cref="EndTime" /> property.</summary>
        private global::System.DateTime? _endTime;

        /// <summary>End time of the period.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public global::System.DateTime? EndTime { get => this._endTime; set => this._endTime = value; }

        /// <summary>Backing field for <see cref="Name" /> property.</summary>
        private string _name;

        /// <summary>Unique key name of the counter.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public string Name { get => this._name; set => this._name = value; }

        /// <summary>Backing field for <see cref="StartTime" /> property.</summary>
        private global::System.DateTime? _startTime;

        /// <summary>Start time of the period.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public global::System.DateTime? StartTime { get => this._startTime; set => this._startTime = value; }

        /// <summary>Backing field for <see cref="TimeGrain" /> property.</summary>
        private string _timeGrain;

        /// <summary>Presented time grain.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public string TimeGrain { get => this._timeGrain; set => this._timeGrain = value; }

        /// <summary>Backing field for <see cref="Value" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IPerfMonSample[] _value;

        /// <summary>Collection of workers that are active during this time.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IPerfMonSample[] Value { get => this._value; set => this._value = value; }

        /// <summary>Creates an new <see cref="PerfMonSet" /> instance.</summary>
        public PerfMonSet()
        {

        }
    }
    /// Metric information.
    public partial interface IPerfMonSet :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.IJsonSerializable
    {
        /// <summary>End time of the period.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"End time of the period.",
        SerializedName = @"endTime",
        PossibleTypes = new [] { typeof(global::System.DateTime) })]
        global::System.DateTime? EndTime { get; set; }
        /// <summary>Unique key name of the counter.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Unique key name of the counter.",
        SerializedName = @"name",
        PossibleTypes = new [] { typeof(string) })]
        string Name { get; set; }
        /// <summary>Start time of the period.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Start time of the period.",
        SerializedName = @"startTime",
        PossibleTypes = new [] { typeof(global::System.DateTime) })]
        global::System.DateTime? StartTime { get; set; }
        /// <summary>Presented time grain.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Presented time grain.",
        SerializedName = @"timeGrain",
        PossibleTypes = new [] { typeof(string) })]
        string TimeGrain { get; set; }
        /// <summary>Collection of workers that are active during this time.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Collection of workers that are active during this time.",
        SerializedName = @"values",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IPerfMonSample) })]
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IPerfMonSample[] Value { get; set; }

    }
    /// Metric information.
    internal partial interface IPerfMonSetInternal

    {
        /// <summary>End time of the period.</summary>
        global::System.DateTime? EndTime { get; set; }
        /// <summary>Unique key name of the counter.</summary>
        string Name { get; set; }
        /// <summary>Start time of the period.</summary>
        global::System.DateTime? StartTime { get; set; }
        /// <summary>Presented time grain.</summary>
        string TimeGrain { get; set; }
        /// <summary>Collection of workers that are active during this time.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IPerfMonSample[] Value { get; set; }

    }
}