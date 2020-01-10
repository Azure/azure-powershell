namespace Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Extensions;

    /// <summary>The virtual network connection reset shared key</summary>
    public partial class ConnectionResetSharedKey :
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IConnectionResetSharedKey,
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IConnectionResetSharedKeyInternal
    {

        /// <summary>Backing field for <see cref="KeyLength" /> property.</summary>
        private int _keyLength;

        /// <summary>
        /// The virtual network connection reset shared key length, should between 1 and 128.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public int KeyLength { get => this._keyLength; set => this._keyLength = value; }

        /// <summary>Creates an new <see cref="ConnectionResetSharedKey" /> instance.</summary>
        public ConnectionResetSharedKey()
        {

        }
    }
    /// The virtual network connection reset shared key
    public partial interface IConnectionResetSharedKey :
        Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.IJsonSerializable
    {
        /// <summary>
        /// The virtual network connection reset shared key length, should between 1 and 128.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"The virtual network connection reset shared key length, should between 1 and 128.",
        SerializedName = @"keyLength",
        PossibleTypes = new [] { typeof(int) })]
        int KeyLength { get; set; }

    }
    /// The virtual network connection reset shared key
    internal partial interface IConnectionResetSharedKeyInternal

    {
        /// <summary>
        /// The virtual network connection reset shared key length, should between 1 and 128.
        /// </summary>
        int KeyLength { get; set; }

    }
}