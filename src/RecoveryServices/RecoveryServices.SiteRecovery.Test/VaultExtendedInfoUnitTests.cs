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

using System;
using System.Net;
using System.Net.Http;
using Microsoft.Azure.Commands.RecoveryServices.SiteRecovery;
using Microsoft.Azure.Management.RecoveryServices.Models;
using Microsoft.Rest;
using Microsoft.Rest.Azure;
using Xunit;

namespace RecoveryServices.SiteRecovery.Test
{
    /// <summary>
    /// Pure in-process unit tests for detecting the ResourceExtendedInfoNotFound error returned
    /// by the vault extended info GET call. When it is detected, Set-AzRecoveryServicesAsrVaultContext
    /// creates the vault extended info instead of failing with a NullReferenceException.
    /// </summary>
    public class VaultExtendedInfoUnitTests
    {
        private const string ExtendedInfoNotFoundContent =
            "{\"ErrorCode\":\"ResourceExtendedInfoNotFound\",\"Message\":{\"Language\":\"en-US\",\"Value\":\"\"}}";

        [Fact]
        public void IsResourceExtendedInfoNotFound_CloudErrorRecoveryServiceException_ReturnsTrue()
        {
            var exception = new CloudErrorRecoveryServiceException("Operation returned an invalid status code 'NotFound'")
            {
                Response = CreateResponse(ExtendedInfoNotFoundContent)
            };

            Assert.True(PSRecoveryServicesClient.IsResourceExtendedInfoNotFound(exception));
        }

        [Fact]
        public void IsResourceExtendedInfoNotFound_CloudException_ReturnsTrue()
        {
            var exception = new CloudException("Operation returned an invalid status code 'NotFound'")
            {
                Response = CreateResponse(ExtendedInfoNotFoundContent)
            };

            Assert.True(PSRecoveryServicesClient.IsResourceExtendedInfoNotFound(exception));
        }

        [Theory]
        [InlineData("{\"error\":{\"code\":\"ResourceNotFound\",\"message\":\"Vault not found.\"}}")]
        [InlineData("{\"ErrorCode\":\"AuthorizationFailed\"}")]
        [InlineData("<html>Bad Gateway</html>")]
        [InlineData("")]
        public void IsResourceExtendedInfoNotFound_OtherErrorContent_ReturnsFalse(string content)
        {
            var exception = new CloudErrorRecoveryServiceException("Operation failed.")
            {
                Response = CreateResponse(content)
            };

            Assert.False(PSRecoveryServicesClient.IsResourceExtendedInfoNotFound(exception));
        }

        [Fact]
        public void IsResourceExtendedInfoNotFound_ExceptionWithoutResponse_ReturnsFalse()
        {
            Assert.False(PSRecoveryServicesClient.IsResourceExtendedInfoNotFound(
                new CloudErrorRecoveryServiceException("Operation failed.")));
            Assert.False(PSRecoveryServicesClient.IsResourceExtendedInfoNotFound(
                new InvalidOperationException(ExtendedInfoNotFoundContent)));
            Assert.False(PSRecoveryServicesClient.IsResourceExtendedInfoNotFound(null));
        }

        private static HttpResponseMessageWrapper CreateResponse(string content)
        {
            return new HttpResponseMessageWrapper(new HttpResponseMessage(HttpStatusCode.NotFound), content);
        }
    }
}
