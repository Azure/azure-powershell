namespace Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Extensions;

    /// <summary>Parameters that define destination of connection.</summary>
    public partial class ConnectivityDestination :
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IConnectivityDestination,
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IConnectivityDestinationInternal
    {

        /// <summary>Backing field for <see cref="Address" /> property.</summary>
        private string _address;

        /// <summary>The IP address or URI the resource to which a connection attempt will be made.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public string Address { get => this._address; set => this._address = value; }

        /// <summary>Backing field for <see cref="Port" /> property.</summary>
        private int? _port;

        /// <summary>Port on which check connectivity will be performed.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public int? Port { get => this._port; set => this._port = value; }

        /// <summary>Backing field for <see cref="ResourceId" /> property.</summary>
        private string _resourceId;

        /// <summary>The ID of the resource to which a connection attempt will be made.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public string ResourceId { get => this._resourceId; set => this._resourceId = value; }

        /// <summary>Creates an new <see cref="ConnectivityDestination" /> instance.</summary>
        public ConnectivityDestination()
        {

        }
    }
    /// Parameters that define destination of connection.
    public partial interface IConnectivityDestination :
        Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.IJsonSerializable
    {
        /// <summary>The IP address or URI the resource to which a connection attempt will be made.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The IP address or URI the resource to which a connection attempt will be made.",
        SerializedName = @"address",
        PossibleTypes = new [] { typeof(string) })]
        string Address { get; set; }
        /// <summary>Port on which check connectivity will be performed.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Port on which check connectivity will be performed.",
        SerializedName = @"port",
        PossibleTypes = new [] { typeof(int) })]
        int? Port { get; set; }
        /// <summary>The ID of the resource to which a connection attempt will be made.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The ID of the resource to which a connection attempt will be made.",
        SerializedName = @"resourceId",
        PossibleTypes = new [] { typeof(string) })]
        string ResourceId { get; set; }

    }
    /// Parameters that define destination of connection.
    internal partial interface IConnectivityDestinationInternal

    {
        /// <summary>The IP address or URI the resource to which a connection attempt will be made.</summary>
        string Address { get; set; }
        /// <summary>Port on which check connectivity will be performed.</summary>
        int? Port { get; set; }
        /// <summary>The ID of the resource to which a connection attempt will be made.</summary>
        string ResourceId { get; set; }

    }
}