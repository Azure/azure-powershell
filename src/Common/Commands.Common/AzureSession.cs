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
using Microsoft.WindowsAzure.Commands.Common.Common;
using Microsoft.WindowsAzure.Commands.Common.Factories;
using Microsoft.WindowsAzure.Commands.Common.Models;
using Microsoft.WindowsAzure.Commands.Common.Properties;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using Microsoft.WindowsAzure.Commands.Utilities.Common.Authentication;

namespace Microsoft.WindowsAzure.Commands.Common
{
    public static class AzureSession
    {
        static AzureSession()
        {
            ClientFactory = new AzurePowerShellClientFactory();
            AuthenticationFactory = new AuthenticationFactory();
            CurrentContext = new AzureContext();
            CurrentContext.Environment = AzureEnvironment.PublicEnvironments[EnvironmentName.AzureCloud];
        }

        public static AzureContext CurrentContext {get; private set; }
        
        public static void SetCurrentContext(AzureSubscription subscription, AzureEnvironment environment, AzureAccount account)
        {
            if (environment == null)
            {
                if (subscription != null && CurrentContext != null &&
                    subscription.Environment == CurrentContext.Environment.Name)
                {
                    environment = CurrentContext.Environment;
                }
                else
                {
                    environment = AzureEnvironment.PublicEnvironments[EnvironmentName.AzureCloud];
                }

                if (subscription != null)
                {
                    subscription.Environment = environment.Name;
                }
            }

            if (account == null)
            {
                if (subscription != null && CurrentContext != null && subscription.Account != null)
                {
                    if (CurrentContext.Account != null && subscription.Account == CurrentContext.Account.Id)
                    {
                        account = CurrentContext.Account;
                    }
                    else
                    {
                        throw new ArgumentException(Resources.AccountIdDoesntMatchSubscription, "account");
                    }

                    subscription.Account = account.Id;

                }
            }

            if (subscription != null && subscription.Environment != environment.Name)
            {
                throw new ArgumentException(Resources.EnvironmentNameDoesntMatchSubscription, "environment");
            }

            CurrentContext = new AzureContext
            {
                Subscription = subscription,
                Account = account,
                Environment = environment
            };
        }

        public static IClientFactory ClientFactory { get; set; }

        public static IAuthenticationFactory AuthenticationFactory { get; set; }
    }
}
