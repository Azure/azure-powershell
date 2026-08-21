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

using Microsoft.Azure.Commands.Common.Exceptions;
using Microsoft.Azure.Commands.Sql.Common;
using Microsoft.Azure.Management.Sql.Models;
using Microsoft.Azure.ServiceManagement.Common.Models;
using Microsoft.Rest;
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using Xunit;
using Xunit.Abstractions;

namespace Microsoft.Azure.Commands.Sql.Test.UnitTests
{
    public class ErrorResponseExceptionHelperTests
    {
        public ErrorResponseExceptionHelperTests(ITestOutputHelper output)
        {
            XunitTracingInterceptor.AddToContext(new XunitTracingInterceptor(output));
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void CreateFrom_WithBodyErrorMessage_ReturnsDetailedMessage()
        {
            // Arrange
            var ex = new ErrorResponseException("Operation returned an invalid status code 'Forbidden'")
            {
                Body = new ErrorResponse(new ErrorDetail(
                    code: "RequestDisallowedByPolicy",
                    message: "Resource 'myserver' was disallowed by policy."))
            };

            // Act
            var result = ErrorResponseExceptionHelper.CreateFrom(ex);

            // Assert
            Assert.IsType<AzPSCloudException>(result);
            Assert.Contains("Resource 'myserver' was disallowed by policy.", result.Message);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void CreateFrom_WithBodyErrorDetails_IncludesDetailMessages()
        {
            // Arrange
            var details = new List<ErrorDetail>
            {
                new ErrorDetail(code: "PolicyViolation", message: "TLS version must be 1.2 or higher."),
                new ErrorDetail(code: "PolicyViolation", message: "Public network access must be disabled.")
            };
            var ex = new ErrorResponseException("Operation returned an invalid status code 'Forbidden'")
            {
                Body = new ErrorResponse(new ErrorDetail(
                    code: "RequestDisallowedByPolicy",
                    message: "Resource was disallowed by policy.",
                    details: details))
            };

            // Act
            var result = ErrorResponseExceptionHelper.CreateFrom(ex);

            // Assert
            Assert.IsType<AzPSCloudException>(result);
            Assert.Contains("Resource was disallowed by policy.", result.Message);
            Assert.Contains("TLS version must be 1.2 or higher.", result.Message);
            Assert.Contains("Public network access must be disabled.", result.Message);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void CreateFrom_WithResponseContentArmFormat_ParsesErrorMessage()
        {
            // Arrange — Body is null, but Response.Content has the ARM error JSON
            var httpResponse = new HttpResponseMessage(HttpStatusCode.NotFound)
            {
                Content = new StringContent("{\"error\":{\"code\":\"ResourceNotFound\",\"message\":\"The Resource 'Microsoft.Sql/servers/myserver' was not found.\"}}")
            };
            var ex = new ErrorResponseException("Operation returned an invalid status code 'NotFound'")
            {
                Response = new HttpResponseMessageWrapper(httpResponse, "{\"error\":{\"code\":\"ResourceNotFound\",\"message\":\"The Resource 'Microsoft.Sql/servers/myserver' was not found.\"}}")
            };

            // Act
            var result = ErrorResponseExceptionHelper.CreateFrom(ex);

            // Assert
            Assert.IsType<AzPSCloudException>(result);
            Assert.Contains("The Resource 'Microsoft.Sql/servers/myserver' was not found.", result.Message);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void CreateFrom_WithResponseContentFlatFormat_ParsesMessage()
        {
            // Arrange — Body is null, Response.Content has flat "Message" key
            var httpResponse = new HttpResponseMessage(HttpStatusCode.BadRequest)
            {
                Content = new StringContent("{\"Message\":\"Only one active directory allowed.\"}")
            };
            var ex = new ErrorResponseException("Operation returned an invalid status code 'BadRequest'")
            {
                Response = new HttpResponseMessageWrapper(httpResponse, "{\"Message\":\"Only one active directory allowed.\"}")
            };

            // Act
            var result = ErrorResponseExceptionHelper.CreateFrom(ex);

            // Assert
            Assert.IsType<AzPSCloudException>(result);
            Assert.Contains("Only one active directory allowed.", result.Message);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void CreateFrom_WithNoBodyAndNoContent_ReturnsOriginalMessage()
        {
            // Arrange — No body, no response content
            var ex = new ErrorResponseException("Operation returned an invalid status code 'InternalServerError'");

            // Act
            var result = ErrorResponseExceptionHelper.CreateFrom(ex);

            // Assert
            Assert.IsType<AzPSCloudException>(result);
            Assert.Equal("Operation returned an invalid status code 'InternalServerError'", result.Message);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void CreateFrom_WithInvalidJsonContent_ReturnsOriginalMessage()
        {
            // Arrange — Response content is not valid JSON
            var httpResponse = new HttpResponseMessage(HttpStatusCode.BadRequest)
            {
                Content = new StringContent("This is not JSON")
            };
            var ex = new ErrorResponseException("Operation returned an invalid status code 'BadRequest'")
            {
                Response = new HttpResponseMessageWrapper(httpResponse, "This is not JSON")
            };

            // Act
            var result = ErrorResponseExceptionHelper.CreateFrom(ex);

            // Assert
            Assert.IsType<AzPSCloudException>(result);
            Assert.Equal("Operation returned an invalid status code 'BadRequest'", result.Message);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void CreateFrom_BodyTakesPrecedenceOverResponseContent()
        {
            // Arrange — Both Body and Response.Content have error info; Body should win
            var httpResponse = new HttpResponseMessage(HttpStatusCode.Forbidden)
            {
                Content = new StringContent("{\"error\":{\"code\":\"Forbidden\",\"message\":\"Response content message\"}}")
            };
            var ex = new ErrorResponseException("Operation returned an invalid status code 'Forbidden'")
            {
                Body = new ErrorResponse(new ErrorDetail(
                    code: "RequestDisallowedByPolicy",
                    message: "Body error message")),
                Response = new HttpResponseMessageWrapper(httpResponse, "{\"error\":{\"code\":\"Forbidden\",\"message\":\"Response content message\"}}")
            };

            // Act
            var result = ErrorResponseExceptionHelper.CreateFrom(ex);

            // Assert
            Assert.Contains("Body error message", result.Message);
            Assert.DoesNotContain("Response content message", result.Message);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void CreateFrom_PreservesInnerExceptionAndContext()
        {
            // Arrange
            var httpResponse = new HttpResponseMessage(HttpStatusCode.Forbidden);
            var ex = new ErrorResponseException("Operation returned an invalid status code 'Forbidden'")
            {
                Body = new ErrorResponse(new ErrorDetail(
                    code: "AuthorizationFailed",
                    message: "Authorization failed.")),
                Request = new HttpRequestMessageWrapper(new HttpRequestMessage(HttpMethod.Get, "https://management.azure.com/test"), ""),
                Response = new HttpResponseMessageWrapper(httpResponse, "")
            };

            // Act
            var result = ErrorResponseExceptionHelper.CreateFrom(ex);

            // Assert — inner exception is preserved
            Assert.IsType<ErrorResponseException>(result.InnerException);
            // Assert — ErrorCode is propagated
            Assert.True(result.Data.Contains("CloudErrorCode"));
            // Assert — Request and Response are set
            Assert.NotNull(result.Request);
            Assert.NotNull(result.Response);
        }
    }
}
