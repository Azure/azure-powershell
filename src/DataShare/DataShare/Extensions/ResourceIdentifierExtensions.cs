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

namespace Microsoft.Azure.Commands.DataShare.Helpers
{
    using System;
    using Microsoft.Azure.Management.Internal.Resources.Utilities.Models;

    public static class ResourceIdentifierExtensions
    {
        private const string Accounts = "accounts";
        private const string Shares = "shares";
        private const string Invitations = "invitations";
        private const string ShareSubscriptions = "shareSubscriptions";
        private const string SynchronizationSettings = "SynchronizationSettings";
        private const string Triggers = "triggers";
        private const string StorageAccounts = "storageAccounts";
        private const string DataSet = "dataSets";
        private const string DataSetMapping = "dataSetMappings";

        public static string GetAccountName(this ResourceIdentifier resourceId)
        {
            if (string.IsNullOrEmpty(resourceId.ParentResource))
            {
                return resourceId.ResourceName;
            }

            return resourceId.GetChildResourceName(ResourceIdentifierExtensions.Accounts);
        }

        public static string GetShareName(this ResourceIdentifier resourceId)
        {
            return resourceId.GetChildResourceName(ResourceIdentifierExtensions.Shares);
        }

        public static string GetShareSubscriptionName(this ResourceIdentifier resourceId)
        {
            return resourceId.GetChildResourceName(ResourceIdentifierExtensions.ShareSubscriptions);
        }

        public static string GetInvitationName(this ResourceIdentifier resourceId)
        {
            return resourceId.GetChildResourceName(ResourceIdentifierExtensions.Invitations);
        }

        public static string GetSynchronizationSettingName(this ResourceIdentifier resourceId)
        {
            return resourceId.GetChildResourceName(ResourceIdentifierExtensions.SynchronizationSettings);
        }
        public static string GetTriggerName(this ResourceIdentifier resourceId)
        {
            return resourceId.GetChildResourceName(ResourceIdentifierExtensions.Triggers);
        }

        public static string GetStorageAccountName(this ResourceIdentifier resourceId)
        {
            return resourceId.GetChildResourceName(ResourceIdentifierExtensions.StorageAccounts);
        }

        public static string GetDataSetName(this ResourceIdentifier resourceId)
        {
            return resourceId.GetChildResourceName(ResourceIdentifierExtensions.DataSet);
        }

        public static string GetDataSetMappingName(this ResourceIdentifier resourceId)
        {
            return resourceId.GetChildResourceName(ResourceIdentifierExtensions.DataSetMapping);
        }

        private static string GetChildResourceName(this ResourceIdentifier resourceId, string resourceType)
        {
            var parentResource = resourceId.ToString().Split(new[] { '/' });

            for (int idx = 0; idx < parentResource.Length; idx++)
            {
                if (parentResource[idx].Equals(resourceType, StringComparison.OrdinalIgnoreCase))
                {
                    return parentResource[idx + 1];
                }
            }

            return null;
        }
    }
}