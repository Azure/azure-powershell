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
    [Cmdlet(VerbsCommon.Get, "AzureDtlEnvironment", DefaultParameterSetName = "ListAll")]
    [OutputType(typeof(IEnumerable<Environment>), typeof(Environment))]
    public class GetAzureDtlEnvironment : DevTestLabBaseCmdlet
    {
        ///////////////////////////////////////////////////////////////////////////////////////////

        #region Optional Parameters

        // We support four parameter sets:
        // 1: ListAll: Lists all environments within the current subscription, if no parameters are specified.
        // 2: ListAllWithinResourceGroup: Lists all environments within a resource group, if the -ResourceGroupName parameter is specified. 
        // 3: GetSpecificWithinResourceGroup: Gets a specific environment within a resource group, if both the -EnvironmentName and -ResourceGroupName are specified.
        // 4: ListAllWithinLab: Lists all environments within a lab, if both the -LabName and the -LabResourceGroupName parameters are specified. 
        // 5: @TODO: GetSpecificWithinLab: Gets a specific environment within a lab, if the -LabName, -LabResourceGroupName and -EnvironmentName parameters are specified. 

        [Parameter(Mandatory = true, ParameterSetName = "ListAllWithinResourceGroup")]
        [Parameter(Mandatory = true, ParameterSetName = "GetSpecificWithinResourceGroup")]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Parameter(Mandatory = true, ParameterSetName = "GetSpecificWithinResourceGroup")]
        // @TODO: [Parameter(Mandatory = true, ParameterSetName = "GetSpecificWithinLab")]
        [ValidateNotNullOrEmpty]
        public string EnvironmentName { get; set; }

        [Parameter(Mandatory = true, ParameterSetName = "ListAllWithinLab")]
        // @TODO: [Parameter(Mandatory = true, ParameterSetName = "GetSpecificWithinLab")]
        [ValidateNotNullOrEmpty]
        public string LabName { get; set; }

        [Parameter(Mandatory = true, ParameterSetName = "ListAllWithinLab")]
        // @TODO: [Parameter(Mandatory = true, ParameterSetName = "GetSpecificWithinLab")]
        [ValidateNotNullOrEmpty]
        public string LabResourceGroupName { get; set; }

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
                case "GetSpecificWithinResourceGroup":
                    WriteObject(this.DtlClient.GetEnvironment(this.ResourceGroupName, this.EnvironmentName));
                    break;

                case "ListAllWithinResourceGroup":
                    WriteObject(this.DtlClient.ListEnvironmentByResourceGroup(this.ResourceGroupName));
                    break;

                case "ListAllWithinLab":
                    WriteObject(this.DtlClient.ListEnvironmentByLab(this.LabResourceGroupName, this.LabName));
                    break;

                case "ListAll":
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
