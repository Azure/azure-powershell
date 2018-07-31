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

using Microsoft.Azure.Management.Storage.Models;
using System;

namespace Microsoft.Azure.Commands.Management.Storage.Models
{
    public class PSManagementPolicy
    {
        public PSManagementPolicy(StorageAccountManagementPolicies policy, string ResourceGroupName, string StorageAccountName)
        {
            this.ResourceGroupName = ResourceGroupName;
            this.StorageAccountName = StorageAccountName;
            this.Id = policy.Id;
            this.Name = policy.Name;
            this.Type = policy.Type;
            this.Policy = policy.Policy.ToString();
            this.LastModifiedTime = policy.LastModifiedTime;
        }
        public string ResourceGroupName { get; set; }
        public string StorageAccountName { get; set; }
        public string Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public string Policy { get; set; }
        public DateTime? LastModifiedTime { get; set; }
    }
}
