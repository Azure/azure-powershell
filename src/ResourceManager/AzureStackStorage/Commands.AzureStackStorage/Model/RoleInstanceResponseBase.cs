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

using Microsoft.AzureStack.Management.StorageAdmin.Models;
using System.Collections.Generic;

namespace Microsoft.AzureStack.Commands.StorageAdmin
{
    internal class RoleInstanceResponseBase : ResponseBase
    {
        public RoleInstanceResponseBase(ResourceBase resource) : base(resource)
        {
        }

        public string InstanceId
        {
            get
            {
                return RoleIdentifier;
            }
        }

        protected string RoleIdentifier { get; set; }
        public string Version { get; set; }
        public RoleInstanceStatus Status { get; set; }
        public HealthStatus HealthStatus { get; set; }
        public string NodeUri { get; set; }
        public IEnumerable<RoleInstanceHistoricEntry> HistoryInfos { get; set; }

        public RoleType RoleType { get; set; }
    }
}
