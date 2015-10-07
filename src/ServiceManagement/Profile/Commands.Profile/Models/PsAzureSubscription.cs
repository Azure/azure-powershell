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
using System.ServiceModel.Description;
using Microsoft.Azure.Common.Authentication;
using Microsoft.Azure.Common.Authentication.Models;
using Microsoft.Web.Deployment;

namespace Microsoft.WindowsAzure.Commands.Profile.Models
{
    public class PSAzureSubscription
    {
        public PSAzureSubscription() {}
        public PSAzureSubscription(AzureSubscription subscription, AzureSMProfile profile)
        {
            SubscriptionId = subscription.Id.ToString();
            SubscriptionName = subscription.Name;
            Environment = subscription.Environment;
            DefaultAccount = subscription.Account;
            Accounts = profile.Accounts.Values.Where(a => a.HasSubscription(subscription.Id)).ToArray();
            IsDefault = subscription.IsPropertySet(AzureSubscription.Property.Default);
            IsCurrent = profile.Context != null && profile.Context.Subscription.Id == subscription.Id;
            CurrentStorageAccountName = subscription.GetProperty(AzureSubscription.Property.StorageAccount);
            TenantId = subscription.GetPropertyAsArray(AzureSubscription.Property.Tenants).FirstOrDefault();
        }



        public string SubscriptionId { get; set; }
        
        public string SubscriptionName { get; set; }
        
        public string Environment { get; set; }
        
        public string DefaultAccount { get; set; }
        
        public AzureAccount[] Accounts { get; set; }
        
        public bool IsDefault { get; set; }
        
        public bool IsCurrent { get; set; }
        
        public string CurrentStorageAccountName { get; set; }
        
        public string TenantId { get; set; }

        public string GetAccountName()
        {
            var result = CurrentStorageAccountName;
            if (!string.IsNullOrWhiteSpace(result))
            {
                try
                {
                    var pairs = result.Split(new char[]{';'}, StringSplitOptions.RemoveEmptyEntries);
                    foreach (var pair in pairs)
                    {
                        var sides = pair.Split(new char[] {'='}, 2, StringSplitOptions.RemoveEmptyEntries);
                        if (string.Equals("AccountName", sides[0].Trim(), StringComparison.OrdinalIgnoreCase))
                        {
                            result = sides[1].Trim();
                            break;
                        }
                    }
                }
                catch
                {
                    // if there are any errors, return the unchanged account name
                }
            }

            return result;
        }
    }
}
