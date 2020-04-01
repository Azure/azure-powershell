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
using System.Management.Automation;

namespace Microsoft.Azure.Commands.SecurityCenter.Cmdlets.SqlInformationProtectionPolicy
{
    public class SqlInformationTypeCreateOrUpdateCmdlet : SqlInformationTypeCmdlet
    {
        [Parameter(
            Mandatory = false,
            ParameterSetName = SqlInformationTypeParameterSet,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = DescriptionHelpMessage)]
        [ValidateNotNullOrEmpty]
        public string Description { get; set; }
        
        [Parameter(
            Mandatory = false,
            ParameterSetName = SqlInformationTypeParameterSet,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = StateHelpMessage)]
        public PSSqlSensitivityObjectState State { get; set; }

        [Parameter(
            Mandatory = false,
            ParameterSetName = SqlInformationTypeParameterSet,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = AssociatedLabelHelpMessage)]
        public string AssociatedLabel { get; set; }

        [Parameter(
            Mandatory = false,
            ParameterSetName = SqlInformationTypeParameterSet,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = OrderHelpMessage)]
        public int Order { get; set; }

        private const string AssociatedLabelHelpMessage = "Display name of the sensitivity label to be associated with this information type";
        private const string DescriptionHelpMessage = "The description of the information type";
        private const string OrderHelpMessage = "The order of the information type.";
        private const string StateHelpMessage = "Indicates whether the information type is enabled or not";
    }
}
