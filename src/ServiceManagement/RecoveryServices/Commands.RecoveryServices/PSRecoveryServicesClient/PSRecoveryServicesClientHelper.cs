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
using Microsoft.WindowsAzure;
using Microsoft.WindowsAzure.Commands.Common;
using Microsoft.WindowsAzure.Commands.Common.Models;
using Microsoft.WindowsAzure.Management.Storage;
using Microsoft.WindowsAzure.Management.Storage.Models;

namespace Microsoft.Azure.Commands.RecoveryServices
{
    /// <summary>
    /// Recovery Services Client Helper Methods class
    /// </summary>
    public class PSRecoveryServicesClientHelper
    {
        /// <summary>
        /// Validates whether the subscription belongs to the currently logged account or not.
        /// </summary>
        /// <param name="azureSubscriptionId">Azure Subscription ID</param>
        public static void ValidateSubscriptionAccountAssociation(string azureSubscriptionId)
        {
            bool associatedSubscription = false;
            ProfileClient pc = new ProfileClient();
            List<AzureSubscription> subscriptions =
                pc.RefreshSubscriptions(AzureSession.CurrentContext.Environment);

            foreach (AzureSubscription sub in subscriptions)
            {
                if (azureSubscriptionId.Equals(sub.Id.ToString(), StringComparison.OrdinalIgnoreCase))
                {
                    associatedSubscription = true;
                    break;
                }
            }

            if (!associatedSubscription)
            {
                throw new InvalidOperationException(
                    string.Format(
                    Properties.Resources.SubscriptionIsNotAssociatedWithTheAccount,
                    azureSubscriptionId));
            }
        }

        /// <summary>
        /// Validates whether the storage belongs to the currently logged account or not.
        /// </summary>
        /// <param name="azureStorageAccount">Storage Account details</param>
        public static void ValidateStorageAccountAssociation(string azureStorageAccount)
        {
            bool associatedAccount = false;

            SubscriptionCloudCredentials creds 
                = AzureSession.AuthenticationFactory.GetSubscriptionCloudCredentials(AzureSession.CurrentContext);
            StorageManagementClient storageManagementClient = new StorageManagementClient(creds);

            StorageAccountListResponse storageAccounts = storageManagementClient.StorageAccounts.List();
            foreach (StorageAccount storage in storageAccounts)
            {
                if (azureStorageAccount.Equals(storage.Name, StringComparison.OrdinalIgnoreCase))
                {
                    associatedAccount = true;
                    break;
                }
            }

            if (!associatedAccount)
            {
                throw new InvalidOperationException(
                    string.Format(
                    Properties.Resources.StorageIsNotAssociatedWithTheAccount,
                    azureStorageAccount));
            }
        }
    }
}
