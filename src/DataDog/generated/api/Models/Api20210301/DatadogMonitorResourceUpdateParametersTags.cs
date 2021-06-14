namespace Microsoft.Azure.PowerShell.Cmdlets.DataDog.Models.Api20210301
{
    using static Microsoft.Azure.PowerShell.Cmdlets.DataDog.Runtime.Extensions;

    /// <summary>The new tags of the monitor resource.</summary>
    public partial class DatadogMonitorResourceUpdateParametersTags :
        Microsoft.Azure.PowerShell.Cmdlets.DataDog.Models.Api20210301.IDatadogMonitorResourceUpdateParametersTags,
        Microsoft.Azure.PowerShell.Cmdlets.DataDog.Models.Api20210301.IDatadogMonitorResourceUpdateParametersTagsInternal
    {

        /// <summary>
        /// Creates an new <see cref="DatadogMonitorResourceUpdateParametersTags" /> instance.
        /// </summary>
        public DatadogMonitorResourceUpdateParametersTags()
        {

        }
    }
    /// The new tags of the monitor resource.
    public partial interface IDatadogMonitorResourceUpdateParametersTags :
        Microsoft.Azure.PowerShell.Cmdlets.DataDog.Runtime.IJsonSerializable,
        Microsoft.Azure.PowerShell.Cmdlets.DataDog.Runtime.IAssociativeArray<string>
    {

    }
    /// The new tags of the monitor resource.
    internal partial interface IDatadogMonitorResourceUpdateParametersTagsInternal

    {

    }
}