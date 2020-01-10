namespace Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Extensions;

    /// <summary>Connection monitor tags.</summary>
    public partial class ConnectionMonitorResultTags :
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IConnectionMonitorResultTags,
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IConnectionMonitorResultTagsInternal
    {

        /// <summary>Creates an new <see cref="ConnectionMonitorResultTags" /> instance.</summary>
        public ConnectionMonitorResultTags()
        {

        }
    }
    /// Connection monitor tags.
    public partial interface IConnectionMonitorResultTags :
        Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.IJsonSerializable,
        Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.IAssociativeArray<string>
    {

    }
    /// Connection monitor tags.
    internal partial interface IConnectionMonitorResultTagsInternal

    {

    }
}