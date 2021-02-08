namespace Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Models.Api10
{
    using static Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Runtime.Extensions;

    /// <summary>Dictionary of <string></summary>
    public partial class KeyValueTags :
        Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Models.Api10.IKeyValueTags,
        Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Models.Api10.IKeyValueTagsInternal
    {

        /// <summary>Creates an new <see cref="KeyValueTags" /> instance.</summary>
        public KeyValueTags()
        {

        }
    }
    /// Dictionary of <string>
    public partial interface IKeyValueTags :
        Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Runtime.IJsonSerializable,
        Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Runtime.IAssociativeArray<string>
    {

    }
    /// Dictionary of <string>
    internal partial interface IKeyValueTagsInternal

    {

    }
}