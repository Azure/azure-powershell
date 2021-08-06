namespace Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301
{
    using static Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Runtime.Extensions;

    /// <summary>Image registry credential.</summary>
    public partial class ImageRegistryCredential :
        Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IImageRegistryCredential,
        Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IImageRegistryCredentialInternal
    {

        /// <summary>Backing field for <see cref="Password" /> property.</summary>
        private string _password;

        /// <summary>The password for the private registry.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Origin(Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.PropertyOrigin.Owned)]
        public string Password { get => this._password; set => this._password = value; }

        /// <summary>Backing field for <see cref="Server" /> property.</summary>
        private string _server;

        /// <summary>The Docker image registry server without a protocol such as "http" and "https".</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Origin(Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.PropertyOrigin.Owned)]
        public string Server { get => this._server; set => this._server = value; }

        /// <summary>Backing field for <see cref="Username" /> property.</summary>
        private string _username;

        /// <summary>The username for the private registry.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Origin(Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.PropertyOrigin.Owned)]
        public string Username { get => this._username; set => this._username = value; }

        /// <summary>Creates an new <see cref="ImageRegistryCredential" /> instance.</summary>
        public ImageRegistryCredential()
        {

        }
    }
    /// Image registry credential.
    public partial interface IImageRegistryCredential :
        Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Runtime.IJsonSerializable
    {
        /// <summary>The password for the private registry.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The password for the private registry.",
        SerializedName = @"password",
        PossibleTypes = new [] { typeof(string) })]
        string Password { get; set; }
        /// <summary>The Docker image registry server without a protocol such as "http" and "https".</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"The Docker image registry server without a protocol such as ""http"" and ""https"".",
        SerializedName = @"server",
        PossibleTypes = new [] { typeof(string) })]
        string Server { get; set; }
        /// <summary>The username for the private registry.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"The username for the private registry.",
        SerializedName = @"username",
        PossibleTypes = new [] { typeof(string) })]
        string Username { get; set; }

    }
    /// Image registry credential.
    internal partial interface IImageRegistryCredentialInternal

    {
        /// <summary>The password for the private registry.</summary>
        string Password { get; set; }
        /// <summary>The Docker image registry server without a protocol such as "http" and "https".</summary>
        string Server { get; set; }
        /// <summary>The username for the private registry.</summary>
        string Username { get; set; }

    }
}