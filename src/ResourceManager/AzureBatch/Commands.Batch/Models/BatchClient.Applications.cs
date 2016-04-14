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
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;

using Hyak.Common;

using Microsoft.Azure.Management.Batch;
using Microsoft.Azure.Management.Batch.Models;
using Microsoft.WindowsAzure.Storage.Blob;

namespace Microsoft.Azure.Commands.Batch.Models
{
    public partial class BatchClient
    {
        public virtual PSApplication AddApplication(string resourceGroupName, string accountName, string applicationId, bool? allowUpdates, string displayName)
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

            if (allowUpdates != null)
            {
                addApplicationParameters.AllowUpdates = (bool)allowUpdates;
            }

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

            return this.ConvertGetApplicationPackageResponseToApplicationPackage(response);
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
            bool? allowUpdates,
            string defaultVersion,
            string displayName)
        {
            if (string.IsNullOrEmpty(resourceGroupName))
            {
                // use resource mgr to see if account exists and then use resource group name to do the actual lookup
                resourceGroupName = GetGroupForAccount(accountName);
            }

            UpdateApplicationParameters uap = new UpdateApplicationParameters();

            if (allowUpdates != null)
            {
                uap.AllowUpdates = (bool)allowUpdates;
            }

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
                throw new FileNotFoundException("File not found", filePath);
            }

            if (string.IsNullOrEmpty(resourceGroupName))
            {
                // use resource mgr to see if account exists and then use resource group name to do the actual lookup
                resourceGroupName = GetGroupForAccount(accountName);
            }

            bool appPackageAlreadyExists;
            var storageUrl = this.GetStorageUrl(resourceGroupName, accountName, applicationId, version, out appPackageAlreadyExists);

            try
            {
                CloudBlockBlob blob = new CloudBlockBlob(new Uri(storageUrl));
                blob.UploadFromFile(filePath, FileMode.Open);

                BatchManagementClient.Applications.ActivateApplicationPackage(resourceGroupName, accountName, applicationId, version, new ActivateApplicationPackageParameters { Format = format });
            }
            catch
            {
                // If the application package has already been created we don't want to delete the application package mysteriously.
                if (appPackageAlreadyExists)
                {
                    // If we are creating a new application package and the upload fails we should delete the application package.
                    this.DeleteApplicationPackage(resourceGroupName, accountName, applicationId, version);
                }

                // Need to throw if we fail to upload the file's content.
                throw;
            }

            return this.GetApplicationPackage(resourceGroupName, accountName, applicationId, version);
        }

        private string GetStorageUrl(string resourceGroupName, string accountName, string applicationId, string version, out bool didCreateAppPackage)
        {
            try
            {
                // Checks to see if the package exists
                GetApplicationPackageResponse response = BatchManagementClient.Applications.GetApplicationPackage(
                    resourceGroupName,
                    accountName,
                    applicationId,
                    version);

                didCreateAppPackage = false;
                return response.StorageUrl;
            }
            catch (CloudException exception)
            {
                if (exception.Response.StatusCode != HttpStatusCode.NotFound)
                {
                    throw;
                }
            }

            AddApplicationPackageResponse addResponse = BatchManagementClient.Applications.AddApplicationPackage(
                resourceGroupName,
                accountName,
                applicationId,
                version);

            // If Application was created be created we need to return.
            didCreateAppPackage = true;
            return addResponse.StorageUrl;
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
                ApplicationPackages = ConvertApplicationPackage(application.ApplicationPackages),
                DefaultVersion = application.DefaultVersion,
                DisplayName = application.DisplayName,
                Id = application.Id,
            };
        }

        private static IList<PSApplicationPackage> ConvertApplicationPackage(IList<ApplicationPackage> applicationPackages)
        {
            return applicationPackages.Select(applicationPackage => new PSApplicationPackage
            {
                Format = applicationPackage.Format,
                LastActivationTime = applicationPackage.LastActivationTime,
                State = applicationPackage.State,
                Version = applicationPackage.Version,
            }).ToList();
        }
    }
}
