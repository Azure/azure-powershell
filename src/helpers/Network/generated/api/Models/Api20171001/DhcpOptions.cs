namespace Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Extensions;

    /// <summary>
    /// DhcpOptions contains an array of DNS servers available to VMs deployed in the virtual network. Standard DHCP option for
    /// a subnet overrides VNET DHCP options.
    /// </summary>
    public partial class DhcpOptions :
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IDhcpOptions,
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IDhcpOptionsInternal
    {

        /// <summary>Backing field for <see cref="DnsServer" /> property.</summary>
        private string[] _dnsServer;

        /// <summary>The list of DNS servers IP addresses.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public string[] DnsServer { get => this._dnsServer; set => this._dnsServer = value; }

        /// <summary>Creates an new <see cref="DhcpOptions" /> instance.</summary>
        public DhcpOptions()
        {

        }
    }
    /// DhcpOptions contains an array of DNS servers available to VMs deployed in the virtual network. Standard DHCP option for
    /// a subnet overrides VNET DHCP options.
    public partial interface IDhcpOptions :
        Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.IJsonSerializable
    {
        /// <summary>The list of DNS servers IP addresses.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The list of DNS servers IP addresses.",
        SerializedName = @"dnsServers",
        PossibleTypes = new [] { typeof(string) })]
        string[] DnsServer { get; set; }

    }
    /// DhcpOptions contains an array of DNS servers available to VMs deployed in the virtual network. Standard DHCP option for
    /// a subnet overrides VNET DHCP options.
    internal partial interface IDhcpOptionsInternal

    {
        /// <summary>The list of DNS servers IP addresses.</summary>
        string[] DnsServer { get; set; }

    }
}