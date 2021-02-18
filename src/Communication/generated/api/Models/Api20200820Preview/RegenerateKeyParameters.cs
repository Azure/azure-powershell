namespace Microsoft.Azure.PowerShell.Cmdlets.Communication.Models.Api20200820Preview
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Communication.Runtime.Extensions;

    /// <summary>Parameters describes the request to regenerate access keys</summary>
    public partial class RegenerateKeyParameters :
        Microsoft.Azure.PowerShell.Cmdlets.Communication.Models.Api20200820Preview.IRegenerateKeyParameters,
        Microsoft.Azure.PowerShell.Cmdlets.Communication.Models.Api20200820Preview.IRegenerateKeyParametersInternal
    {

        /// <summary>Backing field for <see cref="KeyType" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Communication.Support.KeyType? _keyType;

        /// <summary>
        /// The keyType to regenerate. Must be either 'primary' or 'secondary'(case-insensitive).
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Communication.Origin(Microsoft.Azure.PowerShell.Cmdlets.Communication.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Communication.Support.KeyType? KeyType { get => this._keyType; set => this._keyType = value; }

        /// <summary>Creates an new <see cref="RegenerateKeyParameters" /> instance.</summary>
        public RegenerateKeyParameters()
        {

        }
    }
    /// Parameters describes the request to regenerate access keys
    public partial interface IRegenerateKeyParameters :
        Microsoft.Azure.PowerShell.Cmdlets.Communication.Runtime.IJsonSerializable
    {
        /// <summary>
        /// The keyType to regenerate. Must be either 'primary' or 'secondary'(case-insensitive).
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Communication.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The keyType to regenerate. Must be either 'primary' or 'secondary'(case-insensitive).",
        SerializedName = @"keyType",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Communication.Support.KeyType) })]
        Microsoft.Azure.PowerShell.Cmdlets.Communication.Support.KeyType? KeyType { get; set; }

    }
    /// Parameters describes the request to regenerate access keys
    internal partial interface IRegenerateKeyParametersInternal

    {
        /// <summary>
        /// The keyType to regenerate. Must be either 'primary' or 'secondary'(case-insensitive).
        /// </summary>
        Microsoft.Azure.PowerShell.Cmdlets.Communication.Support.KeyType? KeyType { get; set; }

    }
}