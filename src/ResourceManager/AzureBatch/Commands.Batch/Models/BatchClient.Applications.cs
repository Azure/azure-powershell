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
using System.Net;

using Hyak.Common;

using Microsoft.Azure.Commands.Tags.Model;
using Microsoft.Azure.Management.Batch;
using Microsoft.Azure.Management.Batch.Models;
using Microsoft.WindowsAzure.Storage.Blob;

namespace Microsoft.Azure.Commands.Batch.Models
{
    public partial class BatchClient
    {
        public virtual PSApplication AddApplication(string resourceGroupName, string accountName, string applicationId, bool allowUpdates, string displayName)
        {
            if (string.IsNullOrEmpty(resourceGroupName))
            {
                // use resource mgr to see if account exists and then use resource group name to do the actual lookup
                resourceGroupName = GetGroupForAccount(accountName);
            }

            AddApplicationParameters addApplicationParameters = new AddApplicationParameters();

            if (displayName != null)
            {
                addApplicationParameters.DisplayName = displayName;
            }

            addApplicationParameters.AllowUpdates = allowUpdates;

            AddApplicationResponse response = BatchManagementClient.Applications.AddApplication(
                resourceGroupName,
                accountName,
                applicationId,
                addApplicationParameters);

            return ConvertApplicationToPSApplication(response.Application);
        }

        public virtual AzureOperationResponse DeleteApplication(string resourceGroupName, string accountName, string applicationId)
        {
            if (string.IsNullOrEmpty(resourceGroupName))
            {
                // use resource mgr to see if account exists and then use resource group name to do the actual lookup
                resourceGroupName = GetGroupForAccount(accountName);
            }

            return BatchManagementClient.Applications.DeleteApplication(resourceGroupName, accountName, applicationId);
        }

        public virtual AzureOperationResponse DeleteApplicationPackage(string resourceGroupName, string accountName, string applicationId, string version)
        {
            if (string.IsNullOrEmpty(resourceGroupName))
            {
                // use resource mgr to see if account exists and then use resource group name to do the actual lookup
                resourceGroupName = GetGroupForAccount(accountName);
            }

            return BatchManagementClient.Applications.DeleteApplicationPackage(resourceGroupName, accountName, applicationId, version);
        }

        public virtual PSApplication GetApplication(string resourceGroupName, string accountName, string applicationId)
        {
            // single account lookup - find its resource group if not specified
            if (string.IsNullOrEmpty(resourceGroupName))
            {
                resourceGroupName = GetGroupForAccount(accountName);
            }

            GetApplicationResponse response = BatchManagementClient.Applications.GetApplication(resourceGroupName, accountName, applicationId);

            return ConvertApplicationToPSApplication(response.Application);
        }

        public virtual PSApplicationPackage GetApplicationPackage(string resourceGroupName, string accountName, string applicationId, string version)
        {
            // single account lookup - find its resource group if not specified
            if (string.IsNullOrEmpty(resourceGroupName))
            {
                resourceGroupName = GetGroupForAccount(accountName);
            }

            GetApplicationPackageResponse response = BatchManagementClient.Applications.GetApplicationPackage(
                resourceGroupName,
                accountName,
                applicationId,
                version);


            PSApplicationPackage applicationPackage = this.ConvertGetApplicationPackageResponseToApplicationPackage(response);
            return applicationPackage;
        }

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

        public virtual AzureOperationResponse UpdateApplication(
            string resourceGroupName,
            string accountName,
            string applicationId,
            bool allowUpdates,
            string defaultVersion,
            string displayName)
        {
            if (string.IsNullOrEmpty(resourceGroupName))
            {
                // use resource mgr to see if account exists and then use resource group name to do the actual lookup
                resourceGroupName = GetGroupForAccount(accountName);
            }

            UpdateApplicationParameters uap = new UpdateApplicationParameters { AllowUpdates = allowUpdates };

            if (defaultVersion != null)
            {
                uap.DefaultVersion = defaultVersion;
            }

            if (displayName != null)
            {
                uap.DisplayName = displayName;
            }

            return BatchManagementClient.Applications.UpdateApplication(
                resourceGroupName,
                accountName,
                applicationId,
                uap);
        }

        public virtual PSApplicationPackage AddAndUploadApplicationPackage(
            string resourceGroupName,
            string accountName,
            string applicationId,
            string version,
            string filePath,
            string format)
        {
            if (!File.Exists(filePath))
            {
                throw new FileNotFoundException("File not found: " + filePath);
            }

            if (string.IsNullOrEmpty(resourceGroupName))
            {
                // use resource mgr to see if account exists and then use resource group name to do the actual lookup
                resourceGroupName = GetGroupForAccount(accountName);
            }

            AddApplicationPackageResponse response = BatchManagementClient.Applications.AddApplicationPackage(
                resourceGroupName,
                accountName,
                applicationId,
                version);

            CloudBlockBlob blob = new CloudBlockBlob(new Uri(response.StorageUrl));

            try
            {
                blob.UploadFromFile(filePath, FileMode.Open);

                BatchManagementClient.Applications.ActivateApplicationPackage(
                    resourceGroupName,
                    accountName,
                    applicationId,
                    version,
                    new ActivateApplicationPackageParameters { Format = format });
            }
            catch
            {
                this.DeleteApplicationPackage(resourceGroupName, accountName, applicationId, version);
                throw;
            }

            PSApplicationPackage getResponse = this.GetApplicationPackage(resourceGroupName, accountName, applicationId, version);

            return getResponse;
        }


        public virtual PSApplicationPackage UploadApplicationPackage(
            string resourceGroupName,
            string accountName,
            string applicationId,
            string version,
            string filePath,
            string format)
        {
            if (!File.Exists(filePath))
            {
                throw new FileNotFoundException("File not found: " + filePath);
            }

            if (string.IsNullOrEmpty(resourceGroupName))
            {
                // use resource mgr to see if account exists and then use resource group name to do the actual lookup
                resourceGroupName = GetGroupForAccount(accountName);
            }
            
            bool needToCreateAnApplicationPackage;
            var storageUrl = GetStorageUrl(resourceGroupName, accountName, applicationId, version, out needToCreateAnApplicationPackage);

            try
            {
                CloudBlockBlob blob = new CloudBlockBlob(new Uri(storageUrl));
                blob.UploadFromFile(filePath, FileMode.Open);

                BatchManagementClient.Applications.ActivateApplicationPackage(
                    resourceGroupName,
                    accountName,
                    applicationId,
                    version,
                    new ActivateApplicationPackageParameters { Format = format });
            }
            catch
            {
                // If the application package has already been created we don't want to delete the application package mysteriously.
                if (needToCreateAnApplicationPackage)
                {
                    // If we are creating a new application package and the upload fails we should delete the application package.
                    this.DeleteApplicationPackage(resourceGroupName, accountName, applicationId, version);
                }

                throw;
            }

            return this.GetApplicationPackage(resourceGroupName, accountName, applicationId, version);
        }

        private string GetStorageUrl(string resourceGroupName, string accountName, string applicationId, string version, out bool neededToCreateAnApplicationPackage)
        {
            string storageUrl = null;
            neededToCreateAnApplicationPackage = false;
            try
            {
                // Checks to see if the package exists
                GetApplicationPackageResponse response = BatchManagementClient.Applications.GetApplicationPackage(
                    resourceGroupName,
                    accountName,
                    applicationId,
                    version);
                storageUrl = response.StorageUrl;
            }
            catch (CloudException exception)
            {
                neededToCreateAnApplicationPackage = exception.Response.StatusCode == HttpStatusCode.NotFound;
                // This if for catching the error if we come back with HttpStatusCode.NotFound
            }

            // if package doesn't exist create a new one
            if (neededToCreateAnApplicationPackage)
            {
                AddApplicationPackageResponse addResponse = BatchManagementClient.Applications.AddApplicationPackage(
                    resourceGroupName,
                    accountName,
                    applicationId,
                    version);

                storageUrl = addResponse.StorageUrl;
            }
            return storageUrl;
        }

        private PSApplicationPackage ConvertGetApplicationPackageResponseToApplicationPackage(GetApplicationPackageResponse response)
        {
            return new PSApplicationPackage()
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
