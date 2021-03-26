namespace Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api20210201Preview
{
    using static Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.Extensions;

    /// <summary>RecoveryPoint datastore details</summary>
    public partial class RecoveryPointDataStoreDetails :
        Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api20210201Preview.IRecoveryPointDataStoreDetails,
        Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api20210201Preview.IRecoveryPointDataStoreDetailsInternal
    {

        /// <summary>Backing field for <see cref="CreationTime" /> property.</summary>
        private global::System.DateTime? _creationTime;

        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Origin(Microsoft.Azure.PowerShell.Cmdlets.DataProtection.PropertyOrigin.Owned)]
        public global::System.DateTime? CreationTime { get => this._creationTime; set => this._creationTime = value; }

        /// <summary>Backing field for <see cref="ExpiryTime" /> property.</summary>
        private global::System.DateTime? _expiryTime;

        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Origin(Microsoft.Azure.PowerShell.Cmdlets.DataProtection.PropertyOrigin.Owned)]
        public global::System.DateTime? ExpiryTime { get => this._expiryTime; set => this._expiryTime = value; }

        /// <summary>Backing field for <see cref="Id" /> property.</summary>
        private string _id;

        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Origin(Microsoft.Azure.PowerShell.Cmdlets.DataProtection.PropertyOrigin.Owned)]
        public string Id { get => this._id; set => this._id = value; }

        /// <summary>Backing field for <see cref="MetaData" /> property.</summary>
        private string _metaData;

        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Origin(Microsoft.Azure.PowerShell.Cmdlets.DataProtection.PropertyOrigin.Owned)]
        public string MetaData { get => this._metaData; set => this._metaData = value; }

        /// <summary>Internal Acessors for RehydrationExpiryTime</summary>
        global::System.DateTime? Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api20210201Preview.IRecoveryPointDataStoreDetailsInternal.RehydrationExpiryTime { get => this._rehydrationExpiryTime; set { {_rehydrationExpiryTime = value;} } }

        /// <summary>Internal Acessors for RehydrationStatus</summary>
        Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Support.RehydrationStatus? Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api20210201Preview.IRecoveryPointDataStoreDetailsInternal.RehydrationStatus { get => this._rehydrationStatus; set { {_rehydrationStatus = value;} } }

        /// <summary>Backing field for <see cref="RehydrationExpiryTime" /> property.</summary>
        private global::System.DateTime? _rehydrationExpiryTime;

        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Origin(Microsoft.Azure.PowerShell.Cmdlets.DataProtection.PropertyOrigin.Owned)]
        public global::System.DateTime? RehydrationExpiryTime { get => this._rehydrationExpiryTime; }

        /// <summary>Backing field for <see cref="RehydrationStatus" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Support.RehydrationStatus? _rehydrationStatus;

        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Origin(Microsoft.Azure.PowerShell.Cmdlets.DataProtection.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Support.RehydrationStatus? RehydrationStatus { get => this._rehydrationStatus; }

        /// <summary>Backing field for <see cref="State" /> property.</summary>
        private string _state;

        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Origin(Microsoft.Azure.PowerShell.Cmdlets.DataProtection.PropertyOrigin.Owned)]
        public string State { get => this._state; set => this._state = value; }

        /// <summary>Backing field for <see cref="Type" /> property.</summary>
        private string _type;

        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Origin(Microsoft.Azure.PowerShell.Cmdlets.DataProtection.PropertyOrigin.Owned)]
        public string Type { get => this._type; set => this._type = value; }

        /// <summary>Backing field for <see cref="Visible" /> property.</summary>
        private bool? _visible;

        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Origin(Microsoft.Azure.PowerShell.Cmdlets.DataProtection.PropertyOrigin.Owned)]
        public bool? Visible { get => this._visible; set => this._visible = value; }

        /// <summary>Creates an new <see cref="RecoveryPointDataStoreDetails" /> instance.</summary>
        public RecoveryPointDataStoreDetails()
        {

        }
    }
    /// RecoveryPoint datastore details
    public partial interface IRecoveryPointDataStoreDetails :
        Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.IJsonSerializable
    {
        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"",
        SerializedName = @"creationTime",
        PossibleTypes = new [] { typeof(global::System.DateTime) })]
        global::System.DateTime? CreationTime { get; set; }

        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"",
        SerializedName = @"expiryTime",
        PossibleTypes = new [] { typeof(global::System.DateTime) })]
        global::System.DateTime? ExpiryTime { get; set; }

        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"",
        SerializedName = @"id",
        PossibleTypes = new [] { typeof(string) })]
        string Id { get; set; }

        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"",
        SerializedName = @"metaData",
        PossibleTypes = new [] { typeof(string) })]
        string MetaData { get; set; }

        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"",
        SerializedName = @"rehydrationExpiryTime",
        PossibleTypes = new [] { typeof(global::System.DateTime) })]
        global::System.DateTime? RehydrationExpiryTime { get;  }

        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"",
        SerializedName = @"rehydrationStatus",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Support.RehydrationStatus) })]
        Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Support.RehydrationStatus? RehydrationStatus { get;  }

        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"",
        SerializedName = @"state",
        PossibleTypes = new [] { typeof(string) })]
        string State { get; set; }

        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"",
        SerializedName = @"type",
        PossibleTypes = new [] { typeof(string) })]
        string Type { get; set; }

        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"",
        SerializedName = @"visible",
        PossibleTypes = new [] { typeof(bool) })]
        bool? Visible { get; set; }

    }
    /// RecoveryPoint datastore details
    internal partial interface IRecoveryPointDataStoreDetailsInternal

    {
        global::System.DateTime? CreationTime { get; set; }

        global::System.DateTime? ExpiryTime { get; set; }

        string Id { get; set; }

        string MetaData { get; set; }

        global::System.DateTime? RehydrationExpiryTime { get; set; }

        Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Support.RehydrationStatus? RehydrationStatus { get; set; }

        string State { get; set; }

        string Type { get; set; }

        bool? Visible { get; set; }

    }
}