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
    using System.Collections;
    using System.ComponentModel;
    using System.Management.Automation;

    using Microsoft.Azure.Commands.Network.Models;
    using Microsoft.Azure.Commands.Network.Models.Bastion;
    using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
    using Microsoft.Azure.Commands.ResourceManager.Common.Tags;
    using Microsoft.Azure.Management.Internal.Resources.Utilities.Models;
    using Microsoft.Azure.Management.Network;
    using MNM = Management.Network.Models;

    [Cmdlet(VerbsCommon.New,
       ResourceManager.Common.AzureRMConstants.AzureRMPrefix + Constants.BastionResourceName,
       DefaultParameterSetName = BastionParameterSetNames.ByIpObject + BastionParameterSetNames.ByVNObject,
       SupportsShouldProcess = true),
       OutputType(typeof(PSBastion))]

    public class NewAzBastionCommand : BastionBaseCmdlet
    {
        [Parameter(
            Mandatory = true,
            HelpMessage = "The resource group name where you need to create bastion.")]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Alias("ResourceName", "BastionName")]
        [Parameter(
            Mandatory = true,
            HelpMessage = "The Bastion resource name.")]
        [ValidateNotNullOrEmpty]
        [ResourceNameCompleter(Constants.BastionResourceType, "ResourceGroupName")]
        public string Name { get; set; }

        [Alias("PublicIpAddressObject")]
        [Parameter(
            Mandatory = true,
             ParameterSetName = BastionParameterSetNames.ByIpObject + BastionParameterSetNames.ByVNObject,
            HelpMessage = "The public IP address object for bastion.")]
        [Parameter(
            Mandatory = true,
             ParameterSetName = BastionParameterSetNames.ByIpObject + BastionParameterSetNames.ByVNRGName + BastionParameterSetNames.ByVNName,
            HelpMessage = "The public IP address object for bastion.")]
        [Parameter(
            Mandatory = true,
             ParameterSetName = BastionParameterSetNames.ByIpObject + BastionParameterSetNames.ByVNResourceId,
            HelpMessage = "The public IP address object for bastion.")]
        [ValidateNotNull]
        public PSPublicIpAddress PublicIpAddress { get; set; }

        [Alias("PublicIpAddressResourceId")]
        [Parameter(
            Mandatory = true,
             ParameterSetName = BastionParameterSetNames.ByIpResourceId + BastionParameterSetNames.ByVNObject,
            HelpMessage = "The public Ip address Azure resource Id for bastion.")]
        [Parameter(
            Mandatory = true,
             ParameterSetName = BastionParameterSetNames.ByIpResourceId + BastionParameterSetNames.ByVNRGName + BastionParameterSetNames.ByVNName,
            HelpMessage = "The public Ip address Azure resource Id for bastion.")]
        [Parameter(
            Mandatory = true,
             ParameterSetName = BastionParameterSetNames.ByIpResourceId + BastionParameterSetNames.ByVNResourceId,
            HelpMessage = "The public Ip address Azure resource Id for bastion.")]
        [ValidateNotNullOrEmpty]
        public string PublicIpAddressId { get; set; }

        [Alias("PublicIpAddressResourceGroupName")]
        [Parameter(
            Mandatory = true,
             ParameterSetName = BastionParameterSetNames.ByIpRGName + BastionParameterSetNames.ByIpName + BastionParameterSetNames.ByVNObject,
            HelpMessage = "The public Ip address resource group name for bastion.")]
        [Parameter(
            Mandatory = true,
             ParameterSetName = BastionParameterSetNames.ByIpRGName + BastionParameterSetNames.ByIpName + BastionParameterSetNames.ByVNRGName + BastionParameterSetNames.ByVNName,
            HelpMessage = "The public Ip address resource group name for bastion.")]
        [Parameter(
            Mandatory = true,
             ParameterSetName = BastionParameterSetNames.ByIpRGName + BastionParameterSetNames.ByIpName + BastionParameterSetNames.ByVNResourceId,
            HelpMessage = "The public Ip address resource group name for bastion.")]
        [ValidateNotNullOrEmpty]
        public string PublicIpAddressRgName { get; set; }

        [Parameter(
            Mandatory = true,
             ParameterSetName = BastionParameterSetNames.ByIpRGName + BastionParameterSetNames.ByIpName + BastionParameterSetNames.ByVNObject,
            HelpMessage = "The public Ip address resource name for bastion.")]
        [Parameter(
            Mandatory = true,
             ParameterSetName = BastionParameterSetNames.ByIpRGName + BastionParameterSetNames.ByIpName + BastionParameterSetNames.ByVNRGName + BastionParameterSetNames.ByVNName,
            HelpMessage = "The public Ip address resource name for bastion.")]
        [Parameter(
            Mandatory = true,
             ParameterSetName = BastionParameterSetNames.ByIpRGName + BastionParameterSetNames.ByIpName + BastionParameterSetNames.ByVNResourceId,
            HelpMessage = "The public Ip address resource name for bastion.")]
        [ValidateNotNullOrEmpty]
        public string PublicIpAddressName { get; set; }

        [Alias("VirtualNetworkObject")]
        [Parameter(
            Mandatory = true,
             ParameterSetName = BastionParameterSetNames.ByIpObject + BastionParameterSetNames.ByVNObject,
            HelpMessage = "The virtual network object for bastion.")]
        [Parameter(
            Mandatory = true,
             ParameterSetName = BastionParameterSetNames.ByIpRGName + BastionParameterSetNames.ByIpName + BastionParameterSetNames.ByVNObject,
            HelpMessage = "The virtual network name for bastion.")]
        [Parameter(
            Mandatory = true,
             ParameterSetName = BastionParameterSetNames.ByIpResourceId + BastionParameterSetNames.ByVNObject,
            HelpMessage = "The virtual network name for bastion.")]
        [ValidateNotNull]
        public PSVirtualNetwork VirtualNetwork { get; set; }

        [Alias("VirtualNetworkResourceId")]
        [Parameter(
           Mandatory = true,
            ParameterSetName = BastionParameterSetNames.ByIpObject + BastionParameterSetNames.ByVNResourceId,
           HelpMessage = "The virtual network Azure resource Id for bastion.")]
        [Parameter(
           Mandatory = true,
            ParameterSetName = BastionParameterSetNames.ByIpRGName + BastionParameterSetNames.ByIpName + BastionParameterSetNames.ByVNResourceId,
           HelpMessage = "The virtual network Azure resource Id for bastion.")]
        [Parameter(
           Mandatory = true,
            ParameterSetName = BastionParameterSetNames.ByIpResourceId + BastionParameterSetNames.ByVNResourceId,
           HelpMessage = "The virtual network Azure resource Id for bastion.")]
        [ValidateNotNullOrEmpty]
        public string VirtualNetworkId { get; set; }

        [Alias("VirtualNetworkResourceGroupName")]
        [Parameter(
            Mandatory = true,
             ParameterSetName = BastionParameterSetNames.ByIpObject + BastionParameterSetNames.ByVNRGName + BastionParameterSetNames.ByVNName,
            HelpMessage = "The virtual network resource group name for bastion.")]
        [Parameter(
            Mandatory = true,
             ParameterSetName = BastionParameterSetNames.ByIpRGName + BastionParameterSetNames.ByIpName + BastionParameterSetNames.ByVNRGName + BastionParameterSetNames.ByVNName,
            HelpMessage = "The virtual network resource group name for bastion.")]
        [Parameter(
            Mandatory = true,
             ParameterSetName = BastionParameterSetNames.ByIpResourceId + BastionParameterSetNames.ByVNRGName + BastionParameterSetNames.ByVNName,
            HelpMessage = "The virtual network resource group name for bastion.")]
        [ValidateNotNullOrEmpty]
        public string VirtualNetworkRgName { get; set; }

        [Parameter(
           Mandatory = true,
            ParameterSetName = BastionParameterSetNames.ByIpObject + BastionParameterSetNames.ByVNRGName + BastionParameterSetNames.ByVNName,
           HelpMessage = "The virtual network resource name for bastion.")]
        [Parameter(
           Mandatory = true,
            ParameterSetName = BastionParameterSetNames.ByIpRGName + BastionParameterSetNames.ByIpName + BastionParameterSetNames.ByVNRGName + BastionParameterSetNames.ByVNName,
           HelpMessage = "The virtual network resource name for bastion.")]
        [Parameter(
           Mandatory = true,
            ParameterSetName = BastionParameterSetNames.ByIpResourceId + BastionParameterSetNames.ByVNRGName + BastionParameterSetNames.ByVNName,
           HelpMessage = "The virtual network resource name for bastion.")]
        [ValidateNotNullOrEmpty]
        public string VirtualNetworkName { get; set; }

        [Parameter(
            Mandatory = false,
            ValueFromPipeline = true,
            HelpMessage = "The Bastion Sku Tier")]
        [PSArgumentCompleter(PSBastionSku.Basic, PSBastionSku.Standard, PSBastionSku.Premium)]
        [ValidateSet(
            MNM.BastionHostSkuName.Basic,
            MNM.BastionHostSkuName.Standard,
            MNM.BastionHostSkuName.Premium,
            IgnoreCase = false)]
        public string Sku { get; set; }

        [Parameter(
            Mandatory = false,
            ValueFromPipeline = true,
            HelpMessage = "The Scale Units for Bastion")]
        [DefaultValue(Constants.MinimumScaleUnits)]
        public int? ScaleUnit { get; set; }

        [Parameter(
            Mandatory = false,
            ValueFromPipeline = true,
            HelpMessage = "Kerberos")]
        [DefaultValue(false)]
        public bool? EnableKerberos { get; set; }

        [Parameter(
            Mandatory = false,
            ValueFromPipeline = true,
            HelpMessage = "Copy and Paste")]
        [DefaultValue(false)]
        public bool? DisableCopyPaste { get; set; }

        [Parameter(
            Mandatory = false,
            ValueFromPipeline = true,
            HelpMessage = "Native Client")]
        [DefaultValue(false)]
        public bool? EnableTunneling { get; set; }

        [Parameter(
            Mandatory = false,
            ValueFromPipeline = true,
            HelpMessage = "IP Connect")]
        [DefaultValue(false)]
        public bool? EnableIpConnect { get; set; }

        [Parameter(
            Mandatory = false,
            ValueFromPipeline = true,
            HelpMessage = "Shareable Link")]
        [DefaultValue(false)]
        public bool? EnableShareableLink { get; set; }

        [Parameter(
           Mandatory = false,
           ValueFromPipeline = true,
           HelpMessage = "Session Recording")]
        [DefaultValue(false)]
        public bool? EnableSessionRecording { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "Run cmdlet in the background")]
        public SwitchParameter AsJob { get; set; }

        [Parameter(
             Mandatory = false,
             HelpMessage = "A hashtable which represents resource tags.")]
        public Hashtable Tag { get; set; }

        public override void Execute()
        {
            if (this.IsResourcePresent(this.ResourceGroupName, this.Name))
            {
                throw new PSArgumentException(string.Format(Properties.Resources.ResourceAlreadyPresentInResourceGroup, this.Name, this.ResourceGroupName));
            }

            ParsePublicIpAddressObject();

            ParseVirtualNetworkObject();

            base.Execute();

            ConfirmAction(
                Properties.Resources.CreatingResourceMessage,
                Name,
                 () =>
                 {
                     WriteVerbose(String.Format(Properties.Resources.CreatingLongRunningOperationMessage, this.ResourceGroupName, this.Name));
                     WriteObject(this.CreateBastion());
                });
        }

        private PSBastion CreateBastion()
        {
            PSBastion bastion = new PSBastion(this.Name, this.ResourceGroupName, this.VirtualNetwork.Location, this.Sku);

            #region Feature Validations
            ValidateFeatures(bastion, this.DisableCopyPaste, this.EnableTunneling, this.EnableIpConnect, this.EnableShareableLink, this.EnableSessionRecording);
            if (this.EnableKerberos.HasValue)
            {
                bastion.EnableKerberos = this.EnableKerberos.Value;
            }
            if (this.DisableCopyPaste.HasValue)
            {
                bastion.DisableCopyPaste = this.DisableCopyPaste.Value;
            }
            if (this.EnableTunneling.HasValue)
            {
                bastion.EnableTunneling = this.EnableTunneling.Value;
            }
            if (this.EnableIpConnect.HasValue)
            {
                bastion.EnableIpConnect = this.EnableIpConnect.Value;
            }
            if (this.EnableShareableLink.HasValue)
            {
                bastion.EnableShareableLink = this.EnableShareableLink.Value;
            }
            if (this.EnableSessionRecording.HasValue)
            {
                bastion.EnableSessionRecording = this.EnableSessionRecording.Value;
            }
            #endregion

            #region Scale Unit Validations
            ValidateScaleUnits(bastion, this.ScaleUnit);
            if (this.ScaleUnit.HasValue)
            {
                bastion.ScaleUnit = this.ScaleUnit.Value;
            }
            #endregion

            if (this.VirtualNetwork != null)
            {
                bastion.Allocate(this.VirtualNetwork, this.PublicIpAddress);
            }

            //// Map to the sdk object
            var BastionModel = NetworkResourceManagerProfile.Mapper.Map<MNM.BastionHost>(bastion);
            //// PS does not allow plurals which is why there is a mismatch in property name and hence the below line
            BastionModel.ScaleUnits = bastion.ScaleUnit;
            BastionModel.Tags = TagsConversionHelper.CreateTagDictionary(this.Tag, validate: true);

            //// Execute the Create bastion call
            this.BastionClient.CreateOrUpdate(this.ResourceGroupName, this.Name, BastionModel);

            return this.GetBastion(this.ResourceGroupName, this.Name);
        }
        
       public void ParsePublicIpAddressObject()
        {
            //// Get PublicIpAddressRgName and PublicIpAddressName by PublicIpAddressId
            if (ParameterSetName.Contains(BastionParameterSetNames.ByIpResourceId))
            {
                var parsedResourceId = new ResourceIdentifier(this.PublicIpAddressId);
                this.PublicIpAddressRgName = parsedResourceId.ResourceGroupName;
                this.PublicIpAddressName = parsedResourceId.ResourceName;
            }

            //// Get PublicIpAddress by PublicIpAddressRgName and PublicIpAddressName
            if (ParameterSetName.Contains(BastionParameterSetNames.ByIpRGName + BastionParameterSetNames.ByIpName) || ParameterSetName.Contains(BastionParameterSetNames.ByIpResourceId))
            {
                var publicIp = this.PublicIPAddressesClient.Get(this.PublicIpAddressRgName, this.PublicIpAddressName);
                this.PublicIpAddress = NetworkResourceManagerProfile.Mapper.Map<PSPublicIpAddress>(publicIp);
            }
            else
            {
                //// Get PublicIpAddress by publicIpObject
                this.PublicIpAddress = PublicIpAddress;
            }

            if (this.PublicIpAddress == null)
            {
                throw new ArgumentException(string.Format(Properties.Resources.ResourceNotFound, this.PublicIpAddressName));
            }
        }
        
        public void ParseVirtualNetworkObject()
        {
            //// Get VirtualNetworkRgName and VirtualNetworkName by ByVNResourceId
            if (ParameterSetName.Contains(BastionParameterSetNames.ByVNResourceId))
            {
                var parsedResourceId = new ResourceIdentifier(this.VirtualNetworkId);
                this.VirtualNetworkRgName = parsedResourceId.ResourceGroupName;
                this.VirtualNetworkName = parsedResourceId.ResourceName;
            }

            //// Get Virtual Network by VirtualNetworkRgName and VirtualNetworkName
            if (ParameterSetName.Contains(BastionParameterSetNames.ByVNRGName + BastionParameterSetNames.ByVNName) || ParameterSetName.Contains(BastionParameterSetNames.ByVNResourceId))
            {
                var vnet = this.VirtualNetworkClient.Get(this.VirtualNetworkRgName, VirtualNetworkName);
                this.VirtualNetwork = NetworkResourceManagerProfile.Mapper.Map<PSVirtualNetwork>(vnet);
            }
            else
            {
                //// Get virtual network by virtualNetworkObject
                this.VirtualNetwork = VirtualNetwork;
            }

            if (this.VirtualNetwork == null)
            {
                throw new ArgumentException(string.Format(Properties.Resources.ResourceNotFound, this.VirtualNetworkName));
            }
        }
    }
}
