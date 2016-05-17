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
using Microsoft.Azure.ServiceManagemenet.Common.Models;
using System;
using System.Collections.Generic;

namespace Microsoft.WindowsAzure.Commands.Common
{
    public static class ProfileClientExtensions
    {
        public static PSAzureAccount ToPSAzureAccount(this AzureAccount account)
        {
            string subscriptionsList = account.GetProperty(AzureAccount.Property.Subscriptions);
            string tenantsList = account.GetProperty(AzureAccount.Property.Tenants);

            return new PSAzureAccount
            {
                Id = account.Id,
                Type = account.Type,
                Subscriptions = subscriptionsList == null ? "" : subscriptionsList.Replace(",", "\r\n"),
                Tenants = tenantsList == null ? null : new List<string>(tenantsList.Split(new[] { "," }, StringSplitOptions.RemoveEmptyEntries))
            };
        }
    }
}
