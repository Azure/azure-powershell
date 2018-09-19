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

using System.Management.Automation;
using Microsoft.WindowsAzure.Commands.Utilities.Properties;
using Microsoft.WindowsAzure.Commands.Utilities.Scheduler;

namespace Microsoft.WindowsAzure.Commands.Scheduler
{
    /// <summary>
    /// Cmdlet to remove a job
    /// </summary>
    [Cmdlet(VerbsCommon.Remove, "AzureSchedulerJobCollection"), OutputType(typeof(bool))]
    public class RemoveSchedulerJobCollectionCommand : SchedulerBaseCmdlet
    {
        [Parameter(Mandatory = false, HelpMessage = "Do not confirm job collection deletion")]
        public SwitchParameter Force { get; set; }

        [Parameter(Position = 0, Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "The location name.")]
        [ValidateNotNullOrEmpty]
        public string Location { get; set; }

        [Parameter(Position = 1, Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "The job collection name.")]
        [ValidateNotNullOrEmpty]
        public string JobCollectionName { get; set; }

        public override void ExecuteCmdlet()
        {
            ConfirmAction(
               Force.IsPresent,
               string.Format(Resources.RemoveJobCollectionWarning, JobCollectionName),
               Resources.RemoveJobCollectionMessage,
               JobCollectionName,
               () =>
               {                  
                    WriteObject(SMClient.DeleteJobCollection(region: Location, jobCollection: JobCollectionName), true);
               });
        }
    }
}
