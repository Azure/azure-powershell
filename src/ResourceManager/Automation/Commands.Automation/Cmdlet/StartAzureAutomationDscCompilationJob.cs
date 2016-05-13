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

using Microsoft.Azure.Commands.Automation.Model;
using Microsoft.Azure.Commands.Automation.Properties;
using System;
using System.Collections;
using System.Globalization;
using System.Management.Automation;
using System.Security.Permissions;

namespace Microsoft.Azure.Commands.Automation.Cmdlet
{
    /// <summary>
    /// starts azure automation compilation job
    /// </summary>
    [Cmdlet(VerbsLifecycle.Start, "AzureRmAutomationDscCompilationJob")]
    [OutputType(typeof(CompilationJob))]
    public class StartAzureAutomationDscCompilationJob : AzureAutomationBaseCmdlet
    {
        /// <summary>
        /// Gets or sets the configuration name.
        /// </summary>
        [Parameter(Position = 2, Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "The configuration name.")]
        [Alias("Name")]
        public string ConfigurationName { get; set; }

        /// <summary>
        /// Gets or sets the configuration parameters.
        /// </summary>
        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = false, HelpMessage = "The compilation job parameters.")]
        public IDictionary Parameters { get; set; }

        /// <summary>
        /// Gets or sets the configuration data.
        /// </summary>
        [Parameter(Mandatory = false, HelpMessage = "The compilation job configuration data.")]
        public IDictionary ConfigurationData { get; set; }

        /// <summary>
        /// Execute this cmdlet.
        /// </summary>
        [PermissionSet(SecurityAction.Demand, Name = "FullTrust")]
        protected override void AutomationProcessRecord()
        {
            CompilationJob job = null;

            if (this.Parameters != null && this.Parameters.Contains("ConfigurationData"))
            {
                throw new ArgumentException(
                                          string.Format(
                                              CultureInfo.CurrentCulture,
                                              Resources.ConfigurationDataShouldNotBeInJobParameters, "-ConfigurationData"));
            }

            job = this.AutomationClient.StartCompilationJob(this.ResourceGroupName, this.AutomationAccountName, this.ConfigurationName, this.Parameters, this.ConfigurationData);

            this.WriteObject(job);
        }
    }
}
