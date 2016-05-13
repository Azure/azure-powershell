using System;
using System.Collections.Generic;
using System.Management.Automation;
using System.Globalization;
using Microsoft.AzureStack.AzureConsistentStorage;
using Microsoft.AzureStack.AzureConsistentStorage.Models;

namespace Microsoft.AzureStack.AzureConsistentStorage.Commands
{
    /// <summary>
    ///     SYNTAX
    ///          Get-StorageAccountsWithAdminInfo [-SubscriptionId] {string} [-Token] {string} [-AdminUri] {Uri} [-ResourceGroupName] {string} 
    ///             [-SkipCertificateValidation] [-FarmName] {string} [[-TenantSubscriptionId] {string}] [[-StorageAccountName] {string}] 
    ///             [[-StorageAccountStatus] {int}] [[-AccountId] {long}] [-Summary]]
    /// 
    /// </summary>
    [Cmdlet(VerbsCommon.Get, Nouns.AdminStorageAccount, DefaultParameterSetName = ListAccountsParamSet)]
    public sealed class GetStorageAccountsWithAdminInfo : AdminCmdlet
    {
        const string ListAccountsParamSet = "ListMultipleAccounts";
        const string GetSingleAccountParamSet = "GetSingleAccount";

        /// <summary>
        /// Resource group name
        /// </summary>
        [Parameter(Position = 3, Mandatory = true, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public string ResourceGroupName { get; set; }

        /// <summary>
        /// Farm Identifier
        /// </summary>
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, Position = 4)]
        [ValidateNotNull]
        public string FarmName { get; set; }

        /// <summary>
        /// Tenant Subscription Id
        /// </summary>
        [Parameter(Mandatory = false, Position = 5, ParameterSetName = ListAccountsParamSet)]
        public string TenantSubscriptionId { get; set; }

        /// <summary>
        /// Storage Account Name
        /// </summary>
        [Parameter(Mandatory = false, Position = 6, ParameterSetName = ListAccountsParamSet)]
        public string PartialAccountName { get; set; }

        /// <summary>
        /// Storage Account Status
        /// </summary>
        [Parameter(Mandatory = false, Position = 7, ParameterSetName = ListAccountsParamSet)]
        public int? StorageAccountStatus { get; set; }

        /// <summary>
        /// Storage Account AccountId
        /// </summary>
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, Position = 8, ParameterSetName = GetSingleAccountParamSet)]
        public long AccountId { get; set; }

        /// <summary>
        /// Only need return summary information if not specified
        /// </summary>
        [Parameter(Mandatory = false, Position = 9)]
        public SwitchParameter Detail { get; set; }

        protected override void Execute()
        {
            List<KeyValuePair<StorageAccountSearchFilterParameter, string>> filters = new List<KeyValuePair<StorageAccountSearchFilterParameter, string>>();

            switch (ParameterSetName)
            {
                case GetSingleAccountParamSet:
                    filters.Add(new KeyValuePair<StorageAccountSearchFilterParameter, string>(StorageAccountSearchFilterParameter.VersionedAccountName, AccountId.ToString(CultureInfo.InvariantCulture)));
                    break;
                case ListAccountsParamSet:
                    if (TenantSubscriptionId != null)
                        filters.Add(new KeyValuePair<StorageAccountSearchFilterParameter, string>(StorageAccountSearchFilterParameter.TenantSubscriptionId, TenantSubscriptionId));
                    if (PartialAccountName != null)
                        filters.Add(new KeyValuePair<StorageAccountSearchFilterParameter, string>(StorageAccountSearchFilterParameter.PartialAccountName, PartialAccountName));
                    if (StorageAccountStatus.HasValue == true)
                        filters.Add(new KeyValuePair<StorageAccountSearchFilterParameter, string>(StorageAccountSearchFilterParameter.StorageAccountStatus, StorageAccountStatus.Value.ToString(CultureInfo.InvariantCulture)));
                    break;
            }
            string filter = Tools.GenerateStorageAccountsSearchFilter(filters);
            var response = Client.StorageAccounts.List(ResourceGroupName, FarmName, filter, !Detail.IsPresent);
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                List<StorageAccountResponse> adminViewList = new List<StorageAccountResponse>();
                foreach (StorageAccountModel model in response.StorageAccounts)
                {
                    adminViewList.Add(new StorageAccountResponse(model, FarmName));
                }
                WriteObject(adminViewList, true);
            }
            else
                WriteObject(response, true);
        }
    }
}
