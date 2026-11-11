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

using Azure.Core;
using Azure.Core.Pipeline;
using Microsoft.Azure.Commands.Batch.Track2;
using Microsoft.Azure.Management.Batch.Models;
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using System;
using System.Text;
using Xunit;
using Track2BatchClient = Azure.Compute.Batch.BatchClient;
using Track2BatchClientOptions = Azure.Compute.Batch.BatchClientOptions;

namespace Microsoft.Azure.Commands.Batch.Test.Track2
{
    public class Track2ClientTests
    {
        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void RetriesAndTimeOutsAreTheSameAsTrack1()
        {
            Track2BatchClientOptions options = new DefaultOptionsContext().DefaultOptions();

            Assert.Equal(RetryMode.Exponential, options.Retry.Mode);
            Assert.Equal(TimeSpan.FromSeconds(1), options.Retry.Delay);
            Assert.Equal(6, options.Retry.MaxRetries);
            Assert.Equal(TimeSpan.FromMinutes(1), options.Retry.NetworkTimeout);
        }

        [Theory]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [InlineData("GET", "/jobs/job1/tasks/task1/files/stdout.txt", true)]
        [InlineData("GET", "/pools/pool1/nodes/node1/files/startup/stdout.txt", true)]
        [InlineData("POST", "/jobs/job1/tasks", true)]
        [InlineData("GET", "/jobs/job1/tasks/task1/files", false)]
        [InlineData("HEAD", "/jobs/job1/tasks/task1/files/stdout.txt", false)]
        [InlineData("DELETE", "/pools/pool1/nodes/node1/files/startup/stdout.txt", false)]
        [InlineData("POST", "/jobs/job1/addtaskcollection", false)]
        [InlineData("GET", "/jobs/job1/tasks", false)]
        [InlineData("GET", "/jobs/files/tasks", false)]
        [InlineData("GET", "/pools/pool1", false)]
        [InlineData("POST", "/pools", false)]
        public void ReadingAFileAndAddingATaskGetTheLongTimeOut(string method, string path, bool longRequest)
        {
            HttpMessage message = HttpPipelineBuilder.Build(new Track2BatchClientOptions()).CreateMessage();
            message.Request.Method = RequestMethod.Parse(method);
            message.Request.Uri.Reset(new Uri("https://account.westus.batch.azure.com" + path + "?api-version=2025-06-01"));

            new BatchRequestTimeoutPolicy().OnSendingRequest(message);

            Assert.Equal(longRequest ? TimeSpan.FromMinutes(3) : (TimeSpan?)null, message.NetworkTimeout);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void SwitchingKeysGivesANewTrack2Client()
        {
            string primary = Convert.ToBase64String(Encoding.UTF8.GetBytes("primary-key-not-a-real-key-00000"));
            string secondary = Convert.ToBase64String(Encoding.UTF8.GetBytes("secondary-key-not-a-real-key-000"));
            Track2TestContext context = new Track2TestContext(null, "account", "https://account.westus.batch.azure.com", new RecordingHandler(), primary);
            context.SecondaryAccountKey = secondary;

            Track2BatchClient first = context.Track2Client;
            Assert.Same(first, context.Track2Client);

            context.KeyInUse = AccountKeyType.Secondary;

            Assert.NotSame(first, context.Track2Client);
        }

        private class DefaultOptionsContext : BatchAccountContext
        {
            public DefaultOptionsContext() : base(null)
            {
            }

            public Track2BatchClientOptions DefaultOptions()
            {
                return this.CreateTrack2ClientOptions();
            }
        }
    }
}
