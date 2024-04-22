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

using Microsoft.Azure.Commands.Common.Authentication.Abstractions;
using Microsoft.Azure.Commands.Sql.ManagedInstanceHybridLink.Model;
using Microsoft.Azure.Management.Sql.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Microsoft.Azure.Commands.Sql.ManagedInstanceHybridLink.Services
{
    /// <summary>
    /// Adapter for ManagedInstanceLink operations
    /// </summary>
    public class AzureSqlManagedInstanceLinkAdapter
    {
        /// <summary>
        /// Gets or sets the AzureSqlManagedInstanceLinkCommunicator which has all the needed management clients
        /// </summary>
        private AzureSqlManagedInstanceLinkCommunicator Communicator { get; set; }

        /// <summary>
        /// Gets or sets the Azure profile
        /// </summary>
        public IAzureContext Context { get; set; }

        /// <summary>
        /// Constructs a ManagedInstanceLink adapter
        /// </summary>
        /// <param name="context"></param>
        public AzureSqlManagedInstanceLinkAdapter(IAzureContext context)
        {
            Context = context;
            Communicator = new AzureSqlManagedInstanceLinkCommunicator(Context);
        }

        /// <summary>
        /// Gets a managed instance link in a managed instance
        /// </summary>
        /// <param name="resourceGroupName">Name of the resource group</param>
        /// <param name="instanceName">Name of the managed instance</param>
        /// <param name="distributedAvailabilityGroupName">Name of the DAG</param>
        /// <returns>The managed instance link</returns>
        public AzureSqlManagedInstanceLinkModel GetManagedInstanceLink(string resourceGroupName, string instanceName, string distributedAvailabilityGroupName)
        {
            try
            {
                var resp = Communicator.Get(resourceGroupName, instanceName, distributedAvailabilityGroupName);
                return CreateManagedInstanceLinkModelFromResponse(resourceGroupName, instanceName, resp);
            }
            catch (ErrorResponseException ex)
            {
                throw CreateExceptionWithDescriptiveErrorMessage(ex);
            }
        }

        /// <summary>
        /// Gets a list of all distributed availiability groups in managed instance
        /// </summary>
        /// <param name="resourceGroupName"></param>
        /// <param name="instanceName"></param>
        /// <returns>A list of all the server trust certificates</returns>
        public List<AzureSqlManagedInstanceLinkModel> ListManagedInstanceLinks(string resourceGroupName, string instanceName)
        {
            try
            {
                var resp = Communicator.List(resourceGroupName, instanceName);
                return resp.Select((dag) => CreateManagedInstanceLinkModelFromResponse(resourceGroupName, instanceName, dag)).ToList();
            }
            catch (ErrorResponseException ex)
            {
                throw CreateExceptionWithDescriptiveErrorMessage(ex);
            }
        }

        /// <summary>
        /// Creates a new managed instance link
        /// </summary>
        /// <param name="model">The input parameters for the create/update operation</param>
        /// <returns>The upserted Azure Sql Managed Instance Link</returns>
        internal AzureSqlManagedInstanceLinkModel CreateManagedInstanceLink(AzureSqlManagedInstanceLinkModel model)
        {
            try
            {
                var resp = Communicator.CreateOrUpdate(model.ResourceGroupName, model.InstanceName, model.Name, new Management.Sql.Models.DistributedAvailabilityGroup
                {
                    Databases = model.Databases,
                    FailoverMode = model.FailoverMode,
                    InstanceAvailabilityGroupName = model.InstanceAvailabilityGroupName,
                    InstanceLinkRole = model.InstanceLinkRole,
                    PartnerAvailabilityGroupName = model.PartnerAvailabilityGroupName,
                    PartnerEndpoint = model.PartnerEndpoint,
                    ReplicationMode = model.ReplicationMode,
                    SeedingMode = model.SeedingMode
                });

                return CreateManagedInstanceLinkModelFromResponse(model.ResourceGroupName, model.InstanceName, resp);
            }
            catch (ErrorResponseException ex)
            {
                throw CreateExceptionWithDescriptiveErrorMessage(ex);
            }
        }

        /// <summary>
        /// Updates managed instance link
        /// </summary>
        /// <param name="model">The input parameters for the update operation</param>
        /// <returns>The updated Azure Sql Managed Instance Link</returns>
        internal AzureSqlManagedInstanceLinkModel UpdateManagedInstanceLink(AzureSqlManagedInstanceLinkModel model)
        {
            try
            {
                var resp = Communicator.Update(model.ResourceGroupName, model.InstanceName, model.Name, new Management.Sql.Models.DistributedAvailabilityGroup
                {
                    ReplicationMode = model.ReplicationMode,
                });

                return CreateManagedInstanceLinkModelFromResponse(model.ResourceGroupName, model.InstanceName, resp);
            }
            catch (ErrorResponseException ex)
            {
                throw CreateExceptionWithDescriptiveErrorMessage(ex);
            }
        }

        /// <summary>
        /// Deletes a managed instance link
        /// </summary>
        /// <param name="resourceGroupName">Resource group used by the managed instance</param>
        /// <param name="instanceName">Name of the managed instance</param>
        /// <param name="managedInstanceLinkName">Name of the instance link to delete</param>
        public void RemoveManagedInstanceLink(string resourceGroupName, string instanceName, string managedInstanceLinkName)
        {
            try
            {
                Communicator.Remove(resourceGroupName, instanceName, managedInstanceLinkName);
            }
            catch (ErrorResponseException ex)
            {
                throw CreateExceptionWithDescriptiveErrorMessage(ex);
            }
        }

        /// <summary>
        /// Failovers managed instance link
        /// </summary>
        /// <param name="model">The input parameters for the update operation</param>
        /// <returns>The updated Azure Sql Managed Instance Link</returns>
        internal AzureSqlManagedInstanceLinkModel FailoverManagedInstanceLink(AzureSqlManagedInstanceLinkModel model)
        {
            try
            {
                var resp = Communicator.Failover(model.ResourceGroupName, model.InstanceName, model.Name, new Management.Sql.Models.DistributedAvailabilityGroupsFailoverRequest
                {
                    FailoverType = model.FailoverMode,
                });

                return CreateManagedInstanceLinkModelFromResponse(model.ResourceGroupName, model.InstanceName, resp);
            }
            catch (ErrorResponseException ex)
            {
                throw CreateExceptionWithDescriptiveErrorMessage(ex);
            }
        }

        /// <summary>
        /// Convert a Management.Sql.Models.DistributedAvailabilityGroup to AzureSqlManagedInstanceLinkModel
        /// </summary>
        /// <param name="resourceGroupName">Resource group used by the managed instance</param>
        /// <param name="instanceName">Name of the managed instance</param>
        /// <param name="managedInstanceLink">The management client distributed availiability group response to convert</param>
        /// <returns>The converted managed instance link model</returns>
        private static AzureSqlManagedInstanceLinkModel CreateManagedInstanceLinkModelFromResponse(string resourceGroupName, string instanceName, Management.Sql.Models.DistributedAvailabilityGroup managedInstanceLink)
        {
            AzureSqlManagedInstanceLinkModel managedInstanceLinkModel = new AzureSqlManagedInstanceLinkModel()
            {
                ResourceGroupName = resourceGroupName,
                InstanceName = instanceName,
                Id = managedInstanceLink.Id,
                Type = managedInstanceLink.Type,
                Name = managedInstanceLink.Name,
                DistributedAvailabilityGroupName = managedInstanceLink.DistributedAvailabilityGroupName,
                DistributedAvailabilityGroupId = managedInstanceLink.DistributedAvailabilityGroupId,
                ReplicationMode = managedInstanceLink.ReplicationMode,
                PartnerLinkRole = managedInstanceLink.PartnerLinkRole,
                PartnerAvailabilityGroupName = managedInstanceLink.PartnerAvailabilityGroupName,
                PartnerEndpoint = managedInstanceLink.PartnerEndpoint,
                InstanceLinkRole = managedInstanceLink.InstanceLinkRole,
                InstanceAvailabilityGroupName = managedInstanceLink.InstanceAvailabilityGroupName,
                FailoverMode = managedInstanceLink.FailoverMode,
                SeedingMode = managedInstanceLink.SeedingMode,
                Databases = managedInstanceLink.Databases,
            };
            return managedInstanceLinkModel;
        }

        /// <summary>
        /// Due to some change in SDK generator, proper messages from REST aren't propagated as a exception message.
        /// For this reason the error message of the PS cmdlet will always be generic that is 'Operation returned an invalid status code '{0}''.
        /// In order to get the correct error message we need to extract it from Body of the original exception.
        /// </summary>
        /// <returns>The new ErrorResponseException that will have non-generic error message.</returns>
        private ErrorResponseException CreateExceptionWithDescriptiveErrorMessage(ErrorResponseException originalException)
        {
            ErrorResponseException responseException = new ErrorResponseException(originalException.Body.Error.Message, originalException.InnerException);
            responseException.Body = originalException.Body;
            responseException.Request = originalException.Request;
            responseException.Response = originalException.Response;

            return responseException;
        }
    }
}
