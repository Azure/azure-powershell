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

using System.Security;

namespace Microsoft.Azure.Commands.Security.Models.Automations
{
    public class PSSecurityAutomationActionEventHub : PSSecurityAutomationAction
    {
        /// <summary>
        /// Gets or sets the target Event Hub Azure Resource ID.
        /// </summary>
        public string EventHubResourceId { get; set; }

        /// <summary>
        /// Gets the target Event Hub SAS policy name.
        /// </summary>
        public string SasPolicyName { get; set; }

        /// <summary>
        /// Gets or sets the target Event Hub connection string (it will not be
        /// included in any response).
        /// </summary>
        public string ConnectionString { get; set; }
    }
}
