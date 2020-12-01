namespace Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20200701Preview
{
    using static Microsoft.Azure.PowerShell.Cmdlets.MySql.Runtime.Extensions;

    /// <summary>Application-specific metadata in the form of key-value pairs.</summary>
    public partial class ServerForUpdateTags :
        Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20200701Preview.IServerForUpdateTags,
        Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20200701Preview.IServerForUpdateTagsInternal
    {

        /// <summary>Creates an new <see cref="ServerForUpdateTags" /> instance.</summary>
        public ServerForUpdateTags()
        {

        }
    }
    /// Application-specific metadata in the form of key-value pairs.
    public partial interface IServerForUpdateTags :
        Microsoft.Azure.PowerShell.Cmdlets.MySql.Runtime.IJsonSerializable,
        Microsoft.Azure.PowerShell.Cmdlets.MySql.Runtime.IAssociativeArray<string>
    {

    }
    /// Application-specific metadata in the form of key-value pairs.
    internal partial interface IServerForUpdateTagsInternal

    {

    }
}