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

using System.Collections;
using System.Collections.Generic;

namespace Microsoft.Azure.Commands.Security.Models.Automations
{
    public class PSSecurityAutomation
    {
        /// <summary>
        /// Gets or sets the Azure identifier
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Gets or sets the name of the resource
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the Azure resource type.
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// Gets or sets the Azure location.
        /// </summary>
        public string Location { get; set; }

        /// <summary>
        /// Gets or sets the etag.
        /// </summary>
        public string ETag { get; set; }

        /// <summary>
        /// Gets or sets the resource tags
        /// </summary>
        public Hashtable Tags { get; set; }

        /// <summary>
        /// Gets or sets the security automation description.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets indicates whether the security automation is enabled.
        /// </summary>
        public bool? IsEnabled { get; set; }

        /// <summary>
        /// Gets or sets a collection of scopes on which the security
        /// automations logic is applied. Supported scopes are the subscription
        /// itself or a resource group under that subscription. The automation
        /// will only apply on defined scopes.
        /// </summary>
        public IList<PSSecurityAutomationScope> Scopes { get; set; }

        /// <summary>
        /// Gets or sets a collection of the source event types which evaluate
        /// the security automation set of rules.
        /// </summary>
        public IList<PSSecurityAutomationSource> Sources { get; set; }

        /// <summary>
        /// Gets or sets a collection of the actions which are triggered if all
        /// the configured rules evaluations, within at least one rule set, are
        /// true.
        /// </summary>
        public IList<PSSecurityAutomationAction> Actions { get; set; }

    }
}
