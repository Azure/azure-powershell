namespace Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701
{
    using static Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Runtime.Extensions;

    /// <summary>Regenerate test key request payload</summary>
    public partial class RegenerateTestKeyRequestPayload :
        Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.IRegenerateTestKeyRequestPayload,
        Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.IRegenerateTestKeyRequestPayloadInternal
    {

        /// <summary>Backing field for <see cref="KeyType" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Support.TestKeyType _keyType;

        /// <summary>Type of the test key</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Origin(Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Support.TestKeyType KeyType { get => this._keyType; set => this._keyType = value; }

        /// <summary>Creates an new <see cref="RegenerateTestKeyRequestPayload" /> instance.</summary>
        public RegenerateTestKeyRequestPayload()
        {

        }
    }
    /// Regenerate test key request payload
    public partial interface IRegenerateTestKeyRequestPayload :
        Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Runtime.IJsonSerializable
    {
        /// <summary>Type of the test key</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"Type of the test key",
        SerializedName = @"keyType",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Support.TestKeyType) })]
        Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Support.TestKeyType KeyType { get; set; }

    }
    /// Regenerate test key request payload
    public partial interface IRegenerateTestKeyRequestPayloadInternal

    {
        /// <summary>Type of the test key</summary>
        Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Support.TestKeyType KeyType { get; set; }

    }
}