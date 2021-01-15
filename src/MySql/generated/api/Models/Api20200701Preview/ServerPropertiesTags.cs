namespace Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20200701Preview
{
    using static Microsoft.Azure.PowerShell.Cmdlets.MySql.Runtime.Extensions;

    /// <summary>Application-specific metadata in the form of key-value pairs.</summary>
    public partial class ServerPropertiesTags :
        Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20200701Preview.IServerPropertiesTags,
        Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20200701Preview.IServerPropertiesTagsInternal
    {

        /// <summary>Creates an new <see cref="ServerPropertiesTags" /> instance.</summary>
        public ServerPropertiesTags()
        {

        }
    }
    /// Application-specific metadata in the form of key-value pairs.
    public partial interface IServerPropertiesTags :
        Microsoft.Azure.PowerShell.Cmdlets.MySql.Runtime.IJsonSerializable,
        Microsoft.Azure.PowerShell.Cmdlets.MySql.Runtime.IAssociativeArray<string>
    {

    }
    /// Application-specific metadata in the form of key-value pairs.
    internal partial interface IServerPropertiesTagsInternal

    {

    }
}