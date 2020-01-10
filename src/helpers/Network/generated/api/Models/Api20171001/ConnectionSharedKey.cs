namespace Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Extensions;

    /// <summary>Response for GetConnectionSharedKey API service call</summary>
    public partial class ConnectionSharedKey :
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IConnectionSharedKey,
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IConnectionSharedKeyInternal
    {

        /// <summary>Backing field for <see cref="Value" /> property.</summary>
        private string _value;

        /// <summary>The virtual network connection shared key value.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public string Value { get => this._value; set => this._value = value; }

        /// <summary>Creates an new <see cref="ConnectionSharedKey" /> instance.</summary>
        public ConnectionSharedKey()
        {

        }
    }
    /// Response for GetConnectionSharedKey API service call
    public partial interface IConnectionSharedKey :
        Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.IJsonSerializable
    {
        /// <summary>The virtual network connection shared key value.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"The virtual network connection shared key value.",
        SerializedName = @"value",
        PossibleTypes = new [] { typeof(string) })]
        string Value { get; set; }

    }
    /// Response for GetConnectionSharedKey API service call
    internal partial interface IConnectionSharedKeyInternal

    {
        /// <summary>The virtual network connection shared key value.</summary>
        string Value { get; set; }

    }
}