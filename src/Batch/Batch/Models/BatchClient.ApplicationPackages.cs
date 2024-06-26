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
        public virtual void DeleteApplicationPackage(string resourceGroupName, string accountName, string applicationName, string version)
        {
            if (string.IsNullOrEmpty(resourceGroupName))
            {
                // use resource mgr to see if account exists and then use resource group name to do the actual lookup
                resourceGroupName = GetGroupForAccount(accountName);
            }

            BatchManagementClient.ApplicationPackage.Delete(resourceGroupName, accountName, applicationName, version);
        }

        public virtual PSApplicationPackage GetApplicationPackage(string resourceGroupName, string accountName, string applicationName, string version)
        {
            // single account lookup - find its resource group if not specified
            if (string.IsNullOrEmpty(resourceGroupName))
            {
                resourceGroupName = GetGroupForAccount(accountName);
            }

            var response = BatchManagementClient.ApplicationPackage.Get(
                resourceGroupName,
                accountName,
                applicationName,
                version);

            return ConvertGetApplicationPackageResponseToApplicationPackage(response);
        }

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
                ActivateApplicationPackage(resourceGroupName, accountName, applicationName, version, format, Resources.FailedToActivate);
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

                var storageUrl = GetStorageUrl(resourceGroupName, accountName, applicationName, version, out appPackageAlreadyExists);

                if (appPackageAlreadyExists)
                {
                    CheckApplicationAllowsUpdates(resourceGroupName, accountName, applicationName, version);
                }

                UploadFileToApplicationPackage(resourceGroupName, accountName, applicationName, version, filePath, storageUrl, appPackageAlreadyExists);

                ActivateApplicationPackage(resourceGroupName, accountName, applicationName, version, format, Resources.UploadedApplicationButFailedToActivate);
            }

            return GetApplicationPackage(resourceGroupName, accountName, applicationName, version);
        }

        private void UploadFileToApplicationPackage(
            string resourceGroupName,
            string accountName,
            string applicationName,
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
                        DeleteApplicationPackage(resourceGroupName, accountName, applicationName, version);
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

        private void ActivateApplicationPackage(string resourceGroupName, string accountName, string applicationName, string version, string format, string errorMessageFormat)
        {
            try
            {
                BatchManagementClient.ApplicationPackage.Activate(
                    resourceGroupName,
                    accountName,
                    applicationName,
                    version,
                    format);
            }
            catch (Exception exception)
            {
                var message = string.Format(errorMessageFormat, applicationName, version, exception.Message);
                throw new NewApplicationPackageException(message, exception);
            }
        }

        private string GetStorageUrl(string resourceGroupName, string accountName, string applicationName, string version, out bool appPackageAlreadyExists)
        {
            try
            {
                // Checks to see if the package exists
                var response = BatchManagementClient.ApplicationPackage.Get(
                    resourceGroupName,
                    accountName,
                    applicationName,
                    version);

                appPackageAlreadyExists = true;
                return response.StorageUrl;
            }
            catch (CloudException exception)
            {
                // If the application package is not found we want to create a new application package.
                if (exception.Response.StatusCode != HttpStatusCode.NotFound)
                {
                    var message = string.Format(Resources.FailedToGetApplicationPackage, applicationName, version, exception.Message);
                    throw new CloudException(message, exception);
                }
            }

            try
            {
                var addResponse = BatchManagementClient.ApplicationPackage.Create(
                    resourceGroupName,
                    accountName,
                    applicationName,
                    version);

                //Package didn't exist before we created it
                appPackageAlreadyExists = false;
                return addResponse.StorageUrl;
            }
            catch (Exception exception)
            {
                var message = string.Format(Resources.FailedToAddApplicationPackage, applicationName, version, exception.Message);
                throw new NewApplicationPackageException(message, exception);
            }
        }

        private static PSApplicationPackage ConvertGetApplicationPackageResponseToApplicationPackage(ApplicationPackage response)
        {
            return new PSApplicationPackage
            {
                Format = response.Format,
                StorageUrl = response.StorageUrl,
                StorageUrlExpiry = response.StorageUrlExpiry,
                State = response.State.Value,
                Id = response.Id,
                Name = response.Name,
                LastActivationTime = response.LastActivationTime
            };
        }
    }
}
