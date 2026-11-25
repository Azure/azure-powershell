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

                // check to see if the application package already exists
                bool appPackageAlreadyExists = AppPackageExists(resourceGroupName, accountName, applicationName, version);

                // if it exists, verify it allows updates
                if (appPackageAlreadyExists)
                {
                    CheckApplicationAllowsUpdates(resourceGroupName, accountName, applicationName, version);
                }

                // Get the storage URL to upload the application package to by calling create/update
                ApplicationPackage package = CreateUpdateAppPackage(resourceGroupName, accountName, applicationName, version);

                UploadFileToApplicationPackage(resourceGroupName, accountName, applicationName, version, filePath, package, appPackageAlreadyExists);

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
            ApplicationPackage package,
            bool appPackageAlreadyExists)
        {
            try
            {
                var blob = new CloudBlockBlob(new Uri(package.StorageUrl));
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
                // Another upload of the same version may also have created or changed it after the check above.
                // package is null if the create returned no body; then there's no ETag, and no delete.
                if (!appPackageAlreadyExists && IsUnchangedSinceCreated(resourceGroupName, accountName, applicationName, version, package?.Etag))
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


        private bool AppPackageExists(string resourceGroupName, string accountName, string applicationName, string version)
        {
            try
            {
                // Checks to see if the package exists
                var response = BatchManagementClient.ApplicationPackage.Get(
                    resourceGroupName,
                    accountName,
                    applicationName,
                    version);

                return true;

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

            return false;
        }

        /// <summary>
        /// Whether the version is still as this call's create left it: still Pending, with the same non-blank ETag.
        /// This is best effort only. The service has no If-Match for application packages, and its create returns 200
        /// for a new version and for one that already exists. So another upload of the same version at the same time
        /// can still race with this one, and this call can then delete that upload's version.
        /// </summary>
        private bool IsUnchangedSinceCreated(string resourceGroupName, string accountName, string applicationName, string version, string createdEtag)
        {
            if (string.IsNullOrWhiteSpace(createdEtag))
            {
                // Nothing to compare with: don't delete.
                return false;
            }

            try
            {
                ApplicationPackage current = BatchManagementClient.ApplicationPackage.Get(
                    resourceGroupName,
                    accountName,
                    applicationName,
                    version);

                return current.State == PackageState.Pending && string.Equals(current.Etag, createdEtag, StringComparison.Ordinal);
            }
            catch (Exception)
            {
                // Gone already, or we can't tell: don't delete.
                return false;
            }
        }


        private ApplicationPackage CreateUpdateAppPackage(string resourceGroupName, string accountName, string applicationName, string version)
        {
            try
            {
                return BatchManagementClient.ApplicationPackage.Create(
                    resourceGroupName,
                    accountName,
                    applicationName,
                    version);
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
