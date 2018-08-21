namespace Microsoft.Azure.Commands.Network
{
    using Microsoft.Azure.Commands.Network.Models;
    using Microsoft.Azure.Commands.ResourceManager.Common.Tags;
    using Microsoft.Azure.Management.Network;
    using System.Net;

    public class VirtualWanBaseCmdlet : NetworkBaseCmdlet
    {
        public IVirtualWANsOperations VirtualWanClient
        {
            get
            {
                return NetworkClient.NetworkManagementClient.VirtualWANs;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="virtualWan"></param>
        /// <returns></returns>
        public PSVirtualWan ToPsVirtualWan(Management.Network.Models.VirtualWAN virtualWan)
        {
            var psVirtualWan = NetworkResourceManagerProfile.Mapper.Map<PSVirtualWan>(virtualWan);

            psVirtualWan.Tag = TagsConversionHelper.CreateTagHashtable(virtualWan.Tags);

            return psVirtualWan;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="resourceGroupName"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public PSVirtualWan GetVirtualWan(string resourceGroupName, string name)
        {
            var virtualWan = this.VirtualWanClient.Get(resourceGroupName, name);
            var psVirtualWan = ToPsVirtualWan(virtualWan);
            psVirtualWan.ResourceGroupName = resourceGroupName;

            return psVirtualWan;
        }
    }
}
