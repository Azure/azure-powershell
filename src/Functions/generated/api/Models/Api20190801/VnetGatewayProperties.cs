namespace Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Extensions;

    /// <summary>VnetGateway resource specific properties</summary>
    public partial class VnetGatewayProperties :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IVnetGatewayProperties,
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IVnetGatewayPropertiesInternal
    {

        /// <summary>Backing field for <see cref="VnetName" /> property.</summary>
        private string _vnetName;

        /// <summary>The Virtual Network name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public string VnetName { get => this._vnetName; set => this._vnetName = value; }

        /// <summary>Backing field for <see cref="VpnPackageUri" /> property.</summary>
        private string _vpnPackageUri;

        /// <summary>The URI where the VPN package can be downloaded.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public string VpnPackageUri { get => this._vpnPackageUri; set => this._vpnPackageUri = value; }

        /// <summary>Creates an new <see cref="VnetGatewayProperties" /> instance.</summary>
        public VnetGatewayProperties()
        {

        }
    }
    /// VnetGateway resource specific properties
    public partial interface IVnetGatewayProperties :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.IJsonSerializable
    {
        /// <summary>The Virtual Network name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The Virtual Network name.",
        SerializedName = @"vnetName",
        PossibleTypes = new [] { typeof(string) })]
        string VnetName { get; set; }
        /// <summary>The URI where the VPN package can be downloaded.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"The URI where the VPN package can be downloaded.",
        SerializedName = @"vpnPackageUri",
        PossibleTypes = new [] { typeof(string) })]
        string VpnPackageUri { get; set; }

    }
    /// VnetGateway resource specific properties
    internal partial interface IVnetGatewayPropertiesInternal

    {
        /// <summary>The Virtual Network name.</summary>
        string VnetName { get; set; }
        /// <summary>The URI where the VPN package can be downloaded.</summary>
        string VpnPackageUri { get; set; }

    }
}