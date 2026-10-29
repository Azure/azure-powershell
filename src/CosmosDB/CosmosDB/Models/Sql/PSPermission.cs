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
using Microsoft.Azure.Management.CosmosDB.Models;

namespace Microsoft.Azure.Commands.CosmosDB.Models
{
    public class PSPermission
    {
        public PSPermission()
        {
        }

        public PSPermission(List<string> dataActions)
        {
            DataActions = dataActions;
        }

        /// <summary>
        /// Gets or sets DataActions
        /// </summary>
        public IList<string> DataActions { get; set; }

        public string Id { get; set; }

        public IList<string> NotDataActions { get; set; }

        public static PSPermission FromSDKModel(Permission permission)
        {
            if (permission == null)
            {
                return null;
            }

            return new PSPermission
            {
                Id = permission.Id,
                DataActions = permission.DataActions == null ? null : new List<string>(permission.DataActions),
                NotDataActions = permission.NotDataActions == null ? null : new List<string>(permission.NotDataActions)
            };
        }

        public static Permission ToSDKModel(PSPermission permission)
        {
            if (permission == null)
            {
                return null;
            }

            return new Permission
            {
                Id = permission.Id,
                DataActions = permission.DataActions == null ? null : new List<string>(permission.DataActions),
                NotDataActions = permission.NotDataActions == null ? null : new List<string>(permission.NotDataActions)
            };
        }
    }
}