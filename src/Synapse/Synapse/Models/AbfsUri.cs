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

using Microsoft.Azure.Commands.Common.Exceptions;
using System;
using System.Text.RegularExpressions;

namespace Microsoft.Azure.Commands.Synapse.Models
{
    public sealed class AbfsUri : AzureStorageUri
    {
        public static readonly string AdlsGen2PathRegex = "^(?<schema>abfss?)://(?<fileSystem>[^/.\\s]+)@(?<accountName>[^/.\\s]+)(\\.)(dfs)(\\.)(?<storageEndpointSuffix>[^/\\s]+)(?<relativePath>(/[-a-zA-Z0-9.~_@:!$'()*+,;=%]+)*/?)$";
        public static readonly string AdlsGen2RestfulPathRegex = "^(?<schema>https?)://(?<accountName>[^/.\\s]+)(\\.)(dfs|blob)(\\.)(?<storageEndpointSuffix>[^/\\s]+)(/)(?<fileSystem>[^/.\\s]+)(?<relativePath>(/[-a-zA-Z0-9.~_@:!$'()*+,;=%]+)*/?)$";
        public static readonly Regex AbfsUriPattern = new Regex(AdlsGen2PathRegex, RegexOptions.IgnoreCase | RegexOptions.Compiled);
        public static readonly Regex HttpUriPattern = new Regex(AdlsGen2RestfulPathRegex, RegexOptions.IgnoreCase | RegexOptions.Compiled);

        public string FileSystem { get; private set; }

        public  string AccountName { get; private set; }

        private AbfsUri(Uri rawUri) : base(rawUri)
        {
        }

        public override Uri GetUri()
        {
            string schema = Schema;
            if (schema.Equals("http", StringComparison.OrdinalIgnoreCase))
            {
                schema = "abfs";
            }
            else if (schema.Equals("https", StringComparison.OrdinalIgnoreCase))
            {
                schema = "abfss";
            }

            return new Uri(string.Format("{0}://{1}@{2}.dfs.{3}{4}",
                    schema, FileSystem, AccountName, StorageEndpointSuffix, RelativePath));
        }

        public static AbfsUri Parse(string rawUri)
        {
            Match matcher;
            if (rawUri.StartsWith("abfs", StringComparison.OrdinalIgnoreCase))
            {
                matcher = AbfsUriPattern.Match(rawUri);
            } 
            else if (rawUri.StartsWith("http", StringComparison.OrdinalIgnoreCase))
            {
                matcher = HttpUriPattern.Match(rawUri);
            }
            else 
            {
                throw new AzPSInvalidOperationException("Unsupported ADLS Gen2 Uri Scheme: " + rawUri);
            }

            if (matcher.Success) 
            {
                AbfsUri abfsUri = new AbfsUri(new Uri(rawUri));
                abfsUri.Schema = matcher.Groups["schema"].Value;
                abfsUri.AccountName = matcher.Groups["accountName"].Value;
                abfsUri.FileSystem = matcher.Groups["fileSystem"].Value;
                abfsUri.StorageEndpointSuffix = matcher.Groups["storageEndpointSuffix"].Value;
                abfsUri.RelativePath = matcher.Groups["relativePath"].Value;
                return abfsUri;
            }

            throw new AzPSInvalidOperationException("Unmatched ADLS Gen2 Uri: " + rawUri);
        }

        public static bool IsType(string uri)
        {
            return uri != null && (AbfsUriPattern.IsMatch(uri) || HttpUriPattern.IsMatch(uri));
        }
    }
}
