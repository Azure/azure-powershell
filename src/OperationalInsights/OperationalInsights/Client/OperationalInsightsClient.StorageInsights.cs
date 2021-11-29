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

using Microsoft.Azure.Commands.OperationalInsights.Models;
using Microsoft.Azure.Commands.OperationalInsights.Properties;
using Microsoft.Azure.Management.OperationalInsights;
using Microsoft.Azure.Management.OperationalInsights.Models;
using Microsoft.Rest;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Management.Automation;
using System.Net;

namespace Microsoft.Azure.Commands.OperationalInsights.Client
{
    public partial class OperationalInsightsClient
    {
        public virtual PSStorageInsight GetStorageInsight(string resourceGroupName, string workspaceName, string storageInsightName)
        {
            var response = OperationalInsightsManagementClient.StorageInsightConfigs.Get(resourceGroupName, workspaceName, storageInsightName);

            return new PSStorageInsight(response, resourceGroupName, workspaceName);
        }

        public virtual List<PSStorageInsight> ListStorageInsights(string resourceGroupName, string workspaceName)
        {
            List<PSStorageInsight> storageInsights = new List<PSStorageInsight>();

            var response = OperationalInsightsManagementClient.StorageInsightConfigs.ListByWorkspace(resourceGroupName, workspaceName);

            if (response != null)
            {
                response.ForEach(si => storageInsights.Add(new PSStorageInsight(si, resourceGroupName, workspaceName)));
            }

            return storageInsights;
        }

        public virtual HttpStatusCode DeleteStorageInsight(string resourceGroupName, string workspaceName, string storageInsightName)
        {
            Rest.Azure.AzureOperationResponse result = OperationalInsightsManagementClient.StorageInsightConfigs.DeleteWithHttpMessagesAsync(resourceGroupName, workspaceName, storageInsightName).GetAwaiter().GetResult();
            return result.Response.StatusCode;
        }

        public virtual StorageInsight CreateOrUpdateStorageInsight(PSStorageInsightParameters parameters)
        {
            StorageInsight storageInsightsToUpdate = new StorageInsight { 
                Containers = parameters.Containers, 
                Tables = parameters.Tables,
                ETag = parameters.Etag,
                Tags = parameters.Tags?.Cast<DictionaryEntry>().ToDictionary(kv => (string)kv.Key, kv => (string)kv.Value)
            };

            if (!string.IsNullOrWhiteSpace(parameters.StorageAccountResourceId) && !string.IsNullOrWhiteSpace(parameters.StorageAccountKey))
            {
                storageInsightsToUpdate.StorageAccount = new StorageAccount { Id = parameters.StorageAccountResourceId, Key = parameters.StorageAccountKey };
            }

            return OperationalInsightsManagementClient.StorageInsightConfigs.CreateOrUpdate(
                parameters.ResourceGroupName,
                parameters.WorkspaceName,
                parameters.Name,
                storageInsightsToUpdate);
        }

        public virtual PSStorageInsight UpdatePSStorageInsight(PSStorageInsightParameters parameters)
        {
            // Get the existing storage insight
            PSStorageInsight storageInsight;
            try
            {
                storageInsight = GetStorageInsight(parameters.ResourceGroupName, parameters.WorkspaceName, parameters.Name);
            }
            catch (RestException)
            {
                throw new PSArgumentException($"StorageInsight {parameters.Name} under workspace {parameters.WorkspaceName} does not existed");
            }

            // Execute the update
            StorageInsight updatedStorageInsight = CreateOrUpdateStorageInsight(parameters);

            return new PSStorageInsight(updatedStorageInsight, parameters.ResourceGroupName, parameters.WorkspaceName);
        }


        public virtual PSStorageInsight CreatePSStorageInsight(PSStorageInsightParameters parameters, Action<bool, string, string, string, Action, Func<bool>> confirmAction, bool force)
        {
            PSStorageInsight storageInsight = null;
            Action createStorageInsight = () =>
            {
                storageInsight = new PSStorageInsight(CreateOrUpdateStorageInsight(parameters), parameters.ResourceGroupName, parameters.WorkspaceName);
            };

            confirmAction(force,
                string.Format(CultureInfo.InvariantCulture, Resources.StorageInsightExists, parameters.Name, parameters.WorkspaceName),
                string.Format(CultureInfo.InvariantCulture, Resources.StorageInsightCreating, parameters.Name, parameters.WorkspaceName),
                parameters.Name,
                createStorageInsight,
                () => CheckStorageInsightExists(parameters.ResourceGroupName, parameters.WorkspaceName, parameters.Name));
            return storageInsight;
        }

        public virtual List<PSStorageInsight> FilterPSStorageInsights(string resourceGroupName, string workspaceName, string storageInsightName)
        {
            List<PSStorageInsight> storageInsights = new List<PSStorageInsight>();

            if (!string.IsNullOrWhiteSpace(storageInsightName))
            {
                if (string.IsNullOrWhiteSpace(resourceGroupName) || string.IsNullOrWhiteSpace(workspaceName))
                {
                    throw new PSArgumentException(Resources.WorkspaceDetailsCannotBeEmpty);
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
            catch (Microsoft.Rest.Azure.CloudException e)
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
