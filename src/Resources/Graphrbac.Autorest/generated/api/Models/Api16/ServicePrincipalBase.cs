namespace Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16
{
    using static Microsoft.Azure.PowerShell.Cmdlets.AD.Runtime.Extensions;

    /// <summary>
    /// Active Directory service principal common properties shared among GET, POST and PATCH
    /// </summary>
    public partial class ServicePrincipalBase :
        Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IServicePrincipalBase,
        Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IServicePrincipalBaseInternal
    {

        /// <summary>Backing field for <see cref="AccountEnabled" /> property.</summary>
        private bool? _accountEnabled;

        /// <summary>whether or not the service principal account is enabled</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AD.Origin(Microsoft.Azure.PowerShell.Cmdlets.AD.PropertyOrigin.Owned)]
        public bool? AccountEnabled { get => this._accountEnabled; set => this._accountEnabled = value; }

        /// <summary>Backing field for <see cref="AppRoleAssignmentRequired" /> property.</summary>
        private bool? _appRoleAssignmentRequired;

        /// <summary>
        /// Specifies whether an AppRoleAssignment to a user or group is required before Azure AD will issue a user or access token
        /// to the application.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AD.Origin(Microsoft.Azure.PowerShell.Cmdlets.AD.PropertyOrigin.Owned)]
        public bool? AppRoleAssignmentRequired { get => this._appRoleAssignmentRequired; set => this._appRoleAssignmentRequired = value; }

        /// <summary>Backing field for <see cref="KeyCredentials" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IKeyCredential[] _keyCredentials;

        /// <summary>The collection of key credentials associated with the service principal.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AD.Origin(Microsoft.Azure.PowerShell.Cmdlets.AD.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IKeyCredential[] KeyCredentials { get => this._keyCredentials; set => this._keyCredentials = value; }

        /// <summary>Backing field for <see cref="PasswordCredentials" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IPasswordCredential[] _passwordCredentials;

        /// <summary>The collection of password credentials associated with the service principal.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AD.Origin(Microsoft.Azure.PowerShell.Cmdlets.AD.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IPasswordCredential[] PasswordCredentials { get => this._passwordCredentials; set => this._passwordCredentials = value; }

        /// <summary>Backing field for <see cref="ServicePrincipalType" /> property.</summary>
        private string _servicePrincipalType;

        /// <summary>the type of the service principal</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AD.Origin(Microsoft.Azure.PowerShell.Cmdlets.AD.PropertyOrigin.Owned)]
        public string ServicePrincipalType { get => this._servicePrincipalType; set => this._servicePrincipalType = value; }

        /// <summary>Backing field for <see cref="Tag" /> property.</summary>
        private string[] _tag;

        /// <summary>
        /// Optional list of tags that you can apply to your service principals. Not nullable.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AD.Origin(Microsoft.Azure.PowerShell.Cmdlets.AD.PropertyOrigin.Owned)]
        public string[] Tag { get => this._tag; set => this._tag = value; }

        /// <summary>Creates an new <see cref="ServicePrincipalBase" /> instance.</summary>
        public ServicePrincipalBase()
        {

        }
    }
    /// Active Directory service principal common properties shared among GET, POST and PATCH
    public partial interface IServicePrincipalBase :
        Microsoft.Azure.PowerShell.Cmdlets.AD.Runtime.IJsonSerializable
    {
        /// <summary>whether or not the service principal account is enabled</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AD.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"whether or not the service principal account is enabled",
        SerializedName = @"accountEnabled",
        PossibleTypes = new [] { typeof(bool) })]
        bool? AccountEnabled { get; set; }
        /// <summary>
        /// Specifies whether an AppRoleAssignment to a user or group is required before Azure AD will issue a user or access token
        /// to the application.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AD.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Specifies whether an AppRoleAssignment to a user or group is required before Azure AD will issue a user or access token to the application.",
        SerializedName = @"appRoleAssignmentRequired",
        PossibleTypes = new [] { typeof(bool) })]
        bool? AppRoleAssignmentRequired { get; set; }
        /// <summary>The collection of key credentials associated with the service principal.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AD.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The collection of key credentials associated with the service principal.",
        SerializedName = @"keyCredentials",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IKeyCredential) })]
        Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IKeyCredential[] KeyCredentials { get; set; }
        /// <summary>The collection of password credentials associated with the service principal.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AD.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The collection of password credentials associated with the service principal.",
        SerializedName = @"passwordCredentials",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IPasswordCredential) })]
        Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IPasswordCredential[] PasswordCredentials { get; set; }
        /// <summary>the type of the service principal</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AD.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"the type of the service principal",
        SerializedName = @"servicePrincipalType",
        PossibleTypes = new [] { typeof(string) })]
        string ServicePrincipalType { get; set; }
        /// <summary>
        /// Optional list of tags that you can apply to your service principals. Not nullable.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AD.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Optional list of tags that you can apply to your service principals. Not nullable.",
        SerializedName = @"tags",
        PossibleTypes = new [] { typeof(string) })]
        string[] Tag { get; set; }

    }
    /// Active Directory service principal common properties shared among GET, POST and PATCH
    internal partial interface IServicePrincipalBaseInternal

    {
        /// <summary>whether or not the service principal account is enabled</summary>
        bool? AccountEnabled { get; set; }
        /// <summary>
        /// Specifies whether an AppRoleAssignment to a user or group is required before Azure AD will issue a user or access token
        /// to the application.
        /// </summary>
        bool? AppRoleAssignmentRequired { get; set; }
        /// <summary>The collection of key credentials associated with the service principal.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IKeyCredential[] KeyCredentials { get; set; }
        /// <summary>The collection of password credentials associated with the service principal.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IPasswordCredential[] PasswordCredentials { get; set; }
        /// <summary>the type of the service principal</summary>
        string ServicePrincipalType { get; set; }
        /// <summary>
        /// Optional list of tags that you can apply to your service principals. Not nullable.
        /// </summary>
        string[] Tag { get; set; }

    }
}