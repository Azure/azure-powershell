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
using System;
using Xunit;

namespace Authentication.Abstractions.Test
{
    public class AzureEnvironmentTests
    {
        private const string ArmMetadataEnvVariable = "ARM_CLOUD_METADATA_URL";

        [Fact]
        public void TestArmAndNonArmBasedCloudMetadataInit()
        {
            Environment.SetEnvironmentVariable(ArmMetadataEnvVariable, @"TestData\GoodArmResponse.json");
            var armEnvironments = AzureEnvironment.InitializeBuiltInEnvironments(null, httpOperations: TestOperationsFactory.Create().GetHttpOperations());

            // Check all discovered environments are loaded.
            Assert.Equal(4, armEnvironments.Count);
            foreach (var env in armEnvironments.Values)
            {
                Assert.Equal(AzureEnvironment.TypeDiscovered, env.Type);
            }
        }

        [Fact]
        public void TestArmCloudMetadata20190501Init()
        {
            Environment.SetEnvironmentVariable(ArmMetadataEnvVariable, @"TestData\ArmResponse2019-05-01.json");
            var armEnvironments = AzureEnvironment.InitializeBuiltInEnvironments(null, httpOperations: TestOperationsFactory.Create().GetHttpOperations());

            // Check all discovered environments are loaded.
            Assert.Equal(4, armEnvironments.Count);
            foreach (var env in armEnvironments.Values)
            {
                Assert.Equal(AzureEnvironment.TypeDiscovered, env.Type);
                Assert.EndsWith("/", env.ServiceManagementUrl);
                Assert.StartsWith(".", env.SqlDatabaseDnsSuffix);
            }
        }

        [Fact]
        public void TestFallbackWhenArmCloudMetadataInitFails()
        {
            Environment.SetEnvironmentVariable(ArmMetadataEnvVariable, @"TestData\BadArmResponse.json");
            var armEnvironments = AzureEnvironment.InitializeBuiltInEnvironments(null, httpOperations: TestOperationsFactory.Create().GetHttpOperations());

            // Check all built-in environments are loaded because discover is failed
            Assert.Equal(4, armEnvironments.Count);
            foreach (var env in armEnvironments.Values)
            {
                Assert.Equal(AzureEnvironment.TypeBuiltIn, env.Type);
            }
        }

        [Fact]
        public void TestDisableArmCloudMetadataInit()
        {
            Environment.SetEnvironmentVariable(ArmMetadataEnvVariable, "disabled");
            var armEnvironments = AzureEnvironment.InitializeBuiltInEnvironments(null, httpOperations: TestOperationsFactory.Create().GetHttpOperations());

            // Check all built-in environments are loaded because discover is disabled
            Assert.Equal(4, armEnvironments.Count);
            foreach (var env in armEnvironments.Values)
            {
                Assert.Equal(AzureEnvironment.TypeBuiltIn, env.Type);
            }
        }
    }
}
