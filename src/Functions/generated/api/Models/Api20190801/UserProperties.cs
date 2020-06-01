namespace Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Extensions;

    /// <summary>User resource specific properties</summary>
    public partial class UserProperties :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IUserProperties,
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IUserPropertiesInternal
    {

        /// <summary>Backing field for <see cref="PublishingPassword" /> property.</summary>
        private string _publishingPassword;

        /// <summary>Password used for publishing.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public string PublishingPassword { get => this._publishingPassword; set => this._publishingPassword = value; }

        /// <summary>Backing field for <see cref="PublishingPasswordHash" /> property.</summary>
        private string _publishingPasswordHash;

        /// <summary>Password hash used for publishing.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public string PublishingPasswordHash { get => this._publishingPasswordHash; set => this._publishingPasswordHash = value; }

        /// <summary>Backing field for <see cref="PublishingPasswordHashSalt" /> property.</summary>
        private string _publishingPasswordHashSalt;

        /// <summary>Password hash salt used for publishing.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public string PublishingPasswordHashSalt { get => this._publishingPasswordHashSalt; set => this._publishingPasswordHashSalt = value; }

        /// <summary>Backing field for <see cref="PublishingUserName" /> property.</summary>
        private string _publishingUserName;

        /// <summary>Username used for publishing.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public string PublishingUserName { get => this._publishingUserName; set => this._publishingUserName = value; }

        /// <summary>Backing field for <see cref="ScmUri" /> property.</summary>
        private string _scmUri;

        /// <summary>Url of SCM site.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public string ScmUri { get => this._scmUri; set => this._scmUri = value; }

        /// <summary>Creates an new <see cref="UserProperties" /> instance.</summary>
        public UserProperties()
        {

        }
    }
    /// User resource specific properties
    public partial interface IUserProperties :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.IJsonSerializable
    {
        /// <summary>Password used for publishing.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Password used for publishing.",
        SerializedName = @"publishingPassword",
        PossibleTypes = new [] { typeof(string) })]
        string PublishingPassword { get; set; }
        /// <summary>Password hash used for publishing.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Password hash used for publishing.",
        SerializedName = @"publishingPasswordHash",
        PossibleTypes = new [] { typeof(string) })]
        string PublishingPasswordHash { get; set; }
        /// <summary>Password hash salt used for publishing.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Password hash salt used for publishing.",
        SerializedName = @"publishingPasswordHashSalt",
        PossibleTypes = new [] { typeof(string) })]
        string PublishingPasswordHashSalt { get; set; }
        /// <summary>Username used for publishing.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"Username used for publishing.",
        SerializedName = @"publishingUserName",
        PossibleTypes = new [] { typeof(string) })]
        string PublishingUserName { get; set; }
        /// <summary>Url of SCM site.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Url of SCM site.",
        SerializedName = @"scmUri",
        PossibleTypes = new [] { typeof(string) })]
        string ScmUri { get; set; }

    }
    /// User resource specific properties
    internal partial interface IUserPropertiesInternal

    {
        /// <summary>Password used for publishing.</summary>
        string PublishingPassword { get; set; }
        /// <summary>Password hash used for publishing.</summary>
        string PublishingPasswordHash { get; set; }
        /// <summary>Password hash salt used for publishing.</summary>
        string PublishingPasswordHashSalt { get; set; }
        /// <summary>Username used for publishing.</summary>
        string PublishingUserName { get; set; }
        /// <summary>Url of SCM site.</summary>
        string ScmUri { get; set; }

    }
}