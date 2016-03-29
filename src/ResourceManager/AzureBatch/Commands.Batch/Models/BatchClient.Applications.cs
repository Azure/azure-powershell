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
using System.IO;
using System.Linq;

using Microsoft.Azure.Commands.Tags.Model;
using Microsoft.Azure.Management.Batch;
using Microsoft.Azure.Management.Batch.Models;
using Microsoft.WindowsAzure.Storage.Blob;

namespace Microsoft.Azure.Commands.Batch.Models
{
    public partial class BatchClient
    {

        /// <summary>
        /// TODO: IVAN
        /// </summary>
        /// <param name="resourceGroupName"></param>
        /// <param name="accountName"></param>
        /// <param name="applicationId"></param>
        /// <param name="allowUpdates"></param>
        /// <param name="displayName"></param>
        /// <returns></returns>
        public virtual PSApplication AddApplication(string resourceGroupName, string accountName, string applicationId, bool allowUpdates, string displayName)
        {
            if (string.IsNullOrEmpty(resourceGroupName))
            {
                // use resource mgr to see if account exists and then use resource group name to do the actual lookup
                resourceGroupName = GetGroupForAccount(accountName);
            }

            AddApplicationResponse response = BatchManagementClient.Applications.AddApplication(
                resourceGroupName,
                accountName,
                applicationId,
                new AddApplicationParameters() { AllowUpdates = allowUpdates, DisplayName = displayName });

            return ConvertApplicationToPSApplication(response.Application);
        }

        /// <summary>
        /// TODO: IVAN
        /// </summary>
        /// <param name="resourceGroupName"></param>
        /// <param name="accountName"></param>
        /// <param name="applicationId"></param>
        /// <returns></returns>
        public virtual AzureOperationResponse DeleteApplication(string resourceGroupName, string accountName, string applicationId)
        {
            if (string.IsNullOrEmpty(resourceGroupName))
            {
                // use resource mgr to see if account exists and then use resource group name to do the actual lookup
                resourceGroupName = GetGroupForAccount(accountName);
            }

            return BatchManagementClient.Applications.DeleteApplication(resourceGroupName, accountName, applicationId);
        }

        /// <summary>
        /// TODO: IVAN
        /// </summary>
        /// <param name="resourceGroupName"></param>
        /// <param name="accountName"></param>
        /// <param name="applicationId"></param>
        /// <param name="version"></param>
        /// <returns></returns>
        public virtual AzureOperationResponse DeleteApplicationPackage(string resourceGroupName, string accountName, string applicationId, string version)
        {
            if (string.IsNullOrEmpty(resourceGroupName))
            {
                // use resource mgr to see if account exists and then use resource group name to do the actual lookup
                resourceGroupName = GetGroupForAccount(accountName);
            }

            return BatchManagementClient.Applications.DeleteApplicationPackage(resourceGroupName, accountName, applicationId, version);
        }

        /// <summary>
        /// TODO: IVAN
        /// </summary>
        /// <param name="resourceGroupName"></param>
        /// <param name="accountName"></param>
        /// <param name="applicationId"></param>
        /// <returns></returns>
        public virtual PSApplication GetApplication(string resourceGroupName, string accountName, string applicationId)
        {
            // single account lookup - find its resource group if not specified
            if (string.IsNullOrEmpty(resourceGroupName))
            {
                resourceGroupName = GetGroupForAccount(accountName);
            }

            var response = BatchManagementClient.Applications.GetApplication(resourceGroupName, accountName, applicationId);

            return ConvertApplicationToPSApplication(response.Application);
        }

        /// <summary>
        /// TODO: IVAN
        /// </summary>
        /// <param name="resourceGroupName"></param>
        /// <param name="accountName"></param>
        /// <param name="applicationId"></param>
        /// <param name="version"></param>
        /// <returns></returns>
        public virtual PSApplicationPackage GetApplicationPackage(string resourceGroupName, string accountName, string applicationId, string version)
        {
            // single account lookup - find its resource group if not specified
            if (string.IsNullOrEmpty(resourceGroupName))
            {
                resourceGroupName = GetGroupForAccount(accountName);
            }

            GetApplicationPackageResponse response = BatchManagementClient.Applications.GetApplicationPackage(resourceGroupName, accountName, applicationId, version);

            var context = this.ConvertGetApplicationPackageResponseToApplicationPackage(response);
            return context;
        }

        /// <summary>
        /// TODO: IVAN
        /// </summary>
        /// <param name="resourceGroupName"></param>
        /// <param name="accountName"></param>
        /// <returns></returns>
        public virtual IEnumerable<PSApplication> ListApplications(string resourceGroupName, string accountName)
        {

            if (string.IsNullOrEmpty(resourceGroupName))
            {
                // use resource mgr to see if account exists and then use resource group name to do the actual lookup
                resourceGroupName = GetGroupForAccount(accountName);
            }

            ListApplicationsResponse response = BatchManagementClient.Applications.List(resourceGroupName, accountName, new ListApplicationsParameters());

            List<PSApplication> psApplications = response.Applications.Select(ConvertApplicationToPSApplication).ToList();

            string nextLink = response.NextLink;

            while (nextLink != null)
            {
                response = BatchManagementClient.Applications.ListNext(nextLink);

                psApplications.AddRange(response.Applications.Select(ConvertApplicationToPSApplication));

                nextLink = response.NextLink;
            }

            return psApplications;
        }

        /// <summary>
        /// TODO: IVAN
        /// </summary>
        /// <param name="resourceGroupName"></param>
        /// <param name="accountName"></param>
        /// <param name="applicationId"></param>
        /// <param name="allowUpdates"></param>
        /// <param name="defaultVersion"></param>
        /// <param name="displayName"></param>
        /// <returns></returns>
        public virtual AzureOperationResponse UpdateApplication(string resourceGroupName, string accountName, string applicationId, bool allowUpdates, string defaultVersion, string displayName)
        {
            if (string.IsNullOrEmpty(resourceGroupName))
            {
                // use resource mgr to see if account exists and then use resource group name to do the actual lookup
                resourceGroupName = GetGroupForAccount(accountName);
            }

            return BatchManagementClient.Applications.UpdateApplication(
                resourceGroupName,
                accountName,
                applicationId,
                new UpdateApplicationParameters() { AllowUpdates = allowUpdates, DefaultVersion = defaultVersion, DisplayName = displayName, });
        }

        /// <summary>
        /// TODO: IVAN
        /// </summary>
        /// <param name="resourceGroupName"></param>
        /// <param name="accountName"></param>
        /// <param name="applicationId"></param>
        /// <param name="version"></param>
        /// <param name="filePath"></param>
        /// <param name="format"></param>
        /// <returns></returns>
        public virtual PSApplicationPackage UploadApplicationPackage(string resourceGroupName, string accountName, string applicationId, string version, string filePath, string format)
        {
            if (string.IsNullOrEmpty(resourceGroupName))
            {
                // use resource mgr to see if account exists and then use resource group name to do the actual lookup
                resourceGroupName = GetGroupForAccount(accountName);
            }

            AddApplicationPackageResponse response = BatchManagementClient.Applications.AddApplicationPackage(resourceGroupName, accountName, applicationId, version);

            CloudBlockBlob blob = new CloudBlockBlob(new Uri(response.StorageUrl));

            blob.UploadFromFile(filePath, FileMode.Open);

            BatchManagementClient.Applications.ActivateApplicationPackage(
                resourceGroupName,
                accountName,
                applicationId,
                version,
                new ActivateApplicationPackageParameters { Format = format, });

            PSApplicationPackage getResponse = this.GetApplicationPackage(resourceGroupName, accountName, applicationId, version);

            return getResponse;
        }

        private PSApplicationPackage ConvertGetApplicationPackageResponseToApplicationPackage(GetApplicationPackageResponse response)
        {
            return new PSApplicationPackage
            {
                Format = response.Format,
                StorageUrl = response.StorageUrl,
                StorageUrlExpiry = response.StorageUrlExpiry,
                State = response.State,
                Id = response.Id,
                Version = response.Version,
                LastActivationTime = response.LastActivationTime,
            };
        }

        private static PSApplication ConvertApplicationToPSApplication(Application application)
        {
            return new PSApplication()
                       {
                           AllowUpdates = application.AllowUpdates,
                           ApplicationPackages = application.ApplicationPackages,
                           DefaultVersion = application.DefaultVersion,
                           DisplayName = application.DisplayName,
                           Id = application.Id,
                       };
        }
    }
}
