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
using System.Collections.Generic;
using System.Linq;
using Protocol = Microsoft.Azure.Batch.Protocol;
using BatchRequests = Microsoft.Azure.Batch.Protocol.BatchRequests;

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

            user.Commit(ComputeNodeUserCommitSemantics.AddUser, WithUnsetExpiryTimeOmitted(options.AdditionalBehaviors));
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
            computeNodeUser.Commit(ComputeNodeUserCommitSemantics.UpdateUser, WithUnsetExpiryTimeOmitted(parameters.AdditionalBehaviors));
        }

        /// <summary>
        /// -ExpiryTime is a DateTime, so it is 0001-01-01 when it isn't specified, and Track 1's ComputeNodeUser always
        /// sends its expiry time. This omits expiryTime from the add and update requests when it isn't specified, so the
        /// service default applies.
        /// </summary>
        private static IEnumerable<BatchClientBehavior> WithUnsetExpiryTimeOmitted(IEnumerable<BatchClientBehavior> additionalBehaviors)
        {
            Protocol.RequestInterceptor interceptor = new Protocol.RequestInterceptor(baseRequest =>
            {
                // ExpiryTime is a DateTime? here, so compare with default(DateTime) (0001-01-01), not with default (null).
                switch (baseRequest)
                {
                    case BatchRequests.ComputeNodeAddUserBatchRequest addUser
                        when addUser.Parameters?.ExpiryTime == default(DateTime):
                        addUser.Parameters.ExpiryTime = null;
                        break;

                    case BatchRequests.ComputeNodeUpdateUserBatchRequest updateUser
                        when updateUser.Parameters?.ExpiryTime == default(DateTime):
                        updateUser.Parameters.ExpiryTime = null;
                        break;
                }
            });

            return new List<BatchClientBehavior> { interceptor }.Concat(additionalBehaviors ?? Enumerable.Empty<BatchClientBehavior>());
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
