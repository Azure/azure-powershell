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

using Microsoft.Azure.Batch.Common;
using Microsoft.Azure.Commands.Batch.Models;
using Microsoft.Azure.Commands.Batch.Test.Track2;
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using Xunit;
using BatchClient = Microsoft.Azure.Commands.Batch.Models.BatchClient;

namespace Microsoft.Azure.Commands.Batch.Test.ScenarioTests
{
    public class ScenarioTestHelpersTests
    {
        private const string AccountUrl = "https://account.westus2.batch.azure.com";

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void PoolTheTestCreatedIsDeletedAfterRecording()
        {
            RecordingHandler service = new RecordingHandler().On("POST /pools", HttpStatusCode.Created);
            List<string> deleted = new List<string>();

            ScenarioTestHelpers.CreatePoolIfNotExists(new BatchClient(), PoolOn(service), deleted.Add);

            Assert.Equal("POST /pools", Sent(service));
            Assert.Equal(new[] { "pool1" }, deleted);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void PoolThatWasAlreadyThereIsNotDeletedAfterRecording()
        {
            RecordingHandler service = new RecordingHandler().On("POST /pools", HttpStatusCode.Conflict,
                Error("PoolExists", "The specified pool already exists."));
            List<string> deleted = new List<string>();

            ScenarioTestHelpers.CreatePoolIfNotExists(new BatchClient(), PoolOn(service), deleted.Add);

            Assert.Equal("POST /pools", Sent(service));
            Assert.Empty(deleted);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void PoolThatCouldNotBeCreatedIsNotDeletedAfterRecording()
        {
            RecordingHandler service = new RecordingHandler().On("POST /pools", HttpStatusCode.BadRequest,
                Error("InvalidPropertyValue", "The value provided for one of the properties in the request body is invalid."));
            List<string> deleted = new List<string>();

            BatchException e = Assert.Throws<BatchException>(
                () => ScenarioTestHelpers.CreatePoolIfNotExists(new BatchClient(), PoolOn(service), deleted.Add));

            Assert.Equal("InvalidPropertyValue", e.RequestInformation.BatchError.Code);
            Assert.Empty(deleted);
        }

        // The pool the helper creates, in an account whose requests go to the fake service instead of the network.
        private static NewPoolParameters PoolOn(RecordingHandler service)
        {
            string key = Convert.ToBase64String(Encoding.UTF8.GetBytes("account-key-not-a-real-key-00000"));
            Track2TestContext context = new Track2TestContext(null, "account", AccountUrl, service, key);
            return new NewPoolParameters(context, "pool1") { VirtualMachineSize = "standard_d2s_v3" };
        }

        private static string Sent(RecordingHandler service)
        {
            return string.Join(", ", service.Requests.Select(r => r.Method + " " + r.Uri.AbsolutePath));
        }

        private static string Error(string code, string message)
        {
            return "{\"code\":\"" + code + "\",\"message\":{\"lang\":\"en-US\",\"value\":\"" + message + "\"}}";
        }
    }
}
