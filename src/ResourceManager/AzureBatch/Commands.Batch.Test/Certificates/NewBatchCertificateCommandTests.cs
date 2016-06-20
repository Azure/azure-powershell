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
using Microsoft.Azure.Batch.Protocol.BatchRequests;
using Microsoft.Azure.Batch.Protocol.Models;
using Microsoft.Rest.Azure;
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using Moq;
using System;
using System.Collections.Generic;
using System.Management.Automation;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using Xunit;
using BatchClient = Microsoft.Azure.Commands.Batch.Models.BatchClient;

namespace Microsoft.Azure.Commands.Batch.Test.Certificates
{
    public class NewBatchCertificateCommandTests : WindowsAzure.Commands.Test.Utilities.Common.RMTestBase
    {
        private NewBatchCertificateCommand cmdlet;
        private Mock<BatchClient> batchClientMock;
        private Mock<ICommandRuntime> commandRuntimeMock;

        public NewBatchCertificateCommandTests(Xunit.Abstractions.ITestOutputHelper output)
        {
            ServiceManagemenet.Common.Models.XunitTracingInterceptor.AddToContext(new ServiceManagemenet.Common.Models.XunitTracingInterceptor(output));
            batchClientMock = new Mock<BatchClient>();
            commandRuntimeMock = new Mock<ICommandRuntime>();
            cmdlet = new NewBatchCertificateCommand()
            {
                CommandRuntime = commandRuntimeMock.Object,
                BatchClient = batchClientMock.Object,
            };
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void NewBatchCertificateRequiredParametersTest()
        {
            // Setup cmdlet without the required parameters
            BatchAccountContext context = BatchTestHelpers.CreateBatchContextWithKeys();
            cmdlet.BatchContext = context;

            Assert.Throws<ArgumentException>(() => cmdlet.ExecuteCmdlet());

            cmdlet.FilePath = BatchTestHelpers.TestCertificateFileName;

            // Don't go to the service on an Add Certificate call
            RequestInterceptor interceptor = BatchTestHelpers.CreateFakeServiceResponseInterceptor<
                CertificateAddParameter,
                CertificateAddOptions,
                AzureOperationHeaderResponse<CertificateAddHeaders>>();

            cmdlet.AdditionalBehaviors = new List<BatchClientBehavior>() { interceptor };

            // Verify no exceptions when required parameters are set
            cmdlet.ExecuteCmdlet();

            // Use the RawData parameter set next
            cmdlet.FilePath = null;
            X509Certificate2 cert = new X509Certificate2(BatchTestHelpers.TestCertificateFileName);
            cmdlet.RawData = cert.RawData;

            // Verify no exceptions when required parameters are set
            cmdlet.ExecuteCmdlet();
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void NewBatchCertificateRequestBodyTest()
        {
            BatchAccountContext context = BatchTestHelpers.CreateBatchContextWithKeys();
            cmdlet.BatchContext = context;

            X509Certificate2 cert = new X509Certificate2(BatchTestHelpers.TestCertificateFileName);
            string certDataBase64String = Convert.ToBase64String(cert.RawData);

            CertificateAddParameter requestParameters = null;

            // Don't go to the service on an Add Certificate call
            RequestInterceptor interceptor = new RequestInterceptor((baseRequest) =>
            {
                CertificateAddBatchRequest request = (CertificateAddBatchRequest)baseRequest;

                request.ServiceRequestFunc = (cancellationToken) =>
                {
                    requestParameters = request.Parameters;

                    var response = new AzureOperationHeaderResponse<CertificateAddHeaders>();
                    Task<AzureOperationHeaderResponse<CertificateAddHeaders>> task = Task.FromResult(response);
                    return task;
                };
            });

            cmdlet.AdditionalBehaviors = new List<BatchClientBehavior>() { interceptor };

            // Verify that when just the raw data is specified, the request body matches expectations
            cmdlet.RawData = cert.RawData;
            cmdlet.ExecuteCmdlet();
            Assert.Equal(CertificateFormat.Cer, requestParameters.CertificateFormat);
            Assert.Equal(BatchTestHelpers.TestCertificateAlgorithm, requestParameters.ThumbprintAlgorithm);
            Assert.Equal(cert.Thumbprint.ToLowerInvariant(), requestParameters.Thumbprint.ToLowerInvariant());
            Assert.True(string.IsNullOrEmpty(requestParameters.Password));
            Assert.Equal(certDataBase64String, requestParameters.Data);

            // Verify that when the raw data is specified with a password, the request body matches expectations
            cmdlet.RawData = cert.RawData;
            cmdlet.Password = BatchTestHelpers.TestCertificatePassword;
            cmdlet.ExecuteCmdlet();
            Assert.Equal(CertificateFormat.Pfx, requestParameters.CertificateFormat);
            Assert.Equal(BatchTestHelpers.TestCertificateAlgorithm, requestParameters.ThumbprintAlgorithm);
            Assert.Equal(cert.Thumbprint.ToLowerInvariant(), requestParameters.Thumbprint.ToLowerInvariant());
            Assert.Equal(BatchTestHelpers.TestCertificatePassword, requestParameters.Password);
            Assert.Equal(certDataBase64String, requestParameters.Data);

            // Verify that when just a file path is specified, the request body matches expectations
            cmdlet.RawData = null;
            cmdlet.Password = null;
            cmdlet.FilePath = BatchTestHelpers.TestCertificateFileName;
            cmdlet.ExecuteCmdlet();
            Assert.Equal(CertificateFormat.Cer, requestParameters.CertificateFormat);
            Assert.Equal(BatchTestHelpers.TestCertificateAlgorithm, requestParameters.ThumbprintAlgorithm);
            Assert.Equal(cert.Thumbprint.ToLowerInvariant(), requestParameters.Thumbprint.ToLowerInvariant());
            Assert.True(string.IsNullOrEmpty(requestParameters.Password));
            Assert.Equal(certDataBase64String, requestParameters.Data);

            // Verify that when a file path is specified with a password, the request body matches expectations
            cmdlet.Password = BatchTestHelpers.TestCertificatePassword;
            cmdlet.ExecuteCmdlet();
            Assert.Equal(CertificateFormat.Pfx, requestParameters.CertificateFormat);
            Assert.Equal(BatchTestHelpers.TestCertificateAlgorithm, requestParameters.ThumbprintAlgorithm);
            Assert.Equal(cert.Thumbprint.ToLowerInvariant(), requestParameters.Thumbprint.ToLowerInvariant());
            Assert.Equal(BatchTestHelpers.TestCertificatePassword, requestParameters.Password);
            Assert.Equal(certDataBase64String, requestParameters.Data);
        }
    }
}
