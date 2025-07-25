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
    /// <summary>
    /// The policy exemption category. Possible values are Waiver and Mitigated.
    /// </summary>
    public static class PolicyExemptionCategory
    {
        /// <summary>
        /// This category of exemptions usually means the scope is not applicable for the policy.
        /// </summary>
        public const string Waiver = "Waiver";

        /// <summary>
        /// This category of exemptions usually means the mitigation actions have been applied to the scope.
        /// </summary>
        public const string Mitigated = "Mitigated";
    }
}