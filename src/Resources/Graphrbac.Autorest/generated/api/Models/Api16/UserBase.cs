namespace Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16
{
    using static Microsoft.Azure.PowerShell.Cmdlets.AD.Runtime.Extensions;

    public partial class UserBase :
        Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IUserBase,
        Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IUserBaseInternal
    {

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

        /// <summary>Backing field for <see cref="Surname" /> property.</summary>
        private string _surname;

        /// <summary>The user's surname (family name or last name).</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AD.Origin(Microsoft.Azure.PowerShell.Cmdlets.AD.PropertyOrigin.Owned)]
        public string Surname { get => this._surname; set => this._surname = value; }

        /// <summary>Backing field for <see cref="UsageLocation" /> property.</summary>
        private string _usageLocation;

        /// <summary>
        /// A two letter country code (ISO standard 3166). Required for users that will be assigned licenses due to legal requirement
        /// to check for availability of services in countries. Examples include: "US", "JP", and "GB".
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AD.Origin(Microsoft.Azure.PowerShell.Cmdlets.AD.PropertyOrigin.Owned)]
        public string UsageLocation { get => this._usageLocation; set => this._usageLocation = value; }

        /// <summary>Backing field for <see cref="UserType" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.AD.Support.UserType? _userType;

        /// <summary>
        /// A string value that can be used to classify user types in your directory, such as 'Member' and 'Guest'.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AD.Origin(Microsoft.Azure.PowerShell.Cmdlets.AD.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.AD.Support.UserType? UserType { get => this._userType; set => this._userType = value; }

        /// <summary>Creates an new <see cref="UserBase" /> instance.</summary>
        public UserBase()
        {

        }
    }
    public partial interface IUserBase :
        Microsoft.Azure.PowerShell.Cmdlets.AD.Runtime.IJsonSerializable,
        Microsoft.Azure.PowerShell.Cmdlets.AD.Runtime.IAssociativeArray<global::System.Object>
    {
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
        /// <summary>The user's surname (family name or last name).</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AD.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The user's surname (family name or last name).",
        SerializedName = @"surname",
        PossibleTypes = new [] { typeof(string) })]
        string Surname { get; set; }
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
        /// <summary>
        /// A string value that can be used to classify user types in your directory, such as 'Member' and 'Guest'.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AD.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"A string value that can be used to classify user types in your directory, such as 'Member' and 'Guest'.",
        SerializedName = @"userType",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.AD.Support.UserType) })]
        Microsoft.Azure.PowerShell.Cmdlets.AD.Support.UserType? UserType { get; set; }

    }
    internal partial interface IUserBaseInternal

    {
        /// <summary>The given name for the user.</summary>
        string GivenName { get; set; }
        /// <summary>
        /// This must be specified if you are using a federated domain for the user's userPrincipalName (UPN) property when creating
        /// a new user account. It is used to associate an on-premises Active Directory user account with their Azure AD user object.
        /// </summary>
        string ImmutableId { get; set; }
        /// <summary>The user's surname (family name or last name).</summary>
        string Surname { get; set; }
        /// <summary>
        /// A two letter country code (ISO standard 3166). Required for users that will be assigned licenses due to legal requirement
        /// to check for availability of services in countries. Examples include: "US", "JP", and "GB".
        /// </summary>
        string UsageLocation { get; set; }
        /// <summary>
        /// A string value that can be used to classify user types in your directory, such as 'Member' and 'Guest'.
        /// </summary>
        Microsoft.Azure.PowerShell.Cmdlets.AD.Support.UserType? UserType { get; set; }

    }
}