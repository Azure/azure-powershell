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
// ------------------------------------

using System;
using System.Management.Automation;
using Microsoft.Azure.Commands.SecurityInsights;
using Microsoft.Azure.Commands.SecurityInsights.Common;
using Microsoft.Azure.Commands.SecurityInsights.Models.Bookmarks;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Management.SecurityInsights.Models;

namespace Microsoft.Azure.Commands.SecurityInsights.Cmdlets.Bookmarks
{
    [Cmdlet(VerbsCommon.New, ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "SentinelBookmarkIncidentInfo", DefaultParameterSetName = ParameterSetNames.GeneralScope), OutputType(typeof(PSSentinelBookmarkIncidentInfo))]
    public class NewBookmarkIncidentInfo : SecurityInsightsCmdletBase
    {
        [Parameter(ParameterSetName = ParameterSetNames.GeneralScope, Mandatory = true, HelpMessage = ParameterHelpMessages.IncidentId)]
        public string IncidentId { get; set; }

        [Parameter(ParameterSetName = ParameterSetNames.GeneralScope, Mandatory = true, HelpMessage = ParameterHelpMessages.RelationName)]
        public string RelationName { get; set; }

        [Parameter(ParameterSetName = ParameterSetNames.GeneralScope, Mandatory = true, HelpMessage = ParameterHelpMessages.Severity)]
        public string Severity { get; set; }

        [Parameter(ParameterSetName = ParameterSetNames.GeneralScope, Mandatory = true, HelpMessage = ParameterHelpMessages.Title)]
        public string Title { get; set; }

        public override void ExecuteCmdlet()
        {
            PSSentinelBookmarkIncidentInfo incidentInfo = new PSSentinelBookmarkIncidentInfo
            {
                IncidentId = IncidentId,
                RelationName = RelationName,
                Severity = Severity,
                Title = Title
            };

            WriteObject(incidentInfo, enumerateCollection: false);
        }
    }
}
