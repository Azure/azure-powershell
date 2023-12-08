namespace Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120
{
    using static Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Runtime.Extensions;

    public partial class SwaggerSpecification :
        Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.ISwaggerSpecification,
        Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.ISwaggerSpecificationInternal
    {

        /// <summary>Backing field for <see cref="ApiVersion" /> property.</summary>
        private string[] _apiVersion;

        [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Origin(Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.PropertyOrigin.Owned)]
        public string[] ApiVersion { get => this._apiVersion; set => this._apiVersion = value; }

        /// <summary>Backing field for <see cref="SwaggerSpecFolderUri" /> property.</summary>
        private string _swaggerSpecFolderUri;

        [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Origin(Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.PropertyOrigin.Owned)]
        public string SwaggerSpecFolderUri { get => this._swaggerSpecFolderUri; set => this._swaggerSpecFolderUri = value; }

        /// <summary>Creates an new <see cref="SwaggerSpecification" /> instance.</summary>
        public SwaggerSpecification()
        {

        }
    }
    public partial interface ISwaggerSpecification :
        Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Runtime.IJsonSerializable
    {
        [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"",
        SerializedName = @"apiVersions",
        PossibleTypes = new [] { typeof(string) })]
        string[] ApiVersion { get; set; }

        [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"",
        SerializedName = @"swaggerSpecFolderUri",
        PossibleTypes = new [] { typeof(string) })]
        string SwaggerSpecFolderUri { get; set; }

    }
    internal partial interface ISwaggerSpecificationInternal

    {
        string[] ApiVersion { get; set; }

        string SwaggerSpecFolderUri { get; set; }

    }
}