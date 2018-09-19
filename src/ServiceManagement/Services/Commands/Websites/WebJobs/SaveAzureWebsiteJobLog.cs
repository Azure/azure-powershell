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
using Microsoft.WindowsAzure.Commands.Utilities.Websites.Common;
using Microsoft.WindowsAzure.WebSitesExtensions.Models;

namespace Microsoft.WindowsAzure.Commands.Websites.WebJobs
{
    public class SaveAzureWebsiteJobLogCommand : WebsiteContextBaseCmdlet
    {
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "The web job name.")]
        public string JobName { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "The web job type.")]
        public WebJobType JobType { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "The logs output file.")]
        public string Output { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, 
            HelpMessage = "If the given job is a triggered job. Users can use the parameter to specify the run history whose log they want to download. If not give, download the latest run history log.")]
        public string RunId { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Returns a boolean value indicating that the log saved successfully. By default, this cmdlet does not return any output.")]
        public SwitchParameter PassThru { get; set; }

        public override void ExecuteCmdlet()
        {
            WebsitesClient.SaveWebJobLog(Name, Slot, JobName, JobType, Output, RunId);
            if (PassThru)
            {
                WriteObject(true);
            }
        }
    }
}
