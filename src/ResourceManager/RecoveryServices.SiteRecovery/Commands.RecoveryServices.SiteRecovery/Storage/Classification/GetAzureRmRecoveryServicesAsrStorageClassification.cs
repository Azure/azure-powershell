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
        "AzureRmRecoveryServicesAsrStorageClassification",
        DefaultParameterSetName = ASRParameterSets.ByFabricObject)]
    [Alias("Get-ASRStorageClassification")]
    [OutputType(typeof(IEnumerable<ASRStorageClassification>))]
    public class GetAzureRmRecoveryServicesAsrStorageClassification : SiteRecoveryCmdletBase
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
        ///     Gets or sets friendly name of classification.
        /// </summary>
        [Parameter(
            ParameterSetName = ASRParameterSets.ByObjectWithFriendlyName,
            Mandatory = true)]
        [ValidateNotNullOrEmpty]
        public string FriendlyName { get; set; }

        /// <summary>
        ///     Gets or sets friendly name of classification.
        /// </summary>
        [Parameter(
            ParameterSetName = ASRParameterSets.ByObjectWithName,
            Mandatory = true,
            ValueFromPipeline = true)]
        [Parameter(
            ParameterSetName = ASRParameterSets.ByObjectWithFriendlyName,
            Mandatory = true,
            ValueFromPipeline = true)]
        [Parameter(
            ParameterSetName = ASRParameterSets.ByFabricObject,
            Mandatory = true,
            ValueFromPipeline = true)]
        public ASRFabric Fabric { get; set; }

        /// <summary>
        ///     ProcessRecord of the command.
        /// </summary>
        public override void ExecuteSiteRecoveryCmdlet()
        {
            base.ExecuteSiteRecoveryCmdlet();

            var storageClassifications = this.RecoveryServicesClient
                .GetAzureSiteRecoveryStorageClassification();

            switch (this.ParameterSetName)
            {
                case ASRParameterSets.ByObjectWithFriendlyName:
                    storageClassifications = storageClassifications.Where(
                            item => item.Properties.FriendlyName.Equals(
                                this.FriendlyName,
                                StringComparison.InvariantCultureIgnoreCase))
                        .ToList();
                    storageClassifications = storageClassifications.Where(
                            item => item.GetFabricId()
                                .ToLower()
                                .Equals(this.Fabric.ID.ToLower()))
                        .ToList();
                    break;
                case ASRParameterSets.ByObjectWithName:
                    storageClassifications = storageClassifications.Where(
                            item => item.Name.Equals(
                                this.Name,
                                StringComparison.InvariantCultureIgnoreCase))
                        .ToList();
                    storageClassifications = storageClassifications.Where(
                            item => item.GetFabricId()
                                .ToLower()
                                .Equals(this.Fabric.ID.ToLower()))
                        .ToList();
                    break;
                case ASRParameterSets.ByFabricObject:
                    storageClassifications = storageClassifications.Where(
                            item => item.GetFabricId()
                                .ToLower()
                                .Equals(this.Fabric.ID.ToLower()))
                        .ToList();
                    break;
            }

            var psObject = storageClassifications.ConvertAll(
                item =>
                {
                    return new ASRStorageClassification
                    {
                        FriendlyName = item.Properties.FriendlyName,
                        Id = item.Id,
                        Name = item.Name
                    };
                });

            this.WriteObject(
                psObject,
                true);
        }
    }
}