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

using System.Linq;
using Microsoft.Azure.Batch;
using Microsoft.Azure.Commands.Batch.Models;
using Microsoft.Azure.Commands.Batch.Properties;
using System;
using System.Collections.Generic;

namespace Microsoft.Azure.Commands.Batch.Models
{
    public partial class BatchClient
    {
        /// <summary>
        /// Creates a new user
        /// </summary>
        /// <param name="options">The options to use when creating the user</param>
        public void CreateVMUser(NewVMUserParameters options)
        {
            if (options == null)
            {
                throw new ArgumentNullException("options");
            }

            IUser user = null;
            string vmName = null;
            if (options.VM != null)
            {
                user = options.VM.omObject.CreateUser();
                vmName = options.VM.Name;
            }
            else
            {
                using (IPoolManager poolManager = options.Context.BatchOMClient.OpenPoolManager())
                {
                    user = poolManager.CreateUser(options.PoolName, options.VMName);
                }
                vmName = options.VMName;
            }

            user.Name = options.VMUserName;
            user.Password = options.Password;
            user.ExpiryTime = options.ExpiryTime;
            user.IsAdmin = options.IsAdmin;

            WriteVerbose(string.Format(Resources.NBU_CreatingUser, user.Name, vmName));

            user.Commit(UserCommitSemantics.AddUser, options.AdditionalBehaviors);
        }

        /// <summary>
        /// Deletes the specified user
        /// </summary>
        /// <param name="parameters">The parameters indicating which user to delete</param>
        public void DeleteVMUser(VMUserOperationParameters parameters)
        {
            if (parameters == null)
            {
                throw new ArgumentNullException("parameters");
            }

            using (IPoolManager poolManager = parameters.Context.BatchOMClient.OpenPoolManager())
            {
                poolManager.DeleteUser(parameters.PoolName, parameters.VMName, parameters.VMUserName, parameters.AdditionalBehaviors);
            }
        }
    }
}
