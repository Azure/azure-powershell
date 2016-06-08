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
using System;
using System.Management.Automation;
using System.Security.Permissions;

namespace Microsoft.Azure.Commands.Automation.Cmdlet
{
    /// <summary>  
    /// Gets azure automation job stream record for a given job.  
    /// </summary>  
    [Cmdlet(VerbsCommon.Get, "AzureRmAutomationJobOutputRecord")]
    [OutputType(typeof(JobStreamRecord))]
    public class GetAzureAutomationJobOutputRecord : AzureAutomationBaseCmdlet
    {
        /// <summary>  
        /// Gets or sets the job id  
        /// </summary>  
        [Parameter(Mandatory = true, Position = 2, ValueFromPipelineByPropertyName = true, HelpMessage = "The job Id")]
        public Guid JobId { get; set; }

        /// <summary>  
        /// Gets or sets the job stream record id  
        /// </summary>  
        [Alias("StreamRecordId")]
        [Parameter(Mandatory = true, Position = 3, ValueFromPipelineByPropertyName = true, HelpMessage = "The stream record id")]
        [ValidateNotNullOrEmpty]
        public string Id { get; set; }

        /// <summary>  
        /// Execute this cmdlet.  
        /// </summary>  
        [PermissionSet(SecurityAction.Demand, Name = "FullTrust")]
        protected override void AutomationProcessRecord()
        {
            var ret = this.AutomationClient.GetJobStreamRecord(this.ResourceGroupName, this.AutomationAccountName, this.JobId, this.Id);
            this.GenerateCmdletOutput(ret);
        }
    }
}