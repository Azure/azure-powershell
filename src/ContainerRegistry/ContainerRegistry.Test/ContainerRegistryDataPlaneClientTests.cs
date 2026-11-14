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

using Microsoft.Azure.Commands.Common.Authentication;
using Microsoft.Azure.Commands.Common.Authentication.Abstractions;
using Microsoft.Azure.Commands.Common.Authentication.Models;
using Microsoft.Azure.Commands.Common.Exceptions;
using Microsoft.Azure.Commands.ScenarioTest;
using Microsoft.Azure.Management.Internal.Resources;
using Microsoft.Azure.Management.Internal.Resources.Models;
using Microsoft.Rest.Azure;
using Microsoft.Rest.Azure.OData;
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using Moq;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Management.Automation;
using System.Management.Automation.Runspaces;
using System.Net;
using System.Net.Http;
using System.Threading;
using Xunit;

namespace Microsoft.Azure.Commands.ContainerRegistry.Test
{
    [Trait(Category.AcceptanceType, Category.CheckIn)]
    public class ContainerRegistryDataPlaneClientTests : IDisposable
    {
        private const string RegistryName = "myregistry";
        private const string LoginServer = "myregistry-fedcba9876543210.azurecr.io";
        private readonly AzureContext context;
        private readonly Mock<IResourceManagementClient> managementClient = new Mock<IResourceManagementClient>(MockBehavior.Strict);
        private readonly Mock<IResourcesOperations> resources = new Mock<IResourcesOperations>(MockBehavior.Strict);
        private readonly List<ContainerRegistryDataPlaneClient> clients = new List<ContainerRegistryDataPlaneClient>();
        private readonly List<string> warnings = new List<string>();
        private readonly string resourceId;
        private int factoryCalls;
        private string requestedFilter;

        public ContainerRegistryDataPlaneClientTests()
        {
            TestExecutionHelpers.SetUpSessionAndProfile();
            AzureSession.Instance.RegisterComponent<AuthenticationTelemetry>(
                AuthenticationTelemetry.Name, () => new AuthenticationTelemetry());
            context = new AzureContext(
                new AzureSubscription { Id = Guid.NewGuid().ToString() },
                new AzureAccount { Id = "offline@example.invalid", Type = AzureAccount.AccountType.User },
                new AzureEnvironment(AzureEnvironment.PublicEnvironments[EnvironmentName.AzureCloud]),
                new AzureTenant { Id = Guid.NewGuid().ToString() });
            resourceId = "/subscriptions/" + context.Subscription.Id +
                "/resourceGroups/offline-rg/providers/Microsoft.ContainerRegistry/registries/" + RegistryName;
            managementClient.SetupGet(client => client.Resources).Returns(resources.Object);
            managementClient.Setup(client => client.Dispose());
            SetupList(new ResourcePage { Registry() });
            SetupProperties(new JObject { ["loginServer"] = LoginServer });
        }

        [Theory]
        [InlineData("MyRegistry-0123456789ABCDEF")]
        [InlineData("abcde-0123456789abcdef")]
        [InlineData("myregistry-microsoft")]
        [InlineData("MyRegistry-MiCrOsOfT")]
        [InlineData("abcde-microsoft")]
        [InlineData("myregistry-on")]
        [InlineData("myregistry-Custom42")]
        [InlineData("abcde-x")]
        [InlineData("abcde-0123456789abcde")]
        [InlineData("abcde-0123456789abcdef0")]
        [InlineData("myregistry-microsoftx")]
        public void ExplicitLoginServerLabelDoesNotInvokeDiscovery(string label)
        {
            var client = CreateClient();
            client.SetEndPoint(label);

            Assert.Equal(label.ToLowerInvariant() + ".azurecr.io", client.GetEndPoint());
            Assert.Equal("https://" + client.GetEndPoint(), client.GetClient().LoginUri);
            Assert.Equal(0, factoryCalls);
            Assert.Empty(warnings);
            resources.VerifyNoOtherCalls();
        }

        public static TheoryData<string> InvalidRegistryNames => new TheoryData<string>
        {
            null,
            "",
            "abcd",
            new string('a', 51),
            " abcde",
            "abcde ",
            "abc de",
            "abc-de",
            "abcd-" + new string('a', 16),
            new string('a', 47) + "-" + new string('b', 16),
            "abcde-",
            "-abcde",
            "abcde--suffix",
            "abcde-suffix-",
            "abcde-" + new string('a', 58),
            "abcd-microsoft",
            new string('a', 51) + "-microsoft",
            "abcde-microsoft-microsoft",
            "abcde-microsoft.azurecr.io",
            "abcde-microsoft/path",
            "abcde-microsoft\n",
            "abcde-micro\u017Foft",
            "abc_de",
            "abcde.azurecr.io",
            "https://abcde.azurecr.io",
            "abcde/path",
            "abcde:443",
            "abcde\n",
            "abcd\u00e9",
            "abcd\u0661",
            "abcde; throw \"Registry name evaluated\"",
            "collector.example/path",
            "myregistry-0123456789abcdef\n"
        };

        [Theory]
        [MemberData(nameof(InvalidRegistryNames))]
        public void InvalidInputFailsBeforeDiscovery(string name)
        {
            var client = CreateClient();
            var exception = Assert.Throws<AzPSArgumentException>(() => client.SetEndPoint(name));
            Assert.Equal("RegistryName", exception.ParamName);
            Assert.Equal(0, factoryCalls);
            Assert.Empty(warnings);
        }

        [Theory]
        [MemberData(nameof(InvalidRegistryNames))]
        public void InvalidInputPreservesPreviouslyResolvedEndpoint(string name)
        {
            var client = CreateClient();
            client.SetEndPoint(RegistryName);
            var exception = Assert.Throws<AzPSArgumentException>(() => client.SetEndPoint(name));

            Assert.Equal("RegistryName", exception.ParamName);
            Assert.Equal(LoginServer, client.GetEndPoint());
            Assert.Equal("https://" + LoginServer, client.GetClient().LoginUri);
            Assert.Equal(1, factoryCalls);
            VerifyList(Times.Once());
            VerifyGet(Times.Once());
            Assert.Empty(warnings);
        }

        [Theory]
        [InlineData("IMAGE123", "image123.azurecr.io")]
        [InlineData("IMAGE123-0123456789ABCDEF", "image123-0123456789abcdef.azurecr.io")]
        [InlineData("IMAGE123-MICROSOFT", "image123-microsoft.azurecr.io")]
        public void EndpointFormattingIsIndependentOfCurrentCulture(string name, string expectedServer)
        {
            var originalCulture = CultureInfo.CurrentCulture;
            context.Subscription.Id = null;
            var client = CreateClient();
            try
            {
                CultureInfo.CurrentCulture = CultureInfo.GetCultureInfo("tr-TR");
                client.SetEndPoint(name);

                Assert.Equal(expectedServer, client.GetEndPoint());
                Assert.Equal("https://" + expectedServer, client.GetClient().LoginUri);
                Assert.Equal(0, factoryCalls);
            }
            finally
            {
                CultureInfo.CurrentCulture = originalCulture;
            }
        }

        [Theory]
        [InlineData(5, 57)]
        [InlineData(46, 16)]
        [InlineData(47, 15)]
        [InlineData(50, 12)]
        public void LoginServerLabelLengthBoundaryIsEnforcedWithoutDiscovery(int prefixLength, int suffixLength)
        {
            var client = CreateClient();
            string label = new string('A', prefixLength) + "-" + new string('B', suffixLength);
            client.SetEndPoint(label);
            Assert.Equal(label.ToLowerInvariant() + ".azurecr.io", client.GetEndPoint());
            Assert.Throws<AzPSArgumentException>(() => client.SetEndPoint(label + "B"));
            Assert.Equal(0, factoryCalls);
        }

        [Fact]
        public void LoginServerPrefixLengthBoundaryIsEnforcedWithoutDiscovery()
        {
            var client = CreateClient();
            string label = new string('A', 50) + "-x";
            client.SetEndPoint(label);
            Assert.Equal(label.ToLowerInvariant() + ".azurecr.io", client.GetEndPoint());
            Assert.Throws<AzPSArgumentException>(() => client.SetEndPoint("A" + label));
            Assert.Equal(0, factoryCalls);
            Assert.Empty(warnings);
        }

        [Fact]
        public void MissingSubscriptionFallbackDoesNotPreventLaterDiscovery()
        {
            string subscriptionId = context.Subscription.Id;
            context.Subscription.Id = null;
            var client = CreateClient();
            client.SetEndPoint(RegistryName);
            Assert.Equal("myregistry.azurecr.io", client.GetEndPoint());
            Assert.Equal(0, factoryCalls);
            Assert.Single(warnings);

            context.Subscription.Id = subscriptionId;
            client.SetEndPoint(RegistryName);
            Assert.Equal(LoginServer, client.GetEndPoint());
            Assert.Equal(1, factoryCalls);
        }

        [Fact]
        public void SuccessfulDiscoveryUsesRegistryApiAndCachesResult()
        {
            var client = CreateClient();
            client.SetEndPoint("MyRegistry");

            Assert.Equal(LoginServer, client.GetEndPoint());
            Assert.Equal("https://" + LoginServer, client.GetClient().LoginUri);
            Assert.Contains("Microsoft.ContainerRegistry/registries", requestedFilter);
            Assert.Contains("MyRegistry", requestedFilter);

            client.SetEndPoint("MYREGISTRY");
            Assert.Equal(LoginServer, client.GetEndPoint());
            Assert.Equal(1, factoryCalls);
            Assert.Empty(warnings);
            VerifyGet(Times.Once());
            VerifyList(Times.Once());
            managementClient.Verify(clientMock => clientMock.Dispose(), Times.Once());
        }

        [Theory]
        [InlineData("myregistry-0123456789abcdef")]
        [InlineData("myregistry-microsoft")]
        public void ExplicitLoginServerLabelDoesNotUseCachedPlainNameResolution(string label)
        {
            var client = CreateClient();
            client.SetEndPoint(RegistryName);
            client.SetEndPoint(label);
            Assert.Equal(label + ".azurecr.io", client.GetEndPoint());
            client.SetEndPoint(RegistryName);
            Assert.Equal(LoginServer, client.GetEndPoint());
            Assert.Equal(1, factoryCalls);
        }

        [Fact]
        public void DiscoveryFollowsNextPageAndCachesTheCompletedResult()
        {
            const string nextLink = "https://management.azure.com/offline-next-page";
            SetupList(new ResourcePage { NextPageLink = nextLink });
            resources.Setup(operations => operations.ListNextWithHttpMessagesAsync(
                    nextLink, null, It.IsAny<CancellationToken>()))
                .ReturnsAsync(() => PageResponse(new ResourcePage { Registry() }));
            var client = CreateClient();

            client.SetEndPoint(RegistryName);
            client.SetEndPoint(RegistryName);

            Assert.Equal(LoginServer, client.GetEndPoint());
            Assert.Equal(1, factoryCalls);
            resources.Verify(operations => operations.ListNextWithHttpMessagesAsync(
                nextLink, null, It.IsAny<CancellationToken>()), Times.Once());
            VerifyGet(Times.Once());
        }

        [Fact]
        public void CacheIsLocalToEachClient()
        {
            CreateClient().SetEndPoint(RegistryName);
            CreateClient().SetEndPoint(RegistryName);
            Assert.Equal(2, factoryCalls);
            VerifyGet(Times.Exactly(2));
        }

        [Theory]
        [InlineData("subscription")]
        [InlineData("tenant")]
        [InlineData("account")]
        [InlineData("environment")]
        [InlineData("armEndpoint")]
        public void ChangedContextDoesNotReuseCachedResolution(string field)
        {
            var client = CreateClient();
            client.SetEndPoint(RegistryName);
            switch (field)
            {
                case "subscription":
                    context.Subscription.Id = Guid.NewGuid().ToString();
                    break;
                case "tenant":
                    context.Tenant.Id = Guid.NewGuid().ToString();
                    break;
                case "account":
                    context.Account.Id = "another-offline@example.invalid";
                    break;
                case "environment":
                    context.Environment.Name = "AnotherEnvironment";
                    break;
                case "armEndpoint":
                    context.Environment.SetEndpoint(AzureEnvironment.Endpoint.ResourceManager, "https://management.example.invalid/");
                    break;
            }
            const string updatedServer = "myregistry-aaaaaaaaaaaaaaaa.azurecr.io";
            SetupProperties(new JObject { ["loginServer"] = updatedServer });
            client.SetEndPoint(RegistryName);
            Assert.Equal(updatedServer, client.GetEndPoint());
            Assert.Equal(2, factoryCalls);
            VerifyGet(Times.Exactly(2));
        }

        [Fact]
        public void DifferentRegistryNamesHaveSeparateCacheEntries()
        {
            var client = CreateClient();
            client.SetEndPoint(RegistryName);
            const string otherName = "otherregistry";
            string otherId = resourceId.Replace(RegistryName, otherName);
            SetupList(new ResourcePage { new GenericResource(id: otherId, name: otherName, type: "Microsoft.ContainerRegistry/registries") });
            resources.Setup(operations => operations.GetByIdWithHttpMessagesAsync(
                    otherId.TrimStart('/'), "2023-07-01", null, It.IsAny<CancellationToken>()))
                .ReturnsAsync(() => ResourceResponse(new JObject { ["loginServer"] = "otherregistry.azurecr.io" }));

            client.SetEndPoint(otherName);
            Assert.Equal("otherregistry.azurecr.io", client.GetEndPoint());
            client.SetEndPoint(RegistryName);
            Assert.Equal(LoginServer, client.GetEndPoint());
            Assert.Equal(2, factoryCalls);
        }

        [Theory]
        [InlineData("notFound")]
        [InlineData("missing")]
        [InlineData("nullProperties")]
        [InlineData("empty")]
        [InlineData("whitespace")]
        [InlineData("wrongType")]
        [InlineData("duplicate")]
        [InlineData("forbidden")]
        [InlineData("network")]
        public void FallbackIsWarnedAndNotCached(string failure)
        {
            switch (failure)
            {
                case "notFound":
                    SetupList(new ResourcePage());
                    break;
                case "missing":
                    SetupProperties(new JObject());
                    break;
                case "nullProperties":
                    SetupProperties(null);
                    break;
                case "empty":
                    SetupProperties(new JObject { ["loginServer"] = "" });
                    break;
                case "whitespace":
                    SetupProperties(new JObject { ["loginServer"] = " " });
                    break;
                case "wrongType":
                    SetupProperties(new JObject { ["loginServer"] = 42 });
                    break;
                case "duplicate":
                    SetupList(new ResourcePage { Registry(), Registry() });
                    break;
                case "forbidden":
                    resources.Setup(operations => operations.ListWithHttpMessagesAsync(
                            It.IsAny<ODataQuery<GenericResourceFilter>>(), null, It.IsAny<CancellationToken>()))
                        .ThrowsAsync(new CloudException("Offline forbidden response")
                        {
                            Response = new Microsoft.Rest.HttpResponseMessageWrapper(
                                new HttpResponseMessage(HttpStatusCode.Forbidden), string.Empty)
                        });
                    break;
                case "network":
                    resources.Setup(operations => operations.ListWithHttpMessagesAsync(
                            It.IsAny<ODataQuery<GenericResourceFilter>>(), null, It.IsAny<CancellationToken>()))
                        .ThrowsAsync(new HttpRequestException("Offline network failure"));
                    break;
            }
            var client = CreateClient();
            client.SetEndPoint(RegistryName);
            Assert.Equal("myregistry.azurecr.io", client.GetEndPoint());
            Assert.Single(warnings);

            SetupList(new ResourcePage { Registry() });
            SetupProperties(new JObject { ["loginServer"] = LoginServer });
            client.SetEndPoint(RegistryName);
            Assert.Equal(LoginServer, client.GetEndPoint());
            client.SetEndPoint(RegistryName);
            Assert.Equal(2, factoryCalls);
            Assert.Single(warnings);
        }

        [Theory]
        [InlineData(false, LoginServer)]
        [InlineData(true, LoginServer)]
        [InlineData(false, "myregistry-microsoft.azurecr.io")]
        [InlineData(true, "myregistry-microsoft.azurecr.io")]
        public void LoginConsumersUseDiscoveredServer(bool exposeToken, string loginServer)
        {
            SetupProperties(new JObject { ["loginServer"] = loginServer });
            var client = CreateClient();
            var session = InitialSessionState.CreateDefault();
            session.Commands.Add(new SessionStateCmdletEntry(
                "Test-RegistryLogin", typeof(TestRegistryLoginCommand), null));
            using (var runspace = RunspaceFactory.CreateRunspace(session))
            {
                runspace.Open();
                runspace.SessionStateProxy.SetVariable("RegistryClientUnderTest", client);
                using (var powershell = System.Management.Automation.PowerShell.Create())
                {
                    powershell.Runspace = runspace;
                    powershell.AddScript(
                        "function global:docker { [pscustomobject]@{ Arguments = @($args); Password = @($input) } }");
                    powershell.Invoke();
                    powershell.Commands.Clear();
                    powershell.AddCommand("Test-RegistryLogin")
                        .AddParameter("Name", RegistryName)
                        .AddParameter("UserName", "offline-user")
                        .AddParameter("Password", "offline-password")
                        .AddParameter("DefaultProfile", new AzureRmProfile { DefaultContext = context })
                        .AddParameter("ExposeToken", exposeToken);
                    var output = powershell.Invoke();

                    Assert.Empty(powershell.Streams.Error);
                    Assert.Single(output);
                    if (exposeToken)
                    {
                        Assert.Equal(loginServer, output[0].Properties["loginServer"].Value);
                        Assert.IsType<System.Security.SecureString>(output[0].Properties["accessToken"].Value);
                    }
                    else
                    {
                        var items = Assert.IsType<List<object>>(output[0].BaseObject);
                        var capture = PSObject.AsPSObject(Assert.Single(items));
                        var arguments = Assert.IsType<object[]>(capture.Properties["Arguments"].Value);
                        Assert.Equal(loginServer, arguments[1]);
                        Assert.Equal("--password-stdin", arguments[4]);
                    }
                    Assert.Equal(1, factoryCalls);
                }
            }
        }

        private ContainerRegistryDataPlaneClient CreateClient()
        {
            var client = new ContainerRegistryDataPlaneClient(context, "RegistryDiscoveryTests", () =>
            {
                factoryCalls++;
                return managementClient.Object;
            });
            client.WarningLogger = warnings.Add;
            clients.Add(client);
            return client;
        }

        private GenericResource Registry()
        {
            return new GenericResource(id: resourceId, name: RegistryName, type: "Microsoft.ContainerRegistry/registries");
        }

        private void SetupList(ResourcePage page)
        {
            resources.Setup(operations => operations.ListWithHttpMessagesAsync(
                    It.IsAny<ODataQuery<GenericResourceFilter>>(), null, It.IsAny<CancellationToken>()))
                .Callback<ODataQuery<GenericResourceFilter>, Dictionary<string, List<string>>, CancellationToken>(
                    (filter, headers, cancellation) => requestedFilter = filter.Filter)
                .ReturnsAsync(() => PageResponse(page));
        }

        private void SetupProperties(object properties)
        {
            resources.Setup(operations => operations.GetByIdWithHttpMessagesAsync(
                    resourceId.TrimStart('/'), "2023-07-01", null, It.IsAny<CancellationToken>()))
                .ReturnsAsync(() => ResourceResponse(properties));
        }

        private static AzureOperationResponse<IPage<GenericResource>> PageResponse(ResourcePage page)
        {
            return new AzureOperationResponse<IPage<GenericResource>> { Body = page };
        }

        private static AzureOperationResponse<GenericResource> ResourceResponse(object properties)
        {
            return new AzureOperationResponse<GenericResource>
            {
                Body = new GenericResource(properties: properties)
            };
        }

        private void VerifyList(Times times)
        {
            resources.Verify(operations => operations.ListWithHttpMessagesAsync(
                It.IsAny<ODataQuery<GenericResourceFilter>>(), null, It.IsAny<CancellationToken>()), times);
        }

        private void VerifyGet(Times times)
        {
            resources.Verify(operations => operations.GetByIdWithHttpMessagesAsync(
                resourceId.TrimStart('/'), "2023-07-01", null, It.IsAny<CancellationToken>()), times);
        }

        public void Dispose()
        {
            foreach (var client in clients)
            {
                client.GetClient().Dispose();
            }
        }

        private class ResourcePage : List<GenericResource>, IPage<GenericResource>
        {
            public string NextPageLink { get; set; }
        }
    }

    [Cmdlet(VerbsDiagnostic.Test, "RegistryLogin", DefaultParameterSetName = "WithNameAndPasswordParameterSet")]
    public class TestRegistryLoginCommand : ConnectAzureContainerRegistry
    {
        public override void ExecuteCmdlet()
        {
            RegistryDataPlaneClient =
                (ContainerRegistryDataPlaneClient)SessionState.PSVariable.GetValue("RegistryClientUnderTest");
            base.ExecuteCmdlet();
        }
    }
}
