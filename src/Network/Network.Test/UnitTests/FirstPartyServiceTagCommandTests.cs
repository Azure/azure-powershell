// ----------------------------------------------------------------------------------
//
// Copyright Microsoft Corporation
// Licensed under the Apache License, Version 2.0 (the "License");
// ----------------------------------------------------------------------------------

using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Azure.Commands.Common.Authentication;
using Microsoft.Azure.Commands.Network;
using Microsoft.Azure.Commands.Network.Models;
using Microsoft.Azure.Management.Network;
using Microsoft.Azure.Management.Network.Models;
using Microsoft.Rest.Azure;
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using Moq;
using Newtonsoft.Json;
using Xunit;

namespace Commands.Network.Test.UnitTests
{
    public class FirstPartyServiceTagCommandTests
    {
        private const string ResourceGroupName = "test-rg";
        private const string ResourceName = "service-tag";

        private readonly Mock<IFirstPartyServiceTagsOperations> operations;
        private readonly Mock<INetworkManagementClient> managementClient;
        private readonly Mock<ICommandRuntime> commandRuntime;
        private readonly List<object> output;

        public FirstPartyServiceTagCommandTests()
        {
            AzureSessionInitializer.InitializeAzureSession();
            operations = new Mock<IFirstPartyServiceTagsOperations>();
            managementClient = new Mock<INetworkManagementClient>();
            commandRuntime = new Mock<ICommandRuntime>();
            output = new List<object>();

            managementClient.SetupGet(client => client.FirstPartyServiceTags).Returns(operations.Object);
            commandRuntime.Setup(runtime => runtime.ShouldProcess(It.IsAny<string>())).Returns(true);
            commandRuntime.Setup(runtime => runtime.ShouldProcess(It.IsAny<string>(), It.IsAny<string>())).Returns(true);
            commandRuntime
                .Setup(runtime => runtime.ShouldProcess(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>()))
                .Returns(true);
            commandRuntime
                .Setup(runtime => runtime.WriteObject(It.IsAny<object>()))
                .Callback<object>(item => output.Add(item));
            commandRuntime
                .Setup(runtime => runtime.WriteObject(It.IsAny<object>(), It.IsAny<bool>()))
                .Callback<object, bool>(AddOutput);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void NewCreatesAndReturnsFirstPartyServiceTag()
        {
            FirstPartyServiceTag request = null;
            var serviceTag = CreateSdkServiceTag(ResourceName, "initial-value");
            SetupGet(serviceTag);
            operations
                .Setup(client => client.CreateOrUpdateWithHttpMessagesAsync(
                    ResourceGroupName,
                    ResourceName,
                    It.IsAny<FirstPartyServiceTag>(),
                    null,
                    It.IsAny<CancellationToken>()))
                .Callback<string, string, FirstPartyServiceTag, Dictionary<string, List<string>>, CancellationToken>(
                    (_, _, parameters, _, _) => request = parameters)
                .ReturnsAsync(CreateResponse(serviceTag));

            var command = Configure(new NewFirstPartyServiceTagCommand
            {
                ResourceGroupName = ResourceGroupName,
                Name = ResourceName,
                Location = "eastus",
                Value = "initial-value",
                Tag = new Hashtable { ["environment"] = "test" },
                Force = true
            });

            command.Execute();

            Assert.Equal("initial-value", request.Properties.Value);
            Assert.Equal("test", request.Tags["environment"]);
            var result = Assert.IsType<PSFirstPartyServiceTag>(Assert.Single(output));
            Assert.Equal(ResourceName, result.Name);
            Assert.Equal("initial-value", result.Value);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void GetReturnsNamedResource()
        {
            SetupGet(CreateSdkServiceTag(ResourceName, "value"));
            var command = Configure(new GetFirstPartyServiceTagCommand
            {
                ResourceGroupName = ResourceGroupName,
                Name = ResourceName
            });

            command.Execute();

            operations.Verify(client => client.GetWithHttpMessagesAsync(
                ResourceGroupName,
                ResourceName,
                null,
                It.IsAny<CancellationToken>()), Times.Once);
            Assert.IsType<PSFirstPartyServiceTag>(Assert.Single(output));
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void GetSupportsWildcardAndPaging()
        {
            var firstPage = CreatePage(
                new[]
                {
                    CreateSdkServiceTag("service-one", "one"),
                    CreateSdkServiceTag("other", "other")
                },
                "next-page");
            var secondPage = CreatePage(
                new[]
                {
                    CreateSdkServiceTag("service-two", "two")
                });

            operations
                .Setup(client => client.ListAllWithHttpMessagesAsync(null, It.IsAny<CancellationToken>()))
                .ReturnsAsync(new AzureOperationResponse<IPage<FirstPartyServiceTag>> { Body = firstPage });
            operations
                .Setup(client => client.ListAllNextWithHttpMessagesAsync(
                    "next-page",
                    null,
                    It.IsAny<CancellationToken>()))
                .ReturnsAsync(new AzureOperationResponse<IPage<FirstPartyServiceTag>> { Body = secondPage });

            var command = Configure(new GetFirstPartyServiceTagCommand
            {
                Name = "service-*"
            });

            command.Execute();

            Assert.Equal(
                new[] { "service-one", "service-two" },
                output.Cast<PSFirstPartyServiceTag>().Select(item => item.Name).OrderBy(name => name));
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void SetAcceptsPipelineObjectAndUpdatesResource()
        {
            FirstPartyServiceTag request = null;
            SetupGet(CreateSdkServiceTag(ResourceName, "updated-value"));
            operations
                .Setup(client => client.CreateOrUpdateWithHttpMessagesAsync(
                    ResourceGroupName,
                    ResourceName,
                    It.IsAny<FirstPartyServiceTag>(),
                    null,
                    It.IsAny<CancellationToken>()))
                .Callback<string, string, FirstPartyServiceTag, Dictionary<string, List<string>>, CancellationToken>(
                    (_, _, parameters, _, _) => request = parameters)
                .ReturnsAsync(CreateResponse(CreateSdkServiceTag(ResourceName, "updated-value")));

            var command = Configure(new SetFirstPartyServiceTagCommand
            {
                FirstPartyServiceTag = new PSFirstPartyServiceTag
                {
                    ResourceGroupName = ResourceGroupName,
                    Name = ResourceName,
                    Location = "eastus",
                    Value = "updated-value"
                }
            });

            command.Execute();

            Assert.Equal("updated-value", request.Properties.Value);
            Assert.True(
                typeof(SetFirstPartyServiceTagCommand)
                    .GetProperty(nameof(SetFirstPartyServiceTagCommand.FirstPartyServiceTag))
                    .GetCustomAttributes(typeof(ParameterAttribute), true)
                    .Cast<ParameterAttribute>()
                    .Single()
                    .ValueFromPipeline);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void RemoveSupportsPassThru()
        {
            operations
                .Setup(client => client.DeleteWithHttpMessagesAsync(
                    ResourceGroupName,
                    ResourceName,
                    null,
                    It.IsAny<CancellationToken>()))
                .ReturnsAsync(new AzureOperationResponse
                {
                    Response = new HttpResponseMessage()
                });

            var command = Configure(new RemoveFirstPartyServiceTagCommand
            {
                ResourceGroupName = ResourceGroupName,
                Name = ResourceName,
                Force = true,
                PassThru = true
            });

            command.Execute();

            operations.Verify(client => client.DeleteWithHttpMessagesAsync(
                ResourceGroupName,
                ResourceName,
                null,
                It.IsAny<CancellationToken>()), Times.Once);
            Assert.True(Assert.IsType<bool>(Assert.Single(output)));
        }

        private T Configure<T>(T command)
            where T : FirstPartyServiceTagBaseCmdlet
        {
            command.CommandRuntime = commandRuntime.Object;
            command.NetworkClient = new NetworkClient(managementClient.Object);
            return command;
        }

        private void SetupGet(FirstPartyServiceTag serviceTag)
        {
            operations
                .Setup(client => client.GetWithHttpMessagesAsync(
                    It.IsAny<string>(),
                    It.IsAny<string>(),
                    null,
                    It.IsAny<CancellationToken>()))
                .ReturnsAsync(CreateResponse(serviceTag));
        }

        private static FirstPartyServiceTag CreateSdkServiceTag(string name, string value)
        {
            return new FirstPartyServiceTag(
                id: $"/subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/{ResourceGroupName}/providers/Microsoft.Network/firstPartyServiceTags/{name}",
                name: name,
                type: "Microsoft.Network/firstPartyServiceTags",
                location: "eastus",
                properties: new FirstPartyServiceTagPropertiesFormat(value));
        }

        private static AzureOperationResponse<FirstPartyServiceTag> CreateResponse(FirstPartyServiceTag serviceTag)
        {
            return new AzureOperationResponse<FirstPartyServiceTag> { Body = serviceTag };
        }

        private static IPage<FirstPartyServiceTag> CreatePage(
            IEnumerable<FirstPartyServiceTag> items,
            string nextPageLink = null)
        {
            return JsonConvert.DeserializeObject<Page<FirstPartyServiceTag>>(
                JsonConvert.SerializeObject(new { value = items, nextLink = nextPageLink }));
        }

        private void AddOutput(object value, bool enumerateCollection)
        {
            if (enumerateCollection && value is IEnumerable collection)
            {
                foreach (var item in collection)
                {
                    output.Add(item);
                }

                return;
            }

            output.Add(value);
        }
    }
}
