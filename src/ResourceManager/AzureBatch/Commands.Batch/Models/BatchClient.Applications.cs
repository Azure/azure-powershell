using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Azure.Management.Batch;
using Microsoft.Azure.Management.Batch.Models;
using Microsoft.WindowsAzure.Storage.Blob;

namespace Microsoft.Azure.Commands.Batch.Models
{
    public partial class BatchClient
    {
		public virtual BatchAccountContext GetApplications(string resourceGroupName, string accountName, string applicationId)
        {
            // single account lookup - find its resource group if not specified
            if (string.IsNullOrEmpty(resourceGroupName))
            {
                resourceGroupName = GetGroupForAccount(accountName);
            }

            var response = BatchManagementClient.Applications.GetApplication(resourceGroupName, accountName, applicationId);

		    return null;//BatchAccountContext.ConvertAccountResourceToNewAccountContext(response.Resource);
        }

        /// <summary>
        /// Lists all accounts in a subscription or in a resource group if its name is specified
        /// </summary>
        /// <param name="resourceGroupName">The name of the resource group to search under for accounts. If unspecified, all accounts will be looked up.</param>
        /// <param name="tag">The tag to filter accounts on</param>
        /// <param name="accountName"></param>
        /// <returns>A collection of BatchAccountContext objects</returns>
        public virtual IEnumerable<BatchAccountContext> ListApplications(string resourceGroupName, Hashtable tag, string accountName)
        {
            List<BatchAccountContext> accounts = new List<BatchAccountContext>();

            // no account name so we're doing some sort of list. If no resource group, then list all accounts under the
            // subscription otherwise all accounts in the resource group.
            var response = BatchManagementClient.Applications.List(resourceGroupName, accountName, new ListApplicationsParameters());

            Console.WriteLine("response: " + response);
            // filter out the accounts if a tag was specified
            /*            IList<AccountResource> accountResources = new List<AccountResource>();
                        if (tag != null && tag.Count > 0)
                        {
                            accountResources = Helpers.FilterAccounts(response.Accounts, tag);
                        }
                        else
                        {
                            accountResources = response.Accounts;
                        }

                        foreach (AccountResource resource in accountResources)
                        {
                            accounts.Add(BatchAccountContext.ConvertAccountResourceToNewAccountContext(resource));
                        }

                        var nextLink = response.NextLink;

                        while (nextLink != null)
                        {
                            response = ListNextAccounts(nextLink);

                            foreach (AccountResource resource in response.Accounts)
                            {
                                accounts.Add(BatchAccountContext.ConvertAccountResourceToNewAccountContext(resource));
                            }

                            nextLink = response.NextLink;
                        }*/

            return null;
        }

        public BatchAccountContext AddApplicationPackage(string resourceGroupName, string applicationId, string version, string accountName, string filePath)
        {
            var response = BatchManagementClient.Applications.AddApplicationPackage(resourceGroupName, accountName, applicationId, version);

            Console.WriteLine("response: " + response);

            CloudBlockBlob blob = new CloudBlockBlob(new Uri(response.StorageUrl));

            blob.UploadFromFile(filePath, FileMode.Open);

            BatchManagementClient.Applications.ActivateApplicationPackage(
                resourceGroupName,
                accountName,
                applicationId,
                version,
                new ActivateApplicationPackageParameters { Format = "zip" });

            var getResponse = this.GetApplications(resourceGroupName, accountName, applicationId);

            return null;
        }

        public BatchAccountContext DeleteApplicationPackage(string resourceGroupName, string accountName, string applicationId, string version)
        {
            var response = BatchManagementClient.Applications.DeleteApplicationPackage(resourceGroupName, accountName, applicationId, version);

            Console.WriteLine("response: " + response);

            return null;
        }

        public BatchAccountContext UpdateApplication(string resourceGroupName, string applicationId, string applicationVersion, bool allowUpdates, string defaultVersion, string displayName)
        {
            var response = BatchManagementClient.Applications.UpdateApplication(
                resourceGroupName,
                applicationVersion,
                applicationId,
                new UpdateApplicationParameters() { AllowUpdates = allowUpdates, DefaultVersion = defaultVersion, DisplayName = displayName, });

            return null;
        }

        public BatchAccountContext AddApplication(string resourceGroupName, string applicationId, string applicationVersion, bool allowUpdates, string displayName)
        {
            var response = BatchManagementClient.Applications.AddApplication(
                resourceGroupName,
                applicationVersion,
                applicationId,
                new AddApplicationParameters() { AllowUpdates = allowUpdates, DisplayName = displayName });

            return null;
        }

        public BatchAccountContext DeleteApplication(string resourceGroupName, string applicationId, string applicationVersion)
        {
            var response = BatchManagementClient.Applications.DeleteApplication(resourceGroupName, applicationVersion, applicationId);

            return null;
        }
    }
}
