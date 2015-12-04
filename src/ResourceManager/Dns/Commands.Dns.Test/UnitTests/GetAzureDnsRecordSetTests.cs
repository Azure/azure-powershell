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

namespace Microsoft.Azure.Commands.Dns.Test.UnitTests
{
    using System.Management.Automation;
    using Microsoft.WindowsAzure.Commands.ScenarioTest;
    using WindowsAzure.Commands.Test.Utilities.Common;
    using Xunit;

    public class GetAzureDnsRecordSetTests : RMTestBase
    {
        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void GetAzureDnsRecordSetThrowsExceptionWhenUsingNameAndEndsWith()
        {
            var cmdlet = new GetAzureDnsRecordSet
            {
                Name = "record",
                ZoneName = "zone.com",
                ResourceGroupName = "resourceGroup",
                Zone = new DnsZone
                {
                    Name = "zone.com",
                    ResourceGroupName = "resourceGroup"
                },
                RecordType = "A",
                EndsWith = ".com."
            };

            Assert.Throws<PSArgumentException>(() => cmdlet.ExecuteCmdlet());
        }
    }
}
