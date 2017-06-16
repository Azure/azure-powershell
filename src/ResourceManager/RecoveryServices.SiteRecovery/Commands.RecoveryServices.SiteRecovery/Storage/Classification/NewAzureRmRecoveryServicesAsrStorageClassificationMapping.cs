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
using Microsoft.Azure.Management.RecoveryServices.SiteRecovery.Models;

namespace Microsoft.Azure.Commands.RecoveryServices.SiteRecovery
{
    /// <summary>
    ///     Pairs storage classification
    /// </summary>
    [Cmdlet(VerbsCommon.New,
        "AzureRmRecoveryServicesAsrStorageClassificationMapping",
        DefaultParameterSetName = ASRParameterSets.ByObject)]
    [Alias("New-ASRStorageClassificationMapping")]
    [OutputType(typeof(ASRJob))]
    public class NewAzureRmRecoveryServicesAsrStorageClassificationMapping : SiteRecoveryCmdletBase
    {
        /// <summary>
        ///     Gets or sets Name.
        /// </summary>
        [Parameter(ParameterSetName = ASRParameterSets.ByObject,
            Mandatory = true)]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        /// <summary>
        ///     Gets or sets primary storage classification.
        /// </summary>
        [Parameter(ParameterSetName = ASRParameterSets.ByObject,
            Mandatory = true,
            ValueFromPipeline = true)]
        [ValidateNotNullOrEmpty]
        public ASRStorageClassification PrimaryStorageClassification { get; set; }

        /// <summary>
        ///     Gets or sets recovery storage classification.
        /// </summary>
        [Parameter(ParameterSetName = ASRParameterSets.ByObject,
            Mandatory = true)]
        [ValidateNotNullOrEmpty]
        public ASRStorageClassification RecoveryStorageClassification { get; set; }

        /// <summary>
        ///     ProcessRecord of the command.
        /// </summary>
        public override void ExecuteSiteRecoveryCmdlet()
        {
            base.ExecuteSiteRecoveryCmdlet();

            var mappingName = Name;

            var props = new StorageMappingInputProperties
            {
                TargetStorageClassificationId = RecoveryStorageClassification.Id
            };

            var input = new StorageClassificationMappingInput {Properties = props};

            var operationResponse = RecoveryServicesClient.MapStorageClassification(
                PrimaryStorageClassification,
                input,
                mappingName);

            var jobResponse =
                RecoveryServicesClient.GetAzureSiteRecoveryJobDetails(
                    PSRecoveryServicesClient
                        .GetJobIdFromReponseLocation(operationResponse.Location));

            WriteObject(new ASRJob(jobResponse));
        }
    }
}