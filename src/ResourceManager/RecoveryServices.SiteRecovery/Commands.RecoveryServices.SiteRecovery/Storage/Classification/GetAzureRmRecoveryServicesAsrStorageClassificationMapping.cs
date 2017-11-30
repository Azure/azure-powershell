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
using System.Linq;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.RecoveryServices.SiteRecovery
{
    /// <summary>
    ///     Retrieves Azure Site Recovery storage classification.
    /// </summary>
    [Cmdlet(
        VerbsCommon.Get,
        "AzureRmRecoveryServicesAsrStorageClassificationMapping",
        DefaultParameterSetName = ASRParameterSets.ByObject)]
    [Alias("Get-ASRStorageClassificationMapping")]
    [OutputType(typeof(IEnumerable<ASRStorageClassificationMapping>))]
    public class GetAzureRmRecoveryServicesAsrStorageClassificationMapping : SiteRecoveryCmdletBase
    {
        /// <summary>
        ///     Gets or sets name of classification.
        /// </summary>
        [Parameter(
            ParameterSetName = ASRParameterSets.ByObjectWithName,
            Mandatory = true)]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        /// <summary>
        ///     Gets or sets primary storage classification.
        /// </summary>
        [Parameter(
            ParameterSetName = ASRParameterSets.ByObjectWithName,
            Mandatory = true,
            ValueFromPipeline = true)]
        [Parameter(
            ParameterSetName = ASRParameterSets.ByObject,
            Mandatory = true,
            ValueFromPipeline = true)]
        [ValidateNotNullOrEmpty]
        public ASRStorageClassification StorageClassification { get; set; }

        /// <summary>
        ///     ProcessRecord of the command.
        /// </summary>
        public override void ExecuteSiteRecoveryCmdlet()
        {
            base.ExecuteSiteRecoveryCmdlet();

            var mappings = this.RecoveryServicesClient
                .GetAzureSiteRecoveryStorageClassificationMapping();

            switch (this.ParameterSetName)
            {
                case ASRParameterSets.ByObjectWithName:
                    mappings = mappings.Where(
                            item => item.Name.Equals(
                                this.Name,
                                StringComparison.InvariantCultureIgnoreCase))
                        .ToList();
                    mappings = mappings.Where(
                            item => item.GetPrimaryStorageClassificationId()
                                .Equals(
                                    this.StorageClassification.Id,
                                    StringComparison.InvariantCultureIgnoreCase))
                        .ToList();
                    break;
                case ASRParameterSets.ByObject:
                    mappings = mappings.Where(
                            item => item.GetPrimaryStorageClassificationId()
                                .Equals(
                                    this.StorageClassification.Id,
                                    StringComparison.InvariantCultureIgnoreCase))
                        .ToList();
                    break;
            }

            var psObject = mappings.ConvertAll(
                item =>
                {
                    return new ASRStorageClassificationMapping
                    {
                        Id = item.Id,
                        Name = item.Name,
                        PrimaryClassificationId = item.GetPrimaryStorageClassificationId(),
                        RecoveryClassificationId = item.Properties.TargetStorageClassificationId
                    };
                });

            this.WriteObject(
                psObject,
                true);
        }
    }
}