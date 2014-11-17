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

using System;
using System.Collections;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.Automation.Cmdlet
{
    public abstract class StartAzureAutomationRunbookBase : AzureAutomationBaseCmdlet
    {
        /// <summary>
        /// The start runbook by runbook id parameter set.
        /// </summary>
        protected const string ByRunbookId = "ByRunbookId";

        /// <summary>
        /// The start runbook by runbook name parameter set.
        /// </summary>
        protected const string ByRunbookName = "ByRunbookName";

        /// <summary>
        /// Gets or sets the runbook Id
        /// </summary>
        [Parameter(ParameterSetName = ByRunbookId, Mandatory = true, ValueFromPipelineByPropertyName = true,
            HelpMessage = "The runbook id.")]
        [Alias("RunbookId")]
        public Guid? Id { get; set; }

        /// <summary>
        /// Gets or sets the runbook name
        /// </summary>
        [Parameter(ParameterSetName = ByRunbookName, Mandatory = true, ValueFromPipelineByPropertyName = true,
            HelpMessage = "The runbook name.")]
        [ValidateNotNullOrEmpty]
        [Alias("RunbookName")]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the runbook parameters.
        /// </summary>
        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true,
            HelpMessage = "The runbook parameters.")]
        public IDictionary Parameters { get; set; }
    }
}
