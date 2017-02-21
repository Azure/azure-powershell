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

namespace Microsoft.Azure.Commands.ResourceManager.Cmdlets.Extensions
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net.Http;
    using System.Threading;
    using System.Threading.Tasks;
    using Microsoft.Azure.Management.ResourceManager;
    using Microsoft.Azure.Management.ResourceManager.Models;

    /// <summary>
    /// SDK client extension methods
    /// </summary>
    public static class SdkClientExtensions
    {
        /// <summary>
        /// Get a deployment with HTTP response (so headers are accessible).
        /// </summary>
        /// <param name="operations">The operations group for this extension method.</param>
        /// <param name="resourceGroupName">The name of the resource group to get. The name is case insensitive.</param>
        /// <param name="deploymentName">The name of the deployment.</param>
        /// <returns>A tuple of the deployment and the HTTP response.</returns>
        public static Tuple<DeploymentExtended, HttpResponseMessage> GetDeploymentWithResponseMessage(this IDeploymentsOperations operations, string resourceGroupName, string deploymentName)
        {
            return Task.Factory.StartNew(s => ((IDeploymentsOperations)s).GetDeploymentWithResponseMessageAsync(resourceGroupName, deploymentName), operations, CancellationToken.None, TaskCreationOptions.None, TaskScheduler.Default).Unwrap().GetAwaiter().GetResult();
        }

        /// <summary>
        /// Get a deployment with HTTP response (so headers are accessible).
        /// </summary>
        /// <param name="operations">The operations group for this extension method.</param>
        /// <param name="resourceGroupName">The name of the resource group to get. The name is case insensitive.</param>
        /// <param name="deploymentName">The name of the deployment.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>A tuple of the deployment and the HTTP response.</returns>
        public static async Task<Tuple<DeploymentExtended, HttpResponseMessage>> GetDeploymentWithResponseMessageAsync(this IDeploymentsOperations operations, string resourceGroupName, string deploymentName, CancellationToken cancellationToken = default(CancellationToken))
        {
            using (var _result = await operations.GetWithHttpMessagesAsync(resourceGroupName, deploymentName, null, cancellationToken).ConfigureAwait(false))
            {
                return Tuple.Create(_result.Body, _result.Response);
            }
        }
    }
}