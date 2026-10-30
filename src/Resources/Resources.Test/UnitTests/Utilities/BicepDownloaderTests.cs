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
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using FluentAssertions;
using Microsoft.Azure.Commands.ResourceManager.Cmdlets.Utilities;
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using Newtonsoft.Json;
using Xunit;

namespace Microsoft.Azure.Commands.Resources.Test.UnitTests.Utilities
{
    /// <summary>
    /// A minimal <see cref="HttpMessageHandler"/> that returns a canned response (or throws, to
    /// simulate a network failure) for every request, without making any real network call.
    /// </summary>
    internal class FakeHttpMessageHandler : HttpMessageHandler
    {
        private readonly HttpStatusCode statusCode;
        private readonly string content;
        private readonly byte[] byteContent;
        private readonly Exception exceptionToThrow;

        public string LastRequestUri { get; private set; }

        public static FakeHttpMessageHandler ReturningString(string content, HttpStatusCode statusCode = HttpStatusCode.OK)
            => new FakeHttpMessageHandler(statusCode, content, null, null);

        public static FakeHttpMessageHandler ReturningBytes(byte[] content, HttpStatusCode statusCode = HttpStatusCode.OK)
            => new FakeHttpMessageHandler(statusCode, null, content, null);

        public static FakeHttpMessageHandler Throwing(Exception exception)
            => new FakeHttpMessageHandler(HttpStatusCode.OK, null, null, exception);

        private FakeHttpMessageHandler(HttpStatusCode statusCode, string content, byte[] byteContent, Exception exceptionToThrow)
        {
            this.statusCode = statusCode;
            this.content = content;
            this.byteContent = byteContent;
            this.exceptionToThrow = exceptionToThrow;
        }

        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            LastRequestUri = request.RequestUri.ToString();

            if (exceptionToThrow != null)
            {
                throw exceptionToThrow;
            }

            var response = new HttpResponseMessage(statusCode)
            {
                Content = byteContent != null ? new ByteArrayContent(byteContent) : new StringContent(content ?? string.Empty)
            };

            return Task.FromResult(response);
        }
    }

    public class BicepDownloaderTests
    {
        private static BicepDownloader CreateDownloader(FakeHttpMessageHandler handler)
            => new BicepDownloader(new HttpClient(handler));

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void GetLatestReleaseTag_parses_tag_name_from_response()
        {
            var handler = FakeHttpMessageHandler.ReturningString(JsonConvert.SerializeObject(new { tag_name = "v0.26.54" }));
            var downloader = CreateDownloader(handler);

            var tag = downloader.GetLatestReleaseTag();

            tag.Should().Be("v0.26.54");
            handler.LastRequestUri.Should().Be("https://downloads.bicep.azure.com/releases/latest");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void GetLatestReleaseTag_returns_null_when_tag_name_is_missing()
        {
            var handler = FakeHttpMessageHandler.ReturningString(JsonConvert.SerializeObject(new { some_other_field = "x" }));
            var downloader = CreateDownloader(handler);

            downloader.GetLatestReleaseTag().Should().BeNull();
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void GetLatestReleaseTag_throws_for_malformed_json()
        {
            var handler = FakeHttpMessageHandler.ReturningString("not valid json");
            var downloader = CreateDownloader(handler);

            Assert.ThrowsAny<JsonException>(() => downloader.GetLatestReleaseTag());
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void GetLatestReleaseTag_throws_for_network_failure()
        {
            var handler = FakeHttpMessageHandler.Throwing(new HttpRequestException("network down"));
            var downloader = CreateDownloader(handler);

            Assert.Throws<HttpRequestException>(() => downloader.GetLatestReleaseTag());
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void GetLatestReleaseTag_throws_for_non_success_status_code()
        {
            var handler = FakeHttpMessageHandler.ReturningString("not found", HttpStatusCode.NotFound);
            var downloader = CreateDownloader(handler);

            Assert.Throws<HttpRequestException>(() => downloader.GetLatestReleaseTag());
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void GetAvailableReleaseTags_parses_all_tag_names_from_response()
        {
            var handler = FakeHttpMessageHandler.ReturningString(JsonConvert.SerializeObject(new[]
            {
                new { tag_name = "v0.26.54" },
                new { tag_name = "v0.26.53" },
                new { tag_name = "v0.26.52" },
            }));
            var downloader = CreateDownloader(handler);

            var tags = downloader.GetAvailableReleaseTags();

            tags.Should().Equal("v0.26.54", "v0.26.53", "v0.26.52");
            handler.LastRequestUri.Should().Be("https://downloads.bicep.azure.com/releases");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void GetAvailableReleaseTags_skips_entries_with_missing_or_empty_tag_name()
        {
            var handler = FakeHttpMessageHandler.ReturningString(JsonConvert.SerializeObject(new object[]
            {
                new { tag_name = "v0.26.54" },
                new { tag_name = "" },
                new { some_other_field = "x" },
                new { tag_name = "v0.26.52" },
            }));
            var downloader = CreateDownloader(handler);

            var tags = downloader.GetAvailableReleaseTags();

            tags.Should().Equal("v0.26.54", "v0.26.52");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void GetAvailableReleaseTags_returns_empty_list_for_empty_array()
        {
            var handler = FakeHttpMessageHandler.ReturningString("[]");
            var downloader = CreateDownloader(handler);

            downloader.GetAvailableReleaseTags().Should().BeEmpty();
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void GetAvailableReleaseTags_throws_for_malformed_json()
        {
            var handler = FakeHttpMessageHandler.ReturningString("{ not an array }");
            var downloader = CreateDownloader(handler);

            Assert.ThrowsAny<JsonException>(() => downloader.GetAvailableReleaseTags());
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void DownloadFile_returns_raw_bytes()
        {
            var expectedBytes = new byte[] { 1, 2, 3, 4, 5 };
            var handler = FakeHttpMessageHandler.ReturningBytes(expectedBytes);
            var downloader = CreateDownloader(handler);

            var bytes = downloader.DownloadFile("https://downloads.bicep.azure.com/v0.26.54/bicep-win-x64.exe");

            bytes.Should().Equal(expectedBytes);
            handler.LastRequestUri.Should().Be("https://downloads.bicep.azure.com/v0.26.54/bicep-win-x64.exe");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void DownloadFile_throws_for_non_success_status_code()
        {
            var handler = FakeHttpMessageHandler.ReturningString("not found", HttpStatusCode.NotFound);
            var downloader = CreateDownloader(handler);

            Assert.Throws<HttpRequestException>(() => downloader.DownloadFile("https://downloads.bicep.azure.com/v9.9.9/bicep-win-x64.exe"));
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void DownloadFile_throws_for_network_failure()
        {
            var handler = FakeHttpMessageHandler.Throwing(new HttpRequestException("network down"));
            var downloader = CreateDownloader(handler);

            Assert.Throws<HttpRequestException>(() => downloader.DownloadFile("https://downloads.bicep.azure.com/v0.26.54/bicep-win-x64.exe"));
        }
    }
}
