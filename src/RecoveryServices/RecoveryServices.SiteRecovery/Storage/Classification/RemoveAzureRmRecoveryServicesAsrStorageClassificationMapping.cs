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

using System.IO;
using System.Management.Automation;
using System.Reflection;
using Microsoft.Azure.Commands.Common.Authentication;
using Microsoft.Azure.Commands.ResourceManager.Common;
using Microsoft.WindowsAzure.Commands.Common;
using Microsoft.Azure.Commands.Common.Authentication.Abstractions;

namespace Microsoft.Azure.Commands.RecoveryServices.SiteRecovery
{
    /// <summary>
    /// Pairs storage classification
    /// </summary>
    [Cmdlet("Remove", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "RecoveryServicesAsrStorageClassificationMapping",DefaultParameterSetName = ASRParameterSets.Default,SupportsShouldProcess = true)]
    [Alias("Remove-ASRStorageClassificationMapping")]
    [OutputType(typeof(ASRJob))]
    public class RemoveAzureRmRecoveryServicesAsrStorageClassificationMapping :
        SiteRecoveryCmdletBase
    {
        /// <summary>
        ///     Gets or sets primary storage classification.
        /// </summary>
        [Parameter(
            ParameterSetName = ASRParameterSets.Default,
            Mandatory = true,
            ValueFromPipeline = true)]
        [ValidateNotNullOrEmpty]
        [Alias("StorageClassificationMapping")]
        public ASRStorageClassificationMapping InputObject { get; set; }

        /// <summary>
        ///     ProcessRecord of the command.
        /// </summary>
        public override void ExecuteSiteRecoveryCmdlet()
        {
            base.ExecuteSiteRecoveryCmdlet();

            if (this.ShouldProcess(
                this.InputObject.Name,
                VerbsCommon.Remove))
            {
                var tokens = this.InputObject.Id.UnFormatArmId(
                    ARMResourceIdPaths.StorageClassificationMappingResourceIdPath);
                var operationResponse = this.RecoveryServicesClient.UnmapStorageClassifications(
                    tokens[0],
                    tokens[1],
                    tokens[2]);
                var jobResponse = this.RecoveryServicesClient.GetAzureSiteRecoveryJobDetails(
                    PSRecoveryServicesClient
                        .GetJobIdFromReponseLocation(operationResponse.Location));

                this.WriteObject(new ASRJob(jobResponse));
            }
        }
    }
}
