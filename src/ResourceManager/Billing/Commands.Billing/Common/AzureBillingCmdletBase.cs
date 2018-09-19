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
using Microsoft.Azure.Commands.Common.Authentication;
using Microsoft.Azure.Commands.Common.Authentication.Models;
using Microsoft.Azure.Commands.ResourceManager.Common;
using Microsoft.Azure.Management.Billing;
using Microsoft.Azure.Commands.Common.Authentication.Abstractions;

namespace Microsoft.Azure.Commands.Billing.Common
{
    /// <summary>
    /// Base class of Azure Billing Cmdlet.
    /// </summary>
    public abstract class AzureBillingCmdletBase : AzureRMCmdlet
    {
        private IBillingManagementClient _billingManagementClient;

        /// <summary>
        /// Gets or sets the Billing management client.
        /// </summary>
        public IBillingManagementClient BillingManagementClient
        {
            get
            {
                return _billingManagementClient ??
                       (_billingManagementClient =
                           AzureSession.Instance.ClientFactory.CreateArmClient<BillingManagementClient>(DefaultProfile.DefaultContext,
                               AzureEnvironment.Endpoint.ResourceManager));
            }
            set { _billingManagementClient = value; }
        }
    }
}
