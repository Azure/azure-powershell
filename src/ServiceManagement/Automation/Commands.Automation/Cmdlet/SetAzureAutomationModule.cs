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
using System.Linq;

namespace Microsoft.Azure.Commands.Automation.Cmdlet
{
    /// <summary>
    /// Sets a Module for automation.
    /// </summary>
    [Cmdlet(VerbsCommon.Set, "AzureAutomationModule", DefaultParameterSetName = AutomationCmdletParameterSets.ByName)]
    [OutputType(typeof(Module))]
     public class SetAzureAutomationModule : AzureAutomationBaseCmdlet
    {
        /// <summary>
        /// Gets or sets the module name.
        /// </summary>
        [Parameter(ParameterSetName = AutomationCmdletParameterSets.ByName, Mandatory = true, Position = 1, ValueFromPipelineByPropertyName = true,
            HelpMessage = "The module name.")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the module tags.
        /// </summary>
        [Parameter(ParameterSetName = AutomationCmdletParameterSets.ByName, Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "The module tags.")]
        [ValidateNotNullOrEmpty]
        [Alias("Tag")] 
        public IDictionary Tags { get; set; }

        /// <summary>
        /// Gets or sets the contentLink
        /// </summary>
        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true,
            HelpMessage = "The ContentLinkUri.")]
        public Uri ContentLinkUri { get; set; }

        /// <summary>
        /// Gets or sets the contentLinkVersion
        /// </summary>
        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true,
            HelpMessage = "The ContentLink version.")]
        public string ContentLinkVersion { get; set; }

        /// <summary>
        /// Execute this cmdlet.
        /// </summary>
        [PermissionSet(SecurityAction.Demand, Name = "FullTrust")]
        protected override void AutomationExecuteCmdlet()
        {
            var updatedModule = this.AutomationClient.UpdateModule(this.AutomationAccountName, Tags, Name, ContentLinkUri, ContentLinkVersion);
            
            this.WriteObject(updatedModule);
        }
    }
}
