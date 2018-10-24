// --------------------------------------------------------------------------------------------------------------------
// <copyright file="UriExtensions.cs" company="Microsoft">
//   Copyright (c) Microsoft Corporation. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

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
