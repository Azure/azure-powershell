﻿// ----------------------------------------------------------------------------------
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
using System;
using System.Collections.Generic;
using System.Text;

namespace Microsoft.Azure.Commands.Common.Authentication
{
    public class ManagedServiceAppServiceAccessToken : ManagedServiceAccessTokenBase<ManagedServiceAppServiceTokenInfo>
    {
        public ManagedServiceAppServiceAccessToken(IAzureAccount account, IAzureEnvironment environment, string tenant = "organizations")
            : base(account, environment, @"https://management.azure.com/", tenant)
        {
        }

        public ManagedServiceAppServiceAccessToken(IAzureAccount account, IAzureEnvironment environment, string resourceId, string tenant = "organizations")
            : base(account, environment, resourceId, tenant)
        {
        }

        protected override IEnumerable<string> BuildTokenUri(string baseUri, IAzureAccount account, IdentityType identityType,
            string resourceId)
        {
            StringBuilder query = new StringBuilder($"{baseUri}?resource={resourceId}&api-version=2017-09-01");

            if(identityType == IdentityType.ClientId || identityType == IdentityType.ObjectId)
            {
                query.Append($"&clientid={Uri.EscapeDataString(account.Id)}");
            }

            yield return query.ToString();
        }

        protected override void SetToken(ManagedServiceAppServiceTokenInfo infoWebApps)
        {
            if (infoWebApps != null)
            {
                Expiration = infoWebApps.ExpiresOn;
                accessToken = infoWebApps.AccessToken;
            }
        }
    }
}
