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

using Hyak.Common;
using Microsoft.Azure.Commands.OperationalInsights.Models;
using Microsoft.Azure.Commands.OperationalInsights.Properties;
using Microsoft.Azure.Management.OperationalInsights;
using Microsoft.Azure.Management.OperationalInsights.Models;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net;

namespace Microsoft.Azure.Commands.OperationalInsights.Client
{
    public partial class OperationalInsightsClient
    {
        public virtual PSStorageInsight GetStorageInsight(string resourceGroupName, string workspaceName, string storageInsightName)
        {
            var response = OperationalInsightsManagementClient.StorageInsights.Get(resourceGroupName, workspaceName, storageInsightName);

            return new PSStorageInsight(response.StorageInsight, resourceGroupName, workspaceName);
        }

        public virtual List<PSStorageInsight> ListStorageInsights(string resourceGroupName, string workspaceName)
        {
            List<PSStorageInsight> storageInsights = new List<PSStorageInsight>();

            var response = OperationalInsightsManagementClient.StorageInsights.ListInWorkspace(resourceGroupName, workspaceName);

            if (response != null && response.StorageInsights != null)
            {
                response.StorageInsights.ForEach(si => storageInsights.Add(new PSStorageInsight(si, resourceGroupName, workspaceName)));
            }

            return storageInsights;
        }

        public virtual HttpStatusCode DeleteStorageInsight(string resourceGroupName, string workspaceName, string storageInsightName)
        {
            AzureOperationResponse response = OperationalInsightsManagementClient.StorageInsights.Delete(resourceGroupName, workspaceName, storageInsightName);
            return response.StatusCode;
        }

        public virtual StorageInsight CreateOrUpdateStorageInsight(
            string resourceGroupName,
            string workspaceName,
            string name,
            string storageAccountResourceId,
            string storageAccountKey,
            List<string> tables,
            List<string> containers)
        {
            StorageInsightProperties properties = new StorageInsightProperties { Containers = containers, Tables = tables };

            if (!string.IsNullOrWhiteSpace(storageAccountResourceId) || !string.IsNullOrWhiteSpace(storageAccountKey))
            {
                properties.StorageAccount = new StorageAccount { Id = storageAccountResourceId, Key = storageAccountKey };
            }

            var response = OperationalInsightsManagementClient.StorageInsights.CreateOrUpdate(
                resourceGroupName,
                workspaceName,
                new StorageInsightCreateOrUpdateParameters
                {
                    StorageInsight = new StorageInsight { Name = name, Properties = properties }
                });

            return response.StorageInsight;
        }

        public virtual PSStorageInsight UpdatePSStorageInsight(UpdatePSStorageInsightParameters parameters)
        {
            // Get the existing storage insight
            StorageInsightGetResponse response = OperationalInsightsManagementClient.StorageInsights.Get(parameters.ResourceGroupName, parameters.WorkspaceName, parameters.Name);
            StorageInsight storageInsight = response.StorageInsight;

            // Execute the update
            StorageInsight updatedStorageInsight = CreateOrUpdateStorageInsight(
                parameters.ResourceGroupName,
                parameters.WorkspaceName,
                storageInsight.Name,
                storageInsight.Properties.StorageAccount.Id,
                string.IsNullOrWhiteSpace(parameters.StorageAccountKey) ? storageInsight.Properties.StorageAccount.Key : parameters.StorageAccountKey,
                parameters.Tables ?? storageInsight.Properties.Tables.ToList(),
                parameters.Containers ?? storageInsight.Properties.Containers.ToList());

            return new PSStorageInsight(updatedStorageInsight, parameters.ResourceGroupName, parameters.WorkspaceName);
        }

        public virtual PSStorageInsight CreatePSStorageInsight(CreatePSStorageInsightParameters parameters)
        {
            PSStorageInsight storageInsight = null;
            Action createStorageInsight = () =>
            {
                storageInsight =
                    new PSStorageInsight(
                        CreateOrUpdateStorageInsight(
                            parameters.ResourceGroupName,
                            parameters.WorkspaceName,
                            parameters.Name,
                            parameters.StorageAccountResourceId,
                            parameters.StorageAccountKey,
                            parameters.Tables,
                            parameters.Containers),
                        parameters.ResourceGroupName,
                        parameters.WorkspaceName);
            };

            parameters.ConfirmAction(
                parameters.Force,
                string.Format(
                    CultureInfo.InvariantCulture,
                    Resources.StorageInsightExists,
                    parameters.Name,
                    parameters.WorkspaceName),
                string.Format(
                    CultureInfo.InvariantCulture,
                    Resources.StorageInsightCreating,
                    parameters.Name,
                    parameters.WorkspaceName),
                parameters.Name,
                createStorageInsight,
                () => CheckStorageInsightExists(parameters.ResourceGroupName, 
                    parameters.WorkspaceName, parameters.Name));
            return storageInsight;
        }

        public virtual List<PSStorageInsight> FilterPSStorageInsights(string resourceGroupName, string workspaceName, string storageInsightName)
        {
            List<PSStorageInsight> storageInsights = new List<PSStorageInsight>();

            if (!string.IsNullOrWhiteSpace(storageInsightName))
            {
                if (string.IsNullOrWhiteSpace(resourceGroupName) || string.IsNullOrWhiteSpace(workspaceName))
                {
                    throw new ArgumentException(Resources.WorkspaceDetailsCannotBeEmpty);
                }

                storageInsights.Add(GetStorageInsight(resourceGroupName, workspaceName, storageInsightName));
            }
            else
            {
                storageInsights.AddRange(ListStorageInsights(resourceGroupName, workspaceName));
            }

            return storageInsights;
        }

        private bool CheckStorageInsightExists(string resourceGroupName, string workspaceName, string storageInsightName)
        {
            try
            {
                PSStorageInsight storageInsight = GetStorageInsight(resourceGroupName, workspaceName, storageInsightName);
                return true;
            }
            catch (CloudException e)
            {
                // Get throws NotFound exception if workspace does not exist
                if (e.Response.StatusCode == HttpStatusCode.NotFound)
                {
                    return false;
                }

                throw;
            }
        }
    }
}
