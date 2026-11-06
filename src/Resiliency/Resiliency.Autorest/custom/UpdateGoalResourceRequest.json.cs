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

namespace Microsoft.Azure.PowerShell.Cmdlets.Resiliency.Models
{
    using Microsoft.Azure.PowerShell.Cmdlets.Resiliency.Runtime.Json;

    /// <summary>
    /// The service needs the goal resource ID (resources[].id) for every item of updateGoalResources
    /// (see GoalResource.json.cs). An item without it is rejected after the service has returned 202,
    /// and the operation then stays Accepted, holding a lock on the goal assignment. Fail before the
    /// request is sent instead. Remove after the spec makes id writable and the service validates
    /// before accepting the request.
    /// </summary>
    public partial class UpdateGoalResourceRequest
    {
        partial void AfterToJson(ref JsonObject container)
        {
            if (container == null || !container.ContainsKey("resources") || !(container["resources"] is JsonArray resources))
            {
                return;
            }
            for (int i = 0; i < resources.Count; i++)
            {
                if (resources[i] is JsonObject item && !item.ContainsKey("id"))
                {
                    throw new global::System.ArgumentException(
                        $"Resource[{i}] has no Id. Each goal resource needs its Id, as returned by Get-AzResiliencyGoalResource.");
                }
            }
        }
    }
}
