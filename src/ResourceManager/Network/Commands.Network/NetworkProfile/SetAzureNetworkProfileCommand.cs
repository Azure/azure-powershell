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

namespace Microsoft.Azure.Commands.Network
{

    [Cmdlet(VerbsCommon.Set, ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "NetworkProfile", SupportsShouldProcess = true), OutputType(typeof(PSNetworkProfile))]
    public class SetAzureNetworkProfileCommand : NetworkBaseCmdlet
    {
        [Parameter(
            Mandatory = true,
            ValueFromPipeline = true,
            HelpMessage = "The network profile")]
        public PSNetworkProfile NetworkProfile { get; set; }

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
                            "/resourceGroups/" + this.NetworkProfile.ResourceGroupName);

                        outValue = outValue.Replace(
                            "/networkProfiles/" + Microsoft.Azure.Commands.Network.Properties.Resources.NetworkProfileNameNotSet,
                            "/networkProfiles/" + this.NetworkProfile.Name);

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

            var present = true;
            try
            {
                this.NetworkClient.NetworkManagementClient.NetworkProfiles.Get(this.NetworkProfile.ResourceGroupName, this.NetworkProfile.Name, null);
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

            if(!present)
            {
                throw new ArgumentException(Microsoft.Azure.Commands.Network.Properties.Resources.ResourceNotFound);
            }

            NormalizeChildIds(this.NetworkProfile);

            // Map to the sdk object
            var vNetworkProfileModel = NetworkResourceManagerProfile.Mapper.Map<MNM.NetworkProfile>(this.NetworkProfile);
            vNetworkProfileModel.Tags = TagsConversionHelper.CreateTagDictionary(this.NetworkProfile.Tag, validate: true);

            // Execute the PUT NetworkProfile call
            this.NetworkClient.NetworkManagementClient.NetworkProfiles.CreateOrUpdate(this.NetworkProfile.ResourceGroupName, this.NetworkProfile.Name, vNetworkProfileModel);

            var getNetworkProfile = this.NetworkClient.NetworkManagementClient.NetworkProfiles.Get(this.NetworkProfile.ResourceGroupName, this.NetworkProfile.Name);
            var psNetworkProfile = NetworkResourceManagerProfile.Mapper.Map<PSNetworkProfile>(getNetworkProfile);
            psNetworkProfile.ResourceGroupName = this.NetworkProfile.ResourceGroupName;
            psNetworkProfile.Tag = TagsConversionHelper.CreateTagHashtable(getNetworkProfile.Tags);
            WriteObject(psNetworkProfile, true);
        }
    }
}
