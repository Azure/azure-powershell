namespace Microsoft.Azure.PowerShell.Cmdlets.Maps.Models.Api20210201
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Maps.Runtime.Extensions;

    /// <summary>
    /// Gets or sets a list of key value pairs that describe the resource. These tags can be used in viewing and grouping this
    /// resource (across resource groups). A maximum of 15 tags can be provided for a resource. Each tag must have a key no greater
    /// than 128 characters and value no greater than 256 characters.
    /// </summary>
    public partial class CreatorUpdateParametersTags :
        Microsoft.Azure.PowerShell.Cmdlets.Maps.Models.Api20210201.ICreatorUpdateParametersTags,
        Microsoft.Azure.PowerShell.Cmdlets.Maps.Models.Api20210201.ICreatorUpdateParametersTagsInternal
    {

        /// <summary>Creates an new <see cref="CreatorUpdateParametersTags" /> instance.</summary>
        public CreatorUpdateParametersTags()
        {

        }
    }
    /// Gets or sets a list of key value pairs that describe the resource. These tags can be used in viewing and grouping this
    /// resource (across resource groups). A maximum of 15 tags can be provided for a resource. Each tag must have a key no greater
    /// than 128 characters and value no greater than 256 characters.
    public partial interface ICreatorUpdateParametersTags :
        Microsoft.Azure.PowerShell.Cmdlets.Maps.Runtime.IJsonSerializable,
        Microsoft.Azure.PowerShell.Cmdlets.Maps.Runtime.IAssociativeArray<string>
    {

    }
    /// Gets or sets a list of key value pairs that describe the resource. These tags can be used in viewing and grouping this
    /// resource (across resource groups). A maximum of 15 tags can be provided for a resource. Each tag must have a key no greater
    /// than 128 characters and value no greater than 256 characters.
    internal partial interface ICreatorUpdateParametersTagsInternal

    {

    }
}