namespace Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Models.Api20180601Preview
{
    using static Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Runtime.Extensions;

    /// <summary>Application-specific metadata in the form of key-value pairs.</summary>
    public partial class ServerForCreateTags :
        Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Models.Api20180601Preview.IServerForCreateTags,
        Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Models.Api20180601Preview.IServerForCreateTagsInternal
    {

        /// <summary>Creates an new <see cref="ServerForCreateTags" /> instance.</summary>
        public ServerForCreateTags()
        {

        }
    }
    /// Application-specific metadata in the form of key-value pairs.
    public partial interface IServerForCreateTags :
        Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Runtime.IJsonSerializable,
        Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Runtime.IAssociativeArray<string>
    {

    }
    /// Application-specific metadata in the form of key-value pairs.
    internal partial interface IServerForCreateTagsInternal

    {

    }
}