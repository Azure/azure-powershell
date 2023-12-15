namespace Microsoft.Azure.PowerShell.Cmdlets.Maps.Models.Api20210201
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Maps.Runtime.Extensions;

    /// <summary>
    /// Gets or sets a list of key value pairs that describe the resource. These tags can be used in viewing and grouping this
    /// resource (across resource groups). A maximum of 15 tags can be provided for a resource. Each tag must have a key no greater
    /// than 128 characters and value no greater than 256 characters.
    /// </summary>
    public partial class MapsAccountUpdateParametersTags :
        Microsoft.Azure.PowerShell.Cmdlets.Maps.Models.Api20210201.IMapsAccountUpdateParametersTags,
        Microsoft.Azure.PowerShell.Cmdlets.Maps.Models.Api20210201.IMapsAccountUpdateParametersTagsInternal
    {

        /// <summary>Creates an new <see cref="MapsAccountUpdateParametersTags" /> instance.</summary>
        public MapsAccountUpdateParametersTags()
        {

        }
    }
    /// Gets or sets a list of key value pairs that describe the resource. These tags can be used in viewing and grouping this
    /// resource (across resource groups). A maximum of 15 tags can be provided for a resource. Each tag must have a key no greater
    /// than 128 characters and value no greater than 256 characters.
    public partial interface IMapsAccountUpdateParametersTags :
        Microsoft.Azure.PowerShell.Cmdlets.Maps.Runtime.IJsonSerializable,
        Microsoft.Azure.PowerShell.Cmdlets.Maps.Runtime.IAssociativeArray<string>
    {

    }
    /// Gets or sets a list of key value pairs that describe the resource. These tags can be used in viewing and grouping this
    /// resource (across resource groups). A maximum of 15 tags can be provided for a resource. Each tag must have a key no greater
    /// than 128 characters and value no greater than 256 characters.
    internal partial interface IMapsAccountUpdateParametersTagsInternal

    {

    }
}