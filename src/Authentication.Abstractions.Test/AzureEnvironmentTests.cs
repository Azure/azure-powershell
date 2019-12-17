using System;
using System.Collections;
using System.Collections.Generic;
using Microsoft.Azure.Commands.Common.Authentication;
using Microsoft.Azure.Commands.Common.Authentication.Abstractions;
using Xunit;

namespace Authentication.Abstractions.Test
{
    public class AzureEnvironmentTests
    {
        private const string ArmMetadataEnvVariable = "ARM_CLOUD_METADATA_URL";

        [Fact]
        public void TestHardCodedAndArmBasedCloudMetadata()
        {
            Environment.SetEnvironmentVariable(ArmMetadataEnvVariable, "Some ARM URL");
            AzureSessionInitializer.InitializeAzureSession();
            AzureSession.Instance.RegisterComponent(HttpClientOperationsFactory.Name, () => TestOperationsFactory.Create(), true);
            var armEnvironments = AzureEnvironment.InitializeBuiltInEnvironments();
        }
    }
}
