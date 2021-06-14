namespace Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301
{
    using static Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Runtime.Extensions;

    /// <summary>The port exposed on the container instance.</summary>
    public partial class ContainerPort :
        Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainerPort,
        Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainerPortInternal
    {

        /// <summary>Backing field for <see cref="Port" /> property.</summary>
        private int _port;

        /// <summary>The port number exposed within the container group.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Origin(Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.PropertyOrigin.Owned)]
        public int Port { get => this._port; set => this._port = value; }

        /// <summary>Backing field for <see cref="Protocol" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Support.ContainerNetworkProtocol? _protocol;

        /// <summary>The protocol associated with the port.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Origin(Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Support.ContainerNetworkProtocol? Protocol { get => this._protocol; set => this._protocol = value; }

        /// <summary>Creates an new <see cref="ContainerPort" /> instance.</summary>
        public ContainerPort()
        {

        }
    }
    /// The port exposed on the container instance.
    public partial interface IContainerPort :
        Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Runtime.IJsonSerializable
    {
        /// <summary>The port number exposed within the container group.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"The port number exposed within the container group.",
        SerializedName = @"port",
        PossibleTypes = new [] { typeof(int) })]
        int Port { get; set; }
        /// <summary>The protocol associated with the port.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The protocol associated with the port.",
        SerializedName = @"protocol",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Support.ContainerNetworkProtocol) })]
        Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Support.ContainerNetworkProtocol? Protocol { get; set; }

    }
    /// The port exposed on the container instance.
    internal partial interface IContainerPortInternal

    {
        /// <summary>The port number exposed within the container group.</summary>
        int Port { get; set; }
        /// <summary>The protocol associated with the port.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Support.ContainerNetworkProtocol? Protocol { get; set; }

    }
}