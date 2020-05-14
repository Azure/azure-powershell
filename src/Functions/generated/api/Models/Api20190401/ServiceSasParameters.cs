namespace Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Extensions;

    /// <summary>The parameters to list service SAS credentials of a specific resource.</summary>
    public partial class ServiceSasParameters :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IServiceSasParameters,
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IServiceSasParametersInternal
    {

        /// <summary>Backing field for <see cref="CacheControl" /> property.</summary>
        private string _cacheControl;

        /// <summary>The response header override for cache control.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public string CacheControl { get => this._cacheControl; set => this._cacheControl = value; }

        /// <summary>Backing field for <see cref="CanonicalizedResource" /> property.</summary>
        private string _canonicalizedResource;

        /// <summary>The canonical path to the signed resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public string CanonicalizedResource { get => this._canonicalizedResource; set => this._canonicalizedResource = value; }

        /// <summary>Backing field for <see cref="ContentDisposition" /> property.</summary>
        private string _contentDisposition;

        /// <summary>The response header override for content disposition.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public string ContentDisposition { get => this._contentDisposition; set => this._contentDisposition = value; }

        /// <summary>Backing field for <see cref="ContentEncoding" /> property.</summary>
        private string _contentEncoding;

        /// <summary>The response header override for content encoding.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public string ContentEncoding { get => this._contentEncoding; set => this._contentEncoding = value; }

        /// <summary>Backing field for <see cref="ContentLanguage" /> property.</summary>
        private string _contentLanguage;

        /// <summary>The response header override for content language.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public string ContentLanguage { get => this._contentLanguage; set => this._contentLanguage = value; }

        /// <summary>Backing field for <see cref="ContentType" /> property.</summary>
        private string _contentType;

        /// <summary>The response header override for content type.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public string ContentType { get => this._contentType; set => this._contentType = value; }

        /// <summary>Backing field for <see cref="IPAddressOrRange" /> property.</summary>
        private string _iPAddressOrRange;

        /// <summary>An IP address or a range of IP addresses from which to accept requests.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public string IPAddressOrRange { get => this._iPAddressOrRange; set => this._iPAddressOrRange = value; }

        /// <summary>Backing field for <see cref="Identifier" /> property.</summary>
        private string _identifier;

        /// <summary>
        /// A unique value up to 64 characters in length that correlates to an access policy specified for the container, queue, or
        /// table.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public string Identifier { get => this._identifier; set => this._identifier = value; }

        /// <summary>Backing field for <see cref="KeyToSign" /> property.</summary>
        private string _keyToSign;

        /// <summary>The key to sign the account SAS token with.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public string KeyToSign { get => this._keyToSign; set => this._keyToSign = value; }

        /// <summary>Backing field for <see cref="PartitionKeyEnd" /> property.</summary>
        private string _partitionKeyEnd;

        /// <summary>The end of partition key.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public string PartitionKeyEnd { get => this._partitionKeyEnd; set => this._partitionKeyEnd = value; }

        /// <summary>Backing field for <see cref="PartitionKeyStart" /> property.</summary>
        private string _partitionKeyStart;

        /// <summary>The start of partition key.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public string PartitionKeyStart { get => this._partitionKeyStart; set => this._partitionKeyStart = value; }

        /// <summary>Backing field for <see cref="Permission" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.Permissions? _permission;

        /// <summary>
        /// The signed permissions for the service SAS. Possible values include: Read (r), Write (w), Delete (d), List (l), Add (a),
        /// Create (c), Update (u) and Process (p).
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.Permissions? Permission { get => this._permission; set => this._permission = value; }

        /// <summary>Backing field for <see cref="Protocol" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.HttpProtocol? _protocol;

        /// <summary>The protocol permitted for a request made with the account SAS.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.HttpProtocol? Protocol { get => this._protocol; set => this._protocol = value; }

        /// <summary>Backing field for <see cref="Resource" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.SignedResource? _resource;

        /// <summary>
        /// The signed services accessible with the service SAS. Possible values include: Blob (b), Container (c), File (f), Share
        /// (s).
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.SignedResource? Resource { get => this._resource; set => this._resource = value; }

        /// <summary>Backing field for <see cref="RowKeyEnd" /> property.</summary>
        private string _rowKeyEnd;

        /// <summary>The end of row key.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public string RowKeyEnd { get => this._rowKeyEnd; set => this._rowKeyEnd = value; }

        /// <summary>Backing field for <see cref="RowKeyStart" /> property.</summary>
        private string _rowKeyStart;

        /// <summary>The start of row key.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public string RowKeyStart { get => this._rowKeyStart; set => this._rowKeyStart = value; }

        /// <summary>Backing field for <see cref="SharedAccessExpiryTime" /> property.</summary>
        private global::System.DateTime? _sharedAccessExpiryTime;

        /// <summary>The time at which the shared access signature becomes invalid.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public global::System.DateTime? SharedAccessExpiryTime { get => this._sharedAccessExpiryTime; set => this._sharedAccessExpiryTime = value; }

        /// <summary>Backing field for <see cref="SharedAccessStartTime" /> property.</summary>
        private global::System.DateTime? _sharedAccessStartTime;

        /// <summary>The time at which the SAS becomes valid.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public global::System.DateTime? SharedAccessStartTime { get => this._sharedAccessStartTime; set => this._sharedAccessStartTime = value; }

        /// <summary>Creates an new <see cref="ServiceSasParameters" /> instance.</summary>
        public ServiceSasParameters()
        {

        }
    }
    /// The parameters to list service SAS credentials of a specific resource.
    public partial interface IServiceSasParameters :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.IJsonSerializable
    {
        /// <summary>The response header override for cache control.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The response header override for cache control.",
        SerializedName = @"rscc",
        PossibleTypes = new [] { typeof(string) })]
        string CacheControl { get; set; }
        /// <summary>The canonical path to the signed resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"The canonical path to the signed resource.",
        SerializedName = @"canonicalizedResource",
        PossibleTypes = new [] { typeof(string) })]
        string CanonicalizedResource { get; set; }
        /// <summary>The response header override for content disposition.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The response header override for content disposition.",
        SerializedName = @"rscd",
        PossibleTypes = new [] { typeof(string) })]
        string ContentDisposition { get; set; }
        /// <summary>The response header override for content encoding.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The response header override for content encoding.",
        SerializedName = @"rsce",
        PossibleTypes = new [] { typeof(string) })]
        string ContentEncoding { get; set; }
        /// <summary>The response header override for content language.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The response header override for content language.",
        SerializedName = @"rscl",
        PossibleTypes = new [] { typeof(string) })]
        string ContentLanguage { get; set; }
        /// <summary>The response header override for content type.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The response header override for content type.",
        SerializedName = @"rsct",
        PossibleTypes = new [] { typeof(string) })]
        string ContentType { get; set; }
        /// <summary>An IP address or a range of IP addresses from which to accept requests.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"An IP address or a range of IP addresses from which to accept requests.",
        SerializedName = @"signedIp",
        PossibleTypes = new [] { typeof(string) })]
        string IPAddressOrRange { get; set; }
        /// <summary>
        /// A unique value up to 64 characters in length that correlates to an access policy specified for the container, queue, or
        /// table.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"A unique value up to 64 characters in length that correlates to an access policy specified for the container, queue, or table.",
        SerializedName = @"signedIdentifier",
        PossibleTypes = new [] { typeof(string) })]
        string Identifier { get; set; }
        /// <summary>The key to sign the account SAS token with.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The key to sign the account SAS token with.",
        SerializedName = @"keyToSign",
        PossibleTypes = new [] { typeof(string) })]
        string KeyToSign { get; set; }
        /// <summary>The end of partition key.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The end of partition key.",
        SerializedName = @"endPk",
        PossibleTypes = new [] { typeof(string) })]
        string PartitionKeyEnd { get; set; }
        /// <summary>The start of partition key.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The start of partition key.",
        SerializedName = @"startPk",
        PossibleTypes = new [] { typeof(string) })]
        string PartitionKeyStart { get; set; }
        /// <summary>
        /// The signed permissions for the service SAS. Possible values include: Read (r), Write (w), Delete (d), List (l), Add (a),
        /// Create (c), Update (u) and Process (p).
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The signed permissions for the service SAS. Possible values include: Read (r), Write (w), Delete (d), List (l), Add (a), Create (c), Update (u) and Process (p).",
        SerializedName = @"signedPermission",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.Permissions) })]
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.Permissions? Permission { get; set; }
        /// <summary>The protocol permitted for a request made with the account SAS.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The protocol permitted for a request made with the account SAS.",
        SerializedName = @"signedProtocol",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.HttpProtocol) })]
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.HttpProtocol? Protocol { get; set; }
        /// <summary>
        /// The signed services accessible with the service SAS. Possible values include: Blob (b), Container (c), File (f), Share
        /// (s).
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The signed services accessible with the service SAS. Possible values include: Blob (b), Container (c), File (f), Share (s).",
        SerializedName = @"signedResource",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.SignedResource) })]
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.SignedResource? Resource { get; set; }
        /// <summary>The end of row key.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The end of row key.",
        SerializedName = @"endRk",
        PossibleTypes = new [] { typeof(string) })]
        string RowKeyEnd { get; set; }
        /// <summary>The start of row key.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The start of row key.",
        SerializedName = @"startRk",
        PossibleTypes = new [] { typeof(string) })]
        string RowKeyStart { get; set; }
        /// <summary>The time at which the shared access signature becomes invalid.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The time at which the shared access signature becomes invalid.",
        SerializedName = @"signedExpiry",
        PossibleTypes = new [] { typeof(global::System.DateTime) })]
        global::System.DateTime? SharedAccessExpiryTime { get; set; }
        /// <summary>The time at which the SAS becomes valid.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The time at which the SAS becomes valid.",
        SerializedName = @"signedStart",
        PossibleTypes = new [] { typeof(global::System.DateTime) })]
        global::System.DateTime? SharedAccessStartTime { get; set; }

    }
    /// The parameters to list service SAS credentials of a specific resource.
    internal partial interface IServiceSasParametersInternal

    {
        /// <summary>The response header override for cache control.</summary>
        string CacheControl { get; set; }
        /// <summary>The canonical path to the signed resource.</summary>
        string CanonicalizedResource { get; set; }
        /// <summary>The response header override for content disposition.</summary>
        string ContentDisposition { get; set; }
        /// <summary>The response header override for content encoding.</summary>
        string ContentEncoding { get; set; }
        /// <summary>The response header override for content language.</summary>
        string ContentLanguage { get; set; }
        /// <summary>The response header override for content type.</summary>
        string ContentType { get; set; }
        /// <summary>An IP address or a range of IP addresses from which to accept requests.</summary>
        string IPAddressOrRange { get; set; }
        /// <summary>
        /// A unique value up to 64 characters in length that correlates to an access policy specified for the container, queue, or
        /// table.
        /// </summary>
        string Identifier { get; set; }
        /// <summary>The key to sign the account SAS token with.</summary>
        string KeyToSign { get; set; }
        /// <summary>The end of partition key.</summary>
        string PartitionKeyEnd { get; set; }
        /// <summary>The start of partition key.</summary>
        string PartitionKeyStart { get; set; }
        /// <summary>
        /// The signed permissions for the service SAS. Possible values include: Read (r), Write (w), Delete (d), List (l), Add (a),
        /// Create (c), Update (u) and Process (p).
        /// </summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.Permissions? Permission { get; set; }
        /// <summary>The protocol permitted for a request made with the account SAS.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.HttpProtocol? Protocol { get; set; }
        /// <summary>
        /// The signed services accessible with the service SAS. Possible values include: Blob (b), Container (c), File (f), Share
        /// (s).
        /// </summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.SignedResource? Resource { get; set; }
        /// <summary>The end of row key.</summary>
        string RowKeyEnd { get; set; }
        /// <summary>The start of row key.</summary>
        string RowKeyStart { get; set; }
        /// <summary>The time at which the shared access signature becomes invalid.</summary>
        global::System.DateTime? SharedAccessExpiryTime { get; set; }
        /// <summary>The time at which the SAS becomes valid.</summary>
        global::System.DateTime? SharedAccessStartTime { get; set; }

    }
}