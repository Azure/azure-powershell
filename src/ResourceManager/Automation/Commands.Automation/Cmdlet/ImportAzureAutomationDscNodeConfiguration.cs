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
using System.Collections.Generic;
using System.Management.Automation;
using System.Security.Permissions;
using Microsoft.Azure.Commands.Automation.Common;
using Microsoft.Azure.Commands.Automation.Model;
using Microsoft.WindowsAzure.Commands.Utilities.Common;

namespace Microsoft.Azure.Commands.Automation.Cmdlet
{
    /// <summary>
    /// Imports dsc node configuration script
    /// </summary>
    [Cmdlet(VerbsData.Import, "ImportAzureAutomationDscNodeConfiguration")]
    [OutputType(typeof(DscConfiguration))]
    public class ImportAzureAutomationDscNodeConfiguration : AzureAutomationBaseCmdlet
    {       
        /// <summary>
        /// Gets or sets the source path.
        /// </summary>
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "Path to the node configuration script .mof to import.")]
        [Alias("Path")]
        [ValidateNotNullOrEmpty]
        public string SourcePath { get; set; }

        /// <summary>
        /// Gets or sets the node configuration name.
        /// </summary>
        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "The dsc node configuration name for which .mof is imported.")]
        [Alias("Name")]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the configuration name for the node configuration.
        /// </summary>
        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "The dsc configuration name for .mof imported")]
        [Alias("ConfigurationName")]
        public string ConfigurationName { get; set; }
        
        /// <summary>
        /// Execute this cmdlet.
        /// </summary>
        [PermissionSet(SecurityAction.Demand, Name = "FullTrust")]
        public override void ExecuteCmdlet()
        {
            var nodeConfiguration = this.AutomationClient.CreateNodeConfiguration(
                    this.ResourceGroupName,
                    this.AutomationAccountName,
                    this.SourcePath,
                    this.Name,
                    this.ConfigurationName);

            this.WriteObject(nodeConfiguration);
        }
    }
}
