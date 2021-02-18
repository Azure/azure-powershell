namespace Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Extensions;

    /// <summary>Trigger based on status code.</summary>
    public partial class StatusCodesBasedTrigger :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IStatusCodesBasedTrigger,
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IStatusCodesBasedTriggerInternal
    {

        /// <summary>Backing field for <see cref="Count" /> property.</summary>
        private int? _count;

        /// <summary>Request Count.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public int? Count { get => this._count; set => this._count = value; }

        /// <summary>Backing field for <see cref="Status" /> property.</summary>
        private int? _status;

        /// <summary>HTTP status code.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public int? Status { get => this._status; set => this._status = value; }

        /// <summary>Backing field for <see cref="SubStatus" /> property.</summary>
        private int? _subStatus;

        /// <summary>Request Sub Status.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public int? SubStatus { get => this._subStatus; set => this._subStatus = value; }

        /// <summary>Backing field for <see cref="TimeInterval" /> property.</summary>
        private string _timeInterval;

        /// <summary>Time interval.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public string TimeInterval { get => this._timeInterval; set => this._timeInterval = value; }

        /// <summary>Backing field for <see cref="Win32Status" /> property.</summary>
        private int? _win32Status;

        /// <summary>Win32 error code.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public int? Win32Status { get => this._win32Status; set => this._win32Status = value; }

        /// <summary>Creates an new <see cref="StatusCodesBasedTrigger" /> instance.</summary>
        public StatusCodesBasedTrigger()
        {

        }
    }
    /// Trigger based on status code.
    public partial interface IStatusCodesBasedTrigger :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.IJsonSerializable
    {
        /// <summary>Request Count.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Request Count.",
        SerializedName = @"count",
        PossibleTypes = new [] { typeof(int) })]
        int? Count { get; set; }
        /// <summary>HTTP status code.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"HTTP status code.",
        SerializedName = @"status",
        PossibleTypes = new [] { typeof(int) })]
        int? Status { get; set; }
        /// <summary>Request Sub Status.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Request Sub Status.",
        SerializedName = @"subStatus",
        PossibleTypes = new [] { typeof(int) })]
        int? SubStatus { get; set; }
        /// <summary>Time interval.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Time interval.",
        SerializedName = @"timeInterval",
        PossibleTypes = new [] { typeof(string) })]
        string TimeInterval { get; set; }
        /// <summary>Win32 error code.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Win32 error code.",
        SerializedName = @"win32Status",
        PossibleTypes = new [] { typeof(int) })]
        int? Win32Status { get; set; }

    }
    /// Trigger based on status code.
    internal partial interface IStatusCodesBasedTriggerInternal

    {
        /// <summary>Request Count.</summary>
        int? Count { get; set; }
        /// <summary>HTTP status code.</summary>
        int? Status { get; set; }
        /// <summary>Request Sub Status.</summary>
        int? SubStatus { get; set; }
        /// <summary>Time interval.</summary>
        string TimeInterval { get; set; }
        /// <summary>Win32 error code.</summary>
        int? Win32Status { get; set; }

    }
}