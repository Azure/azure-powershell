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
    using Microsoft.Azure.PowerShell.Cmdlets.Resiliency.Runtime;
    using Microsoft.Azure.PowerShell.Cmdlets.Resiliency.Runtime.Json;

    /// <summary>
    /// The service accepts faultProperties.defaultFault on add-or-update resources
    /// (Update-AzResiliencyDrillResource), but the spec marks defaultFault read-only, so it is never
    /// written to request bodies. IncludeOrUpdateResource is used only in that request (never in a
    /// response), so a default fault on it was always set by the user (DefaultFaultName, DefaultFaultUrn,
    /// DefaultFaultTargetResourceId keys). Write it into faultProperties when set; requests without it
    /// are unchanged. Remove after the spec makes defaultFault writable.
    /// </summary>
    public partial class IncludeOrUpdateResource
    {
        partial void AfterToJson(ref JsonObject container)
        {
            var defaultFault = (this._faultProperty as FaultProperties)?.DefaultFaultForRequest();
            if (container == null || defaultFault == null)
            {
                return;
            }
            var faultProperties = container.PropertyT<JsonObject>("faultProperties");
            if (faultProperties == null)
            {
                faultProperties = new JsonObject();
                container.Add("faultProperties", (JsonNode)faultProperties);
            }
            if (!faultProperties.ContainsKey("defaultFault"))
            {
                faultProperties.Add("defaultFault", defaultFault);
            }
        }
    }

    public partial class FaultProperties
    {
        /// <summary>
        /// Returns the default fault as request JSON, or null when none of its fields is set. Reads the
        /// backing field directly so that it never creates an empty default fault as a side effect.
        /// </summary>
        internal JsonNode DefaultFaultForRequest()
        {
            var fault = this._defaultFault;
            if (fault == null
                || (string.IsNullOrEmpty(fault.FaultName) && string.IsNullOrEmpty(fault.FaultUrn) && string.IsNullOrEmpty(fault.TargetResourceId)))
            {
                return null;
            }
            return fault.ToJson(null, SerializationMode.None);
        }
    }
}
