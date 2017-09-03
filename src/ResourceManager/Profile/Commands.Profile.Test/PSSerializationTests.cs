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
using Microsoft.Azure.Commands.Common.Authentication.Abstractions;
using Microsoft.Azure.Commands.Profile.Models;
using Microsoft.Azure.Commands.ResourceManager.Common;
using Microsoft.Azure.ServiceManagemenet.Common.Models;
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using System;
using System.Globalization;
using System.Management.Automation;
using Xunit;
using Xunit.Abstractions;

namespace Microsoft.Azure.Commands.Profile.Test
{
    public class PSSerializationTests
    {
        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void CanConvertProfileToContextContainer()
        {
            IAzureContext context = new AzureContext(new AzureSubscription(), new AzureAccount(), new AzureEnvironment(), new AzureTenant(), new byte[0]);
            var testContext = new PSAzureContext(context);
            var testEnvironment = new PSAzureEnvironment(AzureEnvironment.PublicEnvironments["AzureCloud"]);
            var testProfile = new PSAzureProfile();
            testProfile.Context = testContext;
            testProfile.Environments.Add("ExtraEnvironment", testEnvironment);
            string content = PSSerializer.Serialize(testProfile, 10);
            var reconstituted = PSSerializer.Deserialize(content);
            var converter = new AzureContextConverter();
            Assert.True(converter.CanConvertFrom(reconstituted, typeof(IAzureContextContainer)));
            var container = converter.ConvertFrom(reconstituted, typeof(IAzureContextContainer), CultureInfo.InvariantCulture, true);
            Assert.True(container is IAzureContextContainer);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void CanConvertContextToContextContainer()
        {
            IAzureContext context = new AzureContext(new AzureSubscription(), new AzureAccount(), new AzureEnvironment(), new AzureTenant(), new byte[0]);
            var testContext = new PSAzureContext(context);
            string content = PSSerializer.Serialize(testContext, 10);
            var reconstituted = PSSerializer.Deserialize(content);
            var converter = new AzureContextConverter();
            Assert.True(converter.CanConvertFrom(reconstituted, typeof(IAzureContextContainer)));
            var container = converter.ConvertFrom(reconstituted, typeof(IAzureContextContainer), CultureInfo.InvariantCulture, true);
            Assert.True(container is IAzureContextContainer);
        }

    }
}
