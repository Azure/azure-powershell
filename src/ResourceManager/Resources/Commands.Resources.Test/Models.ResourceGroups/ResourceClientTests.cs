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
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.Serialization.Formatters;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Azure.Commands.ResourceManager.Cmdlets.SdkClient;
using Microsoft.Azure.Commands.ResourceManager.Cmdlets.SdkModels;
using Microsoft.Azure.Commands.Resources.Models;
using Microsoft.Azure.Commands.ScenarioTest;
using Microsoft.Azure.Management.Authorization;
using Microsoft.Azure.Management.ResourceManager;
using Microsoft.Azure.Management.ResourceManager.Models;
using Microsoft.Rest.Azure;
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using Microsoft.WindowsAzure.Commands.Test.Utilities.Common;
using Moq;
using Newtonsoft.Json;
using Xunit;

namespace Microsoft.Azure.Commands.Resources.Test.Models
{
    public class ResourceClientTests : RMTestBase
    {
        private Mock<IResourceManagementClient> resourceManagementClientMock;

        private Mock<IAuthorizationManagementClient> authorizationManagementClientMock;

        private Mock<IDeploymentsOperations> deploymentsMock;

        private Mock<IResourceGroupsOperations> resourceGroupMock;

        private Mock<IResourcesOperations> resourceOperationsMock;

        private Mock<IDeploymentOperationsOperations> deploymentOperationsMock;

        private Mock<IProvidersOperations> providersMock;

        private Mock<Action<string>> progressLoggerMock;

        private Mock<Action<string>> errorLoggerMock;

        private ResourceManagerSdkClient resourcesClient;

        private string resourceGroupName = "myResourceGroup";

        private string resourceGroupLocation = "West US";

        private string deploymentName = "fooDeployment";

        private string templateFile = string.Empty;

        private string storageAccountName = "myStorageAccount";

        private string requestId = "1234567890";

        private string resourceName = "myResource";

        private ResourceIdentifier resourceIdentity;

        private Dictionary<string, object> properties;

        private string serializedProperties;

        private int ConfirmActionCounter = 0;

        private static GenericResource CreateGenericResource(string location = null, string id = null, string name = null, string type = null)
        {
            GenericResource resource = new GenericResource();
            if (id != null)
            {
                typeof(Resource).GetProperty("Id").SetValue(resource, id);
            }
            if (name != null)
            {
                typeof(Resource).GetProperty("Name").SetValue(resource, name);
            }
            if (type != null)
            {
                typeof(Resource).GetProperty("Type").SetValue(resource, type);
            }
            if (location != null)
            {
                resource.Location = location;
            }

            return resource;
        }

        private static AzureOperationResponse<T> CreateAzureOperationResponse<T>(T type)
        {
            return new AzureOperationResponse<T>()
            {
                Body = type
            };
        }

        private void ConfirmAction(bool force, string actionMessage, string processMessage, string target, Action action, Func<bool> predicate)
        {
            ConfirmActionCounter++;
            action();
        }

        private int RejectActionCounter = 0;

        private void RejectAction(bool force, string actionMessage, string processMessage, string target, Action action, Func<bool> predicate)
        {
            RejectActionCounter++;
        }

        private IPage<T> GetPagableType<T>(List<T> collection)
        {
            var pagableResult = new Page<T>();
            pagableResult.SetItemValue<T>(collection);
            return pagableResult;
        }

        private void SetupListForResourceGroupAsync(string name, List<GenericResource> result)
        {
            resourceOperationsMock.Setup(f => f.ListWithHttpMessagesAsync(
                null,
                null,
                new CancellationToken()))
            .Returns(Task.Factory.StartNew(() => new AzureOperationResponse<IPage<GenericResource>>()
            {
                Body = GetPagableType(result)
            }));
        }

        private void SetupListForResourceGroupAsync(string name, IPage<GenericResource> result)
        {
            resourceOperationsMock.Setup(f => f.ListAsync(
                null,
                new CancellationToken()))
                    .Returns(Task.Factory.StartNew(() => result));
        }

        private void EqualsIgnoreWhitespace(string left, string right)
        {
            string normalized1 = Regex.Replace(left, @"\s", "");
            string normalized2 = Regex.Replace(right, @"\s", "");

            Assert.Equal(
                normalized1.ToLowerInvariant(),
                normalized2.ToLowerInvariant());
        }

        private void SetupClass()
        {
            resourceManagementClientMock = new Mock<IResourceManagementClient>();
            authorizationManagementClientMock = new Mock<IAuthorizationManagementClient>();
            deploymentsMock = new Mock<IDeploymentsOperations>();
            resourceGroupMock = new Mock<IResourceGroupsOperations>();
            resourceOperationsMock = new Mock<IResourcesOperations>();
            deploymentOperationsMock = new Mock<IDeploymentOperationsOperations>();
            providersMock = new Mock<IProvidersOperations>();
            providersMock.Setup(f => f.ListWithHttpMessagesAsync(null, null, null, new CancellationToken()))
                .Returns(Task.Factory.StartNew(() =>
                new AzureOperationResponse<IPage<Provider>>()
                {
                    Body = new Page<Provider>()
                }));
            progressLoggerMock = new Mock<Action<string>>();
            errorLoggerMock = new Mock<Action<string>>();
            resourceManagementClientMock.Setup(f => f.Deployments).Returns(deploymentsMock.Object);
            resourceManagementClientMock.Setup(f => f.ResourceGroups).Returns(resourceGroupMock.Object);
            resourceManagementClientMock.Setup(f => f.Resources).Returns(resourceOperationsMock.Object);
            resourceManagementClientMock.Setup(f => f.DeploymentOperations).Returns(deploymentOperationsMock.Object);
            resourceManagementClientMock.Setup(f => f.Providers).Returns(providersMock.Object);
            resourceManagementClientMock.Setup(f => f.ApiVersion).Returns("11-01-2015");
            resourcesClient = new ResourceManagerSdkClient(
                resourceManagementClientMock.Object)
            {
                VerboseLogger = progressLoggerMock.Object,
                ErrorLogger = errorLoggerMock.Object,
            };

            resourceIdentity = new ResourceIdentifier
            {
                ParentResource = "sites/siteA",
                ResourceName = "myResource",
                ResourceGroupName = "Microsoft.Web", // ResourceProviderNamespace
                ResourceType = "sites"
            };
            properties = new Dictionary<string, object>
                {
                    {"name", "site1"},
                    {"siteMode", "Standard"},
                    {"computeMode", "Dedicated"},
                    {"misc", new Dictionary<string, object>
                        {
                            {"key1", "value1"},
                            {"key2", "value2"}
                        }}
                };
            serializedProperties = JsonConvert.SerializeObject(properties, new JsonSerializerSettings
            {
                TypeNameAssemblyFormat = FormatterAssemblyStyle.Simple,
                TypeNameHandling = TypeNameHandling.None
            });
            templateFile = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Resources\sampleTemplateFile.json");
        }

        public ResourceClientTests()
        {
            SetupClass();
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void NewResourceGroupChecksForPermissionForExistingResource()
        {
            RejectActionCounter = 0;
            PSCreateResourceGroupParameters parameters = new PSCreateResourceGroupParameters() { ResourceGroupName = resourceGroupName, ConfirmAction = RejectAction };
            resourceGroupMock.Setup(f => f.CheckExistenceWithHttpMessagesAsync(parameters.ResourceGroupName, null, new CancellationToken()))
                .Returns(Task.Factory.StartNew(() =>
                    new AzureOperationResponse<bool?>()
                    {
                        Body = (bool?)true
                    }));

            resourceGroupMock.Setup(f => f.GetWithHttpMessagesAsync(
                parameters.ResourceGroupName,
                null,
                new CancellationToken()))
                    .Returns(Task.Factory.StartNew(() => new AzureOperationResponse<ResourceGroup>()
                    {
                        Body = new ResourceGroup() { Name = parameters.ResourceGroupName, Location = parameters.Location }
                    }));

            resourceOperationsMock.Setup(f => f.ListWithHttpMessagesAsync(null, null, It.IsAny<CancellationToken>()))
                .Returns(() => Task.Factory.StartNew(() =>
                {
                    var resources = new List<GenericResource>()
                        {
                            CreateGenericResource(location: "West US", id: null, name: "foo", type: null),
                            CreateGenericResource(location: "West US", id: null, name: "bar", type: null)
                        };
                    var result = new Page<GenericResource>();
                    result.SetItemValue(resources);

                    return new AzureOperationResponse<IPage<GenericResource>>() { Body = result };
                }));

            resourcesClient.CreatePSResourceGroup(parameters);
            Assert.Equal(1, RejectActionCounter);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void NewResourceGroupWithoutDeploymentSucceeds()
        {
            PSCreateResourceGroupParameters parameters = new PSCreateResourceGroupParameters()
            {
                ResourceGroupName = resourceGroupName,
                Location = resourceGroupLocation,
                ConfirmAction = ConfirmAction
            };
            resourceGroupMock.Setup(f => f.CheckExistenceWithHttpMessagesAsync(parameters.ResourceGroupName, null, new CancellationToken()))
                .Returns(Task.Factory.StartNew(() => CreateAzureOperationResponse((bool?)false)));

            resourceGroupMock.Setup(f => f.CreateOrUpdateWithHttpMessagesAsync(
                parameters.ResourceGroupName,
                It.IsAny<ResourceGroup>(),
                null,
                new CancellationToken()))
                    .Returns(Task.Factory.StartNew(() => CreateAzureOperationResponse(new ResourceGroup() { Name = parameters.ResourceGroupName, Location = parameters.Location })));
            SetupListForResourceGroupAsync(parameters.ResourceGroupName, new List<GenericResource>());

            PSResourceGroup result = resourcesClient.CreatePSResourceGroup(parameters);

            Assert.Equal(parameters.ResourceGroupName, result.ResourceGroupName);
            Assert.Equal(parameters.Location, result.Location);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestTemplateShowsErrorMessage()
        {
            Uri templateUri = new Uri("http://templateuri.microsoft.com");
            Deployment deploymentFromValidate = new Deployment();
            PSValidateResourceGroupDeploymentParameters parameters = new PSValidateResourceGroupDeploymentParameters()
            {
                ResourceGroupName = resourceGroupName,
                TemplateFile = templateFile,
            };
            resourceGroupMock.Setup(f => f.CheckExistenceWithHttpMessagesAsync(parameters.ResourceGroupName, null, new CancellationToken()))
                .Returns(Task.Factory.StartNew(() => CreateAzureOperationResponse((bool?)true)));

            deploymentsMock.Setup(f => f.ValidateWithHttpMessagesAsync(resourceGroupName, It.IsAny<string>(), It.IsAny<Deployment>(), null, new CancellationToken()))
                .Returns(Task.Factory.StartNew(() =>
                {
                    var result = CreateAzureOperationResponse(new DeploymentValidateResult
                    {
                        Error = new ResourceManagementErrorWithDetails()
                        {
                            Code = "404",
                            Message = "Awesome error message",
                            Details = new List<ResourceManagementErrorWithDetails>(new[] { new ResourceManagementErrorWithDetails
                            {
                                Code = "SubError",
                                Message = "Sub error message"
                            }})
                        }
                    });
                    result.Response = new System.Net.Http.HttpResponseMessage();
                    result.Response.StatusCode = HttpStatusCode.NotFound;

                    return result;
                }))
                .Callback((string rg, string dn, Deployment d, Dictionary<string, List<string>> customHeaders, CancellationToken c) => { deploymentFromValidate = d; });

            IEnumerable<PSResourceManagerError> error = resourcesClient.ValidatePSResourceGroupDeployment(parameters, DeploymentMode.Incremental);
            Assert.Equal(1, error.Count());
            Assert.Equal(1, error.ElementAtOrDefault(0).Details.Count);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestTemplateShowsSuccessMessage()
        {
            Uri templateUri = new Uri("http://templateuri.microsoft.com");
            Deployment deploymentFromValidate = new Deployment();
            PSValidateResourceGroupDeploymentParameters parameters = new PSValidateResourceGroupDeploymentParameters()
            {
                ResourceGroupName = resourceGroupName,
                TemplateFile = templateFile,
            };
            resourceGroupMock.Setup(f => f.CheckExistenceWithHttpMessagesAsync(parameters.ResourceGroupName, null, new CancellationToken()))
                .Returns(Task.Factory.StartNew(() => CreateAzureOperationResponse((bool?)true)));

            deploymentsMock.Setup(f => f.ValidateWithHttpMessagesAsync(resourceGroupName, It.IsAny<string>(), It.IsAny<Deployment>(), null, new CancellationToken()))
                .Returns(Task.Factory.StartNew(() =>
                {
                    var result = CreateAzureOperationResponse(new DeploymentValidateResult
                    {
                        Error = null
                    });

                    result.Response = new System.Net.Http.HttpResponseMessage();
                    result.Response.StatusCode = HttpStatusCode.OK;

                    return result;
                }))
                .Callback((string rg, string dn, Deployment d, Dictionary<string, List<string>> customHeaders, CancellationToken c) => { deploymentFromValidate = d; });

            IEnumerable<PSResourceManagerError> error = resourcesClient.ValidatePSResourceGroupDeployment(parameters, DeploymentMode.Incremental);
            Assert.Equal(0, error.Count());
            progressLoggerMock.Verify(f => f("Template is valid."), Times.Once());
        }

        [Fact]
        public void NewResourceGroupUsesDeploymentNameForDeploymentName()
        {
            // fix test flakiness
            TestExecutionHelpers.RetryAction(
                () =>
                {
                    SetupClass();
                    string deploymentName = "abc123";
                    Deployment deploymentFromGet = new Deployment();
                    Deployment deploymentFromValidate = new Deployment();
                    PSCreateResourceGroupParameters parameters = new PSCreateResourceGroupParameters()
                    {
                        ResourceGroupName = resourceGroupName,
                        Location = resourceGroupLocation,
                        DeploymentName = deploymentName,
                        ConfirmAction = ConfirmAction,
                        TemplateFile = "http://path/file.html"
                    };


                    deploymentsMock.Setup(f => f.ValidateWithHttpMessagesAsync(
                        It.IsAny<string>(),
                        It.IsAny<string>(),
                        It.IsAny<Deployment>(),
                        null,
                        new CancellationToken()))
                        .Returns(Task.Factory.StartNew(() =>
                            new AzureOperationResponse<DeploymentValidateResult>()
                            {
                                Body = new DeploymentValidateResult
                                {
                                }
                            }))
                        .Callback(
                            (string rg, string dn, Deployment d, Dictionary<string, List<string>> customHeaders,
                                CancellationToken c) =>
                            {
                                deploymentFromValidate = d;
                            });

                    deploymentsMock.Setup(f => f.BeginCreateOrUpdateWithHttpMessagesAsync(
                        It.IsAny<string>(),
                        It.IsAny<string>(),
                        It.IsAny<Deployment>(),
                        null,
                        new CancellationToken()))
                        .Returns(Task.Factory.StartNew(() => new AzureOperationResponse<DeploymentExtended>()
                        {
                            Body = new DeploymentExtended
                            {
                                Id = requestId
                            }
                        }))
                        .Callback(
                            (string name, string dName, Deployment bDeploy,
                                Dictionary<string, List<string>> customHeaders, CancellationToken token) =>
                            {
                                deploymentFromGet = bDeploy;
                                deploymentName = dName;
                            });

                    deploymentsMock.Setup(f => f.CheckExistenceWithHttpMessagesAsync(
                        It.IsAny<string>(),
                        It.IsAny<string>(),
                        null,
                        new CancellationToken()))
                        .Returns(Task.Factory.StartNew(() => new AzureOperationResponse<bool?>()
                        {
                            Body = true
                        }));

                    SetupListForResourceGroupAsync(parameters.ResourceGroupName, new List<GenericResource>
                    {
                        CreateGenericResource(null, null, "website")
                    });

                    var operationId = Guid.NewGuid().ToString();
                    var operationQueue = new Queue<DeploymentOperation>();
                    operationQueue.Enqueue(
                        new DeploymentOperation()
                        {
                            OperationId = operationId,
                            Properties = new DeploymentOperationProperties()
                            {
                                ProvisioningState = "Accepted",
                                TargetResource = new TargetResource()
                                {
                                    ResourceType = "Microsoft.Website",
                                    ResourceName = resourceName
                                }
                            }
                        }
                        );
                    operationQueue.Enqueue(
                        new DeploymentOperation()
                        {
                            OperationId = operationId,
                            Properties = new DeploymentOperationProperties()
                            {
                                ProvisioningState = "Running",
                                TargetResource = new TargetResource()
                                {
                                    ResourceType = "Microsoft.Website",
                                    ResourceName = resourceName
                                }
                            }
                        }
                        );
                    operationQueue.Enqueue(
                        new DeploymentOperation()
                        {
                            OperationId = operationId,
                            Properties = new DeploymentOperationProperties()
                            {
                                ProvisioningState = "Succeeded",
                                TargetResource = new TargetResource()
                                {
                                    ResourceType = "Microsoft.Website",
                                    ResourceName = resourceName
                                }
                            }
                        }
                        );
                    deploymentOperationsMock.SetupSequence(
                        f =>
                            f.ListWithHttpMessagesAsync(It.IsAny<string>(), It.IsAny<string>(), null, null,
                                new CancellationToken()))
                        .Returns(Task.Factory.StartNew(() =>
                            new AzureOperationResponse<IPage<DeploymentOperation>>()
                            {
                                Body = GetPagableType(
                                    new List<DeploymentOperation>()
                                    {
                                        operationQueue.Dequeue()
                                    })
                            }))
                        .Returns(Task.Factory.StartNew(() => new AzureOperationResponse<IPage<DeploymentOperation>>()
                        {
                            Body = GetPagableType(
                                new List<DeploymentOperation>()
                                {
                                    operationQueue.Dequeue()
                                })
                        }))
                        .Returns(Task.Factory.StartNew(() => new AzureOperationResponse<IPage<DeploymentOperation>>()
                        {
                            Body = GetPagableType(
                                new List<DeploymentOperation>()
                                {
                                    operationQueue.Dequeue()
                                })
                        }));

                    var deploymentQueue = new Queue<DeploymentExtended>();
                    deploymentQueue.Enqueue(new DeploymentExtended()
                    {
                        Name = deploymentName,
                        Properties = new DeploymentPropertiesExtended()
                        {
                            Mode = DeploymentMode.Incremental,
                            CorrelationId = "123",
                            ProvisioningState = "Accepted"
                        }
                    });
                    deploymentQueue.Enqueue(new DeploymentExtended
                    {
                        Name = deploymentName,
                        Properties = new DeploymentPropertiesExtended()
                        {
                            Mode = DeploymentMode.Incremental,
                            CorrelationId = "123",
                            ProvisioningState = "Running"
                        }
                    });
                    deploymentQueue.Enqueue(new DeploymentExtended
                    {
                        Name = deploymentName,
                        Properties = new DeploymentPropertiesExtended()
                        {
                            Mode = DeploymentMode.Incremental,
                            CorrelationId = "123",
                            ProvisioningState = "Succeeded"
                        }
                    });
                    deploymentsMock.SetupSequence(
                        f =>
                            f.GetWithHttpMessagesAsync(It.IsAny<string>(), It.IsAny<string>(), null,
                                new CancellationToken()))
                        .Returns(
                            Task.Factory.StartNew(
                                () =>
                                    new AzureOperationResponse<DeploymentExtended>() { Body = deploymentQueue.Dequeue() }))
                        .Returns(
                            Task.Factory.StartNew(
                                () =>
                                    new AzureOperationResponse<DeploymentExtended>() { Body = deploymentQueue.Dequeue() }))
                        .Returns(
                            Task.Factory.StartNew(
                                () =>
                                    new AzureOperationResponse<DeploymentExtended>() { Body = deploymentQueue.Dequeue() }));

                    Microsoft.Azure.Commands.ResourceManager.Cmdlets.SdkModels.PSResourceGroupDeployment result =
                        resourcesClient.ExecuteDeployment(parameters);
                    Assert.Equal(deploymentName, deploymentName);
                    Assert.Equal("Succeeded", result.ProvisioningState);
                    progressLoggerMock.Verify(
                        f =>
                            f(string.Format("Resource {0} '{1}' provisioning status is {2}", "Microsoft.Website",
                                resourceName, "Accepted".ToLower())),
                        Times.Once());
                    progressLoggerMock.Verify(
                        f =>
                            f(string.Format("Resource {0} '{1}' provisioning status is {2}", "Microsoft.Website",
                                resourceName, "Running".ToLower())),
                        Times.Once());
                    progressLoggerMock.Verify(
                        f =>
                            f(string.Format("Resource {0} '{1}' provisioning status is {2}", "Microsoft.Website",
                                resourceName, "Succeeded".ToLower())),
                        Times.Once());
                });
        }

        [Fact]
        public void NewResourceGroupDeploymentWithDelay()
        {
            string deploymentName = "abc123";
            ConcurrentBag<string> deploymentNames = new ConcurrentBag<string>();

            PSCreateResourceGroupParameters parameters = new PSCreateResourceGroupParameters()
            {
                ResourceGroupName = resourceGroupName,
                Location = resourceGroupLocation,
                DeploymentName = deploymentName,
                ConfirmAction = ConfirmAction,
                TemplateFile = "http://path/file.html"
            };

            deploymentsMock.Setup(f => f.ValidateWithHttpMessagesAsync(
                parameters.ResourceGroupName,
                parameters.DeploymentName,
                It.IsAny<Deployment>(),
                null,
                new CancellationToken()))
                .Returns(Task.Factory.StartNew(() =>
                    new AzureOperationResponse<DeploymentValidateResult>()
                    {
                        Body = new DeploymentValidateResult
                        {
                        }
                    }));

            deploymentsMock.Setup(f => f.GetWithHttpMessagesAsync(
                parameters.ResourceGroupName,
                parameters.DeploymentName,
                null,
                new CancellationToken()))
                .Returns<string, string, Dictionary<string, List<string>>, CancellationToken>(
                    async (getResourceGroupName, getDeploymentName, customHeaders, cancellationToken) =>
                    {
                        await Task.Delay(100, cancellationToken);

                        if (deploymentNames.Contains(getDeploymentName))
                        {
                            return new AzureOperationResponse<DeploymentExtended>()
                            {
                                Body = new DeploymentExtended()
                                {
                                    Name = getDeploymentName,
                                    Id = requestId,
                                    Properties = new DeploymentPropertiesExtended()
                                    {
                                        Mode = DeploymentMode.Incremental,
                                        CorrelationId = "123",
                                        ProvisioningState = "Succeeded"
                                    },
                                }
                            };
                        }

                        throw new CloudException(String.Format("Deployment '{0}' could not be found.", getDeploymentName));
                    });

            deploymentsMock.Setup(f => f.BeginCreateOrUpdateWithHttpMessagesAsync(
                parameters.ResourceGroupName,
                parameters.DeploymentName,
                It.IsAny<Deployment>(),
                null,
                new CancellationToken()))
                .Returns<string, string, Deployment, Dictionary<string, List<string>>, CancellationToken>(
                    async (craeteResourceGroupName, createDeploymentName, createDeployment, customHeaders, cancellationToken) =>
                    {
                        await Task.Delay(500, cancellationToken);

                        deploymentNames.Add(createDeploymentName);

                        return new AzureOperationResponse<DeploymentExtended>()
                        {
                            Body = new DeploymentExtended
                            {
                                Id = requestId
                            }
                        };
                    });

            deploymentsMock.Setup(f => f.CreateOrUpdateWithHttpMessagesAsync(
                parameters.ResourceGroupName,
                parameters.DeploymentName,
                It.IsAny<Deployment>(),
                null,
                new CancellationToken()))
                .Returns<string, string, Deployment, Dictionary<string, List<string>>, CancellationToken>(
                    async (craeteResourceGroupName, createDeploymentName, createDeployment, customHeaders, cancellationToken) =>
                    {
                        await Task.Delay(10000, cancellationToken);

                        deploymentNames.Add(createDeploymentName);

                        return new AzureOperationResponse<DeploymentExtended>()
                        {
                            Body = new DeploymentExtended
                            {
                                Id = requestId
                            }
                        };
                    });

            deploymentsMock.Setup(f => f.CheckExistenceWithHttpMessagesAsync(
                parameters.ResourceGroupName,
                parameters.DeploymentName,
                null,
                new CancellationToken()))
                .Returns(Task.Factory.StartNew(() => new AzureOperationResponse<bool?>()
                {
                    Body = true
                }));

            SetupListForResourceGroupAsync(parameters.ResourceGroupName, new List<GenericResource>
            {
                CreateGenericResource(null, null, "website")
            });

            var operationId = Guid.NewGuid().ToString();
            var operationQueue = new Queue<DeploymentOperation>();
            operationQueue.Enqueue(
                new DeploymentOperation()
                {
                    OperationId = operationId,
                    Properties = new DeploymentOperationProperties()
                    {
                        ProvisioningState = "Succeeded",
                        TargetResource = new TargetResource()
                        {
                            ResourceType = "Microsoft.Website",
                            ResourceName = resourceName
                        }
                    }
                }
            );
            deploymentOperationsMock.Setup(f => f.ListWithHttpMessagesAsync(
                parameters.ResourceGroupName,
                parameters.DeploymentName,
                null,
                null,
                new CancellationToken()))
                .Returns<string, string, int?, Dictionary<string, List<string>>, CancellationToken>(
                    async (getResourceGroupName, getDeploymentName, top, customHeaders, cancellationToken) =>
                    {
                        await Task.Delay(100, cancellationToken);

                        if (deploymentNames.Contains(getDeploymentName))
                        {
                            return new AzureOperationResponse<IPage<DeploymentOperation>>()
                            {
                                Body = GetPagableType(
                                    new List<DeploymentOperation>()
                                    {
                                        operationQueue.Dequeue()
                                    })
                            };
                        }

                        throw new CloudException(String.Format("Deployment '{0}' could not be found.", getDeploymentName));
                    });

            Microsoft.Azure.Commands.ResourceManager.Cmdlets.SdkModels.PSResourceGroupDeployment result = resourcesClient.ExecuteDeployment(parameters);
            Assert.Equal(deploymentName, result.DeploymentName);
            Assert.Equal("Succeeded", result.ProvisioningState);
            progressLoggerMock.Verify(
                f => f(string.Format("Resource {0} '{1}' provisioning status is {2}", "Microsoft.Website", resourceName, "Succeeded".ToLower())),
                Times.Once());
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void NewResourceGroupWithDeploymentSucceeds()
        {
            Uri templateUri = new Uri("http://templateuri.microsoft.com");
            Deployment deploymentFromGet = new Deployment();
            Deployment deploymentFromValidate = new Deployment();
            PSCreateResourceGroupParameters parameters = new PSCreateResourceGroupParameters()
            {
                ResourceGroupName = resourceGroupName,
                Location = resourceGroupLocation,
                DeploymentName = deploymentName,
                TemplateFile = templateFile,
                ConfirmAction = ConfirmAction
            };
            resourceGroupMock.Setup(f => f.CheckExistenceWithHttpMessagesAsync(parameters.ResourceGroupName, null, new CancellationToken()))
                .Returns(Task.Factory.StartNew(() => new AzureOperationResponse<bool?>() { Body = (bool?)false }));

            resourceGroupMock.Setup(f => f.CreateOrUpdateWithHttpMessagesAsync(
                parameters.ResourceGroupName,
                It.IsAny<ResourceGroup>(),
                null,
                new CancellationToken()))
                    .Returns(Task.Factory.StartNew(() =>
                    new AzureOperationResponse<ResourceGroup>()
                    {
                        Body = new ResourceGroup() { Name = parameters.ResourceGroupName, Location = parameters.Location }
                    }));

            resourceGroupMock.Setup(f => f.GetWithHttpMessagesAsync(resourceGroupName, null, new CancellationToken()))
                .Returns(Task.Factory.StartNew(() =>
                new AzureOperationResponse<ResourceGroup>()
                {
                    Body = new ResourceGroup() { Location = resourceGroupLocation }
                }));

            deploymentsMock.Setup(f => f.BeginCreateOrUpdateWithHttpMessagesAsync(resourceGroupName, deploymentName, It.IsAny<Deployment>(), null, new CancellationToken()))
                .Returns(Task.Factory.StartNew(() => new AzureOperationResponse<DeploymentExtended>()
                {
                    Body = new DeploymentExtended
                    {
                        Id = requestId
                    }
                }))
                .Callback((string name, string dName, Deployment bDeploy, Dictionary<string, List<string>> customHeaders, CancellationToken token) =>
                { deploymentFromGet = bDeploy; });
            deploymentsMock.Setup(f => f.GetWithHttpMessagesAsync(resourceGroupName, deploymentName, null, new CancellationToken()))
                .Returns(Task.Factory.StartNew(() => new AzureOperationResponse<DeploymentExtended>()
                {
                    Body = new DeploymentExtended()
                    {
                        Name = deploymentName,
                        Properties = new DeploymentPropertiesExtended()
                        {
                            Mode = DeploymentMode.Incremental,
                            CorrelationId = "123",
                            ProvisioningState = "Succeeded"
                        },
                    }
                }
                ));

            deploymentsMock.Setup(f => f.ValidateWithHttpMessagesAsync(resourceGroupName, It.IsAny<string>(), It.IsAny<Deployment>(), null, new CancellationToken()))
                .Returns(Task.Factory.StartNew(() => CreateAzureOperationResponse(new DeploymentValidateResult
                {
                })))
                .Callback((string rg, string dn, Deployment d, Dictionary<string, List<string>> customHeaders, CancellationToken c) => { deploymentFromValidate = d; });
            deploymentsMock.Setup(f => f.CheckExistenceWithHttpMessagesAsync(
                It.IsAny<string>(),
                It.IsAny<string>(),
                null,
                new CancellationToken()))
                .Returns(Task.Factory.StartNew(() => new AzureOperationResponse<bool?>()
                {
                    Body = true
                }));

            SetupListForResourceGroupAsync(parameters.ResourceGroupName, new List<GenericResource>() { CreateGenericResource(null, null, "website") });
            deploymentOperationsMock.Setup(f => f.ListWithHttpMessagesAsync(resourceGroupName, deploymentName, null, null, new CancellationToken()))
                .Returns(Task.Factory.StartNew(() => CreateAzureOperationResponse(GetPagableType(new List<DeploymentOperation>()
                    {
                        new DeploymentOperation()
                        {
                            OperationId = Guid.NewGuid().ToString(),
                            Properties = new DeploymentOperationProperties()
                            {
                                ProvisioningState = "Succeeded",
                                TargetResource = new TargetResource()
                                {
                                    ResourceType = "Microsoft.Website",
                                    ResourceName = resourceName
                                }
                            }
                        }
                    }))));

            PSResourceGroup result = resourcesClient.CreatePSResourceGroup(parameters);
            Microsoft.Azure.Commands.ResourceManager.Cmdlets.SdkModels.PSResourceGroupDeployment deploymentResult = resourcesClient.ExecuteDeployment(parameters);
            deploymentsMock.Verify((f => f.BeginCreateOrUpdateWithHttpMessagesAsync(resourceGroupName, deploymentName, deploymentFromGet, null, new CancellationToken())), Times.Once());
            Assert.Equal(parameters.ResourceGroupName, deploymentResult.ResourceGroupName);

            Assert.Equal(DeploymentMode.Incremental, deploymentFromGet.Properties.Mode);
            Assert.NotNull(deploymentFromGet.Properties.Template);

            progressLoggerMock.Verify(
                f => f(string.Format("Resource {0} '{1}' provisioning status is {2}",
                        "Microsoft.Website",
                        resourceName,
                        "Succeeded".ToLower())),
                Times.Once());
        }


        [Fact(Skip = "TODO: Fix the test to fit the new client post migration")]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void ShowsFailureErrorWhenResourceGroupWithDeploymentFails()
        {
            Uri templateUri = new Uri("http://templateuri.microsoft.com");
            Deployment deploymentFromGet = new Deployment();
            Deployment deploymentFromValidate = new Deployment();
            PSCreateResourceGroupParameters parameters = new PSCreateResourceGroupParameters()
            {
                ResourceGroupName = resourceGroupName,
                Location = resourceGroupLocation,
                DeploymentName = deploymentName,
                TemplateFile = templateFile,
                ConfirmAction = ConfirmAction
            };
            resourceGroupMock.Setup(f => f.CheckExistenceWithHttpMessagesAsync(parameters.ResourceGroupName, null, new CancellationToken()))
                .Returns(Task.Factory.StartNew(() => CreateAzureOperationResponse((bool?)false)));

            resourceGroupMock.Setup(f => f.CreateOrUpdateWithHttpMessagesAsync(
                parameters.ResourceGroupName,
                It.IsAny<ResourceGroup>(),
                null,
                new CancellationToken()))
                    .Returns(Task.Factory.StartNew(() =>
                        CreateAzureOperationResponse(new ResourceGroup() { Name = parameters.ResourceGroupName, Location = parameters.Location })
                    ));
            resourceGroupMock.Setup(f => f.GetWithHttpMessagesAsync(resourceGroupName, null, new CancellationToken()))
                .Returns(Task.Factory.StartNew(() => CreateAzureOperationResponse(new ResourceGroup() { Location = resourceGroupLocation })
                ));
            deploymentsMock.Setup(f => f.CreateOrUpdateWithHttpMessagesAsync(resourceGroupName, deploymentName, It.IsAny<Deployment>(), null, new CancellationToken()))
                .Returns(Task.Factory.StartNew(() => CreateAzureOperationResponse(new DeploymentExtended
                {
                    Id = requestId
                })))
                .Callback((string name, string dName, Deployment bDeploy, Dictionary<string, List<string>> customHeaders, CancellationToken token) => { deploymentFromGet = bDeploy; });
            deploymentsMock.Setup(f => f.GetWithHttpMessagesAsync(resourceGroupName, deploymentName, null, new CancellationToken()))
                .Returns(Task.Factory.StartNew(() => CreateAzureOperationResponse(new DeploymentExtended()
                {
                    Name = deploymentName,
                    Properties = new DeploymentPropertiesExtended()
                    {
                        Mode = DeploymentMode.Incremental,
                        ProvisioningState = "Succeeded"
                    },
                })
                ));
            deploymentsMock.Setup(f => f.ValidateWithHttpMessagesAsync(resourceGroupName, It.IsAny<string>(), It.IsAny<Deployment>(), null, new CancellationToken()))
                .Returns(Task.Factory.StartNew(() => CreateAzureOperationResponse(new DeploymentValidateResult
                {
                    Error = new ResourceManagementErrorWithDetails()
                })))
                .Callback((string resourceGroup, string deployment, Deployment d, Dictionary<string, List<string>> customHeaders, CancellationToken c) => { deploymentFromValidate = d; });
            SetupListForResourceGroupAsync(parameters.ResourceGroupName, new List<GenericResource>() {
                CreateGenericResource(null, null, "website") });
            var listOperations = new List<DeploymentOperation>() {
                new DeploymentOperation()
                {
                    OperationId = Guid.NewGuid().ToString(),
                    Properties = new DeploymentOperationProperties()
                    {
                        ProvisioningState = "Failed",
                        StatusMessage = "{\"Code\":\"Conflict\"}",
                        TargetResource = new TargetResource()
                        {
                            ResourceType = "Microsoft.Website",
                            ResourceName = resourceName
                        }
                    }
                }
            };
            var pageableOperations = new Page<DeploymentOperation>();
            pageableOperations.SetItemValue(listOperations);

            deploymentOperationsMock.Setup(f => f.ListWithHttpMessagesAsync(resourceGroupName, deploymentName, null, null, new CancellationToken()))
                .Returns(Task.Factory.StartNew(() => CreateAzureOperationResponse((IPage<DeploymentOperation>)pageableOperations)));

            PSResourceGroup result = resourcesClient.CreatePSResourceGroup(parameters);

            deploymentsMock.Verify((f => f.CreateOrUpdateWithHttpMessagesAsync(resourceGroupName, deploymentName, deploymentFromGet, null, new CancellationToken())), Times.Once());
            Assert.Equal(parameters.ResourceGroupName, result.ResourceGroupName);
            Assert.Equal(parameters.Location, result.Location);

            Assert.Equal(DeploymentMode.Incremental, deploymentFromGet.Properties.Mode);
            Assert.NotNull(deploymentFromGet.Properties.Template);

            errorLoggerMock.Verify(
                f => f(string.Format("Resource {0} '{1}' failed with message '{2}'",
                        "Microsoft.Website",
                        resourceName,
                        "{\"Code\":\"Conflict\"}")),
                Times.Once());
        }

        [Fact(Skip = "TODO: Fix the test to fit the new client post migration")]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void ExtractsErrorMessageFromFailedDeploymentOperation()
        {
            Uri templateUri = new Uri("http://templateuri.microsoft.com");
            Deployment deploymentFromGet = new Deployment();
            Deployment deploymentFromValidate = new Deployment();
            PSCreateResourceGroupParameters parameters = new PSCreateResourceGroupParameters()
            {
                ResourceGroupName = resourceGroupName,
                Location = resourceGroupLocation,
                DeploymentName = deploymentName,
                TemplateFile = templateFile,
                ConfirmAction = ConfirmAction
            };
            resourceGroupMock.Setup(f => f.CheckExistenceWithHttpMessagesAsync(parameters.ResourceGroupName, null, new CancellationToken()))
            .Returns(Task.Factory.StartNew(() => new AzureOperationResponse<bool?>()
            {
                Body = (bool?)false
            }));

            resourceGroupMock.Setup(f => f.CreateOrUpdateWithHttpMessagesAsync(
                parameters.ResourceGroupName,
                It.IsAny<ResourceGroup>(),
                null,
                new CancellationToken()))
            .Returns(Task.Factory.StartNew(() =>
                new AzureOperationResponse<ResourceGroup>()
                {
                    Body = new ResourceGroup() { Name = parameters.ResourceGroupName, Location = parameters.Location }
                }
            ));
            resourceGroupMock.Setup(f => f.GetWithHttpMessagesAsync(resourceGroupName, null, new CancellationToken()))
            .Returns(Task.Factory.StartNew(() =>
                new AzureOperationResponse<ResourceGroup>() { Body = new ResourceGroup() { Location = resourceGroupLocation } }
            ));
            deploymentsMock.Setup(f => f.CreateOrUpdateWithHttpMessagesAsync(
                resourceGroupName,
                deploymentName,
                It.IsAny<Deployment>(),
                null,
                new CancellationToken()))
            .Returns(Task.Factory.StartNew(() => new AzureOperationResponse<DeploymentExtended>()
            {
                Body = new DeploymentExtended
                {
                    Id = requestId
                }
            }))
            .Callback((string name, string dName, Deployment bDeploy, Dictionary<string, List<string>> customHeaders,
                    CancellationToken token) =>
            { deploymentFromGet = bDeploy; });
            deploymentsMock.Setup(f => f.GetWithHttpMessagesAsync(resourceGroupName, deploymentName, null, new CancellationToken()))
            .Returns(Task.Factory.StartNew(() =>
                new AzureOperationResponse<DeploymentExtended>()
                {
                    Body = new DeploymentExtended()
                    {
                        Name = deploymentName,
                        Properties = new DeploymentPropertiesExtended()
                        {
                            Mode = DeploymentMode.Incremental,
                            ProvisioningState = "Succeeded"
                        }
                    }
                }
            ));
            deploymentsMock.Setup(f => f.ValidateWithHttpMessagesAsync(
                resourceGroupName,
                It.IsAny<string>(),
                It.IsAny<Deployment>(),
                null,
                new CancellationToken()))
            .Returns(Task.Factory.StartNew(() =>
                new AzureOperationResponse<DeploymentValidateResult>()
                {
                    Body = new DeploymentValidateResult
                    {
                        Error = new ResourceManagementErrorWithDetails()
                    }
                }
            ))
            .Callback((string rg, string dn, Deployment d, Dictionary<string, List<string>> customHeaders,
                    CancellationToken c) =>
            { deploymentFromValidate = d; });

            SetupListForResourceGroupAsync(parameters.ResourceGroupName, new List<GenericResource>() {
                CreateGenericResource(location: null, id: null, name: "website", type: null)});

            var listOperations = new List<DeploymentOperation>() {
                new DeploymentOperation()
                {
                    OperationId = Guid.NewGuid().ToString(),
                    Properties = new DeploymentOperationProperties()
                    {
                        ProvisioningState = "Failed",
                        StatusMessage = JsonConvert.SerializeObject(new ResourceManagementErrorWithDetails()
                        {
                            Message = "A really bad error occured"
                        }),
                        TargetResource = new TargetResource()
                        {
                            ResourceType = "Microsoft.Website",
                            ResourceName = resourceName
                        }
                    }
                }
            };

            deploymentOperationsMock.Setup(f => f.ListWithHttpMessagesAsync(
                resourceGroupName,
                deploymentName,
                null,
                null,
                new CancellationToken()))
            .Returns(Task.Factory.StartNew(() =>
                new AzureOperationResponse<IPage<DeploymentOperation>>()
                {
                    Body = GetPagableType<DeploymentOperation>(listOperations)
                }
            ));

            PSResourceGroup result = resourcesClient.CreatePSResourceGroup(parameters);
            Microsoft.Azure.Commands.ResourceManager.Cmdlets.SdkModels.PSResourceGroupDeployment deploymentResult = resourcesClient.ExecuteDeployment(parameters);

            deploymentsMock.Verify((f => f.CreateOrUpdateWithHttpMessagesAsync(
                    resourceGroupName,
                    deploymentName,
                    deploymentFromGet,
                    null,
                    new CancellationToken())),
                Times.Never);
            Assert.Equal(parameters.ResourceGroupName, deploymentResult.ResourceGroupName);

            Assert.Equal(DeploymentMode.Incremental, deploymentFromGet.Properties.Mode);
            Assert.NotNull(deploymentFromGet.Properties.Template);

            errorLoggerMock.Verify(
                f => f("A really bad error occured"),
                Times.Once());
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void GetsSpecificResourceGroup()
        {
            string name = resourceGroupName;
            GenericResource resource1 = CreateGenericResource(
                resourceGroupLocation,
                "/subscriptions/abc123/resourceGroups/group1/providers/Microsoft.Test/servers/r12345sql/db/r45678db",
                resourceName);
            GenericResource resource2 = CreateGenericResource(
                resourceGroupLocation,
                "/subscriptions/abc123/resourceGroups/group1/providers/Microsoft.Test/servers/r12345sql/db/r45678db",
                resourceName + "2");
            ResourceGroup resourceGroup = new ResourceGroup()
            {
                Name = name,
                Location = resourceGroupLocation,
                Properties = new ResourceGroupProperties("Succeeded")
            };
            resourceGroupMock.Setup(f => f.GetWithHttpMessagesAsync(name, null, new CancellationToken()))
                             .Returns(Task.Factory.StartNew(() =>
                                new AzureOperationResponse<ResourceGroup>()
                                {
                                    Body = resourceGroup
                                }));
            SetupListForResourceGroupAsync(name, new List<GenericResource>() { resource1, resource2 });

            List<PSResourceGroup> actual = resourcesClient.FilterResourceGroups(name, null, true);

            Assert.Equal(1, actual.Count);
            Assert.Equal(name, actual[0].ResourceGroupName);
            Assert.Equal(resourceGroupLocation, actual[0].Location);
            Assert.Equal("Succeeded", actual[0].ProvisioningState);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void GetsAllResourceGroups()
        {
            ResourceGroup resourceGroup1 = new ResourceGroup() { Name = resourceGroupName + 1, Location = resourceGroupLocation };
            ResourceGroup resourceGroup2 = new ResourceGroup() { Name = resourceGroupName + 2, Location = resourceGroupLocation };
            ResourceGroup resourceGroup3 = new ResourceGroup() { Name = resourceGroupName + 3, Location = resourceGroupLocation };
            ResourceGroup resourceGroup4 = new ResourceGroup() { Name = resourceGroupName + 4, Location = resourceGroupLocation };
            var listResult = new List<ResourceGroup>() { resourceGroup1, resourceGroup2, resourceGroup3, resourceGroup4 };
            var pagableResult = new Page<ResourceGroup>();
            pagableResult.SetItemValue(listResult);
            resourceGroupMock.Setup(f => f.ListWithHttpMessagesAsync(null, null, new CancellationToken()))
            .Returns(Task.Factory.StartNew(() => new AzureOperationResponse<IPage<ResourceGroup>>()
            {
                Body = pagableResult
            }));
            SetupListForResourceGroupAsync(resourceGroup1.Name, new List<GenericResource>() { CreateGenericResource(null, null, "resource") });
            SetupListForResourceGroupAsync(resourceGroup2.Name, new List<GenericResource>() { CreateGenericResource(null, null, "resource") });
            SetupListForResourceGroupAsync(resourceGroup3.Name, new List<GenericResource>() { CreateGenericResource(null, null, "resource") });
            SetupListForResourceGroupAsync(resourceGroup4.Name, new List<GenericResource>() { CreateGenericResource(null, null, "resource") });

            List<PSResourceGroup> actual = resourcesClient.FilterResourceGroups(null, null, false);

            Assert.Equal(4, actual.Count);
            Assert.Equal(resourceGroup1.Name, actual[0].ResourceGroupName);
            Assert.Equal(resourceGroup2.Name, actual[1].ResourceGroupName);
            Assert.Equal(resourceGroup3.Name, actual[2].ResourceGroupName);
            Assert.Equal(resourceGroup4.Name, actual[3].ResourceGroupName);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void GetsAllResourceGroupsWithDetails()
        {
            ResourceGroup resourceGroup1 = new ResourceGroup() { Name = resourceGroupName + 1, Location = resourceGroupLocation };
            ResourceGroup resourceGroup2 = new ResourceGroup() { Name = resourceGroupName + 2, Location = resourceGroupLocation };
            ResourceGroup resourceGroup3 = new ResourceGroup() { Name = resourceGroupName + 3, Location = resourceGroupLocation };
            ResourceGroup resourceGroup4 = new ResourceGroup() { Name = resourceGroupName + 4, Location = resourceGroupLocation };
            var listResult = new List<ResourceGroup>() { resourceGroup1, resourceGroup2, resourceGroup3, resourceGroup4 };
            var pagableResult = new Page<ResourceGroup>();
            pagableResult.SetItemValue(listResult);
            resourceGroupMock.Setup(f => f.ListWithHttpMessagesAsync(null, null, new CancellationToken()))
            .Returns(Task.Factory.StartNew(() => new AzureOperationResponse<IPage<ResourceGroup>>()
            {
                Body = pagableResult
            }));
            SetupListForResourceGroupAsync(resourceGroup1.Name, new List<GenericResource>() { CreateGenericResource(null, null, "resource") });
            SetupListForResourceGroupAsync(resourceGroup2.Name, new List<GenericResource>() { CreateGenericResource(null, null, "resource") });
            SetupListForResourceGroupAsync(resourceGroup3.Name, new List<GenericResource>() { CreateGenericResource(null, null, "resource") });
            SetupListForResourceGroupAsync(resourceGroup4.Name, new List<GenericResource>() { CreateGenericResource(null, null, "resource") });

            List<PSResourceGroup> actual = resourcesClient.FilterResourceGroups(null, null, true);

            Assert.Equal(4, actual.Count);
            Assert.Equal(resourceGroup1.Name, actual[0].ResourceGroupName);
            Assert.Equal(resourceGroup2.Name, actual[1].ResourceGroupName);
            Assert.Equal(resourceGroup3.Name, actual[2].ResourceGroupName);
            Assert.Equal(resourceGroup4.Name, actual[3].ResourceGroupName);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void GetsResourceGroupsFilteredByTags()
        {
            Dictionary<string, string> tag1 = new Dictionary<string, string> { { "tag1", "val1" }, { "tag2", "val2" } };
            Dictionary<string, string> tag2 = new Dictionary<string, string> { { "tag1", "valx" } };
            Dictionary<string, string> tag3 = new Dictionary<string, string> { { "tag2", "" } };

            ResourceGroup resourceGroup1 = new ResourceGroup() { Name = resourceGroupName + 1, Location = resourceGroupLocation, Tags = tag1 };
            ResourceGroup resourceGroup2 = new ResourceGroup() { Name = resourceGroupName + 2, Location = resourceGroupLocation, Tags = tag2 };
            ResourceGroup resourceGroup3 = new ResourceGroup() { Name = resourceGroupName + 3, Location = resourceGroupLocation, Tags = tag3 };
            ResourceGroup resourceGroup4 = new ResourceGroup() { Name = resourceGroupName + 4, Location = resourceGroupLocation };
            var listResult = new List<ResourceGroup>() { resourceGroup1, resourceGroup2, resourceGroup3, resourceGroup4 };
            var pagableResult = new Page<ResourceGroup>();
            pagableResult.SetItemValue(listResult);
            resourceGroupMock.Setup(f => f.ListWithHttpMessagesAsync(null, null, new CancellationToken()))
                             .Returns(Task.Factory.StartNew(() =>
                                new AzureOperationResponse<IPage<ResourceGroup>>()
                                {
                                    Body = pagableResult
                                }));
            SetupListForResourceGroupAsync(resourceGroup1.Name, new List<GenericResource>() { CreateGenericResource(null, null, "resource") });
            SetupListForResourceGroupAsync(resourceGroup2.Name, new List<GenericResource>() { CreateGenericResource(null, null, "resource") });
            SetupListForResourceGroupAsync(resourceGroup3.Name, new List<GenericResource>() { CreateGenericResource(null, null, "resource") });
            SetupListForResourceGroupAsync(resourceGroup4.Name, new List<GenericResource>() { CreateGenericResource(null, null, "resource") });

            List<PSResourceGroup> groups1 = resourcesClient.FilterResourceGroups(null, 
                new Hashtable(new Dictionary<string, string> { { "tag1", "val1" } }), false);

            Assert.Equal(1, groups1.Count);
            Assert.Equal(resourceGroup1.Name, groups1[0].ResourceGroupName);

            List<PSResourceGroup> groups2 = resourcesClient.FilterResourceGroups(null,
                new Hashtable(new Dictionary<string, string> { { "tag2", "" } }), false);

            Assert.Equal(2, groups2.Count);
            Assert.Equal(resourceGroup1.Name, groups2[0].ResourceGroupName);
            Assert.Equal(resourceGroup3.Name, groups2[1].ResourceGroupName);

            List<PSResourceGroup> groups3 = resourcesClient.FilterResourceGroups(null,
                new Hashtable(new Dictionary<string, string> { { "Name", "tag3" } }), false);

            Assert.Equal(0, groups3.Count);

            List<PSResourceGroup> groups4 = resourcesClient.FilterResourceGroups(null,
                new Hashtable(new Dictionary<string, string> { { "TAG1", "val1" } }), false);

            Assert.Equal(1, groups4.Count);
            Assert.Equal(resourceGroup1.Name, groups4[0].ResourceGroupName);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void GetsResourceGroupsFilteredByTagsWithDetails()
        {
            Dictionary<string, string> tag1 = new Dictionary<string, string> { { "tag1", "val1" }, { "tag2", "val2" } };
            Dictionary<string, string> tag2 = new Dictionary<string, string> { { "tag1", "valx" } };
            Dictionary<string, string> tag3 = new Dictionary<string, string> { { "tag2", "" } };

            ResourceGroup resourceGroup1 = new ResourceGroup() { Name = resourceGroupName + 1, Location = resourceGroupLocation, Tags = tag1 };
            ResourceGroup resourceGroup2 = new ResourceGroup() { Name = resourceGroupName + 2, Location = resourceGroupLocation, Tags = tag2 };
            ResourceGroup resourceGroup3 = new ResourceGroup() { Name = resourceGroupName + 3, Location = resourceGroupLocation, Tags = tag3 };
            ResourceGroup resourceGroup4 = new ResourceGroup() { Name = resourceGroupName + 4, Location = resourceGroupLocation };
            var listResult = new List<ResourceGroup>() { resourceGroup1, resourceGroup2, resourceGroup3, resourceGroup4 };
            var pagableResult = new Page<ResourceGroup>();
            pagableResult.SetItemValue(listResult);
            resourceGroupMock.Setup(f => f.ListWithHttpMessagesAsync(null, null, new CancellationToken()))
                             .Returns(Task.Factory.StartNew(() =>
                                new AzureOperationResponse<IPage<ResourceGroup>>()
                                {
                                    Body = pagableResult
                                }));
            SetupListForResourceGroupAsync(resourceGroup1.Name, new List<GenericResource>() { CreateGenericResource(null, null, "resource") });
            SetupListForResourceGroupAsync(resourceGroup2.Name, new List<GenericResource>() { CreateGenericResource(null, null, "resource") });
            SetupListForResourceGroupAsync(resourceGroup3.Name, new List<GenericResource>() { CreateGenericResource(null, null, "resource") });
            SetupListForResourceGroupAsync(resourceGroup4.Name, new List<GenericResource>() { CreateGenericResource(null, null, "resource") });

            List<PSResourceGroup> groups1 = resourcesClient.FilterResourceGroups(null,
                new Hashtable(new Dictionary<string, string> { { "tag1", "val1" } }), true);

            Assert.Equal(1, groups1.Count);
            Assert.Equal(resourceGroup1.Name, groups1[0].ResourceGroupName);

            List<PSResourceGroup> groups2 = resourcesClient.FilterResourceGroups(null,
                new Hashtable(new Dictionary<string, string> { { "tag2", "" } }), true);

            Assert.Equal(2, groups2.Count);
            Assert.Equal(resourceGroup1.Name, groups2[0].ResourceGroupName);
            Assert.Equal(resourceGroup3.Name, groups2[1].ResourceGroupName);

            List<PSResourceGroup> groups3 = resourcesClient.FilterResourceGroups(null,
                new Hashtable(new Dictionary<string, string> { { "tag3", "" } }), true);

            Assert.Equal(0, groups3.Count);

            List<PSResourceGroup> groups4 = resourcesClient.FilterResourceGroups(null,
                new Hashtable(new Dictionary<string, string> { { "TAG1", "val1" }}), true);

            Assert.Equal(1, groups4.Count);
            Assert.Equal(resourceGroup1.Name, groups4[0].ResourceGroupName);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void DeletesResourcesGroup()
        {
            resourceGroupMock.Setup(f => f.CheckExistenceWithHttpMessagesAsync(resourceGroupName, null, new CancellationToken()))
                .Returns(Task.Factory.StartNew(() =>
                    new AzureOperationResponse<bool?>()
                    {
                        Body = (bool?)true
                    }));

            resourcesClient.DeleteResourceGroup(resourceGroupName);

            resourceGroupMock.Verify(f => f.DeleteWithHttpMessagesAsync(resourceGroupName, null, It.IsAny<CancellationToken>()), Times.Once());
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void FiltersOneResourceGroupDeployment()
        {
            FilterResourceGroupDeploymentOptions options = new FilterResourceGroupDeploymentOptions()
            {
                DeploymentName = deploymentName,
                ResourceGroupName = resourceGroupName
            };
            deploymentsMock.Setup(f => f.GetWithHttpMessagesAsync(resourceGroupName, deploymentName, null, new CancellationToken()))
            .Returns(Task.Factory.StartNew(() => new AzureOperationResponse<DeploymentExtended>()
            {
                Body = new DeploymentExtended()
                {
                    Name = deploymentName,
                    Properties = new DeploymentPropertiesExtended()
                    {
                        Mode = DeploymentMode.Incremental,
                        CorrelationId = "123",
                        TemplateLink = new TemplateLink()
                        {
                            Uri = "http://microsoft.com/"
                        }
                    }
                }
            }));

            List<Microsoft.Azure.Commands.ResourceManager.Cmdlets.SdkModels.PSResourceGroupDeployment> result = resourcesClient.FilterResourceGroupDeployments(options);

            Assert.Equal(deploymentName, result[0].DeploymentName);
            Assert.Equal(resourceGroupName, result[0].ResourceGroupName);
            Assert.Equal(DeploymentMode.Incremental, result[0].Mode);
            Assert.Equal("123", result[0].CorrelationId);
            Assert.Equal(new Uri("http://microsoft.com").ToString(), result[0].TemplateLink.Uri.ToString());
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void CancelsActiveDeployment()
        {
            DeploymentExtended actualParameters = new DeploymentExtended();

            var listResult = new List<DeploymentExtended>()
            {
                new DeploymentExtended()
                {
                    Name = deploymentName + 1,
                    Properties = new DeploymentPropertiesExtended()
                    {
                        Mode = DeploymentMode.Incremental,
                        TemplateLink = new TemplateLink()
                        {
                            Uri = "http://microsoft1.com"
                        },
                        ProvisioningState = "Succeeded"
                    }
                },
                new DeploymentExtended()
                {
                    Name = deploymentName + 2,
                    Properties = new DeploymentPropertiesExtended()
                    {
                        Mode = DeploymentMode.Incremental,
                        TemplateLink = new TemplateLink()
                        {
                            Uri = "http://microsoft1.com"
                        },
                        ProvisioningState = "Failed"
                    }
                },
                new DeploymentExtended()
                {
                    Name = deploymentName + 3,
                    Properties = new DeploymentPropertiesExtended()
                    {
                        Mode = DeploymentMode.Incremental,
                        TemplateLink = new TemplateLink()
                        {
                            Uri = "http://microsoft1.com"
                        },
                        ProvisioningState = "Running"
                    }
                }
            };
            var pagableResult = new Page<DeploymentExtended>();
            pagableResult.SetItemValue<DeploymentExtended>(listResult);
            var result = new AzureOperationResponse<IPage<DeploymentExtended>>()
            {
                Body = pagableResult
            };
            deploymentsMock.Setup(f => f.ListWithHttpMessagesAsync(
                resourceGroupName,
                null,
                null,
                It.IsAny<CancellationToken>()))
                .Returns(Task.Factory.StartNew(() => result));

            resourcesClient.CancelDeployment(resourceGroupName, null);

            deploymentsMock.Verify(f => f.CancelWithHttpMessagesAsync(resourceGroupName, deploymentName + 3, null, new CancellationToken()), Times.Once());
        }

        [Fact(Skip = "Test produces different outputs since hashtable order is not guaranteed.")]
        public void SerializeHashtableProperlyHandlesAllDataTypes()
        {
            Hashtable hashtable = new Hashtable();
            var password = "pass";
            hashtable.Add("key1", "string");
            hashtable.Add("key2", 1);
            hashtable.Add("key3", true);
            hashtable.Add("key4", new DateTime(2014, 05, 08));
            hashtable.Add("key5", null);
            hashtable.Add("key6", password);

            string resultWithoutAddedLayer = resourcesClient.SerializeHashtable(hashtable, false);
            Assert.NotEmpty(resultWithoutAddedLayer);
            EqualsIgnoreWhitespace(@"{
                ""key5"": null,
                ""key2"": 1,
                ""key4"": ""2014-05-08T00:00:00"",
                ""key6"": ""pass"",
                ""key1"": ""string"",
                ""key3"": true
            }", resultWithoutAddedLayer);

            string resultWithAddedLayer = resourcesClient.SerializeHashtable(hashtable, true);
            Assert.NotEmpty(resultWithAddedLayer);
            EqualsIgnoreWhitespace(@"{
              ""key5"": {
                ""value"": null
              },
              ""key2"": {
                ""value"": 1
              },
              ""key4"": {
                ""value"": ""2014-05-08T00:00:00""
              },
              ""key6"": {
                ""value"": ""pass""
              },
              ""key1"": {
                ""value"": ""string""
              },
              ""key3"": {
                ""value"": true
              }
            }", resultWithAddedLayer);
        }
    }
}
