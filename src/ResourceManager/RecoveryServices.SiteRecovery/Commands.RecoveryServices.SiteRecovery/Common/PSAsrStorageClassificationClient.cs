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

using System.Collections.Generic;
using AutoMapper;
using Microsoft.Azure.Management.RecoveryServices.SiteRecovery.Models;

namespace Microsoft.Azure.Commands.RecoveryServices.SiteRecovery
{
    public partial class PSRecoveryServicesClient
    {
        /// <summary>
        ///     Gets Azure Site Recovery Storage Classification.
        /// </summary>
        /// <returns>Storage classification list response</returns>
        public List<StorageClassification> GetAzureSiteRecoveryStorageClassification()
        {
            var firstPage = this.GetSiteRecoveryClient()
                .ReplicationStorageClassifications
                .ListWithHttpMessagesAsync(this.GetRequestHeaders(true))
                .GetAwaiter()
                .GetResult()
                .Body;
            var pages = Utilities.GetAllFurtherPages(
                this.GetSiteRecoveryClient()
                    .ReplicationStorageClassifications.ListNextWithHttpMessagesAsync,
                firstPage.NextPageLink,
                this.GetRequestHeaders(true));
            pages.Insert(
                0,
                firstPage);

            return Utilities.IpageToList(pages);
        }

        /// <summary>
        ///     Gets Azure Site Recovery Storage Classification Mappings.
        /// </summary>
        /// <returns>Storage classification Mapping list response</returns>
        public List<StorageClassificationMapping> GetAzureSiteRecoveryStorageClassificationMapping()
        {
            var firstPage = this.GetSiteRecoveryClient()
                .ReplicationStorageClassificationMappings
                .ListWithHttpMessagesAsync(this.GetRequestHeaders(true))
                .GetAwaiter()
                .GetResult()
                .Body;
            var pages = Utilities.GetAllFurtherPages(
                this.GetSiteRecoveryClient()
                    .ReplicationStorageClassificationMappings.ListNextWithHttpMessagesAsync,
                firstPage.NextPageLink,
                this.GetRequestHeaders(true));
            pages.Insert(
                0,
                firstPage);

            return Utilities.IpageToList(pages);
        }

        /// <summary>
        ///     Starts job for mapping storage classification.
        /// </summary>
        /// <param name="primaryClassification">Primary classification.</param>
        /// <param name="input">Mapping input.</param>
        /// <param name="armName">Optional. ARM name of the mapping.</param>
        /// <returns>Operation response.</returns>
        public PSSiteRecoveryLongRunningOperation MapStorageClassification(
            ASRStorageClassification primaryClassification,
            StorageClassificationMappingInput input,
            string armName)
        {
            var tokens =
                primaryClassification.Id.UnFormatArmId(
                    ARMResourceIdPaths.StorageClassificationResourceIdPath);

            var op = this.GetSiteRecoveryClient()
                .ReplicationStorageClassificationMappings.BeginCreateWithHttpMessagesAsync(
                    tokens[0],
                    tokens[1],
                    armName,
                    input,
                    this.GetRequestHeaders(true))
                .GetAwaiter()
                .GetResult();
            var result = SiteRecoveryAutoMapperProfile.Mapper.Map<PSSiteRecoveryLongRunningOperation>(op);
            return result;
        }

        /// <summary>
        ///     Starts job for unmapping classifications
        /// </summary>
        /// <param name="fabricName">Fabric name name.</param>
        /// <param name="storageClassificationName">Storage classification name.</param>
        /// <param name="mappingName">Classification mapping name.</param>
        /// <returns>Operation result.</returns>
        public PSSiteRecoveryLongRunningOperation UnmapStorageClassifications(
            string fabricName,
            string storageClassificationName,
            string mappingName)
        {
            var op = this.GetSiteRecoveryClient()
                .ReplicationStorageClassificationMappings.BeginDeleteWithHttpMessagesAsync(
                    fabricName,
                    storageClassificationName,
                    mappingName,
                    this.GetRequestHeaders(true))
                .GetAwaiter()
                .GetResult();
            var result = SiteRecoveryAutoMapperProfile.Mapper.Map<PSSiteRecoveryLongRunningOperation>(op);
            return result;
        }
    }

    /// <summary>
    ///     Extension methods for Storage classification.
    /// </summary>
    public static class StorageClassificationExtensions
    {
        /// <summary>
        ///     Gets fabric Id from classification ARM Id.
        /// </summary>
        /// <param name="classification">Storage classification.</param>
        /// <returns>ARM Id of the fabric.</returns>
        public static string GetFabricId(
            this StorageClassification classification)
        {
            var tokens =
                classification.Id.UnFormatArmId(
                    ARMResourceIdPaths.StorageClassificationResourceIdPath);

            var vaultId = classification.Id.GetVaultArmId();

            return vaultId +
                   "/" +
                   string.Format(
                       ARMResourceIdPaths.FabricResourceIdPath,
                       tokens[0]);
        }

        /// <summary>
        ///     Gets primary storage classification ARM Id.
        /// </summary>
        /// <param name="mapping">Storage classification mapping input.</param>
        /// <returns>ARM Id of the primary storage classification.</returns>
        public static string GetPrimaryStorageClassificationId(
            this StorageClassificationMapping mapping)
        {
            var tokens = mapping.Id.UnFormatArmId(
                ARMResourceIdPaths.StorageClassificationMappingResourceIdPath);

            var vaultId = mapping.Id.GetVaultArmId();

            return vaultId +
                   "/" +
                   string.Format(
                       ARMResourceIdPaths.StorageClassificationResourceIdPath,
                       tokens[0],
                       tokens[1]);
        }
    }
}