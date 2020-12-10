﻿// ----------------------------------------------------------------------------------
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
using Microsoft.Azure.Commands.SecurityInsights.Models.Incidents;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Management.SecurityInsights.Models;

namespace Microsoft.Azure.Commands.SecurityInsights.Cmdlets.Incidents
{
    [Cmdlet(VerbsCommon.New, ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "SentinelIncidentOwner", DefaultParameterSetName = ParameterSetNames.GeneralScope, SupportsShouldProcess = true), OutputType(typeof(PSSentinelIncident))]
    public class NewIncidentsOwner : SecurityInsightsCmdletBase
    {
        [Parameter(ParameterSetName = ParameterSetNames.GeneralScope, Mandatory = true, HelpMessage = ParameterHelpMessages.AssignedTo)]
        public string AssignedTo { get; set; }

        [Parameter(ParameterSetName = ParameterSetNames.GeneralScope, Mandatory = true, HelpMessage = ParameterHelpMessages.Email)]
        public string Email { get; set; }

        [Parameter(ParameterSetName = ParameterSetNames.GeneralScope, Mandatory = true, HelpMessage = ParameterHelpMessages.ObjectId)]
        public string ObjectId { get; set; }

        [Parameter(ParameterSetName = ParameterSetNames.GeneralScope, Mandatory = true, HelpMessage = ParameterHelpMessages.UserPrincipalName)]
        public string UserPrincipalName { get; set; }

        public override void ExecuteCmdlet()
        {
            PSSentinelIncidentOwner owner = new PSSentinelIncidentOwner
            {
                AssignedTo = AssignedTo,
                Email = Email,
                ObjectId = Guid.Parse(ObjectId),
                UserPrincipalName = UserPrincipalName
            };

            if (ShouldProcess(ObjectId, VerbsCommon.New))
            {
                WriteObject(owner, enumerateCollection: false);
            }
        }
    }
}
