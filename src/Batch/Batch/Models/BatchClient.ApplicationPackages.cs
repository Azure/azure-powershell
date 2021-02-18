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
using System.Threading.Tasks;
using Microsoft.Rest.Azure;

namespace Microsoft.Azure.Commands.Batch.Models
{
    public partial class BatchClient
    {
<<<<<<< HEAD
        public virtual void DeleteApplicationPackage(string resourceGroupName, string accountName, string applicationId, string version)
=======
        public virtual void DeleteApplicationPackage(string resourceGroupName, string accountName, string applicationName, string version)
>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a
        {
            if (string.IsNullOrEmpty(resourceGroupName))
            {
                // use resource mgr to see if account exists and then use resource group name to do the actual lookup
                resourceGroupName = GetGroupForAccount(accountName);
            }

<<<<<<< HEAD
            BatchManagementClient.ApplicationPackage.Delete(resourceGroupName, accountName, applicationId, version);
        }

        public virtual PSApplicationPackage GetApplicationPackage(string resourceGroupName, string accountName, string applicationId, string version)
=======
            BatchManagementClient.ApplicationPackage.Delete(resourceGroupName, accountName, applicationName, version);
        }

        public virtual PSApplicationPackage GetApplicationPackage(string resourceGroupName, string accountName, string applicationName, string version)
>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a
        {
            // single account lookup - find its resource group if not specified
            if (string.IsNullOrEmpty(resourceGroupName))
            {
                resourceGroupName = GetGroupForAccount(accountName);
            }

            var response = BatchManagementClient.ApplicationPackage.Get(
                resourceGroupName,
                accountName,
<<<<<<< HEAD
                applicationId,
=======
                applicationName,
>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a
                version);

            return ConvertGetApplicationPackageResponseToApplicationPackage(response);
        }

<<<<<<< HEAD
        public virtual PSApplicationPackage UploadAndActivateApplicationPackage(
            string resourceGroupName,
            string accountName,
            string applicationId,
=======
        public virtual IEnumerable<PSApplicationPackage> ListApplicationPackages(string resourceGroupName, string accountName, string applicationName)
        {
            if (string.IsNullOrEmpty(resourceGroupName))
            {
                // use resource mgr to see if account exists and then use resource group name to do the actual lookup
                resourceGroupName = GetGroupForAccount(accountName);
            }

            IPage<ApplicationPackage> response = BatchManagementClient.ApplicationPackage.List(resourceGroupName, accountName, applicationName);
            List<PSApplicationPackage> psApplicationPackages = response.Select(ConvertGetApplicationPackageResponseToApplicationPackage).ToList();

            string nextLink = response.NextPageLink;
            while (nextLink != null)
            {
                response = BatchManagementClient.ApplicationPackage.ListNext(nextLink);
                psApplicationPackages.AddRange(response.Select(ConvertGetApplicationPackageResponseToApplicationPackage));
                nextLink = response.NextPageLink;
            }

            return psApplicationPackages;
        }

        public virtual PSApplicationPackage UploadAndActivateApplicationPackage(
            string resourceGroupName,
            string accountName,
            string applicationName,
>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a
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
<<<<<<< HEAD
                ActivateApplicationPackage(resourceGroupName, accountName, applicationId, version, format, Resources.FailedToActivate);
=======
                ActivateApplicationPackage(resourceGroupName, accountName, applicationName, version, format, Resources.FailedToActivate);
>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a
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

<<<<<<< HEAD
                var storageUrl = GetStorageUrl(resourceGroupName, accountName, applicationId, version, out appPackageAlreadyExists);

                if (appPackageAlreadyExists)
                {
                    CheckApplicationAllowsUpdates(resourceGroupName, accountName, applicationId, version);
                }

                UploadFileToApplicationPackage(resourceGroupName, accountName, applicationId, version, filePath, storageUrl, appPackageAlreadyExists);

                ActivateApplicationPackage(resourceGroupName, accountName, applicationId, version, format, Resources.UploadedApplicationButFailedToActivate);
            }

            return GetApplicationPackage(resourceGroupName, accountName, applicationId, version);
=======
                var storageUrl = GetStorageUrl(resourceGroupName, accountName, applicationName, version, out appPackageAlreadyExists);

                if (appPackageAlreadyExists)
                {
                    CheckApplicationAllowsUpdates(resourceGroupName, accountName, applicationName, version);
                }

                UploadFileToApplicationPackage(resourceGroupName, accountName, applicationName, version, filePath, storageUrl, appPackageAlreadyExists);

                ActivateApplicationPackage(resourceGroupName, accountName, applicationName, version, format, Resources.UploadedApplicationButFailedToActivate);
            }

            return GetApplicationPackage(resourceGroupName, accountName, applicationName, version);
>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a
        }

        private void UploadFileToApplicationPackage(
            string resourceGroupName,
            string accountName,
<<<<<<< HEAD
            string applicationId,
=======
            string applicationName,
>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a
            string version,
            string filePath,
            string storageUrl,
            bool appPackageAlreadyExists)
        {
            try
            {
                var blob = new CloudBlockBlob(new Uri(storageUrl));
// TODO: Remove IfDef
#if NETSTANDARD
                Task.Run(() => blob.UploadFromFileAsync(filePath)).Wait();
#else
                blob.UploadFromFile(filePath, FileMode.Open);
#endif
            }
            catch (Exception exception)
            {
                // If the application package has already been created we don't want to delete the application package mysteriously.
                if (appPackageAlreadyExists)
                {
                    // If we are creating a new application package and the upload fails we should delete the application package.
                    try
                    {
<<<<<<< HEAD
                        DeleteApplicationPackage(resourceGroupName, accountName, applicationId, version);
=======
                        DeleteApplicationPackage(resourceGroupName, accountName, applicationName, version);
>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a
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

<<<<<<< HEAD
        private void ActivateApplicationPackage(string resourceGroupName, string accountName, string applicationId, string version, string format, string errorMessageFormat)
=======
        private void ActivateApplicationPackage(string resourceGroupName, string accountName, string applicationName, string version, string format, string errorMessageFormat)
>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a
        {
            try
            {
                BatchManagementClient.ApplicationPackage.Activate(
                    resourceGroupName,
                    accountName,
<<<<<<< HEAD
                    applicationId,
=======
                    applicationName,
>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a
                    version,
                    format);
            }
            catch (Exception exception)
            {
<<<<<<< HEAD
                var message = string.Format(errorMessageFormat, applicationId, version, exception.Message);
=======
                var message = string.Format(errorMessageFormat, applicationName, version, exception.Message);
>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a
                throw new NewApplicationPackageException(message, exception);
            }
        }

<<<<<<< HEAD
        private string GetStorageUrl(string resourceGroupName, string accountName, string applicationId, string version, out bool didCreateAppPackage)
=======
        private string GetStorageUrl(string resourceGroupName, string accountName, string applicationName, string version, out bool didCreateAppPackage)
>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a
        {
            try
            {
                // Checks to see if the package exists
                var response = BatchManagementClient.ApplicationPackage.Get(
                    resourceGroupName,
                    accountName,
<<<<<<< HEAD
                    applicationId,
=======
                    applicationName,
>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a
                    version);

                didCreateAppPackage = false;
                return response.StorageUrl;
            }
            catch (CloudException exception)
            {
                // If the application package is not found we want to create a new application package.
                if (exception.Response.StatusCode != HttpStatusCode.NotFound)
                {
<<<<<<< HEAD
                    var message = string.Format(Resources.FailedToGetApplicationPackage, applicationId, version, exception.Message);
=======
                    var message = string.Format(Resources.FailedToGetApplicationPackage, applicationName, version, exception.Message);
>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a
                    throw new CloudException(message, exception);
                }
            }

            try
            {
                var addResponse = BatchManagementClient.ApplicationPackage.Create(
                    resourceGroupName,
                    accountName,
<<<<<<< HEAD
                    applicationId,
=======
                    applicationName,
>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a
                    version);

                // If Application was created we need to return a flag.
                didCreateAppPackage = true;
                return addResponse.StorageUrl;
            }
            catch (Exception exception)
            {
<<<<<<< HEAD
                var message = string.Format(Resources.FailedToAddApplicationPackage, applicationId, version, exception.Message);
=======
                var message = string.Format(Resources.FailedToAddApplicationPackage, applicationName, version, exception.Message);
>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a
                throw new NewApplicationPackageException(message, exception);
            }
        }

        private static PSApplicationPackage ConvertGetApplicationPackageResponseToApplicationPackage(ApplicationPackage response)
        {
            return new PSApplicationPackage
            {
                Format = response.Format,
                StorageUrl = response.StorageUrl,
<<<<<<< HEAD
                StorageUrlExpiry = response.StorageUrlExpiry.Value,
                State = response.State.Value,
                Id = response.Id,
                Version = response.Version,
                LastActivationTime = response.LastActivationTime
            };
        }

        private static IList<PSApplicationPackage> ConvertApplicationPackagesToPsApplicationPackages(IEnumerable<ApplicationPackage> applicationPackages)
        {
            return applicationPackages.Select(applicationPackage => new PSApplicationPackage
            {
                Format = applicationPackage.Format,
                LastActivationTime = applicationPackage.LastActivationTime,
                State = applicationPackage.State.Value,
                Version = applicationPackage.Version
            }).ToList();
        }
=======
                StorageUrlExpiry = response.StorageUrlExpiry,
                State = response.State.Value,
                Id = response.Id,
                Name = response.Name,
                LastActivationTime = response.LastActivationTime
            };
        }
>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a
    }
}
