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

using Microsoft.Azure.Commands.Common.Authentication.Abstractions;
using Microsoft.Azure.Commands.Common.Serialization;
using Microsoft.WindowsAzure.Commands.Utilities.Common;

namespace Microsoft.WindowsAzure.Commands.ServiceManagement.Common.Serialization
{
    public static class RdfeConversionExtensions
    {
        /// <summary>
        /// Try to convert a legacy profile
        /// </summary>
        /// <param name="profile">The legacy profile to convert</param>
        /// <param name="result">The new profile, with data copied form the old</param>
        /// <returns>True if the conversion was successful, false if not</returns>
        public static bool TryConvert(this LegacyAzureSMProfile profile, AzureSMProfile result)
        {
            if (profile != null)
            {
                if (profile.Environments != null)
                {
                    result.EnvironmentTable.Clear();
                    foreach (var environment in profile.Environments)
                    {
                        if (environment != null && !string.IsNullOrWhiteSpace(environment.Name))
                        {
                            result.EnvironmentTable[environment.Name] = environment.Convert();
                        }
                    }

                    foreach (var environment in AzureEnvironment.PublicEnvironments)
                    {
                        result.EnvironmentTable[environment.Key] = environment.Value;
                    }
                }
                if (profile.Accounts != null)
                {
                    result.AccountTable.Clear();
                    foreach (var account in profile.Accounts)
                    {
                        if (account != null && !string.IsNullOrWhiteSpace(account.Id))
                        {
                            result.AccountTable[account.Id] = account.Convert();
                        }
                    }
                }
                if (profile.Subscriptions != null)
                {
                    result.SubscriptionTable.Clear();
                    foreach (var subscription in profile.Subscriptions)
                    {
                        if (subscription != null && subscription.Id != null)
                        {
                            result.SubscriptionTable[subscription.Id] = subscription.Convert();
                        }
                    }
                }

            }

            return profile != null && profile.Accounts != null && profile.Subscriptions != null 
                && profile.Accounts.Count > 0 && profile.Subscriptions.Count > 0;
        }
    }
}
