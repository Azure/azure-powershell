namespace Microsoft.Azure.PowerShell.Cmdlets.Communication.Models.Api20200820Preview
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Communication.Runtime.Extensions;

    /// <summary>The current status of an async operation</summary>
    public partial class OperationStatus :
        Microsoft.Azure.PowerShell.Cmdlets.Communication.Models.Api20200820Preview.IOperationStatus,
        Microsoft.Azure.PowerShell.Cmdlets.Communication.Models.Api20200820Preview.IOperationStatusInternal
    {

        /// <summary>Error code.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Communication.Origin(Microsoft.Azure.PowerShell.Cmdlets.Communication.PropertyOrigin.Inlined)]
        public string Code { get => ((Microsoft.Azure.PowerShell.Cmdlets.Communication.Models.Api20200820Preview.IErrorResponseInternal)Error).Code; set => ((Microsoft.Azure.PowerShell.Cmdlets.Communication.Models.Api20200820Preview.IErrorResponseInternal)Error).Code = value; }

        /// <summary>Backing field for <see cref="EndTime" /> property.</summary>
        private global::System.DateTime? _endTime;

        /// <summary>The end time of the operation</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Communication.Origin(Microsoft.Azure.PowerShell.Cmdlets.Communication.PropertyOrigin.Owned)]
        public global::System.DateTime? EndTime { get => this._endTime; }

        /// <summary>Backing field for <see cref="Error" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Communication.Models.Api20200820Preview.IErrorResponse _error;

        /// <summary>Operation Error message</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Communication.Origin(Microsoft.Azure.PowerShell.Cmdlets.Communication.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.Communication.Models.Api20200820Preview.IErrorResponse Error { get => (this._error = this._error ?? new Microsoft.Azure.PowerShell.Cmdlets.Communication.Models.Api20200820Preview.ErrorResponse()); set => this._error = value; }

        /// <summary>Backing field for <see cref="Id" /> property.</summary>
        private string _id;

        /// <summary>The operation Id.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Communication.Origin(Microsoft.Azure.PowerShell.Cmdlets.Communication.PropertyOrigin.Owned)]
        public string Id { get => this._id; }

        /// <summary>Error message indicating why the operation failed.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Communication.Origin(Microsoft.Azure.PowerShell.Cmdlets.Communication.PropertyOrigin.Inlined)]
        public string Message { get => ((Microsoft.Azure.PowerShell.Cmdlets.Communication.Models.Api20200820Preview.IErrorResponseInternal)Error).Message; set => ((Microsoft.Azure.PowerShell.Cmdlets.Communication.Models.Api20200820Preview.IErrorResponseInternal)Error).Message = value; }

        /// <summary>Internal Acessors for EndTime</summary>
        global::System.DateTime? Microsoft.Azure.PowerShell.Cmdlets.Communication.Models.Api20200820Preview.IOperationStatusInternal.EndTime { get => this._endTime; set { {_endTime = value;} } }

        /// <summary>Internal Acessors for Error</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Communication.Models.Api20200820Preview.IErrorResponse Microsoft.Azure.PowerShell.Cmdlets.Communication.Models.Api20200820Preview.IOperationStatusInternal.Error { get => (this._error = this._error ?? new Microsoft.Azure.PowerShell.Cmdlets.Communication.Models.Api20200820Preview.ErrorResponse()); set { {_error = value;} } }

        /// <summary>Internal Acessors for ErrorResponseError</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Communication.Models.Api20200820Preview.IErrorResponseError Microsoft.Azure.PowerShell.Cmdlets.Communication.Models.Api20200820Preview.IOperationStatusInternal.ErrorResponseError { get => ((Microsoft.Azure.PowerShell.Cmdlets.Communication.Models.Api20200820Preview.IErrorResponseInternal)Error).Error; set => ((Microsoft.Azure.PowerShell.Cmdlets.Communication.Models.Api20200820Preview.IErrorResponseInternal)Error).Error = value; }

        /// <summary>Internal Acessors for Id</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Communication.Models.Api20200820Preview.IOperationStatusInternal.Id { get => this._id; set { {_id = value;} } }

        /// <summary>Internal Acessors for PercentComplete</summary>
        float? Microsoft.Azure.PowerShell.Cmdlets.Communication.Models.Api20200820Preview.IOperationStatusInternal.PercentComplete { get => this._percentComplete; set { {_percentComplete = value;} } }

        /// <summary>Internal Acessors for StartTime</summary>
        global::System.DateTime? Microsoft.Azure.PowerShell.Cmdlets.Communication.Models.Api20200820Preview.IOperationStatusInternal.StartTime { get => this._startTime; set { {_startTime = value;} } }

        /// <summary>Internal Acessors for Status</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Communication.Support.Status? Microsoft.Azure.PowerShell.Cmdlets.Communication.Models.Api20200820Preview.IOperationStatusInternal.Status { get => this._status; set { {_status = value;} } }

        /// <summary>Backing field for <see cref="PercentComplete" /> property.</summary>
        private float? _percentComplete;

        /// <summary>Percent of the operation that is complete</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Communication.Origin(Microsoft.Azure.PowerShell.Cmdlets.Communication.PropertyOrigin.Owned)]
        public float? PercentComplete { get => this._percentComplete; }

        /// <summary>Backing field for <see cref="StartTime" /> property.</summary>
        private global::System.DateTime? _startTime;

        /// <summary>The start time of the operation</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Communication.Origin(Microsoft.Azure.PowerShell.Cmdlets.Communication.PropertyOrigin.Owned)]
        public global::System.DateTime? StartTime { get => this._startTime; }

        /// <summary>Backing field for <see cref="Status" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Communication.Support.Status? _status;

        /// <summary>Provisioning state of the resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Communication.Origin(Microsoft.Azure.PowerShell.Cmdlets.Communication.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Communication.Support.Status? Status { get => this._status; }

        /// <summary>Creates an new <see cref="OperationStatus" /> instance.</summary>
        public OperationStatus()
        {

        }
    }
    /// The current status of an async operation
    public partial interface IOperationStatus :
        Microsoft.Azure.PowerShell.Cmdlets.Communication.Runtime.IJsonSerializable
    {
        /// <summary>Error code.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Communication.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Error code.",
        SerializedName = @"code",
        PossibleTypes = new [] { typeof(string) })]
        string Code { get; set; }
        /// <summary>The end time of the operation</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Communication.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"The end time of the operation",
        SerializedName = @"endTime",
        PossibleTypes = new [] { typeof(global::System.DateTime) })]
        global::System.DateTime? EndTime { get;  }
        /// <summary>The operation Id.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Communication.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"The operation Id.",
        SerializedName = @"id",
        PossibleTypes = new [] { typeof(string) })]
        string Id { get;  }
        /// <summary>Error message indicating why the operation failed.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Communication.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Error message indicating why the operation failed.",
        SerializedName = @"message",
        PossibleTypes = new [] { typeof(string) })]
        string Message { get; set; }
        /// <summary>Percent of the operation that is complete</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Communication.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Percent of the operation that is complete",
        SerializedName = @"percentComplete",
        PossibleTypes = new [] { typeof(float) })]
        float? PercentComplete { get;  }
        /// <summary>The start time of the operation</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Communication.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"The start time of the operation",
        SerializedName = @"startTime",
        PossibleTypes = new [] { typeof(global::System.DateTime) })]
        global::System.DateTime? StartTime { get;  }
        /// <summary>Provisioning state of the resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Communication.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Provisioning state of the resource.",
        SerializedName = @"status",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Communication.Support.Status) })]
        Microsoft.Azure.PowerShell.Cmdlets.Communication.Support.Status? Status { get;  }

    }
    /// The current status of an async operation
    internal partial interface IOperationStatusInternal

    {
        /// <summary>Error code.</summary>
        string Code { get; set; }
        /// <summary>The end time of the operation</summary>
        global::System.DateTime? EndTime { get; set; }
        /// <summary>Operation Error message</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Communication.Models.Api20200820Preview.IErrorResponse Error { get; set; }
        /// <summary>The error</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Communication.Models.Api20200820Preview.IErrorResponseError ErrorResponseError { get; set; }
        /// <summary>The operation Id.</summary>
        string Id { get; set; }
        /// <summary>Error message indicating why the operation failed.</summary>
        string Message { get; set; }
        /// <summary>Percent of the operation that is complete</summary>
        float? PercentComplete { get; set; }
        /// <summary>The start time of the operation</summary>
        global::System.DateTime? StartTime { get; set; }
        /// <summary>Provisioning state of the resource.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Communication.Support.Status? Status { get; set; }

    }
}