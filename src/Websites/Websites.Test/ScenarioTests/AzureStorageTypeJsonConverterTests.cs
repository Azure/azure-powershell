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

using Microsoft.Azure.Commands.WebApps.Utilities;
using Microsoft.Azure.Management.WebSites.Models;
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using Newtonsoft.Json;
using Xunit;

namespace Microsoft.Azure.Commands.WebApps.Test.ScenarioTests
{
    public class AzureStorageTypeJsonConverterTests
    {
        private static JsonSerializerSettings CreateSettings()
        {
            return new JsonSerializerSettings
            {
                ContractResolver = new AzureStorageTypeContractResolver(),
                Converters = { new AzureStorageTypeJsonConverter() }
            };
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void UnknownAzureStorageTypeDeserializesToNullInsteadOfThrowing()
        {
            // "FileShare" is a value the service can return that is not defined by the
            // AzureStorageType enum (see https://github.com/Azure/azure-powershell/issues/29979).
            var json = "{\"type\":\"FileShare\",\"accountName\":\"test\",\"shareName\":\"test\",\"mountPath\":\"\\\\mounts\\\\FileSystem\"}";

            var result = JsonConvert.DeserializeObject<AzureStorageInfoValue>(json, CreateSettings());

            Assert.NotNull(result);
            Assert.Null(result.Type);
            Assert.Equal("test", result.AccountName);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void KnownAzureStorageTypeDeserializesCorrectly()
        {
            var json = "{\"type\":\"AzureFiles\",\"accountName\":\"test\",\"shareName\":\"test\"}";

            var result = JsonConvert.DeserializeObject<AzureStorageInfoValue>(json, CreateSettings());

            Assert.NotNull(result);
            Assert.Equal(AzureStorageType.AzureFiles, result.Type);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void NullAzureStorageTypeDeserializesToNull()
        {
            var json = "{\"type\":null,\"accountName\":\"test\"}";

            var result = JsonConvert.DeserializeObject<AzureStorageInfoValue>(json, CreateSettings());

            Assert.NotNull(result);
            Assert.Null(result.Type);
        }
    }
}
