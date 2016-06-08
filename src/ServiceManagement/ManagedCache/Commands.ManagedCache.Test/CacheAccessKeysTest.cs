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

using Microsoft.Azure.Commands.ManagedCache.Models;
using Microsoft.Azure.Management.ManagedCache.Models;
using Xunit;

namespace Microsoft.Azure.Commands.ManagedCache.Test
{
    public class CacheAccessKeysTest
    {
        [Fact]
        public void InitializeAllFieldsCorrect()
        {
            //Arrange
            string primary = "primary";
            string secondary = "secondary";
            string requestID = "ID1";
            string serviceName = "cache1";
            System.Net.HttpStatusCode statusCode = System.Net.HttpStatusCode.OK;
            CachingKeysResponse response = new CachingKeysResponse()
            {
                Primary = primary,
                Secondary = secondary,
                StatusCode = statusCode,
                RequestId = requestID
            };

            //Act
            CacheAccessKeys keys = new CacheAccessKeys(serviceName, response);

            //Assert
            Assert.Equal(primary, keys.Primary);
            Assert.Equal(secondary, keys.Secondary);
            Assert.Equal(statusCode, keys.StatusCode);
            Assert.Equal(requestID, keys.RequestId);
            Assert.Equal(serviceName, keys.Name);
        }
    }
}
