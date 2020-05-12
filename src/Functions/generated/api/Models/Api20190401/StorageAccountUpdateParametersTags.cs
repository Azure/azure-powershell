namespace Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Extensions;

    /// <summary>
    /// Gets or sets a list of key value pairs that describe the resource. These tags can be used in viewing and grouping this
    /// resource (across resource groups). A maximum of 15 tags can be provided for a resource. Each tag must have a key no greater
    /// in length than 128 characters and a value no greater in length than 256 characters.
    /// </summary>
    public partial class StorageAccountUpdateParametersTags :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IStorageAccountUpdateParametersTags,
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IStorageAccountUpdateParametersTagsInternal
    {

        /// <summary>Creates an new <see cref="StorageAccountUpdateParametersTags" /> instance.</summary>
        public StorageAccountUpdateParametersTags()
        {

        }
    }
    /// Gets or sets a list of key value pairs that describe the resource. These tags can be used in viewing and grouping this
    /// resource (across resource groups). A maximum of 15 tags can be provided for a resource. Each tag must have a key no greater
    /// in length than 128 characters and a value no greater in length than 256 characters.
    public partial interface IStorageAccountUpdateParametersTags :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.IJsonSerializable,
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.IAssociativeArray<string>
    {

    }
    /// Gets or sets a list of key value pairs that describe the resource. These tags can be used in viewing and grouping this
    /// resource (across resource groups). A maximum of 15 tags can be provided for a resource. Each tag must have a key no greater
    /// in length than 128 characters and a value no greater in length than 256 characters.
    internal partial interface IStorageAccountUpdateParametersTagsInternal

    {

    }
}