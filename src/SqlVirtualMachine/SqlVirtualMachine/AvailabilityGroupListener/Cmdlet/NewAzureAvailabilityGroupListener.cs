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

using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Management.Automation;
using Microsoft.Azure.Commands.SqlVirtualMachine.Common;
using Microsoft.Azure.Commands.SqlVirtualMachine.SqlVirtualMachine.Model;
using Microsoft.Azure.Management.SqlVirtualMachine.Models;
using Microsoft.Rest.Azure;

namespace Microsoft.Azure.Commands.SqlVirtualMachine.SqlVirtualMachine.Cmdlet
{
    /// <summary>
    /// This class implements the New-AzAvailabilityGroupListener cmdlet. It creates a new instance of an Azure Availability Group Listener and returns its information 
    /// to the powershell user as a AzureAvailabilityGroupListenerModel object.
    /// </summary>
    [Cmdlet(VerbsCommon.New, ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "AvailabilityGroupListener", SupportsShouldProcess = true, DefaultParameterSetName = ParameterSet.Name)]
    [OutputType(typeof(AzureAvailabilityGroupListenerModel))]
    public class NewAzureAvailabilityGroupListener : AzureAvailabilityGroupListenerUpsertCmdletBase
    {
        /// <summary>
        /// Name of the Availability Group
        /// </summary>
        [Parameter(
            Mandatory = true,
            HelpMessage = HelpMessages.AvailabilityGroupNameHelpMessage)]
        public string AvailabilityGroupName { get; private set; }

        /// <summary>
        /// Port number of AG Listener. Default Value is 1433.
        /// </summary>
        [Parameter(
            Mandatory = false,
            HelpMessage = HelpMessages.PortHelpMessage)]
        public int? Port { get; private set; } = 1433;

        /// <summary>
        /// Load Balancer Resource Id
        /// </summary>
        [Parameter(
            Mandatory = true,
            HelpMessage = HelpMessages.LoadBalancerResourceIdHelpMessage)]
        public string LoadBalancerResourceId { get; private set; }

        /// <summary>
        /// Private Ip Address
        /// </summary>
        [Parameter(
            Mandatory = false,
            HelpMessage = HelpMessages.PrivateIpAddressHelpMessage)]
        public string IpAddress { get; private set; }

        /// <summary>
        /// Private Ip Address
        /// </summary>
        [Parameter(
            Mandatory = false,
            HelpMessage = HelpMessages.SubnetIdHelpMessage)]
        public string SubnetId { get; private set; }

        /// <summary>
        /// Probe Port
        /// </summary>
        [Parameter(
            Mandatory = true,
            HelpMessage = HelpMessages.ProbePortHelpMessage)]
        public int? ProbePort { get; private set; }

        /// <summary>
        /// Public Ip Address of the AG Listener
        /// </summary>
        [Parameter(
            Mandatory = false,
            HelpMessage = HelpMessages.PublicIpAddressResourceIdHelpMessage)]
        public string PublicIpAddressResourceId { get; private set; }

        /// <summary>
        /// Gets or sets whether or not to run this cmdlet in the background as a job
        /// </summary>
        [Parameter(
            Mandatory = false,
            HelpMessage = HelpMessages.AsJobHelpMessage)]
        public SwitchParameter AsJob { get; set; }

        /// <summary>
        /// Parse the parameters provided as input in order to obtain the name of the resource group and the Availability Group Listener
        /// </summary>
        protected override void ParseInput()
        {
            if (ParameterSetName == ParameterSet.SqlVMGroupObject)
            {
                ResourceGroupName = SqlVMGroupObject.ResourceGroupName;
                SqlVMGroupName = SqlVMGroupObject.Name;
            }
        }

        /// <summary>
        /// Check to see if Availability Group Listener with the same name already exists in this resource group.
        /// </summary>
        /// <returns>Null if the Availability Group Listener doesn't exist.  Otherwise throws exception</returns>
        protected override IEnumerable<AzureAvailabilityGroupListenerModel> GetEntity()
        {
            try
            {
                ModelAdapter.GetAvailabilityGroupListener(this.ResourceGroupName, this.SqlVMGroupName, this.Name);
            }
            catch (CloudException)
            {
                return null;
            }

            throw new PSArgumentException(
                string.Format("An Availability Group Listener with name {0} in resource group {1} already exists. If you want to modify an existing Availability Group Listener you can use" +
                " Update-AzAvailabilityGroupListener command.", Name, ResourceGroupName),
                "AvailabilityGroupListener");
        }

        /// <summary>
        /// Generates the model from user input.
        /// </summary>
        /// <param name="model">This is null since the Availability Group Listener doesn't exist yet</param>
        /// <returns>The generated model from user input</returns>
        protected override IEnumerable<AzureAvailabilityGroupListenerModel> ApplyUserInputToModel(IEnumerable<AzureAvailabilityGroupListenerModel> model)
        {
            List<AzureAvailabilityGroupListenerModel> newEntity = new List<AzureAvailabilityGroupListenerModel>();
            var privateIpAddress = new PrivateIPAddress()
            {
                IpAddress = this.IpAddress,
                SubnetResourceId = this.SubnetId
            };
            var loadBalancerConfiguration = new LoadBalancerConfiguration()
            {
                LoadBalancerResourceId = this.LoadBalancerResourceId,
                PrivateIpAddress = privateIpAddress,
                ProbePort = this.ProbePort,
                PublicIpAddressResourceId = this.PublicIpAddressResourceId,
                SqlVirtualMachineInstances = this.SqlVirtualMachineId
            };
            var loadBalancerConfigurations = new List<LoadBalancerConfiguration>();
            loadBalancerConfigurations.Add(loadBalancerConfiguration);

            newEntity.Add(new AzureAvailabilityGroupListenerModel(ResourceGroupName, SqlVMGroupName)
            {
                AvailabilityGroupName = this.AvailabilityGroupName,
                Name = this.Name,
                Port = this.Port,
                LoadBalancerConfigurations = loadBalancerConfigurations
            });
            return newEntity;
        }

        /// <summary>
        /// Creates the Availability Group Listener
        /// </summary>
        /// <param name="entity">The Availability Group Listener to create</param>
        /// <returns>The created Availability Group Listener</returns>
        protected override IEnumerable<AzureAvailabilityGroupListenerModel> PersistChanges(IEnumerable<AzureAvailabilityGroupListenerModel> entity)
        {
            return new List<AzureAvailabilityGroupListenerModel>()
            {
                ModelAdapter.UpsertAvailabilityGroupListener(entity.FirstOrDefault())
            };
        }
    }
}
