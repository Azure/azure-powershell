namespace Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api202101
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Kusto.Runtime.Extensions;

    /// <summary>Operation Result Entity.</summary>
    public partial class OperationResult :
        Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api202101.IOperationResult,
        Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api202101.IOperationResultInternal
    {

        /// <summary>The code of the error.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Kusto.Origin(Microsoft.Azure.PowerShell.Cmdlets.Kusto.PropertyOrigin.Inlined)]
        public string Code { get => ((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api202101.IOperationResultErrorPropertiesInternal)Error).Code; set => ((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api202101.IOperationResultErrorPropertiesInternal)Error).Code = value ?? null; }

        /// <summary>Backing field for <see cref="EndTime" /> property.</summary>
        private global::System.DateTime? _endTime;

        /// <summary>The operation end time</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Kusto.Origin(Microsoft.Azure.PowerShell.Cmdlets.Kusto.PropertyOrigin.Owned)]
        public global::System.DateTime? EndTime { get => this._endTime; set => this._endTime = value; }

        /// <summary>Backing field for <see cref="Error" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api202101.IOperationResultErrorProperties _error;

        /// <summary>Object that contains the error code and message if the operation failed.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Kusto.Origin(Microsoft.Azure.PowerShell.Cmdlets.Kusto.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api202101.IOperationResultErrorProperties Error { get => (this._error = this._error ?? new Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api202101.OperationResultErrorProperties()); set => this._error = value; }

        /// <summary>Backing field for <see cref="Id" /> property.</summary>
        private string _id;

        /// <summary>ID of the resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Kusto.Origin(Microsoft.Azure.PowerShell.Cmdlets.Kusto.PropertyOrigin.Owned)]
        public string Id { get => this._id; }

        /// <summary>The error message.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Kusto.Origin(Microsoft.Azure.PowerShell.Cmdlets.Kusto.PropertyOrigin.Inlined)]
        public string Message { get => ((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api202101.IOperationResultErrorPropertiesInternal)Error).Message; set => ((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api202101.IOperationResultErrorPropertiesInternal)Error).Message = value ?? null; }

        /// <summary>Internal Acessors for Error</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api202101.IOperationResultErrorProperties Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api202101.IOperationResultInternal.Error { get => (this._error = this._error ?? new Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api202101.OperationResultErrorProperties()); set { {_error = value;} } }

        /// <summary>Internal Acessors for Id</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api202101.IOperationResultInternal.Id { get => this._id; set { {_id = value;} } }

        /// <summary>Internal Acessors for Name</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api202101.IOperationResultInternal.Name { get => this._name; set { {_name = value;} } }

        /// <summary>Internal Acessors for Property</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api202101.IOperationResultProperties Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api202101.IOperationResultInternal.Property { get => (this._property = this._property ?? new Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api202101.OperationResultProperties()); set { {_property = value;} } }

        /// <summary>Internal Acessors for Status</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Kusto.Support.Status? Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api202101.IOperationResultInternal.Status { get => this._status; set { {_status = value;} } }

        /// <summary>Backing field for <see cref="Name" /> property.</summary>
        private string _name;

        /// <summary>Name of the resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Kusto.Origin(Microsoft.Azure.PowerShell.Cmdlets.Kusto.PropertyOrigin.Owned)]
        public string Name { get => this._name; }

        /// <summary>The kind of the operation.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Kusto.Origin(Microsoft.Azure.PowerShell.Cmdlets.Kusto.PropertyOrigin.Inlined)]
        public string OperationKind { get => ((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api202101.IOperationResultPropertiesInternal)Property).OperationKind; set => ((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api202101.IOperationResultPropertiesInternal)Property).OperationKind = value ?? null; }

        /// <summary>The state of the operation.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Kusto.Origin(Microsoft.Azure.PowerShell.Cmdlets.Kusto.PropertyOrigin.Inlined)]
        public string OperationState { get => ((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api202101.IOperationResultPropertiesInternal)Property).OperationState; set => ((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api202101.IOperationResultPropertiesInternal)Property).OperationState = value ?? null; }

        /// <summary>Backing field for <see cref="PercentComplete" /> property.</summary>
        private double? _percentComplete;

        /// <summary>Percentage completed.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Kusto.Origin(Microsoft.Azure.PowerShell.Cmdlets.Kusto.PropertyOrigin.Owned)]
        public double? PercentComplete { get => this._percentComplete; set => this._percentComplete = value; }

        /// <summary>Backing field for <see cref="Property" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api202101.IOperationResultProperties _property;

        /// <summary>Properties of the operation results</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Kusto.Origin(Microsoft.Azure.PowerShell.Cmdlets.Kusto.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api202101.IOperationResultProperties Property { get => (this._property = this._property ?? new Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api202101.OperationResultProperties()); set => this._property = value; }

        /// <summary>Backing field for <see cref="StartTime" /> property.</summary>
        private global::System.DateTime? _startTime;

        /// <summary>The operation start time</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Kusto.Origin(Microsoft.Azure.PowerShell.Cmdlets.Kusto.PropertyOrigin.Owned)]
        public global::System.DateTime? StartTime { get => this._startTime; set => this._startTime = value; }

        /// <summary>Backing field for <see cref="Status" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Kusto.Support.Status? _status;

        /// <summary>status of the Operation result.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Kusto.Origin(Microsoft.Azure.PowerShell.Cmdlets.Kusto.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Kusto.Support.Status? Status { get => this._status; }

        /// <summary>Creates an new <see cref="OperationResult" /> instance.</summary>
        public OperationResult()
        {

        }
    }
    /// Operation Result Entity.
    public partial interface IOperationResult :
        Microsoft.Azure.PowerShell.Cmdlets.Kusto.Runtime.IJsonSerializable
    {
        /// <summary>The code of the error.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Kusto.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The code of the error.",
        SerializedName = @"code",
        PossibleTypes = new [] { typeof(string) })]
        string Code { get; set; }
        /// <summary>The operation end time</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Kusto.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The operation end time",
        SerializedName = @"endTime",
        PossibleTypes = new [] { typeof(global::System.DateTime) })]
        global::System.DateTime? EndTime { get; set; }
        /// <summary>ID of the resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Kusto.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"ID of the resource.",
        SerializedName = @"id",
        PossibleTypes = new [] { typeof(string) })]
        string Id { get;  }
        /// <summary>The error message.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Kusto.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The error message.",
        SerializedName = @"message",
        PossibleTypes = new [] { typeof(string) })]
        string Message { get; set; }
        /// <summary>Name of the resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Kusto.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Name of the resource.",
        SerializedName = @"name",
        PossibleTypes = new [] { typeof(string) })]
        string Name { get;  }
        /// <summary>The kind of the operation.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Kusto.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The kind of the operation.",
        SerializedName = @"operationKind",
        PossibleTypes = new [] { typeof(string) })]
        string OperationKind { get; set; }
        /// <summary>The state of the operation.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Kusto.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The state of the operation.",
        SerializedName = @"operationState",
        PossibleTypes = new [] { typeof(string) })]
        string OperationState { get; set; }
        /// <summary>Percentage completed.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Kusto.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Percentage completed.",
        SerializedName = @"percentComplete",
        PossibleTypes = new [] { typeof(double) })]
        double? PercentComplete { get; set; }
        /// <summary>The operation start time</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Kusto.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The operation start time",
        SerializedName = @"startTime",
        PossibleTypes = new [] { typeof(global::System.DateTime) })]
        global::System.DateTime? StartTime { get; set; }
        /// <summary>status of the Operation result.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Kusto.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"status of the Operation result.",
        SerializedName = @"status",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Kusto.Support.Status) })]
        Microsoft.Azure.PowerShell.Cmdlets.Kusto.Support.Status? Status { get;  }

    }
    /// Operation Result Entity.
    internal partial interface IOperationResultInternal

    {
        /// <summary>The code of the error.</summary>
        string Code { get; set; }
        /// <summary>The operation end time</summary>
        global::System.DateTime? EndTime { get; set; }
        /// <summary>Object that contains the error code and message if the operation failed.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api202101.IOperationResultErrorProperties Error { get; set; }
        /// <summary>ID of the resource.</summary>
        string Id { get; set; }
        /// <summary>The error message.</summary>
        string Message { get; set; }
        /// <summary>Name of the resource.</summary>
        string Name { get; set; }
        /// <summary>The kind of the operation.</summary>
        string OperationKind { get; set; }
        /// <summary>The state of the operation.</summary>
        string OperationState { get; set; }
        /// <summary>Percentage completed.</summary>
        double? PercentComplete { get; set; }
        /// <summary>Properties of the operation results</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api202101.IOperationResultProperties Property { get; set; }
        /// <summary>The operation start time</summary>
        global::System.DateTime? StartTime { get; set; }
        /// <summary>status of the Operation result.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Kusto.Support.Status? Status { get; set; }

    }
}