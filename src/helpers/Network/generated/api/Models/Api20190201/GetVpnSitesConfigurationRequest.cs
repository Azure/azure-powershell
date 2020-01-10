namespace Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Extensions;

    /// <summary>List of Vpn-Sites</summary>
    public partial class GetVpnSitesConfigurationRequest :
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IGetVpnSitesConfigurationRequest,
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IGetVpnSitesConfigurationRequestInternal
    {

        /// <summary>Backing field for <see cref="OutputBlobSasUrl" /> property.</summary>
        private string _outputBlobSasUrl;

        /// <summary>The sas-url to download the configurations for vpn-sites</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public string OutputBlobSasUrl { get => this._outputBlobSasUrl; set => this._outputBlobSasUrl = value; }

        /// <summary>Backing field for <see cref="VpnSite" /> property.</summary>
        private string[] _vpnSite;

        /// <summary>List of resource-ids of the vpn-sites for which config is to be downloaded.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public string[] VpnSite { get => this._vpnSite; set => this._vpnSite = value; }

        /// <summary>Creates an new <see cref="GetVpnSitesConfigurationRequest" /> instance.</summary>
        public GetVpnSitesConfigurationRequest()
        {

        }
    }
    /// List of Vpn-Sites
    public partial interface IGetVpnSitesConfigurationRequest :
        Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.IJsonSerializable
    {
        /// <summary>The sas-url to download the configurations for vpn-sites</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"The sas-url to download the configurations for vpn-sites",
        SerializedName = @"outputBlobSasUrl",
        PossibleTypes = new [] { typeof(string) })]
        string OutputBlobSasUrl { get; set; }
        /// <summary>List of resource-ids of the vpn-sites for which config is to be downloaded.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"List of resource-ids of the vpn-sites for which config is to be downloaded.",
        SerializedName = @"vpnSites",
        PossibleTypes = new [] { typeof(string) })]
        string[] VpnSite { get; set; }

    }
    /// List of Vpn-Sites
    internal partial interface IGetVpnSitesConfigurationRequestInternal

    {
        /// <summary>The sas-url to download the configurations for vpn-sites</summary>
        string OutputBlobSasUrl { get; set; }
        /// <summary>List of resource-ids of the vpn-sites for which config is to be downloaded.</summary>
        string[] VpnSite { get; set; }

    }
}