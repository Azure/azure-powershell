// ----------------------------------------------------------------------------------
//
// Copyright Microsoft Corporation
// Licensed under the Apache License, Version 2.0 (the "License");
// ----------------------------------------------------------------------------------

using Microsoft.Azure.Commands.Network;
using Microsoft.Azure.Commands.Network.Models;
using Microsoft.Azure.Management.Network.Models;
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using System.Collections.Generic;
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
    }
}
