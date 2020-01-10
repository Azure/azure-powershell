namespace Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Extensions;

    /// <summary>Response for list BGP peer status API service call</summary>
    public partial class BgpPeerStatusListResult :
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IBgpPeerStatusListResult,
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IBgpPeerStatusListResultInternal
    {

        /// <summary>Backing field for <see cref="Value" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IBgpPeerStatus[] _value;

        /// <summary>List of BGP peers</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IBgpPeerStatus[] Value { get => this._value; set => this._value = value; }

        /// <summary>Creates an new <see cref="BgpPeerStatusListResult" /> instance.</summary>
        public BgpPeerStatusListResult()
        {

        }
    }
    /// Response for list BGP peer status API service call
    public partial interface IBgpPeerStatusListResult :
        Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.IJsonSerializable
    {
        /// <summary>List of BGP peers</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"List of BGP peers",
        SerializedName = @"value",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IBgpPeerStatus) })]
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IBgpPeerStatus[] Value { get; set; }

    }
    /// Response for list BGP peer status API service call
    internal partial interface IBgpPeerStatusListResultInternal

    {
        /// <summary>List of BGP peers</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IBgpPeerStatus[] Value { get; set; }

    }
}