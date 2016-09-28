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

using Microsoft.Azure.Commands.Batch.Properties;
using Microsoft.Azure.Management.Batch;
using Microsoft.Azure.Management.Batch.Models;
using Microsoft.WindowsAzure.Storage.Blob;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using Microsoft.Rest.Azure;

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

            AddApplicationParameters addApplicationParameters = new AddApplicationParameters()
            {
                DisplayName = displayName,
                AllowUpdates = allowUpdates
            };

             var response = BatchManagementClient.Application.AddApplication(
                resourceGroupName,
                accountName,
                applicationId,
                addApplicationParameters);

            return ConvertApplicationToPSApplication(response);
        }

        public virtual void DeleteApplication(string resourceGroupName, string accountName, string applicationId)
        {
            if (string.IsNullOrEmpty(resourceGroupName))
            {
                // use resource mgr to see if account exists and then use resource group name to do the actual lookup
                resourceGroupName = GetGroupForAccount(accountName);
            }

            BatchManagementClient.Application.DeleteApplication(resourceGroupName, accountName, applicationId);
        }

        public virtual void DeleteApplicationPackage(string resourceGroupName, string accountName, string applicationId, string version)
        {
            if (string.IsNullOrEmpty(resourceGroupName))
            {
                // use resource mgr to see if account exists and then use resource group name to do the actual lookup
                resourceGroupName = GetGroupForAccount(accountName);
            }

            BatchManagementClient.Application.DeleteApplicationPackage(resourceGroupName, accountName, applicationId, version);
        }

        public virtual PSApplication GetApplication(string resourceGroupName, string accountName, string applicationId)
        {
            // single account lookup - find its resource group if not specified
            if (string.IsNullOrEmpty(resourceGroupName))
            {
                resourceGroupName = GetGroupForAccount(accountName);
            }

            Application response = BatchManagementClient.Application.GetApplication(resourceGroupName, accountName, applicationId);

            return ConvertApplicationToPSApplication(response);
        }

        public virtual PSApplicationPackage GetApplicationPackage(string resourceGroupName, string accountName, string applicationId, string version)
        {
            // single account lookup - find its resource group if not specified
            if (string.IsNullOrEmpty(resourceGroupName))
            {
                resourceGroupName = GetGroupForAccount(accountName);
            }

            GetApplicationPackageResult response = BatchManagementClient.Application.GetApplicationPackage(
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

            IPage<Application> response = BatchManagementClient.Application.List(resourceGroupName, accountName);
            List<PSApplication> psApplications = response.Select(ConvertApplicationToPSApplication).ToList();

            string nextLink = response.NextPageLink;
            while (nextLink != null)
            {
                response = BatchManagementClient.Application.ListNext(nextLink);
                psApplications.AddRange(response.Select(ConvertApplicationToPSApplication));
                nextLink = response.NextPageLink;
            }

            return psApplications;
        }

        public virtual void UpdateApplication(
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
                uap.AllowUpdates = allowUpdates;
            }

            if (defaultVersion != null)
            {
                uap.DefaultVersion = defaultVersion;
            }

            if (displayName != null)
            {
                uap.DisplayName = displayName;
            }

            BatchManagementClient.Application.UpdateApplication(
                resourceGroupName,
                accountName,
                applicationId,
                uap);
        }

        public virtual PSApplicationPackage UploadAndActivateApplicationPackage(
            string resourceGroupName,
            string accountName,
            string applicationId,
            string version,
            string filePath,
            string format,
            bool activateOnly)
        {
            if (string.IsNullOrEmpty(resourceGroupName))
            {
                // use resource mgr to see if account exists and then use resource group name to do the actual lookup
                resourceGroupName = GetGroupForAccount(accountName);
            }

            if (activateOnly)
            {
                // If the package has already been uploaded but wasn't activated.
                ActivateApplicationPackage(resourceGroupName, accountName, applicationId, version, format, Resources.FailedToActivate);
            }
            else
            {
                if (string.IsNullOrEmpty(filePath))
                {
                    throw new ArgumentNullException("filePath", Resources.NewApplicationPackageNoPathSpecified);
                }

                if (!File.Exists(filePath))
                {
                    throw new FileNotFoundException(string.Format(Resources.FileNotFound, filePath), filePath);
                }

                // Else create Application Package and upload.
                bool appPackageAlreadyExists;

                var storageUrl = GetStorageUrl(resourceGroupName, accountName, applicationId, version, out appPackageAlreadyExists);

                if (appPackageAlreadyExists)
                {
                    CheckApplicationAllowsUpdates(resourceGroupName, accountName, applicationId, version);
                }

                UploadFileToApplicationPackage(resourceGroupName, accountName, applicationId, version, filePath, storageUrl, appPackageAlreadyExists);

                ActivateApplicationPackage(resourceGroupName, accountName, applicationId, version, format, Resources.UploadedApplicationButFailedToActivate);
            }

            return GetApplicationPackage(resourceGroupName, accountName, applicationId, version);
        }

        private void CheckApplicationAllowsUpdates(string resourceGroupName, string accountName, string applicationId, string version)
        {
            try
            {
                PSApplication psApplication = this.GetApplication(resourceGroupName, accountName, applicationId);

                if (psApplication.AllowUpdates == false)
                {
                    var allowUpdateErrorMessage = string.Format(Resources.ApplicationDoesNotAllowUpdates, applicationId, version);
                    throw new NewApplicationPackageException(allowUpdateErrorMessage);
                }
            }
            catch (CloudException exception)
            {
                var errorMessage = string.Format(Resources.FailedToCheckApplication, applicationId, version, exception);
                throw new CloudException(errorMessage, exception);
            }
        }

        private void UploadFileToApplicationPackage(
            string resourceGroupName,
            string accountName,
            string applicationId,
            string version,
            string filePath,
            string storageUrl,
            bool appPackageAlreadyExists)
        {
            try
            {
                CloudBlockBlob blob = new CloudBlockBlob(new Uri(storageUrl));
                blob.UploadFromFile(filePath, FileMode.Open);
            }
            catch (Exception exception)
            {
                // If the application package has already been created we don't want to delete the application package mysteriously.
                if (appPackageAlreadyExists)
                {
                    // If we are creating a new application package and the upload fails we should delete the application package.
                    try
                    {
                        DeleteApplicationPackage(resourceGroupName, accountName, applicationId, version);
                    }
                    catch
                    {
                        // Need to throw if we fail to delete the application while attempting to clean it up.
                        var deleteMessage = string.Format(Resources.FailedToUploadAndDelete, filePath, exception.Message);
                        throw new NewApplicationPackageException(deleteMessage, exception);
                    }
                }

                // Need to throw if we fail to upload the file's content.
                var uploadMessage = string.Format(Resources.FailedToUpload, filePath, exception.Message);
                throw new NewApplicationPackageException(uploadMessage, exception);
            }
        }

        private void ActivateApplicationPackage(string resourceGroupName, string accountName, string applicationId, string version, string format, string errorMessageFormat)
        {
            try
            {
                BatchManagementClient.Application.ActivateApplicationPackage(
                    resourceGroupName,
                    accountName,
                    applicationId,
                    version,
                    new ActivateApplicationPackageParameters { Format = format });
            }
            catch (Exception exception)
            {
                string message = string.Format(errorMessageFormat, applicationId, version, exception.Message);
                throw new NewApplicationPackageException(message, exception);
            }
        }

        private string GetStorageUrl(string resourceGroupName, string accountName, string applicationId, string version, out bool didCreateAppPackage)
        {
            try
            {
                // Checks to see if the package exists
                GetApplicationPackageResult response = BatchManagementClient.Application.GetApplicationPackage(
                    resourceGroupName,
                    accountName,
                    applicationId,
                    version);

                didCreateAppPackage = false;
                return response.StorageUrl;
            }
            catch (CloudException exception)
            {
                // If the application package is not found we want to create a new application package.
                if (exception.Response.StatusCode != HttpStatusCode.NotFound)
                {
                    var message = string.Format(Resources.FailedToGetApplicationPackage, applicationId, version, exception.Message);
                    throw new CloudException(message, exception);
                }
            }

            try
            {
                AddApplicationPackageResult addResponse = BatchManagementClient.Application.AddApplicationPackage(
                    resourceGroupName,
                    accountName,
                    applicationId,
                    version);

                // If Application was created we need to return a flag.
                didCreateAppPackage = true;
                return addResponse.StorageUrl;
            }
            catch (Exception exception)
            {
                var message = string.Format(Resources.FailedToAddApplicationPackage, applicationId, version, exception.Message);
                throw new NewApplicationPackageException(message, exception);
            }
        }

        private PSApplicationPackage ConvertGetApplicationPackageResponseToApplicationPackage(GetApplicationPackageResult response)
        {
            return new PSApplicationPackage()
            {
                Format = response.Format,
                StorageUrl = response.StorageUrl,
                StorageUrlExpiry = response.StorageUrlExpiry.Value,
                State = response.State.Value,
                Id = response.Id,
                Version = response.Version,
                LastActivationTime = response.LastActivationTime,
            };
        }

        private static PSApplication ConvertApplicationToPSApplication(Application application)
        {
            return new PSApplication()
            {
                AllowUpdates = application.AllowUpdates.Value,
                ApplicationPackages = ConvertApplicationPackagesToPsApplicationPackages(application.Packages),
                DefaultVersion = application.DefaultVersion,
                DisplayName = application.DisplayName,
                Id = application.Id,
            };
        }

        private static IList<PSApplicationPackage> ConvertApplicationPackagesToPsApplicationPackages(IEnumerable<ApplicationPackage> applicationPackages)
        {
            return applicationPackages.Select(applicationPackage => new PSApplicationPackage
            {
                Format = applicationPackage.Format,
                LastActivationTime = applicationPackage.LastActivationTime,
                State = applicationPackage.State.Value,
                Version = applicationPackage.Version,
            }).ToList();
        }
    }
}
