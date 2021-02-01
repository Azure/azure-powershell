namespace Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16
{
    using static Microsoft.Azure.PowerShell.Cmdlets.AD.Runtime.Extensions;

    /// <summary>KeyCredential list operation result.</summary>
    public partial class KeyCredentialListResult :
        Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IKeyCredentialListResult,
        Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IKeyCredentialListResultInternal
    {

        /// <summary>Backing field for <see cref="Value" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IKeyCredential[] _value;

        /// <summary>A collection of KeyCredentials.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AD.Origin(Microsoft.Azure.PowerShell.Cmdlets.AD.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IKeyCredential[] Value { get => this._value; set => this._value = value; }

        /// <summary>Creates an new <see cref="KeyCredentialListResult" /> instance.</summary>
        public KeyCredentialListResult()
        {

        }
    }
    /// KeyCredential list operation result.
    public partial interface IKeyCredentialListResult :
        Microsoft.Azure.PowerShell.Cmdlets.AD.Runtime.IJsonSerializable
    {
        /// <summary>A collection of KeyCredentials.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AD.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"A collection of KeyCredentials.",
        SerializedName = @"value",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IKeyCredential) })]
        Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IKeyCredential[] Value { get; set; }

    }
    /// KeyCredential list operation result.
    internal partial interface IKeyCredentialListResultInternal

    {
        /// <summary>A collection of KeyCredentials.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IKeyCredential[] Value { get; set; }

    }
}