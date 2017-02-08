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

using Microsoft.Azure.Commands.Batch.Utils;
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using System;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Microsoft.Azure.Commands.Batch.Test.UtilsTests
{
    public class BatchAadTokenProviderTests : WindowsAzure.Commands.Test.Utilities.Common.RMTestBase
    {
        public BatchAadTokenProviderTests(Xunit.Abstractions.ITestOutputHelper output)
        {
            ServiceManagemenet.Common.Models.XunitTracingInterceptor.AddToContext(new ServiceManagemenet.Common.Models.XunitTracingInterceptor(output));
        }

        private class TestBatchAadTokenProvider : BatchAadTokenProvider
        {
            string fakeToken;

            public TestBatchAadTokenProvider(string fakeToken) : base(null)
            {
                this.fakeToken = fakeToken;
            }

            protected override string GetBatchAadToken()
            {
                return fakeToken;
            }
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public async Task BatchAadTokenProviderReturnsProperAuthHeaderWithProvidedToken()
        {
            string fakeToken = "fake token";
            BatchAadTokenProvider tokenProvider = new TestBatchAadTokenProvider(fakeToken);
            AuthenticationHeaderValue headerValue = await tokenProvider.GetAuthenticationHeaderAsync(CancellationToken.None);

            Assert.Equal("Bearer", headerValue.Scheme);
            Assert.Equal(fakeToken, headerValue.Parameter);
        }
    }
}
