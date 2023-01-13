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
using Microsoft.Azure.Commands.Common.Authentication;
using Microsoft.Azure.Commands.Common.Authentication.Abstractions;
using Microsoft.Azure.Commands.ResourceManager.Common.Tags;
using Microsoft.Azure.Commands.SqlVirtualMachine.Services;
using Microsoft.Azure.Commands.SqlVirtualMachine.SqlVirtualMachine.Model;
using Microsoft.Azure.Management.SqlVirtualMachine;
using Microsoft.Azure.Management.SqlVirtualMachine.Models;

namespace Microsoft.Azure.Commands.SqlVirtualMachine.SqlVirtualMachine.Adapter
{
    /// <summary>
    /// Adapter for Sql Virtual Machine operations. This class is common for all the cmdlets regarding a Sql Virtual Machine and it is used to convert
    /// between the powershell object (AzureSqlVMModel) and the object used by the .NET client (SqlVirtualMachineModel). 
    /// After converting the object format it calls the communicator class that handles the communication betweeen the .NET client and Azure.
    /// </summary>
    public class AzureSqlVMAdapter
    {
        /// <summary>
        /// Gets or sets the communicator which has all the needed management clients
        /// </summary>
        private AzureSqlVMCommunicator Communicator { get; set; }

        /// <summary>
        /// Gets or sets the Azure profile
        /// </summary>
        public IAzureContext DefaultContext { get; private set; }

        /// <summary>
        /// Constructs a sql virtual machine adapter
        /// </summary>
        /// <param name="context">The current azure profile</param>
        public AzureSqlVMAdapter(IAzureContext context)
        {
            DefaultContext = context;
            Communicator = new AzureSqlVMCommunicator(DefaultContext);
        }

        /// <summary>
        /// Upserts a sql virtual machine
        /// </summary>
        /// <param name="model">The sql virtual machine to upsert</param>
        /// <returns>The updated sql virtual machine model</returns>
        public AzureSqlVMModel UpsertSqlVirtualMachine(AzureSqlVMModel model)
        {
            var resp = Communicator.CreateOrUpdate(model.ResourceGroupName, model.Name, new Management.SqlVirtualMachine.Models.SqlVirtualMachineModel()
            {
                Location = model.Location,
                SqlImageOffer = model.Offer,
                SqlImageSku = model.Sku,
                VirtualMachineResourceId = model.VirtualMachineId,
                SqlServerLicenseType = model.LicenseType,
                SqlManagement = model.SqlManagementType,
                SqlVirtualMachineGroupResourceId = model.SqlVirtualMachineGroup != null ? model.SqlVirtualMachineGroup.ResourceId : null,
                WsfcDomainCredentials = model.WsfcDomainCredentials,
                Tags = model.Tags
            });
            return CreateSqlVirtualMachineModelFromResponse(resp);
        }

        /// <summary>
        /// Deletes a sql virtual machine
        /// </summary>
        /// <param name="resourceGroupName">The resource group the sql virtual machine is in</param>
        /// <param name="sqlVirtualMachineName">The name of the sql virtual machine to delete</param>
        public void RemoveSqlVirtualMachine(string resourceGroupName, string sqlVirtualMachineName)
        {
            Communicator.Delete(resourceGroupName, sqlVirtualMachineName);
        }

        /// <summary>
        /// Gets a list of all the sql virtual machines in a subscription
        /// </summary>
        /// <returns>A list of all the sql virtual machines</returns>
        public List<AzureSqlVMModel> ListSqlVirtualMachine()
        {
            var resp = Communicator.List();
            return resp.Select((s) =>
            {
                return CreateSqlVirtualMachineModelFromResponse(s);
            }).ToList();
        }

        /// <summary>
        /// Gets a list of all the sql virtual machines in a resource group
        /// </summary>
        /// <param name="resourceGroupName">The name of the resource group</param>
        /// <returns>A list of all the sql virtual machines</returns>
        public List<AzureSqlVMModel> ListSqlVirtualMachineByResourceGroup(string resourceGroupName)
        {
            var resp = Communicator.ListByResourceGroup(resourceGroupName);
            return resp.Select((s) =>
            {
                return CreateSqlVirtualMachineModelFromResponse(s);
            }).ToList();
        }

        /// <summary>
        /// Gets a sql virtual machine in a resource group
        /// </summary>
        /// <param name="resourceGroupName">The name of the resource group</param>
        /// <param name="sqlVirtualMachineName">The name of the sql virtual machine</param>
        /// <returns>The sql virtual machine</returns>
        public AzureSqlVMModel GetSqlVirtualMachine(string resourceGroupName, string sqlVirtualMachineName)
        {
            var resp = Communicator.Get(resourceGroupName, sqlVirtualMachineName);
            return CreateSqlVirtualMachineModelFromResponse(resp);
        }

        /// <summary>
        /// Convert a Management.SqlVirtualMachine.Models.SqlVirtualMachineModel to AzureSqlVirtualMachineModel
        /// </summary>
        /// <param name="resp">The management client sql virtual machine response to convert</param>
        /// <returns>The converted sql virtual machine model</returns>
        private AzureSqlVMModel CreateSqlVirtualMachineModelFromResponse(SqlVirtualMachineModel resp)
        {
            // Extract the resource group name from the ID.
            // ID is in the form:
            // /subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/rgName/providers/Microsoft.SqlVirtualMachine/SqlVirtualMachine/sqlVirtualMachineName
            string[] segments = resp.Id.Split('/');

            AzureSqlVMModel model = new AzureSqlVMModel(segments[4])
            {
                Name = resp.Name,
                Location = resp.Location,
                Sku = resp.SqlImageSku,
                Offer = resp.SqlImageOffer,
                VirtualMachineId = resp.VirtualMachineResourceId,
                SqlManagementType = resp.SqlManagement,
                LicenseType = resp.SqlServerLicenseType,
                Tags = TagsConversionHelper.CreateTagDictionary(TagsConversionHelper.CreateTagHashtable(resp.Tags), false),
                ResourceId = resp.Id
            };
            
            // Retrieve group
            if (!string.IsNullOrEmpty(resp.SqlVirtualMachineGroupResourceId))
            {
                var client = AzureSession.Instance.ClientFactory.CreateArmClient<SqlVirtualMachineManagementClient>(DefaultContext, AzureEnvironment.Endpoint.ResourceManager);
                string[] groupId = resp.SqlVirtualMachineGroupResourceId.Split('/');

                SqlVirtualMachineGroup group = client.SqlVirtualMachineGroups.Get(groupId[4], groupId[8]);
                model.SqlVirtualMachineGroup = new AzureSqlVMGroupModel(groupId[4])
                {
                    Name = group.Name,
                    Location = group.Location,
                    Sku = group.SqlImageSku,
                    Offer = group.SqlImageOffer,
                    ResourceId = group.Id,
                    Tags = TagsConversionHelper.CreateTagDictionary(TagsConversionHelper.CreateTagHashtable(group.Tags), false),
                    WsfcDomainProfile = group.WsfcDomainProfile
                };
            }
            
            return model;            
        }
    }
}
