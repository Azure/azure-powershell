namespace Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16
{
    using static Microsoft.Azure.PowerShell.Cmdlets.AD.Runtime.Extensions;

    public partial class OAuth2PermissionGrant :
        Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IOAuth2PermissionGrant,
        Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IOAuth2PermissionGrantInternal
    {

        /// <summary>Backing field for <see cref="ClientId" /> property.</summary>
        private string _clientId;

        /// <summary>
        /// The id of the resource's service principal granted consent to impersonate the user when accessing the resource (represented
        /// by the resourceId property).
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AD.Origin(Microsoft.Azure.PowerShell.Cmdlets.AD.PropertyOrigin.Owned)]
        public string ClientId { get => this._clientId; set => this._clientId = value; }

        /// <summary>Backing field for <see cref="ConsentType" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.AD.Support.ConsentType? _consentType;

        /// <summary>
        /// Indicates if consent was provided by the administrator (on behalf of the organization) or by an individual.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AD.Origin(Microsoft.Azure.PowerShell.Cmdlets.AD.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.AD.Support.ConsentType? ConsentType { get => this._consentType; set => this._consentType = value; }

        /// <summary>Backing field for <see cref="ExpiryTime" /> property.</summary>
        private string _expiryTime;

        /// <summary>Expiry time for TTL</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AD.Origin(Microsoft.Azure.PowerShell.Cmdlets.AD.PropertyOrigin.Owned)]
        public string ExpiryTime { get => this._expiryTime; set => this._expiryTime = value; }

        /// <summary>Backing field for <see cref="ObjectId" /> property.</summary>
        private string _objectId;

        /// <summary>The id of the permission grant</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AD.Origin(Microsoft.Azure.PowerShell.Cmdlets.AD.PropertyOrigin.Owned)]
        public string ObjectId { get => this._objectId; set => this._objectId = value; }

        /// <summary>Backing field for <see cref="OdataType" /> property.</summary>
        private string _odataType;

        /// <summary>Microsoft.DirectoryServices.OAuth2PermissionGrant</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AD.Origin(Microsoft.Azure.PowerShell.Cmdlets.AD.PropertyOrigin.Owned)]
        public string OdataType { get => this._odataType; set => this._odataType = value; }

        /// <summary>Backing field for <see cref="PrincipalId" /> property.</summary>
        private string _principalId;

        /// <summary>
        /// When consent type is Principal, this property specifies the id of the user that granted consent and applies only for that
        /// user.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AD.Origin(Microsoft.Azure.PowerShell.Cmdlets.AD.PropertyOrigin.Owned)]
        public string PrincipalId { get => this._principalId; set => this._principalId = value; }

        /// <summary>Backing field for <see cref="ResourceId" /> property.</summary>
        private string _resourceId;

        /// <summary>Object Id of the resource you want to grant</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AD.Origin(Microsoft.Azure.PowerShell.Cmdlets.AD.PropertyOrigin.Owned)]
        public string ResourceId { get => this._resourceId; set => this._resourceId = value; }

        /// <summary>Backing field for <see cref="Scope" /> property.</summary>
        private string _scope;

        /// <summary>
        /// Specifies the value of the scope claim that the resource application should expect in the OAuth 2.0 access token. For
        /// example, User.Read
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AD.Origin(Microsoft.Azure.PowerShell.Cmdlets.AD.PropertyOrigin.Owned)]
        public string Scope { get => this._scope; set => this._scope = value; }

        /// <summary>Backing field for <see cref="StartTime" /> property.</summary>
        private string _startTime;

        /// <summary>Start time for TTL</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AD.Origin(Microsoft.Azure.PowerShell.Cmdlets.AD.PropertyOrigin.Owned)]
        public string StartTime { get => this._startTime; set => this._startTime = value; }

        /// <summary>Creates an new <see cref="OAuth2PermissionGrant" /> instance.</summary>
        public OAuth2PermissionGrant()
        {

        }
    }
    public partial interface IOAuth2PermissionGrant :
        Microsoft.Azure.PowerShell.Cmdlets.AD.Runtime.IJsonSerializable
    {
        /// <summary>
        /// The id of the resource's service principal granted consent to impersonate the user when accessing the resource (represented
        /// by the resourceId property).
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AD.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The id of the resource's service principal granted consent to impersonate the user when accessing the resource (represented by the resourceId property).",
        SerializedName = @"clientId",
        PossibleTypes = new [] { typeof(string) })]
        string ClientId { get; set; }
        /// <summary>
        /// Indicates if consent was provided by the administrator (on behalf of the organization) or by an individual.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AD.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Indicates if consent was provided by the administrator (on behalf of the organization) or by an individual.",
        SerializedName = @"consentType",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.AD.Support.ConsentType) })]
        Microsoft.Azure.PowerShell.Cmdlets.AD.Support.ConsentType? ConsentType { get; set; }
        /// <summary>Expiry time for TTL</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AD.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Expiry time for TTL",
        SerializedName = @"expiryTime",
        PossibleTypes = new [] { typeof(string) })]
        string ExpiryTime { get; set; }
        /// <summary>The id of the permission grant</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AD.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The id of the permission grant",
        SerializedName = @"objectId",
        PossibleTypes = new [] { typeof(string) })]
        string ObjectId { get; set; }
        /// <summary>Microsoft.DirectoryServices.OAuth2PermissionGrant</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AD.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Microsoft.DirectoryServices.OAuth2PermissionGrant",
        SerializedName = @"odata.type",
        PossibleTypes = new [] { typeof(string) })]
        string OdataType { get; set; }
        /// <summary>
        /// When consent type is Principal, this property specifies the id of the user that granted consent and applies only for that
        /// user.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AD.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"When consent type is Principal, this property specifies the id of the user that granted consent and applies only for that user.",
        SerializedName = @"principalId",
        PossibleTypes = new [] { typeof(string) })]
        string PrincipalId { get; set; }
        /// <summary>Object Id of the resource you want to grant</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AD.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Object Id of the resource you want to grant",
        SerializedName = @"resourceId",
        PossibleTypes = new [] { typeof(string) })]
        string ResourceId { get; set; }
        /// <summary>
        /// Specifies the value of the scope claim that the resource application should expect in the OAuth 2.0 access token. For
        /// example, User.Read
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AD.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Specifies the value of the scope claim that the resource application should expect in the OAuth 2.0 access token. For example, User.Read",
        SerializedName = @"scope",
        PossibleTypes = new [] { typeof(string) })]
        string Scope { get; set; }
        /// <summary>Start time for TTL</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AD.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Start time for TTL",
        SerializedName = @"startTime",
        PossibleTypes = new [] { typeof(string) })]
        string StartTime { get; set; }

    }
    internal partial interface IOAuth2PermissionGrantInternal

    {
        /// <summary>
        /// The id of the resource's service principal granted consent to impersonate the user when accessing the resource (represented
        /// by the resourceId property).
        /// </summary>
        string ClientId { get; set; }
        /// <summary>
        /// Indicates if consent was provided by the administrator (on behalf of the organization) or by an individual.
        /// </summary>
        Microsoft.Azure.PowerShell.Cmdlets.AD.Support.ConsentType? ConsentType { get; set; }
        /// <summary>Expiry time for TTL</summary>
        string ExpiryTime { get; set; }
        /// <summary>The id of the permission grant</summary>
        string ObjectId { get; set; }
        /// <summary>Microsoft.DirectoryServices.OAuth2PermissionGrant</summary>
        string OdataType { get; set; }
        /// <summary>
        /// When consent type is Principal, this property specifies the id of the user that granted consent and applies only for that
        /// user.
        /// </summary>
        string PrincipalId { get; set; }
        /// <summary>Object Id of the resource you want to grant</summary>
        string ResourceId { get; set; }
        /// <summary>
        /// Specifies the value of the scope claim that the resource application should expect in the OAuth 2.0 access token. For
        /// example, User.Read
        /// </summary>
        string Scope { get; set; }
        /// <summary>Start time for TTL</summary>
        string StartTime { get; set; }

    }
}