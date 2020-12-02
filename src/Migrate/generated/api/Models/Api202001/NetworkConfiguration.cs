namespace Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Extensions;

    public partial class NetworkConfiguration :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.INetworkConfiguration,
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.INetworkConfigurationInternal
    {

        /// <summary>Backing field for <see cref="DefaultIpv4Gateway" /> property.</summary>
        private string[] _defaultIpv4Gateway;

        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string[] DefaultIpv4Gateway { get => this._defaultIpv4Gateway; set => this._defaultIpv4Gateway = value; }

        /// <summary>Backing field for <see cref="DnsCanonicalName" /> property.</summary>
        private string[] _dnsCanonicalName;

        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string[] DnsCanonicalName { get => this._dnsCanonicalName; set => this._dnsCanonicalName = value; }

        /// <summary>Backing field for <see cref="DnsName" /> property.</summary>
        private string[] _dnsName;

        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string[] DnsName { get => this._dnsName; set => this._dnsName = value; }

        /// <summary>Backing field for <see cref="DnsQuestion" /> property.</summary>
        private string[] _dnsQuestion;

        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string[] DnsQuestion { get => this._dnsQuestion; set => this._dnsQuestion = value; }

        /// <summary>Backing field for <see cref="Ipv4Interface" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IIpv4NetworkInterface[] _ipv4Interface;

        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IIpv4NetworkInterface[] Ipv4Interface { get => this._ipv4Interface; set => this._ipv4Interface = value; }

        /// <summary>Backing field for <see cref="Ipv6Interface" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IIpv6NetworkInterface[] _ipv6Interface;

        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IIpv6NetworkInterface[] Ipv6Interface { get => this._ipv6Interface; set => this._ipv6Interface = value; }

        /// <summary>Backing field for <see cref="MacAddress" /> property.</summary>
        private string[] _macAddress;

        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string[] MacAddress { get => this._macAddress; set => this._macAddress = value; }

        /// <summary>Creates an new <see cref="NetworkConfiguration" /> instance.</summary>
        public NetworkConfiguration()
        {

        }
    }
    public partial interface INetworkConfiguration :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.IJsonSerializable
    {
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"",
        SerializedName = @"defaultIpv4Gateways",
        PossibleTypes = new [] { typeof(string) })]
        string[] DefaultIpv4Gateway { get; set; }

        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"",
        SerializedName = @"dnsCanonicalNames",
        PossibleTypes = new [] { typeof(string) })]
        string[] DnsCanonicalName { get; set; }

        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"",
        SerializedName = @"dnsNames",
        PossibleTypes = new [] { typeof(string) })]
        string[] DnsName { get; set; }

        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"",
        SerializedName = @"dnsQuestions",
        PossibleTypes = new [] { typeof(string) })]
        string[] DnsQuestion { get; set; }

        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"",
        SerializedName = @"ipv4Interfaces",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IIpv4NetworkInterface) })]
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IIpv4NetworkInterface[] Ipv4Interface { get; set; }

        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"",
        SerializedName = @"ipv6Interfaces",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IIpv6NetworkInterface) })]
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IIpv6NetworkInterface[] Ipv6Interface { get; set; }

        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"",
        SerializedName = @"macAddresses",
        PossibleTypes = new [] { typeof(string) })]
        string[] MacAddress { get; set; }

    }
    internal partial interface INetworkConfigurationInternal

    {
        string[] DefaultIpv4Gateway { get; set; }

        string[] DnsCanonicalName { get; set; }

        string[] DnsName { get; set; }

        string[] DnsQuestion { get; set; }

        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IIpv4NetworkInterface[] Ipv4Interface { get; set; }

        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IIpv6NetworkInterface[] Ipv6Interface { get; set; }

        string[] MacAddress { get; set; }

    }
}