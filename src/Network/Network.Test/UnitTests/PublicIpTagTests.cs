// ----------------------------------------------------------------------------------
//
// Copyright Microsoft Corporation
// Licensed under the Apache License, Version 2.0 (the "License");
// ----------------------------------------------------------------------------------

using Microsoft.Azure.Commands.Network;
using Microsoft.Azure.Commands.Network.Models;
using Microsoft.Azure.Management.Network.Models;
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using Xunit;

namespace Commands.Network.Test.UnitTests
{
    public class PublicIpTagTests
    {
        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void FirstPartyServiceTagIdIsPreservedThroughSdkMapping()
        {
            const string serviceTagId =
                "/subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/test-rg/providers/Microsoft.Network/firstPartyServiceTags/service-tag";
            var command = new NewAzurePublicIpTagCommand
            {
                IpTagType = "FirstPartyUsage",
                Tag = "/Sql",
                FirstPartyServiceTagId = serviceTagId
            };

            var publicIpTag = command.CreatePublicIpTag();

            Assert.Equal(serviceTagId, publicIpTag.FirstPartyServiceTagId);

            var sdkIpTag = NetworkResourceManagerProfile.Mapper.Map<IpTag>(publicIpTag);
            Assert.Equal(serviceTagId, sdkIpTag.FirstPartyServiceTagId);

            var mappedPublicIpTag = NetworkResourceManagerProfile.Mapper.Map<PSPublicIpTag>(sdkIpTag);
            Assert.Equal(serviceTagId, mappedPublicIpTag.FirstPartyServiceTagId);
        }
    }
}
