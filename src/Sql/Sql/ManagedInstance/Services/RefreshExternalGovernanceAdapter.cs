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
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Azure.Commands.Sql.ManagedInstance.Model;
using Microsoft.Azure.Management.Sql.Models;

namespace Microsoft.Azure.Commands.Sql.ManagedInstance.Services
{
    /// <summary>
    /// Adapter for refreshing external governance status.
    /// </summary>
    public class RefreshExternalGovernanceAdapter
    {

        /// <summary>
        /// Communicator for refreshing external governance status.
        /// </summary>
        private RefreshExternalGovernanceCommunicator Communicator { get; set; }

        /// <summary>
        /// Gets or sets the Azure profile
        /// </summary>
        public IAzureContext Context { get; set; }


        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="context">The current azure context.</param>
        public RefreshExternalGovernanceAdapter(IAzureContext context)
        {
            Context = context;
            Communicator = new RefreshExternalGovernanceCommunicator(Context);
        }

        /// <summary>
        /// Refresh external governance status.
        /// </summary>
        /// <param name="resourceGroupName">Resource group.</param>
        /// <param name="serverName"></param>
        /// <returns></returns>
        public RefreshExternalGovernanceMIModel RefreshExternalGovernanceStatus(string resourceGroupName, string serverName)
        {
            var response = Communicator.Refresh(resourceGroupName, serverName);
            return CreateRefreshExternalGovernanceStatusResponse(response, resourceGroupName);
        }

        /// <summary>
        /// Create RefreshExternalGovernanceStatus response.
        /// </summary>
        /// <param name="response"></param>
        /// <param name="resourceGroupName"></param>
        /// <returns></returns>
        private static RefreshExternalGovernanceMIModel CreateRefreshExternalGovernanceStatusResponse(RefreshExternalGovernanceStatusOperationResultMI response, string resourceGroupName)
        {
            return new RefreshExternalGovernanceMIModel
            {
                ResourceGroupName = resourceGroupName,
                InstanceName = response.ManagedInstanceName,
                RequestId = response.RequestId.Value.ToString(),
                QueuedTime = response.QueuedTime.ToString(),
                Status = response.Status.ToString(),
                ErrorMessage = response.ErrorMessage,
            };
        }
    }
}
