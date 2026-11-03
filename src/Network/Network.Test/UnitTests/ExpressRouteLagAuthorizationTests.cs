// ----------------------------------------------------------------------------------
//
// Copyright Microsoft Corporation
// Licensed under the Apache License, Version 2.0 (the "License");
// ----------------------------------------------------------------------------------

using Microsoft.Azure.Commands.Network;
using Microsoft.Azure.Commands.Network.Models;
using Microsoft.Azure.Commands.Common.Authentication;
using Microsoft.Azure.Management.Network;
using Microsoft.Azure.Management.Network.Models;
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using Moq;
using System.Collections.Generic;
using System.Management.Automation;
using Xunit;

namespace Commands.Network.Test.UnitTests
{
    public class ExpressRouteLagAuthorizationTests
    {
        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void AuthorizationPropertiesAreFlattenedThroughSdkMapping()
        {
            var sdkAuthorization = new ExpressRouteLagAuthorization(
                id: "/subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/test-rg/providers/Microsoft.Network/expressRouteLags/test-lag/authorizations/test-auth",
                name: "test-auth",
                type: "Microsoft.Network/expressRouteLags/authorizations",
                properties: new ExpressRouteLagAuthorizationPropertiesFormat(
                    authorizationUseStatus: "Available",
                    circuitResourceUri: null,
                    provisioningState: "Succeeded"),
                etag: "etag");

            var psAuthorization = NetworkResourceManagerProfile.Mapper.Map<PSExpressRouteLagAuthorization>(sdkAuthorization);

            Assert.Equal(sdkAuthorization.Id, psAuthorization.Id);
            Assert.Equal("test-auth", psAuthorization.Name);
            Assert.Equal("Available", psAuthorization.AuthorizationUseStatus);
            Assert.Equal("Succeeded", psAuthorization.ProvisioningState);
            Assert.Null(psAuthorization.CircuitResourceUri);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void LagIncludesMappedAuthorizations()
        {
            var sdkLag = new ExpressRouteLag
            {
                Properties = new ExpressRouteLagPropertiesFormat
                {
                    Authorizations = new List<ExpressRouteLagAuthorization>
                    {
                        new ExpressRouteLagAuthorization(
                            name: "test-auth",
                            properties: new ExpressRouteLagAuthorizationPropertiesFormat(
                                authorizationUseStatus: "InUse",
                                circuitResourceUri: "/subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/test-rg/providers/Microsoft.Network/expressRouteCircuits/test-circuit",
                                provisioningState: "Succeeded"))
                    }
                }
            };

            var psLag = NetworkResourceManagerProfile.Mapper.Map<PSExpressRouteLag>(sdkLag);

            var authorization = Assert.Single(psLag.Authorizations);
            Assert.Equal("test-auth", authorization.Name);
            Assert.Equal("InUse", authorization.AuthorizationUseStatus);
            Assert.Equal("Succeeded", authorization.ProvisioningState);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void AddAuthorizationHonorsWhatIf()
        {
            AzureSessionInitializer.InitializeAzureSession();
            var operations = new Mock<IExpressRouteLagAuthorizationsOperations>();
            var managementClient = new Mock<INetworkManagementClient>();
            var commandRuntime = new Mock<ICommandRuntime>();
            managementClient.SetupGet(client => client.ExpressRouteLagAuthorizations).Returns(operations.Object);
            commandRuntime
                .Setup(runtime => runtime.ShouldProcess(It.IsAny<string>(), It.IsAny<string>()))
                .Returns(false);
            var command = new AddAzureExpressRouteLagAuthorizationCommand
            {
                CommandRuntime = commandRuntime.Object,
                NetworkClient = new NetworkClient(managementClient.Object),
                Name = "test-auth",
                ExpressRouteLagObject = new PSExpressRouteLag
                {
                    Name = "test-lag",
                    ResourceGroupName = "test-rg"
                }
            };

            command.Execute();

            commandRuntime.Verify(
                runtime => runtime.ShouldProcess("test-auth", It.Is<string>(action => !string.IsNullOrEmpty(action))),
                Times.Once);
            operations.VerifyNoOtherCalls();
        }
    }
}
