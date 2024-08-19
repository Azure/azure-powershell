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

using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Microsoft.Azure.Commands.Common.Authentication.Sanitizer.Services
{
    internal class DefaultSanitizerService : ISanitizerService
    {
        public IReadOnlyDictionary<string, IEnumerable<string>> IgnoredProperties => new Dictionary<string, IEnumerable<string>>()
        {
            /*
             * This dictionary is used to store the properties that should be ignored during sanitization.
             * The key is the full name of the object type that contains the properties to be ignored.
             * The value is the list of property names that should be ignored.
             */

            // Skip lazy load properties
            { "Microsoft.Azure.Commands.Management.Storage.Models.PSStorageAccount", new[] { "Context" } },
            { "Microsoft.WindowsAzure.Commands.Common.Storage.ResourceModel.AzureStorageContainer", new[] { "CloudBlobContainer", "Permission" } },
            { "Microsoft.WindowsAzure.Commands.Common.Storage.ResourceModel.AzureStorageBlob", new[] { "BlobProperties" } },
            { "Microsoft.WindowsAzure.Commands.Common.Storage.ResourceModel.AzureStorageFile", new[] { "FileProperties" } },
            { "Microsoft.WindowsAzure.Commands.Common.Storage.ResourceModel.AzureStorageFileShare", new[] { "ShareProperties" } },
            { "Microsoft.WindowsAzure.Commands.Common.Storage.ResourceModel.AzureStorageFileDirectory", new[] { "ShareDirectoryProperties" } },

            // Skip large properties
            { "Microsoft.Azure.Storage.Blob.CloudBlob", new[] { "ICloudBlob" } },
            { "Microsoft.Azure.Storage.File.CloudFile", new[] { "CloudFile" } },

            // Skip infinite recursion properties
            { "Microsoft.Azure.Storage.Blob.CloudBlobDirectory", new[] { "Parent" } },
            { "Microsoft.Azure.Storage.File.CloudFileDirectory", new[] { "Parent" } },
        };

        private static readonly IEnumerable<string> SensitiveDataPatterns = new List<string>()
        {
            // AAD client app, most recent two versions.
            @"\b" // pre-match
          + @"[0-9A-Za-z-_~.]{3}7Q~[0-9A-Za-z-_~.]{31}\b|\b[0-9A-Za-z-_~.]{3}8Q~[0-9A-Za-z-_~.]{34}" // match
          + @"\b", // post-match
            
            // Prominent Azure provider 512-bit symmetric keys.
            @"\b" // pre-match
          + @"[0-9A-Za-z+/]{76}(APIM|ACDb|\+(ABa|AMC|ASt))[0-9A-Za-z+/]{5}[AQgw]==" // match
          + @"", // post-match

            // Prominent Azure provider 256-bit symmetric keys.
            @"\b" // pre-match
          + @"[0-9A-Za-z+/]{33}(AIoT|\+(ASb|AEh|ARm))[A-P][0-9A-Za-z+/]{5}=" // match
          + @"", // post-match
            
            // Azure Function key.
            @"\b" // pre-match
          + @"[0-9A-Za-z_\-]{44}AzFu[0-9A-Za-z\-_]{5}[AQgw]==" // match
          + @"", // post-match

            // Azure Search keys.
            @"\b" // pre-match
          + @"[0-9A-Za-z]{42}AzSe[A-D][0-9A-Za-z]{5}" // match
          + @"\b", // post-match
            
            // Azure Container Registry keys.
            @"\b" // pre-match
          + @"[0-9A-Za-z+/]{42}\+ACR[A-D][0-9A-Za-z+/]{5}" // match
          + @"\b", // post-match
            
            // Azure Cache for Redis keys.
            @"\b" // pre-match
          + @"[0-9A-Za-z]{33}AzCa[A-P][0-9A-Za-z]{5}=" // match
          + @"", // post-match
            
            // NuGet API keys.
            @"\b" // pre-match
          + @"oy2[a-p][0-9a-z]{15}[aq][0-9a-z]{11}[eu][bdfhjlnprtvxz357][a-p][0-9a-z]{11}[aeimquy4]" // match
          + @"\b", // post-match
            
            // NPM author keys.
            @"\b" // pre-match
          + @"npm_[0-9A-Za-z]{36}" // match
          + @"\b", // post-match
        };

        public bool TrySanitizeData(string data, out string sanitizedData)
        {
            sanitizedData = string.Empty;

            if (!string.IsNullOrWhiteSpace(data))
            {
                foreach (var pattern in SensitiveDataPatterns)
                {
                    if (Regex.IsMatch(data, pattern))
                    {
                        return true;
                    }
                }
            }

            return false;
        }
    }
}
