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
using Microsoft.WindowsAzure.Commands.Common;
using Microsoft.Azure.Common.Authentication.Models;
using Microsoft.WindowsAzure.Commands.Common.Storage;
using ArmStorage = Microsoft.Azure.Management.Storage;
using SmStorage = Microsoft.WindowsAzure.Management.Storage;
using Microsoft.WindowsAzure.Storage;
using Microsoft.Azure.Common.Authentication;
using Microsoft.WindowsAzure.Storage.Auth;

namespace Microsoft.WindowsAzure.Commands.Utilities.Common
{
    public static class AzureContextExtensions
    {
        private static Dictionary<Guid, CloudStorageAccount> storageAccountCache = new Dictionary<Guid,CloudStorageAccount>();

        public static CloudStorageAccount GetCloudStorageAccount(this AzureContext context, string connectionString)
        {
            if (connectionString == null)
            {
                return null;
            }
            return CloudStorageAccount.Parse(connectionString);
        }

        public static void SetCurrentStorageAccount(this AzureContext context, string connectionString)
        {
            if (context.Subscription != null)
            {
                context.Subscription.SetProperty(AzureSubscription.Property.StorageAccount, connectionString);
            }
        }

        public static void SetCurrentStorageAccount(this AzureContext context, IStorageContextProvider account)
        {
            if (context.Subscription != null && account != null && account.Context != null && account.Context.StorageAccount != null)
            {
                context.SetCurrentStorageAccount(account.Context.StorageAccount.ToString(true));
            }
        }

    }
}
