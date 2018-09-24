namespace Microsoft.Azure.Commands.Network
{
    using Microsoft.Azure.Commands.Network.Models;
    using Microsoft.Azure.Commands.ResourceManager.Common.Tags;
    using Microsoft.Azure.Management.Network;
    using Rest.Azure;
    using System.Collections;
    using System.Collections.Generic;
    using System.Net;
    using MNM = Microsoft.Azure.Management.Network.Models;

    public class P2SVpnGatewayBaseCmdlet : NetworkBaseCmdlet
    {
        public IP2sVpnGatewaysOperations P2SVpnGatewayClient
        {
            get
            {
                return NetworkClient.NetworkManagementClient.P2sVpnGateways;
            }
        }

        public PSP2SVpnGateway ToPsP2SVpnGateway(MNM.P2SVpnGateway p2sVpnGateway)
        {
            var pSP2SVpnGateway = NetworkResourceManagerProfile.Mapper.Map<PSP2SVpnGateway>(p2sVpnGateway);
            pSP2SVpnGateway.Tag = TagsConversionHelper.CreateTagHashtable(p2sVpnGateway.Tags);

            return pSP2SVpnGateway;
        }

        public PSP2SVpnGateway GetP2SVpnGateway(string resourceGroupName, string name)
        {
            var p2sVpnGateway = this.P2SVpnGatewayClient.Get(resourceGroupName, name);
            var psP2SVpnGateway = this.ToPsP2SVpnGateway(p2sVpnGateway);
            psP2SVpnGateway.ResourceGroupName = resourceGroupName;

            return psP2SVpnGateway;
        }

        /// <summary>
        /// Gets a list of all P2SVpnGateways under Resource group (if specified), else under subscription.
        /// </summary>
        /// <param name="resourceGroupName">Resource group name</param>
        /// <returns>Virtual Wan P2SVpnServerConfigurations list</returns>
        public List<PSP2SVpnGateway> ListP2SVpnGateways(string resourceGroupName)
        {
            IPage<MNM.P2SVpnGateway> p2sVpnGatewayList;
            if (!string.IsNullOrEmpty(resourceGroupName))
            {
                p2sVpnGatewayList = this.P2SVpnGatewayClient.ListByResourceGroup(resourceGroupName);
            }
            else
            {
                p2sVpnGatewayList = this.P2SVpnGatewayClient.List();
            }

            var p2sVpnGateways = new List<PSP2SVpnGateway>();
            foreach (var p2sVpnGateway in p2sVpnGatewayList)
            {
                var psP2SVpnGateway = this.ToPsP2SVpnGateway(p2sVpnGateway);
                p2sVpnGateways.Add(psP2SVpnGateway);
            }

            return p2sVpnGateways;
        }

        public bool IsP2SVpnGatewayPresent(string resourceGroupName, string name)
        {
            try
            {
                GetP2SVpnGateway(resourceGroupName, name);
            }
            catch (Microsoft.Rest.Azure.CloudException exception)
            {
                if (exception.Response.StatusCode == HttpStatusCode.NotFound)
                {
                    // Resource is not present
                    return false;
                }
                throw;
            }

            return true;
        }

        public PSP2SVpnGateway CreateOrUpdateP2SVpnGateway(string resourceGroupName, string p2sVpnGatewayName, PSP2SVpnGateway p2sVpnGateway, Hashtable tags)
        {
            var p2sVpnGatewayModel = NetworkResourceManagerProfile.Mapper.Map<MNM.P2SVpnGateway>(p2sVpnGateway);
            p2sVpnGatewayModel.Tags = TagsConversionHelper.CreateTagDictionary(tags, validate: true);

            var p2sVpnGatewayCreatedOrUpdated = this.P2SVpnGatewayClient.CreateOrUpdate(resourceGroupName, p2sVpnGatewayName, p2sVpnGatewayModel);
            return this.ToPsP2SVpnGateway(p2sVpnGatewayCreatedOrUpdated);
        }

        public PSVpnProfileResponse GenerateP2SVpnGatewayVpnProfile(string resourceGroupName, string p2sVpnGatewayName, PSP2SVpnProfileParameters p2sVpnProfileParameters)
        {
            var p2sVpnProfileParametersModel = NetworkResourceManagerProfile.Mapper.Map<MNM.P2SVpnProfileParameters>(p2sVpnProfileParameters);

            var generateP2SVpnGatewayVpnProfileResponse = this.P2SVpnGatewayClient.GenerateVpnProfile(resourceGroupName, p2sVpnGatewayName, p2sVpnProfileParametersModel);

            var psVpnProfileResponse = NetworkResourceManagerProfile.Mapper.Map<PSVpnProfileResponse>(generateP2SVpnGatewayVpnProfileResponse);
            return psVpnProfileResponse;
        }
    }
}
