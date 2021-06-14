namespace Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301
{
    using static Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Runtime.Extensions;

    /// <summary>The workspace resource id for log analytics</summary>
    public partial class LogAnalyticsWorkspaceResourceId :
        Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.ILogAnalyticsWorkspaceResourceId,
        Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.ILogAnalyticsWorkspaceResourceIdInternal
    {

        /// <summary>Creates an new <see cref="LogAnalyticsWorkspaceResourceId" /> instance.</summary>
        public LogAnalyticsWorkspaceResourceId()
        {

        }
    }
    /// The workspace resource id for log analytics
    public partial interface ILogAnalyticsWorkspaceResourceId :
        Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Runtime.IJsonSerializable,
        Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Runtime.IAssociativeArray<string>
    {

    }
    /// The workspace resource id for log analytics
    internal partial interface ILogAnalyticsWorkspaceResourceIdInternal

    {

    }
}