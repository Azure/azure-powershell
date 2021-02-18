namespace Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Extensions;

    /// <summary>An operation on a resource.</summary>
    public partial class Operation :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IOperation,
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IOperationInternal
    {

        /// <summary>Backing field for <see cref="CreatedTime" /> property.</summary>
        private global::System.DateTime? _createdTime;

        /// <summary>Time when operation has started.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public global::System.DateTime? CreatedTime { get => this._createdTime; set => this._createdTime = value; }

        /// <summary>Backing field for <see cref="Error" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IErrorEntity[] _error;

        /// <summary>Any errors associate with the operation.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IErrorEntity[] Error { get => this._error; set => this._error = value; }

        /// <summary>Backing field for <see cref="ExpirationTime" /> property.</summary>
        private global::System.DateTime? _expirationTime;

        /// <summary>Time when operation will expire.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public global::System.DateTime? ExpirationTime { get => this._expirationTime; set => this._expirationTime = value; }

        /// <summary>Backing field for <see cref="GeoMasterOperationId" /> property.</summary>
        private string _geoMasterOperationId;

        /// <summary>Applicable only for stamp operation ids.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public string GeoMasterOperationId { get => this._geoMasterOperationId; set => this._geoMasterOperationId = value; }

        /// <summary>Backing field for <see cref="Id" /> property.</summary>
        private string _id;

        /// <summary>Operation ID.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public string Id { get => this._id; set => this._id = value; }

        /// <summary>Backing field for <see cref="ModifiedTime" /> property.</summary>
        private global::System.DateTime? _modifiedTime;

        /// <summary>Time when operation has been updated.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public global::System.DateTime? ModifiedTime { get => this._modifiedTime; set => this._modifiedTime = value; }

        /// <summary>Backing field for <see cref="Name" /> property.</summary>
        private string _name;

        /// <summary>Operation name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public string Name { get => this._name; set => this._name = value; }

        /// <summary>Backing field for <see cref="Status" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.OperationStatus? _status;

        /// <summary>The current status of the operation.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.OperationStatus? Status { get => this._status; set => this._status = value; }

        /// <summary>Creates an new <see cref="Operation" /> instance.</summary>
        public Operation()
        {

        }
    }
    /// An operation on a resource.
    public partial interface IOperation :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.IJsonSerializable
    {
        /// <summary>Time when operation has started.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Time when operation has started.",
        SerializedName = @"createdTime",
        PossibleTypes = new [] { typeof(global::System.DateTime) })]
        global::System.DateTime? CreatedTime { get; set; }
        /// <summary>Any errors associate with the operation.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Any errors associate with the operation.",
        SerializedName = @"errors",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IErrorEntity) })]
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IErrorEntity[] Error { get; set; }
        /// <summary>Time when operation will expire.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Time when operation will expire.",
        SerializedName = @"expirationTime",
        PossibleTypes = new [] { typeof(global::System.DateTime) })]
        global::System.DateTime? ExpirationTime { get; set; }
        /// <summary>Applicable only for stamp operation ids.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Applicable only for stamp operation ids.",
        SerializedName = @"geoMasterOperationId",
        PossibleTypes = new [] { typeof(string) })]
        string GeoMasterOperationId { get; set; }
        /// <summary>Operation ID.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Operation ID.",
        SerializedName = @"id",
        PossibleTypes = new [] { typeof(string) })]
        string Id { get; set; }
        /// <summary>Time when operation has been updated.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Time when operation has been updated.",
        SerializedName = @"modifiedTime",
        PossibleTypes = new [] { typeof(global::System.DateTime) })]
        global::System.DateTime? ModifiedTime { get; set; }
        /// <summary>Operation name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Operation name.",
        SerializedName = @"name",
        PossibleTypes = new [] { typeof(string) })]
        string Name { get; set; }
        /// <summary>The current status of the operation.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The current status of the operation.",
        SerializedName = @"status",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.OperationStatus) })]
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.OperationStatus? Status { get; set; }

    }
    /// An operation on a resource.
    internal partial interface IOperationInternal

    {
        /// <summary>Time when operation has started.</summary>
        global::System.DateTime? CreatedTime { get; set; }
        /// <summary>Any errors associate with the operation.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IErrorEntity[] Error { get; set; }
        /// <summary>Time when operation will expire.</summary>
        global::System.DateTime? ExpirationTime { get; set; }
        /// <summary>Applicable only for stamp operation ids.</summary>
        string GeoMasterOperationId { get; set; }
        /// <summary>Operation ID.</summary>
        string Id { get; set; }
        /// <summary>Time when operation has been updated.</summary>
        global::System.DateTime? ModifiedTime { get; set; }
        /// <summary>Operation name.</summary>
        string Name { get; set; }
        /// <summary>The current status of the operation.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.OperationStatus? Status { get; set; }

    }
}