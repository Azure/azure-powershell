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

using Microsoft.Azure.Batch;
using Microsoft.Azure.Commands.Batch.Properties;
using System;

namespace Microsoft.Azure.Commands.Batch.Models
{
    public partial class BatchClient
    {
        /// <summary>
        /// Creates a new compute node user.
        /// </summary>
        /// <param name="options">The options to use when creating the compute node user.</param>
        public void CreateComputeNodeUser(NewComputeNodeUserParameters options)
        {
            if (options == null)
            {
                throw new ArgumentNullException("options");
            }

            ComputeNodeUser user = null;
            string computeNodeId = null;
            if (options.ComputeNode != null)
            {
                user = options.ComputeNode.omObject.CreateComputeNodeUser();
                computeNodeId = options.ComputeNode.Id;
            }
            else
            {
                PoolOperations poolOperations = options.Context.BatchOMClient.PoolOperations;
                user = poolOperations.CreateComputeNodeUser(options.PoolId, options.ComputeNodeId);
                computeNodeId = options.ComputeNodeId;
            }

            user.Name = options.ComputeNodeUserName;
            user.Password = options.Password;
            user.ExpiryTime = options.ExpiryTime;
            user.IsAdmin = options.IsAdmin;

            WriteVerbose(string.Format(Resources.CreatingComputeNodeUser, user.Name, computeNodeId));

            user.Commit(ComputeNodeUserCommitSemantics.AddUser, options.AdditionalBehaviors);
        }

        /// <summary>
        /// Updates a compute node user account
        /// </summary>
        /// <param name="parameters">The parameters specifying the compute node user to update and the changes to make</param>
        public void UpdateComputeNodeUser(UpdateComputeNodeUserParameters parameters)
        {
            if (parameters == null)
            {
                throw new ArgumentNullException("parameters");
            }

            WriteVerbose(string.Format(Resources.UpdatingComputeNodeUser, parameters.ComputeNodeUserName));

            ComputeNodeUser computeNodeUser = parameters.Context.BatchOMClient.PoolOperations.CreateComputeNodeUser(parameters.PoolId, parameters.ComputeNodeId);
            computeNodeUser.Name = parameters.ComputeNodeUserName;
            computeNodeUser.Password = parameters.Password;
            computeNodeUser.ExpiryTime = parameters.ExpiryTime;
            computeNodeUser.Commit(ComputeNodeUserCommitSemantics.UpdateUser, parameters.AdditionalBehaviors);
        }

        /// <summary>
        /// Deletes the specified compute node user.
        /// </summary>
        /// <param name="parameters">The parameters indicating which compute node user to delete.</param>
        public void DeleteComputeNodeUser(ComputeNodeUserOperationParameters parameters)
        {
            if (parameters == null)
            {
                throw new ArgumentNullException("parameters");
            }

            PoolOperations poolOperations = parameters.Context.BatchOMClient.PoolOperations;
            poolOperations.DeleteComputeNodeUser(parameters.PoolId, parameters.ComputeNodeId, parameters.ComputeNodeUserName, parameters.AdditionalBehaviors);
        }
    }
}
