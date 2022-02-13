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

namespace Microsoft.Azure.Commands.ResourceManager.Cmdlets.Entities.Policy
{
    using Newtonsoft.Json;

    /// <summary>
    /// The policy assignment non compliance message used to describe why a resource is non-compliant with a policy.
    /// </summary>
    public class NonComplianceMessage
    {
        /// <summary>
        /// The message that describes why a resource is non-compliant with the policy. This is shown in 'deny' error messages and 
        /// on resource's non-compliant compliance results.
        /// </summary>
        [JsonProperty(Required = Required.Default)]
        public string Message { get; set; }

        /// <summary>
        /// The policy definition reference ID within a policy set definition that the message is intended for. This is only applicable if
        /// the policy assignment assigns a policy set definition. If this is not provided the message applies to all policies assigned by this
        /// policy assignment.
        /// </summary>
        [JsonProperty(Required = Required.Default)]
        public string PolicyDefinitionReferenceId { get; set; }
    }
}