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
using System.Collections.Generic;
using System.Management.Automation;
using System.Security.Permissions;
using Microsoft.Azure.Commands.Automation.Model;
using Microsoft.Azure.Commands.Automation.Common;
using System.Collections;

namespace Microsoft.Azure.Commands.Automation.Cmdlet
{
    /// <summary>
    /// Create a new Module for automation.
    /// </summary>
    [Cmdlet(VerbsCommon.New, "AzureAutomationModule")]
    [OutputType(typeof(Module))]
    public class NewAzureAutomationModule : AzureAutomationBaseCmdlet
    {
        /// <summary>
        /// Gets or sets the module name.
        /// </summary>
        [Parameter(Position = 1, Mandatory = true, ValueFromPipelineByPropertyName = true,
            HelpMessage = "The module name.")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the contentLink
        /// </summary>
        [Parameter(Position = 2, Mandatory = true, ValueFromPipelineByPropertyName = true,
            HelpMessage = "The ContentLink.")]
        [ValidateNotNullOrEmpty]
        public Uri ContentLink { get; set; }

        /// <summary>
        /// Gets or sets the module tags.
        /// </summary>
        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "The module tags.")]
        [Alias("Tag")] 
        public IDictionary Tags { get; set; }

        /// <summary>
        /// Execute this cmdlet.
        /// </summary>
        [PermissionSet(SecurityAction.Demand, Name = "FullTrust")]
        protected override void AutomationExecuteCmdlet()
        {
            var createdModule = this.AutomationClient.CreateModule(this.AutomationAccountName, ContentLink, Name, Tags);

            this.WriteObject(createdModule);
        }
    }
}
