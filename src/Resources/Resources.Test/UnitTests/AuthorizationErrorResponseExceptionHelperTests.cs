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

using FluentAssertions;
using Microsoft.Azure.Commands.Common.Exceptions;
using Microsoft.Azure.Commands.Resources.Helper;
using Microsoft.Azure.Management.Authorization.Models;
using Microsoft.Rest;
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using System.Net.Http;
using Xunit;

namespace Microsoft.Azure.Commands.Resources.Test.UnitTests
{
    public class AuthorizationErrorResponseExceptionHelperTests
    {
        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void CreateDescriptiveException_WithStructuredBody_IncludesCodeAndMessage()
        {
            var ex = new ErrorResponseException("Operation returned an invalid status code 'Conflict'")
            {
                Body = new ErrorResponse(new ErrorDetail(
                    code: "RoleAssignmentExists",
                    message: "The role assignment already exists."))
            };

            var result = AuthorizationErrorResponseExceptionHelper.CreateDescriptiveException(ex);

            result.Should().BeOfType<AzPSCloudException>();
            result.Message.Should().Contain("Operation returned an invalid status code 'Conflict'");
            result.Message.Should().Contain("RoleAssignmentExists");
            result.Message.Should().Contain("The role assignment already exists.");
            result.InnerException.Should().Be(ex);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void CreateDescriptiveException_WithRawResponseContentOnly_IncludesResponseContent()
        {
            var ex = new ErrorResponseException("Operation returned an invalid status code 'NotFound'")
            {
                Response = new HttpResponseMessageWrapper(
                    new HttpResponseMessage(System.Net.HttpStatusCode.NotFound),
                    "{\"error\":{\"code\":\"SubscriptionNotFound\",\"message\":\"The subscription could not be found.\"}}")
            };

            var result = AuthorizationErrorResponseExceptionHelper.CreateDescriptiveException(ex);

            result.Should().BeOfType<AzPSCloudException>();
            result.Message.Should().Contain("Operation returned an invalid status code 'NotFound'");
            result.Message.Should().Contain("SubscriptionNotFound");
            result.InnerException.Should().Be(ex);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void CreateDescriptiveException_WithNoBodyOrResponse_FallsBackToOriginalMessage()
        {
            var ex = new ErrorResponseException("Operation returned an invalid status code 'BadRequest'");

            var result = AuthorizationErrorResponseExceptionHelper.CreateDescriptiveException(ex);

            result.Should().BeOfType<AzPSCloudException>();
            result.Message.Should().Be("Operation returned an invalid status code 'BadRequest'");
            result.InnerException.Should().Be(ex);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void CreateDescriptiveException_PreservesRequestAndResponse()
        {
            var request = new HttpRequestMessageWrapper(
                new HttpRequestMessage(HttpMethod.Put, "https://management.azure.com/test"),
                "{}");
            var response = new HttpResponseMessageWrapper(
                new HttpResponseMessage(System.Net.HttpStatusCode.Conflict),
                "{}");
            var ex = new ErrorResponseException("Conflict")
            {
                Request = request,
                Response = response,
                Body = new ErrorResponse(new ErrorDetail(code: "X", message: "Y"))
            };

            var result = AuthorizationErrorResponseExceptionHelper.CreateDescriptiveException(ex);

            result.Request.Should().Be(request);
            result.Response.Should().Be(response);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void CreateDescriptiveException_WithParseableResponseContent_FormatsCodeAndDetail()
        {
            var ex = new ErrorResponseException("Operation returned an invalid status code 'NotFound'")
            {
                Response = new HttpResponseMessageWrapper(
                    new HttpResponseMessage(System.Net.HttpStatusCode.NotFound),
                    "{\"error\":{\"code\":\"SubscriptionNotFound\",\"message\":\"The subscription could not be found.\"}}")
            };

            var result = AuthorizationErrorResponseExceptionHelper.CreateDescriptiveException(ex);

            // Should produce the same "<orig>. code: detail" shape as the structured-body branch,
            // not dump the raw JSON blob.
            result.Message.Should().Contain("SubscriptionNotFound: The subscription could not be found.");
            result.Message.Should().NotContain("Response: {");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void CreateDescriptiveException_WithMalformedResponseContent_FallsBackToRawContent()
        {
            const string malformed = "this is not json {";
            var ex = new ErrorResponseException("Operation returned an invalid status code 'BadRequest'")
            {
                Response = new HttpResponseMessageWrapper(
                    new HttpResponseMessage(System.Net.HttpStatusCode.BadRequest),
                    malformed)
            };

            var result = AuthorizationErrorResponseExceptionHelper.CreateDescriptiveException(ex);

            result.Message.Should().Contain("Operation returned an invalid status code 'BadRequest'");
            result.Message.Should().Contain($"Response: {malformed}");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void CreateDescriptiveException_WithJsonMissingErrorObject_FallsBackToRawContent()
        {
            const string content = "{\"unrelated\":\"value\"}";
            var ex = new ErrorResponseException("Operation returned an invalid status code 'BadRequest'")
            {
                Response = new HttpResponseMessageWrapper(
                    new HttpResponseMessage(System.Net.HttpStatusCode.BadRequest),
                    content)
            };

            var result = AuthorizationErrorResponseExceptionHelper.CreateDescriptiveException(ex);

            result.Message.Should().Contain($"Response: {content}");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void CreateDescriptiveException_WithBothBodyAndResponseContent_PrefersStructuredBody()
        {
            var ex = new ErrorResponseException("Operation returned an invalid status code 'Conflict'")
            {
                Body = new ErrorResponse(new ErrorDetail(code: "BodyCode", message: "Body message.")),
                Response = new HttpResponseMessageWrapper(
                    new HttpResponseMessage(System.Net.HttpStatusCode.Conflict),
                    "{\"error\":{\"code\":\"ResponseCode\",\"message\":\"Response message.\"}}")
            };

            var result = AuthorizationErrorResponseExceptionHelper.CreateDescriptiveException(ex);

            result.Message.Should().Contain("BodyCode");
            result.Message.Should().Contain("Body message.");
            result.Message.Should().NotContain("ResponseCode");
        }
    }
}
