namespace Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Extensions;

    /// <summary>Operation status REST resource.</summary>
    public partial class OperationStatus :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IOperationStatus,
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IOperationStatusInternal
    {

        /// <summary>Error code.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Inlined)]
        public string Code { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IOperationStatusErrorInternal)Error).Code; }

        /// <summary>Backing field for <see cref="EndTime" /> property.</summary>
        private string _endTime;

        /// <summary>End time.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string EndTime { get => this._endTime; }

        /// <summary>Backing field for <see cref="Error" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IOperationStatusError _error;

        /// <summary>Error stating all error details for the operation.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IOperationStatusError Error { get => (this._error = this._error ?? new Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.OperationStatusError()); }

        /// <summary>Backing field for <see cref="Id" /> property.</summary>
        private string _id;

        /// <summary>Resource Id.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string Id { get => this._id; }

        /// <summary>Error message.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Inlined)]
        public string Message { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IOperationStatusErrorInternal)Error).Message; }

        /// <summary>Internal Acessors for Code</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IOperationStatusInternal.Code { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IOperationStatusErrorInternal)Error).Code; set => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IOperationStatusErrorInternal)Error).Code = value; }

        /// <summary>Internal Acessors for EndTime</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IOperationStatusInternal.EndTime { get => this._endTime; set { {_endTime = value;} } }

        /// <summary>Internal Acessors for Error</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IOperationStatusError Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IOperationStatusInternal.Error { get => (this._error = this._error ?? new Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.OperationStatusError()); set { {_error = value;} } }

        /// <summary>Internal Acessors for Id</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IOperationStatusInternal.Id { get => this._id; set { {_id = value;} } }

        /// <summary>Internal Acessors for Message</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IOperationStatusInternal.Message { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IOperationStatusErrorInternal)Error).Message; set => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IOperationStatusErrorInternal)Error).Message = value; }

        /// <summary>Internal Acessors for Name</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IOperationStatusInternal.Name { get => this._name; set { {_name = value;} } }

        /// <summary>Internal Acessors for Property</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IOperationStatusProperties Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IOperationStatusInternal.Property { get => (this._property = this._property ?? new Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.OperationStatusProperties()); set { {_property = value;} } }

        /// <summary>Internal Acessors for StartTime</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IOperationStatusInternal.StartTime { get => this._startTime; set { {_startTime = value;} } }

        /// <summary>Internal Acessors for Status</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IOperationStatusInternal.Status { get => this._status; set { {_status = value;} } }

        /// <summary>Backing field for <see cref="Name" /> property.</summary>
        private string _name;

        /// <summary>Operation name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string Name { get => this._name; }

        /// <summary>Backing field for <see cref="Property" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IOperationStatusProperties _property;

        /// <summary>Custom data.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IOperationStatusProperties Property { get => (this._property = this._property ?? new Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.OperationStatusProperties()); }

        /// <summary>Result or output of the workflow.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Inlined)]
        public string Result { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IOperationStatusPropertiesInternal)Property).Result; set => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IOperationStatusPropertiesInternal)Property).Result = value ?? null; }

        /// <summary>Backing field for <see cref="StartTime" /> property.</summary>
        private string _startTime;

        /// <summary>Start time.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string StartTime { get => this._startTime; }

        /// <summary>Backing field for <see cref="Status" /> property.</summary>
        private string _status;

        /// <summary>
        /// Status of the operation. ARM expects the terminal status to be one of Succeeded/ Failed/ Canceled. All other values imply
        /// that the operation is still running.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string Status { get => this._status; }

        /// <summary>Creates an new <see cref="OperationStatus" /> instance.</summary>
        public OperationStatus()
        {

        }
    }
    /// Operation status REST resource.
    public partial interface IOperationStatus :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.IJsonSerializable
    {
        /// <summary>Error code.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Error code.",
        SerializedName = @"code",
        PossibleTypes = new [] { typeof(string) })]
        string Code { get;  }
        /// <summary>End time.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"End time.",
        SerializedName = @"endTime",
        PossibleTypes = new [] { typeof(string) })]
        string EndTime { get;  }
        /// <summary>Resource Id.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Resource Id.",
        SerializedName = @"id",
        PossibleTypes = new [] { typeof(string) })]
        string Id { get;  }
        /// <summary>Error message.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Error message.",
        SerializedName = @"message",
        PossibleTypes = new [] { typeof(string) })]
        string Message { get;  }
        /// <summary>Operation name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Operation name.",
        SerializedName = @"name",
        PossibleTypes = new [] { typeof(string) })]
        string Name { get;  }
        /// <summary>Result or output of the workflow.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Result or output of the workflow.",
        SerializedName = @"result",
        PossibleTypes = new [] { typeof(string) })]
        string Result { get; set; }
        /// <summary>Start time.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Start time.",
        SerializedName = @"startTime",
        PossibleTypes = new [] { typeof(string) })]
        string StartTime { get;  }
        /// <summary>
        /// Status of the operation. ARM expects the terminal status to be one of Succeeded/ Failed/ Canceled. All other values imply
        /// that the operation is still running.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Status of the operation. ARM expects the terminal status to be one of Succeeded/ Failed/ Canceled. All other values imply that the operation is still running.",
        SerializedName = @"status",
        PossibleTypes = new [] { typeof(string) })]
        string Status { get;  }

    }
    /// Operation status REST resource.
    internal partial interface IOperationStatusInternal

    {
        /// <summary>Error code.</summary>
        string Code { get; set; }
        /// <summary>End time.</summary>
        string EndTime { get; set; }
        /// <summary>Error stating all error details for the operation.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IOperationStatusError Error { get; set; }
        /// <summary>Resource Id.</summary>
        string Id { get; set; }
        /// <summary>Error message.</summary>
        string Message { get; set; }
        /// <summary>Operation name.</summary>
        string Name { get; set; }
        /// <summary>Custom data.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IOperationStatusProperties Property { get; set; }
        /// <summary>Result or output of the workflow.</summary>
        string Result { get; set; }
        /// <summary>Start time.</summary>
        string StartTime { get; set; }
        /// <summary>
        /// Status of the operation. ARM expects the terminal status to be one of Succeeded/ Failed/ Canceled. All other values imply
        /// that the operation is still running.
        /// </summary>
        string Status { get; set; }

    }
}