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

using Microsoft.Azure.Commands.Sql.ManagedInstanceOperation.Model;
using Microsoft.Azure.Commands.Sql.ManagedInstanceOperation.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security;
using System.Security.Permissions;
using Microsoft.Azure.Commands.ResourceManager.Common.Tags;
using Microsoft.Azure.Commands.Common.Authentication.Abstractions;
using Microsoft.Azure.Commands.Sql.Common;
using Microsoft.WindowsAzure.Commands.Common;
using Microsoft.Azure.Management.Internal.Resources.Utilities.Models;

namespace Microsoft.Azure.Commands.Sql.ManagedInstanceOperation.Adapter
{
    /// <summary>
    /// Adapter for Managed instance operations
    /// </summary>
    public class AzureSqlManagedInstanceOperationAdapter
    {
        /// <summary>
        /// Gets or sets the AzureEndpointsCommunicator which has all the needed management clients
        /// </summary>
        private AzureSqlManagedInstanceOperationCommunicator Communicator { get; set; }

        /// <summary>
        /// Gets or sets the Azure profile
        /// </summary>
        public IAzureContext Context { get; set; }

        /// <summary>
        /// Constructs a Managed instance adapter
        /// </summary>
        /// <param name="context">The current azure profile</param>
        public AzureSqlManagedInstanceOperationAdapter(IAzureContext context)
        {
            Context = context;
            Communicator = new AzureSqlManagedInstanceOperationCommunicator(Context);
        }

        /// <summary>
        /// Gets a managed instance in a resource group
        /// </summary>
        /// <param name="resourceGroupName">The name of the resource group</param>
        /// <param name="managedInstanceName">The name of the managed instance</param>
        /// <param name="operationName">The id of the operation.</param>
        /// <returns>The managed instance operation</returns>
        public AzureSqlManagedInstanceOperationModel GetManagedInstanceOperation(string resourceGroupName, string managedInstanceName, Guid operationName)
        {
            var resp = Communicator.Get(resourceGroupName, managedInstanceName, operationName);
            return CreateManagedInstanceOperationModelFromResponse(resp);
        }

        /// <summary>
        /// Gets a list of all the operations on managed instances
        /// </summary>
        /// <param name="resourceGroupName">The name of the resource group</param>
        /// <param name="managedInstanceName">The name of the managed instance</param>
        /// <returns>A list of all the managed instances</returns>
        public List<AzureSqlManagedInstanceOperationModel> ListOperationsByManagedInstance(string resourceGroupName, string managedInstanceName)
        {
            var resp = Communicator.ListByManagedInstance(resourceGroupName, managedInstanceName);
            return resp.Select((s) =>
            {
                return CreateManagedInstanceOperationModelFromResponse(s);
            }).ToList();
        }

        /// <summary>
        /// Cancels a managed instance operation
        /// </summary>
        /// <param name="resourceGroupName">The resource group the managed instance is in</param>
        /// <param name="managedInstanceName">The name of the managed instance</param>
        /// <param name="operationName">The id of the operation to cancel.</param>
        public void CancelManagedInstanceOperation(string resourceGroupName, string managedInstanceName, Guid operationName)
        {
            Communicator.Cancel(resourceGroupName, managedInstanceName, operationName);
        }

        /// <summary>
        /// Convert a Management.Sql.LegacySdk.Models.ManagedInstance to AzureSqlDatabaseManagedInstanceModel
        /// </summary>
        /// <param name="resp">The management client managed instance response to convert</param>
        /// <returns>The converted managed instance model</returns>
        private static AzureSqlManagedInstanceOperationModel CreateManagedInstanceOperationModelFromResponse(Management.Sql.Models.ManagedInstanceOperation resp)
        {
            AzureSqlManagedInstanceOperationModel managedInstanceOperation = new AzureSqlManagedInstanceOperationModel();

            // Extract the resource group name from the ID.
            // ID is in the form:
            // /subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/rgName/providers/Microsoft.Sql/managedInstances/managedInstanceName
            string[] segments = resp.Id.Split('/');
            managedInstanceOperation.ResourceGroupName = segments[4];

            managedInstanceOperation.ManagedInstanceName = resp.ManagedInstanceName;
            managedInstanceOperation.Id = resp.Id;
            managedInstanceOperation.Name = resp.Name;
            managedInstanceOperation.Description = resp.Description;
            managedInstanceOperation.ErrorCode = resp.ErrorCode;
            managedInstanceOperation.ErrorDescription = resp.ErrorDescription;
            managedInstanceOperation.ErrorSeverity = resp.ErrorSeverity;
            managedInstanceOperation.EstimatedCompletionTime = resp.EstimatedCompletionTime;
            managedInstanceOperation.IsCancellable = resp.IsCancellable;
            managedInstanceOperation.Operation = resp.Operation;
            managedInstanceOperation.OperationFriendlyName = resp.OperationFriendlyName;
            managedInstanceOperation.PercentComplete = resp.PercentComplete;
            managedInstanceOperation.StartTime = resp.StartTime;
            managedInstanceOperation.State = resp.State;
            managedInstanceOperation.IsUserError = resp.IsUserError;

            if (resp.OperationParameters != null)
            {
                Management.Sql.Models.UpsertManagedServerOperationParameters currentParameters = new Management.Sql.Models.UpsertManagedServerOperationParameters();
                if (resp.OperationParameters.CurrentParameters != null)
                {
                    currentParameters.Family = resp.OperationParameters.CurrentParameters.Family;
                    currentParameters.Tier = resp.OperationParameters.CurrentParameters.Tier;
                    currentParameters.VCores = resp.OperationParameters.CurrentParameters.VCores;
                    currentParameters.StorageSizeInGB = resp.OperationParameters.CurrentParameters.StorageSizeInGB;
                }

                Management.Sql.Models.UpsertManagedServerOperationParameters requestedParameters = new Management.Sql.Models.UpsertManagedServerOperationParameters();
                if (resp.OperationParameters.RequestedParameters != null)
                {
                    requestedParameters.Family = resp.OperationParameters.RequestedParameters.Family;
                    requestedParameters.Tier = resp.OperationParameters.RequestedParameters.Tier;
                    requestedParameters.VCores = resp.OperationParameters.RequestedParameters.VCores;
                    requestedParameters.StorageSizeInGB = resp.OperationParameters.RequestedParameters.StorageSizeInGB;
                }

                managedInstanceOperation.OperationParameters = new Management.Sql.Models.ManagedInstanceOperationParametersPair(currentParameters, requestedParameters);
            }
            else
            {
                managedInstanceOperation.OperationParameters = new Management.Sql.Models.ManagedInstanceOperationParametersPair();
            }

            IList<Management.Sql.Models.UpsertManagedServerOperationStep> stepsList = new List<Management.Sql.Models.UpsertManagedServerOperationStep>();
            if (resp.OperationSteps != null && resp.OperationSteps.StepsList != null)
            {
                foreach (Management.Sql.Models.UpsertManagedServerOperationStep step in resp.OperationSteps.StepsList)
                {
                    stepsList.Add(new Management.Sql.Models.UpsertManagedServerOperationStep(step.Order, step.Name, step.Status));
                }

                managedInstanceOperation.OperationSteps = new Management.Sql.Models.ManagedInstanceOperationSteps(resp.OperationSteps.TotalSteps, resp.OperationSteps.CurrentStep, stepsList);
            }
            else
            {
                managedInstanceOperation.OperationSteps = new Management.Sql.Models.ManagedInstanceOperationSteps();
            }

            return managedInstanceOperation;
        }
    }
}
