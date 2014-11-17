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
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using Microsoft.WindowsAzure.Commands.Utilities.Websites.Common;
using Microsoft.WindowsAzure.WebSitesExtensions.Models;

namespace Microsoft.WindowsAzure.Commands.Websites.WebJobs
{
    [Cmdlet(VerbsCommon.New, "AzureWebsiteJob")]
    public class NewAzureWebsiteJobCommand : WebsiteContextBaseCmdlet
    {
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "The web job name.")]
        public string JobName { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "The web job type.")]
        public WebJobType JobType { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "The web job file.")]
        public string JobFile { get; set; }

        public override void ExecuteCmdlet()
        {
            WriteObject(WebsitesClient.CreateWebJob(Name, Slot, JobName, JobType, this.ResolvePath(JobFile)));
        }
    }
}
