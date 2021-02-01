namespace Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16
{
    using static Microsoft.Azure.PowerShell.Cmdlets.AD.Runtime.Extensions;

    public partial class AppRole :
        Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IAppRole,
        Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IAppRoleInternal
    {

        /// <summary>Backing field for <see cref="AllowedMemberType" /> property.</summary>
        private string[] _allowedMemberType;

        /// <summary>
        /// Specifies whether this app role definition can be assigned to users and groups by setting to 'User', or to other applications
        /// (that are accessing this application in daemon service scenarios) by setting to 'Application', or to both.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AD.Origin(Microsoft.Azure.PowerShell.Cmdlets.AD.PropertyOrigin.Owned)]
        public string[] AllowedMemberType { get => this._allowedMemberType; set => this._allowedMemberType = value; }

        /// <summary>Backing field for <see cref="Description" /> property.</summary>
        private string _description;

        /// <summary>
        /// Permission help text that appears in the admin app assignment and consent experiences.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AD.Origin(Microsoft.Azure.PowerShell.Cmdlets.AD.PropertyOrigin.Owned)]
        public string Description { get => this._description; set => this._description = value; }

        /// <summary>Backing field for <see cref="DisplayName" /> property.</summary>
        private string _displayName;

        /// <summary>
        /// Display name for the permission that appears in the admin consent and app assignment experiences.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AD.Origin(Microsoft.Azure.PowerShell.Cmdlets.AD.PropertyOrigin.Owned)]
        public string DisplayName { get => this._displayName; set => this._displayName = value; }

        /// <summary>Backing field for <see cref="Id" /> property.</summary>
        private string _id;

        /// <summary>Unique role identifier inside the appRoles collection.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AD.Origin(Microsoft.Azure.PowerShell.Cmdlets.AD.PropertyOrigin.Owned)]
        public string Id { get => this._id; set => this._id = value; }

        /// <summary>Backing field for <see cref="IsEnabled" /> property.</summary>
        private bool? _isEnabled;

        /// <summary>
        /// When creating or updating a role definition, this must be set to true (which is the default). To delete a role, this must
        /// first be set to false. At that point, in a subsequent call, this role may be removed.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AD.Origin(Microsoft.Azure.PowerShell.Cmdlets.AD.PropertyOrigin.Owned)]
        public bool? IsEnabled { get => this._isEnabled; set => this._isEnabled = value; }

        /// <summary>Backing field for <see cref="Value" /> property.</summary>
        private string _value;

        /// <summary>
        /// Specifies the value of the roles claim that the application should expect in the authentication and access tokens.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AD.Origin(Microsoft.Azure.PowerShell.Cmdlets.AD.PropertyOrigin.Owned)]
        public string Value { get => this._value; set => this._value = value; }

        /// <summary>Creates an new <see cref="AppRole" /> instance.</summary>
        public AppRole()
        {

        }
    }
    public partial interface IAppRole :
        Microsoft.Azure.PowerShell.Cmdlets.AD.Runtime.IJsonSerializable
    {
        /// <summary>
        /// Specifies whether this app role definition can be assigned to users and groups by setting to 'User', or to other applications
        /// (that are accessing this application in daemon service scenarios) by setting to 'Application', or to both.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AD.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Specifies whether this app role definition can be assigned to users and groups by setting to 'User', or to other applications (that are accessing this application in daemon service scenarios) by setting to 'Application', or to both. ",
        SerializedName = @"allowedMemberTypes",
        PossibleTypes = new [] { typeof(string) })]
        string[] AllowedMemberType { get; set; }
        /// <summary>
        /// Permission help text that appears in the admin app assignment and consent experiences.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AD.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Permission help text that appears in the admin app assignment and consent experiences.",
        SerializedName = @"description",
        PossibleTypes = new [] { typeof(string) })]
        string Description { get; set; }
        /// <summary>
        /// Display name for the permission that appears in the admin consent and app assignment experiences.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AD.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Display name for the permission that appears in the admin consent and app assignment experiences.",
        SerializedName = @"displayName",
        PossibleTypes = new [] { typeof(string) })]
        string DisplayName { get; set; }
        /// <summary>Unique role identifier inside the appRoles collection.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AD.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Unique role identifier inside the appRoles collection.",
        SerializedName = @"id",
        PossibleTypes = new [] { typeof(string) })]
        string Id { get; set; }
        /// <summary>
        /// When creating or updating a role definition, this must be set to true (which is the default). To delete a role, this must
        /// first be set to false. At that point, in a subsequent call, this role may be removed.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AD.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"When creating or updating a role definition, this must be set to true (which is the default). To delete a role, this must first be set to false. At that point, in a subsequent call, this role may be removed.",
        SerializedName = @"isEnabled",
        PossibleTypes = new [] { typeof(bool) })]
        bool? IsEnabled { get; set; }
        /// <summary>
        /// Specifies the value of the roles claim that the application should expect in the authentication and access tokens.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AD.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Specifies the value of the roles claim that the application should expect in the authentication and access tokens.",
        SerializedName = @"value",
        PossibleTypes = new [] { typeof(string) })]
        string Value { get; set; }

    }
    internal partial interface IAppRoleInternal

    {
        /// <summary>
        /// Specifies whether this app role definition can be assigned to users and groups by setting to 'User', or to other applications
        /// (that are accessing this application in daemon service scenarios) by setting to 'Application', or to both.
        /// </summary>
        string[] AllowedMemberType { get; set; }
        /// <summary>
        /// Permission help text that appears in the admin app assignment and consent experiences.
        /// </summary>
        string Description { get; set; }
        /// <summary>
        /// Display name for the permission that appears in the admin consent and app assignment experiences.
        /// </summary>
        string DisplayName { get; set; }
        /// <summary>Unique role identifier inside the appRoles collection.</summary>
        string Id { get; set; }
        /// <summary>
        /// When creating or updating a role definition, this must be set to true (which is the default). To delete a role, this must
        /// first be set to false. At that point, in a subsequent call, this role may be removed.
        /// </summary>
        bool? IsEnabled { get; set; }
        /// <summary>
        /// Specifies the value of the roles claim that the application should expect in the authentication and access tokens.
        /// </summary>
        string Value { get; set; }

    }
}