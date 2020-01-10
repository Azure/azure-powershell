namespace Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Extensions;

    /// <summary>Parameters that define the source of the connection.</summary>
    public partial class ConnectivitySource :
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IConnectivitySource,
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IConnectivitySourceInternal
    {

        /// <summary>Backing field for <see cref="Port" /> property.</summary>
        private int? _port;

        /// <summary>The source port from which a connectivity check will be performed.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public int? Port { get => this._port; set => this._port = value; }

        /// <summary>Backing field for <see cref="ResourceId" /> property.</summary>
        private string _resourceId;

        /// <summary>The ID of the resource from which a connectivity check will be initiated.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public string ResourceId { get => this._resourceId; set => this._resourceId = value; }

        /// <summary>Creates an new <see cref="ConnectivitySource" /> instance.</summary>
        public ConnectivitySource()
        {

        }
    }
    /// Parameters that define the source of the connection.
    public partial interface IConnectivitySource :
        Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.IJsonSerializable
    {
        /// <summary>The source port from which a connectivity check will be performed.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The source port from which a connectivity check will be performed.",
        SerializedName = @"port",
        PossibleTypes = new [] { typeof(int) })]
        int? Port { get; set; }
        /// <summary>The ID of the resource from which a connectivity check will be initiated.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"The ID of the resource from which a connectivity check will be initiated.",
        SerializedName = @"resourceId",
        PossibleTypes = new [] { typeof(string) })]
        string ResourceId { get; set; }

    }
    /// Parameters that define the source of the connection.
    internal partial interface IConnectivitySourceInternal

    {
        /// <summary>The source port from which a connectivity check will be performed.</summary>
        int? Port { get; set; }
        /// <summary>The ID of the resource from which a connectivity check will be initiated.</summary>
        string ResourceId { get; set; }

    }
}