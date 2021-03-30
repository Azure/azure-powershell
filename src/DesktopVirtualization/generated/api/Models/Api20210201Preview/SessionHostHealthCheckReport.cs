namespace Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Models.Api20210201Preview
{
    using static Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Runtime.Extensions;

    /// <summary>The report for session host information.</summary>
    public partial class SessionHostHealthCheckReport :
        Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Models.Api20210201Preview.ISessionHostHealthCheckReport,
        Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Models.Api20210201Preview.ISessionHostHealthCheckReportInternal
    {

        /// <summary>Backing field for <see cref="AdditionalFailureDetail" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Models.Api20210201Preview.ISessionHostHealthCheckFailureDetails _additionalFailureDetail;

        /// <summary>Additional detailed information on the failure.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Origin(Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Models.Api20210201Preview.ISessionHostHealthCheckFailureDetails AdditionalFailureDetail { get => (this._additionalFailureDetail = this._additionalFailureDetail ?? new Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Models.Api20210201Preview.SessionHostHealthCheckFailureDetails()); }

        /// <summary>Error code corresponding for the failure.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Origin(Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.PropertyOrigin.Inlined)]
        public int? AdditionalFailureDetailErrorCode { get => ((Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Models.Api20210201Preview.ISessionHostHealthCheckFailureDetailsInternal)AdditionalFailureDetail).ErrorCode; }

        /// <summary>The timestamp of the last update.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Origin(Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.PropertyOrigin.Inlined)]
        public global::System.DateTime? AdditionalFailureDetailLastHealthCheckDateTime { get => ((Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Models.Api20210201Preview.ISessionHostHealthCheckFailureDetailsInternal)AdditionalFailureDetail).LastHealthCheckDateTime; }

        /// <summary>Failure message: hints on what is wrong and how to recover.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Origin(Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.PropertyOrigin.Inlined)]
        public string AdditionalFailureDetailMessage { get => ((Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Models.Api20210201Preview.ISessionHostHealthCheckFailureDetailsInternal)AdditionalFailureDetail).Message; }

        /// <summary>Backing field for <see cref="HealthCheckName" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Support.HealthCheckName? _healthCheckName;

        /// <summary>Represents the name of the health check operation performed.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Origin(Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Support.HealthCheckName? HealthCheckName { get => this._healthCheckName; }

        /// <summary>Backing field for <see cref="HealthCheckResult" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Support.HealthCheckResult? _healthCheckResult;

        /// <summary>Represents the Health state of the health check we performed.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Origin(Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Support.HealthCheckResult? HealthCheckResult { get => this._healthCheckResult; }

        /// <summary>Internal Acessors for AdditionalFailureDetail</summary>
        Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Models.Api20210201Preview.ISessionHostHealthCheckFailureDetails Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Models.Api20210201Preview.ISessionHostHealthCheckReportInternal.AdditionalFailureDetail { get => (this._additionalFailureDetail = this._additionalFailureDetail ?? new Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Models.Api20210201Preview.SessionHostHealthCheckFailureDetails()); set { {_additionalFailureDetail = value;} } }

        /// <summary>Internal Acessors for AdditionalFailureDetailErrorCode</summary>
        int? Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Models.Api20210201Preview.ISessionHostHealthCheckReportInternal.AdditionalFailureDetailErrorCode { get => ((Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Models.Api20210201Preview.ISessionHostHealthCheckFailureDetailsInternal)AdditionalFailureDetail).ErrorCode; set => ((Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Models.Api20210201Preview.ISessionHostHealthCheckFailureDetailsInternal)AdditionalFailureDetail).ErrorCode = value; }

        /// <summary>Internal Acessors for AdditionalFailureDetailLastHealthCheckDateTime</summary>
        global::System.DateTime? Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Models.Api20210201Preview.ISessionHostHealthCheckReportInternal.AdditionalFailureDetailLastHealthCheckDateTime { get => ((Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Models.Api20210201Preview.ISessionHostHealthCheckFailureDetailsInternal)AdditionalFailureDetail).LastHealthCheckDateTime; set => ((Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Models.Api20210201Preview.ISessionHostHealthCheckFailureDetailsInternal)AdditionalFailureDetail).LastHealthCheckDateTime = value; }

        /// <summary>Internal Acessors for AdditionalFailureDetailMessage</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Models.Api20210201Preview.ISessionHostHealthCheckReportInternal.AdditionalFailureDetailMessage { get => ((Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Models.Api20210201Preview.ISessionHostHealthCheckFailureDetailsInternal)AdditionalFailureDetail).Message; set => ((Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Models.Api20210201Preview.ISessionHostHealthCheckFailureDetailsInternal)AdditionalFailureDetail).Message = value; }

        /// <summary>Internal Acessors for HealthCheckName</summary>
        Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Support.HealthCheckName? Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Models.Api20210201Preview.ISessionHostHealthCheckReportInternal.HealthCheckName { get => this._healthCheckName; set { {_healthCheckName = value;} } }

        /// <summary>Internal Acessors for HealthCheckResult</summary>
        Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Support.HealthCheckResult? Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Models.Api20210201Preview.ISessionHostHealthCheckReportInternal.HealthCheckResult { get => this._healthCheckResult; set { {_healthCheckResult = value;} } }

        /// <summary>Creates an new <see cref="SessionHostHealthCheckReport" /> instance.</summary>
        public SessionHostHealthCheckReport()
        {

        }
    }
    /// The report for session host information.
    public partial interface ISessionHostHealthCheckReport :
        Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Runtime.IJsonSerializable
    {
        /// <summary>Error code corresponding for the failure.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Error code corresponding for the failure.",
        SerializedName = @"errorCode",
        PossibleTypes = new [] { typeof(int) })]
        int? AdditionalFailureDetailErrorCode { get;  }
        /// <summary>The timestamp of the last update.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"The timestamp of the last update.",
        SerializedName = @"lastHealthCheckDateTime",
        PossibleTypes = new [] { typeof(global::System.DateTime) })]
        global::System.DateTime? AdditionalFailureDetailLastHealthCheckDateTime { get;  }
        /// <summary>Failure message: hints on what is wrong and how to recover.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Failure message: hints on what is wrong and how to recover.",
        SerializedName = @"message",
        PossibleTypes = new [] { typeof(string) })]
        string AdditionalFailureDetailMessage { get;  }
        /// <summary>Represents the name of the health check operation performed.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Represents the name of the health check operation performed.",
        SerializedName = @"healthCheckName",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Support.HealthCheckName) })]
        Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Support.HealthCheckName? HealthCheckName { get;  }
        /// <summary>Represents the Health state of the health check we performed.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Represents the Health state of the health check we performed.",
        SerializedName = @"healthCheckResult",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Support.HealthCheckResult) })]
        Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Support.HealthCheckResult? HealthCheckResult { get;  }

    }
    /// The report for session host information.
    internal partial interface ISessionHostHealthCheckReportInternal

    {
        /// <summary>Additional detailed information on the failure.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Models.Api20210201Preview.ISessionHostHealthCheckFailureDetails AdditionalFailureDetail { get; set; }
        /// <summary>Error code corresponding for the failure.</summary>
        int? AdditionalFailureDetailErrorCode { get; set; }
        /// <summary>The timestamp of the last update.</summary>
        global::System.DateTime? AdditionalFailureDetailLastHealthCheckDateTime { get; set; }
        /// <summary>Failure message: hints on what is wrong and how to recover.</summary>
        string AdditionalFailureDetailMessage { get; set; }
        /// <summary>Represents the name of the health check operation performed.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Support.HealthCheckName? HealthCheckName { get; set; }
        /// <summary>Represents the Health state of the health check we performed.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Support.HealthCheckResult? HealthCheckResult { get; set; }

    }
}