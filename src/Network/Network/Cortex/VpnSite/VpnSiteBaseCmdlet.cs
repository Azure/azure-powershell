// ----------------------------------------------------------------------------------
//
// Copyright Microsoft Corporation
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// http://www.apache.org/licenses/LICENSE-2.0
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// ----------------------------------------------------------------------------------

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
            PSVpnSite siteToReturn = ToPsVpnSite(vpnSiteCreatedOrUpdated);
            siteToReturn.ResourceGroupName = resourceGroupName;

            return siteToReturn;
        }

        public List<PSVpnSite> ListVpnSites(string resourceGroupName)
        {
            var vpnSites = ShouldListBySubscription(resourceGroupName, null) ?
                this.VpnSiteClient.List() :                                       //// List by SubId
                this.VpnSiteClient.ListByResourceGroup(resourceGroupName);        //// List by RG Name

            List<PSVpnSite> sitesToReturn = new List<PSVpnSite>();
            if (vpnSites != null)
            {
                foreach (MNM.VpnSite vpnSite in vpnSites)
                {
                    PSVpnSite siteToReturn = ToPsVpnSite(vpnSite);
                    siteToReturn.ResourceGroupName = resourceGroupName;
                    sitesToReturn.Add(siteToReturn);
                }
            }

            return sitesToReturn;
        }

        public bool IsVpnSitePresent(string resourceGroupName, string name)
        {
            try
            {
                GetVpnSite(resourceGroupName, name);
            }
            catch (Microsoft.Azure.Management.Network.Models.ErrorException exception)
            {
                if (exception.Response.StatusCode == HttpStatusCode.NotFound)
                {
                    // Resource is not present
                    return false;
                }
            }

            return true;
        }
    }
}
