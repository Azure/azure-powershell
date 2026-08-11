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
using Microsoft.Azure.Commands.Common.Authentication;
using Microsoft.Azure.Commands.Common.Authentication.Models;
using System;
using System.Management.Automation;
using Xunit;

namespace Microsoft.Azure.Commands.Profile.Test.UnitTest
{
    public class GetAzureRMSubscriptionTest
    {
        [Fact]
        public void ManagedServiceTenantMismatchThrows()
        {
            string defaultTenantId = Guid.NewGuid().ToString();
            string requestedTenantId = Guid.NewGuid().ToString();
            var command = new GetAzureRMSubscriptionCommand
            {
                TenantId = requestedTenantId,
                DefaultProfile = new AzureRmProfile
                {
                    DefaultContext = new AzureContext(
                        null,
                        new AzureAccount { Type = AzureAccount.AccountType.ManagedService },
                        null,
                        new AzureTenant { Id = defaultTenantId })
                }
            };

            var exception = Assert.Throws<PSInvalidOperationException>(() => command.ExecuteCmdlet());

            Assert.Equal(
                string.Format(
                    "The current context is using Managed Service Identity (MSI) authentication which only supports the tenant of the Managed Identity ({0}). The requested TenantId '{1}' does not match and cannot be used. Remove the -TenantId parameter or use Connect-AzAccount with a different authentication method to target a different tenant.",
                    defaultTenantId,
                    requestedTenantId),
                exception.Message);
            Assert.Equal(ErrorKind.UserError, exception.Data[AzurePSErrorDataKeys.ErrorKindKey]);
        }
    }
}
