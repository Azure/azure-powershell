namespace Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16
{
    using static Microsoft.Azure.PowerShell.Cmdlets.AD.Runtime.Extensions;

    /// <summary>Request parameters for a KeyCredentials update operation</summary>
    public partial class KeyCredentialsUpdateParameters :
        Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IKeyCredentialsUpdateParameters,
        Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IKeyCredentialsUpdateParametersInternal
    {

        /// <summary>Backing field for <see cref="Value" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IKeyCredential[] _value;

        /// <summary>A collection of KeyCredentials.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AD.Origin(Microsoft.Azure.PowerShell.Cmdlets.AD.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IKeyCredential[] Value { get => this._value; set => this._value = value; }

        /// <summary>Creates an new <see cref="KeyCredentialsUpdateParameters" /> instance.</summary>
        public KeyCredentialsUpdateParameters()
        {

        }
    }
    /// Request parameters for a KeyCredentials update operation
    public partial interface IKeyCredentialsUpdateParameters :
        Microsoft.Azure.PowerShell.Cmdlets.AD.Runtime.IJsonSerializable
    {
        /// <summary>A collection of KeyCredentials.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AD.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"A collection of KeyCredentials.",
        SerializedName = @"value",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IKeyCredential) })]
        Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IKeyCredential[] Value { get; set; }

    }
    /// Request parameters for a KeyCredentials update operation
    internal partial interface IKeyCredentialsUpdateParametersInternal

    {
        /// <summary>A collection of KeyCredentials.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IKeyCredential[] Value { get; set; }

    }
}