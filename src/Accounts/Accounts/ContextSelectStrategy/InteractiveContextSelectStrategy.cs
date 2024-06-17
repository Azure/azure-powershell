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

using Microsoft.Azure.Commands.Common;
using Microsoft.Azure.Commands.Common.Authentication.Abstractions;
using Microsoft.Azure.Commands.Common.Strategies;
using Microsoft.Azure.Commands.Profile.Utilities;
using Microsoft.Azure.Commands.ResourceManager.Common;
using Microsoft.Identity.Client;

using System;
using System.Collections.Generic;
using System.Linq;

namespace Microsoft.Azure.Commands.Profile.ContextSelectStrategy
{
    public class InteractiveContextSelectStrategy : ContextSelectStrategy
    {
        RMProfileClient ProfileClient;
        
        public InteractiveContextSelectStrategy(RMProfileClient profileClient) {
            ProfileClient = profileClient;
        }

        public override (IAzureTenant, IAzureSubscription) GetDefaultTenantAndSubscription(ContextSelectParameter selectParameter)
        {
            IAzureTenant defaultTenant = null;
            IAzureSubscription defaultSubscription = null;

            InteractiveContextSelectionHelper.SelectContextFromList(
                selectParameter.PopulatedSubscriptions, selectParameter.QueriedTenants, selectParameter.TenantIdOrName, selectParameter.TenantName, selectParameter.LastUsedSubscription,
                Prompt, WriteInformationMessage,
                ref defaultSubscription, ref defaultTenant);
            return (defaultTenant, defaultSubscription);
        }

        private string Prompt(string message) => ProfileClient.Prompt(message);
        private void WriteDebugMessage(string message) => ProfileClient.WriteDebugMessage(message);
        private void WriteWarningMessage(string message) => ProfileClient.WriteWarningMessage(message);
        private void WriteInformationMessage(string message) => ProfileClient.WriteInformationMessage(message);

    }
}
