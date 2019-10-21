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

using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.RecoveryServices.SiteRecovery
{
    /// <summary>
    ///     Creates Azure Site Recovery Disk replication configuration for A2A replication.
    /// </summary>
    [Cmdlet("New", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "RecoveryServicesAsrInMageAzureV2DiskInput", DefaultParameterSetName = ASRParameterSets.VMwareToAzure, SupportsShouldProcess = true)]
    [Alias("New-AsrInMageAzureV2DiskInput")]
    [OutputType(typeof(AsrInMageAzureV2DiskInput))]
    public class AzureRmAsrInMageAzureV2DiskInput : SiteRecoveryCmdletBase
    {
        #region Parameters
        /// <summary>
        ///     Gets or sets the disk uri.
        /// </summary>
        [Parameter(ParameterSetName = ASRParameterSets.VMwareToAzure,
            Mandatory = true,
            HelpMessage = "Specify the DiskId of the disk that this mapping corresponds to.")]
        [ValidateNotNullOrEmpty]
        public string DiskId { get; set; }

        /// <summary>
        ///     Gets or sets the primary staging/ log storage account ARM Id.
        /// </summary>
        [Parameter(ParameterSetName = ASRParameterSets.VMwareToAzure,
            Mandatory = true,
            HelpMessage = "Specifies the log or cache storage account Id to be used to store replication logs.")]
        [ValidateNotNullOrEmpty]
        public string LogStorageAccountId { get; set; }

        /// <summary>
        ///     Gets or sets the recovery disk storage account ARM Id. 
        /// </summary>
        [Parameter(ParameterSetName = ASRParameterSets.VMwareToAzure,
            Mandatory = true,
            HelpMessage = "Specifies the Recovery disk type.")]
        [ValidateNotNullOrEmpty]
        [PSArgumentCompleter("Standard_LRS", "Premium_LRS", "StandardSSD_LRS")]
        public string DiskType { get; set; }

        #endregion Parameters

        /// <summary>
        ///     ProcessRecord of the command.
        /// </summary>
        public override void ExecuteSiteRecoveryCmdlet()
        {
            base.ExecuteSiteRecoveryCmdlet();
            AsrInMageAzureV2DiskInput diskRelicationConfig = null;

            if (this.ShouldProcess(
                this.DiskId,
                VerbsCommon.New))
            {
                diskRelicationConfig = new AsrInMageAzureV2DiskInput()
                {
                    DiskId = this.DiskId,
                    DiskType = this.DiskType,
                    LogStorageAccountId = this.LogStorageAccountId
                };
            }
            this.WriteObject(diskRelicationConfig);
        }
    }
}