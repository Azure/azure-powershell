namespace Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Extensions;

    /// <summary>
    /// Filter that is applied to packet capture request. Multiple filters can be applied.
    /// </summary>
    public partial class PacketCaptureFilter :
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IPacketCaptureFilter,
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IPacketCaptureFilterInternal
    {

        /// <summary>Backing field for <see cref="LocalIPAddress" /> property.</summary>
        private string _localIPAddress;

        /// <summary>
        /// Local IP Address to be filtered on. Notation: "127.0.0.1" for single address entry. "127.0.0.1-127.0.0.255" for range.
        /// "127.0.0.1;127.0.0.5"? for multiple entries. Multiple ranges not currently supported. Mixing ranges with multiple entries
        /// not currently supported. Default = null.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public string LocalIPAddress { get => this._localIPAddress; set => this._localIPAddress = value; }

        /// <summary>Backing field for <see cref="LocalPort" /> property.</summary>
        private string _localPort;

        /// <summary>
        /// Local port to be filtered on. Notation: "80" for single port entry."80-85" for range. "80;443;" for multiple entries.
        /// Multiple ranges not currently supported. Mixing ranges with multiple entries not currently supported. Default = null.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public string LocalPort { get => this._localPort; set => this._localPort = value; }

        /// <summary>Backing field for <see cref="Protocol" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Network.Support.PcProtocol? _protocol;

        /// <summary>Protocol to be filtered on.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Network.Support.PcProtocol? Protocol { get => this._protocol; set => this._protocol = value; }

        /// <summary>Backing field for <see cref="RemoteIPAddress" /> property.</summary>
        private string _remoteIPAddress;

        /// <summary>
        /// Local IP Address to be filtered on. Notation: "127.0.0.1" for single address entry. "127.0.0.1-127.0.0.255" for range.
        /// "127.0.0.1;127.0.0.5;" for multiple entries. Multiple ranges not currently supported. Mixing ranges with multiple entries
        /// not currently supported. Default = null.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public string RemoteIPAddress { get => this._remoteIPAddress; set => this._remoteIPAddress = value; }

        /// <summary>Backing field for <see cref="RemotePort" /> property.</summary>
        private string _remotePort;

        /// <summary>
        /// Remote port to be filtered on. Notation: "80" for single port entry."80-85" for range. "80;443;" for multiple entries.
        /// Multiple ranges not currently supported. Mixing ranges with multiple entries not currently supported. Default = null.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public string RemotePort { get => this._remotePort; set => this._remotePort = value; }

        /// <summary>Creates an new <see cref="PacketCaptureFilter" /> instance.</summary>
        public PacketCaptureFilter()
        {

        }
    }
    /// Filter that is applied to packet capture request. Multiple filters can be applied.
    public partial interface IPacketCaptureFilter :
        Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.IJsonSerializable
    {
        /// <summary>
        /// Local IP Address to be filtered on. Notation: "127.0.0.1" for single address entry. "127.0.0.1-127.0.0.255" for range.
        /// "127.0.0.1;127.0.0.5"? for multiple entries. Multiple ranges not currently supported. Mixing ranges with multiple entries
        /// not currently supported. Default = null.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Local IP Address to be filtered on. Notation: ""127.0.0.1"" for single address entry. ""127.0.0.1-127.0.0.255"" for range. ""127.0.0.1;127.0.0.5""? for multiple entries. Multiple ranges not currently supported. Mixing ranges with multiple entries not currently supported. Default = null.",
        SerializedName = @"localIPAddress",
        PossibleTypes = new [] { typeof(string) })]
        string LocalIPAddress { get; set; }
        /// <summary>
        /// Local port to be filtered on. Notation: "80" for single port entry."80-85" for range. "80;443;" for multiple entries.
        /// Multiple ranges not currently supported. Mixing ranges with multiple entries not currently supported. Default = null.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Local port to be filtered on. Notation: ""80"" for single port entry.""80-85"" for range. ""80;443;"" for multiple entries. Multiple ranges not currently supported. Mixing ranges with multiple entries not currently supported. Default = null.",
        SerializedName = @"localPort",
        PossibleTypes = new [] { typeof(string) })]
        string LocalPort { get; set; }
        /// <summary>Protocol to be filtered on.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Protocol to be filtered on.",
        SerializedName = @"protocol",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Network.Support.PcProtocol) })]
        Microsoft.Azure.PowerShell.Cmdlets.Network.Support.PcProtocol? Protocol { get; set; }
        /// <summary>
        /// Local IP Address to be filtered on. Notation: "127.0.0.1" for single address entry. "127.0.0.1-127.0.0.255" for range.
        /// "127.0.0.1;127.0.0.5;" for multiple entries. Multiple ranges not currently supported. Mixing ranges with multiple entries
        /// not currently supported. Default = null.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Local IP Address to be filtered on. Notation: ""127.0.0.1"" for single address entry. ""127.0.0.1-127.0.0.255"" for range. ""127.0.0.1;127.0.0.5;"" for multiple entries. Multiple ranges not currently supported. Mixing ranges with multiple entries not currently supported. Default = null.",
        SerializedName = @"remoteIPAddress",
        PossibleTypes = new [] { typeof(string) })]
        string RemoteIPAddress { get; set; }
        /// <summary>
        /// Remote port to be filtered on. Notation: "80" for single port entry."80-85" for range. "80;443;" for multiple entries.
        /// Multiple ranges not currently supported. Mixing ranges with multiple entries not currently supported. Default = null.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Remote port to be filtered on. Notation: ""80"" for single port entry.""80-85"" for range. ""80;443;"" for multiple entries. Multiple ranges not currently supported. Mixing ranges with multiple entries not currently supported. Default = null.",
        SerializedName = @"remotePort",
        PossibleTypes = new [] { typeof(string) })]
        string RemotePort { get; set; }

    }
    /// Filter that is applied to packet capture request. Multiple filters can be applied.
    internal partial interface IPacketCaptureFilterInternal

    {
        /// <summary>
        /// Local IP Address to be filtered on. Notation: "127.0.0.1" for single address entry. "127.0.0.1-127.0.0.255" for range.
        /// "127.0.0.1;127.0.0.5"? for multiple entries. Multiple ranges not currently supported. Mixing ranges with multiple entries
        /// not currently supported. Default = null.
        /// </summary>
        string LocalIPAddress { get; set; }
        /// <summary>
        /// Local port to be filtered on. Notation: "80" for single port entry."80-85" for range. "80;443;" for multiple entries.
        /// Multiple ranges not currently supported. Mixing ranges with multiple entries not currently supported. Default = null.
        /// </summary>
        string LocalPort { get; set; }
        /// <summary>Protocol to be filtered on.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Support.PcProtocol? Protocol { get; set; }
        /// <summary>
        /// Local IP Address to be filtered on. Notation: "127.0.0.1" for single address entry. "127.0.0.1-127.0.0.255" for range.
        /// "127.0.0.1;127.0.0.5;" for multiple entries. Multiple ranges not currently supported. Mixing ranges with multiple entries
        /// not currently supported. Default = null.
        /// </summary>
        string RemoteIPAddress { get; set; }
        /// <summary>
        /// Remote port to be filtered on. Notation: "80" for single port entry."80-85" for range. "80;443;" for multiple entries.
        /// Multiple ranges not currently supported. Mixing ranges with multiple entries not currently supported. Default = null.
        /// </summary>
        string RemotePort { get; set; }

    }
}