namespace Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api20191001Preview
{
    using static Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Runtime.Extensions;

    /// <summary>Defines the move resource status.</summary>
    public partial class MoveResourceStatus :
        Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api20191001Preview.IMoveResourceStatus,
        Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api20191001Preview.IMoveResourceStatusInternal
    {

        /// <summary>
        /// An identifier for the error. Codes are invariant and are intended to be consumed programmatically.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Origin(Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.PropertyOrigin.Inlined)]
        public string Code { get => ((Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api20191001Preview.IMoveResourceErrorInternal)Error).Code; }

        /// <summary>A list of additional details about the error.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Origin(Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api20191001Preview.IMoveResourceErrorBody[] Detail { get => ((Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api20191001Preview.IMoveResourceErrorInternal)Error).Detail; }

        /// <summary>Backing field for <see cref="Error" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api20191001Preview.IMoveResourceError _error;

        /// <summary>An error response from the azure region move service.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Origin(Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api20191001Preview.IMoveResourceError Error { get => (this._error = this._error ?? new Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api20191001Preview.MoveResourceError()); set => this._error = value; }

        /// <summary>Backing field for <see cref="JobStatus" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api20191001Preview.IJobStatus _jobStatus;

        /// <summary>Defines the job status.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Origin(Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api20191001Preview.IJobStatus JobStatus { get => (this._jobStatus = this._jobStatus ?? new Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api20191001Preview.JobStatus()); set => this._jobStatus = value; }

        /// <summary>Defines the job name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Origin(Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Support.JobName? JobStatusJobName { get => ((Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api20191001Preview.IJobStatusInternal)JobStatus).JobName; }

        /// <summary>Gets or sets the monitoring job percentage.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Origin(Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.PropertyOrigin.Inlined)]
        public string JobStatusJobProgress { get => ((Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api20191001Preview.IJobStatusInternal)JobStatus).JobProgress; }

        /// <summary>
        /// A message describing the error, intended to be suitable for display in a user interface.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Origin(Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.PropertyOrigin.Inlined)]
        public string Message { get => ((Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api20191001Preview.IMoveResourceErrorInternal)Error).Message; }

        /// <summary>Internal Acessors for Code</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api20191001Preview.IMoveResourceStatusInternal.Code { get => ((Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api20191001Preview.IMoveResourceErrorInternal)Error).Code; set => ((Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api20191001Preview.IMoveResourceErrorInternal)Error).Code = value; }

        /// <summary>Internal Acessors for Detail</summary>
        Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api20191001Preview.IMoveResourceErrorBody[] Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api20191001Preview.IMoveResourceStatusInternal.Detail { get => ((Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api20191001Preview.IMoveResourceErrorInternal)Error).Detail; set => ((Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api20191001Preview.IMoveResourceErrorInternal)Error).Detail = value; }

        /// <summary>Internal Acessors for Error</summary>
        Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api20191001Preview.IMoveResourceError Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api20191001Preview.IMoveResourceStatusInternal.Error { get => (this._error = this._error ?? new Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api20191001Preview.MoveResourceError()); set { {_error = value;} } }

        /// <summary>Internal Acessors for ErrorProperty</summary>
        Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api20191001Preview.IMoveResourceErrorBody Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api20191001Preview.IMoveResourceStatusInternal.ErrorProperty { get => ((Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api20191001Preview.IMoveResourceErrorInternal)Error).Property; set => ((Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api20191001Preview.IMoveResourceErrorInternal)Error).Property = value; }

        /// <summary>Internal Acessors for JobStatus</summary>
        Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api20191001Preview.IJobStatus Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api20191001Preview.IMoveResourceStatusInternal.JobStatus { get => (this._jobStatus = this._jobStatus ?? new Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api20191001Preview.JobStatus()); set { {_jobStatus = value;} } }

        /// <summary>Internal Acessors for JobStatusJobName</summary>
        Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Support.JobName? Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api20191001Preview.IMoveResourceStatusInternal.JobStatusJobName { get => ((Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api20191001Preview.IJobStatusInternal)JobStatus).JobName; set => ((Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api20191001Preview.IJobStatusInternal)JobStatus).JobName = value; }

        /// <summary>Internal Acessors for JobStatusJobProgress</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api20191001Preview.IMoveResourceStatusInternal.JobStatusJobProgress { get => ((Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api20191001Preview.IJobStatusInternal)JobStatus).JobProgress; set => ((Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api20191001Preview.IJobStatusInternal)JobStatus).JobProgress = value; }

        /// <summary>Internal Acessors for Message</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api20191001Preview.IMoveResourceStatusInternal.Message { get => ((Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api20191001Preview.IMoveResourceErrorInternal)Error).Message; set => ((Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api20191001Preview.IMoveResourceErrorInternal)Error).Message = value; }

        /// <summary>Internal Acessors for MoveState</summary>
        Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Support.MoveState? Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api20191001Preview.IMoveResourceStatusInternal.MoveState { get => this._moveState; set { {_moveState = value;} } }

        /// <summary>Internal Acessors for Target</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api20191001Preview.IMoveResourceStatusInternal.Target { get => ((Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api20191001Preview.IMoveResourceErrorInternal)Error).Target; set => ((Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api20191001Preview.IMoveResourceErrorInternal)Error).Target = value; }

        /// <summary>Internal Acessors for TargetId</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api20191001Preview.IMoveResourceStatusInternal.TargetId { get => this._targetId; set { {_targetId = value;} } }

        /// <summary>Backing field for <see cref="MoveState" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Support.MoveState? _moveState;

        /// <summary>Defines the MoveResource states.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Origin(Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Support.MoveState? MoveState { get => this._moveState; }

        /// <summary>
        /// The target of the particular error. For example, the name of the property in error.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Origin(Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.PropertyOrigin.Inlined)]
        public string Target { get => ((Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api20191001Preview.IMoveResourceErrorInternal)Error).Target; }

        /// <summary>Backing field for <see cref="TargetId" /> property.</summary>
        private string _targetId;

        /// <summary>Gets the Target ARM Id of the resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Origin(Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.PropertyOrigin.Owned)]
        public string TargetId { get => this._targetId; }

        /// <summary>Creates an new <see cref="MoveResourceStatus" /> instance.</summary>
        public MoveResourceStatus()
        {

        }
    }
    /// Defines the move resource status.
    public partial interface IMoveResourceStatus :
        Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Runtime.IJsonSerializable
    {
        /// <summary>
        /// An identifier for the error. Codes are invariant and are intended to be consumed programmatically.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"An identifier for the error. Codes are invariant and are intended to be consumed programmatically.",
        SerializedName = @"code",
        PossibleTypes = new [] { typeof(string) })]
        string Code { get;  }
        /// <summary>A list of additional details about the error.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"A list of additional details about the error.",
        SerializedName = @"details",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api20191001Preview.IMoveResourceErrorBody) })]
        Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api20191001Preview.IMoveResourceErrorBody[] Detail { get;  }
        /// <summary>Defines the job name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Defines the job name.",
        SerializedName = @"jobName",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Support.JobName) })]
        Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Support.JobName? JobStatusJobName { get;  }
        /// <summary>Gets or sets the monitoring job percentage.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Gets or sets the monitoring job percentage.",
        SerializedName = @"jobProgress",
        PossibleTypes = new [] { typeof(string) })]
        string JobStatusJobProgress { get;  }
        /// <summary>
        /// A message describing the error, intended to be suitable for display in a user interface.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"A message describing the error, intended to be suitable for display in a user interface.",
        SerializedName = @"message",
        PossibleTypes = new [] { typeof(string) })]
        string Message { get;  }
        /// <summary>Defines the MoveResource states.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Defines the MoveResource states.",
        SerializedName = @"moveState",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Support.MoveState) })]
        Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Support.MoveState? MoveState { get;  }
        /// <summary>
        /// The target of the particular error. For example, the name of the property in error.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"The target of the particular error. For example, the name of the property in error.",
        SerializedName = @"target",
        PossibleTypes = new [] { typeof(string) })]
        string Target { get;  }
        /// <summary>Gets the Target ARM Id of the resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Gets the Target ARM Id of the resource.",
        SerializedName = @"targetId",
        PossibleTypes = new [] { typeof(string) })]
        string TargetId { get;  }

    }
    /// Defines the move resource status.
    internal partial interface IMoveResourceStatusInternal

    {
        /// <summary>
        /// An identifier for the error. Codes are invariant and are intended to be consumed programmatically.
        /// </summary>
        string Code { get; set; }
        /// <summary>A list of additional details about the error.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api20191001Preview.IMoveResourceErrorBody[] Detail { get; set; }
        /// <summary>An error response from the azure region move service.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api20191001Preview.IMoveResourceError Error { get; set; }
        /// <summary>The move resource error body.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api20191001Preview.IMoveResourceErrorBody ErrorProperty { get; set; }
        /// <summary>Defines the job status.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api20191001Preview.IJobStatus JobStatus { get; set; }
        /// <summary>Defines the job name.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Support.JobName? JobStatusJobName { get; set; }
        /// <summary>Gets or sets the monitoring job percentage.</summary>
        string JobStatusJobProgress { get; set; }
        /// <summary>
        /// A message describing the error, intended to be suitable for display in a user interface.
        /// </summary>
        string Message { get; set; }
        /// <summary>Defines the MoveResource states.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Support.MoveState? MoveState { get; set; }
        /// <summary>
        /// The target of the particular error. For example, the name of the property in error.
        /// </summary>
        string Target { get; set; }
        /// <summary>Gets the Target ARM Id of the resource.</summary>
        string TargetId { get; set; }

    }
}