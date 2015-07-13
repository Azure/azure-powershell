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

using System;
using System.Collections.Generic;
using System.Management.Automation;
using Microsoft.Azure.Commands.RecoveryServices.SiteRecovery;
using Microsoft.Azure.Portal.RecoveryServices.Models.Common;
using Microsoft.WindowsAzure.Management.SiteRecovery.Models;

namespace Microsoft.Azure.Commands.RecoveryServices
{
    /// <summary>
    /// Updates protected Virtual Machine properties.
    /// </summary>
    [Cmdlet(VerbsCommon.Set, "AzureSiteRecoveryVM")]
    [OutputType(typeof(ASRJob))]
    public class SetAzureSiteRecoveryVirtualMachine : RecoveryServicesCmdletBase
    {
        #region Parameters
        /// <summary>
        /// Job response.
        /// </summary>
        private JobResponse jobResponse = null;

        /// <summary>
        /// Gets or sets ID of the Virtual Machine.
        /// </summary>
        [Parameter(Mandatory = true)]
        [ValidateNotNullOrEmpty]
        public ASRVirtualMachine VirtualMachine { get; set; }

        /// <summary>
        /// Gets or sets Recovery Azure VM given name
        /// </summary>
        [Parameter]
        [ValidateNotNullOrEmpty]
        public string RecoveryAzureVMName { get; set; }

        /// <summary>
        /// Gets or sets Recovery Azure VM size
        /// </summary>
        [Parameter]
        [ValidateNotNullOrEmpty]
        public string RecoveryAzureVMSize { get; set; }

        /// <summary>
        /// Gets or sets Recovery Azure Network Id
        /// </summary>
        [Parameter]
        [ValidateNotNullOrEmpty]
        public string RecoveryAzureNetworkId { get; set; }

        /// <summary>
        /// Gets or sets Selected Primary Network interface card Id
        /// </summary>
        [Parameter]
        [ValidateNotNullOrEmpty]
        public string PrimaryNicId { get; set; }

        /// <summary>
        /// Gets or sets recovery VM subnet name
        /// </summary>
        [Parameter]
        [ValidateNotNullOrEmpty]
        public string RecoveryVMSubnetName { get; set; }

        /// <summary>
        /// Gets or sets recovery NIC static IP address
        /// </summary>
        [Parameter]
        [ValidateNotNullOrEmpty]
        public string RecoveryNicIPAddress { get; set; }

        #endregion Parameters

        /// <summary>
        /// ProcessRecord of the command.
        /// </summary>
        public override void ExecuteCmdlet()
        {
            // Check for at least one option
            if (string.IsNullOrEmpty(this.RecoveryAzureVMName) &&
                string.IsNullOrEmpty(this.RecoveryAzureVMSize) &&
                string.IsNullOrEmpty(this.PrimaryNicId) &&
                (string.IsNullOrEmpty(this.RecoveryAzureNetworkId) ||
                string.IsNullOrEmpty(this.RecoveryVMSubnetName) ||
                string.IsNullOrEmpty(this.RecoveryNicIPAddress)))
            {
                this.WriteWarning(Properties.Resources.ArgumentsMissingForUpdateVmProperties.ToString());
                return;
            }

            VMProperties updateVmPropertiesInput = new VMProperties();
            updateVmPropertiesInput.RecoveryAzureVMName = this.RecoveryAzureVMName;
            updateVmPropertiesInput.RecoveryAzureVMSize = this.RecoveryAzureVMSize;
            updateVmPropertiesInput.SelectedRecoveryAzureNetworkId = this.RecoveryAzureNetworkId;

            updateVmPropertiesInput.VMNics = new List<VMNicDetails>();
            VMNicDetails vmnicDetails = new VMNicDetails();
            vmnicDetails.NicId = this.PrimaryNicId;
            vmnicDetails.RecoveryVMSubnetName = this.RecoveryVMSubnetName;
            vmnicDetails.ReplicaNicStaticIPAddress = this.RecoveryNicIPAddress;
            updateVmPropertiesInput.VMNics.Add(vmnicDetails);

            this.jobResponse = RecoveryServicesClient.UpdateVmProperties(
                this.VirtualMachine.ProtectionContainerId,
                this.VirtualMachine.ID,
                updateVmPropertiesInput);

            this.WriteJob(this.jobResponse.Job);
        }

        /// <summary>
        /// Writes Job.
        /// </summary>
        /// <param name="job">JOB object</param>
        private void WriteJob(Microsoft.WindowsAzure.Management.SiteRecovery.Models.Job job)
        {
            this.WriteObject(new ASRJob(job));
        }
    }
}