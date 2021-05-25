namespace Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301
{
    using static Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Runtime.Extensions;

    /// <summary>The information for the output stream from container attach.</summary>
    public partial class ContainerAttachResponse :
        Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainerAttachResponse,
        Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainerAttachResponseInternal
    {

        /// <summary>Backing field for <see cref="Password" /> property.</summary>
        private string _password;

        /// <summary>
        /// The password to the output stream from the attach. Send as an Authorization header value when connecting to the websocketUri.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Origin(Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.PropertyOrigin.Owned)]
        public string Password { get => this._password; set => this._password = value; }

        /// <summary>Backing field for <see cref="WebSocketUri" /> property.</summary>
        private string _webSocketUri;

        /// <summary>The uri for the output stream from the attach.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Origin(Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.PropertyOrigin.Owned)]
        public string WebSocketUri { get => this._webSocketUri; set => this._webSocketUri = value; }

        /// <summary>Creates an new <see cref="ContainerAttachResponse" /> instance.</summary>
        public ContainerAttachResponse()
        {

        }
    }
    /// The information for the output stream from container attach.
    public partial interface IContainerAttachResponse :
        Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Runtime.IJsonSerializable
    {
        /// <summary>
        /// The password to the output stream from the attach. Send as an Authorization header value when connecting to the websocketUri.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The password to the output stream from the attach. Send as an Authorization header value when connecting to the websocketUri.",
        SerializedName = @"password",
        PossibleTypes = new [] { typeof(string) })]
        string Password { get; set; }
        /// <summary>The uri for the output stream from the attach.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The uri for the output stream from the attach.",
        SerializedName = @"webSocketUri",
        PossibleTypes = new [] { typeof(string) })]
        string WebSocketUri { get; set; }

    }
    /// The information for the output stream from container attach.
    internal partial interface IContainerAttachResponseInternal

    {
        /// <summary>
        /// The password to the output stream from the attach. Send as an Authorization header value when connecting to the websocketUri.
        /// </summary>
        string Password { get; set; }
        /// <summary>The uri for the output stream from the attach.</summary>
        string WebSocketUri { get; set; }

    }
}