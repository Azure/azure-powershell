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

using Microsoft.Azure.Commands.Common.Authentication.Models;
using Microsoft.WindowsAzure.Commands.Common.Storage;
using Microsoft.WindowsAzure.Storage;

namespace Microsoft.WindowsAzure.Commands.Utilities.Common
{
    public static class AzureContextExtensions
    {
        /// <summary>
        /// Set the current storage account using the given connection string
        /// </summary>
        /// <param name="context">The current context.</param>
        /// <param name="connectionString">The connection string to check.</param>
        public static void SetCurrentStorageAccount(this AzureContext context, string connectionString)
        {
            if (context.Subscription != null)
            {
                context.Subscription.SetProperty(AzureSubscription.Property.StorageAccount, connectionString);
            }
        }

        /// <summary>
        /// Set the current storage account using the given connection string.
        /// </summary>
        /// <param name="context">The current context.</param>
        /// <param name="account">A storage account.</param>
        public static void SetCurrentStorageAccount(this AzureContext context, IStorageContextProvider account)
        {
            if (context.Subscription != null && account != null && account.Context != null
                && account.Context.StorageAccount != null)
            {
                context.SetCurrentStorageAccount(account.Context.StorageAccount.ToString(true));
            }
        }

        /// <summary>
        /// Get the current storage account.
        /// </summary>
        /// <param name="context">The current context.</param>
        /// <returns>The current storage account, or null, if no current storage account is set.</returns>
        public static CloudStorageAccount GetCurrentStorageAccount(this AzureContext context)
        {
            if (context != null && context.Subscription != null)
            {
                try
                {
                    return
                        CloudStorageAccount.Parse(
                            context.Subscription.GetProperty(AzureSubscription.Property.StorageAccount));
                }
                catch
                {
                    // return null if we could not parse the connection string
                }
            }

            return null;
        }

    }
}
