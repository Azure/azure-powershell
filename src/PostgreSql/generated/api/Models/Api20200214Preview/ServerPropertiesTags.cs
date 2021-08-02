namespace Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Models.Api20200214Preview
{
    using static Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Runtime.Extensions;

    /// <summary>Application-specific metadata in the form of key-value pairs.</summary>
    public partial class ServerPropertiesTags :
        Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Models.Api20200214Preview.IServerPropertiesTags,
        Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Models.Api20200214Preview.IServerPropertiesTagsInternal
    {

        /// <summary>Creates an new <see cref="ServerPropertiesTags" /> instance.</summary>
        public ServerPropertiesTags()
        {

        }
    }
    /// Application-specific metadata in the form of key-value pairs.
    public partial interface IServerPropertiesTags :
        Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Runtime.IJsonSerializable,
        Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Runtime.IAssociativeArray<string>
    {

    }
    /// Application-specific metadata in the form of key-value pairs.
    internal partial interface IServerPropertiesTagsInternal

    {

    }
}