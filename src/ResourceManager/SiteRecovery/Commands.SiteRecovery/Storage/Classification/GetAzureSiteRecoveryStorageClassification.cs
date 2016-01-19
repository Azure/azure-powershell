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
using System.Text;
using System.Threading.Tasks;
using Microsoft.Azure.Management.SiteRecovery.Models;

namespace Microsoft.Azure.Commands.SiteRecovery
{
    /// <summary>
    /// Retrieves Azure Site Recovery storage classification.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "AzureRmSiteRecoveryStorageClassification", DefaultParameterSetName = ASRParameterSets.Default)]
    [OutputType(typeof(IEnumerable<ASRStorageClassification>))]
    public class GetAzureSiteRecoveryStorageClassification : SiteRecoveryCmdletBase
    {
        /// <summary>
        /// ProcessRecord of the command.
        /// </summary>
        public override void ExecuteCmdlet()
        {
            List<Fabric> fabrics = new List<Fabric>();
            List<StorageClassification> storageClassifications = new List<StorageClassification>();
            List<StorageClassificationMapping> storageClassificationMappings
                = new List<StorageClassificationMapping>();

            Task fabricTask = RecoveryServicesClient.EnumerateFabricsAsync((entities) =>
                {
                    fabrics.AddRange(entities);
                });

            Task storageClassificationTask =
                RecoveryServicesClient.EnumerateStorageClassificationsAsync((entities) =>
                {
                    storageClassifications.AddRange(entities);
                });

            Task mappingsTask = 
                RecoveryServicesClient.EnumerateStorageClassificationMappingsAsync((entities) =>
                {
                    storageClassificationMappings.AddRange(entities);
                });

            Task.WaitAll(fabricTask, storageClassificationTask, mappingsTask);

            var fabricMap = fabrics.ToDictionary(item => item.Id, item => item);
            var classificationMap = storageClassifications
                .ToDictionary(item => item.Id, item => item);
            var mappingsDict = storageClassificationMappings
                .GroupBy(item => item.GetPrimaryStorageClassificationId())
                .ToDictionary(item => item.Key, item => item.ToList());

            List<ASRStorageClassification> psStorageClassifications
                = new List<ASRStorageClassification>();

            var psObject = storageClassifications.ConvertAll(item => 
                item.GetPSObject(classificationMap, fabricMap, mappingsDict));

            base.WriteObject(psObject);
        }
    }
}
