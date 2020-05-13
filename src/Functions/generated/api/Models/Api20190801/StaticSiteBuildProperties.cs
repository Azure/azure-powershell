namespace Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Extensions;

    /// <summary>Build properties for the static site.</summary>
    public partial class StaticSiteBuildProperties :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IStaticSiteBuildProperties,
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IStaticSiteBuildPropertiesInternal
    {

        /// <summary>Backing field for <see cref="ApiLocation" /> property.</summary>
        private string _apiLocation;

        /// <summary>The path to the api code within the repository.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public string ApiLocation { get => this._apiLocation; set => this._apiLocation = value; }

        /// <summary>Backing field for <see cref="AppArtifactLocation" /> property.</summary>
        private string _appArtifactLocation;

        /// <summary>The path of the app artifacts after building.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public string AppArtifactLocation { get => this._appArtifactLocation; set => this._appArtifactLocation = value; }

        /// <summary>Backing field for <see cref="AppLocation" /> property.</summary>
        private string _appLocation;

        /// <summary>The path to the app code within the repository.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public string AppLocation { get => this._appLocation; set => this._appLocation = value; }

        /// <summary>Creates an new <see cref="StaticSiteBuildProperties" /> instance.</summary>
        public StaticSiteBuildProperties()
        {

        }
    }
    /// Build properties for the static site.
    public partial interface IStaticSiteBuildProperties :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.IJsonSerializable
    {
        /// <summary>The path to the api code within the repository.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The path to the api code within the repository.",
        SerializedName = @"apiLocation",
        PossibleTypes = new [] { typeof(string) })]
        string ApiLocation { get; set; }
        /// <summary>The path of the app artifacts after building.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The path of the app artifacts after building.",
        SerializedName = @"appArtifactLocation",
        PossibleTypes = new [] { typeof(string) })]
        string AppArtifactLocation { get; set; }
        /// <summary>The path to the app code within the repository.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The path to the app code within the repository.",
        SerializedName = @"appLocation",
        PossibleTypes = new [] { typeof(string) })]
        string AppLocation { get; set; }

    }
    /// Build properties for the static site.
    internal partial interface IStaticSiteBuildPropertiesInternal

    {
        /// <summary>The path to the api code within the repository.</summary>
        string ApiLocation { get; set; }
        /// <summary>The path of the app artifacts after building.</summary>
        string AppArtifactLocation { get; set; }
        /// <summary>The path to the app code within the repository.</summary>
        string AppLocation { get; set; }

    }
}