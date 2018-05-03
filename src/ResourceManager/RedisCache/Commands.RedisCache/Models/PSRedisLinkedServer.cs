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

namespace Microsoft.Azure.Commands.RedisCache.Models
{
    using System;
    using Management.Redis.Models;

    public class PSRedisLinkedServer
    {
        public string PrimaryServerName { get; set; }
        public string SecondaryServerName { get; set; }
        public string ProvisioningState { get; set; }

        public PSRedisLinkedServer() { }

        internal PSRedisLinkedServer(RedisLinkedServerWithProperties redisLinkedServer)
        {
            ProvisioningState = redisLinkedServer.ProvisioningState;
            if (redisLinkedServer.ServerRole == ReplicationRole.Primary)
            {
                /* ID is of the form: 
                   "/subscriptions/<subscription id>/resourceGroups/<resource group name>/providers/Microsoft.Cache/Redis/
                   <primary cache name>/linkedServers/<secondary cache name>"
                */
                string[] ele = redisLinkedServer.Id.Split('/');
                PrimaryServerName = ele[10];
                SecondaryServerName = ele[8];
            }
            else
            {
                /* ID is of the form: 
                   "/subscriptions/<subscription id>/resourceGroups/<resource group name>/providers/Microsoft.Cache/Redis/
                   <secondary cache name>/linkedServers/<primary cache name>"
                */
                string[] ele = redisLinkedServer.Id.Split('/');
                PrimaryServerName = ele[8];
                SecondaryServerName = ele[10];
            }
        }
    }
}