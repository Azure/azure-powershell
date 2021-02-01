namespace Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16
{
    using static Microsoft.Azure.PowerShell.Cmdlets.AD.Runtime.Extensions;

    /// <summary>Request parameters for a PasswordCredentials update operation.</summary>
    public partial class PasswordCredentialsUpdateParameters :
        Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IPasswordCredentialsUpdateParameters,
        Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IPasswordCredentialsUpdateParametersInternal
    {

        /// <summary>Backing field for <see cref="Value" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IPasswordCredential[] _value;

        /// <summary>A collection of PasswordCredentials.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AD.Origin(Microsoft.Azure.PowerShell.Cmdlets.AD.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IPasswordCredential[] Value { get => this._value; set => this._value = value; }

        /// <summary>Creates an new <see cref="PasswordCredentialsUpdateParameters" /> instance.</summary>
        public PasswordCredentialsUpdateParameters()
        {

        }
    }
    /// Request parameters for a PasswordCredentials update operation.
    public partial interface IPasswordCredentialsUpdateParameters :
        Microsoft.Azure.PowerShell.Cmdlets.AD.Runtime.IJsonSerializable
    {
        /// <summary>A collection of PasswordCredentials.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AD.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"A collection of PasswordCredentials.",
        SerializedName = @"value",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IPasswordCredential) })]
        Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IPasswordCredential[] Value { get; set; }

    }
    /// Request parameters for a PasswordCredentials update operation.
    internal partial interface IPasswordCredentialsUpdateParametersInternal

    {
        /// <summary>A collection of PasswordCredentials.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IPasswordCredential[] Value { get; set; }

    }
}