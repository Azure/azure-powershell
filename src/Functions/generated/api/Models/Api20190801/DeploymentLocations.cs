namespace Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Extensions;

    /// <summary>
    /// List of available locations (regions or App Service Environments) for
    /// deployment of App Service resources.
    /// </summary>
    public partial class DeploymentLocations :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDeploymentLocations,
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDeploymentLocationsInternal
    {

        /// <summary>Backing field for <see cref="HostingEnvironment" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceEnvironment[] _hostingEnvironment;

        /// <summary>Available App Service Environments with full descriptions of the environments.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceEnvironment[] HostingEnvironment { get => this._hostingEnvironment; set => this._hostingEnvironment = value; }

        /// <summary>Backing field for <see cref="HostingEnvironmentDeploymentInfo" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IHostingEnvironmentDeploymentInfo[] _hostingEnvironmentDeploymentInfo;

        /// <summary>Available App Service Environments with basic information.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IHostingEnvironmentDeploymentInfo[] HostingEnvironmentDeploymentInfo { get => this._hostingEnvironmentDeploymentInfo; set => this._hostingEnvironmentDeploymentInfo = value; }

        /// <summary>Backing field for <see cref="Location" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IGeoRegion[] _location;

        /// <summary>Available regions.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IGeoRegion[] Location { get => this._location; set => this._location = value; }

        /// <summary>Creates an new <see cref="DeploymentLocations" /> instance.</summary>
        public DeploymentLocations()
        {

        }
    }
    /// List of available locations (regions or App Service Environments) for
    /// deployment of App Service resources.
    public partial interface IDeploymentLocations :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.IJsonSerializable
    {
        /// <summary>Available App Service Environments with full descriptions of the environments.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Available App Service Environments with full descriptions of the environments.",
        SerializedName = @"hostingEnvironments",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceEnvironment) })]
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceEnvironment[] HostingEnvironment { get; set; }
        /// <summary>Available App Service Environments with basic information.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Available App Service Environments with basic information.",
        SerializedName = @"hostingEnvironmentDeploymentInfos",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IHostingEnvironmentDeploymentInfo) })]
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IHostingEnvironmentDeploymentInfo[] HostingEnvironmentDeploymentInfo { get; set; }
        /// <summary>Available regions.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Available regions.",
        SerializedName = @"locations",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IGeoRegion) })]
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IGeoRegion[] Location { get; set; }

    }
    /// List of available locations (regions or App Service Environments) for
    /// deployment of App Service resources.
    internal partial interface IDeploymentLocationsInternal

    {
        /// <summary>Available App Service Environments with full descriptions of the environments.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceEnvironment[] HostingEnvironment { get; set; }
        /// <summary>Available App Service Environments with basic information.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IHostingEnvironmentDeploymentInfo[] HostingEnvironmentDeploymentInfo { get; set; }
        /// <summary>Available regions.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IGeoRegion[] Location { get; set; }

    }
}