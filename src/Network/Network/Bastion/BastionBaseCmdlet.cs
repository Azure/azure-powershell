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

namespace Microsoft.Azure.Commands.Network.Bastion
{
    using System;
    using System.Collections.Generic;
    using System.Net;

    using Microsoft.Azure.Commands.Network.Models;
    using Microsoft.Azure.Commands.Network.Models.Bastion;
    using Microsoft.Azure.Commands.ResourceManager.Common.Tags;
    using Microsoft.Azure.Management.Network;
    using MNM = Management.Network.Models;

    public abstract class BastionBaseCmdlet : NetworkBaseCmdlet
    {
        public IBastionHostsOperations BastionClient
        {
            get
            {
                return NetworkClient.NetworkManagementClient.BastionHosts;
            }
        }
        
        protected IVirtualNetworksOperations VirtualNetworkClient
        {
            get
            {
                return NetworkClient.NetworkManagementClient.VirtualNetworks;
            }
        }

        protected IPublicIPAddressesOperations PublicIPAddressesClient
        {
            get
            {
                return NetworkClient.NetworkManagementClient.PublicIPAddresses;
            }
        }

        public bool IsResourcePresent(string resourceGroupName, string name)
        {
            try
            {
                GetBastion(resourceGroupName, name);
            }
            catch (Rest.Azure.CloudException exception)
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

        public bool TryGetBastion(string resourceGroupName, string name, out PSBastion psBastion)
        {
            psBastion = null;
            try
            {
                psBastion = GetBastion(resourceGroupName, name);
            }
            catch (Rest.Azure.CloudException exception)
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

        public PSBastion GetBastion(string resourceGroupName, string name)
        {
            var bastion = this.BastionClient.Get(resourceGroupName, name);

            var psBastion = NetworkResourceManagerProfile.Mapper.Map<PSBastion>(bastion);
            psBastion.ResourceGroupName = resourceGroupName;
            psBastion.Sku.Name = bastion.Sku.Name;
            psBastion.ScaleUnit = bastion.ScaleUnits;
            psBastion.Tag = TagsConversionHelper.CreateTagHashtable(bastion.Tags);
            psBastion.EnableKerberos = bastion.EnableKerberos;
            psBastion.DisableCopyPaste = bastion.DisableCopyPaste;
            psBastion.EnableTunneling = bastion.EnableTunneling;
            psBastion.EnableIpConnect = bastion.EnableIPConnect;
            psBastion.EnableShareableLink = bastion.EnableShareableLink;
            psBastion.EnableSessionRecording = bastion.EnableSessionRecording;

            return psBastion;
        }

        public PSBastion ToPsBastion(MNM.BastionHost host)
        {
            var bastion = NetworkResourceManagerProfile.Mapper.Map<PSBastion>(host);
            bastion.Sku.Name = host.Sku.Name;
            bastion.ScaleUnit = host.ScaleUnits;
            bastion.Tag = TagsConversionHelper.CreateTagHashtable(host.Tags);
            bastion.EnableKerberos = bastion.EnableKerberos;
            bastion.DisableCopyPaste = host.DisableCopyPaste;
            bastion.EnableTunneling = host.EnableTunneling;
            bastion.EnableIpConnect = host.EnableIPConnect;
            bastion.EnableShareableLink = host.EnableShareableLink;
            bastion.EnableSessionRecording = host.EnableSessionRecording;

            return bastion;
        }

        public List<PSBastion> ListBastions(string resourceGroupName)
        {
            var bastions = ShouldListBySubscription(resourceGroupName, null) ?
                 this.BastionClient.List() :                                              //// List by sub id
                 this.BastionClient.ListByResourceGroup(resourceGroupName);               //// List by RG name

            List<PSBastion> bastionsToReturn = new List<PSBastion>();
            if (bastions != null)
            {
                foreach (MNM.BastionHost bastion in bastions)
                {
                    PSBastion bastionToReturn = ToPsBastion(bastion);
                    bastionToReturn.ResourceGroupName = GetResourceGroup(bastion.Id);
                    bastionsToReturn.Add(bastionToReturn);
                }
            }

            return bastionsToReturn;
        }

        public bool IsSkuDowngrade(PSBastion bastion, string sku)
        {
            if (PSBastionSku.TryGetSkuTier(sku, out string newSkuTier)
                && PSBastionSku.TryGetSkuTier(bastion.Sku.Name, out string existingSkuTier))
            {
                switch (existingSkuTier)
                {
                    case PSBastionSku.Basic:
                        return false;
                    // Standard -> Basic
                    case PSBastionSku.Standard:
                        if (newSkuTier == PSBastionSku.Basic)
                        {
                            return true;
                        }
                        return false;
                    // Premium -> Basic or Standard
                    case PSBastionSku.Premium:
                        if (newSkuTier == PSBastionSku.Basic || newSkuTier == PSBastionSku.Standard)
                        {
                            return true;
                        }
                        return false;
                    default:
                        return true;
                }
            }

            return true;
        }

        public void ValidateScaleUnits(PSBastion bastion, int? scaleUnits = Constants.MinimumScaleUnits)
        {
            if (!scaleUnits.HasValue) return;

            if (PSBastionSku.TryGetSkuTier(bastion.Sku.Name, out string skuTierValue))
            {
                switch (skuTierValue)
                {
                    case PSBastionSku.Basic:
                        if (scaleUnits != Constants.MinimumScaleUnits)
                        {
                            throw new ArgumentException(Properties.Resources.BastionScaleUnitUpdateNotAllowedOnBasic);
                        }
                        break;
                    case PSBastionSku.Standard:
                        if (scaleUnits < Constants.MinimumScaleUnits
                            || scaleUnits > Constants.MaximumScaleUnits)
                        {
                            throw new ArgumentException(string.Format(Properties.Resources.BastionScaleUnitOutOfRange, Constants.MinimumScaleUnits, Constants.MaximumScaleUnits));
                        }
                        break;
                    default:
                        throw new ArgumentException(Properties.Resources.BastionSkuInvalidValue);
                }
            }
            else
            {
                throw new ArgumentException(Properties.Resources.BastionSkuInvalidValue);
            }
        }

        public void ValidateFeatures(PSBastion bastion,
            bool? disableCopyPaste = false,
            bool? enableTunneling = false,
            bool? enableIpConnect = false,
            bool? enableShareableLink = false,
            bool? enableSessionRecording = false)
        {
            if (PSBastionSku.TryGetSkuTier(bastion.Sku.Name, out string skuTierValue))
            {
                switch (skuTierValue)
                {
                    case PSBastionSku.Basic:
                        if (disableCopyPaste != null && disableCopyPaste != false)
                        {
                            throw new ArgumentException(Properties.Resources.BastionCopyPasteInvalidValue);
                        }
                        if (enableTunneling != null && enableTunneling != false)
                        {
                            throw new ArgumentException(Properties.Resources.BastionTunnelingInvalidValue);
                        }
                        if (enableIpConnect != null && enableIpConnect != false)
                        {
                            throw new ArgumentException(Properties.Resources.BastionIpConnectInvalidValue);
                        }
                        if (enableShareableLink != null && enableShareableLink != false)
                        {
                            throw new ArgumentException(Properties.Resources.BastionShareableLinkInvalidValue);
                        }
                        if (enableSessionRecording != null && enableSessionRecording != false)
                        {
                            throw new ArgumentException(Properties.Resources.BastionSessionRecordingInvalidValue);
                        }
                        break;
                    case PSBastionSku.Standard:
                        if (enableSessionRecording != null && enableSessionRecording != false)
                        {
                            throw new ArgumentException(Properties.Resources.BastionSessionRecordingInvalidValue);
                        }
                        break;
                    case PSBastionSku.Premium:
                        if ((enableTunneling.GetValueOrDefault(false) && enableSessionRecording.GetValueOrDefault(false))
                            || (bastion.EnableTunneling.GetValueOrDefault(false) && enableSessionRecording.GetValueOrDefault(false))
                            || (enableTunneling.GetValueOrDefault(false)&& bastion.EnableSessionRecording.GetValueOrDefault(false)))
                        {
                            throw new ArgumentException(Properties.Resources.BastionTunnelingAndSessionRecordingNotAllowed);
                        }
                        break;
                    default:
                        throw new ArgumentException(Properties.Resources.BastionSkuInvalidValue);
                }
            }
            else
            {
                throw new ArgumentException(Properties.Resources.BastionSkuInvalidValue);
            }
        }
    }
}
