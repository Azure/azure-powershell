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

using Microsoft.Security.Utilities;
using System.Collections.Generic;
using System.Linq;

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

        private readonly SecretMasker _secretMasker = new SecretMasker(WellKnownRegexPatterns.HighConfidenceMicrosoftSecurityModels, generateCorrelatingIds: true);

        public bool TrySanitizeData(string data, out string sanitizedData)
        {
            sanitizedData = string.Empty;

            if (!string.IsNullOrWhiteSpace(data))
            {
                var detections = _secretMasker.DetectSecrets(data);
                return detections.Any();
            }

            return false;
        }
    }
}
