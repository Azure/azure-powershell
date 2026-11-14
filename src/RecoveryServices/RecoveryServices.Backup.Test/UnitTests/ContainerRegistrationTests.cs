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
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Azure.Commands.Common.Authentication;
using Microsoft.Azure.Commands.Common.Authentication.Abstractions;
using Microsoft.Azure.Commands.Common.Authentication.Models;
using Microsoft.Azure.Commands.RecoveryServices.Backup.Cmdlets.Models;
using Microsoft.Azure.Commands.RecoveryServices.Backup.Cmdlets.ProviderModel;
using Microsoft.Azure.Commands.RecoveryServices.Backup.Cmdlets.ServiceClientAdapterNS;
using Microsoft.Azure.Commands.TestFx.Mocks;
using Microsoft.Rest;
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using Newtonsoft.Json.Linq;
using Xunit;
using Xunit.Abstractions;
using BackupClient = BackupSdk::Microsoft.Azure.Management.RecoveryServices.Backup.RecoveryServicesBackupClient;
using Sdk = BackupSdk::Microsoft.Azure.Management.RecoveryServices.Backup.Models;

namespace Microsoft.Azure.Commands.RecoveryServices.Backup.Test.UnitTests
{
    public class ContainerRegistrationTests
    {
        private const string VaultSubscription = "11111111-1111-1111-1111-111111111111";
        private const string OtherSubscription = "22222222-2222-2222-2222-222222222222";
        private const string VaultId = "/subscriptions/" + VaultSubscription +
            "/resourceGroups/vault-rg/providers/Microsoft.RecoveryServices/vaults/test-vault";
        private const string VmSuffix = "/resourceGroups/vm-rg/providers/Microsoft.Compute/virtualMachines/sql-vm";
        private readonly ITestOutputHelper output;

        public ContainerRegistrationTests(ITestOutputHelper output)
        {
            this.output = output;
        }

        [Theory]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [InlineData(false, false, false, "SQLDataBase")]
        [InlineData(false, true, true, "SQLDataBase")]
        [InlineData(true, false, false, "SQLDataBase")]
        [InlineData(true, true, false, "SQLDataBase")]
        [InlineData(true, true, true, "SQLDataBase")]
        [InlineData(false, false, false, "SQLInstance")]
        [InlineData(true, false, false, "SQLInstance")]
        [InlineData(true, true, false, "SQLInstance")]
        [InlineData(true, true, true, "SQLInstance")]
        public void RegistrationMatchesFullResourceId(bool crossSubscription, bool requestedLast, bool differentCase, string workloadType)
        {
            string requestedSubscription = crossSubscription ? OtherSubscription : VaultSubscription;
            string requestedId = "/subscriptions/" + requestedSubscription + VmSuffix;
            string otherId = "/subscriptions/" + (crossSubscription ? VaultSubscription : OtherSubscription) + VmSuffix;
            JObject requested = CreateCandidate(requestedId);
            JObject other = CreateCandidate(otherId);
            var discovered = requestedLast ? new JArray(other, requested) : new JArray(requested, other);
            var handler = new ContainerRegistrationHandler(discovered);
            var data = CreateProviderData(differentCase ? requestedId.ToUpperInvariant() : requestedId);
            data[ContainerParams.ContainerType] = workloadType;
            if (crossSubscription)
            {
                data[ContainerParams.ContainerSubscriptionId] = requestedSubscription;
            }

            Register(data, handler);

            JObject registration = Assert.Single(handler.Registrations);
            Assert.Equal(requestedId, (string)registration["properties"]["sourceResourceId"]);
            Assert.Equal("Register", (string)registration["properties"]["operationType"]);
            Assert.Equal(workloadType, (string)registration["properties"]["workloadType"]);
            Assert.Equal(VaultId + "/backupFabrics/Azure/protectionContainers/" + (string)requested["name"],
                Uri.UnescapeDataString(handler.RegistrationUri.AbsolutePath));
            if (crossSubscription)
            {
                Assert.Contains("containerSubscriptionId eq '" + requestedSubscription + "'", handler.RefreshQuery);
            }
            else
            {
                Assert.DoesNotContain("containerSubscriptionId", handler.RefreshQuery);
            }
        }

        [Theory]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [InlineData("subscription")]
        [InlineData("resource-group")]
        [InlineData("vm")]
        [InlineData("missing-id")]
        [InlineData("missing-properties")]
        [InlineData("empty")]
        public void RegistrationDoesNotFallBackToAnotherResource(string mismatch)
        {
            string requestedId = "/subscriptions/" + OtherSubscription + VmSuffix;
            string candidateId = requestedId;
            if (mismatch == "subscription")
            {
                candidateId = "/subscriptions/" + VaultSubscription + VmSuffix;
            }
            else if (mismatch == "resource-group")
            {
                candidateId = requestedId.Replace("/vm-rg/", "/other-rg/");
            }
            else if (mismatch == "vm")
            {
                candidateId = requestedId.Replace("/sql-vm", "/other-vm");
            }

            JObject candidate = CreateCandidate(candidateId);
            if (mismatch == "missing-id")
            {
                candidate["properties"]["containerId"] = null;
            }
            else if (mismatch == "missing-properties")
            {
                candidate["properties"] = null;
            }
            var handler = new ContainerRegistrationHandler(
                mismatch == "empty" ? new JArray() : new JArray(candidate));

            ArgumentException error = Assert.Throws<ArgumentException>(() => Register(CreateProviderData(requestedId), handler));

            Assert.Contains(requestedId, error.Message);
            Assert.Contains("No unregistered workload container was discovered", error.Message);
            Assert.Empty(handler.Registrations);
        }

        [Theory]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [InlineData(false, "SQLDataBase")]
        [InlineData(true, "SQLDataBase")]
        [InlineData(false, "SQLInstance")]
        [InlineData(true, "SQLInstance")]
        public void ReregistrationUsesSuppliedContainerWithoutResourceId(bool emptyDiscovery, string workloadType)
        {
            string sourceId = "/subscriptions/" + OtherSubscription + VmSuffix;
            const string containerName = "VMAppContainer;compute;vm-rg;sql-vm";
            var container = new AzureVmWorkloadContainer(new Sdk.ProtectionContainerResource(
                VaultId + "/backupFabrics/Azure/protectionContainers/" + containerName, containerName)
            {
                Properties = new Sdk.AzureVMAppContainerProtectionContainer
                {
                    BackupManagementType = "AzureWorkload",
                    SourceResourceId = sourceId,
                    FriendlyName = "sql-vm",
                    RegistrationStatus = "Registered",
                    ExtendedInfo = new Sdk.AzureWorkloadContainerExtendedInfo
                    {
                        InquiryInfo = new Sdk.InquiryInfo
                        {
                            InquiryDetails = new List<Sdk.WorkloadInquiryDetails>
                            {
                                new Sdk.WorkloadInquiryDetails
                                {
                                    Type = "SQL",
                                    InquiryValidation = new Sdk.InquiryValidation { Status = "Success" }
                                }
                            }
                        }
                    }
                }
            });
            var data = CreateProviderData(null);
            data[ContainerParams.ContainerType] = workloadType;
            data[ContainerParams.Container] = container;
            data[ContainerParams.Name] = container.Name;
            var handler = new ContainerRegistrationHandler(emptyDiscovery
                ? new JArray()
                : new JArray(CreateCandidate("/subscriptions/" + VaultSubscription + VmSuffix)));

            Register(data, handler);

            JObject registration = Assert.Single(handler.Registrations);
            Assert.Equal(sourceId, (string)registration["properties"]["sourceResourceId"]);
            Assert.Equal("Reregister", (string)registration["properties"]["operationType"]);
            Assert.Equal(workloadType, (string)registration["properties"]["workloadType"]);
            Assert.Equal(container.Id, Uri.UnescapeDataString(handler.RegistrationUri.AbsolutePath));
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void RegistrationRequiresResourceIdentityBeforeDiscovery()
        {
            var handler = new ContainerRegistrationHandler(new JArray(CreateCandidate(null)));

            Assert.Throws<ArgumentException>(() => Register(CreateProviderData(null), handler));

            Assert.Null(handler.RefreshQuery);
            Assert.Empty(handler.Registrations);
        }

        private static Dictionary<Enum, object> CreateProviderData(string resourceId)
        {
            return new Dictionary<Enum, object>
            {
                { VaultParams.VaultName, "test-vault" },
                { VaultParams.ResourceGroupName, "vault-rg" },
                { ContainerParams.Name, "sql-vm" },
                { ContainerParams.ResourceGroupName, "vm-rg" },
                { ContainerParams.ContainerType, "SQLDataBase" },
                { ContainerParams.BackupManagementType, "AzureWorkload" },
                { ContainerParams.Container, null },
                { ContainerParams.ResourceId, resourceId }
            };
        }

        private void Register(Dictionary<Enum, object> data, ContainerRegistrationHandler handler)
        {
            using (var client = new BackupClient(new TokenCredentials("test-token"), handler))
            {
                client.SubscriptionId = VaultSubscription;
                AzureSessionInitializer.InitializeAzureSession();
                var originalFactory = AzureSession.Instance.ClientFactory;
                var originalLogger = Logger.Instance;
                try
                {
                    Logger.Instance = new Logger(output.WriteLine, output.WriteLine, output.WriteLine,
                        error => throw error.Exception, error => throw error.Exception);
                    AzureSession.Instance.ClientFactory = new MockClientFactory(null, new List<object> { client });
                    var context = new AzureContext
                    {
                        Subscription = new AzureSubscription { Id = VaultSubscription }
                    };
                    var provider = new AzureWorkloadPsBackupProvider();
                    provider.Initialize(data, new ServiceClientAdapter(context));
                    provider.RegisterContainer();
                }
                finally
                {
                    AzureSession.Instance.ClientFactory = originalFactory;
                    Logger.Instance = originalLogger;
                }
            }
        }

        private static JObject CreateCandidate(string resourceId)
        {
            string[] segments = resourceId?.Split('/');
            string name = "VMAppContainer;compute;" + (segments?[2] ?? "unknown") + ";" +
                (segments?[4] ?? "vm-rg") + ";" + (segments?[8] ?? "sql-vm");
            return new JObject
            {
                ["id"] = VaultId + "/backupFabrics/Azure/protectableContainers/" + name,
                ["name"] = name,
                ["properties"] = new JObject
                {
                    ["protectableContainerType"] = "VMAppContainer",
                    ["backupManagementType"] = "AzureWorkload",
                    ["containerId"] = resourceId,
                    ["friendlyName"] = "sql-vm"
                }
            };
        }

        private sealed class ContainerRegistrationHandler : DelegatingHandler
        {
            private readonly JArray discovered;
            public List<JObject> Registrations { get; } = new List<JObject>();
            public Uri RegistrationUri { get; private set; }
            public string RefreshQuery { get; private set; }

            public ContainerRegistrationHandler(JArray discovered)
            {
                this.discovered = discovered;
            }

            protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
            {
                Assert.StartsWith(VaultId + "/backupFabrics/Azure/", Uri.UnescapeDataString(request.RequestUri.AbsolutePath));
                Assert.Contains("api-version=2026-10-01", request.RequestUri.Query);
                string path = request.RequestUri.AbsolutePath;
                if (request.Method == HttpMethod.Post && path.EndsWith("/refreshContainers"))
                {
                    RefreshQuery = Uri.UnescapeDataString(request.RequestUri.Query);
                    var response = new HttpResponseMessage(HttpStatusCode.Accepted) { RequestMessage = request };
                    response.Headers.Location = new Uri("https://management.azure.com" + VaultId +
                        "/backupFabrics/Azure/operationResults/test-operation?api-version=2026-10-01");
                    return response;
                }
                if (request.Method == HttpMethod.Get && path.EndsWith("/operationResults/test-operation"))
                {
                    return new HttpResponseMessage(HttpStatusCode.NoContent) { RequestMessage = request };
                }
                if (request.Method == HttpMethod.Get && path.EndsWith("/protectableContainers"))
                {
                    return JsonResponse(request, new JObject { ["value"] = discovered });
                }
                if (request.Method == HttpMethod.Put && path.Contains("/protectionContainers/"))
                {
                    RegistrationUri = request.RequestUri;
                    JObject body = JObject.Parse(await request.Content.ReadAsStringAsync());
                    Registrations.Add(body);
                    var response = (JObject)body.DeepClone();
                    response["properties"]["registrationStatus"] = "Registered";
                    return JsonResponse(request, response);
                }
                throw new InvalidOperationException("Unexpected registration request: " + request.Method + " " + request.RequestUri);
            }

            private static HttpResponseMessage JsonResponse(HttpRequestMessage request, JObject body)
            {
                return new HttpResponseMessage(HttpStatusCode.OK)
                {
                    RequestMessage = request,
                    Content = new StringContent(body.ToString(), Encoding.UTF8, "application/json")
                };
            }
        }
    }
}
