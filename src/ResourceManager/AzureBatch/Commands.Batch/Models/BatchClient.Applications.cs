using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            AddApplicationResponse response = BatchManagementClient.Applications.AddApplication(
                resourceGroupName,
                accountName,
                applicationId,
                new AddApplicationParameters() { AllowUpdates = allowUpdates, DisplayName = displayName });

            return ConvertApplicationToPSApplication(response.Application);
        }

        public virtual PSApplicationPackage UploadApplicationPackage(string resourceGroupName, string accountName, string applicationId, string version, string filePath)
        {
            AddApplicationPackageResponse response = BatchManagementClient.Applications.AddApplicationPackage(resourceGroupName, accountName, applicationId, version);

            CloudBlockBlob blob = new CloudBlockBlob(new Uri(response.StorageUrl));

            blob.UploadFromFile(filePath, FileMode.Open);

            BatchManagementClient.Applications.ActivateApplicationPackage(
                resourceGroupName,
                accountName,
                applicationId,
                version,
                new ActivateApplicationPackageParameters { Format = "zip", });

            PSApplicationPackage getResponse = this.GetApplicationPackage(resourceGroupName, accountName, applicationId, version);

            return getResponse;
        }

        public virtual AzureOperationResponse DeleteApplication(string resourceGroupName, string accountName, string applicationId)
        {
            return BatchManagementClient.Applications.DeleteApplication(resourceGroupName, accountName, applicationId);
        }

        public virtual AzureOperationResponse DeleteApplicationPackage(string resourceGroupName, string accountName, string applicationId, string version)
        {
            return BatchManagementClient.Applications.DeleteApplicationPackage(resourceGroupName, accountName, applicationId, version);
        }

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

        public virtual IEnumerable<PSApplication> ListApplications(string resourceGroupName, string accountName)
        {
            ListApplicationsResponse response = BatchManagementClient.Applications.List(resourceGroupName, accountName, new ListApplicationsParameters());

            List<PSApplication> psApplications = response.Applications.Select(ConvertApplicationToPSApplication).ToList();

            string nextLink = response.NextLink;

            while (nextLink != null)
            {
                response = ListNextApplications(nextLink);

                psApplications.AddRange(response.Applications.Select(ConvertApplicationToPSApplication));

                nextLink = response.NextLink;
            }

            return psApplications;
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

        private ListApplicationsResponse ListNextApplications(string NextLink)
        {
            return BatchManagementClient.Applications.ListNext(NextLink);
        }

        public virtual AzureOperationResponse UpdateApplication(string resourceGroupName, string accountName, string applicationId, bool allowUpdates, string defaultVersion, string displayName)
        {
            return BatchManagementClient.Applications.UpdateApplication(
                resourceGroupName,
                accountName,
                applicationId,
                new UpdateApplicationParameters() { AllowUpdates = allowUpdates, DefaultVersion = defaultVersion, DisplayName = displayName, });
        }
    }
}
