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

namespace Microsoft.Azure.Commands.ResourceManager.Cmdlets.Utilities
{
    using Newtonsoft.Json.Linq;
    using System;
    using System.Collections.Generic;
    using System.Net.Http;

    public interface IBicepDownloader
    {
        /// <summary>
        /// Resolves the tag name (e.g. "v0.26.54") of the latest published Bicep release.
        /// </summary>
        string GetLatestReleaseTag();

        /// <summary>
        /// Resolves the tag names (e.g. "v0.26.54") of all published Bicep releases, newest first,
        /// so that a specific version satisfying a 'bicep.version' constraint can be selected.
        /// </summary>
        IReadOnlyList<string> GetAvailableReleaseTags();

        /// <summary>
        /// Downloads the file at the given URL and returns its raw contents.
        /// </summary>
        byte[] DownloadFile(string url);
    }

    public class BicepDownloader : IBicepDownloader
    {
        // Bicep's official, purpose-built distribution endpoint (also used by the official
        // "bicep-deploy" GitHub Action/ADO task). Unlike the raw GitHub API, this requires no
        // User-Agent header, isn't subject to GitHub's unauthenticated rate limits, and returns
        // the releases list in a single, non-paginated response.
        private const string DownloadBaseUrl = "https://downloads.bicep.azure.com";

        private const string LatestReleaseUrl = DownloadBaseUrl + "/releases/latest";

        private const string ReleasesListUrl = DownloadBaseUrl + "/releases";

        private static IBicepDownloader Instance = null;

        /// <summary>
        /// This hook can be used by the test framework to provide a mock IBicepDownloader instance,
        /// so that tests do not depend on real network access.
        /// </summary>
        /// <param name="instance">The downloader instance</param>
        public static void InitializeWithMock(IBicepDownloader instance)
            => Instance = instance;

        public static IBicepDownloader Create()
            => Instance ?? new BicepDownloader();

        private readonly HttpClient httpClient;

        public BicepDownloader()
            : this(new HttpClient())
        {
        }

        /// <summary>
        /// Lets tests inject an <see cref="HttpClient"/> backed by a fake handler, so they can
        /// exercise the real parsing logic without hitting the network.
        /// </summary>
        internal BicepDownloader(HttpClient httpClient)
        {
            this.httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
        }

        public string GetLatestReleaseTag()
        {
            var response = httpClient.GetStringAsync(LatestReleaseUrl).GetAwaiter().GetResult();
            var json = JObject.Parse(response);
            return json["tag_name"]?.ToString();
        }

        public IReadOnlyList<string> GetAvailableReleaseTags()
        {
            var response = httpClient.GetStringAsync(ReleasesListUrl).GetAwaiter().GetResult();
            var releases = JArray.Parse(response);

            var tags = new List<string>();
            foreach (var release in releases)
            {
                var tag = release["tag_name"]?.ToString();
                if (!string.IsNullOrEmpty(tag))
                {
                    tags.Add(tag);
                }
            }

            return tags;
        }

        public byte[] DownloadFile(string url)
        {
            return httpClient.GetByteArrayAsync(url).GetAwaiter().GetResult();
        }
    }
}
