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
using System.Globalization;
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using Xunit;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using Microsoft.WindowsAzure.Commands.Utilities.Properties;

namespace Microsoft.WindowsAzure.Commands.Test.Common
{
    
    public class GeneralTests : IDisposable
    {
        private const string _publishSettingsUrl = "http://manage.windowsazure.com/";
        private const string _azureHostNameSuffix = "the suffix";

        public GeneralTests()
        {
            // Set test environment variables
            System.Environment.SetEnvironmentVariable(Resources.PublishSettingsUrlEnv, _publishSettingsUrl);
        }

        public void ClassCleanup()
        {
            // Delete test environment variables
            System.Environment.SetEnvironmentVariable(Resources.PublishSettingsUrlEnv, null);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestBlobEndpointUri()
        {
            string accountName = "azure awesome account";
            string expected = string.Format(Resources.BlobEndpointUri, accountName);
            string actual = string.Format(CultureInfo.InvariantCulture,
                TryGetEnvironmentVariable(Resources.BlobEndpointUriEnv, Resources.BlobEndpointUri),
                accountName);

            Assert.Equal<string>(expected, actual);
        }

        private static string TryGetEnvironmentVariable(string environmentVariableName, string defaultValue)
        {
            string value = System.Environment.GetEnvironmentVariable(environmentVariableName);
            return (string.IsNullOrEmpty(value)) ? defaultValue : value;
        }

        public void Dispose()
        {
            ClassCleanup();
        }
    }
}