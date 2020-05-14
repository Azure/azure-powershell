namespace Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Extensions;

    /// <summary>List of environment variables.</summary>
    public partial class ProcessInfoPropertiesEnvironmentVariables :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProcessInfoPropertiesEnvironmentVariables,
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProcessInfoPropertiesEnvironmentVariablesInternal
    {

        /// <summary>
        /// Creates an new <see cref="ProcessInfoPropertiesEnvironmentVariables" /> instance.
        /// </summary>
        public ProcessInfoPropertiesEnvironmentVariables()
        {

        }
    }
    /// List of environment variables.
    public partial interface IProcessInfoPropertiesEnvironmentVariables :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.IJsonSerializable,
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.IAssociativeArray<string>
    {

    }
    /// List of environment variables.
    internal partial interface IProcessInfoPropertiesEnvironmentVariablesInternal

    {

    }
}