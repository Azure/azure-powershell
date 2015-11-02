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
using System.Management.Automation;
using Environment = Microsoft.Azure.Management.DevTestLab.Models.Environment;

namespace Microsoft.Azure.Commands.DevTestLab
{
    [Cmdlet(VerbsCommon.New, "AzureDtlEnvironment")]
    [OutputType(typeof(Environment))]
    public class NewAzureDTLEnvironment : DevTestLabBaseCmdlet
    {
        ///////////////////////////////////////////////////////////////////////////////////////////

        #region Mandatory Parameters

        [Parameter(Mandatory = true)]
        [ValidateNotNullOrEmpty]
        public string EnvironmentName { get; set; }

        [Parameter(Mandatory = true)]
        [ValidateNotNullOrEmpty]
        public string UserName { get; set; }

        [Parameter(Mandatory = true)]
        [ValidateNotNullOrEmpty]
        public string Password { get; set; }

        [Parameter(Mandatory = true)]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Parameter(Mandatory = true)]
        [ValidateNotNullOrEmpty]
        public string LabName { get; set; }

        [Parameter(Mandatory = true)]
        [ValidateNotNullOrEmpty]
        public string Location { get; set; }

        [Parameter(Mandatory = true)]
        [ValidateNotNullOrEmpty]
        public string VMTemplateName { get; set; }

        [Parameter(Mandatory = true)]
        [ValidateNotNullOrEmpty]
        public string VMSize { get; set; }

        #endregion // Mandatory Parameters

        ///////////////////////////////////////////////////////////////////////////////////////////

        #region Optional Parameters

        /* Not implemented yet

        [Parameter()]
        [ValidateNotNullOrEmpty]
        public SwitchParameter DontWaitForCompletion { get; set; }

        */

        #endregion // Optional Parameters

        ///////////////////////////////////////////////////////////////////////////////////////////

        #region Cmdlet Overrides

        /// <summary>
        /// Implements the New-AzureDTLLab cmdlet.
        /// </summary>
        protected override void ProcessRecord()
        {
            WriteVerbose("Processing StartTime : " + DateTime.UtcNow.ToString());

            EnvironmentCreateParameters ecp = new EnvironmentCreateParameters()
            {
                Name = this.EnvironmentName,
                Location = this.Location,
                Tags = null,
                Properties = new EnvironmentCreateProperties()
                {
                    Notes = "",
                    LabId = string.Format("/subscriptions/{0}/resourceGroups/{1}/providers/Microsoft.DevTestLab/labs/{2}",
                                    DefaultContext.Subscription.Id.ToString(),
                                    this.ResourceGroupName,
                                    this.LabName)
                }
            };

            VMCreateParameters vcp = new VMCreateParameters()
            {
                Name = this.EnvironmentName,
                VMTemplateName = this.VMTemplateName,
                Size = this.VMSize,
                UserName = this.UserName,
                Password = this.Password,
                PowerState = "",
                SshKey = "",
                IsAuthenticationWithSshKey = false
            };

            ecp.Properties.VMParameters.Add(vcp);

            WriteObject(this.DtlClient.CreateEnvironment(ecp, vcp, this.ResourceGroupName, this.LabName));

            WriteVerbose("Processing EndTime : " + DateTime.UtcNow.ToString());
        }

        #endregion // Cmdlet Overrides

        ///////////////////////////////////////////////////////////////////////////////////////////
    }
}
