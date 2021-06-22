namespace Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301
{
    using static Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Runtime.Extensions;

    /// <summary>The information for the container exec command.</summary>
    public partial class ContainerExecResponse :
        Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainerExecResponse,
        Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainerExecResponseInternal
    {

        /// <summary>Backing field for <see cref="Password" /> property.</summary>
        private string _password;

        /// <summary>The password to start the exec command.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Origin(Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.PropertyOrigin.Owned)]
        public string Password { get => this._password; set => this._password = value; }

        /// <summary>Backing field for <see cref="WebSocketUri" /> property.</summary>
        private string _webSocketUri;

        /// <summary>The uri for the exec websocket.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Origin(Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.PropertyOrigin.Owned)]
        public string WebSocketUri { get => this._webSocketUri; set => this._webSocketUri = value; }

        /// <summary>Creates an new <see cref="ContainerExecResponse" /> instance.</summary>
        public ContainerExecResponse()
        {

        }
    }
    /// The information for the container exec command.
    public partial interface IContainerExecResponse :
        Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Runtime.IJsonSerializable
    {
        /// <summary>The password to start the exec command.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The password to start the exec command.",
        SerializedName = @"password",
        PossibleTypes = new [] { typeof(string) })]
        string Password { get; set; }
        /// <summary>The uri for the exec websocket.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The uri for the exec websocket.",
        SerializedName = @"webSocketUri",
        PossibleTypes = new [] { typeof(string) })]
        string WebSocketUri { get; set; }

    }
    /// The information for the container exec command.
    internal partial interface IContainerExecResponseInternal

    {
        /// <summary>The password to start the exec command.</summary>
        string Password { get; set; }
        /// <summary>The uri for the exec websocket.</summary>
        string WebSocketUri { get; set; }

    }
}