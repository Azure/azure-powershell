namespace Microsoft.Azure.Commands.Network
{
    using AutoMapper;
    using Microsoft.Azure.Commands.Network.Models;
    using Microsoft.Azure.Commands.ResourceManager.Common.Tags;
    using Microsoft.Azure.Management.Network;
    using MNM = Microsoft.Azure.Management.Network.Models;
    using System;
    using System.Collections;
    using System.Management.Automation;
    using System.Net;
    using System.Collections.Generic;

    public class VpnGatewayBaseCmdlet : NetworkBaseCmdlet
    {
        public IVpnGatewaysOperations VpnGatewayClient
        {
            get
            {
                return NetworkClient.NetworkManagementClient.VpnGateways;
            }
        }

        public PSVpnGateway ToPsVpnGateway(Management.Network.Models.VpnGateway vpnGateway)
        {
            var pSVpnGateway = NetworkResourceManagerProfile.Mapper.Map<PSVpnGateway>(vpnGateway);
            pSVpnGateway.Tag = TagsConversionHelper.CreateTagHashtable(vpnGateway.Tags);

            return pSVpnGateway;
        }

        public PSVpnGateway GetVpnGateway(string resourceGroupName, string name)
        {
            var vpnGateway = this.VpnGatewayClient.Get(resourceGroupName, name);
            var psVpnGateway = this.ToPsVpnGateway(vpnGateway);
            psVpnGateway.ResourceGroupName = resourceGroupName;

            return psVpnGateway;
        }

        public List<PSVpnGateway> ListVpnGateways(string resourceGroupName)
        {
            var vpnGateways = string.IsNullOrWhiteSpace(resourceGroupName) ?
                this.VpnGatewayClient.List() :                                              //// List by sub id
                this.VpnGatewayClient.ListByResourceGroup(resourceGroupName);               //// List by RG name

            List<PSVpnGateway> gatewaysToReturn = new List<PSVpnGateway>();
            if (vpnGateways != null)
            {
                foreach (MNM.VpnGateway gateway in vpnGateways)
                {
                    gatewaysToReturn.Add(ToPsVpnGateway(gateway));
                }
            }

            return gatewaysToReturn;
        }

        public PSVpnGateway CreateOrUpdateVpnGateway(string resourceGroupName, string vpnGatewayName, PSVpnGateway vpnGateway, Hashtable tags)
        {
            var vpnGatewayModel = NetworkResourceManagerProfile.Mapper.Map<MNM.VpnGateway>(vpnGateway);
            vpnGatewayModel.Tags = TagsConversionHelper.CreateTagDictionary(tags, validate: true);

            var vpnGatewayCreatedOrUpdated = this.VpnGatewayClient.CreateOrUpdate(resourceGroupName, vpnGatewayName, vpnGatewayModel);
            return this.ToPsVpnGateway(vpnGatewayCreatedOrUpdated);
        }
    }
}
