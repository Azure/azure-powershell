namespace Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Models.Api20200214Preview
{
    using static Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Runtime.Extensions;

    /// <summary>Maintenance window of a server.</summary>
    public partial class MaintenanceWindow :
        Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Models.Api20200214Preview.IMaintenanceWindow,
        Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Models.Api20200214Preview.IMaintenanceWindowInternal
    {

        /// <summary>Backing field for <see cref="CustomWindow" /> property.</summary>
        private string _customWindow;

        /// <summary>indicates whether custom window is enabled or disabled</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Origin(Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.PropertyOrigin.Owned)]
        public string CustomWindow { get => this._customWindow; set => this._customWindow = value; }

        /// <summary>Backing field for <see cref="DayOfWeek" /> property.</summary>
        private int? _dayOfWeek;

        /// <summary>day of week for maintenance window</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Origin(Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.PropertyOrigin.Owned)]
        public int? DayOfWeek { get => this._dayOfWeek; set => this._dayOfWeek = value; }

        /// <summary>Backing field for <see cref="StartHour" /> property.</summary>
        private int? _startHour;

        /// <summary>start hour for maintenance window</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Origin(Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.PropertyOrigin.Owned)]
        public int? StartHour { get => this._startHour; set => this._startHour = value; }

        /// <summary>Backing field for <see cref="StartMinute" /> property.</summary>
        private int? _startMinute;

        /// <summary>start minute for maintenance window</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Origin(Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.PropertyOrigin.Owned)]
        public int? StartMinute { get => this._startMinute; set => this._startMinute = value; }

        /// <summary>Creates an new <see cref="MaintenanceWindow" /> instance.</summary>
        public MaintenanceWindow()
        {

        }
    }
    /// Maintenance window of a server.
    public partial interface IMaintenanceWindow :
        Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Runtime.IJsonSerializable
    {
        /// <summary>indicates whether custom window is enabled or disabled</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"indicates whether custom window is enabled or disabled",
        SerializedName = @"customWindow",
        PossibleTypes = new [] { typeof(string) })]
        string CustomWindow { get; set; }
        /// <summary>day of week for maintenance window</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"day of week for maintenance window",
        SerializedName = @"dayOfWeek",
        PossibleTypes = new [] { typeof(int) })]
        int? DayOfWeek { get; set; }
        /// <summary>start hour for maintenance window</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"start hour for maintenance window",
        SerializedName = @"startHour",
        PossibleTypes = new [] { typeof(int) })]
        int? StartHour { get; set; }
        /// <summary>start minute for maintenance window</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"start minute for maintenance window",
        SerializedName = @"startMinute",
        PossibleTypes = new [] { typeof(int) })]
        int? StartMinute { get; set; }

    }
    /// Maintenance window of a server.
    internal partial interface IMaintenanceWindowInternal

    {
        /// <summary>indicates whether custom window is enabled or disabled</summary>
        string CustomWindow { get; set; }
        /// <summary>day of week for maintenance window</summary>
        int? DayOfWeek { get; set; }
        /// <summary>start hour for maintenance window</summary>
        int? StartHour { get; set; }
        /// <summary>start minute for maintenance window</summary>
        int? StartMinute { get; set; }

    }
}