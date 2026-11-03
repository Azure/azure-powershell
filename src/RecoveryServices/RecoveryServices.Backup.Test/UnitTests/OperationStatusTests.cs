// ----------------------------------------------------------------------------------
//
// Copyright Microsoft Corporation
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// ----------------------------------------------------------------------------------

extern alias BackupSdk;

using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Azure.Commands.Common.Authentication;
using Microsoft.Azure.Commands.Common.Authentication.Abstractions;
using Microsoft.Azure.Commands.Common.Authentication.Models;
using Microsoft.Azure.Commands.RecoveryServices.Backup.Cmdlets.ServiceClientAdapterNS;
using Microsoft.Azure.Commands.TestFx.Mocks;
using Microsoft.Rest;
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using Xunit;
using BackupClient = BackupSdk::Microsoft.Azure.Management.RecoveryServices.Backup.RecoveryServicesBackupClient;

namespace Microsoft.Azure.Commands.RecoveryServices.Backup.Test.UnitTests
{
    public class OperationStatusTests
    {
        [Theory]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [InlineData(true, "InProgress")]
        [InlineData(true, "Succeeded")]
        [InlineData(true, "Failed")]
        [InlineData(true, "Canceled")]
        [InlineData(false, "Succeeded")]
        public void OperationStatusPreservesScopeAndServiceResult(bool scoped, string status)
        {
            const string subscriptionId = "11111111-1111-1111-1111-111111111111";
            const string containerName = "IaasVMContainer;iaasvmcontainerv2;vm-rg;vm";
            const string itemName = "VM;iaasvmcontainerv2;vm-rg;vm";
            const string operationId = "22222222-2222-2222-2222-222222222222";
            var handler = new OperationStatusHandler(status);
            using (var client = new BackupClient(new TokenCredentials("test-token"), handler))
            {
                client.SubscriptionId = subscriptionId;
                AzureSessionInitializer.InitializeAzureSession();
                var originalFactory = AzureSession.Instance.ClientFactory;
                try
                {
                    AzureSession.Instance.ClientFactory = new MockClientFactory(null, new List<object> { client });
                    var context = new AzureContext
                    {
                        Subscription = new AzureSubscription { Id = subscriptionId }
                    };
                    var adapter = new ServiceClientAdapter(context);
                    var response = scoped
                        ? adapter.GetScopedProtectedItemOperationStatus(
                            containerName, itemName, operationId, "explicit-vault", "explicit-rg")
                        : adapter.GetProtectedItemOperationStatus(operationId, "explicit-vault", "explicit-rg");

                    string expectedPath = $"/subscriptions/{subscriptionId}/resourceGroups/explicit-rg/providers/Microsoft.RecoveryServices/vaults/explicit-vault/";
                    expectedPath += scoped
                        ? $"backupFabrics/Azure/protectionContainers/{containerName}/protectedItems/{itemName}/operationsStatus/{operationId}"
                        : $"backupOperations/{operationId}";
                    Assert.Equal(expectedPath, Uri.UnescapeDataString(handler.RequestUri.AbsolutePath));
                    Assert.Equal("?api-version=2026-10-01", handler.RequestUri.Query);
                    Assert.Equal(HttpMethod.Get, handler.RequestMethod);
                    Assert.Equal(status, response.Body.Status);
                    if (status == "Failed")
                    {
                        Assert.Equal("TestServiceFailure", response.Body.Error.Code);
                        Assert.Equal("Test service error.", response.Body.Error.Message);
                    }
                }
                finally
                {
                    AzureSession.Instance.ClientFactory = originalFactory;
                }
            }
        }

        private sealed class OperationStatusHandler : DelegatingHandler
        {
            private readonly string status;
            public Uri RequestUri { get; private set; }
            public HttpMethod RequestMethod { get; private set; }

            public OperationStatusHandler(string status)
            {
                this.status = status;
            }

            protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
            {
                RequestUri = request.RequestUri;
                RequestMethod = request.Method;
                string error = status == "Failed"
                    ? ",\"error\":{\"code\":\"TestServiceFailure\",\"message\":\"Test service error.\"}"
                    : string.Empty;
                return Task.FromResult(new HttpResponseMessage(HttpStatusCode.OK)
                {
                    RequestMessage = request,
                    Content = new StringContent("{\"status\":\"" + status + "\"" + error + "}")
                });
            }
        }
    }
}
