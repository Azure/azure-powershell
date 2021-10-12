namespace Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Models.Api20210201Preview
{
    using static Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Runtime.Extensions;

    /// <summary>Contains details on the failure.</summary>
    public partial class SessionHostHealthCheckFailureDetails :
        Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Models.Api20210201Preview.ISessionHostHealthCheckFailureDetails,
        Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Models.Api20210201Preview.ISessionHostHealthCheckFailureDetailsInternal
    {

        /// <summary>Backing field for <see cref="ErrorCode" /> property.</summary>
        private int? _errorCode;

        /// <summary>Error code corresponding for the failure.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Origin(Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.PropertyOrigin.Owned)]
        public int? ErrorCode { get => this._errorCode; }

        /// <summary>Backing field for <see cref="LastHealthCheckDateTime" /> property.</summary>
        private global::System.DateTime? _lastHealthCheckDateTime;

        /// <summary>The timestamp of the last update.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Origin(Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.PropertyOrigin.Owned)]
        public global::System.DateTime? LastHealthCheckDateTime { get => this._lastHealthCheckDateTime; }

        /// <summary>Backing field for <see cref="Message" /> property.</summary>
        private string _message;

        /// <summary>Failure message: hints on what is wrong and how to recover.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Origin(Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.PropertyOrigin.Owned)]
        public string Message { get => this._message; }

        /// <summary>Internal Acessors for ErrorCode</summary>
        int? Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Models.Api20210201Preview.ISessionHostHealthCheckFailureDetailsInternal.ErrorCode { get => this._errorCode; set { {_errorCode = value;} } }

        /// <summary>Internal Acessors for LastHealthCheckDateTime</summary>
        global::System.DateTime? Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Models.Api20210201Preview.ISessionHostHealthCheckFailureDetailsInternal.LastHealthCheckDateTime { get => this._lastHealthCheckDateTime; set { {_lastHealthCheckDateTime = value;} } }

        /// <summary>Internal Acessors for Message</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Models.Api20210201Preview.ISessionHostHealthCheckFailureDetailsInternal.Message { get => this._message; set { {_message = value;} } }

        /// <summary>Creates an new <see cref="SessionHostHealthCheckFailureDetails" /> instance.</summary>
        public SessionHostHealthCheckFailureDetails()
        {

        }
    }
    /// Contains details on the failure.
    public partial interface ISessionHostHealthCheckFailureDetails :
        Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Runtime.IJsonSerializable
    {
        /// <summary>Error code corresponding for the failure.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Error code corresponding for the failure.",
        SerializedName = @"errorCode",
        PossibleTypes = new [] { typeof(int) })]
        int? ErrorCode { get;  }
        /// <summary>The timestamp of the last update.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"The timestamp of the last update.",
        SerializedName = @"lastHealthCheckDateTime",
        PossibleTypes = new [] { typeof(global::System.DateTime) })]
        global::System.DateTime? LastHealthCheckDateTime { get;  }
        /// <summary>Failure message: hints on what is wrong and how to recover.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Failure message: hints on what is wrong and how to recover.",
        SerializedName = @"message",
        PossibleTypes = new [] { typeof(string) })]
        string Message { get;  }

    }
    /// Contains details on the failure.
    internal partial interface ISessionHostHealthCheckFailureDetailsInternal

    {
        /// <summary>Error code corresponding for the failure.</summary>
        int? ErrorCode { get; set; }
        /// <summary>The timestamp of the last update.</summary>
        global::System.DateTime? LastHealthCheckDateTime { get; set; }
        /// <summary>Failure message: hints on what is wrong and how to recover.</summary>
        string Message { get; set; }

    }
}