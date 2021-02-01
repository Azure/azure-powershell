namespace Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16
{
    using static Microsoft.Azure.PowerShell.Cmdlets.AD.Runtime.Extensions;

    /// <summary>Active Directory user information.</summary>
    public partial class User :
        Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IUser,
        Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IUserInternal,
        Microsoft.Azure.PowerShell.Cmdlets.AD.Runtime.IValidates
    {
        /// <summary>
        /// Backing field for Inherited model <see cref= "Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IDirectoryObject" />
        /// </summary>
        private Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IDirectoryObject __directoryObject = new Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.DirectoryObject();

        /// <summary>Backing field for <see cref="AccountEnabled" /> property.</summary>
        private bool? _accountEnabled;

        /// <summary>Whether the account is enabled.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AD.Origin(Microsoft.Azure.PowerShell.Cmdlets.AD.PropertyOrigin.Owned)]
        public bool? AccountEnabled { get => this._accountEnabled; set => this._accountEnabled = value; }

        /// <summary>The time at which the directory object was deleted.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AD.Origin(Microsoft.Azure.PowerShell.Cmdlets.AD.PropertyOrigin.Inherited)]
        public global::System.DateTime? DeletionTimestamp { get => ((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IDirectoryObjectInternal)__directoryObject).DeletionTimestamp; }

        /// <summary>Backing field for <see cref="DisplayName" /> property.</summary>
        private string _displayName;

        /// <summary>The display name of the user.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AD.Origin(Microsoft.Azure.PowerShell.Cmdlets.AD.PropertyOrigin.Owned)]
        public string DisplayName { get => this._displayName; set => this._displayName = value; }

        /// <summary>Backing field for <see cref="GivenName" /> property.</summary>
        private string _givenName;

        /// <summary>The given name for the user.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AD.Origin(Microsoft.Azure.PowerShell.Cmdlets.AD.PropertyOrigin.Owned)]
        public string GivenName { get => this._givenName; set => this._givenName = value; }

        /// <summary>Backing field for <see cref="ImmutableId" /> property.</summary>
        private string _immutableId;

        /// <summary>
        /// This must be specified if you are using a federated domain for the user's userPrincipalName (UPN) property when creating
        /// a new user account. It is used to associate an on-premises Active Directory user account with their Azure AD user object.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AD.Origin(Microsoft.Azure.PowerShell.Cmdlets.AD.PropertyOrigin.Owned)]
        public string ImmutableId { get => this._immutableId; set => this._immutableId = value; }

        /// <summary>Backing field for <see cref="Mail" /> property.</summary>
        private string _mail;

        /// <summary>The primary email address of the user.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AD.Origin(Microsoft.Azure.PowerShell.Cmdlets.AD.PropertyOrigin.Owned)]
        public string Mail { get => this._mail; set => this._mail = value; }

        /// <summary>Backing field for <see cref="MailNickname" /> property.</summary>
        private string _mailNickname;

        /// <summary>The mail alias for the user.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AD.Origin(Microsoft.Azure.PowerShell.Cmdlets.AD.PropertyOrigin.Owned)]
        public string MailNickname { get => this._mailNickname; set => this._mailNickname = value; }

        /// <summary>Internal Acessors for DeletionTimestamp</summary>
        global::System.DateTime? Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IDirectoryObjectInternal.DeletionTimestamp { get => ((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IDirectoryObjectInternal)__directoryObject).DeletionTimestamp; set => ((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IDirectoryObjectInternal)__directoryObject).DeletionTimestamp = value; }

        /// <summary>Internal Acessors for ObjectId</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IDirectoryObjectInternal.ObjectId { get => ((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IDirectoryObjectInternal)__directoryObject).ObjectId; set => ((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IDirectoryObjectInternal)__directoryObject).ObjectId = value; }

        /// <summary>The object ID.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AD.Origin(Microsoft.Azure.PowerShell.Cmdlets.AD.PropertyOrigin.Inherited)]
        public string ObjectId { get => ((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IDirectoryObjectInternal)__directoryObject).ObjectId; }

        /// <summary>The object type.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AD.Origin(Microsoft.Azure.PowerShell.Cmdlets.AD.PropertyOrigin.Inherited)]
        public string ObjectType { get => ((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IDirectoryObjectInternal)__directoryObject).ObjectType; set => ((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IDirectoryObjectInternal)__directoryObject).ObjectType = value; }

        /// <summary>Backing field for <see cref="PrincipalName" /> property.</summary>
        private string _principalName;

        /// <summary>The principal name of the user.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AD.Origin(Microsoft.Azure.PowerShell.Cmdlets.AD.PropertyOrigin.Owned)]
        public string PrincipalName { get => this._principalName; set => this._principalName = value; }

        /// <summary>Backing field for <see cref="SignInName" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.ISignInName[] _signInName;

        /// <summary>The sign-in names of the user.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AD.Origin(Microsoft.Azure.PowerShell.Cmdlets.AD.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.ISignInName[] SignInName { get => this._signInName; set => this._signInName = value; }

        /// <summary>Backing field for <see cref="Surname" /> property.</summary>
        private string _surname;

        /// <summary>The user's surname (family name or last name).</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AD.Origin(Microsoft.Azure.PowerShell.Cmdlets.AD.PropertyOrigin.Owned)]
        public string Surname { get => this._surname; set => this._surname = value; }

        /// <summary>Backing field for <see cref="Type" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.AD.Support.UserType? _type;

        /// <summary>
        /// A string value that can be used to classify user types in your directory, such as 'Member' and 'Guest'.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AD.Origin(Microsoft.Azure.PowerShell.Cmdlets.AD.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.AD.Support.UserType? Type { get => this._type; set => this._type = value; }

        /// <summary>Backing field for <see cref="UsageLocation" /> property.</summary>
        private string _usageLocation;

        /// <summary>
        /// A two letter country code (ISO standard 3166). Required for users that will be assigned licenses due to legal requirement
        /// to check for availability of services in countries. Examples include: "US", "JP", and "GB".
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AD.Origin(Microsoft.Azure.PowerShell.Cmdlets.AD.PropertyOrigin.Owned)]
        public string UsageLocation { get => this._usageLocation; set => this._usageLocation = value; }

        /// <summary>Creates an new <see cref="User" /> instance.</summary>
        public User()
        {

        }

        /// <summary>Validates that this object meets the validation criteria.</summary>
        /// <param name="eventListener">an <see cref="Microsoft.Azure.PowerShell.Cmdlets.AD.Runtime.IEventListener" /> instance that will receive validation
        /// events.</param>
        /// <returns>
        /// A < see cref = "global::System.Threading.Tasks.Task" /> that will be complete when validation is completed.
        /// </returns>
        public async global::System.Threading.Tasks.Task Validate(Microsoft.Azure.PowerShell.Cmdlets.AD.Runtime.IEventListener eventListener)
        {
            await eventListener.AssertNotNull(nameof(__directoryObject), __directoryObject);
            await eventListener.AssertObjectIsValid(nameof(__directoryObject), __directoryObject);
        }
    }
    /// Active Directory user information.
    public partial interface IUser :
        Microsoft.Azure.PowerShell.Cmdlets.AD.Runtime.IJsonSerializable,
        Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IDirectoryObject
    {
        /// <summary>Whether the account is enabled.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AD.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Whether the account is enabled.",
        SerializedName = @"accountEnabled",
        PossibleTypes = new [] { typeof(bool) })]
        bool? AccountEnabled { get; set; }
        /// <summary>The display name of the user.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AD.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The display name of the user.",
        SerializedName = @"displayName",
        PossibleTypes = new [] { typeof(string) })]
        string DisplayName { get; set; }
        /// <summary>The given name for the user.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AD.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The given name for the user.",
        SerializedName = @"givenName",
        PossibleTypes = new [] { typeof(string) })]
        string GivenName { get; set; }
        /// <summary>
        /// This must be specified if you are using a federated domain for the user's userPrincipalName (UPN) property when creating
        /// a new user account. It is used to associate an on-premises Active Directory user account with their Azure AD user object.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AD.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"This must be specified if you are using a federated domain for the user's userPrincipalName (UPN) property when creating a new user account. It is used to associate an on-premises Active Directory user account with their Azure AD user object.",
        SerializedName = @"immutableId",
        PossibleTypes = new [] { typeof(string) })]
        string ImmutableId { get; set; }
        /// <summary>The primary email address of the user.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AD.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The primary email address of the user.",
        SerializedName = @"mail",
        PossibleTypes = new [] { typeof(string) })]
        string Mail { get; set; }
        /// <summary>The mail alias for the user.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AD.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The mail alias for the user.",
        SerializedName = @"mailNickname",
        PossibleTypes = new [] { typeof(string) })]
        string MailNickname { get; set; }
        /// <summary>The principal name of the user.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AD.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The principal name of the user.",
        SerializedName = @"userPrincipalName",
        PossibleTypes = new [] { typeof(string) })]
        string PrincipalName { get; set; }
        /// <summary>The sign-in names of the user.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AD.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The sign-in names of the user.",
        SerializedName = @"signInNames",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.ISignInName) })]
        Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.ISignInName[] SignInName { get; set; }
        /// <summary>The user's surname (family name or last name).</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AD.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The user's surname (family name or last name).",
        SerializedName = @"surname",
        PossibleTypes = new [] { typeof(string) })]
        string Surname { get; set; }
        /// <summary>
        /// A string value that can be used to classify user types in your directory, such as 'Member' and 'Guest'.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AD.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"A string value that can be used to classify user types in your directory, such as 'Member' and 'Guest'.",
        SerializedName = @"userType",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.AD.Support.UserType) })]
        Microsoft.Azure.PowerShell.Cmdlets.AD.Support.UserType? Type { get; set; }
        /// <summary>
        /// A two letter country code (ISO standard 3166). Required for users that will be assigned licenses due to legal requirement
        /// to check for availability of services in countries. Examples include: "US", "JP", and "GB".
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AD.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"A two letter country code (ISO standard 3166). Required for users that will be assigned licenses due to legal requirement to check for availability of services in countries. Examples include: ""US"", ""JP"", and ""GB"".",
        SerializedName = @"usageLocation",
        PossibleTypes = new [] { typeof(string) })]
        string UsageLocation { get; set; }

    }
    /// Active Directory user information.
    internal partial interface IUserInternal :
        Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IDirectoryObjectInternal
    {
        /// <summary>Whether the account is enabled.</summary>
        bool? AccountEnabled { get; set; }
        /// <summary>The display name of the user.</summary>
        string DisplayName { get; set; }
        /// <summary>The given name for the user.</summary>
        string GivenName { get; set; }
        /// <summary>
        /// This must be specified if you are using a federated domain for the user's userPrincipalName (UPN) property when creating
        /// a new user account. It is used to associate an on-premises Active Directory user account with their Azure AD user object.
        /// </summary>
        string ImmutableId { get; set; }
        /// <summary>The primary email address of the user.</summary>
        string Mail { get; set; }
        /// <summary>The mail alias for the user.</summary>
        string MailNickname { get; set; }
        /// <summary>The principal name of the user.</summary>
        string PrincipalName { get; set; }
        /// <summary>The sign-in names of the user.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.ISignInName[] SignInName { get; set; }
        /// <summary>The user's surname (family name or last name).</summary>
        string Surname { get; set; }
        /// <summary>
        /// A string value that can be used to classify user types in your directory, such as 'Member' and 'Guest'.
        /// </summary>
        Microsoft.Azure.PowerShell.Cmdlets.AD.Support.UserType? Type { get; set; }
        /// <summary>
        /// A two letter country code (ISO standard 3166). Required for users that will be assigned licenses due to legal requirement
        /// to check for availability of services in countries. Examples include: "US", "JP", and "GB".
        /// </summary>
        string UsageLocation { get; set; }

    }
}