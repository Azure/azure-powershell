namespace Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Extensions;

    /// <summary>Connection monitor tags.</summary>
    public partial class ConnectionMonitorTags :
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IConnectionMonitorTags,
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IConnectionMonitorTagsInternal
    {

        /// <summary>Creates an new <see cref="ConnectionMonitorTags" /> instance.</summary>
        public ConnectionMonitorTags()
        {

        }
    }
    /// Connection monitor tags.
    public partial interface IConnectionMonitorTags :
        Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.IJsonSerializable,
        Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.IAssociativeArray<string>
    {

    }
    /// Connection monitor tags.
    internal partial interface IConnectionMonitorTagsInternal

    {

    }
}