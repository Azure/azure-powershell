namespace Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Extensions;

    /// <summary>Class for machine properties.</summary>
    public partial class JobProperties :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IJobProperties,
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IJobPropertiesInternal
    {

        /// <summary>Backing field for <see cref="ActivityId" /> property.</summary>
        private string _activityId;

        /// <summary>Activity Id used in the operation execution context.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string ActivityId { get => this._activityId; }

        /// <summary>Backing field for <see cref="ClientRequestId" /> property.</summary>
        private string _clientRequestId;

        /// <summary>Client request Id used in the operation execution context.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string ClientRequestId { get => this._clientRequestId; }

        /// <summary>Backing field for <see cref="DisplayName" /> property.</summary>
        private string _displayName;

        /// <summary>Display name of the Job.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string DisplayName { get => this._displayName; }

        /// <summary>Backing field for <see cref="EndTime" /> property.</summary>
        private string _endTime;

        /// <summary>Operation end time.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string EndTime { get => this._endTime; }

        /// <summary>Backing field for <see cref="Error" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IErrorDetails[] _error;

        /// <summary>Errors.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IErrorDetails[] Error { get => this._error; }

        /// <summary>Internal Acessors for ActivityId</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IJobPropertiesInternal.ActivityId { get => this._activityId; set { {_activityId = value;} } }

        /// <summary>Internal Acessors for ClientRequestId</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IJobPropertiesInternal.ClientRequestId { get => this._clientRequestId; set { {_clientRequestId = value;} } }

        /// <summary>Internal Acessors for DisplayName</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IJobPropertiesInternal.DisplayName { get => this._displayName; set { {_displayName = value;} } }

        /// <summary>Internal Acessors for EndTime</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IJobPropertiesInternal.EndTime { get => this._endTime; set { {_endTime = value;} } }

        /// <summary>Internal Acessors for Error</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IErrorDetails[] Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IJobPropertiesInternal.Error { get => this._error; set { {_error = value;} } }

        /// <summary>Internal Acessors for StartTime</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IJobPropertiesInternal.StartTime { get => this._startTime; set { {_startTime = value;} } }

        /// <summary>Internal Acessors for Status</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IJobPropertiesInternal.Status { get => this._status; set { {_status = value;} } }

        /// <summary>Backing field for <see cref="StartTime" /> property.</summary>
        private string _startTime;

        /// <summary>Operation start time.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string StartTime { get => this._startTime; }

        /// <summary>Backing field for <see cref="Status" /> property.</summary>
        private string _status;

        /// <summary>Operation status.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string Status { get => this._status; }

        /// <summary>Creates an new <see cref="JobProperties" /> instance.</summary>
        public JobProperties()
        {

        }
    }
    /// Class for machine properties.
    public partial interface IJobProperties :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.IJsonSerializable
    {
        /// <summary>Activity Id used in the operation execution context.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Activity Id used in the operation execution context.",
        SerializedName = @"activityId",
        PossibleTypes = new [] { typeof(string) })]
        string ActivityId { get;  }
        /// <summary>Client request Id used in the operation execution context.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Client request Id used in the operation execution context.",
        SerializedName = @"clientRequestId",
        PossibleTypes = new [] { typeof(string) })]
        string ClientRequestId { get;  }
        /// <summary>Display name of the Job.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Display name of the Job.",
        SerializedName = @"displayName",
        PossibleTypes = new [] { typeof(string) })]
        string DisplayName { get;  }
        /// <summary>Operation end time.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Operation end time.",
        SerializedName = @"endTime",
        PossibleTypes = new [] { typeof(string) })]
        string EndTime { get;  }
        /// <summary>Errors.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Errors.",
        SerializedName = @"errors",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IErrorDetails) })]
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IErrorDetails[] Error { get;  }
        /// <summary>Operation start time.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Operation start time.",
        SerializedName = @"startTime",
        PossibleTypes = new [] { typeof(string) })]
        string StartTime { get;  }
        /// <summary>Operation status.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Operation status.",
        SerializedName = @"status",
        PossibleTypes = new [] { typeof(string) })]
        string Status { get;  }

    }
    /// Class for machine properties.
    internal partial interface IJobPropertiesInternal

    {
        /// <summary>Activity Id used in the operation execution context.</summary>
        string ActivityId { get; set; }
        /// <summary>Client request Id used in the operation execution context.</summary>
        string ClientRequestId { get; set; }
        /// <summary>Display name of the Job.</summary>
        string DisplayName { get; set; }
        /// <summary>Operation end time.</summary>
        string EndTime { get; set; }
        /// <summary>Errors.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IErrorDetails[] Error { get; set; }
        /// <summary>Operation start time.</summary>
        string StartTime { get; set; }
        /// <summary>Operation status.</summary>
        string Status { get; set; }

    }
}