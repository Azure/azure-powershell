namespace Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301
{
    using static Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Runtime.Extensions;

    /// <summary>The port exposed on the container group.</summary>
    public partial class Port :
        Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IPort,
        Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IPortInternal
    {

        /// <summary>Backing field for <see cref="Port1" /> property.</summary>
        private int _port1;

        /// <summary>The port number.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Origin(Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.PropertyOrigin.Owned)]
        public int Port1 { get => this._port1; set => this._port1 = value; }

        /// <summary>Backing field for <see cref="Protocol" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Support.ContainerGroupNetworkProtocol? _protocol;

        /// <summary>The protocol associated with the port.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Origin(Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Support.ContainerGroupNetworkProtocol? Protocol { get => this._protocol; set => this._protocol = value; }

        /// <summary>Creates an new <see cref="Port" /> instance.</summary>
        public Port()
        {

        }
    }
    /// The port exposed on the container group.
    public partial interface IPort :
        Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Runtime.IJsonSerializable
    {
        /// <summary>The port number.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"The port number.",
        SerializedName = @"port",
        PossibleTypes = new [] { typeof(int) })]
        int Port1 { get; set; }
        /// <summary>The protocol associated with the port.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The protocol associated with the port.",
        SerializedName = @"protocol",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Support.ContainerGroupNetworkProtocol) })]
        Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Support.ContainerGroupNetworkProtocol? Protocol { get; set; }

    }
    /// The port exposed on the container group.
    internal partial interface IPortInternal

    {
        /// <summary>The port number.</summary>
        int Port1 { get; set; }
        /// <summary>The protocol associated with the port.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Support.ContainerGroupNetworkProtocol? Protocol { get; set; }

    }
}