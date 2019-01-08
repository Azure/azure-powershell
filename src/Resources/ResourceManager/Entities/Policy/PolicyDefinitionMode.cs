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
    /// The policy definition mode.
    /// </summary>
    public class PolicyDefinitionMode
    {
        /// <summary>
        /// The indexed policy definition mode. Limits evaluation to resource types that support tags and location.
        /// </summary>
        public const string Indexed = "Indexed";

        /// <summary>
        /// The all policy definition mode. Evaluates all resource types.
        /// </summary>
        public const string All = "All";
    }
}
