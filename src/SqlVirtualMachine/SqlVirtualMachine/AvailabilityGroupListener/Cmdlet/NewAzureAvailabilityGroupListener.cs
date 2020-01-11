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

using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Security;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Commands.ResourceManager.Common.Tags;
using Microsoft.Azure.Commands.SqlVirtualMachine.Common;
using Microsoft.Azure.Commands.SqlVirtualMachine.Common.ArgumentCompleters;
using Microsoft.Azure.Commands.SqlVirtualMachine.SqlVirtualMachine.Model;
using Microsoft.Azure.Management.SqlVirtualMachine.Models;
using Microsoft.Rest.Azure;
using Microsoft.WindowsAzure.Commands.Common;

namespace Microsoft.Azure.Commands.SqlVirtualMachine.SqlVirtualMachine.Cmdlet
{
    /// <summary>
    /// This class implements the New-AzAvailabilityGroupListener cmdlet. It creates a new instance of an Azure Availability Group Listener and returns its information 
    /// to the powershell user as a AzureAvailabilityGroupListenerModel object.
    /// </summary>
    [Cmdlet(VerbsCommon.New, ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "AvailabilityGroupListener", SupportsShouldProcess = true)]
    [OutputType(typeof(AzureAvailabilityGroupListenerModel))]
    public class NewAzureAvailabilityGroupListener : AzureAvailabilityGroupListenerUpsertCmdletBase
    {
        /// <summary>
        /// Gets or sets whether or not to run this cmdlet in the background as a job
        /// </summary>
        [Parameter(
            Mandatory = false,
            HelpMessage = HelpMessages.AsJobHelpMessage)]
        public SwitchParameter AsJob { get; set; }
        public string AvailabilityGroupName { get; private set; }
        public int? Port { get; private set; }
        public bool? CreateDefaultAvailabilityGroupIfNotExist { get; private set; }
        public string LoadBalanceResourceId { get; private set; }
        public PrivateIPAddress PrivateIpAddress { get; private set; }
        public int? ProbePort { get; private set; }
        public string PublicIpAddressResourceId { get; private set; }
        public IList<string> SqlVirtualMachineInstances { get; private set; }

        /// <summary>
        /// Check to see if Availability Group Listener with the same name already exists in this resource group.
        /// </summary>
        /// <returns>Null if the Availability Group Listener doesn't exist.  Otherwise throws exception</returns>
        protected override IEnumerable<AzureAvailabilityGroupListenerModel> GetEntity()
        {
            try
            {
                ModelAdapter.GetAvailabilityGroupListener(this.ResourceGroupName, this.GroupName, this.Name);
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
            var loadBalancerConfiguration = new LoadBalancerConfiguration()
            {
                LoadBalancerResourceId = this.LoadBalanceResourceId,
                PrivateIpAddress = this.PrivateIpAddress,
                ProbePort = this.ProbePort,
                PublicIpAddressResourceId = this.PublicIpAddressResourceId,
                SqlVirtualMachineInstances = this.SqlVirtualMachineInstances
            };
            var loadBalancerConfigurations = new List<LoadBalancerConfiguration>();
            loadBalancerConfigurations.Add(loadBalancerConfiguration);

            newEntity.Add(new AzureAvailabilityGroupListenerModel(ResourceGroupName)
            {
                AvailabilityGroupName = this.AvailabilityGroupName,
                Name = this.Name,
                Port = this.Port,
                CreateDefaultAvailabilityGroupIfNotExist = this.CreateDefaultAvailabilityGroupIfNotExist,
                LoadBalancerConfigurations = loadBalancerConfigurations,
                Tags = TagsConversionHelper.CreateTagDictionary(Tag, validate: true)
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
