namespace Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Models.Api20210201Preview
{
    using static Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Runtime.Extensions;

    /// <summary>Scaling plan schedule.</summary>
    public partial class ScalingSchedule :
        Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Models.Api20210201Preview.IScalingSchedule,
        Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Models.Api20210201Preview.IScalingScheduleInternal
    {

        /// <summary>Backing field for <see cref="DaysOfWeek" /> property.</summary>
        private string[] _daysOfWeek;

        /// <summary>Set of days of the week on which this schedule is active.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Origin(Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.PropertyOrigin.Owned)]
        public string[] DaysOfWeek { get => this._daysOfWeek; set => this._daysOfWeek = value; }

        /// <summary>Backing field for <see cref="Name" /> property.</summary>
        private string _name;

        /// <summary>Name of the scaling schedule.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Origin(Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.PropertyOrigin.Owned)]
        public string Name { get => this._name; set => this._name = value; }

        /// <summary>Backing field for <see cref="OffPeakLoadBalancingAlgorithm" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Support.SessionHostLoadBalancingAlgorithm? _offPeakLoadBalancingAlgorithm;

        /// <summary>Load balancing algorithm for off-peak period.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Origin(Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Support.SessionHostLoadBalancingAlgorithm? OffPeakLoadBalancingAlgorithm { get => this._offPeakLoadBalancingAlgorithm; set => this._offPeakLoadBalancingAlgorithm = value; }

        /// <summary>Backing field for <see cref="OffPeakStartTime" /> property.</summary>
        private global::System.DateTime? _offPeakStartTime;

        /// <summary>Starting time for off-peak period.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Origin(Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.PropertyOrigin.Owned)]
        public global::System.DateTime? OffPeakStartTime { get => this._offPeakStartTime; set => this._offPeakStartTime = value; }

        /// <summary>Backing field for <see cref="PeakLoadBalancingAlgorithm" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Support.SessionHostLoadBalancingAlgorithm? _peakLoadBalancingAlgorithm;

        /// <summary>Load balancing algorithm for peak period.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Origin(Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Support.SessionHostLoadBalancingAlgorithm? PeakLoadBalancingAlgorithm { get => this._peakLoadBalancingAlgorithm; set => this._peakLoadBalancingAlgorithm = value; }

        /// <summary>Backing field for <see cref="PeakStartTime" /> property.</summary>
        private global::System.DateTime? _peakStartTime;

        /// <summary>Starting time for peak period.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Origin(Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.PropertyOrigin.Owned)]
        public global::System.DateTime? PeakStartTime { get => this._peakStartTime; set => this._peakStartTime = value; }

        /// <summary>Backing field for <see cref="RampDownCapacityThresholdPct" /> property.</summary>
        private int? _rampDownCapacityThresholdPct;

        /// <summary>Capacity threshold for ramp down period.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Origin(Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.PropertyOrigin.Owned)]
        public int? RampDownCapacityThresholdPct { get => this._rampDownCapacityThresholdPct; set => this._rampDownCapacityThresholdPct = value; }

        /// <summary>Backing field for <see cref="RampDownForceLogoffUser" /> property.</summary>
        private bool? _rampDownForceLogoffUser;

        /// <summary>Should users be logged off forcefully from hosts.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Origin(Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.PropertyOrigin.Owned)]
        public bool? RampDownForceLogoffUser { get => this._rampDownForceLogoffUser; set => this._rampDownForceLogoffUser = value; }

        /// <summary>Backing field for <see cref="RampDownLoadBalancingAlgorithm" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Support.SessionHostLoadBalancingAlgorithm? _rampDownLoadBalancingAlgorithm;

        /// <summary>Load balancing algorithm for ramp down period.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Origin(Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Support.SessionHostLoadBalancingAlgorithm? RampDownLoadBalancingAlgorithm { get => this._rampDownLoadBalancingAlgorithm; set => this._rampDownLoadBalancingAlgorithm = value; }

        /// <summary>Backing field for <see cref="RampDownMinimumHostsPct" /> property.</summary>
        private int? _rampDownMinimumHostsPct;

        /// <summary>Minimum host percentage for ramp down period.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Origin(Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.PropertyOrigin.Owned)]
        public int? RampDownMinimumHostsPct { get => this._rampDownMinimumHostsPct; set => this._rampDownMinimumHostsPct = value; }

        /// <summary>Backing field for <see cref="RampDownNotificationMessage" /> property.</summary>
        private string _rampDownNotificationMessage;

        /// <summary>Notification message for users during ramp down period.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Origin(Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.PropertyOrigin.Owned)]
        public string RampDownNotificationMessage { get => this._rampDownNotificationMessage; set => this._rampDownNotificationMessage = value; }

        /// <summary>Backing field for <see cref="RampDownStartTime" /> property.</summary>
        private global::System.DateTime? _rampDownStartTime;

        /// <summary>Starting time for ramp down period.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Origin(Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.PropertyOrigin.Owned)]
        public global::System.DateTime? RampDownStartTime { get => this._rampDownStartTime; set => this._rampDownStartTime = value; }

        /// <summary>Backing field for <see cref="RampDownStopHostsWhen" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Support.StopHostsWhen? _rampDownStopHostsWhen;

        /// <summary>Specifies when to stop hosts during ramp down period.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Origin(Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Support.StopHostsWhen? RampDownStopHostsWhen { get => this._rampDownStopHostsWhen; set => this._rampDownStopHostsWhen = value; }

        /// <summary>Backing field for <see cref="RampDownWaitTimeMinute" /> property.</summary>
        private int? _rampDownWaitTimeMinute;

        /// <summary>Number of minutes to wait to stop hosts during ramp down period.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Origin(Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.PropertyOrigin.Owned)]
        public int? RampDownWaitTimeMinute { get => this._rampDownWaitTimeMinute; set => this._rampDownWaitTimeMinute = value; }

        /// <summary>Backing field for <see cref="RampUpCapacityThresholdPct" /> property.</summary>
        private int? _rampUpCapacityThresholdPct;

        /// <summary>Capacity threshold for ramp up period.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Origin(Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.PropertyOrigin.Owned)]
        public int? RampUpCapacityThresholdPct { get => this._rampUpCapacityThresholdPct; set => this._rampUpCapacityThresholdPct = value; }

        /// <summary>Backing field for <see cref="RampUpLoadBalancingAlgorithm" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Support.SessionHostLoadBalancingAlgorithm? _rampUpLoadBalancingAlgorithm;

        /// <summary>Load balancing algorithm for ramp up period.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Origin(Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Support.SessionHostLoadBalancingAlgorithm? RampUpLoadBalancingAlgorithm { get => this._rampUpLoadBalancingAlgorithm; set => this._rampUpLoadBalancingAlgorithm = value; }

        /// <summary>Backing field for <see cref="RampUpMinimumHostsPct" /> property.</summary>
        private int? _rampUpMinimumHostsPct;

        /// <summary>Minimum host percentage for ramp up period.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Origin(Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.PropertyOrigin.Owned)]
        public int? RampUpMinimumHostsPct { get => this._rampUpMinimumHostsPct; set => this._rampUpMinimumHostsPct = value; }

        /// <summary>Backing field for <see cref="RampUpStartTime" /> property.</summary>
        private global::System.DateTime? _rampUpStartTime;

        /// <summary>Starting time for ramp up period.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Origin(Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.PropertyOrigin.Owned)]
        public global::System.DateTime? RampUpStartTime { get => this._rampUpStartTime; set => this._rampUpStartTime = value; }

        /// <summary>Creates an new <see cref="ScalingSchedule" /> instance.</summary>
        public ScalingSchedule()
        {

        }
    }
    /// Scaling plan schedule.
    public partial interface IScalingSchedule :
        Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Runtime.IJsonSerializable
    {
        /// <summary>Set of days of the week on which this schedule is active.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Set of days of the week on which this schedule is active.",
        SerializedName = @"daysOfWeek",
        PossibleTypes = new [] { typeof(string) })]
        string[] DaysOfWeek { get; set; }
        /// <summary>Name of the scaling schedule.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Name of the scaling schedule.",
        SerializedName = @"name",
        PossibleTypes = new [] { typeof(string) })]
        string Name { get; set; }
        /// <summary>Load balancing algorithm for off-peak period.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Load balancing algorithm for off-peak period.",
        SerializedName = @"offPeakLoadBalancingAlgorithm",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Support.SessionHostLoadBalancingAlgorithm) })]
        Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Support.SessionHostLoadBalancingAlgorithm? OffPeakLoadBalancingAlgorithm { get; set; }
        /// <summary>Starting time for off-peak period.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Starting time for off-peak period.",
        SerializedName = @"offPeakStartTime",
        PossibleTypes = new [] { typeof(global::System.DateTime) })]
        global::System.DateTime? OffPeakStartTime { get; set; }
        /// <summary>Load balancing algorithm for peak period.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Load balancing algorithm for peak period.",
        SerializedName = @"peakLoadBalancingAlgorithm",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Support.SessionHostLoadBalancingAlgorithm) })]
        Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Support.SessionHostLoadBalancingAlgorithm? PeakLoadBalancingAlgorithm { get; set; }
        /// <summary>Starting time for peak period.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Starting time for peak period.",
        SerializedName = @"peakStartTime",
        PossibleTypes = new [] { typeof(global::System.DateTime) })]
        global::System.DateTime? PeakStartTime { get; set; }
        /// <summary>Capacity threshold for ramp down period.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Capacity threshold for ramp down period.",
        SerializedName = @"rampDownCapacityThresholdPct",
        PossibleTypes = new [] { typeof(int) })]
        int? RampDownCapacityThresholdPct { get; set; }
        /// <summary>Should users be logged off forcefully from hosts.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Should users be logged off forcefully from hosts.",
        SerializedName = @"rampDownForceLogoffUsers",
        PossibleTypes = new [] { typeof(bool) })]
        bool? RampDownForceLogoffUser { get; set; }
        /// <summary>Load balancing algorithm for ramp down period.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Load balancing algorithm for ramp down period.",
        SerializedName = @"rampDownLoadBalancingAlgorithm",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Support.SessionHostLoadBalancingAlgorithm) })]
        Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Support.SessionHostLoadBalancingAlgorithm? RampDownLoadBalancingAlgorithm { get; set; }
        /// <summary>Minimum host percentage for ramp down period.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Minimum host percentage for ramp down period.",
        SerializedName = @"rampDownMinimumHostsPct",
        PossibleTypes = new [] { typeof(int) })]
        int? RampDownMinimumHostsPct { get; set; }
        /// <summary>Notification message for users during ramp down period.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Notification message for users during ramp down period.",
        SerializedName = @"rampDownNotificationMessage",
        PossibleTypes = new [] { typeof(string) })]
        string RampDownNotificationMessage { get; set; }
        /// <summary>Starting time for ramp down period.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Starting time for ramp down period.",
        SerializedName = @"rampDownStartTime",
        PossibleTypes = new [] { typeof(global::System.DateTime) })]
        global::System.DateTime? RampDownStartTime { get; set; }
        /// <summary>Specifies when to stop hosts during ramp down period.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Specifies when to stop hosts during ramp down period.",
        SerializedName = @"rampDownStopHostsWhen",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Support.StopHostsWhen) })]
        Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Support.StopHostsWhen? RampDownStopHostsWhen { get; set; }
        /// <summary>Number of minutes to wait to stop hosts during ramp down period.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Number of minutes to wait to stop hosts during ramp down period.",
        SerializedName = @"rampDownWaitTimeMinutes",
        PossibleTypes = new [] { typeof(int) })]
        int? RampDownWaitTimeMinute { get; set; }
        /// <summary>Capacity threshold for ramp up period.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Capacity threshold for ramp up period.",
        SerializedName = @"rampUpCapacityThresholdPct",
        PossibleTypes = new [] { typeof(int) })]
        int? RampUpCapacityThresholdPct { get; set; }
        /// <summary>Load balancing algorithm for ramp up period.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Load balancing algorithm for ramp up period.",
        SerializedName = @"rampUpLoadBalancingAlgorithm",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Support.SessionHostLoadBalancingAlgorithm) })]
        Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Support.SessionHostLoadBalancingAlgorithm? RampUpLoadBalancingAlgorithm { get; set; }
        /// <summary>Minimum host percentage for ramp up period.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Minimum host percentage for ramp up period.",
        SerializedName = @"rampUpMinimumHostsPct",
        PossibleTypes = new [] { typeof(int) })]
        int? RampUpMinimumHostsPct { get; set; }
        /// <summary>Starting time for ramp up period.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Starting time for ramp up period.",
        SerializedName = @"rampUpStartTime",
        PossibleTypes = new [] { typeof(global::System.DateTime) })]
        global::System.DateTime? RampUpStartTime { get; set; }

    }
    /// Scaling plan schedule.
    internal partial interface IScalingScheduleInternal

    {
        /// <summary>Set of days of the week on which this schedule is active.</summary>
        string[] DaysOfWeek { get; set; }
        /// <summary>Name of the scaling schedule.</summary>
        string Name { get; set; }
        /// <summary>Load balancing algorithm for off-peak period.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Support.SessionHostLoadBalancingAlgorithm? OffPeakLoadBalancingAlgorithm { get; set; }
        /// <summary>Starting time for off-peak period.</summary>
        global::System.DateTime? OffPeakStartTime { get; set; }
        /// <summary>Load balancing algorithm for peak period.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Support.SessionHostLoadBalancingAlgorithm? PeakLoadBalancingAlgorithm { get; set; }
        /// <summary>Starting time for peak period.</summary>
        global::System.DateTime? PeakStartTime { get; set; }
        /// <summary>Capacity threshold for ramp down period.</summary>
        int? RampDownCapacityThresholdPct { get; set; }
        /// <summary>Should users be logged off forcefully from hosts.</summary>
        bool? RampDownForceLogoffUser { get; set; }
        /// <summary>Load balancing algorithm for ramp down period.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Support.SessionHostLoadBalancingAlgorithm? RampDownLoadBalancingAlgorithm { get; set; }
        /// <summary>Minimum host percentage for ramp down period.</summary>
        int? RampDownMinimumHostsPct { get; set; }
        /// <summary>Notification message for users during ramp down period.</summary>
        string RampDownNotificationMessage { get; set; }
        /// <summary>Starting time for ramp down period.</summary>
        global::System.DateTime? RampDownStartTime { get; set; }
        /// <summary>Specifies when to stop hosts during ramp down period.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Support.StopHostsWhen? RampDownStopHostsWhen { get; set; }
        /// <summary>Number of minutes to wait to stop hosts during ramp down period.</summary>
        int? RampDownWaitTimeMinute { get; set; }
        /// <summary>Capacity threshold for ramp up period.</summary>
        int? RampUpCapacityThresholdPct { get; set; }
        /// <summary>Load balancing algorithm for ramp up period.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Support.SessionHostLoadBalancingAlgorithm? RampUpLoadBalancingAlgorithm { get; set; }
        /// <summary>Minimum host percentage for ramp up period.</summary>
        int? RampUpMinimumHostsPct { get; set; }
        /// <summary>Starting time for ramp up period.</summary>
        global::System.DateTime? RampUpStartTime { get; set; }

    }
}