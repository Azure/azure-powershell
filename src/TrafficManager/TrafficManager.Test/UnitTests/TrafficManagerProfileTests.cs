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

namespace Microsoft.Azure.Commands.TrafficManager.Test.UnitTests
{
    using Microsoft.Azure.Commands.TrafficManager.Models;
    using Microsoft.Azure.Commands.TrafficManager.Utilities;
    using Microsoft.WindowsAzure.Commands.ScenarioTest;
    using ServiceManagement.Common.Models;
    using WindowsAzure.Commands.Test.Utilities.Common;
    using Xunit;
    using Xunit.Abstractions;

    public class TrafficManagerProfileTests : RMTestBase
    {
        public TrafficManagerProfileTests(ITestOutputHelper output)
        {
            XunitTracingInterceptor.AddToContext(new XunitTracingInterceptor(output));
        }

        /// <summary>
        /// Regression test for a bug where RecordType was passed as a positional constructor
        /// argument to the generated SDK Profile type, causing it to be placed in the "location"
        /// slot instead of RecordType's actual position. This resulted in ARM rejecting requests
        /// with errors like: "The provided location 'A' is not permitted for subscription."
        /// ToSDKProfile() must always send location = "global" and recordType = the configured value,
        /// regardless of what RecordType is set to (A, AAAA, CNAME, etc.).
        /// </summary>
        [Theory]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [InlineData("A")]
        [InlineData("AAAA")]
        [InlineData("CNAME")]
        [InlineData(null)]
        public void ToSDKProfile_SetsGlobalLocation_RegardlessOfRecordType(string recordType)
        {
            var profile = new TrafficManagerProfile
            {
                Id = "/subscriptions/sub/resourceGroups/rg/providers/Microsoft.Network/trafficManagerProfiles/profile1",
                Name = "profile1",
                RecordType = recordType,
                ProfileStatus = "Enabled",
                TrafficRoutingMethod = "Performance",
                RelativeDnsName = "profile1-dns",
                Ttl = 30,
                MonitorProtocol = "HTTPS",
                MonitorPort = 443,
                MonitorPath = "/"
            };

            var sdkProfile = profile.ToSDKProfile();

            Assert.Equal(TrafficManagerClient.ProfileResourceLocation, sdkProfile.Location);
            Assert.Equal("global", sdkProfile.Location);
            Assert.Equal(recordType, sdkProfile.RecordType);
            Assert.Equal("Enabled", sdkProfile.ProfileStatus);
        }
    }
}
