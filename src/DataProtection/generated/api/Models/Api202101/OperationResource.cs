namespace Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101
{
    using static Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.Extensions;

    /// <summary>Operation Resource</summary>
    public partial class OperationResource :
        Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IOperationResource,
        Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IOperationResourceInternal
    {

        /// <summary>The error additional info.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Origin(Microsoft.Azure.PowerShell.Cmdlets.DataProtection.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IErrorAdditionalInfo[] AdditionalInfo { get => ((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IErrorInternal)Error).AdditionalInfo; }

        /// <summary>The error code.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Origin(Microsoft.Azure.PowerShell.Cmdlets.DataProtection.PropertyOrigin.Inlined)]
        public string Code { get => ((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IErrorInternal)Error).Code; }

        /// <summary>The error details.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Origin(Microsoft.Azure.PowerShell.Cmdlets.DataProtection.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IError[] Detail { get => ((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IErrorInternal)Error).Detail; }

        /// <summary>Backing field for <see cref="EndTime" /> property.</summary>
        private global::System.DateTime? _endTime;

        /// <summary>End time of the operation</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Origin(Microsoft.Azure.PowerShell.Cmdlets.DataProtection.PropertyOrigin.Owned)]
        public global::System.DateTime? EndTime { get => this._endTime; set => this._endTime = value; }

        /// <summary>Backing field for <see cref="Error" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IError _error;

        /// <summary>
        /// Required if status == failed or status == canceled. This is the OData v4 error format, used by the RPC and will go into
        /// the v2.2 Azure REST API guidelines.
        /// The full set of optional properties (e.g. inner errors / details) can be found in the "Error Response" section.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Origin(Microsoft.Azure.PowerShell.Cmdlets.DataProtection.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IError Error { get => (this._error = this._error ?? new Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.Error()); set => this._error = value; }

        /// <summary>Backing field for <see cref="Id" /> property.</summary>
        private string _id;

        /// <summary>It should match what is used to GET the operation result</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Origin(Microsoft.Azure.PowerShell.Cmdlets.DataProtection.PropertyOrigin.Owned)]
        public string Id { get => this._id; set => this._id = value; }

        /// <summary>The error message.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Origin(Microsoft.Azure.PowerShell.Cmdlets.DataProtection.PropertyOrigin.Inlined)]
        public string Message { get => ((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IErrorInternal)Error).Message; }

        /// <summary>Internal Acessors for AdditionalInfo</summary>
        Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IErrorAdditionalInfo[] Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IOperationResourceInternal.AdditionalInfo { get => ((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IErrorInternal)Error).AdditionalInfo; set => ((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IErrorInternal)Error).AdditionalInfo = value; }

        /// <summary>Internal Acessors for Code</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IOperationResourceInternal.Code { get => ((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IErrorInternal)Error).Code; set => ((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IErrorInternal)Error).Code = value; }

        /// <summary>Internal Acessors for Detail</summary>
        Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IError[] Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IOperationResourceInternal.Detail { get => ((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IErrorInternal)Error).Detail; set => ((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IErrorInternal)Error).Detail = value; }

        /// <summary>Internal Acessors for Error</summary>
        Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IError Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IOperationResourceInternal.Error { get => (this._error = this._error ?? new Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.Error()); set { {_error = value;} } }

        /// <summary>Internal Acessors for Message</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IOperationResourceInternal.Message { get => ((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IErrorInternal)Error).Message; set => ((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IErrorInternal)Error).Message = value; }

        /// <summary>Internal Acessors for Property</summary>
        Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IOperationExtendedInfo Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IOperationResourceInternal.Property { get => (this._property = this._property ?? new Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.OperationExtendedInfo()); set { {_property = value;} } }

        /// <summary>Internal Acessors for Target</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IOperationResourceInternal.Target { get => ((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IErrorInternal)Error).Target; set => ((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IErrorInternal)Error).Target = value; }

        /// <summary>Backing field for <see cref="Name" /> property.</summary>
        private string _name;

        /// <summary>
        /// It must match the last segment of the "id" field, and will typically be a GUID / system generated value
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Origin(Microsoft.Azure.PowerShell.Cmdlets.DataProtection.PropertyOrigin.Owned)]
        public string Name { get => this._name; set => this._name = value; }

        /// <summary>
        /// This property will be used as the discriminator for deciding the specific types in the polymorphic chain of types.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Origin(Microsoft.Azure.PowerShell.Cmdlets.DataProtection.PropertyOrigin.Inlined)]
        public string ObjectType { get => ((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IOperationExtendedInfoInternal)Property).ObjectType; set => ((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IOperationExtendedInfoInternal)Property).ObjectType = value ?? null; }

        /// <summary>Backing field for <see cref="Property" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IOperationExtendedInfo _property;

        /// <summary>End time of the operation</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Origin(Microsoft.Azure.PowerShell.Cmdlets.DataProtection.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IOperationExtendedInfo Property { get => (this._property = this._property ?? new Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.OperationExtendedInfo()); set => this._property = value; }

        /// <summary>Backing field for <see cref="StartTime" /> property.</summary>
        private global::System.DateTime? _startTime;

        /// <summary>Start time of the operation</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Origin(Microsoft.Azure.PowerShell.Cmdlets.DataProtection.PropertyOrigin.Owned)]
        public global::System.DateTime? StartTime { get => this._startTime; set => this._startTime = value; }

        /// <summary>Backing field for <see cref="Status" /> property.</summary>
        private string _status;

        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Origin(Microsoft.Azure.PowerShell.Cmdlets.DataProtection.PropertyOrigin.Owned)]
        public string Status { get => this._status; set => this._status = value; }

        /// <summary>The error target.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Origin(Microsoft.Azure.PowerShell.Cmdlets.DataProtection.PropertyOrigin.Inlined)]
        public string Target { get => ((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IErrorInternal)Error).Target; }

        /// <summary>Creates an new <see cref="OperationResource" /> instance.</summary>
        public OperationResource()
        {

        }
    }
    /// Operation Resource
    public partial interface IOperationResource :
        Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.IJsonSerializable
    {
        /// <summary>The error additional info.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"The error additional info.",
        SerializedName = @"additionalInfo",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IErrorAdditionalInfo) })]
        Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IErrorAdditionalInfo[] AdditionalInfo { get;  }
        /// <summary>The error code.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"The error code.",
        SerializedName = @"code",
        PossibleTypes = new [] { typeof(string) })]
        string Code { get;  }
        /// <summary>The error details.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"The error details.",
        SerializedName = @"details",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IError) })]
        Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IError[] Detail { get;  }
        /// <summary>End time of the operation</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"End time of the operation",
        SerializedName = @"endTime",
        PossibleTypes = new [] { typeof(global::System.DateTime) })]
        global::System.DateTime? EndTime { get; set; }
        /// <summary>It should match what is used to GET the operation result</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"It should match what is used to GET the operation result",
        SerializedName = @"id",
        PossibleTypes = new [] { typeof(string) })]
        string Id { get; set; }
        /// <summary>The error message.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"The error message.",
        SerializedName = @"message",
        PossibleTypes = new [] { typeof(string) })]
        string Message { get;  }
        /// <summary>
        /// It must match the last segment of the "id" field, and will typically be a GUID / system generated value
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"It must match the last segment of the ""id"" field, and will typically be a GUID / system generated value",
        SerializedName = @"name",
        PossibleTypes = new [] { typeof(string) })]
        string Name { get; set; }
        /// <summary>
        /// This property will be used as the discriminator for deciding the specific types in the polymorphic chain of types.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"This property will be used as the discriminator for deciding the specific types in the polymorphic chain of types.",
        SerializedName = @"objectType",
        PossibleTypes = new [] { typeof(string) })]
        string ObjectType { get; set; }
        /// <summary>Start time of the operation</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Start time of the operation",
        SerializedName = @"startTime",
        PossibleTypes = new [] { typeof(global::System.DateTime) })]
        global::System.DateTime? StartTime { get; set; }

        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"",
        SerializedName = @"status",
        PossibleTypes = new [] { typeof(string) })]
        string Status { get; set; }
        /// <summary>The error target.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"The error target.",
        SerializedName = @"target",
        PossibleTypes = new [] { typeof(string) })]
        string Target { get;  }

    }
    /// Operation Resource
    internal partial interface IOperationResourceInternal

    {
        /// <summary>The error additional info.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IErrorAdditionalInfo[] AdditionalInfo { get; set; }
        /// <summary>The error code.</summary>
        string Code { get; set; }
        /// <summary>The error details.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IError[] Detail { get; set; }
        /// <summary>End time of the operation</summary>
        global::System.DateTime? EndTime { get; set; }
        /// <summary>
        /// Required if status == failed or status == canceled. This is the OData v4 error format, used by the RPC and will go into
        /// the v2.2 Azure REST API guidelines.
        /// The full set of optional properties (e.g. inner errors / details) can be found in the "Error Response" section.
        /// </summary>
        Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IError Error { get; set; }
        /// <summary>It should match what is used to GET the operation result</summary>
        string Id { get; set; }
        /// <summary>The error message.</summary>
        string Message { get; set; }
        /// <summary>
        /// It must match the last segment of the "id" field, and will typically be a GUID / system generated value
        /// </summary>
        string Name { get; set; }
        /// <summary>
        /// This property will be used as the discriminator for deciding the specific types in the polymorphic chain of types.
        /// </summary>
        string ObjectType { get; set; }
        /// <summary>End time of the operation</summary>
        Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IOperationExtendedInfo Property { get; set; }
        /// <summary>Start time of the operation</summary>
        global::System.DateTime? StartTime { get; set; }

        string Status { get; set; }
        /// <summary>The error target.</summary>
        string Target { get; set; }

    }
}