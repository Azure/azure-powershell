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

using System.Runtime.InteropServices;
using System.Text.RegularExpressions;
using FluentAssertions;
using Microsoft.Azure.Commands.ResourceManager.Cmdlets.Utilities;
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using Xunit;

namespace Microsoft.Azure.Commands.Resources.Test.UnitTests.Utilities
{
    /// <summary>
    /// Exercises <see cref="BicepDownloader"/> against the real "downloads.bicep.azure.com" CDN
    /// (no fakes/mocks). Requires outbound internet access, so these are excluded from the default
    /// run via the "LiveOnly" trait; run explicitly before a release/PR with:
    ///   dotnet test --filter "FullyQualifiedName~BicepDownloaderLiveTests"
    /// Complements <see cref="BicepDownloaderTests"/> (parsing logic in isolation) by proving the
    /// real CDN endpoints/response shapes/asset naming still match what BicepInstaller expects.
    /// </summary>
    public class BicepDownloaderLiveTests
    {
        // e.g. "v0.30.1" - matches the "vX.Y.Z" tag format BicepInstaller expects to parse with
        // BicepSemanticVersion.TryParse after stripping the leading 'v'.
        private static readonly Regex ReleaseTagPattern = new Regex(@"^v\d+\.\d+\.\d+$");

        [Fact]
        [Trait(Category.AcceptanceType, Category.LiveOnly)]
        public void GetLatestReleaseTag_returns_a_well_formed_tag_from_the_real_CDN()
        {
            var downloader = new BicepDownloader();

            var tag = downloader.GetLatestReleaseTag();

            tag.Should().NotBeNullOrEmpty();
            tag.Should().MatchRegex(ReleaseTagPattern.ToString());
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.LiveOnly)]
        public void GetAvailableReleaseTags_returns_a_non_empty_list_of_well_formed_tags_from_the_real_CDN()
        {
            var downloader = new BicepDownloader();

            var tags = downloader.GetAvailableReleaseTags();

            tags.Should().NotBeEmpty();
            foreach (var tag in tags)
            {
                tag.Should().MatchRegex(ReleaseTagPattern.ToString());
            }
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.LiveOnly)]
        public void DownloadFile_downloads_the_latest_release_asset_for_the_current_platform_from_the_real_CDN()
        {
            var downloader = new BicepDownloader();

            var latestTag = downloader.GetLatestReleaseTag();
            latestTag.Should().NotBeNullOrEmpty("a release tag is needed to build the asset download URL");

            var platform = GetCurrentPlatformAssetSuffix();
            var extension = RuntimeInformation.IsOSPlatform(OSPlatform.Windows) ? ".exe" : string.Empty;
            var downloadUrl = $"https://downloads.bicep.azure.com/{latestTag}/bicep-{platform}{extension}";

            var fileContents = downloader.DownloadFile(downloadUrl);

            // A real Bicep executable is several MB; a tiny/empty payload would indicate the CDN
            // path/asset-naming convention BicepInstaller relies on has changed.
            fileContents.Should().NotBeNull();
            fileContents.Length.Should().BeGreaterThan(1_000_000);
        }

        /// <summary>
        /// Independently reimplements BicepInstaller.GetTargetPlatform's asset-suffix convention,
        /// so this test can exercise a real asset URL without depending on that private method.
        /// </summary>
        private static string GetCurrentPlatformAssetSuffix()
        {
            var isArm64 = RuntimeInformation.ProcessArchitecture == Architecture.Arm64;

            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
                return isArm64 ? "win-arm64" : "win-x64";
            }

            if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
            {
                return isArm64 ? "osx-arm64" : "osx-x64";
            }

            // Linux: default to glibc x64, matching BicepInstaller's non-Arm64, non-musl default.
            return isArm64 ? "linux-arm64" : "linux-x64";
        }
    }
}
