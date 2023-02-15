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
using Microsoft.Azure.Commands.ResourceManager.Common.Tags;
using Microsoft.Azure.Commands.SqlVirtualMachine.Services;
using Microsoft.Azure.Commands.SqlVirtualMachine.SqlVirtualMachine.Model;
using Microsoft.Azure.Management.SqlVirtualMachine.Models;

namespace Microsoft.Azure.Commands.SqlVirtualMachine.SqlVirtualMachine.Adapter
{
    /// <summary>
    /// Adapter for Sql Virtual Machine Group operations. This class is common for all the cmdlets regarding a Sql Virtual Machine Group and it is used to 
    /// convert between the powershell object (AzureSqlVMGroupModel) and the object used by the .NET client (SqlVirtualMachineGroup). 
    /// After converting the object format it calls the communicator class that handles the communication betweeen the .NET client and Azure.
    /// </summary>
    public class AzureSqlVMGroupAdapter
    {
        /// <summary>
        /// Gets or sets the communicator which has all the needed management clients
        /// </summary>
        private AzureSqlVMGroupCommunicator Communicator { get; set; }

        /// <summary>
        /// Gets or sets the Azure profile
        /// </summary>
        public IAzureContext Context { get; set; }

        /// <summary>
        /// Constructs a sql virtual machine group adapter
        /// </summary>
        /// <param name="context">The current azure profile</param>
        public AzureSqlVMGroupAdapter(IAzureContext context)
        {
            Context = context;
            Communicator = new AzureSqlVMGroupCommunicator(Context);
        }

        /// <summary>
        /// Upserts a sql virtual machine group
        /// </summary>
        /// <param name="model">The sql virtual machine group to upsert</param>
        /// <returns>The updated sql virtual machine group model</returns>
        public AzureSqlVMGroupModel UpsertSqlVirtualMachineGroup(AzureSqlVMGroupModel model)
        {
            var resp = Communicator.CreateOrUpdate(model.ResourceGroupName, model.Name, new SqlVirtualMachineGroup()
            {
                Location = model.Location,
                SqlImageOffer = model.Offer,
                SqlImageSku = model.Sku,
                WsfcDomainProfile = model.WsfcDomainProfile,
                Tags = model.Tags
            });
            return CreateSqlVirtualMachineGroupModelFromResponse(resp);
        }

        /// <summary>
        /// Deletes a sql virtual machine group
        /// </summary>
        /// <param name="resourceGroupName">The resource group the sql virtual machine goup is in</param>
        /// <param name="sqlVirtualMachineName">The name of the sql virtual machine group to delete</param>
        public void RemoveSqlVirtualMachine(string resourceGroupName, string sqlVirtualMachineName)
        {
            Communicator.Delete(resourceGroupName, sqlVirtualMachineName);
        }

        /// <summary>
        /// Gets a list of all the sql virtual machine groups in a subscription
        /// </summary>
        /// <returns>A list of all the sql virtual machine groups</returns>
        public List<AzureSqlVMGroupModel> ListSqlVirtualMachineGroup()
        {
            var resp = Communicator.List();
            return resp.Select((s) =>
            {
                return CreateSqlVirtualMachineGroupModelFromResponse(s);
            }).ToList();
        }

        /// <summary>
        /// Gets a list of all the sql virtual machine groups in a resource group
        /// </summary>
        /// <param name="resourceGroupName">The name of the resource group</param>
        /// <returns>A list of all the sql virtual machines</returns>
        public List<AzureSqlVMGroupModel> ListSqlVirtualMachineGroupByResourceGroup(string resourceGroupName)
        {
            var resp = Communicator.ListByResourceGroup(resourceGroupName);
            return resp.Select((s) =>
            {
                return CreateSqlVirtualMachineGroupModelFromResponse(s);
            }).ToList();
        }

        /// <summary>
        /// Gets a sql virtual machine group in a resource group
        /// </summary>
        /// <param name="resourceGroupName">The name of the resource group</param>
        /// <param name="groupName">The name of the sql virtual machine group</param>
        /// <returns>The sql virtual machine group</returns>
        public AzureSqlVMGroupModel GetSqlVirtualMachineGroup(string resourceGroupName, string groupName)
        {
            var resp = Communicator.Get(resourceGroupName, groupName);
            return CreateSqlVirtualMachineGroupModelFromResponse(resp);
        }

        /// <summary>
        /// Convert a Management.SqlVirtualMachine.Models.SqlVirtualMachineGroupModel to AzureSqlVirtualMachineGroupModel
        /// </summary>
        /// <param name="resp">The management client sql virtual machine group response to convert</param>
        /// <returns>The converted sql virtual machine group model</returns>
        private static AzureSqlVMGroupModel CreateSqlVirtualMachineGroupModelFromResponse(SqlVirtualMachineGroup resp)
        {
            // Extract the resource group name from the ID.
            string[] segments = resp.Id.Split('/');

            AzureSqlVMGroupModel model = new AzureSqlVMGroupModel(segments[4])
            {
                Name = resp.Name,
                Location = resp.Location,
                Sku = resp.SqlImageSku,
                Offer = resp.SqlImageOffer,
                WsfcDomainProfile = resp.WsfcDomainProfile,
                Tags = TagsConversionHelper.CreateTagDictionary(TagsConversionHelper.CreateTagHashtable(resp.Tags), true),
                ResourceId = resp.Id
            };
            return model;            
        }

       
    }
}
