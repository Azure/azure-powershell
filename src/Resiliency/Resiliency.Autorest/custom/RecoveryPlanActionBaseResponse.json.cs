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
    /// For recovery-plan actions (CheckReadiness, Failover, FailoverCommit, Reprotect, TestFailover,
    /// TestFailoverCleanup) the service returns the final result as an operation-status record
    /// {"status": "Succeeded", "properties": "&lt;JSON-encoded string&gt;"} instead of the spec shape
    /// {"jobId": "..."}, so JobId is null. Decode the string when jobId is absent. No-op once the
    /// service returns the spec shape; remove after the service fix.
    /// </summary>
    public partial class RecoveryPlanActionBaseResponse
    {
        partial void AfterFromJson(JsonObject json)
        {
            if (this._jobId != null)
            {
                return;
            }
            JsonString encoded = json?.PropertyT<JsonString>("properties");
            if (encoded == null)
            {
                return;
            }
            JsonObject inner;
            try
            {
                inner = JsonNode.Parse((string)encoded) as JsonObject;
            }
            catch (System.Exception)
            {
                return;
            }
            JsonString jobId = inner?.PropertyT<JsonString>("jobId");
            if (jobId != null)
            {
                this._jobId = (string)jobId;
            }
        }
    }
}
