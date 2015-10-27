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
    [Cmdlet(VerbsCommon.Get, "AzureDtlEnvironment", DefaultParameterSetName = "FilterNone")]
    [OutputType(typeof(IEnumerable<Environment>), typeof(Environment))]
    public class GetAzureDtlEnvironment : DevTestLabBaseCmdlet
    {
        ///////////////////////////////////////////////////////////////////////////////////////////

        #region Optional Parameters

        // We support four parameter sets:
        // 1: No parameters: Get all environments in current subscription.
        // 2: Only ResourceGroupName specified: Gets all environments in that resource group.
        // 3: Both LabName and lab's ResourceGroupName are specified: Gets all environments in that lab.
        // 4: Both EnvironmentName and ResourceGroupName are specified: Gets the specific environment.

        [Parameter(Mandatory = true, ParameterSetName = "FilterByEnvironmentName")]
        [ValidateNotNullOrEmpty]
        public string EnvironmentName { get; set; }

        [Parameter(Mandatory = true, ParameterSetName = "FilterByLabName")]
        [ValidateNotNullOrEmpty]
        public string LabName { get; set; }

        [Parameter(Mandatory = true, ParameterSetName = "FilterByLabName")]
        [Parameter(Mandatory = true, ParameterSetName = "FilterByEnvironmentName")]
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
                case "FilterByEnvironmentName":
                    WriteObject(this.DtlClient.GetEnvironment(this.ResourceGroupName, this.EnvironmentName));
                    break;

                case "FilterByResourceGroupName":
                    WriteObject(this.DtlClient.ListEnvironmentByResourceGroup(this.ResourceGroupName));
                    break;

                case "FilterByLabName":
                    WriteObject(this.DtlClient.ListEnvironmentByLab(this.ResourceGroupName, this.LabName));
                    break;

                case "FilterNone":
                default:
                    WriteObject(this.DtlClient.ListEnvironments());
                    break;
            }

            WriteVerbose("Processing EndTime : " + DateTime.UtcNow.ToString());
        }

        #endregion // Cmdlet Overrides

        ///////////////////////////////////////////////////////////////////////////////////////////
    }
}
