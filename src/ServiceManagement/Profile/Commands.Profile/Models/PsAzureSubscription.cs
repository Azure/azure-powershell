﻿// ----------------------------------------------------------------------------------
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
using System.ServiceModel.Description;
using Microsoft.Azure.Commands.Common.Authentication;
using Microsoft.Azure.Commands.Common.Authentication.Models;
using Microsoft.Azure.Commands.Common.Authentication.Abstractions;
using Microsoft.WindowsAzure.Commands.Utilities.Common;

namespace Microsoft.WindowsAzure.Commands.Profile.Models
{
    public class PSAzureSubscription
    {
        public PSAzureSubscription() {}
        public PSAzureSubscription(IAzureSubscription subscription, AzureSMProfile profile)
        {
            SubscriptionId = subscription.Id.ToString();
            SubscriptionName = subscription.Name;
            Environment = subscription.GetEnvironment();
            DefaultAccount = subscription.GetAccount();
            Accounts = profile.AccountTable.Values.Where(a => a.HasSubscription(subscription.GetId())).ToArray();
            IsDefault = subscription.IsPropertySet(AzureSubscription.Property.Default);
            IsCurrent = profile.Context != null && profile.Context.Subscription.Id == subscription.Id;
            CurrentStorageAccountName = subscription.GetProperty(AzureSubscription.Property.StorageAccount);
            TenantId = subscription.GetTenant();
        }

        public string SubscriptionId { get; set; }
        
        public string SubscriptionName { get; set; }
        
        public string Environment { get; set; }
        
        public string DefaultAccount { get; set; }
        
        public IAzureAccount[] Accounts { get; set; }
        
        public bool IsDefault { get; set; }
        
        public bool IsCurrent { get; set; }
        
        public string CurrentStorageAccountName { get; set; }
        
        public string TenantId { get; set; }

        public string GetAccountName()
        {
            string accountName = null;

            if (!string.IsNullOrWhiteSpace(this.CurrentStorageAccountName))
            {
                accountName = this.CurrentStorageAccountName.Split(new[] { ';' }, StringSplitOptions.RemoveEmptyEntries)
                                              .Where(s => s.StartsWith("accountname", StringComparison.OrdinalIgnoreCase))
                                              .Select( s => s.Split(new[] { '=' }, StringSplitOptions.RemoveEmptyEntries).Last())
                                              .FirstOrDefault();
            }
            return accountName;
        }
    }
}
