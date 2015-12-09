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

using Microsoft.Azure.Commands.Resources.Models;
using Microsoft.Azure.Commands.ScenarioTest;
using Microsoft.Azure.Commands.Test.Utilities.Common;
using Microsoft.Azure.Management.Authorization;
using Microsoft.Azure.Management.Resources;
using Microsoft.Azure.Management.Resources.Models;
using Microsoft.Rest.Azure;
using Moq;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Net;
using System.Reflection;
using System.Runtime.Serialization.Formatters;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
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

        private Mock<IPermissionsOperations> permissionOperationsMock;

        private Mock<Action<string>> progressLoggerMock;

        private Mock<Action<string>> errorLoggerMock;

        private ResourcesClient resourcesClient;

        private string resourceGroupName = "myResourceGroup";

        private string resourceGroupLocation = "West US";

        private string deploymentName = "fooDeployment";

        private string templateFile = @"Resources\sampleTemplateFile.json";

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
            if(location != null)
            {
                resource.Location = location;
            }

            return resource;
        }

        private void ConfirmAction(bool force, string actionMessage, string processMessage, string target, Action action)
        {
            ConfirmActionCounter++;
            action();
        }

        private int RejectActionCounter = 0;

        private void RejectAction(bool force, string actionMessage, string processMessage, string target, Action action)
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
            .Returns(Task.Factory.StartNew(() => new AzureOperationResponse<IPage<GenericResource>>() {
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

        public ResourceClientTests()
        {
            resourceManagementClientMock = new Mock<IResourceManagementClient>();
            authorizationManagementClientMock = new Mock<IAuthorizationManagementClient>();
            deploymentsMock = new Mock<IDeploymentsOperations>();
            resourceGroupMock = new Mock<IResourceGroupsOperations>();
            resourceOperationsMock = new Mock<IResourcesOperations>();
            //eventsClientMock = new Mock<IEventsClient>();
            deploymentOperationsMock = new Mock<IDeploymentOperationsOperations>();
            //eventDataOperationsMock = new Mock<IEventDataOperations>();
            providersMock = new Mock<IProvidersOperations>();
            providersMock.Setup(f => f.ListWithHttpMessagesAsync(null, null, new CancellationToken()))
                .Returns(Task.Factory.StartNew(() =>
                new AzureOperationResponse<IPage<Provider>>()
                {
                    Body = new Page<Provider>()
                }));
            progressLoggerMock = new Mock<Action<string>>();
            errorLoggerMock = new Mock<Action<string>>();
            permissionOperationsMock = new Mock<IPermissionsOperations>();
            resourceManagementClientMock.Setup(f => f.Deployments).Returns(deploymentsMock.Object);
            resourceManagementClientMock.Setup(f => f.ResourceGroups).Returns(resourceGroupMock.Object);
            resourceManagementClientMock.Setup(f => f.Resources).Returns(resourceOperationsMock.Object);
            resourceManagementClientMock.Setup(f => f.DeploymentOperations).Returns(deploymentOperationsMock.Object);
            resourceManagementClientMock.Setup(f => f.Providers).Returns(providersMock.Object);
            resourceManagementClientMock.Setup(f => f.ApiVersion).Returns("11-01-2015");
            // TODO: http://vstfrd:8080/Azure/RD/_workitems#_a=edit&id=3247094
            //eventsClientMock.Setup(f => f.EventData).Returns(eventDataOperationsMock.Object);
            authorizationManagementClientMock.Setup(f => f.Permissions).Returns(permissionOperationsMock.Object);
            resourcesClient = new ResourcesClient(
                resourceManagementClientMock.Object,
                // TODO: http://vstfrd:8080/Azure/RD/_workitems#_a=edit&id=3247094
                //eventsClientMock.Object,
                authorizationManagementClientMock.Object)
            {
                VerboseLogger = progressLoggerMock.Object,
                ErrorLogger = errorLoggerMock.Object,
                DataStore = new Common.Authentication.Models.DiskDataStore()
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

            // TODO: http://vstfrd:8080/Azure/RD/_workitems#_a=edit&id=3247094
            //sampleEvents = new List<EventData>();
            //sampleEvents.Add(new EventData
            //    {
            //        EventDataId = "ac7d2ab5-698a-4c33-9c19-0a93d3d7f527",
            //        EventName = new LocalizableString { LocalizedValue = "Start request" },
            //        EventSource = new LocalizableString { LocalizedValue = "Microsoft Resources" },
            //        EventChannels = EventChannels.Operation,
            //        Level = EventLevel.Informational,
            //        EventTimestamp = DateTime.Now,
            //        OperationId = "c0f2e85f-efb0-47d0-bf90-f983ec8be91d",
            //        SubscriptionId = "c0f2e85f-efb0-47d0-bf90-f983ec8be91d",
            //        CorrelationId = "c0f2e85f-efb0-47d0-bf90-f983ec8be91d",
            //        OperationName =
            //            new LocalizableString
            //                {
            //                    LocalizedValue = "Microsoft.Resources/subscriptions/resourcegroups/deployments/write"
            //                },
            //        Status = new LocalizableString { LocalizedValue = "Succeeded" },
            //        SubStatus = new LocalizableString { LocalizedValue = "Created" },
            //        ResourceGroupName = "foo",
            //        ResourceProviderName = new LocalizableString { LocalizedValue = "Microsoft Resources" },
            //        ResourceUri =
            //            "/subscriptions/ffce8037-a374-48bf-901d-dac4e3ea8c09/resourcegroups/foo/deployments/testdeploy",
            //        HttpRequest = new HttpRequestInfo
            //            {
            //                Uri =
            //                    "http://path/subscriptions/ffce8037-a374-48bf-901d-dac4e3ea8c09/resourcegroups/foo/deployments/testdeploy",
            //                Method = "PUT",
            //                ClientRequestId = "1234",
            //                ClientIpAddress = "123.123.123.123"
            //            },
            //        Authorization = new SenderAuthorization
            //            {
            //                Action = "PUT",
            //                Condition = "",
            //                Role = "Sender",
            //                Scope = "None"
            //            },
            //        Claims = new Dictionary<string, string>
            //            {
            //                {"aud", "https://management.core.windows.net/"},
            //                {"iss", "https://sts.windows.net/123456/"},
            //                {"iat", "h123445"},
            //                {"http://schemas.xmlsoap.org/ws/2005/05/identity/claims/name", "info@mail.com"}
            //            },
            //        Properties = new Dictionary<string, string>()
            //    });
            //sampleEvents.Add(new EventData
            //{
            //    EventDataId = "ac7d2ab5-698a-4c33-9c19-0sdfsdf34r54",
            //    EventName = new LocalizableString { LocalizedValue = "End request" },
            //    EventSource = new LocalizableString { LocalizedValue = "Microsoft Resources" },
            //    EventChannels = EventChannels.Operation,
            //    Level = EventLevel.Informational,
            //    EventTimestamp = DateTime.Now,
            //    OperationId = "c0f2e85f-efb0-47d0-bf90-f983ec8be91d",
            //    OperationName =
            //        new LocalizableString
            //        {
            //            LocalizedValue = "Microsoft.Resources/subscriptions/resourcegroups/deployments/write"
            //        },
            //    Status = new LocalizableString { LocalizedValue = "Succeeded" },
            //    SubStatus = new LocalizableString { LocalizedValue = "Created" },
            //    ResourceGroupName = "foo",
            //    ResourceProviderName = new LocalizableString { LocalizedValue = "Microsoft Resources" },
            //    ResourceUri =
            //        "/subscriptions/ffce8037-a374-48bf-901d-dac4e3ea8c09/resourcegroups/foo/deployments/testdeploy",
            //    HttpRequest = new HttpRequestInfo
            //    {
            //        Uri =
            //            "http://path/subscriptions/ffce8037-a374-48bf-901d-dac4e3ea8c09/resourcegroups/foo/deployments/testdeploy",
            //        Method = "PUT",
            //        ClientRequestId = "1234",
            //        ClientIpAddress = "123.123.123.123"
            //    },
            //    Authorization = new SenderAuthorization
            //    {
            //        Action = "PUT",
            //        Condition = "",
            //        Role = "Sender",
            //        Scope = "None"
            //    },
            //    Claims = new Dictionary<string, string>
            //            {
            //                {"aud", "https://management.core.windows.net/"},
            //                {"iss", "https://sts.windows.net/123456/"},
            //                {"iat", "h123445"}
            //            },
            //    Properties = new Dictionary<string, string>()
            //});
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void NewResourceGroupChecksForPermissionForExistingResource()
        {
            RejectActionCounter = 0;
            CreatePSResourceGroupParameters parameters = new CreatePSResourceGroupParameters() { ResourceGroupName = resourceGroupName, ConfirmAction = RejectAction };
            resourceGroupMock.Setup(f => f.CheckExistenceAsync(parameters.ResourceGroupName, new CancellationToken()))
                .Returns(Task.Factory.StartNew(() => (bool?) true ));

            resourceGroupMock.Setup(f => f.GetAsync(
                parameters.ResourceGroupName,
                new CancellationToken()))
                    .Returns(Task.Factory.StartNew(() => new ResourceGroup() { Name = parameters.ResourceGroupName, Location = parameters.Location } ));

            resourceOperationsMock.Setup(f => f.ListAsync(null, It.IsAny<CancellationToken>()))
                .Returns(() => Task.Factory.StartNew(() => 
                {
                    var resources = new List<GenericResource>()
                        {
                            (GenericResource) new Resource(location: "West US", id: null, name: "foo", type: null, tags: null)
                            /*
                            {
                                ProvisioningState = ProvisioningState.Running
                            }*/,
                            (GenericResource) new Resource(location: "West US", id: null, name: "bar", type: null, tags: null)
                            /*{
                                ProvisioningState = ProvisioningState.Running,
                            }*/
                        };
                    var result = new Page<GenericResource>();

                    System.Reflection.TypeExtensions.GetProperty(result.GetType(), "Items").SetValue(result, resources);

                    return (IPage<GenericResource>) result;
                }));

            resourcesClient.CreatePSResourceGroup(parameters);
            Assert.Equal(1, RejectActionCounter);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void NewResourceGroupWithGalleryTemplateAndWithoutStorageAccountNameSucceeds()
        {
            CreatePSResourceGroupParameters parameters = new CreatePSResourceGroupParameters()
            {
                ResourceGroupName = resourceGroupName,
                Location = resourceGroupLocation,
                ConfirmAction = ConfirmAction,
            };
            resourceGroupMock.Setup(f => f.CheckExistenceAsync(parameters.ResourceGroupName, new CancellationToken()))
                .Returns(Task.Factory.StartNew(() => (bool?) false ));

            resourceGroupMock.Setup(f => f.CreateOrUpdateAsync(
                parameters.ResourceGroupName,
                It.IsAny<ResourceGroup>(),
                new CancellationToken()))
                    .Returns(Task.Factory.StartNew(() => new ResourceGroup() { Name = parameters.ResourceGroupName, Location = parameters.Location }));

            resourceGroupMock.Setup(f => f.GetAsync(resourceGroupName, new CancellationToken()))
                .Returns(Task.Factory.StartNew(() =>  new ResourceGroup()
                    {
                        Name = resourceGroupName,
                        Location = resourceGroupLocation
                    }));

            SetupListForResourceGroupAsync(parameters.ResourceGroupName, new List<GenericResource>());

            deploymentsMock.Setup(f => f.ValidateAsync(resourceGroupName, It.IsAny<string>(), It.IsAny<Deployment>(), new CancellationToken()))
                .Returns(Task.Factory.StartNew(() => new DeploymentValidateResult()
                /*{
                    IsValid = true
                }*/));

            deploymentsMock.Setup(f => f.GetAsync(resourceGroupName, It.IsAny<string>(), new CancellationToken()))
                .Returns(Task.Factory.StartNew(() =>  new DeploymentExtended()
                    {
                        Properties = new DeploymentPropertiesExtended()
                        {
                            ProvisioningState = "Succeeded"
                        }
                    }));
            deploymentOperationsMock.Setup(f => f.ListAsync(resourceGroupName, It.IsAny<string>(), null, new CancellationToken()))
                .Returns(Task.Factory.StartNew(() => GetPagableType(new List<DeploymentOperation>())));

            PSResourceGroup result = resourcesClient.CreatePSResourceGroup(parameters);

            Assert.Equal(parameters.ResourceGroupName, result.ResourceGroupName);
            Assert.Equal(parameters.Location, result.Location);
            Assert.Empty(result.Resources);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void NewResourceGroupWithoutDeploymentSucceeds()
        {
            CreatePSResourceGroupParameters parameters = new CreatePSResourceGroupParameters()
            {
                ResourceGroupName = resourceGroupName,
                Location = resourceGroupLocation,
                ConfirmAction = ConfirmAction
            };
            resourceGroupMock.Setup(f => f.CheckExistenceAsync(parameters.ResourceGroupName, new CancellationToken()))
                .Returns(Task.Factory.StartNew(() => (bool?) false));

            resourceGroupMock.Setup(f => f.CreateOrUpdateAsync(
                parameters.ResourceGroupName,
                It.IsAny<ResourceGroup>(),
                new CancellationToken()))
                    .Returns(Task.Factory.StartNew(() => new ResourceGroup() { Name = parameters.ResourceGroupName, Location = parameters.Location }));
            SetupListForResourceGroupAsync(parameters.ResourceGroupName, new List<GenericResource>());

            PSResourceGroup result = resourcesClient.CreatePSResourceGroup(parameters);

            Assert.Equal(parameters.ResourceGroupName, result.ResourceGroupName);
            Assert.Equal(parameters.Location, result.Location);
            Assert.Empty(result.Resources);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void NewResourceWithExistingResourceAsksForUserConfirmation()
        {
            CreatePSResourceParameters parameters = new CreatePSResourceParameters()
            {
                Location = "West US",
                Name = resourceIdentity.ResourceName,
                ParentResource = resourceIdentity.ParentResource,
                PropertyObject = new Hashtable(properties),
                ResourceGroupName = resourceGroupName,
                ResourceType = resourceIdentity.ResourceGroupName + "/" + resourceIdentity.ResourceType,
                ConfirmAction = RejectAction
            };

            RejectActionCounter = 0;

            resourceOperationsMock.Setup(f => f.CheckExistenceAsync(
                resourceGroupName,
                resourceIdentity.ResourceGroupName,
                resourceIdentity.ParentResource,
                resourceIdentity.ResourceType,
                resourceIdentity.ResourceName,
                "apiVersion",
                It.IsAny<CancellationToken>()))
                .Returns(Task.Factory.StartNew(() => (bool?) true ));

            resourceGroupMock.Setup(f => f.CheckExistenceAsync(resourceGroupName, It.IsAny<CancellationToken>()))
                .Returns(Task.Factory.StartNew(() => (bool?) true));

            resourceOperationsMock.Setup(f => f.GetAsync(
                resourceGroupName,
                resourceIdentity.ResourceGroupName,
                resourceIdentity.ParentResource,
                resourceIdentity.ResourceType,
                resourceIdentity.ResourceName,
                "apiVersion",
                It.IsAny<CancellationToken>()))
                .Returns(Task.Factory.StartNew(() => new GenericResource
                    {
                        Location = "West US",
                        Properties = serializedProperties
                    }));

            resourcesClient.CreatePSResource(parameters);
            Assert.Equal(1, RejectActionCounter);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void NewResourceWithIncorrectTypeThrowsException()
        {
            CreatePSResourceParameters parameters = new CreatePSResourceParameters()
            {
                Location = "West US",
                Name = resourceIdentity.ResourceName,
                ParentResource = resourceIdentity.ParentResource,
                PropertyObject = new Hashtable(properties),
                ResourceGroupName = resourceGroupName,
                ResourceType = "abc",
                ConfirmAction = ConfirmAction
            };

            Assert.Throws<ArgumentException>(() => resourcesClient.CreatePSResource(parameters));
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void NewResourceWithAllParametersSucceeds()
        {
            CreatePSResourceParameters parameters = new CreatePSResourceParameters()
            {
                Location = "West US",
                Name = resourceIdentity.ResourceName,
                ParentResource = resourceIdentity.ParentResource,
                PropertyObject = new Hashtable(properties),
                ResourceGroupName = resourceGroupName,
                ResourceType = resourceIdentity.ResourceGroupName + "/" + resourceIdentity.ResourceType,
                ConfirmAction = ConfirmAction
            };

            resourceOperationsMock.Setup(f => f.GetAsync(
                resourceGroupName,
                resourceIdentity.ResourceGroupName,
                resourceIdentity.ParentResource,
                resourceIdentity.ResourceType,
                resourceIdentity.ResourceName,
                "apiVersion",
                It.IsAny<CancellationToken>()))
                .Returns(() => Task.Factory.StartNew(() => {
                    var retValue = new GenericResource
                    {
                        Location = parameters.Location,
                        Properties = serializedProperties
                    };

                    System.Reflection.TypeExtensions.GetProperty(typeof(GenericResource), "Name").SetValue(retValue, parameters.Name);
                    return retValue;
                }));

            resourceGroupMock.Setup(f => f.CheckExistenceAsync(resourceGroupName, It.IsAny<CancellationToken>()))
                .Returns(Task.Factory.StartNew(() => (bool?) true ));

            resourceOperationsMock.Setup(f => f.CheckExistenceAsync(
                resourceGroupName,
                resourceIdentity.ResourceGroupName,
                resourceIdentity.ParentResource,
                resourceIdentity.ResourceType,
                resourceIdentity.ResourceName,
                "apiVersion",
                It.IsAny<CancellationToken>()))
                .Returns(Task.Factory.StartNew(() => (bool?) false ));

            resourceOperationsMock.Setup(f => f.CreateOrUpdateAsync(
                resourceGroupName,
                resourceIdentity.ResourceGroupName,
                resourceIdentity.ParentResource,
                resourceIdentity.ResourceType,
                resourceIdentity.ResourceName,
                "apiVersion",
                It.IsAny<GenericResource>(), 
                It.IsAny<CancellationToken>()))
                .Returns(Task.Factory.StartNew(() => new GenericResource
                    {
                        Location = "West US",
                        Properties = serializedProperties
                    }
                ));

            PSResource result = resourcesClient.CreatePSResource(parameters);

            Assert.NotNull(result);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void SetResourceWithoutExistingResourceThrowsException()
        {
            UpdatePSResourceParameters parameters = new UpdatePSResourceParameters()
            {
                Name = resourceIdentity.ResourceName,
                ParentResource = resourceIdentity.ParentResource,
                PropertyObject = new Hashtable(properties),
                ResourceGroupName = resourceGroupName,
                ResourceType = resourceIdentity.ResourceGroupName + "/" + resourceIdentity.ResourceType,
            };

            resourceOperationsMock.Setup(f => f.GetAsync(
                resourceGroupName,
                resourceIdentity.ResourceGroupName,
                resourceIdentity.ParentResource,
                resourceIdentity.ResourceType,
                resourceIdentity.ResourceName,
                "apiVersion",
                It.IsAny<CancellationToken>()))
                .Returns(() => { throw new CloudException("Resource does not exist."); });

            Assert.Throws<ArgumentException>(() => resourcesClient.UpdatePSResource(parameters));
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void SetResourceWithIncorrectTypeThrowsException()
        {
            UpdatePSResourceParameters parameters = new UpdatePSResourceParameters()
            {
                Name = resourceIdentity.ResourceName,
                ParentResource = resourceIdentity.ParentResource,
                PropertyObject = new Hashtable(properties),
                ResourceGroupName = resourceGroupName,
                ResourceType = "abc",
            };

            Assert.Throws<ArgumentException>(() => resourcesClient.UpdatePSResource(parameters));
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void SetResourceWithAllParameters()
        {
            UpdatePSResourceParameters parameters = new UpdatePSResourceParameters()
            {
                Name = resourceIdentity.ResourceName,
                ParentResource = resourceIdentity.ParentResource,
                PropertyObject = new Hashtable(properties),
                ResourceGroupName = resourceGroupName,
                ResourceType = resourceIdentity.ResourceGroupName + "/" + resourceIdentity.ResourceType,
            };

            resourceOperationsMock.Setup(f => f.GetAsync(
                resourceGroupName,
                resourceIdentity.ResourceGroupName,
                resourceIdentity.ParentResource,
                resourceIdentity.ResourceType,
                resourceIdentity.ResourceName,
                "apiVersion",
                It.IsAny<CancellationToken>()))
                .Returns(() => Task.Factory.StartNew(() => {
                    var retValue = new GenericResource
                    {
                        Location = "West US",
                        Properties = serializedProperties
                    };

                    System.Reflection.TypeExtensions.GetProperty(typeof(GenericResource), "Name").SetValue(retValue, parameters.Name);
                    return retValue;
                }));

            resourceOperationsMock.Setup(f => f.CreateOrUpdateAsync(
                resourceGroupName, resourceIdentity.ResourceGroupName,
                resourceIdentity.ParentResource,
                resourceIdentity.ResourceType,
                resourceIdentity.ResourceName,
                "apiVersion",
                It.IsAny<GenericResource>(), It.IsAny<CancellationToken>()))
                .Returns(Task.Factory.StartNew(() => new GenericResource
                    {
                        Location = "West US",
                        Properties = serializedProperties
                    }));

            PSResource result = resourcesClient.UpdatePSResource(parameters);

            Assert.NotNull(result);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void SetResourceWithReplaceRewritesResource()
        {
            var originalProperties = new Dictionary<string, object>
                {
                    {"name", "site1"},
                    {"siteMode", "Standard"},
                    {"computeMode", "Dedicated"},
                    {"list", new [] {1,2,3}},
                    {"misc", new Dictionary<string, object>
                        {
                            {"key1", "value1"},
                            {"key2", "value2"}
                        }}};

            var originalPropertiesSerialized = JsonConvert.SerializeObject(originalProperties, new JsonSerializerSettings
            {
                TypeNameAssemblyFormat = FormatterAssemblyStyle.Simple,
                TypeNameHandling = TypeNameHandling.None
            });

            var patchProperties = new Dictionary<string, object>
                {
                    {"siteMode", "Dedicated"},
                    {"newMode", "NewValue"},
                    {"list", new [] {4,5,6}},
                    {"misc", new Dictionary<string, object>
                        {
                            {"key3", "value3"}
                        }}};

            UpdatePSResourceParameters parameters = new UpdatePSResourceParameters()
            {
                Name = resourceIdentity.ResourceName,
                ParentResource = resourceIdentity.ParentResource,
                PropertyObject = new Hashtable(patchProperties),
                ResourceGroupName = resourceGroupName,
                ResourceType = resourceIdentity.ResourceGroupName + "/" + resourceIdentity.ResourceType
            };

            GenericResource actual = new GenericResource();

            resourceOperationsMock.Setup(f => f.GetAsync(
                resourceGroupName,
                resourceIdentity.ResourceGroupName,
                resourceIdentity.ParentResource,
                resourceIdentity.ResourceType,
                resourceIdentity.ResourceName,
                "apiVersion",
                It.IsAny<CancellationToken>()))
                .Returns(() => Task.Factory.StartNew(() => {
                    var retValue = new GenericResource
                    {
                        Location = "West US",
                        Properties = originalPropertiesSerialized
                    };

                    System.Reflection.TypeExtensions.GetProperty(typeof(GenericResource), "Name").SetValue(retValue, parameters.Name);
                    return retValue;
                }));

            resourceOperationsMock.Setup(f => f.CreateOrUpdateAsync(
                resourceGroupName,
                resourceIdentity.ResourceGroupName,
                resourceIdentity.ParentResource,
                resourceIdentity.ResourceType,
                resourceIdentity.ResourceName,
                "apiVersion",
                It.IsAny<GenericResource>(), 
                It.IsAny<CancellationToken>()))
                .Returns(Task.Factory.StartNew(() => new GenericResource
                    {
                        Location = "West US",
                        Properties = originalPropertiesSerialized
                    }
                ))
                .Callback((string groupName, GenericResource p, CancellationToken token) => actual = p);

            resourcesClient.UpdatePSResource(parameters);

            JToken actualJson = JToken.Parse(actual.Properties.ToString());

            Assert.Null(actualJson["name"]);
            Assert.Equal("Dedicated", actualJson["siteMode"].ToObject<string>());
            Assert.Null(actualJson["computeMode"]);
            Assert.Equal("NewValue", actualJson["newMode"].ToObject<string>());
            Assert.Equal("[4,5,6]", actualJson["list"].ToString(Formatting.None));
            Assert.Null(actualJson["misc"]["key1"]);
            Assert.Null(actualJson["misc"]["key2"]);
            Assert.Equal("value3", actualJson["misc"]["key3"].ToObject<string>());
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void RemoveResourceWithoutExistingResourceThrowsException()
        {
            BasePSResourceParameters parameters = new BasePSResourceParameters()
            {
                Name = resourceIdentity.ResourceName,
                ParentResource = resourceIdentity.ParentResource,
                ResourceGroupName = resourceGroupName,
                ResourceType = resourceIdentity.ResourceGroupName + "/" + resourceIdentity.ResourceType,
            };

            resourceOperationsMock.Setup(f => f.CheckExistenceAsync(
                resourceGroupName,
                resourceIdentity.ResourceGroupName,
                resourceIdentity.ParentResource,
                resourceIdentity.ResourceType,
                resourceIdentity.ResourceName,
                "apiVersion",
                It.IsAny<CancellationToken>()))
                .Returns(() => Task.Factory.StartNew(() => (bool?) false));

            Assert.Throws<ArgumentException>(() => resourcesClient.DeleteResource(parameters));
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void RemoveResourceWithIncorrectTypeThrowsException()
        {
            BasePSResourceParameters parameters = new BasePSResourceParameters()
            {
                Name = resourceIdentity.ResourceName,
                ParentResource = resourceIdentity.ParentResource,
                ResourceGroupName = resourceGroupName,
                ResourceType = "abc",
            };

            Assert.Throws<ArgumentException>(() => resourcesClient.DeleteResource(parameters));
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void RemoveResourceWithAllParametersSucceeds()
        {
            BasePSResourceParameters parameters = new BasePSResourceParameters()
            {
                Name = resourceIdentity.ResourceName,
                ParentResource = resourceIdentity.ParentResource,
                ResourceGroupName = resourceGroupName,
                ResourceType = resourceIdentity.ResourceGroupName + "/" + resourceIdentity.ResourceType,
            };

            resourceOperationsMock.Setup(f => f.CheckExistenceAsync(
                resourceGroupName,
                resourceIdentity.ResourceGroupName,
                resourceIdentity.ParentResource,
                resourceIdentity.ResourceType,
                resourceIdentity.ResourceName,
                "apiVersion",
                It.IsAny<CancellationToken>()))
                .Returns(() => Task.Factory.StartNew(() => (bool?) true ));

            resourceOperationsMock.Setup(f => f.DeleteAsync(
                resourceGroupName, 
                resourceIdentity.ResourceGroupName,
                resourceIdentity.ParentResource,
                resourceIdentity.ResourceType,
                resourceIdentity.ResourceName,
                "apiVersion",
                It.IsAny<CancellationToken>()));

            resourcesClient.DeleteResource(parameters);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void GetResourceWithAllParametersReturnsOneItem()
        {
            BasePSResourceParameters parameters = new BasePSResourceParameters()
            {
                Name = resourceIdentity.ResourceName,
                ParentResource = resourceIdentity.ParentResource,
                ResourceGroupName = resourceGroupName,
                ResourceType = resourceIdentity.ResourceGroupName + "/" + resourceIdentity.ResourceType,
            };

            resourceGroupMock.Setup(f => f.CheckExistenceWithHttpMessagesAsync(parameters.ResourceGroupName, null, new CancellationToken()))
                .Returns(Task.Factory.StartNew(() => new AzureOperationResponse<bool?>() { Body = (bool?) true} ));

            resourceOperationsMock.Setup(f => f.GetWithHttpMessagesAsync(
                resourceGroupName, 
                resourceIdentity.ResourceGroupName,
                resourceIdentity.ParentResource,
                resourceIdentity.ResourceType,
                resourceIdentity.ResourceName,
                "apiVersion",
                null,
                It.IsAny<CancellationToken>()))
                .Returns(() => Task.Factory.StartNew(() =>
                {
                    var retValue = new GenericResource
                    {
                        Location = "West US",
                        Properties = serializedProperties
                    };

                    System.Reflection.TypeExtensions.GetProperty(typeof(GenericResource), "Name").SetValue(retValue, parameters.Name);
                    return new AzureOperationResponse<GenericResource>() { Body = retValue };
                }));


            List<PSResource> result = resourcesClient.FilterPSResources(parameters);

            Assert.NotNull(result);
            Assert.Equal(1, result.Count);
            Assert.Equal(4, result[0].Properties.Count);
            Assert.Equal(2, ((Dictionary<string, object>)result[0].Properties["misc"]).Count);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void GetResourceWithSomeParametersReturnsList()
        {
            BasePSResourceParameters parameters = new BasePSResourceParameters()
            {
                ResourceGroupName = resourceGroupName,
            };

            resourceGroupMock.Setup(f => f.CheckExistenceAsync(parameters.ResourceGroupName, new CancellationToken()))
                .Returns(Task.Factory.StartNew(() => (bool?) true));

            resourceOperationsMock.Setup(f => f.ListAsync(null, It.IsAny<CancellationToken>()))
                .Returns(() => Task.Factory.StartNew(() => GetPagableType(new List<GenericResource>(new[]
                        {
                            (GenericResource) new Resource(location: "West US", id: null, name: "foo", type: null, tags: null),
                            (GenericResource) new Resource(location: "West US", id: null, name: "bar", type: null, tags: null)
                        }))));


            List<PSResource> result = resourcesClient.FilterPSResources(parameters);

            Assert.NotNull(result);
            Assert.Equal(2, result.Count);
            Assert.False(result.Any(r => r.Properties != null));
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void GetResourceWithIncorrectTypeThrowsException()
        {
            BasePSResourceParameters parameters = new BasePSResourceParameters()
            {
                Name = resourceIdentity.ResourceName,
                ParentResource = resourceIdentity.ParentResource,
                ResourceGroupName = resourceGroupName,
                ResourceType = "abc",
            };

            resourceGroupMock.Setup(f => f.CheckExistenceAsync(parameters.ResourceGroupName, new CancellationToken()))
                .Returns(Task.Factory.StartNew(() => (bool?) true));

            Assert.Throws<ArgumentException>(() => resourcesClient.FilterPSResources(parameters));
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestTemplateShowsErrorMessage()
        {
            Uri templateUri = new Uri("http://templateuri.microsoft.com");
            Deployment deploymentFromValidate = new Deployment();
            ValidatePSResourceGroupDeploymentParameters parameters = new ValidatePSResourceGroupDeploymentParameters()
            {
                ResourceGroupName = resourceGroupName,
                TemplateFile = templateFile,
                StorageAccountName = storageAccountName,
            };
            resourceGroupMock.Setup(f => f.CheckExistenceAsync(parameters.ResourceGroupName, new CancellationToken()))
                .Returns(Task.Factory.StartNew(() => (bool?) true ));

            deploymentsMock.Setup(f => f.ValidateAsync(resourceGroupName, It.IsAny<string>(), It.IsAny<Deployment>(), new CancellationToken()))
                .Returns(Task.Factory.StartNew(() => new DeploymentValidateResult
                {
                    Error = new ResourceManagementErrorWithDetails()
                    {
                        Code = "404",
                        Message = "Awesome error message",
                        Details = new List<ResourceManagementError>(new[] { new ResourceManagementError
                            {
                                Code = "SubError",
                                Message = "Sub error message"
                            }})
                    }
                }))
                .Callback((string rg, string dn, Deployment d, CancellationToken c) => { deploymentFromValidate = d; });

            IEnumerable<PSResourceManagerError> error = resourcesClient.ValidatePSResourceGroupDeployment(parameters, DeploymentMode.Incremental);
            Assert.Equal(2, error.Count());
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestTemplateShowsSuccessMessage()
        {
            Uri templateUri = new Uri("http://templateuri.microsoft.com");
            Deployment deploymentFromValidate = new Deployment();
            ValidatePSResourceGroupDeploymentParameters parameters = new ValidatePSResourceGroupDeploymentParameters()
            {
                ResourceGroupName = resourceGroupName,
                TemplateFile = templateFile,
                StorageAccountName = storageAccountName,
            };
            resourceGroupMock.Setup(f => f.CheckExistenceAsync(parameters.ResourceGroupName, new CancellationToken()))
                .Returns(Task.Factory.StartNew(() => (bool?) true));

            deploymentsMock.Setup(f => f.ValidateAsync(resourceGroupName, It.IsAny<string>(), It.IsAny<Deployment>(), new CancellationToken()))
                .Returns(Task.Factory.StartNew(() => new DeploymentValidateResult
                {
                    Error = new ResourceManagementErrorWithDetails()
                    {
                        Code = "404",
                        Message = "Awesome error message",
                        Details = new List<ResourceManagementError>(new[] { new ResourceManagementError
                            {
                                Code = "SubError",
                                Message = "Sub error message"
                            }})
                    }
                }))
                .Callback((string rg, string dn, Deployment d, CancellationToken c) => { deploymentFromValidate = d; });

            IEnumerable<PSResourceManagerError> error = resourcesClient.ValidatePSResourceGroupDeployment(parameters, DeploymentMode.Incremental);
            Assert.Equal(0, error.Count());
            progressLoggerMock.Verify(f => f("Template is valid."), Times.Once());
        }

        [Fact]
        public void NewResourceGroupUsesDeploymentNameForDeploymentName()
        {
            string deploymentName = "abc123";
            Deployment deploymentFromGet = new Deployment();
            Deployment deploymentFromValidate = new Deployment();
            CreatePSResourceGroupParameters parameters = new CreatePSResourceGroupParameters()
            {
                ResourceGroupName = resourceGroupName,
                Location = resourceGroupLocation,
                DeploymentName = deploymentName,
                StorageAccountName = storageAccountName,
                ConfirmAction = ConfirmAction
            };
            

            deploymentsMock.Setup(f => f.ValidateAsync(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<Deployment>(), new CancellationToken()))
                .Returns(Task.Factory.StartNew(() => new DeploymentValidateResult
                {
                    Error = new ResourceManagementErrorWithDetails()
                }))
                .Callback((string rg, string dn, Deployment d, CancellationToken c) => { deploymentFromValidate = d; });

            deploymentsMock.Setup(f => f.CreateOrUpdateAsync(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<Deployment>(), new CancellationToken()))
                .Returns(Task.Factory.StartNew(() => new DeploymentExtended
                {
                    Id = requestId
                }))
                .Callback((string name, string dName, Deployment bDeploy, CancellationToken token) => { deploymentFromGet = bDeploy; deploymentName = dName; });

            SetupListForResourceGroupAsync(parameters.ResourceGroupName, new List<GenericResource>
            {
                (GenericResource) new Resource(null, null, "website")
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
            deploymentOperationsMock.SetupSequence(f => f.ListAsync(It.IsAny<string>(), It.IsAny<string>(), null, new CancellationToken()))
                .Returns(Task.Factory.StartNew(() => GetPagableType( new List<DeploymentOperation>()
                    {
                        operationQueue.Dequeue()
                    })))
                .Returns(Task.Factory.StartNew(() => GetPagableType( new List<DeploymentOperation>()
                    {
                        operationQueue.Dequeue()
                    })))
                .Returns(Task.Factory.StartNew(() => GetPagableType( new List<DeploymentOperation>()
                    {
                        operationQueue.Dequeue()
                    })));

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
            deploymentsMock.SetupSequence(f => f.GetAsync(It.IsAny<string>(), It.IsAny<string>(), new CancellationToken()))
                .Returns(Task.Factory.StartNew(() => deploymentQueue.Dequeue()))
                .Returns(Task.Factory.StartNew(() => deploymentQueue.Dequeue()))
                .Returns(Task.Factory.StartNew(() => deploymentQueue.Dequeue()));

            PSResourceGroupDeployment result = resourcesClient.ExecuteDeployment(parameters);
            Assert.Equal(deploymentName, deploymentName);
            Assert.Equal("Succeeded", result.ProvisioningState);
            progressLoggerMock.Verify(
                f => f(string.Format("Resource {0} '{1}' provisioning status is {2}", "Microsoft.Website", resourceName, "Accepted".ToLower())),
                Times.Once());
            progressLoggerMock.Verify(
                f => f(string.Format("Resource {0} '{1}' provisioning status is {2}", "Microsoft.Website", resourceName, "Running".ToLower())),
                Times.Once());
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
            CreatePSResourceGroupParameters parameters = new CreatePSResourceGroupParameters()
            {
                ResourceGroupName = resourceGroupName,
                Location = resourceGroupLocation,
                DeploymentName = deploymentName,
                TemplateFile = templateFile,
                StorageAccountName = storageAccountName,
                ConfirmAction = ConfirmAction
            };
            resourceGroupMock.Setup(f => f.CheckExistenceAsync(parameters.ResourceGroupName, new CancellationToken()))
                .Returns(Task.Factory.StartNew(() => (bool?) false));

            resourceGroupMock.Setup(f => f.CreateOrUpdateAsync(
                parameters.ResourceGroupName,
                It.IsAny<ResourceGroup>(),
                new CancellationToken()))
                    .Returns(Task.Factory.StartNew(() => new ResourceGroup() { Name = parameters.ResourceGroupName, Location = parameters.Location } ));

            resourceGroupMock.Setup(f => f.GetAsync(resourceGroupName, new CancellationToken()))
                .Returns(Task.Factory.StartNew(() => new ResourceGroup() { Location = resourceGroupLocation } ));

            deploymentsMock.Setup(f => f.CreateOrUpdateAsync(resourceGroupName, deploymentName, It.IsAny<Deployment>(), new CancellationToken()))
                .Returns(Task.Factory.StartNew(() => new DeploymentExtended
                {
                    Id = requestId
                }))
                .Callback((string name, string dName, Deployment bDeploy, CancellationToken token) => { deploymentFromGet = bDeploy; });
            deploymentsMock.Setup(f => f.GetAsync(resourceGroupName, deploymentName, new CancellationToken()))
                .Returns(Task.Factory.StartNew(() => new DeploymentExtended()
                    {
                        Name = deploymentName,
                        Properties = new DeploymentPropertiesExtended()
                        {
                            Mode = DeploymentMode.Incremental,
                            CorrelationId = "123",
                            ProvisioningState = "Succeeded"
                        },
                    }
                ));

            deploymentsMock.Setup(f => f.ValidateAsync(resourceGroupName, It.IsAny<string>(), It.IsAny<Deployment>(), new CancellationToken()))
                .Returns(Task.Factory.StartNew(() => new DeploymentValidateResult
                {
                    Error = new ResourceManagementErrorWithDetails()
                }))
                .Callback((string rg, string dn, Deployment d, CancellationToken c) => { deploymentFromValidate = d; });

            SetupListForResourceGroupAsync(parameters.ResourceGroupName, new List<GenericResource>() {(GenericResource) new Resource(null, null, "website")});
            deploymentOperationsMock.Setup(f => f.ListAsync(resourceGroupName, deploymentName, null, new CancellationToken()))
                .Returns(Task.Factory.StartNew(() => GetPagableType( new List<DeploymentOperation>()
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
                    })));

            PSResourceGroup result = resourcesClient.CreatePSResourceGroup(parameters);
            deploymentsMock.Verify((f => f.CreateOrUpdateAsync(resourceGroupName, deploymentName, deploymentFromGet, new CancellationToken())), Times.Once());
            Assert.Equal(parameters.ResourceGroupName, result.ResourceGroupName);
            Assert.Equal(parameters.Location, result.Location);
            Assert.Equal(1, result.Resources.Count);

            Assert.Equal(DeploymentMode.Incremental, deploymentFromGet.Properties.Mode);
            Assert.NotNull(deploymentFromGet.Properties.Template);

            progressLoggerMock.Verify(
                f => f(string.Format("Resource {0} '{1}' provisioning status is {2}",
                        "Microsoft.Website",
                        resourceName,
                        "Succeeded".ToLower())),
                Times.Once());
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void CreatesResourceGroupWithDeploymentFromTemplateParameterObject()
        {
            Uri templateUri = new Uri("http://templateuri.microsoft.com");
            Deployment deploymentFromGet = new Deployment();
            Deployment deploymentFromValidate = new Deployment();
            CreatePSResourceGroupParameters parameters = new CreatePSResourceGroupParameters()
            {
                ResourceGroupName = resourceGroupName,
                Location = resourceGroupLocation,
                DeploymentName = deploymentName,
                TemplateFile = templateFile,
                TemplateParameterObject = new Hashtable()
                {
                    { "string", "myvalue" },
                    { "securestring", "myvalue" },
                    { "int", 12 },
                    { "bool", true },
                },
                StorageAccountName = storageAccountName,
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
                .Returns(Task.Factory.StartNew(() => new AzureOperationResponse<ResourceGroup>()
                {
                    Body = new ResourceGroup() { Location = resourceGroupLocation }
                }));
            deploymentsMock.Setup(f => f.CreateOrUpdateWithHttpMessagesAsync(resourceGroupName, deploymentName, 
                    It.IsAny<Deployment>(), null, new CancellationToken()))
                .Returns(Task.Factory.StartNew(() => new AzureOperationResponse<DeploymentExtended>() {
                    Body = new DeploymentExtended { Id = requestId }
                }))
                .Callback((string name, string dName, Deployment bDeploy, Dictionary<string, List<string>> customHeaders, 
                    CancellationToken token) => { deploymentFromGet = bDeploy; });

            deploymentsMock.Setup(f => f.GetWithHttpMessagesAsync(resourceGroupName, deploymentName, null, new CancellationToken()))
                .Returns(Task.Factory.StartNew(() => new AzureOperationResponse<DeploymentExtended>()
                {
                    Body = new DeploymentExtended()
                    {
                        Name = deploymentName,
                        Properties = new DeploymentPropertiesExtended()
                        {
                            Mode = DeploymentMode.Incremental,
                            ProvisioningState = "Succeeded"
                        },
                    }
                }));
            deploymentsMock.Setup(f => f.ValidateWithHttpMessagesAsync(resourceGroupName, It.IsAny<string>(), It.IsAny<Deployment>(), null, new CancellationToken()))
                .Returns(Task.Factory.StartNew(() => new AzureOperationResponse<DeploymentValidateResult>() {
                    Body = new DeploymentValidateResult
                    {
                        Error = new ResourceManagementErrorWithDetails()
                    }
                }))
                .Callback((string rg, string dn, Deployment d, Dictionary<string, List<string>> customHeaders, 
                    CancellationToken c) => { deploymentFromValidate = d; });
            SetupListForResourceGroupAsync(parameters.ResourceGroupName, 
                new List<GenericResource>() { CreateGenericResource(null, null, "website") }); 
            var listOperations = new List<DeploymentOperation>() {
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
            };
            var pageableOperations = new Page<DeploymentOperation>();
            pageableOperations.SetItemValue<DeploymentOperation>(listOperations);
            //System.Reflection.TypeExtensions.GetProperty(pageableOperations.GetType(), "Items").SetValue(pageableOperations, listOperations);
            var operationResponse = new AzureOperationResponse<IPage<DeploymentOperation>>()
            {
                Body = pageableOperations
            };
            deploymentOperationsMock.Setup(f => f.ListWithHttpMessagesAsync(resourceGroupName, deploymentName, null, null, new CancellationToken()))
                .Returns(Task.Factory.StartNew(() => (operationResponse)));

            PSResourceGroup result = resourcesClient.CreatePSResourceGroup(parameters);

            deploymentsMock.Verify((f => f.CreateOrUpdateWithHttpMessagesAsync(resourceGroupName, deploymentName, 
                deploymentFromGet, null, new CancellationToken())), Times.Once());
            Assert.Equal(parameters.ResourceGroupName, result.ResourceGroupName);
            Assert.Equal(parameters.Location, result.Location);
            Assert.Equal(1, result.Resources.Count);

            Assert.Equal(DeploymentMode.Incremental, deploymentFromGet.Properties.Mode);
            Assert.NotNull(deploymentFromGet.Properties.Template);
            // Skip: Test produces different outputs since hashtable order is not guaranteed.
            //EqualsIgnoreWhitespace(File.ReadAllText(templateParameterFile), deploymentFromGet.Parameters);

            // Skip: Test produces different outputs since hashtable order is not guaranteed.
            //EqualsIgnoreWhitespace(File.ReadAllText(templateParameterFile), deploymentFromValidate.Parameters);

            progressLoggerMock.Verify(
                f => f(string.Format("Resource {0} '{1}' provisioning status is {2}",
                        "Microsoft.Website",
                        resourceName,
                        "Succeeded".ToLower())),
                Times.Once());
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void ShowsFailureErrorWhenResourceGroupWithDeploymentFails()
        {
            Uri templateUri = new Uri("http://templateuri.microsoft.com");
            Deployment deploymentFromGet = new Deployment();
            Deployment deploymentFromValidate = new Deployment();
            CreatePSResourceGroupParameters parameters = new CreatePSResourceGroupParameters()
            {
                ResourceGroupName = resourceGroupName,
                Location = resourceGroupLocation,
                DeploymentName = deploymentName,
                TemplateFile = templateFile,
                StorageAccountName = storageAccountName,
                ConfirmAction = ConfirmAction
            };
            resourceGroupMock.Setup(f => f.CheckExistenceAsync(parameters.ResourceGroupName, new CancellationToken()))
                .Returns(Task.Factory.StartNew(() => (bool?)false));

            resourceGroupMock.Setup(f => f.CreateOrUpdateAsync(
                parameters.ResourceGroupName,
                It.IsAny<ResourceGroup>(),
                new CancellationToken()))
                    .Returns(Task.Factory.StartNew(() =>
                    new ResourceGroup() { Name = parameters.ResourceGroupName, Location = parameters.Location }
                    ));
            resourceGroupMock.Setup(f => f.GetAsync(resourceGroupName, new CancellationToken()))
                .Returns(Task.Factory.StartNew(() => new ResourceGroup() { Location = resourceGroupLocation }
                ));
            deploymentsMock.Setup(f => f.CreateOrUpdateAsync(resourceGroupName, deploymentName, It.IsAny<Deployment>(), new CancellationToken()))
                .Returns(Task.Factory.StartNew(() => new DeploymentExtended
                {
                    Id = requestId
                }))
                .Callback((string name, string dName, Deployment bDeploy, CancellationToken token) => { deploymentFromGet = bDeploy; });
            deploymentsMock.Setup(f => f.GetAsync(resourceGroupName, deploymentName, new CancellationToken()))
                .Returns(Task.Factory.StartNew(() => new DeploymentExtended()
                {
                    Name = deploymentName,
                    Properties = new DeploymentPropertiesExtended()
                    {
                        Mode = DeploymentMode.Incremental,
                        ProvisioningState = "Succeeded"
                    },
                }
                ));
            deploymentsMock.Setup(f => f.ValidateAsync(resourceGroupName, It.IsAny<string>(), It.IsAny<Deployment>(), new CancellationToken()))
                .Returns(Task.Factory.StartNew(() => new DeploymentValidateResult
                {
                    Error = new ResourceManagementErrorWithDetails()
                }))
                .Callback((string rg, string dn, Deployment d, CancellationToken c) => { deploymentFromValidate = d; });
            SetupListForResourceGroupAsync(parameters.ResourceGroupName, new List<GenericResource>() {
                (GenericResource) new Resource(null, null, "website") });
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
            System.Reflection.TypeExtensions.GetProperty(pageableOperations.GetType(), "Items").SetValue(pageableOperations, listOperations);

            deploymentOperationsMock.Setup(f => f.ListAsync(resourceGroupName, deploymentName, null, new CancellationToken()))
                .Returns(Task.Factory.StartNew(() => (IPage<DeploymentOperation>)pageableOperations));

            PSResourceGroup result = resourcesClient.CreatePSResourceGroup(parameters);

            deploymentsMock.Verify((f => f.CreateOrUpdateAsync(resourceGroupName, deploymentName, deploymentFromGet, new CancellationToken())), Times.Once());
            Assert.Equal(parameters.ResourceGroupName, result.ResourceGroupName);
            Assert.Equal(parameters.Location, result.Location);
            Assert.Equal(1, result.Resources.Count);

            Assert.Equal(DeploymentMode.Incremental, deploymentFromGet.Properties.Mode);
            Assert.NotNull(deploymentFromGet.Properties.Template);

            errorLoggerMock.Verify(
                f => f(string.Format("Resource {0} '{1}' failed with message '{2}'",
                        "Microsoft.Website",
                        resourceName,
                        "{\"Code\":\"Conflict\"}")),
                Times.Once());
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void ExtractsErrorMessageFromFailedDeploymentOperation()
        {
            Uri templateUri = new Uri("http://templateuri.microsoft.com");
            Deployment deploymentFromGet = new Deployment();
            Deployment deploymentFromValidate = new Deployment();
            CreatePSResourceGroupParameters parameters = new CreatePSResourceGroupParameters()
            {
                ResourceGroupName = resourceGroupName,
                Location = resourceGroupLocation,
                DeploymentName = deploymentName,
                TemplateFile = templateFile,
                StorageAccountName = storageAccountName,
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
                new AzureOperationResponse<ResourceGroup>() { Body = new ResourceGroup() { Location = resourceGroupLocation }}
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
                    CancellationToken token) => { deploymentFromGet = bDeploy; });
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
                    CancellationToken c) => { deploymentFromValidate = d; });

            SetupListForResourceGroupAsync(parameters.ResourceGroupName, new List<GenericResource>() {
                CreateGenericResource(location: null, id: null, name: "website", type: null)});

            var listOperations = new List<DeploymentOperation>() {
                new DeploymentOperation()
                {
                    OperationId = Guid.NewGuid().ToString(),
                    Properties = new DeploymentOperationProperties()
                    {
                        ProvisioningState = "Failed",
                        StatusMessage = JsonConvert.SerializeObject(new ResourceManagementError()
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

            deploymentsMock.Verify((f => f.CreateOrUpdateWithHttpMessagesAsync(
                    resourceGroupName, 
                    deploymentName, 
                    deploymentFromGet, 
                    null, 
                    new CancellationToken())), 
                Times.Once());
            Assert.Equal(parameters.ResourceGroupName, result.ResourceGroupName);
            Assert.Equal(parameters.Location, result.Location);
            Assert.Equal(1, result.Resources.Count);

            Assert.Equal(DeploymentMode.Incremental, deploymentFromGet.Properties.Mode);
            Assert.NotNull(deploymentFromGet.Properties.Template);

            errorLoggerMock.Verify(
                f => f(string.Format("Resource {0} '{1}' failed with message '{2}'",
                        "Microsoft.Website",
                        resourceName,
                        "{\"code\":null,\"message\":\"A really bad error occured\",\"target\":null}")),
                Times.Once());
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void GetsOneResource()
        {
            FilterResourcesOptions options = new FilterResourcesOptions() { ResourceGroup = resourceGroupName, Name = resourceName };
            GenericResource expected = CreateGenericResource(location: resourceGroupLocation, id: "resourceId", name: resourceName, type: null);
            ResourceIdentifier actualParameters = new ResourceIdentifier();
            string actualResourceGroup = null;
            resourceOperationsMock.Setup(f => f.GetAsync(
                resourceGroupName,
                It.IsAny<string>(),
                It.IsAny<string>(),
                It.IsAny<string>(),
                resourceName,
                It.IsAny<string>(),
                new CancellationToken()))
                .Returns(Task.Factory.StartNew(() => expected))
                .Callback((string rg, ResourceIdentifier p, CancellationToken ct) => { actualParameters = p; actualResourceGroup = rg; });

            List<GenericResource> result = resourcesClient.FilterResources(options);

            Assert.Equal(1, result.Count);
            Assert.Equal(options.Name, result.First().Name);
            Assert.Equal(expected.Id, result.First().Id);
            Assert.Equal(expected.Location, result.First().Location);
            Assert.Equal(expected.Name, actualParameters.ResourceName);
            Assert.Equal(resourceGroupName, actualResourceGroup);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void GetsAllResourcesUsingResourceType()
        {
            FilterResourcesOptions options = new FilterResourcesOptions() { ResourceGroup = resourceGroupName, ResourceType = "websites" };
            GenericResource resource1 = CreateGenericResource(location: resourceGroupLocation, id: "resourceId", name: resourceName, type: "websites");
            GenericResource resource2 = CreateGenericResource(resourceGroupLocation, "resourceId2", resourceName + "2", "websites");
            GenericResourceFilter actualParameters = new GenericResourceFilter();
            var listResult = new List<GenericResource>() { resource1, resource2 };
            var pagableResult = new Page<GenericResource>();
            System.Reflection.TypeExtensions.GetProperty(pagableResult.GetType(), "Items").SetValue(pagableResult, listResult);
            resourceOperationsMock.Setup(f => f.ListAsync(null, new CancellationToken()))
                .Returns(Task.Factory.StartNew(() => (IPage<GenericResource>)pagableResult))
                .Callback((GenericResourceFilter p, CancellationToken ct) => { actualParameters = p; });

            List<GenericResource> result = resourcesClient.FilterResources(options);

            Assert.Equal(2, result.Count);
            Assert.Equal(options.ResourceType, actualParameters.ResourceType);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void GetsAllResourceGroupResources()
        {
            FilterResourcesOptions options = new FilterResourcesOptions() { ResourceGroup = resourceGroupName };
            GenericResource resource1 = CreateGenericResource(resourceGroupLocation, "resourceId", resourceName);
            GenericResource resource2 = CreateGenericResource(resourceGroupLocation, "resourceId2", resourceName + "2");
            GenericResourceFilter actualParameters = new GenericResourceFilter();
            var listResult = new List<GenericResource>() { resource1, resource2 };
            var pagableResult = new Page<GenericResource>();
            System.Reflection.TypeExtensions.GetProperty(pagableResult.GetType(), "Items").SetValue(pagableResult, listResult);
            resourceOperationsMock.Setup(f => f.ListAsync(null, new CancellationToken()))
                .Returns(Task.Factory.StartNew(() => (IPage<GenericResource>)pagableResult))
                .Callback((GenericResourceFilter p, CancellationToken ct) => { actualParameters = p; });

            List<GenericResource> result = resourcesClient.FilterResources(options);

            Assert.Equal(2, result.Count);
            Assert.True(string.IsNullOrEmpty(actualParameters.ResourceType));
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
            resourceGroupMock.Setup(f => f.GetAsync(name, new CancellationToken()))
                .Returns(Task.Factory.StartNew(() => resourceGroup
                ));
            SetupListForResourceGroupAsync(name, new List<GenericResource>() { resource1, resource2 });

            List<PSResourceGroup> actual = resourcesClient.FilterResourceGroups(name, null, true);

            Assert.Equal(1, actual.Count);
            Assert.Equal(name, actual[0].ResourceGroupName);
            Assert.Equal(resourceGroupLocation, actual[0].Location);
            Assert.Equal(2, actual[0].Resources.Count);
            Assert.Equal("Succeeded", actual[0].ProvisioningState);
            Assert.True(!string.IsNullOrEmpty(actual[0].ResourcesTable));
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
            System.Reflection.TypeExtensions.GetProperty(pagableResult.GetType(), "Items").SetValue(pagableResult, listResult);
            resourceGroupMock.Setup(f => f.ListAsync(null, new CancellationToken()))
                .Returns(Task.Factory.StartNew(() => (IPage<ResourceGroup>) pagableResult));
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
            Assert.True(actual[0].Resources == null || actual[0].Resources.Count() == 0);
            Assert.True(actual[1].Resources == null || actual[1].Resources.Count() == 0);
            Assert.True(actual[2].Resources == null || actual[2].Resources.Count() == 0);
            Assert.True(actual[3].Resources == null || actual[3].Resources.Count() == 0);
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
            System.Reflection.TypeExtensions.GetProperty(pagableResult.GetType(), "Items").SetValue(pagableResult, listResult);
            resourceGroupMock.Setup(f => f.ListAsync( null, new CancellationToken()))
                .Returns(Task.Factory.StartNew(() => (IPage<ResourceGroup>)pagableResult));
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
            Assert.Equal(1, actual[0].Resources.Count());
            Assert.Equal(1, actual[1].Resources.Count());
            Assert.Equal(1, actual[2].Resources.Count());
            Assert.Equal(1, actual[3].Resources.Count());
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
            System.Reflection.TypeExtensions.GetProperty(pagableResult.GetType(), "Items").SetValue(pagableResult, listResult);
            resourceGroupMock.Setup(f => f.ListAsync(null, new CancellationToken()))
                .Returns(Task.Factory.StartNew(() => (IPage<ResourceGroup>)pagableResult));
            SetupListForResourceGroupAsync(resourceGroup1.Name, new List<GenericResource>() { CreateGenericResource(null, null, "resource") });
            SetupListForResourceGroupAsync(resourceGroup2.Name, new List<GenericResource>() { CreateGenericResource(null, null, "resource") });
            SetupListForResourceGroupAsync(resourceGroup3.Name, new List<GenericResource>() { CreateGenericResource(null, null, "resource") });
            SetupListForResourceGroupAsync(resourceGroup4.Name, new List<GenericResource>() { CreateGenericResource(null, null, "resource") });

            List<PSResourceGroup> groups1 = resourcesClient.FilterResourceGroups(null,
                new Hashtable(new Dictionary<string, string> { { "Name", "tag1" } }), false);

            Assert.Equal(2, groups1.Count);
            Assert.Equal(resourceGroup1.Name, groups1[0].ResourceGroupName);
            Assert.Equal(resourceGroup2.Name, groups1[1].ResourceGroupName);
            Assert.True(groups1[0].Resources == null || groups1[0].Resources.Count() == 0);
            Assert.True(groups1[1].Resources == null || groups1[1].Resources.Count() == 0);

            List<PSResourceGroup> groups2 = resourcesClient.FilterResourceGroups(null,
                new Hashtable(new Dictionary<string, string> { { "Name", "tag2" } }), false);

            Assert.Equal(2, groups2.Count);
            Assert.Equal(resourceGroup1.Name, groups2[0].ResourceGroupName);
            Assert.Equal(resourceGroup3.Name, groups2[1].ResourceGroupName);
            Assert.True(groups2[0].Resources == null || groups2[0].Resources.Count() == 0);
            Assert.True(groups2[1].Resources == null || groups2[1].Resources.Count() == 0);

            List<PSResourceGroup> groups3 = resourcesClient.FilterResourceGroups(null,
                new Hashtable(new Dictionary<string, string> { { "Name", "tag3" } }), false);

            Assert.Equal(0, groups3.Count);

            List<PSResourceGroup> groups4 = resourcesClient.FilterResourceGroups(null,
                new Hashtable(new Dictionary<string, string> { { "Name", "TAG1" }, { "Value", "val1" } }), false);

            Assert.Equal(1, groups4.Count);
            Assert.Equal(resourceGroup1.Name, groups4[0].ResourceGroupName);
            Assert.True(groups4[0].Resources == null || groups4[0].Resources.Count() == 0);
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
            System.Reflection.TypeExtensions.GetProperty(pagableResult.GetType(), "Items").SetValue(pagableResult, listResult);
            resourceGroupMock.Setup(f => f.ListAsync(null, new CancellationToken()))
                .Returns(Task.Factory.StartNew(() => (IPage<ResourceGroup>)pagableResult));
            SetupListForResourceGroupAsync(resourceGroup1.Name, new List<GenericResource>() { CreateGenericResource(null, null, "resource") });
            SetupListForResourceGroupAsync(resourceGroup2.Name, new List<GenericResource>() { CreateGenericResource(null, null, "resource") });
            SetupListForResourceGroupAsync(resourceGroup3.Name, new List<GenericResource>() { CreateGenericResource(null, null, "resource") });
            SetupListForResourceGroupAsync(resourceGroup4.Name, new List<GenericResource>() { CreateGenericResource(null, null, "resource") });

            List<PSResourceGroup> groups1 = resourcesClient.FilterResourceGroups(null,
                new Hashtable(new Dictionary<string, string> { { "Name", "tag1" } }), true);

            Assert.Equal(2, groups1.Count);
            Assert.Equal(resourceGroup1.Name, groups1[0].ResourceGroupName);
            Assert.Equal(resourceGroup2.Name, groups1[1].ResourceGroupName);
            Assert.Equal(1, groups1[0].Resources.Count());
            Assert.Equal(1, groups1[1].Resources.Count());

            List<PSResourceGroup> groups2 = resourcesClient.FilterResourceGroups(null,
                new Hashtable(new Dictionary<string, string> { { "Name", "tag2" } }), true);

            Assert.Equal(2, groups2.Count);
            Assert.Equal(resourceGroup1.Name, groups2[0].ResourceGroupName);
            Assert.Equal(resourceGroup3.Name, groups2[1].ResourceGroupName);
            Assert.Equal(1, groups2[0].Resources.Count());
            Assert.Equal(1, groups2[1].Resources.Count());

            List<PSResourceGroup> groups3 = resourcesClient.FilterResourceGroups(null,
                new Hashtable(new Dictionary<string, string> { { "Name", "tag3" } }), true);

            Assert.Equal(0, groups3.Count);

            List<PSResourceGroup> groups4 = resourcesClient.FilterResourceGroups(null,
                new Hashtable(new Dictionary<string, string> { { "Name", "TAG1" }, { "Value", "val1" } }), true);

            Assert.Equal(1, groups4.Count);
            Assert.Equal(resourceGroup1.Name, groups4[0].ResourceGroupName);
            Assert.Equal(1, groups4[0].Resources.Count());
        }

        // TODO: http://vstfrd:8080/Azure/RD/_workitems#_a=edit&id=3247094
        //[Fact]
        //[Trait(Category.AcceptanceType, Category.CheckIn)]
        //public void GetAzureResourceGroupLogWithAllCallsListEventsForResourceGroup()
        //{
        //    eventDataOperationsMock.Setup(f => f.ListEventsForResourceGroupAsync(It.IsAny<ListEventsForResourceGroupParameters>(), new CancellationToken()))
        //        .Returns(Task.Factory.StartNew(() => new EventDataListResponse
        //            {
        //                EventDataCollection = new EventDataCollection
        //                    {
        //                        Value = sampleEvents
        //                    }
        //            }));

        //    IEnumerable<PSDeploymentEventData> results = resourcesClient.GetResourceGroupLogs(new GetPSResourceGroupLogParameters
        //        {
        //            Name = "foo",
        //            All = true
        //        });

        //    Assert.Equal(2, results.Count());
        //    eventDataOperationsMock.Verify(f => f.ListEventsForResourceGroupAsync(It.IsAny<ListEventsForResourceGroupParameters>(), It.IsAny<CancellationToken>()), Times.Once());
        //}

        // TODO: http://vstfrd:8080/Azure/RD/_workitems#_a=edit&id=3247094
        //[Fact]
        //[Trait(Category.AcceptanceType, Category.CheckIn)]
        //public void GetAzureResourceGroupLogWithDeploymentCallsListEventsForCorrelationId()
        //{
        //    deploymentsMock.Setup(
        //        f => f.GetAsync(resourceGroupName, deploymentName, new CancellationToken()))
        //                   .Returns(Task.Factory.StartNew(() => new DeploymentGetResult
        //                       {
        //                           Deployment = new Deployment()
        //                                {
        //                                    Name = deploymentName + 1,
        //                                    Properties = new DeploymentProperties()
        //                                        {
        //                                            Mode = DeploymentMode.Incremental,
        //                                            CorrelationId = "123",
        //                                            TemplateLink = new TemplateLink()
        //                                                {
        //                                                    Uri = new Uri("http://microsoft1.com")
        //                                                }
        //                                        }
        //                                }
        //                       }));

        //    eventDataOperationsMock.Setup(f => f.ListEventsForCorrelationIdAsync(It.IsAny<ListEventsForCorrelationIdParameters>(), new CancellationToken()))
        //        .Returns(Task.Factory.StartNew(() => new EventDataListResponse
        //        {
        //            EventDataCollection = new EventDataCollection
        //            {
        //                Value = sampleEvents
        //            }
        //        }));

        //    IEnumerable<PSDeploymentEventData> results = resourcesClient.GetResourceGroupLogs(new GetPSResourceGroupLogParameters
        //    {
        //        Name = resourceGroupName,
        //        DeploymentName = deploymentName
        //    });

        //    Assert.Equal(2, results.Count());
        //    deploymentsMock.Verify(f => f.GetAsync(resourceGroupName, deploymentName, It.IsAny<CancellationToken>()), Times.Once());
        //    eventDataOperationsMock.Verify(f => f.ListEventsForCorrelationIdAsync(It.IsAny<ListEventsForCorrelationIdParameters>(), It.IsAny<CancellationToken>()), Times.Once());
        //}

        // TODO: http://vstfrd:8080/Azure/RD/_workitems#_a=edit&id=3247094
        //[Fact]
        //[Trait(Category.AcceptanceType, Category.CheckIn)]
        //public void GetAzureResourceGroupLogWithLastDeploymentCallsListEventsForCorrelationId()
        //{
        //    deploymentsMock.Setup(
        //        f => f.ListAsync(resourceGroupName, It.IsAny<DeploymentListParameters>(), new CancellationToken()))
        //                   .Returns(Task.Factory.StartNew(() => new DeploymentListResult
        //                   {
        //                       Deployments = new List<Deployment>()
        //                               {
        //                                   new Deployment()
        //                                       {
        //                                           Name = deploymentName + 1,
        //                                           Properties = new DeploymentProperties()
        //                                               {
        //                                                   Mode = DeploymentMode.Incremental,
        //                                                   CorrelationId = "123",
        //                                                   TemplateLink = new TemplateLink()
        //                                                       {
        //                                                           Uri = new Uri("http://microsoft1.com")
        //                                                       }
        //                                               }
        //                                       }
        //                               }
        //                   }));

        //    eventDataOperationsMock.Setup(f => f.ListEventsForCorrelationIdAsync(It.IsAny<ListEventsForCorrelationIdParameters>(), new CancellationToken()))
        //        .Returns(Task.Factory.StartNew(() => new EventDataListResponse
        //        {
        //            EventDataCollection = new EventDataCollection
        //            {
        //                Value = sampleEvents
        //            }
        //        }));

        //    IEnumerable<PSDeploymentEventData> results = resourcesClient.GetResourceGroupLogs(new GetPSResourceGroupLogParameters
        //    {
        //        Name = resourceGroupName
        //    });

        //    Assert.Equal(2, results.Count());
        //    deploymentsMock.Verify(f => f.ListAsync(resourceGroupName, It.IsAny<DeploymentListParameters>(), It.IsAny<CancellationToken>()), Times.Once());
        //    eventDataOperationsMock.Verify(f => f.ListEventsForCorrelationIdAsync(It.IsAny<ListEventsForCorrelationIdParameters>(), It.IsAny<CancellationToken>()), Times.Once());
        //}

        // TODO: http://vstfrd:8080/Azure/RD/_workitems#_a=edit&id=3247094
        //[Fact]
        //[Trait(Category.AcceptanceType, Category.CheckIn)]
        //public void GetAzureResourceGroupLogReturnsAllRequiredFields()
        //{
        //    eventDataOperationsMock.Setup(f => f.ListEventsForResourceGroupAsync(It.IsAny<ListEventsForResourceGroupParameters>(), new CancellationToken()))
        //        .Returns(Task.Factory.StartNew(() => new EventDataListResponse
        //        {
        //            EventDataCollection = new EventDataCollection
        //            {
        //                Value = sampleEvents
        //            }
        //        }));

        //    IEnumerable<PSDeploymentEventData> results = resourcesClient.GetResourceGroupLogs(new GetPSResourceGroupLogParameters
        //    {
        //        Name = "foo",
        //        All = true
        //    });

        //    Assert.Equal(2, results.Count());
        //    var first = results.First();
        //    Assert.NotNull(first.Authorization);
        //    Assert.NotNull(first.ResourceUri);
        //    Assert.NotNull(first.SubscriptionId);
        //    Assert.NotNull(first.Timestamp);
        //    Assert.NotNull(first.OperationName);
        //    Assert.NotNull(first.OperationId);
        //    Assert.NotNull(first.Status);
        //    Assert.NotNull(first.SubStatus);
        //    Assert.NotNull(first.Caller);
        //    Assert.NotNull(first.CorrelationId);
        //    Assert.NotNull(first.HttpRequest);
        //    Assert.NotNull(first.Level);
        //    Assert.NotNull(first.ResourceGroupName);
        //    Assert.NotNull(first.ResourceProvider);
        //    Assert.NotNull(first.EventSource);
        //    Assert.NotNull(first.PropertiesText);
        //}

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void DeletesResourcesGroup()
        {
            resourceGroupMock.Setup(f => f.CheckExistenceWithHttpMessagesAsync(resourceGroupName, null, new CancellationToken()))
                .Returns(Task.Factory.StartNew(() => 
                    new AzureOperationResponse<bool?>() {
                       Body =  (bool?) true
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
            .Returns(Task.Factory.StartNew(() =>  new AzureOperationResponse<DeploymentExtended>()
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

            List<PSResourceGroupDeployment> result = resourcesClient.FilterResourceGroupDeployments(options);

            Assert.Equal(deploymentName, result[0].DeploymentName);
            Assert.Equal(resourceGroupName, result[0].ResourceGroupName);
            Assert.Equal(DeploymentMode.Incremental, result[0].Mode);
            Assert.Equal("123", result[0].CorrelationId);
            Assert.Equal(new Uri("http://microsoft.com").ToString(), result[0].TemplateLink.Uri.ToString());
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void FiltersResourceGroupDeployments()
        {
            FilterResourceGroupDeploymentOptions options = new FilterResourceGroupDeploymentOptions()
            {
                ResourceGroupName = resourceGroupName
            };

            var listResult = new List<DeploymentExtended>()
            {
                new DeploymentExtended()
                {
                    Name = deploymentName + 1,
                    Properties = new DeploymentPropertiesExtended()
                    {
                        Mode = DeploymentMode.Incremental,
                        CorrelationId = "123",
                        TemplateLink = new TemplateLink()
                        {
                            Uri = "http://microsoft1.com/"
                        }
                    }
                }
            };
            var pagableResult = new Page<DeploymentExtended>();
            pagableResult.SetItemValue(listResult);
            System.Reflection.TypeExtensions.GetProperty(pagableResult.GetType(), "NextPageLink").SetValue(pagableResult, "nextLink");

            deploymentsMock.Setup(f => f.ListWithHttpMessagesAsync(
                resourceGroupName,
                null,
                null,
                new CancellationToken()))
                .Returns(Task.Factory.StartNew(() => new AzureOperationResponse<IPage<DeploymentExtended>>()
                {
                    Body = pagableResult
                }));

            var listResult2 = new List<DeploymentExtended>()
            {
                new DeploymentExtended()
                {
                    Name = deploymentName + 2,
                    Properties = new DeploymentPropertiesExtended()
                    {
                        Mode = DeploymentMode.Incremental,
                        CorrelationId = "456",
                        TemplateLink = new TemplateLink()
                        {
                            Uri = "http://microsoft2.com/"
                        }
                    }
                }
            };
            var pagableResult2 = new Page<DeploymentExtended>();
            pagableResult2.SetItemValue(listResult2);

            deploymentsMock.Setup(f => f.ListNextWithHttpMessagesAsync(
                "nextLink",
                null,
                new CancellationToken()))
                .Returns(Task.Factory.StartNew(() => new AzureOperationResponse<IPage<DeploymentExtended>>()
                {
                    Body = pagableResult2
                }));

            List<PSResourceGroupDeployment> result = resourcesClient.FilterResourceGroupDeployments(options);

            Assert.Equal(2, result.Count);
            Assert.Equal(deploymentName + 1, result[0].DeploymentName);
            Assert.Equal("123", result[0].CorrelationId);
            Assert.Equal(resourceGroupName, result[0].ResourceGroupName);
            Assert.Equal(DeploymentMode.Incremental, result[0].Mode);
            Assert.Equal(new Uri("http://microsoft1.com").ToString(), result[0].TemplateLink.Uri.ToString());

            Assert.Equal(deploymentName + 2, result[1].DeploymentName);
            Assert.Equal(resourceGroupName, result[1].ResourceGroupName);
            Assert.Equal("456", result[1].CorrelationId);
            Assert.Equal(DeploymentMode.Incremental, result[1].Mode);
            Assert.Equal(new Uri("http://microsoft2.com").ToString(), result[1].TemplateLink.Uri.ToString());
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

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void GetsLocations()
        {
            var listResult = new List<Provider>()
            {
                new Provider()
                {
                    NamespaceProperty = "Microsoft.Web",
                    RegistrationState = "Registered",
                    ResourceTypes = new List<ProviderResourceType>()
                    {
                        new ProviderResourceType()
                        {
                            Locations = new List<string>() {"West US", "East US"},
                            ResourceType = "database"
                        },
                        new ProviderResourceType()
                        {
                            Locations = new List<string>() {"West US", "South Central US"},
                            ResourceType = "servers"
                        }
                    }
                },
                new Provider()
                {
                    NamespaceProperty = "Microsoft.HDInsight",
                    RegistrationState = "UnRegistered",
                    ResourceTypes = new List<ProviderResourceType>()
                    {
                        new ProviderResourceType()
                        {
                            Locations = new List<string>() {"West US", "East US"},
                            ResourceType = "hadoop"
                        },
                        new ProviderResourceType()
                        {
                            Locations = new List<string>() {"West US", "South Central US"},
                            ResourceType = "websites"
                        }
                    }
                }
            };
            var pagableResult = new Page<Provider>();
            System.Reflection.TypeExtensions.GetProperty(pagableResult.GetType(), "Items").SetValue(pagableResult, listResult);

            providersMock.Setup(f => f.ListAsync(null, new CancellationToken()))
                .Returns(Task.Factory.StartNew(() => (IPage<Provider>)pagableResult));
            List<PSResourceProviderLocationInfo> resourceTypes = resourcesClient.GetLocations(
                ResourcesClient.ResourceGroupTypeName,
                "Microsoft.HDInsight");

            Assert.Equal(3, resourceTypes.Count);
            Assert.Equal(ResourcesClient.ResourceGroupTypeName, resourceTypes[0].Name);
            Assert.Equal(ResourcesClient.KnownLocations.Count, resourceTypes[0].Locations.Count);
            Assert.Equal("East Asia", resourceTypes[0].Locations[0]);
            Assert.Equal("Microsoft.HDInsight/hadoop", resourceTypes[1].Name);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void IgnoresResourceTypesWithEmptyLocations()
        {
            var listResult = new List<Provider>()
            {
                new Provider()
                {
                    NamespaceProperty = "Microsoft.Web",
                    RegistrationState = "Registered",
                    ResourceTypes = new List<ProviderResourceType>()
                        {
                            new ProviderResourceType()
                            {
                                ResourceType = "database"
                            },
                            new ProviderResourceType()
                            {
                                Locations = new List<string>(),
                                ResourceType = "servers"
                            }
                        }
                },
                    new Provider()
                    {
                        NamespaceProperty = "Microsoft.HDInsight",
                        RegistrationState = "UnRegistered",
                        ResourceTypes = new List<ProviderResourceType>()
                        {
                            new ProviderResourceType()
                            {
                                Locations = new List<string>() {"West US", "East US"},
                                ResourceType = "hadoop"
                            },
                            new ProviderResourceType()
                            {
                                Locations = new List<string>() {"West US", "South Central US"},
                                ResourceType = "websites"
                            }
                        }
                    }
            };
            var pagableResult = new Page<Provider>();
            System.Reflection.TypeExtensions.GetProperty(pagableResult.GetType(), "Items").SetValue(pagableResult, listResult);

            providersMock.Setup(f => f.ListAsync(null, new CancellationToken()))
                .Returns(Task.Factory.StartNew(() => (IPage<Provider>)pagableResult ));
            List<PSResourceProviderLocationInfo> resourceTypes = resourcesClient.GetLocations(
                ResourcesClient.ResourceGroupTypeName,
                "Microsoft.Web");

            Assert.Equal(1, resourceTypes.Count);
            Assert.Equal(ResourcesClient.ResourceGroupTypeName, resourceTypes[0].Name);
            Assert.Equal(ResourcesClient.KnownLocations.Count, resourceTypes[0].Locations.Count);
            Assert.Equal("East Asia", resourceTypes[0].Locations[0]);
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
