// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
// Changes may cause incorrect behavior and will be lost if the code is regenerated.
namespace Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models
{
    using static Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Extensions;

    /// <summary>Maintenance window properties of a server.</summary>
    public partial class MaintenanceWindow :
        Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMaintenanceWindow,
        Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMaintenanceWindowInternal
    {

        /// <summary>Backing field for <see cref="CustomWindow" /> property.</summary>
        private string _customWindow;

        /// <summary>Indicates whether custom window is enabled or disabled.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Origin(Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PropertyOrigin.Owned)]
        public string CustomWindow { get => this._customWindow; set => this._customWindow = value; }

        /// <summary>Backing field for <see cref="DayOfWeek" /> property.</summary>
        private int? _dayOfWeek;

        /// <summary>Day of the week to be used for maintenance window.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Origin(Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PropertyOrigin.Owned)]
        public int? DayOfWeek { get => this._dayOfWeek; set => this._dayOfWeek = value; }

        /// <summary>Backing field for <see cref="StartHour" /> property.</summary>
        private int? _startHour;

        /// <summary>Start hour to be used for maintenance window.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Origin(Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PropertyOrigin.Owned)]
        public int? StartHour { get => this._startHour; set => this._startHour = value; }

        /// <summary>Backing field for <see cref="StartMinute" /> property.</summary>
        private int? _startMinute;

        /// <summary>Start minute to be used for maintenance window.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Origin(Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PropertyOrigin.Owned)]
        public int? StartMinute { get => this._startMinute; set => this._startMinute = value; }

        /// <summary>Creates an new <see cref="MaintenanceWindow" /> instance.</summary>
        public MaintenanceWindow()
        {

        }
    }
    /// Maintenance window properties of a server.
    public partial interface IMaintenanceWindow :
        Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.IJsonSerializable
    {
        /// <summary>Indicates whether custom window is enabled or disabled.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"Indicates whether custom window is enabled or disabled.",
        SerializedName = @"customWindow",
        PossibleTypes = new [] { typeof(string) })]
        string CustomWindow { get; set; }
        /// <summary>Day of the week to be used for maintenance window.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"Day of the week to be used for maintenance window.",
        SerializedName = @"dayOfWeek",
        PossibleTypes = new [] { typeof(int) })]
        int? DayOfWeek { get; set; }
        /// <summary>Start hour to be used for maintenance window.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"Start hour to be used for maintenance window.",
        SerializedName = @"startHour",
        PossibleTypes = new [] { typeof(int) })]
        int? StartHour { get; set; }
        /// <summary>Start minute to be used for maintenance window.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"Start minute to be used for maintenance window.",
        SerializedName = @"startMinute",
        PossibleTypes = new [] { typeof(int) })]
        int? StartMinute { get; set; }

    }
    /// Maintenance window properties of a server.
    internal partial interface IMaintenanceWindowInternal

    {
        /// <summary>Indicates whether custom window is enabled or disabled.</summary>
        string CustomWindow { get; set; }
        /// <summary>Day of the week to be used for maintenance window.</summary>
        int? DayOfWeek { get; set; }
        /// <summary>Start hour to be used for maintenance window.</summary>
        int? StartHour { get; set; }
        /// <summary>Start minute to be used for maintenance window.</summary>
        int? StartMinute { get; set; }

    }
}