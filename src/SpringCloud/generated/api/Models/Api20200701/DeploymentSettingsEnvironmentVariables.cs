namespace Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701
{
    using static Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Runtime.Extensions;

    /// <summary>Collection of environment variables</summary>
    public partial class DeploymentSettingsEnvironmentVariables :
        Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.IDeploymentSettingsEnvironmentVariables,
        Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.IDeploymentSettingsEnvironmentVariablesInternal
    {

        /// <summary>Creates an new <see cref="DeploymentSettingsEnvironmentVariables" /> instance.</summary>
        public DeploymentSettingsEnvironmentVariables()
        {

        }
    }
    /// Collection of environment variables
    public partial interface IDeploymentSettingsEnvironmentVariables :
        Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Runtime.IJsonSerializable,
        Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Runtime.IAssociativeArray<string>
    {

    }
    /// Collection of environment variables
    public partial interface IDeploymentSettingsEnvironmentVariablesInternal

    {

    }
}