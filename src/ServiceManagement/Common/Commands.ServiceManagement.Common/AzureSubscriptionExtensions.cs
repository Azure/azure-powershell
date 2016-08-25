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
using System;

namespace Microsoft.WindowsAzure.Commands.Common
{
    public static class AzureSubscriptionExtensions
    {

        public static string GetStorageAccountName(this AzureSubscription subscription)
        {
            if (subscription == null || !subscription.IsPropertySet(AzureSubscription.Property.StorageAccount))
            {
                return null;
            }

            var result = subscription.GetProperty(AzureSubscription.Property.StorageAccount);
            if (!string.IsNullOrWhiteSpace(result))
            {
                try
                {
                    var pairs = result.Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
                    foreach (var pair in pairs)
                    {
                        var sides = pair.Split(new char[] { '=' }, 2, StringSplitOptions.RemoveEmptyEntries);
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
