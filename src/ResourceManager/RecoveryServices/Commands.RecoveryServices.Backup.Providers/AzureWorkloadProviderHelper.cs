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
using System.Linq;
using Microsoft.Azure.Commands.RecoveryServices.Backup.Cmdlets.ServiceClientAdapterNS;
using Microsoft.Azure.Commands.RecoveryServices.Backup.Helpers;
using Microsoft.Azure.Commands.RecoveryServices.Backup.Properties;
using Microsoft.Rest.Azure.OData;
using CmdletModel = Microsoft.Azure.Commands.RecoveryServices.Backup.Cmdlets.Models;
using ServiceClientModel = Microsoft.Azure.Management.RecoveryServices.Backup.Models;
using SystemNet = System.Net;

namespace Microsoft.Azure.Commands.RecoveryServices.Backup.Cmdlets.ProviderModel
{
    /// <summary>
    /// This class implements implements methods for Azure Workload Provider Helper
    /// </summary>
    public class AzureWorkloadProviderHelper
    {
        ServiceClientAdapter ServiceClientAdapter { get; set; }

        public AzureWorkloadProviderHelper(ServiceClientAdapter serviceClientAdapter)
        {
            ServiceClientAdapter = serviceClientAdapter;
        }

        public void RefreshContainer(string vaultName = null, string resourceGroupName = null)
        {
            string errorMessage = string.Empty;
            var refreshContainerJobResponse = ServiceClientAdapter.RefreshContainers(
                vaultName: vaultName,
                resourceGroupName: resourceGroupName);

            var operationStatus = TrackingHelpers.GetOperationResult(
                refreshContainerJobResponse,
                operationId =>
                    ServiceClientAdapter.GetRefreshContainerOperationResult(
                        operationId,
                        vaultName: vaultName,
                        resourceGroupName: resourceGroupName));

            //Now wait for the operation to Complete
            if (refreshContainerJobResponse.Response.StatusCode
                    != SystemNet.HttpStatusCode.NoContent)
            {
                errorMessage = string.Format(Resources.DiscoveryFailureErrorCode,
                    refreshContainerJobResponse.Response.StatusCode);
                Logger.Instance.WriteDebug(errorMessage);
            }
        }

        public List<ServiceClientModel.ProtectedItemResource> ListProtectedItemsByContainer(
            string vaultName,
            string resourceGroupName,
            CmdletModel.ContainerBase container,
            CmdletModel.PolicyBase policy,
            string backupManagementType,
            string dataSourceType)
        {
            ODataQuery<ServiceClientModel.ProtectedItemQueryObject> queryParams = policy != null ?
                new ODataQuery<ServiceClientModel.ProtectedItemQueryObject>(
                    q => q.BackupManagementType
                            == backupManagementType &&
                         q.ItemType == dataSourceType &&
                         q.PolicyName == policy.Name) :
                new ODataQuery<ServiceClientModel.ProtectedItemQueryObject>(
                    q => q.BackupManagementType
                            == backupManagementType &&
                         q.ItemType == dataSourceType);

            List<ServiceClientModel.ProtectedItemResource> protectedItems = new List<ServiceClientModel.ProtectedItemResource>();
            string skipToken = null;
            var listResponse = ServiceClientAdapter.ListProtectedItem(
                queryParams,
                skipToken,
                vaultName: vaultName,
                resourceGroupName: resourceGroupName);
            protectedItems.AddRange(listResponse);

            if (container != null)
            {
                protectedItems = protectedItems.Where(protectedItem =>
                {
                    Dictionary<CmdletModel.UriEnums, string> dictionary = HelperUtils.ParseUri(protectedItem.Id);
                    string containerUri = HelperUtils.GetContainerUri(dictionary, protectedItem.Id);

                    var delimIndex = containerUri.IndexOf(';');
                    string containerName = containerUri.Substring(delimIndex + 1);
                    return containerName.ToLower().Equals(container.Name.ToLower());
                }).ToList();
            }

            return protectedItems;
        }

        public List<CmdletModel.ItemBase> ListProtectedItemsByItemName(
            List<ServiceClientModel.ProtectedItemResource> protectedItems,
            string itemName,
            string vaultName,
            string resourceGroupName,
            Action<CmdletModel.ItemBase, ServiceClientModel.ProtectedItemResource> extendedInfoProcessor)
        {
            List<ServiceClientModel.ProtectedItemResource> protectedItemGetResponses =
                new List<ServiceClientModel.ProtectedItemResource>();

            if (!string.IsNullOrEmpty(itemName))
            {
                protectedItems = protectedItems.Where(protectedItem =>
                {
                    Dictionary<CmdletModel.UriEnums, string> dictionary = HelperUtils.ParseUri(protectedItem.Id);
                    string protectedItemUri = HelperUtils.GetProtectedItemUri(dictionary, protectedItem.Id);
                    return protectedItemUri.ToLower().Contains(itemName.ToLower());
                }).ToList();

                ODataQuery<ServiceClientModel.GetProtectedItemQueryObject> getItemQueryParams =
                    new ODataQuery<ServiceClientModel.GetProtectedItemQueryObject>(q => q.Expand == "extendedinfo");

                for (int i = 0; i < protectedItems.Count; i++)
                {
                    Dictionary<CmdletModel.UriEnums, string> dictionary = HelperUtils.ParseUri(protectedItems[i].Id);
                    string containerUri = HelperUtils.GetContainerUri(dictionary, protectedItems[i].Id);
                    string protectedItemUri = HelperUtils.GetProtectedItemUri(dictionary, protectedItems[i].Id);

                    var getResponse = ServiceClientAdapter.GetProtectedItem(
                        containerUri,
                        protectedItemUri,
                        getItemQueryParams,
                        vaultName: vaultName,
                        resourceGroupName: resourceGroupName);
                    protectedItemGetResponses.Add(getResponse.Body);
                }
            }

            List<CmdletModel.ItemBase> itemModels = ConversionHelpers.GetItemModelList(protectedItems);

            if (!string.IsNullOrEmpty(itemName))
            {
                for (int i = 0; i < itemModels.Count; i++)
                {
                    extendedInfoProcessor(itemModels[i], protectedItemGetResponses[i]);
                }
            }

            return itemModels;
        }

        public List<CmdletModel.ContainerBase> ListProtectionContainers(
            Dictionary<Enum, object> providerData,
            string backupManagementType)
        {
            string vaultName = (string)providerData[CmdletModel.VaultParams.VaultName];
            string vaultResourceGroupName = (string)providerData[CmdletModel.VaultParams.ResourceGroupName];
            string name = (string)providerData[CmdletModel.ContainerParams.Name];
            string friendlyName = (string)providerData[CmdletModel.ContainerParams.FriendlyName];
            CmdletModel.ContainerRegistrationStatus status =
                (CmdletModel.ContainerRegistrationStatus)providerData[CmdletModel.ContainerParams.Status];

            string nameQueryFilter = friendlyName;

            if (!string.IsNullOrEmpty(name))
            {
                Logger.Instance.WriteWarning(Resources.GetContainerNameParamDeprecated);

                if (string.IsNullOrEmpty(friendlyName))
                {
                    nameQueryFilter = name;
                }
            }

            ODataQuery<ServiceClientModel.BMSContainerQueryObject> queryParams = null;
            if (status == 0)
            {
                queryParams = new ODataQuery<ServiceClientModel.BMSContainerQueryObject>(
                q => q.FriendlyName == nameQueryFilter &&
                q.BackupManagementType == backupManagementType);
            }
            else
            {
                var statusString = status.ToString();
                queryParams = new ODataQuery<ServiceClientModel.BMSContainerQueryObject>(
                q => q.FriendlyName == nameQueryFilter &&
                q.BackupManagementType == backupManagementType &&
                q.Status == statusString);
            }

            var listResponse = ServiceClientAdapter.ListContainers(
                queryParams,
                vaultName: vaultName,
                resourceGroupName: vaultResourceGroupName);

            return ConversionHelpers.GetContainerModelList(listResponse);
        }
    }
}