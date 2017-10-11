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

             var response = BatchManagementClient.Application.Create(
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

            BatchManagementClient.Application.Delete(resourceGroupName, accountName, applicationId);
        }

        public virtual PSApplication GetApplication(string resourceGroupName, string accountName, string applicationId)
        {
            // single account lookup - find its resource group if not specified
            if (string.IsNullOrEmpty(resourceGroupName))
            {
                resourceGroupName = GetGroupForAccount(accountName);
            }

            Application response = BatchManagementClient.Application.Get(resourceGroupName, accountName, applicationId);

            return ConvertApplicationToPSApplication(response);
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

            BatchManagementClient.Application.Update(
                resourceGroupName,
                accountName,
                applicationId,
                uap);
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
    }
}
