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

using Microsoft.Azure.Commands.DevTestLab.Models;
using System;
using System.Collections.Generic;
using System.Management.Automation;
using Environment = Microsoft.Azure.Management.DevTestLab.Models.Environment;

namespace Microsoft.Azure.Commands.DevTestLab
{
    [Cmdlet(VerbsCommon.Get, "AzureDtlVMTemplate", DefaultParameterSetName = "FilterByLabName")]
    [OutputType(typeof(IEnumerable<Environment>), typeof(Environment))]
    public class GetAzureDtlVMTemplate: DevTestLabBaseCmdlet
    {
        ///////////////////////////////////////////////////////////////////////////////////////////

        #region Optional Parameters

        // We support three parameter sets:
        // 1: Both LabName and lab's ResourceGroupName are specified: Gets all VM templates in that lab.
        // 2: LabName, lab's ResourceGroupName and VMTemplateName specified: Gets specific VM template.

        [Parameter(Mandatory = true, ParameterSetName = "FilterByLabName")]
        [Parameter(Mandatory = true, ParameterSetName = "FilterByVMTemplateName")]
        [ValidateNotNullOrEmpty]
        public string LabName { get; set; }

        [Parameter(Mandatory = true, ParameterSetName = "FilterByVMTemplateName")]
        [ValidateNotNullOrEmpty]
        public string VMTemplateName { get; set; }

        [Parameter(Mandatory = true, ParameterSetName = "FilterByLabName")]
        [Parameter(Mandatory = true, ParameterSetName = "FilterByVMTemplateName")]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        #endregion // Optional Parameters

        ///////////////////////////////////////////////////////////////////////////////////////////

        #region Cmdlet Overrides

        /// <summary>
        /// Implements the Get-AzureDTLLab cmdlet.
        /// </summary>
        protected override void ProcessRecord()
        {
            WriteVerbose("Processing StartTime : " + DateTime.UtcNow.ToString());

            switch (ParameterSetName)
            {
                case "FilterByLabName":
                    WriteObject(this.DtlClient.ListVMTemplatesByLab(this.LabName, this.ResourceGroupName));
                    break;

                case "FilterByVMTemplateName":
                    WriteObject(this.DtlClient.GetVMTemplate(this.LabName, this.ResourceGroupName, this.VMTemplateName));
                    break;
            }

            WriteVerbose("Processing EndTime : " + DateTime.UtcNow.ToString());
        }

        #endregion // Cmdlet Overrides

        ///////////////////////////////////////////////////////////////////////////////////////////
    }
}
