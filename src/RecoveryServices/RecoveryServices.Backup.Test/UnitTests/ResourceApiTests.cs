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

using Microsoft.Azure.Commands.RecoveryServices.Backup.Cmdlets.ServiceClientAdapterNS;
using Xunit;

namespace Microsoft.Azure.Commands.RecoveryServices.Backup.Test.UnitTests
{
    public class ResourceApiTests
    {
        [Fact]
        public void DeserializeVmResourceIgnoresCombinedManagedIdentity()
        {
            const string responseContent = @"{
                ""id"": ""/subscriptions/subscriptionId/resourceGroups/resourceGroup/providers/Microsoft.Compute/virtualMachines/vmName"",
                ""name"": ""vmName"",
                ""type"": ""Microsoft.Compute/virtualMachines"",
                ""location"": ""australiaeast"",
                ""identity"": {
                    ""type"": ""SystemAssigned, UserAssigned""
                }
            }";

            var resource = ServiceClientAdapter.DeserializeVmResource(responseContent);

            Assert.Equal("vmName", resource.Name);
            Assert.Equal("Microsoft.Compute/virtualMachines", resource.Type);
            Assert.Equal("australiaeast", resource.Location);
        }
    }
}
