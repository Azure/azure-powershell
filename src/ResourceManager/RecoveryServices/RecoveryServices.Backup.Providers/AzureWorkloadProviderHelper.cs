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

using Microsoft.Azure.Commands.RecoveryServices.Backup.Cmdlets.ServiceClientAdapterNS;
using Microsoft.Azure.Commands.RecoveryServices.Backup.Helpers;
using Microsoft.Azure.Commands.RecoveryServices.Backup.Properties;
using Microsoft.Azure.Management.RecoveryServices.Backup.Models;
using Microsoft.Rest.Azure.OData;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public void RefreshContainer(string vaultName = null, string vaultResourceGroupName = null,
            ODataQuery<BMSRefreshContainersQueryObject> queryParam = null)
        {
            var refreshContainerJobResponse = ServiceClientAdapter.RefreshContainers(
                vaultName: vaultName,
                resourceGroupName: vaultResourceGroupName,
                queryParam: queryParam);

            var operationStatus = TrackingHelpers.GetOperationResult(
                refreshContainerJobResponse,
                operationId =>
                    ServiceClientAdapter.GetContainerRefreshOrInquiryOperationResult(
                        operationId,
                        vaultName: vaultName,
                        resourceGroupName: vaultResourceGroupName));

            //Now wait for the operation to Complete
            if (refreshContainerJobResponse.Response.StatusCode
                    != SystemNet.HttpStatusCode.NoContent)
            {
                string errorMessage = string.Format(Resources.DiscoveryFailureErrorCode,
                    refreshContainerJobResponse.Response.StatusCode);
                Logger.Instance.WriteDebug(errorMessage);
            }
        }

        public void RegisterContainer(string storageAccountName,
            ProtectionContainerResource protectionContainerResource,
            string vaultName, string vaultResourceGroupName)
        {
            var registerResponse = ServiceClientAdapter.RegisterContainer(
                            storageAccountName,
                            protectionContainerResource,
                            vaultName,
                            vaultResourceGroupName);

            var operationStatus = TrackingHelpers.GetOperationResult(
                registerResponse,
                operationId =>
                    ServiceClientAdapter.GetRegisterContainerOperationResult(
                        operationId,
                        storageAccountName,
                        vaultName: vaultName,
                        resourceGroupName: vaultResourceGroupName));

            //Now wait for the operation to Complete
            if (registerResponse.Response.StatusCode
                    != SystemNet.HttpStatusCode.NoContent)
            {
                string errorMessage = string.Format(Resources.RegisterFailureErrorCode,
                    registerResponse.Response.StatusCode);
                Logger.Instance.WriteDebug(errorMessage);
            }
        }

        public List<ProtectedItemResource> ListProtectedItemsByContainer(
            string vaultName,
            string resourceGroupName,
            CmdletModel.ContainerBase container,
            CmdletModel.PolicyBase policy,
            string backupManagementType,
            string dataSourceType)
        {
            ODataQuery<ProtectedItemQueryObject> queryParams = policy != null ?
                new ODataQuery<ProtectedItemQueryObject>(
                    q => q.BackupManagementType
                            == backupManagementType &&
                         q.ItemType == dataSourceType &&
                         q.PolicyName == policy.Name) :
                new ODataQuery<ProtectedItemQueryObject>(
                    q => q.BackupManagementType
                            == backupManagementType &&
                         q.ItemType == dataSourceType);

            List<ProtectedItemResource> protectedItems = new List<ProtectedItemResource>();
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
            List<ProtectedItemResource> protectedItems,
            string itemName,
            string vaultName,
            string resourceGroupName,
            Action<CmdletModel.ItemBase, ProtectedItemResource> extendedInfoProcessor)
        {
            List<ProtectedItemResource> protectedItemGetResponses =
                new List<ProtectedItemResource>();

            if (!string.IsNullOrEmpty(itemName))
            {
                protectedItems = protectedItems.Where(protectedItem =>
                {
                    Dictionary<CmdletModel.UriEnums, string> dictionary = HelperUtils.ParseUri(protectedItem.Id);
                    string protectedItemUri = HelperUtils.GetProtectedItemUri(dictionary, protectedItem.Id);
                    return protectedItemUri.ToLower().Contains(itemName.ToLower());
                }).ToList();

                ODataQuery<GetProtectedItemQueryObject> getItemQueryParams =
                    new ODataQuery<GetProtectedItemQueryObject>(q => q.Expand == "extendedinfo");

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
            string friendlyName = (string)providerData[CmdletModel.ContainerParams.FriendlyName];
            CmdletModel.ContainerRegistrationStatus status =
                (CmdletModel.ContainerRegistrationStatus)providerData[CmdletModel.ContainerParams.Status];

            string nameQueryFilter = friendlyName;

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

        public void ValidateSimpleSchedulePolicy(CmdletModel.SchedulePolicyBase policy)
        {
            if (policy == null || policy.GetType() != typeof(CmdletModel.SimpleSchedulePolicy))
            {
                throw new ArgumentException(string.Format(Resources.InvalidSchedulePolicyException,
                                            typeof(CmdletModel.SimpleSchedulePolicy).ToString()));
            }

            // call validation
            policy.Validate();
        }

        public void ValidateLongTermRetentionPolicy(CmdletModel.RetentionPolicyBase policy)
        {
            if (policy == null || policy.GetType() != typeof(CmdletModel.LongTermRetentionPolicy))
            {
                throw new ArgumentException(
                    string.Format(
                        Resources.InvalidRetentionPolicyException,
                        typeof(CmdletModel.LongTermRetentionPolicy).ToString()));
            }

            // perform validation
            policy.Validate();
        }

        public DateTime GenerateRandomScheduleTime()
        {
            //Schedule time will be random to avoid the load in service (same is in portal as well)
            Random rand = new Random();
            int hour = rand.Next(0, 24);
            int minute = (rand.Next(0, 2) == 0) ? 0 : 30;
            return new DateTime(DateTime.Now.Year,
                DateTime.Now.Month,
                DateTime.Now.Day,
                hour,
                minute,
                00,
                DateTimeKind.Utc);
        }

        public void CopyScheduleTimeToRetentionTimes(CmdletModel.LongTermRetentionPolicy retPolicy,
                                                      CmdletModel.SimpleSchedulePolicy schPolicy)
        {
            // schedule runTimes is already validated if in UTC/not during validate()
            // now copy times from schedule to retention policy
            if (retPolicy.IsDailyScheduleEnabled && retPolicy.DailySchedule != null)
            {
                retPolicy.DailySchedule.RetentionTimes = schPolicy.ScheduleRunTimes;
            }

            if (retPolicy.IsWeeklyScheduleEnabled && retPolicy.WeeklySchedule != null)
            {
                retPolicy.WeeklySchedule.RetentionTimes = schPolicy.ScheduleRunTimes;
            }

            if (retPolicy.IsMonthlyScheduleEnabled && retPolicy.MonthlySchedule != null)
            {
                retPolicy.MonthlySchedule.RetentionTimes = schPolicy.ScheduleRunTimes;
            }

            if (retPolicy.IsYearlyScheduleEnabled && retPolicy.YearlySchedule != null)
            {
                retPolicy.YearlySchedule.RetentionTimes = schPolicy.ScheduleRunTimes;
            }
        }

        public List<CmdletModel.RecoveryPointBase> ListRecoveryPoints(Dictionary<Enum, object> ProviderData)
        {
            string vaultName = (string)ProviderData[CmdletModel.VaultParams.VaultName];
            string resourceGroupName = (string)ProviderData[CmdletModel.VaultParams.ResourceGroupName];
            DateTime startDate = (DateTime)(ProviderData[CmdletModel.RecoveryPointParams.StartDate]);
            DateTime endDate = (DateTime)(ProviderData[CmdletModel.RecoveryPointParams.EndDate]);

            CmdletModel.ItemBase item = ProviderData[CmdletModel.RecoveryPointParams.Item]
                as CmdletModel.ItemBase;

            Dictionary<CmdletModel.UriEnums, string> uriDict = HelperUtils.ParseUri(item.Id);
            string containerUri = HelperUtils.GetContainerUri(uriDict, item.Id);
            string protectedItemName = HelperUtils.GetProtectedItemUri(uriDict, item.Id);

            TimeSpan duration = endDate - startDate;
            if (duration.TotalDays > 30)
            {
                throw new Exception(Resources.RestoreDiskTimeRangeError);
            }

            //we need to fetch the list of RPs
            var queryFilterString = QueryBuilder.Instance.GetQueryString(new BMSRPQueryObject()
            {
                StartDate = startDate,
                EndDate = endDate
            });

            ODataQuery<BMSRPQueryObject> queryFilter = new ODataQuery<BMSRPQueryObject>();
            queryFilter.Filter = queryFilterString;

            List<RecoveryPointResource> rpListResponse = ServiceClientAdapter.GetRecoveryPoints(
                containerUri,
                protectedItemName,
                queryFilter,
                vaultName: vaultName,
                resourceGroupName: resourceGroupName);
            return RecoveryPointConversions.GetPSAzureRecoveryPoints(rpListResponse, item);
        }

        public CmdletModel.RecoveryPointBase GetRecoveryPointDetails(Dictionary<Enum, object> ProviderData)
        {
            string vaultName = (string)ProviderData[CmdletModel.VaultParams.VaultName];
            string resourceGroupName = (string)ProviderData[CmdletModel.VaultParams.ResourceGroupName];
            CmdletModel.ItemBase item = ProviderData[CmdletModel.RecoveryPointParams.Item]
                as CmdletModel.ItemBase;

            string recoveryPointId = ProviderData[CmdletModel.RecoveryPointParams.RecoveryPointId].ToString();

            Dictionary<CmdletModel.UriEnums, string> uriDict = HelperUtils.ParseUri(item.Id);
            string containerUri = HelperUtils.GetContainerUri(uriDict, item.Id);
            string protectedItemName = HelperUtils.GetProtectedItemUri(uriDict, item.Id);

            var rpResponse = ServiceClientAdapter.GetRecoveryPointDetails(
                containerUri,
                protectedItemName,
                recoveryPointId,
                vaultName: vaultName,
                resourceGroupName: resourceGroupName);

            return RecoveryPointConversions.GetPSAzureRecoveryPoints(rpResponse, item);
        }
    }
}