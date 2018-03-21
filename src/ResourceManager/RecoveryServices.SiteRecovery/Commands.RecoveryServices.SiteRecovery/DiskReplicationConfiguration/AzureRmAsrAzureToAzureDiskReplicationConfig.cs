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

using System.Management.Automation;

namespace Microsoft.Azure.Commands.RecoveryServices.SiteRecovery
{
    /// <summary>
    ///     Creates Azure Site Recovery Disk replication configuration for A2A replication.
    /// </summary>
    [Cmdlet(
        VerbsCommon.New,
        "AzureRmRecoveryServicesAsrAzureToAzureDiskReplicationConfig",
        DefaultParameterSetName = ASRParameterSets.AzureToAzure,
        SupportsShouldProcess = true)]
    [Alias("New-ASRAzureToAzureDiskReplicationConfig")]
    [OutputType(typeof(ASRAzuretoAzureDiskReplicationConfig))]
    public class AzureRmAsrAzureToAzureDiskReplicationConfig : SiteRecoveryCmdletBase
    {
        #region Parameters

        /// <summary>
        ///     Gets or sets the disk uri.
        /// </summary>
        [Parameter(ParameterSetName = ASRParameterSets.AzureToAzure,
            Mandatory = true,
            HelpMessage = "Specify the VHD URI of the disk that this mapping corresponds to.")]
        [ValidateNotNullOrEmpty]
        public string VhdUri { get; set; }

        /// <summary>
        ///     Gets or sets the primary staging/ log storage account ARM Id.
        /// </summary>
        [Parameter(ParameterSetName = ASRParameterSets.AzureToAzure,
            Mandatory = true,
            HelpMessage = "Specifies the log or cache storage account Id to be used to store replication logs.")]
        [ValidateNotNullOrEmpty]
        public string LogStorageAccountId { get; set; }

        /// <summary>
        ///     Gets or sets the recovery disk storage account ARM Id. 
        /// </summary>
        [Parameter(ParameterSetName = ASRParameterSets.AzureToAzure,
            Mandatory = true,
            HelpMessage = "Specifies the ID of the Azure storage account to replicate to.")]
        [ValidateNotNullOrEmpty]
        public string RecoveryAzureStorageAccountId { get; set; }

        #endregion Parameters

        /// <summary>
        ///     ProcessRecord of the command.
        /// </summary>
        public override void ExecuteSiteRecoveryCmdlet()
        {
            base.ExecuteSiteRecoveryCmdlet();

            // Creating ASRAzureToAzureDiskReplicationConfig for Disk uri
            if (this.ShouldProcess(
                this.VhdUri,
                VerbsCommon.New))
            {
                var diskRelicationConfig = new ASRAzuretoAzureDiskReplicationConfig()
                {
                    VhdUri = this.VhdUri,
                    LogStorageAccountId = this.LogStorageAccountId,
                    RecoveryAzureStorageAccountId = this.RecoveryAzureStorageAccountId
                };
                this.WriteObject(diskRelicationConfig);
            }

        }
    }
}
