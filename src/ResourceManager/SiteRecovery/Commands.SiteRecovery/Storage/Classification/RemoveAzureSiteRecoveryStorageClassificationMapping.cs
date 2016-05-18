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

using Microsoft.Azure.Management.SiteRecovery.Models;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.SiteRecovery
{
    // <summary>
    /// Pairs storage classification
    /// </summary>
    [Cmdlet(VerbsCommon.Remove, "AzureRmSiteRecoveryStorageClassificationMapping")]
    [OutputType(typeof(ASRJob))]
    public class RemoveAzureSiteRecoveryStorageClassificationMapping : SiteRecoveryCmdletBase
    {
        #region Parameters

        /// <summary>
        /// Gets or sets primary storage classification.
        /// </summary>
        [Parameter(Mandatory = true, ValueFromPipeline = true)]
        [ValidateNotNullOrEmpty]
        public ASRStorageClassificationMapping StorageClassificationMapping { get; set; }
        #endregion

        /// <summary>
        /// ProcessRecord of the command.
        /// </summary>
        public override void ExecuteSiteRecoveryCmdlet()
        {
            base.ExecuteSiteRecoveryCmdlet();

            string[] tokens = StorageClassificationMapping.Id.UnFormatArmId(
                ARMResourceIdPaths.StorageClassificationMappingResourceIdPath);
            var operationResponse = RecoveryServicesClient.UnmapStorageClassifications(
                fabricName: tokens[0],
                storageClassificationName: tokens[1],
                mappingName: tokens[2]);
            JobResponse jobResponse =
                RecoveryServicesClient.GetAzureSiteRecoveryJobDetails(
                PSRecoveryServicesClient.GetJobIdFromReponseLocation(operationResponse.Location));

            base.WriteObject(new ASRJob(jobResponse.Job));
        }
    }
}
