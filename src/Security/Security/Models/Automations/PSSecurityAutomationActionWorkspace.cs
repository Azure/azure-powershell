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
    public class PSSecurityAutomationActionLogicApp : PSSecurityAutomationAction
    {
        /// <summary>
        /// Gets or sets the triggered Logic App Azure Resource ID. This can
        /// also reside on other subscriptions, given that you have permissions
        /// to trigger the Logic App
        /// </summary>
        public string LogicAppResourceId { get; set; }

        /// <summary>
        /// Gets or sets the Logic App trigger URI endpoint (it will not be
        /// included in any response).
        /// </summary>
        public string Uri { get; set; }
    }
}
