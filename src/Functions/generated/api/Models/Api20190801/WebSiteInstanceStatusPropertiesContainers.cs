namespace Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Extensions;

    /// <summary>Dictionary of <ContainerInfo></summary>
    public partial class WebSiteInstanceStatusPropertiesContainers :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IWebSiteInstanceStatusPropertiesContainers,
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IWebSiteInstanceStatusPropertiesContainersInternal
    {

        /// <summary>
        /// Creates an new <see cref="WebSiteInstanceStatusPropertiesContainers" /> instance.
        /// </summary>
        public WebSiteInstanceStatusPropertiesContainers()
        {

        }
    }
    /// Dictionary of <ContainerInfo>
    public partial interface IWebSiteInstanceStatusPropertiesContainers :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.IJsonSerializable,
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.IAssociativeArray<Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IContainerInfo>
    {

    }
    /// Dictionary of <ContainerInfo>
    internal partial interface IWebSiteInstanceStatusPropertiesContainersInternal

    {

    }
}