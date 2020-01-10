namespace Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Extensions;

    /// <summary>Vpn Profile Response for package generation</summary>
    public partial class VpnProfileResponse :
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVpnProfileResponse,
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVpnProfileResponseInternal
    {

        /// <summary>Backing field for <see cref="ProfileUrl" /> property.</summary>
        private string _profileUrl;

        /// <summary>URL to the VPN profile</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public string ProfileUrl { get => this._profileUrl; set => this._profileUrl = value; }

        /// <summary>Creates an new <see cref="VpnProfileResponse" /> instance.</summary>
        public VpnProfileResponse()
        {

        }
    }
    /// Vpn Profile Response for package generation
    public partial interface IVpnProfileResponse :
        Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.IJsonSerializable
    {
        /// <summary>URL to the VPN profile</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"URL to the VPN profile",
        SerializedName = @"profileUrl",
        PossibleTypes = new [] { typeof(string) })]
        string ProfileUrl { get; set; }

    }
    /// Vpn Profile Response for package generation
    internal partial interface IVpnProfileResponseInternal

    {
        /// <summary>URL to the VPN profile</summary>
        string ProfileUrl { get; set; }

    }
}