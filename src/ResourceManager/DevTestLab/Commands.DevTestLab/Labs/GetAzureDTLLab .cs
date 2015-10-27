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
using Microsoft.Azure.Management.DevTestLab.Models;
using System;
using System.Collections.Generic;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.DevTestLab
{
    [Cmdlet(VerbsCommon.Get, "AzureDtlLab", DefaultParameterSetName = "FilterNone")]
    [OutputType(typeof(IEnumerable<Lab>), typeof(Lab))]
    public class GetAzureDtlLab : DevTestLabBaseCmdlet
    {
        ///////////////////////////////////////////////////////////////////////////////////////////

        #region Optional Parameters

        // We support three parameter sets:
        // 1: No parameters: Get all labs in current subscription.
        // 2: Only ResourceGroupName specified: Gets all labs in that resource group.
        // 3: Both LabName and ResourceGroupName are specified: Gets the specific lab.

        [Parameter(Mandatory = true, ParameterSetName = "FilterByLabName")]
        [ValidateNotNullOrEmpty]
        public string LabName { get; set; }

        [Parameter(Mandatory = true, ParameterSetName = "FilterByLabName")]
        [Parameter(Mandatory = true, ParameterSetName = "FilterByResourceGroupName")]
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
                    WriteObject(this.DtlClient.GetLab(this.ResourceGroupName, this.LabName));
                    break;

                case "FilterByResourceGroupName":
                    WriteObject(this.DtlClient.ListLabsByResourceGroup(this.ResourceGroupName));
                    break;

                case "FilterNone":
                default:
                    WriteObject(this.DtlClient.ListLabs());
                    break;
            }

            WriteVerbose("Processing EndTime : " + DateTime.UtcNow.ToString());
        }

        #endregion // Cmdlet Overrides

        ///////////////////////////////////////////////////////////////////////////////////////////
    }
}
