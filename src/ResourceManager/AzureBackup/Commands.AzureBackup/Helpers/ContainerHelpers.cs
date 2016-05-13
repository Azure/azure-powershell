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

using Microsoft.Azure.Commands.AzureBackup.Models;
using Microsoft.Azure.Management.BackupServices.Models;
using System;
using System.Collections.Specialized;
using System.Text.RegularExpressions;

namespace Microsoft.Azure.Commands.AzureBackup.Helpers
{
    internal class ContainerHelpers
    {
        private static readonly Regex ResourceGroupRegex = new Regex(@"/subscriptions/(?<subscriptionsId>.+)/resourceGroups/(?<resourceGroupName>.+)/providers/(?<providersName>.+)/BackupVault/(?<BackupVaultName>.+)/containers/(?<containersName>.+)", RegexOptions.Compiled);

        internal static AzureBackupContainerType GetContainerType(string customerTypeString)
        {
            AzureBackupContainerType containerType = 0;
            CustomerType customerType = CustomerType.Invalid;

            if (Enum.TryParse<CustomerType>(customerTypeString, out customerType))
            {
                switch (customerType)
                {
                    case CustomerType.DPM:
                        containerType = AzureBackupContainerType.SCDPM;
                        break;
                    case CustomerType.OBS:
                        containerType = AzureBackupContainerType.Windows;
                        break;
                    case CustomerType.SBS:
                        containerType = AzureBackupContainerType.Windows;
                        break;
                    case CustomerType.DPMVenus:
                        containerType = AzureBackupContainerType.AzureBackupServer;
                        break;
                    case CustomerType.Invalid:
                        break;
                    default:
                        containerType = AzureBackupContainerType.Other;
                        break;
                }
            }
            else if (!string.IsNullOrEmpty(customerTypeString))
            {
                containerType = AzureBackupContainerType.Other;
            }

            return containerType;
        }

        internal static AzureBackupContainerType GetTypeForManagedContainer(string managedContainerTypeString)
        {
            ManagedContainerType managedContainerType = (ManagedContainerType)Enum.Parse(typeof(ManagedContainerType), managedContainerTypeString, true);

            AzureBackupContainerType containerType = 0;

            switch (managedContainerType)
            {
                case ManagedContainerType.Invalid:
                    break;
                case ManagedContainerType.IaasVM:
                    containerType = AzureBackupContainerType.AzureVM;
                    break;
                case ManagedContainerType.IaasVMService:
                    break;
                default:
                    break;
            }

            return containerType;
        }

        internal static string GetQueryFilter(ListContainerQueryParameter queryParams)
        {
            NameValueCollection collection = new NameValueCollection();
            if (!String.IsNullOrEmpty(queryParams.ContainerTypeField))
            {
                collection.Add("ContainerType", queryParams.ContainerTypeField);
            }

            if (!String.IsNullOrEmpty(queryParams.ContainerStatusField))
            {
                collection.Add("ContainerStatus", queryParams.ContainerStatusField);
            }

            if (!String.IsNullOrEmpty(queryParams.ContainerFriendlyNameField))
            {
                collection.Add("FriendlyName", queryParams.ContainerFriendlyNameField);
            }

            if (collection == null || collection.Count == 0)
            {
                return String.Empty;
            }

            return CreateQueryString(collection);
        }

        internal static string GetRGNameFromId(string id)
        {
            var match = ResourceGroupRegex.Match(id);
            if (match.Success)
            {
                var vmRGName = match.Groups["containersName"];
                if (vmRGName != null && vmRGName.Success)
                {
                    return vmRGName.Value;
                }
            }

            return null;
        }

        private static string CreateQueryString(NameValueCollection collection)
        {
            string filterValue = string.Empty;

            if (collection == null)
            {
                throw new ArgumentNullException("collection");
            }

            if (collection.Count > 0)
            {
                foreach (string key in collection.Keys)
                {
                    filterValue += key + " eq '" + collection[key] + "' and ";
                }
                filterValue = filterValue.Remove(filterValue.Length - 5);
            }
            return filterValue;
        }
    }
}
