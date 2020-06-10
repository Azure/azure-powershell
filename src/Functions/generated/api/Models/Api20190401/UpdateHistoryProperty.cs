namespace Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Extensions;

    /// <summary>An update history of the ImmutabilityPolicy of a blob container.</summary>
    public partial class UpdateHistoryProperty :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IUpdateHistoryProperty,
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IUpdateHistoryPropertyInternal
    {

        /// <summary>Backing field for <see cref="ImmutabilityPeriodSinceCreationInDay" /> property.</summary>
        private int? _immutabilityPeriodSinceCreationInDay;

        /// <summary>
        /// The immutability period for the blobs in the container since the policy creation, in days.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public int? ImmutabilityPeriodSinceCreationInDay { get => this._immutabilityPeriodSinceCreationInDay; }

        /// <summary>Internal Acessors for ImmutabilityPeriodSinceCreationInDay</summary>
        int? Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IUpdateHistoryPropertyInternal.ImmutabilityPeriodSinceCreationInDay { get => this._immutabilityPeriodSinceCreationInDay; set { {_immutabilityPeriodSinceCreationInDay = value;} } }

        /// <summary>Internal Acessors for ObjectIdentifier</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IUpdateHistoryPropertyInternal.ObjectIdentifier { get => this._objectIdentifier; set { {_objectIdentifier = value;} } }

        /// <summary>Internal Acessors for TenantId</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IUpdateHistoryPropertyInternal.TenantId { get => this._tenantId; set { {_tenantId = value;} } }

        /// <summary>Internal Acessors for Timestamp</summary>
        global::System.DateTime? Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IUpdateHistoryPropertyInternal.Timestamp { get => this._timestamp; set { {_timestamp = value;} } }

        /// <summary>Internal Acessors for Update</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.ImmutabilityPolicyUpdateType? Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IUpdateHistoryPropertyInternal.Update { get => this._update; set { {_update = value;} } }

        /// <summary>Internal Acessors for Upn</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IUpdateHistoryPropertyInternal.Upn { get => this._upn; set { {_upn = value;} } }

        /// <summary>Backing field for <see cref="ObjectIdentifier" /> property.</summary>
        private string _objectIdentifier;

        /// <summary>Returns the Object ID of the user who updated the ImmutabilityPolicy.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public string ObjectIdentifier { get => this._objectIdentifier; }

        /// <summary>Backing field for <see cref="TenantId" /> property.</summary>
        private string _tenantId;

        /// <summary>
        /// Returns the Tenant ID that issued the token for the user who updated the ImmutabilityPolicy.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public string TenantId { get => this._tenantId; }

        /// <summary>Backing field for <see cref="Timestamp" /> property.</summary>
        private global::System.DateTime? _timestamp;

        /// <summary>Returns the date and time the ImmutabilityPolicy was updated.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public global::System.DateTime? Timestamp { get => this._timestamp; }

        /// <summary>Backing field for <see cref="Update" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.ImmutabilityPolicyUpdateType? _update;

        /// <summary>
        /// The ImmutabilityPolicy update type of a blob container, possible values include: put, lock and extend.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.ImmutabilityPolicyUpdateType? Update { get => this._update; }

        /// <summary>Backing field for <see cref="Upn" /> property.</summary>
        private string _upn;

        /// <summary>Returns the User Principal Name of the user who updated the ImmutabilityPolicy.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public string Upn { get => this._upn; }

        /// <summary>Creates an new <see cref="UpdateHistoryProperty" /> instance.</summary>
        public UpdateHistoryProperty()
        {

        }
    }
    /// An update history of the ImmutabilityPolicy of a blob container.
    public partial interface IUpdateHistoryProperty :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.IJsonSerializable
    {
        /// <summary>
        /// The immutability period for the blobs in the container since the policy creation, in days.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"The immutability period for the blobs in the container since the policy creation, in days.",
        SerializedName = @"immutabilityPeriodSinceCreationInDays",
        PossibleTypes = new [] { typeof(int) })]
        int? ImmutabilityPeriodSinceCreationInDay { get;  }
        /// <summary>Returns the Object ID of the user who updated the ImmutabilityPolicy.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Returns the Object ID of the user who updated the ImmutabilityPolicy.",
        SerializedName = @"objectIdentifier",
        PossibleTypes = new [] { typeof(string) })]
        string ObjectIdentifier { get;  }
        /// <summary>
        /// Returns the Tenant ID that issued the token for the user who updated the ImmutabilityPolicy.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Returns the Tenant ID that issued the token for the user who updated the ImmutabilityPolicy.",
        SerializedName = @"tenantId",
        PossibleTypes = new [] { typeof(string) })]
        string TenantId { get;  }
        /// <summary>Returns the date and time the ImmutabilityPolicy was updated.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Returns the date and time the ImmutabilityPolicy was updated.",
        SerializedName = @"timestamp",
        PossibleTypes = new [] { typeof(global::System.DateTime) })]
        global::System.DateTime? Timestamp { get;  }
        /// <summary>
        /// The ImmutabilityPolicy update type of a blob container, possible values include: put, lock and extend.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"The ImmutabilityPolicy update type of a blob container, possible values include: put, lock and extend.",
        SerializedName = @"update",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.ImmutabilityPolicyUpdateType) })]
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.ImmutabilityPolicyUpdateType? Update { get;  }
        /// <summary>Returns the User Principal Name of the user who updated the ImmutabilityPolicy.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Returns the User Principal Name of the user who updated the ImmutabilityPolicy.",
        SerializedName = @"upn",
        PossibleTypes = new [] { typeof(string) })]
        string Upn { get;  }

    }
    /// An update history of the ImmutabilityPolicy of a blob container.
    internal partial interface IUpdateHistoryPropertyInternal

    {
        /// <summary>
        /// The immutability period for the blobs in the container since the policy creation, in days.
        /// </summary>
        int? ImmutabilityPeriodSinceCreationInDay { get; set; }
        /// <summary>Returns the Object ID of the user who updated the ImmutabilityPolicy.</summary>
        string ObjectIdentifier { get; set; }
        /// <summary>
        /// Returns the Tenant ID that issued the token for the user who updated the ImmutabilityPolicy.
        /// </summary>
        string TenantId { get; set; }
        /// <summary>Returns the date and time the ImmutabilityPolicy was updated.</summary>
        global::System.DateTime? Timestamp { get; set; }
        /// <summary>
        /// The ImmutabilityPolicy update type of a blob container, possible values include: put, lock and extend.
        /// </summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.ImmutabilityPolicyUpdateType? Update { get; set; }
        /// <summary>Returns the User Principal Name of the user who updated the ImmutabilityPolicy.</summary>
        string Upn { get; set; }

    }
}