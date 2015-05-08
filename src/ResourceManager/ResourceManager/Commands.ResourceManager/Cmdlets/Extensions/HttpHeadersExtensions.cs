// ----------------------------------------------------------------------------------
//
// Copyright Microsoft Corporation
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// HTTP://www.apache.org/licenses/LICENSE-2.0
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// ----------------------------------------------------------------------------------

namespace Microsoft.Azure.Commands.ResourceManager.Cmdlets.Extensions
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net.Http.Headers;

    /// <summary>
    /// Http headers extensions.
    /// </summary>
    public static class HttpHeadersExtensions
    {
        /// <summary>
        /// Gets the first HTTP header or default value.
        /// </summary>
        /// <typeparam name="TType">The type of the object housed in the header.</typeparam>
        /// <param name="headers">The HTTP headers.</param>
        /// <param name="name">The header name.</param>
        /// <param name="transform">A transformation function that converts strings to <typeparamref name="TType"/>.</param>
        /// <param name="defaultValue">The default value.</param>
        public static TType GetFirstOrDefault<TType>(this HttpHeaders headers, string name, Func<string, TType> transform, TType defaultValue = default(TType))
        {
            IEnumerable<string> values;
            if (headers.TryGetValues(name, out values) && values.Any())
            {
                return transform(values.First());
            }

            return defaultValue;
        }

        /// <summary>
        /// Gets the azure async operation percent complete header.
        /// </summary>
        /// <param name="headers">The HTTP response headers.</param>
        public static double? GetAzureAzyncOperationPercentComplete(this HttpResponseHeaders headers)
        {
            return headers.GetFirstOrDefault(
                "Azure-AsyncOperationPercentComplete",
                (value) =>
                {
                    double percentComplete;
                    if (double.TryParse(value, out percentComplete))
                    {
                        return (double?)percentComplete;
                    }

                    return null;
                });
        }

        /// <summary>
        /// Gets the azure async operation header.
        /// </summary>
        /// <param name="headers">The HTTP response headers.</param>
        public static Uri GetAzureAsyncOperation(this HttpResponseHeaders headers)
        {
            return headers.GetFirstOrDefault("Azure-AsyncOperation", value =>
            {
                Uri uri;
                if (Uri.TryCreate(value, UriKind.Absolute, out uri))
                {
                    return uri;
                }
                return null;
            });
        }
    }
}
