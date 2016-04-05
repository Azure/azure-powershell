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
using Microsoft.Azure.Commands.Common.Authentication;
using Microsoft.Azure.Commands.Common.Authentication.Models;
using Microsoft.WindowsAzure.Commands.Common;
using Microsoft.WindowsAzure.Management.SiteRecovery;
using Microsoft.WindowsAzure.Management.SiteRecovery.Models;

namespace Microsoft.Azure.Commands.RecoveryServices
{
    /// <summary>
    /// Recovery Services Client Helper Methods class
    /// </summary>
    public partial class PSRecoveryServicesClient
    {
        /// <summary>
        /// Converts the Parameter set string of Replication Frequency in seconds to UShort.
        /// </summary>
        /// <param name="replicationFrequencyString">Replication frequency in seconds.</param>
        /// <returns>A UShort corresponding to the value.</returns>
        public static ushort ConvertReplicationFrequencyToUshort(string replicationFrequencyString)
        {
            if (replicationFrequencyString == null)
            {
                return 0;
            }

            ushort replicationFrequency;

            if (!ushort.TryParse(replicationFrequencyString, out replicationFrequency))
            {
                throw new InvalidOperationException(
                    string.Format(
                    Properties.Resources.InvalidReplicationFrequency,
                    replicationFrequencyString));
            }

            return replicationFrequency;
        }

        /// <summary>
        /// Validates if the time span object has a valid value.
        /// </summary>
        /// <param name="timeSpan">Time span object to be validated</param>
        public static void ValidateReplicationStartTime(TimeSpan? timeSpan)
        {
            if (timeSpan == null)
            {
                return;
            }

            if (TimeSpan.Compare(timeSpan.Value, new TimeSpan(24, 0, 0)) == 1)
            {
                throw new InvalidOperationException(
                    string.Format(Properties.Resources.ReplicationStartTimeInvalid));
            }
        }

        /// <summary>
        /// Validates whether the subscription belongs to the currently logged account or not.
        /// </summary>
        /// <param name="azureSubscriptionId">Azure Subscription ID</param>
        public void ValidateSubscriptionAccountAssociation(string azureSubscriptionId)
        {
            if (string.IsNullOrEmpty(azureSubscriptionId))
            {
                throw new InvalidOperationException(
                    string.Format(
                    Properties.Resources.SubscriptionIdIsNotValid));
            }

            bool associatedSubscription = false;
            List<AzureSubscription> subscriptions =
                new List<AzureSubscription>(this.Profile.Subscriptions.Values);

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
        /// <param name="azureSubscription">Subscription ID</param>
        /// <param name="azureStorageAccount">Storage Account details</param>
        /// <param name="vaultLocation">Current Vault Location</param>
        /// <param name="validationSuccessful">Out variable to indicate if validation was successful</param>
        /// <param name="locationValid">Out variable to indicate if location of storage account is valid</param>
        public void ValidateStorageAccountAssociation(
            string azureSubscription,
            string azureStorageAccount,
            string vaultLocation,
            out bool validationSuccessful,
            out bool locationValid)
        {
            if (string.IsNullOrEmpty(azureSubscription))
            {
                throw new InvalidOperationException(
                    string.Format(
                    Properties.Resources.SubscriptionIdIsNotValid));
            }

            if (string.IsNullOrEmpty(azureStorageAccount))
            {
                throw new InvalidOperationException(
                    string.Format(
                    Properties.Resources.StorageAccountNameIsNotValid));
            }

            bool associatedAccount = false;
            StorageAccountListResponse azureStorageListResponse = null;
            StorageAccountListResponse.StorageAccount currentStorageAccount = null;

            try
            {
                azureStorageListResponse =
                    this.GetSiteRecoveryClient().Storages.ListAzureStorages(azureSubscription);
            }
            catch (Exception)
            {
                validationSuccessful = false;
                locationValid = false;
                return;
            }

            foreach (var storage in azureStorageListResponse.StorageAccounts)
            {
                if (string.Compare(
                    azureStorageAccount,
                    storage.Name,
                    StringComparison.OrdinalIgnoreCase) == 0)
                {
                    associatedAccount = true;
                    currentStorageAccount = storage;
                    break;
                }
            }

            if (!associatedAccount)
            {
                validationSuccessful = false;
                locationValid = false;
                return;
            }

            // Validate that the Geo Location of the storage account is the same as that of the vault.
            if (string.IsNullOrEmpty(currentStorageAccount.Properties.Location))
            {
                validationSuccessful = false;
                locationValid = false;
                return;
            }

            if (0 != string.Compare(
                currentStorageAccount.Properties.Location,
                vaultLocation,
                StringComparison.OrdinalIgnoreCase))
            {
                validationSuccessful = true;
                locationValid = false;
                return;
            }

            validationSuccessful = true;
            locationValid = true;
        }
    }
}
