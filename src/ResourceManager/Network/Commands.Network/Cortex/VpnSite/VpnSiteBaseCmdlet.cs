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

    public class VpnSiteBaseCmdlet : NetworkBaseCmdlet
    {
        public IVpnSitesOperations VpnSiteClient
        {
            get
            {
                return NetworkClient.NetworkManagementClient.VpnSites;
            }
        }

        public PSVpnSite ToPsVpnSite(Management.Network.Models.VpnSite vpnSite)
        {
            var psVpnSite = NetworkResourceManagerProfile.Mapper.Map<PSVpnSite>(vpnSite);
            psVpnSite.Tag = TagsConversionHelper.CreateTagHashtable(vpnSite.Tags);

            return psVpnSite;
        }

        public PSVpnSite GetVpnSite(string resourceGroupName, string name)
        {
            var vpnSite = this.VpnSiteClient.Get(resourceGroupName, name);
            var psVpnSite = ToPsVpnSite(vpnSite);
            psVpnSite.ResourceGroupName = resourceGroupName;

            return psVpnSite;
        }

        protected PSBgpSettings ValidateAndCreatePSBgpSettings(uint bgpAsn, uint peeringWeight, string bgpPeeringAddress)
        {
            if ((bgpAsn > 0 && string.IsNullOrWhiteSpace(bgpPeeringAddress)) ||
                (!string.IsNullOrWhiteSpace(bgpPeeringAddress) && bgpAsn == 0))
            {
                throw new PSArgumentException("For a BGP session to be established over IPsec, the VpnSite's ASN and BgpPeeringAddress must both be specified.");
            }

            return new PSBgpSettings
            {
                Asn = bgpAsn,
                BgpPeeringAddress = bgpPeeringAddress,
                PeerWeight = Convert.ToInt32(peeringWeight)
            };
        }

        protected PSVpnSiteDeviceProperties ValidateAndCreateVpnSiteDeviceProperties(string deviceModel, string deviceVendor, uint linkSpeedInMbps)
        {
            if (string.IsNullOrWhiteSpace(deviceModel) || string.IsNullOrWhiteSpace(deviceVendor))
            {
                throw new PSArgumentException("Please specify both device model and device vendor to identify the device");
            }

            return new PSVpnSiteDeviceProperties
            {
                DeviceModel = deviceModel,
                DeviceVendor = deviceVendor,
                LinkSpeedInMbps = Convert.ToInt32(linkSpeedInMbps)
            };
        }

        public PSVpnSite CreateOrUpdateVpnSite(string resourceGroupName, string vpnSiteName, PSVpnSite vpnSite, Hashtable tags)
        {
            var vpnSiteModel = NetworkResourceManagerProfile.Mapper.Map<MNM.VpnSite>(vpnSite);
            vpnSiteModel.Location = vpnSite.Location;
            vpnSiteModel.Tags = TagsConversionHelper.CreateTagDictionary(tags, validate: true);

            var vpnSiteCreatedOrUpdated = this.VpnSiteClient.CreateOrUpdate(resourceGroupName, vpnSiteName, vpnSiteModel);
            return this.ToPsVpnSite(vpnSiteCreatedOrUpdated);
        }

        public List<PSVpnSite> ListVpnSites(string resourceGroupName)
        {
            var vpnSites = string.IsNullOrWhiteSpace(resourceGroupName) ?
                this.VpnSiteClient.List() :                                       //// List by SubId
                this.VpnSiteClient.ListByResourceGroup(resourceGroupName);        //// List by RG Name

            List<PSVpnSite> sitesToReturn = new List<PSVpnSite>();
            if (vpnSites != null)
            {
                foreach (MNM.VpnSite vpnSite in vpnSites)
                {
                    sitesToReturn.Add(ToPsVpnSite(vpnSite));
                }
            }

            return sitesToReturn;
        }
    }
}
