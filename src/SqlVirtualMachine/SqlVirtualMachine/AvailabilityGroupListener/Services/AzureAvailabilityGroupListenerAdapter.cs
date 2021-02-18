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
using System.Linq;
using Microsoft.Azure.Commands.Common.Authentication.Abstractions;
using Microsoft.Azure.Commands.SqlVirtualMachine.Services;
using Microsoft.Azure.Commands.SqlVirtualMachine.SqlVirtualMachine.Model;
using Microsoft.Azure.Management.SqlVirtualMachine.Models;

namespace Microsoft.Azure.Commands.SqlVirtualMachine.SqlVirtualMachine.Adapter
{
    /// <summary>
    /// Adapter for AvailabilityGroupListener operations. This class is common for all the cmdlets regarding a AvailabilityGroupListener and it is used to 
    /// convert between the powershell object (AzureAvailabilityGroupListenerModel) and the object used by the .NET client (AvailabilityGroupListener). 
    /// After converting the object format it calls the communicator class that handles the communication betweeen the .NET client and Azure.
    /// </summary>
    public class AzureAvailabilityGroupListenerAdapter
    {
        /// <summary>
        /// Gets or sets the communicator which has all the needed management clients
        /// </summary>
        private AzureAvailabilityGroupListenerCommunicator Communicator { get; set; }

        /// <summary>
        /// Gets or sets the Azure profile
        /// </summary>
        public IAzureContext Context { get; set; }

        /// <summary>
        /// Constructs a Availability Group Listener adapter
        /// </summary>
        /// <param name="context">The current azure profile</param>
        public AzureAvailabilityGroupListenerAdapter(IAzureContext context)
        {
            Context = context;
            Communicator = new AzureAvailabilityGroupListenerCommunicator(Context);
        }

        /// <summary>
        /// Upserts a Availability Group Listener
        /// </summary>
        /// <param name="model">The Availability Group Listener to upsert</param>
        /// <returns>The updated Availability Group Listener model</returns>
        public AzureAvailabilityGroupListenerModel UpsertAvailabilityGroupListener(AzureAvailabilityGroupListenerModel model)
        {
            var resp = Communicator.CreateOrUpdate(model.ResourceGroupName, model.GroupName, model.Name, 
                new AvailabilityGroupListener()
                {
                    AvailabilityGroupName = model.AvailabilityGroupName,
                    LoadBalancerConfigurations = model.LoadBalancerConfigurations,
                    Port = model.Port
                });
            return CreateAvailabilityGroupListenerModelFromResponse(resp);
        }

        /// <summary>
        /// Deletes a Availability Group Listener
        /// </summary>
        /// <param name="resourceGroupName">The resource group the Availability Group Listener is in</param>
        /// <param name="groupName">The name of the group</param>
        /// <param name="agListenerName">The name of the Availability Listener Group to be deleted</param>
        public void RemoveAvailabilityGroupListener(string resourceGroupName, string groupName, string agListenerName)
        {
            Communicator.Delete(resourceGroupName, groupName, agListenerName);
        }

        /// <summary>
        /// Gets a list of all the AvailabilityGroupListeners in a group
        /// </summary>
        /// <param name="resourceGroupName">The name of the resource group</param>
        /// <param name="groupName">Name of the Group</param>
        /// <returns>A list of all AvailabilityGroupListeners</returns>
        public List<AzureAvailabilityGroupListenerModel> ListAvailabilityGroupListenerByGroup(string resourceGroupName, string groupName)
        {
            var resp = Communicator.ListByGroup(resourceGroupName, groupName);
            return resp.Select((s) =>
            {
                return CreateAvailabilityGroupListenerModelFromResponse(s);
            }).ToList();
        }

        /// <summary>
        /// Gets a AvailabilityGroupListener
        /// </summary>
        /// <param name="resourceGroupName">The name of the resource group</param>
        /// <param name="groupName">The name of the Group</param>
        /// <param name="agListenerName">Name of the listener</param>
        /// <returns>The AvailabilityGroupListener</returns>
        public AzureAvailabilityGroupListenerModel GetAvailabilityGroupListener(string resourceGroupName, string groupName, string agListenerName)
        {
            var resp = Communicator.Get(resourceGroupName, groupName, agListenerName);
            return CreateAvailabilityGroupListenerModelFromResponse(resp);
        }

        /// <summary>
        /// Convert a Management.SqlVirtualMachine.Models.AvailabilityGroupListenerModel to AzureAvailabilityGroupListenerModel
        /// </summary>
        /// <param name="resp">The management client sql virtual machine group response to convert</param>
        /// <returns>The converted sql virtual machine group model</returns>
        private static AzureAvailabilityGroupListenerModel CreateAvailabilityGroupListenerModelFromResponse(AvailabilityGroupListener resp)
        {
            // Extract the resource group name from the ID.
            string[] segments = resp.Id.Split('/');

            AzureAvailabilityGroupListenerModel model = new AzureAvailabilityGroupListenerModel(segments[4], segments[8])
            {
                Name = resp.Name,
                AvailabilityGroupName = resp.AvailabilityGroupName,
                Port = resp.Port,
                LoadBalancerConfigurations = resp.LoadBalancerConfigurations,
                ResourceId = resp.Id,
                ProvisioningState = resp.ProvisioningState
            };
            return model;
        }
    }
}
