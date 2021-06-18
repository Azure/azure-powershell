namespace Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301
{
    using static Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Runtime.Extensions;

    /// <summary>DNS configuration for the container group.</summary>
    public partial class DnsConfiguration :
        Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IDnsConfiguration,
        Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IDnsConfigurationInternal
    {

        /// <summary>Backing field for <see cref="NameServer" /> property.</summary>
        private string[] _nameServer;

        /// <summary>The DNS servers for the container group.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Origin(Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.PropertyOrigin.Owned)]
        public string[] NameServer { get => this._nameServer; set => this._nameServer = value; }

        /// <summary>Backing field for <see cref="Option" /> property.</summary>
        private string _option;

        /// <summary>The DNS options for the container group.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Origin(Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.PropertyOrigin.Owned)]
        public string Option { get => this._option; set => this._option = value; }

        /// <summary>Backing field for <see cref="SearchDomain" /> property.</summary>
        private string _searchDomain;

        /// <summary>The DNS search domains for hostname lookup in the container group.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Origin(Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.PropertyOrigin.Owned)]
        public string SearchDomain { get => this._searchDomain; set => this._searchDomain = value; }

        /// <summary>Creates an new <see cref="DnsConfiguration" /> instance.</summary>
        public DnsConfiguration()
        {

        }
    }
    /// DNS configuration for the container group.
    public partial interface IDnsConfiguration :
        Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Runtime.IJsonSerializable
    {
        /// <summary>The DNS servers for the container group.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"The DNS servers for the container group.",
        SerializedName = @"nameServers",
        PossibleTypes = new [] { typeof(string) })]
        string[] NameServer { get; set; }
        /// <summary>The DNS options for the container group.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The DNS options for the container group.",
        SerializedName = @"options",
        PossibleTypes = new [] { typeof(string) })]
        string Option { get; set; }
        /// <summary>The DNS search domains for hostname lookup in the container group.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The DNS search domains for hostname lookup in the container group.",
        SerializedName = @"searchDomains",
        PossibleTypes = new [] { typeof(string) })]
        string SearchDomain { get; set; }

    }
    /// DNS configuration for the container group.
    internal partial interface IDnsConfigurationInternal

    {
        /// <summary>The DNS servers for the container group.</summary>
        string[] NameServer { get; set; }
        /// <summary>The DNS options for the container group.</summary>
        string Option { get; set; }
        /// <summary>The DNS search domains for hostname lookup in the container group.</summary>
        string SearchDomain { get; set; }

    }
}