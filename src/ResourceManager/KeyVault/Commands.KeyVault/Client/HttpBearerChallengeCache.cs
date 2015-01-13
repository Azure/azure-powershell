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
using System.Collections.Generic;

namespace Microsoft.Azure.Commands.KeyVault.Client.Authentication
{
    /// <summary>
    /// Cache of Bearer challenges based on URL of the target service.
    /// </summary>
    /// <remarks>
    /// This class is more than a simple map of URL to challenge, it contains
    /// internal logic to derive the correct key for the challenge from the URL.
    /// </remarks>
    public sealed class HttpBearerChallengeCache
    {
        private static HttpBearerChallengeCache _instance = new HttpBearerChallengeCache();

        public static HttpBearerChallengeCache GetInstance()
        {
            return _instance;
        }

        private Dictionary<string, HttpBearerChallenge> _cache     = null;
        private object                                  _cacheLock = null;

        private HttpBearerChallengeCache()
        {
            _cache = new Dictionary<string, HttpBearerChallenge>();
            _cacheLock = new object();
        }

        public HttpBearerChallenge GetChallengeForURL(Uri url)
        {
            if (url == null)
                throw new ArgumentNullException("url");

            HttpBearerChallenge value = null;

            lock (_cacheLock)
            {
                _cache.TryGetValue(url.FullAuthority(), out value);
            }

            return value;
        }

        public void RemoveChallengeForURL(Uri url)
        {
            if (url == null)
                throw new ArgumentNullException("url");

            lock (_cacheLock)
            {
                _cache.Remove(url.FullAuthority());
            }
        }

        public void SetChallengeForURL(Uri url, HttpBearerChallenge value)
        {
            if (url == null)
                throw new ArgumentNullException("url");

            if (value == null)
                throw new ArgumentNullException("value");

            if (string.Compare(url.FullAuthority(), value.SourceAuthority, StringComparison.OrdinalIgnoreCase) != 0)
                throw new ArgumentException("Source URL and Challenge URL do not match");

            lock (_cacheLock)
            {
                _cache[url.FullAuthority()] = value;
            }
        }

        public void Clear()
        {
            lock (_cacheLock)
            {
                _cache.Clear();
            }
        }
    }
}
