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
using System.Collections.Specialized;
using System.Text;

namespace Microsoft.Azure.Commands.StorageSync.Common.Extensions
{
    /// <summary>
    /// Uri extensions class
    /// </summary>
    public static class UriExtensions
    {
        public const string QueryStringSeparator = "&";

        public static Uri AddQuery(this Uri uri, NameValueCollection nameValueCollection)
        {
            if (uri == null || nameValueCollection == null || nameValueCollection.Count == 0)
            {
                return uri;
            }

            var uriBuilder = new UriBuilder(uri);
            var queryStringToAppend = nameValueCollection.ToQuery();

            if (!string.IsNullOrEmpty(queryStringToAppend))
            {
                // Uri already has query string
                if (!string.IsNullOrEmpty(uriBuilder.Query))
                {
                    queryStringToAppend = QueryStringSeparator + queryStringToAppend;
                }

                uriBuilder.Query += queryStringToAppend;
            }

            return uriBuilder.Uri;
        }
        public static string ToQuery(this NameValueCollection nameValueCollection, string keyValueSeparator = UriExtensions.QueryStringSeparator)
        {
            var queryStringBuilder = new StringBuilder();

            foreach (string key in nameValueCollection.Keys)
            {
                if (string.IsNullOrEmpty(key)) continue;

                string[] values = nameValueCollection.GetValues(key);
                if (values == null) continue;

                foreach (string value in values)
                {
                    queryStringBuilder.Append(queryStringBuilder.Length == 0 ? string.Empty : keyValueSeparator);
                    queryStringBuilder.AppendFormat("{0}={1}", Uri.EscapeDataString(key), Uri.EscapeDataString(value));
                }
            }

            return queryStringBuilder.ToString();
        }
    }
}
