namespace Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Extensions;

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
    public partial interface IWebSiteInstanceStatusPropertiesContainers :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.IJsonSerializable,
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.IAssociativeArray<Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IContainerInfo>
    {

    }
    internal partial interface IWebSiteInstanceStatusPropertiesContainersInternal

    {

    }
}