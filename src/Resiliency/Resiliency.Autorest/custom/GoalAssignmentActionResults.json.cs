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
    /// For goal-assignment actions (Update-AzResiliencyGoalResource, Get-AzResiliencyGoalAssignmentCapacity)
    /// the service returns the final result as an operation-status record
    /// {"status": "Succeeded", "properties": "&lt;JSON-encoded string&gt;"} instead of the spec shape, so the
    /// output is empty. When properties is a string, decode it and read the result from the decoded
    /// object. No-op once the service returns the spec shape; remove after the service fix.
    /// </summary>
    internal static class StringEncodedProperties
    {
        internal static JsonObject Decode(JsonObject json)
        {
            JsonString encoded = json?.PropertyT<JsonString>("properties");
            if (encoded == null)
            {
                return null;
            }
            try
            {
                return JsonNode.Parse((string)encoded) as JsonObject;
            }
            catch (System.Exception)
            {
                return null;
            }
        }
    }

    public partial class UpdateGoalResourceResponse
    {
        partial void BeforeFromJson(JsonObject json, ref bool returnNow)
        {
            JsonObject inner = json?.ContainsKey("resources") == true ? null : StringEncodedProperties.Decode(json);
            if (inner == null)
            {
                return;
            }
            var decoded = new UpdateGoalResourceResponse(inner);
            this._resource = decoded._resource;
            returnNow = true;
        }
    }

    public partial class RecommendCapacityResult
    {
        partial void BeforeFromJson(JsonObject json, ref bool returnNow)
        {
            bool specShape = json != null
                && (json.ContainsKey("recommendations") || json.ContainsKey("resourceCapacities") || json.ContainsKey("agentError"));
            JsonObject inner = specShape ? null : StringEncodedProperties.Decode(json);
            if (inner == null)
            {
                return;
            }
            var decoded = new RecommendCapacityResult(inner);
            this._resourceCapacity = decoded._resourceCapacity;
            this._recommendation = decoded._recommendation;
            this._agentError = decoded._agentError;
            returnNow = true;
        }
    }
}
