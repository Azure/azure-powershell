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

namespace Microsoft.Azure.Commands.ResourceManager.Cmdlets.Implementation.Policy
{
    /// <summary>
    /// The policy assignment enforcement mode.
    /// </summary>
    public enum PsPolicyAssignmentEnforcementMode
    {
        /// <summary>
        /// The policy effect is enforced during resource creation or update.
        /// </summary>
        Default,

        /// <summary>
        /// The policy effect is not enforced during resource creation or update.
        /// </summary>
        DoNotEnforce
    }
}
