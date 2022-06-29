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

namespace Microsoft.Azure.Commands.Security.Models.Automations
{
    public class PSSecurityAutomationScope
    {
        /// <summary>
        /// Gets or sets the resources scope description.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the resources scope path. Can be the subscription on
        /// which the automation is defined on or a resource group under that
        /// subscription (fully qualified Azure resource IDs).
        /// </summary>
        public string ScopePath { get; set; }
    }
}
