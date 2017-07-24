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

using Hyak.Common;
using Microsoft.Azure.Commands.Profile.Errors;
using Microsoft.Azure.Commands.ScenarioTest;
using Microsoft.WindowsAzure.Commands.Common.Test.Mocks;
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using System;
using System.Collections.Generic;
using System.Management.Automation;
using System.Net;
using System.Net.Http;
using Xunit;

namespace Microsoft.Azure.Commands.Profile.Test
{
    public class ErrorResolutionTests
    {
        class TestHyakException : CloudException
        {
            public TestHyakException(string message, CloudHttpRequestErrorInfo request, CloudHttpResponseErrorInfo response) : base(message)
            {
                Request = request;
                Response = response;
            }
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void DoesNotThrowWithNullError()
        {
            TestExecutionHelpers.SetUpSessionAndProfile();
            var cmdlet = new ResolveError();
            var output = cmdlet.ExecuteCmdletInPipeline<AzureErrorRecord>("Resolve-Error");
            Assert.True(output == null || output.Count == 0);
            output = cmdlet.ExecuteCmdletInPipeline<AzureErrorRecord>("Resolve-Error", new ErrorRecord[] { null, null });
            Assert.True(output == null || output.Count == 0);
            output = cmdlet.ExecuteCmdletInPipeline<AzureErrorRecord>("Resolve-Error", new ErrorRecord[] { null, new ErrorRecord(new Exception(null), null, ErrorCategory.AuthenticationError, null) });
            Assert.NotNull(output);
            Assert.Equal(1, output.Count);
            var record = output[0] as AzureExceptionRecord;
            Assert.NotNull(record);
            Assert.Equal(ErrorCategory.AuthenticationError, record.ErrorCategory.Category);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void HandlesExceptionError()
        {
            var runtime = new MockCommandRuntime();
            var request = new HttpRequestMessage(HttpMethod.Get, new Uri("https://www.contoso.com/resource?api-version-1.0"));
            request.Headers.Add("x-ms-request-id", "HyakRequestId");
            var response = new HttpResponseMessage(HttpStatusCode.BadRequest);
            var hyakException = new TestHyakException("exception message", CloudHttpRequestErrorInfo.Create(request), CloudHttpResponseErrorInfo.Create(response))
            {
                Error = new Hyak.Common.CloudError { Code="HyakCode", Message="HyakError"}
            };

            var autorestException = new Microsoft.Rest.Azure.CloudException("exception message")
            {
                Body = new Microsoft.Rest.Azure.CloudError { Code = "AutorestCode", Message = "Autorest message" },
                Request = new Rest.HttpRequestMessageWrapper(request, ""),
                Response = new Rest.HttpResponseMessageWrapper(response, ""),
                RequestId = "AutoRestRequestId"
            };

            var cmdlet = new ResolveError
            {
                Error = new [] 
                {
                    new ErrorRecord(new Exception("exception message"), "errorCode", ErrorCategory.AuthenticationError, this),
                    new ErrorRecord(hyakException, "errorCode", ErrorCategory.ConnectionError, this),
                    new ErrorRecord(autorestException , "errorCode", ErrorCategory.InvalidOperation, this),
                },
                CommandRuntime = runtime
            };

            cmdlet.ExecuteCmdlet();
            Assert.NotNull(runtime.OutputPipeline);
            Assert.Equal(3, runtime.OutputPipeline.Count);
            var errorResult = runtime.OutputPipeline[0] as AzureExceptionRecord;
            Assert.NotNull(errorResult);
            Assert.Equal(ErrorCategory.AuthenticationError, errorResult.ErrorCategory.Category);
            Assert.NotNull(errorResult.Exception);
            Assert.Equal(errorResult.Exception.GetType(), typeof(Exception));
            Assert.Equal("exception message", errorResult.Exception.Message);
            var hyakResult = runtime.OutputPipeline[1] as AzureRestExceptionRecord;
            Assert.NotNull(hyakResult);
            Assert.Equal(ErrorCategory.ConnectionError, hyakResult.ErrorCategory.Category);
            Assert.NotNull(errorResult.Exception);
            Assert.Equal(hyakResult.Exception.GetType(), typeof(TestHyakException));
            Assert.Equal("exception message", hyakResult.Exception.Message);
            Assert.NotNull(hyakResult.RequestMessage);
            Assert.Equal(HttpMethod.Get.ToString(), hyakResult.RequestMessage.Verb);
            Assert.Equal(new Uri("https://www.contoso.com/resource?api-version-1.0"), hyakResult.RequestMessage.Uri);
            Assert.NotNull(hyakResult.ServerResponse);
            Assert.Equal(HttpStatusCode.BadRequest.ToString(), hyakResult.ServerResponse.ResponseStatusCode);
            var autorestResult = runtime.OutputPipeline[2] as AzureRestExceptionRecord;
            Assert.NotNull(autorestResult);
            Assert.Equal(ErrorCategory.InvalidOperation, autorestResult.ErrorCategory.Category);
            Assert.NotNull(autorestResult.Exception);
            Assert.Equal(autorestResult.Exception.GetType(), typeof(Microsoft.Rest.Azure.CloudException));
            Assert.Equal("exception message", autorestResult.Exception.Message);
            Assert.NotNull(autorestResult.RequestMessage);
            Assert.Equal(HttpMethod.Get.ToString(), autorestResult.RequestMessage.Verb);
            Assert.Equal(new Uri("https://www.contoso.com/resource?api-version-1.0"), autorestResult.RequestMessage.Uri);
            Assert.NotNull(autorestResult.ServerResponse);
            Assert.Equal(HttpStatusCode.BadRequest.ToString(), autorestResult.ServerResponse.ResponseStatusCode);
            Assert.Equal("AutoRestRequestId", autorestResult.RequestId);
            Assert.Contains("AutorestCode", autorestResult.ServerMessage);
            Assert.Contains("Autorest message", autorestResult.ServerMessage);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void HandlesNullValuesInArmExceptions()
        {
            var runtime = new MockCommandRuntime();
            var hyakException = new TestHyakException(null, null, null);

            var autorestException = new Microsoft.Rest.Azure.CloudException();

            var cmdlet = new ResolveError
            {
                Error = new[]
                {
                    new ErrorRecord(new Exception(), null, ErrorCategory.AuthenticationError, null),
                    new ErrorRecord(hyakException, null, ErrorCategory.ConnectionError, null),
                    new ErrorRecord(autorestException , null, ErrorCategory.InvalidOperation, null),
                },
                CommandRuntime = runtime
            };

            cmdlet.ExecuteCmdlet();
            Assert.NotNull(runtime.OutputPipeline);
            Assert.Equal(3, runtime.OutputPipeline.Count);
            var errorResult = runtime.OutputPipeline[0] as AzureExceptionRecord;
            Assert.NotNull(errorResult);
            Assert.Equal(ErrorCategory.AuthenticationError, errorResult.ErrorCategory.Category);
            Assert.NotNull(errorResult.Exception);
            Assert.Equal(errorResult.Exception.GetType(), typeof(Exception));
            var hyakResult = runtime.OutputPipeline[1] as AzureRestExceptionRecord;
            Assert.NotNull(hyakResult);
            Assert.Equal(ErrorCategory.ConnectionError, hyakResult.ErrorCategory.Category);
            Assert.NotNull(errorResult.Exception);
            Assert.Equal(hyakResult.Exception.GetType(), typeof(TestHyakException));
            var autorestResult = runtime.OutputPipeline[2] as AzureRestExceptionRecord;
            Assert.NotNull(autorestResult);
            Assert.Equal(ErrorCategory.InvalidOperation, autorestResult.ErrorCategory.Category);
            Assert.NotNull(autorestResult.Exception);
            Assert.Equal(autorestResult.Exception.GetType(), typeof(Microsoft.Rest.Azure.CloudException));
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void LastParameterFindsLastError()
        {
            TestExecutionHelpers.SetUpSessionAndProfile();
            var mock = new MockCommandRuntime();
            var cmdlet = new ResolveError { CommandRuntime = mock };
            var message = "RuntimeErrorMessage";
            var exception = new Exception(message);
            cmdlet.ExecuteCmdletWithExceptionInPipeline<AzureErrorRecord>("Resolve-AzureRmError", exception, new KeyValuePair<string, object>("Last", null ) );
            Assert.NotNull(mock.ErrorStream);
            Assert.Equal(1, mock.ErrorStream.Count);
            Assert.NotNull(mock.OutputPipeline);
            Assert.Equal(1, mock.OutputPipeline.Count);
            var record = mock.OutputPipeline[0] as AzureExceptionRecord;
            Assert.NotNull(record);
            Assert.NotNull(record.Exception);
            Assert.Equal(typeof(Exception), record.Exception.GetType());
            Assert.Equal(message, record.Message);


        }
    }
}
