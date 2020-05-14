namespace Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Extensions;

    /// <summary>The properties of a storage account’s Blob service.</summary>
    public partial class BlobServiceProperties1 :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IBlobServiceProperties1,
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IBlobServiceProperties1Internal
    {

        /// <summary>Backing field for <see cref="AutomaticSnapshotPolicyEnabled" /> property.</summary>
        private bool? _automaticSnapshotPolicyEnabled;

        /// <summary>Automatic Snapshot is enabled if set to true.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public bool? AutomaticSnapshotPolicyEnabled { get => this._automaticSnapshotPolicyEnabled; set => this._automaticSnapshotPolicyEnabled = value; }

        /// <summary>Backing field for <see cref="ChangeFeed" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IChangeFeed _changeFeed;

        /// <summary>The blob service properties for change feed events.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IChangeFeed ChangeFeed { get => (this._changeFeed = this._changeFeed ?? new Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.ChangeFeed()); set => this._changeFeed = value; }

        /// <summary>Indicates whether change feed event logging is enabled for the Blob service.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public bool? ChangeFeedEnabled { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IChangeFeedInternal)ChangeFeed).Enabled; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IChangeFeedInternal)ChangeFeed).Enabled = value; }

        /// <summary>Backing field for <see cref="Cor" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.ICorsRules _cor;

        /// <summary>
        /// Specifies CORS rules for the Blob service. You can include up to five CorsRule elements in the request. If no CorsRule
        /// elements are included in the request body, all CORS rules will be deleted, and CORS will be disabled for the Blob service.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.ICorsRules Cor { get => (this._cor = this._cor ?? new Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.CorsRules()); set => this._cor = value; }

        /// <summary>
        /// The List of CORS rules. You can include up to five CorsRule elements in the request.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.ICorsRule[] CorCorsRule { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.ICorsRulesInternal)Cor).CorsRule; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.ICorsRulesInternal)Cor).CorsRule = value; }

        /// <summary>Backing field for <see cref="DefaultServiceVersion" /> property.</summary>
        private string _defaultServiceVersion;

        /// <summary>
        /// DefaultServiceVersion indicates the default version to use for requests to the Blob service if an incoming request’s version
        /// is not specified. Possible values include version 2008-10-27 and all more recent versions.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public string DefaultServiceVersion { get => this._defaultServiceVersion; set => this._defaultServiceVersion = value; }

        /// <summary>Backing field for <see cref="DeleteRetentionPolicy" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IDeleteRetentionPolicy _deleteRetentionPolicy;

        /// <summary>The blob service properties for soft delete.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IDeleteRetentionPolicy DeleteRetentionPolicy { get => (this._deleteRetentionPolicy = this._deleteRetentionPolicy ?? new Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.DeleteRetentionPolicy()); set => this._deleteRetentionPolicy = value; }

        /// <summary>
        /// Indicates the number of days that the deleted blob should be retained. The minimum specified value can be 1 and the maximum
        /// value can be 365.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public int? DeleteRetentionPolicyDay { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IDeleteRetentionPolicyInternal)DeleteRetentionPolicy).Day; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IDeleteRetentionPolicyInternal)DeleteRetentionPolicy).Day = value; }

        /// <summary>Indicates whether DeleteRetentionPolicy is enabled for the Blob service.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public bool? DeleteRetentionPolicyEnabled { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IDeleteRetentionPolicyInternal)DeleteRetentionPolicy).Enabled; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IDeleteRetentionPolicyInternal)DeleteRetentionPolicy).Enabled = value; }

        /// <summary>Internal Acessors for ChangeFeed</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IChangeFeed Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IBlobServiceProperties1Internal.ChangeFeed { get => (this._changeFeed = this._changeFeed ?? new Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.ChangeFeed()); set { {_changeFeed = value;} } }

        /// <summary>Internal Acessors for Cor</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.ICorsRules Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IBlobServiceProperties1Internal.Cor { get => (this._cor = this._cor ?? new Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.CorsRules()); set { {_cor = value;} } }

        /// <summary>Internal Acessors for DeleteRetentionPolicy</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IDeleteRetentionPolicy Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IBlobServiceProperties1Internal.DeleteRetentionPolicy { get => (this._deleteRetentionPolicy = this._deleteRetentionPolicy ?? new Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.DeleteRetentionPolicy()); set { {_deleteRetentionPolicy = value;} } }

        /// <summary>Creates an new <see cref="BlobServiceProperties1" /> instance.</summary>
        public BlobServiceProperties1()
        {

        }
    }
    /// The properties of a storage account’s Blob service.
    public partial interface IBlobServiceProperties1 :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.IJsonSerializable
    {
        /// <summary>Automatic Snapshot is enabled if set to true.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Automatic Snapshot is enabled if set to true.",
        SerializedName = @"automaticSnapshotPolicyEnabled",
        PossibleTypes = new [] { typeof(bool) })]
        bool? AutomaticSnapshotPolicyEnabled { get; set; }
        /// <summary>Indicates whether change feed event logging is enabled for the Blob service.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Indicates whether change feed event logging is enabled for the Blob service.",
        SerializedName = @"enabled",
        PossibleTypes = new [] { typeof(bool) })]
        bool? ChangeFeedEnabled { get; set; }
        /// <summary>
        /// The List of CORS rules. You can include up to five CorsRule elements in the request.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The List of CORS rules. You can include up to five CorsRule elements in the request. ",
        SerializedName = @"corsRules",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.ICorsRule) })]
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.ICorsRule[] CorCorsRule { get; set; }
        /// <summary>
        /// DefaultServiceVersion indicates the default version to use for requests to the Blob service if an incoming request’s version
        /// is not specified. Possible values include version 2008-10-27 and all more recent versions.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"DefaultServiceVersion indicates the default version to use for requests to the Blob service if an incoming request’s version is not specified. Possible values include version 2008-10-27 and all more recent versions.",
        SerializedName = @"defaultServiceVersion",
        PossibleTypes = new [] { typeof(string) })]
        string DefaultServiceVersion { get; set; }
        /// <summary>
        /// Indicates the number of days that the deleted blob should be retained. The minimum specified value can be 1 and the maximum
        /// value can be 365.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Indicates the number of days that the deleted blob should be retained. The minimum specified value can be 1 and the maximum value can be 365.",
        SerializedName = @"days",
        PossibleTypes = new [] { typeof(int) })]
        int? DeleteRetentionPolicyDay { get; set; }
        /// <summary>Indicates whether DeleteRetentionPolicy is enabled for the Blob service.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Indicates whether DeleteRetentionPolicy is enabled for the Blob service.",
        SerializedName = @"enabled",
        PossibleTypes = new [] { typeof(bool) })]
        bool? DeleteRetentionPolicyEnabled { get; set; }

    }
    /// The properties of a storage account’s Blob service.
    internal partial interface IBlobServiceProperties1Internal

    {
        /// <summary>Automatic Snapshot is enabled if set to true.</summary>
        bool? AutomaticSnapshotPolicyEnabled { get; set; }
        /// <summary>The blob service properties for change feed events.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IChangeFeed ChangeFeed { get; set; }
        /// <summary>Indicates whether change feed event logging is enabled for the Blob service.</summary>
        bool? ChangeFeedEnabled { get; set; }
        /// <summary>
        /// Specifies CORS rules for the Blob service. You can include up to five CorsRule elements in the request. If no CorsRule
        /// elements are included in the request body, all CORS rules will be deleted, and CORS will be disabled for the Blob service.
        /// </summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.ICorsRules Cor { get; set; }
        /// <summary>
        /// The List of CORS rules. You can include up to five CorsRule elements in the request.
        /// </summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.ICorsRule[] CorCorsRule { get; set; }
        /// <summary>
        /// DefaultServiceVersion indicates the default version to use for requests to the Blob service if an incoming request’s version
        /// is not specified. Possible values include version 2008-10-27 and all more recent versions.
        /// </summary>
        string DefaultServiceVersion { get; set; }
        /// <summary>The blob service properties for soft delete.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IDeleteRetentionPolicy DeleteRetentionPolicy { get; set; }
        /// <summary>
        /// Indicates the number of days that the deleted blob should be retained. The minimum specified value can be 1 and the maximum
        /// value can be 365.
        /// </summary>
        int? DeleteRetentionPolicyDay { get; set; }
        /// <summary>Indicates whether DeleteRetentionPolicy is enabled for the Blob service.</summary>
        bool? DeleteRetentionPolicyEnabled { get; set; }

    }
}