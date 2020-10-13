namespace Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701
{
    using static Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Runtime.Extensions;

    /// <summary>Desired outbound IP resources for Azure Spring Cloud instance.</summary>
    public partial class NetworkProfileOutboundIPs :
        Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.INetworkProfileOutboundIPs,
        Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.INetworkProfileOutboundIPsInternal
    {

        /// <summary>Internal Acessors for PublicIP</summary>
        string[] Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.INetworkProfileOutboundIPsInternal.PublicIP { get => this._publicIP; set { {_publicIP = value;} } }

        /// <summary>Backing field for <see cref="PublicIP" /> property.</summary>
        private string[] _publicIP;

        /// <summary>A list of public IP addresses.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Origin(Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.PropertyOrigin.Owned)]
        public string[] PublicIP { get => this._publicIP; }

        /// <summary>Creates an new <see cref="NetworkProfileOutboundIPs" /> instance.</summary>
        public NetworkProfileOutboundIPs()
        {

        }
    }
    /// Desired outbound IP resources for Azure Spring Cloud instance.
    public partial interface INetworkProfileOutboundIPs :
        Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Runtime.IJsonSerializable
    {
        /// <summary>A list of public IP addresses.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"A list of public IP addresses.",
        SerializedName = @"publicIPs",
        PossibleTypes = new [] { typeof(string) })]
        string[] PublicIP { get;  }

    }
    /// Desired outbound IP resources for Azure Spring Cloud instance.
    public partial interface INetworkProfileOutboundIPsInternal

    {
        /// <summary>A list of public IP addresses.</summary>
        string[] PublicIP { get; set; }

    }
}