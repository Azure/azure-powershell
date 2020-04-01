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

using Microsoft.Azure.Commands.SecurityCenter.Models.SqlInformationProtectionPolicy;
using System.Collections.Generic;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.SecurityCenter.Cmdlets.SqlInformationProtectionPolicy
{
    public class SqlSensitivityLabelCreateOrUpdateCmdlet : SqlSensitivityLabelCmdlet
    {
        [Parameter(
            Mandatory = false,
            ParameterSetName = SqlSensitivityLabelParameterSet,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = DescriptionHelpMessage)]
        [ValidateNotNullOrEmpty]
        public string Description { get; set; }

        [Parameter(
            Mandatory = false,
            ParameterSetName = SqlSensitivityLabelParameterSet,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = StateHelpMessage)]
        public PSSqlSensitivityObjectState State { get; set; }

        [Parameter(
            Mandatory = false,
            ParameterSetName = SqlSensitivityLabelParameterSet,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = RankHelpMessage)]
        public PSSensitivityRank Rank { get; set; }

        [Parameter(
            Mandatory = false,
            ParameterSetName = SqlSensitivityLabelParameterSet,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = OrderHelpMessage)]
        public int Order { get; set; }

        [Parameter(
            Mandatory = false,
            ParameterSetName = SqlSensitivityLabelParameterSet,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = AssociatedInformationTypesHelpMessage)]
        public string[] AssociatedInformationTypes { get; set; }

        private const string AssociatedInformationTypesHelpMessage = "If any of these information types are identified, this label is applied";
        private const string StateHelpMessage = "Indicates whether the sensitivity label is enabled or not";
        private const string RankHelpMessage = "An identifier based on a predefinied set of values which define sensitivity rank.Used by other services like Advanced Threat Protection to detect anomalies based on their rank";
        private const string DescriptionHelpMessage = "The description of the sensitivity label";
        private const string OrderHelpMessage = "The order of the sensitivity label.";
    }
}
