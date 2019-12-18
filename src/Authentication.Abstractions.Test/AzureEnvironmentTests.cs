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

using Microsoft.Azure.Commands.Common.Authentication;
using Microsoft.Azure.Commands.Common.Authentication.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Authentication.Abstractions.Test
{
    public class AzureEnvironmentTests
    {
        private const string ArmMetadataEnvVariable = "ARM_CLOUD_METADATA_URL";
        readonly IDictionary<string, AzureEnvironment> hardCodedEnvironments = AzureEnvironment.PublicEnvironments;

        [Fact]
        public void TestArmAndNonArmBasedCloudMetadataInit()
        {
            Environment.SetEnvironmentVariable(ArmMetadataEnvVariable, @"TestData\GoodArmResponse.json");
            AzureSessionInitializer.InitializeAzureSession();
            AzureSession.Instance.RegisterComponent(HttpClientOperationsFactory.Name, () => TestOperationsFactory.Create(), true);
            var armEnvironments = AzureEnvironment.InitializeBuiltInEnvironments();

            var unequalItemsDict = armEnvironments
                .Where(keyValuePair => !hardCodedEnvironments[keyValuePair.Key].Equals(keyValuePair.Value))
                .ToDictionary(entry => entry.Key, entry => entry.Value);

            if (unequalItemsDict.Any())
            {
                Assert.True(false, "Hard coded and ARM based cloud metadata initializations have different values.");
            }
        }

        [Fact]
        public void TestFallbackWhenArmCloudMetadataInitFails()
        {
            Environment.SetEnvironmentVariable(ArmMetadataEnvVariable, @"TestData\BadArmResponse.json");
            AzureSessionInitializer.InitializeAzureSession();
            AzureSession.Instance.RegisterComponent(HttpClientOperationsFactory.Name, () => TestOperationsFactory.Create(), true);
            var armEnvironments = AzureEnvironment.InitializeBuiltInEnvironments();

            var unequalItemsDict = armEnvironments
                .Where(keyValuePair => !hardCodedEnvironments[keyValuePair.Key].Equals(keyValuePair.Value))
                .ToDictionary(entry => entry.Key, entry => entry.Value);

            if (unequalItemsDict.Any())
            {
                Assert.True(false, "Hard coded and ARM based cloud metadata initializations have different values.");
            }
        }
    }
}
