namespace Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Extensions;

    /// <summary>
    /// Gets or sets a list of key value pairs that describe the resource. These tags can be used for viewing and grouping this
    /// resource (across resource groups). A maximum of 15 tags can be provided for a resource. Each tag must have a key with
    /// a length no greater than 128 characters and a value with a length no greater than 256 characters.
    /// </summary>
    public partial class StorageAccountCreateParametersTags :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IStorageAccountCreateParametersTags,
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IStorageAccountCreateParametersTagsInternal
    {

        /// <summary>Creates an new <see cref="StorageAccountCreateParametersTags" /> instance.</summary>
        public StorageAccountCreateParametersTags()
        {

        }
    }
    /// Gets or sets a list of key value pairs that describe the resource. These tags can be used for viewing and grouping this
    /// resource (across resource groups). A maximum of 15 tags can be provided for a resource. Each tag must have a key with
    /// a length no greater than 128 characters and a value with a length no greater than 256 characters.
    public partial interface IStorageAccountCreateParametersTags :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.IJsonSerializable,
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.IAssociativeArray<string>
    {

    }
    /// Gets or sets a list of key value pairs that describe the resource. These tags can be used for viewing and grouping this
    /// resource (across resource groups). A maximum of 15 tags can be provided for a resource. Each tag must have a key with
    /// a length no greater than 128 characters and a value with a length no greater than 256 characters.
    internal partial interface IStorageAccountCreateParametersTagsInternal

    {

    }
}