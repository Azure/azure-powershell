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

using Microsoft.Azure.Commands.Common.Authentication.Abstractions;
using Microsoft.Rest;
using System;
using Xunit;

namespace Common.Authentication.Test
{
    public class ServiceClientExtensionTests
    {
        private class FakeServiceClient : ServiceClient<FakeServiceClient>
        {
            public FakeServiceClient(params System.Net.Http.DelegatingHandler[] handlers) : base(handlers)
            {
            }
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestRetryCountPrecedenceAndFallback()
        {
            var origCanonical = Environment.GetEnvironmentVariable("AZURE_PS_HTTP_MAX_RETRIES");
            var origLegacy = Environment.GetEnvironmentVariable("PS_HTTP_MAX_RETRIES");

            try
            {
                // Scenario 1: Neither is set
                Environment.SetEnvironmentVariable("AZURE_PS_HTTP_MAX_RETRIES", null);
                Environment.SetEnvironmentVariable("PS_HTTP_MAX_RETRIES", null);
                var client = new FakeServiceClient();
                Assert.False(client.TrySetRetryCountofRetryPolicy());

                // Scenario 2: Only legacy is set
                Environment.SetEnvironmentVariable("AZURE_PS_HTTP_MAX_RETRIES", null);
                Environment.SetEnvironmentVariable("PS_HTTP_MAX_RETRIES", "5");
                client = new FakeServiceClient();
                Assert.True(client.TrySetRetryCountofRetryPolicy());

                // Scenario 3: Only canonical is set
                Environment.SetEnvironmentVariable("AZURE_PS_HTTP_MAX_RETRIES", "3");
                Environment.SetEnvironmentVariable("PS_HTTP_MAX_RETRIES", null);
                client = new FakeServiceClient();
                Assert.True(client.TrySetRetryCountofRetryPolicy());

                // Scenario 4: Both are set, canonical wins
                Environment.SetEnvironmentVariable("AZURE_PS_HTTP_MAX_RETRIES", "4");
                Environment.SetEnvironmentVariable("PS_HTTP_MAX_RETRIES", "10");
                client = new FakeServiceClient();
                Assert.True(client.TrySetRetryCountofRetryPolicy());
            }
            finally
            {
                Environment.SetEnvironmentVariable("AZURE_PS_HTTP_MAX_RETRIES", origCanonical);
                Environment.SetEnvironmentVariable("PS_HTTP_MAX_RETRIES", origLegacy);
            }
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestRetry429PrecedenceAndFallback()
        {
            var origCanonical = Environment.GetEnvironmentVariable("AZURE_PS_HTTP_MAX_RETRIES_FOR_429");
            var origLegacy = Environment.GetEnvironmentVariable("PS_HTTP_MAX_RETRIES_FOR_429");

            try
            {
                var handler = new RetryAfterDelegatingHandler();

                // Scenario 1: Neither is set
                Environment.SetEnvironmentVariable("AZURE_PS_HTTP_MAX_RETRIES_FOR_429", null);
                Environment.SetEnvironmentVariable("PS_HTTP_MAX_RETRIES_FOR_429", null);
                var client = new FakeServiceClient(handler);
                Assert.False(client.TrySetMaxTimesForRetryAfterHandler());

                // Scenario 2: Only legacy is set
                Environment.SetEnvironmentVariable("AZURE_PS_HTTP_MAX_RETRIES_FOR_429", null);
                Environment.SetEnvironmentVariable("PS_HTTP_MAX_RETRIES_FOR_429", "8");
                client = new FakeServiceClient(handler);
                Assert.True(client.TrySetMaxTimesForRetryAfterHandler());
                Assert.Equal(8, handler.MaxRetries);

                // Scenario 3: Only canonical is set
                Environment.SetEnvironmentVariable("AZURE_PS_HTTP_MAX_RETRIES_FOR_429", "6");
                Environment.SetEnvironmentVariable("PS_HTTP_MAX_RETRIES_FOR_429", null);
                client = new FakeServiceClient(handler);
                Assert.True(client.TrySetMaxTimesForRetryAfterHandler());
                Assert.Equal(6, handler.MaxRetries);

                // Scenario 4: Both are set, canonical wins
                Environment.SetEnvironmentVariable("AZURE_PS_HTTP_MAX_RETRIES_FOR_429", "12");
                Environment.SetEnvironmentVariable("PS_HTTP_MAX_RETRIES_FOR_429", "2");
                client = new FakeServiceClient(handler);
                Assert.True(client.TrySetMaxTimesForRetryAfterHandler());
                Assert.Equal(12, handler.MaxRetries);
            }
            finally
            {
                Environment.SetEnvironmentVariable("AZURE_PS_HTTP_MAX_RETRIES_FOR_429", origCanonical);
                Environment.SetEnvironmentVariable("PS_HTTP_MAX_RETRIES_FOR_429", origLegacy);
            }
        }
    }
}
