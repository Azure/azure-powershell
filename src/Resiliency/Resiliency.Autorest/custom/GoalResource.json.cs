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
    /// The service identifies each item of updateGoalResources (Update-AzResiliencyGoalResource) by the
    /// goal resource's own ARM ID (resources[].id), but the spec reuses GoalResource where id is read-only,
    /// so it is never written to request bodies. Without it the service rejects the item after returning
    /// 202 and the operation stays Accepted, holding a lock on the goal assignment. Write id when it is set
    /// (from Get-AzResiliencyGoalResource output or an Id key). Remove after the spec makes it writable.
    /// </summary>
    public partial class GoalResource
    {
        partial void AfterToJson(ref JsonObject container)
        {
            if (container == null || container.ContainsKey("id") || string.IsNullOrEmpty(this.Id))
            {
                return;
            }
            container.Add("id", (JsonNode)new JsonString(this.Id));
        }
    }
}
