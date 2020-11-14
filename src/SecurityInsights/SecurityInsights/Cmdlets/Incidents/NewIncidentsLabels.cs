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
    [Cmdlet(VerbsCommon.New, ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "SentinelIncidentLabel", DefaultParameterSetName = ParameterSetNames.GeneralScope), OutputType(typeof(PSSentinelIncidentAdditionalData))]
    public class NewIncidentsLabels : SecurityInsightsCmdletBase
    {
        [Parameter(ParameterSetName = ParameterSetNames.GeneralScope, Mandatory = true, HelpMessage = ParameterHelpMessages.LabelName)]
        public string LabelName { get; set; }

        [Parameter(ParameterSetName = ParameterSetNames.GeneralScope, Mandatory = true, HelpMessage = ParameterHelpMessages.LabelType)]
        [PSArgumentCompleter("System", "User")]
        public string LabelType { get; set; }

        public override void ExecuteCmdlet()
        {
            PSSentinelIncidentLabel label = new PSSentinelIncidentLabel
            {
                LabelName = LabelName,
                LabelType = LabelType
            };

            WriteObject(label, enumerateCollection: false);
        }
    }
}
