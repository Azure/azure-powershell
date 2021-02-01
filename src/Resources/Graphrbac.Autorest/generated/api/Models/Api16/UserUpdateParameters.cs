namespace Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16
{
    using static Microsoft.Azure.PowerShell.Cmdlets.AD.Runtime.Extensions;

    /// <summary>Request parameters for updating an existing work or school account user.</summary>
    public partial class UserUpdateParameters :
        Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IUserUpdateParameters,
        Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IUserUpdateParametersInternal,
        Microsoft.Azure.PowerShell.Cmdlets.AD.Runtime.IValidates
    {
        /// <summary>
        /// Backing field for Inherited model <see cref= "Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IUserBase" />
        /// </summary>
        private Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IUserBase __userBase = new Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.UserBase();

        /// <summary>Backing field for <see cref="AccountEnabled" /> property.</summary>
        private bool? _accountEnabled;

        /// <summary>Whether the account is enabled.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AD.Origin(Microsoft.Azure.PowerShell.Cmdlets.AD.PropertyOrigin.Owned)]
        public bool? AccountEnabled { get => this._accountEnabled; set => this._accountEnabled = value; }

        /// <summary>Backing field for <see cref="DisplayName" /> property.</summary>
        private string _displayName;

        /// <summary>The display name of the user.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AD.Origin(Microsoft.Azure.PowerShell.Cmdlets.AD.PropertyOrigin.Owned)]
        public string DisplayName { get => this._displayName; set => this._displayName = value; }

        /// <summary>The given name for the user.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AD.Origin(Microsoft.Azure.PowerShell.Cmdlets.AD.PropertyOrigin.Inherited)]
        public string GivenName { get => ((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IUserBaseInternal)__userBase).GivenName; set => ((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IUserBaseInternal)__userBase).GivenName = value; }

        /// <summary>
        /// This must be specified if you are using a federated domain for the user's userPrincipalName (UPN) property when creating
        /// a new user account. It is used to associate an on-premises Active Directory user account with their Azure AD user object.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AD.Origin(Microsoft.Azure.PowerShell.Cmdlets.AD.PropertyOrigin.Inherited)]
        public string ImmutableId { get => ((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IUserBaseInternal)__userBase).ImmutableId; set => ((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IUserBaseInternal)__userBase).ImmutableId = value; }

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

        /// <summary>Backing field for <see cref="PasswordProfile" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IPasswordProfile _passwordProfile;

        /// <summary>The password profile of the user.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AD.Origin(Microsoft.Azure.PowerShell.Cmdlets.AD.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IPasswordProfile PasswordProfile { get => (this._passwordProfile = this._passwordProfile ?? new Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.PasswordProfile()); set => this._passwordProfile = value; }

        /// <summary>The user's surname (family name or last name).</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AD.Origin(Microsoft.Azure.PowerShell.Cmdlets.AD.PropertyOrigin.Inherited)]
        public string Surname { get => ((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IUserBaseInternal)__userBase).Surname; set => ((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IUserBaseInternal)__userBase).Surname = value; }

        /// <summary>
        /// A two letter country code (ISO standard 3166). Required for users that will be assigned licenses due to legal requirement
        /// to check for availability of services in countries. Examples include: "US", "JP", and "GB".
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AD.Origin(Microsoft.Azure.PowerShell.Cmdlets.AD.PropertyOrigin.Inherited)]
        public string UsageLocation { get => ((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IUserBaseInternal)__userBase).UsageLocation; set => ((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IUserBaseInternal)__userBase).UsageLocation = value; }

        /// <summary>Backing field for <see cref="UserPrincipalName" /> property.</summary>
        private string _userPrincipalName;

        /// <summary>
        /// The user principal name (someuser@contoso.com). It must contain one of the verified domains for the tenant.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AD.Origin(Microsoft.Azure.PowerShell.Cmdlets.AD.PropertyOrigin.Owned)]
        public string UserPrincipalName { get => this._userPrincipalName; set => this._userPrincipalName = value; }

        /// <summary>
        /// A string value that can be used to classify user types in your directory, such as 'Member' and 'Guest'.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AD.Origin(Microsoft.Azure.PowerShell.Cmdlets.AD.PropertyOrigin.Inherited)]
        public Microsoft.Azure.PowerShell.Cmdlets.AD.Support.UserType? UserType { get => ((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IUserBaseInternal)__userBase).UserType; set => ((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IUserBaseInternal)__userBase).UserType = value; }

        /// <summary>Creates an new <see cref="UserUpdateParameters" /> instance.</summary>
        public UserUpdateParameters()
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
            await eventListener.AssertNotNull(nameof(__userBase), __userBase);
            await eventListener.AssertObjectIsValid(nameof(__userBase), __userBase);
        }
    }
    /// Request parameters for updating an existing work or school account user.
    public partial interface IUserUpdateParameters :
        Microsoft.Azure.PowerShell.Cmdlets.AD.Runtime.IJsonSerializable,
        Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IUserBase
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
        /// <summary>The password profile of the user.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AD.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The password profile of the user.",
        SerializedName = @"passwordProfile",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IPasswordProfile) })]
        Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IPasswordProfile PasswordProfile { get; set; }
        /// <summary>
        /// The user principal name (someuser@contoso.com). It must contain one of the verified domains for the tenant.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AD.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The user principal name (someuser@contoso.com). It must contain one of the verified domains for the tenant.",
        SerializedName = @"userPrincipalName",
        PossibleTypes = new [] { typeof(string) })]
        string UserPrincipalName { get; set; }

    }
    /// Request parameters for updating an existing work or school account user.
    internal partial interface IUserUpdateParametersInternal :
        Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IUserBaseInternal
    {
        /// <summary>Whether the account is enabled.</summary>
        bool? AccountEnabled { get; set; }
        /// <summary>The display name of the user.</summary>
        string DisplayName { get; set; }
        /// <summary>The primary email address of the user.</summary>
        string Mail { get; set; }
        /// <summary>The mail alias for the user.</summary>
        string MailNickname { get; set; }
        /// <summary>The password profile of the user.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IPasswordProfile PasswordProfile { get; set; }
        /// <summary>
        /// The user principal name (someuser@contoso.com). It must contain one of the verified domains for the tenant.
        /// </summary>
        string UserPrincipalName { get; set; }

    }
}