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

using Microsoft.Azure.Batch;
using Microsoft.Azure.Batch.Protocol;
using Microsoft.Azure.Batch.Protocol.Models;
using Microsoft.Azure.Commands.Batch.Models;
using Microsoft.Rest.Azure;
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using Moq;
using System;
using System.Collections.Generic;
using System.Management.Automation;
using Xunit;
using BatchClient = Microsoft.Azure.Commands.Batch.Models.BatchClient;

namespace Microsoft.Azure.Commands.Batch.Test.Pools
{
    public class SetBatchPoolCommandTests
    {
        private SetBatchPoolCommand cmdlet;
        private Mock<BatchClient> batchClientMock;
        private Mock<ICommandRuntime> commandRuntimeMock;

        public SetBatchPoolCommandTests(Xunit.Abstractions.ITestOutputHelper output)
        {
            ServiceManagemenet.Common.Models.XunitTracingInterceptor.AddToContext(new ServiceManagemenet.Common.Models.XunitTracingInterceptor(output));
            batchClientMock = new Mock<BatchClient>();
            commandRuntimeMock = new Mock<ICommandRuntime>();
            cmdlet = new SetBatchPoolCommand()
            {
                CommandRuntime = commandRuntimeMock.Object,
                BatchClient = batchClientMock.Object,
            };
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void SetBatchPoolParametersTest()
        {
            // Setup cmdlet without the required parameters
            BatchAccountContext context = BatchTestHelpers.CreateBatchContextWithKeys();
            cmdlet.BatchContext = context;

            Assert.Throws<ArgumentNullException>(() => cmdlet.ExecuteCmdlet());

            cmdlet.Pool = new PSCloudPool(BatchTestHelpers.CreateFakeBoundPool(context));

            RequestInterceptor interceptor = BatchTestHelpers.CreateFakeServiceResponseInterceptor<
                PoolUpdatePropertiesParameter,
                PoolUpdatePropertiesOptions,
                AzureOperationHeaderResponse<PoolUpdatePropertiesHeaders>>();

            cmdlet.AdditionalBehaviors = new BatchClientBehavior[] { interceptor };

            // Verify that no exceptions occur
            cmdlet.ExecuteCmdlet();
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void SetBatchPoolParametersGetPassedToRequestTest()
        {
            BatchAccountContext context = BatchTestHelpers.CreateBatchContextWithKeys();
            cmdlet.BatchContext = context;

            cmdlet.Pool = new PSCloudPool(BatchTestHelpers.CreateFakeBoundPool(context));

            // Update the pool
            cmdlet.Pool.StartTask = new PSStartTask("cmd /c echo start task");
            cmdlet.Pool.CertificateReferences = new List<PSCertificateReference>()
            {
                new PSCertificateReference()
                {
                    StoreLocation = Azure.Batch.Common.CertStoreLocation.LocalMachine,
                    Thumbprint = "thumbprint",
                    ThumbprintAlgorithm = "sha1",
                    StoreName = "My",
                    Visibility = Azure.Batch.Common.CertificateVisibility.StartTask
                }
            };
            cmdlet.Pool.ApplicationPackageReferences = new List<PSApplicationPackageReference>()
            {
                new PSApplicationPackageReference()
                {
                    ApplicationId = "myApp",
                    Version = "1.0"
                }
            };
            cmdlet.Pool.Metadata = new List<PSMetadataItem>()
            {
                new PSMetadataItem("meta1", "value1")
            };

            PoolUpdatePropertiesParameter requestParameters = null;

            // Store the request parameters
            RequestInterceptor interceptor = BatchTestHelpers.CreateFakeServiceResponseInterceptor<
                PoolUpdatePropertiesParameter,
                PoolUpdatePropertiesOptions,
                AzureOperationHeaderResponse<PoolUpdatePropertiesHeaders>>(requestAction: (r) =>
                {
                    requestParameters = r.Parameters;
                });
            cmdlet.AdditionalBehaviors = new List<BatchClientBehavior>() { interceptor };
            cmdlet.ExecuteCmdlet();

            // Verify the request parameters match the cmdlet parameters
            Assert.Equal(cmdlet.Pool.StartTask.CommandLine, requestParameters.StartTask.CommandLine);
            Assert.Equal(cmdlet.Pool.CertificateReferences.Count, requestParameters.CertificateReferences.Count);
            Assert.Equal(cmdlet.Pool.CertificateReferences[0].StoreName, requestParameters.CertificateReferences[0].StoreName);
            Assert.Equal(cmdlet.Pool.CertificateReferences[0].Thumbprint, requestParameters.CertificateReferences[0].Thumbprint);
            Assert.Equal(cmdlet.Pool.CertificateReferences[0].ThumbprintAlgorithm, requestParameters.CertificateReferences[0].ThumbprintAlgorithm);
            Assert.Equal(cmdlet.Pool.ApplicationPackageReferences.Count, requestParameters.ApplicationPackageReferences.Count);
            Assert.Equal(cmdlet.Pool.ApplicationPackageReferences[0].ApplicationId, requestParameters.ApplicationPackageReferences[0].ApplicationId);
            Assert.Equal(cmdlet.Pool.ApplicationPackageReferences[0].Version, requestParameters.ApplicationPackageReferences[0].Version);
            Assert.Equal(cmdlet.Pool.Metadata.Count, requestParameters.Metadata.Count);
            Assert.Equal(cmdlet.Pool.Metadata[0].Name, requestParameters.Metadata[0].Name);
            Assert.Equal(cmdlet.Pool.Metadata[0].Value, requestParameters.Metadata[0].Value);
        }
    }
}
