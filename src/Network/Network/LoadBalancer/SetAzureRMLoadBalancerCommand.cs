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

    [Cmdlet(VerbsCommon.Set, ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "LoadBalancer", SupportsShouldProcess = true), OutputType(typeof(PSLoadBalancer))]
    public class SetAzureLoadBalancerCommand : NetworkBaseCmdlet
    {
        [Parameter(
            Mandatory = true,
            ValueFromPipeline = true,
            HelpMessage = "The load balancer")]
        public PSLoadBalancer LoadBalancer { get; set; }

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
                            "/resourceGroups/" + this.LoadBalancer.ResourceGroupName);

                        outValue = outValue.Replace(
                            "/loadBalancers/" + Microsoft.Azure.Commands.Network.Properties.Resources.LoadBalancerNameNotSet,
                            "/loadBalancers/" + this.LoadBalancer.Name);

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
                this.NetworkClient.NetworkManagementClient.LoadBalancers.Get(this.LoadBalancer.ResourceGroupName, this.LoadBalancer.Name);
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

            NormalizeChildIds(this.LoadBalancer);

            // Map to the sdk object
            var vLoadBalancerModel = NetworkResourceManagerProfile.Mapper.Map<MNM.LoadBalancer>(this.LoadBalancer);
            vLoadBalancerModel.Tags = TagsConversionHelper.CreateTagDictionary(this.LoadBalancer.Tag, validate: true);

            List<string> resourceIds = new List<string>();
            Dictionary<string, List<string>> auxAuthHeader = null;

            // Get aux token for each gateway lb references
            foreach (FrontendIPConfiguration frontend in vLoadBalancerModel.FrontendIPConfigurations)
            {
                if (frontend.GatewayLoadBalancer != null)
                {
                    //Get the aux header for the remote vnet
                    resourceIds.Add(frontend.GatewayLoadBalancer.Id);
                }
            }

            if (resourceIds.Count > 0)
            {
                var auxHeaderDictionary = GetAuxilaryAuthHeaderFromResourceIds(resourceIds);
                if (auxHeaderDictionary != null && auxHeaderDictionary.Count > 0)
                {
                    auxAuthHeader = new Dictionary<string, List<string>>(auxHeaderDictionary);
                }
            }

            // Execute the PUT LoadBalancer call
            this.NetworkClient.NetworkManagementClient.LoadBalancers.CreateOrUpdateWithHttpMessagesAsync(this.LoadBalancer.ResourceGroupName, this.LoadBalancer.Name, vLoadBalancerModel, auxAuthHeader).GetAwaiter().GetResult();

            var getLoadBalancer = this.NetworkClient.NetworkManagementClient.LoadBalancers.Get(this.LoadBalancer.ResourceGroupName, this.LoadBalancer.Name);
            var psLoadBalancer = NetworkResourceManagerProfile.Mapper.Map<PSLoadBalancer>(getLoadBalancer);
            psLoadBalancer.ResourceGroupName = this.LoadBalancer.ResourceGroupName;
            psLoadBalancer.Tag = TagsConversionHelper.CreateTagHashtable(getLoadBalancer.Tags);
            WriteObject(psLoadBalancer, true);
        }
    }
}
