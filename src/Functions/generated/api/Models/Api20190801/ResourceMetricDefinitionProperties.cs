namespace Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Extensions;

    /// <summary>Resource metric definition properties.</summary>
    public partial class ResourceMetricDefinitionProperties :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IResourceMetricDefinitionProperties,
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IResourceMetricDefinitionPropertiesInternal
    {

        /// <summary>Creates an new <see cref="ResourceMetricDefinitionProperties" /> instance.</summary>
        public ResourceMetricDefinitionProperties()
        {

        }
    }
    /// Resource metric definition properties.
    public partial interface IResourceMetricDefinitionProperties :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.IJsonSerializable,
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.IAssociativeArray<string>
    {

    }
    /// Resource metric definition properties.
    internal partial interface IResourceMetricDefinitionPropertiesInternal

    {

    }
}