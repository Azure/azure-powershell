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

using System.Collections.Generic;
using System.Management.Automation;
using Microsoft.WindowsAzure.Commands.Utilities.Websites.Common;
using Microsoft.WindowsAzure.Commands.Utilities.Websites.Services.WebJobs;
using Microsoft.WindowsAzure.WebSitesExtensions.Models;

namespace Microsoft.WindowsAzure.Commands.Websites.WebJobs
{
    [Cmdlet(VerbsCommon.Get, "AzureWebsiteJobHistory"), OutputType(typeof(List<TriggeredWebJobRun>))]
    public class GetAzureWebsiteJobHistoryCommand : WebsiteContextBaseCmdlet
    {
        private const string RunIdParameterSetName = "RunIdParameterSetName";

        private const string HistoryParameterSetName = "HistoryParameterSetName";

        private const string LatestParameterSetName = "LatestParameterSetName";

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "The web job name.", ParameterSetName = HistoryParameterSetName)]
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "The web job name.", ParameterSetName = RunIdParameterSetName)]
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "The web job name.", ParameterSetName = LatestParameterSetName)]
        public string JobName { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "The id of the run history you want to see.", ParameterSetName = RunIdParameterSetName)]
        public string RunId { get; set; }

        [Parameter(Mandatory = true, HelpMessage = "If specified, return the latest run history.", ParameterSetName = LatestParameterSetName)]
        public SwitchParameter Latest { get; set; }

        public override void ExecuteCmdlet()
        {
            WebJobHistoryFilterOptions options = new WebJobHistoryFilterOptions()
            {
                Name = Name,
                Slot = Slot,
                JobName = JobName,
                Latest = Latest,
                RunId = RunId
            };
            WriteObject(WebsitesClient.FilterWebJobHistory(options), true);
        }
    }
}
