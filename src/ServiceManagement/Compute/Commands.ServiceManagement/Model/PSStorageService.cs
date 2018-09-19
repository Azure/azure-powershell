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
using Microsoft.WindowsAzure.Commands.Common.Storage;
using Microsoft.WindowsAzure.Management.Storage;
using Microsoft.Azure.Commands.Common.Authentication.Abstractions;

namespace Microsoft.WindowsAzure.Commands.ServiceManagement.Model
{
    public class PSStorageService : StorageServicePropertiesOperationContext, IStorageContextProvider
    {
        private AzureStorageContext _context;
        public IStorageContext Context
        {
            get { return _context; }
        }

        public PSStorageService(AzureStorageContext context)
        {
            _context = context;
        }

        protected PSStorageService(StorageServicePropertiesOperationContext account, AzureStorageContext context)
            : this(context)
        {
            this.AccountType = account.AccountType;
            this.AffinityGroup = account.AffinityGroup;
            this.GeoPrimaryLocation = account.GeoPrimaryLocation;
            this.GeoSecondaryLocation = account.GeoSecondaryLocation;
            this.Label = account.Label;
            this.Location = account.Location;
            this.OperationDescription = account.OperationDescription;
            this.OperationId = account.OperationId;
            this.OperationStatus = account.OperationStatus;
            this.StatusOfPrimary = account.StatusOfPrimary;
            this.StatusOfSecondary = account.StatusOfSecondary;
            this.StorageAccountName = account.StorageAccountName;
            this.StorageAccountDescription = account.StorageAccountDescription;
            this.StorageAccountStatus = account.StorageAccountStatus;
            this.LastGeoFailoverTime = account.LastGeoFailoverTime;
            var endpointList = new List<string>();
            foreach (var endpoint in account.Endpoints)
            {
                endpointList.Add(endpoint);
            }

            this.Endpoints = endpointList;
            this.MigrationState = account.MigrationState;
        }

        public static PSStorageService Create(StorageManagementClient client,
            StorageServicePropertiesOperationContext account)
        {
            return new PSStorageService(account, new LazyAzureStorageContext((s) =>
            {
                return StorageUtilities.GenerateCloudStorageAccount(client, account.StorageAccountName);
            }, account.StorageAccountName) as AzureStorageContext); 
        }

        /// <summary>
        /// Custom properties for the context
        /// </summary>
        public IDictionary<string, string> ExtendedProperties { get; } = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);

        /// <summary>
        /// String representation of this account
        /// </summary>
        /// <returns>null</returns>
        public override string ToString()
        {
            // Allow sceanrios that list storage account contents through piping
            return null;
        }
    }
}
 