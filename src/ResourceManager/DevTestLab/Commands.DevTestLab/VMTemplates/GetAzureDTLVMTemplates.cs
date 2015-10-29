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
    [Cmdlet(VerbsCommon.Get, "AzureDtlVMTemplate", DefaultParameterSetName = "ListAll")]
    [OutputType(typeof(IEnumerable<Environment>), typeof(Environment))]
    public class GetAzureDtlVMTemplate: DevTestLabBaseCmdlet
    {
        ///////////////////////////////////////////////////////////////////////////////////////////

        #region Optional Parameters

        // We support two parameter sets:
        // 1: ListAll: Lists all VM templates within a lab, if the -LabName and -LabResourceGroupName parameters are specified.
        // 2: GetSpecific: Gets a specific VM template within a lab, if the -VMTemplateName, -LabName and -LabResourceGroupName parameters are specified.

        [Parameter(Mandatory = true, ParameterSetName = "ListAll")]
        [Parameter(Mandatory = true, ParameterSetName = "GetSpecific")]
        [ValidateNotNullOrEmpty]
        public string LabName { get; set; }

        [Parameter(Mandatory = true, ParameterSetName = "ListAll")]
        [Parameter(Mandatory = true, ParameterSetName = "GetSpecific")]
        [ValidateNotNullOrEmpty]
        public string LabResourceGroupName { get; set; }

        [Parameter(Mandatory = true, ParameterSetName = "GetSpecific")]
        [ValidateNotNullOrEmpty]
        public string VMTemplateName { get; set; }

        #endregion // Optional Parameters

        ///////////////////////////////////////////////////////////////////////////////////////////

        #region Cmdlet Overrides

        /// <summary>
        /// Implements the Get-AzureDtlLab cmdlet.
        /// </summary>
        protected override void ProcessRecord()
        {
            WriteVerbose("Processing StartTime : " + DateTime.UtcNow.ToString());

            switch (ParameterSetName)
            {
                case "ListAll":
                    WriteObject(this.DtlClient.ListVMTemplatesByLab(this.LabName, this.LabResourceGroupName));
                    break;

                case "GetSpecific":
                    WriteObject(this.DtlClient.GetVMTemplate(this.LabName, this.LabResourceGroupName, this.VMTemplateName));
                    break;
            }

            WriteVerbose("Processing EndTime : " + DateTime.UtcNow.ToString());
        }

        #endregion // Cmdlet Overrides

        ///////////////////////////////////////////////////////////////////////////////////////////
    }
}
