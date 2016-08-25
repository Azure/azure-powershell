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

using System.Security.Cryptography.X509Certificates;
using Microsoft.Azure.Commands.Common.Authentication.Models;

namespace Microsoft.WindowsAzure.Commands.Profile.Models
{
    public class PSAzureSubscriptionExtended : PSAzureSubscription
    {
        public PSAzureSubscriptionExtended()
        {

        }

        public PSAzureSubscriptionExtended(PSAzureSubscription subscription)
        {
            base.SubscriptionId = subscription.SubscriptionId;
            base.SubscriptionName = subscription.SubscriptionName;
            base.Accounts = subscription.Accounts;
            base.IsDefault = subscription.IsDefault;
            base.IsCurrent = subscription.IsCurrent;
            base.TenantId = subscription.TenantId;
        }

        public string ActiveDirectoryUserId { get; set; }

        public AzureAccount Account { get; set; }
        
        public X509Certificate2 Certificate { get; set; }
        
        public string AccountAdminLiveEmailId { get; set; }
        
        public int CurrentCoreCount { get; set; }
        
        public int CurrentHostedServices { get; set; }
        
        public int CurrentDnsServers { get; set; }
        
        public int CurrentLocalNetworkSites { get; set; }
        
        public int CurrentVirtualNetworkSites { get; set; }
        
        public int CurrentStorageAccounts { get; set; }
        
        public int MaxCoreCount { get; set; }
        
        public int MaxDnsServers { get; set; }
        
        public int MaxHostedServices { get; set; }
        
        public int MaxLocalNetworkSites { get; set; }
        
        public int MaxVirtualNetworkSites { get; set; }
        
        public int MaxStorageAccounts { get; set; }
        
        public string ServiceAdminLiveEmailId { get; set; }
        
        public string SubscriptionRealName { get; set; }
        
        public string SubscriptionStatus { get; set; }
        
        public string OperationDescription { get; set; }
        
        public string OperationId { get; set; }
        
        public string OperationStatus { get; set; }
        
        public string ServiceEndpoint { get; set; }
        
        public string ResourceManagerEndpoint { get; set; }
        
        public string GalleryEndpoint { get; set; }
    }
}