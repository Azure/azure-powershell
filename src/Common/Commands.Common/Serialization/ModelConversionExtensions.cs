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

namespace Microsoft.Azure.Commands.Common.Serialization
{
    public static class ModelConversionExtensions
    {
        /// <summary>
        /// Convert the older representation of accounts into the newer representation
        /// </summary>
        /// <param name="account">The legacy account to convert</param>
        /// <returns>An AzureAccount model with data copied from the legacy account</returns>
        public static IAzureAccount Convert(this LegacyAzureAccount account)
        {
            var result = new AzureAccount();
            result.Id = account.Id;
            result.Type = ConvertAccountType(account.Type);

            foreach (var property in account.Properties)
            {
                result.SetProperty(property.Key, property.Value);
            }

            if (result.IsPropertySet(AzureAccount.Property.AccessToken))
            {
                result.Credential = result.GetAccessToken();
            }

            return result;
        }

        /// <summary>
        /// Convert the older representation of environments into the newer representation
        /// </summary>
        /// <param name="environment">The legacy environment to convert</param>
        /// <returns>An AzureEnvironment model with data copied from the legacy enbironment</returns>
        public static IAzureEnvironment Convert(this LegacyAzureEnvironment environment)
        {
            var result = new AzureEnvironment();
            result.Name = environment.Name;
            result.OnPremise = environment.OnPremise;
            foreach (var endpoint in environment.Endpoints)
            {
                result.SetEndpoint(endpoint.Key, endpoint.Value);
            }

            return result;
        }

        /// <summary>
        /// Convert the older representation of subscriptions into the newer representation
        /// </summary>
        /// <param name="subscription">The legacy subscription to convert</param>
        /// <returns>An AzureSubscription model with data copied from the legacy subscription</returns>
        public static IAzureSubscription Convert(this LegacyAzureSubscription subscription)
        {
            var result = new AzureSubscription();
            result.Id = subscription.Id.ToString();
            result.Name = subscription.Name;
            result.State = subscription.State;
            result.SetAccount(subscription.Account);
            result.SetEnvironment(subscription.Environment);
            foreach (var property in subscription.Properties)
            {
                result.SetProperty(property.Key, property.Value);
            }

            return result;
        }

        static string ConvertAccountType(int legacyType)
        {
            string result = AzureAccount.AccountType.User;
            switch(legacyType)
            {
                case 0:
                    result = AzureAccount.AccountType.Certificate;
                    break;
                case 1:
                    result = AzureAccount.AccountType.User;
                    break;
                case 2:
                    result = AzureAccount.AccountType.ServicePrincipal;
                    break;
                case 3:
                    result = AzureAccount.AccountType.AccessToken;
                    break;
                default:
                    result = AzureAccount.AccountType.User;
                    break;
            }

            return result;
        }
    }
}
