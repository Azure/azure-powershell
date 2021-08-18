namespace Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Models.Api20210601
{
    using static Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Runtime.Extensions;

    /// <summary>Application-specific metadata in the form of key-value pairs.</summary>
    public partial class ServerForUpdateTags :
        Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Models.Api20210601.IServerForUpdateTags,
        Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Models.Api20210601.IServerForUpdateTagsInternal
    {

        /// <summary>Creates an new <see cref="ServerForUpdateTags" /> instance.</summary>
        public ServerForUpdateTags()
        {

        }
    }
    /// Application-specific metadata in the form of key-value pairs.
    public partial interface IServerForUpdateTags :
        Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Runtime.IJsonSerializable,
        Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Runtime.IAssociativeArray<string>
    {

    }
    /// Application-specific metadata in the form of key-value pairs.
    internal partial interface IServerForUpdateTagsInternal

    {

    }
}