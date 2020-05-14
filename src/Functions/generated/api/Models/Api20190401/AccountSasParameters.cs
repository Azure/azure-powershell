namespace Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Extensions;

    /// <summary>The parameters to list SAS credentials of a storage account.</summary>
    public partial class AccountSasParameters :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IAccountSasParameters,
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IAccountSasParametersInternal
    {

        /// <summary>Backing field for <see cref="IPAddressOrRange" /> property.</summary>
        private string _iPAddressOrRange;

        /// <summary>An IP address or a range of IP addresses from which to accept requests.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public string IPAddressOrRange { get => this._iPAddressOrRange; set => this._iPAddressOrRange = value; }

        /// <summary>Backing field for <see cref="KeyToSign" /> property.</summary>
        private string _keyToSign;

        /// <summary>The key to sign the account SAS token with.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public string KeyToSign { get => this._keyToSign; set => this._keyToSign = value; }

        /// <summary>Backing field for <see cref="Permission" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.Permissions _permission;

        /// <summary>
        /// The signed permissions for the account SAS. Possible values include: Read (r), Write (w), Delete (d), List (l), Add (a),
        /// Create (c), Update (u) and Process (p).
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.Permissions Permission { get => this._permission; set => this._permission = value; }

        /// <summary>Backing field for <see cref="Protocol" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.HttpProtocol? _protocol;

        /// <summary>The protocol permitted for a request made with the account SAS.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.HttpProtocol? Protocol { get => this._protocol; set => this._protocol = value; }

        /// <summary>Backing field for <see cref="ResourceType" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.SignedResourceTypes _resourceType;

        /// <summary>
        /// The signed resource types that are accessible with the account SAS. Service (s): Access to service-level APIs; Container
        /// (c): Access to container-level APIs; Object (o): Access to object-level APIs for blobs, queue messages, table entities,
        /// and files.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.SignedResourceTypes ResourceType { get => this._resourceType; set => this._resourceType = value; }

        /// <summary>Backing field for <see cref="Service" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.Services _service;

        /// <summary>
        /// The signed services accessible with the account SAS. Possible values include: Blob (b), Queue (q), Table (t), File (f).
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.Services Service { get => this._service; set => this._service = value; }

        /// <summary>Backing field for <see cref="SharedAccessExpiryTime" /> property.</summary>
        private global::System.DateTime _sharedAccessExpiryTime;

        /// <summary>The time at which the shared access signature becomes invalid.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public global::System.DateTime SharedAccessExpiryTime { get => this._sharedAccessExpiryTime; set => this._sharedAccessExpiryTime = value; }

        /// <summary>Backing field for <see cref="SharedAccessStartTime" /> property.</summary>
        private global::System.DateTime? _sharedAccessStartTime;

        /// <summary>The time at which the SAS becomes valid.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public global::System.DateTime? SharedAccessStartTime { get => this._sharedAccessStartTime; set => this._sharedAccessStartTime = value; }

        /// <summary>Creates an new <see cref="AccountSasParameters" /> instance.</summary>
        public AccountSasParameters()
        {

        }
    }
    /// The parameters to list SAS credentials of a storage account.
    public partial interface IAccountSasParameters :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.IJsonSerializable
    {
        /// <summary>An IP address or a range of IP addresses from which to accept requests.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"An IP address or a range of IP addresses from which to accept requests.",
        SerializedName = @"signedIp",
        PossibleTypes = new [] { typeof(string) })]
        string IPAddressOrRange { get; set; }
        /// <summary>The key to sign the account SAS token with.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The key to sign the account SAS token with.",
        SerializedName = @"keyToSign",
        PossibleTypes = new [] { typeof(string) })]
        string KeyToSign { get; set; }
        /// <summary>
        /// The signed permissions for the account SAS. Possible values include: Read (r), Write (w), Delete (d), List (l), Add (a),
        /// Create (c), Update (u) and Process (p).
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"The signed permissions for the account SAS. Possible values include: Read (r), Write (w), Delete (d), List (l), Add (a), Create (c), Update (u) and Process (p).",
        SerializedName = @"signedPermission",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.Permissions) })]
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.Permissions Permission { get; set; }
        /// <summary>The protocol permitted for a request made with the account SAS.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The protocol permitted for a request made with the account SAS.",
        SerializedName = @"signedProtocol",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.HttpProtocol) })]
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.HttpProtocol? Protocol { get; set; }
        /// <summary>
        /// The signed resource types that are accessible with the account SAS. Service (s): Access to service-level APIs; Container
        /// (c): Access to container-level APIs; Object (o): Access to object-level APIs for blobs, queue messages, table entities,
        /// and files.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"The signed resource types that are accessible with the account SAS. Service (s): Access to service-level APIs; Container (c): Access to container-level APIs; Object (o): Access to object-level APIs for blobs, queue messages, table entities, and files.",
        SerializedName = @"signedResourceTypes",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.SignedResourceTypes) })]
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.SignedResourceTypes ResourceType { get; set; }
        /// <summary>
        /// The signed services accessible with the account SAS. Possible values include: Blob (b), Queue (q), Table (t), File (f).
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"The signed services accessible with the account SAS. Possible values include: Blob (b), Queue (q), Table (t), File (f).",
        SerializedName = @"signedServices",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.Services) })]
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.Services Service { get; set; }
        /// <summary>The time at which the shared access signature becomes invalid.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"The time at which the shared access signature becomes invalid.",
        SerializedName = @"signedExpiry",
        PossibleTypes = new [] { typeof(global::System.DateTime) })]
        global::System.DateTime SharedAccessExpiryTime { get; set; }
        /// <summary>The time at which the SAS becomes valid.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The time at which the SAS becomes valid.",
        SerializedName = @"signedStart",
        PossibleTypes = new [] { typeof(global::System.DateTime) })]
        global::System.DateTime? SharedAccessStartTime { get; set; }

    }
    /// The parameters to list SAS credentials of a storage account.
    internal partial interface IAccountSasParametersInternal

    {
        /// <summary>An IP address or a range of IP addresses from which to accept requests.</summary>
        string IPAddressOrRange { get; set; }
        /// <summary>The key to sign the account SAS token with.</summary>
        string KeyToSign { get; set; }
        /// <summary>
        /// The signed permissions for the account SAS. Possible values include: Read (r), Write (w), Delete (d), List (l), Add (a),
        /// Create (c), Update (u) and Process (p).
        /// </summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.Permissions Permission { get; set; }
        /// <summary>The protocol permitted for a request made with the account SAS.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.HttpProtocol? Protocol { get; set; }
        /// <summary>
        /// The signed resource types that are accessible with the account SAS. Service (s): Access to service-level APIs; Container
        /// (c): Access to container-level APIs; Object (o): Access to object-level APIs for blobs, queue messages, table entities,
        /// and files.
        /// </summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.SignedResourceTypes ResourceType { get; set; }
        /// <summary>
        /// The signed services accessible with the account SAS. Possible values include: Blob (b), Queue (q), Table (t), File (f).
        /// </summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.Services Service { get; set; }
        /// <summary>The time at which the shared access signature becomes invalid.</summary>
        global::System.DateTime SharedAccessExpiryTime { get; set; }
        /// <summary>The time at which the SAS becomes valid.</summary>
        global::System.DateTime? SharedAccessStartTime { get; set; }

    }
}