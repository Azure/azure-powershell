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
using Microsoft.Azure.Commands.Batch.Models;
using Microsoft.Rest.Azure;
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Threading.Tasks;
using Xunit;
using BatchClient = Microsoft.Azure.Commands.Batch.Models.BatchClient;
using ProxyModels = Microsoft.Azure.Batch.Protocol.Models;

namespace Microsoft.Azure.Commands.Batch.Test.Certificates
{
    public class GetBatchCertificateCommandTests : WindowsAzure.Commands.Test.Utilities.Common.RMTestBase
    {
        private GetBatchCertificateCommand cmdlet;
        private Mock<BatchClient> batchClientMock;
        private Mock<ICommandRuntime> commandRuntimeMock;

        public GetBatchCertificateCommandTests(Xunit.Abstractions.ITestOutputHelper output)
        {
            ServiceManagemenet.Common.Models.XunitTracingInterceptor.AddToContext(new ServiceManagemenet.Common.Models.XunitTracingInterceptor(output));
            batchClientMock = new Mock<BatchClient>();
            commandRuntimeMock = new Mock<ICommandRuntime>();
            cmdlet = new GetBatchCertificateCommand()
            {
                CommandRuntime = commandRuntimeMock.Object,
                BatchClient = batchClientMock.Object,
            };
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void GetBatchCertificateTest()
        {
            // Setup cmdlet to get a cert by its thumbprint
            BatchAccountContext context = BatchTestHelpers.CreateBatchContextWithKeys();
            cmdlet.BatchContext = context;
            cmdlet.ThumbprintAlgorithm = "sha1";
            cmdlet.Thumbprint = "123456789";
            cmdlet.Filter = null;

            // Build a Certificate instead of querying the service on a Get Certificate call
            AzureOperationResponse<ProxyModels.Certificate, ProxyModels.CertificateGetHeaders> response = BatchTestHelpers.CreateCertificateGetResponse(cmdlet.Thumbprint);
            RequestInterceptor interceptor = BatchTestHelpers.CreateFakeServiceResponseInterceptor<
                ProxyModels.CertificateGetOptions,
                AzureOperationResponse<ProxyModels.Certificate, ProxyModels.CertificateGetHeaders>>(response);

            cmdlet.AdditionalBehaviors = new List<BatchClientBehavior>() { interceptor };

            // Setup the cmdlet to write pipeline output to a list that can be examined later
            List<PSCertificate> pipeline = new List<PSCertificate>();
            commandRuntimeMock.Setup(r => r.WriteObject(It.IsAny<PSCertificate>())).Callback<object>(c => pipeline.Add((PSCertificate)c));

            cmdlet.ExecuteCmdlet();

            // Verify that the cmdlet wrote the cert returned from the OM to the pipeline
            Assert.Equal(1, pipeline.Count);
            Assert.Equal(cmdlet.Thumbprint, pipeline[0].Thumbprint);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void GetBatchCertificateODataTest()
        {
            // Setup cmdlet to get a single certificate
            BatchAccountContext context = BatchTestHelpers.CreateBatchContextWithKeys();
            cmdlet.BatchContext = context;
            cmdlet.ThumbprintAlgorithm = "sha1";
            cmdlet.Thumbprint = "123456789";
            cmdlet.Select = "thumbprint,state";

            string requestSelect = null;

            // Fetch the OData clauses off the request. The OData clauses are applied after user provided RequestInterceptors, so a ResponseInterceptor is used.
            AzureOperationResponse<ProxyModels.Certificate, ProxyModels.CertificateGetHeaders> getResponse = BatchTestHelpers.CreateCertificateGetResponse(cmdlet.Thumbprint);
            RequestInterceptor requestInterceptor = BatchTestHelpers.CreateFakeServiceResponseInterceptor<
                ProxyModels.CertificateGetOptions,
                AzureOperationResponse<ProxyModels.Certificate, ProxyModels.CertificateGetHeaders>>(getResponse);
            ResponseInterceptor responseInterceptor = new ResponseInterceptor((response, request) =>
            {
                ProxyModels.CertificateGetOptions certOptions = (ProxyModels.CertificateGetOptions)request.Options;
                requestSelect = certOptions.Select;

                return Task.FromResult(response);
            });
            cmdlet.AdditionalBehaviors = new List<BatchClientBehavior>() { requestInterceptor, responseInterceptor };

            cmdlet.ExecuteCmdlet();

            Assert.Equal(cmdlet.Select, requestSelect);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void ListBatchCertificatesODataTest()
        {
            // Setup cmdlet to list certs using an OData filter
            BatchAccountContext context = BatchTestHelpers.CreateBatchContextWithKeys();
            cmdlet.BatchContext = context;
            cmdlet.ThumbprintAlgorithm = null;
            cmdlet.Thumbprint = null;
            cmdlet.Filter = "state eq 'active'";
            cmdlet.Select = "id,state";

            string requestFilter = null;
            string requestSelect = null;

            AzureOperationResponse<IPage<ProxyModels.Certificate>, ProxyModels.CertificateListHeaders> response = BatchTestHelpers.CreateGenericAzureOperationListResponse<ProxyModels.Certificate, ProxyModels.CertificateListHeaders>();

            Action<BatchRequest<ProxyModels.CertificateListOptions, AzureOperationResponse<IPage<ProxyModels.Certificate>, ProxyModels.CertificateListHeaders>>> extractCertificateListAction =
                (request) =>
                {
                    ProxyModels.CertificateListOptions options = request.Options;
                    requestFilter = options.Filter;
                    requestSelect = options.Select;
                };

            RequestInterceptor requestInterceptor = BatchTestHelpers.CreateFakeServiceResponseInterceptor(responseToUse: response, requestAction: extractCertificateListAction);

            cmdlet.AdditionalBehaviors = new List<BatchClientBehavior>() { requestInterceptor };

            cmdlet.ExecuteCmdlet();

            Assert.Equal(cmdlet.Filter, requestFilter);
            Assert.Equal(cmdlet.Select, requestSelect);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void ListBatchCertificatesWithoutFiltersTest()
        {
            // Setup cmdlet to list certs without filters
            BatchAccountContext context = BatchTestHelpers.CreateBatchContextWithKeys();
            cmdlet.BatchContext = context;
            cmdlet.ThumbprintAlgorithm = null;
            cmdlet.Thumbprint = null;
            cmdlet.Filter = null;

            string[] thumbprintsOfConstructedCerts = new[] { "12345", "67890", "ABCDE" };

            // Build some Certificates instead of querying the service on a List Certificates call
            AzureOperationResponse<IPage<ProxyModels.Certificate>, ProxyModels.CertificateListHeaders> response = BatchTestHelpers.CreateCertificateListResponse(thumbprintsOfConstructedCerts);
            RequestInterceptor interceptor = BatchTestHelpers.CreateFakeServiceResponseInterceptor<
                ProxyModels.CertificateListOptions,
                AzureOperationResponse<IPage<ProxyModels.Certificate>, ProxyModels.CertificateListHeaders>>(response);

            cmdlet.AdditionalBehaviors = new List<BatchClientBehavior>() { interceptor };

            // Setup the cmdlet to write pipeline output to a list that can be examined later
            List<PSCertificate> pipeline = new List<PSCertificate>();
            commandRuntimeMock.Setup(r =>
                r.WriteObject(It.IsAny<PSCertificate>()))
                .Callback<object>(c => pipeline.Add((PSCertificate)c));

            cmdlet.ExecuteCmdlet();

            // Verify that the cmdlet wrote the constructed certs to the pipeline
            Assert.Equal(3, pipeline.Count);
            int poolCount = 0;
            foreach (PSCertificate c in pipeline)
            {
                Assert.True(thumbprintsOfConstructedCerts.Contains(c.Thumbprint));
                poolCount++;
            }
            Assert.Equal(thumbprintsOfConstructedCerts.Length, poolCount);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void ListCertificatesMaxCountTest()
        {
            // Verify default max count
            Assert.Equal(Microsoft.Azure.Commands.Batch.Utils.Constants.DefaultMaxCount, cmdlet.MaxCount);

            // Setup cmdlet to list pools without filters and a max count
            BatchAccountContext context = BatchTestHelpers.CreateBatchContextWithKeys();
            cmdlet.BatchContext = context;
            cmdlet.ThumbprintAlgorithm = null;
            cmdlet.Thumbprint = null;
            cmdlet.Filter = null;
            int maxCount = 2;
            cmdlet.MaxCount = maxCount;

            string[] thumbprintsOfConstructedCerts = new[] { "12345", "67890", "ABCDE" };

            // Build some Certificates instead of querying the service on a List Certificates call
            AzureOperationResponse<IPage<ProxyModels.Certificate>, ProxyModels.CertificateListHeaders> response = BatchTestHelpers.CreateCertificateListResponse(thumbprintsOfConstructedCerts);
            RequestInterceptor interceptor = BatchTestHelpers.CreateFakeServiceResponseInterceptor<
                ProxyModels.CertificateListOptions,
                AzureOperationResponse<IPage<ProxyModels.Certificate>, ProxyModels.CertificateListHeaders>>(response);

            cmdlet.AdditionalBehaviors = new List<BatchClientBehavior>() { interceptor };

            // Setup the cmdlet to write pipeline output to a list that can be examined later
            List<PSCertificate> pipeline = new List<PSCertificate>();
            commandRuntimeMock.Setup(r =>
                r.WriteObject(It.IsAny<PSCertificate>()))
                .Callback<object>(c => pipeline.Add((PSCertificate)c));

            cmdlet.ExecuteCmdlet();

            // Verify that the max count was respected
            Assert.Equal(maxCount, pipeline.Count);

            // Verify setting max count <= 0 doesn't return nothing
            cmdlet.MaxCount = -5;
            pipeline.Clear();
            cmdlet.ExecuteCmdlet();

            Assert.Equal(thumbprintsOfConstructedCerts.Length, pipeline.Count);
        }
    }
}
