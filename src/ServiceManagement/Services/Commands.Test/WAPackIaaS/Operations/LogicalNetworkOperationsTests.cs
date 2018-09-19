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
using System.Collections.Generic;
using System.Linq;
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using Xunit;
using Microsoft.WindowsAzure.Commands.Test.WAPackIaaS.Mocks;
using Microsoft.WindowsAzure.Commands.Utilities.WAPackIaaS;
using Microsoft.WindowsAzure.Commands.Utilities.WAPackIaaS.DataContract;
using Microsoft.WindowsAzure.Commands.Utilities.WAPackIaaS.Operations;
using Microsoft.WindowsAzure.Commands.Utilities.WAPackIaaS.WebClient;

namespace Microsoft.WindowsAzure.Commands.Test.WAPackIaaS.Operations
{
    
    public class LogicalNetworkOperationsTests
    {
        private const string logicalNetworkName = "LogicalNetwork01";

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait("Type", "WAPackIaaS-All")]
        [Trait("Type", "WAPackIaaS-Unit")]
        public void ShouldReturnOneLogicalNetwork()
        {
            var mockChannel = new MockRequestChannel();
            mockChannel.AddReturnObject(new LogicalNetwork { ID = Guid.Empty, CloudId = Guid.Empty, Name = logicalNetworkName });

            var logicalNetworkOperations = new LogicalNetworkOperations(new WebClientFactory(new Subscription(), mockChannel));
            Assert.Equal(1, logicalNetworkOperations.Read().Count);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait("Type", "WAPackIaaS-All")]
        [Trait("Type", "WAPackIaaS-Unit")]
        public void ShouldReturnOneLogicalNetworkByName()
        {
            var mockChannel = new MockRequestChannel();
            mockChannel.AddReturnObject(new LogicalNetwork { ID = Guid.Empty, CloudId = Guid.Empty, Name = logicalNetworkName });

            var logicalNetworkOperations = new LogicalNetworkOperations(new WebClientFactory(new Subscription(), mockChannel));
            var logicalNetworkList = logicalNetworkOperations.Read(logicalNetworkName);

            Assert.Equal(1, logicalNetworkList.Count);
            Assert.Equal(logicalNetworkName, logicalNetworkList.First().Name);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait("Type", "WAPackIaaS-All")]
        [Trait("Type", "WAPackIaaS-Unit")]
        public void ShouldReturnMultipleLogicalNetworks()
        {
            var mockChannel = new MockRequestChannel();
            var logicalNetworks = new List<object>
            {
                new LogicalNetwork { ID = Guid.Empty, CloudId = Guid.Empty, Name = logicalNetworkName },
                new LogicalNetwork { ID = Guid.Empty, CloudId = Guid.Empty, Name = logicalNetworkName }
            };
            mockChannel.AddReturnObject(logicalNetworks);

            var logicalNetworkOperations = new LogicalNetworkOperations(new WebClientFactory(new Subscription(), mockChannel));
            var logicalNetworkList = logicalNetworkOperations.Read();

            Assert.Equal(2, logicalNetworkList.Count);
            Assert.True(logicalNetworkList.All(logicalNetwork => logicalNetwork.Name == logicalNetworkName));
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait("Type", "WAPackIaaS-All")]
        [Trait("Type", "WAPackIaaS-Unit")]
        [Trait("Type", "WAPackIaaS-Negative")]
        public void ShouldReturnEmptyOnNoResult()
        {
            var logicalNetworkOperations = new LogicalNetworkOperations(new WebClientFactory(new Subscription(), MockRequestChannel.Create()));
            Assert.False(logicalNetworkOperations.Read().Any());
        }
    }
}
