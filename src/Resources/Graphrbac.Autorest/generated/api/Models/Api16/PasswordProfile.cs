namespace Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16
{
    using static Microsoft.Azure.PowerShell.Cmdlets.AD.Runtime.Extensions;

    /// <summary>The password profile associated with a user.</summary>
    public partial class PasswordProfile :
        Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IPasswordProfile,
        Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IPasswordProfileInternal
    {

        /// <summary>Backing field for <see cref="ForceChangePasswordNextLogin" /> property.</summary>
        private bool? _forceChangePasswordNextLogin;

        /// <summary>Whether to force a password change on next login.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AD.Origin(Microsoft.Azure.PowerShell.Cmdlets.AD.PropertyOrigin.Owned)]
        public bool? ForceChangePasswordNextLogin { get => this._forceChangePasswordNextLogin; set => this._forceChangePasswordNextLogin = value; }

        /// <summary>Backing field for <see cref="Password" /> property.</summary>
        private string _password;

        /// <summary>Password</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AD.Origin(Microsoft.Azure.PowerShell.Cmdlets.AD.PropertyOrigin.Owned)]
        public string Password { get => this._password; set => this._password = value; }

        /// <summary>Creates an new <see cref="PasswordProfile" /> instance.</summary>
        public PasswordProfile()
        {

        }
    }
    /// The password profile associated with a user.
    public partial interface IPasswordProfile :
        Microsoft.Azure.PowerShell.Cmdlets.AD.Runtime.IJsonSerializable,
        Microsoft.Azure.PowerShell.Cmdlets.AD.Runtime.IAssociativeArray<global::System.Object>
    {
        /// <summary>Whether to force a password change on next login.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AD.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Whether to force a password change on next login.",
        SerializedName = @"forceChangePasswordNextLogin",
        PossibleTypes = new [] { typeof(bool) })]
        bool? ForceChangePasswordNextLogin { get; set; }
        /// <summary>Password</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AD.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"Password",
        SerializedName = @"password",
        PossibleTypes = new [] { typeof(string) })]
        string Password { get; set; }

    }
    /// The password profile associated with a user.
    internal partial interface IPasswordProfileInternal

    {
        /// <summary>Whether to force a password change on next login.</summary>
        bool? ForceChangePasswordNextLogin { get; set; }
        /// <summary>Password</summary>
        string Password { get; set; }

    }
}