namespace Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16
{
    using static Microsoft.Azure.PowerShell.Cmdlets.AD.Runtime.Extensions;

    /// <summary>PasswordCredential list operation result.</summary>
    public partial class PasswordCredentialListResult :
        Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IPasswordCredentialListResult,
        Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IPasswordCredentialListResultInternal
    {

        /// <summary>Backing field for <see cref="Value" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IPasswordCredential[] _value;

        /// <summary>A collection of PasswordCredentials.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AD.Origin(Microsoft.Azure.PowerShell.Cmdlets.AD.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IPasswordCredential[] Value { get => this._value; set => this._value = value; }

        /// <summary>Creates an new <see cref="PasswordCredentialListResult" /> instance.</summary>
        public PasswordCredentialListResult()
        {

        }
    }
    /// PasswordCredential list operation result.
    public partial interface IPasswordCredentialListResult :
        Microsoft.Azure.PowerShell.Cmdlets.AD.Runtime.IJsonSerializable
    {
        /// <summary>A collection of PasswordCredentials.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AD.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"A collection of PasswordCredentials.",
        SerializedName = @"value",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IPasswordCredential) })]
        Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IPasswordCredential[] Value { get; set; }

    }
    /// PasswordCredential list operation result.
    internal partial interface IPasswordCredentialListResultInternal

    {
        /// <summary>A collection of PasswordCredentials.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IPasswordCredential[] Value { get; set; }

    }
}