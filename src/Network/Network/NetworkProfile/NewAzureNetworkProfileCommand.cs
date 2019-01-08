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

using Microsoft.Azure.Commands.ResourceManager.Common.Tags;
using System.Net;
using Microsoft.Azure.Commands.Network.Models;
using Microsoft.Azure.Management.Network;
using Microsoft.Azure.Management.Network.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using AutoMapper;
using MNM = Microsoft.Azure.Management.Network.Models;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;

namespace Microsoft.Azure.Commands.Network
{
    [Cmdlet(VerbsCommon.New, ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "NetworkProfile", SupportsShouldProcess = true), OutputType(typeof(PSNetworkProfile))]
    public partial class NewAzureNetworkProfile : NetworkBaseCmdlet
    {
        [Parameter(
            Mandatory = true,
            HelpMessage = "The resource group name of the network profile.",
            ValueFromPipelineByPropertyName = true)]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Alias("ResourceName")]
        [Parameter(
            Mandatory = true,
            HelpMessage = "The name of the network profile.",
            ValueFromPipelineByPropertyName = true)]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "The location.",
            ValueFromPipelineByPropertyName = true)]
        [LocationCompleter("Microsoft.Network/networkProfiles")]
        public string Location { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "A hashtable which represents resource tags.",
            ValueFromPipelineByPropertyName = true)]
        public Hashtable Tag { get; set; }

        [Alias("ContainerNetworkInterfaceConfiguration")]
        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true)]
        public PSContainerNetworkInterfaceConfiguration[] ContainerNicConfig { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "Do not ask for confirmation if you want to overwrite a resource")]
        public SwitchParameter Force { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Run cmdlet in the background")]
        public SwitchParameter AsJob { get; set; }

        private bool IsResourceReference(Type t)
        {
            return t.Equals(typeof(PSResourceId)) || t.IsSubclassOf(typeof(PSResourceId));
        }

        private void NormalizeChildIds(object inputItem)
        {
            foreach (var item in inputItem.GetType().GetProperties())
            {
                var value = item.GetValue(inputItem);
                if (value != null && value.ToString() != "null")
                {
                    var valueType = value.GetType();
                    if (item.Name == "Id")
                    {
                        string outValue = value.ToString().Replace(
                            "/resourceGroups/" + Microsoft.Azure.Commands.Network.Properties.Resources.ResourceGroupNotSet,
                            "/resourceGroups/" + this.ResourceGroupName);

                        outValue = outValue.Replace(
                            "/networkProfiles/" + Microsoft.Azure.Commands.Network.Properties.Resources.NetworkProfileNameNotSet,
                            "/networkProfiles/" + this.Name);

                        item.SetValue(inputItem, outValue);
                    }
                    else if (value is IList)
                    {
                        if (IsResourceReference(valueType.GetGenericArguments()[0]))
                        {
                            foreach (var listItem in (IList)value)
                            {
                                NormalizeChildIds(listItem);
                            }
                        }
                    }
                    else if (IsResourceReference(valueType))
                    {
                        NormalizeChildIds(value);
                    }
                }
            }
        }

        public override void Execute()
        {
            base.Execute();


            var vNetworkProfile = new PSNetworkProfile
            {
                Location = this.Location,
                ContainerNetworkInterfaceConfigurations = this.ContainerNicConfig == null ? 
                    new List<PSContainerNetworkInterfaceConfiguration>() :
                    new List<PSContainerNetworkInterfaceConfiguration>(this.ContainerNicConfig),
            };

            NormalizeChildIds(vNetworkProfile);

            var vNetworkProfileModel = NetworkResourceManagerProfile.Mapper.Map<MNM.NetworkProfile>(vNetworkProfile);
            vNetworkProfileModel.Tags = TagsConversionHelper.CreateTagDictionary(this.Tag, validate: true);
            var present = true;
            try
            {
                this.NetworkClient.NetworkManagementClient.NetworkProfiles.Get(this.ResourceGroupName, this.Name);
            }
            catch (Microsoft.Rest.Azure.CloudException exception)
            {
                if (exception.Response.StatusCode == HttpStatusCode.NotFound)
                {
                    // Resource is not present
                    present = false;
                }
                else
                {
                    throw;
                }
            }

            ConfirmAction(
                Force.IsPresent,
                string.Format(Properties.Resources.OverwritingResource, Name),
                Properties.Resources.CreatingResourceMessage,
                Name,
            () =>
            {
                this.NetworkClient.NetworkManagementClient.NetworkProfiles.CreateOrUpdate(this.ResourceGroupName, this.Name, vNetworkProfileModel);
                var getNetworkProfile = this.NetworkClient.NetworkManagementClient.NetworkProfiles.Get(this.ResourceGroupName, this.Name);
                var psNetworkProfile = NetworkResourceManagerProfile.Mapper.Map<PSNetworkProfile>(getNetworkProfile);
                psNetworkProfile.ResourceGroupName = this.ResourceGroupName;
                psNetworkProfile.Tag = TagsConversionHelper.CreateTagHashtable(getNetworkProfile.Tags);
                WriteObject(psNetworkProfile, true);
            },
            () => present);

        }
    }
}
